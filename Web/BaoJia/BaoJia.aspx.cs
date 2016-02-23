//最新报价管理 汪奇志 2014-10-21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.BaoJia
{
    /// <summary>
    /// 最新报价管理
    /// </summary>
    public partial class BaoJia : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_ShanChu = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "shanchu") ShanChu();

            InitRpt();
            InitZxlbs();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_最新报价_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_最新报价_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_最新报价_修改);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_最新报价_删除);

            phInsert.Visible = Privs_TianJia;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MBaoJiaChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MBaoJiaChaXunInfo();

            info.BiaoTi = Utils.GetQueryStringValue("txtBiaoTi");
            info.ZxlbId = Utils.GetIntNull(Utils.GetQueryStringValue("txtZxlb"));

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            pageIndex = UtilsCommons.GetPagingIndex();

            var chaXun = GetChaXunInfo();
            int recordCount = 0;
            var items = new EyouSoft.BLL.PtStructure.BBaoJia().GetBaoJias(CurrentUserCompanyID, CurrentZxsId, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
            }
        }

        /// <summary>
        /// shan chu
        /// </summary>
        void ShanChu()
        {
            if (!Privs_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string txtBaoJiaId = Utils.GetFormValue("txtBaoJiaId");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BBaoJia().BaoJia_D(CurrentUserCompanyID, CurrentZxsId, txtBaoJiaId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init zxlb
        /// </summary>
        void InitZxlbs()
        {
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZxsZhanDians(CurrentUserCompanyID, CurrentZxsId);

            if (items == null || items.Count == 0) return;

            StringBuilder s = new StringBuilder();

            foreach (var item in items)
            {
                s.AppendFormat("<optgroup label=\"{0}\">", item.MingCheng + "站");

                foreach (var item1 in item.Zxlbs)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item1.ZxlbId, item1.MingCheng);
                }

                s.AppendFormat("</optgroup>");
            }

            ltrZxlbOption.Text = s.ToString();
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml()
        {
            string s = string.Empty;

            if (Privs_XiuGai) s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\" data-chakan=\"1\">查看</a> ";

            if (Privs_ShanChu) s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";

            return s.ToString();
        }

        /// <summary>
        /// get fujian
        /// </summary>
        /// <param name="fuJians"></param>
        /// <returns></returns>
        protected string GetFuJian(object fuJians)
        {
            if (fuJians == null) return "<a javascript:\"void(0)\">未上传附件<a/>";

            var items = (IList<EyouSoft.Model.PtStructure.MFuJianInfo>)fuJians;
            if (items == null || items.Count == 0) return "<a javascript:\"void(0)\">未上传附件<a/>";

            StringBuilder s = new StringBuilder();

            s.AppendFormat("<a href=\"javascript:void(0)\" class=\"fujian_ck\">查看附件</a>");

            s.AppendFormat("<div style=\"display:none;\">");
            s.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0' class='pp-tableclass'>");
            s.Append("<tr class='pp-table-title'><th width='30'>序号</th><th>标题</th><th width='60'>下载</th>");
            int i = 1;
            foreach (var item in items)
            {
                s.Append("<tr class=''>");
                s.AppendFormat("<td>{0}</td>", i);
                s.AppendFormat("<td style=\"text-align:left;\">{0}</td>", item.MiaoShu);
                s.AppendFormat("<td><a href=\"{0}\" target=\"_blank\">下载</a></td>", item.Filepath);
                s.Append("</tr>");
                i++;
            }
            s.Append("</table>");
            s.AppendFormat("</div>");

            return s.ToString();
        }
        #endregion
    }
}
