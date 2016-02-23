using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.AdminCenterStructure
{
    #region 行政中心-人事档案信息实体
    /// <summary>
    /// 行政中心-人事档案信息实体
    /// </summary>
    public class PersonnelInfo
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public int CompanyId { set; get; }
        /// <summary>
        /// 档案编号
        /// </summary>
        public string ArchiveNo { set; get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 性别(未知，男，女，默认0)
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.Sex ContactSex { set; get; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string CardId { set; get; }

        /// <summary>
        /// 身份证附件路径
        /// </summary>
        public string CardPath { set; get; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { set; get; }
        /// <summary>
        /// 员工照片
        /// </summary>
        public string PhotoPath { set; get; }
        /// <summary>
        /// 所属部门(多个部门时，id值以逗号","分开)
        /// </summary>
        public string DepartmentId { set; get; }
        /// <summary>
        /// 职务
        /// </summary>
        public int? DutyId { set; get; }
        /// <summary>
        /// 类型（正式，试用，学徒）
        /// </summary>
        public EyouSoft.Model.EnumType.AdminCenterStructure.PersonalType PersonalType { set; get; }
        /// <summary>
        /// 员工状态(离职=true，在职=false)
        /// </summary>
        public bool IsLeave { set; get; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? EntryDate { set; get; }
        /// <summary>
        /// 工龄
        /// </summary>
        public int WorkYear { get; set; }
        /// <summary>
        /// 参加工作时间
        /// </summary>
        public DateTime? ServiceYear { set; get; }
        /// <summary>
        /// 离职时间
        /// </summary>
        public DateTime? LeaveDate { set; get; }
        /// <summary>
        /// 婚姻状态(未婚=false，已婚=true)
        /// </summary>
        public bool IsMarried { set; get; }
        /// <summary>
        /// 民族
        /// </summary>
        public string National { set; get; }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string Birthplace { set; get; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Politic { set; get; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel { set; get; }
        /// <summary>
        /// 手机
        /// </summary>
        public string ContactMobile { set; get; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { set; get; }
        /// <summary>
        /// MSN(手机短号)
        /// </summary>
        public string MSN { set; get; }
        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { set; get; }
        /// <summary>
        /// 住址
        /// </summary>
        public string ContactAddress { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime{set;get;}
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId{set;get;}        
        /// <summary>
        /// 所属部门
        /// </summary>
        public IList<EyouSoft.Model.CompanyStructure.Department> DepartmentList { get; set; }
        /// <summary>
        /// 职务名称
        /// </summary>
        public string DutyName { get; set; }
        /// <summary>
        /// 学历信息集合
        /// </summary>
        public IList<EyouSoft.Model.AdminCenterStructure.SchoolInfo> SchoolList { get; set; }
        /// <summary>
        /// 履历信息集合
        /// </summary>
        public IList<EyouSoft.Model.AdminCenterStructure.PersonalHistory> HistoryList { get; set; }
        /// <summary>
        /// 考勤信息集合
        /// </summary>
        public IList<EyouSoft.Model.AdminCenterStructure.AttendanceInfo> AttendanceList { get; set; }
        /// <summary>
        /// 银行账户信息集合
        /// </summary>
        public IList<EyouSoft.Model.CompanyStructure.CompanyAccountBase> YinHangZhangHus { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WeiXinHao { get; set; }
    }
    #endregion

    #region 人事档案搜索实体
    /// <summary>
    /// 人事档案搜索实体
    /// </summary>
    public class PersonnelSearchInfo
    {
        /// <summary>
        /// 档案编号
        /// </summary>
        public string ArchiveNo { set; get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 性别(未知，男，女，默认0)
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.Sex? ContactSex { set; get; }
        /// <summary>
        /// 出生日期开始
        /// </summary>
        public DateTime? BirthDateFrom { set; get; }
        /// <summary>
        /// 出生日期结束
        /// </summary>
        public DateTime? BirthDateTo { set; get; }
        /// <summary>
        /// 工龄 起始
        /// </summary>
        public int? WorkYearFrom { get; set; }
        /// <summary>
        /// 工龄 结束
        /// </summary>
        public int? WorkYearTo { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public int? DutyId { set; get; }
        /// <summary>
        /// 类型（正式，试用，学徒）
        /// </summary>
        public EyouSoft.Model.EnumType.AdminCenterStructure.PersonalType? PersonalType { set; get; }

        /// <summary>
        /// 员工状态(离职=true，在职=false)
        /// </summary>
        public bool? IsLeave { set; get; }
        /// <summary>
        /// 婚姻状态(未婚=false，已婚=true)
        /// </summary>
        public bool? IsMarried { set; get; }
    }
    #endregion
}
