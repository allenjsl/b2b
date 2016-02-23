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
    /// 出纳登帐销账-退回押金
    /// </summary>
    public partial class DengZhangXiaoZhangTuiHuiYaJin : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 销账权限
        /// </summary>
        bool Privs_XiaoZhang = false;
        /// <summary>
        /// 可以销账金额
        /// </summary>
        protected decimal KeYiXiaoZhangJinE = 0;
        /// <summary>
        /// 登账编号
        /// </summary>
        protected string DengZhangId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DengZhangId = Utils.GetQueryStringValue("dzid");

            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "xiaozhang") XiaoZhang();

            InitInfo();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_XiaoZhang = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_销账);
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.FinStructure.BDengZhang().GetChuNaDengZhang(DengZhangId);
            if (info == null) RCWE("异常请求");

            KeYiXiaoZhangJinE = info.DaoKuanJinE - info.UnCheckMoney;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.FinStructure.MXiaoZhangChaXunInfo GetChaXunInfo()
        {
            EyouSoft.Model.FinStructure.MXiaoZhangChaXunInfo info = new EyouSoft.Model.FinStructure.MXiaoZhangChaXunInfo();

            info.QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate1"));
            info.QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate2"));
            info.TuiYaJin_GysJiaoYiHao = Utils.GetQueryStringValue("txtGysJiaoYiHao");
            info.TuiYaJin_DaiLiShangName = Utils.GetQueryStringValue("txtDaiLiShangName");

            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            int pageSize = 10;
            int pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;

            var chaXun = GetChaXunInfo();

            var items = new EyouSoft.BLL.FinStructure.BDengZhang().GetXiaoZhangTuiHuiYaJins(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;

                phEmpty.Visible = false;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
            }
        }

        /// <summary>
        /// xiaozhang
        /// </summary>
        void XiaoZhang()
        {
            if (!Privs_XiaoZhang) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string[] txtDaiLiId = Utils.GetFormValues("txtDaiLiId[]");
            string[] txtXiaoZhangJinE = Utils.GetFormValues("txtXiaoZhangJinE[]");

            if (txtDaiLiId == null || txtDaiLiId.Length == 0 || txtXiaoZhangJinE == null || txtDaiLiId.Length != txtXiaoZhangJinE.Length)
                RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：表单异常。"));

            var items = new List<EyouSoft.Model.FinStructure.MXiaoZhang>();

            for (int i = 0; i < txtDaiLiId.Length; i++)
            {
                var item = new EyouSoft.Model.FinStructure.MXiaoZhang();
                item.OrderId = txtDaiLiId[i];
                item.XiaoZhangJinE = Utils.GetDecimal(txtXiaoZhangJinE[i]);

                if (string.IsNullOrEmpty(item.OrderId) || item.XiaoZhangJinE <= 0) continue;

                items.Add(item);
            }

            if (items == null || items.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：表单异常。"));

            int bllRetCode = new EyouSoft.BLL.FinStructure.BDengZhang().XiaoZhang(DengZhangId, SiteUserInfo.UserId, EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing1.销退回押金, items);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "销账成功！"));
            else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：要销账的登账信息不存在或未审批"));
            else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：要销账的所有的金额合计大于出纳登帐信息能销账的金额(到款金额减去已销账金额)"));
            else if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：要销账的所有的金额合计大于出纳登帐信息能销账的金额(到款金额减去已销账金额)"));
            else if (bllRetCode == -96) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：没有有效的销账信息"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode.ToString()));
        }
        #endregion
    }
}
