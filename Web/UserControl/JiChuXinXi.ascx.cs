using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    /// <summary>
    /// 系统设置-基础设置-导航
    /// </summary>
    public partial class JiChuXinXi : System.Web.UI.UserControl
    {
        #region attributes
        /// <summary>
        /// 高亮的标签
        /// </summary>
        public int HighlightNav { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            var uinfo = EyouSoft.Security.Membership.UserProvider.GetUserInfo();

            if (uinfo != null)
            {
                ph__3.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_城市管理栏目);
                ph__2.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_线路区域栏目);
                ph__1.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_交通信息栏目);
                //ph_0.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_去程时间栏目);
                //ph_1.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_回程时间栏目);
                ph_0.Visible = ph_1.Visible = false;
                ph_2.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_去程班次栏目);
                ph_3.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_回程班次栏目);
                ph_4.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_集合地点栏目);
                ph_5.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_集合时间栏目);
                ph_6.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_送团信息栏目);
                ph_7.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_目的地接团方式栏目);
                ph_8.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_用餐标准栏目);
                ph_9.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_其它收入项目栏目);
                ph_10.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_其它支出项目栏目);
                ph_11.Visible = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_常用城市栏目);
            }

            ph_tr0.Visible = ph__3.Visible || ph__1.Visible || ph_9.Visible || ph_10.Visible;
            ph_tr1.Visible = ph__2.Visible||ph_2.Visible || ph_3.Visible || ph_6.Visible || ph_7.Visible || ph_8.Visible;
            ph_tr2.Visible = ph_4.Visible || ph_5.Visible || ph_11.Visible;
        }
    }
}