//付款登记信息业务实体 汪奇志 2012-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 付款登记信息业务实体
    /// <summary>
    /// 付款登记信息业务实体
    /// </summary>
    public class MFuKuanInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MFuKuanInfo() { }

        /// <summary>
        /// 付款登记编号
        /// </summary>
        public string DengJiId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 付款登记类型
        /// </summary>
        public EnumType.FinStructure.KuanXiangType KuanXiangType { get; set; }
        /// <summary>
        /// 付款项目关联编号
        /// </summary>
        public string FuKuanXiangMuId { get; set; }
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime FuKuanRiQi { get; set; }
        /// <summary>
        /// 付款人姓名
        /// </summary>
        public string FuKuanRenName { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public EnumType.FinStructure.ShouFuKuanFangShi FangShi { get; set; }
        /// <summary>
        /// 付款账户编号
        /// </summary>
        public string ZhangHuId { get; set; }
        /// <summary>
        /// 付款账户名称
        /// </summary>
        public string ZhangHuName { get; set; }
        /// <summary>
        /// 付款备注
        /// </summary>
        public string FuKuanBeiZhu { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EnumType.FinStructure.KuanXiangStatus Status { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 银行实际业务日期
        /// </summary>
        public DateTime? BankDate { get; set; }
        /// <summary>
        /// 审核人编号
        /// </summary>
        public int? ShenHeRenId { get; set; }
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string ShenHeRenName { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ShenHeTime { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string ShenHeBeiZhu { get; set; }
        /// <summary>
        /// 支付人编号
        /// </summary>
        public int? ZhiFuRenId { get; set; }
        /// <summary>
        /// 支付人姓名
        /// </summary>
        public string ZhiFuRenName { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? ZhiFuTime { get; set; }
        /// <summary>
        /// 支付备注
        /// </summary>
        public string ZhiFuBeiZhu { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region  付款审批列表信息业务实体
    /// <summary>
    /// 付款审批列表信息业务实体
    /// </summary>
    public class MLBFuKuanShenPiInfo : MFuKuanInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MLBFuKuanShenPiInfo() { }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
    }
    #endregion

    #region  付款审批列表查询信息业务实体
    /// <summary>
    /// 付款审批列表查询信息业务实体
    /// </summary>
    public class MLBFuKuanShenPiChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MLBFuKuanShenPiChaXunInfo() { }

        /// <summary>
        /// 付款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType? KuanXiangType { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 付款金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator FuKuanJinEOperator { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal? FuKuanJinE { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }

        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus? FuKuanStatus { get; set; }
        /// <summary>
        /// 付款时间-起
        /// </summary>
        public DateTime? FuKuanShiJian1 { get; set; }
        /// <summary>
        /// 付款时间-止
        /// </summary>
        public DateTime? FuKuanShiJian2 { get; set; }
    }
    #endregion
}
