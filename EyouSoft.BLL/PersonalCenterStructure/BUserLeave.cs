using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.PersonalCenterStructure;
using EyouSoft.Model.EnumType.PersonalCenterStructure;

namespace EyouSoft.BLL.PersonalCenterStructure
{   
    /// <summary>
    /// 个人中心-请假申请
    /// zhengzy 2012-11-21
    /// </summary>
    public class BUserLeave:BLLBase
    {
        /// <summary>
        /// 个人中心-请假申请接口层
        /// </summary>
        private readonly EyouSoft.IDAL.PersonalCenterStructure.IUserLeave _idal =
            EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PersonalCenterStructure.IUserLeave>();

        /// <summary>
        /// 操作日志业务层
        /// </summary>
        private readonly BLL.CompanyStructure.SysHandleLogs _handleLogsBll =
            new EyouSoft.BLL.CompanyStructure.SysHandleLogs();

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        private readonly Model.SSOStructure.MUserInfo _currUserInfo = Security.Membership.UserProvider.GetUserInfo();

        #region IUserLeave成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl">请假申请</param>
        /// <returns>True：成功 False：失败</returns>
        public bool Add(UserLeave mdl)
        {
            if (mdl == null || mdl.CompanyId <= 0 || mdl.UserId <= 0) return false;
            var isOk= this._idal.Add(mdl);
            if (isOk)
            {
                this._handleLogsBll.Add(new SysHandleLogs()
                {
                    ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.None,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "用户编号：" + this._currUserInfo.UserId + "用户名：" + this._currUserInfo.Username + "新增了请假申请！申请编号为：" + mdl.LeaveId,
                    EventTitle = "新增请假申请"
                });
            }
            return isOk;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl">请假申请</param>
        /// <returns>-1:已审核不允许修改 1:修改成功 0:修改失败</returns>
        public int Upd(UserLeave mdl)
        {
            if (mdl == null || mdl.LeaveId <= 0) return 0;
            var isOk= this._idal.Upd(mdl);
            if (isOk==1)
            {
                this._handleLogsBll.Add(new SysHandleLogs()
                {
                    ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.None,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "用户编号：" + this._currUserInfo.UserId + "用户名：" + this._currUserInfo.Username + "修改了请假申请！申请编号为：" + mdl.LeaveId,
                    EventTitle = "修改请假申请"
                });
            }
            return isOk;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>-1:请假已审核不允许删除 1:删除成功 0:删除失败</returns>
        public int Del(int id)
        {
            if (id <= 0) return 0;
            var isOk = this._idal.Del(id);
            if (isOk==1)
            {
                this._handleLogsBll.Add(new SysHandleLogs()
                {
                    ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.None,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "用户编号：" + this._currUserInfo.UserId + "用户名：" + this._currUserInfo.Username + "删除了请假申请！申请编号为：" + id,
                    EventTitle = "删除请假申请"
                });
            }
            return isOk;
        }

        /*/// <summary>
        /// 审批
        /// </summary>
        /// <param name="mdl">审批信息实体</param>
        /// <returns>True：成功 False：失败</returns>
        public bool SetChk(UserLeave mdl)
        {
            if (mdl == null || mdl.LeaveId <= 0||mdl.OperatorId<=0) return false;
            var isOk = this._idal.SetChk(mdl);
            if (isOk)
            {
                this._handleLogsBll.Add(new SysHandleLogs()
                {
                    ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_请假管理,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "用户编号：" + this._currUserInfo.UserId + "用户名：" + this._currUserInfo.Username + "审批了请假申请！申请编号为：" + mdl.LeaveId,
                    EventTitle = "审批请假申请"
                });
            }
            return isOk;
        }*/

        /// <summary>
        /// 获取请假申请实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>True：成功 False：失败</returns>
        public UserLeave GetMdl(int id)
        {
            return id <= 0 ? null : this._idal.GetMdl(id);
        }

        /*/// <summary>
        /// 获取请假申请列表
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="operatorId">当前操作者编号(0为全部)</param>
        /// <returns>请假申请列表</returns>
        public IList<UserLeave> GetLst(int pageSize, int pageIndex, ref int recordCount, int companyId, int operatorId,string zxsId)
        {
            MQingJiaChaXunInfo chaXun = new MQingJiaChaXunInfo();
            if (operatorId > 0) chaXun.QingJiaRenId = operatorId;
            chaXun.ZxsId = zxsId;

            return GetLst(pageSize, pageIndex, ref recordCount, companyId, chaXun);
        }*/

        /// <summary>
        /// 获取请假申请列表
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns>请假申请列表</returns>
        public IList<UserLeave> GetLst(int pageSize, int pageIndex, ref int recordCount, int companyId, MQingJiaChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = _idal.GetLst(pageSize, pageIndex, ref recordCount, companyId, chaXun);

            return items;
        }

        /// <summary>
        /// 请假审批，返回1成功，其它失败
        /// </summary>
        /// <param name="qingJiaId">请假编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="isTongYi">是否同意 true:同意 false:不同意</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ShenPi(int qingJiaId, int companyId, bool isTongYi, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            if (qingJiaId < 1 || companyId < 1 || info == null || info.OperatorId < 1) return 0;
            if (_idal.GetStatus(qingJiaId) != LeaveState.未审批) return -1;

            LeaveState status= LeaveState.已同意;
            if(!isTongYi) status= LeaveState.未通过;

            int dalRetCode = _idal.ShenPi(qingJiaId, companyId, status, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "请假审批";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_请假管理;
                log.EventMessage = "请假审批，请假编号：" + qingJiaId + "，状态为：" + status + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 请假作废，返回1成功，其它失败
        /// </summary>
        /// <param name="qingJiaId">请假编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ZuoFei(int qingJiaId, int companyId, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            if (qingJiaId < 1 || companyId < 1 || info == null || info.OperatorId < 1) return 0;
            if (_idal.GetStatus(qingJiaId) != LeaveState.已同意) return -1;

            LeaveState status = LeaveState.作废;

            int dalRetCode = _idal.ZuoFei(qingJiaId, companyId, status, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "请假作废";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_请假管理;
                log.EventMessage = "请假作废，请假编号：" + qingJiaId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
