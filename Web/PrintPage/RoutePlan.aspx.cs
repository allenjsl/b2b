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
    /// 线路行程单
    /// </summary>
    public partial class RoutePlan : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_栏目, true);
                return;
            }

            if (!IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            string routeId = Utils.GetQueryStringValue("rid");
            if(string.IsNullOrEmpty(routeId)) return;

            var model = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(routeId);
            if(model == null) return;

            ltrRouteName.Text = model.RouteName;
            ltrXLMS.Text = model.AreaDesc;
            if (model.RoutePlanList != null)
            {

                rptPlan.DataSource = model.RoutePlanList.OrderBy(c => (c.Days));
                rptPlan.DataBind();
            }

            if (!string.IsNullOrEmpty(model.TrafficStandard))
            {
                phJiaoTongBiaoZhun.Visible = true;
                ltrJTBZ.Text = model.TrafficStandard;                
            }
            if (!string.IsNullOrEmpty(model.StayStandard))
            {
                phZhuSuBiaoZhun.Visible = true;
                ltrZSBZ.Text = model.StayStandard;
            }
            if (!string.IsNullOrEmpty(model.DiningStandard))
            {
                phCanYinBiaoZhun.Visible = true;
                ltrCYBZ.Text = model.DiningStandard;
            }
            if (!string.IsNullOrEmpty(model.AttractionsStandard))
            {
                phJingDianBiaoZhun.Visible = true;
                ltrJDBZ.Text = model.AttractionsStandard;
            }
            if (!string.IsNullOrEmpty(model.GuideStandard))
            {
                phDaoYouFuWu.Visible = true;
                ltrDYFW.Text = model.GuideStandard;
            }
            if (!string.IsNullOrEmpty(model.ShoppingStandard))
            {
                phGouWuShuoMing.Visible = true;
                ltrGWSM.Text = model.ShoppingStandard;
            }
            if (!string.IsNullOrEmpty(model.ChildStandard))
            {
                phErTongBiaoZhun.Visible = true;
                ltrETBZ.Text = model.ChildStandard;
            }
            if (!string.IsNullOrEmpty(model.InsuranceDesc))
            {
                phBaoXianShuoMing.Visible = true;
                ltrBXSM.Text = model.InsuranceDesc;
            }
            if (!string.IsNullOrEmpty(model.ExpenseRecommend))
            {
                phZiFeiTuiJian.Visible = true;
                ltrZFTJ.Text = model.ExpenseRecommend;
            }
            if (!string.IsNullOrEmpty(model.Tips))
            {
                phWenXinTiShi.Visible = true;
                ltrWXTX.Text = model.Tips;
            }
            ltrBMXZ.Text = model.RegistrationNotes;

            if (!string.IsNullOrEmpty(model.RouteHeader)) this.Master.PageHeadFile = model.RouteHeader;
        }
    }
}
