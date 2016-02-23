//积分记录 汪奇志 2014-09-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.HuiYuan
{
    /// <summary>
    /// 积分记录
    /// </summary>
    public partial class JiFenMingXi : HuiYuanYeMian
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitJiFenMingXi();
            InitYongHuJiFen();
        }

        #region private members
        /// <summary>
        /// init jifenmingxi
        /// </summary>
        void InitJiFenMingXi()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            object[] heJi;
            var items = new EyouSoft.BLL.PtStructure.BJiFen().GetYongHuJiFenMingXis(SysCompanyId, YongHuInfo.YongHuId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                rptJiFenMingXi.DataSource = items;
                rptJiFenMingXi.DataBind();

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;

                phHeJi.Visible = false;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MYongHuJiFenMingXiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MYongHuJiFenMingXiChaXunInfo();

            info.JiFenStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenStatus), Utils.GetQueryStringValue("txtStatus"));

            if (info.JiFenStatus.HasValue && info.JiFenStatus.Value != EyouSoft.Model.EnumType.PtStructure.JiFenStatus.冻结)
                info.JiFenStatus = null;

            return info;
        }

        /// <summary>
        /// init yonghu jifen
        /// </summary>
        void InitYongHuJiFen()
        {
            var info = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetYongHuJiFenInfo(YongHuInfo.YongHuId);

            if (info != null)
            {
                ltrKeYongJiFen.Text = info.KeYongJiFen.ToString();
                ltrDongJieJiFen.Text = info.DongJieJiFen.ToString();
            }

        }
        #endregion

        #region protected members
        /// <summary>
        /// rptJiFenMingXi_ItemDataBound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptJiFenMingXi_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            var info = (EyouSoft.Model.PtStructure.MYongHuJiFenMingXiInfo)e.Item.DataItem;

            var ltrJiFenMingXi = (Literal)e.Item.FindControl("ltrJiFenMingXi");

            string s = string.Empty;

            if (info.JiFenLeiXing == EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing.积分)
            {
                s += "线路预订--积分结算--获得";
                s += info.JiFen + "个积分，";
                if (string.IsNullOrEmpty(info.GuanLianChanPinName))
                {
                    s += "线路：" + info.YeWuLeiXing.Value;
                }
                else
                {
                    s += "线路：" + info.GuanLianChanPinName;
                }
                if (!string.IsNullOrEmpty(info.GuanLianChanPinBianHao))
                {
                    s += "（编号：" + info.GuanLianChanPinBianHao + "）";
                }
                s += "。";
            }

            if (info.JiFenLeiXing == EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing.兑换)
            {
                s += "商品兑换--减少";
                s += info.JiFen + "个积分，";
                s += "兑换商品：" + info.GuanLianChanPinName ;
                if (!string.IsNullOrEmpty(info.GuanLianChanPinBianHao))
                {
                    s += "（编号：" + info.GuanLianChanPinBianHao + "）";
                }
                s += "。";
            }
            ltrJiFenMingXi.Text = s;

        }

        /// <summary>
        /// get jifen status
        /// </summary>
        /// <param name="jiFenStatus"></param>
        /// <returns></returns>
        protected string GetJiFenStatus(object jiFenStatus)
        {
            var _jiFenStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenStatus)jiFenStatus;

            string s = "<b style=\"color:{0}\">" + jiFenStatus + "</b>";

            switch (_jiFenStatus)
            {
                case EyouSoft.Model.EnumType.PtStructure.JiFenStatus.冻结:
                    s = string.Format(s, "#ff0000");
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenStatus.取消:
                    s = string.Format(s, "#999");
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenStatus.有效:
                    s = string.Format(s, "#2f2f2f");
                    break;
                default:
                    s = string.Empty;
                    break;
            }

            return s;
        }
        #endregion
    }
}
