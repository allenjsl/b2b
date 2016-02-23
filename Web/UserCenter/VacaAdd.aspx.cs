using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class VacaAdd : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ajax
            string type = Utils.GetQueryStringValue("Type");
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "Save":
                        Response.Clear();
                        Response.Write(Save());
                        Response.End();
                        break;
                    case "Update":
                        Response.Clear();
                        Response.Write(Update(Utils.GetInt(Utils.GetFormValue(this.hidId.UniqueID))));
                        Response.End();
                        break;
                }
            }

            if (!IsPostBack)
            {
                string _do = Utils.GetQueryStringValue("do");
                if (!string.IsNullOrEmpty(_do))
                {
                    int userId;
                    switch (_do)
                    {
                        case "_add":
                            this.btnSave.Visible = true;
                            BindStatus(null);
                            break;
                        case "_update":
                            int id = Utils.GetInt(Utils.GetQueryStringValue("Id"));
                            InitData(id, out userId);
                            if (userId == SiteUserInfo.UserId)
                            {
                                this.btnUpdate.Visible = true;
                            }
                            break;
                        default:
                            InitData(Utils.GetInt(Utils.GetQueryStringValue("Id")), out userId);
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="id"></param>
        protected void InitData(int id, out int UserId)
        {
            UserId = 0;
            EyouSoft.BLL.PersonalCenterStructure.BUserLeave bll = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave();
            EyouSoft.Model.PersonalCenterStructure.UserLeave model = bll.GetMdl(id);
            if (model != null)
            {
                UserId = model.UserId;
                this.txtEndDate.Value = model.EndDate.ToShortDateString();
                this.txtEndTime.Value = model.EndTime;
                this.txtReason.Value = model.Reason;
                this.txtSituation.Value = model.Situation;
                this.txtStartDate.Value = model.StartDate.ToShortDateString();
                this.txtStartTime.Value = model.StartTime;

                this.hidId.Value = model.LeaveId.ToString();
                BindStatus((int)model.Nature);


            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        protected string Save()
        {
            string msg = string.Empty;

            string StartDate = Utils.GetFormValue(this.txtStartDate.UniqueID);
            string StartTime = Utils.GetFormValue(this.txtStartTime.UniqueID);
            string EndDate = Utils.GetFormValue(this.txtEndDate.UniqueID);
            string EndTime = Utils.GetFormValue(this.txtEndTime.UniqueID);
            string Reason = Utils.GetFormValue(this.txtReason.UniqueID);
            string Status = Utils.GetFormValue(this.ddlStatus.UniqueID);
            string Situation = Utils.GetFormValue(this.txtSituation.UniqueID);

            if (string.IsNullOrEmpty(StartDate))
            {
                msg += "请假开始日期不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(StartTime))
            {
                msg += "请假开始时间不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(EndDate))
            {
                msg += "请假结束日期不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(EndTime))
            {
                msg += "请假结束时间不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(Reason))
            {
                msg += "请假原因不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(Status))
            {
                msg += "请选择请假性质！ </br>";
            }
            if (string.IsNullOrEmpty(Situation))
            {
                msg += "调班状况不能为空！ </br>";
            }

            if (Reason.Length > 255)
            {
                msg += "请假原因内容过长！ </br>";
            }

            if (msg.Length <= 0)
            {
                EyouSoft.Model.PersonalCenterStructure.UserLeave model = new EyouSoft.Model.PersonalCenterStructure.UserLeave();
                model.StartDate = Utils.GetDateTime(StartDate);
                model.StartTime = StartTime;
                model.EndDate = Utils.GetDateTime(EndDate);
                model.EndTime = EndTime;
                model.Reason = Reason;
                model.State = (EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState)Utils.GetInt(Status);
                model.Situation = Situation;


                model.CompanyId = SiteUserInfo.CompanyId;
                model.IssueTime = DateTime.Now;
                model.UserContactName = SiteUserInfo.Name;
                model.UserId = SiteUserInfo.UserId;
                model.ZxsId = CurrentZxsId;

                EyouSoft.BLL.PersonalCenterStructure.BUserLeave bll = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave();
                if (bll.Add(model))
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "添加成功！");
                }
                else
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "添加失败！");
                }
            }
            else
            {
                msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", msg);
            }

            return msg;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string Update(int id)
        {
            string msg = string.Empty;

            string StartDate = Utils.GetFormValue(this.txtStartDate.UniqueID);
            string StartTime = Utils.GetFormValue(this.txtStartTime.UniqueID);
            string EndDate = Utils.GetFormValue(this.txtEndDate.UniqueID);
            string EndTime = Utils.GetFormValue(this.txtEndTime.UniqueID);
            string Reason = Utils.GetFormValue(this.txtReason.UniqueID);
            string Status = Utils.GetFormValue(this.ddlStatus.UniqueID);
            string Situation = Utils.GetFormValue(this.txtSituation.UniqueID);

            if (string.IsNullOrEmpty(StartDate))
            {
                msg += "请假开始日期不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(StartTime))
            {
                msg += "请假开始时间不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(EndDate))
            {
                msg += "请假结束日期不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(EndTime))
            {
                msg += "请假结束时间不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(Reason))
            {
                msg += "请假原因不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(Status))
            {
                msg += "请选择请假性质！ </br>";
            }
            if (string.IsNullOrEmpty(Situation))
            {
                msg += "调班状况不能为空！ </br>";
            }

            if (msg.Length <= 0)
            {
                EyouSoft.Model.PersonalCenterStructure.UserLeave model = new EyouSoft.Model.PersonalCenterStructure.UserLeave();
                model.LeaveId = id;
                model.StartDate = Utils.GetDateTime(StartDate);
                model.StartTime = StartTime;
                model.EndDate = Utils.GetDateTime(EndDate);
                model.EndTime = EndTime;
                model.Reason = Reason;
                model.Nature = (EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveNature)Utils.GetInt(Status);
                model.Situation = Situation;

                EyouSoft.BLL.PersonalCenterStructure.BUserLeave bll = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave();
                int flg = bll.Upd(model);
                if (flg == 1)
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "修改成功！");
                }
                else if (flg == -1)
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "已审核的请假申请不允许修改！");
                }
                else
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "修改失败！");
                }
            }
            else
            {
                msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", msg);
            }

            return msg;
        }

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="id"></param>
        private void BindStatus(int? id)
        {
            List<EnumObj> list = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveNature));
            this.ddlStatus.DataSource = list;
            this.ddlStatus.DataTextField = "Text";
            this.ddlStatus.DataValueField = "Value";
            this.ddlStatus.DataBind();


            this.ddlStatus.Items.Insert(0, new ListItem("请选择...", ""));
            if (id.HasValue)
            {
                this.ddlStatus.SelectedValue = id.ToString();
            }
            
        }
    }
}
