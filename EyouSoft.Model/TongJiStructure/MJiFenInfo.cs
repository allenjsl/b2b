using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.TongJiStructure
{
    #region 统计分析-积分发放明细信息业务实体
    /// <summary>
    /// 统计分析-积分发放明细信息业务实体
    /// </summary>
    public class MJiFenFaFangMingXiInfo
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
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType YeWuLeiXing { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 婴儿数
        /// </summary>
        public int YingErShu { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int QuanPeiShu { get; set; }
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
        /// 客户单位
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string YongHuXingMing { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户联系人编号
        /// </summary>
        public int KeHuLxrId { get; set; }
        /// <summary>
        /// 发放积分的专线商名称
        /// </summary>
        public string ZxsName { get; set; }
    }
    #endregion

    #region 统计分析-积分发放结算明细信息业务实体
    /// <summary>
    /// 统计分析-积分发放结算明细信息业务实体
    /// </summary>
    public class MJiFenFaFangJieSuanMingXiInfo
    {
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }
        /// <summary>
        /// 有效积分
        /// </summary>
        public int YouXiaoJiFen { get; set; }
        /// <summary>
        /// 冻结积分
        /// </summary>
        public int DongJieJiFen { get; set; }
        /// <summary>
        /// 取消积分
        /// </summary>
        public int QuXiaoJiFen { get; set; }
        /// <summary>
        /// 结算积分
        /// </summary>
        public int JieSuanJiFen { get; set; }
        /// <summary>
        /// 未结算积分
        /// </summary>
        public int WeiJieSuanJiFen { get { return YouXiaoJiFen - JieSuanJiFen; } }
    }
    #endregion

    #region 统计分析-积分收付款明细信息业务实体
    /// <summary>
    /// 统计分析-积分收付款明细信息业务实体
    /// </summary>
    public class MJiFenShouFuKanMingXiInfo
    {
        /// <summary>
        /// 明细编号
        /// </summary>
        public string MxId { get; set; }
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
        public string YinHangZhaoHao { get; set; }
        /// <summary>
        /// 往来单位名称
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
        /// 收付款状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus Status { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 统计分析-积分结算收款信息业务实体
    /// <summary>
    /// 统计分析-积分结算收款信息业务实体
    /// </summary>
    public class MJiFenJieSuanShouKuanInfo
    {
        /// <summary>
        /// 结算编号
        /// </summary>
        public string JieSuanId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime JieSuanRiQi { get; set; }
        /// <summary>
        /// 结算人姓名
        /// </summary>
        public string JieSuanRenName { get; set; }
        /// <summary>
        /// 结算积分
        /// </summary>
        public int JiFen { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 收款方式
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi JieSuanFangShi { get; set; }
        /// <summary>
        /// 收款账号
        /// </summary>
        public string JieSuanZhangHao { get; set; }
        /// <summary>
        /// 结算备注
        /// </summary>
        public string JieSuanBeiZhu { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus Status { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 审批人编号
        /// </summary>
        public int? ShenPiRenId { get; set; }
        /// <summary>
        /// 审批备注
        /// </summary>
        public string ShenPiBeiZhu { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? ShenPiShiJian { get; set; }
    }
    #endregion


    #region 统计分析-积分发放明细信息查询业务实体
    /// <summary>
    /// 统计分析-积分发放明细信息查询业务实体
    /// </summary>
    public class MJiFenFaFangMingXiChaXunInfo
    {
        /// <summary>
        /// 出团时间-起
        /// </summary>
        public DateTime? QuDate1 { get; set; }
        /// <summary>
        /// 出团时间-止
        /// </summary>
        public DateTime? QuDate2 { get; set; }
        /// <summary>
        /// 积分状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.JiFenStatus? JiFenStatus { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 积分时间-起
        /// </summary>
        public DateTime? JiFenShiJian1 { get; set; }
        /// <summary>
        /// 积分时间-止
        /// </summary>
        public DateTime? JiFenShiJian2 { get; set; }

        /// <summary>
        /// 积分客户单位编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 积分客户单位名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 积分用户编号
        /// </summary>
        public int? YongHuId { get; set; }
        /// <summary>
        /// 积分用户姓名
        /// </summary>
        public string YongHuXingMing { get; set; }
        /// <summary>
        /// 积分用户客户联系人编号
        /// </summary>
        public int? KeHuLxrId { get; set; }
    }
    #endregion

    #region 统计分析-积分发放结算明细信息查询业务实体
    /// <summary>
    /// 统计分析-积分发放结算明细信息查询业务实体
    /// </summary>
    public class MJiFenFaFangJieSuanMingXiChaXunInfo
    {
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }

        /// <summary>
        /// 出团日期-起
        /// </summary>
        public DateTime? QuDate1 { get; set; }
        /// <summary>
        /// 出团日期-止
        /// </summary>
        public DateTime? QuDate2 { get; set; }

        /// <summary>
        /// 发放时间-起
        /// </summary>
        public DateTime? FaFangShiJian1 { get; set; }
        /// <summary>
        /// 发放时间-止
        /// </summary>
        public DateTime? FaFangShiJian2 { get; set; }

        /// <summary>
        /// 结算时间-起
        /// </summary>
        public DateTime? JieSuanShiJian1 { get; set; }
        /// <summary>
        /// 结算时间-止
        /// </summary>
        public DateTime? JieSuanShiJian2 { get; set; }
    }
    #endregion

    #region 统计分析-积分收付款明细信息查询业务实体
    /// <summary>
    /// 统计分析-积分收付款明细信息查询业务实体
    /// </summary>
    public class MJiFenShouFuKanMingXiChaXunInfo
    {
        /// <summary>
        /// 登记日期-起
        /// </summary>
        public DateTime? DengJiRiQi1 { get; set; }
        /// <summary>
        /// 登记日期-止
        /// </summary>
        public DateTime? DengJiRiQi2 { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus? Status { get; set; }
    }
    #endregion

    #region 统计分析-客户用户积分信息业务实体
    /// <summary>
    /// 统计分析-客户用户积分信息业务实体
    /// </summary>
    public class MKeHuYongHuJiFenInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
        /// <summary>
        /// 客户联系人编号
        /// </summary>
        public int KeHuLxrId { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string YongHuName { get; set; }
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string YongHuDianHua { get; set; }
        /// <summary>
        /// 用户手机
        /// </summary>
        public string YongHuShouJi { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string YongHuYouXiang { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 可用积分
        /// </summary>
        public int KeYongJiFen { get; set; }
        /// <summary>
        /// 冻结积分
        /// </summary>
        public int DongJieJiFen { get; set; }
        /// <summary>
        /// 已使用积分
        /// </summary>
        public int YiShiYongJiFen { get; set; }
    }
    #endregion

    #region 统计分析-客户用户积分信息查询业务实体
    /// <summary>
    /// 统计分析-客户用户积分信息查询业务实体
    /// </summary>
    public class MKeHuYongHuJiFenChaXunInfo
    {
        /// <summary>
        /// 客户单位编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? YongHuId { get; set; }
        /// <summary>
        /// 客户联系人编号
        /// </summary>
        public int? KeHuLxrId { get; set; }
    }
    #endregion
}
