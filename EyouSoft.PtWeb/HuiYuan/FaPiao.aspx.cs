//发票信息 汪奇志 2014-10-14
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
    /// 发票信息
    /// </summary>
    public partial class FaPiao : HuiYuanYeMian
    {
        #region attributes
        /// <summary>
        /// 订单编号
        /// </summary>
        string DingDanId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("dingdanid");
            if (string.IsNullOrEmpty(DingDanId)) Utils.RCWE("异常请求");

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.FinStructure.BFaPiao().GetFaPiaoMxInfoByDingDanId(DingDanId);
            if (info == null) Utils.RCWE("异常请求");

            ltrDingDanHao.Text = info.DingDanHao;
            ltrQuDate.Text = info.ChuTuanRiQi.ToString("yyyy-MM-dd");
            ltrTaiTou.Text = info.TaiTou;
            ltrJinE.Text = info.JinE.ToString("F2");
            ltrFaPiaoHao.Text = info.FaPiaoHao;
            ltrKaiPiaoDanWei.Text = info.KaiPiaoDanWei;
            ltrMingXi.Text = info.MingXi;

            ltrFaSongStatus.Text = info.Status.ToString();
            if (info.FaSongTime.HasValue) ltrFaSongShiJian.Text = info.FaSongTime.Value.ToString("yyyy-MM-dd");
            ltrFaSongFangShi.Text = info.FaSongFangShi;
            ltrFaSongYouJiGongSi.Text = info.YouJiGongSiName;
            ltrFaSongYouJiDanHao.Text = info.YouJiDanHao;
            ltrQianShouRen.Text = info.QianShouRenName;
            if (info.QianShouTime.HasValue) ltrQianShouShiJian.Text = info.QianShouTime.Value.ToString("yyyy-MM-dd");

        }
        #endregion
    }
}
