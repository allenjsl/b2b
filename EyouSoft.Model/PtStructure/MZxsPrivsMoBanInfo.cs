//专线商权限模板信息业务实体 汪奇志 2014-10-22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 专线商权限模板信息业务实体
    /// <summary>
    /// 专线商权限模板信息业务实体
    /// </summary>
    public class MZxsPrivsMoBanInfo
    {
        /// <summary>
        /// 模板编号
        /// </summary>
        public string MoBanId { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 一级栏目
        /// </summary>
        public string Privs1 { get; set; }
        /// <summary>
        /// 二样栏目
        /// </summary>
        public string Privs2 { get; set; }
        /// <summary>
        /// 明细权限
        /// </summary>
        public string Privs3 { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
    }
    #endregion
}
