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
    /// 积分兑换商品编辑
    /// </summary>
    public partial class JiFenShangPinEdit : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 商品编号
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

        protected string SPLeiXing = "";
        protected string SPStatus = "";
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
            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换商品管理_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换商品管理_修改);

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

            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetShangPinInfo(EditId);
            if (info == null) RCWE("异常请求");

            txtMingCheng.Value = info.MingCheng;
            txtJiaGe.Value = info.JiaGe.ToString("F2");
            SPLeiXing = ((int)info.LeiXing).ToString();
            SPStatus = ((int)info.Status).ToString();
            txtJiFen.Value = info.JiFen.ToString();
            txtJieShao.Value = info.MiaoShu;
            txtPeiSongShuoMing.Value = info.PeiSongShuoMing;
            txtDuiHuanXuZhi.Value = info.DuiHuanXuZhi;

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
        EyouSoft.Model.PtStructure.MJiFenShangPinInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MJiFenShangPinInfo();

            info.BianMa = string.Empty;
            info.CompanyId = CurrentUserCompanyID;
            info.DuiHuanXuZhi = Utils.GetFormEditorValue(txtDuiHuanXuZhi.UniqueID);
            info.FengMian = string.Empty;
            info.FuJians = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            info.IssueTime = DateTime.Now;
            info.JiaGe = Utils.GetDecimal(Utils.GetFormValue(txtJiaGe.UniqueID));
            info.JiFen = Utils.GetInt(Utils.GetFormValue(txtJiFen.UniqueID));
            info.LeiXing = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing>(Utils.GetFormValue("txtLeiXing"), EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing.None);
            info.MiaoShu = Utils.GetFormEditorValue(txtJieShao.UniqueID);
            info.MingCheng = Utils.GetFormValue(txtMingCheng.UniqueID);
            info.OperatorId = SiteUserInfo.UserId;
            info.PeiSongShuoMing = Utils.GetFormEditorValue(txtPeiSongShuoMing.UniqueID);
            info.ShangPinId = EditId;
            info.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus>(Utils.GetFormValue("txtStatus"), EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus.上架);

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

            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();

            if (string.IsNullOrEmpty(info.ShangPinId))
            {
                if (!Privs_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.ShangPinId))
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().InsertShangPin(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().UpdateShangPin(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
