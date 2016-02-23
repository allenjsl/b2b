//收款相关信息业务实体  汪奇志 2012-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    /// <summary>
    /// 收款登记信息业务实体
    /// </summary>
    public class MShouKuanInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MShouKuanInfo() { }

        /// <summary>
        /// 收款登记编号
        /// </summary>
        public string DengJiId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 收款登记类型
        /// </summary>
        public EnumType.FinStructure.KuanXiangType KuanXiangType { get; set; }
        /// <summary>
        /// 收款项目编号
        /// </summary>
        public string ShouKuanXiangMuId { get; set; }
        /// <summary>
        /// 收款日期
        /// </summary>
        public DateTime ShouKuanRiQi { get; set; }
        /// <summary>
        /// 收款人姓名
        /// </summary>
        public string ShouKuanRenName { get; set; }
        /// <summary>
        /// 收款金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 收款方式
        /// </summary>
        public EnumType.FinStructure.ShouFuKuanFangShi FangShi { get; set; }
        /// <summary>
        /// 收款账户编号
        /// </summary>
        public string ZhangHuId { get; set; }
        /// <summary>
        /// 收款备注
        /// </summary>
        public string ShouKuanBeiZhu { get; set; }
        /// <summary>
        /// 收款状态
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
        /// 是否是出纳登记销账后产生的信息
        /// </summary>
        public bool IsXiaoZhang { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
}
