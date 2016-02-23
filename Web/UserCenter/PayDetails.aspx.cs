using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class PayDetails : EyouSoft.Common.Page.BackPage
    {

        /// <summary>
        /// 每页显示条数(常量)
        /// </summary>
        private int pageSize = 20;
        /// <summary>
        /// 当前页数
        /// </summary>
        private int pageIndex = 0;
        /// <summary>
        /// 总记录条数
        /// </summary>
        private int recordCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //判断栏目
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_事务提醒_付款提醒栏目))
            {
                this.RCWE(
                    UtilsCommons.AjaxReturnJson(
                        "0",
                        string.Format(
                            "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_事务提醒_付款提醒栏目)));
                return;
            }

            if (!IsPostBack)
            {
                InitData();
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            var supplierId = Utils.GetQueryStringValue("SupplierId");
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            var chaXun = new EyouSoft.Model.PersonalCenterStructure.FuKuanTiXingChaXun();
            chaXun.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LBeginDate"));
            chaXun.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LEndDate"));
            chaXun.ZxsId = CurrentZxsId;

            EyouSoft.BLL.PersonalCenterStructure.TranRemind bll = new EyouSoft.BLL.PersonalCenterStructure.TranRemind();
            var list = bll.GetFuKuanTiXingMxs(pageSize, pageIndex, ref  recordCount, supplierId, chaXun);
            this.rpPay.DataSource = list;
            this.rpPay.DataBind();
            BindPage();
        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
            this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
        }
        #endregion
    }
}
