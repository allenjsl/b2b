//财务管理其它支出相关信息业务实体 汪奇志 2012-11-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 其它支出信息业务实体
    /// <summary>
    /// 其它支出信息业务实体
    /// </summary>
    public class MQiTaZhiChuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MQiTaZhiChuInfo() { }

        /// <summary>
        /// 支出编号
        /// </summary>
        public string ZhiChuId { get; set; }
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
        public EnumType.FinStructure.QiTaShouZhiType Type { get { return EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiType.支出; } }
        /// <summary>
        /// 支出项目
        /// </summary>
        public string XiangMu { get; set; }
        /// <summary>
        /// 支出金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 支出时间
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
        /// 已支付金额
        /// </summary>
        public decimal YiZhiFuJinE { get; set; }
        /// <summary>
        /// 已审批金额
        /// </summary>
        public decimal YiShenPiJinE { get; set; }
        /// <summary>
        /// 未审批金额
        /// </summary>
        public decimal WeiShenPiJinE { get; set; }
        /// <summary>
        /// 支出备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 付款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType KuanXiangType { get { return EyouSoft.Model.EnumType.FinStructure.KuanXiangType.其它支出付款; } }
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
}
