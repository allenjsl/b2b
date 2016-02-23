using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using System.Text;

    using EyouSoft.BLL.AdminCenterStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;

    public partial class CompanyRole : BackPage
    {
        #region 分页参数
        /// <summary>
        /// 页大小
        /// </summary>
        protected int pageSize = 20;
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

            Master.ITitle = "规章制度_行政中心";
            #region 处理AJAX请求
            //获取ajax请求
            string doType = Utils.GetQueryStringValue("doType");
            //存在ajax请求
            if (doType != null && doType.Length > 0)
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
            //获取分页参数并强转
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"),1);
            var lst = new RuleInfo().GetList(pageSize, pageIndex, ref recordCount, this.SiteUserInfo.CompanyId, Utils.GetQueryStringValue("txtNum"), Utils.GetQueryStringValue("txtTitle"));
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
                this.RepList.Controls.Add(new Label() { Text = "<tr><td colspan='3' align='center'>对不起，没有相关数据！</td></tr>" });
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
            //对应执行操作
            if (doType == "delete")
            {
                string id = Utils.GetQueryStringValue("id");
                //执行并获取结果
                DeleteData(id);
            }
            //返回ajax操作结果

        }
        #endregion

        #region 删除操作
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private void DeleteData(string id)
        {
            bool b = false;
            string msg = string.Empty;
            if (IsDelGrant)
            {
                b = new RuleInfo().Delete(this.SiteUserInfo.CompanyId, Utils.GetInt(id));
                msg = b ? "删除成功！" : "删除失败！";
            }
            else
            {
                msg = "对不起，您没有删除权限！";
            }
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(b ? "1" : "0", msg));
            Response.End();
        }
        #endregion

        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        private void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_规章制度_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_规章制度_栏目, false);
            }
            IsAddGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_规章制度_新增);
            IsUpdGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_规章制度_修改);
            IsDelGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_规章制度_删除);
        }
        #endregion
    }
}
