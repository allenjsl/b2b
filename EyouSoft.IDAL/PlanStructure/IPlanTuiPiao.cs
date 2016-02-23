using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PlanStructure
{
    public interface IPlanTuiPiao
    {

        /// <summary>
        /// 添加退票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:存在不能正常退票的游客
        /// -2:添加成功
        /// -3:添加失败			
        /// </returns>
        int AddPlanTuiPiao(EyouSoft.Model.PlanStructure.MPlanTuiPiao model);

        /// <summary>
        /// 修改退票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:存在不能正常退票的游客
        /// -2:添加成功
        /// -3:添加失败	
        /// </returns>
        int UpdatePlanTuiPiao(EyouSoft.Model.PlanStructure.MPlanTuiPiao model);


        /// <summary>
        /// 删除退票
        /// </summary>
        /// <param name="tuiId"></param>
        /// <returns>
        /// -1:已经存在收款登记的退票项，不允许删除
        /// -2:删除成功
        /// -3:删除失败	
        /// </returns>
        int DeletePlanTuiPiao(string tuiId);

        /// <summary>
        /// 根据退票编号获取退票实体
        /// </summary>
        /// <param name="tuiId"></param>
        /// <returns></returns>
        EyouSoft.Model.PlanStructure.MPlanTuiPiao GetPlanTuiPiaoById(string tuiId);


        /// <summary>
        /// 获取退票列表
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PlanStructure.MPlan_TuiPiao> GetPlanTuiPiaoList(string planId);
    }
}
