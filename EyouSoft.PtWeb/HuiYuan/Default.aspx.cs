using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.PtWeb.HuiYuan
{
    /// <summary>
    /// 用户后台-首页
    /// </summary>
    public partial class Default : HuiYuanYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitTuiJian();
        }

        #region private members
        /// <summary>
        /// init tuijian
        /// </summary>
        void InitTuiJian()
        {
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.PtStructure.MTuiJianChaXunInfo();
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.正常;

            var items = new EyouSoft.BLL.PtStructure.BTuiJian().GetTuiJians(SysCompanyId, 12, 1, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptTuiJian.DataSource = items;
                rptTuiJian.DataBind();
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
