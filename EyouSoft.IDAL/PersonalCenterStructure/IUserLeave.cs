using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.PersonalCenterStructure;
using EyouSoft.Model.EnumType.PersonalCenterStructure;

namespace EyouSoft.IDAL.PersonalCenterStructure
{

    public interface IUserLeave
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl">请假申请</param>
        /// <returns>True：成功 False：失败</returns>
        bool Add(UserLeave mdl);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl">请假申请</param>
        /// <returns>-1:已审核不允许修改 1:修改成功 0:修改失败</returns>
        int Upd(UserLeave mdl);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>-1:请假已审核不允许删除 1:删除成功 0:删除失败</returns>
        int Del(int id);

        /*/// <summary>
        /// 审批
        /// </summary>
        /// <param name="mdl">审批信息实体</param>
        /// <returns>True：成功 False：失败</returns>
        bool SetChk(UserLeave mdl);*/

        /// <summary>
        /// 获取请假申请实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>True：成功 False：失败</returns>
        UserLeave GetMdl(int id);

        /// <summary>
        /// 获取请假申请列表
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns>请假申请列表</returns>
        IList<UserLeave> GetLst(int pageSize, int pageIndex, ref int recordCount, int companyId, MQingJiaChaXunInfo chaXun);

        /// <summary>
        /// 获取请假状态
        /// </summary>
        /// <param name="qingJiaId">请假编号</param>
        /// <returns></returns>
        LeaveState GetStatus(int qingJiaId);
        /// <summary>
        /// 请假审批，返回1成功，其它失败
        /// </summary>
        /// <param name="qingJiaId">请假编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int ShenPi(int qingJiaId, int companyId, LeaveState status, EyouSoft.Model.FinStructure.MOperatorInfo info);
        /// <summary>
        /// 请假作废，返回1成功，其它失败
        /// </summary>
        /// <param name="qingJiaId">请假编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int ZuoFei(int qingJiaId, int companyId, LeaveState status, EyouSoft.Model.FinStructure.MOperatorInfo info);

    }
}
