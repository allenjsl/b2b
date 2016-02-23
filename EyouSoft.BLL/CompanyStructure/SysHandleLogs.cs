using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 系统操作日志BLL
    /// </summary>
    public class SysHandleLogs : BLLBase
    {
        /// <summary>
        /// 操作日志数据层
        /// </summary>
        private readonly IDAL.CompanyStructure.ISysHandleLogs _dal =
            Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.ISysHandleLogs>();

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        private readonly Model.SSOStructure.MUserInfo _SysYongHuInfo = Security.Membership.UserProvider.GetUserInfo();
        private readonly EyouSoft.Model.SSOStructure.MGysYongHuInfo _GysYongHuInfo = Security.Membership.GysYongHuProvider.GetYongHuInfo();

        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="model">系统操作日志实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(Model.CompanyStructure.SysHandleLogs model)
        {
            if (model == null)
                return false;

            model.EventIp = Toolkit.Utils.GetRemoteIP();
            model.EventTime = DateTime.Now;

            if (_SysYongHuInfo == null) return true;

            if (_SysYongHuInfo != null)
            {
                model.OperatorId = _SysYongHuInfo.UserId;
                model.CompanyId = _SysYongHuInfo.CompanyId;
                model.DepatId = _SysYongHuInfo.DeptId;
                if (!string.IsNullOrEmpty(model.EventMessage) && model.EventMessage.Contains("{0}") && this._SysYongHuInfo.Name != null)
                    model.EventMessage = string.Format(model.EventMessage, _SysYongHuInfo.Name);
                model.ZxsId = _SysYongHuInfo.ZxsId;
            }

            
            return this._dal.Add(model);
        }

        /// <summary>
        /// 添加操作日志(供应商平台)
        /// </summary>
        /// <param name="model">系统操作日志实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add1(Model.CompanyStructure.SysHandleLogs model)
        {
            if (model == null)
                return false;

            model.EventIp = Toolkit.Utils.GetRemoteIP();
            model.EventTime = DateTime.Now;

            if (_GysYongHuInfo == null) return true;

            if ( _GysYongHuInfo != null)
            {
                model.OperatorId = _GysYongHuInfo.YongHuId;
                model.CompanyId = _GysYongHuInfo.CompanyId;
                model.DepatId = 0;
                model.ZxsId = string.Empty;
            }

            
            return this._dal.Add(model);
        }

        /*/// <summary>
        /// 获取操作日志实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>操作日志实体</returns>
        public Model.CompanyStructure.SysHandleLogs GetModel(string id)
        {
            return this._dal.GetModel(id);
        }*/

        /// <summary>
        /// 分页获取操作日志列表
        /// </summary>
        /// <param name="pageSize">每页现实条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">系统操作日志查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.SysHandleLogs> GetList(int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QueryHandleLog model)
        {
            return this._dal.GetList(pageSize, pageIndex, ref recordCount, model);
        }
    }
}
