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
    /// 财务管理-收款审批
    /// </summary>
    public partial class ShouKuanShenPiBoxy : BackPage
    {
        #region attributes
        /// <summary>
        /// 款项类型
        /// </summary>
        protected EyouSoft.Model.EnumType.FinStructure.KuanXiangType? IKuanXiangType;
        /// <summary>
        /// 收款项目编号
        /// </summary>
        protected string XiangMuId = string.Empty;
        /// <summary>
        /// 审批权限
        /// </summary>
        bool Privs_ShenPi = false;
        /// <summary>
        /// 收款登记编号
        /// </summary>
        string ShouKuanId = string.Empty;
        /// <summary>
        /// 取消审批权限
        /// </summary>
        bool Privs_QuXiaoShenPi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
            IKuanXiangType = (KuanXiangType?)Utils.GetEnumValueNull(typeof(KuanXiangType), Utils.GetQueryStringValue("kxtype"));
            XiangMuId = Utils.GetQueryStringValue("xmid");
            ShouKuanId = Utils.GetQueryStringValue("shoukuanid");
            KuanXiangType[] types = { KuanXiangType.订单收款, KuanXiangType.其它收入收款, KuanXiangType.票务押金退还, KuanXiangType.票务退款 };
            var info = new EyouSoft.BLL.FinStructure.BShouKuan().GetInfo(ShouKuanId);

            if (!IKuanXiangType.HasValue || string.IsNullOrEmpty(XiangMuId)
                || string.IsNullOrEmpty(ShouKuanId)
                || info == null
                || !types.Contains(IKuanXiangType.Value)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));

            InitPrivs();

            string doType = Utils.GetQueryStringValue("doType");

            switch (doType)
            {
                case "shenpi": ShenPi(); break;
                case "quxiaoshenpi": QuXiaoShenPi(); break;
                default: break;
            }

            InitInfo(info);
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            switch (IKuanXiangType.Value)
            {
                case KuanXiangType.订单收款:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_收款审核);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_取消收款审核);
                    break;
                case KuanXiangType.其它收入收款:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他收入表_收款审核);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他收入表_取消收款审核);
                    break;
                case KuanXiangType.票务押金退还:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_押金登记表_退回审核);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_押金登记表_取消退回审核);
                    break;
                case KuanXiangType.票务退款:
                    Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_退票登记表_收款审核);
                    Privs_QuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_退票登记表_取消收款审核);
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

            int bllRetCode = new EyouSoft.BLL.FinStructure.BShouKuan().ShenPi(ShouKuanId, IKuanXiangType.Value, XiangMuId, info, bankDate);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
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

            int bllRetCode = new EyouSoft.BLL.FinStructure.BShouKuan().QuXiaoShenPi(ShouKuanId, IKuanXiangType.Value, XiangMuId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 初始化审批信息
        /// </summary>
        void InitInfo(MShouKuanInfo info)
        {
            if (info.Status == KuanXiangStatus.未审批)
            {
                txtName.Value = SiteUserInfo.Name;
                txtTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (Privs_ShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有审批权限";
            }
            else
            {
                if (info.BankDate.HasValue) txtBankDate.Value = info.BankDate.Value.ToString("yyyy-MM-dd");
                else txtBankDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                txtBeiZhu.Value = info.ShenHeBeiZhu;
                if (!string.IsNullOrEmpty(info.ShenHeRenName)) txtName.Value = info.ShenHeRenName;
                else txtName.Value = SiteUserInfo.Name;
                if (info.ShenHeTime.HasValue) txtTime.Value = info.ShenHeTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                else txtTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (Privs_QuXiaoShenPi && !info.IsXiaoZhang) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_quxiaoshenpi\">取消审批</a>";
                else ltrOperatorHtml.Text = "该款项已审批";
            }            
        }
        #endregion
    }
}
