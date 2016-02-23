using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.CuXiao
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
            InitCuXiao();
        }

        #region private members
        /// <summary>
        /// init cuxiao
        /// </summary>
        void InitCuXiao()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            var chaXun = new EyouSoft.Model.PtStructure.MCuXiaoChaXunInfo();
            chaXun.BiaoTi= Utils.GetQueryStringValue("searchkey");
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus.正常;

            var items = new EyouSoft.BLL.PtStructure.BCuXiao().GetCuXiaos(SysCompanyId, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptCuXiao.DataSource = items;
                rptCuXiao.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }

        }
        #endregion

        #region protected members
        /// <summary>
        /// 促销封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetCuXiaoFengMian(object filepath)
        {
            string _filepath = "/images/cx_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
