using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.MP
{
    /// <summary>
    /// 同行平台-同行用户后台模板
    /// </summary>
    public partial class HuiYuan : System.Web.UI.MasterPage
    {
        #region attributes
        /// <summary>
        /// titile
        /// </summary>
        protected string ITitle = string.Empty;
        /// <summary>
        /// keywords
        /// </summary>
        protected string Keywords = string.Empty;
        /// <summary>
        /// description
        /// </summary>
        protected string Description = string.Empty;
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
            YuMingInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetYuMingInfo();
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            ITitle = Page.Title;

            var biaoTiInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.平台标题);
            var keywordsInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.平台关键字);
            var descriptionInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.平台描述);
            var keFuDianHuaInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.客服电话);
            var copyrightInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.平台版权);

            ITitle += "-" + biaoTiInfo.V;
            Keywords = string.Format("<meta name=\"keywords\" content=\"{0}\" />", keywordsInfo.V);
            Description = string.Format("<meta name=\"description\" content=\"{0}\" />", descriptionInfo.V);
            KeFuDianHua = keFuDianHuaInfo.V;
        }

        /// <summary>
        /// init yonghu info
        /// </summary>
        void InitYongHuInfo()
        {
            EyouSoft.Model.SSOStructure.MTongHangYongHuInfo yongHuInfo = null;
            var isLogin = EyouSoft.Security.Membership.TongHangYongHuProvider.IsLogin(out yongHuInfo);

            if (isLogin) YongHuXingMing = yongHuInfo.XingMing;
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

            if (s.Equals("/huiyuan/default.aspx", StringComparison.OrdinalIgnoreCase) 
                || s.Equals("/huiyuan/xianlu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_1.Attributes["class"] = h2ShowClass;
                ul_1.Attributes["style"] = showStyle;
                a_1.Attributes["class"] = highlightClass;
            }
            if (s.Equals("/huiyuan/xianluyuding.aspx", StringComparison.OrdinalIgnoreCase))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("dingdanid")))
                {
                    h2_2.Attributes["class"] = h2ShowClass;
                    ul_2.Attributes["style"] = showStyle;
                    a_3.Attributes["class"] = highlightClass;
                }
                else
                {
                    h2_1.Attributes["class"] = h2ShowClass;
                    ul_1.Attributes["style"] = showStyle;
                    a_1.Attributes["class"] = highlightClass;
                }
            }
            else if (s.Equals("/huiyuan/dingdan.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_2.Attributes["class"] = h2ShowClass;
                ul_2.Attributes["style"] = showStyle;
                a_3.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/huiyuan/gongsi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_4.Attributes["class"] = h2ShowClass;
                ul_4.Attributes["style"] = showStyle;
                a_6.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/huiyuan/geren.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_4.Attributes["class"] = h2ShowClass;
                ul_4.Attributes["style"] = showStyle;
                a_7.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/huiyuan/yuangong.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_4.Attributes["class"] = h2ShowClass;
                ul_4.Attributes["style"] = showStyle;
                a_8.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/huiyuan/jifenmingxi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_5.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/huiyuan/jifendingdan.aspx", StringComparison.OrdinalIgnoreCase) 
                || s.Equals("/huiyuan/jifendingdanxx.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_9.Attributes["class"] = highlightClass;
            }
        }
        #endregion
    }
}
