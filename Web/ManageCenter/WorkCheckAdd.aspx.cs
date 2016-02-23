namespace Web.ManageCenter
{
    using System;
    using System.Collections.Generic;

    using EyouSoft.BLL.AdminCenterStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;
    using EyouSoft.Model.EnumType;
    using EyouSoft.Model.EnumType.PrivsStructure;

    public partial class WorkCheckAdd : BackPage
    {
        #region Constants and Fields

        /// <summary>
        /// 是否有操作权限
        /// </summary>
        protected bool IsAddGrant;

        #endregion

        #region Methods

        /// <summary>
        /// 重写OnPreInit 指定页面类型
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = PageType.boxyPage;
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="id">操作ID</param>
        protected void PageInit(string doType)
        {
            //考勤编号
            string attId = Utils.GetQueryStringValue("attID");
            //如果为修改
            if (doType == "update" && !string.IsNullOrEmpty(attId))
            {
                var BLL = new AttendanceInfo();
                EyouSoft.Model.AdminCenterStructure.AttendanceInfo model = BLL.GetModel(
                    this.SiteUserInfo.CompanyId, attId);
                if (model != null)
                {
                    //考勤编号
                    this.attentID.Value = model.Id;
                    //考勤类型
                    this.attType.Value = ((int)model.WorkStatus).ToString();
                    //员工编号
                    this.staffID.Value = model.StaffNo.Value.ToString();
                    //开始时间
                    this.sTime.Value = model.BeginDate.HasValue
                                           ? model.BeginDate.Value.ToString("yyyy-MM-dd HH:mm")
                                           : "";
                    //结束时间
                    this.eTime.Value = model.EndDate.HasValue ? model.EndDate.Value.ToString("yyyy-MM-dd HH:mm") : "";
                    //考勤时间
                    this.tbtime.Text = model.AddDate.ToString("yyyy-MM-dd");
                    //原因
                    this.subject.Value = model.Reason;
                    //请假天数/加班时数
                    this.timeCount.Value = model.OutTime.ToString();
                }
            }
            else //考勤登记
            {
                //员工编号
                string id = Utils.GetQueryStringValue("id");
                //员工部门编号
                string deptid = Utils.GetQueryStringValue("deptid");
                //考勤默认时间为当前日期
                this.tbtime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                this.deptID.Value = deptid;
                this.staffID.Value = id;
            }
        }

        /// <summary>
        /// 保存
        /// <param name="id">考勤ID</param>
        /// </summary>
        protected void PageSave(string doType)
        {
            #region 表单取值

            //考勤编号
            string attid = Utils.GetFormValue(this.attentID.UniqueID);
            //员工编号
            string staffid = Utils.GetFormValue(this.staffID.UniqueID);
            //考勤时间
            string atttime = Utils.GetFormValue(this.tbtime.UniqueID);
            //考勤类型
            string atttype = Utils.GetFormValue(this.attType.UniqueID);
            //开始时间
            string stime = Utils.GetFormValue(this.sTime.UniqueID);
            //结束时间
            string etime = Utils.GetFormValue(this.eTime.UniqueID);
            //天数/时数
            string count = Utils.GetFormValue(this.timeCount.UniqueID);
            //理由
            string sub = Utils.GetFormValue(this.subject.UniqueID);

            #endregion

            #region 表单验证

            string msg = string.Empty;
            if (string.IsNullOrEmpty(atttime) && Utils.GetInt(atttype, 0) < 7)
            {
                msg += "请选择考勤时间！<br/>";
            }
            if (string.IsNullOrEmpty(stime) && Utils.GetInt(atttype, 0) > 6)
            {
                msg += "请选择开始时间！<br/>";
            }
            if (string.IsNullOrEmpty(etime) && Utils.GetInt(atttype, 0) > 6)
            {
                msg += "请选择结束时间！<br/>";
            }
            if (string.IsNullOrEmpty(sub) && Utils.GetInt(atttype, 0) > 6)
            {
                msg += "请输入原因！<br/>";
            }
            if (!string.IsNullOrEmpty(msg))
            {
                this.Response.Clear();
                this.Response.Write(UtilsCommons.AjaxReturnJson("0", msg));
                this.Response.End();
            }

            #endregion

            #region 实体赋值

            var list = new List<EyouSoft.Model.AdminCenterStructure.AttendanceInfo>();
            var model = new EyouSoft.Model.AdminCenterStructure.AttendanceInfo();
            model.Id = attid;
            model.AddDate = Utils.GetDateTime(atttime);
            model.WorkStatus = (AdminCenterStructure.WorkStatus)(Utils.GetInt(atttype, 0));
            model.CompanyId = this.SiteUserInfo.CompanyId;
            model.EndDate = string.IsNullOrEmpty(etime)
                                ? Utils.GetDateTimeNullable(atttime)
                                : Utils.GetDateTimeNullable(etime);
            model.IssueTime = DateTime.Now;
            model.OperatorId = this.SiteUserInfo.UserId;
            model.StaffNo = Utils.GetIntNull(staffid);
            model.BeginDate = string.IsNullOrEmpty(stime)
                                  ? Utils.GetDateTimeNullable(atttime)
                                  : Utils.GetDateTimeNullable(stime);
            model.Reason = sub;
            //全、迟、退、旷工 算一天 其他的用户自己填
            model.OutTime = string.IsNullOrEmpty(count) ? 1 : Utils.GetDecimal(count);
            list.Add(model);

            #endregion

            #region 提交保存

            var BLL = new AttendanceInfo();
            bool result = BLL.Update(this.SiteUserInfo.CompanyId, list, Utils.GetDateTime(atttime));
            msg = result ? "提交保存成功！" : "提交保存失败";
            this.Response.Clear();
            this.Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            this.Response.End();

            #endregion
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //权限验证
            this.PowerControl();

            #region 处理AJAX请求

            //获取ajax请求
            string save = Utils.GetQueryStringValue("save");
            string doType = Utils.GetQueryStringValue("doType");
            //存在ajax请求
            if (save == "save")
            {
                this.PageSave(doType);
            }

            #endregion

            if (!this.IsPostBack)
            {
                //根据ID初始化页面
                this.PageInit(doType);
            }
        }

        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(Privs3.行政中心_考勤管理_栏目))
            {
                Utils.ResponseNoPermit(Privs3.行政中心_考勤管理_栏目, false);
            }
            else
            {
                this.IsAddGrant = this.CheckGrant(Privs3.行政中心_考勤管理_登记);
            }
        }

        #endregion
    }
}