using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Model.EnumType.PrivsStructure;
using EyouSoft.Common;

namespace Web.ManageCenter
{
    using EyouSoft.Model.CompanyStructure;

    /// <summary>
    /// 行政中心_考勤管理列表
    /// 郑知远 2012-11-26
    /// </summary>
    public partial class WorkCheckList : BackPage
    {
        #region 分页参数
        /// <summary>
        /// 每页显示条数(常量)
        /// </summary>
        /// 当变量需要在前台使用时可换成protected修饰
        protected int pageSize = 20;
        /// <summary>
        /// 当前页数
        /// </summary>
        ///  当变量需要在前台使用时可换成protected修饰
        protected int pageIndex = 0;
        /// <summary>
        /// 总记录条数
        /// </summary>
        ///  当变量需要在前台使用时可换成protected修饰
        public int recordCount = 0;
        /// <summary>
        /// 新增权限
        /// </summary>
        public bool IsAddGrant;
        /// <summary>
        /// 修改权限
        /// </summary>
        public bool IsUpdGrant;
        /// <summary>
        /// 删除权限
        /// </summary>
        public bool IsDelGrant;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.ITitle = "考勤管理_行政中心";

            //权限初始化
            this.InitGrant();

            //页面初始化
            this.PageInit();
        }

        /// <summary>
        /// 权限初始化
        /// </summary>
        void InitGrant()
        {
            if (!this.CheckGrant(Privs3.行政中心_考勤管理_栏目))
            {
                Utils.ResponseNoPermit(Privs3.行政中心_考勤管理_栏目, false);
                return;
            }

            //操作权限
            IsAddGrant = CheckGrant(Privs3.行政中心_考勤管理_登记);
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void PageInit()
        {
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            var strArchiveNo = Utils.GetQueryStringValue("txtArchiveNo");
            var strStaffName = Utils.GetQueryStringValue("txtStaffName");
            var strDeptId = Utils.GetQueryStringValue(this.SelectSection1.SelectIDClient);
            var strDeptNm = Utils.GetQueryStringValue(this.SelectSection1.SelectNameClient);
            this.SelectSection1.SectionID = strDeptId;
            this.SelectSection1.SectionName = strDeptNm;

            var items = new EyouSoft.BLL.AdminCenterStructure.AttendanceInfo().GetList(pageSize, pageIndex, ref recordCount, strArchiveNo, strStaffName, Utils.GetInt(strDeptId, 0), strDeptNm, CurrentUserCompanyID);
            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rptLst.DataSource = items;
                rptLst.DataBind();
            }

            BindPage();

        }

        /// <summary>
        /// 绑定分页
        /// </summary>
        private void BindPage()
        {            
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;

            if (this.ExporPageInfoSelect1.intRecordCount == 0)
            {
                this.ExporPageInfoSelect1.Visible = false;
                this.phEmpty.Visible = true;
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
            if (lst!=null)
            {
                strRtn = lst.Aggregate(strRtn, (current, m) => current + m.DepartName + ",");
            }
            return strRtn.TrimEnd(',');
        }
    }
}
