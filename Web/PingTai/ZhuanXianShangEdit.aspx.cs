using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Web.UserControl;
using System.Text;

namespace Web.PingTai
{
    public partial class ZhuanXianShangEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 专线商编号
        /// </summary>
        protected string EditId = string.Empty;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;
        /// <summary>
        /// 省份编号
        /// </summary>
        protected string ShengFenId=string.Empty;
        /// <summary>
        /// 城市编号
        /// </summary>
        protected string ChengShiId=string.Empty;
        /// <summary>
        /// zxs t2
        /// </summary>
        protected string T2 = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId =Utils.GetQueryStringValue("editid");
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "save") Save();

            InitWuc();
            InitInfo();
            InitZxlb();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_修改);

            if (string.IsNullOrEmpty(EditId))
            {
                if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
            else
            {
                if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(EditId))
            {
                return;
            }

            var info = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(EditId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));

            txtMingCheng.Value = info.MingCheng;
            txtZhuCeHao.Value = info.ZhuCeHao;
            txtShuiWuHao.Value = info.ShuiWuHao;
            txtXuKeZhengHao.Value = info.XuKeZhengHao;
            txtFaRenName.Value = info.FaRenName;
            txtLxrName.Value = info.LxrName;
            txtLxrDianHua.Value = info.LxrDianHua;
            txtLxrShouJi.Value = info.LxrShouJi;
            txtLxrQQ.Value = info.LxrQQ;
            txtFax.Value = info.Fax;
            txtDiZhi.Value = info.DiZhi;

            if (info.QQs != null && info.QQs.Count > 0)
            {
                rptQQ.DataSource = info.QQs;
                rptQQ.DataBind();

                phQQ.Visible = false;
            }

            txtLianXiFangShi.Value = info.LianXiFangShi;
            txtYinHangZhangHao.Value = info.YinHangZhangHao;
            txtJieShao.Value = info.JieShao;

            ShengFenId=info.ProvinceId.ToString();
            ChengShiId=info.CityId.ToString();
            T2 = ((int)info.T2).ToString();

            MFileInfo logoFile = new MFileInfo();
            logoFile.FilePath = info.Logo;
            var logoItems = new List<MFileInfo>();
            logoItems.Add(logoFile);
            UploadLogo.YuanFiles = logoItems;

            txtGuanLiYuanUsername.Value = info.GuanLiYuanUsername;
            txtPaiXuId.Value = info.PaiXuId.ToString();

            var script = string.Format("var zhanDians={0};", Newtonsoft.Json.JsonConvert.SerializeObject(info.ZhanDians));
            RegisterScript(script);

        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (string.IsNullOrEmpty(EditId))
            {
                if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            var info = GetFormInfo();

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(EditId ))
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BZhuanXianShang().InsertZhuanXianShang(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BZhuanXianShang().UpdateZhuanXianShang(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已经存在的用户名"));
            if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：所选中的专线类别已有其他供应商使用"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZhuanXianShangInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MZhuanXianShangInfo();

            info.CityId = Utils.GetInt(Utils.GetFormValue("txtChengShiId"));
            info.CompanyId = CurrentUserCompanyID;
            info.DiZhi = Utils.GetFormValue(txtDiZhi.UniqueID);
            info.FaRenName = Utils.GetFormValue(txtFaRenName.UniqueID);
            info.Fax = Utils.GetFormValue(txtFax.UniqueID);
            info.IssueTime = DateTime.Now;
            info.JieShao = Utils.GetFormEditorValue(txtJieShao.UniqueID);
            info.JiFenStatus = EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.启用;
            info.LianXiFangShi = Utils.GetFormEditorValue(txtLianXiFangShi.UniqueID);
            info.Logo = string.Empty;
            info.LxrDianHua = Utils.GetFormValue(txtLxrDianHua.UniqueID);
            info.LxrName = Utils.GetFormValue(txtLxrName.UniqueID);
            info.LxrQQ = Utils.GetFormValue(txtLxrQQ.UniqueID);
            info.LxrShouJi = Utils.GetFormValue(txtLxrShouJi.UniqueID);
            info.MingCheng = Utils.GetFormValue(txtMingCheng.UniqueID);
            info.OperatorId = SiteUserInfo.UserId;
            info.Privs1 = string.Empty;
            info.Privs2 = string.Empty;
            info.Privs3 = string.Empty;
            info.ProvinceId = Utils.GetInt(Utils.GetFormValue("txtShengFenId"));
            info.QQs = null;
            info.ShuiWuHao = Utils.GetFormValue(txtShuiWuHao.UniqueID);
            info.Status = EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus.启用;
            info.T1 = EyouSoft.Model.EnumType.PtStructure.ZxsT1.其它专线商;
            info.XuKeZhengHao = Utils.GetFormValue(txtXuKeZhengHao.UniqueID);
            info.YinHangZhangHao = Utils.GetFormEditorValue(txtYinHangZhangHao.UniqueID);
            info.ZhanDians = null;
            info.ZhuCeHao = Utils.GetFormValue(txtZhuCeHao.UniqueID);
            info.ZxsId = EditId;

            var logoFiles = UploadLogo.Files;
            if (logoFiles != null && logoFiles.Count > 0)
            {
                info.Logo = logoFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = UploadLogo.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    info.Logo = yuanFiles[0].FilePath;
                }
            }

            info.QQs = new List<EyouSoft.Model.PtStructure.MZhuanXianShangQQInfo>();

            string[] txtQQMiaoShu = Utils.GetFormValues("txtQQMiaoShu");
            string[] txtQQHaoMa = Utils.GetFormValues("txtQQHaoMa");
            int qqsLength = txtQQMiaoShu.Length;

            if (qqsLength == txtQQHaoMa.Length)
            {
                for (int i = 0; i < qqsLength; i++)
                {
                    if (string.IsNullOrEmpty(txtQQHaoMa[i])) continue;
                    var qqItem = new EyouSoft.Model.PtStructure.MZhuanXianShangQQInfo();
                    qqItem.MiaoShu = txtQQMiaoShu[i];
                    qqItem.QQ = txtQQHaoMa[i];
                    info.QQs.Add(qqItem);
                }
            }

            info.GuanLiYuanUsername = Utils.GetFormValue(txtGuanLiYuanUsername.UniqueID);
            string guanLiYunPwd = Utils.GetFormValue(txtGuanLiYunPwd.UniqueID);

            if (string.IsNullOrEmpty(EditId))
            {
                info.GuanLiYuanPassword = new EyouSoft.Model.CompanyStructure.PassWord(guanLiYunPwd);
            }
            else
            {
                if (!string.IsNullOrEmpty(guanLiYunPwd))
                {
                    info.GuanLiYuanPassword = new EyouSoft.Model.CompanyStructure.PassWord(guanLiYunPwd);
                }
            }

            info.ZhanDians = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<EyouSoft.Model.PtStructure.MZhuanXianShangZhanDianInfo>>(Utils.GetFormValue("txtZhanDian"));

            if (string.IsNullOrEmpty(info.LxrName)) info.LxrName = info.FaRenName;

            info.PaiXuId = Utils.GetInt(Utils.GetFormValue(txtPaiXuId.UniqueID));
            info.T2 = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.ZxsT2>(Utils.GetFormValue("txtT2"), EyouSoft.Model.EnumType.PtStructure.ZxsT2.默认);

            return info;
        }

        /// <summary>
        /// int web user control
        /// </summary>
        void InitWuc()
        {
            UploadLogo.CompanyID = CurrentUserCompanyID;
            UploadLogo.IsUploadSelf = true;
        }

        /// <summary>
        /// init zxlb
        /// </summary>
        void InitZxlb()
        {
            var zhanDians = new EyouSoft.BLL.PtStructure.BPt().GetZhanDians(CurrentUserCompanyID, null);
            if (zhanDians == null || zhanDians.Count == 0) return;

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<div>");
            int i = 0;
            foreach (var zhanDian in zhanDians)
            {
                var zxlbChaXun = new EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo();
                zxlbChaXun.ZhanDianId = zhanDian.ZhanDianId;
                zxlbChaXun.ShiYongShuLiangZxsId = EditId;
                var zxlbs = new EyouSoft.BLL.PtStructure.BPt().GetZhuanXianLeiBies(CurrentUserCompanyID, zxlbChaXun);
                if (zxlbs == null || zxlbs.Count == 0) continue;

                s.AppendFormat("<ul class=\"zxlbul1\">");
                s.AppendFormat("<li class=\"zxlbul1title\"><input type=\"checkbox\" name=\"chk_zhandian\" value=\"{0}\" id=\"chk_zhandian_{0}\"><label for=\"chk_chk_zhandian_{0}\">{1}</label></li>", zhanDian.ZhanDianId, zhanDian.MingCheng);
                foreach (var zxlb in zxlbs)
                {
                    string _disabled = " disabled=\"disabled\" ";
                    string _style = " style=\"color:#ff0000;\" ";
                    if (zxlb.ShiYongShuLiang == 0)
                    {
                        _disabled = ""; _style = "";
                    }

                    s.AppendFormat("<li class=\"zxlbul1item\"><input type=\"checkbox\" name=\"chk_zxlb\" value=\"{0}\" id=\"chk_zxlb_{0}\" {2}><label for=\"chk_zxlb_{0}\" {3}>{1}</label></li>", zxlb.ZxlbId, zxlb.MingCheng, _disabled, _style);
                }
                s.AppendFormat("</ul>");

                if (i % 3 == 2)
                {
                    s.Append("<ul class=\"zxlbul2\"><li></li></ul>");
                }
                i++;
            }

            s.Append("</div>");

            ltrZxlb.Text = s.ToString();
        }
        #endregion
    }
}
