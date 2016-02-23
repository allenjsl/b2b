//汪奇志 2013-01-29
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
    /// <summary>
    /// 财务管理-出纳登账-已销账信息
    /// </summary>
    public partial class DengZhangYiXiaoZhang : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 出纳登账编号
        /// </summary>
        string DengZhangId = string.Empty;
        /// <summary>
        /// 取消销账权限
        /// </summary>
        bool Privs_QuXiaoXiaoZhang = false;
        /// <summary>
        /// 取消冲抵权限
        /// </summary>
        bool Privs_QuXiaoChongDi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DengZhangId = Utils.GetQueryStringValue("dengzhangid");
            InitPrivs();
            if (string.IsNullOrEmpty(DengZhangId)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));

            string doType = Utils.GetQueryStringValue("doType");

            switch (doType)
            {
                case "quxiaoxiaozhang": QuXiaoXiaoZhang(); break;
                case "quxiaochongdi": QuXiaoChongDi(); break;
                default: break;
            }

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_QuXiaoXiaoZhang = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_取消销账);
            Privs_QuXiaoChongDi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_取消冲抵);

            phQuXiaoXiaoZhang.Visible = Privs_QuXiaoXiaoZhang;
            phQuXiaoChongDi.Visible = Privs_QuXiaoChongDi;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            object[] heJi;
            int recordCount = 0;
            var items = new EyouSoft.BLL.FinStructure.BDengZhang().GetYiXiaoZhangs(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrXiaoZhangJinEHeJi.Text = ToMoneyString(heJi[0]);

                rpts.Visible = phHeJi.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                rpts.Visible = phHeJi.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        MYiXiaoZhangChaXunInfo GetChaXunInfo()
        {
            var info = new MYiXiaoZhangChaXunInfo();
            info.DengZhangId = DengZhangId;

            return info;
        }

        /// <summary>
        /// 取消销账
        /// </summary>
        void QuXiaoXiaoZhang()
        {
            if (!Privs_QuXiaoXiaoZhang) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string[] xiaoZhangId = Utils.GetFormValues("txtXiaoZhangId[]");
            if (xiaoZhangId == null || xiaoZhangId.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请选择要取消销账的信息。"));

            var info = new MOperatorInfo();
            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = string.Empty;

            int bllRetCode = new EyouSoft.BLL.FinStructure.BDengZhang().QuXiaoXiaoZhang(CurrentUserCompanyID, DengZhangId, xiaoZhangId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消冲抵
        /// </summary>
        void QuXiaoChongDi()
        {
            if (!Privs_QuXiaoChongDi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string[] xiaoZhangId = Utils.GetFormValues("txtXiaoZhangId[]");
            if (xiaoZhangId == null || xiaoZhangId.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：请选择要取消冲抵的信息。"));

            var info = new MOperatorInfo();
            info.OperatorId = SiteUserInfo.UserId;
            info.BeiZhu = string.Empty;

            int bllRetCode = new EyouSoft.BLL.FinStructure.BDengZhang().QuXiaoChongDi(CurrentUserCompanyID, DengZhangId, xiaoZhangId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion

        #region protected members
        /// <summary>
        /// get routename
        /// </summary>
        /// <returns></returns>
        protected string GetRouteName(object routeName,object yeWuLeiXing,object leiXing)
        {
            XiaoZhangLeiXing _leiXing = (XiaoZhangLeiXing)leiXing;
            string _routeName=routeName.ToString();

            if (_leiXing == XiaoZhangLeiXing.冲抵)
            {
                return "冲抵备注：" + _routeName;
            }

            if (string.IsNullOrEmpty(_routeName))
            {
                return yeWuLeiXing.ToString();
            }

            return _routeName;
        }

        /// <summary>
        /// get xiaozhang leixing1
        /// </summary>
        /// <param name="leiXing"></param>
        /// <param name="leiXing1"></param>
        /// <returns></returns>
        protected string GetXiaoZhangLeiXing1(object leiXing, object leiXing1)
        {
            var _leiXing = (EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing)leiXing;
            var _leiXing1 = (EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing1)leiXing1;

            if (_leiXing == XiaoZhangLeiXing.冲抵) return "冲抵";

            return _leiXing1.ToString();
        }
        #endregion
    }
}
