using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class LoanList : EyouSoft.Common.Page.BackPage
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
            pageIndex = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("page"), 1);

            EyouSoft.Model.FinStructure.MJieKuanChaXunInfo model = new EyouSoft.Model.FinStructure.MJieKuanChaXunInfo();
            model.JieKuanRenId = SiteUserInfo.UserId;
            decimal[] obj = null;

            EyouSoft.BLL.FinStructure.BJieKuan bll = new EyouSoft.BLL.FinStructure.BJieKuan();

            IList<EyouSoft.Model.FinStructure.MJieKuanInfo> list = bll.GetJieKuans(SiteUserInfo.CompanyId, pageSize, pageIndex, ref  recordCount, model, out obj);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            this.rpLoan.DataSource = list;
            this.rpLoan.DataBind();
            if (obj != null)
            {
                this.ltTotal.Text = obj[0].ToString("c");
            }

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
