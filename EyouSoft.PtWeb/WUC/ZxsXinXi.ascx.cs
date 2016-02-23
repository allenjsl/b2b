using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace EyouSoft.PtWeb.WUC
{
    public partial class ZxsXinXi : System.Web.UI.UserControl
    {
        #region attributes
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitInfo();
        }

        /// <summary>
        /// init zxsinfo
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(ZxsId)) this.Visible = false;

            var info = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(ZxsId);
            if (info == null) return;

            ltrZxsXinXiMingCheng.Text = info.MingCheng;

            if (info.QQs != null && info.QQs.Count > 0)
            {
                StringBuilder s = new StringBuilder();
                foreach (var item in info.QQs)
                {
                    s.AppendFormat("<li><a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin={1}&site={2}&menu=yes\">{0}&nbsp;<img src=\"http://wpa.qq.com/pa?p=2:{1}:52\" /></a></li>", item.MiaoShu, item.QQ, "金芒果商旅网");
                }
                ltrZxsXinXiQQ.Text = s.ToString();
            }

            if (!string.IsNullOrEmpty(info.LianXiFangShi)) ltrLianXiFangShi.Text = info.LianXiFangShi;
            if (!string.IsNullOrEmpty(info.YinHangZhangHao)) ltrYinHangZhangHao.Text = info.YinHangZhangHao;
        }
    }
}