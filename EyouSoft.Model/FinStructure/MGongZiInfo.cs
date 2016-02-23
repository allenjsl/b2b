using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 财务管理-工资信息业务实体
    /// <summary>
    /// 财务管理-工资信息业务实体
    /// </summary>
    public class MGongZiInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MGongZiInfo() { }

		/// <summary>
		/// 工资编号
		/// </summary>
        public string GongZiId { get; set; }
		/// <summary>
		/// 公司编号
		/// </summary>
        public int CompanyId { get; set; }
		/// <summary>
		/// 员工编号
		/// </summary>
        public int YuanGongId { get; set; }
        /// <summary>
        /// 员工姓名（OUTPUT）
        /// </summary>
        public string YuanGongName { get; set; }
		/// <summary>
		/// 工资年份
		/// </summary>
        public int Year { get; set; }
		/// <summary>
		/// 工资月份
		/// </summary>
        public int Month { get; set; }
		/// <summary>
		/// 工资年月(工资年月-01)
		/// </summary>
        public DateTime YMD { get; set; }
		/// <summary>
		/// 基本工资
		/// </summary>
        public decimal JiBenGongZi { get; set; }
		/// <summary>
		/// 工龄补贴
		/// </summary>
        public decimal GongLingBuTie { get; set; }
		/// <summary>
		/// 生活费补贴
		/// </summary>
        public decimal ShengHuoFeiBuTie { get; set; }
		/// <summary>
		/// 社保补贴
		/// </summary>
        public decimal SheBaoBuTie { get; set; }
		/// <summary>
		/// 岗位补贴
		/// </summary>
        public decimal GangWeiBuTie { get; set; }
		/// <summary>
		/// 季度奖金
		/// </summary>
        public decimal JiDuJiangJin { get; set; }
		/// <summary>
		/// 社保扣除
		/// </summary>
        public decimal SheBaoKouChu { get; set; }
		/// <summary>
		/// 工资合计
		/// </summary>
        public decimal GongZiHeJi { get; set; }
		/// <summary>
		/// 生活费扣除
		/// </summary>
        public decimal ShengHuoFeiKouChu { get; set; }
		/// <summary>
		/// 生活费扣除明细
		/// </summary>
        public string ShengHuoFeiBeiZhu { get; set; }
		/// <summary>
		/// 迟到扣除
		/// </summary>
        public decimal ChiDaoKouChu { get; set; }
		/// <summary>
		/// 迟到扣除明细
		/// </summary>
        public string ChiDaoBeiZhu { get; set; }
		/// <summary>
		/// 其他扣除
		/// </summary>
        public decimal QiTaKouChu { get; set; }
		/// <summary>
		/// 其他扣除明细
		/// </summary>
        public string QiTaBeiZhu { get; set; }
		/// <summary>
		/// 季度奖金明细
		/// </summary>
        public string JiDuJiangJinBeiZhu { get; set; }
		/// <summary>
		/// 实发工资
		/// </summary>
        public decimal ShiFaGongZi { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
        public string BeiZhu { get; set; }
		/// <summary>
		/// 状态
		/// </summary>
        public EyouSoft.Model.EnumType.FinStructure.GongZiStatus Status { get; set; }
		/// <summary>
		/// 审核人编号
		/// </summary>
        public int? ShenHeOperatorId { get; set; }
        /// <summary>
        /// 审核人姓名（OUTPUT）
        /// </summary>
        public string ShenHeOperatorName { get; set; }
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
        public int? ZhiFuOperatorId { get; set; }
        /// <summary>
        /// 支付人姓名（OUTPUT）
        /// </summary>
        public string ZhiFuOperatorName { get; set; }
		/// <summary>
		/// 支付时间
		/// </summary>
        public DateTime? ZhiFuTime { get; set; }
        /// <summary>
        /// 支付备注
        /// </summary>
        public string ZhiFuBeiZhu { get; set; }
		/// <summary>
		/// 银行账户编号
		/// </summary>
        public string ZhangHuId { get; set; }
		/// <summary>
		/// 银行实际业务日期
		/// </summary>
        public DateTime? YingHangTime { get; set; }
		/// <summary>
		/// 发放时间
		/// </summary>
        public DateTime FaFangTime { get; set; }
		/// <summary>
		/// 操作人编号
		/// </summary>
        public int OperatorId { get; set; }
		/// <summary>
		/// 操作时间
		/// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 工资发放类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.GongZiFaFangLeiXing FaFangLeiXing { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 财务管理-工资信息查询业务实体
    /// <summary>
    /// 财务管理-工资信息查询业务实体
    /// </summary>
    public class MGongZiChaXunInfo
    {
        /// <summary>
        /// 起始年份
        /// </summary>
        public int? SYear { get; set; }
        /// <summary>
        /// 起始月份
        /// </summary>
        public int? SMonth { get; set; }
        /// <summary>
        /// 截止年份
        /// </summary>
        public int? EYear { get; set; }
        /// <summary>
        /// 截止月份
        /// </summary>
        public int? EMonth { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string YuanGongName { get; set; }
        /// <summary>
        /// 工资发放类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.GongZiFaFangLeiXing? FaFangLeiXing { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public int? YuanGongId { get; set; }
        /// <summary>
        /// 工资状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.GongZiStatus? Status { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 工资合计信息业务实体
    /// <summary>
    /// 工资合计信息业务实体
    /// </summary>
    public class MGongZiHeJiInfo
    {
        /// <summary>
        /// 基本工资
        /// </summary>
        public decimal JiBenGongZi { get; set; }
        /// <summary>
        /// 工龄补贴
        /// </summary>
        public decimal GongLingBuTie { get; set; }
        /// <summary>
        /// 生活费补贴
        /// </summary>
        public decimal ShengHuoFeiBuTie { get; set; }
        /// <summary>
        /// 社保补贴
        /// </summary>
        public decimal SheBaoBuTie { get; set; }
        /// <summary>
        /// 岗位补贴
        /// </summary>
        public decimal GangWeiBuTie { get; set; }
        /// <summary>
        /// 季度奖金
        /// </summary>
        public decimal JiDuJiangJin { get; set; }
        /// <summary>
        /// 社保扣除
        /// </summary>
        public decimal SheBaoKouChu { get; set; }
        /// <summary>
        /// 工资合计
        /// </summary>
        public decimal GongZiHeJi { get; set; }
        /// <summary>
        /// 生活费扣除
        /// </summary>
        public decimal ShengHuoFeiKouChu { get; set; }
        /// <summary>
        /// 生活费扣除明细
        /// </summary>
        public string ShengHuoFeiBeiZhu { get; set; }
        /// <summary>
        /// 迟到扣除
        /// </summary>
        public decimal ChiDaoKouChu { get; set; }
        /// <summary>
        /// 迟到扣除明细
        /// </summary>
        public string ChiDaoBeiZhu { get; set; }
        /// <summary>
        /// 其他扣除
        /// </summary>
        public decimal QiTaKouChu { get; set; }
        /// <summary>
        /// 其他扣除明细
        /// </summary>
        public string QiTaBeiZhu { get; set; }
        /// <summary>
        /// 季度奖金明细
        /// </summary>
        public string JiDuJiangJinBeiZhu { get; set; }
        /// <summary>
        /// 实发工资
        /// </summary>
        public decimal ShiFaGongZi { get; set; }        
    }
    #endregion
}
