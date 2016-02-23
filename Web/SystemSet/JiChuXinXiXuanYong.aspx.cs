//汪奇志 2013-01-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.SystemSet
{
    /// <summary>
    /// 系统基础信息选用
    /// </summary>
    public partial class JiChuXinXiXuanYong : BackPage
    {
        #region attributes
        protected int pageSize = 10;
        protected int pageIndex = 1;
        /// <summary>
        /// 基础信息类型
        /// </summary>
        protected EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType IJiChuXinXiType = EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            IJiChuXinXiType = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType>(Utils.GetQueryStringValue("jichuxinxitype"), EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次);

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.CompanyStructure.MJiChuXinXiChaXunInfo();
            chaXun.ZxsId = CurrentZxsId;

            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, IJiChuXinXiType, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();


                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                paging.Visible = false;
            }
        }
        #endregion
    }
}
