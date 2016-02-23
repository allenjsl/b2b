//兑换订单明细 汪奇志 2014-09-11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.PtWeb.HuiYuan
{
    /// <summary>
    /// 兑换订单明细
    /// </summary>
    public partial class JiFenDingDanXX : HuiYuanYeMian
    {
        #region attributes
        /// <summary>
        /// 订单编号
        /// </summary>
        string DingDanId = string.Empty;
        /// <summary>
        /// 商品编号
        /// </summary>
        string ShangPinId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("dingdanid");

            if (Utils.GetQueryStringValue("dotype") == "quxiao") QuXiaoDingDan();

            if (string.IsNullOrEmpty(DingDanId)) Utils.RCWE("异常请求");

            InitDingDanInfo();
            InitShangPinInfo();
        }

        #region private members
        /// <summary>
        /// init dingdan info
        /// </summary>
        void InitDingDanInfo()
        {
            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDanInfo(DingDanId);
            if (info == null) Utils.RCWE("异常请求");
            if (info.XiaDanRenId != YongHuInfo.YongHuId) Utils.RCWE("异常请求");

            ShangPinId = info.ShangPinId;
            ltrJiaoYiHao.Text = info.JiaoYiHao;
            ltrShuLiang.Text = info.ShuLiang.ToString();
            ltrJiFen1.Text = info.JiFen1.ToString();
            ltrJiFen2.Text = info.JiFen2.ToString();
            ltrShouJianRenName.Text = info.LxrXingMing;
            ltrShouJianRenShouJi.Text = info.LxrShouJi;
            ltrShouJianRenDianHua.Text = info.LxrDianHua;
            ltrShouJianRenYouBian.Text = info.LxrYouBian;
            ltrShouJianRenYouXiang.Text = info.LxrYouXiang;
            ltrXiaDanBeiZhu.Text = info.XiaDanBeiZhu;

            #region dizhi
            var shengFenInfo = new EyouSoft.BLL.CompanyStructure.Province().GetModel(info.LxrProvinceId);
            var chengShiInfo = new EyouSoft.BLL.CompanyStructure.City().GetModel(info.LxrCityId);
            string diZhi = string.Empty;
            if (shengFenInfo != null) diZhi += shengFenInfo.ProvinceName;
            if (chengShiInfo != null) diZhi += "&nbsp;" + chengShiInfo.CityName;
            diZhi += info.LxrDiZhi;
            ltrShouJianRenDiZhi.Text = diZhi;
            #endregion

            InitCaoZuo(info);
            InitTiShiXinXi(info);
        }

        /// <summary>
        /// init shangpin info
        /// </summary>
        void InitShangPinInfo()
        {
            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetShangPinInfo(ShangPinId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求"));

            ltrShangPinMingCheng.Text = info.MingCheng;
            ltrShangPinLeiXing.Text = info.LeiXing.ToString();
            ltrShangPinJiaGe.Text = info.JiaGe.ToString("F2");
            ltrShangPinJiFen.Text = info.JiFen.ToString();
            ltrShangPinBianMa.Text = info.BianMa;
        }

        /// <summary>
        /// init caozuo
        /// </summary>
        /// <param name="info"></param>
        void InitCaoZuo(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            string _quXiao = "<a href=\"javascript:void(0)\" id=\"i_a_quxiao\" class=\"baocun\">取 消</a>&nbsp;&nbsp;";

            switch (info.Status)
            {
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.未确认:
                    ltrCaoZuo.Text = _quXiao;
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已确认:
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已发货:
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已取消:
                    break;
            }
        }

        /// <summary>
        /// 初始化提示信息
        /// </summary>
        /// <param name="info"></param>
        void InitTiShiXinXi(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("下单时间：{0}。", info.IssueTime.ToString("yyyy-MM-dd HH:mm"));

            s.AppendFormat("当前订单状态为：<b>{0}</b>。", info.Status);

            if (info.Status == EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已发货)
            {
                s.AppendFormat("快递信息：" + info.KuaiDi + "。");
            }

            ltrTiShiXinXi.Text = s.ToString();
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        void QuXiaoDingDan()
        {
            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDanInfo(DingDanId);

            if (info == null || info.XiaDanRenId != YongHuInfo.YongHuId) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：你不能取消该订单。"));

            if (info.Status != EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.未确认) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：你不能取消该订单。"));

            info.Status = EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已取消;
            info.LatestOperatorId = YongHuInfo.YongHuId;
            info.LatestTime = DateTime.Now;

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().PT_SheZhiDingDanStatus(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
