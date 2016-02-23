//客户用户积分明细 汪奇志 2014-11-18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.TongJi
{
    /// <summary>
    /// 客户用户积分明细
    /// </summary>
    public partial class KeHuYongHuJiFenMingXi : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        int? YongHuId = null;
        string KeHuId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            YongHuId = Utils.GetIntNull(Utils.GetQueryStringValue("txtYongHuId"));
            KeHuId = Utils.GetQueryStringValue("txtKeHuId");

            if (!YongHuId.HasValue||string.IsNullOrEmpty(KeHuId)) { RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求。")); }

            InitPrivs();

            InitRpt();

            InitYongHuJiFenInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            string refererLeiXing = Utils.GetQueryStringValue("refererLeiXing");

            if (refererLeiXing == "jifendingdanchakanyonghujifenmingxi")
            {
                if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换订单管理_订单管理))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
            }
            else
            {
                if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_客户用户积分统计表_栏目))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MYongHuJiFenMingXiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MYongHuJiFenMingXiChaXunInfo();

            info.JiFenStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenStatus), Utils.GetQueryStringValue("txtJiFenStatus"));
            info.JiFenLeiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing), Utils.GetQueryStringValue("txtJiFenLeiXing"));
            info.JiFenShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtJiFenShiJian1"));
            info.JiFenShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtJiFenShiJian2"));

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
            object[] heJi;
            var items = new EyouSoft.BLL.PtStructure.BJiFen().GetYongHuJiFenMingXis(CurrentUserCompanyID, YongHuId.Value, pageSize, pageIndex, ref recordCount, chaXun,out heJi);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;

                if (chaXun.JiFenLeiXing.HasValue && chaXun.JiFenStatus.HasValue)
                {
                    phHeJi.Visible = true;
                    ltrJiFenHeJi.Text = heJi[0].ToString();
                }
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
                phHeJi.Visible = false;
            }
        }

        /// <summary>
        /// init yonghu jifen info
        /// </summary>
        void InitYongHuJiFenInfo()
        {
            var info = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetYongHuJiFenInfo(YongHuId.Value);
            var keHuInfo = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(KeHuId);
            var yongHuInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(YongHuId.Value);

            if (keHuInfo == null || yongHuInfo == null)
            {
                RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求。"));
            }

            ltrYongHuJiFenXinXi.Text = "<b>用户（" + keHuInfo.Name + "-" + yongHuInfo.PersonInfo.ContactName + "）当前积分信息：可用积分：<span style=\"font-size:14px\">" + info.KeYongJiFen + "</span>，冻结积分：<span style=\"font-size:14px\">" + info.DongJieJiFen + "</span>，已使用积分：<span style=\"font-size:14px\">" + info.YiShiYongJiFen + "</span>。</b>";

        }
        #endregion

        #region protected members
        /// <summary>
        /// rpt_ItemDataBound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                s += "，订单编号：" + info.JiaoYiHao;
                s += "。";
            }

            if (info.JiFenLeiXing == EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing.兑换)
            {
                s += "商品兑换--减少";
                s += info.JiFen + "个积分，";
                s += "兑换商品：" + info.GuanLianChanPinName;
                if (!string.IsNullOrEmpty(info.GuanLianChanPinBianHao))
                {
                    s += "（编号：" + info.GuanLianChanPinBianHao + "）";
                }
                s += "，订单编号：" + info.JiaoYiHao;
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
