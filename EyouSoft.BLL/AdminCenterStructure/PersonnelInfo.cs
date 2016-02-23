using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.AdminCenterStructure
{
    /// <summary>
    /// 行政中心-人事档案BLL
    /// </summary>
    public class PersonnelInfo : EyouSoft.BLL.BLLBase
    {
        private readonly EyouSoft.IDAL.AdminCenterStructure.IPersonnelInfo idal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.AdminCenterStructure.IPersonnelInfo>();

        #region 公共方法
        /// <summary>
        /// 获取认识档案信息实体
        /// </summary>
        /// <param name="CompanyId">公司编号</param>
        /// <param name="PersonId">职员编号</param>
        /// <returns></returns>
        public EyouSoft.Model.AdminCenterStructure.PersonnelInfo GetModel(int CompanyId, int PersonId)
        {
            return idal.GetModel(CompanyId, PersonId);
        }
        /// <summary>
        /// 获取人事档案列表(内部通讯录)信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="ReCordCount"></param>
        /// <param name="CompanyId">公司编号</param>
        /// <param name="SearchInfo">认识档案搜索实体</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.AdminCenterStructure.PersonnelInfo> GetList(int PageSize, int PageIndex, ref int ReCordCount, int CompanyId, EyouSoft.Model.AdminCenterStructure.PersonnelSearchInfo SearchInfo)
        {
            return idal.GetList(PageSize, PageIndex, ref ReCordCount, CompanyId, SearchInfo);
        }
        /// <summary>
        /// 获取通讯录信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="ReCordCount"></param>
        /// <param name="CompanyId"></param>
        /// <param name="UserName">姓名</param>
        /// <param name="DepartmentId">部门编号(null或0时取所有)</param>
        /// <param name="deptNm">部门名称(部门编号为null或0时用部门名称模糊查询)</param>
        /// <param name="s">是否离职（0：所有 1：在职 2：离职）</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.AdminCenterStructure.PersonnelInfo> GetList(int PageSize, int PageIndex, ref int ReCordCount, int CompanyId, string UserName, int? DepartmentId,string deptNm,string s)
        {
            return idal.GetList(PageSize, PageIndex, ref ReCordCount, CompanyId, UserName, DepartmentId,deptNm,s);
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model">职工档案信息实体</param>
        /// <returns></returns>
        public bool Add(EyouSoft.Model.AdminCenterStructure.PersonnelInfo model)
        {
            bool IsTrue = false;
            IsTrue = idal.Add(model);
            #region LGWR
            if (IsTrue)
            {
                EyouSoft.Model.CompanyStructure.SysHandleLogs logInfo = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                logInfo.CompanyId = 0;
                logInfo.DepatId = 0;
                logInfo.EventCode = EyouSoft.Model.CompanyStructure.SysHandleLogsNO.EventCode;
                logInfo.EventIp = string.Empty;
                logInfo.EventMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在" + Model.EnumType.PrivsStructure.Privs2.行政中心_人事档案.ToString() + "新增了人事档案信息数据。";
                logInfo.EventTime = DateTime.Now;
                logInfo.EventTitle = "新增人事档案信息";
                logInfo.ModuleId = Model.EnumType.PrivsStructure.Privs2.行政中心_人事档案;
                logInfo.OperatorId = 0;
                this.Logwr(logInfo);
                logInfo = null;
            }
            #endregion
            return IsTrue;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">职工档案信息实体</param>
        /// <returns></returns>
        public bool Update(EyouSoft.Model.AdminCenterStructure.PersonnelInfo model)
        {
            bool IsTrue = false;
            IsTrue = idal.Update(model);
            #region LGWR
            if (IsTrue)
            {
                EyouSoft.Model.CompanyStructure.SysHandleLogs logInfo = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                logInfo.CompanyId = 0;
                logInfo.DepatId = 0;
                logInfo.EventCode = EyouSoft.Model.CompanyStructure.SysHandleLogsNO.EventCode;
                logInfo.EventIp = string.Empty;
                logInfo.EventMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在" + Model.EnumType.PrivsStructure.Privs2.行政中心_人事档案.ToString() + "修改了人事档案信息数据,编号为：" + model.Id;
                logInfo.EventTime = DateTime.Now;
                logInfo.EventTitle = "修改人事档案信息";
                logInfo.ModuleId = Model.EnumType.PrivsStructure.Privs2.行政中心_人事档案;
                logInfo.OperatorId = 0;
                this.Logwr(logInfo);
                logInfo = null;
            }
            #endregion
            return IsTrue;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CompanyId">公司编号</param>
        /// <param name="PersonId">员工编号</param>
        /// <returns></returns>
        public bool Delete(int CompanyId, params int[] PersonId)
        {
            bool IsTrue = false;
            IsTrue = idal.Delete(CompanyId, PersonId);
            #region LGWR
            if (IsTrue)
            {
                EyouSoft.Model.CompanyStructure.SysHandleLogs logInfo = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                logInfo.CompanyId = 0;
                logInfo.DepatId = 0;
                logInfo.EventCode = EyouSoft.Model.CompanyStructure.SysHandleLogsNO.EventCode;
                logInfo.EventIp = string.Empty;
                logInfo.EventMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在" + Model.EnumType.PrivsStructure.Privs2.行政中心_人事档案.ToString() + "删除了人事档案信息数据。";
                logInfo.EventTime = DateTime.Now;
                logInfo.EventTitle = "删除人事档案信息";
                logInfo.ModuleId = Model.EnumType.PrivsStructure.Privs2.行政中心_人事档案;
                logInfo.OperatorId = 0;
                this.Logwr(logInfo);
                logInfo = null;
            }
            #endregion
            return IsTrue;
        }
        #endregion 公共方法

        #region 私有方法
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logInfo">日志信息</param>
        private void Logwr(EyouSoft.Model.CompanyStructure.SysHandleLogs logInfo)
        {
            EyouSoft.BLL.CompanyStructure.SysHandleLogs logbll = new EyouSoft.BLL.CompanyStructure.SysHandleLogs();
            logbll.Add(logInfo);
            logbll = null;
        }
        #endregion
    }
}
