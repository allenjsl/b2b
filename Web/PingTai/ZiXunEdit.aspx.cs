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
    /// 资讯编辑
    /// </summary>
    public partial class ZiXunEdit : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 资讯编号
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
        /// <summary>
        /// 资讯类型
        /// </summary>
        protected string LeiXing = string.Empty;
        /// <summary>
        /// 资讯状态
        /// </summary>
        protected EyouSoft.Model.EnumType.PtStructure.ZiXunStatus ZiXunStatus = EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常;
        /// <summary>
        /// 站点编号
        /// </summary>
        protected string ZhanDianId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");

            InitPrivs();
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();
            InitWuc();
            InitInfo();

            InitZhanDain();
        }

        #region private members
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
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_旅游资讯_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_旅游资讯_修改);

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
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(EditId)) return;

            var info = new EyouSoft.BLL.PtStructure.BZiXun().GetInfo(EditId);
            if (info == null) RCWE("异常请求");

            txtBiaoTi.Value = info.BiaoTi;
            txtNeiRong.Value = info.NeiRong;
            LeiXing = ((int)info.LeiXing).ToString();
            txtJianYaoJieShao.Value = info.JianYaoJieShao;
            ZiXunStatus = info.Status;

            if (info.ZhanDianId > 0) ZhanDianId = info.ZhanDianId.ToString();

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
        EyouSoft.Model.PtStructure.MZiXunInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MZiXunInfo();

            info.BiaoTi = Utils.GetFormValue(txtBiaoTi.UniqueID);
            info.CompanyId = CurrentUserCompanyID;
            info.IssueTime = DateTime.Now;
            info.LeiXing = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing>(Utils.GetFormValue("txtLeiXing"), EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing.平台资讯);
            info.NeiRong = Utils.GetFormEditorValue(txtNeiRong.UniqueID);
            info.OperatorId = SiteUserInfo.UserId;
            info.ZiXunId = EditId;
            info.JianYaoJieShao = Utils.GetFormValue(txtJianYaoJieShao.UniqueID);
            info.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.ZiXunStatus>(Utils.GetFormValue("txtStatus"), EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常);
            info.ZhanDianId = Utils.GetInt(Utils.GetFormValue("txtZhanDian"));

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

            info.FuJians = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
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

            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();

            if (string.IsNullOrEmpty(info.ZiXunId))
            {
                if (!Privs_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.ZiXunId))
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BZiXun().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BZiXun().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init zhandain
        /// </summary>
        void InitZhanDain()
        {
            StringBuilder s = new StringBuilder();

            var chaXun = new EyouSoft.Model.PtStructure.MZhanDianChaXunInfo();
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZhanDians(CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</options>", item.ZhanDianId, item.MingCheng);
                }
            }

            ltrZhanDianOption.Text = s.ToString();
        }
        #endregion
    }
}
