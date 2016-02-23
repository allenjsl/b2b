using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.TuiJian
{
    public partial class Default : QianTaiYeMian
    {
        #region attributes
        protected int recordCount = 0;
        protected int pageSize = 6;
        protected int pageIndex = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitTuiJian();
        }

        #region private members
        /// <summary>
        /// init cuxiao
        /// </summary>
        void InitTuiJian()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            var chaXun = new EyouSoft.Model.PtStructure.MTuiJianChaXunInfo();
            chaXun.BiaoTi = Utils.GetQueryStringValue("searchkey");
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.正常;
            var items = new EyouSoft.BLL.PtStructure.BTuiJian().GetTuiJians(SysCompanyId, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptTuiJian.DataSource = items;
                rptTuiJian.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }

        }
        #endregion

        #region protected members
        /// <summary>
        /// 推荐封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetTuiJianFengMian(object filepath)
        {
            string _filepath = "/images/cx_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
