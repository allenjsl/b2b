using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.CommonPage
{
    /// <summary>
    /// 线路选用页面
    /// </summary>
    public partial class SelectRoute : EyouSoft.Common.Page.BackPage
    {
        private const int PageSize = 20;

        private int _pageIndex = 1;

        private int _recordCount;

        protected int IsSelectMore;
        protected string ZhuangTai = string.Empty;
        protected string LeiXing = string.Empty;
        protected string QuYuId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            IsSelectMore = Utils.GetInt(Utils.GetQueryStringValue("isMore"));
            InitQuYu();

            if (!IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            IsSelectMore = Utils.GetInt(Utils.GetQueryStringValue("isMore"));
            _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            var chaXun = new EyouSoft.Model.TourStructure.MSearchRoute();
            chaXun.AreaId = Utils.GetInt(Utils.GetQueryStringValue("txtQuYu"));
            chaXun.RouteName = Utils.GetQueryStringValue("txtRouteName");
            chaXun.StartDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtTime1"));
            chaXun.EndDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtTime2"));
            chaXun.ZhengCeStatus = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus), Utils.GetQueryStringValue("txtZhengCeStatus"));
            chaXun.ZxsId = CurrentZxsId;
            chaXun.LeiXing = (EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing), Utils.GetQueryStringValue("txtLeiXing"));

            if (Utils.GetQueryStringValue("iscx") != "1")
            {
                chaXun.ZhengCeStatus = EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.正常;
                chaXun.LeiXing = EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing.常规旅游;
            }

            if (chaXun.ZhengCeStatus.HasValue)
            {
                ZhuangTai = ((int)chaXun.ZhengCeStatus.Value).ToString();
            }

            if (chaXun.LeiXing.HasValue)
            {
                LeiXing = ((int)chaXun.LeiXing.Value).ToString();
            }

            if (chaXun.AreaId > 0) QuYuId = chaXun.AreaId.ToString();

            IList<EyouSoft.Model.TourStructure.MPageRoute> list = new EyouSoft.BLL.TourStructure.BRoute().GetRouteList(CurrentUserCompanyID, PageSize, _pageIndex, ref _recordCount, chaXun);
            if (list != null && list.Count > 0)
            {
                rptRoute.DataSource = list;
                rptRoute.DataBind();
            }


            page1.CurrencyPage = _pageIndex;
            page1.intPageSize = PageSize;
            page1.intRecordCount = _recordCount;
        }

        /// <summary>
        /// 生成选择框的html
        /// </summary>
        /// <param name="objId">编号</param>
        /// <param name="objName">名称</param>
        /// <param name="index">数据项索引</param>
        /// <param name="status">政策状态</param>
        /// <returns></returns>
        protected string GetInputHtml(object objId, object objName, int index,object status)
        {
            if (objId == null || objName == null || string.IsNullOrEmpty(objId.ToString())) return string.Empty;

            bool isCheck = false;

            string initId = Utils.GetQueryStringValue("initId");
            if (!string.IsNullOrEmpty(initId))
            {
                string[] tmpId = initId.Split(',');
                if (tmpId.Length > 0)
                {
                    isCheck = tmpId.Contains(objId);
                }
            }

            if (status == null) status = EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.正常;
            var _status = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)status;

            string routeName = string.Empty;
            if (objName != null) routeName = objName.ToString();

            if (_status == EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.已过期)
            {
                routeName = "<span style=\"color:#666\" title=\"已过期\">" + objName.ToString() + "</span>";
            }

            if (IsSelectMore == 1)
            {
                return
                    string.Format(
                        "<input type=\"checkbox\" name=\"ckbRoute\" {3} value=\"{0}\" data-name=\"{1}\" id=\"ckbRoute{2}\" i_status=\"{4}\" /><label for=\"ckbRoute{2}\">{5}</label>",
                        objId.ToString(),
                        objName,
                        index,
                        isCheck ? "checked" : string.Empty
                        , (int)_status
                        , routeName);
            }

            return
                string.Format(
                    "<input type=\"radio\" name=\"radRoute\" {3} value=\"{0}\" data-name=\"{1}\" id=\"radRoute{2}\" i_status=\"{4}\" /><label for=\"radRoute{2}\">{5}</label>",
                    objId.ToString(),
                    objName,
                    index,
                    isCheck ? "checked" : string.Empty
                    , (int)_status
                    , routeName);
        }

        /// <summary>
        /// 计算行索引
        /// </summary>
        /// <param name="index">循环项索引</param>
        /// <returns></returns>
        protected string GetTrHtml(int index)
        {
            if (index != 0 && index % 4 == 0)
            {
                string strHtm = "</tr><tr class=\"{0}\">";
                string strColor = "odd";
                int t = index / 4;
                if (t % 2 != 0)
                {
                    strColor = "even";
                }

                return string.Format(strHtm, strColor);
            }

            return string.Empty;
        }

        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetZxsZhanDians(CurrentZxsId);

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<option value=\"\">请选择</option>");

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var item1 in item.Zxlbs)
                    {
                        s.AppendFormat("<optgroup label=\"{0}\">", item.ZhanDianName + "站-" + item1.ZxlbName);

                        foreach (var item2 in item1.QuYus)
                        {
                            s.AppendFormat("<option value=\"{0}\">{1}</option>", item2.QuYuId, item2.QuYuName);
                        }

                        s.AppendFormat("</optgroup>");
                    }
                }
            }

            ltrQuYuOption.Text = s.ToString();
        }
    }
}
