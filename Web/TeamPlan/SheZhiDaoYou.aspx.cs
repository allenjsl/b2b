//汪奇志 2013-01-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;

namespace Web.TeamPlan
{
    /// <summary>
    /// 设置地接安排导游
    /// </summary>
    public partial class SheZhiDaoYou : BackPage
    {
        #region attributes
        /// <summary>
        /// 安排编号
        /// </summary>
        string AnPaiId = string.Empty;
        /// <summary>
        /// 设置导游权限
        /// </summary>
        bool Privs_SheZhiDaoYou = false;
        /// <summary>
        /// 地接社编号
        /// </summary>
        protected string DiJieSheId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            AnPaiId = Utils.GetQueryStringValue("anpaiid");

            string doType = Utils.GetQueryStringValue("doType");
            if (string.IsNullOrEmpty(AnPaiId)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));
            if (doType == "shezhidaoyou") SetDaoYou();

            InitPrivs();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_SheZhiDaoYou = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_地接导游设置);

            if (Privs_SheZhiDaoYou) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有设置导游权限";
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.PlanStructure.BPlanDiJie().GetPlanDiJieById(AnPaiId);

            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));

            //txtDaoYou.SellsID = info.DaoYouId.ToString();
            //txtDaoYou.SellsName = info.DaoYouName;

            txtDaoYouName.Value = info.DaoYouName;

            DiJieSheId = info.GysId;
        }

        /// <summary>
        /// 设置导游
        /// </summary>
        void SetDaoYou()
        {
            /*int daoYouId = Utils.GetInt(Utils.GetFormValue("txtDaoYouId"));

            int bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanDiJie().SetDaoYou(AnPaiId, daoYouId);*/

            string txtDaoYouName = Utils.GetFormValue("txtDaoYouName");
            int bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanDiJie().SetDaoYou(AnPaiId, txtDaoYouName);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
