using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.ZiXun
{
    public partial class Default : QianTaiYeMian
    {
        #region attributes
        protected int recordCount = 0;
        protected int pageSize = 10;
        protected int pageIndex = 0;
        protected int Count = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InteBind();
        }

        #region private members
        void InteBind()
        {
            var chaXun = new EyouSoft.Model.PtStructure.MZiXunChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            chaXun.BiaoTi = Utils.GetQueryStringValue("searchkey");
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常;
            chaXun.LeiXing = EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing.平台资讯;

            var list = new EyouSoft.BLL.PtStructure.BZiXun().GetZiXuns(SysCompanyId, pageSize, pageIndex, ref recordCount, chaXun);
            if (list.Count > 0)
            {
                RepZiXunList.DataSource = list;
                RepZiXunList.DataBind(); 
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// 资讯封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetZiXunFengMian(object filepath)
        {
            string _filepath = "/images/cx_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
