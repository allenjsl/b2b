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

    public partial class ConManage : BackPage
    {
        #region 分页参数
        /// <summary>
        /// 页大小
        /// </summary>
        protected int pageSize = 10;
        /// <summary>
        /// 页码
        /// </summary>
        protected int pageIndex = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        private int recordCount = 0;
        /// <summary>
        /// 新增权限
        /// </summary>
        public bool IsAddGrant;
        /// <summary>
        /// 修改权限
        /// </summary>
        public bool IsUpdGrant;
        /// <summary>
        /// 删除权限
        /// </summary>
        public bool IsDelGrant;
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //权限判断
            PowerControl();
            Master.ITitle = "会议记录管理_行政中心";
            #region 处理AJAX请求
            //获取ajax请求
            string doType = Request.QueryString["doType"];
            //存在ajax请求
            if (doType == "delete")
            {
                AJAX(doType);
            }
            #endregion
            if (!IsPostBack)
            {
                //初始化
                DataInit();
            }
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void DataInit()
        {
            string txtNum = Utils.GetQueryStringValue("txtNum");//会议编号
            string txtTitle = Utils.GetQueryStringValue("txtTitle");//会议主题
            DateTime? txtStartTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime"));//会议时间（始）
            DateTime? txtEndTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime"));//会议时间（终）
            //获取分页参数并强转
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"),1);
            var BLL = new MeetingInfo();
            var lst = BLL.GetList( this.pageSize, this.pageIndex, ref this.recordCount,this.SiteUserInfo.CompanyId,txtNum,txtTitle ,txtStartTime,txtEndTime);
            if (null != lst && lst.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.RepList.DataSource = lst;
                this.RepList.DataBind();
                if (recordCount <= pageSize)
                {
                    this.ExporPageInfoSelect1.Visible = false;
                }
                else
                {
                    BindPage();
                }
            }
            else
            {
                this.RepList.Controls.Add(new Label() { Text = "<tr><td colspan='8' align='center'>对不起，没有相关数据！</td></tr>" });
                this.ExporPageInfoSelect1.Visible = false;
            }
        }
        #endregion

        #region 绑定分页
        /// <summary>
        /// 绑定分页
        /// </summary>
        private void BindPage()
        {            
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion

        #region ajax操作
        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType)
        {
            string msg = string.Empty;
            bool result = false;
            switch (doType)
            {
                case "delete":
                    //判断权限
                    if (IsDelGrant)
                    {
                        string id = Utils.GetQueryStringValue("id");
                        result = DeleteData(id);
                        msg = result ? "删除成功！" : "删除失败!";
                    }
                    else
                    {
                        msg = "对不起，您没有删除权限";
                    }
                    break;
                default:
                    break;
            }
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            Response.End();
        }
        #endregion

        #region 删除操作
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private bool DeleteData(string id)
        {
            bool b = false;
            if (!String.IsNullOrEmpty(id))
            {
                b = new MeetingInfo().Delete(this.SiteUserInfo.CompanyId,Utils.GetInt(id));
            }
            return b;
        }
        #endregion

        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        private void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_栏目, false);
            }
            else
            {
                IsAddGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_新增);
                IsUpdGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_修改);
                IsDelGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_会议记录_删除);
            }
        }
        #endregion
    }
}
