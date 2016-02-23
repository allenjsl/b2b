using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.TuiJian
{
    public partial class TuiJianXX : QianTaiYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("tuijianid")))
            {
                InteBind();
            }
        }
        void InteBind()
        {
            string tuijianid = Utils.GetQueryStringValue("tuijianid");
            var list = new EyouSoft.BLL.PtStructure.BTuiJian().GetInfo(tuijianid);
            if (list != null)
            {
                TuiJianTitle.Text = list.BiaoTi;
                TuiJianNeiRong.Text = list.NeiRong;

                rptTuPian.DataSource = list.FuJians;
                rptTuPian.DataBind();
            }
        }
    }
}
