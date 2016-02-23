using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.PingTai
{
    /// <summary>
    /// 专线商管理
    /// </summary>
    public partial class ZhuanXianShang : EyouSoft.Common.Page.BackPage
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
        /// 修改权限
        /// </summary>
        protected bool Privs_Update = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "delete": Delete(); break;
                case "setstatus": SetStatus(); break;
                case "setjifenstatus": SetJiFenStatus(); break;
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_新增);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_删除);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_修改);

            phInsert.Visible = Privs_Insert;

            phPrivsMoban.Visible = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_专线商管理_权限模板管理);
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            int recordCount=0;
            pageIndex = UtilsCommons.GetPagingIndex();

            var items = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetZxss(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, null);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;

                phEmpty.Visible = false;
            }
            else
            {
                phPaging.Visible = false;
                phEmpty.Visible = true;
            }
            
        }

        /// <summary>
        /// 删除
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string zxsId = Utils.GetFormValue("zxsid");
            int bllRetCode = new EyouSoft.BLL.PtStructure.BZhuanXianShang().Delete(CurrentUserCompanyID, zxsId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// set status
        /// </summary>
        void SetStatus()
        {
            if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string txtZxsId = Utils.GetFormValue("txtZxsId");
            string txtStatus=Utils.GetFormValue("txtStatus");
            EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus status = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus>(txtStatus, EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus.启用);

            int bllRetCode = new EyouSoft.BLL.PtStructure.BZhuanXianShang().SheZhiStatus(CurrentUserCompanyID, txtZxsId, status);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// set jifenstatus
        /// </summary>
        void SetJiFenStatus()
        {
            if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string txtZxsId = Utils.GetFormValue("txtZxsId");
            string txtStatus = Utils.GetFormValue("txtStatus");
            EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus status = Utils.GetEnumValue<EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus>(txtStatus, EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.启用);

            int bllRetCode = new EyouSoft.BLL.PtStructure.BZhuanXianShang().SheZhiJiFenStatus(CurrentUserCompanyID, txtZxsId, status);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml(object t1,object status,object jiFenStatus)
        {
            string s = string.Empty;
            int _t1 = (int)t1;
            var _status = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus)status;
            var _jiFenStatus = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus)jiFenStatus;

            if (_t1 == 0)
            {
                if (Privs_Update)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
                    s += "<a href=\"javascript:void(0)\" class=\"i_privs\">授权</a> ";

                    if (_status == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus.启用)
                    {
                        s += "<a href=\"javascript:void(0)\" class=\"i_jinyong\" data-status=\"1\">禁用</a> ";
                    }
                    if (_status == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus.禁用)
                    {
                        s += "<a href=\"javascript:void(0)\" class=\"i_qiyong\" data-status=\"0\">启用</a> ";
                    }
                    if (_jiFenStatus == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.启用)
                    {
                        s += "<a href=\"javascript:void(0)\" class=\"i_jinyongjifen\" data-status=\"1\">禁止积分</a> ";
                    }
                    if (_jiFenStatus == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用)
                    {
                        s += "<a href=\"javascript:void(0)\" class=\"i_qiyongjifen\" data-status=\"0\">启用积分</a> ";
                    }
                }
                else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";

                if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a> ";
            }

            if (_t1 == 1)
            {
                if (Privs_Update)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";

                    if (_jiFenStatus == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.启用)
                    {
                        s += "<a href=\"javascript:void(0)\" class=\"i_jinyongjifen\" data-status=\"1\">禁止积分</a> ";
                    }
                    if (_jiFenStatus == EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用)
                    {
                        s += "<a href=\"javascript:void(0)\" class=\"i_qiyongjifen\" data-status=\"0\">启用积分</a> ";
                    }
                }
                else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";       
        
            }

            return s.ToString();
        }
        #endregion
    }
}
