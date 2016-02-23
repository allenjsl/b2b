//财务管理出纳日记账相关信息业务实体 汪奇志 2012-11-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 出纳日记账信息业务实体
    /// <summary>
    /// 出纳日记账信息业务实体
    /// </summary>
    public class MRiJiZhangInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MRiJiZhangInfo() { }

        /// <summary>
        /// 日记账编号
        /// </summary>
        public string RiJiId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime DengJiRiQi { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public EnumType.FinStructure.RiJiZhangXiangMu XiangMu { get; set; }
        /*/// <summary>
        /// 业务日期
        /// </summary>
        public string YeWuRiQi { get; set; }*/
        /// <summary>
        /// 业务日期
        /// </summary>
        public string YeWuRiQi { get { return YeWuRiQi1.ToString("yyyy-MM-dd"); } }
        /// <summary>
        /// 凭证编号
        /// </summary>
        public string PingZhengHao { get; set; }
        /// <summary>
        /// 银行账户编号
        /// </summary>
        public string ZhangHuId { get; set; }
        /// <summary>
        /// 银行账户名称
        /// </summary>
        public string ZhangHuName { get; set; }
        /// <summary>
        /// 往来单位
        /// </summary>
        public string WangLaiDanWei { get; set; }
        /// <summary>
        /// 明细
        /// </summary>
        public string MingXi { get; set; }
        /// <summary>
        /// 借方金额
        /// </summary>
        public decimal JieFangJinE { get; set; }
        /// <summary>
        /// 贷方金额
        /// </summary>
        public decimal DaiFangJinE { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal YuE { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 往来单位编号
        /// </summary>
        public string WangLaiDanWeiId { get; set; }
        /// <summary>
        /// 往来单位类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.RiJiZhangDanWeiType WangLaiDanWeiLeiXing { get; set; }
        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime YeWuRiQi1 { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 出纳日记账查询信息业务实体
    /// <summary>
    /// 出纳日记账查询信息业务实体
    /// </summary>
    public class MRiJiZhangChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MRiJiZhangChaXunInfo() { }

        /// <summary>
        /// 登记起始日期
        /// </summary>
        public DateTime? SDengJiRiQi { get; set; }
        /// <summary>
        /// 登记截止日期
        /// </summary>
        public DateTime? EDengJiRiQi { get; set; }
        /// <summary>
        /// 业务起始日期
        /// </summary>
        public DateTime? SYeWuRiQi { get; set; }
        /// <summary>
        /// 业务截止时间
        /// </summary>
        public DateTime? EYeWuRiQi { get; set; }
        /// <summary>
        /// 凭证号
        /// </summary>
        public string PingZhengHao { get; set; }
        /// <summary>
        /// 银行账户编号
        /// </summary>
        public string YinHangZhangHuId { get; set; }
        /// <summary>
        /// 借方金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator JieFangJinEOperator { get; set; }
        /// <summary>
        /// 借方金额
        /// </summary>
        public decimal? JieFangJinE { get; set; }
        /// <summary>
        /// 贷方金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator DaiFangJinEOperator { get; set; }
        /// <summary>
        /// 贷方金额
        /// </summary>
        public decimal? DaiFangJinE { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public EnumType.FinStructure.RiJiZhangXiangMu? XiangMu { get; set; }
        /// <summary>
        /// 往来单位名称
        /// </summary>
        public string WangLaiDanWeiName { get; set; }
        /// <summary>
        /// 往来单位编号
        /// </summary>
        public string WangLaiDanWeiId { get; set; }
        /// <summary>
        /// 往来单位类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.RiJiZhangDanWeiType? WangLaiDanWeiLeiXing { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
