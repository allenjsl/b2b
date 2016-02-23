using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.TourStructure
{
    #region 订单基类
    /// <summary>
    /// 订单基类
    /// </summary>
    public class MBaseTourOrder
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public string TourId { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType? BusinessType { get; set; }
        /// <summary>
        /// 性质
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessNature? BusinessNature { get; set; }
        /// <summary>
        /// 成人数
        /// </summary>
        public int Adults { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int Childs { get; set; }
        /// <summary>
        /// 全配数
        /// </summary>
        public int Bears { get; set; }
        /// <summary>
        /// 占位数
        /// </summary>
        public int Accounts { get; set; }
        /// <summary>
        /// 客源单位编号
        /// </summary>
        public string BuyCompanyId { get; set; }
        /// <summary>
        /// 客源单位名称
        /// </summary>
        public string BuyCompanyName { get; set; }
        /// <summary>
        /// 对方操作人编号
        /// </summary>
        public int BuyOperatorId { get; set; }
        /// <summary>
        /// 对方操作人姓名
        /// </summary>
        public string BuyOperatorName { get; set; }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string RouteId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 价格明细
        /// </summary>
        public string PriceDetials { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal SumPrice { get; set; }
        /// <summary>
        /// 价格备注
        /// </summary>
        public string PriceRemark { get; set; }
        /// <summary>
        /// 集合地点
        /// </summary>
        public string CongregationPlace { get; set; }
        /// <summary>
        /// 集合时间
        /// </summary>
        public string CongregationTime { get; set; }
        /// <summary>
        /// 送团方式
        /// </summary>
        public string SendTourInfo { get; set; }
        /// <summary>
        /// 接团方式
        /// </summary>
        public string WelcomeWay { get; set; }
        /// <summary>
        /// 特殊要求
        /// </summary>
        public string SpecialAskRemark { get; set; }
        /// <summary>
        /// 地接备注
        /// </summary>
        public string GroundRemark { get; set; }
        /// <summary>
        /// 操作备注
        /// </summary>
        public string OperatoRemark { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.OrderStatus? OrderStatus { get; set; }
        /// <summary>
        /// 留位时间
        /// </summary>
        public DateTime? SaveSeatDate { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? IssueTime { get; set; }
        /// <summary>
        /// 已收金额(已审核)
        /// </summary>
        public decimal CheckMoney { get; set; }
        /// <summary>
        /// 已退金额(已审核)
        /// </summary>
        public decimal ReturnMoney { get; set; }
        /// <summary>
        /// 已收金额(不管审核状态)
        /// </summary>
        public decimal ReceivedMoney { get; set; }
        /// <summary>
        /// 已退金额(不管审核状态)
        /// </summary>
        public decimal RefundMoney { get; set; }
        /// <summary>
        /// 未收金额/待收金额
        /// </summary>
        public decimal WeiShouJine
        {
            get
            {
                return this.SumPrice - this.CheckMoney + this.ReturnMoney;
            }
        }
        /// <summary>
        /// 标识颜色
        /// </summary>
        public string BiaoShiYanSe { get; set; }
        /// <summary>
        /// 下单类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing XiaDanLeiXing { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 最后操作人编号
        /// </summary>
        public int LatestOperatorId { get; set; }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 婴儿数量
        /// </summary>
        public int YingErRenShu { get; set; }
        /// <summary>
        /// 不占位人数
        /// </summary>
        public int BuZhanWeiRenShu { get; set; }
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
        /// <summary>
        /// 增加金额备注
        /// </summary>
        public string JiaBeiZhu { get; set; }
        /// <summary>
        /// 减少金额备注
        /// </summary>
        public string JianBeiZhu { get; set; }
        /// <summary>
        /// 补房差人数
        /// </summary>
        public int BuFangChaRenShu { get; set; }
        /// <summary>
        /// 退房差人数
        /// </summary>
        public int TuiFangChaRenShu { get; set; }
        /// <summary>
        /// 补房差单价
        /// </summary>
        public decimal BuFangChaJiaGe { get; set; }
        /// <summary>
        /// 退房差单价
        /// </summary>
        public decimal TuiFangChaJiaGe { get; set; }
        /// <summary>
        /// 订单金额（不含退补房差、不含增减费用）
        /// </summary>
        public decimal DingDanJinE { get; set; }
        /// <summary>
        /// 单人积分
        /// </summary>
        public int JiFen1 { get; set; }
        /// <summary>
        /// 积分总计
        /// </summary>
        public int JiFen2 { get; set; }
        /// <summary>
        /// 下单备注
        /// </summary>
        public string XiaDanBeiZhu { get; set; }
        /// <summary>
        /// 取消原因
        /// </summary>
        public string YuanYin1 { get; set; }
        /// <summary>
        /// 拒绝原因
        /// </summary>
        public string YuanYin2 { get; set; }
        /// <summary>
        /// 计划内线路产品编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 最后操作人姓名
        /// </summary>
        public string LatestOperatorName { get; set; }

        /// <summary>
        /// 价格明细（自动）
        /// </summary>
        public string JiaGeMingXi { get; set; }
        /// <summary>
        /// 订单联系人姓名
        /// </summary>
        public string DingDanLxrXingMing { get; set; }
        /// <summary>
        /// 订单联系人手机
        /// </summary>
        public string DingDanLxrShouJi { get; set; }
        /// <summary>
        /// 订单联系人电话
        /// </summary>
        public string DingDanLxrDianHua { get; set; }
        /// <summary>
        /// 订单联系人传真
        /// </summary>
        public string DingDanLxrFax { get; set; }
        /// <summary>
        /// 显示的价格明细
        /// </summary>
        public string JiaGeMingXi1
        {
            get
            {
                if (!string.IsNullOrEmpty(PriceDetials)) return PriceDetials;
                return JiaGeMingXi;
            }
        }

        /// <summary>
        /// 积分显示标识
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi JiFenXianShiBiaoShi { get; set; }
    }
    #endregion

    #region 订单游客表
    /// <summary>
    /// 订单游客表
    /// </summary>
    public class MTourOrderTraveller
    {
        /// <summary>
        /// 游客编号
        /// </summary>
        public string TravellerId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 控位编号(计划编号)
        /// </summary>
        public string TourId { get; set; }
        /// <summary>
        /// 游客姓名
        /// </summary>
        public string TravellerName { get; set; }
        /// <summary>
        /// 游客类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.TravellerType TravellerType { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.CardType CardType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNumber { get; set; }        
        /// <summary>
        /// 性别
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.Sex Sex { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 游客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.TravellerStatus TravellerStatus { get; set; }
        /// <summary>
        /// TicketType出票状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.TicketType TicketType { get; set; }
    }
    #endregion

    #region 订单酒店安排
    /// <summary>
    /// 订单酒店安排
    /// </summary>
    public class MTourOrderHotelPlan
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string TourId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 交易号（程序自动生成）
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime? CheckInDate { get; set; }
        /// <summary>
        /// 退房时间
        /// </summary>
        public DateTime? CheckOutDate { get; set; }
        /// <summary>
        /// 房型
        /// </summary>
        public string Room { get; set; }
        /// <summary>
        /// 要求备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 间夜
        /// </summary>
        public string RoomNights { get; set; }
        /// <summary>
        /// 取房方式
        /// </summary>
        public string HumorWas { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GYSId { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GYSName { get; set; }
        /// <summary>
        /// 对方操作人编号
        /// </summary>
        public int SideOperatorId { get; set; }
        /// <summary>
        /// 结算明细
        /// </summary>
        public string SettleDetail { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal SettleAmount { get; set; }
        /// <summary>
        /// 安排备注
        /// </summary>
        public string PlanRemark { get; set; }
        /// <summary>
        /// 具体安排
        /// </summary>
        public string PlanDetail { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string FileInfo { get; set; }
        /// <summary>
        /// 是否存在收支
        /// </summary>
        public bool IsShouZhi { get; set; }
        /// <summary>
        /// 酒店明细安排信息集合
        /// </summary>
        public IList<MPlanHotelMxInfo> AnPaiMxs { get; set; }
    }
    #endregion

    #region 订单信息
    /// <summary>
    /// 订单信息
    /// </summary>
    public class MTourOrder : MBaseTourOrder
    {
        /// <summary>
        /// 页面地址
        /// </summary>
        public string PageUri { get; set; }
        /// <summary>
        /// 游客集合
        /// </summary>
        public IList<MTourOrderTraveller> TourOrderTravellerList { get; set; }
        /// <summary>
        /// 酒店安排的集合
        /// </summary>
        public IList<MTourOrderHotelPlan> TourOrderHotelPlanList { get; set; }
    }
    #endregion

    #region 线路下所有订单
    /// <summary>
    /// 线路下所有订单
    /// </summary>
    public class MRoute_TourOrder
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string BuyCompanyName { get; set; }
        /// <summary>
        /// 对方操作人
        /// </summary>
        public string BuyOperatorName { get; set; }
        /// <summary>
        /// 成人数
        /// </summary>
        public int Adults { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int Childs { get; set; }
        /// <summary>
        /// 全配数
        /// </summary>
        public int Bears { get; set; }
        /// <summary>
        /// 占位数
        /// </summary>
        public int Accounts { get; set; }
        /// <summary>
        /// 价格明细-录入
        /// </summary>
        public string PriceDetials { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal SumPrice { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingErRenShu { get; set; }
        /// <summary>
        /// 价格明细-自动
        /// </summary>
        public string JiaGeMingXi { get; set; }
        /// <summary>
        /// 价格明细-显示
        /// </summary>
        public string JiaGeMingXi1 { get { if (!string.IsNullOrEmpty(PriceDetials)) return PriceDetials; return JiaGeMingXi; } }
    }
    #endregion

    #region 订单酒店明细安排信息业务实体
    /// <summary>
    /// 订单酒店明细安排信息业务实体
    /// </summary>
    public class MPlanHotelMxInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MPlanHotelMxInfo() { }

        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KognWeiId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 安排编号
        /// </summary>
        public string AnPaiId { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public string RuZhuTime { get; set; }
        /// <summary>
        /// 退房时间
        /// </summary>
        public string TuiFangTime { get; set; }
        /// <summary>
        /// 房型
        /// </summary>
        public string FangXing { get; set; }
        /// <summary>
        /// 要求备注
        /// </summary>
        public string YaoQiuBeiZhu { get; set; }
        /// <summary>
        /// 间夜
        /// </summary>
        public string JianYe { get; set; }
        /// <summary>
        /// 取房方式
        /// </summary>
        public string QuFangFangShi { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string JiuDianName { get; set; }
    }
    #endregion
}
