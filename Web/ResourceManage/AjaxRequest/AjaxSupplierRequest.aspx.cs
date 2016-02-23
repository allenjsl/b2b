using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Text;
using System.Collections;

namespace Web.ResourceManage.AjaxRequest
{
    public partial class AjaxSupplierRequest : BackPage
    {
        protected int pageSize = 24;
        protected int pageIndex = 0;
        protected int recordCount = 0;
        protected int listCount = 0;
        protected string NodataMsg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //省份
                string Provice = Utils.GetQueryStringValue("provice");
                //城市
                string City = Utils.GetQueryStringValue("city");
                //县区
                string Area = Utils.GetQueryStringValue("area");
                //名称
                string Name = Utils.GetQueryStringValue("name");
                ListDataInit(Provice, City, Area, Name);
            }
        }
        #region 初始化列表
        /// <summary>
        /// 列表数据初始化
        /// </summary>
        /// <param name="searchModel"></param>
        private void ListDataInit(string provice, string city, string area, string name)
        {
            //供应商BLL
            pageIndex = Utils.GetInt(Request.QueryString["Page"], 1);
            //供应商选用类别
            string type = Utils.GetQueryStringValue("type");
            EyouSoft.BLL.CompanyStructure.CompanySupplier bll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
            var proarr = new List<int>();
            var cityarr = new List<int>();
            switch (type.ToLower())
            {
                case "wineshop"://酒店
                    EyouSoft.Model.CompanyStructure.QuerySupplierHotel model = new EyouSoft.Model.CompanyStructure.QuerySupplierHotel();
                    model.Name = name;
                    if (Utils.GetInt(provice) != 0)
                    {
                        proarr.Add(Utils.GetInt(provice));
                    }
                    model.ProvinceId = proarr.ToArray();
                    if (Utils.GetInt(city) != 0)
                    {
                        cityarr.Add(Utils.GetInt(city));
                    }
                    model.CityId = cityarr.ToArray();
                    model.ZxsId = CurrentZxsId;
                    IList<EyouSoft.Model.CompanyStructure.SupplierHotel> list = bll.GetSupplierHotel(this.SiteUserInfo.CompanyId, pageSize, pageIndex, ref recordCount, model);
                    if (list != null && list.Count > 0)
                    {
                        RptList.DataSource = list;
                        RptList.DataBind();
                        BindPage();
                    }
                    else
                    {
                        lbemptymsg.Text = "<tr class='old'><td colspan='4' align='center'>没有相关数据</td></tr>";
                    }
                    break;

                case "ground"://地接社
                    EyouSoft.Model.CompanyStructure.QuerySupplierLocal localmodel = new EyouSoft.Model.CompanyStructure.QuerySupplierLocal();
                    localmodel.Name = name;
                    if (Utils.GetInt(provice) != 0)
                    {
                        proarr.Add(Utils.GetInt(provice));
                    }
                    localmodel.ProvinceId = proarr.ToArray();
                    if (Utils.GetInt(city) != 0)
                    {
                        cityarr.Add(Utils.GetInt(city));
                    }
                    localmodel.CityId = cityarr.ToArray();
                    localmodel.ZxsId = CurrentZxsId;
                    IList<EyouSoft.Model.CompanyStructure.SupplierLocal> locallist = bll.GetSupplierLocal(this.SiteUserInfo.CompanyId, pageSize, pageIndex, ref recordCount, localmodel);
                    if (locallist != null && locallist.Count > 0)
                    {
                        RptList.DataSource = locallist;
                        RptList.DataBind();
                        BindPage();
                    }
                    else
                    {
                        lbemptymsg.Text = "<tr class='old'><td colspan='4' align='center'>没有相关数据</td></tr>";
                    }
                    break;

                case "scenicspots"://景点
                    EyouSoft.Model.CompanyStructure.QuerySupplierSpot spotmodel = new EyouSoft.Model.CompanyStructure.QuerySupplierSpot();
                    spotmodel.Name = name;
                    if (Utils.GetInt(provice) != 0)
                    {
                        proarr.Add(Utils.GetInt(provice));
                    }
                    spotmodel.ProvinceId = proarr.ToArray();
                    if (Utils.GetInt(city) != 0)
                    {
                        cityarr.Add(Utils.GetInt(city));
                    }
                    spotmodel.CityId = cityarr.ToArray();
                    spotmodel.ZxsId = CurrentZxsId;
                    IList<EyouSoft.Model.CompanyStructure.SupplierSpot> spotlist = bll.GetSupplierSpot(this.SiteUserInfo.CompanyId, pageSize, pageIndex, ref recordCount, spotmodel);
                    if (spotlist != null && spotlist.Count > 0)
                    {
                        RptList.DataSource = spotlist;
                        RptList.DataBind();
                        BindPage();
                    }
                    else
                    {
                        lbemptymsg.Text = "<tr class='old'><td colspan='4' align='center'>没有相关数据</td></tr>";
                    }
                    break;
                case "ticket"://票务
                    EyouSoft.Model.CompanyStructure.QuerySupplierTicket ticketmodel = new EyouSoft.Model.CompanyStructure.QuerySupplierTicket();
                    ticketmodel.Name = name;
                    if (Utils.GetInt(provice) != 0)
                    {
                        proarr.Add(Utils.GetInt(provice));
                    }
                    ticketmodel.ProvinceId = proarr.ToArray();
                    if (Utils.GetInt(city) != 0)
                    {
                        cityarr.Add(Utils.GetInt(city));
                    }
                    ticketmodel.CityId = cityarr.ToArray();
                    ticketmodel.ZxsId = CurrentZxsId;
                    IList<EyouSoft.Model.CompanyStructure.SupplierTicket> ticketlist = bll.GetSupplierTicket(this.SiteUserInfo.CompanyId, pageSize, pageIndex, ref recordCount, ticketmodel);
                    if (ticketlist != null && ticketlist.Count > 0)
                    {
                        RptList.DataSource = ticketlist;
                        RptList.DataBind();
                        BindPage();
                    }
                    else
                    {
                        lbemptymsg.Text = "<tr class='old'><td colspan='4' align='center'>没有相关数据</td></tr>";
                    }
                    break;
                case "other"://其它
                    EyouSoft.Model.CompanyStructure.QuerySupplierOther othermodel = new EyouSoft.Model.CompanyStructure.QuerySupplierOther();
                    othermodel.Name = name;
                    if (Utils.GetInt(provice) != 0)
                    {
                        proarr.Add(Utils.GetInt(provice));
                    }
                    othermodel.ProvinceId = proarr.ToArray();
                    if (Utils.GetInt(city) != 0)
                    {
                        cityarr.Add(Utils.GetInt(city));
                    }
                    othermodel.CityId = cityarr.ToArray();
                    othermodel.ZxsId = CurrentZxsId;
                    IList<EyouSoft.Model.CompanyStructure.SupplierOther> otherlist = bll.GetSupplierOther(this.SiteUserInfo.CompanyId, pageSize, pageIndex, ref recordCount, othermodel);
                    if (otherlist != null && otherlist.Count > 0)
                    {
                        RptList.DataSource = otherlist;
                        RptList.DataBind();
                        BindPage();
                    }
                    else
                    {
                        lbemptymsg.Text = "<tr class='old'><td colspan='4' align='center'>没有相关数据</td></tr>";
                    }
                    break;

            }
            BindPage();
        }
        #endregion

        #region 设置分页
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.PageLinkURL = "/CommonPage/UseSupplier.aspx?";
            this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion
        /// <summary>
        /// 获取联系人信息
        /// </summary>
        /// <param name="linkManlist"></param>
        /// <returns></returns>
        protected string GetContactInfo(object linkManlist, string type, string sid, string sName)
        {
            IList<EyouSoft.Model.CompanyStructure.SupplierContact> list = (IList<EyouSoft.Model.CompanyStructure.SupplierContact>)linkManlist;
            StringBuilder stb = new System.Text.StringBuilder();
            switch (type)
            {
                case "name":
                    if (list != null && list.Count > 0)
                    {
                        stb.Append(list[0].ContactName);
                    }
                    break;
                case "tel":
                    if (list != null && list.Count > 0)
                    {
                        stb.Append(string.IsNullOrEmpty(list[0].ContactTel) ? list[0].ContactMobile : list[0].ContactTel);
                    }
                    break;
                case "fax":
                    if (list != null && list.Count > 0)
                    {
                        stb.Append(list[0].ContactFax);
                    }
                    break;
                case "list":
                    if (list != null && list.Count > 0)
                    {
                        stb.Append("<table style='z-index:9999' cellspacing='0' cellpadding='0' border='0' width='100%'class='pp-tableclass'><tr class='pp-table-title'><th width='25%' align='center'>联系人</th><th align='center' width='25%'>电话</th><th align='center' width='25%'>手机</th><th align='center' width='25%'>传真</th></tr>");
                        for (int i = 0; i < list.Count; i++)
                        {
                            stb.Append("<tr><td  width='25%' align='center'>" + list[i].ContactName + "</td><td align='center' width='25%'>" + list[i].ContactTel + "</td><td align='center' width='25%'>" + list[i].ContactMobile + "</td><td align='center' width='25%'>" + list[i].ContactFax + "</td></tr>");
                        }
                        stb.Append("</table>");
                    }
                    break;
            }
            return stb.ToString();
        }

        protected string GetContactInfo(object linkManlist, string type)
        {
            return GetContactInfo(linkManlist, type, "", "");
        }

        /// <summary>
        /// 获取客户的联系人信息集合(json格式)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetContactList(object obj)
        {
            if (obj == null) return string.Empty;

            var list = (List<EyouSoft.Model.CompanyStructure.SupplierContact>)obj;
            if (!list.Any()) return string.Empty;

            var str = new System.Text.StringBuilder();
            str.Append("[");
            for (int i = 0; i < list.Count; i++)
            {
                str.Append(i == 0 ? "{" : ",{");
                str.AppendFormat("\"ccId\":\"{0}\"", list[i].Id);
                str.AppendFormat(",\"ccname\":\"{0}\"", list[i].ContactName);
                str.Append("}");
            }
            str.Append("]");

            return str.ToString();
        }
    }
}
