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
    /// 控位操作备注
    /// </summary>
    public partial class KongWeiBeiZhu : EyouSoft.Common.Page.BackPage
    {
        string KongWeiId = string.Empty;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            KongWeiId = Utils.GetQueryStringValue("kongweiid");

            InitPrivs();

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "save": Save(); break;
                case "shixiao": ShiXiao(); break;
                default: break;
            }
            
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改);
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var items = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiBeiZhus(KongWeiId, null);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();
            }
        }

        /// <summary>
        /// save
        /// </summary>
        void Save()
        {
            if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = new EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo();
            info.BeiZhuId = string.Empty;
            info.IssueTime = DateTime.Now;
            info.KongWeiId = KongWeiId;
            info.LatestOperatorId = SiteUserInfo.UserId;
            info.LatestTime = DateTime.Now;
            info.NeiRong = Utils.GetFormValue("txtNeiRong");
            info.OperatorId = SiteUserInfo.UserId;
            info.Status = 0;

            int bllRetCode = new EyouSoft.BLL.TourStructure.BTour().InsertKongWeiBeiZhu(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// shixiao
        /// </summary>
        void ShiXiao()
        {
            if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string txtBeiZhuId = Utils.GetFormValue("txtBeiZhuId");
            int bllRetCode = new EyouSoft.BLL.TourStructure.BTour().KongWeiBeiZhuShiXiao(KongWeiId, txtBeiZhuId, SiteUserInfo.UserId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="status"></param>
        /// <param name="latestOperatorName"></param>
        /// <param name="latestTime"></param>
        /// <returns></returns>
        protected string GetStatus(object status, object latestOperatorName, object latestTime)
        {
            int _status = (int)status;
            if (_status == 0) return "<b>有效</b>";

            DateTime _latestTime = (DateTime)latestTime;

            return string.Format("失效[{0} {1}]", latestOperatorName.ToString(), _latestTime.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// get caozuo
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetCaoZuo(object status)
        {
            int _status = (int)status;
            if (_status == 1) return string.Empty;

            return "<a href=\"javascript:void(0)\" class=\"shixiao\">设为失效</a>";
        }
        #endregion
    }
}
