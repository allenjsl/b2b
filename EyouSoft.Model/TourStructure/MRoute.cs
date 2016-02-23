using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.TourStructure
{
    /// <summary>
    /// 线路产品基类
    /// </summary>
    public class MBaseRoute
    {
        /// <summary>
        /// 线路产品编号
        /// </summary>
        public string RouteId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 线路页眉
        /// </summary>
        public string RouteHeader { get; set; }
        /// <summary>
        /// 线路描述
        /// </summary>
        public string AreaDesc { get; set; }
        /// <summary>
        /// 天数
        /// </summary>
        public int Days { get; set; }
        /// <summary>
        /// 线路图片
        /// </summary>
        public string RoutePic { get; set; }
        /// <summary>
        /// 交通标准
        /// </summary>
        public string TrafficStandard { get; set; }
        /// <summary>
        /// 住宿标注
        /// </summary>
        public string StayStandard { get; set; }
        /// <summary>
        /// 餐饮标准
        /// </summary>
        public string DiningStandard { get; set; }
        /// <summary>
        /// 景点标准
        /// </summary>
        public string AttractionsStandard { get; set; }
        /// <summary>
        /// 导游标准
        /// </summary>
        public string GuideStandard { get; set; }
        /// <summary>
        /// 购物标准
        /// </summary>
        public string ShoppingStandard { get; set; }
        /// <summary>
        /// 儿童标准
        /// </summary>
        public string ChildStandard { get; set; }
        /// <summary>
        /// 保险说明
        /// </summary>
        public string InsuranceDesc { get; set; }
        /// <summary>
        /// 自费推荐
        /// </summary>
        public string ExpenseRecommend { get; set; }
        /// <summary>
        /// 温馨提示
        /// </summary>
        public string Tips { get; set; }
        /// <summary>
        /// 内部信息
        /// </summary>
        public string InsideInfo { get; set; }
        /// <summary>
        /// 报名须知
        /// </summary>
        public string RegistrationNotes { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 政策状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus Status { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing LeiXing { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? GuoQiShiJian { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int ZxlbId { get; set; }
        /// <summary>
        /// 线路标准
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun BiaoZhun { get; set; }
        /// <summary>
        /// 集合地点
        /// </summary>
        public string JiHeDiDian { get; set; }
        /// <summary>
        /// 集合时间
        /// </summary>
        public string JiHeShiJian { get; set; }
        /// <summary>
        /// 送团信息
        /// </summary>
        public string SongTuanXinXi { get; set; }
        /// <summary>
        /// 目的地接团方式
        /// </summary>
        public string MuDiDiJieTuanFangShi { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 线路封面
        /// </summary>
        public string FengMian { get; set; }
        /// <summary>
        /// 线路附件集合
        /// </summary>
        public IList<EyouSoft.Model.PtStructure.MFuJianInfo> FuJians { get; set; }
    }


    /// <summary>
    /// 线路行程安排
    /// </summary>
    public class MRoutePlan
    {
        /// <summary>
        /// 线路编号
        /// </summary>
        public string RouteId { get; set; }

        /// <summary>
        /// 第几天
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// 行程内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 行程附件
        /// </summary>
        public string FilePath { get; set; }

    }

    /// <summary>
    /// 线路政策 
    /// </summary>
    public class MRouteZhengCe
    {
        /// <summary>
        /// 政策编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 政策标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 政策附件
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 政策状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus Status { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }


    /// <summary>
    /// 线路产品
    /// </summary>
    public class MRoute : MBaseRoute
    {

        /// <summary>
        /// 线路行程安排
        /// </summary>
        public IList<MRoutePlan> RoutePlanList { get; set; }

    }


    /// <summary>
    /// 政策中心的搜索实体
    /// </summary>
    public class MSeachRouteZhengCe
    {
        /// <summary>
        /// 政策标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 发布开始时间
        /// </summary>
        public DateTime? BeginDate { get; set; }
        /// <summary>
        /// 发布结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 政策状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus? Status { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }


    /// <summary>
    /// 分页列表显示的实体
    /// </summary>
    public class MPageRoute
    {
        /// <summary>
        /// 线路编号
        /// </summary>
        public string RouteId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 线路区域
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 行程天数
        /// </summary>
        public int Days { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime IssueTime { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 收客数
        /// </summary>
        public int TotalAccounts { get; set; }
        /// <summary>
        /// 政策状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus? Status { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing LeiXing { get; set; }
        /// <summary>
        /// 线路标准
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun BiaoZhun { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string ZhanDianName { get; set; }
        /// <summary>
        /// 专线类别名称
        /// </summary>
        public string ZxlbName { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }

    /// <summary>
    /// 线路查询实体
    /// </summary>
    public class MSearchRoute
    {
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 线路发布时间开始
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 线路发布时间结束
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 线路政策状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus? ZhengCeStatus { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing? LeiXing { get; set; }
        /// <summary>
        /// 线路标准
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun? BiaoZhun { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }


}
