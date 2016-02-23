using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PersonalCenterStructure
{
    #region 工作计划实体
    /// <summary>
    /// 工作计划实体
    /// </summary>
    [Serializable]
    public class WorkPlan
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkPlan()
        { }
        #endregion

        #region Model
        /// <summary>
        /// 编号
        /// </summary>
        public int PlanId
        {
            get;
            set;
        }
        /// <summary>
        /// 计划编号
        /// </summary>
        public string PlanNO
        {
            get;
            set;
        }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 计划标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 计划内容
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 计划附件
        /// </summary>
        public string FilePath
        {
            get;
            set;
        }
        /// <summary>
        /// 计划说明
        /// </summary>
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 计划人编号
        /// </summary>
        public int OperatorId
        {
            get;
            set;
        }
        /// <summary>
        /// 计划人姓名
        /// </summary>
        public string OperatorName
        {
            get;
            set;
        }
        /// <summary>
        /// 预计完成时间
        /// </summary>
        public DateTime? ExpectedDate
        {
            get;
            set;
        }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public DateTime? ActualDate
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState Status
        {
            get;
            set;
        }
        /// <summary>
        /// 上级部门评语
        /// </summary>
        public string DepartmentComment
        {
            get;
            set;
        }
        /// <summary>
        /// 总经理评语
        /// </summary>
        public string ManagerComment
        {
            get;
            set;
        }
        /// <summary>
        /// 填写时间
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastTime
        {
            get;
            set;
        }
        #endregion Model

        #region 附加属性
        /// <summary>
        /// 接收人集合
        /// </summary>
        public IList<WorkPlanAccept> AcceptList
        {
            get;
            set;
        }
        /// <summary>
        /// 接收状态
        /// </summary>
        public EyouSoft.Model.EnumType.PersonalCenterStructure.WorkType WorkType { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public int CheckId { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsCheck { get; set; }

        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string CheckName { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckDate { get; set; }

        #endregion
    }
    #endregion

    #region 工作计划接收人实体
    /// <summary>
    /// 工作计划接收人实体
    /// </summary>
    [Serializable]
    public class WorkPlanAccept
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkPlanAccept() { }
        #endregion

        #region Model
        /// <summary>
        /// 计划编号
        /// </summary>
        public int PlanId
        {
            get;
            set;
        }
        /// <summary>
        /// 接收人编号
        /// </summary>
        public int AccetpId
        {
            get;
            set;
        }
        /// <summary>
        /// 接收人名称
        /// </summary>
        public string AccetpName
        {
            get;
            set;
        }
        #endregion Model
    }
    #endregion

    #region 工作计划查询实体
    /// <summary>
    /// 工作计划查询实体
    /// </summary>
    public class QueryWorkPlan
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public QueryWorkPlan() { }

        #region 属性
        /// <summary>
        /// 计划标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 提交人姓名
        /// </summary>
        public string OperatorName
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState? Status
        {
            get;
            set;
        }
        /// <summary>
        /// 预计完成时间起
        /// </summary>
        public DateTime? SYuJiTime { get; set; }
        /// <summary>
        /// 预计完成时间止
        /// </summary>
        public DateTime? EYuJiTime { get; set; }
        #endregion

    }
    #endregion



}
