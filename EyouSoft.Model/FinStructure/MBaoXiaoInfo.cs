//财务管理-报销管理相关信息业务实体 汪奇志 2012-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 报销信息业务实体
    /// <summary>
    /// 报销信息业务实体
    /// </summary>
    public class MBaoXiaoInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MBaoXiaoInfo() { }

        /// <summary>
        /// 报销编号
        /// </summary>
        public string BaoXiaoId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 报销日期
        /// </summary>
        public DateTime BaoXiaoRiQi { get; set; }
        /// <summary>
        /// 报销人编号
        /// </summary>
        public int BaoXiaoRenId { get; set; }
        /// <summary>
        /// 报销人姓名
        /// </summary>
        public string BaoXiaoRenName { get; set; }
        /// <summary>
        /// 报销状态
        /// </summary>
        public EnumType.FinStructure.BaoXiaoStatus Status { get; set; }
        /// <summary>
        /// 报销总金额
        /// </summary>
        public decimal JinE { get; set; }
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
        /// 付款账户编号
        /// </summary>
        public string ZhangHuId { get; set; }
        /// <summary>
        /// 付款账户名称
        /// </summary>
        public string ZhangHuName { get; set; }
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
        /// 消费明细信息集合
        /// </summary>
        public IList<MBaoXiaoXiaoFeiInfo> XiaoFeis { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 报销消费明细信息业务实体
    /// <summary>
    /// 报销消费明细信息业务实体
    /// </summary>
    public class MBaoXiaoXiaoFeiInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MBaoXiaoXiaoFeiInfo() { }

        /// <summary>
        /// 消费日期
        /// </summary>
        public DateTime XiaoFeiRiQi { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public EnumType.FinStructure.BaoXiaoXiaoFeiType XiaoFeiType { get; set; }
        /// <summary>
        /// 消费备注
        /// </summary>
        public string XiaoFeiBeiZhu { get; set; }
    }
    #endregion

    #region 报销查询信息业务实体
    /// <summary>
    /// 报销查询信息业务实体
    /// </summary>
    public class MBaoXiaoChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MBaoXiaoChaXunInfo() { }

        /// <summary>
        /// 报销起始日期
        /// </summary>
        public DateTime? SRiQi { get; set; }
        /// <summary>
        /// 报销截止日期
        /// </summary>
        public DateTime? ERiQi { get; set; }
        /// <summary>
        /// 报销人姓名
        /// </summary>
        public string BaoXiaoRenName { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public EnumType.FinStructure.BaoXiaoXiaoFeiType? XiaoFeiType { get; set; }
        /// <summary>
        /// 报销金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator BaoXiaoJinEOperator { get; set; }
        /// <summary>
        /// 报销金额
        /// </summary>
        public decimal? BaoXiaoJinE { get; set; }
        /// <summary>
        /// 报销状态
        /// </summary>
        public EnumType.FinStructure.BaoXiaoStatus? BaoXiaoStatus { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
