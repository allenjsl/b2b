using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.AdminCenterStructure
{
    /// <summary>
    /// 行政中心-人事档案IDAL
    /// 创建人：luofx 2011-01-17
    /// </summary>
    public interface IPersonnelInfo
    {
        /// <summary>
        /// 获取认识档案信息实体
        /// </summary>
        /// <param name="CompanyId">公司编号</param>
        /// <param name="PersonId">职员编号</param>
        /// <returns></returns>
        EyouSoft.Model.AdminCenterStructure.PersonnelInfo GetModel(int CompanyId, int PersonId);
        /// <summary>
        /// 获取人事档案列表信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="ReCordCount"></param>
        /// <param name="CompanyId">公司编号</param>
        /// <param name="SearchInfo">认识档案搜索实体</param>
        /// <returns></returns>
        IList<EyouSoft.Model.AdminCenterStructure.PersonnelInfo> GetList(int PageSize, int PageIndex, ref int ReCordCount, int CompanyId, EyouSoft.Model.AdminCenterStructure.PersonnelSearchInfo SearchInfo);
        /// <summary>
        /// 获取通讯录信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="ReCordCount"></param>
        /// <param name="CompanyId"></param>
        /// <param name="UserName">姓名</param>
        /// <param name="DepartmentId">部门编号</param>
        /// <param name="deptNm">部门名称(部门编号为null或0时用部门名称模糊查询)</param>
        /// <param name="s"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.AdminCenterStructure.PersonnelInfo> GetList(int PageSize, int PageIndex, ref int ReCordCount, int CompanyId, string UserName, int? DepartmentId, string deptNm, string s);
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model">职工档案信息实体</param>
        /// <returns></returns>
        bool Add(EyouSoft.Model.AdminCenterStructure.PersonnelInfo model);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">职工档案信息实体</param>
        /// <returns></returns>
        bool Update(EyouSoft.Model.AdminCenterStructure.PersonnelInfo model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CompanyId">公司编号</param>
        /// <param name="PersonId">员工编号</param>
        /// <returns></returns>
        bool Delete(int CompanyId, params int[] PersonId);
    }
}
