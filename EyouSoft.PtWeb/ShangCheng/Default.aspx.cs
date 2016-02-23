using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.ShangCheng
{
    public partial class Default : QianTaiYeMian
    {
        #region attributes
        protected int recordCount = 0;
        protected int pageSize = 12;
        protected int pageIndex = 0;
        protected int type = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InteBind();
        }

        #region private members
        void InteBind()
        {
            var chaxun = new EyouSoft.Model.PtStructure.MJiFenShangPinChaXunInfo();
            if(!string.IsNullOrEmpty(Utils.GetQueryStringValue("type")))
            {
                type = Utils.GetInt(Utils.GetQueryStringValue("type"));
                chaxun.LeiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing)type;
            }
            chaxun.Status = EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus.上架;
            pageIndex = UtilsCommons.GetPagingIndex();
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("searchkey")))
            {
                chaxun.MingCheng = Utils.GetQueryStringValue("searchkey");
            }
            var list = new EyouSoft.BLL.PtStructure.BJiFen().GetShangPins(SysCompanyId, pageSize, pageIndex, ref recordCount, chaxun);
            if (list.Count > 0)
            {
                RepJiFen.DataSource = list;
                RepJiFen.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// 商品封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetShangPinFengMian(object filepath)
        {
            string _filepath = "/images/jifen_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
