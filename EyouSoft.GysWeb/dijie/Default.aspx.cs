//地接社主体-计划中心 汪奇志 2015-05-17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.GysWeb.dijie
{
    /// <summary>
    /// 地接社主体-计划中心
    /// </summary>
    public partial class Default : DiJieYeMian
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitRpt();
        }

        #region private members
        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiChaXunInfo();

            info.DiJieRouteName = Utils.GetQueryStringValue("txtDiJieRouteName");
            info.DiJieTuanHao = string.Empty;
            info.GysId = YongHuInfo.GysId;
            info.JieQingStatus = (EyouSoft.Model.EnumType.FinStructure.JieQingStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.FinStructure.JieQingStatus), Utils.GetQueryStringValue("txtJieQingStatus"));
            info.PaiXuLeiXing = 2;
            info.QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate1"));
            info.QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate2"));
            info.ZxsName = Utils.GetQueryStringValue("txtZxsName");
            info.ZxsRouteName = string.Empty;
            info.ZxsTuanHao = string.Empty;
            info.QueRenStatus = (EyouSoft.Model.EnumType.TourStructure.QueRenStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.QueRenStatus), Utils.GetQueryStringValue("txtQueRenStatus"));

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            object[] heJi = null;

            var items = new EyouSoft.BLL.PlanStructure.BPlanDiJie().GYS_GetDiJieAnPais(YongHuInfo.CompanyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                fenYe.intPageSize = pageSize;
                fenYe.CurrencyPage = pageIndex;
                fenYe.intRecordCount = recordCount;

                phHeJi.Visible = true;

                ltrJinEHeJi.Text = ((decimal)heJi[3]).ToString("F2");
                ltrYiShouJinEHeJi.Text = ((decimal)heJi[4]).ToString("F2");
                ltrWeiShouJinEHeJi.Text = ((decimal)heJi[3]-(decimal)heJi[4]).ToString("F2");
                ltrRenShuHeJi.Text = string.Format("{0}大{1}小<br/>{2}婴{3}陪", heJi[0], heJi[1], heJi[7], heJi[2]);
            }
            else
            {
                phEmpty.Visible = true;
                phFenYe.Visible = false;
            }
        }
        #endregion

        #region protected members

        /// <summary>
        /// get caozuo
        /// </summary>
        /// <param name="anPaiId"></param>
        /// <param name="queRenStatus"></param>
        /// <returns></returns>
        protected string GetCaoZuo(object anPaiId,object queRenStatus)
        {
            string s = string.Empty;
            var _queRenSatus = (EyouSoft.Model.EnumType.TourStructure.QueRenStatus)queRenStatus;

            if (_queRenSatus == EyouSoft.Model.EnumType.TourStructure.QueRenStatus.未确认)
            {
                s = "<a class=\"caozuo-btn\" data-class=\"caozuo\" href=\"javascript:void(0)\" data-fs=\"queren\">确认</a>&nbsp;";
            }
            else
            {
                s = "<a class=\"caozuo-btn\" data-class=\"caozuo\" href=\"javascript:void(0)\" data-fs=\"chakan\">查看</a>&nbsp;";
            }

            s += string.Format("<a class=\"caozuo-btn\" href=\"{0}?anpaiid={1}\" target=\"_blank\">计划单</a>", "/danju/dijiejihuadan.aspx", anPaiId);

            s += "<a class=\"caozuo-btn\" data-class=\"caozuo\" href=\"javascript:void(0)\" data-fs=\"mingdan\">名单</a>&nbsp;";

            return s.ToString();
        }
        #endregion
    }
}
