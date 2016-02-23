//公司基础信息相关业务实体 汪奇志 2013-01-06 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.EnumType.CompanyStructure;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.Model.CompanyStructure
{
    #region 公司基础信息业务实体
    /// <summary>
    /// 公司基础信息业务实体
    /// </summary>
    public class MJiChuXinXiInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MJiChuXinXiInfo() { }

        /// <summary>
        /// 自增编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 信息类型
        /// </summary>
        public JiChuXinXiType Type { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 其它收支T1
        /// </summary>
        public QiTaShouZhiT1 T1 { get; set; }
        /// <summary>
        /// 其它收支T2
        /// </summary>
        public QiTaShouZhiT2 T2 { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }

        /// <summary>
        /// 线路区域信息
        /// </summary>
        public IList<MJiChuXinXiQuYuInfo> QuYus { get; set; }
    }
    #endregion

    #region 公司基础信息查询业务实体
    /// <summary>
    /// 公司基础信息查询业务实体
    /// </summary>
    public class MJiChuXinXiChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MJiChuXinXiChaXunInfo() { }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 公司基础信息线路区域业务实体
    /// <summary>
    /// 公司基础信息线路区域业务实体
    /// </summary>
    public class MJiChuXinXiQuYuInfo
    {
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int QuYuId { get; set; }
    }
    #endregion
}
