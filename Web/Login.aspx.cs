using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web
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

        /// <summary>
        /// 用户登录
        /// </summary>
        /// 戴银柱 2011-9-7
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SysStructure.SystemDomain sysDomain = EyouSoft.Security.Membership.UserProvider.GetDomain();

            if (sysDomain == null || sysDomain.CompanyId < 1 || sysDomain.SysId < 1)
            {
                Response.Clear();
                Response.Write("请求异常：错误的域名配置。");
                Response.End();
            }

            //CompanyName = sysDomain.CompanyName;
            CompanyName = "金芒果商旅网专线商管理系统";

            var setting=EyouSoft.Security.Membership.UserProvider.GetComSetting(sysDomain.CompanyId);

            if (setting != null && !string.IsNullOrEmpty(setting.SysLogoFilepath)) LogoFilePath = setting.SysLogoFilepath;

        }
    }
}
