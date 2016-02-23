using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Function;

namespace Web.UserCenter
{
    public partial class UserInfo : EyouSoft.Common.Page.BackPage
    {
        protected string SetPwd;////ps:password 是无法从后台赋值的

        protected void Page_Load(object sender, EventArgs e)
        {
            //Ajax
            string type = Utils.GetQueryStringValue("Type");
            if (!string.IsNullOrEmpty(type))
            {
                if (type.Equals("Save"))
                {
                    Response.Write(Save());
                    Response.End();
                    Response.Clear();
                }
            }

            if (!IsPostBack)
            {
                InitData();
            }
        }


        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitData()
        {
            EyouSoft.BLL.CompanyStructure.CompanyUser bll = new EyouSoft.BLL.CompanyStructure.CompanyUser();
            EyouSoft.Model.CompanyStructure.CompanyUser model = bll.GetUserInfo(SiteUserInfo.UserId);
           // this.txtPwd.Value = model.PassWordInfo.NoEncryptPassword;
            this.txtName.Value = model.PersonInfo.ContactName;

            if (model.PersonInfo.ContactSex == EyouSoft.Model.EnumType.CompanyStructure.Sex.男)
            {
                this.rbman.Checked = true;
            }
            else
            {
                this.rbwoman.Checked = true;
            }
            SetPwd = model.PassWordInfo.NoEncryptPassword;

            this.ltJob.Text = model.PersonInfo.JobName;
            this.txtPhone.Value = model.PersonInfo.ContactTel;
            this.txtMobile.Value = model.PersonInfo.ContactMobile;
            this.txtFax.Value = model.PersonInfo.ContactFax;
            this.txtQQ.Value = model.PersonInfo.QQ;
            this.txtMsn.Value = model.PersonInfo.MSN;
            this.txtEmail.Value = model.PersonInfo.ContactEmail;


        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        private string Save()
        {
            string msg = string.Empty;
            string pwd = Utils.GetFormValue("txtPwd");
            if (string.IsNullOrEmpty(pwd))
            {
                msg += "请填写密码! </br>";
            }
            string name = Utils.GetFormValue(this.txtName.UniqueID);
            if (string.IsNullOrEmpty(name))
            {
                msg += "请填写姓名! </br>";
            }

            string mobile = Utils.GetFormValue(this.txtMobile.UniqueID);
            if (string.IsNullOrEmpty(mobile))
            {
                msg += "请填写手机号! </br>";
            }
            string email = Utils.GetFormValue(this.txtEmail.UniqueID);

            if (!string.IsNullOrEmpty(email) && new EyouSoft.BLL.CompanyStructure.CompanyUser().IsExistsEmail(email, SiteUserInfo.UserId, CurrentUserCompanyID))
            {
                msg += "邮箱已存在! </br>";
            }

            if (msg.Length <= 0)
            {
                
                EyouSoft.BLL.CompanyStructure.CompanyUser bll = new EyouSoft.BLL.CompanyStructure.CompanyUser();
                EyouSoft.Model.CompanyStructure.CompanyUser model = bll.GetUserInfo(SiteUserInfo.UserId);

                model.PassWordInfo.NoEncryptPassword = pwd;
                model.PersonInfo.ContactSex = (EyouSoft.Model.EnumType.CompanyStructure.Sex)Utils.GetInt(Utils.GetQueryStringValue("rbSex"), 0);

                model.PersonInfo.ContactName = name;
                model.PersonInfo.ContactMobile = mobile;
                model.PersonInfo.ContactTel = Utils.GetFormValue(this.txtPhone.UniqueID);
                model.PersonInfo.ContactFax = Utils.GetFormValue(this.txtFax.UniqueID);
                model.PersonInfo.QQ = Utils.GetFormValue(this.txtQQ.UniqueID);
                model.PersonInfo.MSN = Utils.GetFormValue(this.txtMsn.UniqueID);
                model.PersonInfo.ContactEmail = Utils.GetFormValue(this.txtEmail.UniqueID);

               
                if (bll.Update(model))
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "修改成功!");
                }
                else
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "修改失败!");
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
