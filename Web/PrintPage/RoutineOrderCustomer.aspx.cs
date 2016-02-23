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
    /// 常规业务客户确认单
    /// </summary>
    public partial class RoutineOrderCustomer : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tourId = Utils.GetQueryStringValue("tourId");
            var routeId = Utils.GetQueryStringValue("routeId");
            var orderId = Utils.GetQueryStringValue("orderId");

            if (string.IsNullOrEmpty(orderId))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数丢失，请重新打开此页面！"));
                return;
            }

            if (!IsPostBack)
            {
                InitCompanyInfo();
                InitPage(tourId, routeId, orderId);
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
            ltrCompanyFax.Text = SiteUserInfo.Fax;
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

            rptBank.DataSource = items1;
            rptBank.DataBind();
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="tourId"></param>
        /// <param name="routeId"></param>
        /// <param name="orderId"></param>
        private void InitPage(string tourId, string routeId, string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                return;
            }

            var order = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(orderId);
            if (order != null)
            {
                if (string.IsNullOrEmpty(tourId)) tourId = order.TourId;
                if (string.IsNullOrEmpty(routeId)) routeId = order.RouteId;
            }
            var tour = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(tourId);
            var route = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(routeId);

            InitRoute(route);

            InitOrder(order);

            if (tour != null)
            {
                var citybll = new EyouSoft.BLL.CompanyStructure.City();
                var QuDepCity = citybll.GetModel(tour.QuDepCityId) ?? new EyouSoft.Model.CompanyStructure.City();
                var QuArrCity = citybll.GetModel(tour.QuArrCityId) ?? new EyouSoft.Model.CompanyStructure.City();
                var HuiDepCity = citybll.GetModel(tour.HuiDepCityId) ?? new EyouSoft.Model.CompanyStructure.City();
                var HuiArrCity = citybll.GetModel(tour.HuiArrCityId) ?? new EyouSoft.Model.CompanyStructure.City();

                ltrQuDate.Text = this.ToDateTimeString(tour.QuDate);
                if (!string.IsNullOrEmpty(QuDepCity.CityName) || !string.IsNullOrEmpty(QuArrCity.CityName))
                {
                    ltrQuAirAndTime.Text = QuDepCity.CityName + "--" + QuArrCity.CityName + "&nbsp;&nbsp;";
                }

                //ltrQuAirAndTime.Text += string.Format("{0} {1}", string.IsNullOrEmpty(tour.QuBanCi) ? string.Empty : tour.QuBanCi + " / ", tour.QuTime);
                if (!string.IsNullOrEmpty(tour.QuBanCi))
                {
                    ltrQuAirAndTime.Text += tour.QuBanCi;

                    if (!string.IsNullOrEmpty(tour.QuTime))
                    {
                        ltrQuAirAndTime.Text += " / " + tour.QuTime;
                    }
                }

                ltrHuiDate.Text = this.ToDateTimeString(tour.HuiDate);

                if (!string.IsNullOrEmpty(HuiDepCity.CityName) || !string.IsNullOrEmpty(HuiArrCity.CityName))
                {
                    ltrHuiAirAndTime.Text = HuiDepCity.CityName + "--" + HuiArrCity.CityName + "&nbsp;&nbsp;";
                }
                //ltrHuiAirAndTime.Text += string.Format("{0} {1}", string.IsNullOrEmpty(tour.HuiBanCi) ? string.Empty : tour.HuiBanCi + " / ", tour.HuiTime);
                if (!string.IsNullOrEmpty(tour.HuiBanCi))
                {
                    ltrHuiAirAndTime.Text += tour.HuiBanCi;

                    if (!string.IsNullOrEmpty(tour.HuiTime))
                    {
                        ltrHuiAirAndTime.Text += " / " + tour.HuiTime;
                    }
                }

                citybll = null; QuDepCity = null; QuArrCity = null; HuiDepCity = null; HuiArrCity = null;

                if (tour.HangDuans != null && tour.HangDuans.Count > 0)
                {
                    phHangDuan.Visible = true;
                    rptHangDuan.DataSource = tour.HangDuans;
                    rptHangDuan.DataBind();
                }
            }
        }

        /// <summary>
        /// 初始化订单信息
        /// </summary>
        /// <param name="order"></param>
        private void InitOrder(EyouSoft.Model.TourStructure.MTourOrder order)
        {
            if (order == null) return;

            InitBuyCompany(order.BuyCompanyId, order.BuyOperatorId);

            ltrPeopleNum.Text = order.Adults + " + " + order.Childs + " + " + order.YingErRenShu + " + " + order.Bears;
            ltrJiHeTime.Text = order.CongregationTime;
            ltrJiHeAddress.Text = order.CongregationPlace;
            ltrSendTour.Text = order.SendTourInfo;
            ltrJieSuanMingXi.Text = order.JiaGeMingXi1;
            ltrZongJinE.Text = this.ToMoneyString(order.SumPrice);
            ltrJieTuanFangShi.Text = order.WelcomeWay;
            ltrRemark.Text = order.SpecialAskRemark;
            ltrJiaGeBeiZhu.Text = order.PriceRemark;
            ltrIssueTime.Text = order.IssueTime.HasValue ? order.IssueTime.Value.ToString("yyyy-MM-dd") : string.Empty;

            rptCustomer.DataSource = order.TourOrderTravellerList;
            rptCustomer.DataBind();

            if (order.BusinessType.Value == EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行)
            {
                var items = new List<EyouSoft.Model.TourStructure.MPlanHotelMxInfo>();
                foreach (var item in order.TourOrderHotelPlanList)
                {
                    if (item.AnPaiMxs != null && item.AnPaiMxs.Count > 0)
                    {
                        foreach (var item1 in item.AnPaiMxs)
                        {
                            items.Add(item1);
                        }
                    }
                }

                if (items != null && items.Count > 0)
                {
                    phJiuDianAnPai.Visible = true;
                    rptJiuDianAnPai.DataSource = items;
                    rptJiuDianAnPai.DataBind();
                }
            }
        }

        /// <summary>
        /// 初始化线路信息
        /// </summary>
        /// <param name="route"></param>
        private void InitRoute(EyouSoft.Model.TourStructure.MRoute route)
        {
            if (route == null) return;

            ltrRouteName.Text = route.RouteName;

            if (route.RoutePlanList != null)
            {
                rptXCAP.DataSource = route.RoutePlanList.OrderBy(c => (c.Days));
                rptXCAP.DataBind();
            }

            if (!string.IsNullOrEmpty(route.TrafficStandard))
            {
                phJiaoTongBiaoZhun.Visible = true;
                ltrJTBZ.Text = route.TrafficStandard;
            }
            if (!string.IsNullOrEmpty(route.StayStandard))
            {
                phZhuSuBiaoZhun.Visible = true;
                ltrZSBZ.Text = route.StayStandard;
            }
            if (!string.IsNullOrEmpty(route.DiningStandard))
            {
                phCanYinBiaoZhun.Visible = true;
                ltrCYBZ.Text = route.DiningStandard;
            }
            if (!string.IsNullOrEmpty(route.AttractionsStandard))
            {
                phJingDianBiaoZhun.Visible = true;
                ltrJDBZ.Text = route.AttractionsStandard;
            }
            if (!string.IsNullOrEmpty(route.GuideStandard))
            {
                phDaoYouFuWu.Visible = true;
                ltrDYFW.Text = route.GuideStandard;
            }
            if (!string.IsNullOrEmpty(route.ShoppingStandard))
            {
                phGouWuShuoMing.Visible = true;
                ltrGWSM.Text = route.ShoppingStandard;
            }
            if (!string.IsNullOrEmpty(route.ChildStandard))
            {
                phErTongBiaoZhun.Visible = true;
                ltrETBZ.Text = route.ChildStandard;
            }
            if (!string.IsNullOrEmpty(route.InsuranceDesc))
            {
                phBaoXianShuoMing.Visible = true;
                ltrBXSM.Text = route.InsuranceDesc;
            }
            if (!string.IsNullOrEmpty(route.ExpenseRecommend))
            {
                phZiFeiTuiJian.Visible = true;
                ltrZFTJ.Text = route.ExpenseRecommend;
            }
            if (!string.IsNullOrEmpty(route.Tips))
            {
                phWenXinTiShi.Visible = true;
                ltrWXTX.Text = route.Tips;
            }

            ltrBMXZ.Text = route.RegistrationNotes;
        }

        /// <summary>
        /// 初始化组团社信息
        /// </summary>
        /// <param name="buyCompanyId"></param>
        /// <param name="buyOperatorId"></param>
        private void InitBuyCompany(string buyCompanyId, int buyOperatorId)
        {
            if (string.IsNullOrEmpty(buyCompanyId)) return;

            var model = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(buyCompanyId);
            if (model == null) return;

            ltrBuyCompanyName.Text = model.Name;
            ltrBuyCompanyFax.Text = model.Fax;
            if (model.CustomerContact != null)
            {
                var info = model.CustomerContact.FirstOrDefault(c => (c.ContactId == buyOperatorId));

                if (info != null)
                {
                    ltrBuyOperator.Text = info.Name;
                    ltrBuyCompanyFax.Text = info.Fax;
                }

            }
        }
    }
}
