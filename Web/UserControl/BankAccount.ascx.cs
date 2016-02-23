using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Model.CompanyStructure;
using System.Collections.Generic;

namespace Web.UserControl
{
    public partial class BankAccount : System.Web.UI.UserControl
    {
        /// <summary>
        /// 设置控件的数据源
        /// </summary>
        private IList<UserBank> _setTravelList;

        public IList<UserBank> SetTravelList
        {
            get { return _setTravelList; }
            set { _setTravelList = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDataList();
            }
        }

        /// <summary>
        /// 页面初始化时绑定数据
        /// </summary>
        private void SetDataList()
        {
            if (this.SetTravelList != null && this.SetTravelList.Count > 0)
            {
                this.rptlist.DataSource = this.SetTravelList;
                this.rptlist.DataBind();
                this.phdefault.Visible = false;
            }
            else
            {
                this.phdefault.Visible = true;
            }

        }
    }
}