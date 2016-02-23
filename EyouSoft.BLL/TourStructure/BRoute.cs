using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TourStructure
{
    /// <summary>
    /// Creater 王磊
    /// Data 2012-11-14
    /// </summary>
    public class BRoute : BLLBase
    {
        private readonly EyouSoft.IDAL.TourStructure.IRoute dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TourStructure.IRoute>();

        #region 线路产品


        /// <summary>
        /// 添加线路
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0：失败 1：成功</returns>
        public int AddRoute(EyouSoft.Model.TourStructure.MRoute model)
        {
            if (model.CompanyId == 0
                || string.IsNullOrEmpty(model.RouteName)
                || model.AreaId == 0
                || string.IsNullOrEmpty(model.AreaDesc)
                || model.Days == 0
                || model.OperatorId == 0)
            {
                return 0;
            }
            if (model.RoutePlanList == null)
            {
                return 0;
            }
            if (model.Days != model.RoutePlanList.Count)
            {
                return 0;
            }

            model.RouteId = Guid.NewGuid().ToString();
            int flg = dal.AddRoute(model);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="添加线路信息，编号："+model.RouteId,
                    EventTitle = "添加线路信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.线路产品_线路管理
                };
                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;
        }


        /// <summary>
        /// 删除线路产品
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns>0：失败 1：成功</returns>
        public int DeleteRouteById(string routeId)
        {
            if (string.IsNullOrEmpty(routeId)) return 0;

            int flg = dal.DeleteRouteById(routeId);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="删除线路信息，线路编号："+routeId,
                    EventTitle = "删除线路信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.线路产品_线路管理
                };
                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }

            return flg;
        }

        /// <summary>
        /// 修改线路
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0：失败 1：成功</returns>
        public int UpdateRoute(EyouSoft.Model.TourStructure.MRoute model)
        {
            if (string.IsNullOrEmpty(model.RouteId)
                || model.CompanyId == 0
                || string.IsNullOrEmpty(model.RouteName)
                || model.AreaId == 0
                || string.IsNullOrEmpty(model.AreaDesc)
                || model.Days == 0
                || model.OperatorId == 0)
            {
                return 0;
            }

            if (model.RoutePlanList == null)
            {
                return 0;
            }
            if (model.Days != model.RoutePlanList.Count)
            {
                return 0;
            }


            int flg = dal.UpdateRoute(model);

            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "修改线路信息，线路编号："+model.RouteId,
                    EventTitle = "修改线路信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.线路产品_线路管理
                };
                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }

            return flg;
        }

        /// <summary>
        /// 根据编号获取model
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MRoute GetRouteById(string routeId)
        {
            if (string.IsNullOrEmpty(routeId)) return null;
            return dal.GetRouteById(routeId);
        }

        /// <summary>
        /// 获取线路产品列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="model">线路查询实体</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MPageRoute> GetRouteList(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            Model.TourStructure.MSearchRoute model)
        {

            if (companyId == 0) return null;
            return dal.GetRouteList(companyId, pageSize, pageIndex, ref recordCount, model);
        }

        #endregion

        #region 政策中心

        /// <summary>
        /// 添加线路政策
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0:失败 1:成功</returns>
        public int AddRouteZhengCe(EyouSoft.Model.TourStructure.MRouteZhengCe model)
        {
            if (model.CompanyId == 0 || model.OperatorId == 0) return 0;

            model.Id = Guid.NewGuid().ToString();
            int flg = dal.AddRouteZhengCe(model);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "添加线路政策信息，编号："+model.Id,
                    EventTitle = "添加线路政策信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.线路产品_政策中心
                };
                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;

        }

        /// <summary>
        /// 删除线路政策
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>0:失败 1:成功</returns>
        public int DeleteRouteZhengCe(string id)
        {

            if (string.IsNullOrEmpty(id)) return 0;
            int flg = dal.DeleteRouteZhengCe(id);

            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "删除线路政策信息，编号："+id,
                    EventTitle = "删除线路政策信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.线路产品_政策中心
                };
                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }

            return flg;
        }

        /// <summary>
        /// 修改线路政策
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0:失败 1:成功</returns>
        public int UpdateRouteZhengCe(EyouSoft.Model.TourStructure.MRouteZhengCe model)
        {

            if (string.IsNullOrEmpty(model.Id) || model.CompanyId == 0 || model.OperatorId == 0) return 0;
            int flg = dal.UpdateRouteZhengCe(model);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="修改线路政策信息，编号："+model.Id,
                    EventTitle = "修改线路政策信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.线路产品_政策中心
                };
                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;

        }

        /// <summary>
        /// 根据ID获取线路政策
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MRouteZhengCe GetRouteZhengCeById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            return dal.GetRouteZhengCeById(id);
        }

        /// <summary>
        /// 分页获取线路政策
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MRouteZhengCe> GetRouteZhengCeList(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            EyouSoft.Model.TourStructure.MSeachRouteZhengCe search)
        {
            if (companyId == 0) return null;
            return dal.GetRouteZhengCeList(companyId, pageSize, pageIndex, ref recordCount, search);
        }

        #endregion
    }
}
