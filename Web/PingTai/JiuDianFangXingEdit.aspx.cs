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
    /// 酒店房型编辑
    /// </summary>
    public partial class JiuDianFangXingEdit : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 房型编号
        /// </summary>
        string EditId = string.Empty;
        /// <summary>
        /// 酒店编号
        /// </summary>
        string JiuDianId = string.Empty;
        bool Privs_FangXingGuanLi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");
            JiuDianId = Utils.GetQueryStringValue("jiudianid");

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
            Privs_FangXingGuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_房型管理);

            if (Privs_FangXingGuanLi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有操作权限";
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

            var info = new EyouSoft.BLL.PtStructure.BJiuDian().GetFangXingInfo(EditId);
            if (info == null) RCWE("异常请求");

            txtMingCheng.Value = info.MingCheng;
            txtShuLiang.Value = info.ShuLiang;
            txtMianJi.Value = info.MianJi;
            txtLouCeng.Value = info.LouCeng;
            txtGuaPaiJiaGe.Value = info.GuaPaiJiaGe.ToString("F2");
            //txtChuangWeiPeiZhi.Value = info.ChuangWeiPeiZhi;
            //txtKeFangSheShi.Value = info.KeFangSheShi;
            txtJieShao.Value = info.JieShao;
            txtPaiXuId.Value = info.PaiXuId.ToString();
            txtRuZhuRiQi1.Value = info.RuZhuRiQi1.ToString("yyyy-MM-dd");
            txtRuZhuRiQi2.Value = info.RuZhuRiQi2.ToString("yyyy-MM-dd");
            txtYouHuiJiaGe.Value = info.YouHuiJiaGe.ToString("F2");

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
        EyouSoft.Model.PtStructure.MJiuDianFangXingInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MJiuDianFangXingInfo();

            //info.ChuangWeiPeiZhi = Utils.GetFormEditorValue(txtChuangWeiPeiZhi.UniqueID);
            info.FangXingId = EditId;
            info.FuJians = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            info.GuaPaiJiaGe = Utils.GetDecimal(Utils.GetFormValue(txtGuaPaiJiaGe.UniqueID));
            info.IssueTime = DateTime.Now;
            info.JieShao = Utils.GetFormValue(txtJieShao.UniqueID);
            info.JiuDianId = JiuDianId;
            //info.KeFangSheShi = Utils.GetFormEditorValue(txtKeFangSheShi.UniqueID);
            info.LouCeng = Utils.GetFormValue(txtLouCeng.UniqueID);
            info.MianJi = Utils.GetFormValue(txtMianJi.UniqueID);
            info.MingCheng = Utils.GetFormValue(txtMingCheng.UniqueID);
            info.OperatorId = SiteUserInfo.UserId;
            info.ShuLiang = Utils.GetFormValue(txtShuLiang.UniqueID);
            info.PaiXuId = Utils.GetInt(Utils.GetFormValue(txtPaiXuId.UniqueID));
            info.RuZhuRiQi1 = Utils.GetDateTime(Utils.GetFormValue(txtRuZhuRiQi1.UniqueID));
            info.RuZhuRiQi2 = Utils.GetDateTime(Utils.GetFormValue(txtRuZhuRiQi2.UniqueID));
            info.YouHuiJiaGe = Utils.GetDecimal(Utils.GetFormValue(txtYouHuiJiaGe.UniqueID));

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

            if (!Privs_FangXingGuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.FangXingId))
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BJiuDian().InsertFangXing(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BJiuDian().UpdateFangXing(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
