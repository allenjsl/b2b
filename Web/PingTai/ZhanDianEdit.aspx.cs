using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.PingTai
{
    /// <summary>
    /// 站点管理-编辑
    /// </summary>
    public partial class ZhanDianEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 站点编号
        /// </summary>
        int EditId = 0;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetInt(Utils.GetQueryStringValue("editid"));
            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "save") Save();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_站点管理_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_站点管理_修改);

            if (EditId == 0)
            {
                if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
            else
            {
                if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.PtStructure.BPt().GetZhanDianInfo(EditId);
            if (EditId > 0 && info == null) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));
            if (info == null) return;
            txtMingCheng.Value = info.MingCheng;
            txtPaiXuId.Value = info.PaiXuId.ToString();

            if (info.Xzqhdms != null && info.Xzqhdms.Count > 0)
            {
                StringBuilder s = new StringBuilder();
                foreach (var item in info.Xzqhdms)
                {
                    s.Append("," + item);
                }

                txtXzqhdm.Value = s.ToString().TrimStart(',');
            }
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (EditId == 0)
            {
                if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            var info = GetFormInfo();

            int bllRetCode = 0;

            if (EditId == 0)
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BPt().InsertZhanDian(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BPt().UpdateZhanDian(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已存在相同的站点名称"));           
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZhanDianInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MZhanDianInfo();
            info.CompanyId = CurrentUserCompanyID;
            info.IssueTime = DateTime.Now;
            info.MingCheng = Utils.GetFormValue("txtMingCheng");
            info.OperatorId = SiteUserInfo.UserId;
            info.ZhanDianId = EditId;
            info.PaiXuId = Utils.GetInt(Utils.GetFormValue("txtPaiXuId"));

            info.Xzqhdms = new List<string>();

            string xzqhdm = Utils.GetFormValue("txtXzqhdm");
            if (!string.IsNullOrEmpty(xzqhdm))
            {
                var items = xzqhdm.Split(',');
                foreach (var item in items)
                {
                    string s=item;
                    if (string.IsNullOrEmpty(s)) continue;
                    if (item.Length > 6) s = s.Substring(0, 6);
                    else if (item.Length == 6) { }
                    else if (item.Length > 4) s = s.Substring(0, 4);
                    else if (item.Length == 4) { }
                    else if (item.Length > 2) s = s.Substring(0, 2);
                    else if (item.Length == 2) { }
                    else continue;
                    info.Xzqhdms.Add(s);
                }
            }

            return info;
        }
        #endregion
    }
}
