using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.SystemSet
{
    public partial class TrafficAdd : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Utils.GetQueryStringValue("type");
            string dotype = Utils.GetQueryStringValue("dotype");
            string trafficid = Utils.GetQueryStringValue("trafficid");
            PowerControl();
            //存在ajax请求
            switch (type)
            {
                case "save":
                    Response.Clear();
                    Response.Write(PageSave(dotype, trafficid));
                    Response.End();
                    break;
            }

            //获得操作ID
            if (!IsPostBack)
            {
                PageInit(dotype, trafficid);
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dotype"></param>
        /// <param name="id"></param>
        private void PageInit(string dotype, string id)
        {
            if (String.Equals(dotype, "update", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(id))
            {
                EyouSoft.BLL.CompanyStructure.BCompanyTraffic bllTraffic = new EyouSoft.BLL.CompanyStructure.BCompanyTraffic();
                EyouSoft.Model.CompanyStructure.CompanyTraffic model = new EyouSoft.Model.CompanyStructure.CompanyTraffic();
                model = bllTraffic.GetModel(Utils.GetInt(id));
                if (model != null)
                {
                    this.txtTrafficName.Text = model.TrafficName;
                }
            }
        }
        private string PageSave(string dotype, string id)
        {
            //t为false为编辑，true时为新增
            bool t = String.Equals(dotype, "update", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(id) ? false : true;
            EyouSoft.BLL.CompanyStructure.BCompanyTraffic blltraffic = new EyouSoft.BLL.CompanyStructure.BCompanyTraffic();
            EyouSoft.Model.CompanyStructure.CompanyTraffic model = new EyouSoft.Model.CompanyStructure.CompanyTraffic();


            model.TrafficName = this.txtTrafficName.Text.Trim();
            model.CompanyId = this.SiteUserInfo.CompanyId;
            if (t)
            {
                if (blltraffic.AddTraffic(model) == 1)
                {
                    return UtilsCommons.AjaxReturnJson("1", "添加成功!");
                }
                else if (blltraffic.AddTraffic(model) == -2)
                {
                    return UtilsCommons.AjaxReturnJson("0", "交通名称已经存在!");
                }
                else
                {
                    return UtilsCommons.AjaxReturnJson("0", "添加失败!");
                }
            }
            else
            {
                model.TrafficId = Utils.GetInt(id);
                if (blltraffic.UpdateTraffic(model) == 1)
                {
                    return UtilsCommons.AjaxReturnJson("1", "修改成功!");
                }
                else if (blltraffic.UpdateTraffic(model) == -2)
                {
                    return UtilsCommons.AjaxReturnJson("0", "交通名称已经存在!");
                }
                else if (blltraffic.UpdateTraffic(model) == -3)
                {
                    return UtilsCommons.AjaxReturnJson("0", "交通已经被使用!");
                }
                else
                {
                    return UtilsCommons.AjaxReturnJson("0", "修改失败!");
                }
            }
        }
        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_交通信息栏目))
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
