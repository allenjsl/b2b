using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region key-value业务实体
    /// <summary>
    /// key-value业务实体
    /// </summary>
    public class MKvInfo
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// K
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.KvKey K { get; set; }
        /// <summary>
        /// V
        /// </summary>
        public string V { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
    }
    #endregion

    #region 站点信息业务实体
    /// <summary>
    /// 站点信息业务实体
    /// </summary>
    public class MZhanDianInfo
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 行政区划代码集合
        /// </summary>
        public IList<string> Xzqhdms { get; set; }
    }
    #endregion

    #region 专线类别信息业务实体
    /// <summary>
    /// 专线类别信息业务实体
    /// </summary>
    public class MZhuanXianLeiBieInfo
    {
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int ZxlbId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus Status { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 站点名称(OUTPUT)
        /// </summary>
        public string ZhanDianMingCheng { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 使用数量（OUTPUT）
        /// </summary>
        public int ShiYongShuLiang { get; set; }
        /// <summary>
        /// zxs t2
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZxsT2 T2 { get; set; }
    }
    #endregion    

    #region 附件信息业务实体
    /// <summary>
    /// 附件信息业务实体
    /// </summary>
    public class MFuJianInfo
    {
        /// <summary>
        /// 附件编号
        /// </summary>
        public int FuJianId { get; set; }
        /// <summary>
        /// 附件路径
        /// </summary>
        public string Filepath { get; set; }
        /// <summary>
        /// 附件描述
        /// </summary>
        public string MiaoShu { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int LeiXing { get; set; }
    }
    #endregion

    #region 平台-站点信息业务实体1
    /// <summary>
    /// 平台-站点信息业务实体1
    /// </summary>
    public class MZhanDianInfo1
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 专线类别集合
        /// </summary>
        public IList<MZhuanXianLeiBieInfo1> Zxlbs { get; set; }
    }
    #endregion

    #region 平台-专线类别信息业务实体1
    /// <summary>
    /// 平台-专线类别信息业务实体1
    /// </summary>
    public class MZhuanXianLeiBieInfo1
    {
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int ZxlbId { get; set; }
        /// <summary>
        /// 专线类别名称
        /// </summary>
        public string MingCheng { get; set; }
    }
    #endregion

    #region 站点查询实体
    /// <summary>
    /// 站点查询实体
    /// </summary>
    public class MZhanDianChaXunInfo
    {
    }
    #endregion

    #region 专线类别查询实体
    /// <summary>
    /// 专线类别查询实体
    /// </summary>
    public class MZhuanXianLeiBieChaXunInfo
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public int? ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus? Status { get; set; }
        /// <summary>
        /// 专线类别名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 使用数量专线商编号（传入值时使用数量不包含该专线高）
        /// </summary>
        public string ShiYongShuLiangZxsId { get; set; }
        /// <summary>
        /// zxs t2
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZxsT2? T2 { get; set; }
    }
    #endregion
}
