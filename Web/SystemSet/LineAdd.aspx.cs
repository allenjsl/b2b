using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.SystemSet
{
    public partial class LineAdd : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        int EditId = 0;
        protected string ZhanDianId = "";
        protected string ZxlbId = "";
        bool Privs_LanMu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetInt(Utils.GetQueryStringValue("editid"));

            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "baocun") Save();

            InitInfo();
            InitZxlbs();
            InitShengFenChengShi();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (EditId < 1) return;

            var info = new EyouSoft.BLL.CompanyStructure.Area().GetModel(EditId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));

            this.txtAreaName.Text = info.AreaName;
            ZhanDianId = info.ZhanDianId.ToString();
            ZxlbId = info.ZxlbId.ToString();

            var script = string.Format("var shengFenChengShis={0};", Newtonsoft.Json.JsonConvert.SerializeObject(info.ShengFenChengShis));
            RegisterScript(script);
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.Area GetFormInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.Area();

            info.AreaName = Utils.GetFormValue(txtAreaName.UniqueID);
            info.CompanyId = CurrentUserCompanyID;
            info.Id = EditId;
            info.IsDelete = false;
            info.IssueTime = DateTime.Now;
            info.OperatorId = SiteUserInfo.UserId;
            info.ShengFenChengShis = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<EyouSoft.Model.CompanyStructure.MXianLuQuYuShengFenChengShiInfo>>(Utils.GetFormValue("txtShengFenChengShi"));
            info.SortId = 0;
            info.ZhanDianId = 0;
            info.ZxlbId = Utils.GetInt(Utils.GetFormValue("txtZxlb"));
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// bao cun
        /// </summary>
        void Save()
        {
            var info = GetFormInfo();

            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限"));

            if (info.ZxlbId < 1) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请选择专线类别"));
            if (string.IsNullOrEmpty(info.AreaName)) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请输入线路区域名称"));

            int bllRetCode = 0;
            if (info.Id > 0) bllRetCode = new EyouSoft.BLL.CompanyStructure.Area().QuYu_U(info);
            else bllRetCode = new EyouSoft.BLL.CompanyStructure.Area().QuYu_C(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已经存在相同的线路名称名称"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init zxlb
        /// </summary>
        void InitZxlbs()
        {
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZxsZhanDians(CurrentUserCompanyID, CurrentZxsId);

            if (items == null || items.Count == 0) return;

            StringBuilder s = new StringBuilder();

            foreach (var item in items)
            {
                s.AppendFormat("<optgroup label=\"{0}\">", item.MingCheng + "站");

                foreach (var item1 in item.Zxlbs)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item1.ZxlbId, item1.MingCheng);
                }

                s.AppendFormat("</optgroup>");
            }

            ltrZxlbOption.Text = s.ToString();            
        }

        /// <summary>
        /// init shengfen chengshi
        /// </summary>
        void InitShengFenChengShi()
        {
            var chaXun = new EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo();
            chaXun.LeiXing1 = 1;
            chaXun.LeiXing = 0;
            chaXun.LeiXing2 = EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing.显示;
            var shengFens = new EyouSoft.BLL.CompanyStructure.City().GetShengFens(CurrentUserCompanyID, chaXun);

            StringBuilder s = new StringBuilder();
            if (shengFens == null || shengFens.Count == 0) return;

            s.AppendFormat("<div>");
            int i = 0;
            foreach (var shengFen in shengFens)
            {
                var chengShis = shengFen.ChengShis;
                if (chengShis == null || chengShis.Count == 0) continue;

                s.AppendFormat("<ul class=\"p1\">");
                s.AppendFormat("<li class=\"p1title\"><input type=\"checkbox\" name=\"chk_s\" value=\"{0}\" id=\"chk_s_{0}\"><label for=\"chk_s_{0}\">{1}</label></li>", shengFen.ShengFenId, shengFen.ShengFenName);
                foreach (var chengShi in chengShis)
                {
                    s.AppendFormat("<li class=\"p1item\"><input type=\"checkbox\" name=\"chk_c\" value=\"{0}\" id=\"chk_c_{0}\"><label for=\"chk_c_{0}\">{1}</label></li>", chengShi.ChengShiId, chengShi.ChengShiName);
                }
                s.AppendFormat("</ul>");

                if (i % 5 == 4)
                {
                    s.Append("<ul class=\"p2\"><li></li></ul>");
                }
                i++;
            }
            s.AppendFormat("</div>");

            ltrQuChengChuFaDi.Text = ltrQuChengMuDiDi.Text = s.ToString();
        }

        /// <summary>
        /// 权限判断
        /// </summary>
        void InitPrivs()
        {
            Privs_LanMu = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_线路区域栏目);

            btn.Visible = Privs_LanMu;
        }
        #endregion
    }
}
