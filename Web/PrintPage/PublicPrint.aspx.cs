using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.PrintPage
{
    /// <summary>
    /// 公共打印页
    /// </summary>
    public partial class PublicPrint : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = EyouSoft.Common.Utils.GetQueryStringValue("title");
        }
    }
}
