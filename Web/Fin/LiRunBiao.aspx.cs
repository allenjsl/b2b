//汪奇志 2013-02-04
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
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-利润表
    /// </summary>
    public partial class LiRunBiao : BackPage
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
        bool Privs_Insert = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "delete") Delete();
            if (UtilsCommons.IsToXls()) ToXls();

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_利润表_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_利润表_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_利润表_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_利润表_修改);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_利润表_删除);

            phInsert.Visible = Privs_Insert;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            object[] heJi;
            int recordCount = 0;
            var items = new EyouSoft.BLL.FinStructure.BLiRun().GetLiRuns(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrTuanDuiJieSuanMaoLiHeJi.Text = ToMoneyString(heJi[0]);
                ltrBaoXiaoFeiYongHeJi.Text = ToMoneyString(heJi[1]);
                ltrYingYeWaiShouRuHeJi.Text = ToMoneyString(heJi[2]);
                ltrYingYeWaiZhiChuHeJi.Text = ToMoneyString(heJi[3]);
                ltrChunLiRunHeJi.Text = ToMoneyString(heJi[4]);
                ltrZhuYingYeWuShouRuHeJi.Text= ToMoneyString(heJi[5]);
                ltrZhuYingYeWuZhiChuHeJi.Text = ToMoneyString(heJi[6]);
                ltrQiTaSunShiHeJi.Text = ToMoneyString(heJi[7]);

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
        EyouSoft.Model.FinStructure.MLiRunChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MLiRunChaXunInfo();

            info.Year = Utils.GetIntNull(Utils.GetQueryStringValue("txtYear"));
            info.Month = Utils.GetIntNull(Utils.GetQueryStringValue("txtMonth"));
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 删除利润表信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string liRunId = Utils.GetFormValue("txtLiRunId");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BLiRun().Delete(liRunId, CurrentUserCompanyID);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));            
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// ToXls
        /// </summary>
        private void ToXls()
        {
            StringBuilder s = new StringBuilder();
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            int _recordCount = 0;

            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);
            var chaXun = GetChaXunInfo();
            object[] heJi;
            var items = new EyouSoft.BLL.FinStructure.BLiRun().GetLiRuns(CurrentUserCompanyID, toXlsRecordCount, 1, ref _recordCount, chaXun, out heJi);

            if (items == null || items.Count == 0) ResponseToXls(string.Empty);

            int i = 1;
            s.Append("序号\t年月\t主营业务收入\t主营业务成本\t团队结算毛利\t营业费用\t营业外收入\t营业外支出\t其它损失\t纯利润\n");
            foreach (var item in items)
            {
                s.Append(i + "\t");
                s.Append(item.YMD.ToString("yyyy-MM") + "\t");
                s.Append(item.ZhuYingYeWuShouRu.ToString("F2") + "\t");
                s.Append(item.ZhuYingYeWuZhiChu.ToString("F2") + "\t");
                s.Append(item.TuanDuiJieSuanMaoLi.ToString("F2") + "\t");
                s.Append(item.BaoXiaoFeiYong.ToString("F2") + "\t");
                s.Append(item.YingYeWaiShouRu.ToString("F2") + "\t");
                s.Append(item.YingYeWaiZhiChu.ToString("F2") + "\t");
                s.Append(item.QiTaSunShi.ToString("F2") + "\t");
                s.Append(item.ChunLiRun.ToString("F2") + "\n");
                i++;
            }

            ResponseToXls(s.ToString());
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

            if (Privs_Update) s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";

            if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a> ";
                
            return s.ToString();
        }

        /// <summary>
        /// 获取年份下拉菜单项
        /// </summary>
        /// <param name="v">选中项的值</param>
        /// <returns></returns>
        protected string GetYearOptions(string v)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</option>");
            int i = 2012;
            int e = DateTime.Now.Year;

            for (; i <= e; i++)
            {
                if (i.ToString() == v)
                {
                    s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
                }
                else
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</option>", i);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取月份下拉菜单项
        /// </summary>
        /// <param name="v">选中项的值</param>
        /// <returns></returns>
        protected string GetMonthOptions(string v)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</option>");
            int i = 1;

            for (; i <= 12; i++)
            {
                if (i.ToString() == v)
                {
                    s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
                }
                else
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</option>", i);
                }
            }

            return s.ToString();
        }
        #endregion

    }
}
