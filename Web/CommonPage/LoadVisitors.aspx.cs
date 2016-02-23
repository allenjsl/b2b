using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CommonPage
{
    public partial class LoadVisitors : EyouSoft.Common.Page.BackPage
    {
        /// <summary>
        /// OnPreInit事件 设置模式窗体属性
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.CompanyID = SiteUserInfo.CompanyId;
        }
    }
}
