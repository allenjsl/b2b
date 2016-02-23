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
    /// 财务管理-押金登记表
    /// </summary>
    public partial class YaJin : BackPage
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_押金登记表_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_押金登记表_栏目, true);
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

            var items = new EyouSoft.BLL.FinStructure.BFin().GetYaJins(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrYaJinJinEHeJi.Text = ToMoneyString(heJi[0]);
                ltrYiZhiFuYaJinJinEHeJi.Text = ToMoneyString(heJi[1]);
                ltrYingTuiYaJinJinEHeJi.Text = ToMoneyString(heJi[4]);
                ltrYiTuiYaJinJinEHeJi.Text = ToMoneyString(heJi[5]);

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
        EyouSoft.Model.FinStructure.MYingFuChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MYingFuChaXunInfo();

            info.GysJiaoYiHao = Utils.GetQueryStringValue("txtGysJiaoYiHao");
            info.GysName = Utils.GetQueryStringValue("txtGysName");
            info.JiaoYiHao = Utils.GetQueryStringValue("txtJiaoYiHao");
            info.KongWeiCode = Utils.GetQueryStringValue("txtKongWeiCode");
            info.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLEDate"));
            info.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLSDate"));
            info.YingTuiYaJinOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtYingTuiYaJinOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.YingTuiYaJinJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtYingTuiYaJinJinE"));
            info.TuiYiShenPiYaJinOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtTuiYiShenPiYaJinOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.TuiYiShenPiYaJinJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtTuiYiShenPiYaJinJinE"));
            info.ZxsId = CurrentZxsId;

            info.YingFuJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtYingFuYaJinJinE"));
            info.YingFuJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtYingFuYaJinOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);

            info.YiZhiFuJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtYiZhiFuYaJinJinE"));
            info.YiZhiFuJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtYiZhiFuYaJinOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);

            info.WeiZhiFuJinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtWeiZhiFuYaJinJinE"));
            info.WeiZhiFuJinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtWeiZhiFuYaJinOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);

            info.PaiXuLeiXing = Utils.GetInt(Utils.GetQueryStringValue("paixuleixing"));

            return info;
        }
        #endregion
    }
}
