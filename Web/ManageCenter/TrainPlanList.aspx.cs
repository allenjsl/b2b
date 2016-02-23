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
    using EyouSoft.BLL.CompanyStructure;

    public partial class TrainPlanList : BackPage
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GrantInit();
            Master.ITitle = "培训计划_行政中心";
            var doType = Utils.GetQueryStringValue("doType");
            //存在ajax请求
            if (!string.IsNullOrEmpty(doType))
            {
                AJAX(doType);
            }
            if (!IsPostBack)
            {
                this.PageInit();
            }
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        void PageInit()
        {
            var b = new TrainPlan();

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            var l = b.GetList(pageSize, pageIndex, ref recordCount, this.SiteUserInfo.CompanyId, this.SiteUserInfo.UserId,this.SiteUserInfo.DeptId);
            if (null != l && l.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.RepList.DataSource = l;
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
                this.RepList.Controls.Add(new Label() { Text = "<tr><td colspan='6' align='center'>对不起，没有相关数据！</td></tr>" });
                this.ExporPageInfoSelect1.Visible = false;
            }
        }

        /// <summary>
        /// 获取发送对象
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected string GetAcc(object o)
        {
            if (o == null) return string.Empty;
            var l = ((IList<EyouSoft.Model.AdminCenterStructure.TrainPlanAccepts>)o).OrderBy(m=>m.AcceptType);
            var r = string.Empty;

            foreach (var m in l)
            {
                switch (m.AcceptType)
                {
                    case EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.所有:
                        r = r + m.AcceptType + ",";
                        break;
                    case EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.指定部门:
                        var md = new Department().GetModel(m.AcceptId);
                        r = r + (md!=null?md.DepartName:"") + ",";
                        break;
                    case EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.指定人:
                        var mu =new CompanyUser().GetUserInfo(m.AcceptId);
                        r = r + (mu.PersonInfo != null ? mu.PersonInfo.ContactName : "") + ",";
                        break;
                }
            }

            return r.TrimEnd(',');
        }

        /// <summary>
        /// 权限初始化
        /// </summary>
        void GrantInit()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_栏目, false);
            }
            else
            {
                IsAddGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_新增);
                IsUpdGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_修改);
                IsDelGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_删除);
            }
        }

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
                b = new TrainPlan().Delete(this.SiteUserInfo.CompanyId, Utils.GetInt(id));
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
    }
}
