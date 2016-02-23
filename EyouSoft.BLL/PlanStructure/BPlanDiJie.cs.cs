using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PlanStructure
{
    using System.Web;

    using EyouSoft.Toolkit;

    public class BPlanDiJie:BLLBase
    {
        private readonly EyouSoft.IDAL.PlanStructure.IPlanDiJie dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PlanStructure.IPlanDiJie>();


        /// <summary>
        /// 添加地接安排
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:已经安排地接的订单 不能重新安排
        /// -2:当订单性质为团队时，一次只能选择一个订单进行地接安排
        /// -3:当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
        /// 1:安排成功 0:安排失败</returns>
        public int AddPlanDiJie(EyouSoft.Model.PlanStructure.MPlanDiJie model)
        {
            if (model.CompanyId == 0
                || string.IsNullOrEmpty(model.KongWeiId)
                || string.IsNullOrEmpty(model.GysId)
                || string.IsNullOrEmpty(model.RouteId)
                || model.OperatorId == 0)
            {
                return 0;
            }
            if (model.OrderId == null)
            {
                return 0;
            }
            if (model.OrderId.Length < 1)
            {
                return 0;
            }
            model.PlanId = Guid.NewGuid().ToString();
            int flg = dal.AddPlanDiJie(model);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "安排地接。安排编号：" + model.PlanId + "。",
                    EventTitle = "安排地接",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;

        }

        /// <summary>
        /// 删除地接安排
        /// </summary>
        /// <param name="planId"></param>
        /// <returns>1:删除成功 0:修改失败,-1：已经登记过付款的安排项不允许删除</returns>
        public int DeletePlanDiJie(string planId)
        {
            if (string.IsNullOrEmpty(planId)) return 0;
            int flg = dal.DeletePlanDiJie(planId);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="删除安排地接，地接安排编号："+planId+"。",
                    EventTitle = "删除安排地接",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;

        }


        /// <summary>
        /// 修改地接安排
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:已经安排地接的订单 不能重新安排
        /// -2:当订单性质为团队时，一次只能选择一个订单进行地接安排
        /// -3:当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
        /// 1:修改成功 0:修改失败
        /// -4:变更信息添加失败
        /// </returns>
        public int UpdatePlanDiJie(EyouSoft.Model.PlanStructure.MPlanDiJie model)
        {
            if (string.IsNullOrEmpty(model.PlanId)
                || model.CompanyId == 0
                || string.IsNullOrEmpty(model.KongWeiId)
                || string.IsNullOrEmpty(model.GysId)
                || string.IsNullOrEmpty(model.RouteId)
                || model.OperatorId == 0)
            {
                return 0;
            }

            if (model.OrderId == null)
            {
                return 0;
            }
            if (model.OrderId.Length < 1)
            {
                return 0;
            }

            int flg = -4;
            EyouSoft.Model.TourStructure.MBianGeng bModel = new EyouSoft.Model.TourStructure.MBianGeng();
            bModel.BianId = model.PlanId;
            bModel.BianType = EyouSoft.Model.EnumType.TourStructure.BianType.地接安排变更;
            bModel.OperatorId = model.OperatorId;
            bModel.Url = new EyouSoft.Toolkit.request(Utils.GetRequestUrlReferrer(), 1024, 768, 1024, 768, model.CompanyId, HttpContext.Current.Request.Cookies).SavePageAsImg();
            flg = dal.UpdatePlanDiJie(model);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "修改地接安排，地接安排编号：" + model.PlanId + "。",
                    EventTitle = "修改地接安排",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);

                new EyouSoft.BLL.TourStructure.BBianGeng().InsertBianGeng(bModel);
            }

            return flg;
        }

        /// <summary>
        /// 获取地接安排信息
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public EyouSoft.Model.PlanStructure.MPlanDiJie GetPlanDiJieById(string planId)
        {
            if (string.IsNullOrEmpty(planId)) return null;
            return dal.GetPlanDiJieById(planId);
        }

        /// <summary>
        /// 已安排地接列表
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MPlan_DiJie> GetPlanDiJieList(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;
            return dal.GetPlanDiJieList(kongWeiId);

        }


        /// <summary>
        /// 获取已安排地接的订单信息
        /// </summary>
        /// <param name="PlanId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MDiJieOrder> GetDiJieOrder(string PlanId)
        {
            return dal.GetDiJieOrder(PlanId);
        }

        /// <summary>
        /// 设置地接安排导游，返回1成功，其它失败
        /// </summary>
        /// <param name="anPaiId">地接安排编号</param>
        /// <param name="daoYouId">导游编号</param>
        /// <returns></returns>
        public int SetDaoYou(string anPaiId, int daoYouId)
        {
            if (string.IsNullOrEmpty(anPaiId) || daoYouId < 0) return 0;

            int dalRetCode=dal.SetDaoYou(anPaiId, daoYouId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置地接安排导游";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;
                log.EventMessage = "设置地接安排导游，地接安排编号：" + anPaiId + "，导游编号：" + daoYouId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 地接平台-获取地接安排信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiInfo> GYS_GetDiJieAnPais(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiChaXunInfo chaXun,out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0M, 0M, 0M, 0M, 0 };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GYS_GetDiJieAnPais(companyId, pageSize, pageIndex, ref recordCount, chaXun,out heJi);

            return items;
        }

        /// <summary>
        /// 地接平台-地接社设置计划信息
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int GYS_DiJieJiHua_U(EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiJiHuaInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.AnPaiId) || info.CaoZuoRenId < 1) return 0;

            info.CaoZuoTime = DateTime.Now;

            int dalRetCode = dal.GYS_DiJieJiHua_U(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "地接社设置计划信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.None;
                log.EventMessage = "地接社设置计划信息，地接安排编号：" + info.AnPaiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add1(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 地接平台-地接社确认计划
        /// </summary>
        /// <param name="anPaiId">安排编号</param>
        /// <param name="gysId">供应商主体编号</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <returns></returns>
        public int GYS_DiJieQueRen(string anPaiId, string gysId, int caoZuoRenId)
        {
            if (string.IsNullOrEmpty(anPaiId) || string.IsNullOrEmpty(gysId) || caoZuoRenId < 1) return 0;
            int dalRetCode = dal.GYS_DiJieSheZhiQueRenStatus(anPaiId, EyouSoft.Model.EnumType.TourStructure.QueRenStatus.已确认, gysId, caoZuoRenId, DateTime.Now);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "地接社确认计划信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.None;
                log.EventMessage = "地接社确认计划信息，地接安排编号：" + anPaiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add1(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 设置地接安排导游，返回1成功，其它失败
        /// </summary>
        /// <param name="anPaiId">地接安排编号</param>
        /// <param name="daoYouName">导游</param>
        /// <returns></returns>
        public int SetDaoYou(string anPaiId, string daoYouName)
        {
            if (string.IsNullOrEmpty(anPaiId) || string.IsNullOrEmpty(daoYouName)) return 0;

            int dalRetCode = dal.SetDaoYou(anPaiId, daoYouName);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置地接安排导游";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;
                log.EventMessage = "设置地接安排导游，地接安排编号：" + anPaiId + "，导游：" + daoYouName + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
    }
}
