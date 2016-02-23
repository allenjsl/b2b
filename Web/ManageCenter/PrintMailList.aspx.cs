using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using EyouSoft.Common.Page;
    using EyouSoft.Model.AdminCenterStructure;

    using PersonnelInfo = EyouSoft.BLL.AdminCenterStructure.PersonnelInfo;

    public partial class PrintMailList : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var reCount = 0;
            var bll = new PersonnelInfo();
            var lst = bll.GetList(1, 1, ref reCount, this.SiteUserInfo.CompanyId, new PersonnelSearchInfo());

            if (lst!=null&&lst.Count()>0)
            {
                this.rpt.DataSource = bll.GetList(reCount, 1, ref reCount, this.SiteUserInfo.CompanyId, new PersonnelSearchInfo());
                this.rpt.DataBind();
            }
            else
            {
                this.rpt.Controls.Add(new Label() { Text = "<tr><td colspan='7' align='center'>对不起，没有相关数据！</td></tr>" });
            }
        }

        #region 获取部门
        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected string getSectionInfo(object o)
        {
            if (null == o)
                return "";
            string[] strArr = { };
            List<string> lstStr = new List<string>();
            var lst = (IList<EyouSoft.Model.CompanyStructure.Department>)o;
            if (null != lst && lst.Count > 0)
            {
                foreach (EyouSoft.Model.CompanyStructure.Department m in lst)
                {
                    lstStr.Add(m.DepartName);
                }
            }
            strArr = lstStr.ToArray();
            return strArr == null ? "" : String.Join(",", strArr);
        }
        #endregion
    }
}
