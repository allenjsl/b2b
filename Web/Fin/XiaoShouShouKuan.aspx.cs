//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-销售收款
    /// </summary>
    public partial class XiaoShouShouKuan : BackPage
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_销售收款_栏目, true);
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
            object[] heJi;

            var items = new EyouSoft.BLL.FinStructure.BFin().GetYingShou(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrJinEHeJi.Text = ToMoneyString(heJi[4]);
                ltrYiShouJinEHeJi.Text = ToMoneyString((decimal)heJi[5] - (decimal)heJi[7]);
                ltrWeiShouJinEHeJi.Text = ToMoneyString((decimal)heJi[4] - (decimal)heJi[5] + (decimal)heJi[7]);
                ltrWeiShenHeJinEHeJi.Text = ToMoneyString(heJi[6]);
                ltrTuiWeiShenHeJinEHeJi.Text = ToMoneyString(heJi[8]);

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
        EyouSoft.Model.FinStructure.MOrderChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MOrderChaXunInfo();

            info.KeHuCityId = Utils.GetIntNull(Utils.GetQueryStringValue("txtCity"));
            info.keHuName = Utils.GetQueryStringValue("txtKeHuName");
            info.KeHuProvinceId = Utils.GetIntNull(Utils.GetQueryStringValue("txtProvince"));
            info.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLEDate"));
            info.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLSDate"));
            info.OperatorName = Utils.GetQueryStringValue("txtOperatorName");
            info.OrderCode = Utils.GetQueryStringValue("txtOrderCode");
            info.YouKeName = Utils.GetQueryStringValue("txtYouKeName");
            info.YingShouJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtYingShouJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.YingShouJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtYingShouJinE"));
            info.JieQingStatus = Utils.GetIntNull(Utils.GetQueryStringValue("txtJieQingStatus"));
            info.DanBiShouKuanJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtDanBiShouKuanJinE"));
            info.DanBiShouKuanJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtDanBiShouKuanJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.WeiShouJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtWeiShouJinE"));
            info.WeiShouJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtWeiShouJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.ZxsId = CurrentZxsId;
            info.TuiKuanJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtTuiKuanJinE"));
            info.TuiKuanJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtTuiKuanJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);

            info.PaiXuLeiXing = Utils.GetInt(Utils.GetQueryStringValue("paixuleixing"));

            return info;
        }

        /// <summary>
        /// 获取列表行样式
        /// </summary>
        /// <param name="biaoShiYanSe">标识颜色</param>
        /// <returns></returns>
        protected string GetHangYangShi(object biaoShiYanSe)
        {
            if (biaoShiYanSe == null || string.IsNullOrEmpty(biaoShiYanSe.ToString())) return string.Empty;

            return ";color:" + biaoShiYanSe + ";";
        }
        #endregion
    }
}
