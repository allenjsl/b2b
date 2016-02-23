using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.CompanyStructure;

namespace Web.UserControl
{
    public partial class BankContact : System.Web.UI.UserControl
    {

        /// <summary>
        /// 设置控件的数据源
        /// </summary>
        private IList<SupplierBank> _setTravelList;

        public IList<SupplierBank> SetTravelList
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
