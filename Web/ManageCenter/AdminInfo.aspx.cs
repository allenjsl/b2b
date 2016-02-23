using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using EyouSoft.Common;
    using EyouSoft.Common.Page;

    public partial class AdminInfo : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var m = new EyouSoft.BLL.AdminCenterStructure.PersonnelInfo().GetModel(
                this.SiteUserInfo.CompanyId, Utils.GetInt(Utils.GetQueryStringValue("id")));
            if (m==null)return;
            Name.InnerText = m.UserName;
            ArchiveNo.InnerText = m.ArchiveNo;
            UserName.InnerText = m.UserName;
            ContactSex.InnerText = m.ContactSex.ToString();
            var photoPath = m.PhotoPath.Split('|');
            Photo.Src = Utils.AbsoluteWebRoot + (photoPath.Count() > 1 ? photoPath[1] : photoPath[0]).TrimStart('/');
            CardId.InnerText = m.CardId;
            BirthDate.InnerText = UtilsCommons.GetDateString(m.BirthDate,ProviderToDate);
            DepartmentList.InnerText = m.DepartmentList!=null&& m.DepartmentList.Count>0? m.DepartmentList.Aggregate(string.Empty, (current, mo) => current + mo.DepartName + ",").TrimEnd(','):string.Empty;
            DutyName.InnerText = m.DutyName;
            PersonalType.InnerText = m.PersonalType.ToString();
            IsLeave.InnerText = m.IsLeave ? "离职" : "在职";
            EntryDate.InnerText = UtilsCommons.GetDateString(m.EntryDate, ProviderToDate);
            WorkYear.InnerText = m.WorkYear.ToString();
            National.InnerText = m.National;
            if (!string.IsNullOrEmpty(m.Birthplace))
            {
                var arr = m.Birthplace.Split(',');
                if (arr.Any())
                {
                    var p = new EyouSoft.BLL.CompanyStructure.Province().GetModel(Utils.GetInt(arr[0]));
                    Birthplace.InnerText = Birthplace.InnerText + (p != null ? p.ProvinceName : "");
                    if (arr.Length>1)
                    {
                        var c = new EyouSoft.BLL.CompanyStructure.City().GetModel(Utils.GetInt(arr[1]));
                        Birthplace.InnerText = Birthplace.InnerText + (c != null ? "." +c.CityName : "");
                    }
                }
            }
            Politic.InnerText = m.Politic;
            IsMarried.InnerText = m.IsMarried ? "已婚" : "未婚";
            ContactTel.InnerText = m.ContactTel;
            ContactMobile.InnerText = m.ContactMobile;
            LeaveDate.InnerText = UtilsCommons.GetDateString(m.LeaveDate, ProviderToDate);
            QQ.InnerText = m.QQ;
            MSN.InnerText = m.MSN;
            Email.InnerText = m.Email;
            ContactAddress.InnerText = m.ContactAddress;
            Remark.InnerText = m.Remark;
            rptXueLi.DataSource = m.SchoolList;
            rptXueLi.DataBind();
            rptLvLi.DataSource = m.HistoryList;
            rptLvLi.DataBind();
        }
    }
}
