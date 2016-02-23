using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using EyouSoft.BLL.AdminCenterStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;

    public partial class ConferenceAdd : BackPage
    {
        /// <summary>
        /// 是否有保存权限
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
                var BLL = new MeetingInfo();
                var Model = BLL.GetModel(this.SiteUserInfo.CompanyId,Utils.GetInt(id));
                if (null != Model)
                {
                    //主键编号
                    hidId.Value = Model.Id.ToString();
                    //会议编号
                    this.txtNum.Text = Model.MetttingNo;
                    //会议主题
                    this.txtTitle.Text = Model.Title;
                    //会议人员
                    this.Seller1.Text = Model.Personal;
                    //会议时间
                    this.txtStartTime.Text = string.Format("{0:yyyy-MM-dd HH:mm}", Model.BeginDate);
                    this.txtEndTime.Text = string.Format("{0:yyyy-MM-dd HH:mm}", Model.EndDate);
                    //会议地点
                    this.txtPlace.Text = Model.Location;
                    //会议纪要 
                    this.txtContent.Text = Model.Remark;
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
            //会议编号
            string num = Utils.GetFormValue(txtNum.UniqueID);
            //会议主题
            string title = Utils.GetFormValue(txtTitle.UniqueID);
            //参会人员
            string people = Utils.GetFormValue(Seller1.UniqueID);
            //开始时间
            string starttime = Utils.GetFormValue(txtStartTime.UniqueID);
            //结束时间
            string endtime = Utils.GetFormValue(txtEndTime.UniqueID);
            //会议地点
            string place = Utils.GetFormValue(txtPlace.UniqueID);
            //会议纪要
            string content = Utils.GetFormValue(txtContent.UniqueID);
            //主键编号
            string hidid = Utils.GetFormValue(hidId.UniqueID);
            #endregion

            #region 表单验证
            string msg = "";
            bool result = false;
            Response.Clear();
            if (string.IsNullOrEmpty(num))
            {
                msg += "-请输入会议编号！<br/>";
            }
            if (string.IsNullOrEmpty(title))
            {
                msg += "-请输入会议主题！<br/>";
            }
            if (string.IsNullOrEmpty(place))
            {
                msg += "-请输入会议地点！<br/>";
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
            var Model = new EyouSoft.Model.AdminCenterStructure.MeetingInfo();
            Model.CompanyId = this.SiteUserInfo.CompanyId;
            Model.EndDate = Utils.GetDateTime(endtime);
            Model.IssueTime = DateTime.Now;
            Model.Personal = people;
            Model.Remark = content;
            Model.MetttingNo = num;
            Model.OperatorId = this.SiteUserInfo.UserId;
            Model.BeginDate = Utils.GetDateTime(starttime);
            Model.Title = title;
            Model.Location = place;
            Model.Personal = people;
            Model.Id = Utils.GetInt(hidid);
            #endregion

            #region 提交回应
            var BLL = new MeetingInfo();
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
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_栏目, false);
            }
            else
            {
                string doType = Utils.GetQueryStringValue("doType");
                if (doType == "add")
                {
                    IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_新增);
                }
                else
                {
                    IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_修改);
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
