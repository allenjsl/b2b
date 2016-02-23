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
    /// 平台基础信息
    /// </summary>
    public partial class WangZhanJiChuXinXi : EyouSoft.Common.Page.BackPage
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
            var info1 = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(CurrentUserCompanyID, EyouSoft.Model.EnumType.PtStructure.KvKey.平台标题);
            var info2 = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(CurrentUserCompanyID, EyouSoft.Model.EnumType.PtStructure.KvKey.平台关键字);
            var info3 = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(CurrentUserCompanyID, EyouSoft.Model.EnumType.PtStructure.KvKey.平台描述);
            var info4 = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(CurrentUserCompanyID, EyouSoft.Model.EnumType.PtStructure.KvKey.客服电话);
            var info5 = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(CurrentUserCompanyID, EyouSoft.Model.EnumType.PtStructure.KvKey.平台版权);

            txt1.Value = info1.V;
            txt2.Value = info2.V;
            txt3.Value = info3.V;
            txt4.Value = info4.V;
            txt5.Value = info5.V;
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
            info1.K = EyouSoft.Model.EnumType.PtStructure.KvKey.平台标题;
            info1.OperatorId = SiteUserInfo.UserId;
            info1.V = Utils.GetFormValue(txt1.UniqueID);
            new EyouSoft.BLL.PtStructure.BPt().SheZhiKvInfo(info1);

            var info2 = new EyouSoft.Model.PtStructure.MKvInfo();
            info2.CompanyId = CurrentUserCompanyID;
            info2.IssueTime = DateTime.Now;
            info2.K = EyouSoft.Model.EnumType.PtStructure.KvKey.平台关键字;
            info2.OperatorId = SiteUserInfo.UserId;
            info2.V = Utils.GetFormValue(txt2.UniqueID);
            new EyouSoft.BLL.PtStructure.BPt().SheZhiKvInfo(info2);

            var info3 = new EyouSoft.Model.PtStructure.MKvInfo();
            info3.CompanyId = CurrentUserCompanyID;
            info3.IssueTime = DateTime.Now;
            info3.K = EyouSoft.Model.EnumType.PtStructure.KvKey.平台描述;
            info3.OperatorId = SiteUserInfo.UserId;
            info3.V = Utils.GetFormValue(txt3.UniqueID);
            new EyouSoft.BLL.PtStructure.BPt().SheZhiKvInfo(info3);

            var info4 = new EyouSoft.Model.PtStructure.MKvInfo();
            info4.CompanyId = CurrentUserCompanyID;
            info4.IssueTime = DateTime.Now;
            info4.K = EyouSoft.Model.EnumType.PtStructure.KvKey.客服电话;
            info4.OperatorId = SiteUserInfo.UserId;
            info4.V = Utils.GetFormValue(txt4.UniqueID);
            new EyouSoft.BLL.PtStructure.BPt().SheZhiKvInfo(info4);

            var info5 = new EyouSoft.Model.PtStructure.MKvInfo();
            info5.CompanyId = CurrentUserCompanyID;
            info5.IssueTime = DateTime.Now;
            info5.K = EyouSoft.Model.EnumType.PtStructure.KvKey.平台版权;
            info5.OperatorId = SiteUserInfo.UserId;
            info5.V = Utils.GetFormEditorValue(txt5.UniqueID);
            new EyouSoft.BLL.PtStructure.BPt().SheZhiKvInfo(info5);

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
        }
        #endregion
    }
}
