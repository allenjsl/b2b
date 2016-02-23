using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.TeamPlan
{
    /// <summary>
    /// 团队结算页面
    /// </summary>
    public partial class TeamAccounts : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 返回的url
        /// </summary>
        private string _returnUrl = "/TeamPlan/PlanList.aspx";

        private decimal _shouRu;
        private decimal _qiTaShouRu;
        private decimal _zhiChu;
        private decimal _qiTaZhiChu;
        private decimal _maoLi;
        private decimal _maoLiLv;
        /// <summary>
        /// 团队结算权限
        /// </summary>
        bool Privs_TuanDuiJieSuan = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Utils.GetQueryStringValue("type");
            string tourId = Utils.GetQueryStringValue("tourId");
            _returnUrl = Utils.GetQueryStringValue("rurl");
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(tourId)) return;

            InitPrivs(type);

            if (!IsPostBack)
            {
                switch (type.ToLower())
                {
                    case "hotel":
                        ltrTitle.Text = "代订酒店";
                        break;
                    case "tour":
                        ltrTitle.Text = "常规业务";
                        break;
                    default:
                        Response.Redirect(_returnUrl);
                        break;
                }

                InitShouRu(tourId);
                InitZhiChu(tourId);
                InitQiTaShouRu(tourId);
                InitQiTaZhiChu(tourId);

                InitLtr();
            }
        }

        /// <summary>
        /// 初始化合计信息
        /// </summary>
        private void InitLtr()
        {
            /*ltrShouRuHeJi.Text = _shouRu > 0 ? this.ToMoneyString(_shouRu) : string.Empty;
            ltrZhiChuHeJi.Text = _zhiChu > 0 ? this.ToMoneyString(_zhiChu) : string.Empty;
            ltrQiTaShouRuHeJi.Text = _qiTaShouRu > 0 ? this.ToMoneyString(_qiTaShouRu) : string.Empty;
            ltrQiTaZhiChuHeJi.Text = _qiTaZhiChu > 0 ? this.ToMoneyString(_qiTaZhiChu) : string.Empty;

            _maoLi = _shouRu + _qiTaShouRu - _zhiChu - _qiTaZhiChu;
            ltrMaoLi.Text = _maoLi > 0 ? this.ToMoneyString(_maoLi) : string.Empty;
            if (_shouRu + _qiTaShouRu > 0)
                _maoLiLv = _maoLi / (_shouRu + _qiTaShouRu);
            ltrMaoLiLv.Text = _maoLiLv > 0 ? (_maoLiLv * 100).ToString("F2") + "%" : string.Empty;*/

            ltrShouRuHeJi.Text = this.ToMoneyString(_shouRu);
            ltrZhiChuHeJi.Text = this.ToMoneyString(_zhiChu) ;
            ltrQiTaShouRuHeJi.Text = this.ToMoneyString(_qiTaShouRu);
            ltrQiTaZhiChuHeJi.Text = this.ToMoneyString(_qiTaZhiChu);

            _maoLi = _shouRu + _qiTaShouRu - _zhiChu - _qiTaZhiChu;
            ltrMaoLi.Text = this.ToMoneyString(_maoLi);
            if (_shouRu + _qiTaShouRu > 0) _maoLiLv = _maoLi / (_shouRu + _qiTaShouRu);
            else _maoLiLv = 0;
            ltrMaoLiLv.Text = (_maoLiLv * 100).ToString("F2") + "%";
        }

        /// <summary>
        /// 初始化收入
        /// </summary>
        /// <param name="tourId"></param>
        private void InitShouRu(string tourId)
        {
            if (string.IsNullOrEmpty(tourId)) return;
            var list = new EyouSoft.BLL.FinStructure.BFin().GetKongWeiShouRus(tourId);
            rptShouRu.DataSource = list;
            rptShouRu.DataBind();

            if (list != null && list.Any())
            {
                _shouRu = list.Sum(c => (c.JinE));
            }
        }

        /// <summary>
        /// 初始化支出
        /// </summary>
        /// <param name="tourId"></param>
        private void InitZhiChu(string tourId)
        {
            if (string.IsNullOrEmpty(tourId)) return;
            var list = new EyouSoft.BLL.FinStructure.BFin().GetKongWeiZhiChus(tourId);

            rptZhiChu.DataSource = list;
            rptZhiChu.DataBind();

            if (list != null && list.Any())
            {
                _zhiChu = list.Sum(c => (c.JinE));
            }
        }

        /// <summary>
        /// 初始化其他收入
        /// </summary>
        /// <param name="tourId"></param>
        private void InitQiTaShouRu(string tourId)
        {
            if (string.IsNullOrEmpty(tourId)) return;
            var list = new EyouSoft.BLL.FinStructure.BQiTaShouRu().GetKongWeiQiTaShouRus(tourId);

            rptQiTaShouRu.DataSource = list;
            rptQiTaShouRu.DataBind();

            if (list != null && list.Any())
            {
                _qiTaShouRu = list.Sum(c => (c.JinE));
            }
        }

        /// <summary>
        /// 初始化其他支出
        /// </summary>
        /// <param name="tourId"></param>
        private void InitQiTaZhiChu(string tourId)
        {
            if (string.IsNullOrEmpty(tourId)) return;
            var list = new EyouSoft.BLL.FinStructure.BQiTaZhiChu().GetKongWeiQiTaZhiChus(tourId);

            rptQiTaZhiChu.DataSource = list;
            rptQiTaZhiChu.DataBind();

            if (list != null && list.Any())
            {
                _qiTaZhiChu = list.Sum(c => (c.JinE));
            }
        }

        protected void btrReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect(_returnUrl);
        }

        /// <summary>
        /// init privs
        /// </summary>
        /// <param name="_t">type</param>
        void InitPrivs(string _t)
        {
            EyouSoft.Model.EnumType.PrivsStructure.Privs3 privs3 = EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_团队结算;
            if (_t == "hotel") privs3 = EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_代订酒店_团队结算;
            Privs_TuanDuiJieSuan=CheckGrant(privs3);
            if (!Privs_TuanDuiJieSuan) Utils.ResponseNoPermit(privs3, false);
        }
    }
}
