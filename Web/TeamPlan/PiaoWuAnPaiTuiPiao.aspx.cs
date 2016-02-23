//汪奇志 2012-12-07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.EnumType.TourStructure;
using EyouSoft.Model.TourStructure;
using EyouSoft.Model.PlanStructure;

namespace Web.TeamPlan
{
    /// <summary>
    /// 常规业务-票务安排退票
    /// </summary>
    public partial class PiaoWuAnPaiTuiPiao : BackPage
    {
        #region attributes
        /// <summary>
        /// 控位编号
        /// </summary>
        protected string KongWeiId = string.Empty;
        /// <summary>
        /// 安排编号
        /// </summary>
        protected string AnPaiId = string.Empty;
        /// <summary>
        /// 退票编号
        /// </summary>
        protected string TuiPiaoId = string.Empty;

        /// <summary>
        /// 退票权限-新增
        /// </summary>
        bool Privs_TuiPiao = false;
        /// <summary>
        /// 退票权限-修改
        /// </summary>
        bool Privs_TuiPiaoXiuGai = false;
        /// <summary>
        /// 退票权限-删除
        /// </summary>
        bool Privs_TuiPiaoShanChu = false;
        /// <summary>
        /// 已退票列表操作列HTML
        /// </summary>
        protected string YiTuiPiaoRptCaoZuoHtml = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            KongWeiId = Utils.GetQueryStringValue("kongweiid");
            AnPaiId = Utils.GetQueryStringValue("anpaiid");
            TuiPiaoId = Utils.GetQueryStringValue("tuipiaoid");

