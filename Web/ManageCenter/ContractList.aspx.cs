using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using EyouSoft.Common;
    using EyouSoft.Common.Page;
    using EyouSoft.Model.AdminCenterStructure;

    using ContractInfo = EyouSoft.BLL.AdminCenterStructure.ContractInfo;

    public partial class ContractList : BackPage
    {
        /// <summary>
        /// 页大小
        /// </summary>
        protected int pageSize = 20;
        /// <summary>
        /// 页码
        /// </summary>
        protected int pageIndex = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        private int recordCount = 0;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GrantInit();
            Master.ITitle = "劳动合同管理_行政中心";
            var doType = Utils.GetQueryStringValue("doType");
            //存在ajax请求
            if (!string.IsNullOrEmpty(doType))
            {
                AJAX(doType);
            }
            if (!IsPostBack)
            {
                this.PageInit();
            }
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        void PageInit()
        {
            var b = new ContractInfo();

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            var l = b.GetList(pageSize, pageIndex, ref recordCount, this.SiteUserInfo.CompanyId, this.GetSearchModel());
            if (null != l && l.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.RepList.DataSource = l;
                this.RepList.DataBind();
                if (recordCount <= pageSize)
                {
                    this.ExporPageInfoSelect1.Visible = false;
                }
                else
                {
                    BindPage();
                }
            }
            else
            {
                this.RepList.Controls.Add(new Label() { Text = "<tr><td colspan='8' align='center'>对不起，没有相关数据！</td></tr>" });
                this.ExporPageInfoSelect1.Visible = false;
            }
        }

        /// <summary>
        /// 权限初始化
        /// </summary>
        void GrantInit()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_栏目, false);
            }
            else
            {
                IsAddGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_新增);
                IsUpdGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_修改);
                IsDelGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_删除);
            }
        }

        #region ajax操作
        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType)
        {
            string msg = string.Empty;
            //对应执行操作
            if (doType == "delete")
            {
                string id = Utils.GetQueryStringValue("id");
                //执行并获取结果
                DeleteData(id);
            }
        }
        #endregion

        #region 删除操作
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private void DeleteData(string id)
        {
            bool b = false;
            string msg = string.Empty;
            if (IsDelGrant)
            {
                b = new ContractInfo().Delete(this.SiteUserInfo.CompanyId, Utils.GetInt(id));
                msg = b ? "删除成功！" : "删除失败！";
            }
            else
            {
                msg = "对不起，您没有删除权限！";
            }
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(b ? "1" : "0", msg));
            Response.End();
        }
        #endregion

        /// <summary>
        /// 获取页面搜索条件实体
        /// </summary>
        /// <returns>搜索条件实体</returns>
        ContractSearchInfo GetSearchModel()
        {
            var m = new ContractSearchInfo()
                {
                    StaffNo = Utils.GetQueryStringValue("txtStaffNo"),
                    StaffName = Utils.GetQueryStringValue("txtStaffName"),
                    BeginFrom = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtBeginDateF")),
                    BeginTo = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtBeginDateE")),
                    EndFrom = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndDateF")),
                    EndTo = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndDateE"))
                };
            return m;
        }

            #region 绑定分页
        /// <summary>
        /// 绑定分页
        /// </summary>
        private void BindPage()
        {            
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion
    }
}
