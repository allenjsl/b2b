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
    /// 财务管理-付款审批
    /// </summary>
    public partial class FuKuanShenPi : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_付款审批_栏目, true);
                }
            }
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
            var items = new EyouSoft.BLL.FinStructure.BFuKuan().GetShenPis(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                this.ltrJinEHeJi.Text = ToMoneyString(heJi);

                rpts.Visible = phHeJi.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;

                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
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
        EyouSoft.Model.FinStructure.MLBFuKuanShenPiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MLBFuKuanShenPiChaXunInfo();

            info.GysName = Utils.GetQueryStringValue("txtGysName");
            info.JiaoYiHao = Utils.GetQueryStringValue("txtJiaoYiHao");
            info.KuanXiangType = (KuanXiangType?)Utils.GetEnumValueNull(typeof(KuanXiangType), Utils.GetQueryStringValue("txtKuanXiangType"));
            info.FuKuanJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtFuKuanJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.FuKuanJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtFuKuanJinE"));
            info.ZxsId = CurrentZxsId;

            info.FuKuanStatus = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus), Utils.GetQueryStringValue("txtFuKuanStatus"));
            info.FuKuanShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtFuKuanShiJian1"));
            info.FuKuanShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtFuKuanShiJian2"));

            return info;
        }
        #endregion

        #region protected members        

        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        protected string GetOperatorHtml(object status)
        {
            string s = string.Empty;
            KuanXiangStatus _status = (KuanXiangStatus)status;

            if (_status == KuanXiangStatus.未审批)
            {
                s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">审批</a> ";
            }
            else if(_status== KuanXiangStatus.未支付)
            {
                s = "<a href=\"javascript:void(0)\" class=\"i_zhifu\">支付</a> ";
            }
            else if (_status == KuanXiangStatus.已支付)
            {
                s = "<a href=\"javascript:void(0)\" class=\"i_zhifu\" i_chakan=\"1\">查看</a> ";
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取报销类型下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetKuanXiangTypeOptionHtml()
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();

            s.Append("<option value=\"\">请选择</option>");

            s.AppendFormat("<option value=\"{0}\">{1}</option>", (int)KuanXiangType.地接支出付款,"地接安排");
            s.AppendFormat("<option value=\"{0}\">{1}</option>", (int)KuanXiangType.酒店安排付款, "酒店安排");
            s.AppendFormat("<option value=\"{0}\">{1}</option>", (int)KuanXiangType.票务安排付款, "票务安排");
            s.AppendFormat("<option value=\"{0}\">{1}</option>", (int)KuanXiangType.票务押金付款, "票务押金");
            s.AppendFormat("<option value=\"{0}\">{1}</option>", (int)KuanXiangType.其它支出付款, "其它支出");

            return s.ToString();
        }

        /// <summary>
        /// 获取款项类型字符串
        /// </summary>
        /// <param name="obj">款项类型</param>
        /// <returns></returns>
        protected string GetKuanXiangType(object obj)
        {
            KuanXiangType kuanXiangType = (KuanXiangType)obj;
            string s = string.Empty;
            switch (kuanXiangType)
            {
                case KuanXiangType.地接支出付款: s = "地接安排"; break;
                case KuanXiangType.酒店安排付款: s = "酒店安排"; break;
                case KuanXiangType.票务安排付款: s = "票务安排"; break;
                case KuanXiangType.票务押金付款: s = "票务押金"; break;
                case KuanXiangType.其它支出付款: s = "其它支出"; break;
            }
            return s;
        }
        #endregion
    }
}
