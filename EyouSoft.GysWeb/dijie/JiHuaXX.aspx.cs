//地接社主体-计划中心-计划信息 汪奇志 2015-05-22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.GysWeb.dijie
{
    /// <summary>
    /// 地接社主体-计划中心-计划信息
    /// </summary>
    public partial class JiHuaXX : DiJieYeMian
    {
        #region attributes
        protected string AnPaiId = string.Empty;
        string[] DingDanIds = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            AnPaiId = Utils.GetQueryStringValue("anpaiid");

            if (string.IsNullOrEmpty(AnPaiId)) Utils.RCWE_AJAX("0", "异常请求");

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "baocun": BaoCun(true); break;
                case "queren": QueRen(); break;
                default: break;
            }

            InitInfo();

            InitYouKeRpt();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.PlanStructure.BPlanDiJie().GetPlanDiJieById(AnPaiId);
            if (info == null) Utils.RCWE("异常请求");
            var kongWeiInfo = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(info.KongWeiId);
            if (kongWeiInfo == null) Utils.RCWE("异常请求");

            ltrDiJieRouteName.Text = info.DiJieRouteName;
            if (string.IsNullOrEmpty(info.DiJieRouteName)) ltrDiJieRouteName.Text = info.RouteName;

            ltrZxsName.Text = info.ZxsName;
            ltrZxsRouteName.Text = info.RouteName;
            ltrZxsTuanHao.Text = info.JiaoYiHao;
            ltrRenShu.Text = info.ChengRenShu + "成人&nbsp;" + info.ErTongShu + "儿童&nbsp;" + info.YingErShu + "婴儿&nbsp;" + info.QuPeiShu + "全陪&nbsp;";

            var citybll = new EyouSoft.BLL.CompanyStructure.City();
            var QuDepCity = citybll.GetModel(kongWeiInfo.QuDepCityId) ?? new EyouSoft.Model.CompanyStructure.City();
            var QuArrCity = citybll.GetModel(kongWeiInfo.QuArrCityId) ?? new EyouSoft.Model.CompanyStructure.City();
            var HuiDepCity = citybll.GetModel(kongWeiInfo.HuiDepCityId) ?? new EyouSoft.Model.CompanyStructure.City();
            var HuiArrCity = citybll.GetModel(kongWeiInfo.HuiArrCityId) ?? new EyouSoft.Model.CompanyStructure.City();

            ltrQuRiQi.Text = string.Format("{0:yyyy-MM-dd}", kongWeiInfo.QuDate);

            if (!string.IsNullOrEmpty(QuDepCity.CityName) || !string.IsNullOrEmpty(QuArrCity.CityName))
            {
                ltrQuJiaoTong.Text = QuDepCity.CityName + "--" + QuArrCity.CityName + "&nbsp;&nbsp;";
            }
            ltrQuJiaoTong.Text += string.Format("{0} {1}", string.IsNullOrEmpty(kongWeiInfo.QuBanCi) ? string.Empty : kongWeiInfo.QuBanCi + "/", kongWeiInfo.QuTime);

            ltrHuiRiQi.Text = string.Format("{0:yyyy-MM-dd}", kongWeiInfo.HuiDate);
            if (!string.IsNullOrEmpty(HuiDepCity.CityName) || !string.IsNullOrEmpty(HuiArrCity.CityName))
            {
                ltrHuiJiaoTong.Text = HuiDepCity.CityName + "--" + HuiArrCity.CityName + "&nbsp;&nbsp;";
            }
            ltrHuiJiaoTong.Text += string.Format("{0} {1}", string.IsNullOrEmpty(kongWeiInfo.HuiBanCi) ? string.Empty : kongWeiInfo.HuiBanCi + "/", kongWeiInfo.HuiTime);

            citybll = null; QuDepCity = null; QuArrCity = null; HuiDepCity = null; HuiArrCity = null;

            ltrYongCan.Text = info.YongCan;
            ltrQuanPei.Text = info.QuPeiName;
            ltrJieTuanFangShi.Text = info.JieTuanFangShi;
            ltrJieSuanXX.Text = info.JieSuanMX;
            ltrJieSuanJinE.Text = info.JieSuanAmount.ToString("F2");
            ltrYouKe.Text = EyouSoft.Common.Function.StringValidate.TextToHtml(info.YouKeXinXi);
            ltrBeiZhu.Text = info.Remark;

            txtDaoYouName.Value = info.DaoYouName;
            txtDiJieRouteName.Value = info.DiJieRouteName;

            #region 提示信息
            string s = string.Empty;
            s += "我方确认状态：" + info.DiJieQueRenStatus;
            if (info.DiJieQueRenStatus == EyouSoft.Model.EnumType.TourStructure.QueRenStatus.已确认 && info.DiJieQueRenRenId > 0)
            {
                s += "，确认人：" + info.DiJieQueRenRenName;
                if (info.DiJieQueRenTime.HasValue)
                {
                    s += "，确认时间：" + info.DiJieQueRenTime.Value.ToString("yyyy-MM-dd HH:mm");
                }
            }
            s += "。专线商操作人：" + info.OperatorName + "，操作时间：" + info.IssueTime.ToString("yyyy-MM-dd HH:mm");
            //s += "。如有变更，请联系专线商。";
            s += "。";

            ltrTiShiXinXi.Text = s.ToString();
            #endregion

            #region caozuo
            s = string.Empty;
            s += "<a href=\"javascript:void(0)\" id=\"a_baocun\" class=\"baocun\">保存计划</a>&nbsp;&nbsp;";
            if (info.DiJieQueRenStatus == EyouSoft.Model.EnumType.TourStructure.QueRenStatus.未确认)
            {
                s += "<a href=\"javascript:void(0)\" id=\"a_queren\" class=\"baocun\">确认计划</a>&nbsp;&nbsp;";
            }            
            ltrCaoZuo.Text = s;
            #endregion

            DingDanIds = info.OrderId;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun(bool isRCWE)
        {
            var info = new EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiJiHuaInfo();
            info.AnPaiId = AnPaiId;
            info.CaoZuoRenId = YongHuInfo.YongHuId;
            info.CaoZuoTime = DateTime.Now;
            info.DaoYouName = Utils.GetFormValue("txtDaoYouName");
            info.DiJieRouteName = Utils.GetFormValue("txtDiJieRouteName");
            info.DiJieTuanHao = string.Empty;
            info.GysId = YongHuInfo.GysId;

            int bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanDiJie().GYS_DiJieJiHua_U(info);

            if (isRCWE)
            {
                if (bllRetCode == 1) { Utils.RCWE_AJAX("1", "操作成功"); }
                else { Utils.RCWE_AJAX("0", "操作失败"); }
            }
        }

        /// <summary>
        /// queren
        /// </summary>
        void QueRen()
        {
            BaoCun(false);

            var bllRetCode = new EyouSoft.BLL.PlanStructure.BPlanDiJie().GYS_DiJieQueRen(AnPaiId, YongHuInfo.GysId, YongHuInfo.YongHuId);

            if (bllRetCode == 1) { Utils.RCWE_AJAX("1", "操作成功"); }
            else { Utils.RCWE_AJAX("0", "操作失败"); }
        }

        /// <summary>
        /// init youke rpt
        /// </summary>
        void InitYouKeRpt()
        {
            if (DingDanIds == null || DingDanIds.Length == 0) return;

            var items = new List<EyouSoft.Model.TourStructure.MTourOrderTraveller>();
            var bll = new EyouSoft.BLL.TourStructure.BTourOrder();

            foreach (var dingDanId in DingDanIds)
            {
                if (string.IsNullOrEmpty(dingDanId)) continue;
                var items1 = bll.GetYouKes(dingDanId);
                if (items1 == null || items1.Count == 0) continue;

                items.AddRange(items1);
            }

            if (items != null && items.Count > 0)
            {
                rptYouKe.DataSource = items;
                rptYouKe.DataBind();
            }
            else
            {
                phYouKeEmpty.Visible = true;
            }
        }
        #endregion
    }
}
