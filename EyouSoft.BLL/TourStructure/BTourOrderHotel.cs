using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TourStructure
{
    using System.Web;

    public class BTourOrderHotel
    {
        private readonly EyouSoft.IDAL.TourStructure.ITourOrderHotel dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TourStructure.ITourOrderHotel>();

        #region ITourOrderHotel 成员
        /// <summary>
        /// (管理系统)添加代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTourOrderHotel(EyouSoft.Model.TourStructure.MTourOrderHotel model)
        {
            if (model.CompanyId == 0
                || !model.QuDate.HasValue
                || string.IsNullOrEmpty(model.BuyCompanyId)
                || model.BuyOperatorId == 0
                || string.IsNullOrEmpty(model.PriceDetials)
                || model.Adults + model.Childs == 0)
            {
                return 0;
            }

            if (model.TourOrderHotelPlanList == null || model.TourOrderHotelPlanList.Count==0)
            {
                return 0;
            }

            model.KongWeiId = Guid.NewGuid().ToString();
            model.OrderId = Guid.NewGuid().ToString();

            foreach (var item in model.TourOrderHotelPlanList)
            {
                item.Id = Guid.NewGuid().ToString();
            }

            if (model.TourOrderTravellerList != null && model.TourOrderTravellerList.Count > 0)
            {
                foreach (var item in model.TourOrderTravellerList)
                {
                    item.TravellerId = Guid.NewGuid().ToString();
                }
            }

            model.LatestTime = model.IssueTime = DateTime.Now;

            int flg = dal.AddTourOrderHotel(model);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="添加代订酒店信息，编号："+model.KongWeiId,
                    EventTitle = "添加代订酒店信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_代订酒店
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;
        }

        /// <summary>
        /// 删除代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public int DeleteTourOrderHotel(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return 0;
            int flg = dal.DeleteTourOrderHotel(kongWeiId);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="删除代订酒店信息，编号："+kongWeiId,
                    EventTitle = "删除代订酒店信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_代订酒店
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;
        }

        /// <summary>
        /// (管理系统)修改代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateTourOrderHotel(EyouSoft.Model.TourStructure.MTourOrderHotel model)
        {
            if (string.IsNullOrEmpty(model.KongWeiId)
                || string.IsNullOrEmpty(model.OrderId)
                || !model.QuDate.HasValue
                || string.IsNullOrEmpty(model.BuyCompanyId)
                || model.BuyOperatorId == 0
                || string.IsNullOrEmpty(model.PriceDetials)
                || model.Adults + model.Childs == 0)
            {
                return 0;
            }

            if (model.TourOrderHotelPlanList == null || model.TourOrderHotelPlanList.Count == 0)
            {
                return 0;
            }

            foreach (var item in model.TourOrderHotelPlanList)
            {
                if (string.IsNullOrEmpty(item.Id)) item.Id = Guid.NewGuid().ToString();
            }

            if (model.TourOrderTravellerList != null && model.TourOrderTravellerList.Count > 0)
            {
                foreach (var item in model.TourOrderTravellerList)
                {
                    if(string.IsNullOrEmpty(item.TravellerId))item.TravellerId = Guid.NewGuid().ToString();
                }
            }

            int flg = -2;
            EyouSoft.Model.TourStructure.MBianGeng bModel = new EyouSoft.Model.TourStructure.MBianGeng();
            bModel.BianId = model.OrderId;
            bModel.BianType = EyouSoft.Model.EnumType.TourStructure.BianType.代订酒店;
            bModel.OperatorId = model.OperatorId;
            bModel.Url = new EyouSoft.Toolkit.request(model.PageUri, 1024, 768, 1024, 768, model.CompanyId, HttpContext.Current.Request.Cookies).SavePageAsImg();
            model.LatestTime = model.IssueTime = DateTime.Now;
            flg = dal.UpdateTourOrderHotel(model);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "修改代订酒店信息，编号："+model.KongWeiId,
                    EventTitle = "修改代订酒店信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_代订酒店
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);

                new BBianGeng().InsertBianGeng(bModel);
            }

            return flg;
        }

        /// <summary>
        /// 获取代订酒店的实体
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MTourOrderHotel GetTourOrderHotel(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;
            return dal.GetTourOrderHotel(kongWeiId);
        }

        /// <summary>
        /// 代订酒店分页显示信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MTour_OrderHotel> GetTourOrderHotel(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            EyouSoft.Model.TourStructure.MSearchTourOrderHotel search)
        {
            if (companyId == 0) return null;
            return dal.GetTourOrderHotel(companyId, pageSize, pageIndex, ref recordCount, search);
        }

        #endregion
    }
}
