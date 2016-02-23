//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.EnumType.FinStructure;
using EyouSoft.Common.Page;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-收款登记
    /// </summary>
    public partial class ShouKuan :BackPage
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
        /// 删除权限
        /// </summary>
        bool Privs_Delete = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        protected bool Privs_Insert = false;
        /*/// <summary>
        /// 审批权限
        /// </summary>
        bool Privs_ShenPi = false;*/
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            IKuanXiangType = (KuanXiangType?)Utils.GetEnumValueNull(typeof(KuanXiangType), Utils.GetQueryStringValue("kxtype"));
            XiangMuId = Utils.GetQueryStringValue("xmid");
            KuanXiangType[] types = { KuanXiangType.订单收款, KuanXiangType.其它收入收款, KuanXiangType.票务押金退还, KuanXiangType.票务退款 };

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
                case KuanXiangType.订单收款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_收款登记);
                    //Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_收款审核);
                    break;
                case KuanXiangType.其它收入收款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他收入表_收款登记);
                    //Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他收入表_收款审核);
                    break;
                case KuanXiangType.票务押金退还:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_押金登记表_退回登记);
                    //Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_押金登记表_退回审核);
                    break;
                case KuanXiangType.票务退款:
                    Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_退票登记表_收款登记);
                    //Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_退票登记表_收款审核);
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 初始化金额信息
        /// </summary>
        void InitJinE()
        {
            var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingShouJinE(XiangMuId, IKuanXiangType.Value);

            ltrJinE.Text = string.Format("应收金额：{0}，已审批金额：{1}，未审批金额：{2}，未登记金额：{3}", ToMoneyString(jinE[0])
                , ToMoneyString(jinE[1])
                , ToMoneyString(jinE[2])
                , ToMoneyString(jinE[0] - jinE[1] - jinE[2]));
        }

        /// <summary>
        /// int repeater
        /// </summary>
        void InitRpts()
        {
            var items = new EyouSoft.BLL.FinStructure.BShouKuan().GetShouKuans(IKuanXiangType.Value, XiangMuId);

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

            var info = new EyouSoft.Model.FinStructure.MShouKuanInfo();
            info.CompanyId = CurrentUserCompanyID;
            info.DengJiId = Utils.GetFormValue("txtShouKuanId");
            info.ShouKuanRiQi = Utils.GetDateTime(Utils.GetFormValue("txtRiQi"));
            info.ShouKuanRenName = Utils.GetFormValue("txtName");            
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("txtJinE"));
            info.FangShi = Utils.GetEnumValue<ShouFuKuanFangShi>(Utils.GetFormValue("txtFangShi"), ShouFuKuanFangShi.财务现收);
            info.ShouKuanBeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.ShouKuanXiangMuId = XiangMuId;
            info.OperatorId = SiteUserInfo.UserId;
            info.ZhangHuId = Utils.GetFormValue("txtZhangHu");
            info.KuanXiangType = IKuanXiangType.Value;
            info.ZxsId = CurrentZxsId;

            int bllRetCode = 4;
            if (!string.IsNullOrEmpty(info.DengJiId)) bllRetCode = new EyouSoft.BLL.FinStructure.BShouKuan().Update(info);
            else bllRetCode = new EyouSoft.BLL.FinStructure.BShouKuan().Insert(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -3) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：登记金额不能大于应收金额"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 删除
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string dengJiId = Utils.GetFormValue("txtShouKuanId");
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

                /*if (Privs_ShenPi)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_shenpi\">审批</a>";
                }*/

                s += "<a href=\"javascript:void(0)\" class=\"i_shenpi\">审批</a>";
            }
            else
            {
                s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">已审批</a>";
            }

            return s;
        }
        #endregion
    }
}
