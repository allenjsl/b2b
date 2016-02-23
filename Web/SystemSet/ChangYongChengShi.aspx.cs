using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;

namespace Web.SystemSet
{
    /// <summary>
    /// 常用城市
    /// </summary>
    public partial class ChangYongChengShi : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "shezhichangyongchengshi") SheZhiChangYongChengShi();

            InitRpt();
            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_常用城市栏目);

            if (!Privs_LanMu) Utils.RCWE(UtilsCommons.AjaxReturnJson("-1000", "没有权限"));
        }

        /// <summary>
        /// init shengFen
        /// </summary>
        void InitRpt()
        {
            var chaXun = new EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo();
            chaXun.LeiXing1 = 1;
            chaXun.LeiXing = 0;
            chaXun.LeiXing2 = EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing.显示;

            var items = new EyouSoft.BLL.CompanyStructure.City().GetShengFens(CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();
            }
        }

        /// <summary>
        /// shezhi changyongcheng shi
        /// </summary>
        void SheZhiChangYongChengShi()
        {
            int txtChengShiId = Utils.GetInt(Utils.GetFormValue("txtChengShiId"));

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.City().SheZhiChangYongChengShi(CurrentUserCompanyID, CurrentZxsId, txtChengShiId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：该城市已使用不能取消"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var chaXun = new EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo();
            chaXun.LeiXing = 1;
            chaXun.ZxsId = CurrentZxsId;

            var items = new EyouSoft.BLL.CompanyStructure.City().GetChengShis(CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                string output = string.Format("var changYongChengShis={0};", Newtonsoft.Json.JsonConvert.SerializeObject(items));
                RegisterScript(output);
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// get chengshi
        /// </summary>
        /// <param name="chengShis"></param>
        /// <returns></returns>
        protected string GetChengShi(object chengShis)
        {
            if (chengShis == null) return string.Empty;

            var items = (IList<EyouSoft.Model.CompanyStructure.MChengShiInfo>)chengShis;
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<ul class=\"chengshi_ul\">");
            foreach (var item in items)
            {
                s.AppendFormat("<li>");
                s.AppendFormat("<input type=\"checkbox\" class=\"chengshi_chk\" name=\"chk_chengshi\" id=\"chk_chengshi_{0}\" data-chengshiid=\"{0}\" /><label class=\"chengshi_chk\" for=\"chk_chengshi_{0}\">{1}</label>", item.ChengShiId, item.ChengShiName);
                s.AppendFormat("</li>");
            }
            s.AppendFormat("</ul>");
            return s.ToString();
        }
        #endregion
    }
}
