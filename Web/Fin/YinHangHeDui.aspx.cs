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
    /// 财务管理-银行核对表
    /// </summary>
    public partial class YinHangHeDui : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_Delete = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        protected bool Privs_Insert = false;
        /// <summary>
        /// 确认权限
        /// </summary>
        bool Privs_QueRen = false;
        /// <summary>
        /// 修改权限 
        /// </summary>
        bool Privs_Update = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "delete": Delete(); break;
                case "queren": QueRen(); break;
                default: break; 
            }

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行核对表_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行核对表_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行核对表_登记);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行核对表_删除);
            Privs_QueRen = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行核对表_确认);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行核对表_修改);

            phInsert.Visible = Privs_Insert;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var items = new EyouSoft.BLL.FinStructure.BYinHangHeDui().GetHeDuis(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

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
        EyouSoft.Model.FinStructure.MYinHangHeDuiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MYinHangHeDuiChaXunInfo();

            info.EYeWuRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEYeWuRiQi"));
            info.SYeWuRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSYeWuRiQi"));
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 删除银行核对信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string heDuiId = Utils.GetFormValue("heduiid");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BYinHangHeDui().Delete(heDuiId, CurrentUserCompanyID);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 确认银行核对信息
        /// </summary>
        void QueRen()
        {
            if (!Privs_QueRen) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            EyouSoft.Model.FinStructure.MOperatorInfo info = new EyouSoft.Model.FinStructure.MOperatorInfo();
            info.OperatorId = SiteUserInfo.UserId;

            string heDuiId = Utils.GetFormValue("heduiid");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BYinHangHeDui().QueRen(heDuiId, info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
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
            YinHangHeDuiStatus _status = (YinHangHeDuiStatus)status;

            switch (_status)
            {
                case YinHangHeDuiStatus.未确认: s = "<a href=\"javascript:void(0)\" class=\"i_queren\">未确认</a>"; break;
                case YinHangHeDuiStatus.已确认: s = "<span style=\"color:#333\">已确认</span>"; break;
                default: break;
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        protected string GetOperatorHtml(object status)
        {
            string s = string.Empty;
            YinHangHeDuiStatus _status = (YinHangHeDuiStatus)status;

            if (_status == YinHangHeDuiStatus.未确认)
            {
                if (Privs_Update) s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
                else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";

                if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a> ";
            }
            else
            {
                s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";
            }

            return s.ToString();
        }
        #endregion
    }
}
