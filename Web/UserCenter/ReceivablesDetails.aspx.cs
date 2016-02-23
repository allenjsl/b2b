using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.UserCenter
{
    public partial class ReceivablesDetails : BackPage
    {

        /// <summary>
        /// 每页显示条数(常量)
        /// </summary>
        private int pageSize = 10;
        /// <summary>
        /// 当前页数
        /// </summary>
        private int pageIndex = 0;
        /// <summary>
        /// 总记录条数
        /// </summary>
        private int recordCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                InitData();
            }
        }

        /// <summary>
        /// 初始化页面数据
        /// </summary>
        private void InitData()
        {
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            var customerId = Utils.GetQueryStringValue("CustomerId");

            var chaXun = new EyouSoft.Model.PersonalCenterStructure.MShouKuanTiXingChaXunInfo();
            chaXun.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LBeginDate"));
            chaXun.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LEndDate"));
            chaXun.ZxsId = CurrentZxsId;

            var list = new EyouSoft.BLL.PersonalCenterStructure.TranRemind().GetShouKuanTiXingMxs(pageSize, pageIndex, ref recordCount, customerId, chaXun);
            
            this.rpOrder.DataSource = list;
            this.rpOrder.DataBind();

            BindPage();
        }


        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
            this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
        }
        #endregion
    }
}
