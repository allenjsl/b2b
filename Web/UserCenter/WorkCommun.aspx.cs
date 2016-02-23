using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;


namespace Web.UserCenter
{
    public partial class WorkCommun : EyouSoft.Common.Page.BackPage
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
        /// <summary>
        /// 权限-栏目
        /// </summary>
        bool Privs_LanMu = false;
        /// <summary>
        /// 权限-删除
        /// </summary>
        bool Privs_ShanChu = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            string dotype = Utils.GetQueryStringValue("dotype");

            switch (dotype)
            {
                case "shanchu": ShanChu(); break;
                default: break;
            }

            InitData();
        }

        void InitPrivs()
        {
            Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_栏目);
            Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作交流栏目);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作交流删除);

            if (!Privs_LanMu) { Utils.RCWE("没有权限"); }
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitData()
        {
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            EyouSoft.Model.PersonalCenterStructure.WorkExchangeSearch search = new EyouSoft.Model.PersonalCenterStructure.WorkExchangeSearch();
            search.Title = Utils.GetQueryStringValue("txtTitle");
            search.Type = !string.IsNullOrEmpty(Utils.GetQueryStringValue("ddlType")) ? (EyouSoft.Model.EnumType.PersonalCenterStructure.ExchangeType?)Utils.GetInt(Utils.GetQueryStringValue("ddlType")) : null;
            search.CBeginDate = !string.IsNullOrEmpty(Utils.GetQueryStringValue("LBeginDate")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LBeginDate")) : null;
            search.CEndDate = !string.IsNullOrEmpty(Utils.GetQueryStringValue("LEndDate")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("LEndDate")) : null;
            search.ZxsId = CurrentZxsId;

            EyouSoft.BLL.PersonalCenterStructure.WorkExchange bll = new EyouSoft.BLL.PersonalCenterStructure.WorkExchange();
            IList<EyouSoft.Model.PersonalCenterStructure.WorkExchange> list = bll.GetList(pageSize, pageIndex, ref recordCount, SiteUserInfo.CompanyId, 0, search);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            this.rpCommun.DataSource = list;
            this.rpCommun.DataBind();

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

        /// <summary>
        /// 绑定状态
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindStatus(string selectItem)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value=''>请选择交流类别...</option>");
            Array values = Enum.GetValues(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.ExchangeType));
            if (values != null)
            {
                foreach (var item in values)
                {
                    int value = (int)Enum.Parse(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.ExchangeType), item.ToString());
                    string text = Enum.GetName(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.ExchangeType), item);
                    if (value.ToString().Equals(selectItem))
                    {
                        query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", value, text);
                    }
                    else
                    {
                        query.AppendFormat("<option value='{0}' >{1}</option>", value, text);

                    }
                }
            }
            return query.ToString();
        }


        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        void ShanChu()
        {
            if (!Privs_ShanChu) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "没有操作权限"));

            int txtId = Utils.GetInt(Utils.GetFormValue("txtId"));

            if (new EyouSoft.BLL.PersonalCenterStructure.WorkExchange().Delete(txtId))
            {
                Utils.RCWE( EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "操作成功！"));
            }
            else
            {
                Utils.RCWE( EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "操作失败！"));
            }
        }
        #endregion
    }
}
