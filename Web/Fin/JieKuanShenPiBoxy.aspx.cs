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
    /// 财务管理-借款审批、支付、归还
    /// </summary>
    public partial class JieKuanShenPiBoxy : BackPage
    {
        #region attributes
        /// <summary>
        /// 借款编号
        /// </summary>
        string JieKuanId = string.Empty;
        /// <summary>
        /// 审批权限
        /// </summary>
        bool Privs_ShenPi = false;
        /// <summary>
        /// 支付权限
        /// </summary>
        bool Privs_ZhiFu = false;
        /// <summary>
        /// 归还权限
        /// </summary>
        bool Privs_GuiHuan = false;
        /// <summary>
        /// 取消审批权限
        /// </summary>
        bool Privs_QuXiaoShenPi = false;
        /// <summary>
        /// 取消支付权限
        /// </summary>
        bool Privs_QuXiaoZhiFu = false;
        /// <summary>
        /// 取消归还权限
        /// </summary>
        bool Privs_QuXiaoGuiHuan = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            JieKuanId = Utils.GetQueryStringValue("jiekuanid");
            if (string.IsNullOrEmpty(JieKuanId)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));
            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "shenpi": ShenPi(); break;
                case "zhifu": ZhiFu(); break;
                case "guihuan": GuiHuan(); break;
                case "quxiaoshenpi": QuXiaoShenPi(); break;
                case "quxiaozhifu": QuXiaoZhiFu(); break;
                case "quxiaoguihuan": QuXiaoGuiHuan(); break;
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
            Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_借款审批);
            Privs_ZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_借款支付);
            Privs_GuiHuan = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_借款归还);
            Privs_QuXiaoGuiHuan = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_取消归还);
            Privs_QuXiaoZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_取消支付);
            Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_取消审批);
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.FinStructure.BJieKuan().GetInfo(JieKuanId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));

            switch (info.Status)
            {
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未审批:
                    phZhiFu.Visible = phGuiHuan.Visible = false;
                    txtShenPiRenName.Value = SiteUserInfo.Name;
                    txtShenPiTime.Value = DateTime.Now.ToString("yyyy-MM-dd");

                    if (Privs_ShenPi) ltrOperatorHtml.Text = "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_shenpi_1\" class=\"i_shenpi\" i_status=\"1\">通过</a></div><div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_shenpi_0\" class=\"i_shenpi\" i_status=\"0\">不通过</a></div>";
                    else ltrOperatorHtml.Text = "你没有借款审批权限";
                    break;
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未通过:
                    phZhiFu.Visible = phGuiHuan.Visible = false;
                    InitShenPiInfo(info);

                    if (Privs_QuXiaoShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_quxiaoshenpi\">取消审批</a>";
                    else ltrOperatorHtml.Text = "借款信息审批未通过";
                    break;
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未支付:
                    phGuiHuan.Visible = false;
                    ltrZhiFuZhangHu.Text = GetZhangHuSelectHtml(string.Empty, "txtZhiFuZhangHu", false);
                    InitShenPiInfo(info);
                    txtShenPiBeiZhu.Disabled = txtShenPiRenName.Disabled = txtShenPiTime.Disabled = true;
                    txtZhiFuRenName.Value = SiteUserInfo.Name;
                    txtZhiFuTime.Value = txtZhiFuBankDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

                    string s1 = string.Empty;
                    if (Privs_ZhiFu) s1 += "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_zhifu\">支付</a></div>";
                    if (Privs_QuXiaoShenPi) s1 += "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_quxiaoshenpi\">取消审批</a></div>";
                    if (string.IsNullOrEmpty(s1)) s1 = "你没有借款支付权限";
                    ltrOperatorHtml.Text = s1; 
                    break;
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已归还:
                    txtShenPiRenName.Disabled = txtShenPiTime.Disabled = txtShenPiBeiZhu.Disabled = true;
                    txtZhiFuBankDate.Disabled = txtZhiFuBeiZhu.Disabled = txtZhiFuRenName.Disabled = txtZhiFuTime.Disabled = true;
                    txtGuiHuanBankDate.Disabled = txtGuiHuanBeiZhu.Disabled = txtGuiHuanJinE.Disabled = txtGuiHuanTime.Disabled = true;
                    InitShenPiInfo(info);
                    InitZhiFuInfo(info);
                    InitGuiHuanInfo(info);

                    if (Privs_QuXiaoGuiHuan) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_quxiaoguihuan\">取消归还</a>";
                    else ltrOperatorHtml.Text = "借款已归还";
                    break;
                case EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已支付:
                    txtShenPiRenName.Disabled = txtShenPiTime.Disabled = txtShenPiBeiZhu.Disabled = true;
                    txtZhiFuBankDate.Disabled = txtZhiFuBeiZhu.Disabled = txtZhiFuRenName.Disabled = txtZhiFuTime.Disabled = true;
                    ltrGuiHuanZhangHu.Text = GetZhangHuSelectHtml(string.Empty, "txtGuiHuanZhangHu", false);
                    InitShenPiInfo(info);
                    InitZhiFuInfo(info);
                    txtGuiHuanBankDate.Value = txtGuiHuanTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    txtGuiHuanJinE.Value = info.JinE.ToString("F2");

                    string s2 = string.Empty;
                    if (Privs_GuiHuan) s2 += "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_guihuan\">归还</a></div>";
                    if (Privs_QuXiaoZhiFu) s2 += "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_quxiaozhifu\">取消支付</a></div>";
                    if (string.IsNullOrEmpty(s2)) s2 = "你没有借款归还权限";
                    ltrOperatorHtml.Text = s2;
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
        /// <param name="info">借款实体</param>
        void InitShenPiInfo(MJieKuanInfo info)
        {
            txtShenPiRenName.Value = info.ShenHeRenName;
            if (info.ShenHeTime.HasValue) txtShenPiTime.Value = info.ShenHeTime.Value.ToString("yyyy-MM-dd");
            txtShenPiBeiZhu.Value = info.ShenHeBeiZhu;
        }

        /// <summary>
        /// 初始化支付信息
        /// </summary>
        /// <param name="info">借款实体</param>
        void InitZhiFuInfo(MJieKuanInfo info)
        {
            if (info.FuKuanBankDate.HasValue) txtZhiFuBankDate.Value = info.FuKuanBankDate.Value.ToString("yyyy-MM-dd");
            txtZhiFuBeiZhu.Value = info.ZhiFuBeiZhu;
            txtZhiFuRenName.Value = info.ZhiFuRenName;
            if (info.ZhiFuTime.HasValue) txtZhiFuTime.Value = info.ZhiFuTime.Value.ToString("yyyy-MM-dd");
            ltrZhiFuZhangHu.Text = GetZhangHuSelectHtml(info.FuKuanZhangHuId, "txtZhiFuZhangHu", true);
        }

        /// <summary>
        /// 初始化归还信息
        /// </summary>
        /// <param name="info">借款实体</param>
        void InitGuiHuanInfo(MJieKuanInfo info)
        {
            txtGuiHuanBankDate.Value = info.GuiHuanBankDate.Value.ToString("yyyy-MM-dd");
            txtGuiHuanBeiZhu.Value = info.GuiHuanBeiZhu;
            txtGuiHuanJinE.Value = info.JinE.ToString("F2");
            txtGuiHuanTime.Value = info.GuiHuanTime.Value.ToString("yyyy-MM-dd");
            ltrGuiHuanZhangHu.Text = GetZhangHuSelectHtml(info.GuiHuanZhangHuId, "txtGuiHuanZhangHu", true);
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
            int bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().ShenPi(JieKuanId, isTongGuo, info);

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
            int bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().ZhiFu(JieKuanId, info, zhangHuId, bankDate);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 归还
        /// </summary>
        void GuiHuan()
        {
            if (!Privs_GuiHuan) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            DateTime bankDate = Utils.GetDateTime(Utils.GetFormValue("txtBankDate"));
            string zhangHuId = Utils.GetFormValue("txtZhangHu");
            var info = new MOperatorInfo();

            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().GuiHuan(JieKuanId, info, zhangHuId, bankDate);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消归还
        /// </summary>
        void QuXiaoGuiHuan()
        {
            if (!Privs_QuXiaoGuiHuan) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            
            var info = new MOperatorInfo();

            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = string.Empty;
            int bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().QuXiaoGuiHuan(JieKuanId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消支付
        /// </summary>
        void QuXiaoZhiFu()
        {
            if (!Privs_QuXiaoGuiHuan) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new MOperatorInfo();

            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = string.Empty;
            int bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().QuXiaoZhiFu(JieKuanId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消支付
        /// </summary>
        void QuXiaoShenPi()
        {
            if (!Privs_QuXiaoGuiHuan) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new MOperatorInfo();

            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = string.Empty;
            int bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().QuXiaoShenPi(JieKuanId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
