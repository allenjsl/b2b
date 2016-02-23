using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.PtWeb.WUC
{
    public partial class TuiJian : System.Web.UI.UserControl
    {
        protected string ErpUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            inteBind();
        }

        #region private members
        void inteBind()
        {
            var chaXun = new EyouSoft.Model.PtStructure.MTuiJianChaXunInfo();
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.正常;
            int recordCount=0;
            var yuMingInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetYuMingInfo();
            var items = new EyouSoft.BLL.PtStructure.BTuiJian().GetTuiJians(yuMingInfo.CompanyId, 12, 1, ref recordCount, chaXun);
            ErpUrl = yuMingInfo.ErpUrl;
            if (items != null && items.Count > 0)
            {
                RepList.DataSource = items;
                RepList.DataBind();
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
            string _filepath = "/images/i_tj_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}