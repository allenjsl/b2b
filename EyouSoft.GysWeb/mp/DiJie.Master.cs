using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.GysWeb.mp
{
    /// <summary>
    /// 供应商-地接社后台模板
    /// </summary>
    public partial class DiJie : System.Web.UI.MasterPage
    {
        #region attributes
        /// <summary>
        /// titile
        /// </summary>
        protected string ITitle = string.Empty;
        /// <summary>
        /// 客服电话
        /// </summary>
        protected string KeFuDianHua = string.Empty;
        /// <summary>
        /// 域名信息
        /// </summary>
        EyouSoft.Model.PtStructure.MYuMingInfo YuMingInfo = null;
        /// <summary>
        /// 登录用户姓名
        /// </summary>
        protected string YongHuXingMing = string.Empty;
        /// <summary>
        /// 供应商名称
        /// </summary>
        protected string GysName = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitYuMingInfo();
            InitInfo();
            InitYongHuInfo();
            InitHighlight();
        }

        #region private members
        /// <summary>
        /// init yuming info
        /// </summary>
        void InitYuMingInfo()
        {
            YuMingInfo = EyouSoft.Security.Membership.GysYongHuProvider.GetYuMingInfo();
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            ITitle = Page.Title+"-金芒果商旅网地接管理系统";
        }

        /// <summary>
        /// init yonghu info
        /// </summary>
        void InitYongHuInfo()
        {
            EyouSoft.Model.SSOStructure.MGysYongHuInfo yongHuInfo = null;
            var isLogin = EyouSoft.Security.Membership.GysYongHuProvider.IsLogin(out yongHuInfo);

            if (isLogin)
            {
                YongHuXingMing = yongHuInfo.XingMing;
                GysName = yongHuInfo.GysName;
            }
        }

        /// <summary>
        /// init hightlight
        /// </summary>
        void InitHighlight()
        {
            string s = Request.Url.AbsolutePath.ToLower();
            string showStyle = "display:'';";
            string highlightClass = "listIn";
            string h2ShowClass = "firstNav";

            if (s.Equals("/dijie/default.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/dijie/jihuaxx.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_1.Attributes["class"] = h2ShowClass;
                ul_1.Attributes["style"] = showStyle;
                a_1.Attributes["class"] = highlightClass;
            }
        }
        #endregion
    }
}
