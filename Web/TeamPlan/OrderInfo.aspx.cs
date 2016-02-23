using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.TeamPlan
{
    /// <summary>
    /// 创建人：刘飞
    /// 时间：2012-12-05
    /// </summary>
    public partial class OrderInfo : BackPage
    {
        /// <summary>
        /// 控位编号
        /// </summary>
        string KongWeiId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            KongWeiId = Utils.GetQueryStringValue("kongweiId");

            if (string.IsNullOrEmpty(KongWeiId)) RCWE("异常请求");

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            EyouSoft.BLL.TourStructure.BTourOrder bll = new EyouSoft.BLL.TourStructure.BTourOrder();
            EyouSoft.Model.EnumType.TourStructure.OrderStatus? status;
            switch (Utils.GetQueryStringValue("orderstatus"))
            {
                case "yuliu": status = EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位; break;
                case "shishou": status = EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交; break;
                case "mingdanbuquan": status = EyouSoft.Model.EnumType.TourStructure.OrderStatus.名单不全; break;
                case "weiqueren": status = EyouSoft.Model.EnumType.TourStructure.OrderStatus.未确认; break;
                case "shenqing": status = EyouSoft.Model.EnumType.TourStructure.OrderStatus.申请中; break;
                default: status = null; break;
            }

            IList<EyouSoft.Model.TourStructure.MTourOrder> list = bll.GetTourOrderList(KongWeiId, status);
            if (list != null && list.Count > 0)
            {
                this.rptList.DataSource = list;
                this.rptList.DataBind();
            }
        }
        #endregion

        #region protected members
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

        /// <summary>
        /// get routename
        /// </summary>
        /// <param name="routeName"></param>
        /// <param name="yeWuLeiXing"></param>
        /// <returns></returns>
        protected string GetRouteName(object routeName, object yeWuLeiXing)
        {
            if (routeName == null && yeWuLeiXing == null) return string.Empty;

            if (routeName == null) return yeWuLeiXing.ToString();

            string _routeName = routeName.ToString();

            if (!string.IsNullOrEmpty(_routeName)) return _routeName;

            return yeWuLeiXing.ToString();
        }
        #endregion

    }
}
