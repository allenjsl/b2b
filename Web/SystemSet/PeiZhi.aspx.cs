using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.SystemSet
{
    /// <summary>
    /// 专线商配置
    /// </summary>
    public partial class PeiZhi : EyouSoft.Common.Page.BackPage
    {
        bool Privs_PeiZhi = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitWuc();
            InitInfo();
        }

        #region private members
        /// <summary>
        /// init wuc
        /// </summary>
        void InitWuc()
        {
            up_logo.FileTypes = up_tuzhang.FileTypes = up_yejiao.FileTypes = up_yemei.FileTypes = "*.jpg;*.jpeg;*.gif;*.png;*.bmp;";
            up_moban.FileTypes = "*.dot";
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_PeiZhi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_系统配置_栏目);

            if (Privs_PeiZhi)
            {
                ltrCaoZuo.Text = "<a id=\"i_a_baocun\" href=\"javascript:void(0)\">保存</a>";
            }
            else
            {
                ltrCaoZuo.Text = "你没有操作权限";
            }
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.CompanyStructure.CompanySetting().GetZxsPeiZhiInfo(CurrentUserCompanyID, CurrentZxsId);
            if (info == null) return;

            IList<Web.UserControl.MFileInfo> logos=new List<Web.UserControl.MFileInfo>();
            var logo=new Web.UserControl.MFileInfo();
            logo.FilePath=info.LogoFilepath;
            logos.Add(logo);
            up_logo.YuanFiles = logos;

            IList<Web.UserControl.MFileInfo> yemeis = new List<Web.UserControl.MFileInfo>();
            var yemei = new Web.UserControl.MFileInfo();
            yemei.FilePath = info.DaYinYeMeiFilepath;
            yemeis.Add(yemei);
            up_yemei.YuanFiles = yemeis;

            IList<Web.UserControl.MFileInfo> yejiaos = new List<Web.UserControl.MFileInfo>();
            var yejiao = new Web.UserControl.MFileInfo();
            yejiao.FilePath = info.DaYinYeJiaoFilepath;
            yejiaos.Add(yejiao);
            up_yejiao.YuanFiles = yejiaos;

            IList<Web.UserControl.MFileInfo> mobans = new List<Web.UserControl.MFileInfo>();
            var moban = new Web.UserControl.MFileInfo();
            moban.FilePath = info.DaYinMoBanFilepath;
            mobans.Add(moban);
            up_moban.YuanFiles = mobans;

            IList<Web.UserControl.MFileInfo> tuzhangs = new List<Web.UserControl.MFileInfo>();
            var tuzhang = new Web.UserControl.MFileInfo();
            tuzhang.FilePath = info.TuZhangFilepath;
            tuzhangs.Add(tuzhang);
            up_tuzhang.YuanFiles = tuzhangs;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            if (!Privs_PeiZhi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new EyouSoft.BLL.CompanyStructure.CompanySetting().GetZxsPeiZhiInfo(CurrentUserCompanyID, CurrentZxsId);
            if (info == null) info = new EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo();
            info.ZxsId = CurrentZxsId;
            info.CompanyId = CurrentUserCompanyID;

            info.LogoFilepath = string.Empty;
            info.DaYinYeMeiFilepath = string.Empty;
            info.DaYinYeJiaoFilepath = string.Empty;
            info.DaYinMoBanFilepath = string.Empty;
            info.TuZhangFilepath = string.Empty;

            var logoFiles = up_logo.Files;
            if (logoFiles != null && logoFiles.Count > 0)
            {
                info.LogoFilepath = logoFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = up_logo.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    info.LogoFilepath = yuanFiles[0].FilePath;
                }
            }

            var yeMeiFiles = up_yemei.Files;
            if (yeMeiFiles != null && yeMeiFiles.Count > 0)
            {
                info.DaYinYeMeiFilepath = yeMeiFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = up_yemei.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    info.DaYinYeMeiFilepath = yuanFiles[0].FilePath;
                }
            }

            var yeJiaoFiles = up_yejiao.Files;
            if (yeJiaoFiles != null && yeJiaoFiles.Count > 0)
            {
                info.DaYinYeJiaoFilepath = yeJiaoFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = up_yejiao.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    info.DaYinYeJiaoFilepath = yuanFiles[0].FilePath;
                }
            }

            var moBanFiles = up_moban.Files;
            if (moBanFiles != null && moBanFiles.Count > 0)
            {
                info.DaYinMoBanFilepath = moBanFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = up_yejiao.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    info.DaYinMoBanFilepath = yuanFiles[0].FilePath;
                }
            }

            var tuZhangFiles = up_tuzhang.Files;
            if (tuZhangFiles != null && tuZhangFiles.Count > 0)
            {
                info.TuZhangFilepath = tuZhangFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = up_yejiao.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    info.TuZhangFilepath = yuanFiles[0].FilePath;
                }
            }

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanySetting().SheZhiZxsPeiZhi(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
