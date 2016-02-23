//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.PersonalCenterStructure;
using EyouSoft.Model.EnumType.PersonalCenterStructure;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-请假审批、作废
    /// </summary>
    public partial class QingJiaShenPiBoxy : BackPage
    {
        #region attributes
        /// <summary>
        /// 请假编号
        /// </summary>
        int QingJiaId = 0;
        /// <summary>
        /// 审批权限
        /// </summary>
        bool Privs_ShenPi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            QingJiaId = Utils.GetInt(Utils.GetQueryStringValue("qingjiaid"));
            if (QingJiaId < 1) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));
            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "shenpi": ShenPi(); break;
                case "zuofei": ZuoFei(); break;
                default: break;
            }

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_请假管理_管理);
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave().GetMdl(QingJiaId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));

            switch (info.State)
            {
                case LeaveState.未审批:
                    phZuoFei.Visible = false;
                    txtShenPiRenName.Value = SiteUserInfo.Name;
                    txtShenPiTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    if (Privs_ShenPi) ltrOperatorHtml.Text = "<div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_shenpi_1\" class=\"i_shenpi\" i_status=\"1\">同意</a></div><div style=\"width:80px; float:left; text-align:center;\"><a href=\"javascript:void(0)\" id=\"i_shenpi_0\" class=\"i_shenpi\" i_status=\"0\">不同意</a></div>";
                    else ltrOperatorHtml.Text = "你没有请假管理权限";
                    break;
                case LeaveState.未通过:
                    phZuoFei.Visible = false;
                    txtShenPiBeiZhu.Disabled = true;
                    InitShenPiInfo(info);
                    ltrOperatorHtml.Text = "请假申请未批准";
                    break;
                case LeaveState.已同意:
                    InitShenPiInfo(info);
                    txtShenPiBeiZhu.Disabled = true;
                    txtZuoFeiRenName.Value = SiteUserInfo.Name;
                    txtZuoFeiTime.Value  = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    if (Privs_ShenPi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_zuofei\">作废</a>";
                    else ltrOperatorHtml.Text = "你没有请假管理权限";
                    break;
                case LeaveState.作废:
                    txtShenPiBeiZhu.Disabled = txtZuoFeiBeiZhu.Disabled = true;
                    InitShenPiInfo(info);
                    InitZuoFeiInfo(info);
                    ltrOperatorHtml.Text = "请假已作废";
                    break;
                default: break;
            }
        }
       
        /// <summary>
        /// 初始化审批信息
        /// </summary>
        /// <param name="info">请假实体</param>
        void InitShenPiInfo(UserLeave info)
        {
            txtShenPiBeiZhu.Value = info.CheckRemark;
            txtShenPiRenName.Value = info.ShenPiRenName;
            if (info.CheckTime.HasValue) txtShenPiTime.Value =info.CheckTime.Value.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// 初始化作废信息
        /// </summary>
        /// <param name="info">请假实体</param>
        void InitZuoFeiInfo(UserLeave info)
        {
            txtZuoFeiRenName.Value = info.ZuoFeiRenName;
            txtZuoFeiBeiZhu.Value = info.ZuoFeiBeiZhu;
            if (info.ZuoFeiTime.HasValue) txtZuoFeiTime.Value = info.ZuoFeiTime.Value.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// 审批
        /// </summary>
        void ShenPi()
        {
            if (!Privs_ShenPi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.OperatorId = SiteUserInfo.UserId;
            bool isTongYi = Utils.GetFormValue("txtStatus") == "1";

            int bllRetCode = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave().ShenPi(QingJiaId, CurrentUserCompanyID, isTongYi, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));            
        }

        /// <summary>
        /// 作废
        /// </summary>
        void ZuoFei()
        {
            if (!Privs_ShenPi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new EyouSoft.Model.FinStructure.MOperatorInfo();
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.OperatorId = SiteUserInfo.UserId;

            int bllRetCode = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave().ZuoFei(QingJiaId, CurrentUserCompanyID, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }        
        #endregion
    }
}
