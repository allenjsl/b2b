//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-应付交通费
    /// </summary>
    public partial class YingFuJiaoTong : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_应付交通费_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_应付交通费_栏目, true);
            }
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            object[] heJi;

            var items = new EyouSoft.BLL.FinStructure.BFin().GetYingFuJiaoTong(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrJieSuanJinEHeJi.Text = ToMoneyString(heJi[1]);
                ltrYiZhiFuJinEHeJi.Text = ToMoneyString(heJi[2]);
                ltrWeiFuJinEHeJi.Text = ToMoneyString((decimal)heJi[1] - (decimal)heJi[2]);

                rpts.Visible = phHeJi.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                rpts.Visible = phHeJi.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.FinStructure.MYingFuChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MYingFuChaXunInfo();

            info.GysJiaoYiHao = Utils.GetQueryStringValue("txtGysJiaoYiHao");
            info.GysName = Utils.GetQueryStringValue("txtGysName");
            info.JiaoYiHao = Utils.GetQueryStringValue("txtJiaoYiHao");
            info.KongWeiCode = Utils.GetQueryStringValue("txtKongWeiCode");
            info.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLEDate"));
            info.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLSDate"));
            info.YingFuJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtYingFuJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.YingFuJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtYingFuJinE"));
            info.JieQingStatus = Utils.GetIntNull(Utils.GetQueryStringValue("txtJieQingStatus"));
            info.QuJiaoTongId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuJiaoTongId"));
            info.ZxsId = CurrentZxsId;

            info.PaiXuLeiXing = Utils.GetInt(Utils.GetQueryStringValue("paixuleixing"));

            return info;
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取游客列表html
        /// </summary>
        /// <param name="obj">游客列表</param>
        /// <returns></returns>
        protected string GetYouKeMxHtml(object obj)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'>");
            s.Append("<tr class='pp-table-title'><th>姓名</th><th>性别</th><th>类型</th><th>证件类型</th><th>证件号码</th><th>联系方式</th></tr>");

            IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> items = (IList<EyouSoft.Model.TourStructure.MTourOrderTraveller>)obj;

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>",
                        item.TravellerName
                        , item.Sex.ToString()
                        , item.TravellerType.ToString()
                        , item.CardType.ToString()
                        , item.CardNumber.ToString()
                        , item.Contact);
                }
            }
            else
            {
                s.Append("<tr><td colspan='6'>无消费明细信息</td></tr>");
            }

            s.Append("</table>");

            return s.ToString();
        }

        /// <summary>
        /// 获取去程交通下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetQuJiaoTongOptions()
        {
            int _quJiaoTongId = Utils.GetInt(Utils.GetQueryStringValue("txtQuJiaoTong"));
            StringBuilder s = new StringBuilder();

            var items = new EyouSoft.BLL.CompanyStructure.BCompanyTraffic().GetList(CurrentUserCompanyID);

            s.Append("<option value=\"\">-请选择-</option>");

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item.TrafficId, item.TrafficId == _quJiaoTongId ? "selected=\"selected\"" : "", item.TrafficName);
                }
            }

            return s.ToString();
        }
        #endregion
    }
}
