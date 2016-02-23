using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.Fin
{
    /// <summary>
    /// 审批出纳登账信息
    /// </summary>
    public partial class DengZhangShenPi : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 审批权限
        /// </summary>
        bool Privs_ShenPi = false;
        /// <summary>
        /// 取消审批权限
        /// </summary>
        bool Privs_QuXiaoShenPi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;

            string doType = Utils.GetQueryStringValue("doType");
            string dzId = Utils.GetQueryStringValue("dzid");

            if (string.IsNullOrEmpty(dzId))
            {
                Utils.ShowMsgAndCloseBoxy("参数丢失，请重新打开此页面！", Utils.GetQueryStringValue("iframeId"), true);
                return;
            }

            InitPrivs();

            switch (doType)
            {
                case "save": SaveData(dzId); break;
                case "quxiaoshenpi": QuXiaoShenPi(); break;
                default: break;
            }

            if (!IsPostBack)
            {
                txtOperatorId.Value = SiteUserInfo.Name;
                txtTime.Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                //只有单个审批时才初始化
                InitPage(dzId);
            }
        }

        #region private members
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="dzId"></param>
        void InitPage(string dzId)
        {
            if (string.IsNullOrEmpty(dzId)) return;

            string[] tmp = dzId.Split(',');

            var model = new EyouSoft.BLL.FinStructure.BDengZhang().GetChuNaDengZhang(tmp.Length > 1 ? tmp[0] : dzId);
            if (model == null) return;

            if (model.Status == EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批)
            {
                if (Privs_ShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"a_DengZhangShenPi_Save\">审批</a>";
                else ltrOperatorHtml.Text = "你没有审批权限";
            }
            else
            {
                if (Privs_QuXiaoShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_quxiaoshenpi\">取消审批</a>";
                else ltrOperatorHtml.Text = "该出纳登账信息已审批";

                txtBankDate.Value = model.ShenPi.BankDate.ToShortDateString();
                txtRemark.Value = model.ShenPi.Remark;
                txtOperatorId.Value = model.ShenPi.OperatorName;
                txtTime.Value = model.ShenPi.IssueTime.ToString("yyyy-MM-dd hh:mm:ss");
            }            
        }

        /// <summary>
        /// 保存审批数据
        /// </summary>
        /// <param name="dzId"></param>
        void SaveData(string dzId)
        {
            if (string.IsNullOrEmpty(dzId))
            {
                Utils.ShowMsgAndCloseBoxy("参数丢失，请重新打开此页面！", Utils.GetQueryStringValue("iframeId"), true);
                return;
            }
            DateTime dt = Utils.GetDateTime(Utils.GetFormValue("txtBankDate"), DateTime.MinValue);
            if (dt == DateTime.MinValue)
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "请填写银行实际业务日期！"));
                return;
            }

            string[] str = dzId.Split(',');

            int i =
                new EyouSoft.BLL.FinStructure.BDengZhang().ShenPiDengZhang(
                    new EyouSoft.Model.FinStructure.MShenPiDengZhang
                        {
                            BankDate = dt,
                            IssueTime = DateTime.Now,
                            OperatorId = SiteUserInfo.UserId,
                            OperatorName = SiteUserInfo.Name,
                            Remark = Utils.GetFormValue("txtRemark")
                        },
                    str);

            if (i == 1)
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("1", "审批成功！"));
                return;
            }

            this.RCWE(UtilsCommons.AjaxReturnJson("0", "审批失败！"));
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_审批);
            Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_取消审批);
        }

        /// <summary>
        /// 取消审批
        /// </summary>
        void QuXiaoShenPi()
        {
            string dengZhangId = Utils.GetQueryStringValue("dzid");
            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();
            info.BeiZhu = string.Empty;
            info.OperatorId = SiteUserInfo.UserId;

            int bllRetCode = new EyouSoft.BLL.FinStructure.BDengZhang().QuXiaoShenPi(dengZhangId, CurrentUserCompanyID, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -3) RCWE(UtilsCommons.AjaxReturnJson("-3", "已经存在销账的出纳登账信息不允许取消审批！"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }
        #endregion
    }
}
