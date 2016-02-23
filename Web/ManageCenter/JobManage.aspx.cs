using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.ManageCenter
{
    public partial class JobManage : BackPage
    {
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.ITitle = "职务管理_行政中心";
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
            EyouSoft.BLL.AdminCenterStructure.DutyManager bllduty = new EyouSoft.BLL.AdminCenterStructure.DutyManager();
            IList<EyouSoft.Model.AdminCenterStructure.DutyManager> List = bllduty.GetList(pageSize, pageIndex, ref recordCount, this.SiteUserInfo.CompanyId);
            if (List != null && List.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.rptList.DataSource = List;
                this.rptList.DataBind();
                BindExportPage();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='6' align='center'>暂无职务信息!</td></tr>";
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
                if (this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_职务管理_删除))
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
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private string DeleteData(string id)
        {
            if (!String.IsNullOrEmpty(id) && Utils.GetInt(id) > 0)
            {
                EyouSoft.BLL.AdminCenterStructure.DutyManager bllduty = new EyouSoft.BLL.AdminCenterStructure.DutyManager();
                if (bllduty.Delete(this.SiteUserInfo.CompanyId, Utils.GetInt(id)))
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
                return UtilsCommons.AjaxReturnJson("0", "职务信息错误!");
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
