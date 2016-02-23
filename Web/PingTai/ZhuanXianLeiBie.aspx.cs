using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.PingTai
{
    /// <summary>
    /// 专线类别管理
    /// </summary>
    public partial class ZhuanXianLeiBie : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_Delete = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        protected bool Privs_Insert = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        protected bool Privs_Update = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
            if (Utils.GetQueryStringValue("doType") == "delete") Delete();
            InitRpt();
            InitZhanDian();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线类别管理_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线类别管理_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线类别管理_新增);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线类别管理_删除);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线类别管理_修改);

            phInsert.Visible = Privs_Insert;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo();

            info.ZhanDianId = Utils.GetIntNull(Utils.GetQueryStringValue("txtZhanDian"));
            info.MingCheng = Utils.GetQueryStringValue("txtMingCheng");

            return info;
        }
     
        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var chaXun = GetChaXunInfo();

            var items = new EyouSoft.BLL.PtStructure.BPt().GetZhuanXianLeiBies(CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                phEmpty.Visible = false;
            }

            phPaging.Visible = false;
        }

        /// <summary>
        /// 删除专线类别信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int zxlbId = Utils.GetInt(Utils.GetFormValue("zxlbid"));
            int bllRetCode = new EyouSoft.BLL.PtStructure.BPt().DeleteZhuanXianLeiBie(CurrentUserCompanyID, zxlbId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -98 || bllRetCode == -97 || bllRetCode == -96 || bllRetCode == -95) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：该专线类别不能删除"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init zhandian
        /// </summary>
        void InitZhanDian()
        {
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZhanDians(CurrentUserCompanyID, null);
            StringBuilder s = new StringBuilder();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.ZhanDianId, item.MingCheng);
                }
            }
            ltrZhanDian.Text = s.ToString();
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

            if (Privs_Update) s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";

            if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a> ";

            return s.ToString();
        }
        #endregion
    }
}
