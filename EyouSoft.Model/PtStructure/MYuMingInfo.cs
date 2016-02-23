using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    /// <summary>
    /// 平台域名信息业务实体
    /// </summary>
    public class MYuMingInfo
    {
        /// <summary>
        /// 域名
        /// </summary>
        public string YuMing { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 管理系统域名
        /// </summary>
        public string ErpYuMing { get; set; }
        /// <summary>
        /// 主专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 管理系统URL
        /// </summary>
        public string ErpUrl { get { return "http://" + ErpYuMing; } }
        /// <summary>
        /// 域名类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing LeiXing { get; set; }
    }
}
