using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.TongJi
{
    /// <summary>
    /// 统计分析-积分发放结算明细表
    /// </summary>
    public partial class JiFenJieSuanMingXi : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 结算登记权限
        /// </summary>
        bool Privs_JieSuanDengJi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_积分发放结算统计表_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_JieSuanDengJi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_积分发放结算统计表_结算收款登记);
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiChaXunInfo();

            info.QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate1"));
            info.QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate2"));

            info.FaFangShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtFaFangShiJian1"));
            info.FaFangShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtFaFangShiJian2"));

            info.JieSuanShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtJieSuanShiJian1"));
            info.JieSuanShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtJieSuanShiJian2"));

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            pageIndex = UtilsCommons.GetPagingIndex();

            var chaXun = GetChaXunInfo();
            int recordCount = 0;
            object[] heJi;
            var items = new EyouSoft.BLL.TongJiStructure.BJiFen().GetJiFenFaFangJieSuanMingXis(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                ltrYouXiaoJiFenHeJi.Text = heJi[0].ToString();
                ltrDongJieJiFenHeJi.Text = heJi[1].ToString();
                ltrQuXiaoJiFenHeJi.Text = heJi[2].ToString();
                ltrJieSuanJiFenHeJi.Text = heJi[3].ToString();
                ltrWeiJieSuanJiFenHeJi.Text = ((int)heJi[0] - (int)heJi[3]).ToString();

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
                phHeJi.Visible = false;
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml()
        {
            string s = string.Empty;

            if (Privs_JieSuanDengJi) s += "<a href=\"javascript:void(0)\" class=\"i_dengji\">收款登记</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_dengji\" data-chakan=\"1\">查看收款</a> ";

            return s.ToString();
        }
        #endregion
    }
}