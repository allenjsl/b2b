using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.GysWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (EyouSoft.Security.Membership.GysYongHuProvider.IsLogin())
            {
                Response.Redirect("/dijie/");
            }
            else
            {
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
}
