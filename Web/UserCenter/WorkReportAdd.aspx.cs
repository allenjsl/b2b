using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class WorkReportAdd : EyouSoft.Common.Page.BackPage
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
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作汇报新增))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作汇报新增)));
                        return;
                    }

                    this.btnSave.Visible = true;
                    this.ltReportMan.Text = SiteUserInfo.Name;
                    this.ltReportTime.Text = DateTime.Now.ToShortDateString();
                    break;
                case "_update":
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作汇报修改))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作汇报修改)));
                        return;
                    }

                    InitUpdateData();
                    break;
                case "_check":
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作汇报审批))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作汇报审批)));
                        return;
                    }

                    InitCheck();
                    break;

            }
        }


        private void InitUpdateData()
        {
            this.ltTitle.Text = "修改工作汇报";
            int id = Utils.GetInt(Utils.GetQueryStringValue("Id"));
            EyouSoft.BLL.PersonalCenterStructure.WorkReport bll = new EyouSoft.BLL.PersonalCenterStructure.WorkReport();
            EyouSoft.Model.PersonalCenterStructure.WorkReport model = bll.GetModel(id);
            if (model != null)
            {
                this.hidId.Value = model.ReportId.ToString();
                if (!string.IsNullOrEmpty(model.FilePath))
                {
                    this.lblFilePath.Text = string.Format("<span class='upload_filename'><a href='{0}'>文档附件</a><a href=\"javascript:void(0)\" onclick=\"Report.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" id=\"hidFilePath\" name=\"hidFilePath\" value='{0}'/></span>", model.FilePath);
                }
                this.ltReportMan.Text = model.OperatorName;
                this.ltReportTime.Text = model.ReportingTime.ToString("yyyy-MM-dd");
                this.txtTitle.Text = model.Title;
                this.txtContent.Text = model.Description;
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

                }

                if (model.Status == EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState.已审核)
                {
                    this.phCheck.Visible = true;
                    this.phCheckPeople.Visible = true;
                    this.ltPeople.Text = model.OperatorName;
                    this.txtComment.Text = model.Comment;
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

        private void InitCheck()
        {
            this.ltTitle.Text = "审核工作汇报";
            int id = Utils.GetInt(Utils.GetQueryStringValue("Id"));
            EyouSoft.BLL.PersonalCenterStructure.WorkReport bll = new EyouSoft.BLL.PersonalCenterStructure.WorkReport();
            EyouSoft.Model.PersonalCenterStructure.WorkReport model = bll.GetModel(id);
            if (model != null)
            {
                this.hidId.Value = model.ReportId.ToString();
                if (!string.IsNullOrEmpty(model.FilePath))
                {
                    this.lblFilePath.Text = string.Format("<span class='upload_filename'><a href='{0}'>文档附件</a><a href=\"javascript:void(0)\" onclick=\"Report.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" id=\"hidFilePath\" name=\"hidFilePath\" value='{0}'/></span>", model.FilePath);
                }
                this.ltReportMan.Text = model.OperatorName;
                this.ltReportTime.Text = model.ReportingTime.ToString("yyyy-MM-dd");
                this.txtTitle.Text = model.Title;
                this.txtContent.Text = model.Description;
                if (model.AcceptList != null)
                {
                    string ids = null;
                    string names = null;
                    foreach (var item in model.AcceptList)
                    {
                        ids += item.AccetpId + ",";
                        names += item.AccetpName + ",";
                    }

                    this.SellsSelect1.SellsID = ids.Substring(0,ids.Length-1);
                    this.SellsSelect1.SellsName = names.Substring(0,names.Length-1);

                }

                if (model.Status == EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState.已审核)
                {
                    this.phCheck.Visible = true;
                    this.phCheckPeople.Visible = true;
                    this.ltPeople.Text = model.OperatorName;
                    this.txtComment.Text = model.Comment;

                }
                else
                {
                    int flg = model.AcceptList.Count(c => c.PlanId == id && c.AccetpId == SiteUserInfo.UserId);
                    if (flg != 0)
                    {
                        this.phCheck.Visible = true;
                        this.btnCheck.Visible = true;
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

            string title = Utils.GetFormValue(this.txtTitle.UniqueID);
            string content = Utils.GetFormValue(this.txtContent.UniqueID);
            string acceptIds = Utils.GetFormValue(this.SellsSelect1.SellsIDClient);
            string filePath = Utils.GetFormValue(this.UploadControl1.ClientHideID);
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = Utils.GetFormValue("hidFilePath");
            }
            else
            {
                filePath = filePath.Split('|')[1];
            }

            switch (type)
            {
                case "Save":

                    if (string.IsNullOrEmpty(title))
                    {
                        msg += "标题不能为空！</br>";
                    }

                    if (string.IsNullOrEmpty(content))
                    {
                        msg += "汇报内容不能为空！</br>";
                    }

                    if (string.IsNullOrEmpty(acceptIds))
                    {
                        msg += "请选择接收人！</br>";
                    }
                    if (msg.Length <= 0)
                    {

                        EyouSoft.Model.PersonalCenterStructure.WorkReport model = new EyouSoft.Model.PersonalCenterStructure.WorkReport();
                        model.CompanyId = SiteUserInfo.CompanyId;
                        model.Title = title;
                        model.Description = content;
                        model.FilePath = filePath;
                        model.DepartmentId = SiteUserInfo.DeptId;
                        model.OperatorId = SiteUserInfo.UserId;
                        model.ReportingTime = DateTime.Now;
                        model.Status = EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState.未审核;
                        model.WorkType = EyouSoft.Model.EnumType.PersonalCenterStructure.WorkType.工作汇报;

                        string[] ids = acceptIds.Split(',');
                        if (ids.Length != 0)
                        {
                            //接收人：
                            model.AcceptList = new List<EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept>();
                            foreach (var item in ids)
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept accept = new EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept();
                                    accept.AccetpId = Utils.GetInt(item);
                                    model.AcceptList.Add(accept);
                                }
                            }
                        }

                        EyouSoft.BLL.PersonalCenterStructure.WorkReport bll = new EyouSoft.BLL.PersonalCenterStructure.WorkReport();
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

                    break;

                case "Update":

                    if (string.IsNullOrEmpty(title))
                    {
                        msg += "标题不能为空！</br>";
                    }

                    if (string.IsNullOrEmpty(content))
                    {
                        msg += "汇报内容不能为空！</br>";
                    }

                    if (string.IsNullOrEmpty(acceptIds))
                    {
                        msg += "请选择接收人！</br>";
                    }
                    if (msg.Length <= 0)
                    {
                        EyouSoft.Model.PersonalCenterStructure.WorkReport model = new EyouSoft.Model.PersonalCenterStructure.WorkReport();
                        model.ReportId = Utils.GetInt(Utils.GetFormValue(this.hidId.UniqueID));
                        model.Title = title;
                        model.Description = content;
                        model.FilePath = filePath;
                        model.Status = EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState.未审核;
                        model.WorkType = EyouSoft.Model.EnumType.PersonalCenterStructure.WorkType.工作汇报;
                        model.ReportingTime = Utils.GetDateTime(this.ltReportTime.Text);
                        model.CompanyId = SiteUserInfo.CompanyId;

                        string[] ids = acceptIds.Split(',');
                        if (ids.Length != 0)
                        {
                            //接收人：
                            model.AcceptList = new List<EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept>();
                            foreach (var item in ids)
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept accept = new EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept();
                                    accept.AccetpId = Utils.GetInt(item);
                                    model.AcceptList.Add(accept);
                                }
                            }
                        }

                        EyouSoft.BLL.PersonalCenterStructure.WorkReport bll = new EyouSoft.BLL.PersonalCenterStructure.WorkReport();
                        int flg = bll.Update(model);
                        if (flg == 1)
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "修改成功！");
                        }
                        else if (flg == -1)
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "汇报已审核部允许修改！");
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
                    string Comment = Utils.GetFormValue(this.txtComment.UniqueID);
                    if (string.IsNullOrEmpty(Comment))
                    {
                        msg += "请填写评语！ </br>";
                    }
                    if (msg.Length <= 0)
                    {
                        EyouSoft.Model.PersonalCenterStructure.WorkReport cmodel = new EyouSoft.Model.PersonalCenterStructure.WorkReport();
                        cmodel.ReportId = Utils.GetInt(Utils.GetFormValue(this.hidId.UniqueID));
                        cmodel.Comment = Comment;
                        cmodel.CheckerId = SiteUserInfo.UserId;
                        cmodel.CheckTime = DateTime.Now;
                        cmodel.Status = EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState.已审核;

                        EyouSoft.BLL.PersonalCenterStructure.WorkReport cbll = new EyouSoft.BLL.PersonalCenterStructure.WorkReport();
                        if (cbll.SetChecked(cmodel))
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "审核成功！");
                        }
                        else
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "审核失败！");
                        }
                    }
                    else
                    {
                        msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", msg);
                    }

                    break;
                default:
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "操作失败!");
                    break;


            }



            return msg;
        }





    }
}