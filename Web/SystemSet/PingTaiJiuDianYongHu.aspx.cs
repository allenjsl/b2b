using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.SystemSet
{
    public partial class PingTaiJiuDianYongHu : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        protected int pageIndex=0;
        protected int pageSize = 20;

        protected EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing YHLX = EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string yhlx = Utils.GetQueryStringValue("yhlx");

            if (yhlx == "3") YHLX = EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户;

            InitPrivs();
            InitYongHu();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (YHLX == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户)
            {
                Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台酒店用户管理栏目);
            }

            if (YHLX == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户)
            {
                Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台景点用户管理栏目);
            }

            if (!Privs_LanMu)
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            phBuMenLanMu.Visible = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_部门管理栏目);
            phYongHuLanMu.Visible = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_用户管理栏目);
            phPtJiuDianYongHuLanMu.Visible = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台酒店用户管理栏目);
            phPtJingDianYongHuLanMu.Visible = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台景点用户管理栏目);
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.QueryCompanyUser GetChaXunInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.QueryCompanyUser();

            info.ContactName = Utils.GetQueryStringValue("txtXingMing");
            info.UserName = Utils.GetQueryStringValue("txtYongHuMing");
            info.ZxsId = CurrentZxsId;
            info.LeiXing = YHLX;
            return info;
        }

        /// <summary>
        /// init yonghu
        /// </summary>
        void InitYongHu()
        {
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();

            var items = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetList(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptYongHu.DataSource = items;
                rptYongHu.DataBind();

                FenYe.intPageSize = pageSize;
                FenYe.CurrencyPage = pageIndex;
                FenYe.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion
    }
}