            if (string.IsNullOrEmpty(KongWeiId) || string.IsNullOrEmpty(AnPaiId)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));

            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "save": Save(); break;
                case "delete": Delete(); break;
                default: break;
            }
            if (Utils.GetQueryStringValue("chakan") == "1") ltrOperatorHtml.Visible = false;

            InitYiTuiPiaoRpts();
            InitTuiPiaoInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_TuiPiao = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_退票);
            Privs_TuiPiaoXiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_退票修改);
            Privs_TuiPiaoShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_退票删除);

            if (Utils.GetQueryStringValue("chakan") == "1") return;

            if (string.IsNullOrEmpty(TuiPiaoId))
            {
                if (Privs_TuiPiao) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有退票操作权限";
            }
            else
            {
                if (Privs_TuiPiaoXiuGai) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有退票修改操作权限";
            }

            if (new EyouSoft.BLL.TourStructure.BTour().GetKongWeiZhuangTai(KongWeiId) == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束)
            {
                ltrOperatorHtml.Text = "控位已核算结束";
            }

            if (Privs_TuiPiaoXiuGai)
            {
                YiTuiPiaoRptCaoZuoHtml = "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a>";
            }
            else
            {
                YiTuiPiaoRptCaoZuoHtml = "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a>";
            }
            if (Privs_TuiPiaoShanChu)
            {
                YiTuiPiaoRptCaoZuoHtml += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a>";
            }

        }

        /// <summary>
        /// 初始化已退票repeater
        /// </summary>
        void InitYiTuiPiaoRpts()
        {
            var items = new EyouSoft.BLL.PlanStructure.BPlanTuiPiao().GetPlanTuiPiaoList(AnPaiId);

            if (items != null && items.Count > 0)
            {
                RptsYiTuiPiao.DataSource = items;
                RptsYiTuiPiao.DataBind();

                phEmpty.Visible = false;
            }
        }

        /// <summary>
        /// 初始化退票信息
        /// </summary>
        void InitTuiPiaoInfo()
        {
            var chuInfo = new EyouSoft.BLL.PlanStructure.BPlanChuPiao().GetPlanChuPiaoById(AnPaiId);
            if (chuInfo == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));

            string s1 = Newtonsoft.Json.JsonConvert.SerializeObject(chuInfo.TravellerList);
            RegisterScript(string.Format("var anPaiYouKes={0};", s1));

            if (string.IsNullOrEmpty(TuiPiaoId))
            {
                RegisterScript("var tuiYouKes=[];");
                ltrJingShouRen.Text = SiteUserInfo.Name;
                return;
            }

            var tuiInfo = new EyouSoft.BLL.PlanStructure.BPlanTuiPiao().GetPlanTuiPiaoById(TuiPiaoId);

            if (tuiInfo == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));

            if (tuiInfo.TuiTime.HasValue) txtTuiTime.Value = tuiInfo.TuiTime.Value.ToString("yyyy-MM-dd");
            txtSunShiMX.Value = tuiInfo.SunShiMX;
            txtSunShiJinE.Value = tuiInfo.SunShiAmount.ToString("F2");
            txtChengDanFang.Value = tuiInfo.ChengDanFang;
            ltrJingShouRen.Text = tuiInfo.OperatorName;
            txtYingTuiJinE.Value = tuiInfo.TuiAmount.ToString("F2");
            txtBeiZhu.Value = tuiInfo.Remark;


            string s2 = Newtonsoft.Json.JsonConvert.SerializeObject(tuiInfo.TravellerList);
            RegisterScript(string.Format("var tuiYouKes={0};", s2));
        }

        /// <summary>
        /// 新增、修改退票
        /// </summary>
        void Save()
        {
            if (string.IsNullOrEmpty(TuiPiaoId))
            {
                if (!Privs_TuiPiao) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_TuiPiaoXiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            var info = GetFormInfo();
            info.TuiId = TuiPiaoId;
            info.PageUri = EyouSoft.Toolkit.Utils.GetRequestUrlReferrer();
            info.CompanyId = this.SiteUserInfo.CompanyId;

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(TuiPiaoId)) bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanTuiPiao().AddPlanTuiPiao(info);
            else bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanTuiPiao().UpdatePlanTuiPiao(info);

            if (bllRetCode == -2) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：游客选择异常"));
            else if (bllRetCode == -80) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：应退金额不能小于收款已登记金额"));
            else if (bllRetCode == -19) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：控位已核算结束"));
            else RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 删除退票
        /// </summary>
        void Delete()
        {
            if (!Privs_TuiPiaoShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限"));

            string _tuiPiaoId = Utils.GetFormValue("txtTuiPiaoId");

            int bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanTuiPiao().DeletePlanTuiPiao(_tuiPiaoId);

            if (bllRetCode == -2) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已存在收款登记的退票信息，不可删除"));
            else if (bllRetCode == -80) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已存在收款登记的退票信息，不可删除"));
            else if (bllRetCode == -19) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：控位已核算结束，不可删除"));
            else RCWE(UtilsCommons.AjaxReturnJson("-2", "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取退票新增、修改表单信息
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PlanStructure.MPlanTuiPiao GetFormInfo()
        {
            var info = new EyouSoft.Model.PlanStructure.MPlanTuiPiao();

            info.ChengDanFang = Utils.GetFormValue("txtChengDanFang");
            info.KongWeiId = KongWeiId;
            info.OperatorId = SiteUserInfo.UserId;
            info.OrderId = string.Empty;
            info.PlanId = AnPaiId;
            info.Remark = Utils.GetFormValue("txtBeiZhu");
            info.ShuLiang = 0;
            info.SunShiAmount = Utils.GetDecimal(Utils.GetFormValue("txtSunShiJinE"));
            info.SunShiMX = Utils.GetFormValue("txtSunShiMX");
            info.TravellerList = new List<MPlanYouKe>();
            info.TuiAmount = Utils.GetDecimal(Utils.GetFormValue("txtYingTuiJinE"));
            info.TuiId = string.Empty;
            info.TuiTime = Utils.GetDateTime(Utils.GetFormValue("txtTuiTime"));

            string[] txtYouKeId = Utils.GetFormValues("txtYouKeId[]");
            string[] txtOrderId = Utils.GetFormValues("txtOrderId[]");

            if (txtYouKeId.Length == 0 || txtYouKeId.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常FORMVALUE ERROR"));
            if (txtYouKeId.Length != txtOrderId.Length) RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常FORMVALUE ERROR"));

            for (int i = 0; i < txtYouKeId.Length; i++)
            {
                var item = new MPlanYouKe();
                item.Id = AnPaiId;
                item.OrderId = txtOrderId[i];
                item.YouKeId = txtYouKeId[i];

                info.TravellerList.Add(item);
            }

            info.OrderId = info.TravellerList[0].OrderId;
            info.ShuLiang = info.TravellerList.Count;

            return info;
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取订单及游客信息HTML
        /// </summary>
        /// <returns></returns>
        protected string GetDingDanAndYouKeHtml()
        {
            StringBuilder s = new StringBuilder();

            var items = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderList(KongWeiId, OrderStatus.已成交);
            if (items == null || items.Count == 0)
            {
                s.Append("<tr><td colspan=\"4\" align=\"center\" style=\"height:30px\">暂无任何订单及游客信息</td></tr>");
                return s.ToString();
            }

            foreach (var item in items)
            {
                s.Append("<tr class=\"odd\">");
                s.Append("<td colspan=\"4\" align=\"right\">");

                s.Append("<table width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"1\" bgcolor=\"#ffffff\">");
                s.Append("<tr class=\"even\">");
                s.Append("<th height=\"22\" colspan=\"8\" align=\"left\" class=\"pandl4\">");
                s.AppendFormat("订单号：{0}", item.OrderCode);
                s.AppendFormat("&nbsp; 客户单位：{0}", item.BuyCompanyName);
                s.AppendFormat("&nbsp; 人数：{0}+{1}+{2}", item.Adults, item.Childs, item.Bears);
                s.AppendFormat("&nbsp; 占位数：{0}", item.Accounts);
                s.Append("</th>");
                s.Append("</tr>");
                s.Append(GetDingDanYouKeHtml(item.OrderId, item.TourOrderTravellerList));
                s.Append("</table>");

                s.Append("</td>");
                s.Append("</tr>");
            }


            return s.ToString();
        }

        /// <summary>
        /// 获取订单游客信息HTML
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="items">游客信息集合</param>        
        /// <returns></returns>
        string GetDingDanYouKeHtml(string orderId, IList<MTourOrderTraveller> items)
        {
            StringBuilder s = new StringBuilder();

            if (items == null || items.Count == 0)
            {
                s.Append("<tr class=\"odd\">");
                s.Append("<td height=\"30\" colspan=\"8\" align=\"left\" class=\"pandl4\">");
                s.Append("无游客信息");
                s.Append("</td>");
                s.Append("</tr>");

                return s.ToString();
            }

            int i = 1;
            foreach (var item in items)
            {
                s.AppendFormat("<tr class=\"even i_tr_youke\" i_orderid=\"{0}\" i_youkeid=\"{1}\" i_youkestatus=\"{2}\" i_youkechupiaostatus=\"{3}\">", orderId
                    , item.TravellerId
                    , (int)item.TravellerStatus
                    , (int)item.TicketType);
                s.AppendFormat("<td style=\"height:30px;width:10%;text-align:left;\">&nbsp;&nbsp;<input type=\"checkbox\" name=\"chkYouKe\" id=\"chkYouKe_{0}\" i_chupiaostatus={1} disabled=\"disabled\" />&nbsp;{2}&nbsp;</td>", item.TravellerId, (int)item.TicketType, i);
                s.AppendFormat("<td align=\"center\" style=\"width:15%\">&nbsp;{0}&nbsp;</td>", item.TravellerName);
                s.AppendFormat("<td align=\"center\" style=\"width:10%\">&nbsp;{0}&nbsp;</td>", item.TravellerType);
                s.AppendFormat("<td align=\"center\" style=\"width:10%\">&nbsp;{0}&nbsp;</td>", item.CardType);
                s.AppendFormat("<td align=\"center\" style=\"width:20%\">&nbsp;{0}&nbsp;</td>", item.CardNumber);
                s.AppendFormat("<td align=\"center\" style=\"width:10%\">&nbsp;{0}&nbsp;</td>", item.Sex);
                s.AppendFormat("<td align=\"center\" style=\"width:15%\">&nbsp;{0}&nbsp;</td>", item.Contact);
                s.AppendFormat("<td align=\"center\"style=\"width:10%\">&nbsp;{0}&nbsp;</td>", item.TicketType);

                s.Append("</tr>");

                i++;
            }

            return s.ToString();
        }
        #endregion
    }
}
