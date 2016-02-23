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
    /// 景点编辑
    /// </summary>
    public partial class JingDianEdit : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 景点编号
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

        protected string JingDianQuYuId = "";
        protected string JingDianYongHuId = "0";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");

            InitPrivs();
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitWuc();
            InitInfo();
            InitJingDianYongHu();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_景点管理_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_景点管理_修改);

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

            var info = new EyouSoft.BLL.PtStructure.BJingDian().GetInfo(EditId);
            if (info == null) RCWE("异常请求");

            txtMingCheng.Value = info.MingCheng;
            JingDianQuYuId = info.QuYuId.ToString();
            txtJieShao.Value = info.JieShao;
            txtPaiXuId.Value = info.PaiXuId.ToString();
            JingDianYongHuId = info.JingDianYongHuId.ToString();
            txtDiZhi.Value = info.DiZhi;

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
        EyouSoft.Model.PtStructure.MJingDianInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MJingDianInfo();

            info.CompanyId = CurrentUserCompanyID;
            info.FuJians = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            info.IssueTime = DateTime.Now;
            info.JieShao = Utils.GetFormEditorValue(txtJieShao.UniqueID);
            info.JingDianId = EditId;
            info.MingCheng = Utils.GetFormValue(txtMingCheng.UniqueID);
            info.OperatorId = SiteUserInfo.UserId;
            info.QuYuId = Utils.GetInt(Utils.GetFormValue("txtJingDianQuYu"));
            info.PaiXuId = Utils.GetInt(Utils.GetFormValue(txtPaiXuId.UniqueID));
            info.JingDianYongHuId = Utils.GetInt(Utils.GetFormValue("txtJingDianYongHu"));
            info.DiZhi = Utils.GetFormValue(txtDiZhi.UniqueID);

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

            if (!string.IsNullOrEmpty(info.JingDianId) && SiteUserInfo.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户)
            {
                var yuanJingDianInfo = new EyouSoft.BLL.PtStructure.BJingDian().GetInfo(info.JingDianId);
                if (yuanJingDianInfo != null)
                {
                    info.JingDianYongHuId = yuanJingDianInfo.JingDianYongHuId;
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

            if (string.IsNullOrEmpty(info.JingDianId))
            {
                if (!Privs_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.JingDianId))
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BJingDian().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BJingDian().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init jingdianyonghu
        /// </summary>
        void InitJingDianYongHu()
        {
            if (SiteUserInfo.LeiXing != EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.专线用户) return;

            phJingDianYongHu.Visible = true;
            var chaXun = new EyouSoft.Model.CompanyStructure.QueryCompanyUser();
            chaXun.LeiXing = EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户;
            chaXun.ZxsId = CurrentZxsId;

            var items = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetList(CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                StringBuilder s = new StringBuilder();
                foreach (var item in items)
                {
                    s.AppendFormat(" <option value=\"{0}\">{1}-{2}</option> ", item.ID, item.PersonInfo.ContactName, item.UserName);
                }
                ltrJingDianYongHu.Text = s.ToString();
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// get jingdian quyu
        /// </summary>
        protected string GetJingDianQuYu()
        {
            StringBuilder s = new StringBuilder();
            var items = new EyouSoft.BLL.PtStructure.BJingDian().GetJingDianQuYus(CurrentUserCompanyID);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.QuYuId, item.MingCheng);
                }
            }
            return s.ToString();
        }
        #endregion
    }
}
