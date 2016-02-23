using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using EyouSoft.BLL.CompanyStructure;
using EyouSoft.Common.Function;

namespace Web.SystemSet
{
    public partial class MsgManage : BackPage
    {
        /// <summary>
        /// 2012-11-20 刘树超
        /// 信息管理列表
        /// </summary>

        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        protected int itemIndex;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 权限判断
            if (!CheckGrant(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_信息管理_栏目))
            {
                Utils.ResponseNoPermit(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_信息管理_栏目, true);
                return;
            }
            #endregion

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            
            string method = Utils.GetQueryStringValue("method");
            string ids = Utils.GetQueryStringValue("ids");//获取员工Id
            EyouSoft.BLL.CompanyStructure.News newsBll = new EyouSoft.BLL.CompanyStructure.News();//初始化newsBll
            //删除操作
            if (method == "del")
            {
                ids = ids.TrimEnd(',');
                int result = newsBll.Delete(ids.Split(',').Select(i => Utils.GetInt(i)).ToArray());
                if (result == 1)
                {
                    MessageBox.ShowAndRedirect(this, "删除成功！", "/SystemSet/MsgManageList.aspx");
                }
                return;
            }
            //绑定信息列表
            IList<EyouSoft.Model.CompanyStructure.News> list = newsBll.GetList(pageSize, pageIndex, ref recordCount, CurrentUserCompanyID,CurrentZxsId);
            if (list != null && list.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                itemIndex = (pageIndex - 1) * pageSize + 1;
                rptInfo.DataSource = list;
                rptInfo.DataBind();
                BindExportPage();
            }
            else
            {
                rptInfo.EmptyText = "<tr><td colspan='7' align='center'>对不起，暂无信息！</td></tr>";
                ExportPageInfo1.Visible = false;
            }
        }
        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExportPageInfo1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExportPageInfo1.intPageSize = pageSize;
            this.ExportPageInfo1.CurrencyPage = pageIndex;
            this.ExportPageInfo1.intRecordCount = recordCount;
        }
        #endregion

    }
}
