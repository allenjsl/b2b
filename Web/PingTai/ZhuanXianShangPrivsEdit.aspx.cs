using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Text;

namespace Web.PingTai
{
    /// <summary>
    /// 专线商权限管理
    /// </summary>
    public partial class ZhuanXianShangPrivsEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 专线商编号
        /// </summary>
        string EditId = string.Empty;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;
        /// <summary>
        /// 未开放一级栏目
        /// </summary>
        int[] WKFP1 = new int[] {7,10 };
        /// <summary>
        /// 未开放二级栏目
        /// </summary>
        int[] WKFP2 = new int[] { 35, 36, 37, 38, 39, 40, 41, 42, 43, 47, 72, 73, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 56, 76, 79, 80, 81 };
        /// <summary>
        /// 未开放明细权限
        /// </summary>
        int[] WKFP3 = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 167, 169, 174, 187, 209, 210, 293, 294, 295, 296, 297, 304, 305, 310, 311 };
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "save") Save();

            InitInfo();
            InitPrivsMoban();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_修改);

            if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有操作权限";
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var zxsInfo = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(EditId);
            if (zxsInfo == null) RCWE("异常请求");
            var comPrivs = new EyouSoft.BLL.SysStructure.BSys().GetComPrivsInfo(CurrentUserCompanyID);
            var allPrivs = new EyouSoft.BLL.SysStructure.BSys().GetPrivs1();
            for (int i = allPrivs.Count - 1; i >= 0; i--)
            {
                if (comPrivs.Privs1.Contains(allPrivs[i].MenuId) && !WKFP1.Contains(allPrivs[i].MenuId)) continue;
                allPrivs.RemoveAt(i);
            }
            foreach (var item in allPrivs)
            {
                for (int i = item.Menu2s.Count - 1; i >= 0; i--)
                {
                    if (comPrivs.Privs2.Contains(item.Menu2s[i].MenuId) && !WKFP2.Contains(item.Menu2s[i].MenuId)) continue;
                    item.Menu2s.RemoveAt(i);
                }
            }
            foreach (var item in allPrivs)
            {
                foreach (var item1 in item.Menu2s)
                {
                    for (int i = item1.Privs.Count - 1; i >= 0; i--)
                    {
                        if (comPrivs.Privs3.Contains(item1.Privs[i].PrivsId) && !WKFP3.Contains(item1.Privs[i].PrivsId)) continue;
                        item1.Privs.RemoveAt(i);
                    }
                }
            }

            StringBuilder s = new StringBuilder();

            foreach (var item in allPrivs)
            {
                s.Append("<div class=\"privs123\">");
                s.AppendFormat("<div class=\"privs1\"><input type=\"checkbox\" id=\"chk_p_1_{1}\" value=\"{1}\" name=\"chk_p_1\" /><label for=\"chk_p_1_{1}\">{0}</label><!--<span class=\"pcode\">[{1}]</span>--></div>", item.Name, item.MenuId);
                if (item.Menu2s == null || item.Menu2s.Count == 0) continue;

                s.Append("<div class=\"privs23\">");
                int i = 0;

                foreach (var item1 in item.Menu2s)
                {
                    s.Append("<ul class=\"privs2\">");
                    s.AppendFormat("<li class=\"privs2title\"><input type=\"checkbox\" id=\"chk_p_2_{1}\" value=\"{1}\" name=\"chk_p_2\" /><label for=\"chk_p_2_{1}\">{0}</label><!--<span class=\"pcode\">[{1}]</span>--></li>", item1.Name, item1.MenuId);

                    if (item1.Privs != null && item1.Privs.Count > 0)
                    {
                        foreach (var item2 in item1.Privs)
                        {
                            s.AppendFormat("<li class=\"privs3\"><input type=\"checkbox\" id=\"chk_p_3_{1}\" value=\"{1}\" name=\"chk_p_3\"  /><label for=\"chk_p_3_{1}\">{0}</label><!--<span class=\"pcode\">[{1}]</span>--></li>", item2.Name, item2.PrivsId);
                        }
                    }
                    s.Append("</ul>");

                    if (i % 4 == 3)
                    {
                        s.Append("<ul class=\"privs2space\"><li></li></ul>");
                    }
                    i++;
                }

                s.Append("<ul class=\"privs2space\"><li></li></ul>");
                s.Append("</div>");
                s.Append("</div>");
            }

            ltrPrivs.Text = s.ToString();

            string script = "var zxsPrivs={0};";
            var obj = new { privs1 = zxsInfo.Privs1, privs2 = zxsInfo.Privs2, privs3 = zxsInfo.Privs3 };
            script = string.Format(script, Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            RegisterScript(script);

            if (zxsInfo.T1 ==  EyouSoft.Model.EnumType.PtStructure.ZxsT1.主专线商)
            {
                ltrOperatorHtml.Visible = false;
            }
        }

        /// <summary>
        /// save
        /// </summary>
        void Save()
        {
            if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var privs1 = GetPrivs1();
            var privs2 = GetPrivs2();
            var privs3 = GetPrivs3();
            string _privs1 = string.Empty;
            string _privs2 = string.Empty;
            string _privs3 = string.Empty;

            if (privs1 != null && privs1.Length > 0) _privs1 = string.Join(",", privs1);
            if (privs2 != null && privs2.Length > 0) _privs2 = string.Join(",", privs2);
            if (privs3 != null && privs3.Length > 0) _privs3 = string.Join(",", privs3);

            int bllRetCode = new EyouSoft.BLL.PtStructure.BZhuanXianShang().SheZhiPrivs(CurrentUserCompanyID, EditId, _privs1, _privs2, _privs3);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// get privs1
        /// </summary>
        /// <returns></returns>
        string[] GetPrivs1()
        {
            string[] _privs1 = EyouSoft.Common.Utils.GetFormValues("chk_p_1");
            if (_privs1 == null || _privs1.Length < 1) return null;
            return _privs1;

            /*int[] privs1 = new int[_privs1.Length];

            for (int i = 0; i < _privs1.Length; i++)
            {
                privs1[i] = EyouSoft.Common.Utils.GetInt(_privs1[i]);
            }

            return privs1;*/
        }

        /// <summary>
        /// get privs2
        /// </summary>
        /// <returns></returns>
        string[] GetPrivs2()
        {
            string[] _privs2 = EyouSoft.Common.Utils.GetFormValues("chk_p_2");
            if (_privs2 == null || _privs2.Length < 1) return null;
            return _privs2;

            /*int[] privs2 = new int[_privs2.Length];

            for (int i = 0; i < _privs2.Length; i++)
            {
                privs2[i] = EyouSoft.Common.Utils.GetInt(_privs2[i]);
            }

            return privs2;*/
        }

        /// <summary>
        /// get privs3
        /// </summary>
        /// <returns></returns>
        string[] GetPrivs3()
        {
            string[] _privs3 = EyouSoft.Common.Utils.GetFormValues("chk_p_3");
            if (_privs3 == null || _privs3.Length < 1) return null;
            return _privs3;

            /*int[] privs3 = new int[_privs3.Length];

            for (int i = 0; i < _privs3.Length; i++)
            {
                privs3[i] = EyouSoft.Common.Utils.GetInt(_privs3[i]);
            }

            return privs3;*/
        }

        /// <summary>
        /// init privs moban
        /// </summary>
        void InitPrivsMoban()
        {
            var items = new EyouSoft.BLL.PtStructure.BZxsPrivsMoBan().GetMoBans(CurrentUserCompanyID);

            if (items == null || items.Count == 0) return;

            StringBuilder s = new StringBuilder();

            foreach (var item in items)
            {
                s.AppendFormat("<option value=\"{0}\">{1}</option>", item.MoBanId, item.MingCheng);
            }

            ltrPrivsMoBanOption.Text = s.ToString();

            string output = string.Format("var moBanPrivs={0};", Newtonsoft.Json.JsonConvert.SerializeObject(items));
            RegisterScript(output);
        }
        #endregion
    }
}
