using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.JingDian
{
    /// <summary>
    /// 景点明细
    /// </summary>
    public partial class JingDianXX : QianTaiYeMian
    {
        #region attributes
        /// <summary>
        /// 景点编号
        /// </summary>
        string JingDianId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            JingDianId = Utils.GetQueryStringValue("jingdianid");

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(JingDianId)) Response.Redirect("/jingdian/");
            var info = new EyouSoft.BLL.PtStructure.BJingDian().GetInfo(JingDianId);
            if (info == null) Response.Redirect("/jingdian/");

            this.Title = ltrJingDianName.Text = ltrJingDianName1.Text = info.MingCheng;

            ltrJieShao.Text = info.JieShao;
            ltrJingDianDiZhi.Text = info.DiZhi;

            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                rptFuJianDaTu.DataSource = rtpFuJianXiaoTu.DataSource = info.FuJians;
                rptFuJianDaTu.DataBind();
                rtpFuJianXiaoTu.DataBind();

                if (info.FuJians.Count > 3)
                {
                    ltrFuJianKuaiSuLiuLan.Text = "<span class=\"btn top\" id=\"span_fujian_shang\"></span><span class=\"btn bottom\" id=\"span_fujian_xia\"></span>";
                }
            }
        }
        #endregion
    }
}
