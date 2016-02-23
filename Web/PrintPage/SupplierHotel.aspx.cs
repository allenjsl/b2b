using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.PrintPage
{
    /// <summary>
    /// 代订酒店供应商确认单
    /// </summary>
    public partial class SupplierHotel : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_栏目, true);
                return;
            }

            if (!IsPostBack)
            {
                InitCompanyInfo();
                InitPage();
            }
        }

        /// <summary>
        /// 初始化公司信息
        /// </summary>
        private void InitCompanyInfo()
        {
            var model = new EyouSoft.BLL.CompanyStructure.CompanyInfo().GetModel(CurrentUserCompanyID);
            if (model == null) return;

            ltrCompanyName1.Text = ltrCompanyName.Text = model.CompanyName;
            ltrCompanyFax.Text = model.ContactFax;
            ltrCompanyContact.Text = SiteUserInfo.Name;
        }

        /// <summary>
        /// 初始化代订酒店信息
        /// </summary>
        private void InitPage()
        {
            string tourId = Utils.GetQueryStringValue("tourId");
            string hotelPlanId = Utils.GetQueryStringValue("hpId");
            string OrderId = Utils.GetQueryStringValue("orderid");
            if (string.IsNullOrEmpty(tourId) || string.IsNullOrEmpty(hotelPlanId) || string.IsNullOrEmpty(OrderId))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数丢失，请重新打开此页面！"));
                return;
            }

            var model = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(OrderId);

            if (model == null) return;

            var tmp = new EyouSoft.Model.TourStructure.MTourOrderHotelPlan();
            var items = new List<EyouSoft.Model.TourStructure.MPlanHotelMxInfo>();

            foreach (var item in model.TourOrderHotelPlanList)
            {
                if (item.Id == hotelPlanId)
                {
                    if (item.AnPaiMxs != null && item.AnPaiMxs.Count > 0)
                    {
                        foreach (var item1 in item.AnPaiMxs)
                        {
                            items.Add(item1);
                        }
                    }
                    tmp = item;
                    break;
                }
            }

            rpthotel.DataSource = items;
            rpthotel.DataBind();

            ltrMingXi.Text = tmp.SettleDetail;
            ltrJinE.Text = UtilsCommons.GetMoneyString(tmp.SettleAmount, this.ProviderToMoney);
            ltrRemark.Text = tmp.PlanRemark;
            ltrSupplierName.Text = tmp.GYSName;
            ltrIssueTime.Text = model.IssueTime.HasValue ? model.IssueTime.Value.ToString("yyyy-MM-dd") : string.Empty;

            InitSupplierInfo(tmp.GYSId, tmp.SideOperatorId);
        }

        /// <summary>
        /// 初始化供应商信息
        /// </summary>
        /// <param name="id">供应商编号</param>
        /// <param name="operatorId">供应商操作人编号</param>
        private void InitSupplierInfo(string id, int operatorId)
        {
            if (string.IsNullOrEmpty(id) || operatorId <= 0) return;

            var list = new EyouSoft.BLL.CompanyStructure.CompanySupplier().GetSupplierContactById(id);

            if (list != null)
            {
                var model = list.FirstOrDefault(c => (c.Id == operatorId));
                if (model != null)
                {
                    ltrSupplierContact.Text = model.ContactName;
                    ltrSupplierFax.Text = model.ContactFax;
                }
            }
        }
    }
}
