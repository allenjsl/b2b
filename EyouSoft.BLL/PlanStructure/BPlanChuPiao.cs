using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PlanStructure
{
    using System.Web;

    using EyouSoft.Toolkit;

    public class BPlanChuPiao
    {
        private readonly EyouSoft.IDAL.PlanStructure.IPlanChuPiao dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PlanStructure.IPlanChuPiao>();

        /// <summary>
        /// 添加押金登记
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:押金金额不能小于已登记的付款金额
        ///	-2:退回金额不能小于已登记的收款金额
        ///	-3:添加成功
        ///	-4:添加失败			
        /// </returns>
        public int YajinDengji(EyouSoft.Model.PlanStructure.MYaJinDengJi model)
        {
            if (string.IsNullOrEmpty(model.DaiLiId)) { return -4; }

            int flg = dal.YajinDengji(model);
            if (flg == -3)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务 + "添加押金。",
                    EventTitle = "添加押金",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;
        }

        /// <summary>
        /// 押金登记的列表（代理商信息）
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MYaJin> GetYaJinList(string kongWeiId)
        {
            return dal.GetYaJinList(kongWeiId);
        }


        /// <summary>
        /// 添加安排出票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:出票数量大于剩余数量
        /// -2:当前操作存在不能正常出票游客	
        /// -3:添加成功
        /// -4:添加失败	
        /// </returns>
        public int AddPlanChuPiao(EyouSoft.Model.PlanStructure.MPlanChuPiao model)
        {
            if (model.CompanyId == 0 || string.IsNullOrEmpty(model.KongWeiId) || string.IsNullOrEmpty(model.DaiLiId) || string.IsNullOrEmpty(model.GysId))
            {
                return -4;
            }
            if (model.TravellerList == null)
            {
                return -4;
            }
            if (model.TravellerList.Count == 0)
            {
                return -4;
            }
            if (model.ShuLiang != model.TravellerList.Count)
            {
                return -4;
            }

            model.PlanId = Guid.NewGuid().ToString();
            int flg = dal.AddPlanChuPiao(model);
            if (flg == -3)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务 + "添加出票。",
                    EventTitle = "添加出票",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;
        }


        /// <summary>
        /// 修改出票安排
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:出票数量大于剩余数量
        /// -2:当前操作存在不能正常出票游客
        /// -3:修改成功
        /// -4:修改失败	
        /// -81:存在付款登记的出票安排不允许修改代理商信息
        /// </returns>
        public int UpdatePlanChuPiao(EyouSoft.Model.PlanStructure.MPlanChuPiao model)
        {
            if (model == null
                || string.IsNullOrEmpty(model.PlanId)
                || model.CompanyId == 0
                || string.IsNullOrEmpty(model.KongWeiId)
                || string.IsNullOrEmpty(model.DaiLiId)
                || string.IsNullOrEmpty(model.GysId)
                || model.TravellerList == null
                || model.TravellerList.Count == 0
                || model.ShuLiang != model.TravellerList.Count)
            {
                return -4;
            }

            var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingFuJinE(model.PlanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务安排付款);
            if (model.JieSuanAmount < jinE[1] + jinE[2] + jinE[3]) return -80;


            int flg = 0;
            EyouSoft.Model.TourStructure.MBianGeng bModel = new EyouSoft.Model.TourStructure.MBianGeng();
            bModel.BianId = model.PlanId;
            bModel.BianType = EyouSoft.Model.EnumType.TourStructure.BianType.票务安排变更;
            bModel.OperatorId = model.OperatorId;
            bModel.Url = new EyouSoft.Toolkit.request(model.PageUri, 1024, 768, 1024, 768, model.CompanyId, HttpContext.Current.Request.Cookies).SavePageAsImg();

            flg = dal.UpdatePlanChuPiao(model);
            if (flg == -3)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务 + "修改出票安排。",
                    EventTitle = "修改出票安排",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);

                new EyouSoft.BLL.TourStructure.BBianGeng().InsertBianGeng(bModel);
            }


            return flg;

        }


        /// <summary>
        /// 删除出票安排
        /// </summary>
        /// <param name="planId"></param>
        /// <returns>
        /// -1:已存在付款登记的出票安排，不可删除。
        /// -2:删除成功
        /// -3:删除失败		
        /// -4：存在退票安排，不可删除		
        /// </returns>
        public int DeletePlanChuPiao(string planId)
        {
            if (string.IsNullOrEmpty(planId)) return -3;

            var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingFuJinE(planId, EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务安排付款);
            if (jinE[1] + jinE[2] + jinE[3] > 0) return -80;

            int flg = dal.DeletePlanChuPiao(planId);
            if (flg == -2)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务 + "删除出票安排。",
                    EventTitle = "删除出票安排",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;
        }

        /// <summary>
        /// 获取出票安排的信息
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public EyouSoft.Model.PlanStructure.MPlanChuPiao GetPlanChuPiaoById(string planId)
        {
            if (string.IsNullOrEmpty(planId)) return null;
            return dal.GetPlanChuPiaoById(planId);
        }

        /// <summary>
        /// 获取已安排出票列表
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MPlan_ChuPiao> GetPlanChuPiaoList(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;
            return dal.GetPlanChuPiaoList(kongWeiId);
        }
    }
}
