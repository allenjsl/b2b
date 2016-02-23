//订单回访信息业务实体 汪奇志 2012-11-23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    /// <summary>
    /// 订单回访信息业务实体
    /// </summary>
    public class MHuiFangInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MHuiFangInfo() { }

        /// <summary>
        /// 回访编号
        /// </summary>
        public string HuiFangId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 回访时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 被访人身份
        /// </summary>
        public string ShenFen { get; set; }
        /// <summary>
        /// 被访人姓名
        /// </summary>
        public string XingMing { get; set; }
        /// <summary>
        /// 被访人电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 回访结果
        /// </summary>
        public string JieGuo { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
    }
}
