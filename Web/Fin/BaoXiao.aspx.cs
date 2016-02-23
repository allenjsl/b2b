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
using EyouSoft.Model.FinStructure;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-报销登记表
    /// </summary>
    public partial class BaoXiao : BackPage
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_报销登记表_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_报销登记表_栏目, true);
                }
            }

            Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_报销登记表_报销登记);

            phInsert.Visible = Privs_Insert;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            decimal heJi;
            int recordCount = 0;
            var items = new EyouSoft.BLL.FinStructure.BBaoXiao().GetBaoXiaos(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrBaoXiaoJinEHeJi.Text = ToMoneyString(heJi);

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
        EyouSoft.Model.FinStructure.MBaoXiaoChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MBaoXiaoChaXunInfo();

            info.BaoXiaoRenName = Utils.GetQueryStringValue("txtBaoXiaoRenName");
            info.ERiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEDate"));            
            info.SRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSDate"));
            info.XiaoFeiType = (BaoXiaoXiaoFeiType?)Utils.GetEnumValueNull(typeof(BaoXiaoXiaoFeiType), Utils.GetQueryStringValue("txtBaoXiaoType"));
            info.BaoXiaoJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtBaoXiaoJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.BaoXiaoJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtBaoXiaoJinE"));
            info.BaoXiaoStatus = (BaoXiaoStatus?)Utils.GetEnumValueNull(typeof(BaoXiaoStatus), Utils.GetQueryStringValue("txtBaoXiaoStatus"));
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 删除报销信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string baoxiaoid = Utils.GetFormValue("baoxiaoid");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BBaoXiao().Delete(baoxiaoid, CurrentUserCompanyID);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取报销类型下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetBaoXiaoTypeOptionHtml()
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = EnumObj.GetList(typeof(ShouFuKuanFangShi));

            s.Append("<option value=\"\">请选择</option>");

            if (items == null || items.Count == 0) return s.ToString();

            foreach (var item in items)
            {
                s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Value, item.Text);
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        protected string GetStatus(object status)
        {
            string s = string.Empty;
            BaoXiaoStatus _status = (BaoXiaoStatus)status;

            switch (_status)
            {
                case BaoXiaoStatus.未审批: s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">未审批</a>"; break;
                case BaoXiaoStatus.未通过: s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">未通过</a>"; break;
                case BaoXiaoStatus.未支付: s = "<a href=\"javascript:void(0)\" class=\"i_zhifu\">未支付</a>"; break;
                case BaoXiaoStatus.已支付: s = "<a href=\"javascript:void(0)\" class=\"i_zhifu\">已支付</a>"; break;
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
            BaoXiaoStatus _status = (BaoXiaoStatus)status;

            if (_status == BaoXiaoStatus.未审批)
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

        /// <summary>
        /// 获取消费明细html
        /// </summary>
        /// <param name="obj">消费明细集合</param>
        /// <returns></returns>
        protected string GetXiaoFeiMxHtml(object obj)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'>");
            s.Append("<tr class='pp-table-title'><th>消费时间</th><th>消费金额</th><th>消费类型</th><th>消费备注</th></tr>");

            IList<MBaoXiaoXiaoFeiInfo> items = (IList<MBaoXiaoXiaoFeiInfo>)obj;

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", ToDateTimeString(item.XiaoFeiRiQi)
                        , ToMoneyString(item.JinE)
                        , item.XiaoFeiType
                        , item.XiaoFeiBeiZhu);
                }
            }
            else
            {
                s.Append("<tr><td colspan='4'>无消费明细信息</td></tr>");
            }

            s.Append("</table>");

            return s.ToString();
        }
        #endregion
    }
}
