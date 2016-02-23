using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 酒店信息业务实体
    /// <summary>
    /// 酒店信息业务实体
    /// </summary>
    public class MJiuDianInfo
    {
        /// <summary>
        /// 酒店编号
        /// </summary>
        public string JiuDianId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 酒店地址
        /// </summary>
        public string DiZhi { get; set; }
        /// <summary>
        /// 开业时间
        /// </summary>
        public string KaiYeShiJian { get; set; }
        /// <summary>
        /// 楼层数量
        /// </summary>
        public string LouCengShuLiang { get; set; }
        /// <summary>
        /// 装修时间
        /// </summary>
        public string ZhuangXiuShiJian { get; set; }
        /// <summary>
        /// 酒店星级
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi XingJi { get; set; }
        /// <summary>
        /// 酒店电话
        /// </summary>
        public string DianHua { get; set; }
        /// <summary>
        /// 酒店简介(酒店介绍-详细)
        /// </summary>
        public string JianJie { get; set; }
        /// <summary>
        /// 交通信息
        /// </summary>
        public string JiaoTong { get; set; }
        /// <summary>
        /// 网络设施
        /// </summary>
        public string WangLuo { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 酒店封面
        /// </summary>
        public string FengMian { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
        /// <summary>
        /// 房型集合
        /// </summary>
        public IList<MJiuDianFangXingInfo> FangXings { get; set; }

        /// <summary>
        /// 省份名称(OUTPUT)
        /// </summary>
        public string ShengFenName { get; set; }
        /// <summary>
        /// 城市名称(OUTPUT)
        /// </summary>
        public string ChengShiName { get; set; }
        /// <summary>
        /// 酒店用户编号
        /// </summary>
        public int JiuDianYongHuId { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 酒店简介(酒店介绍-简要)
        /// </summary>
        public string JianYaoJieShao { get; set; }
    }
    #endregion

    #region 酒店房型信息业务实体
    /// <summary>
    /// 酒店房型信息业务实体
    /// </summary>
    public class MJiuDianFangXingInfo
    {
        /// <summary>
        /// 酒店编号
        /// </summary>
        public string JiuDianId { get; set; }
        /// <summary>
        /// 房型编号
        /// </summary>
        public string FangXingId { get; set; }
        /// <summary>
        /// 房型名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 房型数量
        /// </summary>
        public string ShuLiang { get; set; }
        /// <summary>
        /// 房间面积
        /// </summary>
        public string MianJi { get; set; }
        /// <summary>
        /// 所在楼层
        /// </summary>
        public string LouCeng { get; set; }
        /// <summary>
        /// 床位配置
        /// </summary>
        public string ChuangWeiPeiZhi { get; set; }
        /// <summary>
        /// 客房设施
        /// </summary>
        public string KeFangSheShi { get; set; }
        /// <summary>
        /// 挂牌价格
        /// </summary>
        public decimal GuaPaiJiaGe { get; set; }
        /// <summary>
        /// 房型介绍
        /// </summary>
        public string JieShao { get; set; }
        /// <summary>
        /// 房型封面
        /// </summary>
        public string FengMian { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 入住日期起
        /// </summary>
        public DateTime RuZhuRiQi1 { get; set; }
        /// <summary>
        /// 入住日期止
        /// </summary>
        public DateTime RuZhuRiQi2 { get; set; }
        /// <summary>
        /// 优惠价格
        /// </summary>
        public decimal YouHuiJiaGe { get; set; }
    }
    #endregion


    #region 酒店信息查询实体
    /// <summary>
    /// 酒店信息查询实体
    /// </summary>
    public class MJiuDianChaXunInfo
    {
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string JiuDianMingCheng { get; set; }
        /// <summary>
        /// 房型名称
        /// </summary>
        public string FangXingMingCheg { get; set; }
        /// <summary>
        /// 所在地省份编号
        /// </summary>
        public int? ShengFenId { get; set; }
        /// <summary>
        /// 所在地城市编号
        /// </summary>
        public int? ChengShiId { get; set; }
        /// <summary>
        /// 酒店星级
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi? XingJi { get; set; }
        /// <summary>
        /// 酒店用户编号
        /// </summary>
        public int? JiuDianYongHuId { get; set; }
    }
    #endregion
}
