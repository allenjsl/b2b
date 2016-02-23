using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PlanStructure
{
    public interface IPlanChuPiao
    {

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
        int YajinDengji(EyouSoft.Model.PlanStructure.MYaJinDengJi model);
        /// <summary>
        /// 押金登记的列表（代理商信息）
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PlanStructure.MYaJin> GetYaJinList(string kongWeiId);
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
        int AddPlanChuPiao(EyouSoft.Model.PlanStructure.MPlanChuPiao model);
        /// <summary>
        /// 修改安排出票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:出票数量大于剩余数量
        /// -2:当前操作存在不能正常出票游客
        /// -3:修改成功
        /// -4:修改失败	
        /// -81:存在付款登记的出票安排不允许修改代理商信息
        /// </returns>
        int UpdatePlanChuPiao(EyouSoft.Model.PlanStructure.MPlanChuPiao model);
        /// <summary>
        /// 删除出票安排
        /// </summary>
        /// <param name="planId"></param>
        /// <returns>
        /// -1:已存在付款登记的出票安排，不可删除。
        /// -2:删除成功
        /// -3:删除失败			
        /// </returns>
        int DeletePlanChuPiao(string planId);
        /// <summary>
        /// 获取出票安排的信息
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        EyouSoft.Model.PlanStructure.MPlanChuPiao GetPlanChuPiaoById(string planId);
        /// <summary>
        /// 获取已安排出票列表
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PlanStructure.MPlan_ChuPiao> GetPlanChuPiaoList(string kongWeiId);
    }
}
