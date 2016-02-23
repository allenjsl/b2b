using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.GysWeb
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Security.Membership.GysYongHuProvider.Logout();

            var yuMingInfo = EyouSoft.Security.Membership.GysYongHuProvider.GetYuMingInfo();

            if (yuMingInfo != null)
            {
                Response.Redirect(yuMingInfo.ErpUrl + "/login.aspx");
                return;
            }

            Response.Redirect("/login.aspx");
        }
    }
}
