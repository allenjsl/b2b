//财务管理借款相关信息业务实体 汪奇志 2012-11-15 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 借款信息业务实体
    /// <summary>
    /// 借款信息业务实体
    /// </summary>
    public class MJieKuanInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MJieKuanInfo() { }

        /// <summary>
        /// 借款编号
        /// </summary>
        public string JieKuanId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 借款日期
        /// </summary>
        public DateTime JieKuanRiQi { get; set; }
        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 借款原因
        /// </summary>
        public string JieKuanYuanYin { get; set; }
        /// <summary>
        /// 贷款人编号
        /// </summary>
        public int JieKuanRenId { get; set; }
        /// <summary>
        /// 借款人姓名
        /// </summary>
        public string JieKuanRenName { get; set; }
        /// <summary>
        /// 借款状态
        /// </summary>
        public EnumType.FinStructure.JieKuanStatus Status { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }        
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
        /// 付款银行实际业务日期
        /// </summary>
        public DateTime? FuKuanBankDate { get; set; }
        /// <summary>
        /// 付款账户编号
        /// </summary>
        public string FuKuanZhangHuId { get; set; }
        /// <summary>
        /// 付款账户名称
        /// </summary>
        public string FuKuanZhangHuName { get; set; }
        /// <summary>
        /// 归还操作人编号
        /// </summary>
        public int? GuiHuanOperatorId { get; set; }
        /// <summary>
        /// 归还时间
        /// </summary>
        public DateTime? GuiHuanTime { get; set; }
        /// <summary>
        /// 归还备注
        /// </summary>
        public string GuiHuanBeiZhu { get; set; }
        /// <summary>
        /// 归还银行实际业务日期
        /// </summary>
        public DateTime? GuiHuanBankDate { get; set; }
        /// <summary>
        /// 归还账户编号
        /// </summary>
        public string GuiHuanZhangHuId { get; set; }
        /// <summary>
        /// 归还账户名称
        /// </summary>
        public string GuiHuanZhangHuName { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 借款查询信息业务实体
    /// <summary>
    /// 借款查询信息业务实体
    /// </summary>
    public class MJieKuanChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MJieKuanChaXunInfo() { }

        /// <summary>
        /// 借款开始日期
        /// </summary>
        public DateTime? SRiQi { get; set; }
        /// <summary>
        /// 借款结束日期
        /// </summary>
        public DateTime? ERiQi { get; set; }
        /// <summary>
        /// 借款人编号
        /// </summary>
        public int? JieKuanRenId { get; set; }
        /// <summary>
        /// 借款人姓名
        /// </summary>
        public string JieKuanRenName { get; set; }
        /// <summary>
        /// 借款状态
        /// </summary>
        public EnumType.FinStructure.JieKuanStatus? Status { get; set; }
        /// <summary>
        /// 借款金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator JieKuanJinEOperator { get; set; }
        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal? JieKuanJinE { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
