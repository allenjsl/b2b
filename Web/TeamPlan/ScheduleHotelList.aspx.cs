using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.EnumType.TourStructure;

namespace Web.TeamPlan
{
    /// <summary>
    /// 代订酒店管理
    /// </summary>
    public partial class ScheduleHotel : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        private const int PageSize = 10;

        private int _pageIndex = 1;

        private int _recordCount;

        protected bool IsAdd;

        protected bool IsEdit;

        protected bool IsDel;
        /// <summary>
        /// 团队结算权限
        /// </summary>
        protected char Privs_TuanDuiJieSuan = '0';
        /// <summary>
        /// 核算结束权限
        /// </summary>
        bool Privs_HeSuanJieShu = false;
        /// <summary>
        /// 取消核算结束权限
        /// </summary>
        bool Privs_QuXiaoHeSuanJieShu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {            
            InitPrivs();

            string doType = Utils.GetQueryStringValue("doType");
            string hid = Utils.GetQueryStringValue("hid");

            switch (doType)
            {
                case "del": DeleteHotel(hid); break;
                case "hesuanjieshu": HeSuanJieShu(); break;
                case "quxiaohesuanjieshu": QuXiaoHeSuanJieShu(); break;
                default: break;
            }

            InitPage();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_栏目, true);
                return;
            }

            //判断权限
            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_新增))
            {
                IsAdd = true;
            }
            //判断权限
            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_修改))
            {
                IsEdit = true;
            }
            //判断权限
            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_删除))
            {
                IsDel = true;
            }

            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_团队结算)) Privs_TuanDuiJieSuan = '1';

            Privs_HeSuanJieShu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_核算结束);
            Privs_QuXiaoHeSuanJieShu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_取消核算结束);

            phHeSuanJieShu.Visible = Privs_HeSuanJieShu;
            phQuXiaoHeSuanJieShu.Visible = Privs_QuXiaoHeSuanJieShu;
        }

        /// <summary>
        /// 核算结束
        /// </summary>
        void HeSuanJieShu()
        {
            if (!Privs_HeSuanJieShu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string[] items = Utils.GetFormValues("txtKongWeiId[]");

            if (items == null || items.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：错误的请求。"));

            var bll = new EyouSoft.BLL.TourStructure.BTour();
            foreach (var item in items)
            {
                bll.SetKongWeiZhuangTai(item, KongWeiZhuangTai.核算结束, CurrentUserCompanyID, CurrentZxsId, BusinessType.代订酒店);
            }

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功：已核算结束。"));
        }

        /// <summary>
        /// 取消核算结束
        /// </summary>
        void QuXiaoHeSuanJieShu()
        {
            if (!Privs_QuXiaoHeSuanJieShu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string[] items = Utils.GetFormValues("txtKongWeiId[]");

            if (items == null || items.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：错误的请求。"));

            var bll = new EyouSoft.BLL.TourStructure.BTour();
            foreach (var item in items)
            {
                bll.SetKongWeiZhuangTai(item, KongWeiZhuangTai.正常,CurrentUserCompanyID,CurrentZxsId, BusinessType.代订酒店);
            }

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功：已取消核算结束。"));
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        void InitPage()
        {
            var chaXun = new EyouSoft.Model.TourStructure.MSearchTourOrderHotel();
            chaXun.HotelName = Utils.GetQueryStringValue("hName");
            chaXun.JiaoYiHao = Utils.GetQueryStringValue("txtJiaoYiHao");
            chaXun.KongWeiZhuangTai = (KongWeiZhuangTai?)Utils.GetEnumValueNull(typeof(KongWeiZhuangTai), Utils.GetQueryStringValue("txtKongWeiZhuangTai"));
            chaXun.LBeginDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("sd"));
            chaXun.LEndDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("ed"));
            chaXun.OrderCode=Utils.GetQueryStringValue("ono");
            chaXun.TravellerName=Utils.GetQueryStringValue("cName");
            chaXun.ZxsId = CurrentZxsId;

            var list = new EyouSoft.BLL.TourStructure.BTourOrderHotel().GetTourOrderHotel(CurrentUserCompanyID, PageSize, _pageIndex, ref _recordCount, chaXun);

            UtilsCommons.Paging(PageSize, ref _pageIndex, _recordCount);
            rptHotel.DataSource = list;
            rptHotel.DataBind();
            
            page1.intPageSize = PageSize;
            page1.intRecordCount = _recordCount;
            page1.CurrencyPage = _pageIndex;
        }

        /// <summary>
        /// 删除酒店代订
        /// </summary>
        /// <param name="hid">酒店代订编号</param>
        void DeleteHotel(string hid)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(hid))
            {
                str = UtilsCommons.AjaxReturnJson("0", "参数丢失，请刷新页面后重试！");
                this.RCWE(str);
                return;
            }
            var ids = hid.Split(',');
            if (!ids.Any())
            {
                str = UtilsCommons.AjaxReturnJson("0", "参数丢失，请刷新页面后重试！");
                this.RCWE(str);
                return;
            }

            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_删除))
            {
                str = UtilsCommons.AjaxReturnJson("0", "您没有删除权限，请联系管理员！");
                this.RCWE(str);
                return;
            }
            int e = 0; int n = 0; int heSuanJieShuJiShuQi = 0;
            foreach (var t in ids)
            {
                if (string.IsNullOrEmpty(t))
                    continue;

                int r = new EyouSoft.BLL.TourStructure.BTourOrderHotel().DeleteTourOrderHotel(hid);

                if (r == -1) n++;
                if (r == 0) e++;
                if (r == -19) heSuanJieShuJiShuQi++;
            }
            if (n > 0) str += string.Format("{0}条记录已存在收款或者付款登记，不允许删除！<br />", n);
            if (e > 0) str += string.Format("{0}条记录删除失败！<br />", e);
            if (heSuanJieShuJiShuQi > 0) str += string.Format("{0}条记录已核算结束，不允许删除！<br />", heSuanJieShuJiShuQi);

            str += string.Format("{0}删除成功！", (e > 0 || n > 0 || heSuanJieShuJiShuQi > 0) ? "其他" : "");

            this.RCWE(UtilsCommons.AjaxReturnJson("1", str));
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取行序号
        /// </summary>
        /// <param name="index">行索引</param>
        /// <returns></returns>
        protected int GetIndex(int index)
        {
            return PageSize * (_pageIndex - 1) + index + 1;
        }

        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="orderCode">订单号</param>
        /// <param name="kongWeiZhuangTai">控位状态</param>
        /// <returns></returns>
        protected string GetOrderCode(object orderCode, object kongWeiZhuangTai)
        {
            if (orderCode == null || kongWeiZhuangTai == null) return string.Empty;

            var _kongWeiZhuangTai = (KongWeiZhuangTai)kongWeiZhuangTai;

            if (_kongWeiZhuangTai == KongWeiZhuangTai.正常) return orderCode.ToString();

            return "<b title=\"已核算结束\">" + orderCode.ToString() + "</b>";
        }
        #endregion
    }
}
