using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class KeHuXuanZe : System.Web.UI.UserControl
    {
        #region attributes
        string _Width = "150px";

        /// <summary>
        /// 存放选中客户单位编号input name
        /// </summary>
        public string KeHuIdClientName { get { return ClientID + "_KeHuId"; } }
        /// <summary>
        /// 存放选中客户单位编号input id
        /// </summary>
        public string KeHuIdClientId { get { return ClientID + "_KeHuId"; } }
        /// <summary>
        /// 存放选中客户单位名称input name
        /// </summary>
        public string KeHuMingChengClientName { get { return ClientID + "_KeHuMingCheng"; } }
        /// <summary>
        /// 存放选中客户单位名称input id
        /// </summary>
        public string KeHuMingChengClientId { get { return ClientID + "_KeHuMingCheng"; } }
        /// <summary>
        /// 选用A标签ClientId
        /// </summary>
        public string AClinetId { get { return ClientID + "_A_XuanZe"; } }
        /// <summary>
        /// 对方操作人ClientId
        /// </summary>
        public string DuiFangCaoZuoRenClientId { get; set; }

        /// <summary>
        /// 客户单位名称宽度
        /// </summary>
        public string Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        /// <summary>
        /// callback function
        /// </summary>
        public string CallbackFn { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KeHuMingCheng { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}