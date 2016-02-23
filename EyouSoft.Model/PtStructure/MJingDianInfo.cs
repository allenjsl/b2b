using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 景点区域信息业务实体
    /// <summary>
    /// 景点区域信息业务实体
    /// </summary>
    public class MJingDianQuYuInfo
    {
        /// <summary>
        /// 区域编号
        /// </summary>
        public int QuYuId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int PaiXuId { get; set; }
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

    #region 景点信息业务实体
    /// <summary>
    /// 景点信息业务实体
    /// </summary>
    public class MJingDianInfo
    {
        /// <summary>
        /// 景点编号
        /// </summary>
        public string JingDianId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 景点名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 景点区域
        /// </summary>
        public int QuYuId { get; set; }
        /// <summary>
        /// 景点介绍
        /// </summary>
        public string JieShao { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 景点封面
        /// </summary>
        public string FengMian { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string QuYuMingCheng { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 景点用户编号
        /// </summary>
        public int JingDianYongHuId { get; set; }
        /// <summary>
        /// 景点地址
        /// </summary>
        public string DiZhi { get; set; }
    }
    #endregion


    #region 景点信息查询实体
    /// <summary>
    /// 景点信息查询实体
    /// </summary>
    public class MJingDianChaXunInfo
    {
        /// <summary>
        /// 景点区域编号
        /// </summary>
        public int? JingDianQuYuId { get; set; }
        /// <summary>
        /// 景点名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 景点用户编号
        /// </summary>
        public int? JingDianYongHuId { get; set; }
    }
    #endregion
}
