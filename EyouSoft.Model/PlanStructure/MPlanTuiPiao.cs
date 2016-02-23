using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PlanStructure
{
    /// <summary>
    /// 出票安排退票信息表
    /// </summary>
    public class MBasePlanTuiPiao
    {
        /// <summary>
        /// 退票编号
        /// </summary>
        public string TuiId { get; set; }

        /// <summary>
        /// 安排编号
        /// </summary>
        public string PlanId { get; set; }

        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 退票时间
        /// </summary>
        public DateTime? TuiTime { get; set; }

        /// <summary>
        /// 退票数量
        /// </summary>
        public int ShuLiang { get; set; }

        /// <summary>
        /// 损失明细
        /// </summary>
        public string SunShiMX { get; set; }

        /// <summary>
        /// 损失总价
        /// </summary>
        public decimal SunShiAmount { get; set; }

        /// <summary>
        /// 承担方
        /// </summary>
        public string ChengDanFang { get; set; }

        /// <summary>
        /// 应退金额
        /// </summary>
        public decimal TuiAmount { get; set; }

        /// <summary>
        /// 退票备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 客源单位
        /// </summary>
        public string BuyCompanyName { get; set; }

        /// <summary>
        /// 经手人
        /// </summary>
        public string OperatorName { get; set; }


    }

    /// <summary>
    /// 退票实体
    /// </summary>
    public class MPlanTuiPiao : MBasePlanTuiPiao
    {
        /// <summary>
        /// 页面地址
        /// </summary>
        public string PageUri { get; set; }

        /// <summary>
        /// 系统公司编号
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 退票的游客信息
        /// </summary>
        public IList<MPlanYouKe> TravellerList { get; set; }

    }

    /// <summary>
    /// 退票列表的实体
    /// </summary>
    public class MPlan_TuiPiao : MBasePlanTuiPiao
    {

    }
}
