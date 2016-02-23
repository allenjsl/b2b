using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PersonalCenterStructure
{
    /// <summary>
    /// 个人中心-请假申请
    /// </summary>
    public class UserLeave
    {
        /// <summary>
        /// 申请编号
        /// </summary>
        public int LeaveId { get; set; }
        /// <summary>
        /// 申请用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 请假日期开始
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 请假时间开始
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 请假日期截止
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 请假时间截止
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 请假原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 请假性质
        /// </summary>
        public EnumType.PersonalCenterStructure.LeaveNature Nature { get; set; }
        /// <summary>
        /// 调班情况
        /// </summary>
        public string Situation { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 申请状态
        /// </summary>
        public EnumType.PersonalCenterStructure.LeaveState State { get; set; }
        /// <summary>
        /// 审批人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 审批备注
        /// </summary>
        public string CheckRemark { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? CheckTime { get; set; }
        /// <summary>
        /// 请假人姓名
        /// </summary>
        public string UserContactName { get; set; }
        /// <summary>
        /// 审批人姓名
        /// </summary>
        public string ShenPiRenName { get; set; }
        /// <summary>
        /// 作废人编号
        /// </summary>
        public int? ZuoFeiRenId { get; set; }
        /// <summary>
        /// 作废人姓名
        /// </summary>
        public string ZuoFeiRenName { get; set; }
        /// <summary>
        /// 作废备注
        /// </summary>
        public string ZuoFeiBeiZhu { get; set; }
        /// <summary>
        /// 作废时间
        /// </summary>
        public DateTime? ZuoFeiTime { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }

    #region 请假查询实体
    /// <summary>
    /// 请假查询实体
    /// </summary>
    public class MQingJiaChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MQingJiaChaXunInfo() { }

        /// <summary>
        /// 请假人姓名
        /// </summary>
        public string QingJiaRenName { get; set; }
        /// <summary>
        /// 请假人编号
        /// </summary>
        public int? QingJiaRenId { get; set; }
        /// <summary>
        /// 请假日期起
        /// </summary>
        public DateTime? STime { get; set; }
        /// <summary>
        /// 请假日期止
        /// </summary>
        public DateTime? ETime { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
