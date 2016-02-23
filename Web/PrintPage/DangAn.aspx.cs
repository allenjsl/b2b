using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Web.PrintPage
{
    using System.Collections.Generic;

    using EyouSoft.Common;
    using EyouSoft.Common.Page;

    public partial class DangAn : BackPage
    {
        #region 查询参数
        string FileNo = string.Empty;
        string Name = string.Empty;
        int? Sex = null;
        DateTime? BirthdayStart = null;
        DateTime? BirthdayEnd = null;
        int? WorkYearFrom = null;
        int? WorkYearTo = null;
        int? JobPostion = null;
        int? WorkerType = null;
        string WorkerState = string.Empty;
        string MarriageState = string.Empty;
        #endregion

        #region 分页参数
        protected int pageIndex=1;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 查询参数赋值
            FileNo = Utils.GetQueryStringValue("txtcode");           //编号
            Name = Utils.GetQueryStringValue("txtname");
            Sex = Utils.GetIntNull(Utils.GetQueryStringValue("selsex"));
            BirthdayStart = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtstartdate"));
            BirthdayEnd = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtenddate"));
            WorkYearFrom = Utils.GetIntNull(Utils.GetQueryStringValue("txtage"));       //工龄
            WorkYearTo = Utils.GetIntNull(Utils.GetQueryStringValue("txtendage"));       //工龄
            JobPostion = Utils.GetIntNull(Utils.GetQueryStringValue("dpJobPostion"));                    //职务
            WorkerType = Utils.GetIntNull(Utils.GetQueryStringValue("dpWorkerType"));                    //类型
            WorkerState = Utils.GetQueryStringValue("dpWorkerState");                  //员工状态
            MarriageState = Utils.GetQueryStringValue("dpMarriageState");              //婚姻状况
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            #endregion

            #region 参训对象赋值
            EyouSoft.Model.AdminCenterStructure.PersonnelSearchInfo modelPersonnelSearch = new EyouSoft.Model.AdminCenterStructure.PersonnelSearchInfo();
            if (FileNo != "")
                modelPersonnelSearch.ArchiveNo = FileNo;
            if (Name != "")
                modelPersonnelSearch.UserName = Name;
            if (Sex != null && Sex != 0)
                modelPersonnelSearch.ContactSex = (EyouSoft.Model.EnumType.CompanyStructure.Sex)Sex;
            else
            {
                modelPersonnelSearch.ContactSex = null;
            }
            modelPersonnelSearch.BirthDateFrom = BirthdayStart;
            modelPersonnelSearch.BirthDateTo = BirthdayEnd;
            modelPersonnelSearch.WorkYearFrom = WorkYearFrom;
            modelPersonnelSearch.WorkYearTo = WorkYearTo;
            if (JobPostion != null && JobPostion != -1)
                modelPersonnelSearch.DutyId = JobPostion;
            if (WorkerType != null && WorkerType != -1)
                modelPersonnelSearch.PersonalType = (EyouSoft.Model.EnumType.AdminCenterStructure.PersonalType)(WorkerType);
            if (WorkerState != "" && WorkerState != "-1")
                modelPersonnelSearch.IsLeave = Convert.ToBoolean(Utils.GetInt(WorkerState));
            if (MarriageState != "" && MarriageState != "-1")
                modelPersonnelSearch.IsMarried = Convert.ToBoolean(Utils.GetInt(MarriageState));
            #endregion

            var bllper = new EyouSoft.BLL.AdminCenterStructure.PersonnelInfo();
            var List = bllper.GetList(pageSize, pageIndex, ref recordCount, this.SiteUserInfo.CompanyId, modelPersonnelSearch);
            if (List != null && List.Count > 0)
            {
                this.rpt.DataSource = List;
                this.rpt.DataBind();
            }
            else
            {
                this.rpt.Controls.Add(new Label() { Text = "<tr><td colspan='11' align='center'>对不起，没有相关数据！</td></tr>" });
            }
        }

        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="DepartmentList"></param>
        /// <returns></returns>
        protected string GetDept(List<EyouSoft.Model.CompanyStructure.Department> DepartmentList)
        {
            return DepartmentList!=null&& DepartmentList.Count>0?DepartmentList.Aggregate(string.Empty, (current, mo) => current + mo.DepartName + ",").TrimEnd(','):string.Empty;
        }
    }
}
