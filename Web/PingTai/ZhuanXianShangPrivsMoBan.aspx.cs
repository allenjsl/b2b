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
    /// 专线商权限模板管理
    /// </summary>
    public partial class ZhuanXianShangPrivsMoBan : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 管理权限
        /// </summary>
        bool Privs_GuanLi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "baocun": BaoCun(); break;
                case "shanchu": ShanChu(); break;
                default: break;
            }

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_GuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_权限模板管理);
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var items = new EyouSoft.BLL.PtStructure.BZxsPrivsMoBan().GetMoBans(CurrentUserCompanyID);
            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();
            }
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo();

            info.CompanyId = CurrentUserCompanyID;
            info.IssueTime = DateTime.Now;
            info.MingCheng = Utils.GetFormValue("txt_moban_name");
            info.MoBanId = Utils.GetFormValue("txt_moban_id");
            info.OperatorId = SiteUserInfo.UserId;
            info.Privs1 = string.Empty;
            info.Privs2 = string.Empty;
            info.Privs3 = string.Empty;

            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();
            if (!Privs_GuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            if (string.IsNullOrEmpty(info.MingCheng))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：权限模板名称不能为空。"));
            }

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.MoBanId)) bllRetCode = new EyouSoft.BLL.PtStructure.BZxsPrivsMoBan().Insert(info);
            else bllRetCode = new EyouSoft.BLL.PtStructure.BZxsPrivsMoBan().Update(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }

        /// <summary>
        /// shanchu
        /// </summary>
        void ShanChu()
        {
            string txt_moban_id = Utils.GetFormValue("txt_moban_id");
            if (!Privs_GuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int bllRetCode = new EyouSoft.BLL.PtStructure.BZxsPrivsMoBan().Delete(CurrentUserCompanyID, txt_moban_id);


            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));

        }
        #endregion

        #region protected members
        /// <summary>
        /// get caozuo html
        /// </summary>
        /// <returns></returns>
        protected string GetCaoZuoHtml()
        {
            string s = string.Empty;

            if (Privs_GuanLi)
                s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
            if (Privs_GuanLi)
                s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";
            if (Privs_GuanLi)
                s += "<a href=\"javascript:void(0)\" class=\"i_shezhiprivs\">权限</a> ";

            return s;
        }

        /// <summary>
        /// get caozuo html
        /// </summary>
        /// <returns></returns>
        protected string GetCaoZuoHtml1()
        {
            string s = string.Empty;

            if (Privs_GuanLi)
                s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";

            return s;
        }
        #endregion
    }
}
