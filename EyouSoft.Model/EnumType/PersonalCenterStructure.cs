//个人中心相关枚举
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.EnumType.PersonalCenterStructure
{
    #region 审核状态

    /// <summary>
    /// 审核状态
    /// </summary>
    public enum CheckState
    {
        /// <summary>
        /// 未审核
        /// </summary>
        未审核 = 0,
        /// <summary>
        /// 已审核
        /// </summary>
        已审核 = 1
    }

    #endregion

    #region 工作计划审核状态

    /// <summary>
    /// 工作计划审核状态
    /// </summary>
    public enum PlanCheckState
    {
        /// <summary>
        /// 进行中
        /// </summary>
        进行中 = 1,
        /// <summary>
        /// 取消
        /// </summary>
        取消 = 2,
        /// <summary>
        /// 未完成
        /// </summary>
        未完成 = 3,
        /// <summary>
        /// 效果不理想完成
        /// </summary>
        效果不理想完成 = 4,
        /// <summary>
        /// 效果理想完成
        /// </summary>
        效果理想完成 = 5
    }

    #endregion

    #region 发布对象类型

    /// <summary>
    /// 发布对象类型
    /// </summary>
    public enum AcceptType
    {
        /// <summary>
        /// 所有
        /// </summary>
        所有 = 0,
        /// <summary>
        /// 指定部门
        /// </summary>
        指定部门 = 1,
        /// <summary>
        /// 指定组团
        /// </summary>
        指定组团 = 2,
        /// <summary>
        /// 指定人
        /// </summary>
        指定人 = 3
    }

    #endregion

    #region 工作交流类型

    /// <summary>
    /// 工作交流类型
    /// </summary>
    public enum ExchangeType
    {
        /// <summary>
        /// 公告通知
        /// </summary>
        公告通知 = 0,
        /// <summary>
        /// 业务交流
        /// </summary>
        业务交流 = 1,
        /// <summary>
        /// 财务交流
        /// </summary>
        财务交流 = 2,
        /// <summary>
        /// 发票交流
        /// </summary>
        发票交流 = 3
    }

    #endregion

    #region 个人备忘完成状态

    /// <summary>
    /// 个人备忘完成状态
    /// </summary>
    public enum MemorandumState
    {
        /// <summary>
        /// 未完成
        /// </summary>
        未完成 = 0,
        /// <summary>
        /// 已完成
        /// </summary>
        已完成 = 1
    }

    #endregion

    #region 个人中心 请假申请 请假性质

    /// <summary>
    /// 请假性质
    /// </summary>
    public enum LeaveNature
    {
        /// <summary>
        /// 事假
        /// </summary>
        事假 = 0,
        /// <summary>
        /// 病假
        /// </summary>
        病假 = 1,
        /// <summary>
        /// 年休
        /// </summary>
        年休 = 2,
        /// <summary>
        /// 调休
        /// </summary>
        调休 = 3,
        /// <summary>
        /// 其他
        /// </summary>
        其他 = 4
    }

    #endregion

    #region 个人中心 请假申请状态

    /// <summary>
    /// 请假申请状态
    /// </summary>
    public enum LeaveState
    {
        /// <summary>
        /// 未审批
        /// </summary>
        未审批 = 0,
        /// <summary>
        /// 已同意
        /// </summary>
        已同意 = 1,
        /// <summary>
        /// 未通过
        /// </summary>
        未通过 = 2,
        /// <summary>
        /// 作废(已同意的申请信息可以做作废操作)
        /// </summary>
        作废 = 3
    }

    #endregion

    #region 个人中心工作汇报接收人状态
    /// <summary>
    /// 个人中心工作汇报接收人状态
    /// </summary>
    public enum WorkType
    {
        工作汇报 = 0,
        工作计划    
    }
    #endregion

}
