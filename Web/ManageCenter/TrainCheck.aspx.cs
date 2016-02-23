using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using EyouSoft.BLL.AdminCenterStructure;
    using EyouSoft.BLL.CompanyStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;

    public partial class TrainCheck : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var m = new TrainPlan().GetModel(this.SiteUserInfo.CompanyId, Utils.GetInt(Utils.GetQueryStringValue("id")));
            if (m == null) return;
            this.txtTitle.InnerText = m.PlanTitle;
            this.txtContent.InnerText = Utils.InputText(m.PlanContent);
            this.txtDuiXiang.InnerText = GetAcc(m.AcceptList);
            this.txtFaBuRen.InnerText = m.OperatorName;
            this.txtFaBuDate.InnerText = string.Format("{0:yyyy-MM-dd}", m.IssueTime);
        }

        /// <summary>
        /// 获取发送对象
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected string GetAcc(object o)
        {
            if (o == null) return string.Empty;
            var l = ((IList<EyouSoft.Model.AdminCenterStructure.TrainPlanAccepts>)o).OrderBy(m => m.AcceptType);
            var r = string.Empty;

            foreach (var m in l)
            {
                switch (m.AcceptType)
                {
                    case EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.所有:
                        r = r + m.AcceptType + ",";
                        break;
                    case EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.指定部门:
                        r = r + new Department().GetModel(m.AcceptId).DepartName + ",";
                        break;
                    case EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.指定人:
                        r = r + new CompanyUser().GetUserInfo(m.AcceptId).PersonInfo.ContactName + ",";
                        break;
                }
            }

            return r.TrimEnd(',');
        }
    }
}
