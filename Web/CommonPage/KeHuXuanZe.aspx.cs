using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.CommonPage
{
    public partial class KeHuXuanZe : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var chaXun = GetChaXunInfo();

            int pageSize = 20;
            int pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;

            var items = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomers(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);
            if (items != null && items.Count > 0)
            {
                rptCustomer.DataSource = items;
                rptCustomer.DataBind();

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }

        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.MCustomerSeachInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.MCustomerSeachInfo();

            info.CustomerName = Utils.GetQueryStringValue("txtMingCheng");
            info.ContactName = Utils.GetQueryStringValue("txtLxrName");
            info.KeHuLeiXing = (EyouSoft.Model.EnumType.CompanyStructure.CustomerType?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.CompanyStructure.CustomerType), Utils.GetQueryStringValue("txtKeHuLeiXing"));

            var shengFenId = Utils.GetIntNull(Utils.GetQueryStringValue("txtShengFen"));
            var chengShiId = Utils.GetIntNull(Utils.GetQueryStringValue("txtChengShi"));

            if (shengFenId.HasValue) info.ProvinceIds = new[] { shengFenId.Value };
            if (chengShiId.HasValue) info.CityIdList = new[] { chengShiId.Value };

            info.OrderByType = 2;
            info.ShenHeStatus = EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.已审核;

            return info;
        }

        #endregion

        #region protected
        /// <summary>
        /// get lxr
        /// </summary>
        /// <param name="lxrs"></param>
        /// <returns></returns>
        protected string GetLxr(object lxrs)
        {
            if (lxrs == null) return "[]";

            var items = (List<EyouSoft.Model.CompanyStructure.CustomerContactInfo>)lxrs;

            if (items == null || items.Count == 0) return "[]";

            return Newtonsoft.Json.JsonConvert.SerializeObject(items);
        }
        #endregion
    }
}
