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
    /// 专线类别管理-编辑
    /// </summary>
    public partial class ZhuanXianLeiBieEdit : EyouSoft.Common.Page.BackPage
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
        /// <summary>
        /// 站点编号
        /// </summary>
        protected string ZhanDianId = "";
        /// <summary>
        /// 专线类别状态
        /// </summary>
        protected string ZhuangTai = "";
        /// <summary>
        /// zxs t2
        /// </summary>
        protected string T2 = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetInt(Utils.GetQueryStringValue("editid"));
            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "save") Save();

            InitInfo();
            InitZhanDians();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线类别管理_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线类别管理_修改);

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
            var info = new EyouSoft.BLL.PtStructure.BPt().GetZhuanXianLeiBieInfo(EditId);
            if (EditId > 0 && info == null) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));
            if (info == null) return;
            txtMingCheng.Value = info.MingCheng;
            ZhanDianId = info.ZhanDianId.ToString();
            ZhuangTai = ((int)info.Status).ToString();
            txtPaiXuId.Value = info.PaiXuId.ToString();
            T2 = ((int)info.T2).ToString();
        }

        /// <summary>
        /// init zhandians
        /// </summary>
        void InitZhanDians()
        {
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZhanDians(CurrentUserCompanyID, null);
            StringBuilder s = new StringBuilder();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.ZhanDianId, item.MingCheng);
                }
            }
            ltrZhanDianOption.Text = s.ToString();
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
                bllRetCode = new EyouSoft.BLL.PtStructure.BPt().InsertZhuanXianLeiBie(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BPt().UpdateZhuanXianLeiBie(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已存在相同的专线类别名称"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo();
            info.CompanyId = CurrentUserCompanyID;
            info.IssueTime = DateTime.Now;
            info.MingCheng = Utils.GetFormValue("txtMingCheng");
            info.OperatorId = SiteUserInfo.UserId;
            info.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus>(Utils.GetFormValue("txtStatus"), EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus.启用);
            info.ZhanDianId = Utils.GetInt(Utils.GetFormValue("txtZhanDianId"));
            info.ZxlbId = EditId;
            info.PaiXuId = Utils.GetInt(Utils.GetFormValue("txtPaiXuId"));
            info.T2 = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.ZxsT2>(Utils.GetFormValue("txtT2"), EyouSoft.Model.EnumType.PtStructure.ZxsT2.默认);
            return info;
        }
        #endregion
    }
}
