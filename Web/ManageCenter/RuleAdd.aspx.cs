namespace Web.ManageCenter
{
    using System;
    using System.Linq;

    using EyouSoft.BLL.AdminCenterStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;
    using EyouSoft.Model.CompanyStructure;
    using EyouSoft.Model.EnumType.PrivsStructure;

    public partial class RuleAdd : BackPage
    {
        #region Constants and Fields

        /// <summary>
        /// 是否有保存权限
        /// </summary>
        protected bool IsSaveGrant;

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
        protected void PageInit(string id)
        {
            #region 初始化用户控件

            this.SingleFileUpload1.CompanyID = this.SiteUserInfo.CompanyId;

            #endregion

            var BLL = new RuleInfo();
            EyouSoft.Model.AdminCenterStructure.RuleInfo Model = BLL.GetModel(
                this.SiteUserInfo.CompanyId, Utils.GetInt(id));
            if (null != Model)
            {
                //主键
                this.hidRuleId.Value = Model.Id.ToString();
                //规章制度编号
                this.txtRuleId.Text = Model.RoleNo;
                //制度标题
                this.txtRuleTitle.Text = Model.Title;
                //制度内容
                this.txtRuleContent.Text = Utils.InputText(Model.RoleContent);
                //附件
                if (!string.IsNullOrEmpty(Model.FilePath))
                {
                    var arr = Model.FilePath.Split('|');
                    this.lbFiles.Text = string.Format("<span class='upload_filename' id=\"spanLatestAttach\">&nbsp;<a href='{0}' target='_blank'>{1}</a><a href='javascript:void(0);' onclick=\"PageJsData.delLatestAttach()\"> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='txtLatestAttach' value='{2}'></span>", arr.Length>1?arr[1]:arr[0], arr[0], Model.FilePath);
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected void PageSave(string doType)
        {
            #region 表单取值

            string msg = "";
            bool result = false;
            string code = Utils.GetFormValue(this.txtRuleId.UniqueID);
            string title = Utils.GetFormValue(this.txtRuleTitle.UniqueID);
            string content = Utils.EditInputText(Request.Form[this.txtRuleContent.UniqueID]);
            string ruleid = Utils.GetFormValue(this.hidRuleId.UniqueID);

            #endregion

            #region 表单验证

            if (string.IsNullOrEmpty(code))
            {
                msg += "-请输入制度编号！<br/>";
            }
            if (string.IsNullOrEmpty(title))
            {
                msg += "-请输入制度标题！<br/>";
            }
            if (!string.IsNullOrEmpty(msg))
            {
                result = false;
                this.Response.Clear();
                this.Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
                this.Response.End();
                return;
            }

            #endregion

            #region 实体赋值

            var BLL = new RuleInfo();
            var Model = new EyouSoft.Model.AdminCenterStructure.RuleInfo();
            Model.Id = Utils.GetInt(ruleid);
            //制度编号
            Model.RoleNo = code;
            //制度标题
            Model.Title = title;
            //制度内容
            Model.RoleContent = content;
            //适用部门
            Model.IssueTime = DateTime.Now;
            Model.CompanyId = this.SiteUserInfo.CompanyId;
            Model.OperatorId = this.SiteUserInfo.UserId;
            Model.FilePath = Utils.GetFormValue(this.SingleFileUpload1.ClientHideID);

            #endregion

            #region 提交回应

            if (doType == "update")
            {
                result = BLL.Update(Model);
                msg = result ? "修改成功！" : "修改失败！";
            }
            if (doType == "add")
            {
                result = BLL.Add(Model);
                msg = result ? "添加成功！" : "添加失败";
                //新增
            }
            this.Response.Clear();
            this.Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            this.Response.End();

            #endregion
        }

        /// <summary>
        /// 页面加载 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //权限验证
            this.PowerControl();

            #region 处理AJAX请求

            //获取ajax请求
            string doType = Utils.GetQueryStringValue("doType");
            string save = Utils.GetQueryStringValue("save");
            string id = Utils.GetQueryStringValue("id");
            //存在ajax请求
            if (save == "save")
            {
                this.PageSave(doType);
            }

            #endregion

            if (!this.IsPostBack)
            {
                //根据ID初始化页面
                this.PageInit(id);
            }
        }

        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(Privs3.行政中心_规章制度_栏目))
            {
                Utils.ResponseNoPermit(Privs3.行政中心_规章制度_栏目, false);
            }
            else
            {
                string doType = Utils.GetQueryStringValue("doType");
                if (doType == "update")
                {
                    IsSaveGrant = this.CheckGrant(Privs3.行政中心_规章制度_修改);
                }
                else
                {
                    IsSaveGrant = this.CheckGrant(Privs3.行政中心_规章制度_新增);
                }
            }
        }

        #endregion
    }
}