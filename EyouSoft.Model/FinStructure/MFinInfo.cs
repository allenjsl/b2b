//财务管理相关信息业务实体 汪奇志 2012-11-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.FinStructure
{
    #region 财务管理-银行余额信息业务实体
    /// <summary>
    /// 财务管理-银行余额信息业务实体
    /// </summary>
    public class MYinHangYuEInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYinHangYuEInfo() { }

        /// <summary>
        /// 银行账户编号
        /// </summary>
        public string ZhangHuId { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string KaiHuHang { get; set; }
        /// <summary>
        /// 账户名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string ZhangHao { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal YuE { get; set; }
    }
    #endregion

    #region 财务管理-银行明细信息业务实体
    /// <summary>
    /// 财务管理-银行明细信息业务实体
    /// </summary>
    public class MYinHangMingXiInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYinHangMingXiInfo() { }

        /// <summary>
        /// 明细编号
        /// </summary>
        public string MingXiId { get; set; }
        /// <summary>
        /// 银行账户编号
        /// </summary>
        public string ZhangHuId { get; set; }
        /// <summary>
        /// 银行账户名称
        /// </summary>
        public string ZhangHuName { get; set; }
        /// <summary>
        /// 银行实际业务日期
        /// </summary>
        public DateTime BankDate { get; set; }
        /// <summary>
        /// 款项类型
        /// </summary>
        public EnumType.FinStructure.KuanXiangType KuanXiangType { get; set; }
        /// <summary>
        /// 往来单位
        /// </summary>
        public string WangLaiDanWeiName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 借方金额
        /// </summary>
        public decimal JieFangJinE { get; set; }
        /// <summary>
        /// 贷方金额
        /// </summary>
        public decimal DaiFangJinE { get; set; }
    }
    #endregion

    #region 财务管理-银行明细查询信息业务实体
    /// <summary>
    /// 财务管理-银行明细查询信息业务实体
    /// </summary>
    public class MYinHangMingXiChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYinHangMingXiChaXunInfo() { }

        /// <summary>
        /// 银行实际业务起始时间
        /// </summary>
        public DateTime? SBankDate { get; set; }
        /// <summary>
        /// 银行实际业务截止时间
        /// </summary>
        public DateTime? EBankDate { get; set; }
        /// <summary>
        /// 银行账户编号
        /// </summary>
        public string YinHangZhangHuId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 财务管理-财务操作人相关信息业务实体
    /// <summary>
    /// 财务管理-财务操作人相关信息业务实体
    /// </summary>
    public class MOperatorInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MOperatorInfo() { }

        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperatorTime
        {
            get { return DateTime.Now; }
        }
        /// <summary>
        /// 操作备注
        /// </summary>
        public string BeiZhu { get; set; }
    }
    #endregion

    #region 财务管理-订单中心列表业务实体
    /// <summary>
    /// 财务管理-订单中心列表业务实体
    /// </summary>
    public class MOrderInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MOrderInfo() { }

        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime LDate { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 客户单位编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 对方操作人编号
        /// </summary>
        public int KeHuLxrId { get; set; }
        /// <summary>
        /// 对方操作人姓名
        /// </summary>
        public string KeHuLxrName { get; set; }

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
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int QuanPeiShu { get; set; }
        /// <summary>
        /// 占位数量
        /// </summary>
        public int ZhanWeiShu { get; set; }
        /// <summary>
        /// 价格明细(录入)
        /// </summary>
        public string JiaGeMingXi { get; set; }
        /// <summary>
        /// 价格明细(自动)
        /// </summary>
        public string JiaGeMingXi1 { get; set; }
        /// <summary>
        /// 价格明细（显示）
        /// </summary>
        public string JiaGeMingXi2
        {
            get
            {
                if (!string.IsNullOrEmpty(JiaGeMingXi)) return JiaGeMingXi;
                return JiaGeMingXi1;
            }
        }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.OrderStatus Status { get; set; }
        /// <summary>
        /// 订单下单人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 订单下单人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType YeWuLeiXing { get; set; }
        /// <summary>
        /// 游客姓名
        /// </summary>
        public string YouKeName { get; set; }
        /// <summary>
        /// 留位到期时间
        /// </summary>
        public DateTime? LiuWeiDaoQiTime { get; set; }
        /// <summary>
        /// 订单标识颜色
        /// </summary>
        public string BiaoShiYanSe { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingErRenShu { get; set; }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 最后操作人姓名
        /// </summary>
        public string LatestOperatorName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 发票明细编号
        /// </summary>
        public int FaPiaoMxId { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal FaPiaoJinE { get; set; }
    }
    #endregion

    #region 财务管理-订单查询信息业务实体
    /// <summary>
    /// 财务管理-订单查询信息业务实体
    /// </summary>
    public class MOrderChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MOrderChaXunInfo() { }

        /// <summary>
        /// 出团起始时间
        /// </summary>
        public DateTime? LSDate { get; set; }
        /// <summary>
        /// 出团截止时间
        /// </summary>
        public DateTime? LEDate { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 客户单位省份编号
        /// </summary>
        public int? KeHuProvinceId { get; set; }
        /// <summary>
        /// 客户单位城市编号
        /// </summary>
        public int? KeHuCityId { get; set; }
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string keHuName { get; set; }
        /// <summary>
        /// 游客姓名
        /// </summary>
        public string YouKeName { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EnumType.TourStructure.OrderStatus? Status { get; set; }
        /// <summary>
        /// 订单操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 应收金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator YingShouJinEOperator { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal? YingShouJinE { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType? YeWuLeiXing { get; set; }
        /// <summary>
        /// 结清状态 [0:未结清][1:已结清]
        /// </summary>
        public int? JieQingStatus { get; set; }
        /// <summary>
        /// 单笔收款金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator DanBiShouKuanJinEOperator { get; set; }
        /// <summary>
        /// 单笔收款金额
        /// </summary>
        public decimal? DanBiShouKuanJinE { get; set; }
        /// <summary>
        /// 未收金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator WeiShouJinEOperator { get; set; }
        /// <summary>
        /// 未收金额
        /// </summary>
        public decimal? WeiShouJinE { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int? QuYuId { get; set; }
        /// <summary>
        /// 去程交通编号
        /// </summary>
        public int? QuJiaoTongId { get; set; }

        /// <summary>
        /// 退款金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator TuiKuanJinEOperator { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal? TuiKuanJinE { get; set; }
        /// <summary>
        /// 排序 [0:下单时间DESC] [1:下单时间ASC] [2:出团日期DESC] [3:出团日期ASC]
        /// </summary>
        public int PaiXuLeiXing { get; set; }
    }
    #endregion

    #region 财务管理-销售收款列表业务实体
    /// <summary>
    /// 财务管理-销售收款列表业务实体
    /// </summary>
    public class MYingShouInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYingShouInfo() { }

        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime LDate { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 客户单位编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 对方操作人编号
        /// </summary>
        public int KeHuLxrId { get; set; }
        /// <summary>
        /// 对方操作人姓名
        /// </summary>
        public string KeHuLxrName { get; set; }
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
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int QuanPeiShu { get; set; }
        /// <summary>
        /// 占位数量
        /// </summary>
        public int ZhanWeiShu { get; set; }
        /// <summary>
        /// 价格明细(录入)
        /// </summary>
        public string JiaGeMingXi { get; set; }
        /// <summary>
        /// 价格明细（自动）
        /// </summary>
        public string JiaGeMingXi1 { get; set; }
        /// <summary>
        /// 价格明细（显示）
        /// </summary>
        public string JiaGeMingXi2
        {
            get
            {
                if (!string.IsNullOrEmpty(JiaGeMingXi)) return JiaGeMingXi;
                return JiaGeMingXi1;
            }
        }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.OrderStatus Status { get; set; }
        /// <summary>
        /// 订单下单人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 订单下单人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType YeWuLeiXing { get; set; }
        /*/// <summary>
        /// 已收金额
        /// </summary>
        public decimal YiShouJinE { get { return ShouYiShenHeJinE - TuiYiShenHeJinE; } }
        /// <summary>
        /// 未收金额
        /// </summary>
        public decimal WeiShouJinE { get { return JinE - YiShouJinE; } }*/
        /// <summary>
        /// 收款已审核金额
        /// </summary>
        public decimal ShouYiShenHeJinE { get; set; }
        /// <summary>
        /// 收款未审核金额
        /// </summary>
        public decimal ShouWeiShenHeJinE { get; set; }
        /// <summary>
        /// 退款已审核金额
        /// </summary>
        public decimal TuiYiShenHeJinE { get; set; }
        /// <summary>
        /// 退款未审核金额
        /// </summary>
        public decimal TuiWeiShenHeJinE { get; set; }
        /// <summary>
        /// 游客姓名
        /// </summary>
        public string YouKeName { get; set; }
        /// <summary>
        /// 订单标识颜色
        /// </summary>
        public string BiaoShiYanSe { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingErRenShu { get; set; }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 最后操作人姓名
        /// </summary>
        public string LatestOperatorName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
    }
    #endregion

    #region 财务管理-应付款信息业务实体
    /// <summary>
    /// 财务管理-应付款信息业务实体
    /// </summary>
    public class MYingFuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYingFuInfo() { }

        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 安排编号
        /// </summary>
        public string PlanId { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime LDate { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 交易号(团号)
        /// </summary>
        public string JiaoYiHao { get; set; }        
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }        
        /// <summary>
        /// 结算明细
        /// </summary>
        public string JieSuanMingXi { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JieSuanJinE { get; set; }
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
        /// 未支付金额
        /// </summary>
        public decimal WeiZhiFuJinE { get { return JieSuanJinE - YiZhiFuJinE; } }
        /// <summary>
        /// 导游姓名
        /// </summary>
        public string DaoYouName { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingErShu { get; set; }
    }
    #endregion

    #region 财务管理-应付地接费业务实体
    /// <summary>
    /// 财务管理-应付地接费业务实体
    /// </summary>
    public class MYingFuDiJieInfo:MYingFuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYingFuDiJieInfo() { }
        
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }        
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int QuanPeiShu { get; set; }        
        /// <summary>
        /// 付款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType KuanXiangType { get { return EyouSoft.Model.EnumType.FinStructure.KuanXiangType.地接支出付款; } }

        /// <summary>
        /// 地接社确认状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.QueRenStatus DiJieQueRenStatus { get; set; }
        /// <summary>
        /// 地接社确认人编号
        /// </summary>
        public int DiJieQueRenRenId { get; set; }
        /// <summary>
        /// 地接社确认人姓名（OUTPUT）
        /// </summary>
        public string DiJieQueRenRenName { get; set; }
        /// <summary>
        /// 地接社确认时间
        /// </summary>
        public DateTime? DiJieQueRenTime { get; set; }
    }
    #endregion

    #region 财务管理-应付交通费业务实体
    /// <summary>
    /// 财务管理-应付交通费业务实体
    /// </summary>
    public class MYingFuJiaoTongInfo : MYingFuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYingFuJiaoTongInfo() { }
        
        /// <summary>
        /// 出票数
        /// </summary>
        public int ChuPiaoShu { get; set; }
        /// <summary>
        /// 付款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType KuanXiangType { get { return EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务安排付款; } }
        /// <summary>
        /// 游客信息集合
        /// </summary>
        public IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> YouKes { get; set; }
        /// <summary>
        /// 第一个游客姓名
        /// </summary>
        public string YouKeName
        {
            get
            {
                if (YouKes == null || YouKes.Count == 0) return string.Empty;

                return YouKes[0].TravellerName;
            }
        }
    }
    #endregion

    #region 财务管理-应付酒店费业务实体
    /// <summary>
    /// 财务管理-应付酒店费业务实体
    /// </summary>
    public class MYingFuJiuDianInfo : MYingFuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYingFuJiuDianInfo() { }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string JiuDianName { get; set; }
        /// <summary>
        /// 付款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType KuanXiangType { get { return EyouSoft.Model.EnumType.FinStructure.KuanXiangType.酒店安排付款; } }
    }
    #endregion

    #region 财务管理-应付款查询业务实体
    /// <summary>
    /// 财务管理-应付款查询业务实体
    /// </summary>
    public class MYingFuChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYingFuChaXunInfo() { }
        
        /// <summary>
        /// 出团起始日期
        /// </summary>
        public DateTime? LSDate { get; set; }
        /// <summary>
        /// 出团截止日期
        /// </summary>
        public DateTime? LEDate { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 交易号(系统内)
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 订单号或编码(系统外)
        /// </summary>
        public string GysJiaoYiHao { get; set; }
        /// <summary>
        /// 供应商(代理商)名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 订单号(与客户单位交易产生的单号)
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 押金登记表(财)-应退押金金额
        /// </summary>
        public decimal? YingTuiYaJinJinE { get; set; }
        /// <summary>
        /// 押金登记表(财)-应退押金金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator YingTuiYaJinOperator { get; set; }
        /// <summary>
        /// 退票登记表(财)-应退金额
        /// </summary>
        public decimal? TuiPiaoYingTuiJinE { get; set; }
        /// <summary>
        /// 退票登记表(财)-应退金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator TuiPiaoYingTuiOperator { get; set; }
        /// <summary>
        /// 应付金额(地接、交通、酒店、押金)查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator YingFuJinEOperator { get; set; }
        /// <summary>
        /// 应付(地接、交通、酒店、押金)金额
        /// </summary>
        public decimal? YingFuJinE { get; set; }
        /// <summary>
        /// 应付(地接、交通、酒店)结清状态 [0:未结清][1:已结清]
        /// </summary>
        public int? JieQingStatus { get; set; }        
        /// <summary>
        /// 押金登记表(财)-退押金已审批金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator TuiYiShenPiYaJinOperator { get; set; }
        /// <summary>
        /// 押金登记表(财)-退押金已审批金额
        /// </summary>
        public decimal? TuiYiShenPiYaJinJinE { get; set; }
       
        /// <summary>
        /// 退票登记表(财)-已退金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator TuiPiaoYiTuiJinEOperator { get; set; }
        /// <summary>
        /// 退票登记表(财)-已退金额
        /// </summary>
        public decimal? TuiPiaoYiTuiJinE { get; set; }
        /// <summary>
        /// 退票登记表(财)-未退金额查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator TuiPiaoWeiTuiJinEOperator { get; set; }
        /// <summary>
        /// 退票登记表(财)-未退金额
        /// </summary>
        public decimal? TuiPiaoWeiTuiJinE { get; set; }
        
        /// <summary>
        /// 预订酒店应付表-酒店名称
        /// </summary>
        public string JiuDianName { get; set; }
        /// <summary>
        /// 应付交通费-去程交通
        /// </summary>
        public int? QuJiaoTongId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }

        /// <summary>
        /// 应付地接-线路名称
        /// </summary>
        public string RouteName { get; set; }
        
        /// <summary>
        /// 已支付金额-查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator YiZhiFuJinEOperator { get; set; }
        /// <summary>
        /// 已支付金额
        /// </summary>
        public decimal? YiZhiFuJinE { get; set; }

        /// <summary>
        /// 未支付金额-查询操作符
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.QueryOperator WeiZhiFuJinEOperator { get; set; }
        /// <summary>
        /// 未支付金额
        /// </summary>
        public decimal? WeiZhiFuJinE { get; set; }

        /// <summary>
        /// 排序 [0:操作时间DESC] [1:操作时间ASC] [2:出团日期DESC] [3:出团日期ASC]
        /// </summary>
        public int PaiXuLeiXing { get; set; }
        /// <summary>
        /// 退票登记表-游客姓名
        /// </summary>
        public string YouKeName { get; set; }
    }
    #endregion

    #region 财务管理-押金登记表业务实体
    /// <summary>
    /// 财务管理-押金登记表业务实体
    /// </summary>
    public class MYaJinInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MYaJinInfo() { }

        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 安排编号
        /// </summary>
        public string PlanId { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime LDate { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 订单号或编号(系统外)
        /// </summary>
        public string GysJiaoYiHao { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 控位数量
        /// </summary>
        public int ShuLiang { get; set; }
        /// <summary>
        /// 押金金额
        /// </summary>
        public decimal YaJinJinE { get; set; }
        /// <summary>
        /// 已支付押金金额
        /// </summary>
        public decimal YiZhiFuJinE { get; set; }
        /// <summary>
        /// 已审批押金金额
        /// </summary>
        public decimal YiShenPiJinE { get; set; }
        /// <summary>
        /// 未审批押金金额
        /// </summary>
        public decimal WeiShenPiJinE { get; set; }
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
        /// 付押金款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType FuKuanXiangType { get { return EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务押金付款; } }
        /// <summary>
        /// 退回押金款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType TuiKuanXiangType { get { return EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务押金退还; } }
    }
    #endregion

    #region 财务管理-退票登记表业务实体
    /// <summary>
    /// 财务管理-退票登记表业务实体
    /// </summary>
    public class MTuiPiaoInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MTuiPiaoInfo() { }

        /// <summary>
        /// 退票编号
        /// </summary>
        public string TuiPiaoId { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 出票安排编号
        /// </summary>
        public string PlanId { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime LDate { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 交易号，与供应商交易产生的交易号（系统内）
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 订单号或编码，，与供应商交易产生的交易号（系统外）
        /// </summary>
        public string GysJiaoYiHao { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 退票人数
        /// </summary>
        public int TuiRenShu { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 退票时间
        /// </summary>
        public DateTime TuiTime { get; set; }
        /// <summary>
        /// 损失明细
        /// </summary>
        public string SunShiMingXi { get; set; }
        /// <summary>
        /// 损失金额
        /// </summary>
        public decimal SunShiJinE { get; set; }
        /// <summary>
        /// 承担方
        /// </summary>
        public string ChengDanFang { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
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
        /// 付款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType KuanXiangType { get { return EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务退款; } }

        /// <summary>
        /// 游客信息集合
        /// </summary>
        public IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> YouKes { get; set; }
        /// <summary>
        /// 第一个游客姓名
        /// </summary>
        public string YouKeName
        {
            get
            {
                if (YouKes == null || YouKes.Count == 0) return string.Empty;

                return YouKes[0].TravellerName;
            }
        }
    }
    #endregion

    #region 团队核算控位收入信息业务实体
    /// <summary>
    /// 团队核算控位收入信息业务实体
    /// </summary>
    public class MKongWeiShouRuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MKongWeiShouRuInfo() { }

        /// <summary>
        /// 关联项目编号
        /// </summary>
        public string XiangMuId { get; set; }
        /// <summary>
        /// 收款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType KuanXiangType { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 价格明细-录入
        /// </summary>
        public string JiaGeMingXi { get; set; }
        /// <summary>
        /// 价格明细-自动
        /// </summary>
        public string JiaGeMingXi1 { get; set; }
        /// <summary>
        /// 价格明细-显示
        /// </summary>
        public string JiaGeMingXi2
        {
            get
            {
                if (!string.IsNullOrEmpty(JiaGeMingXi)) return JiaGeMingXi;
                return JiaGeMingXi1;
            }
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal JinE { get; set; }
    }
    #endregion

    #region 团队核算控位支出信息业务实体
    /// <summary>
    /// 团队核算控位支出信息业务实体
    /// </summary>
    public class MKongWeiZhiChuInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MKongWeiZhiChuInfo() { }

        /// <summary>
        /// 关联项目编号
        /// </summary>
        public string XiangMuId { get; set; }
        /// <summary>
        /// 付款款项类型
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.KuanXiangType KuanXiangType { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 结算明细
        /// </summary>
        public string JieSuanMingXi { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal JinE { get; set; }
    }
    #endregion

    #region 财务管理-团队结算汇总表信息业务实体
    /// <summary>
    /// 财务管理-团队结算汇总表信息业务实体
    /// </summary>
    public class MTuanDuiJieSuanInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MTuanDuiJieSuanInfo() { }

        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 控位类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType KongWeiType { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 线路区域名称
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 控位数量
        /// </summary>
        public int ShuLiang { get; set; }
        /// <summary>
        /// 点位数量
        /// </summary>
        public int ZhanWeiShuLiang { get; set; }
        /// <summary>
        /// 去程交通
        /// </summary>
        public string QuJiaoTongName { get; set; }
        /// <summary>
        /// 去程出发地城市名称
        /// </summary>
        public string QuDepCityName { get; set; }
        /// <summary>
        /// 去程目的地城市名称
        /// </summary>
        public string QuArrCityName { get; set; }
        /// <summary>
        /// 收入金额
        /// </summary>
        public decimal ShouRuJinE { get; set; }
        /// <summary>
        /// 支出金额
        /// </summary>
        public decimal ZhiChuJinE { get; set; }
        /// <summary>
        /// 其它收入金额
        /// </summary>
        public decimal QiTaShouRuJinE { get; set; }
        /// <summary>
        /// 其它支出金额
        /// </summary>
        public decimal QiTaZhiChuJinE { get; set; }
        /// <summary>
        /// 毛利金额
        /// </summary>
        public decimal MaoLiJinE { get { return ShouRuJinE + QiTaShouRuJinE - ZhiChuJinE - QiTaZhiChuJinE; } }
        /// <summary>
        /// 毛利率
        /// </summary>
        public string MaoLiLv
        {
            get
            {
                decimal _maolilv = 0;
                if (ShouRuJinE + QiTaShouRuJinE == 0) _maolilv = 0;
                else _maolilv = MaoLiJinE / (ShouRuJinE + QiTaShouRuJinE);

                return (_maolilv * 100).ToString("F2") + "%";
            }
        }
        /// <summary>
        /// 控位状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai KongWeiZhuangTai { get; set; }
    }
    #endregion

    #region 财务管理-团队结算汇总表查询信息业务实体
    /// <summary>
    /// 财务管理-团队结算汇总表查询信息业务实体
    /// </summary>
    public class MTuanDuiJieSuanChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MTuanDuiJieSuanChaXunInfo() { }

        /// <summary>
        /// 出团起始时间
        /// </summary>
        public DateTime? SQuDate { get; set; }
        /// <summary>
        /// 出团截止时间
        /// </summary>
        public DateTime? EQuDate { get; set; }
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int? AreaId { get; set; }
        /// <summary>
        /// 去程交通
        /// </summary>
        public int? QuJiaoTongId { get; set; }
        /// <summary>
        /// 去程出发地省份
        /// </summary>
        public int? QuDepProvinceId { get; set; }
        /// <summary>
        /// 去程出发地城市 
        /// </summary>
        public int? QuDepCityId { get; set; }
        /// <summary>
        /// 去程目的地省份
        /// </summary>
        public int? QuArrProvinceId { get; set; }
        /// <summary>
        /// 去程目的地城市 
        /// </summary>
        public int? QuArrCityId { get; set; }
        /// <summary>
        /// 控位状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai? KongWeiZhuangTai { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 财务管理-催款单信息业务实体
    /// <summary>
    /// 财务管理-催款单信息业务实体
    /// </summary>
    public class MCuiKuanDanInfo
    {
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 预订人姓名(客户联系人姓名)(对方操作人姓名)
        /// </summary>
        public string KeHuLxrName { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingErShu { get; set; }
        /// <summary>
        /// 全陪人数
        /// </summary>
        public int QuanPeiShu { get; set; }
        /// <summary>
        /// 价格明细-录入
        /// </summary>
        public string JiaGeMingXi { get; set; }
        /// <summary>
        /// 价格明细-自动
        /// </summary>
        public string JiaGeMingXi1 { get; set; }
        /// <summary>
        /// 价格明细-显示
        /// </summary>
        public string JiaGeMingXi2
        {
            get
            {
                if (!string.IsNullOrEmpty(JiaGeMingXi)) return JiaGeMingXi;
                return JiaGeMingXi1;
            }
        }
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 已收金额
        /// </summary>
        public decimal YiShouJinE { get; set; }
        /// <summary>
        /// 未收金额
        /// </summary>
        public decimal WeiShouJinE { get {return JinE - YiShouJinE; } }
        /// <summary>
        /// 游客姓名
        /// </summary>
        public string YouKeName { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType YeWuLeiXing { get; set; }
    }
    #endregion

    #region 财务管理-催款单查询实体
    /// <summary>
    /// 财务管理-催款单查询实体
    /// </summary>
    public class MCuiKuanDanChaXunInfo
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户联系人编号（对方操作人编号）
        /// </summary>
        public int? KeHuLxrId { get; set; }
        /// <summary>
        /// 出团日期-起
        /// </summary>
        public DateTime? QuDate1 { get; set; }
        /// <summary>
        /// 出团日期-止
        /// </summary>
        public DateTime? QuDate2 { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
