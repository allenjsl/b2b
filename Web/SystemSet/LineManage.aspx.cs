using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.SystemSet
{
    public partial class LineManage : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        private int pagesize = 20;
        private int pagecount = 0;
        private int pageindex = 1;

        bool Privs_LanMu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "shanchu") ShanChu();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_LanMu = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_线路区域栏目);

            if (!Privs_LanMu) Utils.RCWE("没有权限");
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            pageindex = UtilsCommons.GetPagingIndex();
            var  imtes = new EyouSoft.BLL.CompanyStructure.Area().GetList(pagesize, pageindex, ref pagecount, this.SiteUserInfo.CompanyId,CurrentZxsId);
            if (imtes != null && imtes.Count > 0)
            {
                this.rptList.DataSource = imtes;
                this.rptList.DataBind();

                this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
                this.ExporPageInfoSelect1.intPageSize = pagesize;
                this.ExporPageInfoSelect1.CurrencyPage = pageindex;
                this.ExporPageInfoSelect1.intRecordCount = pagecount;
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='10' align='center'>暂无线路区域!</td></tr>";
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        void ShanChu()
        {
            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限"));

            int txtQuYuId = Utils.GetInt(Utils.GetFormValue("txtQuYuId"));

            if (txtQuYuId < 1) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请选择线路区域"));

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.Area().QuYu_D(CurrentUserCompanyID, CurrentZxsId, txtQuYuId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -98||bllRetCode==-97) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已经使用的线路区域不能删除"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
