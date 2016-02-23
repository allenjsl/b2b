using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.CuXiao
{
    public partial class CuXiaoXX : QianTaiYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("cuxiaoid")))
            {
                InteBind();
            }
        }

        void InteBind()
        {
            string cuxiaoid = Utils.GetQueryStringValue("cuxiaoid");
            var list = new EyouSoft.BLL.PtStructure.BCuXiao().GetInfo(cuxiaoid);
            if (list != null)
            {
                CuXiaoTitle.Text = list.BiaoTi;
                CuXiaoNeiRong.Text = list.NeiRong;
                ShiJian.Text = Convert.ToDateTime(list.ShiJian1).ToString("yyyy-MM-dd") + " 至 " + Convert.ToDateTime(list.ShiJian2).ToString("yyyy-MM-dd");

                rptTuPian.DataSource = list.FuJians;
                rptTuPian.DataBind();
            }
        }
    }
}
