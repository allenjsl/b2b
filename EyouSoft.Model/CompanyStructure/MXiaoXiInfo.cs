using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.CompanyStructure
{
    /// <summary>
    /// 我的消息信息业务实体
    /// </summary>
    public class MXiaoXiInfo
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing LeiXing { get; set; }
        /// <summary>
        /// 消息数量
        /// </summary>
        public int ShuLiang { get; set; }
    }
}
