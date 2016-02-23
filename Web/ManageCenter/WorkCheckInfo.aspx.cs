using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using System.Text;

    using EyouSoft.BLL.AdminCenterStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;
    using EyouSoft.Model.EnumType;

    public partial class WorkCheckInfo : BackPage
    {
        protected DateTime dt;
        protected StringBuilder nullDayEndStr = new StringBuilder();//日历结尾的空li
        protected void Page_Load(object sender, EventArgs e)
        {
            //权限验证
            PowerControl();

            //获得操作ID
            string id = Utils.GetQueryStringValue("id");
            //传过来的时间
            var m = Utils.GetIntSign(Utils.GetQueryStringValue("m"));
            var d = Utils.GetDateTime(Utils.GetQueryStringValue("curdate"), DateTime.Now);
            dt = d.AddMonths(m);
            //根据ID初始化页面
            PageInit(id);
            //if (UtilsCommons.IsToXls()) ToXls();
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="id">操作ID</param>
        protected void PageInit(string id)
        {
            var BLL = new AttendanceInfo();
            //统计信息(当月考勤情况)
            if (!string.IsNullOrEmpty(id))
            {
                var m = BLL.GetAttendanceAbout(this.SiteUserInfo.CompanyId, Utils.GetInt(id), dt.Year, dt.Month);
                if (m != null)
                {
                    this.lbAttInfo.Text = string.Format("准点<strong class=\"red\">{0}</strong>天，迟到<strong class=\"red\">{1}</strong>天，早退<strong class=\"red\">{2}</strong>天，旷工<strong class=\"red\">{3}</strong>天，休假<strong class=\"red\">{4}</strong>天，外出<strong class=\"red\">{5}</strong>天，出团<strong class=\"red\">{6}</strong>天，请假<strong class=\"red\">{7}</strong>天，加班<strong class=\"red\">{8}</strong>小时", m.Punctuality, m.Late, m.LeaveEarly, m.Absenteeism, m.Vacation, m.Out, m.Group, Math.Round(m.AskLeave,1), Math.Round(m.OverTime, 1));
                }
                m = BLL.GetAttendanceAbout(this.SiteUserInfo.CompanyId, Utils.GetInt(id), dt.Year, 0);
                if (m != null)
                {
                    this.lblYear.Text = string.Format("准点<strong class=\"red\">{0}</strong>天，迟到<strong class=\"red\">{1}</strong>天，早退<strong class=\"red\">{2}</strong>天，旷工<strong class=\"red\">{3}</strong>天，休假<strong class=\"red\">{4}</strong>天，外出<strong class=\"red\">{5}</strong>天，出团<strong class=\"red\">{6}</strong>天，请假<strong class=\"red\">{7}</strong>天，加班<strong class=\"red\">{8}</strong>小时", m.Punctuality, m.Late, m.LeaveEarly, m.Absenteeism, m.Vacation, m.Out, m.Group, Math.Round(m.AskLeave,1), Math.Round(m.OverTime, 1));
                }
            }
        }
        /// <summary>
        /// 生成主体表格
        /// </summary>
        /// <returns></returns>
        protected string getTables()
        {   //需要传个时间过来，以判断当前月有多少天
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < DateTime.DaysInMonth(dt.Year, dt.Month); i++)
            {
                str.Append(this.getUnit(i + 1));
            }
            return str.ToString();
        }
        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_考勤管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_考勤管理_栏目, false);
            }
        }
        /// <summary>
        /// 生成单元格（包括日期和考勤情况信息）
        /// </summary>
        /// <param name="i">当月几号</param>
        /// <returns></returns>
        protected string getUnit(int i)
        {
            var dic = new Dictionary<AdminCenterStructure.WorkStatus, string>();
            dic.Add(AdminCenterStructure.WorkStatus.迟到, "class=\"rl-red\"");
            dic.Add(AdminCenterStructure.WorkStatus.出团, "class=\"rl-perpel\"");
            dic.Add(AdminCenterStructure.WorkStatus.加班, "class=\"rl-blue\"");
            dic.Add(AdminCenterStructure.WorkStatus.旷工, "class=\"rl-yellow\"");
            dic.Add(AdminCenterStructure.WorkStatus.请假, "class=\"rl-gray\"");
            dic.Add(AdminCenterStructure.WorkStatus.外出, "class=\"rl-skyblue\"");
            dic.Add(AdminCenterStructure.WorkStatus.休假, "class=\"rl-lime\"");
            dic.Add(AdminCenterStructure.WorkStatus.早退, "class=\"rl-green\"");
            DateTime dtCurrent = Convert.ToDateTime(string.Format("{0}{1}", string.Format("{0:yyyy-MM-}", dt), i < 10 ? "0" + i.ToString() : i.ToString()));
            var BLL = new AttendanceInfo();
            var lst = BLL.GetList(this.SiteUserInfo.CompanyId,Utils.GetInt(Utils.GetQueryStringValue("id")), dtCurrent);
            string classStr = string.Empty;
            string type = string.Empty;
            StringBuilder strInfo = new StringBuilder();
            string id = Utils.GetQueryStringValue("id");
            if (null != lst && lst.Count > 0)
            {
                foreach (EyouSoft.Model.AdminCenterStructure.AttendanceInfo m in lst)
                {
                    if (m.WorkStatus != AdminCenterStructure.WorkStatus.准点)
                    {
                        classStr = dic[m.WorkStatus];
                    }
                    if (m.WorkStatus == AdminCenterStructure.WorkStatus.准点)
                    {
                        strInfo.AppendFormat("<a href='WorkCheckAdd.aspx?doType=update&attID={0}&date={2}' data-class='attDetail'>{1}</a>", m.Id,
                            m.WorkStatus.ToString(), string.Format("{0:yyyy-MM-dd}", dtCurrent));
                    }
                    else
                    {
                        bool flag = m.WorkStatus == AdminCenterStructure.WorkStatus.加班;
                        strInfo.AppendFormat("<a href='WorkCheckAdd.aspx?doType=update&attID={1}&date={2}' class='attendBt' data-class='attDetail'>{0}</a>",
                            m.WorkStatus.ToString(), m.Id,
                            string.Format("{0:yyyy-MM-dd}", dtCurrent));
                        strInfo.AppendFormat("<div style='display: none'>");
                        strInfo.AppendFormat("<table cellspacing='0' cellpadding='0' border='0' width='100%'><tr>");
                        strInfo.AppendFormat("<td height='23' align='right'>考勤时间：</td>");
                        strInfo.AppendFormat("<td align='left'>{0}</td></tr>", string.Format("{0:yyyy-MM-dd}", m.AddDate));
                        strInfo.AppendFormat("<tr><th align='right' valign='top'>考勤情况：</th>");
                        strInfo.AppendFormat("<td>{0}时间:{1}至{2}&nbsp;{0}{3}：",
                            m.WorkStatus.ToString(),
                            string.Format("{0:yyyy-MM-dd HH:mm}", m.BeginDate),
                            string.Format("{0:yyyy-MM-dd HH:mm}", m.EndDate),
                            flag ? "时数" : "天数");
                        strInfo.AppendFormat("<strong class='fontred'>{0}{1}</strong>", string.Format("({0})", Math.Round(m.OutTime, 1)),
                            flag ? "小时" : "天");
                        if (m.WorkStatus == AdminCenterStructure.WorkStatus.加班 || m.WorkStatus == AdminCenterStructure.WorkStatus.请假)
                        {
                            strInfo.AppendFormat("&nbsp;<p>{0}原因：{1}</p> ", m.WorkStatus.ToString(), m.Reason);
                        }
                        strInfo.Append("</td></tr></table></div> ");
                    }
                }
            }
            return string.Format("<li {0}><p>&nbsp;{1}&nbsp;</p>&nbsp;{2}&nbsp;</li>", classStr, i < 10 ? "0" + i.ToString() : i.ToString(), strInfo.ToString());
        }
        /// <summary>
        /// 判断当前月的第一天是星期几，如：如果是星期二，则生成一个空的"li",以便repeater的第一天星期数正确
        /// </summary>
        /// <returns></returns>
        protected string getNullDay()
        {
            StringBuilder str = new StringBuilder("");
            //当月一号为星期几
            int i = (int)(Convert.ToDateTime(string.Format("{0}-{1}-01", dt.Year, dt.Month)).DayOfWeek);//0(星期日)-6(星期六)
            int m = 0;//要生成空li的个数
            switch (i)
            {
                case 0:
                    m = 6;
                    break;
                default:
                    m = i - 1;
                    break;
            }
            //日历开始的空单元格
            for (int j = 0; j < m; j++)
            {
                str.Append("<li><p>&nbsp;</p><p>&nbsp;</p></li>");
            }
            //日历结束的空单元格
            for (int j = 0; j < 42 - DateTime.DaysInMonth(dt.Year, dt.Month) - m; j++)
            {
                this.nullDayEndStr.Append("<li><p>&nbsp;</p><p>&nbsp;</p></li>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 重写OnPreInit 指定页面类型
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = PageType.boxyPage;
        }
    }
}
