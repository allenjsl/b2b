//汪奇志 2013-02-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 财务管理-利润表信息业务实体
    /// <summary>
    /// 财务管理-利润表信息业务实体
    /// </summary>
    public class MLiRunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MLiRunInfo() { }

        /// <summary>
        /// 利润编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 团队结算毛利
        /// </summary>
        public decimal TuanDuiJieSuanMaoLi { get; set; }
        /// <summary>
        /// 报销费用/营业费用
        /// </summary>
        public decimal BaoXiaoFeiYong { get; set; }
        /// <summary>
        /// 营业外收入
        /// </summary>
        public decimal YingYeWaiShouRu { get; set; }
        /// <summary>
        /// 营业外支出
        /// </summary>
        public decimal YingYeWaiZhiChu { get; set; }
        /// <summary>
        /// 纯利润
        /// </summary>
        public decimal ChunLiRun { get; set; }
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
        /// 利润年月-01
        /// </summary>
        public DateTime YMD{get;set;}
        /// <summary>
        /// 主营业务收入
        /// </summary>
        public decimal ZhuYingYeWuShouRu { get; set; }
        /// <summary>
        /// 主营业务支出/主营业务成本
        /// </summary>
        public decimal ZhuYingYeWuZhiChu { get; set; }
        /// <summary>
        /// 单订房应收款
        /// </summary>
        public decimal DanFangYingShouKuan { get; set; }
        /// <summary>
        /// 单定票应收款
        /// </summary>
        public decimal DanDingPiaoYingShouKuan { get; set; }
        /// <summary>
        /// 票务酒店应收款
        /// </summary>
        public decimal PiaoWuJiuDianYingShouKuan { get; set; }
        /// <summary>
        /// 常规旅游应收款
        /// </summary>
        public decimal ChangGuiLvYouYingShouKuan { get; set; }
        /// <summary>
        /// 特殊旅游应收款
        /// </summary>
        public decimal TeShuLvYouYingShouKuan { get; set; }
        /// <summary>
        /// 退票收入
        /// </summary>
        public decimal TuiPiaoShouRu { get; set; }
        /// <summary>
        /// 其他主营业务收入收入
        /// </summary>
        public decimal QiTaZhuYingYeWuShouRu { get; set; }
        /// <summary>
        /// 地接款
        /// </summary>
        public decimal DiJieKuan { get; set; }
        /// <summary>
        /// 机票款
        /// </summary>
        public decimal JiPiaoKuan { get; set; }
        /// <summary>
        /// 交通押金
        /// </summary>
        public decimal JiaoTongYaJin { get; set; }
        /// <summary>
        /// 酒店款
        /// </summary>
        public decimal JiuDianKuan { get; set; }
        /// <summary>
        /// 其他主营业务支出
        /// </summary>
        public decimal QiTaZhuYingYeWuZhiChu { get; set; }
        /// <summary>
        /// 银行利息收入
        /// </summary>
        public decimal YingHangLiXiShouRu { get; set; }
        /// <summary>
        /// 房租收入
        /// </summary>
        public decimal FangZuShouRu { get; set; }
        /// <summary>
        /// 供应商返佣
        /// </summary>
        public decimal GongYingShangFanYong { get; set; }
        /// <summary>
        /// 海口公司返佣
        /// </summary>
        public decimal HaiKouGongSiFanYong { get; set; }
        /// <summary>
        /// 其他营业外收入
        /// </summary>
        public decimal QiTaYingYeWaiShouRu { get; set; }
        /// <summary>
        /// 其他损失
        /// </summary>
        public decimal QiTaSunShi { get; set; }
        /// <summary>
        /// 主营业务收入备注
        /// </summary>
        public string ZhuYingYeWuShouRuBeiZhu { get; set; }
        /// <summary>
        /// 主营业务支出备注
        /// </summary>
        public string ZhuYingYeWuZhiChuBeiZhu { get; set; }
        /// <summary>
        /// 营业外收入备注
        /// </summary>
        public string YingYeWaiShouRuBeiZhu { get; set; }
        /// <summary>
        /// 营业外支出备注
        /// </summary>
        public string YingYeWaiZhiChuBeiZhu { get; set; }
        /// <summary>
        /// 其它损失备注
        /// </summary>
        public string QiTaSunShiBeiZhu { get; set; }
        /// <summary>
        /// 修改页面Uri，记录变更历史时使用
        /// </summary>
        public string PageUri { get; set; }
        /// <summary>
        /// 是否变更
        /// </summary>
        public bool IsBianGeng { get; set; }
        /// <summary>
        /// 修改历史信息集合
        /// </summary>
        public IList<MLiRunHistoryInfo> Historys { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 财务管理-利润表查询信息业务实体
    /// <summary>
    /// 财务管理-利润表查询信息业务实体
    /// </summary>
    public class MLiRunChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MLiRunChaXunInfo() { }

        /// <summary>
        /// 年份
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int? Month { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 财务管理-利润表修改记录信息业务实体
    /// <summary>
    /// 财务管理-利润表修改记录信息业务实体
    /// </summary>
    public class MLiRunHistoryInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MLiRunHistoryInfo() { }

        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 修改项目
        /// </summary>
        public string XiangMu { get; set; }
        /// <summary>
        /// 修改内容
        /// </summary>
        public string NeiRong { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
    }
    #endregion
}
