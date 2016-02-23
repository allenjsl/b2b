using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.EnumType.PtStructure;
using System.Text;

namespace EyouSoft.PtWeb.JiuDian
{
    public partial class JiuDianXX : QianTaiYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["jiudianid"]))
            {
                InteBind();
            }
            else
            {
                Response.Redirect("/jiudian/");
            }
        }

        #region private members
        void InteBind()
        {
            string jiudianId = Request.QueryString["jiudianid"];
            var items = new EyouSoft.BLL.PtStructure.BJiuDian().GetInfo(jiudianId);
            if (items != null)
            {
                JDName.Text = JiuDianName.Text = items.MingCheng;
                ChengShiMing.Text = items.ChengShiName;
                DiZhi.Text = items.DiZhi;
                LXDianHua.Text = items.DianHua;
                XingJi.Text = GetJiuDianXingJi(items.XingJi);
                RepFangXing.DataSource = new EyouSoft.BLL.PtStructure.BJiuDian().GetFangXings(jiudianId);
                RepFangXing.DataBind();
                JieShao.Text = items.JianJie;
                JIaoTong.Text = items.JiaoTong;
                SheShi.Text = items.WangLuo;
                if (items.FuJians != null && items.FuJians.Count > 0)
                {
                    ImgBig.DataSource = ImgSmall.DataSource = items.FuJians;
                    ImgSmall.DataBind();
                    ImgBig.DataBind();

                    if (items.FuJians.Count > 3)
                    {
                        ltrFuJianKuaiSuLiuLan.Text = "<span class=\"btn top\" id=\"span_fujian_shang\"></span><span class=\"btn bottom\" id=\"span_fujian_xia\"></span>";
                    }
                }

                if (!string.IsNullOrEmpty(items.KaiYeShiJian)) ltrKaiYeShiJian.Text = "开业时间：" + items.KaiYeShiJian;
                if (!string.IsNullOrEmpty(items.LouCengShuLiang)) ltrLouCengShuLiang.Text = "楼层数量：" + items.LouCengShuLiang;
                if (!string.IsNullOrEmpty(items.ZhuangXiuShiJian)) ltrZhuangXiuShiJian.Text = "装修时间：" + items.ZhuangXiuShiJian;
            }
            else
            {
                Response.Redirect("/jiudian/");
            }
        }

        string GetJiuDianXingJi(JiuDianXingJi xingji)
        {
            string jiudianxingji = "";
            int jixing = 0;
            switch (xingji)
            {
                case JiuDianXingJi.三星以下:
                    jixing = 0;
                    break;
                case JiuDianXingJi.挂三:
                    jixing = 1;
                    break;
                case JiuDianXingJi.准三:
                    jixing = 4;
                    break;
                case JiuDianXingJi.挂四:
                    jixing = 2;
                    break;
                case JiuDianXingJi.准四:
                    jixing = 5;
                    break;
                case JiuDianXingJi.挂五:
                    jixing = 3;
                    break;
                case JiuDianXingJi.准五:
                    jixing = 6;
                    break;
                default:
                    jixing = 0;
                    break;

            }
            if (jixing > 0 && jixing < 4)
            {
                for (int i = 0; i < jixing + 2; i++)
                {
                    jiudianxingji += "<img src=\"/images/star.gif\" />";
                }
            }
            else if (jixing > 3 && jixing < 7)
            {
                for (int i = 3; i < jixing + 2; i++)
                {
                    jiudianxingji += "<img src=\"/images/star_h.gif\" />";
                }
            }
            return jiudianxingji;
        }
        #endregion

        #region p
        protected string GetFangXingFuJian()
        {
            return string.Empty;
        }
        #endregion
    }
}
