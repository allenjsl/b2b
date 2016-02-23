//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-预订酒店应付表
    /// </summary>
    public partial class YingFuJiuDian : BackPage
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_预订酒店应付费_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_预订酒店应付费_栏目, true);
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

            var items = new EyouSoft.BLL.FinStructure.BFin().GetYingFuJiuDian(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrJieSuanJinEHeJi.Text = ToMoneyString(heJi[0]);
                ltrYiZhiFuJinEHeJi.Text = ToMoneyString(heJi[1]);
                ltrWeiFuJinEHeJi.Text = ToMoneyString((decimal)heJi[0] - (decimal)heJi[1]);

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
            info.GysName = Utils.GetQueryStringValue("txtGysName");
            info.JiaoYiHao = Utils.GetQueryStringValue("txtJiaoYiHao");
            info.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLEDate"));
            info.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLSDate"));
            info.YingFuJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtYingFuJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.YingFuJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtYingFuJinE"));
            info.JieQingStatus = Utils.GetIntNull(Utils.GetQueryStringValue("txtJieQingStatus"));
            info.JiuDianName = Utils.GetQueryStringValue("txtJiuDianName");
            info.ZxsId = CurrentZxsId;

            info.PaiXuLeiXing = Utils.GetInt(Utils.GetQueryStringValue("paixuleixing"));

            return info;
        }
        #endregion
    }
}
