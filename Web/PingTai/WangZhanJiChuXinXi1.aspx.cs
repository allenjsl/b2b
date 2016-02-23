using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.PingTai
{
    /// <summary>
    /// 平台基础信息-关于我们
    /// </summary>
    public partial class WangZhanJiChuXinXi1 : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        bool Privs_GuanLi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
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
            Privs_GuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_基础信息_管理);

            if (Privs_GuanLi)
                ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_baocun\">保存</a>";
            else
                ltrOperatorHtml.Text = "你没有操作权限";
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info1 = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(CurrentUserCompanyID, EyouSoft.Model.EnumType.PtStructure.KvKey.关于我们);
            txt1.Value = info1.V;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            if (!Privs_GuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info1 = new EyouSoft.Model.PtStructure.MKvInfo();
            info1.CompanyId = CurrentUserCompanyID;
            info1.IssueTime = DateTime.Now;
            info1.K = EyouSoft.Model.EnumType.PtStructure.KvKey.关于我们;
            info1.OperatorId = SiteUserInfo.UserId;
            info1.V = Utils.GetFormEditorValue(txt1.UniqueID);
            new EyouSoft.BLL.PtStructure.BPt().SheZhiKvInfo(info1);

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
        }
        #endregion
    }
}
