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

namespace Web.CommonPage
{
    using EyouSoft.BLL.TourStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;

    public partial class BianGengList : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Utils.GetQueryStringValue("bianId");
            var typ = (EyouSoft.Model.EnumType.TourStructure.BianType)Utils.GetInt(Utils.GetQueryStringValue("bianType"));
            var List = new BBianGeng().GetBianGengList(id, typ);
            if (List != null && List.Count > 0)
            {
                this.rpt.DataSource = List;
                this.rpt.DataBind();
            }
            else
            {
                this.rpt.Controls.Add(new Label() { Text = "<tr><td colspan='3' align='center'>对不起，没有相关数据！</td></tr>" });
            }
        }
    }
}
