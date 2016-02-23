using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class UserMemo : EyouSoft.Common.Page.BackPage
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

            //权限判断
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_个人备忘_栏目))
            {
                this.RCWE(
                    UtilsCommons.AjaxReturnJson(
                        "0",
                        string.Format(
                            "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_个人备忘_栏目)));
                return;
            }
          

         
           

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

        protected void InitData()
        {
            EyouSoft.Model.PersonalCenterStructure.UserMemoSearch model = new EyouSoft.Model.PersonalCenterStructure.UserMemoSearch();
            model.Title = Utils.GetQueryStringValue("txtTitle");
            model.MemoTimeS = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtMBeginDate"));
            model.MemoTimeE = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtMEndDate"));
            model.ZxsId = CurrentZxsId;

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            EyouSoft.BLL.PersonalCenterStructure.BUserMemo bll = new EyouSoft.BLL.PersonalCenterStructure.BUserMemo();
            IList<EyouSoft.Model.PersonalCenterStructure.UserMemorandum> list = bll.GetLst(pageSize, pageIndex, ref  recordCount, SiteUserInfo.CompanyId, 0, model);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            this.rpMemo.DataSource = list;
            this.rpMemo.DataBind();

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

            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_个人备忘_删除))
            {

                return UtilsCommons.AjaxReturnJson(
                         "0",
                         string.Format(
                             "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_个人备忘_删除));
            }

            EyouSoft.BLL.PersonalCenterStructure.BUserMemo bll = new EyouSoft.BLL.PersonalCenterStructure.BUserMemo();
            if (bll.Del(id))
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "删除成功！");
            }
            else
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "删除失败！");
            }
        }
        #endregion


        /// <summary>
        /// 绑定状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string BindStatus(object obj) {
          
            EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState status = (EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState)obj;
            if (status == EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState.未完成)
            {
                return "<font color='Red'>未完成</font>";
            }
            else {
                return "已完成";
            }
        }


    }
}
