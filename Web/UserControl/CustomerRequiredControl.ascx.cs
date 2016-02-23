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
using System.Collections.Generic;
using EyouSoft.Model.TourStructure;
using EyouSoft.Model.CompanyStructure;

namespace Web.UserControl
{
    public partial class CustomerRequiredControl : System.Web.UI.UserControl
    {
        private IList<MTourOrderHotelPlan> _setPlanList;
        public IList<MTourOrderHotelPlan> SetPlanList
        {
            get { return _setPlanList; }
            set { _setPlanList = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SetPlanList != null && SetPlanList.Count > 0)
                {
                    this.rptList.DataSource = SetPlanList;
                    this.rptList.DataBind();
                    this.PhDefaultTr.Visible = false;
                }
            }
        }
        private string _kongweiid = string.Empty;
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongweiId
        {
            get { return _kongweiid; }
            set { this._kongweiid = value; }
        }
        /// <summary>
        /// 获取供应商联系人(对方操作人)
        /// </summary>
        /// <param name="OperatorId">操作人编号</param>
        /// <param name="gysid">供应商编号</param>
        /// <returns></returns>
        protected string GetOperator(string OperatorId, string gysid)
        {
            EyouSoft.BLL.CompanyStructure.CompanySupplier bll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
            IList<EyouSoft.Model.CompanyStructure.SupplierContact> list = bll.GetSupplierContactById(gysid);
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            if (list != null && list.Count > 0)
            {
                str.Append("<option value='-1'>请选择联系人</option>");
                for (int i = 0; i < list.Count; i++)
                {
                    if (OperatorId == list[i].Id.ToString())
                        str.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].Id.ToString(), list[i].ContactName);
                    else
                        str.AppendFormat("<option value='{0}'>{1}</option>", list[i].Id.ToString(), list[i].ContactName);
                }
            }
            else
            {
                str.Append("<option value='-1'>请选择供应商</option>");
            }
            return str.ToString();

            
        }
    }
}