//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-银行明细表
    /// </summary>
    public partial class YinHangMingXi : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        protected string EBankDate = string.Empty;
        protected string SBankDate = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            string doType = Utils.GetQueryStringValue("doType");

            if (UtilsCommons.IsToXls() && doType == "toxls_yinhangmingxi") { ToXls_YinHangMingXi(); }

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行明细表_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行明细表_栏目, true);
            }
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            decimal[] heJi;

            var items = new EyouSoft.BLL.FinStructure.BFin().GetYinHangMingXi(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrJieFangHeJi.Text = ToMoneyString(heJi[0]);
                ltrDaiFangHeJi.Text = ToMoneyString(heJi[1]);

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
        EyouSoft.Model.FinStructure.MYinHangMingXiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MYinHangMingXiChaXunInfo();

            info.EBankDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEBankDate"));
            info.SBankDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSBankDate"));
            info.YinHangZhangHuId = Utils.GetQueryStringValue("txtYinHangZhangHu");

            if (Utils.GetQueryStringValue("issearch") != "1" && !info.EBankDate.HasValue && !info.SBankDate.HasValue)
            {
                info.EBankDate = DateTime.Now;
                info.SBankDate = info.EBankDate.Value.AddDays(-2);
            }

            if (info.EBankDate.HasValue) EBankDate = info.EBankDate.Value.ToString("yyyy-MM-dd");
            if (info.SBankDate.HasValue) SBankDate = info.SBankDate.Value.ToString("yyyy-MM-dd");

            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 导出银行明细表
        /// </summary>
        void ToXls_YinHangMingXi()
        {
            StringBuilder s = new StringBuilder();
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            int _recordCount = 0;

            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);
            var chaXun = GetChaXunInfo();

            decimal[] heJi;
            var items = new EyouSoft.BLL.FinStructure.BFin().GetYinHangMingXi(CurrentUserCompanyID, toXlsRecordCount, 1, ref _recordCount, chaXun, out heJi);

            if (items == null || items.Count == 0) ResponseToXls(string.Empty);

            int i = 1;
            s.Append("序号\t银行实际业务日期\t银行账号\t借\t贷\t往来单位\t备注\n");
            foreach (var item in items)
            {
                s.Append(i + "\t");
                s.Append(item.BankDate.ToString("yyyy-MM-dd") + "\t");
                s.Append(item.ZhangHuName + "\t");
                s.Append(item.JieFangJinE.ToString("F2") + "\t");
                s.Append(item.DaiFangJinE.ToString("F2") + "\t");
                s.Append(item.WangLaiDanWeiName + "\t");
                s.Append(item.BeiZhu + "\n");
                i++;
            }

            ResponseToXls(s.ToString());
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取借方、贷方金额
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetJieDaiFangJInE(object obj)
        {
            if (obj == null) return string.Empty;

            decimal jinE = Utils.GetDecimal(obj.ToString());

            if (jinE == 0) return string.Empty;

            return ToMoneyString(jinE);
        }

        /// <summary>
        /// 获取银行账户下拉菜单Option
        /// </summary>
        /// <returns></returns>
        protected string GetYinHangZhangHuOptions()
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">--请选择--</option>");
            var items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(CurrentUserCompanyID, CurrentZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.收付款账户);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.未审批) continue;

                    s.AppendFormat("<option value=\"{0}\">{1}-{2}-{3}</option>", item.Id, item.BankName, item.AccountName, item.BankNo);
                }
            }

            return s.ToString();
        }
        #endregion
    }
}
