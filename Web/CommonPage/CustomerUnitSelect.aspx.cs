/*
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
using EyouSoft.Model.EnumType.CompanyStructure;

namespace Web.CommonPage
{
    /// <summary>
    /// 客户单位选用页面
    /// </summary>
    public partial class CustomerUnitSelect : EyouSoft.Common.Page.BackPage
    {
        private const int PageSize = 8;

        private int _pageIndex = 1;

        private int _recordCount;

        protected int IsSelectMore;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            int pid = Utils.GetInt(Utils.GetQueryStringValue("pid"));
            int cid = Utils.GetInt(Utils.GetQueryStringValue("cid"));
            string cname = Utils.GetQueryStringValue("cname");
            string ccname = Utils.GetQueryStringValue("ccname");
            string tel = Utils.GetQueryStringValue("tel");
            IsSelectMore = Utils.GetInt(Utils.GetQueryStringValue("isMore"));
            _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            var search = new EyouSoft.Model.CompanyStructure.MCustomerSeachInfo
            {
                CustomerName = cname,
                ContactName = ccname,
                ContactTelephone = tel,
                ProvinceIds = null,
                CityIdList = null,
                OrderByType = 2
            };
            if (pid > 0) search.ProvinceIds = new[] { pid };
            if (cid > 0) search.CityIdList = new[] { cid };

            search.KeHuLeiXing = (CustomerType?)Utils.GetEnumValueNull(typeof(CustomerType), Utils.GetQueryStringValue("txtKeHuLeiXing"));

            IList<EyouSoft.Model.CompanyStructure.CustomerInfo> list = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomers(CurrentUserCompanyID, PageSize, _pageIndex, ref _recordCount, search);
            if (list != null && list.Count > 0)
            {
                rptCustomer.DataSource = list;
                rptCustomer.DataBind();
            }


            page1.CurrencyPage = _pageIndex;
            page1.intPageSize = PageSize;
            page1.intRecordCount = _recordCount;

            //txtTel.Value = tel;
            txtContact.Value = ccname;
            txtCustomer.Value = cname;
        }

        /// <summary>
        /// 获取input选择框
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="contactName"></param>
        /// <param name="phone"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        protected string GetInputHtml(object id, object name, object contactName, object phone, object mobile)
        {
            bool isCheck = false;

            string initId = Utils.GetQueryStringValue("initId");
            if (!string.IsNullOrEmpty(initId))
            {
                string[] tmpId = initId.Split(',');
                if (tmpId.Length > 0)
                {
                    isCheck = tmpId.Contains(id.ToString());
                }
            }

            if (IsSelectMore == 1)
            {
                return
                    string.Format(
                        "<input type=\"checkbox\" class=\"c1\" data-value=\"{0}\" value=\"{0}\" name=\"ckbCId\" data-cname=\"{1}\" data-ccname=\"{2}\" data-tel=\"{3}\" data-mobile=\"{4}\" {5} />",
                        id.ToString(),
                        name.ToString(),
                        contactName.ToString(),
                        phone.ToString(),
                        mobile.ToString(),
                        isCheck ? "checked" : string.Empty);
            }

            return string.Format(
                        "<input type=\"radio\" class=\"c1\" data-value=\"{0}\" value=\"{0}\" name=\"radCId\" data-cname=\"{1}\" data-ccname=\"{2}\" data-tel=\"{3}>\" data-mobile=\"{4}\" {5} />",
                        id.ToString(),
                        name.ToString(),
                        contactName.ToString(),
                        phone.ToString(),
                        mobile.ToString(),
                        isCheck ? "checked" : string.Empty);
        }

        /// <summary>
        /// 获取客户的联系人信息集合(json格式)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetContactList(object obj)
        {
            if (obj == null) return string.Empty;

            var list = (List<EyouSoft.Model.CompanyStructure.CustomerContactInfo>)obj;
            if (!list.Any()) return string.Empty;

            var str = new System.Text.StringBuilder();
            str.Append("[");
            for (int i = 0; i < list.Count; i++)
            {
                str.Append(i == 0 ? "{" : ",{");
                str.AppendFormat("\"ccId\":\"{0}\"", list[i].ContactId);
                str.AppendFormat(",\"ccname\":\"{0}\"", list[i].Name);
                str.Append("}");
            }
            str.Append("]");

            return str.ToString();
        }
    }
}
*/
