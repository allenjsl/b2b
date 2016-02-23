using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.LineProduct
{
    /// <summary>
    /// 线路收客数
    /// </summary>
    public partial class RouteOrder : EyouSoft.Common.Page.BackPage
    {
        private const int PageSize = 8;

        private int _pageIndex = 1;

        private int _recordCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;

            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_栏目, true);
                return;
            }

            if(!IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            string routeId = Utils.GetQueryStringValue("rid");
            _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            rptOrder.DataSource = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderList(
                CurrentUserCompanyID, PageSize, _pageIndex, ref _recordCount, routeId);
            rptOrder.DataBind();

            page1.CurrencyPage = _pageIndex;
            page1.intPageSize = PageSize;
            page1.intRecordCount = _recordCount;
        }
    }
}
