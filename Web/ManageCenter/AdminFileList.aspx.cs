using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Text;
using EyouSoft.Model.AdminCenterStructure;

namespace Web.ManageCenter
{
    public partial class AdminFileList : BackPage
    {
        protected string dutylist = string.Empty;
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
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.ITitle = "人事档案_行政中心";
            string id = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype != null && dotype.Length > 0)
            {
                AJAX(dotype, id);
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page")) == 0 ? 1 : Utils.GetInt(Utils.GetQueryStringValue("page"));

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
            pageIndex = Utils.GetInt(Request.QueryString["Page"], 1);
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

            if (UtilsCommons.IsToXls()) ListToExcel(modelPersonnelSearch);

            EyouSoft.BLL.AdminCenterStructure.PersonnelInfo bllper = new EyouSoft.BLL.AdminCenterStructure.PersonnelInfo();
            IList<EyouSoft.Model.AdminCenterStructure.PersonnelInfo> List = bllper.GetList(pageSize, pageIndex, ref recordCount, this.SiteUserInfo.CompanyId, modelPersonnelSearch);
            bindDuty(JobPostion);
            if (List != null && List.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.rptList.DataSource = List;
                this.rptList.DataBind();
                BindExportPage();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='12' align='center'>暂无人事档案!</td></tr>";
            }
        }
        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType, string id)
        {
            string msg = string.Empty;
            if (doType == "delete")
            {
                if (this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_人事档案_删除))
                {
                    msg = this.DeleteData(id);
                }
                else
                {
                    msg = UtilsCommons.AjaxReturnJson("0", "对不起，您没有删除权限！");
                }
            }
            //返回ajax操作结果
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }

        private void bindDuty(int? dutyid)
        {
            EyouSoft.BLL.AdminCenterStructure.DutyManager bllDuty = new EyouSoft.BLL.AdminCenterStructure.DutyManager();
            IList<EyouSoft.Model.AdminCenterStructure.DutyManager> listDuty = bllDuty.GetList(CurrentUserCompanyID);
            StringBuilder str = new StringBuilder();
            if (dutyid >= 0)
                str.Append("<option value='-1'>请选择</option>");
            else
                str.Append("<option value='-1' selected='selected'>请选择</option>");
            if (listDuty != null && listDuty.Count > 0)
            {
                for (int i = 0; i < listDuty.Count; i++)
                {
                    if (listDuty[i].Id != dutyid)
                        str.AppendFormat("<option value='{0}'>{1}</option>", listDuty[i].Id.ToString(), listDuty[i].JobName);
                    else
                        str.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", listDuty[i].Id.ToString(), listDuty[i].JobName);
                }
            }
            dutylist = str.ToString();
        }

        protected string GetDepartMent(object obj)
        {
            string department = string.Empty;
            IList<EyouSoft.Model.CompanyStructure.Department> list = (IList<EyouSoft.Model.CompanyStructure.Department>)obj;
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == list.Count - 1)
                    {
                        department += list[i].DepartName;
                    }
                    else
                    {
                        department += list[i].DepartName + "、";
                    }
                }
            }
            return department;
        }

        #region 导出Excel
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ListToExcel(PersonnelSearchInfo modelPersonnelSearch)
        {
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);
            StringBuilder s = new StringBuilder();
            //序号 	档案编号 	姓名 	性别 	出生日期 	所属部门 	职务 	工龄 	联系电话 	手机 	E-mail
            s.Append("序号\t档案编号\t姓名\t性别\t出生日期\t所属部门\t职务\t工龄\t联系电话\t手机\tE-mail\n");
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"));


            EyouSoft.BLL.AdminCenterStructure.PersonnelInfo bllper = new EyouSoft.BLL.AdminCenterStructure.PersonnelInfo();
            IList<EyouSoft.Model.AdminCenterStructure.PersonnelInfo> list = bllper.GetList(toXlsRecordCount, 1, ref recordCount, this.SiteUserInfo.CompanyId, modelPersonnelSearch);


            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    s.AppendFormat(
                        "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\n",
                        i.ToString(),
                        list[i].ArchiveNo,
                        list[i].UserName,
                        list[i].ContactSex.ToString(),
                        list[i].BirthDate.HasValue ? UtilsCommons.GetDateString(list[i].BirthDate.Value, ProviderToDate) : "",
                        GetDepartMent((object)list[i].AttendanceList),
                        list[i].DutyName,
                        list[i].WorkYear.ToString(),
                        list[i].ContactTel,
                        list[i].ContactMobile,
                        list[i].Email);
                }
            }

            ResponseToXls(s.ToString());
        }
        #endregion
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private string DeleteData(string id)
        {
            if (!String.IsNullOrEmpty(id) && Utils.GetInt(id) > 0)
            {
                EyouSoft.BLL.AdminCenterStructure.PersonnelInfo bllper = new EyouSoft.BLL.AdminCenterStructure.PersonnelInfo();
                int[] array = new int[1];
                array[0] = Utils.GetInt(id);
                if (bllper.Delete(this.SiteUserInfo.CompanyId, array))
                {
                    return UtilsCommons.AjaxReturnJson("1", "删除成功");
                }
                else
                {
                    return UtilsCommons.AjaxReturnJson("0", "删除失败!");
                }
            }
            else
            {
                return UtilsCommons.AjaxReturnJson("0", "人事信息错误!");
            }
        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {            
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion
    }
}
