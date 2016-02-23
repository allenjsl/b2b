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
    /// 安排地接确认单
    /// </summary>
    public partial class RoutineLocal : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tourId = Utils.GetQueryStringValue("tourId");
            var routeId = Utils.GetQueryStringValue("routeId");
            var localId = Utils.GetQueryStringValue("localId");

            if (string.IsNullOrEmpty(tourId) || string.IsNullOrEmpty(localId))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数丢失，请重新打开此页面！"));
                return;
            }

            if (!IsPostBack)
            {
                InitPage(tourId, routeId, localId);
            }

            InitInfo();
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="tourId"></param>
        /// <param name="routeId"></param>
        /// <param name="localId"></param>
        private void InitPage(string tourId, string routeId, string localId)
        {
            if (string.IsNullOrEmpty(tourId) || string.IsNullOrEmpty(localId))
            {
                return;
            }
            var tour = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(tourId);
            var local = new EyouSoft.BLL.PlanStructure.BPlanDiJie().GetPlanDiJieById(localId);

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
                ltrQuAirAndTime.Text += string.Format("{0} {1}", string.IsNullOrEmpty(tour.QuBanCi) ? string.Empty : tour.QuBanCi + "/", tour.QuTime);
                ltrHuiDate.Text = this.ToDateTimeString(tour.HuiDate);
                if (!string.IsNullOrEmpty(HuiDepCity.CityName) || !string.IsNullOrEmpty(HuiArrCity.CityName))
                {
                    ltrHuiAirAndTime.Text = HuiDepCity.CityName + "--" + HuiArrCity.CityName + "&nbsp;&nbsp;";
                }
                ltrHuiAirAndTime.Text += string.Format("{0} {1}", string.IsNullOrEmpty(tour.HuiBanCi) ? string.Empty : tour.HuiBanCi + "/", tour.HuiTime);

                citybll = null; QuDepCity = null; QuArrCity = null; HuiDepCity = null; HuiArrCity = null;
            }

            if (local != null)
            {
                ltrTourNo.Text = local.JiaoYiHao;
                ltrPeopleNum.Text = local.ChengRenShu + "+" + local.ErTongShu + "+" + local.YingErShu + "+" + local.QuPeiShu;
                ltrYongCan.Text = local.YongCan;
                ltrQuanPei.Text = string.IsNullOrEmpty(local.QuPeiName) ? "无" : local.QuPeiName;
                ltrJieTuanFangShi.Text = local.JieTuanFangShi;
                ltrJieSuanMingXi.Text = local.JieSuanMX;
                ltrJieSuanJinE.Text = this.ToMoneyString(local.JieSuanAmount);
                ltrRemark.Text = EyouSoft.Common.Function.StringValidate.TextToHtml(local.Remark);
                ltrIssueTime.Text = local.IssueTime.ToString("yyyy-MM-dd");

                string operatorName = string.Empty;
                string caoZuoRenFax = string.Empty;
                if (local.OperatorId > 0)
                {
                    var operatorInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(local.OperatorId);
                    if (operatorInfo != null)
                    {
                        operatorName = operatorInfo.DepartName + "-";
                        caoZuoRenFax = operatorInfo.PersonInfo.ContactFax;
                    }
                }
                operatorName += local.OperatorName;
                ltrOperatorName.Text = operatorName;

                if (string.IsNullOrEmpty(caoZuoRenFax)) caoZuoRenFax = SiteUserInfo.ZxsFax;
                ltrFax.Text = "传真：" + caoZuoRenFax;

                if (!string.IsNullOrEmpty(local.YouKeXinXi)) ltrYouKeXinXi.Text = EyouSoft.Common.Function.StringValidate.TextToHtml(local.YouKeXinXi);
                else phYouKeXinXi.Visible = false;

                if (string.IsNullOrEmpty(routeId)) routeId = local.RouteId;

                ltrGysName.Text = local.GysName;
                var gysInfo = new EyouSoft.BLL.CompanyStructure.CompanySupplier().GetSupplierLocal(local.GysId);
                if (gysInfo != null)
                {
                    if (gysInfo.SupplierContact != null && gysInfo.SupplierContact.Count > 0)
                    {
                        ltrGysFax.Text = gysInfo.SupplierContact[0].ContactFax;
                    }
                    ltrGysName.Text = gysInfo.UnitName;
                }
                

                //InitDaoYou(local.DaoYouId);
                ltrDaoYou.Text = local.DaoYouName;

                if (local.OrderId != null && local.OrderId.Any())
                {
                    IntiOrder(local.OrderId[0]);
                }                
            }

            var route = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(routeId);
            InitRoute(route);
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
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="daoYouId"></param>
        private void InitDaoYou(int daoYouId)
        {
            if (daoYouId <= 0) return;

            var user = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(daoYouId);
            if (user == null || user.PersonInfo == null) return;

            ltrDaoYou.Text = user.PersonInfo.ContactName;
        }

        /// <summary>
        /// 初始化订单信息
        /// </summary>
        /// <param name="orderId"></param>
        private void IntiOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;

            var model = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(orderId);

            if (model == null) return;

            ltrXingZhi.Text = model.BusinessNature.HasValue ? model.BusinessNature.Value.ToString() : string.Empty;
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            ltrZxsName.Text = SiteUserInfo.ZxsName;
        }
    }
}
