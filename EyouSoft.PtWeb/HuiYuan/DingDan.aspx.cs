using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.HuiYuan
{
    public partial class DingDan : HuiYuanYeMian
    {
        #region attbiutes
        protected int pageSize = 20;
        protected int pageIndex = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitDingDan();
            InitZxsOptions();
        }

        #region private members
        /// <summary>
        /// init dingdan
        /// </summary>
        void InitDingDan()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            object[] heJi=null;

            var items = new EyouSoft.BLL.PtStructure.BKongWeiXianLu().GetDingDans(SysCompanyId, YongHuInfo.KeHuId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                rptDingDan.DataSource = items;
                rptDingDan.DataBind();

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
        EyouSoft.Model.PtStructure.MDingDanLbChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MDingDanLbChaXunInfo();

            info.DingDanStatus = (EyouSoft.Model.EnumType.TourStructure.OrderStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.OrderStatus), Utils.GetQueryStringValue("txtDingDanStatus"));
            info.JieQingStatus = Utils.GetIntNull(Utils.GetQueryStringValue("txtJieQingStatus"));
            info.QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate1"));
            info.QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate2"));
            info.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.BusinessType), Utils.GetQueryStringValue("txtYeWuLeiXing"));
            info.YouKeName = Utils.GetQueryStringValue("txtYouKeName");
            //info.ZxsName = Utils.GetQueryStringValue("txtZxsName");
            info.ZxsId = Utils.GetQueryStringValue(txtZxs.ZxsIdClientId);
            info.ZxsName = Utils.GetQueryStringValue(txtZxs.ZxsNameClientId);

            if (string.IsNullOrEmpty(info.ZxsId))
            {
                info.ZxsId = Utils.GetQueryStringValue("txtZxs");
            }

            return info;
        }

        /// <summary>
        /// init zxs options
        /// </summary>
        void InitZxsOptions()
        {
            var chaXun = new EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsChaXunInfo();
            chaXun.TopExpression = 50;
            var items = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetAutocompleteZxss(SysCompanyId, YongHuInfo.KeHuId, chaXun);
            StringBuilder s = new StringBuilder();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.ZxsId, item.ZxsName);
                }
            }
            ltrZxs.Text = s.ToString();
        }
        #endregion

        

        #region protected members
        /// <summary>
        /// rptDingDan_ItemDataBound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptDingDan_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            #region 专线商操作人信息
            var info = (EyouSoft.Model.PtStructure.MDingDanLbInfo)e.Item.DataItem;
            var ltrZxsCaoZuoRenXinXi = (Literal)e.Item.FindControl("ltrZxsCaoZuoRenXinXi");

            if (info.XiaDanLeiXing == EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing.系统下单)
            {
                ltrZxsCaoZuoRenXinXi.Text = info.ZxsCaoZuoRenName + "<br/>" + info.ZxsCaoZuoShiJian.ToString("yyyy-MM-dd");
            }
            else
            {
                if (info.XiaDanRenId != info.ZxsCaoZuoRenId && info.DingDanStatus != EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认)
                {
                    ltrZxsCaoZuoRenXinXi.Text = info.ZxsCaoZuoRenName + "<br/>" + info.ZxsCaoZuoShiJian.ToString("yyyy-MM-dd");
                }
            }
            #endregion 

            #region 积分
            if (info.JiFen2 > 0 && (info.JiFenXianShiBiaoShi == EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi.显示 || info.XiaDanRenId == YongHuInfo.YongHuId || info.KeHuLxrId == YongHuInfo.KeHuLxrId))
            {
                var ltrJiFen = (Literal)e.Item.FindControl("ltrJiFen");
                ltrJiFen.Text = string.Format("<br/><span class=\"jifen\" style=\"white-space:nowrap;\"><em>积分</em>{0}</span>", info.JiFen2);
            }
            #endregion

            #region 操作
            var ltrCaoZuo = (Literal)e.Item.FindControl("ltrCaoZuo");
            string chaKan = "<a class=\"caozuo-btn\" data-class=\"caozuo\" href=\"javascript:void(0)\" data-fs=\"chakan\">查看</a>&nbsp;";
            string quXiao = "<a class=\"caozuo-btn\" data-class=\"caozuo\" href=\"javascript:void(0)\" data-fs=\"quxiao\">取消</a>&nbsp;";
            string yuanYin = "<a class=\"caozuo-btn\" data-class=\"caozuo\" href=\"javascript:void(0)\" data-fs=\"yuanyin\">原因</a><span style=\"display:none\">取消原因：{0}</span>&nbsp;";
            string huiFu = "<a class=\"caozuo-btn\" data-class=\"caozuo\" href=\"javascript:void(0)\" data-fs=\"huifu\">恢复</a>&nbsp;";
            string mingDan = "<a class=\"caozuo-btn\" href=\"{0}\" target=\"_blank\">名单</a>&nbsp;";
            string queRenDan = "<a class=\"caozuo-btn\" href=\"{0}\" target=\"_blank\">确认单</a>&nbsp;";

            string mingDanUrl = "/danju/youkemingdan.aspx?dingdanid="+info.DingDanId;
            string queRenDanUrl = "/danju/youkequerendan.aspx?dingdanid="+info.DingDanId;

            #region danju url
            if (info.YeWuLeiXing == EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店)
            {
                queRenDanUrl = "/danju/jiudianquerendan.aspx?dingdanid="+info.DingDanId;
            }
            else if (info.YeWuLeiXing == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店)
            {
                queRenDanUrl = "/danju/jipiaoquerendan.aspx?dingdanid=" + info.DingDanId;
            }
            else if (info.YeWuLeiXing == EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票)
            {
                queRenDanUrl = "/danju/jipiaoquerendan.aspx?dingdanid=" + info.DingDanId;
            }
            #endregion

            switch (info.DingDanStatus)
            {
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认:
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.申请中:
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全:
                    ltrCaoZuo.Text = chaKan + quXiao;
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已取消:
                    ltrCaoZuo.Text = chaKan + string.Format(yuanYin, info.YuanYin1) + "<br/>" + huiFu;
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交:
                    ltrCaoZuo.Text = chaKan + string.Format(mingDan, mingDanUrl) + "<br/>" + string.Format(queRenDan, queRenDanUrl);
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已拒绝:
                    ltrCaoZuo.Text = chaKan;
                    break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位:
                    ltrCaoZuo.Text = chaKan + quXiao;
                    break;
            }

            if (info.YeWuLeiXing == EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店)
            {
                ltrCaoZuo.Text = string.Format(queRenDan,queRenDanUrl);
            }

            if (info.YeWuLeiXing == EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店)
            {
                ltrCaoZuo.Text = chaKan;
                if (info.DingDanStatus == EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交)
                {
                    ltrCaoZuo.Text += string.Format(mingDan, mingDanUrl) + string.Format(queRenDan, queRenDanUrl);
                }
            }

            if (info.FaPiaoMxId > 0)
            {
                ltrCaoZuo.Text += "<a class=\"caozuo-btn\" data-class=\"caozuo\" href=\"javascript:void(0)\" data-fs=\"fapiao\">发票</a>&nbsp;";
            }
            #endregion

            #region 线路名称
            var ltrRouteName = (Literal)e.Item.FindControl("ltrRouteName");
            if (!string.IsNullOrEmpty(info.RotueName)) ltrRouteName.Text = info.RotueName;
            else ltrRouteName.Text = info.YeWuLeiXing.ToString();
            #endregion

            #region 订单状态
            var ltrDingDanStatus = (Literal)e.Item.FindControl("ltrDingDanStatus");
            string _dingDanStatus = info.DingDanStatus.ToString();
            string _s1 = "<span style=\"color:{0}\">{1}</span>";
            switch (info.DingDanStatus)
            {
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全: _dingDanStatus = string.Format(_s1, "#ff0000", info.DingDanStatus); break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.申请中: _dingDanStatus = string.Format(_s1, "#ff0000", info.DingDanStatus); break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认: _dingDanStatus = string.Format(_s1, "#ff0000", info.DingDanStatus); break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交: _dingDanStatus = string.Format(_s1, "#2f2f2f", "<b>"+info.DingDanStatus+"</b>"); break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已拒绝: _dingDanStatus = string.Format(_s1, "#999", info.DingDanStatus); break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位: _dingDanStatus = string.Format(_s1, "#ff0000", info.DingDanStatus); break;
                case EyouSoft.Model.EnumType.TourStructure.OrderStatus.已取消: _dingDanStatus = string.Format(_s1, "#999", info.DingDanStatus); break;
            }
            ltrDingDanStatus.Text = _dingDanStatus;
            #endregion
        }
        #endregion
    }
}
