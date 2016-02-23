using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PersonalCenterStructure
{
    /// <summary>
    /// 个人中心-工作计划数据层接口
    /// </summary>
    /// 鲁功源 2011-01-17
    public interface IWorkPlan
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">工作计划实体</param>
        /// <returns>true:成功 false:失败</returns>
        bool Add(EyouSoft.Model.PersonalCenterStructure.WorkPlan model);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">工作计划实体</param>
        /// <returns> -1:审核 不允许修改 1:修改成功 0:修改失败</returns>
        int Update(EyouSoft.Model.PersonalCenterStructure.WorkPlan model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns>1:删除成功 0:删除失败 -1已审核的不允许删除</returns>
        int Delete(int id);
        /// <summary>
        /// 获取工作计划实体
        /// </summary>
        /// <param name="Id">主键编号</param>
        /// <returns>工作计划实体</returns>
        EyouSoft.Model.PersonalCenterStructure.WorkPlan GetModel(int Id);
        /// <summary>
        /// 分页工作交流集合
        /// </summary>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="CompanyId">公司编号 =0返回所有</param>
        /// <param name="OperatorId">操作人编号</param>
        /// <param name="QueryInfo">工作计划查询实体</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PersonalCenterStructure.WorkPlan> GetList(int pageSize, int pageIndex, ref int RecordCount, int CompanyId, int OperatorId, EyouSoft.Model.PersonalCenterStructure.QueryWorkPlan QueryInfo);


        /// <summary>
        /// 审核工作计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Check(EyouSoft.Model.PersonalCenterStructure.WorkPlan model);
    }
}
