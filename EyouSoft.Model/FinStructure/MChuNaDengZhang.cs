using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.Model.FinStructure
{
    #region 出纳登帐信息实体

    /// <summary>
    /// 出纳登账信息实体
    /// </summary>
    public class MChuNaDengZhang
    {
        /// <summary>
        /// 出纳登账编号
        /// </summary>
        public string DengZhangId { get; set; }

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 到款时间
        /// </summary>
        public DateTime DaoKuanTime { get; set; }

        /// <summary>
        /// 到款金额
        /// </summary>
        public decimal DaoKuanJinE { get; set; }

        /// <summary>
        /// 到款银行编号
        /// </summary>
        public string DaoKuanBankId { get; set; }

        /// <summary>
        /// 到款银行名称
        /// </summary>
        public string DaoKuanBankName { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public EnumType.FinStructure.ShouFuKuanFangShi FuKuanFangShi { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumType.FinStructure.KuanXiangStatus Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 操作人名称
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 已销账金额
        /// </summary>
        public decimal UnCheckMoney { get; set; }

        /// <summary>
        /// 出纳登账审批信息
        /// </summary>
        public MShenPiDengZhang ShenPi { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }

    #endregion

    #region 出纳登账查询实体

    /// <summary>
    /// 出纳登账查询实体
    /// </summary>
    public class MSearchChuNaDengZhang
    {
        /// <summary>
        /// 银行账户编号
        /// </summary>
        public string BankId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EnumType.FinStructure.KuanXiangStatus? Status { get; set; }
        /// <summary>
        /// 到款时间开始
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 到款时间结束
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 到账金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator DaoZhangJinEOperator { get; set; }
        /// <summary>
        /// 到账金额
        /// </summary>
        public decimal? DaoZhangJinE { get; set; }
        /// <summary>
        /// 未销账金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator WeiXiaoZhangJinEOperator { get; set; }
        /// <summary>
        /// 未销账金额
        /// </summary>
        public decimal? WeiXiaoZhangJinE { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }

        /// <summary>
        /// 销账（冲抵）时间-起
        /// </summary>
        public DateTime? XiaoZhangShiJian1 { get; set; }
        /// <summary>
        /// 销账（冲抵）时间-止
        /// </summary>
        public DateTime? XiaoZhangShiJian2 { get; set; }        
        /// <summary>
        /// 销账（冲抵）金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator XiaoZhangJinEOperator { get; set; }
        /// <summary>
        /// 销账（冲抵）金额
        /// </summary>
        public decimal? XiaoZhangJinE { get; set; }

        /// <summary>
        /// 对方单位类型 0：客户 1：供应商
        /// </summary>
        public string DuiFangDanWeiLeiXing { get; set; }
        /// <summary>
        /// 对方单位编号
        /// </summary>
        public string DuiFangDanWeiId { get; set; }
    }

    #endregion

    #region 审批出纳登账信息实体

    /// <summary>
    /// 审批出纳登账信息实体
    /// </summary>
    public class MShenPiDengZhang
    {
        /// <summary>
        /// 银行实际业务日期
        /// </summary>
        public DateTime BankDate { get; set; }

        /// <summary>
        /// 审批备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 审批人编号
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 审批人名称
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime IssueTime { get; set; }
    }

    #endregion

    #region 销账信息实体
    /// <summary>
    /// 销账信息实体
    /// </summary>
    public class MXiaoZhang
    {
        /// <summary>
        /// 销账编号 
        /// </summary>
        public string XiaoZhangId { get; set; }
        /// <summary>
        /// 要销账的关联编号（订单编号、退票编号、控位代理编号、其它收入编号）
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 销账金额
        /// </summary>
        public decimal XiaoZhangJinE { get; set; }
        /// <summary>
        /// 销账人
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 销账人名称
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 销账时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 销账类型1
        /// </summary>
        public XiaoZhangLeiXing1 LeiXing1 { get; set; }
    }

    #endregion

    #region 已销账信息业务实体
    /// <summary>
    /// 已销账信息业务实体
    /// </summary>
    public class MYiXiaoZhangInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYiXiaoZhangInfo() { }

        /// <summary>
        /// 销账编号
        /// </summary>
        public string XiaoZhangId { get; set; }
        /// <summary>
        /// 登账编号
        /// </summary>
        public string DengZhangId { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal YingShouJinE { get; set; }
        /// <summary>
        /// 销账金额
        /// </summary>
        public decimal XiaoZhangJinE { get; set; }
        /// <summary>
        /// 收款登记编号
        /// </summary>
        public string ShouKuanId { get; set; }
        /// <summary>
        /// 销账时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 销账类型
        /// </summary>
        public XiaoZhangLeiXing LeiXing { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType? YeWuLeiXing { get; set; }
        /// <summary>
        /// 销账类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing1 LeiXing1 { get; set; }
    }
    #endregion

    #region 已销账查询信息业务实体
    /// <summary>
    /// 已销账查询信息业务实体
    /// </summary>
    public class MYiXiaoZhangChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYiXiaoZhangChaXunInfo() { }

        /// <summary>
        /// 登账编号
        /// </summary>
        public string DengZhangId { get; set; }
    }
    #endregion

    #region 出纳登账冲抵信息业务实体
    /// <summary>
    /// 出纳登账冲抵信息业务实体
    /// </summary>
    public class MChongDiInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MChongDiInfo() { }

        /// <summary>
        /// 冲抵编号
        /// </summary>
        public string ChongDiId { get; set; }
        /// <summary>
        /// 登账编号
        /// </summary>
        public string DengZhangId { get; set; }
        /// <summary>
        /// 冲抵金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string DanWeiId { get; set; }
        /// <summary>
        /// 单位类别
        /// </summary>
        public EnumType.FinStructure.QiTaShouZhiKeHuType DanWeiType { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public int XiangMuId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 出纳登账-销账订单款信息业务实体
    /// <summary>
    /// 出纳登账-销账订单款信息业务实体
    /// </summary>
    public class MXiaoZhangDingDanKuanInfo
    {
        string _RouteName = string.Empty;
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName
        {
            get
            {
                if (string.IsNullOrEmpty(_RouteName)) return YeWuLeiXing.ToString();

                return _RouteName;
            }
            set { _RouteName = value; }
        }

        /// <summary>
        /// 控位号 
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 去程日期
        /// </summary>
        public DateTime? QuDate { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 客户单位
        /// </summary>
        public string BuyCompanyName { get; set; }
        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal SumPrice { get; set; }
        /// <summary>
        /// 收款已审批金额
        /// </summary>
        public decimal YiShenPiJinE { get; set; }
        /// <summary>
        /// 收款未审批金额
        /// </summary>
        public decimal WeiShenPiJinE { get; set; }
        /// <summary>
        /// 退款已审批金额
        /// </summary>
        public decimal TuiYiShenPiJinE { get; set; }
        /// <summary>
        /// 退款未审批金额
        /// </summary>
        public decimal TuiWeiShenPiJinE { get; set; }
        /// <summary>
        /// 未登记金额
        /// </summary>
        public decimal WeiDengJiJinE
        {
            get { return SumPrice - YiShenPiJinE - WeiShenPiJinE + TuiYiShenPiJinE + TuiWeiShenPiJinE; }
        }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType YeWuLeiXing { get; set; }
    }
    #endregion

    #region 出纳登账销账-退票款信息业务实体
    /// <summary>
    /// 出纳登账销账-退票款信息业务实体
    /// </summary>
    public class MXiaoZhangTuiPiaoKuanInfo
    {
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 出票交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 订单号或编码，与供应商交易产生的交易号（系统外）
        /// </summary>
        public string GysJiaoYiHao { get; set; }
        /// <summary>
        /// 代理商名称
        /// </summary>
        public string DaiLiShangName { get; set; }
        /// <summary>
        /// 退票时间
        /// </summary>
        public DateTime TuiPiaoShiJian { get; set; }
        /// <summary>
        /// 退票人数
        /// </summary>
        public int TuiPiaoRenShu { get; set; }
        /// <summary>
        /// 损失明细
        /// </summary>
        public string SunShiMingXi { get; set; }
        /// <summary>
        /// 应退金额
        /// </summary>
        public decimal YingTuiJinE { get; set; }
        /// <summary>
        /// 已审批金额
        /// </summary>
        public decimal YiShenPiJinE { get; set; }
        /// <summary>
        /// 未审批金额
        /// </summary>
        public decimal WeiShenPiJinE { get; set; }
        /// <summary>
        /// 未登记金额
        /// </summary>
        public decimal WeiDengJiJinE { get {return YingTuiJinE - YiShenPiJinE - WeiShenPiJinE; } }
        /// <summary>
        /// 承担方
        /// </summary>
        public string ChengDanFang { get; set; }
        /// <summary>
        /// 经手人姓名
        /// </summary>
        public string JingShouRenName { get; set; }
        /// <summary>
        /// 退票编号
        /// </summary>
        public string TuiPiaoId { get; set; }
    }
    #endregion

    #region 出纳登账销账-退回押金信息业务实体
    /// <summary>
    /// 出纳登账销账-退回押金信息业务实体
    /// </summary>
    public class MXiaoZhangTuiHuiYaJinInfo
    {
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 代理商名称
        /// </summary>
        public string DaiLiShangName { get; set; }
        /// <summary>
        /// 控位数量
        /// </summary>
        public int ShuLiang { get; set; }
        /// <summary>
        /// 订单号或编码，与供应商交易产生的交易号（系统外）
        /// </summary>
        public string GysJiaoYiHao { get; set; }
        /// <summary>
        /// 押金金额
        /// </summary>
        public decimal YaJinJinE { get; set; }
        /// <summary>
        /// 应退押金金额
        /// </summary>
        public decimal YingTuiJinE { get; set; }
        /// <summary>
        /// 已审批退押金金额
        /// </summary>
        public decimal TuiYiShenPiJinE { get; set; }
        /// <summary>
        /// 未审批退押金金额
        /// </summary>
        public decimal TuiWeiShenPiJinE { get; set; }
        /// <summary>
        /// 未登记金额
        /// </summary>
        public decimal WeiDengJiJinE { get { return YingTuiJinE - TuiYiShenPiJinE - TuiWeiShenPiJinE; } }
        /// <summary>
        /// 代理编号
        /// </summary>
        public string DaiLiId { get; set; }
    }
    #endregion

    #region 出纳登账销账-团队结算其它收入信息业务实体
    /// <summary>
    /// 出纳登账销账-团队结算其它收入信息业务实体
    /// </summary>
    public class MXiaoZhangJieSuanQiTaShouRuInfo
    {
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 收入时间
        /// </summary>
        public DateTime ShouRuShiJian { get; set; }
        /// <summary>
        /// 收入项目
        /// </summary>
        public string ShouRuXiangMu { get; set; }
        /// <summary>
        /// 收入备注
        /// </summary>
        public string ShouRuBeiZhu { get; set; }
        /// <summary>
        /// 收入金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 对方单位名称
        /// </summary>
        public string DuiFangDanWeiName { get; set; }
        /// <summary>
        /// 已审批金额
        /// </summary>
        public decimal YiShenPiJinE { get; set; }
        /// <summary>
        /// 未审批金额
        /// </summary>
        public decimal WeiShenPiJinE { get; set; }
        /// <summary>
        /// 未登记金额
        /// </summary>
        public decimal WeiDengJiJinE { get { return JinE - YiShenPiJinE - WeiShenPiJinE; } }
        /// <summary>
        /// 其它收入编号
        /// </summary>
        public string QiTaShouRuId { get; set; }
    }
    #endregion

    #region 出纳登账销账-查询信息业务实体
    /// <summary>
    /// 出纳登账销账-查询信息业务实体
    /// </summary>
    public class MXiaoZhangChaXunInfo
    {
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 出团日期-起
        /// </summary>
        public DateTime? QuDate1 { get; set; }
        /// <summary>
        /// 出团日期-止
        /// </summary>
        public DateTime? QuDate2 { get; set; }

        /// <summary>
        /// 退票款-代理商名称
        /// </summary>
        public string TuiPiaoKuan_DaiLiShangName { get; set; }
        /// <summary>
        /// 退票款-交易号，与供应商交易产生的交易号（系统内）
        /// </summary>
        public string TuiPiaoKuan_JiaoYiHao { get; set; }
        /// <summary>
        /// 退票款-订单号或编码，与供应商交易产生的交易号（系统外）
        /// </summary>
        public string TuiPiaoKuan_GysJiaoYiHao { get; set; }
        /// <summary>
        /// 退票款-订单号
        /// </summary>
        public string TuiPiaoKuan_DingDanHao { get; set; }


        /// <summary>
        /// 退回押金-代理商名称
        /// </summary>
        public string TuiYaJin_DaiLiShangName { get; set; }
        /// <summary>
        /// 退回押金-订单号或编码，与供应商交易产生的交易号（系统外）
        /// </summary>
        public string TuiYaJin_GysJiaoYiHao { get; set; }

        /// <summary>
        /// 团队结算其它收入-对方单位名称
        /// </summary>
        public string JieSuanQiTaShouRu_DuiFangDanWeiName { get; set; }

        /// <summary>
        /// 订单款-客户单位名称
        /// </summary>
        public string DingDanKuan_KeHuName { get; set; }
        /// <summary>
        /// 订单款-客户单位编号
        /// </summary>
        public string DingDanKuan_KeHuId { get; set; }
    }
    #endregion
}
