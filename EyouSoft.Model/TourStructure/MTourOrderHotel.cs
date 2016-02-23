using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.TourStructure
{
    public class MTourOrderHotel
    {
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 去程日期
        /// </summary>
        public DateTime? QuDate { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 点单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 成人数
        /// </summary>
        public int Adults { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int Childs { get; set; }
        /// <summary>
        /// 客户单位
        /// </summary>
        public string BuyCompanyId { get; set; }
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string BuyCompanyName { get; set; }
        /// <summary>
        /// 对方操作人Id
        /// </summary>
        public int BuyOperatorId { get; set; }
        /// <summary>
        /// 对方操作人名称
        /// </summary>
        public string BuyOperator { get; set; }
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
        /// 特殊要求说明
        /// </summary>
        public string SpecialAskRemark { get; set; }
        /// <summary>
        /// 操作备注
        /// </summary>
        public string OperatoRemark { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 游客集合
        /// </summary>
        public IList<MTourOrderTraveller> TourOrderTravellerList { get; set; }
        /// <summary>
        /// 酒店安排的集合
        /// </summary>
        public IList<MTourOrderHotelPlan> TourOrderHotelPlanList { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 页面地址
        /// </summary>
        public string PageUri { get; set; }
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
    }


    /// <summary>
    /// 代订酒店列表实体
    /// </summary>
    public class MTour_OrderHotel
    {
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 客户单位
        /// </summary>
        public string BuyCompanyName { get; set; }
        /// <summary>
        /// 对方操作人
        /// </summary>
        public string BuyOperatorName { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 控位状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai KongWeiZhuangTai { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }

    /// <summary>
    /// 查询实体
    /// </summary>
    public class MSearchTourOrderHotel
    {
        /// <summary>
        /// 出团开始时间
        /// </summary>
        public DateTime? LBeginDate { get; set; }
        /// <summary>
        /// 出团结束时间
        /// </summary>
        public DateTime? LEndDate { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// 游客名称
        /// </summary>
        public string TravellerName { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 控位状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai? KongWeiZhuangTai { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
}
