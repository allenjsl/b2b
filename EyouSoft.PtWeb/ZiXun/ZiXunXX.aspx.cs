using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.ZiXun
{
    public partial class ZiXunXX : QianTaiYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("zixunid")))
            {
                InteBind();
            }
        }

        void InteBind()
        {
            string zixunid = Utils.GetQueryStringValue("zixunid");
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.PtStructure.MZiXunChaXunInfo();
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常;
            chaXun.LeiXing = EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing.平台资讯;

            var list = new EyouSoft.BLL.PtStructure.BZiXun().GetInfo(zixunid);
            if (list != null)
            {
                ZiXunTitle.Text = list.BiaoTi;
                ZiXunNeiRong.Text = list.NeiRong;
                
                ShiJian.Text = list.IssueTime.ToString("yyyy-MM-dd");

                rptTuPian.DataSource = list.FuJians;
                rptTuPian.DataBind();
            }           

            var items = new EyouSoft.BLL.PtStructure.BZiXun().GetZiXuns(SysCompanyId,10,1,ref recordCount,chaXun);
            if (items.Count > 0)
            {
                RepZiXunList.DataSource = items;
                RepZiXunList.DataBind();
            }
        }
    }
}
