using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.TeamPlan
{
    /// <summary>
    /// 代订酒店编辑
    /// </summary>
    public partial class ScheduleHotelAdd : EyouSoft.Common.Page.BackPage
    {
        /// <summary>
        /// 对方操作人编号
        /// </summary>
        protected string DuiFangCaoZuoRenId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;

            string doType = Utils.GetQueryStringValue("dotype");
            string save = Utils.GetQueryStringValue("save");
            string sid = Utils.GetQueryStringValue("id");

            CustomerRequired1.KongweiId = sid;

            if (save == "1")
            {
                SaveData(doType.ToLower(), sid);
                return;
            }

            if (!IsPostBack)
            {
                switch (doType.ToLower())
                {
                    case "add":
                        this.Title = "新增代订酒店";
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_新增))
                        {
                            Utils.ShowMsgAndCloseBoxy(
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_新增),
                                Utils.GetQueryStringValue("iframeId"),
                                true);
                            return;
                        }
                        break;
                    case "edit":
                        this.Title = "修改代订酒店";
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_修改))
                        {
                            Utils.ShowMsgAndCloseBoxy(
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_修改),
                                Utils.GetQueryStringValue("iframeId"),
                                true);
                            return;
                        }
                        if (string.IsNullOrEmpty(sid))
                        {
                            Utils.ShowMsgAndCloseBoxy(
                                "参数丢失，请再次进行操作！",
                                Utils.GetQueryStringValue("iframeId"),
                                true);
                            return;
                        }
                        InitPage(sid);
                        break;
                    case "show":
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_栏目))
                        {
                            Utils.ShowMsgAndCloseBoxy(
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_栏目),
                                Utils.GetQueryStringValue("iframeId"),
                                true);
                            return;
                        }
                        if (string.IsNullOrEmpty(sid))
                        {
                            Utils.ShowMsgAndCloseBoxy(
                                "参数丢失，请再次进行操作！",
                                Utils.GetQueryStringValue("iframeId"),
                                true);
                            return;
                        }
                        InitPage(sid);
                        plnSave.Visible = false;
                        break;
                    default:
                        this.Title = "新增代订酒店";
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_新增))
                        {
                            Utils.ShowMsgAndCloseBoxy(
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_新增),
                                Utils.GetQueryStringValue("iframeId"),
                                true);
                            return;
                        }
                        break;
                }
            }
        }

        #region 初始化方法

        /// <summary>
        /// 初始化代订酒店信息
        /// </summary>
        /// <param name="sId">代订酒店编号</param>
        private void InitPage(string sId)
        {
            if (string.IsNullOrEmpty(sId)) return;

            var model = new EyouSoft.BLL.TourStructure.BTourOrderHotel().GetTourOrderHotel(sId);

            if (model == null) return;

            if (model.QuDate.HasValue) txtLeaveDate.Text = model.QuDate.Value.ToShortDateString();
            txtAdultCount.Text = model.Adults.ToString();
            txtChildCount.Text = model.Childs > 0 ? model.Childs.ToString() : string.Empty;
            txtKeHu.KeHuId = model.BuyCompanyId;
            var keHuInfo = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(model.BuyCompanyId);
            if (keHuInfo != null) txtKeHu.KeHuMingCheng = keHuInfo.Name;
            DuiFangCaoZuoRenId = model.BuyOperatorId.ToString();
            txtPriceDesc.Text = model.PriceDetials;
            txtTotalMoney.Text = model.SumPrice.ToString("F2");
            txtPriceRemark.Text = model.PriceRemark;
            txtYaoqiuRemark.Text = model.SpecialAskRemark;
            txtOperatorRemark.Text = model.OperatoRemark;
            OrderCustomer1.CustomerList = model.TourOrderTravellerList;
            CustomerRequired1.SetPlanList = model.TourOrderHotelPlanList;

            hidOrderId.Value = model.OrderId;
           
            if (new EyouSoft.BLL.TourStructure.BTour().GetKongWeiZhuangTai(sId) == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束)
            {
                plnSave.Visible = false;
                ltrOperatorHtml.Text = "已核算结束";
            }
        }

        #endregion

        #region

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="dotype">操作类型</param>
        /// <param name="sid">代订酒店编号 </param>
        private void SaveData(string dotype, string sid)
        {
            if (string.IsNullOrEmpty(dotype))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数错误！"));
                return;
            }
            if (dotype == "edit" && string.IsNullOrEmpty(sid))
            {
                this.RCWE(UtilsCommons.AjaxReturnJson("0", "参数错误！"));
                return;
            }

            switch (dotype)
            {
                case "edit":
                    //判断权限
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_修改))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_修改)));
                        return;
                    }
                    break;
                default:
                    //判断权限
                    if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_新增))
                    {
                        this.RCWE(
                            UtilsCommons.AjaxReturnJson(
                                "0",
                                string.Format(
                                    "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_新增)));
                        return;
                    }
                    break;
            }

            int r = 0;
            var bll = new EyouSoft.BLL.TourStructure.BTourOrderHotel();
            var model = this.GetFormValues();

            if (model.TourOrderHotelPlanList == null || model.TourOrderHotelPlanList.Count == 0)
            {
                RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：至少要填写一个供应商安排信息！"));
            }

            if (dotype == "add")
            {
                r = bll.AddTourOrderHotel(model);
            }
            else if (dotype == "edit")
            {
                model.KongWeiId = sid;
                model.PageUri = EyouSoft.Toolkit.Utils.GetRequestUrlReferrer().Replace("dotype=edit", "dotype=show");
                r = bll.UpdateTourOrderHotel(model);
            }

            switch (r)
            {
                case 1:
                    this.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功！"));
                    break;
                case -19:
                    this.RCWE(UtilsCommons.AjaxReturnJson("-19", "操作失败：已核算结束！"));
                    break;
                default:
                    this.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败！"));
                    break;
            }
        }

        /// <summary>
        /// 获取表单值，返回实体
        /// </summary>
        /// <returns></returns>
        private EyouSoft.Model.TourStructure.MTourOrderHotel GetFormValues()
        {
            var model = new EyouSoft.Model.TourStructure.MTourOrderHotel
                {
                    Adults = Utils.GetInt(Utils.GetFormValue(this.txtAdultCount.UniqueID)),
                    BuyCompanyId = Utils.GetFormValue(this.txtKeHu.KeHuIdClientId),
                    BuyOperatorId = Utils.GetInt(Utils.GetFormValue("txtDuiFangCaoZuoRen")),
                    Childs = Utils.GetInt(Utils.GetFormValue(this.txtChildCount.UniqueID)),
                    CompanyId = this.CurrentUserCompanyID,
                    OperatoRemark = Utils.GetFormValue(this.txtOperatorRemark.UniqueID),
                    OperatorId = this.SiteUserInfo.UserId,
                    OrderId = Utils.GetFormValue(this.hidOrderId.UniqueID),
                    PriceDetials = Utils.GetFormValue(this.txtPriceDesc.UniqueID),
                    PriceRemark = Utils.GetFormValue(this.txtPriceRemark.UniqueID),
                    QuDate = Utils.GetDateTimeNullable(Utils.GetFormValue(this.txtLeaveDate.UniqueID)),
                    SpecialAskRemark = Utils.GetFormValue(this.txtYaoqiuRemark.UniqueID),
                    SumPrice = Utils.GetDecimal(Utils.GetFormValue(this.txtTotalMoney.UniqueID)),
                    TourOrderHotelPlanList = UtilsCommons.GetTourOrderHotelPlanList(),
                    TourOrderTravellerList = this.OrderCustomer1.GetCustomerList()
                };

            model.ZxsId = CurrentZxsId;
            model.LatestOperatorId = SiteUserInfo.UserId;
            model.IssueTime = model.LatestTime = DateTime.Now;

            return model;
        }

        #endregion
    }
}
