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
    /// 添加修改出纳登账信息
    /// </summary>
    public partial class DengZhangEdit : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
            string doType = Utils.GetQueryStringValue("doType");
            string dzid = Utils.GetQueryStringValue("dzid");
            string save = Utils.GetQueryStringValue("save");
            if (save == "1")
            {
                SaveData(doType.ToLower(), dzid);
                return;
            }

            if (!IsPostBack)
            {
                InitDropDownList();

                if (!CheckPrive(doType, dzid))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="doType"></param>
        /// <param name="dzid"></param>
        private bool CheckPrive(string doType, string dzid)
        {
            switch (doType.ToLower())
            {
                case "add":
                    //判断权限
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_登记))
                    {
                        Utils.ShowMsgAndCloseBoxy(
                            string.Format(
                                "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_登记),
                            Utils.GetQueryStringValue("iframeId"),
                            true);
                        return false;
                    }
                    InitBak(string.Empty);
                    InitPage(string.Empty);
                    break;
                case "edit":
                    //判断权限
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_修改))
                    {
                        Utils.ShowMsgAndCloseBoxy(
                            string.Format(
                                "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_修改),
                            Utils.GetQueryStringValue("iframeId"),
                            true);
                        return false;
                    }
                    if (string.IsNullOrEmpty(dzid))
                    {
                        Utils.ShowMsgAndCloseBoxy(
                            "参数丢失，请再次进行操作！",
                            Utils.GetQueryStringValue("iframeId"),
                            true);
                        return false;
                    }
                    InitPage(dzid);
                    break;
                case "show":
                    //判断权限
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_栏目))
                    {
                        Utils.ShowMsgAndCloseBoxy(
                            string.Format(
                                "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_栏目),
                            Utils.GetQueryStringValue("iframeId"),
                            true);
                        return false;
                    }
                    if (string.IsNullOrEmpty(dzid))
                    {
                        Utils.ShowMsgAndCloseBoxy(
                            "参数丢失，请再次进行操作！",
                            Utils.GetQueryStringValue("iframeId"),
                            true);
                        return false;
                    }
                    InitPage(dzid);
                    plnSave.Visible = false;
                    break;
                default:
                    //判断权限
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_登记))
                    {
                        Utils.ShowMsgAndCloseBoxy(
                            string.Format(
                                "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_登记),
                            Utils.GetQueryStringValue("iframeId"),
                            true);
                        return false;
                    }
                    InitBak(string.Empty);
                    break;
            }

            return true;
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitDropDownList()
        {
            ddlPayType.DataSource = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi));
            ddlPayType.DataTextField = "Text";
            ddlPayType.DataValueField = "Value";
            ddlPayType.DataBind();
            ddlPayType.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        /// <summary>
        /// 初始化银行账号
        /// </summary>
        /// <param name="bankId"></param>
        private void InitBak(string bankId)
        {
            ddlBank.Items.Clear();
            var list = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(CurrentUserCompanyID, CurrentZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.收付款账户);
            if (list != null && list.Any())
            {
                foreach (var t in list)
                {
                    if (t == null) continue;

                    if (t.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用 || t.Id == bankId)
                    {
                        ddlBank.Items.Add(
                            new ListItem(string.Format("{0}-{1}-{2}", t.BankName, t.AccountName, t.BankNo), t.Id));
                    }
                }
            }
            ddlBank.Items.Insert(0, new ListItem("请选择", "0"));
        }

        /// <summary>
        /// 初始化页面数据
        /// </summary>
        /// <param name="dzid">登账编号</param>
        private void InitPage(string dzid)
        {
            if (string.IsNullOrEmpty(dzid))
            {
                var zxsPeiZhiFino = new EyouSoft.BLL.CompanyStructure.CompanySetting().GetZxsPeiZhiInfo(CurrentUserCompanyID, CurrentZxsId);
                if (zxsPeiZhiFino != null && !string.IsNullOrEmpty(zxsPeiZhiFino.SFKZFFS))
                {
                    if (ddlPayType.Items.FindByValue(zxsPeiZhiFino.SFKZFFS) != null)
                    {
                        ddlPayType.Items.FindByValue(zxsPeiZhiFino.SFKZFFS).Selected = true;
                    }
                }

                if (zxsPeiZhiFino != null && !string.IsNullOrEmpty(zxsPeiZhiFino.SFKYHZH))
                {
                    if (ddlBank.Items.FindByValue(zxsPeiZhiFino.SFKYHZH) != null)
                    {
                        ddlBank.Items.FindByValue(zxsPeiZhiFino.SFKYHZH).Selected = true;
                    }
                }

                return;
            }

            var model = new EyouSoft.BLL.FinStructure.BDengZhang().GetChuNaDengZhang(dzid);

            if (model == null) return;

            txtDaoKuanDate.Value = model.DaoKuanTime.ToShortDateString();
            txtDaoKuanJinE.Value = model.DaoKuanJinE > 0 ? model.DaoKuanJinE.ToString("F2") : string.Empty;
            InitBak(model.DaoKuanBankId);
            if (ddlBank.Items.FindByValue(model.DaoKuanBankId) != null)
                ddlBank.Items.FindByValue(model.DaoKuanBankId).Selected = true;
            if (ddlPayType.Items.FindByValue(((int)model.FuKuanFangShi).ToString()) != null)
                ddlPayType.Items.FindByValue(((int)model.FuKuanFangShi).ToString()).Selected = true;
            txtRemark.Value = model.Remark;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="dotype">操作类型</param>
        /// <param name="dzid">登账编号 </param>
        private void SaveData(string dotype, string dzid)
        {
            if (string.IsNullOrEmpty(dotype))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数错误！"));
                return;
            }
            if (dotype == "edit" && string.IsNullOrEmpty(dzid))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数错误！"));
                return;
            }
            switch (dotype)
            {
                case "edit":
                    //判断权限
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_修改))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_修改)));
                        return;
                    }
                    break;
                default:
                    //判断权限
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_登记))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_登记)));
                        return;
                    }
                    break;
            }

            int r = 0;
            var bll = new EyouSoft.BLL.FinStructure.BDengZhang();
            var model = this.GetFormValues();
            if (dotype == "add")
            {
                r = bll.AddDengZhang(model);
            }
            else if (dotype == "edit")
            {
                model.DengZhangId = dzid;
                r = bll.UpdateDengZhang(model);
            }

            switch (r)
            {
                case 1:
                    this.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功！"));
                    break;
                case 0:
                    this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数错误！"));
                    break;
                case -1:
                    this.RCWE(UtilsCommons.AjaxReturnJson("0", "服务器错误！"));
                    break;
                case -2:
                    this.RCWE(UtilsCommons.AjaxReturnJson("0", "登账信息已经审批，不能修改！"));
                    break;
                default:
                    this.RCWE(UtilsCommons.AjaxReturnJson("0", "服务器错误！"));
                    break;
            }
        }

        /// <summary>
        /// 获取表单值
        /// </summary>
        /// <returns></returns>
        private EyouSoft.Model.FinStructure.MChuNaDengZhang GetFormValues()
        {
            var model = new EyouSoft.Model.FinStructure.MChuNaDengZhang
                {
                    CompanyId = CurrentUserCompanyID,
                    DaoKuanBankId = Utils.GetFormValue(ddlBank.UniqueID),
                    DaoKuanJinE = Utils.GetDecimal(Utils.GetFormValue(txtDaoKuanJinE.UniqueID)),
                    DaoKuanTime = Utils.GetDateTime(Utils.GetFormValue(txtDaoKuanDate.UniqueID)),
                    FuKuanFangShi =
                        Utils.GetEnumValue(
                            Utils.GetFormValue(ddlPayType.UniqueID),
                            EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi.银行电汇),
                    OperatorId = SiteUserInfo.UserId,
                    OperatorName = SiteUserInfo.Name,
                    Remark = Utils.GetFormValue(txtRemark.UniqueID)
                };
            model.ZxsId = CurrentZxsId;

            return model;
        }
    }
}
