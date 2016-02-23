using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.TeamPlan
{
    /// <summary>
    /// 控位平台数量修改
    /// </summary>
    public partial class KongWeiPingTaiShuLiangEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 控位编号
        /// </summary>
        string EditId = string.Empty;
        /// <summary>
        /// 控位修改权限
        /// </summary>
        bool Privs_XiuGai = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");
            if (string.IsNullOrEmpty(EditId)) RCWE("异常请求");

            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改);

            if (Privs_XiuGai) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有操作权限";
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(EditId);
            if (info == null) RCWE("异常请求");

            ltrShuLiang.Text = info.ShuLiang.ToString();
            txtPingTaiShuLiang.Value = info.PingTaiShuLiang.ToString();
            txtShuLiang.Value = info.ShuLiang.ToString();
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(EditId);
            int pingTaiShuLiang = Utils.GetInt(Utils.GetFormValue(txtPingTaiShuLiang.UniqueID));

            if (info.ShuLiang < pingTaiShuLiang) pingTaiShuLiang = info.ShuLiang;

            int bllRetCode = new EyouSoft.BLL.TourStructure.BTour().SheZhiPingTaiShuLiang(CurrentZxsId, EditId, pingTaiShuLiang);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
