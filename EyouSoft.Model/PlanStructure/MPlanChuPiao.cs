using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PlanStructure
{
    #region 出票安排
    /// <summary>
    /// 出票安排
    /// </summary>
    public class MBasePlanChuPiao
    {
        /// <summary>
        /// 安排编号
        /// </summary>
        public string PlanId { get; set; }

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }

        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }

        /// <summary>
        /// 代理编号
        /// </summary>
        public string DaiLiId { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }

        /// <summary>
        /// 出票数量
        /// </summary>
        public int ShuLiang { get; set; }

        /// <summary>
        /// 结算明细
        /// </summary>
        public string JieSuanMX { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JieSuanAmount { get; set; }

        /// <summary>
        /// 安排备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 确认件附件
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 出票/退票安排游客信息表
    /// <summary>
    /// 出票/退票安排游客信息表
    /// </summary>
    public class MPlanYouKe
    {
        /// <summary>
        /// 安排编号/退票安排
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 游客编号
        /// </summary>
        public string YouKeId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

    }
    #endregion

    #region 出票
    /// <summary>
    /// 出票
    /// </summary>
    public class MPlanChuPiao : MBasePlanChuPiao
    {
        /// <summary>
        /// 页面路径
        /// </summary>
        public string PageUri { get; set; }

        public IList<MPlanYouKe> TravellerList { get; set; }
    }
    #endregion

    #region 押金登记
    /// <summary>
    /// 押金登记
    /// </summary>
    public class MYaJinDengJi
    {
        /// <summary>
        /// 代理商编号
        /// </summary>
        public string DaiLiId { get; set; }

        /// <summary>
        /// 押金金额
        /// </summary>
        public decimal YaJinAmount { get; set; }

        /// <summary>
        /// 押金备注
        /// </summary>
        public string YaJinBeiZhu { get; set; }

        /// <summary>
        /// 押金操作人编号
        /// </summary>
        public int YaJinOperatorId { get; set; }


        /// <summary>
        /// 押金退回金额
        /// </summary>
        public decimal TuiYaJinAmount { get; set; }

        /// <summary>
        /// 押金退回备注
        /// </summary>
        public string TuiYaJinBeiZhu { get; set; }

        /// <summary>
        /// 押金退回时间
        /// </summary>
        public DateTime? TuiTime { get; set; }

        /// <summary>
        /// 押金退回操作人编号
        /// </summary>
        public int TuiYaJinOperatorId { get; set; }

    }
    #endregion

    #region 押金列表
    /// <summary>
    /// 押金列表
    /// </summary>
    public class MYaJin : MYaJinDengJi
    {
        /// <summary>
        /// 出票时限
        /// </summary>
        public string ShiXian
        {

            get;
            set;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 代理商
        /// </summary>
        public string GysName { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal ShuLiang { get; set; }

        /// <summary>
        /// 订单号或编码
        /// </summary>
        public string GysOrderCode { get; set; }

        /// <summary>
        /// 已收金额
        /// </summary>
        public decimal CheckMoney { get; set; }

        /// <summary>
        /// 已退金额
        /// </summary>
        public decimal ReturnMoney { get; set; }

        /// <summary>
        /// 已出票数量
        /// </summary>
        public int YiChuPiao { get; set; }
    }
    #endregion

    #region 已安排出票列表
    /// <summary>
    /// 已安排出票列表
    /// </summary>
    public class MPlan_ChuPiao
    {
        /// <summary>
        /// 安排编号
        /// </summary>
        public string PlanId { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 代理商名称
        /// </summary>
        public string DaiLiName { get; set; }
        /// <summary>
        /// 订单号或编码
        /// </summary>
        public string GysOrderCode { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int ShuLiang { get; set; }
        /// <summary>
        /// 结算明细
        /// </summary>
        public string JieSuanMX { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JieSuanAmount { get; set; }
        /// <summary>
        /// 已支付金额
        /// </summary>
        public decimal PayMoney { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 安排出票时间
        /// </summary>
        public DateTime IssueTime { get; set; }
    }
    #endregion
}
