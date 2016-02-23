//平台统计相关实体
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 积分发放明细信息实体
    /// <summary>
    /// 积分发放明细信息实体
    /// </summary>
    public class MJiFenFaFangMxInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime ChuTuanRiQi { get; set; }
        /// <summary>
        /// 人数-成人
        /// </summary>
        public int RenShu_CR { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int JiFen { get; set; }
        /// <summary>
        /// 积分状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenStatus JiFenStatus { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime FaShengShiJian { get; set; }
    }
    #endregion

    #region 积分发放明细查询实体
    /// <summary>
    /// 积分发放明细查询实体
    /// </summary>
    public class MJiFenFaFangMxChaXunInfo
    {
        /// <summary>
        /// 出团日期-起始
        /// </summary>
        public DateTime? ChuTuanRiQi1 { get; set; }
        /// <summary>
        /// 出团日期-截止
        /// </summary>
        public DateTime? ChuTuanRiQi2 { get; set; }
        /// <summary>
        /// 积分发生时间-起始
        /// </summary>
        public DateTime? FaShengShiJian1 { get; set; }
        /// <summary>
        /// 积分发生时间-截止
        /// </summary>
        public DateTime? FaShengShiJia2 { get; set; }
    }
    #endregion


    #region 积分发放结算统计信息实体
    /// <summary>
    /// 积分发放结算统计信息实体
    /// </summary>
    public class MJiFenFaFangJieSuanTjInfo
    {
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set;}
        /// <summary>
        /// 积分-有效
        /// </summary>
        public int JiFen1 { get; set; }
        /// <summary>
        /// 积分-冻结
        /// </summary>
        public int JiFen2 { get; set; }
        /// <summary>
        /// 积分-取消
        /// </summary>
        public int JiFen3 { get; set; }
        /// <summary>
        /// 已结算积分
        /// </summary>
        public int JiFen4 { get; set; }
        /// <summary>
        /// 未结算积分
        /// </summary>
        public int JiFen5 { get { return JiFen1 + JiFen2 + JiFen3 - JiFen4; } }
    }
    #endregion

    #region 积分发放结算统计查询实体
    /// <summary>
    /// 积分发放结算统计查询实体
    /// </summary>
    public class MJiFenFaFangJieSuanTjChaXunInfo
    {

    }
    #endregion


    #region 积分收付款明细信息实体
    /// <summary>
    /// 积分收付款明细信息实体
    /// </summary>
    public class MJiFenShouFuKuanMxInfo
    {
        /// <summary>
        /// 关联编号(专线商积分结算编号或积分兑换订单编号)
        /// </summary>
        public string GuanLianId { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime DengJiRiQi { get; set; }
        /// <summary>
        /// 积分收付款明细类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing LeiXing { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string YinHangZhangHao { get; set; }
        /// <summary>
        /// 往来单位
        /// </summary>
        public string WangLaiDanWei { get; set; }
        /// <summary>
        /// 借方金额
        /// </summary>
        public decimal JieFangJinE { get; set; }
        /// <summary>
        /// 贷方金额
        /// </summary>
        public decimal DaiFangJinE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 款状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus Status { get; set; }
    }
    #endregion

    #region 积分收付款明细查询实体
    /// <summary>
    /// 积分收付款明细查询实体
    /// </summary>
    public class MJiFenShouFuKuanMxChaXunInfo
    {

    }
    #endregion
}
