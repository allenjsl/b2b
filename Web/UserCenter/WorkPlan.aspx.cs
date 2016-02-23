using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class WorkPlan : EyouSoft.Common.Page.BackPage
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
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            EyouSoft.Model.PersonalCenterStructure.QueryWorkPlan model = new EyouSoft.Model.PersonalCenterStructure.QueryWorkPlan();
            model.Title = Utils.GetQueryStringValue("txtTitle");
            model.OperatorName = Utils.GetQueryStringValue("txtName");
            model.Status = !string.IsNullOrEmpty(Utils.GetQueryStringValue("ddlStatus")) ? (EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState?)Utils.GetInt(Utils.GetQueryStringValue("ddlStatus")) : null;
            model.SYuJiTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LBeginDate"));
            model.EYuJiTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LEndDate"));

            EyouSoft.BLL.PersonalCenterStructure.WorkPlan bll = new EyouSoft.BLL.PersonalCenterStructure.WorkPlan();
            IList<EyouSoft.Model.PersonalCenterStructure.WorkPlan> list = bll.GetList(pageSize, pageIndex, ref recordCount, SiteUserInfo.CompanyId, 0, model);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            this.rpPlan.DataSource = list;
            this.rpPlan.DataBind();

            BindPage();

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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作计划删除))
            {
                return UtilsCommons.AjaxReturnJson(
                        "0",
                        string.Format(
                            "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作计划删除));
            }

            string msg = string.Empty;
            EyouSoft.BLL.PersonalCenterStructure.WorkPlan bll = new EyouSoft.BLL.PersonalCenterStructure.WorkPlan();
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


        /// <summary>
        /// 绑定状态
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindStatus(string selectItem)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value=''>-请选择-</option>");
            //EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState
            Array values = Enum.GetValues(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState));
            foreach (var item in values)
            {
                int value = (int)Enum.Parse(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState), item.ToString());
                string text = Enum.GetName(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState), item);
                if (value.ToString().Equals(selectItem))
                {
                    query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", value, text);
                }
                else
                {
                    query.AppendFormat("<option value='{0}' >{1}</option>", value, text);

                }
            }
            return query.ToString();

        }




    }
}
