using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.GysWeb
{
    public partial class Login : System.Web.UI.Page
    {
        #region attributes
        /// <summary>
        /// 公司名称
        /// </summary>
        protected string CompanyName = string.Empty;
        protected string CompanyName1 = "金芒果商旅网";
        /// <summary>
        /// logo文件路径
        /// </summary>
        protected string LogoFilePath = "/images/pngclear.gif";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            var yuMingInfo = EyouSoft.Security.Membership.GysYongHuProvider.GetYuMingInfo();

            if (yuMingInfo == null || yuMingInfo.CompanyId < 1)
            {
                Response.Clear();
                Response.Write("请求异常：错误的域名配置。");
                Response.End();
            }

            CompanyName = "金芒果商旅网地接社管理系统";

            //var setting = EyouSoft.Security.Membership.GysYongHuProvider.GetXiTongPeiZhiInfo(yuMingInfo.CompanyId);

            //if (setting != null && !string.IsNullOrEmpty(setting.SysLogoFilepath)) LogoFilePath = setting.SysLogoFilepath;

            LogoFilePath = "/images/logo.2015.01.png";
        }
    }
}
