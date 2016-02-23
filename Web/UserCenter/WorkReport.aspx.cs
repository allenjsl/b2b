using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;


namespace Web.UserCenter
{
    public partial class WorkReport : EyouSoft.Common.Page.BackPage
    {

        /// <summary>
        /// 每页显示条数(常量)
        /// </summary>
        public int pageSize = 10;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int pageIndex = 0;
        /// <summary>
        /// 总记录条数
        /// </summary>
        private int recordCount = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Ajax for Delete
            string type = Utils.GetFormValue("Type");
            if (!string.IsNullOrEmpty(type))
            {
                if (type.Equals("Del"))
                {
                    Response.Clear();
                    Response.Write(Del(Utils.GetInt(Utils.GetFormValue("Id"))));
                    Response.End();
                }
            }

            if (!IsPostBack)
            {
                InitData();
            }

        }


        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitData()
        {
            EyouSoft.Model.PersonalCenterStructure.QueryWorkReport model = new EyouSoft.Model.PersonalCenterStructure.QueryWorkReport();
            model.Title = Utils.GetQueryStringValue("txtRTitle");
            model.OperatorName = Utils.GetQueryStringValue("txtRMan");
            model.CreateSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtRBeginData"));
            model.CreateEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtREndData"));
            model.DepartmentId = Utils.GetInt(Utils.GetQueryStringValue("ddlDepart"));
            model.CreateSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtRBeginData"));
            model.CreateEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtREndData"));

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            EyouSoft.BLL.PersonalCenterStructure.WorkReport bll = new EyouSoft.BLL.PersonalCenterStructure.WorkReport();
            IList<EyouSoft.Model.PersonalCenterStructure.WorkReport> list = bll.GetList(pageSize, pageIndex, ref  recordCount, SiteUserInfo.CompanyId, SiteUserInfo.UserId, model);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            this.rpWorkReport.DataSource = list;
            this.rpWorkReport.DataBind();

            BindPage();
        }

        /// <summary>
        /// 绑定部门
        /// </summary>
        /// <returns></returns>
        protected string BindDepartment(string selectItem)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value=''>-请选择部门-</option>");
            EyouSoft.BLL.CompanyStructure.Department bll = new EyouSoft.BLL.CompanyStructure.Department();
            IList<EyouSoft.Model.CompanyStructure.Department> list = bll.GetAllDept(SiteUserInfo.CompanyId, CurrentZxsId);
            if (list != null && list.Count != 0)
            {
                foreach (var item in list)
                {
                    if (item.Id.ToString().Equals(selectItem))
                    {
                        query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", item.Id, item.DepartName);
                    }
                    else
                    {
                        query.AppendFormat("<option value='{0}' >{1}</option>", item.Id, item.DepartName);
                    }
                }
            }
            return query.ToString();

        }


        protected string BingStatus(object obj)
        {
            string font = null;
            EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState status = (EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState)obj;
            if (status == EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState.已审核)
            {
                font = "<font>已审核</font>";
            }
            else
            {
                font = "<font color=\"#FF0000\">未审核</font>";
            }
            return font;
        }


        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion


        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string Del(int id)
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作汇报删除))
            {

                return UtilsCommons.AjaxReturnJson(
                       "0",
                       string.Format(
                           "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作汇报删除));

            }


            string msg = string.Empty;

            EyouSoft.BLL.PersonalCenterStructure.WorkReport bll = new EyouSoft.BLL.PersonalCenterStructure.WorkReport();
            int flg = bll.Delete(id);//1:删除成功 0:删除失败 -1已审核的不允许删除
            if (flg == 1)
            {
                msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "删除成功！");
            }
            else if (flg == -1)
            {
                msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "已审核的不允许删除！");
            }
            else
            {
                msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "删除失败！");
            }
            return msg;
        }
        #endregion
    }
}
