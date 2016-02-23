using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.PtWeb.JingDian
{
    public partial class JingDianXX01 : QianTaiYeMian
    {
        #region attributes
        protected int Count = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["jingdianid"]))
            {
                InteBind();
            }
            else
            {
                Response.Redirect("/jingdian/");
            }
        }
        void InteBind()
        {
            string jingdianId = Request.QueryString["jingdianid"];
            var list = new EyouSoft.BLL.PtStructure.BJingDian().GetInfo(jingdianId);
            JingDianName.Text = list.MingCheng;
            JingDianTitle.Text = list.MingCheng;
            JingDianJIeShao.Text = list.JieShao;
            rptTuPian.DataSource = list.FuJians;
            rptTuPian.DataBind();
            
            var chaXun = new EyouSoft.Model.PtStructure.MJingDianChaXunInfo();

            var items = new EyouSoft.BLL.PtStructure.BJingDian().GetJingDians(SysCompanyId, 15, 1, ref Count, chaXun);
            if(items.Count>0)
            {
            RepReMen.DataSource = items;
            RepReMen.DataBind();
            }
            

        }
    }
}
