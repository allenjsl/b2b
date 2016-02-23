using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.DanJu
{
    public partial class XingChengDan : QianTaiYeMian
    {
        #region attributes
        /// <summary>
        /// 线路编号
        /// </summary>
        string RouteId = string.Empty;
        /// <summary>
        /// 控位线路产品编号
        /// </summary>
        string XianLuId = string.Empty;
        /// <summary>
        /// 控位编号
        /// </summary>
        string KongWeiId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            RouteId = Utils.GetQueryStringValue("routeid");
            XianLuId = Utils.GetQueryStringValue("xianluid");

            Master.DaYinMoBanLeiXing = EyouSoft.PtWeb.MP.DanJuDaYinMoBanLeiXing.KEHU;

            InitKongWeiXianLuInfo();
            InitRouteInfo();
            InitKongWeiInfo();

            InitYeMeiYeJiao();
        }

        #region private members
        /// <summary>
        /// init kongweixianlu info
        /// </summary>
        void InitKongWeiXianLuInfo()
        {
            if (string.IsNullOrEmpty(XianLuId)) return;
            var info = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiXianLuInfo(XianLuId);
            if (info == null) return;
            RouteId = info.RouteId;
            KongWeiId = info.KongWeiId;

            ltrChanPinBianHao.Text = info.XianLuCode;

            ltrJiaGeXinXi.Text = string.Format("成人门市价：{0:F2}&nbsp;&nbsp;&nbsp;&nbsp;儿童门市价：{1:F2}&nbsp;&nbsp;&nbsp;&nbsp;婴儿门市价：{2:F2}", info.MenShiJiaGe1, info.MenShiJiaGe2, info.MenShiJiaGe3);
        }

        /// <summary>
        /// init route info
        /// </summary>
        void InitRouteInfo()
        {
            if (string.IsNullOrEmpty(RouteId)&&string.IsNullOrEmpty(XianLuId)) return;

            var info = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(RouteId);
            if (info == null) return;

            ltrTianShu.Text = info.Days.ToString();

            ltrRouteName.Text = info.RouteName;
            ltrXLMS.Text = info.AreaDesc;
            if (info.RoutePlanList != null)
            {
                rptPlan.DataSource = info.RoutePlanList.OrderBy(c => (c.Days));
                rptPlan.DataBind();
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

            ltrJiHeShiJian.Text = info.JiHeShiJian;
            ltrJiHeDiDian.Text = info.JiHeDiDian;
            ltrSongTuanXinXi.Text = info.SongTuanXinXi;
            ltrMuDiDiJieTuanFangShi.Text = info.MuDiDiJieTuanFangShi;
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
            if (info.HuiDate.HasValue) ltrHuiDate.Text = info.HuiDate.Value.ToString("yyyy-MM-dd");

            ltrQuJiaoTong.Text = info.QuDepCityName + "/" + info.QuArrCityName + "&nbsp;" + info.QuJiaoTongName + "&nbsp;" + info.QuBanCi;
            ltrHuiJiaoTong.Text =  info.HuiDepCityName + "/" + info.HuiArrCityName + "&nbsp;"+info.HuiJiaoTongName + "&nbsp;" + info.HuiBanCi;
            ltrTianShu.Text = info.TianShu.ToString();

            if (info.HangDuans != null && info.HangDuans.Count > 0)
            {
                phHangDuan.Visible = true;
                rptHangDuan.DataSource = info.HangDuans;
                rptHangDuan.DataBind();
            }
        }

        /// <summary>
        /// init yemei yejiao
        /// </summary>
        void InitYeMeiYeJiao()
        {
            if (IsLogin)
            {
                ltrYeJiao.Text = "操作人：" + YongHuInfo.XingMing + "&nbsp;&nbsp;电话：" + YongHuInfo.DianHua + "&nbsp;&nbsp;打印日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                ltrDanJuTaiTouMingCheng.Text = ltrDanJuTaiTouMingCheng1.Text = YongHuInfo.KeHuName;
                ltrDanJuTaiTouDiZhi.Text = ltrDanJuTaiTouDiZhi1.Text = "地址：" + YongHuInfo.KeHuDiZhi;
                ltrDanJuTaiTouDianHua.Text = ltrDanJuTaiTouDianHua1.Text = "电话：" + YongHuInfo.KeHuDianHua;

                if (!string.IsNullOrEmpty(YongHuInfo.KeHuLogo))
                {
                    phYeMei1.Visible = true;
                    ltrDanJuTaiTouLogo.Text = string.Format("<img class=\"djtt_logo\" src=\"{0}\">", YongHuInfo.KeHuLogo);
                }
                else
                {
                    phYeMei2.Visible = true;
                }

                if (!string.IsNullOrEmpty(YongHuInfo.DanJuTaiTouMingCheng)) ltrDanJuTaiTouMingCheng.Text = ltrDanJuTaiTouMingCheng1.Text = YongHuInfo.DanJuTaiTouMingCheng;
                if (!string.IsNullOrEmpty(YongHuInfo.DanJuTaiTouDiZhi)) ltrDanJuTaiTouDiZhi.Text = ltrDanJuTaiTouDiZhi1.Text = "地址：" + YongHuInfo.DanJuTaiTouDiZhi;
                if (!string.IsNullOrEmpty(YongHuInfo.DanJuTaiTouDianHua)) ltrDanJuTaiTouDianHua.Text = ltrDanJuTaiTouDianHua1.Text = "电话：" + YongHuInfo.DanJuTaiTouDianHua;

            }
            else
            {
                phYeMei2.Visible = true;
                ltrYeJiao.Text = "打印日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
        }
        #endregion
    }
}
