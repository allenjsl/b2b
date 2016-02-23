using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.CompanyStructure
{
    #region 省份信息业务实体
    /// <summary>
    /// 省份信息业务实体
    /// </summary>
    public class MShengFenInfo
    {
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ShengFenId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ShengFenName { get; set; }
        /// <summary>
        /// 城市集合
        /// </summary>
        public IList<MChengShiInfo> ChengShis { get; set; }
    }
    #endregion

    #region 城市信息业务实体
    /// <summary>
    /// 城市信息业务实体
    /// </summary>
    public class MChengShiInfo
    {
        /// <summary>
        /// 城市编号
        /// </summary>
        public int ChengShiId { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string ChengShiName { get; set; }
        /// <summary>
        /// 城市类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing LeiXing { get; set; }
    }
    #endregion

    #region 省份城市查询信息业务实体
    /// <summary>
    /// 省份城市查询信息业务实体
    /// </summary>
    public class MShengFenChengShiChaXunInfo
    {
        /// <summary>
        /// 省份编号
        /// </summary>
        public int? ShengFenId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int? ChengShiId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 类型 0:所有 1:仅含常用城市
        /// </summary>
        public int LeiXing { get; set; }
        /// <summary>
        /// 类型1 0:结果不包含城市 1:结果包含城市
        /// </summary>
        public int LeiXing1 { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string ChengShiName { get; set; }
        /// <summary>
        /// top expression
        /// </summary>
        public int TopExpression { get; set; }
        /// <summary>
        /// 类型2 城市类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing? LeiXing2 { get; set; }
    }
    #endregion
}
