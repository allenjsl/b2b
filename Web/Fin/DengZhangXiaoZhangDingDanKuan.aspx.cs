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
    /// 出纳登帐销账-订单款
    /// </summary>
    public partial class DengZhangXiaoZhangDingDanKuan : EyouSoft.Common.Page.BackPage
    {
        private const int PageSize = 10;

        private int _pageIndex = 1;

        private int _recordCount;

        /// <summary>
        /// 可以销账的金额
        /// </summary>
        protected decimal KeYiXiaoZhangJinE = 0;

        protected string DengZhangId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;

            string dzId = Utils.GetQueryStringValue("dzid");
            string save = Utils.GetQueryStringValue("save");

            DengZhangId = dzId;

            if (save == "1")
            {
                SaveData(dzId);
                return;
            }

            if (!IsPostBack)
            {
                if (!CheckPrive(dzId))
                {
                    return;
                }

                InitPage(dzId);
            }
        }

        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="dzId"></param>
        private bool CheckPrive(string dzId)
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_销账))
            {
                Utils.ShowMsgAndCloseBoxy(
                    string.Format(
                        "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_销账),
                    Utils.GetQueryStringValue("iframeId"),
                    true);
                return false;
            }

            if (string.IsNullOrEmpty(dzId))
            {
                Utils.ShowMsgAndCloseBoxy(
                    "参数丢失，请再次进行操作！",
                    Utils.GetQueryStringValue("iframeId"),
                    true);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 初始化页面数据
        /// </summary>
        /// <param name="dzId">登账编号</param>
        private void InitPage(string dzId)
        {
            string cid = Utils.GetQueryStringValue("cid");
            string cname = Utils.GetQueryStringValue("cname");
            _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            var chaXun = new EyouSoft.Model.FinStructure.MXiaoZhangChaXunInfo();
            chaXun.DingDanKuan_KeHuId = cid;
            chaXun.QuDate2=Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLEDate"));
            chaXun.QuDate1=Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLSDate"));
            chaXun.ZxsId=CurrentZxsId;

            var list = new EyouSoft.BLL.FinStructure.BDengZhang().GetXiaoZhangDingDanKuans(
                CurrentUserCompanyID,
                PageSize,
                _pageIndex,
                ref _recordCount,
                chaXun);

            UtilsCommons.Paging(PageSize, ref _pageIndex, _recordCount);
            rptOrder.DataSource = list;
            rptOrder.DataBind();

            page1.CurrencyPage = _pageIndex;
            page1.intPageSize = PageSize;
            page1.intRecordCount = _recordCount;

            var model = new EyouSoft.BLL.FinStructure.BDengZhang().GetChuNaDengZhang(dzId);
            if (model != null)
            {
                KeYiXiaoZhangJinE = model.DaoKuanJinE - model.UnCheckMoney;
                ltrKeyi.Text = this.ToMoneyString(KeYiXiaoZhangJinE);
            }

            txtKeHu.KeHuId= cid;
            txtKeHu.KeHuMingCheng = cname;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dzId"></param>
        private void SaveData(string dzId)
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_销账))
            {
                this.RCWE(
                    UtilsCommons.AjaxReturnJson(
                        "0",
                        string.Format("您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_销账)));
                return;

            }
            if (string.IsNullOrEmpty(dzId))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数丢失，请再次进行操作！"));
                return;
            }

            /*int r = new EyouSoft.BLL.FinStructure.BDengZhang().UnCheckDengZhang(dzId, this.GetFormValues());

            switch (r)
            {
                case 0:
                    this.RCWE(UtilsCommons.AjaxReturnJson("0", "销账失败，参数验证没通过！"));
                    break;
                case 1:
                    this.RCWE(UtilsCommons.AjaxReturnJson("1", "销账成功！"));
                    break;
                case -1:
                    this.RCWE(UtilsCommons.AjaxReturnJson("-1", "要销账的所有的金额合计大于出纳登帐信息能销账的金额(到款金额减去已销账金额)！"));
                    break;
                case -2:
                    this.RCWE(UtilsCommons.AjaxReturnJson("-2", "登账信息没有审批，不能销账！"));
                    break;
                case -3:
                    this.RCWE(UtilsCommons.AjaxReturnJson("-3", "销账失败，服务器错误！"));
                    break;
                default:
                    this.RCWE(UtilsCommons.AjaxReturnJson("0", "销账失败，参数验证没通过！"));
                    break;
            }*/

            var items = GetFormValues();
            int bllRetCode = new EyouSoft.BLL.FinStructure.BDengZhang().XiaoZhang(dzId, SiteUserInfo.UserId, EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing1.销订单款, items);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "销账成功！"));
            else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：要销账的登账信息不存在或未审批"));
            else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：要销账的所有的金额合计大于出纳登帐信息能销账的金额(到款金额减去已销账金额)"));
            else if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：要销账的所有的金额合计大于出纳登帐信息能销账的金额(到款金额减去已销账金额)"));
            else if (bllRetCode == -96) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：没有有效的销账信息"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode.ToString()));
        }

        /// <summary>
        /// 获取表单值
        /// </summary>
        /// <returns></returns>
        private IList<EyouSoft.Model.FinStructure.MXiaoZhang> GetFormValues()
        {
            string[] orderId = Utils.GetFormValues("ckbOrder");
            string[] money = Utils.GetFormValues("txt_XiaoZhang_Money");

            if (orderId == null || money == null || orderId.Length <= 0 || orderId.Length != money.Length)
                return null;

            var list = new List<EyouSoft.Model.FinStructure.MXiaoZhang>();

            for (int i = 0; i < orderId.Length; i++)
            {
                if (string.IsNullOrEmpty(orderId[i]) || Utils.GetDecimal(money[i]) <= 0) continue;

                list.Add(
                    new EyouSoft.Model.FinStructure.MXiaoZhang
                        {
                            IssueTime = DateTime.Now,
                            OperatorId = SiteUserInfo.UserId,
                            OperatorName = SiteUserInfo.Name,
                            OrderId = Utils.InputText(orderId[i]),
                            XiaoZhangJinE = Utils.GetDecimal(money[i]),
                            LeiXing1 = EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing1.销订单款
                        });
            }

            return list;
        }
    }
}
