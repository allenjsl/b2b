using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Web.MasterPage
{
    public partial class Print : System.Web.UI.MasterPage
    {
        #region attributes
        /// <summary>
        /// 页面标题
        /// </summary>
        protected string ITitle = string.Empty;

        /// <summary>
        /// 公司名称
        /// </summary>
        protected string CompanyName = string.Empty;

        /// <summary>
        /// 打印页头部图片路径
        /// </summary>
        public string PageHeadFile { get; set; }

        /// <summary>
        /// 打印页底部图片路径
        /// </summary>
        public string PageFootFile { get; set; }

        /// <summary>
        /// 公司章路径
        /// </summary>
        public string DepartStamp { get; set; }

        /// <summary>
        /// 是否不打印头部(默认false，即打印头部)
        /// 注：此属性只影响word导出
        /// </summary>
        public bool IsNoPrintHead { get; set; }


        /// <summary>
        /// 是否不打印底部(默认false，即打印底部)
        /// 注：此属性只影响word导出
        /// </summary>
        public bool IsNoPrintFoot { get; set; }
        /// <summary>
        /// 打印页宽度
        /// </summary>
        protected int PrintPageWidth = 696;

        private EyouSoft.Model.CompanyStructure.CompanyFieldSetting _setting;

        EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo ZxsPeiZhiInfo;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            var sysDomain = EyouSoft.Security.Membership.UserProvider.GetDomain();

            if (sysDomain == null || sysDomain.CompanyId < 1 || sysDomain.SysId < 1)
            {
                Response.Clear();
                Response.Write("请求异常：错误的域名配置。");
                Response.End();
                return;
            }

            ITitle = this.Page.Title;

            this.CompanyName = sysDomain.CompanyName;
            IsNoPrintHead = true;
            IsNoPrintFoot = true;

            this._setting = EyouSoft.Security.Membership.UserProvider.GetComSetting(sysDomain.CompanyId);

           
            ZxsPeiZhiInfo = EyouSoft.Security.Membership.UserProvider.GetZxsPeiZhiInfo();

            if (this._setting != null)
            {
                /*if (string.IsNullOrEmpty(PageHeadFile))
                {
                    PageHeadFile = this.ImgAddHttp(this._setting.PageHeadFile);
                }
                else
                {
                    IsNoPrintHead = false;
                }
                if (string.IsNullOrEmpty(PageFootFile))
                {
                    PageFootFile = this.ImgAddHttp(this._setting.PageFootFile);
                }
                if (string.IsNullOrEmpty(DepartStamp))
                {
                    DepartStamp = this.ImgAddHttp(this._setting.CompanyStamp);
                }*/

                PrintPageWidth = _setting.PrintPageWidth;
            }

            if (ZxsPeiZhiInfo != null)
            {
                if (string.IsNullOrEmpty(PageHeadFile))
                {
                    PageHeadFile = this.ImgAddHttp(ZxsPeiZhiInfo.DaYinYeMeiFilepath);
                }
                else
                {
                    IsNoPrintHead = false;
                }
                if (string.IsNullOrEmpty(PageFootFile))
                {
                    PageFootFile = this.ImgAddHttp(ZxsPeiZhiInfo.DaYinYeJiaoFilepath);
                }
                if (string.IsNullOrEmpty(DepartStamp))
                {
                    DepartStamp = this.ImgAddHttp(ZxsPeiZhiInfo.TuZhangFilepath);
                }
            }

            this.ibtnWord.Attributes.Add("onclick", "ReplaceInput();");
        }

        /// <summary>
        /// 给图片路径加上http
        /// </summary>
        /// <param name="path">相对站点路径</param>
        /// <returns>http路径</returns>
        private string ImgAddHttp(string path)
        {
            if (string.IsNullOrEmpty(path)) return path;
            if (path.Contains("http://")) return path;

            return string.Format("http://{0}{1}", Request.Url.Authority, path);
        }

        /// <summary>
        /// word导出
        /// </summary>
        protected void ibtnWord_Click(object sender, ImageClickEventArgs e)
        {
            string printHtml = Request.Form["hidPrintHTML"];
            string saveFileName = HttpUtility.UrlEncode(this.hidDocName.Value + ".doc");
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", saveFileName));
            Response.ContentType = "application/ms-word";
            Response.Charset = "utf-8";
            Response.ContentEncoding = Encoding.UTF8;

            var strHtml = new StringBuilder();
            strHtml.Append("<html>\n<head>\n<meta http-equiv=Content-Type content=\"text/html; charset=gb2312\">\n<meta name=ProgId content=Word.Document>");
            strHtml.Append("<style>" + "\n" +
                "<!--" + "\n" +
                "BODY { MARGIN: 0px }" + "\n" +
                "TABLE { BORDER-COLLAPSE: collapse ;}" + "\n" +
                "TD { FONT-SIZE: 12px; WORD-BREAK: break-all; LINE-HEIGHT: 100%; TEXT-DECORATION: none;}" + "\n" +
                "BODY { FONT-SIZE: 12px; WORD-BREAK: break-all; TEXT-DECORATION: none;font-family:宋体;mso-bidi-font-family:宋体;mso-font-kerning:0pt }" + "\n" +
                "p.MsoNormal, li.MsoNormal, div.MsoNormal" + "\n" +
                "{mso-style-parent:\"\";" + "\n" +
                "margin:0cm;" + "\n" +
                "margin-bottom:.0001pt;" + "\n" +
                "text-align:justify;" + "\n" +
                "text-justify:inter-ideograph;" +
                "mso-pagination:none;" + "\n" +
                "font-size:10.5pt;" + "\n" +
                "mso-bidi-font-size:12.0pt;" + "\n" +
                "font-family:\"Times New Roman\";" + "\n" +
                "mso-fareast-font-family:宋体;" + "\n" +
                "mso-font-kerning:1.0pt;}" + "\n" +
                "@page" + "\n" +
                "{mso-page-border-surround-header:no;" + "\n" +
                "mso-page-border-surround-footer:no;}" + "\n" +
                "@page Section1" + "\n" +
                "{size:595.3pt 841.9pt;" + "\n" +
                "margin:1.0cm 1.0cm 1.0cm 1.0cm;" + "\n" +
                "mso-header-margin:0cm;" + "\n" +
                "mso-footer-margin:0cm;" + "\n" +
                "mso-paper-source:0;" + "\n" +
                "layout-grid:15.6pt;}" + "\n" +
                "body{ background:#fff; font-size:12px; font-family:Verdana, Geneva, sans-serif,宋体; margin:5px auto; color:#000;}" + "\n" +
                GetClassStyle() +
                "-->" + "\n" +
                "</style>");

            strHtml.Append("</head>\n");
            strHtml.Append("<body lang=ZH-CN style='tab-interval:21.0pt;text-justify-trim:punctuation'>\n<div class=Section1 style='layout-grid:15.6pt'>\n");
            //内容开始
            strHtml.Append(printHtml);
            //内容结束
            strHtml.Append("</div>\n</body>\n</html>");
            //保存现有线路信息到文件
            var rnd = new Random();
            //获得文件名
            string routeInfoFileName = DateTime.Now.ToFileTime() + rnd.Next(1000, 99999) + ".doc";
            string tmpName = DateTime.Now.ToFileTime() + rnd.Next(1000, 99999).ToString() + ".doc";
            string wordTemplateFile = "/PrintTemplate/default.dot";
            if (ZxsPeiZhiInfo != null)
            {
                if (!string.IsNullOrEmpty(ZxsPeiZhiInfo.DaYinMoBanFilepath) && ZxsPeiZhiInfo.DaYinMoBanFilepath.Trim() != "")
                {
                    //判断文件是否存在
                    if (System.IO.File.Exists(Server.MapPath(ZxsPeiZhiInfo.DaYinMoBanFilepath)))
                    {
                        if (System.IO.Path.GetExtension(ZxsPeiZhiInfo.DaYinMoBanFilepath) == ".dot")
                        {
                            wordTemplateFile = ZxsPeiZhiInfo.DaYinMoBanFilepath;
                        }
                    }
                }
            }
            var objFile = new EyouSoft.Common.Function.StringValidate();
            string directory = Server.MapPath("/temp/word/");
            if (!System.IO.Directory.Exists(directory)) System.IO.Directory.CreateDirectory(directory);
            objFile.WriteTextToFile(Server.MapPath("/temp/word/" + routeInfoFileName), strHtml.ToString());
            //保存到WORD文件
            var objWord = new Adpost.Common.Office.InteropWord();//定义对象
            objWord.Add(Server.MapPath(wordTemplateFile));                                    //打开模板
            objWord.InsertWordFile(Server.MapPath("/temp/word/" + routeInfoFileName));
            objWord.SaveAs(Server.MapPath("/temp/word/") + tmpName);
            objFile.FileDel(Server.MapPath("/temp/word/" + routeInfoFileName));
            objWord.Dispose();
            Response.Clear();
            Response.Redirect("/temp/word/" + tmpName);
            Response.End();
        }

        /// <summary>
        /// 拼接class
        /// </summary>
        /// <returns></returns>
        private string GetClassStyle()
        {
            string str = string.Empty;
            str = "body{ background:#fff; font-size:12px; font-family:Verdana, Geneva, sans-serif,宋体; margin:5px auto; color:#000;}" + "\n" +
"a{ text-decoration:none; cursor:pointer;}" + "\n" +
"table{ border-collapse:collapse; margin-top:5px;}" + "\n" +
".font24{ font-size:24px;}" + "\n" +
".toptable td{ border:#676564 solid 1px; padding-left:3px; font-size:14px; /*line-height:26px;*/}" + "\n" +
".list th{ padding:3px; background:#c5e6f9; font-size:14px; font-weight:bold;}" + "\n" +
".list th,.list td{ /*line-height:26px;*/border:#676564 solid 1px;padding-left:3px;}" + "\n" +
".list1 th{ padding:3px; background:#c5e6f9; font-size:14px; font-weight:bold;}" + "\n" +
".list1 th,.list1 td{ /*line-height:26px;*/padding-left:3px;}";

            str += "p{padding:0px; margin:0px;}\n";

            str += string.Format("\n#divContent table{{width:{0}px;}}\n", PrintPageWidth);

            return str;
        }

    }
}
