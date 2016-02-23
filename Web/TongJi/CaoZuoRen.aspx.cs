using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using EyouSoft.Model.TongJiStructure;
using System.Text;

namespace Web.TongJi
{
    public partial class CaoZuoRen : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetFormValue("istoxls") == "1") ToXls();
            InitPrivs();
            initList();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {

            var searchModel = new EyouSoft.Model.TongJiStructure.MCaoZuoRenChaXunInfo();
            searchModel.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("sendTimes"));
            searchModel.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("sendTimee"));

            #region 处理统计表头
            DateTime today = DateTime.Today;
            if (searchModel.LSDate.HasValue)
            {
                string s = searchModel.LEDate.HasValue ? "至" : ("至" + today.ToString("yyyy年MM月dd日"));
                lbl_serch.Text = Utils.GetDateTime(searchModel.LSDate.ToString()).ToString("yyyy年MM月dd日");
                lbl_serch.Text += s;
            }
            if (searchModel.LEDate.HasValue)
            {
                string s = searchModel.LSDate.HasValue ? "" : "至";
                lbl_serch.Text += s + Utils.GetDateTime(searchModel.LEDate.ToString()).ToString("yyyy年MM月dd日");
            }

            if (!searchModel.LSDate.HasValue && !searchModel.LEDate.HasValue)
            {
                lbl_serch.Text += "至" + today.ToString("yyyy年MM月dd日");
                searchModel.LEDate = today;
            }
            lbl_serch.Text += " 员工操作统计表";
            #endregion

            var items = new EyouSoft.BLL.TongJiStructure.BCaoZuoRen().GetCaoZuoRens(CurrentUserCompanyID,CurrentZxsId, searchModel);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();
                rpts.Visible = true;
                phEmpty.Visible = false;


            }
            else
            {
                rpts.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_我方操作人统计_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_我方操作人统计_栏目, true);
                }
            }

        }
        /// <summary>
        /// 导出excel
        /// </summary>
        void ToXls()
        {
            ResponseToXls(Request.Form["txtXlsHTML"]);
        }

        protected string getRsHtml(object obj)
        {
            if (obj == null) return "";
            MCaoZuoRenRenShuInfo _obj = (MCaoZuoRenRenShuInfo)obj;
            return string.Format("{0}+{1}+{2}+{3}", _obj.ChengRen, _obj.ErTong, _obj.YingEr, _obj.QuanPei);

        }
    }
}
