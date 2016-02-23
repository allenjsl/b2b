//财务管理发票相关信息业务实体 汪奇志 2012-11-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 发票信息业务实体
    /// <summary>
    /// 发票信息业务实体
    /// </summary>
    public class MFaPiaoInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MFaPiaoInfo() { }

        /// <summary>
        /// 发票编号
        /// </summary>
        public string FaPiaoId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 开票申请日期
        /// </summary>
        public DateTime ShenQingRiQi { get; set; }
        /// <summary>
        /// 客户单位编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public string TaiTou { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 开票项目明细
        /// </summary>
        public string XiangMuMingXi { get; set; }
        /// <summary>
        /// 开具发票单位名称
        /// </summary>
        public string KaiJuDanWeiName { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string FaPiaoHao { get; set; }
        /// <summary>
        /// 发票发送状态
        /// </summary>
        public EnumType.FinStructure.FaPiaoFaSongStatus Status { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 发票明细信息集合
        /// </summary>
        public IList<MFaPiaoMXInfo> Mxs { get; set; }
        /// <summary>
        /// 第一个出团日期
        /// </summary>
        public DateTime? FirstChuTuanRiQi
        {
            get
            {
                if (Mxs != null && Mxs.Count > 0) return Mxs[0].ChuTuanRiQi;

                return null;
            }
        }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 发票明细信息业务实体
    /// <summary>
    /// 发票明细信息业务实体
    /// </summary>
    public class MFaPiaoMXInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MFaPiaoMXInfo() { }

        /// <summary>
        /// 自增编号
        /// </summary>
        public int MXId { get; set; }

        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime ChuTuanRiQi { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 发票发送状态
        /// </summary>
        public EnumType.FinStructure.FaPiaoFaSongStatus Status { get; set; }
        /// <summary>
        /// 发票送出时间
        /// </summary>
        public DateTime? FaSongTime { get; set; }
        /// <summary>
        /// 发票送出方式
        /// </summary>
        public string FaSongFangShi { get; set; }
        /// <summary>
        /// 邮寄公司名称
        /// </summary>
        public string YouJiGongSiName { get; set; }
        /// <summary>
        /// 邮寄单号
        /// </summary>
        public string YouJiDanHao { get; set; }
        /// <summary>
        /// 签收人姓名
        /// </summary>
        public string QianShouRenName { get; set; }
        /// <summary>
        /// 签收时间
        /// </summary>
        public DateTime? QianShouTime { get; set; }

        /// <summary>
        /// 明细编号
        /// </summary>
        public string MingXiId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public string TaiTou { get; set; }
        /// <summary>
        /// 开票单位
        /// </summary>
        public string KaiPiaoDanWei { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string FaPiaoHao { get; set; }
        /// <summary>
        /// 发票明细
        /// </summary>
        public string MingXi { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 发票查询信息业务实体
    /// <summary>
    /// 发票查询信息业务实体
    /// </summary>
    public class MFaPiaoChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MFaPiaoChaXunInfo() { }

        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string KeHuName { get; set; }
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
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string FaPiaoHao { get; set; }
    }
    #endregion

    #region AJAX自动完成发票订单信息业务实体
    /// <summary>
    /// AJAX自动完成发票订单信息业务实体
    /// </summary>
    public class MAjaxAutocompleteFaPiaoDingDanInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal JinE { get; set; }
    }
    #endregion

    #region AJAX自动完成发票订单信息查询业务实体
    /// <summary>
    /// AJAX自动完成发票订单信息查询业务实体
    /// </summary>
    public class MAjaxAutocompleteFaPiaoDingChaXunDanInfo
    {
        /// <summary>
        /// 客户单位编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 不需要的订单编号
        /// </summary>
        public IList<string> NotInDingDanId { get; set; }
        int _TopExpression = 15;
        /// <summary>
        /// top expression
        /// </summary>
        public int TopExpression
        {
            get { return _TopExpression; }
            set { _TopExpression = value; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId0 { get; set; }
    }
    #endregion
}
