//线路预订及线路订单编辑 汪奇志 2014-09-07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.PtWeb.HuiYuan
{
    /// <summary>
    /// 线路预订及线路订单编辑
    /// </summary>
    public partial class XianLuYuDing : HuiYuanYeMian
    {
        #region attributes
        /// <summary>
        /// 控位线路产品编号
        /// </summary>
        protected string XianLuId = string.Empty;
        /// <summary>
        /// 订单编号
        /// </summary>
        string DingDanId = string.Empty;
        /// <summary>
        /// 控位状态
        /// </summary>
        EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai KongWeiZhuangTai = EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.正常;
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime? QuDate = null;

        protected string XingChengDanUrl = "javascript:void(0)";
        protected string XianLuXXUrl = "javascript:void(0)";

        int TingShou = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            XianLuId = Utils.GetQueryStringValue("xianluid");
            DingDanId = Utils.GetQueryStringValue("dingdanid");

            if (string.IsNullOrEmpty(XianLuId) && string.IsNullOrEmpty(DingDanId)) Utils.RCWE("异常请求");

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "submit": BaoCun(); break;
                case "quxiao": QuXiao(); break;
                case "huifu": HuiFu(); break;
                default: break;
            }

            InitDingDanInfo();
            InitKongWeiXianLuInfo();
            InitGuanLianChanPin();
        }

        #region private members
        /// <summary>
        /// init dingdan info
        /// </summary>
        void InitDingDanInfo()
        {
            if (string.IsNullOrEmpty(DingDanId)) return;
            var info = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(DingDanId);
            if (info == null) Utils.RCWE("异常请求");
            if (info.BuyCompanyId != YongHuInfo.KeHuId) Utils.RCWE("异常请求");
            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店) Utils.RCWE("异常请求");

            txtChengRenShu.Value = info.Adults.ToString();
            txtErTongShu.Value = info.Childs.ToString();
            txtYingErShu.Value = info.YingErRenShu.ToString();
            txtQuanPeiShu.Value = info.Bears.ToString();
            txtBuZhanWeiShu.Value = info.BuZhanWeiRenShu.ToString();
            txtBuFangChaShu.Value = info.BuFangChaRenShu.ToString();
            txtTuiFangChaShu.Value = info.TuiFangChaRenShu.ToString();

            txtDingDanLxrXingMing.Value = info.DingDanLxrXingMing;
            txtDingDanLxrShouJi.Value = info.DingDanLxrShouJi;
            txtDingDanLxrDianHua.Value = info.DingDanLxrDianHua;
            txtDingDanLxrFax.Value = info.DingDanLxrFax;
            txtXiaDanBeiZhu.Value = info.XiaDanBeiZhu;

            ltrJiHeShiJian.Text = info.CongregationTime;
            ltrJiHeDiDian.Text = info.CongregationPlace;
            ltrSongTuanXinXi.Text = info.SendTourInfo;
            ltrMuDiDiJieTuanFangShi.Text = info.WelcomeWay;

            if (!string.IsNullOrEmpty(info.PriceDetials)) ltrJiaGeMingXi.Text = info.PriceDetials;
            else ltrJiaGeMingXi.Text = info.JiaGeMingXi;

            txtJiaGeMingXi.Value = info.JiaGeMingXi;

            ltrJinE.Text = txtJinE.Value = info.SumPrice.ToString("F2");

            ltrZhanWeiShu.Text = "共计" + (info.Adults + info.Childs + info.YingErRenShu + info.Bears) + "人，其中不占位" + info.BuZhanWeiRenShu + "人，占位" + info.Accounts + "人";

            if (info.JiaJinE != 0 || !string.IsNullOrEmpty(info.JiaBeiZhu))
            {
                phJiaJinE.Visible = true;

                txtJiaJinE.Value = info.JiaJinE.ToString("F2");
                txtJiaJinEBeiZhu.Value = info.JiaBeiZhu;
            }

            if (info.JianJinE != 0 || !string.IsNullOrEmpty(info.JianBeiZhu))
            {
                phJianJinE.Visible = true;

                txtJianJinE.Value = info.JianJinE.ToString("F2");
                txtJianJinEBeiZhu.Value = info.JianBeiZhu;
            }

            if (info.JiFenXianShiBiaoShi == EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi.显示 || info.OperatorId == YongHuInfo.YongHuId || info.BuyOperatorId == YongHuInfo.KeHuLxrId)
            {
                phJiFen.Visible = true;
                ltrJiFen.Text = "此次预订成功结束后您将获得 <span class=\"yuding_jifen1\">" + info.JiFen2 + "</span> 个积分";
            }
            else
            {
                phJiFen.Visible = false;
            }

            #region 价格信息
            var jiaGeInfo = new MDingDanJiaGeInfo();
            jiaGeInfo.BuFangChaJiaGe = info.BuFangChaJiaGe;
            jiaGeInfo.DingDanJinE = info.DingDanJinE;
            jiaGeInfo.JiaJinE = info.JiaJinE;
            jiaGeInfo.JianJinE = info.JianJinE;
            jiaGeInfo.JieSuanJiaGe1 = info.ChengRenJiaGe;
            jiaGeInfo.JieSuanJiaGe2 = info.ErTongJiaGe;
            jiaGeInfo.JieSuanJiaGe3 = info.YingErJiaGe;
            jiaGeInfo.JiFen1 = info.JiFen1;
            jiaGeInfo.JiFen2 = info.JiFen2;
            jiaGeInfo.JinE = info.SumPrice;
            jiaGeInfo.KongWeiId = info.TourId;
            jiaGeInfo.MenShiJiaGe1 = 0;
            jiaGeInfo.MenShiJiaGe2 = 0;
            jiaGeInfo.MenShiJiaGe3 = 0;
            jiaGeInfo.QuanPeiJiaGe = info.QuanPeiJiaGe;
            jiaGeInfo.RouteId = info.RouteId;
            jiaGeInfo.TuiFangChaJiaGe = info.TuiFangChaJiaGe;
            jiaGeInfo.XianLuId = info.XianLuId;

            if (info.ChengRenJiaGe != 0 || info.ErTongJiaGe != 0 || info.YingErJiaGe != 0 || info.QuanPeiJiaGe != 0 || info.TuiFangChaJiaGe != 0 || info.BuFangChaJiaGe != 0)
            {
                ltrJieSuanJia.Text = string.Format("成人<span class=\"yuding_jine\">{0:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;儿童<span class=\"yuding_jine\">{1:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;婴儿<span class=\"yuding_jine\">{2:F2}</span>元/人", info.ChengRenJiaGe, info.ErTongJiaGe, info.YingErJiaGe);
                ltrQuanPeiJia.Text = string.Format("全陪<span class=\"yuding_jine\">{0:F2}</span>元/人", info.QuanPeiJiaGe);
                ltrDanFangCha.Text = string.Format("补房差<span class=\"yuding_jine\">{0:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;退房差<span class=\"yuding_jine\">{1:F2}</span>元/人", info.BuFangChaJiaGe, info.TuiFangChaJiaGe);
            }

            if (!string.IsNullOrEmpty(info.XianLuId))
            {
                var kongWeiXianLuInfo = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiXianLuInfo(info.XianLuId);

                if (kongWeiXianLuInfo != null)
                {
                    jiaGeInfo.MenShiJiaGe1 = kongWeiXianLuInfo.MenShiJiaGe1;
                    jiaGeInfo.MenShiJiaGe2 = kongWeiXianLuInfo.MenShiJiaGe2;
                    jiaGeInfo.MenShiJiaGe3 = kongWeiXianLuInfo.MenShiJiaGe3;

                    ltrChanPinBianMa.Text = "<span class=\"yuding_chanpinbianma\">（产品编码：" + kongWeiXianLuInfo.XianLuCode + ")</span>";
                    ltrYuDingJiFen.Text = "";
                    ltrMenShiJia.Text = string.Format("成人<span class=\"yuding_jine\">{0:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;儿童<span class=\"yuding_jine\">{1:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;婴儿<span class=\"yuding_jine\">{2:F2}</span>元/人", kongWeiXianLuInfo.MenShiJiaGe1, kongWeiXianLuInfo.MenShiJiaGe2, kongWeiXianLuInfo.MenShiJiaGe3);

                    InitXianDingRenShu(kongWeiXianLuInfo.XianDingRenShu, kongWeiXianLuInfo.ZuiXiaoRenShu);
                } 
            }

            string jiaGeXinXi=Newtonsoft.Json.JsonConvert.SerializeObject(jiaGeInfo);
            txtJiaGeXinXi.Value = jiaGeXinXi;
            #endregion

            RegisterScript(string.Format("var jiaGeXinXi={0};", jiaGeXinXi));
            RegisterScript(string.Format("var youKe={0};", Newtonsoft.Json.JsonConvert.SerializeObject(info.TourOrderTravellerList)));

            InitKongWeiInfo(info.TourId);
            InitDingDanRouteInfo(info.RouteId);

            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票)
            {
                ltrRouteName.Text = "单订票";
                phKuaiSuLianJie.Visible = false;
            }

            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店)
            {
                ltrRouteName.Text = "机票+酒店";
                phKuaiSuLianJie.Visible = false;
            }

            #region 操作
            ltrXiaoXi.Text = string.Format("预订人：{0}，下单时间：{1:yyyy-MM-dd HH:mm}。", info.BuyOperatorName, info.IssueTime);
            string _tiJiao = "<a href=\"javascript:void(0)\" id=\"i_a_submit\" class=\"baocun\">提 交</a>&nbsp;&nbsp;";
            string _quXiao = "<a href=\"javascript:void(0)\" id=\"i_a_quxiao\" class=\"baocun\">取 消</a>&nbsp;&nbsp;";
            string _huiFu = "<a href=\"javascript:void(0)\" id=\"i_a_huifu\" class=\"baocun\">恢 复</a>&nbsp;&nbsp;";
            switch (info.OrderStatus.Value)
            {
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.留位过期: 
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全: 
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.申请中:
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认:
                    ltrCaoZuo.Text = _tiJiao+_quXiao;
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交:
                    ltrXiaoXi.Text += "该订单已确定成交，您不能变更订单信息，如需变更，请联系供应商。";
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已拒绝:
                    ltrXiaoXi.Text += "该订单已被供应商拒绝，您不能变更订单信息，如需变更，请联系供应商。";
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位:
                    ltrCaoZuo.Text = _tiJiao + _quXiao;
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已取消:
                    if (KongWeiZhuangTai == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.正常)
                    {
                        ltrXiaoXi.Text += "该订单已取消，取消原因：" + info.YuanYin1 + "。您可以恢复订单。";
                        ltrCaoZuo.Text = _huiFu;
                    }
                    else
                    {
                        ltrXiaoXi.Text += "该订单已取消。如需变更，请联系供应商。";
                    }
                    break;
            }

            if (string.IsNullOrEmpty(info.XianLuId) || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店)
            {
                ltrXiaoXi.Text = string.Format("预订人：{0}，下单时间：{1:yyyy-MM-dd HH:mm}。", info.BuyOperatorName, info.IssueTime);
                ltrXiaoXi.Text += "订单状态：" + info.OrderStatus.Value + "。";
                ltrXiaoXi.Text += "您不能变更订单信息，如需变更，请联系供应商。";
                ltrCaoZuo.Text = "";
            }
            #endregion

            XingChengDanUrl = "/danju/xingchengdan.aspx?xianluid=" + info.XianLuId + "&routeid=" + info.RouteId;
            if (!string.IsNullOrEmpty(info.XianLuId)) XianLuXXUrl = "/xianlu/xianluxx.aspx?xlid=" + info.XianLuId;
        }

        /// <summary>
        /// init kongweixianlu info
        /// </summary>
        void InitKongWeiXianLuInfo()
        {
            if (!string.IsNullOrEmpty(DingDanId)) return;
            var info = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiXianLuInfo(XianLuId);

            if (info == null) Utils.RCWE("异常请求");

            var zxsJiFenStatus = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetZxsJiFenStatus(info.ZxsId);
            if (zxsJiFenStatus == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用)
            {
                info.JiFen= 0;
            }

            ltrChanPinBianMa.Text = "<span class=\"yuding_chanpinbianma\">（产品编码：" + info.XianLuCode + ")</span>";
            ltrYuDingJiFen.Text = "<span class=\"yuding_jifen\">（预订成功每成人赠送积分" + info.JiFen + "分/成人）</span>";

            #region 价格信息
            ltrMenShiJia.Text = string.Format("成人<span class=\"yuding_jine\">{0:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;儿童<span class=\"yuding_jine\">{1:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;婴儿<span class=\"yuding_jine\">{2:F2}</span>元/人", info.MenShiJiaGe1, info.MenShiJiaGe2, info.MenShiJiaGe3);
            ltrJieSuanJia.Text = string.Format("成人<span class=\"yuding_jine\">{0:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;儿童<span class=\"yuding_jine\">{1:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;婴儿<span class=\"yuding_jine\">{2:F2}</span>元/人", info.JieSuanJiaGe1, info.JieSuanJiaGe2, info.JieSuanJiaGe3);
            ltrQuanPeiJia.Text = string.Format("全陪<span class=\"yuding_jine\">{0:F2}</span>元/人", info.QuanPeiJiaGe);
            ltrDanFangCha.Text = string.Format("补房差<span class=\"yuding_jine\">{0:F2}</span>元/人&nbsp;&nbsp;&nbsp;&nbsp;退房差<span class=\"yuding_jine\">{1:F2}</span>元/人", info.BuFangChaJiaGe, info.TuiFangChaJiaGe);
           
            var jiaGeInfo = new MDingDanJiaGeInfo();
            jiaGeInfo.BuFangChaJiaGe = info.BuFangChaJiaGe;
            jiaGeInfo.DingDanJinE = 0;
            jiaGeInfo.JiaJinE = 0;
            jiaGeInfo.JianJinE = 0;
            jiaGeInfo.JieSuanJiaGe1 = info.JieSuanJiaGe1;
            jiaGeInfo.JieSuanJiaGe2 = info.JieSuanJiaGe2;
            jiaGeInfo.JieSuanJiaGe3 = info.JieSuanJiaGe3;
            jiaGeInfo.JiFen1 = info.JiFen;
            jiaGeInfo.JiFen2 = 0;
            jiaGeInfo.JinE = 0;
            jiaGeInfo.KongWeiId = info.KongWeiId;
            jiaGeInfo.MenShiJiaGe1 = info.MenShiJiaGe1;
            jiaGeInfo.MenShiJiaGe2 = info.MenShiJiaGe2;
            jiaGeInfo.MenShiJiaGe3 = info.MenShiJiaGe3;
            jiaGeInfo.QuanPeiJiaGe = info.QuanPeiJiaGe;
            jiaGeInfo.RouteId = info.RouteId;
            jiaGeInfo.TuiFangChaJiaGe = info.TuiFangChaJiaGe;
            jiaGeInfo.XianLuId = info.XianLuId;
            jiaGeInfo.LeiXing = info.LeiXing;

            if (info.LeiXing == EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票)
            {
                jiaGeInfo.QuanPeiJiaGe = info.JieSuanJiaGe1;

                ltrRouteName.Text = "单订票";

                phKuaiSuLianJie.Visible = false;
            }

            string jiaGeXinXi = Newtonsoft.Json.JsonConvert.SerializeObject(jiaGeInfo);
            txtJiaGeXinXi.Value = jiaGeXinXi;
            #endregion 

            RegisterScript(string.Format("var jiaGeXinXi={0};", jiaGeXinXi));

            InitKongWeiInfo(info.KongWeiId);
            InitRouteInfo(info.RouteId);
            InitDingDanLxrInfo();

            if (TingShou == 0)
            {
                ltrCaoZuo.Text = "<a href=\"javascript:void(0)\" id=\"i_a_submit\" class=\"baocun\">提 交</a>&nbsp;&nbsp;";
            }
            else
            {
                ltrXiaoXi.Text = "该线路产品已客满，暂不提供预定。";
            }

            XingChengDanUrl = "/danju/xingchengdan.aspx?xianluid=" + info.XianLuId;
            XianLuXXUrl = "/xianlu/xianluxx.aspx?xlid=" + info.XianLuId;

            InitXianDingRenShu(info.XianDingRenShu, info.ZuiXiaoRenShu);
        }

        /// <summary>
        /// init kongwei info
        /// </summary>
        /// <param name="kongWeiId"></param>
        void InitKongWeiInfo(string kongWeiId)
        {
            var info = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(kongWeiId);
            if (info == null) Utils.RCWE("异常请求");

            ltrQuChuFaDi.Text = info.QuChuFaDiShengFenName + info.QuDepCityName;
            ltrTianShu.Text = info.TianShu.ToString();
            if (info.QuDate.HasValue) ltrQuDate.Text = info.QuDate.Value.ToString("yyyy-MM-dd");
            ltrQuJiaoTong.Text = info.QuJiaoTongName + "&nbsp;" + info.QuBanCi;

            if (info.HuiDate.HasValue)
            {
                ltrHuiDate.Text = info.HuiDate.Value.ToString("yyyy-MM-dd");
                ltrHuiJiaoTong.Text = info.HuiJiaoTongName + "&nbsp;" + info.HuiBanCi;
            }

            ZxsXinXi1.ZxsId = info.ZxsId;

            KongWeiZhuangTai = info.KongWeiZhuangTai;
            QuDate = info.QuDate;

            txtZxsId.Value = info.ZxsId;

            if (info.KongWeiStatus == EyouSoft.Model.EnumType.TourStructure.KongWeiStatus.手动停收 
                || info.PingTaiShouKeStatus == EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus.手动停收)
            {
                TingShou = 1;
            }
        }

        /// <summary>
        ///  init route info
        /// </summary>
        /// <param name="routeId"></param>
        void InitRouteInfo(string routeId)
        {
            var info = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(routeId);
            if (info == null) return;

            ltrRouteName.Text = info.RouteName;
            ltrJiHeShiJian.Text = info.JiHeShiJian;
            ltrJiHeDiDian.Text = info.JiHeDiDian;
            ltrSongTuanXinXi.Text = info.SongTuanXinXi;
            ltrMuDiDiJieTuanFangShi.Text = info.MuDiDiJieTuanFangShi;

            txtRouteLeiXing.Value = ((int)info.LeiXing).ToString();
        }

        /// <summary>
        /// init dingdan route info
        /// </summary>
        void InitDingDanRouteInfo(string routeId)
        {
            var info = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(routeId);
            if (info == null) return;
            ltrRouteName.Text = info.RouteName;
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.TourStructure.MTourOrder GetFormInfo()
        {
            string _txtZxsId = Utils.GetFormValue(txtZxsId.UniqueID);

            if (string.IsNullOrEmpty(_txtZxsId)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求，请重试"));

            var info = new EyouSoft.Model.TourStructure.MTourOrder();
            info.OrderId = DingDanId;
            info.BuyOperatorId = YongHuInfo.KeHuLxrId;

            if (!string.IsNullOrEmpty(info.OrderId))
            {
                info = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(info.OrderId);
                if (info == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求，请重试"));
            }

            info.CompanyId = YuMingInfo.CompanyId;
            info.OperatorId = YongHuInfo.YongHuId;
            info.IssueTime = DateTime.Now;
            info.BuyCompanyId = YongHuInfo.KeHuId;

            string jiaGeXinXi = Utils.GetFormValue(txtJiaGeXinXi.UniqueID);

            if (string.IsNullOrEmpty(jiaGeXinXi)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求，请重试"));

            info.Adults = Utils.GetInt(Utils.GetFormValue(txtChengRenShu.UniqueID));
            info.Childs = Utils.GetInt(Utils.GetFormValue(txtErTongShu.UniqueID));
            info.YingErRenShu = Utils.GetInt(Utils.GetFormValue(txtYingErShu.UniqueID));
            info.Bears = Utils.GetInt(Utils.GetFormValue(txtQuanPeiShu.UniqueID));
            info.BuZhanWeiRenShu = Utils.GetInt(Utils.GetFormValue(txtBuZhanWeiShu.UniqueID));
            info.Accounts = info.Adults + info.Childs + info.YingErRenShu + info.Bears - info.BuZhanWeiRenShu;
            info.BuFangChaRenShu = Utils.GetInt(Utils.GetFormValue(txtBuFangChaShu.UniqueID));
            info.TuiFangChaRenShu = Utils.GetInt(Utils.GetFormValue(txtTuiFangChaShu.UniqueID));
            info.DingDanLxrXingMing = Utils.GetFormValue(txtDingDanLxrXingMing.UniqueID);
            info.DingDanLxrShouJi = Utils.GetFormValue(txtDingDanLxrShouJi.UniqueID);
            info.DingDanLxrDianHua = Utils.GetFormValue(txtDingDanLxrDianHua.UniqueID);
            info.DingDanLxrFax = Utils.GetFormValue(txtDingDanLxrFax.UniqueID);
            info.XiaDanBeiZhu = Utils.GetFormValue(txtXiaDanBeiZhu.UniqueID);

            info.JiaJinE=Utils.GetDecimal(Utils.GetFormValue(txtJiaJinE.UniqueID));
            info.JiaBeiZhu = Utils.GetFormValue(txtJiaJinEBeiZhu.UniqueID);
            info.JianJinE = Utils.GetDecimal(Utils.GetFormValue(txtJianJinE.UniqueID));
            info.JianBeiZhu = Utils.GetFormValue(txtJianJinEBeiZhu.UniqueID);

            info.SumPrice = Utils.GetDecimal(Utils.GetFormValue(txtJinE.UniqueID));

            var jiaGeInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MDingDanJiaGeInfo>(jiaGeXinXi);
            if (jiaGeInfo == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求，请重试"));

            info.ChengRenJiaGe = jiaGeInfo.JieSuanJiaGe1;
            info.ErTongJiaGe = jiaGeInfo.JieSuanJiaGe2;
            info.YingErJiaGe = jiaGeInfo.JieSuanJiaGe3;
            info.QuanPeiJiaGe = jiaGeInfo.QuanPeiJiaGe;
            info.BuFangChaJiaGe = jiaGeInfo.BuFangChaJiaGe;
            info.TuiFangChaJiaGe = jiaGeInfo.TuiFangChaJiaGe;

            info.TourId = jiaGeInfo.KongWeiId;
            info.XianLuId = jiaGeInfo.XianLuId;
            info.RouteId = jiaGeInfo.RouteId;

            info.JiFen1 = jiaGeInfo.JiFen1;
            if (info.JiFen1 > 500) info.JiFen1 = 500;
            info.JiFen2 = jiaGeInfo.JiFen1 * info.Adults;

            info.JiaGeMingXi = Utils.GetFormValue(txtJiaGeMingXi.UniqueID);

            #region youke
            string[] txtYouKeId = Utils.GetFormValues("txtYouKeId");
            string[] txtYouKeXingMing = Utils.GetFormValues("txtYouKeXingMing");
            string[] txtYouKeLeiXing = Utils.GetFormValues("txtYouKeLeiXing");
            string[] txtYongKeXingBie = Utils.GetFormValues("txtYongKeXingBie");
            string[] txtYouKeZhengJianLeiXing = Utils.GetFormValues("txtYouKeZhengJianLeiXing");
            string[] txtYongKeZhengJianHaoMa = Utils.GetFormValues("txtYongKeZhengJianHaoMa");
            string[] txtYongKeLianXiFangShi = Utils.GetFormValues("txtYongKeLianXiFangShi");

            info.TourOrderTravellerList = new List<EyouSoft.Model.TourStructure.MTourOrderTraveller>();

            for (int i = 0; i < txtYouKeId.Length; i++)
            {
                if (string.IsNullOrEmpty(txtYouKeXingMing[i])) continue;

                var youKeItem = new EyouSoft.Model.TourStructure.MTourOrderTraveller();

                youKeItem.TravellerId = txtYouKeId[i];
                youKeItem.TravellerName = txtYouKeXingMing[i];
                youKeItem.TravellerType = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.TravellerType>(txtYouKeLeiXing[i], EyouSoft.Model.EnumType.TourStructure.TravellerType.成人);
                youKeItem.Sex = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.Sex>(txtYongKeXingBie[i], EyouSoft.Model.EnumType.CompanyStructure.Sex.未知);
                youKeItem.CardType = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.CardType>(txtYouKeZhengJianLeiXing[i], EyouSoft.Model.EnumType.TourStructure.CardType.未知);
                youKeItem.CardNumber = txtYongKeZhengJianHaoMa[i];
                youKeItem.Contact = txtYongKeLianXiFangShi[i];

                info.TourOrderTravellerList.Add(youKeItem);
            }
            #endregion

            if (info.Adults + info.Childs + info.YingErRenShu + info.Bears < 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请填写正确的游客人数"));
            decimal chengRenJinE = 0, erTongJinE = 0, yingErJinE = 0, quanPeiJinE = 0, tuiFangChaJinE = 0, buFangChaJinE = 0;
            chengRenJinE = info.ChengRenJiaGe * info.Adults;
            erTongJinE = info.ErTongJiaGe * info.Childs;
            yingErJinE = info.YingErJiaGe * info.YingErRenShu;
            quanPeiJinE = info.QuanPeiJiaGe * info.Bears;
            tuiFangChaJinE = info.TuiFangChaJiaGe * info.TuiFangChaRenShu;
            buFangChaJinE = info.BuFangChaJiaGe * info.BuFangChaRenShu;

            if (chengRenJinE + erTongJinE + yingErJinE + quanPeiJinE + buFangChaJinE - tuiFangChaJinE + info.JiaJinE - info.JianJinE != info.SumPrice) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求"));
            info.DingDanJinE = chengRenJinE + erTongJinE + yingErJinE + quanPeiJinE;

            if (info.JiaJinE != jiaGeInfo.JiaJinE) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求"));
            if (info.JianJinE != jiaGeInfo.JianJinE) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求"));

            if (string.IsNullOrEmpty(info.OrderId))
            {
                if (jiaGeInfo.LeiXing == EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票) info.BusinessType = EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票;
                var xianLuLeXing = (EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing), Utils.GetFormValue(txtRouteLeiXing.UniqueID));

                if (xianLuLeXing.HasValue)
                {
                    switch (xianLuLeXing.Value)
                    {
                        case EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing.常规旅游: info.BusinessType = EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游; break;
                        case EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing.私人订制: info.BusinessType = EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制; break;
                        case EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing.自由行: info.BusinessType = EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行; break;
                        default: break;
                    }
                }
            }

            info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认;
            info.ZxsId = _txtZxsId;

            return info;
        }

        /// <summary>
        /// bao cun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.OrderId))
            {
                var zxsJiFenStatus = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetZxsJiFenStatus(info.ZxsId);
                if (zxsJiFenStatus == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用)
                {
                    info.JiFen1 = 0;
                    info.JiFen2 = 0;
                }

                bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().PT_DingDan_C(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().PT_DingDan_U(info);
            }

            if (bllRetCode == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功，请等待专线商审核。"));
            if (bllRetCode == -99 || bllRetCode == -98) Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：不存在产品不能预订"));
            if (bllRetCode == -97 || bllRetCode == -94) Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已客满暂不能预订"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败"));
        }

        /// <summary>
        /// init dingdan lxr info
        /// </summary>
        void InitDingDanLxrInfo()
        {
            txtDingDanLxrXingMing.Value = YongHuInfo.XingMing;
            var info = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(YongHuInfo.YongHuId);

            if (info == null) return;

            txtDingDanLxrShouJi.Value = info.PersonInfo.ContactMobile;
            txtDingDanLxrDianHua.Value = info.PersonInfo.ContactTel;
            txtDingDanLxrFax.Value = info.PersonInfo.ContactFax;
        }

        /// <summary>
        /// quxiao
        /// </summary>
        void QuXiao()
        {
            string quXiaoYuanYin = Utils.GetFormValue("txtQuXiaoYuanYin");
            if (string.IsNullOrEmpty(quXiaoYuanYin)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请填写取消原因"));
            if (string.IsNullOrEmpty(DingDanId)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求"));

            int bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().QuXiaoDingDan(DingDanId, quXiaoYuanYin, YongHuInfo.YongHuId, 1);

            if (bllRetCode == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败"));
        }

        /// <summary>
        /// huifu
        /// </summary>
        void HuiFu()
        {
            if (string.IsNullOrEmpty(DingDanId)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求"));
            int bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().HuiFuDingDan(DingDanId, YongHuInfo.YongHuId, 1);
            if (bllRetCode == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败"));
        }

        /// <summary>
        /// init guanlian chanpin
        /// </summary>
        void InitGuanLianChanPin()
        {
            if (!string.IsNullOrEmpty(DingDanId)) return;
            if (!QuDate.HasValue) return;
            if (string.IsNullOrEmpty(XianLuId)) return;

            phGuanLianChanPin.Visible = true;

            var items = new EyouSoft.BLL.PtStructure.BKongWeiXianLu().GetGuanLianKongWeiXianLus(XianLuId, QuDate.Value.AddMonths(-1), QuDate.Value.AddMonths(1));

            int count = items.Count;
            int index = 0;

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].QuDate == QuDate.Value) { index = i; break; };
            }

            var items1 = new List<EyouSoft.Model.PtStructure.MGuanLianKongWeiXianLuInfo>();

            if (index < 5 || count < 9)
            {
                for (var i = 0; i < 9 && i < count; i++)
                {
                    items1.Add(items[i]);
                }
            }
            else if (index + 5 > count)
            {
                for (int i = 0; i < 9; i++)
                {
                    items1.Add(items[count - 9 + i]);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    items1.Add(items[index - 4 + i]);
                }

                for (int i = 1; i < 5; i++)
                {
                    items1.Add(items[index + i]);
                }
            }

            StringBuilder s = new StringBuilder();
            foreach (var item in items1)
            {
                string _class = "";
                if (item.QuDate == QuDate.Value) _class = " class=\"on\" ";

                s.AppendFormat("<li><a href=\"?xianluid={4}\" {3}>{0} {1}<br>{2} 元</a></li>", item.QuDate.ToString("MM-dd"), Utils.ConvertWeekDayToChinese(item.QuDate), item.JieSuanJiaGe1.ToString("F2"), _class, item.XianLuId);
            }

            if (count > 9)
            {
                s.AppendFormat("<li class=\"last\"><a href=\"javascript:void(0)\" id=\"i_a_gengduoguanlianchanpin\">更多团期&nbsp;<img src=\"/huiyuan/images/down1.gif\"></a></li>");
            }

            ltrGuanLianChanPin.Text = s.ToString();
        }

        /// <summary>
        /// init xianding renshu
        /// </summary>
        /// <param name="zuiDaRenShu">限定人数（最大）</param>
        /// <param name="zuiXiaoRenShu">限定人数（最小）</param>
        void InitXianDingRenShu(int zuiDaRenShu, int zuiXiaoRenShu)
        {
            if (zuiXiaoRenShu <= 0 && zuiXiaoRenShu <= 0) return;

            string s = string.Empty;
            if (zuiDaRenShu > 0)
            {
                s+=string.Format("每单限制总人数不超过{0}人", zuiDaRenShu);
            }

            if (zuiXiaoRenShu > 0)
            {
                if (!string.IsNullOrEmpty(s)) s += "，";
                s += string.Format("每单至少预定成人数不小于{0}人", zuiXiaoRenShu);
            }

            ltrXianDingRenShu.Text = "<span style=\"color:#2C6504\">【注：" + s + "】</span>";
        }
        #endregion
    }

    #region 订单价格信息实体
    /// <summary>
    /// 订单价格信息实体
    /// </summary>
    public class MDingDanJiaGeInfo
    {
        /// <summary>
        /// 控位线路产品编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 成人单价-门市
        /// </summary>
        public decimal MenShiJiaGe1 { get; set; }
        /// <summary>
        /// 儿童单价-门市
        /// </summary>
        public decimal MenShiJiaGe2 { get; set; }
        /// <summary>
        /// 全陪单价
        /// </summary>
        public decimal QuanPeiJiaGe { get; set; }
        /// <summary>
        /// 婴儿单价-门市
        /// </summary>
        public decimal MenShiJiaGe3 { get; set; }
        /// <summary>
        /// 增加金额
        /// </summary>
        public decimal JiaJinE { get; set; }
        /// <summary>
        /// 减少金额
        /// </summary>
        public decimal JianJinE { get; set; }
        ///<summary>
        /// 补房差单价
        /// </summary>
        public decimal BuFangChaJiaGe { get; set; }
        /// <summary>
        /// 退房差单价
        /// </summary>
        public decimal TuiFangChaJiaGe { get; set; }
        /// <summary>
        /// 单人积分
        /// </summary>
        public int JiFen1 { get; set; }
        /// <summary>
        /// 总积分
        /// </summary>
        public int JiFen2 { get; set; }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string RouteId { get; set; }

        /// <summary>
        /// 成人单价-结算
        /// </summary>
        public decimal JieSuanJiaGe1 { get; set; }
        /// <summary>
        /// 儿童单价-结算
        /// </summary>
        public decimal JieSuanJiaGe2 { get; set; }
        /// <summary>
        /// 婴儿单价-结算
        /// </summary>
        public decimal JieSuanJiaGe3 { get; set; }

        /// <summary>
        /// 订单金额（不含退补房差、不含增减费用）
        /// </summary>
        public decimal DingDanJinE { get; set; }
        /// <summary>
        /// 订单金额（总）
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 线路产品类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing LeiXing { get; set; }
    }
    #endregion
}
