using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.ManageCenter
{
    public partial class JobAdd : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Utils.GetQueryStringValue("type");
            string dutyid = Utils.GetQueryStringValue("dutyid");
            string dotype = Utils.GetQueryStringValue("dotype");
            PowerControl();
            //存在ajax请求
            switch (type)
            {
                case "save":
                    Response.Clear();
                    Response.Write(Save(dotype, dutyid));
                    Response.End();
                    break;
            }

            //获得操作ID
            if (!IsPostBack)
            {
                PageInit(dutyid, dotype);
            }

        }
        private void PageInit(string dutyid, string dotype)
        {
            if (String.Equals(dotype, "update", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(dutyid))
            {
                EyouSoft.BLL.AdminCenterStructure.DutyManager bllduty = new EyouSoft.BLL.AdminCenterStructure.DutyManager();
                EyouSoft.Model.AdminCenterStructure.DutyManager model = bllduty.GetModel(this.SiteUserInfo.CompanyId, Utils.GetInt(dutyid));
                if (model != null)
                {
                    this.txtDesc.Value = model.Help;
                    this.txtDutyName.Value = model.JobName;
                    this.txtDutyRequired.Value = model.Requirement;
                    this.txtremark.Value = model.Remark;
                }
            }
        }

        private string Save(string dotype, string dutyid)
        {
            //t为false为编辑，true时为新增
            bool t = String.Equals(dotype, "update", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(dutyid) ? false : true;
            EyouSoft.BLL.AdminCenterStructure.DutyManager bllduty = new EyouSoft.BLL.AdminCenterStructure.DutyManager();
            EyouSoft.Model.AdminCenterStructure.DutyManager model = new EyouSoft.Model.AdminCenterStructure.DutyManager();


            if (string.IsNullOrEmpty(this.txtDutyName.Value.Trim()))
            {
                return UtilsCommons.AjaxReturnJson("0", "请填写职务名称!");
            }
            model.Help = this.txtDesc.Value.Trim();
            model.JobName = this.txtDutyName.Value.Trim();
            model.Remark = txtremark.Value.Trim();
            model.Requirement = txtDutyRequired.Value.Trim();

            model.CompanyId = this.SiteUserInfo.CompanyId;
            model.IssueTime = DateTime.Now;
            model.OperatorId = this.SiteUserInfo.UserId;
            string msg = string.Empty;
            var rcd = string.Empty;
            if (t)
            {
                switch (bllduty.Add(model))
                {
                    case 0:
                        msg = "添加失败";
                        rcd = "0";break;
                    case 1:
                        msg = "添加成功";
                        rcd = "1"; break;
                    case -1:
                        msg = "职务名称重复!";
                        rcd = "0"; break;
                }
            }
            else
            {
                model.Id = Utils.GetInt(dutyid);
                switch (bllduty.Update(model))
                {
                    case 0:
                        msg = "修改失败";
                        rcd = "0";break;
                    case 1:
                        msg = "修改成功";
                        rcd = "1"; break;
                    case -1:
                        msg = "职务名称重复";
                        rcd = "0"; break;
                }
            }
            return UtilsCommons.AjaxReturnJson(rcd, msg);
        }
        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_职务管理_新增) && !this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_职务管理_修改))
            {
                this.btn.Visible = false;
            }

        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
        }
    }
}
