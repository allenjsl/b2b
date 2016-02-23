//银行核对相关信息业务实体 汪奇志 2012-11-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 银行核对信息业务实体
    /// <summary>
    /// 银行核对信息业务实体
    /// </summary>
    public class MYinHangHeDuiInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYinHangHeDuiInfo() { }

        /// <summary>
        /// 核对编号
        /// </summary>
        public string HeDuiId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime YeWuRiQi { get; set; }
        /// <summary>
        /// 借方总额(业务日期)
        /// </summary>
        public decimal JieFangZongE { get; set; }
        /// <summary>
        /// 贷方总额(业务日期)
        /// </summary>
        public decimal DaiFangZongE { get; set; }
        /// <summary>
        /// 流水总额(业务日期)
        /// </summary>
        public decimal LiuShuiZongE { get; set; }
        /// <summary>
        /// 银行总额(业务日期前一天)
        /// </summary>
        public decimal YinHangZongE { get; set; }
        /// <summary>
        /// 差额
        /// </summary>
        public decimal ChaE
        {
            get
            {
                return YinHangZongE + JieFangZongE - DaiFangZongE - LiuShuiZongE;
            }
        }
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
        public int? ShenHeOperatorId { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ShenHeTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EnumType.FinStructure.YinHangHeDuiStatus Status { get; set; }
        /// <summary>
        /// 银行核对账户信息集合
        /// </summary>
        public IList<MYinHangHeDuiZhangHuInfo> ZhangHus { get; set; }
        /// <summary>
        /// 业务日期前一天日期
        /// </summary>
        public DateTime RiQi { get { return YeWuRiQi.AddDays(-1); } }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 银行核对账户信息业务实体
    /// <summary>
    /// 银行核对账户信息业务实体
    /// </summary>
    public class MYinHangHeDuiZhangHuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYinHangHeDuiZhangHuInfo() { }

        /// <summary>
        /// 银行账户编号
        /// </summary>
        public string ZhangHuId { get; set; }
        /// <summary>
        /// 余额(业务日期前一天)
        /// </summary>
        public decimal YuE { get; set; }
        /// <summary>
        /// 借方金额(业务日期)
        /// </summary>
        public decimal JieFangJinE { get; set; }
        /// <summary>
        /// 贷方金额(业务日期)
        /// </summary>
        public decimal DaiFangJinE { get; set; }
        /// <summary>
        /// 账户名称
        /// </summary>
        public string ZhangHuName { get; set; }
        /// <summary>
        /// 开户银行名称
        /// </summary>
        public string YinHangName { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string ZhangHao { get; set; }
    }
    #endregion

    #region 银行核对查询信息业务实体
    /// <summary>
    /// 银行核对查询信息业务实体
    /// </summary>
    public class MYinHangHeDuiChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYinHangHeDuiChaXunInfo() { }

        /// <summary>
        /// 起始业务日期
        /// </summary>
        public DateTime? SYeWuRiQi { get; set; }
        /// <summary>
        /// 截止业务日期
        /// </summary>
        public DateTime? EYeWuRiQi { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
