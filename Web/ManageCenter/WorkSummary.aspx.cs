using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using System.Text;

    using EyouSoft.Common;
    using EyouSoft.Common.Page;
    using EyouSoft.Model.AdminCenterStructure;
    using EyouSoft.Model.CompanyStructure;

    using AttendanceInfo = EyouSoft.BLL.AdminCenterStructure.AttendanceInfo;

    public partial class WorkSummary : BackPage
    {
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        protected void Page_Load(object sender, EventArgs e)
        {
            //权限验证
            PowerControl();
            year = Utils.GetInt(Utils.GetQueryStringValue("selYear"), year);
            month = Utils.GetInt(Utils.GetQueryStringValue("selMonth"), month);
            if (!IsPostBack)
            {
                //根据ID初始化页面
                PageInit();
            }
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="id">操作ID</param>
        protected void PageInit()
        {
            string txtNum = Utils.GetQueryStringValue("txtNum");
            string txtName = Utils.GetQueryStringValue("txtName");
            string sectionID = Utils.GetQueryStringValue("DeptId");
            string sectionName = Utils.GetQueryStringValue("DeptNm");
            this.SelectSection1.SectionName = sectionName;
            this.SelectSection1.SectionID = sectionID;
            var BLL = new AttendanceInfo();
            var Model = new SearchInfo();
            if (!string.IsNullOrEmpty(sectionID))
            {
                Model.DepartMentId = Utils.GetIntNull(sectionID);
            }
            Model.ArchiveNo = txtNum;
            Model.Month = month;
            Model.StaffName = txtName;
            Model.Year = year;
            var lst = BLL.GetList(this.SiteUserInfo.CompanyId, Model);
            if (null != lst && lst.Count > 0)
            {
                this.RepList.DataSource = lst;
                this.RepList.DataBind();
            }

        }

        /// <summary>
        /// 根据部门信息列表获取用半角逗号隔开的部门名称字符串
        /// </summary>
        /// <param name="lst">部门信息列表</param>
        /// <returns>半角逗号隔开的部门名称字符串</returns>
        protected string GetDeptNameByList(List<Department> lst)
        {
            var strRtn = string.Empty;
            if (lst != null)
            {
                strRtn = lst.Aggregate(strRtn, (current, m) => current + m.DepartName + ",");
            }
            return strRtn.TrimEnd(',');
        }

        /// <summary>
        /// 生成表头日期序号
        /// </summary>
        /// <returns></returns>
        protected String getMonthDays()
        {
            var str = new StringBuilder();
            if (year >= DateTime.MinValue.Year && year <= DateTime.MaxValue.Year && month >= DateTime.MinValue.Month && month <= DateTime.MaxValue.Month)
            {
                for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
                {
                    str.Append(String.Format("<td width=\"2%\"  height=\"28\" align=\"center\" bgcolor=\"#b7e0f3\">{0}</td>", i + 1));
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 主体表格
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        protected String getTables(object AttendanceList)
        {
            StringBuilder str = new StringBuilder();

            var BLL = new AttendanceInfo();
            var lst = (List<EyouSoft.Model.AdminCenterStructure.AttendanceInfo>)AttendanceList;
            var dic = new Dictionary<EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus, string>();
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.迟到, "<font color='#FF0000'><strong>迟</strong></font>");
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.出团, "<font color='#800080'><strong>团</strong></font>");
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.加班, "<font color='#0000FF'><strong>加</strong></font>");
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.旷工, "<font color='#6600CC'><strong>旷</strong></font>");
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.请假, "<font color='#FFA500'><strong>请</strong></font>");
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.准点, "<font color='#A9A9A9'>准</font>");
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.外出, "<font color='#00BFFF'><strong>外</strong></font>");
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.休假, "<font color='#00FF00'><strong>休</strong></font>");
            dic.Add(EyouSoft.Model.EnumType.AdminCenterStructure.WorkStatus.早退, "<font color='#008000'><strong>退</strong></font>");
            for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
            {
                if (null != lst && lst.Count > 0)
                {
                    StringBuilder s = new StringBuilder();
                    DateTime dtCurrent = Convert.ToDateTime(String.Format("{0}-{1}-{2}", year, month, i + 1));
                    var slst = (lst.Where(item => (item.AddDate.Date == dtCurrent)));
                    if (slst != null && slst.ToList().Count > 0)
                    {
                        str.Append(string.Format("<td>{0}</td>", dic[slst.ToList().First().WorkStatus]));
                    }
                    else
                    {
                        str.Append(string.Format("<td></td>"));
                    }
                }
                else
                {
                    str.Append(String.Format("<td></td>"));
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_考勤管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_考勤管理_栏目, false);
            }
        }
    }
}
