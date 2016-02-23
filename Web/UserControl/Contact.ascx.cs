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
using EyouSoft.Common;
using System.Collections.Generic;
using EyouSoft.Model.CompanyStructure;

namespace Web.UserControl
{
    public partial class Contact : System.Web.UI.UserControl
    {
        /// <summary>
        /// 设置控件的数据源
        /// </summary>
        private IList<SupplierContact> _setTravelList;

        public IList<SupplierContact> SetTravelList
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
                this.rptList.DataSource = this.SetTravelList;
                this.rptList.DataBind();
                this.ph_showorhide.Visible = false;
            }
            else
            {
                this.ph_showorhide.Visible = true;
            }

        }
    }
}