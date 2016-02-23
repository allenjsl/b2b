//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.FinStructure;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-借款登记
    /// </summary>
    public partial class JieKuanEdit :BackPage
    {
        #region attributes
        /// <summary>
        /// 借款登记编号
        /// </summary>
        string JieKuanId = string.Empty;
        /// <summary>
        /// 借款操作权限
        /// </summary>
        bool Privs_Insert = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            JieKuanId = Utils.GetQueryStringValue("jiekuanid");
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
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_借款登记);
        }

        /// <summary>
        /// 初始化借款信息
        /// </summary>
        void InitInfo()
        {
            txtRiQi.Value = DateTime.Now.ToString("yyyy-MM-dd");

            if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有借款操作权限";

            var info = new EyouSoft.BLL.FinStructure.BJieKuan().GetInfo(JieKuanId);
            if (info == null) return;

            txtRiQi.Value = info.JieKuanRiQi.ToString("yyyy-MM-dd");
            txtJinE.Value = info.JinE.ToString("F2");
            txtYuanYin.Value = info.JieKuanYuanYin;
            txtJieKuanRen.SellsID = info.JieKuanRenId.ToString();
            txtJieKuanRen.SellsName = info.JieKuanRenName;

            switch (info.Status)
            {
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未审批:
                    if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"a_save\">保存</a>";
                    else ltrOperatorHtml.Text = "你没有借款操作权限";
                    break;
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未通过:
                    ltrOperatorHtml.Text = "该借款信息审批未通过";
                    break;
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未支付:
                    ltrOperatorHtml.Text = "该借款信息审批已通过，等待支付";
                    break;
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已归还:
                    ltrOperatorHtml.Text = "该借款已归还";
                    break;
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已支付:
                    ltrOperatorHtml.Text = "该借款已支付，暂未归还";
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.JieKuanId = JieKuanId;
            int bllRetCode = 4;
            if (string.IsNullOrEmpty(JieKuanId))
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MJieKuanInfo GetFormInfo()
        {
            MJieKuanInfo info = new MJieKuanInfo();

            info.JieKuanRiQi = Utils.GetDateTime(Utils.GetFormValue("txtRiQi"));
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("txtJinE"));
            info.JieKuanYuanYin = Utils.GetFormValue("txtYuanYin");
            info.JieKuanRenId = Utils.GetInt(Utils.GetFormValue("txtJieKuanRenId"));
            info.CompanyId = CurrentUserCompanyID;
            info.OperatorId = SiteUserInfo.UserId;
            info.ZxsId = CurrentZxsId;

            return info;
        }
        #endregion
    }
}
