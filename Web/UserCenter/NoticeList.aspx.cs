using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserCenter
{
    public partial class NoticeList : EyouSoft.Common.Page.BackPage
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
            InitData();
        }

        private void InitData()
        {
            pageIndex = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("page"), 1);

            EyouSoft.BLL.CompanyStructure.News bll = new EyouSoft.BLL.CompanyStructure.News();
            IList<EyouSoft.Model.PersonalCenterStructure.NoticeNews> list = bll.GetAcceptNews(pageSize, pageIndex, ref recordCount, SiteUserInfo.UserId, SiteUserInfo.CompanyId,CurrentZxsId);

            this.rpNotice.DataSource = list;
            this.rpNotice.DataBind();

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
