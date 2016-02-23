using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.EnumType.FinStructure
{
    #region 收付款登记明细类型
    /// <summary>
    /// 收付款登记明细类型
    /// </summary>
    public enum KuanXiangType
    {
        /// <summary>
        /// 收入-订单收款
        /// </summary>
        订单收款 = 0,
        /// <summary>
        /// 收入-借款归还
        /// </summary>
        借款归还 = 1,
        /// <summary>
        /// 收入-票务押金退还
        /// </summary>
        票务押金退还 = 2,
        /// <summary>
        /// 收入-票务退款
        /// </summary>
        票务退款 = 3,
        /// <summary>
        /// 收入-其它收入收款
        /// </summary>
        其它收入收款 = 4,
        /// <summary>
        /// 收入-出纳登账时产生的收入
        /// </summary>
        出纳登账收款 = 5,
        /// <summary>
        /// 支出-订单退款
        /// </summary>
        订单退款 = 101,
        /// <summary>
        /// 支出-地接支出付款
        /// </summary>
        地接支出付款 = 102,
        /// <summary>
        /// 支出-票务押金付款
        /// </summary>
        票务押金付款 = 103,
        /// <summary>
        /// 支出-票务安排付款
        /// </summary>
        票务安排付款 = 104,
        /// <summary>
        /// 支出-酒店安排付款
        /// </summary>
        酒店安排付款 = 105,
        /// <summary>
        /// 支出-借款支付
        /// </summary>
        借款支付 = 106,
        /// <summary>
        /// 支出-报销支付
        /// </summary>
        报销支付 = 107,
        /// <summary>
        /// 支出-其它支出付款
        /// </summary>
        其它支出付款 = 108,
        /// <summary>
        /// 支出-工资支付
        /// </summary>
        工资支付 = 109
    }
    #endregion

    #region 收付款登记状态
    /// <summary>
    /// 收付款登记状态
    /// </summary>
    public enum KuanXiangStatus
    {
        /// <summary>
        /// 未审批(收款未审批,付款未审批)
        /// </summary>
        未审批 = 0,
        /// <summary>
        /// 未支付(收款已审批,付款未支付)
        /// </summary>
        未支付 = 1,
        /// <summary>
        /// 已支付(付款已支付)
        /// </summary>
        已支付 = 2
    }
    #endregion

    #region 收付款方式
    /// <summary>
    /// 收付款方式
    /// </summary>
    public enum ShouFuKuanFangShi
    {
        /// <summary>
        /// 银行电汇
        /// </summary>
        银行电汇 = 0,
        /// <summary>
        /// 转账支票
        /// </summary>
        转账支票,
        /// <summary>
        /// 财务现收
        /// </summary>
        财务现收,
        /// <summary>
        /// 财务现付
        /// </summary>
        财务现付,
        /// <summary>
        /// 导游现收
        /// </summary>
        导游现收,
        /// <summary>
        /// 导游现付
        /// </summary>
        导游现付
    }
    #endregion

    #region 报销消费类型
    /// <summary>
    /// 报销消费类型
    /// </summary>
    public enum BaoXiaoXiaoFeiType
    {
        /// <summary>
        /// 交通费 
        /// </summary>
        交通费 = 0,
        /// <summary>
        /// 招待费
        /// </summary>
        招待费,
        /// <summary>
        /// 住宿费
        /// </summary>
        住宿费,
        /// <summary>
        /// 燃油费
        /// </summary>
        燃油费,
        /// <summary>
        /// 办公费
        /// </summary>
        办公费,
        /// <summary>
        /// 水电费
        /// </summary>
        水电费,
        /// <summary>
        /// 房租费
        /// </summary>
        房租费,
        /// <summary>
        /// 外联开支
        /// </summary>
        外联开支,
        /// <summary>
        /// 其它
        /// </summary>
        其它
    }
    #endregion

    #region 报销状态
    /// <summary>
    /// 报销状态
    /// </summary>
    public enum BaoXiaoStatus
    {
        /// <summary>
        /// 未审批
        /// </summary>
        未审批 = 0,
        /// <summary>
        /// 未通过
        /// </summary>
        未通过 = 1,
        /// <summary>
        /// 未支付
        /// </summary>
        未支付 = 2,
        /// <summary>
        /// 已支付
        /// </summary>
        已支付 = 3
    }
    #endregion

    #region 借款状态
    /// <summary>
    /// 借款状态
    /// </summary>
    public enum JieKuanStatus
    {
        /// <summary>
        /// 未审批
        /// </summary>
        未审批 = 0,
        /// <summary>
        /// 未通过
        /// </summary>
        未通过 = 1,
        /// <summary>
        /// 未支付
        /// </summary>
        未支付 = 2,
        /// <summary>
        /// 已支付
        /// </summary>
        已支付 = 3,
        /// <summary>
        /// 已归还
        /// </summary>
        已归还 = 4
    }
    #endregion

    #region 发票发送状态
    /// <summary>
    /// 发票发送状态
    /// </summary>
    public enum FaPiaoFaSongStatus
    {
        /// <summary>
        /// 未送出
        /// </summary>
        未送出 = 0,
        /// <summary>
        /// 已送出
        /// </summary>
        已送出
    }
    #endregion

    #region 出纳日记账项目
    /// <summary>
    /// 出纳日记账项目
    /// </summary>
    public enum RiJiZhangXiangMu
    {
        /// <summary>
        /// 营业收入
        /// </summary>
        营业收入 = 0,
        /// <summary>
        /// 营业成本
        /// </summary>
        营业成本,
        /// <summary>
        /// 其它收入
        /// </summary>
        其它收入,
        /// <summary>
        /// 其它支出
        /// </summary>
        其它支出,
        /// <summary>
        /// 押金支出
        /// </summary>
        押金支出,
        /// <summary>
        /// 押金退还
        /// </summary>
        押金退还,
        /// <summary>
        /// 借款支出
        /// </summary>
        借款支出,
        /// <summary>
        /// 借款归还
        /// </summary>
        借款归还,
        /// <summary>
        /// 退票收入
        /// </summary>
        退票收入,
        /// <summary>
        /// 管理费用
        /// </summary>
        管理费用,
        /// <summary>
        /// 冲销
        /// </summary>
        冲销,
        /// <summary>
        /// 其它
        /// </summary>
        其它,
        /// <summary>
        /// 投资款
        /// </summary>
        投资款,
        /// <summary>
        /// 账户互转
        /// </summary>
        帐户互转
    }
    #endregion

    #region 银行核对信息状态
    /// <summary>
    /// 银行核对信息状态
    /// </summary>
    public enum YinHangHeDuiStatus
    {
        /// <summary>
        /// 未确认
        /// </summary>
        未确认 = 0,
        /// <summary>
        /// 已确认
        /// </summary>
        已确认
    }
    #endregion

    #region 其它收入、其它支出类别
    /// <summary>
    /// 其它收入、其它支出类别
    /// </summary>
    public enum QiTaShouZhiType
    {
        /// <summary>
        /// 收入
        /// </summary>
        收入 = 0,
        /// <summary>
        /// 支出
        /// </summary>
        支出
    }
    #endregion

    #region 其它收入、其它支出对方单位类别
    /// <summary>
    /// 其它收入、其它支出对方单位类别
    /// </summary>
    public enum QiTaShouZhiKeHuType
    {
        /// <summary>
        /// 客户单位
        /// </summary>
        客户单位 = 0,
        /// <summary>
        /// 供应商
        /// </summary>
        供应商
    }
    #endregion

    #region 查询操作符
    /// <summary>
    /// 查询操作符
    /// </summary>
    public enum QueryOperator
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,
        /// <summary>
        /// =
        /// </summary>
        等于,
        /// <summary>
        /// &lt;=
        /// </summary>
        小于等于,
        /// <summary>
        /// &gt;=
        /// </summary>
        大于等于
    }
    #endregion

    #region 出纳日记账往来单位类型
    /// <summary>
    /// 出纳日记账往来单位类型
    /// </summary>
    public enum RiJiZhangDanWeiType
    {
        /// <summary>
        /// 客户单位
        /// </summary>
        客户单位 = 0,
        /// <summary>
        /// 供应商
        /// </summary>
        供应商,
        /// <summary>
        /// 员工
        /// </summary>
        员工
    }
    #endregion

    #region 出纳登账销账类型
    /// <summary>
    /// 出纳登账销账类型
    /// </summary>
    public enum XiaoZhangLeiXing
    {
        /// <summary>
        /// 销账
        /// </summary>
        销账 = 0,
        /// <summary>
        /// 冲抵
        /// </summary>
        冲抵 = 1
    }
    #endregion

    #region 其它收支T1
    /// <summary>
    /// 其它收支T1
    /// </summary>
    public enum QiTaShouZhiT1
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,
        /// <summary>
        /// 团队结算
        /// </summary>
        团队结算 = 1,
        /// <summary>
        /// 其它收支
        /// </summary>
        其它收支 = 2
    }
    #endregion

    #region 工资状态
    /// <summary>
    /// 工资状态
    /// </summary>
    public enum GongZiStatus
    {
        /// <summary>
        /// 未审批
        /// </summary>
        未审批 = 0,
        /// <summary>
        /// 未支付
        /// </summary>
        未支付 = 1,
        /// <summary>
        /// 已支付
        /// </summary>
        已支付 = 2
    }
    #endregion

    #region 其它收支T2
    /// <summary>
    /// 其它收支T2
    /// </summary>
    public enum QiTaShouZhiT2
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,
        /// <summary>
        /// 营业外收入_收入
        /// </summary>
        营业外收入_收入 = 1,
        /// <summary>
        /// 公司暂收款_收入
        /// </summary>
        公司暂收款_收入 = 2,
        /// <summary>
        /// 账户互转_收入
        /// </summary>
        账户互转_收入 = 3,
        /// <summary>
        /// 理财产品_收入
        /// </summary>
        理财产品_收入 = 4,
        /// <summary>
        /// 原公司帐款_收入
        /// </summary>
        原公司帐款_收入 = 5,
        /// <summary>
        /// 股本金_收入
        /// </summary>
        股本金_收入 = 6,
        /// <summary>
        /// 长期投资_保证金_收入
        /// </summary>
        长期投资_保证金_收入 = 7,
        /// <summary>
        /// 营业外支出_支出
        /// </summary>
        营业外支出_支出 = 101,
        /// <summary>
        /// 公司暂付款_支出
        /// </summary>
        公司暂付款_支出 = 102,
        /// <summary>
        /// 账户互转_支出
        /// </summary>
        账户互转_支出 = 103,
        /// <summary>
        /// 股本金_支出
        /// </summary>
        股本金_支出 = 104,
        /// <summary>
        /// 理财产品_支出
        /// </summary>
        理财产品_支出 = 105,
        /// <summary>
        /// 原公司帐款_支出
        /// </summary>
        原公司帐款_支出 = 106,
        /// <summary>
        /// 长期投资_保证金_支出
        /// </summary>
        长期投资_保证金_支出 = 107
    }
    #endregion

    #region 工资发放类型
    /// <summary>
    /// 工资发放类型
    /// </summary>
    public enum GongZiFaFangLeiXing
    {
        /// <summary>
        /// 工资
        /// </summary>
        工资 = 0,
        /// <summary>
        /// 奖金
        /// </summary>
        奖金 = 1
    }
    #endregion

    #region 出纳登账销账类型1
    /// <summary>
    /// 出纳登账销账类型1
    /// </summary>
    public enum XiaoZhangLeiXing1
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// 销订单款
        /// </summary>
        销订单款 = 1,
        /// <summary>
        /// 销退票款
        /// </summary>
        销退票款 = 2,
        /// <summary>
        /// 销退回押金
        /// </summary>
        销退回押金 = 3,
        /// <summary>
        /// 销结算其它收入
        /// </summary>
        销结算其它收入 = 4
    }
    #endregion

    #region 银行账户类型
    /// <summary>
    /// 银行账户类型
    /// </summary>
    public enum YinHangZhangHuLeiXing
    {
        /// <summary>
        /// 收付款账户
        /// </summary>
        收付款账户 = 0,
        /// <summary>
        /// 打印单据账户
        /// </summary>
        打印单据账户 = 1
    }
    #endregion

    #region 结清状态
    /// <summary>
    /// 结清状态
    /// </summary>
    public enum JieQingStatus
    {
        /// <summary>
        /// 未结清
        /// </summary>
        未结清=0,
        /// <summary>
        /// 已结清
        /// </summary>
        已结清=1
    }
    #endregion
}
