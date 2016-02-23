using System;
using System.Collections.Generic;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 线路区域BLL
    /// Author:xuqh 2011-01-21 
    /// </summary>
    public class Area : BLLBase
    {
        #region constructure

        /// <summary>
        /// 线路区域数据层
        /// </summary>
        private readonly IDAL.CompanyStructure.IArea _dal = Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.IArea>();
        /// <summary>
        ///  操作日志业务逻辑
        /// </summary>
        private readonly SysHandleLogs _handleLogsBll = new SysHandleLogs();

        #endregion

        #region private members
        /// <summary>
        /// 添加日志记录
        /// </summary>
        /// <param name="actionName">操作名称</param>
        /// <param name="areaId">操作的线路区域编号（可以是多个）</param>
        /// <param name="areaName">线路区域名称</param>
        /// <returns></returns>
        private Model.CompanyStructure.SysHandleLogs AddLogs(string actionName, string areaId, string areaName)
        {
            var model = new Model.CompanyStructure.SysHandleLogs
            {
                ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置,
                EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                EventMessage =
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                    + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + actionName + "了线路区域，编号为" + areaId + "，名称为"
                    + areaName,
                EventTitle = actionName + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + " 线路区域"
            };

            return model;
        }
        #endregion

        #region 成员方法

        /// <summary>
        /// 获取线路区域实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.Area GetModel(int id)
        {
            if (id <= 0) return null;

            return this._dal.GetModel(id);
        }

        /// <summary>
        /// 分页获取公司线路区域集合
        /// </summary>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns>公司线路区域集合</returns>
        public IList<Model.CompanyStructure.Area> GetList(int pageSize, int pageIndex, ref int recordCount, int companyId,string zxsId)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0||string.IsNullOrEmpty(zxsId)) return null;

            return this._dal.GetList(pageSize, pageIndex, ref recordCount, companyId,zxsId);
        }

        /// <summary>
        /// 获取专线商所有线路区域信息
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.Area> GetQuYusByZxsId(string zxsId)
        {
            if (string.IsNullOrEmpty(zxsId)) return null;

            return this._dal.GetQuYusByZxsId(zxsId);
        }

        /// <summary>
        /// 获取专线商站点、专线类别、线路区域集合
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MZxsZhanDianInfo> GetZxsZhanDians(string zxsId)
        {
            if (string.IsNullOrEmpty(zxsId)) return null;

            return _dal.GetZxsZhanDians(zxsId);
        }

        /// <summary>
        /// 获取线路区域集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.Area> GetQuYus(int companyId, EyouSoft.Model.CompanyStructure.MQuYuChaXunInfo chaXun)
        {
            return _dal.GetQuYus(companyId, chaXun);
        }

        /// <summary>
        /// 线路区域新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int QuYu_C(EyouSoft.Model.CompanyStructure.Area info)
        {
            if (info == null || info.CompanyId < 1 || string.IsNullOrEmpty(info.ZxsId)) return 0;

            info.IssueTime = DateTime.Now;
            int dalRetCode = _dal.QuYu_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增线路区域";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置;
                log.EventMessage = "新增线路区域，线路区域编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 线路区域修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int QuYu_U(EyouSoft.Model.CompanyStructure.Area info)
        {
            if (info == null || info.CompanyId < 1 || string.IsNullOrEmpty(info.ZxsId)||info.Id<1) return 0;

            info.IssueTime = DateTime.Now;
            int dalRetCode = _dal.QuYu_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改线路区域";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置;
                log.EventMessage = "修改线路区域，线路区域编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 线路区域删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="quYuId">线路区域编号</param>
        /// <returns></returns>
        public int QuYu_D(int companyId, string zxsId, int quYuId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || quYuId < 1) return 0;

            int dalRetCode = _dal.QuYu_D(companyId, zxsId, quYuId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除线路区域";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置;
                log.EventMessage = "删除线路区域，线路区域编号：" + quYuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }
        #endregion
    }
}
