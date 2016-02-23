using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.TongJiStructure
{
    #region 统计分析-操作人统计信息业务实体
    /// <summary>
    /// 统计分析-操作人统计信息业务实体
    /// </summary>
    public class MCaoZuoRenInfo
    {
        MCaoZuoRenRenShuInfo _t0 = new MCaoZuoRenRenShuInfo();
        MCaoZuoRenRenShuInfo _t1 = new MCaoZuoRenRenShuInfo();
        MCaoZuoRenRenShuInfo _t2 = new MCaoZuoRenRenShuInfo();
        MCaoZuoRenRenShuInfo _t3 = new MCaoZuoRenRenShuInfo();
        MCaoZuoRenRenShuInfo _t4 = new MCaoZuoRenRenShuInfo();
        MCaoZuoRenRenShuInfo _t5 = new MCaoZuoRenRenShuInfo();

        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 常规旅游
        /// </summary>
        public MCaoZuoRenRenShuInfo T0 { get { return _t0; } set { _t0 = value; } }
        /// <summary>
        /// 单订票
        /// </summary>
        public MCaoZuoRenRenShuInfo T1 { get { return _t1; } set { _t1 = value; } }
        /// <summary>
        /// 票务酒店
        /// </summary>
        public MCaoZuoRenRenShuInfo T2 { get { return _t2; } set { _t2 = value; } }
        /// <summary>
        /// 代订酒店
        /// </summary>
        public MCaoZuoRenRenShuInfo T3 { get { return _t3; } set { _t3 = value; } }
        /// <summary>
        /// 私人订制（特殊旅游）
        /// </summary>
        public MCaoZuoRenRenShuInfo T4 { get { return _t4; } set { _t4 = value; } }
        /// <summary>
        /// 自由行
        /// </summary>
        public MCaoZuoRenRenShuInfo T5 { get { return _t5; } set { _t5 = value; } }
    }
    #endregion

    #region 统计分析-操作人统计查询信息业务实体
    /// <summary>
    /// 统计分析-操作人统计查询信息业务实体
    /// </summary>
    public class MCaoZuoRenChaXunInfo
    {
        /// <summary>
        /// 出团开始时间
        /// </summary>
        public DateTime? LSDate { get; set; }
        /// <summary>
        /// 出团截止时间
        /// </summary>
        public DateTime? LEDate { get; set; }
    }
    #endregion

    #region 统计分析-操作人统计人数信息业务实体
    /// <summary>
    /// 统计分析-操作人统计人数信息业务实体
    /// </summary>
    public class MCaoZuoRenRenShuInfo
    {
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRen { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTong { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int QuanPei { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingEr { get; set; }

        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType YuWuLeiXing { get; set; }
    }
    #endregion
}
