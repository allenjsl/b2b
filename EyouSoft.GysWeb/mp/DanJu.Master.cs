//打印单据master
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace EyouSoft.GysWeb.mp
{
    /// <summary>
    /// 打印单据master
    /// </summary>
    public partial class DanJu : System.Web.UI.MasterPage
    {
        #region attributes
        /// <summary>
        /// 页面标题
        /// </summary>
        protected string ITitle = string.Empty;
        /// <summary>
        /// 公司名称
        /// </summary>
        protected string CompanyName = "金芒果商旅网地接管理系统";
        /// <summary>
        /// 域名信息
        /// </summary>
        EyouSoft.Model.PtStructure.MYuMingInfo YuMingInfo = null;
        /// <summary>
        /// 打印页宽度
        /// </summary>
        protected int PrintPageWidth = 696;

        public DanJuDaYinMoBanLeiXing _DaYinMoBanLeiXing = DanJuDaYinMoBanLeiXing.NONE;
        /// <summary>
        /// 模板类型 0:none 1:zxs 2:kehu
        /// </summary>
        public DanJuDaYinMoBanLeiXing DaYinMoBanLeiXing { get { return _DaYinMoBanLeiXing; } set { _DaYinMoBanLeiXing = value; } }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitYuMingInfo();
            InitInfo();
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
            ITitle = Page.Title;
            ITitle += "-" + "金芒果商旅网地接管理系统";

            var xiTongPeiZhiInfo = EyouSoft.Security.Membership.GysYongHuProvider.GetXiTongPeiZhiInfo(YuMingInfo.CompanyId);
            if (xiTongPeiZhiInfo != null)
            {
                PrintPageWidth = xiTongPeiZhiInfo.PrintPageWidth;
            }
        }

        /// <summary>
        /// get danju html
        /// </summary>
        /// <returns></returns>
        string GetDanJuHtml()
        {
            string s = string.Empty;

            using (StreamReader sr = new StreamReader(Server.MapPath("~/danju/danju.html")))
            {
                s=sr.ReadToEnd();
            }

            return s;
        }

        /// <summary>
        /// get danju dayin moban
        /// </summary>
        /// <returns></returns>
        string GetDanJuDanYinMoBan()
        {
            string moRenMoBan = "/danju/default.dot";
            

            return moRenMoBan;
        }
        #endregion

        #region protected members
        /// <summary>
        /// word导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnWord_Click(object sender, ImageClickEventArgs e)
        {
            string printHtml = Request.Form["hidPrintHTML"];
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "test.doc"));
            Response.ContentType = "application/ms-word";
            Response.Charset = "utf-8";
            Response.ContentEncoding = Encoding.UTF8;

            string strHtml = GetDanJuHtml();

            strHtml = strHtml.Replace("<%=ZHANWEIFU1%>", string.Format("\n#divContent table{{width:{0}px;}}\n", PrintPageWidth));
            strHtml = strHtml.Replace("<%=ZHANWEIFU2%>", printHtml);

            string directory_path = "/temp/word/";
            //保存现有线路信息到文件
            var rnd = new Random();
            //获得文件名
            string fileName1 = DateTime.Now.ToFileTime() + rnd.Next(1000, 99999) + ".doc";
            string fileName2 = DateTime.Now.ToFileTime() + rnd.Next(1000, 99999).ToString() + ".doc";
            //string fileName3 = "/danju/default.dot";
            string fileName3 = GetDanJuDanYinMoBan();

            var objFile = new EyouSoft.Common.Function.StringValidate();
            string directory = Server.MapPath(directory_path);
            if (!System.IO.Directory.Exists(directory)) System.IO.Directory.CreateDirectory(directory);
            objFile.WriteTextToFile(Server.MapPath(directory_path + fileName1), strHtml.ToString());

            //保存到WORD文件
            var objWord = new Adpost.Common.Office.InteropWord();//定义对象
            objWord.Add(Server.MapPath(fileName3));
            objWord.InsertWordFile(Server.MapPath(directory_path + fileName1));
            objWord.SaveAs(Server.MapPath(directory_path) + fileName2);
            objFile.FileDel(Server.MapPath(directory_path + fileName1));
            objWord.Dispose();
            Response.Clear();
            Response.Redirect(directory_path + fileName2);
            Response.End();
        }
        #endregion

    }

    #region 单据打印模板类型
    /// <summary>
    /// 单据打印模板类型
    /// </summary>
    public enum DanJuDaYinMoBanLeiXing
    {
        /// <summary>
        /// 默认模板
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 专线商模板
        /// </summary>
        ZXS = 1,
        /// <summary>
        /// 客户模板
        /// </summary>
        KEHU = 2
    }
    #endregion
}
