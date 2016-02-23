using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.BLL.AdminCenterStructure;

namespace Web.ManageCenter
{
    public partial class ContractAdd : BackPage
    {
        /// <summary>
        /// 操作权限
        /// </summary>
        protected bool IsSaveGrant;
        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //权限验证
            PowerControl();
            string save = Utils.GetQueryStringValue("save");
            string doType = Request.QueryString["doType"];
            #region ajax请求
            if (save == "save")
            {
                PageSave(doType);
            }
            #endregion
            if (!IsPostBack)
            {
                string id = Utils.GetQueryStringValue("id");
                PageInit(id);
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="id">操作ID</param>
        protected void PageInit(string id)
        {
            //编辑初始化
            if (!string.IsNullOrEmpty(id))
            {
                var BLL = new ContractInfo();
                var Model = BLL.GetModel(this.SiteUserInfo.CompanyId,Utils.GetInt(id));
                if (null != Model)
                {
                    //员工编号
                    this.txtStaffNo.Value = Model.StaffNo;
                    //姓名
                    this.txtStaffName.Value = Model.StaffName;
                    //签订时间
                    this.txtBeginDate.Value = string.Format("{0:yyyy-MM-dd HH:mm}", Model.BeginDate);
                    //到期时间
                    this.txtEndDate.Value = string.Format("{0:yyyy-MM-dd HH:mm}", Model.EndDate);
                    //状态
                    this.ddlState.SelectedIndex = (int)Model.ContractStatus;
                    //备注 
                    this.txtRemark.Text = Model.Remark;
                }
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        protected void PageSave(string doType)
        {
            #region 表单取值
            //员工编号
            string num = Utils.GetFormValue(this.txtStaffNo.UniqueID);
            //姓名
            string people = Utils.GetFormValue(this.txtStaffName.UniqueID);
            //签订时间
            string starttime = Utils.GetFormValue(this.txtBeginDate.UniqueID);
            //到期时间
            string endtime = Utils.GetFormValue(this.txtEndDate.UniqueID);
            //状态
            string place = Utils.GetFormValue(this.ddlState.UniqueID);
            //备注
            string content = Utils.GetFormValue(this.txtRemark.UniqueID);
            //主键编号
            string hidid = Utils.GetQueryStringValue("id");
            #endregion

            #region 表单验证
            string msg = "";
            bool result = false;
            Response.Clear();
            if (string.IsNullOrEmpty(num))
            {
                msg += "-请输入员工编号！<br/>";
            }
            if (string.IsNullOrEmpty(people))
            {
                msg += "-请输入姓名！<br/>";
            }
            if (string.IsNullOrEmpty(starttime))
            {
                msg += "-请输入签订时间！<br/>";
            }
            if (string.IsNullOrEmpty(endtime))
            {
                msg += "-请输入到期时间！<br/>";
            }
            if (!string.IsNullOrEmpty(msg))
            {
                result = false;
                Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
                Response.End();
                return;
            }
            #endregion

            #region 实体赋值
            var Model = new EyouSoft.Model.AdminCenterStructure.ContractInfo();
            Model.CompanyId = this.SiteUserInfo.CompanyId;
            Model.EndDate = Utils.GetDateTime(endtime);
            Model.IssueTime = DateTime.Now;
            Model.StaffName = people;
            Model.Remark = content;
            Model.StaffNo = num;
            Model.OperatorId = this.SiteUserInfo.UserId;
            Model.BeginDate = Utils.GetDateTime(starttime);
            Model.Id = Utils.GetInt(hidid);
            Model.ContractStatus = (EyouSoft.Model.EnumType.AdminCenterStructure.ContractStatus)Utils.GetInt(place);
            #endregion

            #region 提交回应
            var BLL = new ContractInfo();
            if (doType == "add")
            {
                result = BLL.Add(Model);
                msg = result ? "添加成功！" : "添加失败！";
            }
            if (doType == "update")
            {
                result = BLL.Update(Model);
                msg = result ? "修改成功！" : "修改失败！";
            }
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            Response.End();
            #endregion
        }
        #endregion

        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_栏目, false);
            }
            else
            {
                string doType = Utils.GetQueryStringValue("doType");
                if (doType == "add")
                {
                    IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_新增);
                }
                else
                {
                    IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_劳动合同管理_修改);
                }
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
