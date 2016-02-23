using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.CompanyStructure
{
    #region 公司线路区域实体
    /// <summary>
    /// 公司线路区域实体
    /// </summary>
    [Serializable]
    public class Area
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Area() { }

        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 线路区域名称
        /// </summary>
        public string AreaName{ get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int ZxlbId { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string ZhanDianMingCheng { get; set; }
        /// <summary>
        /// 专线类别名称
        /// </summary>
        public string ZxlbMingCheng { get; set; }
        /// <summary>
        /// 省份城市集合
        /// </summary>
        public IList<MXianLuQuYuShengFenChengShiInfo> ShengFenChengShis { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 线路区域省份城市信息
    /// <summary>
    /// 线路区域省份城市信息
    /// </summary>
    public class MXianLuQuYuShengFenChengShiInfo
    {
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ShengFenId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int ChengShiId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.QuYuShengFenChengShiLeiXing LeiXing { get; set; }

        /// <summary>
        /// 省份名称(OUTPUT)
        /// </summary>
        public string ShengFenMingCheng { get; set; }
        /// <summary>
        /// 城市名称(OUTPUT)
        /// </summary>
        public string ChengShiMingCheng { get; set; }
    }
    #endregion

    #region 专线商站点、专线类别、线路区域信息
    /// <summary>
    /// 专线商站点实体
    /// </summary>
    public class MZxsZhanDianInfo
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string ZhanDianName { get; set; }
        /// <summary>
        /// 专线类别集合
        /// </summary>
        public List<MZxsZxlbInfo> Zxlbs { get; set; }
    }

    /// <summary>
    /// 专线商专线类别实体
    /// </summary>
    public class MZxsZxlbInfo
    {
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int ZxlbId { get; set; }
        /// <summary>
        /// 专线类别名称
        /// </summary>
        public string ZxlbName { get; set; }
        /// <summary>
        /// 线路区域集合
        /// </summary>
        public List<MZxsQuYuInfo> QuYus { get; set; }
    }

    /// <summary>
    /// 专线商线路区域实体
    /// </summary>
    public class MZxsQuYuInfo
    {
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int QuYuId { get; set; }
        /// <summary>
        /// 线路区域名称
        /// </summary>
        public string QuYuName { get; set; }
    }
    #endregion

    #region 线路区域信息查询业务实体
    /// <summary>
    /// 线路区域信息查询业务实体
    /// </summary>
    public class MQuYuChaXunInfo
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public int? ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int? ZxlbId { get; set; }
    }
    #endregion
}
