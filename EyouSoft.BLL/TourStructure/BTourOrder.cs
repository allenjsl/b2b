using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TourStructure
{
    using System.Web;

    public class BTourOrder:BLLBase
    {
        private readonly EyouSoft.IDAL.TourStructure.ITourOrder dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TourStructure.ITourOrder>();

        #region private members
        /// <summary>
        /// 根据团队编号获取订单集合
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MTourOrder> GetTourOrderList(string tourId)
        {
            if (string.IsNullOrEmpty(tourId)) return null;
            return dal.GetTourOrderList(tourId);
        }

        /// <summary>
        /// 获取有效游客名单人数
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        int GetYouXiaoYouKeRenShu(IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> items)
        {
            int jiShu = 0;
            if (items == null || items.Count == 0) return jiShu;

            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.TravellerName) 
                    //|| item.CardType == EyouSoft.Model.EnumType.TourStructure.CardType.未知 
                    || string.IsNullOrEmpty(item.CardNumber)) continue;

                jiShu++;
            }

            return jiShu;
        }

        /// <summary>
        /// 设置订单状态（取消、拒绝、恢复），返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="status">订单状态</param>
        /// <param name="yuanYin">原因</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="caoZuoLaiYuan">操作来源 0:系统 1:平台</param>
        /// <returns></returns>
        int SheZhiDingDanStatus(string dingDanId, EyouSoft.Model.EnumType.TourStructure.OrderStatus status, string yuanYin, int caoZuoRenId,int caoZuoLaiYuan)
        {
            if (string.IsNullOrEmpty(dingDanId) || caoZuoRenId<1) return 0;

            int dalRetCode = dal.SheZhiDingDanStatus(dingDanId, status, yuanYin, caoZuoRenId,caoZuoLaiYuan);
            return dalRetCode;
        }
        #endregion 

        #region public members
        /// <summary>
        /// (管理系统)添加订单，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTourOrder(EyouSoft.Model.TourStructure.MTourOrder model)
        {
            if (model.CompanyId == 0
                || string.IsNullOrEmpty(model.TourId)
                || !model.BusinessType.HasValue
                || !model.BusinessNature.HasValue
                || string.IsNullOrEmpty(model.BuyCompanyId)
                || model.BuyOperatorId == 0
                || model.Accounts < 0                
                || model.OperatorId == 0
                || !model.OrderStatus.HasValue)
            {
                return 0;
            }

            if (model.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游
                || model.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制
                || model.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行)
            {
                if (string.IsNullOrEmpty(model.RouteId))
                {
                    return 0;
                }
            }
            if (model.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票
                || model.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店)
            {
                //model.RouteId = string.Empty;
            }

            model.OrderId = Guid.NewGuid().ToString();

            if (model.TourOrderHotelPlanList != null && model.TourOrderHotelPlanList.Count > 0)
            {
                foreach (var item in model.TourOrderHotelPlanList)
                {
                    item.Id = Guid.NewGuid().ToString();
                }
            }

            if (model.TourOrderTravellerList != null && model.TourOrderTravellerList.Count > 0)
            {
                foreach (var item in model.TourOrderTravellerList)
                {
                    item.TravellerId = Guid.NewGuid().ToString();
                }
            }

            model.IssueTime = model.LatestTime = DateTime.Now;

            if (model.Adults + model.Childs + model.YingErRenShu + model.Bears > GetYouXiaoYouKeRenShu(model.TourOrderTravellerList))
            {
                model.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全;
            }

            int dalRetCode = dal.AddTourOrder(model);

            if (dalRetCode == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="添加订单信息，编号："+model.OrderId,
                    EventTitle = "添加订单信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return dalRetCode;
        }


        /// <summary>
        /// (管理系统)修改订单，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateTourOrder(EyouSoft.Model.TourStructure.MTourOrder model)
        {
            if (string.IsNullOrEmpty(model.OrderId)
                || model.CompanyId == 0
                || string.IsNullOrEmpty(model.TourId)
                || !model.BusinessType.HasValue
                || !model.BusinessNature.HasValue
                || string.IsNullOrEmpty(model.BuyCompanyId)
                || model.BuyOperatorId == 0
                || model.Accounts < 0
                || model.OperatorId == 0
                || !model.OrderStatus.HasValue)
            {
                return 0;
            }

            if (model.TourOrderHotelPlanList != null && model.TourOrderHotelPlanList.Count > 0)
            {
                foreach (var item in model.TourOrderHotelPlanList)
                {
                    if (string.IsNullOrEmpty(item.Id)) item.Id = Guid.NewGuid().ToString();
                }
            }

            if (model.TourOrderTravellerList != null && model.TourOrderTravellerList.Count > 0)
            {
                foreach (var item in model.TourOrderTravellerList)
                {
                    if (string.IsNullOrEmpty(item.TravellerId)) item.TravellerId = Guid.NewGuid().ToString();
                }
            }

            if (model.Adults + model.Childs + model.YingErRenShu + model.Bears > GetYouXiaoYouKeRenShu(model.TourOrderTravellerList))
            {
                model.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全;
            }

            int dalRetCode = 0;
            EyouSoft.Model.TourStructure.MBianGeng bModel = new EyouSoft.Model.TourStructure.MBianGeng();
            bModel.BianId = model.OrderId;
            bModel.BianType = EyouSoft.Model.EnumType.TourStructure.BianType.订单变更;
            bModel.OperatorId = model.OperatorId;
            bModel.Url = new EyouSoft.Toolkit.request(model.PageUri, 1024, 768, 1024, 768, model.CompanyId, HttpContext.Current.Request.Cookies).SavePageAsImg();
            model.IssueTime = model.LatestTime = DateTime.Now;

            dalRetCode = dal.UpdateTourOrder(model);

            if (dalRetCode == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="修改订单信息，编号："+model.OrderId,
                    EventTitle = "修改订单信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);

                new BBianGeng().InsertBianGeng(bModel);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 根据线路编号获取订单列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MRoute_TourOrder> GetTourOrderList(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            string routeId)
        {
            if (companyId == 0) return null;
            if (string.IsNullOrEmpty(routeId)) return null;
            return dal.GetTourOrderList(companyId, pageSize, pageIndex, ref recordCount, routeId);
        }

        /// <summary>
        /// 根据订单编号获取订单实体
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MTourOrder GetTourOrderById(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return null;
            return dal.GetTourOrderById(orderId);
        }

        /// <summary>
        /// 根据团号（控位编号）订单状态的枚举获取订单集合
        /// </summary>
        /// <param name="tourId">控位编号</param>
        /// <param name="OrderStatus">订单状态(没有值则返回所有)</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MTourOrder> GetTourOrderList(string tourId, EyouSoft.Model.EnumType.TourStructure.OrderStatus? OrderStatus)
        {
            if (string.IsNullOrEmpty(tourId)) return null;

            var items = this.GetTourOrderList(tourId);

            if (items == null || items.Count == 0) return null;

            if (OrderStatus.HasValue)
            {
                return items.Where(c => c.OrderStatus == OrderStatus.Value).ToList();
            }

            return items;
        }


        /// <summary>
        /// 根据团号（控位编号）获取地接安排的订单集合
        /// </summary>
        /// <param name="tourId">控位编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MTourOrder> GetTourPlanOrderList(string tourId)
        {
            if (string.IsNullOrEmpty(tourId)) return null;

            var items = this.GetTourOrderList(tourId);

            if (items == null || items.Count == 0) return null;

            return items.Where(c => c.OrderStatus == EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交
                && (c.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游 || c.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制 || c.BusinessType == EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行)).ToList();
        }

        /// <summary>
        /// 取消订单，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="yuanYin">原因</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="caoZuoLaiYuan">操作来源 0:系统 1:平台</param>
        /// <returns></returns>
        public int QuXiaoDingDan(string dingDanId, string yuanYin, int caoZuoRenId,int caoZuoLaiYuan)
        {
            int dalRetCode = SheZhiDingDanStatus(dingDanId, EyouSoft.Model.EnumType.TourStructure.OrderStatus.已取消, yuanYin, caoZuoRenId, caoZuoLaiYuan);

            return dalRetCode;
        }

        /// <summary>
        /// 拒绝订单，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="yuanYin">原因</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="caoZuoLaiYuan">操作来源 0:系统 1:平台</param>
        /// <returns></returns>
        public int JuJueDingDan(string dingDanId, string yuanYin, int caoZuoRenId,int caoZuoLaiYuan)
        {
            int dalRetCode = SheZhiDingDanStatus(dingDanId, EyouSoft.Model.EnumType.TourStructure.OrderStatus.已拒绝, yuanYin, caoZuoRenId,caoZuoLaiYuan);

            return dalRetCode;
        }

        /// <summary>
        /// 恢复订单，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="caoZuoLaiYuan">操作来源 0:系统 1:平台</param>
        /// <returns></returns>
        public int HuiFuDingDan(string dingDanId, int caoZuoRenId, int caoZuoLaiYuan)
        {
            var info = GetTourOrderById(dingDanId);

            var status=EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认;
            if (info != null 
                && info.Adults + info.Childs + info.YingErRenShu + info.Bears > GetYouXiaoYouKeRenShu(info.TourOrderTravellerList))
                status = EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全;

            int dalRetCode = SheZhiDingDanStatus(dingDanId, status, string.Empty, caoZuoRenId,caoZuoLaiYuan);

            return dalRetCode;
        }

        /// <summary>
        /// （平台）线路订单新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int PT_DingDan_C(EyouSoft.Model.TourStructure.MTourOrder info)
        {
            if (info == null
                || info.CompanyId < 1
                || info.OperatorId < 1
                || string.IsNullOrEmpty(info.XianLuId)
                || string.IsNullOrEmpty(info.TourId)
                || string.IsNullOrEmpty(info.RouteId)
                || string.IsNullOrEmpty(info.BuyCompanyId)
                || info.BuyOperatorId < 1) return 0;

            info.OrderId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            info.XiaDanLeiXing = EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.平台下单;

            if (info.TourOrderTravellerList != null && info.TourOrderTravellerList.Count > 0)
            {
                foreach (var item in info.TourOrderTravellerList)
                {
                    item.TravellerId = Guid.NewGuid().ToString();
                }
            }

            if (info.Adults + info.Childs + info.YingErRenShu + info.Bears > GetYouXiaoYouKeRenShu(info.TourOrderTravellerList))
            {
                info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全;
            }

            int dalRetCode = dal.PT_DingDan_CU(info);

            return dalRetCode;
        }

        /// <summary>
        /// （平台）线路订单修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int PT_DingDan_U(EyouSoft.Model.TourStructure.MTourOrder info)
        {
            if (info == null
                || info.CompanyId < 1
                || info.OperatorId < 1
                || string.IsNullOrEmpty(info.XianLuId)
                || string.IsNullOrEmpty(info.TourId)
                || string.IsNullOrEmpty(info.RouteId) 
                || string.IsNullOrEmpty(info.BuyCompanyId)
                || info.BuyOperatorId < 1
                ||string.IsNullOrEmpty(info.OrderId)) return 0;

            info.IssueTime = DateTime.Now;

            if (info.TourOrderTravellerList != null && info.TourOrderTravellerList.Count > 0)
            {
                foreach (var item in info.TourOrderTravellerList)
                {
                    if (string.IsNullOrEmpty(item.TravellerId)) item.TravellerId = Guid.NewGuid().ToString();
                }
            }

            if (info.Adults + info.Childs + info.YingErRenShu + info.Bears > GetYouXiaoYouKeRenShu(info.TourOrderTravellerList))
            {
                info.OrderStatus = EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全;
            }

            int dalRetCode = dal.PT_DingDan_CU(info);

            return dalRetCode;
        }

        /// <summary>
        /// get youkes
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> GetYouKes(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return null;

            return dal.GetYouKes(dingDanId);
        }
        #endregion
    }
}
