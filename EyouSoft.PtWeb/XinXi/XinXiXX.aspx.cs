using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.XinXi
{
    public partial class XinXiXX : QianTaiYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("xinxiid")))
            {
                InteBind(Utils.GetQueryStringValue("xinxiid"));
            }
        }
        void InteBind(string xinxiid)
        {
            var list = new EyouSoft.BLL.PtStructure.BGuangGao().GetInfo(xinxiid);
            XinXiTitle.Text = list.MingCheng;

            XiangXiNeiRong.Text = list.NeiRong;

            rptTuPian.DataSource = list.FuJians;
            rptTuPian.DataBind();
        }
    }
}
