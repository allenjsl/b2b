//汪奇志 2013-01-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;

namespace Web.SystemSet
{
    /// <summary>
    /// 系统设置-基础设置-回程时间
    /// </summary>
    public partial class HuiChengShiJian : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "delete") Delete();

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_回程时间栏目);

            if (!Privs_LanMu)
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_回程时间栏目, true);
                }
            }
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {            
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.CompanyStructure.MJiChuXinXiChaXunInfo();
            chaXun.ZxsId = CurrentZxsId;

            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程时间, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();
                
                rpts.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                rpts.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// 删除回程时间信息
        /// </summary>
        void Delete()
        {
            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int id = Utils.GetInt(Utils.GetFormValue("txtId"));
            int bllRetCode = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().Delete(CurrentUserCompanyID, id);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
