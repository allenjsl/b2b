//游客确认单 汪奇志 2014-09-11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.DanJu
{
    /// <summary>
    /// 游客确认单
    /// </summary>
    public partial class YouKeQueRenDan : QianTaiYeMian
    {
        #region attributes
        /// <summary>
        /// 订单编号
        /// </summary>
        string DingDanId = string.Empty;
        /// <summary>
        /// 控位编号
        /// </summary>
        string KongWeiId = string.Empty;
        /// <summary>
        /// 线路编号
        /// </summary>
        string RouteId = string.Empty;
        /// <summary>
        /// 专线商编号
        /// </summary>
        string ZxsId = string.Empty;
        /// <summary>
        /// 专线商操作人编号
        /// </summary>
        int ZxsCaoZuoRenId = 0;
        /// <summary>
        /// 客户编号
        /// </summary>
        string KeHuId = string.Empty;
        /// <summary>
        /// 客户联系编号
        /// </summary>
        int KeHuLxrId = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("dingdanid");
            if (string.IsNullOrEmpty(DingDanId)) Utils.RCWE("异常请求");

            InitDingDanInfo();
            InitPrivs();
            InitZxsInfo();
            InitKeHuInfo();
            InitKongWeiInfo();
            InitRouteInfo();
            InitYeMeiYeJiao();
        }

        #region private members
        /// <summary>
        /// init dingdan info
        /// </summary>
        void InitDingDanInfo()
        {
            var info = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(DingDanId);
            if (info == null) Utils.RCWE("异常请求");

            var yeWuLeiXings = new EyouSoft.Model.EnumType.TourStructure.BusinessType[] { EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游, EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制, EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行 };

            if (!yeWuLeiXings.Contains(info.BusinessType.Value)) Utils.RCWE("异常请求");

            KongWeiId = info.TourId;
            RouteId = info.RouteId;
            ZxsId = info.ZxsId;
            ZxsCaoZuoRenId = info.LatestOperatorId;
            KeHuId = info.BuyCompanyId;
            KeHuLxrId = info.BuyOperatorId;

            ltrPeopleNum.Text = info.Adults + " + " + info.Childs + " + " + info.YingErRenShu + " + " + info.Bears;
            ltrJiHeTime.Text = info.CongregationTime;
            ltrJiHeAddress.Text = info.CongregationPlace;
            ltrSendTour.Text = info.SendTourInfo;
            ltrJieSuanMingXi.Text = info.JiaGeMingXi1;
            ltrZongJinE.Text = info.SumPrice.ToString("F2");
            ltrJieTuanFangShi.Text = info.WelcomeWay;
            ltrRemark.Text = info.SpecialAskRemark;
            ltrJiaGeBeiZhu.Text = info.PriceRemark;
            ltrIssueTime.Text = info.IssueTime.HasValue ? info.IssueTime.Value.ToString("yyyy-MM-dd") : string.Empty;

            rptCustomer.DataSource = info.TourOrderTravellerList;
            rptCustomer.DataBind();

            if (info.BusinessType.Value == EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行)
            {
                var items = new List<EyouSoft.Model.TourStructure.MPlanHotelMxInfo>();
                foreach (var item in info.TourOrderHotelPlanList)
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
        /// init zxs info
        /// </summary>
        void InitZxsInfo()
        {
            if (string.IsNullOrEmpty(ZxsId)) return;
            var info = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(ZxsId);
            if (info == null) return;

            ltrZxsName.Text = ltrZxsName1.Text = info.MingCheng;

            var zxsCaoZuoRenInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(ZxsCaoZuoRenId);
            if (zxsCaoZuoRenInfo != null)
            {
                ltrZxsFaJianRenFax.Text = zxsCaoZuoRenInfo.PersonInfo.ContactFax;
                ltrZxsFaJianRenName.Text = zxsCaoZuoRenInfo.PersonInfo.ContactName;
            }

            var items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(SysCompanyId, ZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.打印单据账户);
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
        /// init kehu info
        /// </summary>
        void InitKeHuInfo()
        {
            if (string.IsNullOrEmpty(KeHuId)) return;
            var info = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(KeHuId);
            if (KeHuId == null) return;

            ltrKeHuName.Text = info.Name;

            var keHuLxrInfo = new EyouSoft.BLL.CompanyStructure.Customer().GetKeHuLxrInfo(KeHuId, KeHuLxrId);

            if (keHuLxrInfo != null)
            {
                ltrKeHuLxrName.Text = keHuLxrInfo.Name;
                ltrKeHuLxrFax.Text = keHuLxrInfo.Fax;
            }
        }

        /// <summary>
        /// init kongwei info
        /// </summary>
        void InitKongWeiInfo()
        {
            if (string.IsNullOrEmpty(KongWeiId)) return;
            var info = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(KongWeiId);
            if (info == null) return;

            if (info.QuDate.HasValue) ltrQuDate.Text = info.QuDate.Value.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(info.QuDepCityName) || !string.IsNullOrEmpty(info.QuArrCityName))
                ltrQuAirAndTime.Text = info.QuDepCityName + "--" + info.QuArrCityName + "&nbsp;&nbsp;";
            if (!string.IsNullOrEmpty(info.QuBanCi))
            {
                ltrQuAirAndTime.Text += info.QuBanCi;

                if (!string.IsNullOrEmpty(info.QuTime))
                {
                    ltrQuAirAndTime.Text += " / " + info.QuTime;
                }
            }

            if (info.HuiDate.HasValue) ltrHuiDate.Text = info.HuiDate.Value.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(info.HuiDepCityName) || !string.IsNullOrEmpty(info.HuiArrCityName))
            ltrHuiAirAndTime.Text = info.HuiDepCityName+ "--" + info.HuiArrCityName+ "&nbsp;&nbsp;";
            if (!string.IsNullOrEmpty(info.HuiBanCi))
            {
                ltrHuiAirAndTime.Text += info.HuiBanCi;

                if (!string.IsNullOrEmpty(info.HuiTime))
                {
                    ltrHuiAirAndTime.Text += " / " + info.HuiTime;
                }
            }

            if (info.HangDuans != null && info.HangDuans.Count > 0)
            {
                phHangDuan.Visible = true;
                rptHangDuan.DataSource = info.HangDuans;
                rptHangDuan.DataBind();
            }
        }

        /// <summary>
        /// init rotue info
        /// </summary>
        void InitRouteInfo()
        {
            if (string.IsNullOrEmpty(RouteId)) return;
            var info = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(RouteId);
            if (info == null) return;

            ltrRouteName.Text = info.RouteName;
            if (info.RoutePlanList != null)
            {
                rptXCAP.DataSource = info.RoutePlanList.OrderBy(c => (c.Days));
                rptXCAP.DataBind();
            }

            if (!string.IsNullOrEmpty(info.TrafficStandard))
            {
                phJiaoTongBiaoZhun.Visible = true;
                ltrJTBZ.Text = info.TrafficStandard;
            }
            if (!string.IsNullOrEmpty(info.StayStandard))
            {
                phZhuSuBiaoZhun.Visible = true;
                ltrZSBZ.Text = info.StayStandard;
            }
            if (!string.IsNullOrEmpty(info.DiningStandard))
            {
                phCanYinBiaoZhun.Visible = true;
                ltrCYBZ.Text = info.DiningStandard;
            }
            if (!string.IsNullOrEmpty(info.AttractionsStandard))
            {
                phJingDianBiaoZhun.Visible = true;
                ltrJDBZ.Text = info.AttractionsStandard;
            }
            if (!string.IsNullOrEmpty(info.GuideStandard))
            {
                phDaoYouFuWu.Visible = true;
                ltrDYFW.Text = info.GuideStandard;
            }
            if (!string.IsNullOrEmpty(info.ShoppingStandard))
            {
                phGouWuShuoMing.Visible = true;
                ltrGWSM.Text = info.ShoppingStandard;
            }
            if (!string.IsNullOrEmpty(info.ChildStandard))
            {
                phErTongBiaoZhun.Visible = true;
                ltrETBZ.Text = info.ChildStandard;
            }
            if (!string.IsNullOrEmpty(info.InsuranceDesc))
            {
                phBaoXianShuoMing.Visible = true;
                ltrBXSM.Text = info.InsuranceDesc;
            }
            if (!string.IsNullOrEmpty(info.ExpenseRecommend))
            {
                phZiFeiTuiJian.Visible = true;
                ltrZFTJ.Text = info.ExpenseRecommend;
            }
            if (!string.IsNullOrEmpty(info.Tips))
            {
                phWenXinTiShi.Visible = true;
                ltrWXTX.Text = info.Tips;
            }

            ltrBMXZ.Text = info.RegistrationNotes;

        }

        /// <summary>
        /// init yemei yejiao
        /// </summary>
        void InitYeMeiYeJiao()
        {
            var zxsPeiZhiInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetZxsPeiZhiInfo(SysCompanyId, ZxsId);
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

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!IsLogin) RCWE("异常请求");
            if (YongHuInfo.KeHuId != KeHuId) RCWE("异常请求");
        }
        #endregion
    }
}
