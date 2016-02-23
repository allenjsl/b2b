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
    /// 财务管理-借款登记表
    /// </summary>
    public partial class JieKuan : BackPage
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
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "delete") Delete();

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_栏目, true);
                }
            }

            Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_借款登记表_借款登记);

            phInsert.Visible = Privs_Insert;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            decimal[] heJi;
            int recordCount = 0;
            var items = new EyouSoft.BLL.FinStructure.BJieKuan().GetJieKuans(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrJieKuanJinEHeJi.Text = ToMoneyString(heJi[0]);
                ltrGuiHuanJinEHeJi.Text = ToMoneyString(heJi[1]);

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
        EyouSoft.Model.FinStructure.MJieKuanChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MJieKuanChaXunInfo();

            info.ERiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEDate"));
            info.JieKuanRenName = Utils.GetQueryStringValue("txtJieKuanRenName");
            info.SRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSDate"));
            info.JieKuanJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtJieKuanJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.JieKuanJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtJieKuanJinE"));
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 删除借款信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string jiekuanid = Utils.GetFormValue("jiekuanid");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BJieKuan().Delete(jiekuanid, CurrentUserCompanyID);

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
            JieKuanStatus _status = (JieKuanStatus)status;

            switch (_status)
            {
                case JieKuanStatus.未审批: s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">未审批</a>"; break;
                case JieKuanStatus.未通过: s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">未通过</a>"; break;
                case JieKuanStatus.未支付: s = "<a href=\"javascript:void(0)\" class=\"i_zhifu\">未支付</a>"; break;
                case JieKuanStatus.已归还: s = "<a href=\"javascript:void(0)\" class=\"i_guihuan\">已归还</a>"; break;
                case JieKuanStatus.已支付: s = "<a href=\"javascript:void(0)\" class=\"i_guihuan\">已支付</a>"; break;
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
            JieKuanStatus _status = (JieKuanStatus)status;

            if (_status == JieKuanStatus.未审批)
            {
                if (Privs_Insert) s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
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
