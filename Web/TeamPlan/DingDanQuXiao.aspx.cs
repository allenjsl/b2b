using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.TeamPlan
{
    public partial class DingDanQuXiao : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 订单编号
        /// </summary>
        string DingDanId = string.Empty;
        /// <summary>
        /// 操作方式： quxiao jujue
        /// </summary>
        string FS = string.Empty;
        /// <summary>
        /// 取消权限
        /// </summary>
        bool Privs_QuXiao = false;
        /// <summary>
        /// 拒绝权限
        /// </summary>
        bool Privs_JuJue = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("dingdanid");
            FS = Utils.GetQueryStringValue("fs");

            if (string.IsNullOrEmpty(DingDanId) || string.IsNullOrEmpty(FS)) RCWE("异常请求");

            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "submit") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_JuJue = Privs_QuXiao = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改);
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (FS == "quxiao")
            {
                if (!Privs_QuXiao)
                {
                    ltrOperatorHtml.Text = "你没有操作权限";
                }
                else
                {
                    ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\" data-fs=\"quxiao\">取消订单</a>";
                }
            }

            if (FS == "jujue")
            {
                if (!Privs_JuJue)
                {
                    ltrOperatorHtml.Text = "你没有操作权限";
                }
                else
                {
                    ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\" data-fs=\"jujue\">拒绝订单</a>";
                }
            }
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            string fs1 = "取消";
            if (FS == "quxiao")
            {
                if (!Privs_QuXiao) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            if (FS == "jujue")
            {
                fs1 = "拒绝";
                if (!Privs_JuJue) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            string txtYuanYin = Utils.GetFormValue("txtYuanYin");

            int bllRetCode = 0;

            if (FS == "quxiao")
            {
                bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().QuXiaoDingDan(DingDanId, txtYuanYin, SiteUserInfo.UserId,0);
            }

            if (FS == "jujue")
            {
                bllRetCode = new EyouSoft.BLL.TourStructure.BTourOrder().JuJueDingDan(DingDanId, txtYuanYin, SiteUserInfo.UserId,0);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：控位已核算结束"));
            else if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已安排地接，不允许" + fs1));
            else if (bllRetCode == -96) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已做过票务安排，不允许" + fs1));
            else if (bllRetCode == -95) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：存在收退款登记，不允许" + fs1));
            else if (bllRetCode == -94) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：存在酒店安排且已登记支出项，不允许" + fs1));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
