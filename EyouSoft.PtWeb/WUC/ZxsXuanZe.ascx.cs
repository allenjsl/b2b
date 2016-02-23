using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.PtWeb.WUC
{
    /// <summary>
    /// 专线商选择用户控件
    /// </summary>
    public partial class ZxsXuanZe : System.Web.UI.UserControl
    {
        #region attributes
        string _Width = "150px";

        /// <summary>
        /// 存放选中专线商编号input id
        /// </summary>
        public string ZxsIdClientId { get { return ClientID + "_ZxsId"; } }
        /// <summary>
        /// 存放选中客户单位名称input id
        /// </summary>
        public string ZxsNameClientId { get { return ClientID + "_ZxsName"; } }
        /// <summary>
        /// 专线商名称宽度
        /// </summary>
        public string Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        string _ClassName = "searchinput";
        /// <summary>
        /// 专线商名称样式名
        /// </summary>
        public string ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }

        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}