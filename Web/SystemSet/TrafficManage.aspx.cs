using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.CompanyStructure;

namespace Web.SystemSet
{
    public partial class TrafficManage : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string trafficid = Utils.GetQueryStringValue("trafficid");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype != null && dotype.Length > 0)
            {
                AJAX(dotype, trafficid);
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            EyouSoft.BLL.CompanyStructure.BCompanyTraffic blltraffic = new EyouSoft.BLL.CompanyStructure.BCompanyTraffic();
            IList<CompanyTraffic> List = blltraffic.GetList(this.SiteUserInfo.CompanyId);
            if (List != null && List.Count > 0)
            {
                this.rptList.DataSource = List;
                this.rptList.DataBind();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='3' align='center'>暂无交通信息!</td></tr>";
            }
        }
        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType, string id)
        {
            string msg = string.Empty;
            if (doType == "delete")
            {
                if (this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_交通信息栏目))
                {
                    msg = this.DeleteData(id);
                }
            }
            //返回ajax操作结果
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private string DeleteData(string id)
        {
            if (!String.IsNullOrEmpty(id) && Utils.GetInt(id) > 0)
            {
                EyouSoft.BLL.CompanyStructure.BCompanyTraffic blltraffic = new EyouSoft.BLL.CompanyStructure.BCompanyTraffic();
                int[] array = new int[1];
                array[0] = Utils.GetInt(id);
                if (blltraffic.DeleteTraffic(array) == 1)
                {
                    return UtilsCommons.AjaxReturnJson("1", "删除成功");
                }
                else
                {
                    return UtilsCommons.AjaxReturnJson("0", "删除失败!");
                }
            }
            else
            {
                return UtilsCommons.AjaxReturnJson("0", "交通信息错误!");
            }
        }
    }
}
