using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.Fin
{
    /// <summary>
    /// 催款单详情
    /// </summary>
    public partial class CuiKuanDanXX : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 客户编号
        /// </summary>
        string KeHuId = string.Empty;
        /// <summary>
        /// 客户联系人编号
        /// </summary>
        int? KeHuLxrId = null;
        /// <summary>
        /// 出团起始时间
        /// </summary>
        DateTime? QuDate1 = null;
        /// <summary>
        /// 出团截止时间
        /// </summary>
        DateTime? QuDate2 = null;
        /// <summary>
        /// 催款单栏目权限
        /// </summary>
        bool Privs_CuiKuanDan = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            KeHuId = Utils.GetQueryStringValue("keHuId");
            KeHuLxrId = Utils.GetIntNull(Utils.GetQueryStringValue("duiFangCaoZuoRenId"));
            QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("quDate1"));
            QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("quDate2"));

            if (string.IsNullOrEmpty(KeHuId)) RCWE("异常请求");
            //if (!KeHuLxrId.HasValue) RCWE("异常请求");
            if (!QuDate1.HasValue) RCWE("异常请求");
            if (!QuDate2.HasValue) RCWE("异常请求");

            InitPrivs();
            InitInfo();
            InitRpt();

            InitYingHangZhangHu();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_CuiKuanDan = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_催款单_栏目);
            if (!Privs_CuiKuanDan) RCWE("没有权限");
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var keHuInfo = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(KeHuId);

            if (keHuInfo == null) RCWE("异常请求");

            ltrKeHuName1.Text = ltrKeHuName2.Text = keHuInfo.Name;
            ltrKeHuFax.Text = keHuInfo.GongSiFax;

            if (KeHuLxrId.HasValue)
            {
                var lxrInfo = new EyouSoft.BLL.CompanyStructure.Customer().GetKeHuLxrInfo(KeHuId, KeHuLxrId.Value);

                if (lxrInfo == null) RCWE("异常请求");

                ltrKeHuLxrName1.Text = ltrKeHuLxrName2.Text = lxrInfo.Name;

                if (!string.IsNullOrEmpty(lxrInfo.Fax))
                {
                    ltrKeHuFax.Text = lxrInfo.Fax;
                }
            }

            ltrZxsName1.Text = ltrZxsName2.Text =ltrZxsName3.Text = SiteUserInfo.ZxsName;

            var zxsInfo = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(SiteUserInfo.ZxsId);
            if (zxsInfo == null) RCWE("异常请求");

            ltrZxsFax.Text = zxsInfo.Fax;
            ltrZxsCaoZuoRenName.Text = SiteUserInfo.Name;

            ltrQuDate1.Text = QuDate1.Value.ToString("yyyy-MM-dd");
            ltrQuDate2.Text = QuDate2.Value.ToString("yyyy-MM-dd");
        }


        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var chaXun = new EyouSoft.Model.FinStructure.MCuiKuanDanChaXunInfo();
            chaXun.KeHuId = KeHuId;
            chaXun.KeHuLxrId = KeHuLxrId;
            chaXun.QuDate1 = QuDate1;
            chaXun.QuDate2 = QuDate2;
            chaXun.ZxsId = CurrentZxsId;

            var items = new EyouSoft.BLL.FinStructure.BFin().GetCuiKuanDans(CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                phHeJi.Visible = true;

                decimal jinE = 0;
                decimal yiShouJinE = 0;

                foreach (var item in items)
                {
                    jinE += item.JinE;
                    yiShouJinE += item.YiShouJinE;
                }

                ltrJinEHeJi.Text = jinE.ToString("F2");
                ltrWeiShouJinEHeJi.Text = (jinE - yiShouJinE).ToString("F2");
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// init yinhangzhanghu
        /// </summary>
        void InitYingHangZhangHu()
        {
            var items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(CurrentUserCompanyID, CurrentZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.打印单据账户);
            var items1 = new List<EyouSoft.Model.CompanyStructure.CompanyAccount>();

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用)
                    {
                        items1.Add(item);
                    }
                }
            }

            rptYinHangZhangHu.DataSource = items1;
            rptYinHangZhangHu.DataBind();
        }
        #endregion

        #region protected
        /// <summary>
        /// get routename
        /// </summary>
        /// <param name="routeName"></param>
        /// <param name="yeWuLeiXing"></param>
        /// <returns></returns>
        protected string GetRouteName(object routeName, object yeWuLeiXing)
        {
            if (routeName == null && yeWuLeiXing == null) return string.Empty;

            if (routeName == null) return yeWuLeiXing.ToString();

            string _routeName = routeName.ToString();

            if (!string.IsNullOrEmpty(_routeName)) return _routeName;

            return yeWuLeiXing.ToString();
        }
        #endregion
    }
}
