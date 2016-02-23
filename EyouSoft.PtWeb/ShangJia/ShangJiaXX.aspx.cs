using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.PtWeb.ShangJia
{
    public partial class ShangJiaXX : QianTaiYeMian
    {
        protected string imgurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (YongHuInfo != null && YongHuInfo.YongHuId != 0)
            {
                InitInfo();
            }
            else
            {
                Response.Write("<script>alert('本内容仅对旅行社同行开放,请登陆后继续查看!');location.href = 'default.aspx'</script>");
                Response.End();
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("shangjiaid")))
            {
                InteBind(Utils.GetQueryStringValue("shangjiaid"));
            }
            else
            {
                Response.Redirect("/shangjia/");
            }

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
            string ZXName = "";
            int zhuanxianid = 0;
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("zhuanxianid")))
            {
                zhuanxianid = Utils.GetInt(Utils.GetQueryStringValue("zhuanxianid"));
            }
            int chaXunZhanDianIndex = 0;

            var items = GetZhanDians(out chaXunZhanDianIndex);

            if (items == null || items.Count == 0) return;

            StringBuilder s = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                if (zhuanxianid == 0)
                {
                    zhuanxianid = items[0].ZhanDianId;
                }
                if (items[i].ZhanDianId == zhuanxianid)
                {
                    ZXName = items[i].MingCheng;
                    if (i == items.Count - 1)
                    {
                        s.AppendFormat("<li class=\"noborder\"><a href=\"{0}\">{1}</a></li>", "/shangjia/?zhuanxianid=" + items[i].ZhanDianId, items[i].MingCheng);
                    }
                    else
                    {
                        s.AppendFormat("<li class=\"on\"><a href=\"{0}\">{1}</a></li>", "/shangjia/?zhuanxianid=" + items[i].ZhanDianId, items[i].MingCheng);
                    }
                }
                else
                {
                    if (i == items.Count - 1)
                    {
                        s.AppendFormat("<li class=\"noborder\"><a href=\"{0}\">{1}</a></li>", "/shangjia/?zhuanxianid=" + items[i].ZhanDianId, items[i].MingCheng);
                    }
                    else
                    {
                        s.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", "/shangjia/?zhuanxianid=" + items[i].ZhanDianId, items[i].MingCheng);
                    }
                }
            }
            ZhanDianList.Text = s.ToString();
        }

        void InteBind(string zxsid)
        {
            var list = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(zxsid);
            ZhuanXianShangName.Text = list.MingCheng;
            ltrLxrName.Text = list.LxrName;
            ltrLxrShouJi.Text = list.LxrShouJi;
            ltrLxrDianHua.Text = list.LxrDianHua;

            if (list.QQs != null && list.QQs.Count > 0)
            {
                StringBuilder s = new StringBuilder();
                foreach (var item in list.QQs)
                {
                    s.AppendFormat("  &nbsp;&nbsp;<a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin={1}&site={2}&menu=yes\">{0}&nbsp;<img src=\"http://wpa.qq.com/pa?p=2:{1}:52\" /></a>", item.MiaoShu, item.QQ, "金芒果商旅网");
                }
                ltrZxsXinXiQQ.Text = s.ToString();
            }
            JieShao.Text = list.JieShao;
            imgurl = list.Logo;
            LianXiFangShi.Text = list.LianXiFangShi;
        }
        #endregion
    }
}
