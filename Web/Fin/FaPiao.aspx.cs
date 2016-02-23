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
    /// 财务管理-发票管理
    /// </summary>
    public partial class FaPiao : BackPage
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
        bool Privs_Update = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "delete": Delete(); break;
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_发票管理_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_发票管理_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_发票管理_登记);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_发票管理_删除);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_发票管理_修改);

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
            decimal heJi;
            var items = new EyouSoft.BLL.FinStructure.BFaPiao().GetFaPiaos(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

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
        EyouSoft.Model.FinStructure.MFaPiaoChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MFaPiaoChaXunInfo();

            info.KeHuName = Utils.GetQueryStringValue("txtKeHuName");
            info.ZxsId = CurrentZxsId;

            info.QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate1"));
            info.QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate2"));
            info.DingDanHao = Utils.GetQueryStringValue("txtDingDanHao");
            info.FaPiaoHao = Utils.GetQueryStringValue("txtFaPiaoHao");

            return info;
        }

        /// <summary>
        /// 删除发票信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string fapiaoid = Utils.GetFormValue("fapiaoid");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BFaPiao().Delete(fapiaoid, CurrentUserCompanyID);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已经存在已发送状态的发票不允许删除"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
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

            if (Privs_Update) s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";

            if (Privs_Delete)
            {
                if (status != null && ((FaPiaoFaSongStatus)status) == FaPiaoFaSongStatus.未送出)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a> ";
                }
            }


            return s.ToString();
        }

        /// <summary>
        /// 获取发票明细信息HTML
        /// </summary>
        /// <param name="obj">发票明细信息集合</param>
        /// <returns></returns>
        protected string GetChuTuanRiQiHtml(object obj)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();

            s.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'>");
            s.Append("<tr class='pp-table-title'><th>出团日期</th><th>发票金额</th><th>发票信息</th><th>送出状态</th><th >发票送出时间</th><th>发票送出方式</th><th>邮寄公司名称</th><th>邮寄单号</th><th>签收人</th><th>签收时间</th></tr>");
            IList<MFaPiaoMXInfo> items = (IList<MFaPiaoMXInfo>)obj;

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.Append("<tr>");
                    s.AppendFormat("<td style=\"text-align:left;\">单号：{0}<br/>日期：{1}</td>", item.DingDanHao,ToDateTimeString(item.ChuTuanRiQi));
                    s.AppendFormat("<td>{0}</td>", ToMoneyString(item.JinE));
                    s.AppendFormat("<td style=\"text-align:left;\">抬头：{0}<br/>开票：{1}</td>", item.TaiTou, item.KaiPiaoDanWei);
                    s.AppendFormat("<td>{0}</td>", item.Status);
                    s.AppendFormat("<td>{0}</td>", ToDateTimeString(item.FaSongTime));
                    s.AppendFormat("<td>{0}</td>", item.FaSongFangShi);
                    s.AppendFormat("<td>{0}</td>", item.YouJiGongSiName);
                    s.AppendFormat("<td>{0}</td>", item.YouJiDanHao);
                    s.AppendFormat("<td>{0}</td>", item.QianShouRenName);
                    s.AppendFormat("<td>{0}</td>", ToDateTimeString(item.QianShouTime));
                    s.Append("</tr>");
                }
            }
            else
            {
                s.Append("<tr><td colspan='12'>无发票明细信息</td></tr>");
            }

            s.Append("</table>");

            return s.ToString();
        }
        #endregion
    }
}
