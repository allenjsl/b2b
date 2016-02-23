//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.EnumType.FinStructure;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.FinStructure;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-付款审批
    /// </summary>
    public partial class FuKuanShenPiBoxy : BackPage
    {
        #region attributes
        /// <summary>
        /// 款项类型
        /// </summary>
        protected EyouSoft.Model.EnumType.FinStructure.KuanXiangType? IKuanXiangType;
        /// <summary>
        /// 付款项目编号
        /// </summary>
        protected string XiangMuId = string.Empty;
        /// <summary>
        /// 审批权限
        /// </summary>
        bool Privs_ShenPi = false;
        /// <summary>
        /// 付款登记编号
        /// </summary>
        string FuKuanId = string.Empty;
        /// <summary>
        /// 支付权限
        /// </summary>
        bool Privs_ZhiFu = false;
        /// <summary>
        /// 批量操作类型
        /// </summary>
        string PiLiangType = string.Empty;
        /// <summary>
        /// 取消审批权限
        /// </summary>
        bool Privs_QuXiaoShenPi = false;
        /// <summary>
        /// 取消支付权限
        /// </summary>
        bool Privs_QuXiaoZhiFu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            IKuanXiangType = (KuanXiangType?)Utils.GetEnumValueNull(typeof(KuanXiangType), Utils.GetQueryStringValue("kxtype"));
            XiangMuId = Utils.GetQueryStringValue("xmid");
            FuKuanId = Utils.GetQueryStringValue("fukuanid");
            KuanXiangType[] types = { KuanXiangType.地接支出付款, KuanXiangType.订单退款, KuanXiangType.酒店安排付款, KuanXiangType.票务安排付款, KuanXiangType.票务押金付款, KuanXiangType.其它支出付款 };
            var info = new EyouSoft.BLL.FinStructure.BFuKuan().GetInfo(FuKuanId);
            PiLiangType = Utils.GetQueryStringValue("piLiangType");

            if (string.IsNullOrEmpty(PiLiangType))
                if (!IKuanXiangType.HasValue || string.IsNullOrEmpty(XiangMuId)
                    || string.IsNullOrEmpty(FuKuanId)
                    || info == null
                    || !types.Contains(IKuanXiangType.Value)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));

            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "shenpi": ShenPi(); break;
                case "zhifu": ZhiFu(); break;
                case "shenpipiliang": ShenPiPiLiang(); break;
                case "zhifupiliang": ZhiFuPiLiang(); break;
                case "quxiaoshenpi": QuXiaoShenPi(); break;
                case "quxiaozhifu": QuXiaoZhiFu(); break;
                default: break;
            }

            if (string.IsNullOrEmpty(PiLiangType)) InitInfo(info);
            else InitPiLiangInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!string.IsNullOrEmpty(PiLiangType))
            {
                Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款审批);
                Privs_ZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款支付);
                return;
            }

            switch (IKuanXiangType.Value)
            {
                case KuanXiangType.地接支出付款:
                    Privs_ShenPi =  CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款审批);
                    Privs_ZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款支付);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款审批);
                    Privs_QuXiaoZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款支付);
                    break;
                case KuanXiangType.订单退款:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_退款审核);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_取消退款审核);
                    break;
                case KuanXiangType.酒店安排付款:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款审批);
                    Privs_ZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款支付);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款审批);
                    Privs_QuXiaoZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款支付);
                    break;
                case KuanXiangType.票务安排付款:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款审批);
                    Privs_ZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款支付);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款审批);
                    Privs_QuXiaoZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款支付);
                    break;
                case KuanXiangType.票务押金付款:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款审批);
                    Privs_ZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款支付);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款审批);
                    Privs_QuXiaoZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款支付);
                    break;
                case KuanXiangType.其它支出付款:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款审批);
                    Privs_ZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_付款支付);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款审批);
                    Privs_QuXiaoZhiFu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_取消付款支付);
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 审批
        /// </summary>
        void ShenPi()
        {
            if (!Privs_ShenPi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();

            DateTime bankDate = Utils.GetDateTime(Utils.GetFormValue("txtBankDate"));
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.OperatorId = SiteUserInfo.UserId;

            int bllRetCode = 4;
            if (IKuanXiangType.Value == KuanXiangType.订单退款)
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().ZhiFu(FuKuanId, IKuanXiangType.Value, XiangMuId, info, bankDate);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().ShenPi(FuKuanId, IKuanXiangType.Value, XiangMuId, info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 付款支付
        /// </summary>
        void ZhiFu()
        {
            if (!Privs_ZhiFu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();

            DateTime bankDate = Utils.GetDateTime(Utils.GetFormValue("txtBankDate"));
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.OperatorId = SiteUserInfo.UserId;

            int bllRetCode = 4;
            bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().ZhiFu(FuKuanId, IKuanXiangType.Value, XiangMuId, info, bankDate);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 初始化审批信息
        /// </summary>
        void InitInfo(MFuKuanInfo info)
        {
            //txtShenPiBankDate.Value = txtZhiFuBankDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            txtShenPiRenName.Value = SiteUserInfo.Name;
            txtShenPiTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtZhiFuRenName.Value = SiteUserInfo.Name;
            txtZhiFuTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (info.KuanXiangType == KuanXiangType.订单退款)
            {
                phShenPiBankDate.Visible = true;
                phZhiFu.Visible = false;

                if (info.Status == KuanXiangStatus.未审批)
                {
                    if (Privs_ShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_shenpi\">审批</a>";
                    else ltrOperatorHtml.Text = "你没有审批权限";
                }
                else
                {
                    InitShenPiInfo(info);
                    txtShenPiBeiZhu.Disabled = txtShenPiBankDate.Disabled = true;
                    if (Privs_QuXiaoShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_quxiaoshenpi\">取消审批</a>";
                    else ltrOperatorHtml.Text = "该款项已审批";
                }

                return;
            }

            switch (info.Status)
            {
                case KuanXiangStatus.未审批:
                    phZhiFu.Visible = false;
                    if (Privs_ShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_shenpi\">审批</a>";
                    else ltrOperatorHtml.Text = "你没有审批权限";
                    break;
                case KuanXiangStatus.未支付:                    
                    phZhiFu.Visible = true;
                    InitShenPiInfo(info);
                    txtShenPiBeiZhu.Disabled = true;
                    string s1 = string.Empty;
                    if (Privs_ZhiFu) s1 += "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_a_zhifu\">支付</a></div>";
                    if (Privs_QuXiaoShenPi) s1 += "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_a_quxiaoshenpi\">取消审批</a></div>";
                    if (string.IsNullOrEmpty(s1)) s1 = "你没有支付权限";
                    ltrOperatorHtml.Text = s1;
                    break;
                case KuanXiangStatus.已支付:
                    phZhiFu.Visible = true;
                    InitShenPiInfo(info);
                    InitZhiFuiInfo(info);
                    txtShenPiBeiZhu.Disabled = txtZhiFuBankDate.Disabled = txtZhiFuBeiZhu.Disabled = true;
                    if (Privs_QuXiaoZhiFu) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_quxiaozhifu\">取消支付</a>";
                    else ltrOperatorHtml.Text = "该款项已支付";
                    break;
            }
        }
        
        /// <summary>
        /// 初始化审批信息
        /// </summary>
        /// <param name="info">付款实体</param>
        void InitShenPiInfo(MFuKuanInfo info)
        {
            if (info.BankDate.HasValue) txtShenPiBankDate.Value = info.BankDate.Value.ToString("yyyy-MM-dd");
            txtShenPiBeiZhu.Value = info.ShenHeBeiZhu;
            if (!string.IsNullOrEmpty(info.ShenHeRenName)) txtShenPiRenName.Value = info.ShenHeRenName;
            if (info.ShenHeTime.HasValue) txtShenPiTime.Value = info.ShenHeTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 初始化支付信息
        /// </summary>
        /// <param name="info">付款实体</param>
        void InitZhiFuiInfo(MFuKuanInfo info)
        {
            if (info.BankDate.HasValue) txtZhiFuBankDate.Value = info.BankDate.Value.ToString("yyyy-MM-dd");
            txtZhiFuBeiZhu.Value = info.ZhiFuBeiZhu;
            if (!string.IsNullOrEmpty(info.ZhiFuRenName)) txtZhiFuRenName.Value = info.ZhiFuRenName;
            if (info.ZhiFuTime.HasValue) txtZhiFuTime.Value = info.ZhiFuTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 初始化批量操作页面信息
        /// </summary>
        void InitPiLiangInfo()
        {
            if (PiLiangType == "shenpi")
            {
                phShenPiBankDate.Visible = phZhiFu.Visible = false;
                txtShenPiRenName.Value = SiteUserInfo.Name;
                txtShenPiTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (Privs_ShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_shenpi_piliang\">批量审批</a>";
                else ltrOperatorHtml.Text = "你没有审批权限";
            }
            else if (PiLiangType == "zhifu")
            {
                phShenPiBankDate.Visible = phShenPi.Visible = false;
                phZhiFu.Visible = true;
                txtZhiFuRenName.Value = SiteUserInfo.Name;
                txtZhiFuTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (Privs_ZhiFu) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_zhifu_piliang\">批量支付</a>";
                else ltrOperatorHtml.Text = "你没有支付权限";
            }
            else
            {
                RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));
            }
        }

        /// <summary>
        /// 批量审批
        /// </summary>
        void ShenPiPiLiang()
        {
            if (!Privs_ShenPi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();

            info.BeiZhu = Utils.GetFormValue("BeiZhu");
            info.OperatorId = SiteUserInfo.UserId;

            string[] fuKuanIds = Utils.GetFormValues("FuKuanId[]");
            string[] xiangMuIds = Utils.GetFormValues("XiangMuId[]");
            string[] kuanXiangTypes = Utils.GetFormValues("KuanXiangType[]");

            if (fuKuanIds.Length == 0 || xiangMuIds.Length == 0 || kuanXiangTypes.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请求异常。"));
            if (fuKuanIds.Length != xiangMuIds.Length) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请求异常。"));
            if (fuKuanIds.Length != kuanXiangTypes.Length) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请求异常。"));

            int bllRetCode = 4;

            for (int i = 0; i < fuKuanIds.Length; i++)
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().ShenPi(fuKuanIds[i], Utils.GetEnumValue<KuanXiangType>(kuanXiangTypes[i], KuanXiangType.其它收入收款), xiangMuIds[i], info);
            }

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
        }

        /// <summary>
        /// 批量支付
        /// </summary>
        void ZhiFuPiLiang()
        {
            if (!Privs_ZhiFu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();

            DateTime bankDate = Utils.GetDateTime(Utils.GetFormValue("BankDate"));
            info.BeiZhu = Utils.GetFormValue("BeiZhu");
            info.OperatorId = SiteUserInfo.UserId;

            string[] fuKuanIds = Utils.GetFormValues("FuKuanId[]");
            string[] xiangMuIds = Utils.GetFormValues("XiangMuId[]");
            string[] kuanXiangTypes = Utils.GetFormValues("KuanXiangType[]");

            if (fuKuanIds.Length == 0 || xiangMuIds.Length == 0 || kuanXiangTypes.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请求异常。"));
            if (fuKuanIds.Length != xiangMuIds.Length) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请求异常。"));
            if (fuKuanIds.Length != kuanXiangTypes.Length) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请求异常。"));

            int bllRetCode = 4;

            for (int i = 0; i < fuKuanIds.Length; i++)
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().ZhiFu(fuKuanIds[i], Utils.GetEnumValue<KuanXiangType>(kuanXiangTypes[i], KuanXiangType.其它收入收款), xiangMuIds[i], info, bankDate);
            }

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
        }

        /// <summary>
        /// 取消审批
        /// </summary>
        void QuXiaoShenPi()
        {
            if (!Privs_QuXiaoShenPi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();
            info.BeiZhu = string.Empty;
            info.OperatorId = SiteUserInfo.UserId;

            int bllRetCode = 4;
            if (IKuanXiangType.Value == KuanXiangType.订单退款)
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().QuXiaoZhiFu(FuKuanId, IKuanXiangType.Value, XiangMuId, info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().QuXiaoShenPi(FuKuanId, IKuanXiangType.Value, XiangMuId, info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消付款支付
        /// </summary>
        void QuXiaoZhiFu()
        {
            if (!Privs_ZhiFu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();
            info.BeiZhu = string.Empty;
            info.OperatorId = SiteUserInfo.UserId;

            int bllRetCode = 4;
            bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().QuXiaoZhiFu(FuKuanId, IKuanXiangType.Value, XiangMuId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
