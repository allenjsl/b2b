//报价信息业务实体 汪奇志 2014-10-21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 报价信息业务实体
    /// <summary>
    /// 报价信息业务实体
    /// </summary>
    public class MBaoJiaInfo
    {
        /// <summary>
        /// 报价编号
        /// </summary>
        public string BaoJiaId { get; set; }
        /// <summary>
        /// 报价标题
        /// </summary>
        public string BiaoTi { get; set; }
        /// <summary>
        /// 报价时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int ZxlbId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
        /// <summary>
        /// 专线类别名称（OUTPUT）
        /// </summary>
        public string ZxlbName { get; set; }
    }
    #endregion

    #region 报价信息查询业务实体
    /// <summary>
    /// 报价信息查询业务实体
    /// </summary>
    public class MBaoJiaChaXunInfo
    {
        /// <summary>
        /// 报价标题
        /// </summary>
        public string BiaoTi { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int? ZxlbId { get; set; }
    }
    #endregion
}
