//计划单 汪奇志 2015-05-22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.GysWeb.danju
{
    /// <summary>
    /// 计划单
    /// </summary>
    public partial class DiJieJiHuaDan : DiJieYeMian
    {
        #region attributes
        string AnPaiId = string.Empty;
        string KongWeiId = string.Empty;
        string RouteId = string.Empty;
        string DingDanId = string.Empty;

        string ZxsId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            AnPaiId = Utils.GetQueryStringValue("anpaiid");
            if (string.IsNullOrEmpty(AnPaiId)) Utils.RCWE("异常请求");

            InitInfo();
            InitKongWeiInfo();
            InitRouteInfo();
            InitXingZhi();
            InitYeMeiYeJiao();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var anPaiInfo = new EyouSoft.BLL.PlanStructure.BPlanDiJie().GetPlanDiJieById(AnPaiId);
            if (anPaiInfo == null) return;

            KongWeiId = anPaiInfo.KongWeiId;
            RouteId = anPaiInfo.RouteId;
            ZxsId = anPaiInfo.ZxsId;
            if (anPaiInfo.OrderId != null && anPaiInfo.OrderId.Any())
            {
                DingDanId=anPaiInfo.OrderId[0];
            }

            ltrTourNo.Text = anPaiInfo.JiaoYiHao;
            ltrPeopleNum.Text = anPaiInfo.ChengRenShu + "+" + anPaiInfo.ErTongShu + "+" + anPaiInfo.YingErShu + "+" + anPaiInfo.QuPeiShu;
            ltrYongCan.Text = anPaiInfo.YongCan;
            ltrQuanPei.Text = string.IsNullOrEmpty(anPaiInfo.QuPeiName) ? "无" : anPaiInfo.QuPeiName;
            ltrJieTuanFangShi.Text = anPaiInfo.JieTuanFangShi;
            ltrJieSuanMingXi.Text = anPaiInfo.JieSuanMX;
            ltrJieSuanJinE.Text =anPaiInfo.JieSuanAmount.ToString("F2");
            ltrRemark.Text = EyouSoft.Common.Function.StringValidate.TextToHtml(anPaiInfo.Remark);
            ltrIssueTime.Text = anPaiInfo.IssueTime.ToString("yyyy-MM-dd");

            string operatorName = string.Empty;
            string caoZuoRenFax = string.Empty;
            if (anPaiInfo.OperatorId > 0)
            {
                var operatorInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(anPaiInfo.OperatorId);
                if (operatorInfo != null)
                {
                    operatorName = operatorInfo.DepartName + "-";
                    caoZuoRenFax = operatorInfo.PersonInfo.ContactFax;
                }
            }
            operatorName += anPaiInfo.OperatorName;
            ltrOperatorName.Text = operatorName;

            if (string.IsNullOrEmpty(caoZuoRenFax))
            {
                var zxsInfo = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(anPaiInfo.ZxsId);
                if (zxsInfo != null)
                {
                    caoZuoRenFax = zxsInfo.Fax;
                }
            }
            ltrFax.Text = "传真：" + caoZuoRenFax;

            if (!string.IsNullOrEmpty(anPaiInfo.YouKeXinXi)) ltrYouKeXinXi.Text = EyouSoft.Common.Function.StringValidate.TextToHtml(anPaiInfo.YouKeXinXi);
            else phYouKeXinXi.Visible = false;

            ltrGysName.Text = anPaiInfo.GysName;
            var gysInfo = new EyouSoft.BLL.CompanyStructure.CompanySupplier().GetSupplierLocal(anPaiInfo.GysId);
            if (gysInfo != null)
            {
                if (gysInfo.SupplierContact != null && gysInfo.SupplierContact.Count > 0)
                {
                    ltrGysFax.Text = gysInfo.SupplierContact[0].ContactFax;
                }
                ltrGysName.Text = gysInfo.UnitName;
            }

            ltrDaoYou.Text = anPaiInfo.DaoYouName;
            ltrZxsName.Text = anPaiInfo.ZxsName;
        }

        /// <summary>
        /// init kongwei info
        /// </summary>
        void InitKongWeiInfo()
        {
            var kongWeiInfo = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(KongWeiId);
            if (kongWeiInfo == null) Utils.RCWE("异常请求");

            var citybll = new EyouSoft.BLL.CompanyStructure.City();
            var QuDepCity = citybll.GetModel(kongWeiInfo.QuDepCityId) ?? new EyouSoft.Model.CompanyStructure.City();
            var QuArrCity = citybll.GetModel(kongWeiInfo.QuArrCityId) ?? new EyouSoft.Model.CompanyStructure.City();
            var HuiDepCity = citybll.GetModel(kongWeiInfo.HuiDepCityId) ?? new EyouSoft.Model.CompanyStructure.City();
            var HuiArrCity = citybll.GetModel(kongWeiInfo.HuiArrCityId) ?? new EyouSoft.Model.CompanyStructure.City();

            ltrQuDate.Text = string.Format("{0:yyyy-MM-dd}", kongWeiInfo.QuDate);
            if (!string.IsNullOrEmpty(QuDepCity.CityName) || !string.IsNullOrEmpty(QuArrCity.CityName))
            {
                ltrQuAirAndTime.Text = QuDepCity.CityName + "--" + QuArrCity.CityName + "&nbsp;&nbsp;";
            }
            ltrQuAirAndTime.Text += string.Format("{0} {1}", string.IsNullOrEmpty(kongWeiInfo.QuBanCi) ? string.Empty : kongWeiInfo.QuBanCi + "/", kongWeiInfo.QuTime);
            ltrHuiDate.Text = string.Format("{0:yyyy-MM-dd}", kongWeiInfo.HuiDate);
            if (!string.IsNullOrEmpty(HuiDepCity.CityName) || !string.IsNullOrEmpty(HuiArrCity.CityName))
            {
                ltrHuiAirAndTime.Text = HuiDepCity.CityName + "--" + HuiArrCity.CityName + "&nbsp;&nbsp;";
            }
            ltrHuiAirAndTime.Text += string.Format("{0} {1}", string.IsNullOrEmpty(kongWeiInfo.HuiBanCi) ? string.Empty : kongWeiInfo.HuiBanCi + "/", kongWeiInfo.HuiTime);
            citybll = null; QuDepCity = null; QuArrCity = null; HuiDepCity = null; HuiArrCity = null;
        }

        /// <summary>
        /// init route info
        /// </summary>
        void InitRouteInfo()
        {
            var xianLuInfo = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(RouteId);
            if (xianLuInfo == null) return;

            ltrRouteName.Text = xianLuInfo.RouteName;

            if (xianLuInfo.RoutePlanList != null)
            {
                rptXCAP.DataSource = xianLuInfo.RoutePlanList.OrderBy(c => (c.Days));
                rptXCAP.DataBind();
            }

            if (!string.IsNullOrEmpty(xianLuInfo.TrafficStandard))
            {
                phJiaoTongBiaoZhun.Visible = true;
                ltrJTBZ.Text = xianLuInfo.TrafficStandard;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.StayStandard))
            {
                phZhuSuBiaoZhun.Visible = true;
                ltrZSBZ.Text = xianLuInfo.StayStandard;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.DiningStandard))
            {
                phCanYinBiaoZhun.Visible = true;
                ltrCYBZ.Text = xianLuInfo.DiningStandard;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.AttractionsStandard))
            {
                phJingDianBiaoZhun.Visible = true;
                ltrJDBZ.Text = xianLuInfo.AttractionsStandard;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.GuideStandard))
            {
                phDaoYouFuWu.Visible = true;
                ltrDYFW.Text = xianLuInfo.GuideStandard;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.ShoppingStandard))
            {
                phGouWuShuoMing.Visible = true;
                ltrGWSM.Text = xianLuInfo.ShoppingStandard;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.ChildStandard))
            {
                phErTongBiaoZhun.Visible = true;
                ltrETBZ.Text = xianLuInfo.ChildStandard;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.InsuranceDesc))
            {
                phBaoXianShuoMing.Visible = true;
                ltrBXSM.Text = xianLuInfo.InsuranceDesc;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.ExpenseRecommend))
            {
                phZiFeiTuiJian.Visible = true;
                ltrZFTJ.Text = xianLuInfo.ExpenseRecommend;
            }
            if (!string.IsNullOrEmpty(xianLuInfo.Tips))
            {
                phWenXinTiShi.Visible = true;
                ltrWXTX.Text = xianLuInfo.Tips;
            }
        }

        /// <summary>
        /// init xingzhi
        /// </summary>
        void InitXingZhi()
        {
            if (string.IsNullOrEmpty(DingDanId)) return;

            var dingDanInfo = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(DingDanId);

            if (dingDanInfo == null) return;

            ltrXingZhi.Text = dingDanInfo.BusinessNature.HasValue ? dingDanInfo.BusinessNature.Value.ToString() : string.Empty;
        }

        /// <summary>
        /// init yemei yejiao
        /// </summary>
        void InitYeMeiYeJiao()
        {
            var zxsPeiZhiInfo = EyouSoft.Security.Membership.GysYongHuProvider.GetZxsPeiZhiInfo(YongHuInfo.CompanyId, ZxsId);
            if (zxsPeiZhiInfo == null) return;

            if (!string.IsNullOrEmpty(zxsPeiZhiInfo.DaYinYeMeiFilepath))
            {
                ltrYeiMei.Text = string.Format("<img src=\"{0}\" style=\"width:100%;height:115px\" />", ErpUrl + zxsPeiZhiInfo.DaYinYeMeiFilepath);
            }

            if (!string.IsNullOrEmpty(zxsPeiZhiInfo.DaYinYeJiaoFilepath))
            {
                ltrYeJiao.Text = string.Format("<img src=\"{0}\" style=\"width:100%;height:76px\" />", ErpUrl + zxsPeiZhiInfo.DaYinYeJiaoFilepath);
            }
        }
        #endregion
    }
}
