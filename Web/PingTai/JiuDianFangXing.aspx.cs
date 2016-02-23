using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;

namespace Web.PingTai
{
    /// <summary>
    /// 酒店房型管理
    /// </summary>
    public partial class JiuDianFangXing : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 房型管理权限
        /// </summary>
        bool Privs_FangXingGuanLi = false;
        /// <summary>
        /// 酒店编号
        /// </summary>
        protected string JiuDianId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
            JiuDianId = Utils.GetQueryStringValue("jiudianid");

            if (string.IsNullOrEmpty(JiuDianId)) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求"));

            if (Utils.GetQueryStringValue("dotype") == "shanchu") ShanChu();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_FangXingGuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_房型管理);
            phTianJia.Visible = Privs_FangXingGuanLi;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            var items = new EyouSoft.BLL.PtStructure.BJiuDian().GetFangXings(JiuDianId);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// shan chu
        /// </summary>
        void ShanChu()
        {
            if (!Privs_FangXingGuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string fangXingId = Utils.GetFormValue("txtFangXingId");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJiuDian().DeleteFangXing(CurrentUserCompanyID,JiuDianId,fangXingId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml()
        {
            string s = string.Empty;

            if (Privs_FangXingGuanLi) s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\" data-chakan=\"1\">查看</a> ";

            if (Privs_FangXingGuanLi) s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";

            return s.ToString();
        }
        #endregion
    }
}
