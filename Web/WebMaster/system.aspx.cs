//2011-09-30 汪奇志
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.Webmaster
{
    /// <summary>
    /// 查看子系统信息
    /// </summary>
    public partial class _system : WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var info = new EyouSoft.BLL.SysStructure.BSys().GetSysInfo(Utils.GetInt(Utils.GetQueryStringValue("SysId")));

            if (info != null)
            {
                this.ltrSysId.Text = info.SysId.ToString();
                this.ltrCompanyId.Text = info.CompanyId.ToString();                
                this.ltrIssueTime.Text = info.IssueTime.ToString();
                this.ltrSysName1.Text = this.ltrSysName2.Text = info.SysName;
                this.ltrFullname.Text = info.FullName;
                this.ltrTelephone.Text = info.Telephone;
                this.ltrMobile.Text = info.Mobile;
                this.ltrUserId.Text = info.UserId.ToString();
                this.ltrUsername.Text = info.Username;
                this.ltrPassword.Text = info.Password.NoEncryptPassword;

                if (!string.IsNullOrEmpty(info.ZxsId)) ltrZxsId.Text = info.ZxsId;
                else ltrZxsId.Text = "未分配主专线商";
            }
        }
    }
}
