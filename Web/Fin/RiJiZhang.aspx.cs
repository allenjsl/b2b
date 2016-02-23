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
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-出纳日记账
    /// </summary>
    public partial class RiJiZhang : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 新增权限
        /// </summary>
        protected bool Privs_Insert = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            string doType = Utils.GetQueryStringValue("doType");
            if (UtilsCommons.IsToXls() && doType == "toxls_rijizhang") { ToXls_RiJiZhang(); }

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳日记账_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳日记账_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳日记账_登记);

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
            var items = new EyouSoft.BLL.FinStructure.BRiJiZhang().GetRiJiZhangs(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

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
        EyouSoft.Model.FinStructure.MRiJiZhangChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MRiJiZhangChaXunInfo();

            info.EDengJiRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtERiQi"));
            info.SDengJiRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSRiQi"));
            info.EYeWuRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEYeWuRiQi"));
            info.SYeWuRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSYeWuRiQi"));
            info.YinHangZhangHuId = Utils.GetQueryStringValue("txtYinHangZhangHu");
            info.XiangMu = (EyouSoft.Model.EnumType.FinStructure.RiJiZhangXiangMu?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.FinStructure.RiJiZhangXiangMu), Utils.GetQueryStringValue("txtXiangMu"));
            info.PingZhengHao = Utils.GetQueryStringValue("txtPingZhengHao");
            info.JieFangJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtJieFangJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.JieFangJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtJieFangJinE"));
            info.DaiFangJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtDaiFangJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.DaiFangJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtDaiFangJinE"));
            info.WangLaiDanWeiName = Utils.GetQueryStringValue("txtWangLaiDanWeiName");
            info.WangLaiDanWeiLeiXing = (RiJiZhangDanWeiType?)Utils.GetEnumValueNull(typeof(RiJiZhangDanWeiType), Utils.GetQueryStringValue("txtKeHuType"));

            if (info.WangLaiDanWeiLeiXing.HasValue)
            {
                switch (info.WangLaiDanWeiLeiXing)
                {
                    case RiJiZhangDanWeiType.供应商: info.WangLaiDanWeiId = Utils.GetQueryStringValue(txtGys.ClientValue); break;
                    case RiJiZhangDanWeiType.客户单位: info.WangLaiDanWeiId = Utils.GetQueryStringValue(txtKeHu.KeHuIdClientName); break;
                    case RiJiZhangDanWeiType.员工: info.WangLaiDanWeiId = Utils.GetQueryStringValue(txtYuanGong.SellsIDClient); break;
                    default: break;
                }
            }

            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 导出出纳日记账
        /// </summary>
        void ToXls_RiJiZhang()
        {
            StringBuilder s = new StringBuilder();
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            int _recordCount = 0;

            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);
            var chaXun = GetChaXunInfo();

            var items = new EyouSoft.BLL.FinStructure.BRiJiZhang().GetRiJiZhangs(CurrentUserCompanyID, toXlsRecordCount, 1, ref _recordCount, chaXun);


            if (items == null || items.Count == 0) ResponseToXls(string.Empty);

            int i = 1;
            s.Append("序号\t登记日期\t项目\t业务日期\t凭证编号\t银行账号\t往来单位\t明细\t借方\t贷方\t余额\n");
            foreach (var item in items)
            {
                s.Append(i + "\t");
                s.Append(item.DengJiRiQi.ToString("yyyy-MM-dd") + "\t");
                s.Append(item.XiangMu + "\t");
                s.Append(item.YeWuRiQi + "\t");
                s.Append(item.PingZhengHao + "\t");
                s.Append(item.ZhangHuName + "\t");
                s.Append(item.WangLaiDanWei + "\t");
                s.Append(item.MingXi + "\t");
                s.Append(item.JieFangJinE.ToString("F2") + "\t");
                s.Append(item.DaiFangJinE.ToString("F2") + "\t");
                s.Append(item.YuE.ToString("F2") + "\n");
                i++;
            }

            ResponseToXls(s.ToString());
        }
        #endregion

        #region protected members
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

        /// <summary>
        /// 获取单位类型HTML
        /// </summary>
        /// <param name="selectValue">要选中的值</param>
        /// <returns></returns>
        protected string GetKeHuTypeOptions(string selectValue)
        {
            if (string.IsNullOrEmpty(selectValue)) selectValue = "";
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.RiJiZhangDanWeiType));

            s.Append("<option value=\"\">请选择</option>");
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.Value == selectValue) s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value, item.Text);
                    else s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Value, item.Text);
                }
            }

            return s.ToString();
        }
        #endregion
    }
}
