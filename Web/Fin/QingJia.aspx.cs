//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.EnumType.FinStructure;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-请假管理
    /// </summary>
    public partial class QingJia : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 审批权限
        /// </summary>
        protected bool Privs_ShenPi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_请假管理_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_请假管理_栏目, true);
                }
            }

            Privs_ShenPi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_请假管理_管理);
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var items = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave().GetLst(pageSize, pageIndex, ref recordCount, CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息

                rpts.Visible = phHeJi.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;
                
                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                rpts.Visible = phHeJi.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PersonalCenterStructure.MQingJiaChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PersonalCenterStructure.MQingJiaChaXunInfo();

            info.ETime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEDate"));
            info.QingJiaRenName = Utils.GetQueryStringValue("txtQingJiaRenName");
            info.STime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSDate"));
            info.ZxsId = CurrentZxsId;

            return info;
        }
        
        #endregion

        #region protected members
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        protected string GetStatus(object status)
        {
            string s = string.Empty;
            EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState _status = (EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState)status;

            switch (_status)
            {
                case EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState.未审批: s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">未审批</a>"; break;
                case EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState.未通过: s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">未通过</a>"; break;
                case EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState.已同意: s = "<a href=\"javascript:void(0)\" class=\"i_zuofei\">已同意</a>"; break;
                case EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState.作废: s = "<a href=\"javascript:void(0)\" class=\"i_zuofei\">已作废</a>"; break;
                default: break;
            }

            return s.ToString();
        }
        #endregion
    }
}
