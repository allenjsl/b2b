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
    /// 财务管理-应付地接费
    /// </summary>
    public partial class YingFuDiJie : BackPage
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_应付地接费_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_应付地接费_栏目, true);
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

            var items = new EyouSoft.BLL.FinStructure.BFin().GetYingFuDiJie(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);            

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrJieSuanJinEHeJi.Text = ToMoneyString(heJi[3]);
                ltrYiZhiFuJinEHeJi.Text = ToMoneyString(heJi[4]);
                ltrWeiFuJinEHeJi.Text = ToMoneyString((decimal)heJi[3] - (decimal)heJi[4]);
                ltrRenShuHeJi.Text = string.Format("{0}大{1}小<br/>{2}婴{3}陪", heJi[0], heJi[1], heJi[7], heJi[2]);

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

            info.GysJiaoYiHao = string.Empty;
            info.GysName = Utils.GetQueryStringValue("txtGysName");
            info.JiaoYiHao = Utils.GetQueryStringValue("txtJiaoYiHao");
            info.KongWeiCode = Utils.GetQueryStringValue("txtKongWeiCode");
            info.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLEDate"));
            info.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLSDate"));
            info.YingFuJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtYingFuJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.YingFuJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtYingFuJinE"));
            info.JieQingStatus = Utils.GetIntNull(Utils.GetQueryStringValue("txtJieQingStatus"));
            info.ZxsId = CurrentZxsId;
            info.RouteName = Utils.GetQueryStringValue("txtRouteName");

            info.PaiXuLeiXing = Utils.GetInt(Utils.GetQueryStringValue("paixuleixing"));

            return info;
        }
        #endregion

        #region protected attributes
        /// <summary>
        /// get dijie queren xinxi
        /// </summary>
        /// <param name="queRenStatus"></param>
        /// <param name="queRenRenId"></param>
        /// <param name="queRenRenName"></param>
        /// <param name="queRenTime"></param>
        /// <returns></returns>
        protected string GetDiJieQueRenXinXi(object queRenStatus, object queRenRenId, object queRenRenName, object queRenTime)
        {
            var _queRenStatus = (EyouSoft.Model.EnumType.TourStructure.QueRenStatus)queRenStatus;
            string s = string.Empty;
            if (_queRenStatus == EyouSoft.Model.EnumType.TourStructure.QueRenStatus.未确认)
            {
                s = "地接确认状态：未确认<br/>";
            }
            else
            {
                s = "地接确认状态：已确认<br/>";
                var _queRenRenId = (int)queRenRenId;
                var _queRenTime = (DateTime?)queRenTime;
                if (_queRenRenId > 0)
                {
                    s += "地接确认人：" + queRenRenName + "<br/>";

                    if (_queRenTime.HasValue)
                    {
                        s += "地接确认时间：" + _queRenTime.Value.ToString("yyyy-MM-dd HH:mm");
                    }
                }
            }

            return s;
        }
        #endregion

    }
}
