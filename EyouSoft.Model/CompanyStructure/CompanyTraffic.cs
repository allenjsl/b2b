using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.CompanyStructure
{
    /// <summary>
    /// 公司交通信息
    /// </summary>
    public class CompanyTraffic
    {
        /// <summary>
        /// 交通编号
        /// </summary>
        public int TrafficId { get; set; }

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 交通名称
        /// </summary>
        public string TrafficName { get; set; }
    }
}
