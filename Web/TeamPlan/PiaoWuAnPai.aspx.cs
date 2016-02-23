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

namespace Web.TeamPlan
{
    /// <summary>
    /// 常规业务-机票安排
    /// </summary>
    public partial class PiaoWuAnPai : BackPage
    {
        #region attributes
        /// <summary>
        /// 控位编号
        /// </summary>
        protected string KongWeiId = string.Empty;
        /// <summary>
        /// 已安排操作列HTML
        /// </summary>
        protected string YiAnPaiOperatorHtml = string.Empty;

        /// <summary>
        /// 押金操作权限
        /// </summary>
        bool Privs_YaJin = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;
        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_Delete = false;
        /// <summary>
        /// 退票权限
        /// </summary>
        bool Privs_TuiPiao = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            KongWeiId = Utils.GetQueryStringValue("kongweiid");
            var info =new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(KongWeiId);
            if (info == null || info.KongWeiDaiLiList == null || info.KongWeiDaiLiList.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：错误的请求。"));

            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "anpaidelete": DeleteAnPai(); break;
                case "yajinsave": SaveYaJin(); break;
                case "toxls_youke": ToXls_YouKe_0(); break;
                default: break;
            }
            if (Utils.GetQueryStringValue("doType") == "yajinsave") SaveYaJin();

            YiAnPaiOperatorHtml = GetYiAnPaiOperatorHtml();
            InitYaJinRpts();
            InitYiAnPaiRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_YaJin = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_票务押金登记);
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_新增出票安排);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改出票安排);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_删除出票安排);
            Privs_TuiPiao = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_退票);
            
        }

        /// <summary>
        /// 初始化押金repeater
        /// </summary>
        void InitYaJinRpts()
        {
            var items = new EyouSoft.BLL.PlanStructure.BPlanChuPiao().GetYaJinList(KongWeiId);

            RptsYaJin.DataSource = items;
            RptsYaJin.DataBind();
        }

        /// <summary>
        /// 初始化已安排出票列表
        /// </summary>
        void InitYiAnPaiRpts()
        {
            var items = new EyouSoft.BLL.PlanStructure.BPlanChuPiao().GetPlanChuPiaoList(KongWeiId);

            if (items != null && items.Count > 0)
            {
                RptsYiAnPaiChuPiao.DataSource = items;
                RptsYiAnPaiChuPiao.DataBind();
                phEmpty.Visible = false;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// 保存押金信息
        /// </summary>
        void SaveYaJin()
        {
            if (!Privs_YaJin) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限"));

            if (new EyouSoft.BLL.TourStructure.BTour().GetKongWeiZhuangTai(KongWeiId) == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束)
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：控位已核算结束"));
            }

            var info = new EyouSoft.Model.PlanStructure.MYaJinDengJi();

            info.DaiLiId = Utils.GetFormValue("txtXiangMuId");
            info.TuiTime = Utils.GetDateTimeNullable(Utils.GetFormValue("txtTuiYaJinTime"));
            info.TuiYaJinAmount = Utils.GetDecimal(Utils.GetFormValue("txtTuiYaJinJinE"));
            info.TuiYaJinBeiZhu = Utils.GetFormValue("txtTuiYaJinBaiZhu");
            info.TuiYaJinOperatorId = SiteUserInfo.UserId;
            info.YaJinAmount = Utils.GetDecimal(Utils.GetFormValue("txtYaJinJinE"));
            info.YaJinBeiZhu = Utils.GetFormValue("txtYaJinBeiZhu");
            info.YaJinOperatorId = SiteUserInfo.UserId;

            var bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanChuPiao().YajinDengji(info);

            if (bllRetCode == -3) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：押金金额不能小于已登记的付款金额"));
            else if (bllRetCode == -2) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：退回金额不能小于已登记的收款金额"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取已安排出票列表操作列HTML
        /// </summary>
        /// <returns></returns>
        string GetYiAnPaiOperatorHtml()
        {
            StringBuilder s = new StringBuilder();

            if (Privs_Update) s.Append("<a href=\"javascript:void(0)\" class=\"i_yianpai_update\">修改</a>&nbsp;");
            else s.Append("<a href=\"javascript:void(0)\" class=\"i_yianpai_update\" i_chakan=\"1\">查看</a>&nbsp;");

            if (Privs_Delete) s.Append("<a href=\"javascript:void(0)\" class=\"i_yianpai_delete\">删除</a>&nbsp;");
            if (Privs_TuiPiao) s.Append("<a href=\"javascript:void(0)\" class=\"i_yianpai_tuipiao\">退票</a>&nbsp;");

            s.Append("<br/><a href=\"javascript:void(0)\" class=\"i_yianpai_biangeng\">变更历史</a>&nbsp;");
            s.Append("<a href=\"javascript:void(0)\" class=\"i_yianpai_download\">附件下载</a>&nbsp;");

            return s.ToString();
        }

        /// <summary>
        /// 删除出票安排信息
        /// </summary>
        void DeleteAnPai()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限"));

            string _anPaiId = Utils.GetFormValue("txtAnPaiId");

            int bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanChuPiao().DeletePlanChuPiao(_anPaiId);

            if (bllRetCode == -2) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已存在付款登记的出票安排，不可删除"));
            else if (bllRetCode == -80) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已存在付款登记的出票安排，不可删除"));
            else if (bllRetCode == -4) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已存在退票的出票信息，不可删除"));
            else if (bllRetCode == -19) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：控位已核算结束，不可删除"));
            else RCWE(UtilsCommons.AjaxReturnJson("-2", "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 导出已安排出票游客信息
        /// </summary>
        void ToXls_YouKe_0()
        {
            if (!UtilsCommons.IsToXls()) ResponseToXls(string.Empty);
            StringBuilder s = new StringBuilder();

            var items = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderList(KongWeiId, OrderStatus.已成交);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("订单号：{0} 客户单位：{1} 人数：{2}+{3}+{4} 占位数：{5}\n", item.OrderCode, item.BuyCompanyName, item.Adults, item.Childs, item.Bears, item.Accounts);
                    s.Append(ToXls_YouKe_1(item.TourOrderTravellerList));
                }
            }

            ResponseToXls(s.ToString());
        }

        /// <summary>
        /// 导出已安排出票游客信息(游客)
        /// </summary>
        string ToXls_YouKe_1(IList<MTourOrderTraveller> items)
        {
            StringBuilder s = new StringBuilder();

            if (items != null && items.Count > 0)
            {
                var i = 1;
                foreach (var item in items)
                {                    
                    if (item.TicketType != TicketType.已出票) continue;

                    s.Append(i + "\t");
                    s.Append(item.TravellerName+"\t");
                    s.Append(item.TravellerType + "\t");
                    s.Append(item.CardType + "\t");
                    s.Append("'" + item.CardNumber + "\t");
                    s.Append(item.Sex + "\t");
                    s.Append(item.Contact + "\t");
                    s.Append("\n");

                    i++;
                }
            }

            s.Append("\n");
            return s.ToString();
        }
        #endregion
    }
}
