//游客名单表 汪奇志 2014-09-10
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
    /// 游客名单表
    /// </summary>
    public partial class YouKeMingDan : QianTaiYeMian
    {
        #region attributes
        /// <summary>
        /// 订单编号
        /// </summary>
        string DingDanId = string.Empty;
        /// <summary>
        /// 客户编号
        /// </summary>
        string KeHuId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("dingdanid");
            if (string.IsNullOrEmpty(DingDanId)) Utils.RCWE("异常请求");

            Master.DaYinMoBanLeiXing = EyouSoft.PtWeb.MP.DanJuDaYinMoBanLeiXing.KEHU;

            InitDingDanInfo();
            InitPrivs();
            InitYeMeiYeJiao();
        }

        #region private members
        /// <summary>
        /// init ding dan info
        /// </summary>
        void InitDingDanInfo()
        {
            var info = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(DingDanId);
            if (info == null) Utils.RCWE("异常请求");

            ltrRouteName.Text = info.RouteName;
            if (string.IsNullOrEmpty(info.RouteName)) ltrRouteName.Text = info.BusinessType.ToString();

            var kongWeiInfo = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(info.TourId);
            if (kongWeiInfo != null)
            {
                ltrQuJiaoTong.Text = kongWeiInfo.QuDepCityName + "/" + kongWeiInfo.QuArrCityName + "&nbsp;" + kongWeiInfo.QuJiaoTongName + "&nbsp;" + kongWeiInfo.QuBanCi;
                ltrHuiJiaoTong.Text = kongWeiInfo.HuiDepCityName + "/" + kongWeiInfo.HuiArrCityName + "&nbsp;" + kongWeiInfo.HuiJiaoTongName + "&nbsp;" + kongWeiInfo.HuiBanCi;
            }

            if (info.TourOrderTravellerList != null && info.TourOrderTravellerList.Count > 0)
            {
                rptYouKe.DataSource = info.TourOrderTravellerList;
                rptYouKe.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }

            KeHuId = info.BuyCompanyId;
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
                ltrYeJiao.Text = "打印日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
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
