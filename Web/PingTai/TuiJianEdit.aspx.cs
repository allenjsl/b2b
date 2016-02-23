using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Web.UserControl;

namespace Web.PingTai
{
    /// <summary>
    /// 平台推荐编辑
    /// </summary>
    public partial class TuiJianEdit : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 推荐编号
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
        /// 推荐状态
        /// </summary>
        protected EyouSoft.Model.EnumType.PtStructure.TuiJianStatus TuiJianStatus = EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.正常;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");

            InitPrivs();
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitWuc();
            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_平台推荐_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_平台推荐_修改);

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

            var info = new EyouSoft.BLL.PtStructure.BTuiJian().GetInfo(EditId);
            if (info == null) RCWE("异常请求");

            txtBiaoTi.Value = info.BiaoTi;
            txtNeiRong.Value = info.NeiRong;
            txtPaiXuId.Value = info.PaiXuId.ToString();
            txtJianYaoJieShao.Value = info.JianYaoJieShao;
            TuiJianStatus = info.Status;

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
        EyouSoft.Model.PtStructure.MTuiJianInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MTuiJianInfo();

            info.BiaoTi = Utils.GetFormValue(txtBiaoTi.UniqueID);
            info.CompanyId = CurrentUserCompanyID;
            info.IssueTime = DateTime.Now;
            info.NeiRong = Utils.GetFormEditorValue(txtNeiRong.UniqueID);
            info.OperatorId = SiteUserInfo.UserId;
            info.PaiXuId = Utils.GetInt(Utils.GetFormValue(txtPaiXuId.UniqueID));
            info.TuiJianId = EditId;
            info.JianYaoJieShao = Utils.GetFormValue(txtJianYaoJieShao.UniqueID);
            info.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.TuiJianStatus>(Utils.GetFormValue("txtStatus"), EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.正常);

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

            if (string.IsNullOrEmpty(info.TuiJianId))
            {
                if (!Privs_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.TuiJianId))
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BTuiJian().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BTuiJian().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
