using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PersonalCenterStructure
{

    #region 个人中心-收款提醒实体
    /// <summary>
    /// 个人中心-收款提醒实体
    /// </summary>
    /// 鲁功源 2011-01-30
    public class MShouKuanTiXingInfo
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// 欠款单位名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 联系人名称（主要联系人）
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 联系电话（主要联系人电话）
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 欠款总额（总所有未收款）
        /// </summary>
        public decimal ArrearCash { get; set; }
    }
    #endregion

    #region 个人中心-付款提醒实体
    /// <summary>
    /// 个人中心-付款提醒实体
    /// </summary>
    public class MFuKuanTiXingInfo
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierId { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 联系人名称（供应商第一个联系人）
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 联系电话（供应商第一个联系电话）
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 欠款总额（汇总所有未收款）
        /// </summary>
        public decimal PayCash { get; set; }
    }
    #endregion

    #region 个人中心-公告通知实体
    /// <summary>
    /// 个人中心-公告通知实体
    /// </summary>
    public class NoticeNews
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ClickNum
        {
            get;
            set;
        }

        /// <summary>
        /// 发布人
        /// </summary>
        public string OperateName
        {
            get;
            set;
        }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? IssueTime
        {
            get;
            set;
        }
    }
    #endregion

    #region 个人中心-收款提醒查询实体
    /// <summary>
    /// 个人中心-收款提醒查询实体
    /// </summary>
    public class MShouKuanTiXingChaXunInfo
    {
        /// <summary>
        /// 客源单位
        /// </summary>
        public string QianKuanDanWei { get; set; }
        /// <summary>
        /// 出团起始时间
        /// </summary>
        public DateTime? LSDate { get; set; }
        /// <summary>
        /// 出团截止时间
        /// </summary>
        public DateTime? LEDate { get; set; }

        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 个人中心-付款提醒查询实体
    /// <summary>
    /// FuKuanTiXingChaXun
    /// </summary>
    /// 汪奇志 2012-02-23
    public class FuKuanTiXingChaXun
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public FuKuanTiXingChaXun() { }

        /// <summary>
        /// 出团起始时间
        /// </summary>
        public DateTime? LSDate { get; set; }
        /// <summary>
        /// 出团截止时间
        /// </summary>
        public DateTime? LEDate { get; set; }
        /// <summary>
        /// 收款单位
        /// </summary>
        public string ShouKuanDanWei { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 个人中心-付款提醒明细信息业务实体
    /// <summary>
    /// 个人中心-付款提醒明细信息业务实体
    /// </summary>
    public class MFuKuanTiXingMingXiInfo
    {
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 婴儿数
        /// </summary>
        public int YingErShu { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int QuanPeiShu { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 未支付金额
        /// </summary>
        public decimal WeiZhiFuJinE { get; set; }
    }
    #endregion

    #region 个人中心-收款提醒明细信息业务实体
    /// <summary>
    /// 个人中心-收款提醒明细信息业务实体
    /// </summary>
    public class MShouKuanTiXingMingXiInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 对方操作人姓名
        /// </summary>
        public string DuiFangCaoZuoRenName { get; set; }
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 婴儿数
        /// </summary>
        public int YingErShu { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int QuanPeiShu { get; set; }
        /// <summary>
        /// 占位数
        /// </summary>
        public int ZhanWeiShu { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 未收金额
        /// </summary>
        public decimal WeiShouJinE { get; set; }
    }
    #endregion
}
