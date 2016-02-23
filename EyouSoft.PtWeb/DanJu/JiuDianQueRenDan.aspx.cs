﻿//代订酒店业务确认单 汪奇志 2014-09-11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.DanJu
{
    /// <summary>
    /// 代订酒店业务确认单
    /// </summary>
    public partial class JiuDianQueRenDan : QianTaiYeMian
    {
        #region attributes
        /// <summary>
        /// 订单编号
        /// </summary>
        string DingDanId = string.Empty;
        /// <summary>
        /// 专线商编号
        /// </summary>
        string ZxsId = string.Empty;
        /// <summary>
        /// 专线商操作人编号
        /// </summary>
        int ZxsCaoZuoRenId = 0;
        /// <summary>
        /// 客户编号
        /// </summary>
        string KeHuId = string.Empty;
        /// <summary>
        /// 客户联系编号
        /// </summary>
        int KeHuLxrId = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("dingdanid");
            if (string.IsNullOrEmpty(DingDanId)) Utils.RCWE("异常请求");

            InitDingDanInfo();
            InitPrivs();
            InitZxsInfo();
            InitKeHuInfo();

            InitYeMeiYeJiao();
        }

        #region private members
        /// <summary>
        /// init dingdan info
        /// </summary>
        void InitDingDanInfo()
        {
            var info1 = new EyouSoft.BLL.TourStructure.BTourOrder().GetTourOrderById(DingDanId);
            if (info1 == null) Utils.RCWE("异常请求");

            var info = new EyouSoft.BLL.TourStructure.BTourOrderHotel().GetTourOrderHotel(info1.TourId);

            var yeWuLeiXings = new EyouSoft.Model.EnumType.TourStructure.BusinessType[] { EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店};

            if (!yeWuLeiXings.Contains(info1.BusinessType.Value)) Utils.RCWE("异常请求");

            ZxsId = info.ZxsId;
            ZxsCaoZuoRenId = info1.LatestOperatorId;
            KeHuId = info.BuyCompanyId;
            KeHuLxrId = info.BuyOperatorId;

            ltrJiaGeMinXi.Text = info.PriceDetials;
            ltrZongJinE.Text = info.SumPrice.ToString("F2");
            ltrJiaGeBeiZhu.Text = info.PriceRemark;
            ltrRemark.Text = info.SpecialAskRemark;
            ltrIssueTime.Text = info.IssueTime.ToString("yyyy-MM-dd");

            rptCustomer.DataSource = info.TourOrderTravellerList;
            rptCustomer.DataBind();

            if (info.TourOrderHotelPlanList != null && info.TourOrderHotelPlanList.Count > 0)
            {
                var items = new List<EyouSoft.Model.TourStructure.MPlanHotelMxInfo>();

                foreach (var item in info.TourOrderHotelPlanList)
                {
                    if (string.IsNullOrEmpty(item.GYSId)) continue;
                    if (item.AnPaiMxs != null && item.AnPaiMxs.Count > 0)
                    {
                        foreach (var item1 in item.AnPaiMxs)
                        {
                            items.Add(item1);
                        }
                    }
                }

                rptHotel.DataSource = items;
                rptHotel.DataBind();
            }
        }

        /// <summary>
        /// init zxs info
        /// </summary>
        void InitZxsInfo()
        {
            if (string.IsNullOrEmpty(ZxsId)) return;
            var info = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(ZxsId);
            if (info == null) return;

            ltrZxsName.Text = ltrZxsName1.Text = info.MingCheng;

            var zxsCaoZuoRenInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(ZxsCaoZuoRenId);
            if (zxsCaoZuoRenInfo != null)
            {
                ltrZxsFaJianRenFax.Text = zxsCaoZuoRenInfo.PersonInfo.ContactFax;
                ltrZxsFaJianRenName.Text = zxsCaoZuoRenInfo.PersonInfo.ContactName;
            }

            var items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(SysCompanyId, ZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.打印单据账户);
            IList<EyouSoft.Model.CompanyStructure.CompanyAccount> items1 = new List<EyouSoft.Model.CompanyStructure.CompanyAccount>();

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用)
                    {
                        items1.Add(item);
                    }
                }
            }

            rptBank.DataSource = items1;
            rptBank.DataBind();
        }

        /// <summary>
        /// init kehu info
        /// </summary>
        void InitKeHuInfo()
        {
            if (string.IsNullOrEmpty(KeHuId)) return;
            var info = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(KeHuId);
            if (KeHuId == null) return;

            ltrKeHuName.Text = info.Name;

            var keHuLxrInfo = new EyouSoft.BLL.CompanyStructure.Customer().GetKeHuLxrInfo(KeHuId, KeHuLxrId);

            if (keHuLxrInfo != null)
            {
                ltrKeHuLxrName.Text = keHuLxrInfo.Name;
                ltrKeHuLxrFax.Text = keHuLxrInfo.Fax;
            }
        }

        /// <summary>
        /// init yemei yejiao
        /// </summary>
        void InitYeMeiYeJiao()
        {
            var zxsPeiZhiInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetZxsPeiZhiInfo(SysCompanyId, ZxsId);
            if (zxsPeiZhiInfo == null) return;

            if (!string.IsNullOrEmpty(zxsPeiZhiInfo.DaYinYeMeiFilepath))
            {
                ltrYeiMei.Text = string.Format("<img src=\"{0}\" style=\"width:100%;height:115px\" />", ErpUrl + zxsPeiZhiInfo.DaYinYeMeiFilepath);
            }

            if (!string.IsNullOrEmpty(zxsPeiZhiInfo.DaYinYeJiaoFilepath))
            {
                ltrYeJiao.Text = string.Format("<img src=\"{0}\" style=\"width:100%;height:76px\" />", ErpUrl + zxsPeiZhiInfo.DaYinYeJiaoFilepath);
            }
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!IsLogin) RCWE("异常请求");
            if (YongHuInfo.KeHuId != KeHuId) RCWE("异常请求");
        }
        #endregion
    }
}
