//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.EnumType.FinStructure;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-收款登记
    /// </summary>
    public partial class FuKuan : BackPage
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
        /// 删除权限
        /// </summary>
        bool Privs_Delete = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        protected bool Privs_Insert = false;
        /// <summary>
        /// 订单退款审批权限
        /// </summary>
        bool Privs_DingDanTuiKuanShenPi = false;
        /// <summary>
        /// 订单退款取消审批权限
        /// </summary>
        bool Privs_DingDanTuiKuanQuXiaoShenPi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            IKuanXiangType = (KuanXiangType?)Utils.GetEnumValueNull(typeof(KuanXiangType), Utils.GetQueryStringValue("kxtype"));
            XiangMuId = Utils.GetQueryStringValue("xmid");
            KuanXiangType[] types = { KuanXiangType.地接支出付款, KuanXiangType.订单退款, KuanXiangType.酒店安排付款, KuanXiangType.票务安排付款,KuanXiangType.票务押金付款,KuanXiangType.其它支出付款 };

            if (!IKuanXiangType.HasValue || string.IsNullOrEmpty(XiangMuId) || !types.Contains(IKuanXiangType.Value)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求类型。"));

            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "save": Save(); break;
                case "delete": Delete(); break;
            }

            InitJinE();
            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            switch (IKuanXiangType.Value)
            {
                case KuanXiangType.地接支出付款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_应付地接费_付款登记);
                    break;
                case KuanXiangType.订单退款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_退款登记);
                    Privs_DingDanTuiKuanQuXiaoShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_取消退款审核);
                    Privs_DingDanTuiKuanShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_退款审核);
                    break;
                case KuanXiangType.酒店安排付款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_预订酒店应付费_付款登记);
                    break;
                case KuanXiangType.票务安排付款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_应付交通费_付款登记);
                    break;
                case KuanXiangType.票务押金付款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_押金登记表_付款登记);
                    break;
                case KuanXiangType.其它支出付款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他支出表_付款登记);
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 初始化金额信息
        /// </summary>
        void InitJinE()
        {
            var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingFuJinE(XiangMuId, IKuanXiangType.Value);

            if (IKuanXiangType.Value != KuanXiangType.订单退款)
            {
                ltrJinE.Text = string.Format("应付金额：{0}，已支付金额：{1}，已审批金额：{2}，未审批金额：{3}，未登记金额：{4}", ToMoneyString(jinE[0])
                    , ToMoneyString(jinE[1])
                    , ToMoneyString(jinE[2])
                    , ToMoneyString(jinE[3])
                    , ToMoneyString(jinE[0] - jinE[1] - jinE[2] - jinE[3]));
            }
            else
            {
                ltrJinE.Text = string.Format("已审批金额：{0}，未审批金额：{1}", ToMoneyString(jinE[1]), ToMoneyString(jinE[3]));
            }
        }

        /// <summary>
        /// int repeater
        /// </summary>
        void InitRpts()
        {
            var items = new EyouSoft.BLL.FinStructure.BFuKuan().GetFuKuans(IKuanXiangType.Value, XiangMuId);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();
            }
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new EyouSoft.Model.FinStructure.MFuKuanInfo();
            info.CompanyId = CurrentUserCompanyID;
            info.DengJiId = Utils.GetFormValue("txtFuKuanId");
            info.FuKuanRiQi = Utils.GetDateTime(Utils.GetFormValue("txtRiQi"));
            info.FuKuanRenName = Utils.GetFormValue("txtName");
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("txtJinE"));
            info.FangShi = Utils.GetEnumValue<ShouFuKuanFangShi>(Utils.GetFormValue("txtFangShi"), ShouFuKuanFangShi.财务现付);
            info.FuKuanBeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.FuKuanXiangMuId = XiangMuId;
            info.OperatorId = SiteUserInfo.UserId;
            info.ZhangHuId = Utils.GetFormValue("txtZhangHu");
            info.KuanXiangType = IKuanXiangType.Value;
            info.ZxsId = CurrentZxsId;

            int bllRetCode = 4;
            if (!string.IsNullOrEmpty(info.DengJiId)) bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().Update(info);
            else bllRetCode = new EyouSoft.BLL.FinStructure.BFuKuan().Insert(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -3) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：所有登记金额不能大于应付金额。"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 删除
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string dengJiId = Utils.GetFormValue("txtFuKuanId");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BShouKuan().Delete(dengJiId, CurrentUserCompanyID, XiangMuId, IKuanXiangType.Value);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        #endregion

        #region protected members
        /// <summary>
        /// 获取收款方式下拉菜单项
        /// </summary>
        /// <param name="obj">要选中的值</param>
        /// <returns></returns>
        protected string GetFangShiOptionHtml(object obj)
        {
            if (obj == null) obj = "";

            if (string.IsNullOrEmpty(obj.ToString()))
            {
                var zxsPeiZhiInfo = new EyouSoft.BLL.CompanyStructure.CompanySetting().GetZxsPeiZhiInfo(CurrentUserCompanyID, CurrentZxsId);
                if (zxsPeiZhiInfo != null && !string.IsNullOrEmpty(zxsPeiZhiInfo.SFKZFFS)) obj = zxsPeiZhiInfo.SFKZFFS;
            }

            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = EnumObj.GetList(typeof(ShouFuKuanFangShi));

            s.Append("<option value=\"\">请选择</option>");

            if (items == null || items.Count == 0) return s.ToString();

            foreach (var item in items)
            {
                if (item.Value == obj.ToString())
                {
                    s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value, item.Text);
                }
                else
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Value, item.Text);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取银行账户下拉菜单项
        /// </summary>
        /// <param name="obj">要选中的值</param>
        /// <returns></returns>
        protected string GetZhangHuOptionHtml(object obj)
        {
            if (obj == null) obj = "";
            if (string.IsNullOrEmpty(obj.ToString()))
            {
                var zxsPeiZhiInfo = new EyouSoft.BLL.CompanyStructure.CompanySetting().GetZxsPeiZhiInfo(CurrentUserCompanyID, CurrentZxsId);
                if (zxsPeiZhiInfo != null && !string.IsNullOrEmpty(zxsPeiZhiInfo.SFKYHZH)) obj = zxsPeiZhiInfo.SFKYHZH;
            }

            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(CurrentUserCompanyID, CurrentZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.收付款账户);

            s.Append("<option value=\"\">请选择</option>");

            if (items == null || items.Count == 0) return s.ToString();

            foreach (var item in items)
            {
                if (item.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用 || item.Id == obj.ToString())
                {
                    if (item.Id == obj.ToString())
                    {
                        s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Id, item.BankName + "-" + item.AccountName + "-" + item.BankNo);
                    }
                    else
                    {
                        s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Id, item.BankName + "-" + item.AccountName + "-" + item.BankNo);
                    }
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <param name="obj">状态</param>
        /// <returns></returns>
        protected string GetOperatorHtml(object obj)
        {
            KuanXiangStatus status = (KuanXiangStatus)obj;
            string s = string.Empty;

            if (status == KuanXiangStatus.未审批)
            {
                if (Privs_Insert)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_save\">修改</a>&nbsp;";
                }

                if (Privs_Delete)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a>&nbsp;";
                }

                if (IKuanXiangType.Value == KuanXiangType.订单退款 && Privs_DingDanTuiKuanShenPi)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_shenpi\">审批</a>";
                }
            }

            if (status == KuanXiangStatus.已支付)
            {
                if (IKuanXiangType.Value == KuanXiangType.订单退款 && Privs_DingDanTuiKuanQuXiaoShenPi)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_shenpi\">已审批</a>";
                }
            }

            return s;
        }

        /// <summary>
        /// 获取状态字符串
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="kuanXiangType">款项类型</param>
        /// <returns></returns>
        protected string GetStatus(object status, object kuanXiangType)
        {
            KuanXiangStatus _status = (KuanXiangStatus)status;
            KuanXiangType _kuanXiangType = (KuanXiangType)kuanXiangType;

            if (_kuanXiangType == KuanXiangType.订单退款 && _status == KuanXiangStatus.已支付) return "已审批";

            return _status.ToString();
        }
        #endregion
    }
}
