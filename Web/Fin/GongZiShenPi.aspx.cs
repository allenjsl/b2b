using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.EnumType.FinStructure;
using EyouSoft.Model.FinStructure;

namespace Web.Fin
{
    public partial class GongZiShenPi : BackPage
    {
        #region attributes
        /// <summary>
        /// 借款编号
        /// </summary>
        string BaoXiaoId = string.Empty;
        /// <summary>
        /// 审批权限
        /// </summary>
        bool Privs_ShenPi = false;
        /// <summary>
        /// 支付权限
        /// </summary>
        bool Privs_ZhiFu =  false;
        /// <summary>
        /// 取消审批权限
        /// </summary>
        bool Privs_QuXiaoShenPi =  false;
        /// <summary>
        /// 取消支付权限
        /// </summary>
        bool Privs_QuXiaoZhiFu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BaoXiaoId = Utils.GetQueryStringValue("gongzi");
            if (string.IsNullOrEmpty(BaoXiaoId)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));
            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "shenpi": ShenPi(); break;
                case "zhifu": ZhiFu(); break;
                case "quxiaoshenpi": QuXiaoShenPi(); break;
                case "quxiaozhifu": QuXiaoZhiFu(); break;
                default: break;
            }

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_审批);
            Privs_ZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_支付);
            Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_取消审批);
            Privs_QuXiaoZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_取消支付);
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.FinStructure.BGongZi().GetInfo(BaoXiaoId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));

            switch (info.Status)
            {
                case GongZiStatus.未审批:
                    phZhiFu.Visible = false;
                    txtShenPiRenName.Value = SiteUserInfo.Name;
                    txtShenPiTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    //if (Privs_ShenPi) ltrOperatorHtml.Text = "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_shenpi_1\" class=\"i_shenpi\" i_status=\"1\">通过</a></div><div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_shenpi_0\" class=\"i_shenpi\" i_status=\"0\">不通过</a></div>";
                    if (Privs_ShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_shenpi_1\" class=\"i_shenpi\" i_status=\"1\">审批</a>";
                    else ltrOperatorHtml.Text = "你没有工资审批权限";
                    break;
                case GongZiStatus.未支付:
                    ltrZhiFuZhangHu.Text = GetZhangHuSelectHtml(string.Empty, "txtZhiFuZhangHu", false);
                    InitShenPiInfo(info);
                    txtShenPiBeiZhu.Disabled = txtShenPiRenName.Disabled = txtShenPiTime.Disabled = true;
                    txtZhiFuRenName.Value = SiteUserInfo.Name;
                    txtZhiFuTime.Value = txtZhiFuBankDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

                    string s1 = string.Empty;
                    if (Privs_ZhiFu) s1 += "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_zhifu\">支付</a></div>";
                    if (Privs_QuXiaoShenPi) s1 += "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_quxiaoshenpi\">取消审批</a></div>";
                    if (string.IsNullOrEmpty(s1)) s1 = "你没有工资支付权限";
                    ltrOperatorHtml.Text = s1;
                    break;
                case GongZiStatus.已支付:
                    txtShenPiRenName.Disabled = txtShenPiTime.Disabled = txtShenPiBeiZhu.Disabled = true;
                    txtZhiFuBankDate.Disabled = txtZhiFuBeiZhu.Disabled = txtZhiFuRenName.Disabled = txtZhiFuTime.Disabled = true;
                    InitShenPiInfo(info);
                    InitZhiFuInfo(info);

                    if (Privs_QuXiaoZhiFu) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_quxiaozhifu\">取消支付</a>";
                    else ltrOperatorHtml.Text = "工资已支付";
                    break;
            }
        }

        /// <summary>
        /// 获取银行账户下拉菜单
        /// </summary>
        /// <param name="selectValue">要选中的值</param>
        /// <param name="clientId">下拉菜单CLIENTID</param>
        /// <param name="disabled">是否禁用</param>
        /// <returns></returns>
        string GetZhangHuSelectHtml(string selectValue, string clientId, bool disabled)
        {
            if (string.IsNullOrEmpty(selectValue)) selectValue = "";
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(CurrentUserCompanyID, CurrentZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.收付款账户);

            s.AppendFormat("<select name=\"{0}\" id=\"{0}\" class=\"inputselect\" {1}>", clientId, disabled ? "disabled=\"disabled\"" : "");
            s.Append("<option value=\"\">请选择</option>");

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用 || item.Id == selectValue)
                    {
                        if (item.Id == selectValue)
                        {
                            s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Id, item.BankName + "-" + item.AccountName + "-" + item.BankNo);
                        }
                        else
                        {
                            s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Id, item.BankName + "-" + item.AccountName + "-" + item.BankNo);
                        }
                    }
                }
            }

            s.AppendFormat("</select>");

            return s.ToString();
        }

        /// <summary>
        /// 初始化审批信息
        /// </summary>
        /// <param name="info">实体</param>
        void InitShenPiInfo(MGongZiInfo info)
        {
            txtShenPiRenName.Value = info.ShenHeOperatorName;
            if (info.ShenHeTime.HasValue) txtShenPiTime.Value = info.ShenHeTime.Value.ToString("yyyy-MM-dd");
            txtShenPiBeiZhu.Value = info.ShenHeBeiZhu;
        }

        /// <summary>
        /// 初始化支付信息
        /// </summary>
        /// <param name="info">实体</param>
        void InitZhiFuInfo(MGongZiInfo info)
        {
            if (info.YingHangTime.HasValue) txtZhiFuBankDate.Value = info.YingHangTime.Value.ToString("yyyy-MM-dd");
            txtZhiFuBeiZhu.Value = info.ZhiFuBeiZhu;
            txtZhiFuRenName.Value = info.ZhiFuOperatorName;
            if (info.ZhiFuTime.HasValue) txtZhiFuTime.Value = info.ZhiFuTime.Value.ToString("yyyy-MM-dd");
            ltrZhiFuZhangHu.Text = GetZhangHuSelectHtml(info.ZhangHuId, "txtZhiFuZhangHu", true);
        }

        /// <summary>
        /// 审批
        /// </summary>
        void ShenPi()
        {
            if (!Privs_ShenPi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            bool isTongGuo = Utils.GetFormValue("txtStatus") == "1";
            var info = new MOperatorInfo();

            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");

            int bllRetCode = new EyouSoft.BLL.FinStructure.BGongZi().ShenPi(BaoXiaoId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 支付
        /// </summary>
        void ZhiFu()
        {
            if (!Privs_ZhiFu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            DateTime bankDate = Utils.GetDateTime(Utils.GetFormValue("txtBankDate"));
            string zhangHuId = Utils.GetFormValue("txtZhangHu");
            var info = new MOperatorInfo();

            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BGongZi().ZhiFu(BaoXiaoId, info, zhangHuId, bankDate);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消审批
        /// </summary>
        void QuXiaoShenPi()
        {
            if (!Privs_QuXiaoShenPi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new MOperatorInfo();

            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = string.Empty;
            int bllRetCode = new EyouSoft.BLL.FinStructure.BGongZi().QuXiaoShenPi(BaoXiaoId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消支付
        /// </summary>
        void QuXiaoZhiFu()
        {
            if (!Privs_QuXiaoZhiFu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new MOperatorInfo();

            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = string.Empty;
            int bllRetCode = new EyouSoft.BLL.FinStructure.BGongZi().QuXiaoZhiFu(BaoXiaoId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
