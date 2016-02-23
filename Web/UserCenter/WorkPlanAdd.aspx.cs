using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class WorkPlanAdd : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ajax--
            string type = Utils.GetQueryStringValue("Type");
            if (!string.IsNullOrEmpty(type))
            {
                Response.Clear();
                Response.Write(DoAjax(type));
                Response.End();
            }

            if (!IsPostBack)
            {
                this.SellsSelect1.SMode = true;
                this.UploadControl1.IsUploadSelf = true;
                this.UploadControl1.CompanyID = SiteUserInfo.CompanyId;

                this.rbStatus.DataSource = BindStatus();
                this.rbStatus.DataTextField = "Text";
                this.rbStatus.DataValueField = "Value";
                this.rbStatus.DataBind();

                string _do = Utils.GetQueryStringValue("do");
                InitData(_do);
            }

        }


        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="_do"></param>
        private void InitData(string _do)
        {
            switch (_do)
            {
                case "_add":

                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作计划新增))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作计划新增)));
                        return;
                    }

                    this.btnSave.Visible = true;
                    this.ltPlanTitle.Text = "新增工作计划";
                    this.ltName.Text = SiteUserInfo.Name;
                    this.ltCreateTime.Text = DateTime.Now.ToString("yyy-MM-dd");

                    break;
                case "_update":

                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作计划修改))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作计划修改)));
                        return;
                    }

                    this.ltPlanTitle.Text = "修改工作计划";
                    InitData();
                    break;
                case "_check":
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作计划审批))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作计划审批)));
                        return;
                    }

                    this.ltPlanTitle.Text = "审核工作计划";
                    InitData();
                    break;

            }
        }


        private void InitData()
        {
            int id = Utils.GetInt(Utils.GetQueryStringValue("Id"));
            EyouSoft.BLL.PersonalCenterStructure.WorkPlan bll = new EyouSoft.BLL.PersonalCenterStructure.WorkPlan();
            EyouSoft.Model.PersonalCenterStructure.WorkPlan model = bll.GetModel(id);
            if (model != null)
            {
                this.hidId.Value = model.PlanId.ToString();//

                if (!string.IsNullOrEmpty(model.FilePath))
                {
                    this.lblFilePath.Text = string.Format("<span class='upload_filename'><a href='{0}'>文档附件</a><a href=\"javascript:void(0)\" onclick=\"Plan.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" id=\"hidFilePath\" name=\"hidFilePath\" value='{0}'/></span>", model.FilePath);
                }
                this.ltName.Text = model.OperatorName;
                this.ltCreateTime.Text = model.CreateTime.ToString("yyyy-MM-dd");
                this.txtPlanNo.Text = model.PlanNO;
                this.txtTitle.Text = model.Title;
                this.txtContent.Text = model.Description;
                this.txtRemark.Text = model.Remark;
                this.rbStatus.SelectedValue = ((int)model.Status).ToString();
                this.txtExpectedDate.Value = model.ExpectedDate.HasValue ? model.ExpectedDate.Value.ToString("yyyy-MM-dd") : "";
                this.txtActualDate.Value = model.ActualDate.HasValue ? model.ActualDate.Value.ToString("yyyy-MM-dd") : "";

                if (model.AcceptList != null)
                {
                    string ids = null;
                    string names = null;
                    foreach (var item in model.AcceptList)
                    {
                        ids += item.AccetpId + ",";
                        names += item.AccetpName + ",";
                    }

                    this.SellsSelect1.SellsID = ids.Substring(0, ids.Length - 1);
                    this.SellsSelect1.SellsName = names.Substring(0, names.Length - 1);


                    int flg = model.AcceptList.Count(c => c.PlanId == id && c.AccetpId == SiteUserInfo.UserId);

                    if (flg != 0)
                    {
                        //是否审核
                        if (model.IsCheck)
                        {
                            this.txtManagerComment.Text = model.ManagerComment;
                            this.ltCheckMan.Text = model.CheckName;
                            this.phCheck.Visible = true;
                            this.phCheckMan.Visible = true;
                        }
                        else
                        {
                            this.phCheck.Visible = true;
                            this.btnCheck.Visible = true;
                        }

                    }
                    else
                    {
                        //是否审核
                        if (model.IsCheck)
                        {
                            if (model.OperatorId == SiteUserInfo.UserId)
                            {
                                this.txtManagerComment.Text = model.ManagerComment;
                                this.ltCheckMan.Text = model.CheckName;
                                this.phCheck.Visible = true;
                                this.phCheckMan.Visible = true;

                            }
                            else
                            {
                                this.phCheck.Visible = false;
                                this.phCheckMan.Visible = false;
                            }
                        }
                        else
                        {
                            if (model.OperatorId == SiteUserInfo.UserId)
                            {
                                this.btnUpdate.Visible = true;
                            }
                        }
                    }

                }
                else
                {
                    if (model.IsCheck)
                    {
                        this.txtManagerComment.Text = model.ManagerComment;
                        this.ltCheckMan.Text = model.CheckName;
                        this.phCheck.Visible = true;
                        this.phCheckMan.Visible = true;
                    }
                    else
                    {
                        if (SiteUserInfo.UserId == model.OperatorId)
                        {
                            this.btnUpdate.Visible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string DoAjax(string type)
        {
            string msg = string.Empty;

            string planNo = Utils.GetFormValue(this.txtPlanNo.UniqueID);
            string acceptIds = Utils.GetFormValue(this.SellsSelect1.SellsIDClient);
            string title = Utils.GetFormValue(this.txtTitle.UniqueID);
            string content = Utils.GetFormValue(this.txtContent.UniqueID);

            string filePath = Utils.GetFormValue(this.UploadControl1.ClientHideID);
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = Utils.GetFormValue("hidFilePath");
            }
            else
            {
                filePath = filePath.Split('|')[1];
            }

            string remark = Utils.GetFormValue(this.txtRemark.UniqueID);

            string expectedDate = Utils.GetFormValue(this.txtExpectedDate.UniqueID);

            string actualDate = Utils.GetFormValue(this.txtActualDate.UniqueID);


            string status = Utils.GetFormValue(this.rbStatus.UniqueID);


            switch (type)
            {
                case "Save":
                    if (string.IsNullOrEmpty(planNo))
                    {
                        msg += "计划编号不能为空! </br>";
                    }
                    if (string.IsNullOrEmpty(acceptIds))
                    {
                        msg += "接收人不能为空！</br>";
                    }
                    if (string.IsNullOrEmpty(title))
                    {
                        msg += "计划标题不能为空！</br>";
                    }

                    if (string.IsNullOrEmpty(content))
                    {
                        msg += "计划内容不能为空！</br>";
                    }
                    if (string.IsNullOrEmpty(remark))
                    {
                        msg += "计划说明不能为空！</br>";
                    }
                    if (string.IsNullOrEmpty(expectedDate))
                    {
                        msg += "预计完成时间不能为空！</br>";
                    }

                    if (string.IsNullOrEmpty(status))
                    {
                        msg += "状态不能为空！</br>";
                    }

                    if (msg.Length <= 0)
                    {
                        EyouSoft.Model.PersonalCenterStructure.WorkPlan s_model = new EyouSoft.Model.PersonalCenterStructure.WorkPlan();

                        s_model.CompanyId = SiteUserInfo.CompanyId;
                        s_model.PlanNO = planNo;
                        s_model.Title = title;
                        s_model.Description = content;
                        s_model.FilePath = filePath;
                        s_model.Remark = remark;
                        s_model.OperatorId = SiteUserInfo.UserId;
                        s_model.ExpectedDate = Utils.GetDateTimeNullable(expectedDate);
                        s_model.ActualDate = Utils.GetDateTimeNullable(actualDate);
                        s_model.Status = (EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState)Utils.GetInt(status);
                        s_model.CreateTime = DateTime.Now;
                        s_model.WorkType = EyouSoft.Model.EnumType.PersonalCenterStructure.WorkType.工作计划;

                        string[] ids = acceptIds.Split(',');
                        if (ids.Length != 0)
                        {
                            //接收人：
                            s_model.AcceptList = new List<EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept>();
                            foreach (var item in ids)
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept accept = new EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept();
                                    accept.AccetpId = Utils.GetInt(item);
                                    s_model.AcceptList.Add(accept);
                                }
                            }
                        }

                        EyouSoft.BLL.PersonalCenterStructure.WorkPlan bll = new EyouSoft.BLL.PersonalCenterStructure.WorkPlan();
                        if (bll.Add(s_model))
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
                    break;
                case "Update":
                    if (string.IsNullOrEmpty(planNo))
                    {
                        msg += "计划编号不能为空! </br>";
                    }
                    if (string.IsNullOrEmpty(acceptIds))
                    {
                        msg += "接收人不能为空！</br>";
                    }
                    if (string.IsNullOrEmpty(title))
                    {
                        msg += "计划标题不能为空！</br>";
                    }

                    if (string.IsNullOrEmpty(content))
                    {
                        msg += "计划内容不能为空！</br>";
                    }
                    if (string.IsNullOrEmpty(remark))
                    {
                        msg += "计划说明不能为空！</br>";
                    }
                    if (string.IsNullOrEmpty(expectedDate))
                    {
                        msg += "预计完成时间不能为空！</br>";
                    }

                    if (string.IsNullOrEmpty(status))
                    {
                        msg += "状态不能为空！</br>";
                    }

                    if (msg.Length <= 0)
                    {
                        EyouSoft.Model.PersonalCenterStructure.WorkPlan u_model = new EyouSoft.Model.PersonalCenterStructure.WorkPlan();
                        u_model.PlanId = Utils.GetInt(Utils.GetFormValue(this.hidId.UniqueID));
                        u_model.CompanyId = SiteUserInfo.CompanyId;
                        u_model.PlanNO = planNo;
                        u_model.Title = title;
                        u_model.Description = content;
                        u_model.FilePath = filePath;
                        u_model.Remark = remark;
                        u_model.OperatorId = SiteUserInfo.UserId;
                        u_model.ExpectedDate = Utils.GetDateTimeNullable(expectedDate);
                        u_model.ActualDate = Utils.GetDateTimeNullable(actualDate);
                        u_model.Status = (EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState)Utils.GetInt(status);
                        u_model.CreateTime = DateTime.Now;
                        u_model.WorkType = EyouSoft.Model.EnumType.PersonalCenterStructure.WorkType.工作计划;

                        string[] ids = acceptIds.Split(',');
                        if (ids.Length != 0)
                        {
                            //接收人：
                            u_model.AcceptList = new List<EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept>();
                            foreach (var item in ids)
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept accept = new EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept();
                                    accept.AccetpId = Utils.GetInt(item);
                                    u_model.AcceptList.Add(accept);
                                }
                            }
                        }
                        EyouSoft.BLL.PersonalCenterStructure.WorkPlan bll = new EyouSoft.BLL.PersonalCenterStructure.WorkPlan();
                        int flg = bll.Update(u_model);
                        // -1:审核 不允许修改 1:修改成功 0:修改失败
                        if (flg == 1)
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "修改成功！");
                        }
                        else if (flg == -1)
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "审核部允许修改！");
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
                    break;
                case "Check":
                    string comment = Utils.GetFormValue(this.txtManagerComment.UniqueID);
                    if (string.IsNullOrEmpty(comment))
                    {
                        msg += "审核评论不能为空！";
                    }
                    if (msg.Length <= 0)
                    {
                        EyouSoft.Model.PersonalCenterStructure.WorkPlan c_model = new EyouSoft.Model.PersonalCenterStructure.WorkPlan();
                        c_model.PlanId = Utils.GetInt(Utils.GetFormValue(this.hidId.UniqueID));
                        c_model.CheckId = SiteUserInfo.UserId;
                        c_model.ActualDate = DateTime.Now;
                        c_model.IsCheck = true;
                        c_model.ManagerComment = comment;
                        EyouSoft.BLL.PersonalCenterStructure.WorkPlan cbll = new EyouSoft.BLL.PersonalCenterStructure.WorkPlan();
                        if (cbll.Check(c_model))
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "审核成功！");
                        }
                        else
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "审核失败！");
                        }
                    }
                    else
                    {
                        msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", msg);
                    }

                    break;
            }
            return msg;
        }

        /// <summary>
        /// 绑定状态
        /// </summary>
        /// <returns></returns>
        protected List<EnumObj> BindStatus()
        {

            return EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState));
        }

    }
}
