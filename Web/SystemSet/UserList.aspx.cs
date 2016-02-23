using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Function;
using System.Text;

namespace Web.SystemSet
{
    public partial class UserManage : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageIndex;
        protected int pageSize = 20;
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            string doType = Utils.GetQueryStringValue("doType");

            switch (doType)
            {
                case "delete": Delete(); break;
                case "setuserstatus": SetUserStatus(); break;
                default: break;
            }

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_LanMu=CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_用户管理栏目);

            if (!Privs_LanMu)
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_用户管理栏目, true);
                }
            }

            phBuMenLanMu.Visible = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_部门管理栏目);
            phPtJiuDianYongHuLanMu.Visible = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台酒店用户管理栏目);
            phPtJingDianYongHuLanMu.Visible = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台景点用户管理栏目);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        void Delete()
        {
            bool privs_delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_用户管理栏目);
            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int txtUserId = Utils.GetInt(Utils.GetFormValue("txtUserId"));

            if (txtUserId < 1) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请选择你要删除的账号。"));

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanyUser().YongHu_D(CurrentUserCompanyID, CurrentZxsId, txtUserId);
            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -99 || bllRetCode == -98 || bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：该账号不能删除"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }

        /// <summary>
        /// 设置用户状态
        /// </summary>
        void SetUserStatus()
        {
            string txtStatus = Utils.GetFormValue("txtStatus");
            int txtUserId = Utils.GetInt(Utils.GetFormValue("txtUserId"));
            var status = EyouSoft.Model.EnumType.CompanyStructure.UserStatus.正常;
            if(txtStatus=="stop") status= EyouSoft.Model.EnumType.CompanyStructure.UserStatus.已停用;

            var bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanyUser().SetEnable(txtUserId, status);
            if (bllRetCode) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            
            var items = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetList(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);
            if (items != null && items.Count > 0)
            {
                rptEmployee.DataSource = items;
                rptEmployee.DataBind();

                ExporPageInfoSelect1.intPageSize = pageSize;
                ExporPageInfoSelect1.CurrencyPage = pageIndex;
                ExporPageInfoSelect1.intRecordCount = recordCount;
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='10' align='center'>对不起，暂无部门员工信息！</td></tr>";
                ExporPageInfoSelect1.Visible = false;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.QueryCompanyUser GetChaXunInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.QueryCompanyUser();

            info.ContactName = Utils.GetQueryStringValue("txtContactName");
            info.UserName = Utils.GetQueryStringValue("txtUserName");
            info.ZxsId = CurrentZxsId;
            info.BuMenId = Utils.GetIntNull(Utils.GetQueryStringValue("txtBuMenId"));
            info.LeiXing = EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.专线用户;
            return info;
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取部门
        /// </summary>
        /// <returns></returns>
        protected string GetBuMenOptions()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("<option value=\"\">请选择</option>");
            var items = new EyouSoft.BLL.CompanyStructure.Department().GetAllDept(this.SiteUserInfo.CompanyId, CurrentZxsId);
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Id, item.DepartName);
                }
            }
            return s.ToString();
        }
        #endregion
    }
}
