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
    /// 代订酒店业务确认单
    /// </summary>
    public partial class ScheduleHotel : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tourId = Utils.GetQueryStringValue("tourId");
            if (string.IsNullOrEmpty(tourId))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数丢失，请重新打开此页面！"));
                return;
            }

            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_栏目, true);
                return;
            }

            if (!IsPostBack)
            {
                InitCompanyInfo();
                InitPage(tourId);
            }
        }

        /// <summary>
        /// 初始化公司信息
        /// </summary>
        private void InitCompanyInfo()
        {
            var model = new EyouSoft.BLL.CompanyStructure.CompanyInfo().GetModel(CurrentUserCompanyID);
            if (model == null) return;

            ltrCompanyName.Text = ltrCompanyName1.Text = model.CompanyName;
            ltrCompanyFax.Text = model.ContactFax;
            ltrCompanyContact.Text = SiteUserInfo.Name;

            var items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(model.Id,CurrentZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.打印单据账户);
            IList<EyouSoft.Model.CompanyStructure.CompanyAccount> items1 = new List<EyouSoft.Model.CompanyStructure.CompanyAccount>();

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用)
                    {
                        items1.Add(item);
                    }
                }
            }

            rptbank.DataSource = items1;
            rptbank.DataBind();
        }

        /// <summary>
        /// 初始化代订酒店信息
        /// </summary>
        private void InitPage(string tourId)
        {
            var model = new EyouSoft.BLL.TourStructure.BTourOrderHotel().GetTourOrderHotel(tourId);

            if (model == null) return;

            ltrBuyCompanyName.Text = model.BuyCompanyName;
            ltrBuyOperator.Text = model.BuyOperator;

            if (!string.IsNullOrEmpty(model.BuyCompanyId))
            {
                var t = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(model.BuyCompanyId);
                if (t != null)
                {
                    //ltrBuyCompanyFax.Text = t.Fax;
                    var info = t.CustomerContact.FirstOrDefault(c => (c.ContactId == model.BuyOperatorId));

                    if (info != null)
                    {
                        ltrBuyOperator.Text = info.Name;
                        ltrBuyCompanyFax.Text = info.Fax;
                    }
                }
            }

            rptCustomer.DataSource = model.TourOrderTravellerList;
            rptCustomer.DataBind();

            if (model.TourOrderHotelPlanList != null&&model.TourOrderHotelPlanList.Count>0)
            {
                //rptHotel.DataSource = from c in model.TourOrderHotelPlanList
                //                      where !string.IsNullOrEmpty(c.GYSId)
                //                      select c;
                //rptHotel.DataBind();

                var items = new List<EyouSoft.Model.TourStructure.MPlanHotelMxInfo>();

                foreach (var item in model.TourOrderHotelPlanList)
                {
                    if (string.IsNullOrEmpty(item.GYSId)) continue;
                    if (item.AnPaiMxs != null && item.AnPaiMxs.Count > 0)
                    {
                        foreach (var item1 in item.AnPaiMxs)
                        {
                            items.Add(item1);
                        }
                    }
                }

                rptHotel.DataSource = items;
                rptHotel.DataBind();
            }

            ltrJiaGeMinXi.Text = model.PriceDetials;
            ltrZongJinE.Text = UtilsCommons.GetMoneyString(model.SumPrice, this.ProviderToMoney);
            ltrJiaGeBeiZhu.Text = model.PriceRemark;
            ltrRemark.Text = model.SpecialAskRemark;
            ltrIssueTime.Text = model.IssueTime.ToString("yyyy-MM-dd");
        }
    }
}
