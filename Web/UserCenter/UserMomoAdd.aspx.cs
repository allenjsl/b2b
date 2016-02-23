using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.UserCenter
{
    public partial class UserMomoAdd : EyouSoft.Common.Page.BackPage
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
                        Response.Write(Update());
                        Response.End();
                        break;
                }
            }

            if (!IsPostBack)
            {
                string _do = Utils.GetQueryStringValue("do");
                if (!string.IsNullOrEmpty(_do))
                {
                    switch (_do)
                    {
                        case "_add":

                            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_个人备忘_新增))
                            {
                                this.RCWE(
                                    UtilsCommons.AjaxReturnJson(
                                        "0",
                                        string.Format(
                                            "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_个人备忘_新增)));
                                return;
                            }

                            this.btnSave.Visible = true;
                            GetStatus(null);
                            break;
                        case "_update":
                            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_个人备忘_修改))
                            {
                                this.RCWE(
                                    UtilsCommons.AjaxReturnJson(
                                        "0",
                                        string.Format(
                                            "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_个人备忘_修改)));
                                return;
                            }

                            int id = Utils.GetInt(Utils.GetQueryStringValue("Id"));
                            this.btnUpdate.Visible = true;
                            InitData(id);
                            break;
                        default:
                            InitData(Utils.GetInt(Utils.GetQueryStringValue("Id")));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData(int id)
        {
            EyouSoft.BLL.PersonalCenterStructure.BUserMemo bll = new EyouSoft.BLL.PersonalCenterStructure.BUserMemo();
            EyouSoft.Model.PersonalCenterStructure.UserMemorandum model = bll.GetMdl(id);
            if (model != null)
            {
                this.txtTitle.Value = model.Title;
                this.txtContent.Value = model.Content;
                this.txtDate.Value = model.AlertTime.ToString("yyyy-MM-dd");
                GetStatus((int)model.State);
                this.hidId.Value = model.Id.ToString();
            }
        }


        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected void GetStatus(int? selectItem)
        {
            Array values = Enum.GetValues(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState));

            //why value is enum text？？？

            if (values.Length != 0)
            {
                foreach (var item in values)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = ((int)item).ToString();
                    listItem.Text = Enum.GetName(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState), item);
                    this.ddlStatus.Items.Add(listItem);
                }
            }

            this.ddlStatus.Items.Insert(0, new ListItem("请选择...", ""));

            if (selectItem.HasValue)
            {
                this.ddlStatus.SelectedValue = selectItem.Value.ToString();
            }


            //StringBuilder query = new StringBuilder();
            //query.Append("<option value=''>-请选择完成状况-</option>");

            //Array values = Enum.GetValues(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState));
            //if (values.Length != 0)
            //{
            //    foreach (var item in values)
            //    {
            //        int value = (int)Enum.Parse(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState), item.ToString());


            //        string text = Enum.GetName(typeof(EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState), item);
            //        if (selectItem == value)
            //        {
            //            query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", value, text);
            //        }
            //        else
            //        {
            //            query.AppendFormat("<option value='{0}' >{1}</option>", value, text);
            //        }
            //    }
            //}

            //return query.ToString();
        }

        /// <summary>
        /// 添加保存
        /// </summary>
        /// <returns></returns>
        private string Save()
        {
            string msg = string.Empty;
            string title = Utils.GetFormValue(this.txtTitle.UniqueID);
            string time = Utils.GetFormValue(this.txtDate.UniqueID);
            string content = Utils.GetFormValue(this.txtContent.UniqueID);

            string status = Utils.GetFormValue(this.ddlStatus.UniqueID);

            if (string.IsNullOrEmpty(title))
            {
                msg += "主题不能为空！ </br>";
            }

            if (string.IsNullOrEmpty(time))
            {
                msg += "时间不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(content))
            {
                msg += "内容不能为确！ </br>";
            }
            if (string.IsNullOrEmpty(status))
            {
                msg += "请选择完成状况！ </br>";
            }

            if (title.Length > 255) {
                msg += "主题内容过长！ </br>";
            }

            if (content.Length > 255)
            {
                msg += "输入内容过长！ </br>";
            }

            if (msg.Length <= 0)
            {

                EyouSoft.Model.PersonalCenterStructure.UserMemorandum model = new EyouSoft.Model.PersonalCenterStructure.UserMemorandum();
                model.Title = title;
                model.AlertTime = Utils.GetDateTime(time);
                model.Content = content;
                model.State = (EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState)Utils.GetInt(status);
                model.UserId = SiteUserInfo.UserId;
                model.IssueTime = DateTime.Now;
                model.CompanyId = SiteUserInfo.CompanyId;
                model.ZxsId = CurrentZxsId;
                EyouSoft.BLL.PersonalCenterStructure.BUserMemo bll = new EyouSoft.BLL.PersonalCenterStructure.BUserMemo();

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
        /// 修改
        /// </summary>
        /// <returns></returns>
        private string Update()
        {
            string msg = string.Empty;
            string title = Utils.GetFormValue(this.txtTitle.UniqueID);
            string time = Utils.GetFormValue(this.txtDate.UniqueID);
            string content = Utils.GetFormValue(this.txtContent.UniqueID);

            string status = Utils.GetFormValue(this.ddlStatus.UniqueID);

            if (string.IsNullOrEmpty(title))
            {
                msg += "主题不能为空！ </br>";
            }

            if (string.IsNullOrEmpty(time))
            {
                msg += "时间不能为空！ </br>";
            }
            if (string.IsNullOrEmpty(content))
            {
                msg += "内容不能为确！ </br>";
            }
            if (string.IsNullOrEmpty(status))
            {
                msg += "请选择完成状况！ </br>";
            }

            if (content.Length > 255)
            {
                msg += "输入内容过长！ </br>";
            }

            if (msg.Length <= 0)
            {
                EyouSoft.BLL.PersonalCenterStructure.BUserMemo bll = new EyouSoft.BLL.PersonalCenterStructure.BUserMemo();
                EyouSoft.Model.PersonalCenterStructure.UserMemorandum model = new EyouSoft.Model.PersonalCenterStructure.UserMemorandum();
                model.Id = Utils.GetInt(Utils.GetFormValue(this.hidId.UniqueID));
                model.Title = title;
                model.AlertTime = Utils.GetDateTime(time);
                model.Content = content;
                model.State = (EyouSoft.Model.EnumType.PersonalCenterStructure.MemorandumState)Utils.GetInt(status);

                if (bll.Upd(model))
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "修改成功！");
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

    }
}
