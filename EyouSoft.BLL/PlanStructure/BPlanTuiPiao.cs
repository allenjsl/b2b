using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PlanStructure
{
    using System.Web;

    public class BPlanTuiPiao
    {
        private readonly EyouSoft.IDAL.PlanStructure.IPlanTuiPiao dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PlanStructure.IPlanTuiPiao>();

        /// <summary>
        /// 添加退票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:存在不能正常退票的游客
        /// -2:添加成功
        /// -3:添加失败			
        /// </returns>
        public int AddPlanTuiPiao(EyouSoft.Model.PlanStructure.MPlanTuiPiao model)
        {
            if (model.TravellerList == null)
            {
                return -3;
            }

            if (model.TravellerList.Count != model.ShuLiang)
            {
                return -3;
            }

            model.TuiId = Guid.NewGuid().ToString();
            int flg = dal.AddPlanTuiPiao(model);
            if (flg == -2)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                 {
                     EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                     EventMessage =
                         DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                         + Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务 + "添加退票。",
                     EventTitle = "添加退票",
                     ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                 };

            }
            return flg;
        }

        /// <summary>
        /// 修改退票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:存在不能正常退票的游客
        /// -2:添加成功
        /// -3:添加失败	
        /// </returns>
        public int UpdatePlanTuiPiao(EyouSoft.Model.PlanStructure.MPlanTuiPiao model)
        {
            if (model.TravellerList == null)
            {
                return -3;
            }

            if (model.TravellerList.Count != model.ShuLiang)
            {
                return -3;
            }

            var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingShouJinE(model.PlanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务退款);
            if (model.TuiAmount < jinE[1] + jinE[2] ) return -80;

            
            int flg = 0;
            EyouSoft.Model.TourStructure.MBianGeng bModel = new EyouSoft.Model.TourStructure.MBianGeng();
            bModel.BianId = model.TuiId;
            bModel.BianType = EyouSoft.Model.EnumType.TourStructure.BianType.票务安排变更;
            bModel.OperatorId = model.OperatorId;
            bModel.Url = new EyouSoft.Toolkit.request(model.PageUri, 1024, 768, 1024, 768, model.CompanyId, HttpContext.Current.Request.Cookies).SavePageAsImg();

            flg = dal.UpdatePlanTuiPiao(model);
            if (flg == -2)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务 + "修改退票。",
                    EventTitle = "修改退票",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };
                new EyouSoft.BLL.TourStructure.BBianGeng().InsertBianGeng(bModel);
            }

            return flg;
        }


        /// <summary>
        /// 删除退票
        /// </summary>
        /// <param name="tuiId"></param>
        /// <returns>
        /// -1:已经存在收款登记的退票项，不允许删除
        /// -2:删除成功
        /// -3:删除失败	
        /// </returns>
        public int DeletePlanTuiPiao(string tuiId)
        {
            var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingShouJinE(tuiId, EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务退款);
            if (jinE[1] + jinE[2] > 0) return -80;

            int flg = dal.DeletePlanTuiPiao(tuiId);

            if (flg == -2)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务 + "删除退票。",
                    EventTitle = "删除退票",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };
            }
            return flg;
        }

        /// <summary>
        /// 根据退票编号获取退票实体
        /// </summary>
        /// <param name="tuiId"></param>
        /// <returns></returns>
        public EyouSoft.Model.PlanStructure.MPlanTuiPiao GetPlanTuiPiaoById(string tuiId)
        {
            return dal.GetPlanTuiPiaoById(tuiId);
        }


        /// <summary>
        /// 获取退票列表
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MPlan_TuiPiao> GetPlanTuiPiaoList(string planId)
        {
            return dal.GetPlanTuiPiaoList(planId);
        }
    }
}
