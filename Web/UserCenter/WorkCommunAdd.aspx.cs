using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class WorkCommunAdd : EyouSoft.Common.Page.BackPage
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
                this.UploadControl1.IsUploadSelf = true;
                this.UploadControl1.CompanyID = SiteUserInfo.CompanyId;

                this.ddlStatus.DataSource = BindStatus();
                this.ddlStatus.DataTextField = "Text";
                this.ddlStatus.DataValueField = "Value";
                this.ddlStatus.DataBind();
                this.ddlStatus.Items.Insert(0, new ListItem("请选择交流类别...", ""));

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
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作交流新增))
                    {
                        this.RCWE(UtilsCommons.AjaxReturnJson("-1000","没有权限"));
                    }   

                    this.btnSave.Visible = true;
                    this.ltTitle.Text = "新增工作交流";
                    this.ltName.Text = SiteUserInfo.Name;
                    this.ltCreateDate.Text = DateTime.Now.ToString("yyy-MM-dd");
                    break;
                case "_update":
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作交流修改))
                    {
                        this.RCWE(UtilsCommons.AjaxReturnJson("-1000", "没有权限"));
                    }  

                    this.ltTitle.Text = "修改工作交流";
                    int id = Utils.GetInt(Utils.GetQueryStringValue("Id"));
                    EyouSoft.BLL.PersonalCenterStructure.WorkExchange bll = new EyouSoft.BLL.PersonalCenterStructure.WorkExchange();
                    EyouSoft.Model.PersonalCenterStructure.WorkExchange model = bll.GetModel(id);
                    if (model != null)
                    {
                        this.hidId.Value = model.ExchangeId.ToString();
                        this.ddlStatus.SelectedValue = ((int)model.Type).ToString();
                        this.txtTitle.Text = model.Title;
                        this.txtContent.Text = model.Description;
                        this.ltCreateDate.Text = model.CreateTime.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(model.FilePath))
                        {
                            this.lblFilePath.Text = string.Format("<span class='upload_filename'><a href='{0}'>文档附件</a><a href=\"javascript:void(0)\" onclick=\"Commun.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" id=\"hidFilePath\" name=\"hidFilePath\" value='{0}'/></span>", model.FilePath);
                        }
                        if (model.IsAnonymous)
                        {
                            this.cbIsAnonymous.Checked = true;
                        }
                        else
                        {
                            this.ltName.Text = model.OperatorName;
                        }

                        if (SiteUserInfo.UserId == model.OperatorId)
                        {
                            this.btnUpdate.Visible = true;
                        }
                    }
                    break;
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
            string status = Utils.GetFormValue(this.ddlStatus.UniqueID);
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

            if (string.IsNullOrEmpty(status))
            {
                msg += "交流类型不能为空! </br>";
            }
            if (string.IsNullOrEmpty(title))
            {
                msg += "标题不能为空! </br>";
            }
            if (string.IsNullOrEmpty(content))
            {
                msg += "内容不能为空！";
            }

            if (msg.Length <= 0)
            {
                EyouSoft.Model.PersonalCenterStructure.WorkExchange model = new EyouSoft.Model.PersonalCenterStructure.WorkExchange();
                model.CompanyId = SiteUserInfo.CompanyId;
                model.OperatorId = SiteUserInfo.UserId;
                model.Type = (EyouSoft.Model.EnumType.PersonalCenterStructure.ExchangeType)Utils.GetInt(status);
                model.Title = title;
                model.Description = content;
                model.CreateTime = DateTime.Now;
                model.FilePath = filePath;
                model.IsAnonymous = this.cbIsAnonymous.Checked;
                model.ZxsId = CurrentZxsId;

                EyouSoft.BLL.PersonalCenterStructure.WorkExchange bll = new EyouSoft.BLL.PersonalCenterStructure.WorkExchange();

                switch (type)
                {
                    case "Save":
                        if (bll.Add(model))
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "添加成功！");
                        }
                        else
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "添加失败！");
                        }
                        break;
                    case "Update":
                        model.ExchangeId = Utils.GetInt(Utils.GetFormValue(this.hidId.UniqueID));
                        if (bll.Update(model))
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "修改成功！");
                        }
                        else
                        {
                            msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "修改失败！");
                        }
                        break;
                }
            }
            else
            {
                msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", msg);
            }

            return msg;
        }

        /// <summary>
        /// 绑定状态
        /// </summary>
        /// <returns></returns>
        protected List<EnumObj> BindStatus()
        {

            return EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.ExchangeType));
        }



    }
}
