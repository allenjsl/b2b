using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    /// <summary>
    /// 用户登录跳转处理
    /// </summary>
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SysStructure.SystemDomain domain = EyouSoft.Security.Membership.UserProvider.GetDomain();

            if (domain == null || domain.CompanyId < 1 || domain.SysId < 1)
            {
                Response.Clear();
                Response.Write("请求异常：错误的域名配置。");
                Response.End();
            }

            EyouSoft.Model.SSOStructure.MUserInfo uinfo = null;
            string url = "/UserCenter/UserInfo.aspx";

            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out uinfo);

            if (!isLogin)
            {
                if (!string.IsNullOrEmpty(domain.Url))
                {
                    url = domain.Url;
                }
                else
                {
                    url = "/login.aspx";
                }

                Response.Redirect(url, true);
            }

            if (EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_栏目))
            {
                url = "/TeamPlan/PlanList.aspx";
            }

            if (uinfo.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户)
            {
                url = "/pingtai/jiudian.aspx";
            }

            if (uinfo.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户)
            {
                url = "/pingtai/jingdian.aspx";
            }

            Response.Redirect(url, true);
        }
    }
}
