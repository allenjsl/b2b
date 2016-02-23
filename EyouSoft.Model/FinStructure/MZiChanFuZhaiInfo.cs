//汪奇志 2013-02-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 财务管理-资产负债表信息业务实体
    /// <summary>
    /// 财务管理-资产负债表信息业务实体
    /// </summary>
    public class MZiChanFuZhaiInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MZiChanFuZhaiInfo() { }

        /// <summary>
        /// 资产负债编号
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
        /// 货币资金
        /// </summary>
        public decimal HuoBiZiJin { get; set; }
        /// <summary>
        /// 应收帐款合计
        /// </summary>
        public decimal YingShouZhangKuan { get; set; }
        /// <summary>
        /// 其他应收款合计
        /// </summary>
        public decimal QiTaYingShouKuan { get; set; }
        /// <summary>
        /// 预付帐款
        /// </summary>
        public decimal YuFuZhangKuan { get; set; }
        /// <summary>
        /// 其他预付
        /// </summary>
        public decimal QiTaYuFu { get; set; }
        /// <summary>
        /// 应付帐款
        /// </summary>
        public decimal YingFuZhangKuan { get; set; }
        /// <summary>
        /// 应付帐款-其他
        /// </summary>
        public decimal QiTaYingFuKuan { get; set; }
        /// <summary>
        /// 预收帐款
        /// </summary>
        public decimal YuShouZhangKuan { get; set; }
        /// <summary>
        /// 预收帐款-其它
        /// </summary>
        public decimal QiTaYuShou { get; set; }
        /// <summary>
        /// 实收股本
        /// </summary>
        public decimal ShiShouGuBen { get; set; }
        /// <summary>
        /// 未分配利润
        /// </summary>
        public decimal WeiFenPeiLiRun { get; set; }
        /// <summary>
        /// 差 额
        /// </summary>
        public decimal ChaE { get; set; }
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
        /// 资产负债年月-01
        /// </summary>
        public DateTime YMD { get; set; }
        /// <summary>
        /// 应收团款
        /// </summary>
        public decimal YingShouTuanKuan { get; set; }
        /// <summary>
        /// 应收押金退款
        /// </summary>
        public decimal YingShouYaJinTuiKuan { get; set; }
        /// <summary>
        /// 应收酒店退款
        /// </summary>
        public decimal YingShouJiuDianTuiKuan { get; set; }
        /// <summary>
        /// 应收退票款
        /// </summary>
        public decimal YingShouTuiPiaoKuan { get; set; }
        /// <summary>
        /// 应收账款-其他
        /// </summary>
        public decimal YingShouQiTa { get; set; }
        /// <summary>
        /// 质量保证金
        /// </summary>
        public decimal ZhiLiangBaoZhengJin { get; set; }
        /// <summary>
        /// 个人借款
        /// </summary>
        public decimal GeRenJieKuan { get; set; }
        /// <summary>
        /// 供应商押金
        /// </summary>
        public decimal GongYingShangYaJin { get; set; }
        /// <summary>
        /// 酒店押金
        /// </summary>
        public decimal JiuDianYaJin { get; set; }
        /// <summary>
        /// 组团社押金
        /// </summary>
        public decimal ZuTuanSheYaJin { get; set; }
        /// <summary>
        /// 其它应收款-其他
        /// </summary>
        public decimal QTYSQiTa { get; set; }
        /// <summary>
        /// 预付-地接款
        /// </summary>
        public decimal YuFuDiJieKuan { get; set; }
        /// <summary>
        /// 预付-机票款
        /// </summary>
        public decimal YuFuJiPiaoKuan { get; set; }
        /// <summary>
        /// 预付-交通押金款
        /// </summary>
        public decimal YuFuJiaoTongYaJinKuan { get; set; }
        /// <summary>
        /// 预付-酒店款
        /// </summary>
        public decimal YuFuJiuDianKuan { get; set; }
        /// <summary>
        /// 应付-地接款
        /// </summary>
        public decimal YingFuDiJieKuan { get; set; }
        /// <summary>
        /// 应付-机票款
        /// </summary>
        public decimal YingFuJiPiaoKuan { get; set; }
        /// <summary>
        /// 应付-酒店款
        /// </summary>
        public decimal YingFuJiuDianKuan { get; set; }
        /// <summary>
        /// 预收团款
        /// </summary>
        public decimal YuShouTuanKuan { get; set; }
        /// <summary>
        /// 预收退票款
        /// </summary>
        public decimal YuShouTuiPiaoKuan { get; set; }
        /// <summary>
        /// 暂时借款
        /// </summary>
        public decimal ZanShiJieKuan { get; set; }
        /// <summary>
        /// 累计未分配利润
        /// </summary>
        public decimal LeiJiWeiFenPeiLiRun { get; set; }
        /// <summary>
        /// 本月未分配利润
        /// </summary>
        public decimal BenYueWeiFenPeiLiRun { get; set; }
        /// <summary>
        /// 应收账款-备注
        /// </summary>
        public string YingShouZhangKuanBeiZhu { get; set; }
        /// <summary>
        /// 其它应收款-备注
        /// </summary>
        public string QiTaYingShouKuanBeiZhu { get; set; }
        /// <summary>
        /// 预付账款-备注
        /// </summary>
        public string YuFuZhangKuanBeiZhu { get; set; }
        /// <summary>
        /// 应付账款-备注
        /// </summary>
        public string YingFuZhangKuanBeiZhu { get; set; }
        /// <summary>
        /// 预收账款-备注
        /// </summary>
        public string YuShouZhangKuanBeiZhu { get; set; }
        /// <summary>
        /// 实收股本-备注
        /// </summary>
        public string ShiShouGuBenBeiZhu { get; set; }
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
        public IList<MZiChanFuZhaiHistoryInfo> Historys { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 财务管理-资产负债表查询信息业务实体
    /// <summary>
    /// 财务管理-资产负债表查询信息业务实体
    /// </summary>
    public class MZiChanFuZhaiChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MZiChanFuZhaiChaXunInfo() { }

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

    #region 财务管理-资产负债表修改记录信息业务实体
    /// <summary>
    /// 财务管理-资产负债表修改记录信息业务实体
    /// </summary>
    public class MZiChanFuZhaiHistoryInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MZiChanFuZhaiHistoryInfo() { }

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
