using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PlanStructure
{
    public class MPlanDiJie
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
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string RouteId { get; set; }

        /// <summary>
        /// 线路名称（OUTPUT）
        /// </summary>
        public string RouteName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrTelephone { get; set; }
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
        public int QuPeiShu { get; set; }
        /// <summary>
        /// 全陪姓名
        /// </summary>
        public string QuPeiName { get; set; }
        /// <summary>
        /// 导游编号
        /// </summary>
        public int DaoYouId { get; set; }
        /// <summary>
        /// 导游名称
        /// </summary>
        public string DaoYouName { get; set; }
        /// <summary>
        /// 用餐
        /// </summary>
        public string YongCan { get; set; }
        /// <summary>
        /// 结算明细
        /// </summary>
        public string JieSuanMX { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JieSuanAmount { get; set; }
        /// <summary>
        /// 接团方式
        /// </summary>
        public string JieTuanFangShi { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 安排备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 此次安排的订单号
        /// </summary>
        public string[] OrderId { get; set; }
        /// <summary>
        /// 游客信息
        /// </summary>
        public string YouKeXinXi { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }

        /// <summary>
        /// 页面地址
        /// </summary>
        public string PageUri { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingErShu { get; set; }

        
        /// <summary>
        /// 地接社线路名称
        /// </summary>
        public string DiJieRouteName { get; set; }
        /// <summary>
        /// 地接社团号
        /// </summary>
        public string DiJieTuanHao { get; set; }
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
        /// <summary>
        /// 专线商名称（OUTPUT）
        /// </summary>
        public string ZxsName { get; set; }
        /// <summary>
        /// 内部备注
        /// </summary>
        public string NeiBuBeiZhu { get; set; }
    }

    /// <summary>
    /// 已安排地接列表
    /// </summary>
    public class MPlan_DiJie
    {
        /// <summary>
        /// 安排编号
        /// </summary>
        public string PlanId { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 地接社名称
        /// </summary>
        public string GysName { get; set; }
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
        public int QuPeiShu { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 导游姓名
        /// </summary>
        public string DaoYouName { get; set; }
        /// <summary>
        /// 接团方式
        /// </summary>
        public string JieTuanFangShi { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JieSuanAmount { get; set; }
        /// <summary>
        /// 已支付金额
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 未支付金额
        /// </summary>
        public decimal WeiZhiFuJinE { get; set; }
        /// <summary>
        /// 出团时间
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 婴儿数
        /// </summary>
        public int YingErShu { get; set; }
        /// <summary>
        /// 安排地接时间
        /// </summary>
        public DateTime IssueTime { get; set; }

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


    /// <summary>
    /// 已安排地接订单
    /// </summary>
    public class MDiJieOrder
    {
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public EyouSoft.Model.EnumType.TourStructure.BusinessNature BusinessNature { get; set; }
        public string RouteName { get; set; }
        public string BuyCompanyName { get; set; }
        public int Adults { get; set; }
        public int Childs { get; set; }
        public int Bears { get; set; }
        public int Accounts { get; set; }
        public string PriceDetials { get; set; }
        public decimal SumPrice { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingErShu { get; set; }
    }

    #region 地接平台-地接安排信息业务实体
    /// <summary>
    /// 地接平台-地接安排信息业务实体
    /// </summary>
    public class MGYS_DiJieAnPaiInfo
    {
        /// <summary>
        /// 地接安排编号
        /// </summary>
        public string AnPaiId { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 控位去程时期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 专线商团号
        /// </summary>
        public string ZxsTuanHao { get; set; }
        /// <summary>
        /// 专线商线路名称
        /// </summary>
        public string ZxsRouteName { get; set; }
        /// <summary>
        /// 地接团号
        /// </summary>
        public string DiJieTuanHao { get; set; }
        string _DiJieRouteName = string.Empty;
        /// <summary>
        /// 地接线路名称
        /// </summary>
        public string DiJieRouteName
        {
            get
            {
                if (string.IsNullOrEmpty(_DiJieRouteName)) return ZxsRouteName;

                return _DiJieRouteName;
            }
            set { _DiJieRouteName = value; }
        }
        /// <summary>
        /// 成人数
        /// </summary>
        public int RenShuCR { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int RenShuET { get; set; }
        /// <summary>
        /// 婴儿数
        /// </summary>
        public int RenShuYE { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int RenShuQP { get; set; }
        /// <summary>
        /// 结算明细
        /// </summary>
        public string JieSuanMingXi { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 已收金额
        /// </summary>
        public decimal YiShouJinE { get; set; }
        /// <summary>
        /// 未收金额
        /// </summary>
        public decimal WeiShouJinE { get { return JinE - YiShouJinE; } }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }
        /// <summary>
        /// 专线商操作人编号
        /// </summary>
        public int ZxsCaoZuoRenId { get; set; }
        /// <summary>
        /// 专线商操作人姓名
        /// </summary>
        public string ZxsCaoZuoRenName { get; set; }
        /// <summary>
        /// 专线商操作时间
        /// </summary>
        public DateTime ZxsCaoZuoTime{get;set;}
        /// <summary>
        /// 地接社确认状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.QueRenStatus DiJieQueRenStatus { get; set; }
        /// <summary>
        /// 地接社确认人编号
        /// </summary>
        public int DiJieQueRenRenId { get; set; }
        /// <summary>
        /// 地接社确认人姓名
        /// </summary>
        public string DiJieQueRenRenName { get; set; }
        /// <summary>
        /// 地接社确认时间
        /// </summary>
        public DateTime? DiJieQueRenTime { get; set; }
    }
    #endregion

    #region 地接平台-地接安排信息查询业务实体
    /// <summary>
    /// 地接平台-地接安排信息查询业务实体
    /// </summary>
    public class MGYS_DiJieAnPaiChaXunInfo
    {
        /// <summary>
        /// 控位去程时期-起
        /// </summary>
        public DateTime? QuDate1 { get; set; }
        /// <summary>
        /// 控位去程时期-止
        /// </summary>
        public DateTime? QuDate2 { get; set; }
        /// <summary>
        /// 地接线路名称
        /// </summary>
        public string DiJieRouteName { get; set; }
        /// <summary>
        /// 专线商线路名称
        /// </summary>
        public string ZxsRouteName { get; set; }
        /// <summary>
        /// 地接团号
        /// </summary>
        public string DiJieTuanHao { get; set; }
        /// <summary>
        /// 专线商团号
        /// </summary>
        public string ZxsTuanHao { get; set; }
        /// <summary>
        /// 结清状态
        /// </summary>
        public EyouSoft.Model.EnumType.FinStructure.JieQingStatus? JieQingStatus { get; set; }
        /// <summary>
        /// 供应商主体编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 排序 [0:操作时间DESC] [1:操作时间ASC] [2:出团日期DESC] [3:出团日期ASC]
        /// </summary>
        public int PaiXuLeiXing { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }

        /// <summary>
        /// 确认状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.QueRenStatus? QueRenStatus { get; set; }
    }
    #endregion

    #region 地接平台-地接安排计划信息业务实体
    /// <summary>
    /// 地接平台-地接安排计划信息业务实体
    /// </summary>
    public class MGYS_DiJieAnPaiJiHuaInfo
    {
        /// <summary>
        /// 地接安排编号
        /// </summary>
        public string AnPaiId { get; set; }
        /// <summary>
        /// 地接线路名称
        /// </summary>
        public string DiJieRouteName { get; set; }
        /// <summary>
        /// 地接社团号
        /// </summary>
        public string DiJieTuanHao { get; set; }
        /// <summary>
        /// 导游姓名
        /// </summary>
        public string DaoYouName { get; set; }

        /// <summary>
        /// 供应商主体编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int CaoZuoRenId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime CaoZuoTime { get; set; }
    }
    #endregion
}
