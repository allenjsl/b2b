using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.TongJi
{
    /// <summary>
    /// 统计分析-积分收付款明细表
    /// </summary>
    public partial class JiFenShouFuKuanMingXi : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        bool Privs_ShenHe = false;
        bool Privs_QuXiaoShenHe = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "shenpi": ShenPi(); break;
                case "quxiaoshenpi": QuXiaoShenPi(); break;
            }

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_积分收付款明细表_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_ShenHe = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_积分收付款明细表_审核);
            Privs_QuXiaoShenHe = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_积分收付款明细表_取消审核);
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiChaXunInfo();

            info.DengJiRiQi1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtDengJiRiQi1"));
            info.DengJiRiQi2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtDengJiRiQi2"));
            info.Status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus), Utils.GetQueryStringValue("txtStatus"));

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            pageIndex = UtilsCommons.GetPagingIndex();

            var chaXun = GetChaXunInfo();
            int recordCount = 0;
            object[] heJi;
            var items = new EyouSoft.BLL.TongJiStructure.BJiFen().GetJiFenShouFuKuanMingXis(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                ltrJieFangJinEHeJi.Text = ((decimal)heJi[0]).ToString("F2");
                ltrDaiFangJinEHeJi.Text = ((decimal)heJi[1]).ToString("F2");

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
                phHeJi.Visible = false;
            }
        }

        /// <summary>
        /// 审批
        /// </summary>
        void ShenPi()
        {
            if (!Privs_ShenHe) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string txtMxId = Utils.GetFormValue("txtMxId");
            var txtLeiXing = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing>(Utils.GetFormValue("txtLeiXing"), EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.结算积分);
            string txtZxsId = Utils.GetFormValue("txtZxsId");

            int bllRetCode = 0;

            if (txtLeiXing == EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.结算积分)
            {
                var operatorInfo = new EyouSoft.Model.FinStructure.MOperatorInfo();
                operatorInfo.BeiZhu = string.Empty;
                operatorInfo.OperatorId = SiteUserInfo.UserId;

                bllRetCode = new EyouSoft.BLL.TongJiStructure.BJiFen().SheZhiJiFenJieSuanShouKuanStatus(CurrentUserCompanyID, txtZxsId, txtMxId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未支付, operatorInfo);

                if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
                else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
            }

            if (txtLeiXing == EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.兑换商品)
            {
                var operatorInfo = new EyouSoft.Model.FinStructure.MOperatorInfo();
                operatorInfo.BeiZhu = string.Empty;
                operatorInfo.OperatorId = SiteUserInfo.UserId;
                bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanFuKuanStatus(txtMxId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未支付, operatorInfo);
                if (bllRetCode == 1)
                {
                    bllRetCode=new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanFuKuanStatus(txtMxId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.已支付, operatorInfo);
                }

                if (bllRetCode != 1) new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanFuKuanStatus(txtMxId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批, operatorInfo);

                if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
                else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
            }

            RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消审批
        /// </summary>
        void QuXiaoShenPi()
        {
            if (!Privs_QuXiaoShenHe) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string txtMxId = Utils.GetFormValue("txtMxId");
            var txtLeiXing = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing>(Utils.GetFormValue("txtLeiXing"), EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.结算积分);
            string txtZxsId = Utils.GetFormValue("txtZxsId");

            int bllRetCode = 0;

            if (txtLeiXing == EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.结算积分)
            {
                var operatorInfo = new EyouSoft.Model.FinStructure.MOperatorInfo();
                operatorInfo.BeiZhu = string.Empty;
                operatorInfo.OperatorId = SiteUserInfo.UserId;

                bllRetCode = new EyouSoft.BLL.TongJiStructure.BJiFen().SheZhiJiFenJieSuanShouKuanStatus(CurrentUserCompanyID, txtZxsId, txtMxId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批, operatorInfo);

                if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
                else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
            }

            if (txtLeiXing == EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.兑换商品)
            {
                var operatorInfo = new EyouSoft.Model.FinStructure.MOperatorInfo();
                operatorInfo.BeiZhu = string.Empty;
                operatorInfo.OperatorId = SiteUserInfo.UserId;
                bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanFuKuanStatus(txtMxId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未支付, operatorInfo);
                if (bllRetCode == 1)
                {
                    bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanFuKuanStatus(txtMxId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批, operatorInfo);
                }

                if (bllRetCode != 1) new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanFuKuanStatus(txtMxId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.已支付, operatorInfo);

                if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
                else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
            }

            RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion

        #region protected members
        /// <summary>
        /// get routename
        /// </summary>
        /// <param name="routeName"></param>
        /// <param name="yeWuLeiXing"></param>
        /// <returns></returns>
        protected string GetRouteName(object routeName, object yeWuLeiXing)
        {
            if (routeName == null && yeWuLeiXing == null) return string.Empty;

            if (routeName == null) return yeWuLeiXing.ToString();

            string _routeName = routeName.ToString();

            if (!string.IsNullOrEmpty(_routeName)) return _routeName;

            return yeWuLeiXing.ToString();
        }

        /// <summary>
        /// 获取借方金额
        /// </summary>
        /// <param name="jinE"></param>
        /// <returns></returns>
        protected string GetJieFangJInE(object jinE,object leiXing)
        {
            var _leiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing)leiXing;

            if (_leiXing == EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.结算积分)
            {

                if (jinE == null) return "0.00";

                decimal _jinE = Utils.GetDecimal(jinE.ToString());

                if (_jinE == 0) return "0.00";

                return ToMoneyString(_jinE);
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取贷方金额
        /// </summary>
        /// <param name="jinE"></param>
        /// <returns></returns>
        protected string GetDaiFangJInE(object jinE, object leiXing)
        {
            var _leiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing)leiXing;

            if (_leiXing == EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.兑换商品)
            {

                if (jinE == null) return "0.00";

                decimal _jinE = Utils.GetDecimal(jinE.ToString());

                if (_jinE == 0) return "0.00";

                return ToMoneyString(_jinE);
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml(object status)
        {
            string s = string.Empty;
            var _status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)status;

            if (_status == EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批)
            {
                if (Privs_ShenHe) s += "<a href=\"javascript:void(0)\" class=\"i_shenpi\">审批</a> ";
            }
            else
            {
                if (Privs_ShenHe) s += "<a href=\"javascript:void(0)\" class=\"i_quxiaoshenpi\">取消审批</a> ";
            }

            return s.ToString();
        }

        /// <summary>
        /// get status
        /// </summary>
        /// <param name="status"></param>
        /// <param name="leiXing"></param>
        /// <returns></returns>
        protected string GetStatus(object status, object leiXing)
        {
            var _status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)status;
            var _leiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing)leiXing;

            if (_status == EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批) return "未审批";

            return "已审批";
        }
        #endregion
    }
}