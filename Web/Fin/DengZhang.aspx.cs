using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 出纳登账信息
    /// </summary>
    public partial class DengZhang : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        private const int PageSize = 10;
        private int _pageIndex = 1;
        private int _recordCount;
        private bool _isEdit;
        private bool _isDel;
        private bool _isShenPi;
        private bool _isXiaoZhang;
        /// <summary>
        /// 冲抵权限
        /// </summary>
        bool Privs_ChongDi = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (UtilsCommons.IsToXls()) ToXls();

            if (!IsPostBack)
            {
                string doType = Utils.GetQueryStringValue("doType");
                string dzid = Utils.GetQueryStringValue("dzid");

                if (!string.IsNullOrEmpty(doType) && doType.ToLower() == "del" && !string.IsNullOrEmpty(dzid))
                {
                    DeleteDengZhang(dzid);
                    return;
                }

                InitDropDownList();
                InitPage();
            }
        }

        /// <summary>
        /// init privs
        /// </summary>
        private void InitPrivs()
        {
            Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_栏目);

            if (!Privs_LanMu)
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_登记);
            _isShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_审批);
            _isEdit = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_修改);
            _isDel = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_删除);
            _isXiaoZhang=CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_审批);
            Privs_ChongDi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_冲抵);

            plnShenPi.Visible=_isShenPi;
            plnAdd.Visible = Privs_Insert;
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitDropDownList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem("请选择", "-1"));
            ddlStatus.Items.Add(new ListItem("未审批", "0"));
            ddlStatus.Items.Add(new ListItem("已审批", "1"));

            ddlBank.Items.Clear();
            var list = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(CurrentUserCompanyID, CurrentZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.收付款账户);
            if (list != null && list.Any())
            {
                foreach (var t in list)
                {
                    if (t == null) continue;

                    if (t.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用)
                    {
                        ddlBank.Items.Add(
                            new ListItem(string.Format("{0}-{1}-{2}", t.BankName, t.AccountName, t.BankNo), t.Id));
                    }
                }
            }
            ddlBank.Items.Insert(0, new ListItem("请选择", "0"));
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage()
        {
            var search = this.GetSearchInfo();
            decimal zongDaoKuanJinE = 0;
            decimal zongXiaoZhangJinE = 0;
            _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            var list = new EyouSoft.BLL.FinStructure.BDengZhang().GetChuNaDengZhang(
                CurrentUserCompanyID,
                PageSize,
                _pageIndex,
                ref _recordCount,
                search,
                ref zongDaoKuanJinE,
                ref zongXiaoZhangJinE);

            UtilsCommons.Paging(PageSize, ref _pageIndex, _recordCount);
            rptDengZhang.DataSource = list;
            rptDengZhang.DataBind();

            ltrZongDaoKuan.Text = this.ToMoneyString(zongDaoKuanJinE);
            ltrZongXiaoZhang.Text = this.ToMoneyString(zongXiaoZhangJinE);
            ltrWeiXiaoZhangHeJi.Text = this.ToMoneyString(zongDaoKuanJinE - zongXiaoZhangJinE);

            page1.intPageSize = PageSize;
            page1.intRecordCount = _recordCount;
            page1.CurrencyPage = _pageIndex;

            if (search != null)
            {
                if (ddlBank.Items.FindByValue(search.BankId) != null) ddlBank.Items.FindByValue(search.BankId).Selected = true;
                if (search.StartTime.HasValue) txtStartDate.Value = search.StartTime.Value.ToShortDateString();
                if (search.EndTime.HasValue) txtEndDate.Value = search.EndTime.Value.ToShortDateString();
                if (search.Status.HasValue && ddlStatus.Items.FindByValue(Convert.ToInt32(search.Status.Value).ToString()) != null)
                    ddlStatus.Items.FindByValue(Convert.ToInt32(search.Status.Value).ToString()).Selected = true;
            }
        }

        /// <summary>
        /// 获取查询实体
        /// </summary>
        /// <returns></returns>
        private EyouSoft.Model.FinStructure.MSearchChuNaDengZhang GetSearchInfo()
        {
            string bid = Utils.GetQueryStringValue("bid");
            DateTime? sd = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("sd"));
            DateTime? ed = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("ed"));
            int sid = Utils.GetInt(Utils.GetQueryStringValue("sid"), -1);
            var search = new EyouSoft.Model.FinStructure.MSearchChuNaDengZhang { BankId = bid, EndTime = ed, StartTime = sd };
            if (sid == 0 || sid == 1)
            {
                search.Status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)sid;
            }
            else
            {
                search.Status = null;
            }

            search.DaoZhangJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtDaoZhangJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            search.DaoZhangJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtDaoZhangJinE"));

            search.WeiXiaoZhangJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtWeiXiaoZhangJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            search.WeiXiaoZhangJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtWeiXiaoZhangJinE"));
            search.ZxsId = CurrentZxsId;

            search.XiaoZhangShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaoZhangShiJian1"));
            search.XiaoZhangShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaoZhangShiJian2"));
            search.XiaoZhangJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtXiaoZhangJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            search.XiaoZhangJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtXiaoZhangJinE"));

            search.DuiFangDanWeiLeiXing = Utils.GetQueryStringValue("txtDuiFangDanWeiLeiXing");

            if (search.DuiFangDanWeiLeiXing != "0" && search.DuiFangDanWeiLeiXing != "1")
            {
                search.DuiFangDanWeiLeiXing = "";
            }

            search.DuiFangDanWeiId = Utils.GetQueryStringValue("txtDuiFangDanWeiId");

            if (search.DuiFangDanWeiLeiXing == "0")
            {
                txtKeHu.KeHuId = search.DuiFangDanWeiId;
                txtKeHu.KeHuMingCheng = Utils.GetQueryStringValue("txtDuiFangDanWeiName");
            }
            else if (search.DuiFangDanWeiLeiXing == "1")
            {
                txtGys.HideID = search.DuiFangDanWeiId;
                txtGys.Name = Utils.GetQueryStringValue("txtDuiFangDanWeiName");
            }

            return search;
        }

        /// <summary>
        /// 删除登账信息
        /// </summary>
        /// <param name="dzId">登账编号</param>
        private void DeleteDengZhang(string dzId)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(dzId))
            {
                str = UtilsCommons.AjaxReturnJson("0", "参数丢失，请刷新页面后重试！");
                this.RCWE(str);
                return;
            }
            var ids = dzId.Split(',');
            if (!ids.Any())
            {
                str = UtilsCommons.AjaxReturnJson("0", "参数丢失，请刷新页面后重试！");
                this.RCWE(str);
                return;
            }
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_删除))
            {
                str = UtilsCommons.AjaxReturnJson("0", "您没有删除权限，请联系管理员！");
                this.RCWE(str);
                return;
            }

            int r = new EyouSoft.BLL.FinStructure.BDengZhang().DeleteDengZhang(ids);
            switch (r)
            {
                case 0:
                    str = UtilsCommons.AjaxReturnJson("0", "参数错误，请刷新页面后重试！");
                    this.RCWE(str);
                    return;
                case 1:
                    str = UtilsCommons.AjaxReturnJson("1", "删除成功，稍后自动刷新页面！");
                    this.RCWE(str);
                    return;
                case -1:
                    str = UtilsCommons.AjaxReturnJson("0", "删除失败，服务器错误！");
                    this.RCWE(str);
                    return;
                case -2:
                    str = UtilsCommons.AjaxReturnJson("0", "要删除的登账信息已经被审批，不能删除！");
                    this.RCWE(str);
                    return;
                case -3:
                    str = UtilsCommons.AjaxReturnJson("0", "要删除的登账信息中，已经被审批的没有删除，其他删除成功！");
                    this.RCWE(str);
                    return;
                default:
                    str = UtilsCommons.AjaxReturnJson("0", "删除失败，服务器错误！");
                    this.RCWE(str);
                    return;
            }
        }

        /// <summary>
        /// 获取操作列html
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        protected string GetHandleColumn(object status)
        {
            if (status == null) return string.Empty;

            var s = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)status;

            var r = new System.Text.StringBuilder();
            switch (s)
            {
                case EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批:
                    if (_isEdit)
                    {
                        r.AppendFormat("&nbsp;<a href=\"javascript:void(0);\" class=\"editDengZhang\">修改</a>");
                    }
                    if (_isDel)
                    {
                        r.AppendFormat("&nbsp;<a href=\"javascript:void(0);\" class=\"delDengZhang\">删除</a>");
                    }
                    /*if (_isShenPi)
                    {
                        r.AppendFormat("&nbsp;&nbsp;<a href=\"javascript:void(0);\" class=\"shenPiDengZhang\">审批</a>");
                    }*/
                    break;
                default:
                    if (_isXiaoZhang)
                    {
                        r.AppendFormat("&nbsp;<a href=\"javascript:void(0);\" class=\"showDengZhang\">查看</a>");
                        r.AppendFormat("&nbsp;<a href=\"javascript:void(0);\" class=\"xiaoZhangDengZhang\"><font class=\"fblue\">销账</font></a>");
                    }
                    if (Privs_ChongDi)
                    {
                        r.AppendFormat("&nbsp;<a href=\"javascript:void(0);\" class=\"i_a_chongdi\"><font class=\"fblue\">冲抵</font></a>");
                    }
                    break;
            }

            return r.ToString();
        }

        /// <summary>
        /// 导出excel
        /// </summary>
        private void ToXls()
        {
            var s = new StringBuilder();
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            _recordCount = 0;

            if (toXlsRecordCount < 1)
            {
                ResponseToXls(string.Empty);
                return;
            }
            var search = GetSearchInfo();

            decimal zongDaoKuanJinE = 0;
            decimal zongXiaoZhangJinE = 0;
            var list = new EyouSoft.BLL.FinStructure.BDengZhang().GetChuNaDengZhang(
                CurrentUserCompanyID,
                toXlsRecordCount,
                1,
                ref _recordCount,
                search,
                ref zongDaoKuanJinE,
                ref zongXiaoZhangJinE);

            if (list == null || !list.Any())
            {
                ResponseToXls(string.Empty);
                return;
            }

            s.Append("到款时间\t到款金额 \t已销账金额\t未销账金额\t到款银行\t状态\t备注\n");
            foreach (var t in list)
            {
                s.AppendFormat("{0}\t", t.DaoKuanTime.ToString("yyyy-MM-dd"));
                s.AppendFormat("{0}\t", t.DaoKuanJinE.ToString("F2"));
                s.AppendFormat("{0}\t", t.UnCheckMoney.ToString("F2"));
                s.AppendFormat("{0}\t", (t.DaoKuanJinE - t.UnCheckMoney).ToString("F2"));
                s.AppendFormat("{0}\t", t.DaoKuanBankName);
                s.AppendFormat(
                    "{0}\t",
                    t.Status == EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批 ? t.Status.ToString() : "已审核");
                s.AppendFormat("{0}\n", t.Remark);
            }

            /*s.Append("合计:\t");
            s.AppendFormat("{0}\t", zongDaoKuanJinE.ToString("F2"));
            s.AppendFormat("{0}\t", zongXiaoZhangJinE.ToString("F2"));
            s.AppendFormat("{0}\t", (zongDaoKuanJinE - zongXiaoZhangJinE).ToString("F2"));
            s.Append("\t");
            s.Append("\t");
            s.Append("\n");*/

            ResponseToXls(s.ToString());
        }
    }
}
