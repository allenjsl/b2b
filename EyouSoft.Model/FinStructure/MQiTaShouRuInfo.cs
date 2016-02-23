//财务管理其它收入相关信息业务实体 汪奇志 2012-11-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 其它收入信息业务实体
    /// <summary>
    /// 其它收入信息业务实体
    /// </summary>
    public class MQiTaShouRuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MQiTaShouRuInfo() { }

        /// <summary>
        /// 收入编号
        /// </summary>
        public string ShouRuId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 收支类别
        /// </summary>
        public EnumType.FinStructure.QiTaShouZhiType Type { get { return EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiType.收入; } }
        /// <summary>
        /// 收入项目
        /// </summary>
        public string XiangMu { get; set; }
        /// <summary>
        /// 收入金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 收入时间
        /// </summary>
        public DateTime ShiJian { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 对方单位编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 对方单位名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 单位类别
        /// </summary>
        public EnumType.FinStructure.QiTaShouZhiKeHuType KeHuType { get; set; }
        /// <summary>
        /// 已审批金额
        /// </summary>
        public decimal YiShenPiJinE { get; set; }
        /// <summary>
        /// 未审批金额
        /// </summary>
        public decimal WeiShenPiJinE { get; set; }
        /// <summary>
        /// 收入备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 收款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType KuanXiangType { get { return EyouSoft.Model.EnumType.FinStructure.KuanXiangType.其它收入收款; } }
        /// <summary>
        /// 项目编号
        /// </summary>
        public int XiangMuId { get; set; }
        /// <summary>
        /// 是否冲抵
        /// </summary>
        public bool IsChongDi { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 其它收入支出查询信息业务实体
    /// <summary>
    /// 其它收入支出查询信息业务实体
    /// </summary>
    public class MQiTaShouZhiChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MQiTaShouZhiChaXunInfo() { }

        /// <summary>
        /// 收支起始时间
        /// </summary>
        public DateTime? SShiJian { get; set; }
        /// <summary>
        /// 收支截止时间
        /// </summary>
        public DateTime? EShiJian { get; set; }
        /// <summary>
        /// 收支项目
        /// </summary>
        public string XiangMu { get; set; }
        /// <summary>
        /// 对方单位名称
        /// </summary>
        public string DanWeiName { get; set; }
        /// <summary>
        /// 其它收入应收/其它支出应付金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator JinEOperator { get; set; }
        /// <summary>
        /// 其它收入应收金额/其它支出应付金额
        /// </summary>
        public decimal? JinE { get; set; }
        /// <summary>
        /// 其它支出未付金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator WeiFuJinEOperator { get; set; }
        /// <summary>
        /// 其它支出未付金额
        /// </summary>
        public decimal? WeiFuJinE { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public int? XiangMuId { get; set; }
        /// <summary>
        /// 其它收入结清状态/其它支出结清状态 [0:未结清][1:已结清]
        /// </summary>
        public int? JieQingStatus { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
