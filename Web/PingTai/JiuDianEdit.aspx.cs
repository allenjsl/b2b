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
    /// <summary>
    /// 酒店编辑
    /// </summary>
    public partial class JiuDianEdit : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 酒店编号
        /// </summary>
        string EditId = string.Empty;
        /// <summary>
        /// 添加权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai = false;

        protected string ShengFenId = "";
        protected string ChengShiId = "";
        protected string XingJi = "";
        protected string JiuDianYongHuId = "0";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");

            InitPrivs();
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitWuc();
            InitInfo();
            InitJiuDianYongHu();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_修改);

            if (SiteUserInfo.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户)
            {
                Privs_TianJia = false;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                if (Privs_TianJia) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
            else
            {
                if (Privs_XiuGai) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
        }

        /// <summary>
        /// int web user control
        /// </summary>
        void InitWuc()
        {
            up_fengmian.CompanyID = up_fujian.CompanyID = CurrentUserCompanyID;
            up_fengmian.IsUploadSelf = up_fujian.IsUploadSelf = true;

            up_fujian.IsUploadMore = true;
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(EditId)) return;

            var info = new EyouSoft.BLL.PtStructure.BJiuDian().GetInfo(EditId);
            if (info == null) RCWE("异常请求");

            txtMingCheng.Value = info.MingCheng;
            ShengFenId = info.ProvinceId.ToString();
            ChengShiId = info.CityId.ToString();
            XingJi = ((int)info.XingJi).ToString();

            txtDiZhi.Value = info.DiZhi;
            txtKaiYeShiJian.Value = info.KaiYeShiJian;
            txtLouCengShuLiang.Value = info.LouCengShuLiang;
            txtZhuangXiuShiJian.Value = info.ZhuangXiuShiJian;
            txtDianHua.Value = info.DianHua;
            txtJiaoTong.Value = info.JiaoTong;
            txtWangLuo.Value = info.WangLuo;
            txtJieShao.Value = info.JianJie;

            JiuDianYongHuId = info.JiuDianYongHuId.ToString();
            txtPaiXuId.Value = info.PaiXuId.ToString();
            txtJianYaoJieShao.Value = info.JianYaoJieShao;

            MFileInfo fengMianFile = new MFileInfo();
            fengMianFile.FilePath = info.FengMian;
            var fengMianFiles = new List<MFileInfo>();
            fengMianFiles.Add(fengMianFile);
            up_fengmian.YuanFiles = fengMianFiles;

            var fuJianFiles = new List<MFileInfo>();
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    var fuJianFile = new MFileInfo();
                    fuJianFile.FilePath = item.Filepath;
                    fuJianFiles.Add(fuJianFile);
                }
            }
            up_fujian.YuanFiles = fuJianFiles;
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiuDianInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MJiuDianInfo();

            info.CityId = Utils.GetInt(Utils.GetFormValue("txtChengShi"));
            info.CompanyId = CurrentUserCompanyID;
            info.DianHua = Utils.GetFormValue(txtDianHua.UniqueID);
            info.DiZhi = Utils.GetFormValue(txtDiZhi.UniqueID);
            info.FangXings = null;
            info.FuJians = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            info.IssueTime = DateTime.Now;
            info.JianJie = Utils.GetFormEditorValue(txtJieShao.UniqueID);
            info.JiaoTong = Utils.GetFormEditorValue(txtJiaoTong.UniqueID);
            info.JiuDianId = EditId;
            info.KaiYeShiJian = Utils.GetFormValue(txtKaiYeShiJian.UniqueID);
            info.LouCengShuLiang = Utils.GetFormValue(txtLouCengShuLiang.UniqueID);
            info.MingCheng = Utils.GetFormValue(txtMingCheng.UniqueID);
            info.OperatorId = SiteUserInfo.UserId;
            info.ProvinceId = Utils.GetInt(Utils.GetFormValue("txtShengFen"));
            info.WangLuo = Utils.GetFormEditorValue(txtWangLuo.UniqueID);
            info.XingJi = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi>(Utils.GetFormValue("txtXingJi"), EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi.准三);
            info.ZhuangXiuShiJian = Utils.GetFormValue(txtZhuangXiuShiJian.UniqueID);
            info.JiuDianYongHuId = Utils.GetInt(Utils.GetFormValue("txtJiuDianYongHu"));
            info.PaiXuId = Utils.GetInt(Utils.GetFormValue(txtPaiXuId.UniqueID));
            info.JianYaoJieShao = Utils.GetFormValue(txtJianYaoJieShao.UniqueID);

            var fengMianFiles = up_fengmian.Files;
            if (fengMianFiles != null && fengMianFiles.Count > 0)
            {
                info.FengMian = fengMianFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = up_fengmian.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    info.FengMian = yuanFiles[0].FilePath;
                }
            }

            var tuPianFiles = up_fujian.Files;
            var yuanTuPianFiles = up_fujian.YuanFiles;

            if (tuPianFiles != null && tuPianFiles.Count > 0)
            {
                foreach (var item in tuPianFiles)
                {
                    var fuJian = new EyouSoft.Model.PtStructure.MFuJianInfo();

                    fuJian.Filepath = item.FilePath;

                    info.FuJians.Add(fuJian);
                }
            }

            if (yuanTuPianFiles != null && yuanTuPianFiles.Count > 0)
            {
                foreach (var item in yuanTuPianFiles)
                {
                    var fuJian = new EyouSoft.Model.PtStructure.MFuJianInfo();

                    fuJian.Filepath = item.FilePath;

                    info.FuJians.Add(fuJian);
                }
            }

            if (!string.IsNullOrEmpty(info.JiuDianId)&&SiteUserInfo.LeiXing== EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户)
            {
                var yuanJiuDianInfo = new EyouSoft.BLL.PtStructure.BJiuDian().GetInfo(info.JiuDianId);
                if (yuanJiuDianInfo != null)
                {
                    info.JiuDianYongHuId = yuanJiuDianInfo.JiuDianYongHuId;
                }
            }

            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();

            if (string.IsNullOrEmpty(info.JiuDianId))
            {
                if (!Privs_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.JiuDianId))
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BJiuDian().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BJiuDian().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init jiudianyonghu
        /// </summary>
        void InitJiuDianYongHu()
        {
            if (SiteUserInfo.LeiXing != EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.专线用户) return;

            phJiuDianYongHu.Visible = true;
            var chaXun = new EyouSoft.Model.CompanyStructure.QueryCompanyUser();
            chaXun.LeiXing = EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户;
            chaXun.ZxsId = CurrentZxsId;

            var items = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetList(CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                StringBuilder s = new StringBuilder();
                foreach (var item in items)
                {
                    s.AppendFormat(" <option value=\"{0}\">{1}-{2}</option> ", item.ID, item.PersonInfo.ContactName, item.UserName);
                }
                ltrJiuDianYongHu.Text = s.ToString();
            }
        }
        #endregion
    }
}
