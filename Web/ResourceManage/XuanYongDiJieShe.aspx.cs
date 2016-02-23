//地接社选用  汪奇志 2015-05-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.ResourceManage
{
    /// <summary>
    /// 地接社选用
    /// </summary>
    public partial class XuanYongDiJieShe : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageIndex = 0;
        protected int pageSize = 20;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteUserInfo.ZxsT1 != EyouSoft.Model.EnumType.PtStructure.ZxsT1.主专线商) { Utils.RCWE("异常请求"); }

            InitZxs();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.GysStructure.MXuanYongGysChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.GysStructure.MXuanYongGysChaXunInfo();

            info.GysName = Utils.GetQueryStringValue("txtGysName");
            info.ChengShiId = Utils.GetIntNull(Utils.GetQueryStringValue("txtChengShi"));
            info.LxrName = Utils.GetQueryStringValue("txtLxrName");
            info.ShengFenId = Utils.GetIntNull(Utils.GetQueryStringValue("txtShengFen"));
            info.LeiXing = EyouSoft.Model.EnumType.CompanyStructure.SupplierType.地接;
            info.ZxsId = Utils.GetQueryStringValue("txtZxs");

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();

            var items = new EyouSoft.BLL.GysStructure.BGysZhuTi().GetXuanYongGyss(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                FenYe.intPageSize = pageSize;
                FenYe.CurrencyPage = pageIndex;
                FenYe.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// init zxs options
        /// </summary>
        void InitZxs()
        {
            var chaXun =new EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo();

            var items = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetZxss1(CurrentUserCompanyID, chaXun);
            StringBuilder s = new StringBuilder();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.ZxsId, item.MingCheng);
                }
            }
            ltrZxs.Text = s.ToString();
        }
        #endregion
    }
}
