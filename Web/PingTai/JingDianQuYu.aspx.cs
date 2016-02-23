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
    public partial class JingDianQuYu : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_ShanChu = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai = false;
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_景点管理_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_景点管理_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_景点管理_修改);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_景点管理_删除);

            phInsert.Visible = Privs_TianJia;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            var items = new EyouSoft.BLL.PtStructure.BJingDian().GetJingDianQuYus(CurrentUserCompanyID);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                phEmpty.Visible = false;
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
            if (!Privs_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int quYuId =Utils.GetInt( Utils.GetFormValue("txtQuYuId"));

            if (new EyouSoft.BLL.PtStructure.BJingDian().IsExistsJingDian(CurrentUserCompanyID, quYuId, 0, string.Empty)) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：该区域下存在景点信息，不能删除。"));

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJingDian().DeleteJingDianQuYu(CurrentUserCompanyID, quYuId);

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

            if (Privs_XiuGai) s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\" data-chakan=\"1\">查看</a> ";

            if (Privs_ShanChu) s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";

            return s.ToString();
        }
        #endregion
    }
}
