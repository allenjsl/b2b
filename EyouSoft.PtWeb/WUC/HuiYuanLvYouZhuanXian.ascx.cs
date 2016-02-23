using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace EyouSoft.PtWeb.WUC
{
    public partial class HuiYuanLvYouZhuanXian : System.Web.UI.UserControl
    {
        #region attributes
        /// <summary>
        /// 显示站点数量
        /// </summary>
        protected int XianShiZhanDianShuaLiang = 8;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitInfo();
        }

        #region private members
        /// <summary>
        /// get zhandians
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> GetZhanDians(out int chaXunZhanDianIndex)
        {
            chaXunZhanDianIndex = 0;

            var yuMingInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetYuMingInfo();
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZhanDians1(yuMingInfo.CompanyId);

            if (items == null || items.Count == 0) return null;

            var mrzdid = EyouSoft.Security.Membership.TongHangYongHuProvider.GetMoRenZhanDianId();
            if (mrzdid > 0)
            {
                int removeIndex = 0;
                int i = 0;

                foreach (var item in items)
                {
                    if (item.ZhanDianId == mrzdid)
                    {
                        removeIndex = i;
                        break;
                    }

                    i++;
                }

                if (removeIndex > 0)
                {
                    var removeItem = items[removeIndex];

                    items.RemoveAt(removeIndex);
                    items.Insert(0, removeItem);
                }
            }


            int cxzdid = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("zdid"));

            if (cxzdid > 0)
            {
                int i = 0;
                foreach (var item in items)
                {
                    if (item.ZhanDianId == cxzdid) { chaXunZhanDianIndex = i; break; }
                    i++;
                }
            }

            return items;
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            int chaXunZhanDianIndex = 0;

            var items = GetZhanDians(out chaXunZhanDianIndex);

            if (items == null || items.Count == 0) return;

            StringBuilder s = new StringBuilder();
            StringBuilder s1 = new StringBuilder();
            StringBuilder s2 = new StringBuilder();

            int i = 0;
            foreach (var item in items)
            {
                if (i > XianShiZhanDianShuaLiang-1)
                {
                    if (chaXunZhanDianIndex >= XianShiZhanDianShuaLiang)
                    {
                        s.AppendFormat("<li data-class=\"zhandian\" data-zhandianid=\"{0}\" id=\"i_li_zd_{0}\" class=\"active\"><a href=\"javascript:void(0);\">{1}</a></li>", item.ZhanDianId, item.MingCheng);
                    }
                    break;
                }

                string _class = "";
                if (i == chaXunZhanDianIndex) _class = " class=\"active\" ";
                s.AppendFormat("<li data-class=\"zhandian\" data-zhandianid=\"{0}\" id=\"i_li_zd_{0}\" {2}><a href=\"javascript:void(0);\">{1}</a></li>", item.ZhanDianId, item.MingCheng, _class);

                i++;
            }

            string chaXunZxlbId = EyouSoft.Common.Utils.GetQueryStringValue("zxlbid");
            int j = 0;
            foreach (var item in items)
            {
                string _class = " class=\"none\" ";
                if (j == chaXunZhanDianIndex) _class = "";
                s1.AppendFormat("<div data-class=\"zxlb\" id=\"i_div_zx_zd_{0}\" {1}>", item.ZhanDianId, _class);

                if (item.Zxlbs != null && item.Zxlbs.Count > 0)
                {
                    s1.AppendFormat("<div class=\"line_type\"><ul class=\"fixed\">");
                    foreach (var item1 in item.Zxlbs)
                    {
                        string _class1 = "";
                        if (chaXunZxlbId == item1.ZxlbId.ToString()) _class1 = " class=\"on\" ";
                        s1.AppendFormat("<li {3}><a href=\"/huiyuan/xianlu.aspx?zdid={0}&zxlbid={1}\">{2}</a></li>", item.ZhanDianId, item1.ZxlbId, item1.MingCheng, _class1);
                    }
                    s1.AppendFormat("</ul></div>");
                }
                else
                {
                    s1.AppendFormat("<div class=\"zx_none_tishi\"><img src=\"/images/sorry.png\">&nbsp;抱歉，该站点下暂无专线信息，请选择其它站点，谢谢！</div>");
                }

                s1.AppendFormat("</div>");
                j++;
            }

            foreach (var item in items)
            {
                s2.AppendFormat("<a href=\"javascript:void(0)\" data-zhandianid=\"{0}\" data-class=\"gengduozhandian\">{1}</a>", item.ZhanDianId, item.MingCheng);
            }

            ltrZD.Text = s.ToString();
            ltrZX.Text = s1.ToString();
            ltrZD1.Text = s2.ToString();
        }
        #endregion
    }
}