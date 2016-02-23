using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 积分商品信息业务实体
    /// <summary>
    /// 积分商品信息业务实体
    /// </summary>
    public class MJiFenShangPinInfo
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ShangPinId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string BianMa { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 市场价格
        /// </summary>
        public decimal JiaGe { get; set; }
        /// <summary>
        /// 兑换积分
        /// </summary>
        public int JiFen { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing LeiXing { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus Status { get; set; }
        /// <summary>
        /// 商品封面
        /// </summary>
        public string FengMian { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string MiaoShu { get; set; }
        /// <summary>
        /// 兑换须知
        /// </summary>
        public string DuiHuanXuZhi { get; set; }
        /// <summary>
        /// 配送说明
        /// </summary>
        public string PeiSongShuoMing { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
    }
    #endregion

    #region 积分订单信息业务实体
    /// <summary>
    /// 积分订单信息业务实体
    /// </summary>
    public class MJiFenDingDanInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ShangPinId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 兑换数量
        /// </summary>
        public int ShuLiang { get; set; }
        /// <summary>
        /// 兑换积分(单价)
        /// </summary>
        public int JiFen1 { get; set; }
        /// <summary>
        /// 兑换积分(总)
        /// </summary>
        public int JiFen2 { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus Status { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrXingMing { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrDianHua { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string LxrShouJi { get; set; }
        /// <summary>
        /// 联系人邮箱
        /// </summary>
        public string LxrYouXiang { get; set; }
        /// <summary>
        /// 联系人省份编号
        /// </summary>
        public int LxrProvinceId { get; set; }
        /// <summary>
        /// 联系人城市编号
        /// </summary>
        public int LxrCityId { get; set; }
        /// <summary>
        /// 联系人地址
        /// </summary>
        public string LxrDiZhi { get; set; }
        /// <summary>
        /// 联系人邮编
        /// </summary>
        public string LxrYouBian { get; set; }
        /// <summary>
        /// 下单备注
        /// </summary>
        public string XiaDanBeiZhu { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public int XiaDanRenId { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 快递信息
        /// </summary>
        public string KuaiDi { get; set; }
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime? FuKuanShiJian { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal FuKuanJinE { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public EnumType.FinStructure.ShouFuKuanFangShi FuKuanFangShi { get; set; }
        /// <summary>
        /// 付款账号
        /// </summary>
        public string FuKuanZhangHao { get; set; }
        /// <summary>
        /// 付款对方单位
        /// </summary>
        public string FuKuanDuiFangDanWei { get; set; }
        /// <summary>
        /// 付款备注
        /// </summary>
        public string FuKuanBeiZhu { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus FuKuanStatus { get; set; }
        /// <summary>
        /// 付款审批人编号
        /// </summary>
        public int? FuKuanShenPiRenId { get; set; }
        /// <summary>
        /// 付款审批时间
        /// </summary>
        public DateTime? FuKuanShenPiShiJian { get; set; }
        /// <summary>
        /// 付款审批备注
        /// </summary>
        public string FuKuanShenPiBeiZhu { get; set; }
        /// <summary>
        /// 付款支付人编号
        /// </summary>
        public int? FuKuanZhiFuRenId { get; set; }
        /// <summary>
        /// 付款支付时间
        /// </summary>
        public DateTime? FuKuanZhiFuShiJian { get; set; }
        /// <summary>
        /// 付款支付备注
        /// </summary>
        public string FuKuanZhiFuBeiZhu { get; set; }
        /// <summary>
        /// 最后操作人编号
        /// </summary>
        public int LatestOperatorId { get; set; }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 付款操作人编号
        /// </summary>
        public int? FuKuanOperatorId { get; set; }
        /// <summary>
        /// 付款操作时间
        /// </summary>
        public DateTime? FuKuanTime { get; set; }

        /// <summary>
        /// 商品名称（OUTPUT）
        /// </summary>
        public string ShangPinMingCheng { get; set; }
        /// <summary>
        /// 商品编码（OUTPUT）
        /// </summary>
        public string ShangPinBianMa { get; set; }

        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string XiaDanRenXingMing { get; set; }
        /// <summary>
        /// 下单人用户名
        /// </summary>
        public string XiaDanRenYongHuMing { get; set; }
        /// <summary>
        /// 下单人客户单位名称
        /// </summary>
        public string XiaDanRenKeHuName { get; set; }
    }
    #endregion

    #region 用户积分明细信息业务实体
    /// <summary>
    /// 用户积分明细信息业务实体
    /// </summary>
    public class MYongHuJiFenMingXiInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int JiFen { get; set; }
        /// <summary>
        /// 积分状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenStatus JiFenStatus { get; set; }
        /// <summary>
        /// 积分时间
        /// </summary>
        public DateTime JiFenShiJian { get; set; }
        /// <summary>
        /// 积分类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing JiFenLeiXing { get; set; }
        /// <summary>
        /// 关联编号
        /// </summary>
        public string GuanLianId { get; set; }
        /// <summary>
        /// 关联产品编号
        /// </summary>
        public string GuanLianChanPinBianHao { get; set; }
        /// <summary>
        /// 关联产品名称
        /// </summary>
        public string GuanLianChanPinName { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType? YeWuLeiXing { get; set; }
        /// <summary>
        /// 发放积分专线商名称
        /// </summary>
        public string FaFangZxsName { get; set; }
        /// <summary>
        /// 发放积分专线商编号
        /// </summary>
        public string FaFangZxsId { get; set; }
        /// <summary>
        /// 交易号（系统订单编号）
        /// </summary>
        public string JiaoYiHao { get; set; }
    }
    #endregion


    #region 积分商品信息查询实体
    /// <summary>
    /// 积分商品信息查询实体
    /// </summary>
    public class MJiFenShangPinChaXunInfo
    {
        /// <summary>
        /// 商品类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing? LeiXing { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus? Status { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string BianMa { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string MingCheng { get; set; }
    }
    #endregion

    #region 积分订单查询实体
    /// <summary>
    /// 积分订单查询实体
    /// </summary>
    public class MJiFenDingDanChaXunInfo
    {
        /// <summary>
        /// 商品类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing? ShangPinLeiXing { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ShangPinMingCheng { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string ShangPinBianMa { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus? Status { get; set; }
        /// <summary>
        /// 下单时间-起
        /// </summary>
        public DateTime? XiaDanShiJian1 { get; set; }
        /// <summary>
        /// 下单时间-止
        /// </summary>
        public DateTime? XiaDanShiJian2 { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus? FuKuanStatus { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public int? XiaDanRenId { get; set; }
    }
    #endregion

    #region 用户积分明细信息查询业务实体
    /// <summary>
    /// 用户积分明细信息查询业务实体
    /// </summary>
    public class MYongHuJiFenMingXiChaXunInfo
    {
        /// <summary>
        /// 积分状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenStatus? JiFenStatus { get; set; }
        /// <summary>
        /// 积分类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing? JiFenLeiXing { get; set; }
        /// <summary>
        /// 积分时间-起
        /// </summary>
        public DateTime? JiFenShiJian1 { get; set; }
        /// <summary>
        /// 积分时间-止
        /// </summary>
        public DateTime? JiFenShiJian2 { get; set; }
    }
    #endregion
}
