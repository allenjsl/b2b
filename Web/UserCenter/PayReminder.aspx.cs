using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class PayReminder : EyouSoft.Common.Page.BackPage
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
            #region 栏目权限判断
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
            #endregion

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
            EyouSoft.Model.PersonalCenterStructure.FuKuanTiXingChaXun model = new EyouSoft.Model.PersonalCenterStructure.FuKuanTiXingChaXun();
            model.ShouKuanDanWei = Utils.GetQueryStringValue("BuyCustomerName");
            model.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LBeginDate"));
            model.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LEndDate"));
            model.ZxsId = CurrentZxsId;
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            EyouSoft.BLL.PersonalCenterStructure.TranRemind bll = new EyouSoft.BLL.PersonalCenterStructure.TranRemind();
            IList<EyouSoft.Model.PersonalCenterStructure.MFuKuanTiXingInfo> list = bll.GetFuKuanTiXings(pageSize, pageIndex, ref  recordCount, SiteUserInfo.CompanyId, model);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            this.rpRemind.DataSource = list;
            this.rpRemind.DataBind();

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
    }
}
