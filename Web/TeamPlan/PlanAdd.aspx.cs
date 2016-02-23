using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.TourStructure;
using System.Text;

namespace Web.TeamPlan
{
    /// <summary>
    /// 功能说明：报名
    /// 创建人:刘飞
    /// 时间：2012-12-03
    /// </summary>
    public partial class PlanAdd : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 业务类型
        /// </summary>
        protected string YeWuLeiXing = "";
        /// <summary>
        /// 性质
        /// </summary>
        protected string YeWuXingZhi = string.Empty;
        /// <summary>
        /// 控位编号
        /// </summary>
        string KongWeiId = string.Empty;
        /// <summary>
        /// 订单编号
        /// </summary>
        protected string DingDanId = string.Empty;
        /// <summary>
        /// 对方操作人编号
        /// </summary>
        protected string DuiFangCaoZuoRenId = string.Empty;
        /// <summary>
        /// 控位状态
        /// </summary>
        EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai KongWeiZhuangTai = EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.正常;
        /// <summary>
        /// 专线商积分发放状态
        /// </summary>
        protected EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus ZxsJiFenStatus = EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用;
        /// <summary>
        /// 积分显示标识
        /// </summary>
        protected EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi JiFenXianShiBiaoShi = EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi.显示;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            KongWeiId = Utils.GetQueryStringValue("kongweiId");
            DingDanId = Utils.GetQueryStringValue("orderId");

            if (string.IsNullOrEmpty(KongWeiId)) RCWE("异常请求");

