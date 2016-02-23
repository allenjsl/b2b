using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace EyouSoft.PtWeb.ShangCheng
{
    public partial class ShangPinXX : QianTaiYeMian
    {
        #region attributes
        protected string shangpinid = "";//商品id
        protected string btnvalue = "";//按钮显示文字
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["shangpinid"]))
            {
                InteBind();
            }
            else
            {
                Response.Redirect("/shangcheng/");
            }
        }
        void InteBind()
        {
            shangpinid = Request.QueryString["shangpinid"];
            var list = new EyouSoft.BLL.PtStructure.BJiFen().GetShangPinInfo(shangpinid);
            ShangPinName.Text = list.MingCheng;
            ShangPinBianHao.Text = list.BianMa;
            ShangPinXiangQing.Text = list.MiaoShu;
            if (!string.IsNullOrEmpty(list.PeiSongShuoMing))
            {
                phPeiSongShuMing.Visible = true;
                PeiSongShuoMing.Text = list.PeiSongShuoMing;
            }
            ShiChangJia.Text = list.JiaGe.ToString("f2");
            DuiHuanJIFen.Text = list.JiFen.ToString();

            ltrTuPian.Text = string.Format("<img src=\"{0}\" />", ErpUrl + list.FengMian);

            if (list.FuJians == null || list.FuJians.Count == 0)
            {
                list.FuJians = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();

                string filepath = string.Empty;
                if (string.IsNullOrEmpty(list.FengMian)) filepath = "/images/jifen_no.gif";
                else filepath = list.FengMian;

                list.FuJians.Add(new EyouSoft.Model.PtStructure.MFuJianInfo() { Filepath = filepath });
                list.FuJians.Add(new EyouSoft.Model.PtStructure.MFuJianInfo() { Filepath = filepath });
                list.FuJians.Add(new EyouSoft.Model.PtStructure.MFuJianInfo() { Filepath = filepath });
            }

            if (list.FuJians != null && list.FuJians.Count > 0)
            {
                ltrTuPian.Text = string.Format("<img src=\"{0}\" />", ErpUrl + list.FuJians[0].Filepath);

                if (list.FuJians.Count == 1)
                {
                    list.FuJians.Add(list.FuJians[0]);
                    list.FuJians.Add(list.FuJians[0]);
                }

                if (list.FuJians.Count == 2)
                {
                    list.FuJians.Add(list.FuJians[0]);
                }

                StringBuilder s = new StringBuilder();

                s.AppendFormat("<div class=\"jf_focus\" id=\"newsSlider\">");
                s.AppendFormat("<div class=\"piclist\">");

                s.AppendFormat("<ul class=\"slides\"> ");
                foreach (var item in list.FuJians)
                {
                    string _url = ErpUrl + item.Filepath;
                    if (item.Filepath == "/images/jifen_no.gif") _url = item.Filepath;
                    s.AppendFormat("<li><a href=\"javascript:void(0)\" ><img src=\"{0}\" /></a></li>", _url);
                }
                s.AppendFormat("</ul>");
                s.AppendFormat("<div class='validate_Slider'></div>");
                s.AppendFormat("<ul class='pagination'>");
                for (var i = 1; i <= list.FuJians.Count; i++)
                {
                    s.AppendFormat("<li><a href=\"javascript:void(0)\">{0}</a></li>", i);
                }
                s.AppendFormat("</ul>");
                s.AppendFormat("</div>");
                s.AppendFormat("</div>");

                ltrTuPian.Text = s.ToString();
            }

            if (YongHuInfo !=null && YongHuInfo.YongHuId != 0)
            {
                var yongHuJiFenInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetYongHuJiFenInfo(YongHuInfo.YongHuId);
                KeYongJiFen.Text = yongHuJiFenInfo.KeYongJiFen.ToString();
                if (list.JiFen > yongHuJiFenInfo.KeYongJiFen)
                {
                    btnvalue = "积分不够";
                    phEmpty.Visible = false;
                    IsNotDui.Visible = true;
                }
            }
            else
            {
                KeYongJiFen.Text = "请登录后查看可用积分";
                btnvalue = "登录后兑换";
                phEmpty.Visible = false;
                IsNotLogin.Visible = true;
            }
        }
    }
}
