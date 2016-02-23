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
    using EyouSoft.Model.AdminCenterStructure;
    using EyouSoft.Model.EnumType;

    public partial class BatchExamine : BackPage
    {
        protected bool IsSaveGrant;
        protected void Page_Load(object sender, EventArgs e)
        {
            //权限验证
            PowerControl();
            if (!IsPostBack)
            {
                PageInit();
            }
            string save = Utils.GetQueryStringValue("save");
            if (save == "save")
            {
                PageSave();
            }
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="id">操作ID</param>
        protected void PageInit()
        {
            string names = Utils.GetQueryStringValue("names");
            this.attendNames.Text = names;
            string ids = Utils.GetQueryStringValue("id");
            string depts = Utils.GetQueryStringValue("deptids");
            this.hdattenIds.Value = ids;
            this.hdattenNames.Value = names;
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected void PageSave()
        {
            #region 表单取值
            string atttype = Utils.GetFormValue(attType.UniqueID);
            string stime = Utils.GetFormValue(tbStime.UniqueID);
            string etime = Utils.GetFormValue(tbEtime.UniqueID);
            string sub = Utils.GetFormValue(subject.UniqueID);
            string ids = Utils.GetFormValue(hdattenIds.UniqueID);
            string names = Utils.GetFormValue(hdattenNames.UniqueID);
            string timecount = Utils.GetFormValue(timeCount.UniqueID);
            #endregion

            #region 表单验证
            string msg = string.Empty;
            if (string.IsNullOrEmpty(stime))
            {
                msg += "请选择考勤开始时间！";
            }
            if (string.IsNullOrEmpty(etime))
            {
                msg += "请选择考勤结束时间！";
            }
            if (string.IsNullOrEmpty(sub) && Utils.GetInt(atttype, 0) > 6)
            {
                msg += "请输入原因！";
            }
            if (!string.IsNullOrEmpty(msg))
            {
                Response.Clear();
                Response.Write(UtilsCommons.AjaxReturnJson("0", msg));
                Response.End();
            }
            #endregion

            #region 实体赋值
            //时间
            TimeSpan ts = new TimeSpan(Utils.GetDateTime(stime).Ticks);
            TimeSpan te = new TimeSpan(Utils.GetDateTime(etime).Ticks);
            TimeSpan total = ts.Subtract(te).Duration();
            var list = new List<AttendanceInfo>();
            string[] arryIds = ids.Split(',');
            string[] arryNames = names.Split('、');
            if (arryIds.Length == arryNames.Length)
            {
                //小于一天
                if (total.Days == 0)
                {
                    for (int i = 0; i < arryIds.Length; i++)
                    {
                        var model = new AttendanceInfo();
                        model.StaffNo = Utils.GetIntNull(arryIds[i]);
                        model.CompanyId = this.SiteUserInfo.CompanyId;
                        model.OperatorId = this.SiteUserInfo.UserId;
                        model.WorkStatus = (AdminCenterStructure.WorkStatus)(Utils.GetInt(atttype));
                        model.BeginDate = Utils.GetDateTimeNullable(stime);
                        model.AddDate = Utils.GetDateTime(stime);
                        model.EndDate = Utils.GetDateTimeNullable(etime);
                        model.Reason = sub;
                        model.OutTime = string.IsNullOrEmpty(timecount) ? 1 : Utils.GetDecimal(timecount); ;
                        model.IssueTime = DateTime.Now;
                        model.OperatorId = this.SiteUserInfo.UserId;
                        list.Add(model);
                    }
                }
                else
                {
                    //大于一天
                    for (int j = 0; j < total.Days; j++)
                    {
                        for (int i = 0; i < arryIds.Length; i++)
                        {
                            var model = new AttendanceInfo();
                            model.StaffNo = Utils.GetIntNull(arryIds[i]);
                            model.CompanyId = this.SiteUserInfo.CompanyId;
                            model.OperatorId = this.SiteUserInfo.UserId;
                            model.WorkStatus = (AdminCenterStructure.WorkStatus)(Utils.GetInt(atttype));
                            model.BeginDate = Utils.GetDateTime(stime).AddDays(j);
                            model.AddDate = Utils.GetDateTime(stime).AddDays(j);
                            model.EndDate = Utils.GetDateTime(etime).AddDays(-total.Days + j);
                            model.Reason = sub;
                            model.OutTime = (AdminCenterStructure.WorkStatus)(Utils.GetInt(atttype, 0)) == AdminCenterStructure.WorkStatus.加班 ? Utils.GetDecimal(timecount) : 1; ;
                            model.IssueTime = DateTime.Now;
                            model.OperatorId = this.SiteUserInfo.UserId;
                            list.Add(model);
                        }

                    }
                    //多出的小时数
                    if (total.Hours > 0)
                    {
                        for (int i = 0; i < arryIds.Length; i++)
                        {
                            var model = new AttendanceInfo();
                            model.StaffNo = Utils.GetIntNull(arryIds[i]);
                            model.CompanyId = this.SiteUserInfo.CompanyId;
                            model.OperatorId = this.SiteUserInfo.UserId;
                            model.WorkStatus = (AdminCenterStructure.WorkStatus)(Utils.GetInt(atttype));
                            model.AddDate = Utils.GetDateTime(stime).AddDays(total.Days);
                            model.BeginDate = Utils.GetDateTime(stime).AddDays(total.Days);
                            model.EndDate = Utils.GetDateTimeNullable(etime);
                            model.Reason = sub;
                            model.OutTime = (AdminCenterStructure.WorkStatus)(Utils.GetInt(atttype, 0)) == AdminCenterStructure.WorkStatus.加班 ? Utils.GetDecimal(timecount) : 1; ;
                            model.IssueTime = DateTime.Now;
                            model.OperatorId = this.SiteUserInfo.UserId;
                            list.Add(model);
                        }
                    }
                }
            }
            #endregion

            #region 提交验证
            var BLL = new EyouSoft.BLL.AdminCenterStructure.AttendanceInfo();
            bool result = BLL.Add(list);
            msg = result ? "批量考勤成功！" : "批量考勤失败！";
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            Response.End();
            #endregion
        }


        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_考勤管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_考勤管理_栏目, false);
            }
            else
            {
                IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_考勤管理_登记);
            }
        }
        #endregion

        #region 重写OnPreInit
        /// <summary>
        /// 重写OnPreInit 指定页面类型
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = PageType.boxyPage;
        }
        #endregion
    }
}
