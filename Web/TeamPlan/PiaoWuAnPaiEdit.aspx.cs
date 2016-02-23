//汪奇志 2012-12-06
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
using Web.UserControl;
using EyouSoft.Model.PlanStructure;

namespace Web.TeamPlan
{
    /// <summary>
    /// 常规业务-票务安排出票新增、修改
    /// </summary>
    public partial class PiaoWuAnPaiEdit : BackPage
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
        /// 新增权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            KongWeiId = Utils.GetQueryStringValue("kongweiid");
            AnPaiId = Utils.GetQueryStringValue("anpaiid");

            if (string.IsNullOrEmpty(KongWeiId)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));

            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "save") Save();
            if (Utils.GetQueryStringValue("chakan") == "1") ltrOperatorHtml.Visible = false;

            InitWuc();
            InitKongWeiInfo();
            InitAnPaiInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_新增出票安排);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改出票安排);

            if (Utils.GetQueryStringValue("chakan") == "1")
            {
                UploadFuJian.IsChaKan = true;
                return;
            }

            if (string.IsNullOrEmpty(AnPaiId))
            {
                if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有出票安排权限";
            }
            else
            {
                if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有出票修改权限";
            }

            if (new EyouSoft.BLL.TourStructure.BTour().GetKongWeiZhuangTai(KongWeiId) == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束)
            {
                ltrOperatorHtml.Text = "控位已核算结束";
            }
        }

        /// <summary>
        /// int web user control
        /// </summary>
        void InitWuc()
        {
            UploadFuJian.CompanyID = CurrentUserCompanyID;
            UploadFuJian.IsUploadSelf = true;
        }

        /// <summary>
        /// 初始化出票安排信息
        /// </summary>
        void InitAnPaiInfo()
        {
            if (string.IsNullOrEmpty(AnPaiId))
            {
                RegisterScript("var anPaiYouKes=[];var anPaiDaiLiId='';");
                return;
            }

            var info = new EyouSoft.BLL.PlanStructure.BPlanChuPiao().GetPlanChuPiaoById(AnPaiId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));

            txtChuPiaoShuLiang.Value = info.ShuLiang.ToString();
            txtChuPiaoShuLiang.Attributes.Add("i_yuanchupiaoshuliang", info.ShuLiang.ToString());
            txtJieSuanMx.Value = info.JieSuanMX;
            txtJieSuanJinE.Value = info.JieSuanAmount.ToString("F2");
            txtBeiZhu.Value = info.Remark;

            MFileInfo file = new MFileInfo();
            file.FilePath = info.FilePath;
            var items = new List<MFileInfo>();
            items.Add(file);
            UploadFuJian.YuanFiles = items;

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(info.TravellerList);
            RegisterScript(string.Format("var anPaiYouKes={0};var anPaiDaiLiId='{1}';", s, info.DaiLiId));
        }

        /// <summary>
        /// 初始化控位信息
        /// </summary>
        void InitKongWeiInfo()
        {
            //var info = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(KongWeiId);
            //if (info == null || info.KongWeiDaiLiList == null || info.KongWeiDaiLiList.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));

            var items = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiDaiLiById(KongWeiId);
            if (items == null || items.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));
            if (items != null && items.Count > 0)
            {
                daiLiRpts.DataSource = items;
                daiLiRpts.DataBind();
            }

        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (string.IsNullOrEmpty(AnPaiId) && !Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            if (!string.IsNullOrEmpty(AnPaiId) && !Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.PlanId = AnPaiId;
            info.PageUri = EyouSoft.Toolkit.Utils.GetRequestUrlReferrer();

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(AnPaiId)) bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanChuPiao().AddPlanChuPiao(info);
            else bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanChuPiao().UpdatePlanChuPiao(info);

            if (bllRetCode == -3) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：出票数量大于剩余数量"));
            else if (bllRetCode == -2) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：游客选择错误"));
            else if (bllRetCode == -80) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：出票金额不能小于付款已登记金额"));
            else if (bllRetCode == -81) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：存在付款登记的出票安排不允许修改代理商信息"));
            else if (bllRetCode == -19) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：控位已核算结束"));
            else RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PlanStructure.MPlanChuPiao GetFormInfo()
        {
            var info = new EyouSoft.Model.PlanStructure.MPlanChuPiao();
            info.CompanyId = CurrentUserCompanyID;
            info.DaiLiId = Utils.GetFormValue("txtDaiLiId");
            info.GysId = Utils.GetFormValue("txtGysId");
            info.JieSuanAmount = Utils.GetDecimal(Utils.GetFormValue("txtJieSuanJinE"));
            info.JieSuanMX = Utils.GetFormValue("txtJieSuanMx");
            info.KongWeiId = KongWeiId;
            info.OperatorId = SiteUserInfo.UserId;
            info.PlanId = string.Empty;
            info.Remark = Utils.GetFormValue("txtBeiZhu");
            info.ShuLiang = Utils.GetInt(Utils.GetFormValue("txtChuPiaoShuLiang"));
            info.TravellerList = new List<MPlanYouKe>();

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

            string file = Utils.GetFormValue("txtFilePath");
            if (!string.IsNullOrEmpty(file))
            {
                string[] _arr = file.Split('|');
                if (_arr.Length == 2) info.FilePath = _arr[1];
            }
            if (string.IsNullOrEmpty(info.FilePath)) info.FilePath = Utils.GetFormValue("txtYFilePath");

            info.ZxsId = CurrentZxsId;

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
                s.Append("<tr class=\"odd\">");
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
                s.AppendFormat("<td style=\"height:30px;width:10%;text-align:left;\">&nbsp;&nbsp;<input type=\"checkbox\" name=\"chkYouKe\" id=\"chkYouKe_{0}\" i_chupiaostatus={1} />&nbsp;{2}&nbsp;</td>", item.TravellerId, (int)item.TicketType, i);
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
