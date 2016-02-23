using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Web.PrintPage
{
    using EyouSoft.BLL.AdminCenterStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;

    public partial class ZhiDu : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var m = new RuleInfo().GetModel(this.SiteUserInfo.CompanyId, Utils.GetInt(Utils.GetQueryStringValue("id")));
            if (m == null)
            {
                return;
            }
            this.txtNo.InnerText = m.RoleNo;
            this.txtTitle.InnerText = m.Title;
            this.txtContent.InnerText = Utils.InputText(m.RoleContent);
        }
    }
}