            InitPrivs();
            InitWUC();
            InitZxsJiFenStatus();

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "chengjiao":
                case "liuwei":
                case "baocun": Save(); break;
                case "huifu": HuiFu(); break;
                default: break;
            }

            InitWUC();
            InitInfo();
            InitKongWeiInfo();            
        }

        #region private members
        /// <summary>
        /// init wuc
        /// </summary>
        void InitWUC()
        {
            
        }

        /// <summary>
        /// init kongweiinfo
        /// </summary>
        void InitKongWeiInfo()
        {            
            var info = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(KongWeiId);
            if (info == null) RCWE("异常请求");

            lbcount.Text = "剩余位数：" + new EyouSoft.BLL.TourStructure.BTour().GetShengYuShuLiang(KongWeiId);

            KongWeiZhuangTai = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiZhuangTai(KongWeiId);
            
            if (KongWeiZhuangTai == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束)
            {
                ph_HeSuanJieShu.Visible = true;
                ph_ChengJiao.Visible = ph_BaoCun.Visible = ph_LiuWei.Visible = ph_QuXiao.Visible = ph_HuiFu.Visible = ph_JuJue.Visible = false;
            }

            if (info.XianLus != null && info.XianLus.Count > 0)
            {
                string script = string.Format("var jiHuaNeiXianLu={0};", Newtonsoft.Json.JsonConvert.SerializeObject(info.XianLus));
                RegisterScript(script);
            }
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            ltrBiaoShiYanSeOptions.Text = GetBiaoShiYanSeOptions(string.Empty);

            if (string.IsNullOrEmpty(DingDanId)) return;

            var info = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(DingDanId);
            if (info == null) RCWE("异常请求");

            txtAdultCount.Text = info.Adults.ToString();
            txtChildCount.Text = info.Childs.ToString();
            txtJiHeDiDian1.Value = info.CongregationPlace;
            txtJiHeShiJian1.Value = info.CongregationTime;
            txtGroundRemark.Text = info.GroundRemark;
            txtOperatorRemark.Text = info.OperatoRemark;
            txtPriceDesc.Text = info.PriceDetials;
            txtPriceRemark.Text = info.PriceRemark;
            txtQuanPeiCount.Text = info.Bears.ToString();
            txtMuDiDiJieTuanFangShi.Text = info.WelcomeWay;
            txtSeatCount.Text = info.Accounts.ToString();
            txtSongTuanXinXi.Text = info.SendTourInfo;
            txtTotalMoney.Value = info.SumPrice.ToString("f2");
            txtYaoqiuRemark.Text = info.SpecialAskRemark;
            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票)
            {
                if (info.TourOrderHotelPlanList != null && info.TourOrderHotelPlanList.Count > 0)
                {
                    this.CustomerRequiredControl1.SetPlanList = info.TourOrderHotelPlanList;
                }
            }
            else
            {
                this.CustomerRequiredControl1.Visible = false;
            }

            if (info.TourOrderTravellerList != null && info.TourOrderTravellerList.Count > 0)
            {
                this.OrderCustomer1.CustomerList = info.TourOrderTravellerList;
            }

            txtKeHu.KeHuId = info.BuyCompanyId;
            txtKeHu.KeHuMingCheng = info.BuyCompanyName;

            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行)
            {
                if (string.IsNullOrEmpty(info.XianLuId) || string.IsNullOrEmpty(info.XianLuId.Trim()))
                {
                    this.RouteSelect1.InitRouteId = info.RouteId;
                    this.RouteSelect1.InitRouteName = info.RouteName;
                }
            }

            DuiFangCaoZuoRenId = info.BuyOperatorId.ToString();

            ltrBiaoShiYanSeOptions.Text = GetBiaoShiYanSeOptions(info.BiaoShiYanSe);

            YeWuLeiXing = ((int)info.BusinessType).ToString();
            YeWuXingZhi = ((int)info.BusinessNature).ToString();

            if (Utils.GetQueryStringValue("isshow").Length > 0)
            {
                this.pdhAllBtns.Visible = false;
                this.lbcount.Visible = false;
            }

            txtYingErShu.Value = info.YingErRenShu.ToString();
            txtBuFangChaShuLiang.Value = info.BuFangChaRenShu.ToString();
            txtTuiFangChaShuLiang.Value = info.TuiFangChaRenShu.ToString();
            txtJiaJinE.Value = info.JiaJinE.ToString("F2");
            txtJianJinE.Value = info.JianJinE.ToString("F2");
            txtJiaBeiZhu.Value = info.JiaBeiZhu;
            txtJianBeiZhu.Value = info.JianBeiZhu;
            txtDingDanJinE.Value = info.DingDanJinE.ToString("F2");
            txtJiFen1.Value = info.JiFen1.ToString();
            txtJiFen2.Value = info.JiFen2.ToString();
            txtXiaDanBeiZhu.Text = info.XiaDanBeiZhu;

            txtJiaGeMingXi.Value = info.JiaGeMingXi;
            ltrJiaGeMingXi.Text = info.JiaGeMingXi;

            txtTuiFangChaJiaGe.Value = info.TuiFangChaJiaGe.ToString("F2");
            txtBuFangChaJiaGe.Value = info.BuFangChaJiaGe.ToString("F2");

            txtKeHuLxrName.Value = info.DingDanLxrXingMing;
            txtKeHuLxrDianHua.Value = info.DingDanLxrDianHua;
            txtKeHuLxrShouJi.Value = info.DingDanLxrShouJi;
            txtKeHuLxrFax.Value = info.DingDanLxrFax;

            txtChengRenJiaGe.Value = info.ChengRenJiaGe.ToString("F2");
            txtErTongJiaGe.Value = info.ErTongJiaGe.ToString("F2");
            txtYingErJiaGe.Value = info.YingErJiaGe.ToString("F2");
            txtQuanPeiJiaGe.Value = info.QuanPeiJiaGe.ToString("F2");

            txtXianLuId.Value = info.XianLuId;
            JiFenXianShiBiaoShi = info.JiFenXianShiBiaoShi;

            var jiaGeInfo = new MDingDanJiaGeInfo();
            jiaGeInfo.BuFangChaJiaGe = info.BuFangChaJiaGe;
            jiaGeInfo.ChengRenJiaGe = info.ChengRenJiaGe;
            jiaGeInfo.ErTongJiaGe = info.ErTongJiaGe;
            jiaGeInfo.JiaJinE = info.JiaJinE;
            jiaGeInfo.JianJinE = info.JianJinE;
            jiaGeInfo.JiFen1 = info.JiFen1;
            jiaGeInfo.QuanPeiJiaGe = info.QuanPeiJiaGe;
            jiaGeInfo.RouteId = info.RouteId;
            jiaGeInfo.TuiFangChaJiaGe = info.TuiFangChaJiaGe;
            jiaGeInfo.XianLuId = info.XianLuId.Trim();
            jiaGeInfo.YingErJiaGe = info.YingErJiaGe;

            InitCaoZuo(info);
            InitTiShiXinXi(info);

            string script = string.Format("dingDanJiaGe={0};", Newtonsoft.Json.JsonConvert.SerializeObject(jiaGeInfo));
            RegisterScript(script);
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.TourStructure.MTourOrder GetFormInfo()
        {
            var info = new EyouSoft.Model.TourStructure.MTourOrder();

            info.Accounts = Utils.GetInt(Utils.GetFormValue(this.txtSeatCount.UniqueID));
            info.Adults = Utils.GetInt(Utils.GetFormValue(this.txtAdultCount.UniqueID));
            info.Bears = Utils.GetInt(Utils.GetFormValue(this.txtQuanPeiCount.UniqueID));
            info.BusinessNature = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.BusinessNature>(Utils.GetFormValue("sltxingzhi"), EyouSoft.Model.EnumType.TourStructure.BusinessNature.散拼);
            info.BusinessType = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.BusinessType>(Utils.GetFormValue("sltYewutype"), EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游);
            info.BuyCompanyId = Utils.GetFormValue(this.txtKeHu.KeHuIdClientName);
            info.BuyOperatorId = Utils.GetInt(Utils.GetFormValue("txtDuiFangCaoZuoRen"));            
            info.Childs = Utils.GetInt(Utils.GetFormValue(this.txtChildCount.UniqueID));
            info.CompanyId = CurrentUserCompanyID;
            info.CongregationPlace = Utils.GetFormValue(this.txtJiHeDiDian1.UniqueID);
            info.CongregationTime = Utils.GetFormValue(this.txtJiHeShiJian1.UniqueID);
            info.GroundRemark = Utils.GetFormValue(this.txtGroundRemark.UniqueID);
            info.IssueTime = DateTime.Now;
            info.OperatoRemark = Utils.GetFormValue(this.txtOperatorRemark.UniqueID);
            info.OperatorId = SiteUserInfo.UserId;
            info.OperatorName = SiteUserInfo.Username;
            info.PriceDetials = Utils.GetFormValue(this.txtPriceDesc.UniqueID);
            info.PriceRemark = Utils.GetFormValue(this.txtPriceRemark.UniqueID);
            info.RouteId = Utils.GetFormValue(this.RouteSelect1.HidClientName);
            info.SendTourInfo = Utils.GetFormValue(this.txtSongTuanXinXi.UniqueID);
            info.SpecialAskRemark = Utils.GetFormValue(this.txtYaoqiuRemark.UniqueID);
            info.SumPrice = Utils.GetDecimal(Utils.GetFormValue(this.txtTotalMoney.UniqueID));
            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票)
            {
                info.TourOrderHotelPlanList = UtilsCommons.GetTourOrderHotelPlanList();
            }
            else
            {
                info.TourOrderHotelPlanList = new List<MTourOrderHotelPlan>();
            }
            info.TourOrderTravellerList = this.OrderCustomer1.GetCustomerList();
            info.WelcomeWay = Utils.GetFormValue(this.txtMuDiDiJieTuanFangShi.UniqueID);
            info.TourId = KongWeiId;
            info.SaveSeatDate = null;
            info.BiaoShiYanSe = Utils.GetFormValue("txtBiaoShiYanSe");
            info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交;

            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店)
            {
                if (info.TourOrderHotelPlanList == null || info.TourOrderHotelPlanList.Count == 0)
                    info.BusinessType = EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票;
            }

            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票)
            {
                if(info.TourOrderHotelPlanList!=null&&info.TourOrderHotelPlanList.Count>0)
                    info.BusinessType = EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店;
            }

            info.IssueTime = DateTime.Now;
            info.LatestTime = DateTime.Now;
            info.LatestOperatorId = SiteUserInfo.UserId;
            info.ZxsId = CurrentZxsId;

            info.YingErRenShu = Utils.GetInt(Utils.GetFormValue(txtYingErShu.UniqueID));
            info.BuFangChaRenShu = Utils.GetInt(Utils.GetFormValue(txtBuFangChaShuLiang.UniqueID));
            info.TuiFangChaRenShu = Utils.GetInt(Utils.GetFormValue(txtTuiFangChaShuLiang.UniqueID));
            info.JiaJinE = Utils.GetDecimal(Utils.GetFormValue(txtJiaJinE.UniqueID));
            info.JianJinE=Utils.GetDecimal(Utils.GetFormValue(txtJianJinE.UniqueID));
            info.JiaBeiZhu = Utils.GetFormValue(txtJiaBeiZhu.UniqueID);
            info.JianBeiZhu = Utils.GetFormValue(txtJianBeiZhu.UniqueID);
            info.DingDanJinE = Utils.GetDecimal(Utils.GetFormValue(txtDingDanJinE.UniqueID));
            info.TuiFangChaJiaGe = Utils.GetDecimal(Utils.GetFormValue(txtTuiFangChaJiaGe.UniqueID));
            info.BuFangChaJiaGe = Utils.GetDecimal(Utils.GetFormValue(txtBuFangChaJiaGe.UniqueID));

            info.DingDanLxrXingMing = Utils.GetFormValue(txtKeHuLxrName.UniqueID);
            info.DingDanLxrDianHua = Utils.GetFormValue(txtKeHuLxrDianHua.UniqueID);
            info.DingDanLxrShouJi = Utils.GetFormValue(txtKeHuLxrShouJi.UniqueID);
            info.DingDanLxrFax = Utils.GetFormValue(txtKeHuLxrFax.UniqueID);

            string _txtXianLuLeiXing = Utils.GetFormValue(txtXianLuLeiXing.UniqueID);

            info.XianLuId = string.Empty;
            info.ChengRenJiaGe = Utils.GetDecimal(Utils.GetFormValue(txtChengRenJiaGe.UniqueID));
            info.ErTongJiaGe = Utils.GetDecimal(Utils.GetFormValue(txtErTongJiaGe.UniqueID));
            info.YingErJiaGe = Utils.GetDecimal(Utils.GetFormValue(txtYingErJiaGe.UniqueID));
            info.QuanPeiJiaGe = Utils.GetDecimal(Utils.GetFormValue(txtQuanPeiJiaGe.UniqueID));

            if (_txtXianLuLeiXing == "jihuanei")
            {
                info.XianLuId = Utils.GetFormValue("txtJiHuaNeiXianLu");
                if (!string.IsNullOrEmpty(info.XianLuId))
                {
                    var _xianLuInfo = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiXianLuInfo(info.XianLuId);
                    if (_xianLuInfo != null) info.RouteId = _xianLuInfo.RouteId;
                }
            }

            if (info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店 
                || info.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票)
            {
                info.XianLuId = Utils.GetFormValue(txtXianLuId.UniqueID);
                if (!string.IsNullOrEmpty(info.XianLuId))
                {
                    var _xianLuInfo = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiXianLuInfo(info.XianLuId);
                    if (_xianLuInfo != null) info.RouteId = _xianLuInfo.RouteId;
                }
            }

            info.JiFen1 = Utils.GetInt(Utils.GetFormValue(txtJiFen1.UniqueID));
            if (info.JiFen1 > 500) info.JiFen1 = 500;
            info.JiFen2 = info.Adults * info.JiFen1;
            info.XiaDanLeiXing = EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.系统下单;

            info.BuZhanWeiRenShu = info.Adults + info.Childs + info.YingErRenShu + info.Bears - info.Accounts;
            info.XiaDanBeiZhu = Utils.GetFormValue(txtXiaDanBeiZhu.UniqueID);

            /*if (string.IsNullOrEmpty(info.XianLuId)) info.XianLuId = string.Empty;
            else
            {
                info.JiaGeMingXi = Utils.GetFormValue(txtJiaGeMingXi.UniqueID);
            }*/
            info.JiaGeMingXi = Utils.GetFormValue(txtJiaGeMingXi.UniqueID);

            if (Utils.GetFormValue("txtJiFenXianShiBiaoShi") == "1") info.JiFenXianShiBiaoShi = EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi.不显示;
            else info.JiFenXianShiBiaoShi = EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi.显示;

            return info;
        }

        /// <summary>
        /// insert
        /// </summary>
        void Insert()
        {
            string _FS = string.Empty;
            _FS = Utils.GetQueryStringValue("dotype");

            var info = GetFormInfo();
            info.XiaDanLeiXing = EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.系统下单;

            if (ZxsJiFenStatus == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用)
            {
                info.JiFen1 = 0;
                info.JiFen2 = 0;
            }

            if (_FS == "liuwei") info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位;

            int bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().AddTourOrder(info);

            switch (bllRetCode)
            {
                case -99: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：计划已停收")); break;
                case -98: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：计划已客满")); break;
                case -97: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：控位已核算结束")); break;
                case 1: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作成功")); break;
                default: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败:异常代码" + bllRetCode)); break;
            }

            RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败!"));
        }

        /// <summary>
        /// update
        /// </summary>
        void Update()
        {
            string _FS = string.Empty;
            _FS = Utils.GetQueryStringValue("dotype");

            var info = GetFormInfo();
            info.OrderId = DingDanId;

            var yuanDingDanInfo= new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(info.OrderId);
            if (ZxsJiFenStatus == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用)
            {
                info.JiFen1=yuanDingDanInfo.JiFen1;
                info.JiFen2=yuanDingDanInfo.JiFen2;
            }

            if (_FS == "chengjiao") info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交;
            else if (_FS == "liuwei") info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位;
            else if (_FS == "baocun")
            {
                info.OrderStatus = yuanDingDanInfo.OrderStatus;

                if (yuanDingDanInfo.OrderStatus == EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全)
                {
                    if (info.XiaDanLeiXing == EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.系统下单)
                    {
                        info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位;
                    }
                    else if (info.XiaDanLeiXing == EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.平台下单)
                    {
                        info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认;
                    }
                }
            }
            else
            {
                RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败:异常请求"));
            }

            info.PageUri = EyouSoft.Toolkit.Utils.GetRequestUrlReferrer() + "&isshow=show";

            int bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().UpdateTourOrder(info);

            switch (bllRetCode)
            {
                case -99:  RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：计划已客满"));break;
                case -98: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已安排地接，不允许修改订单性质")); break;
                case -97: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已安排地接，不允许取消")); break;
                case -96: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已安排出票，不允许取消")); break;
                case -95: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：存在收退款，不允许取消")); break;
                case -94: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：存在酒店安排且有支出登记，不允许取消")); break;
                case 1: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作成功")); break;
                default: RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败:异常代码" + bllRetCode)); break;
            }

            RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败!"));
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        void Save()
        {
            if (string.IsNullOrEmpty(DingDanId))
            {
                Insert();
            }

            Update();
        }
        
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (string.IsNullOrEmpty(DingDanId))
            {
                this.pdhAllBtns.Visible = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_新增);
            }
            else
            {
                this.pdhAllBtns.Visible = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改);
            }
        }

        /// <summary>
        /// 获取标识颜色下拉菜单项
        /// </summary>
        /// <param name="yanSe">需要选中的颜色</param>
        /// <returns></returns>
        string GetBiaoShiYanSeOptions(string yanSe)
        {
            if (string.IsNullOrEmpty(yanSe)) yanSe = string.Empty;

            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">系统默认</option>");

            if (yanSe == "#ff0000")
            {
                s.Append("<option value=\"#ff0000\" style=\"background:#ff0000\" selected=\"selected\">红色</option>");
            }
            else
            {
                s.Append("<option value=\"#ff0000\" style=\"background:#ff0000\">红色</option>");
            }

            if (yanSe == "#0000ff")
            {
                s.Append("<option value=\"#0000ff\" style=\"background:#0000ff\" selected=\"selected\">蓝色</option>");
            }
            else
            {
                s.Append("<option value=\"#0000ff\" style=\"background:#0000ff\">蓝色</option>");
            }

            if (yanSe == "#008000")
            {
                s.Append("<option value=\"#008000\" style=\"background:#008000\" selected=\"selected\">绿色</option>");
            }
            else
            {
                s.Append("<option value=\"#008000\" style=\"background:#008000\">绿色</option>");
            }

            return s.ToString();
        }

        /// <summary>
        /// 初始化操作栏
        /// </summary>
        /// <param name="info"></param>
        void InitCaoZuo(EyouSoft.Model.TourStructure.MTourOrder info)
        {
            if (!pdhAllBtns.Visible) return;

            if (KongWeiZhuangTai == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束)
            {
                ph_HeSuanJieShu.Visible = true;
                ph_ChengJiao.Visible = ph_BaoCun.Visible = ph_LiuWei.Visible = ph_QuXiao.Visible = ph_HuiFu.Visible = ph_JuJue.Visible = false;
                return;
            }

            ph_ChengJiao.Visible = ph_LiuWei.Visible = false;

            if (info.XiaDanLeiXing == EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.系统下单)
            {
                switch (info.OrderStatus)
                {
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.留位过期:
                        this.pdhAllBtns.Visible = false;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交:
                        this.ph_BaoCun.Visible = this.ph_QuXiao.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位:
                        this.ph_ChengJiao.Visible = this.ph_BaoCun.Visible = this.ph_QuXiao.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已取消:
                        this.ph_HuiFu.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认:
                        ph_ChengJiao.Visible = ph_LiuWei.Visible =ph_BaoCun.Visible= this.ph_QuXiao.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全:
                        ph_ChengJiao.Visible = ph_LiuWei.Visible = ph_BaoCun.Visible = this.ph_QuXiao.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.申请中:
                        ph_ChengJiao.Visible = ph_LiuWei.Visible = ph_BaoCun.Visible = this.ph_QuXiao.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已拒绝:
                        this.ph_HuiFu.Visible = true;
                        break;
                }
            }

            if (info.XiaDanLeiXing == EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.平台下单)
            {
                switch (info.OrderStatus)
                {
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.留位过期:
                        this.pdhAllBtns.Visible = false;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交:
                        this.ph_BaoCun.Visible = this.ph_JuJue.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位:
                        this.ph_ChengJiao.Visible = this.ph_BaoCun.Visible = this.ph_JuJue.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已取消:
                        this.ph_HuiFu.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认:
                        ph_ChengJiao.Visible = ph_LiuWei.Visible = ph_BaoCun.Visible = this.ph_JuJue.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全:
                        ph_ChengJiao.Visible = ph_LiuWei.Visible = ph_BaoCun.Visible = this.ph_JuJue.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.申请中:
                        ph_ChengJiao.Visible = ph_LiuWei.Visible = ph_BaoCun.Visible = this.ph_JuJue.Visible = true;
                        break;
                    case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已拒绝:
                        this.ph_HuiFu.Visible = true;
                        break;
                }
            }
        }

        /// <summary>
        /// 恢复订单
        /// </summary>
        void HuiFu()
        {
            int bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().HuiFuDingDan(DingDanId, SiteUserInfo.UserId, 0);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 初始化提示信息
        /// </summary>
        /// <param name="info"></param>
        void InitTiShiXinXi(EyouSoft.Model.TourStructure.MTourOrder info)
        {
            ph_TiShiXinXi.Visible = true;

            StringBuilder s = new StringBuilder();
            s.AppendFormat("当前订单状态为：<b>{0}</b>。", info.OrderStatus);

            if (info.XiaDanLeiXing == EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.系统下单)
            {
                s.AppendFormat("下单方式：代客预订。");
            }
            if (info.XiaDanLeiXing == EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.平台下单)
            {
                s.AppendFormat("下单方式：平台自行预订。");
            }

            s.AppendFormat("下单人：{0}，下单时间：{1}。", info.OperatorName, info.IssueTime.Value.ToString("yyyy-MM-dd HH:mm"));
            s.AppendFormat("最后操作人：{0}，最后操作时间：{1}。", info.LatestOperatorName, info.LatestTime.ToString("yyyy-MM-dd HH:mm"));

            if (info.OrderStatus == EyouSoft.Model.EnumType.TourStructure.OrderStatus.已取消)
            {
                s.AppendFormat("<br/>取消原因：{0}。", string.IsNullOrEmpty(info.YuanYin1) ? "无" : info.YuanYin1);
            }

            if (info.OrderStatus == EyouSoft.Model.EnumType.TourStructure.OrderStatus.已拒绝)
            {
                s.AppendFormat("<br/>拒绝原因：{0}。", string.IsNullOrEmpty(info.YuanYin2) ? "无" : info.YuanYin2);
            }

            ltrTiShiXinXi.Text = s.ToString();
        }

        /// <summary>
        /// init zxs jifenstatus
        /// </summary>
        void InitZxsJiFenStatus()
        {
            ZxsJiFenStatus = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetZxsJiFenStatus(CurrentZxsId);
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取基础信息下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType jiChuXinXiType)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</options>");
            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, jiChuXinXiType,null,CurrentZxsId);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</options>", item.Name);
                }
            }

            return s.ToString();
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
        /// 成人单价
        /// </summary>
        public decimal ChengRenJiaGe { get; set; }
        /// <summary>
        /// 儿童单价
        /// </summary>
        public decimal ErTongJiaGe { get; set; }
        /// <summary>
        /// 全陪单价
        /// </summary>
        public decimal QuanPeiJiaGe { get; set; }
        /// <summary>
        /// 婴儿单价
        /// </summary>
        public decimal YingErJiaGe { get; set; }
        /// <summary>
        /// 增加金额
        /// </summary>
        public decimal JiaJinE { get; set; }
        /// <summary>
        /// 减少金额
        /// </summary>
        public decimal JianJinE { get; set; }
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
        /// 线路编号
        /// </summary>
        public string RouteId { get; set; }
    }
    #endregion
}
