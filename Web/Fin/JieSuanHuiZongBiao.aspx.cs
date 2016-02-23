//汪奇志 2013-01-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-结算汇总表
    /// </summary>
    public partial class JieSuanHuiZongBiao : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            string doType = Utils.GetQueryStringValue("doType");
            if (UtilsCommons.IsToXls() && doType == "toxls_jiesuanhuizongbiao") { ToXls_JieSuanHuiZongBiao(); }

            InitRpts();
            InitQuYu();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_结算汇总表_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_结算汇总表_栏目, true);
            }
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            object[] heJi;

            var items = new EyouSoft.BLL.FinStructure.BFin().GetTuanDuiJieSuans(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                var shouRuJinEHeJi = (decimal)heJi[0] + (decimal)heJi[1];
                var zhiChuJinEHeJi = (decimal)heJi[2] + (decimal)heJi[3];
                decimal maoLiJinE = shouRuJinEHeJi - zhiChuJinEHeJi;
                decimal maoLiLv = 0;
                if (shouRuJinEHeJi != 0) maoLiLv = maoLiJinE / shouRuJinEHeJi;

                ltrShuLiangHeJi.Text = heJi[4].ToString();
                ltrZhanWeiShuLiangHeJi.Text = heJi[5].ToString();                
                ltrShouRuJinEHeJi.Text = ToMoneyString(shouRuJinEHeJi);
                ltrZhiChuJinEHeJi.Text = ToMoneyString(zhiChuJinEHeJi);
                ltrMaoLiJinEHeJi.Text = ToMoneyString(maoLiJinE);
                ltrMaoLiLv.Text = (maoLiLv * 100).ToString("F2") + "%";
                
                rpts.Visible = phHeJi.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                rpts.Visible = phHeJi.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.FinStructure.MTuanDuiJieSuanChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MTuanDuiJieSuanChaXunInfo();

            info.EQuDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEQuDate"));
            info.SQuDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSQuDate"));
            info.AreaId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuYu"));
            info.QuJiaoTongId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuJiaoTong"));
            info.QuDepProvinceId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuDepProvince"));
            info.QuDepCityId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuDepCity"));
            info.QuArrProvinceId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuArrProvince"));
            info.QuArrCityId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuArrCity"));
            info.KongWeiZhuangTai = (EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai), Utils.GetQueryStringValue("txtKongWeiZhuangTai"));
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 导出结算汇总表
        /// </summary>
        void ToXls_JieSuanHuiZongBiao()
        {
            StringBuilder s = new StringBuilder();
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            int _recordCount = 0;

            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);
            var chaXun = GetChaXunInfo();
            object[] heJi;
            var items = new EyouSoft.BLL.FinStructure.BFin().GetTuanDuiJieSuans(CurrentUserCompanyID, toXlsRecordCount, 1, ref _recordCount, chaXun, out heJi);


            if (items == null || items.Count == 0) ResponseToXls(string.Empty);

            int i = 1;
            s.Append("序号\t控位号\t出团日期\t线路区域\t去程交通\t去程出发地\t去程目的地\t数量\t占位数\t收入金额\t支出金额\t毛利\t毛利率\n");
            foreach (var item in items)
            {
                s.Append(i + "\t");
                s.Append(item.KongWeiCode + "\t");
                s.Append(item.QuDate.ToString("yyyy-MM-dd") + "(" + Utils.ConvertWeekDayToChinese(item.QuDate) + ")" + "\t");
                s.Append(item.AreaName + "\t");
                s.Append(item.QuJiaoTongName + "\t");
                s.Append(item.QuDepCityName + "\t");
                s.Append(item.QuArrCityName + "\t");
                s.Append(item.ShuLiang + "\t");
                s.Append(item.ZhanWeiShuLiang + "\t");
                s.Append((item.ShouRuJinE + item.QiTaShouRuJinE).ToString("F2") + "\t");
                s.Append((item.ZhiChuJinE + item.QiTaZhiChuJinE).ToString("F2") + "\t");
                s.Append(item.MaoLiJinE + "\t");
                s.Append(item.MaoLiLv + "\n");
                i++;
            }

            ResponseToXls(s.ToString());
        }

        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetZxsZhanDians(CurrentZxsId);

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<option value=\"\">请选择</option>");

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var item1 in item.Zxlbs)
                    {
                        s.AppendFormat("<optgroup label=\"{0}\">", item.ZhanDianName + "站-" + item1.ZxlbName);

                        foreach (var item2 in item1.QuYus)
                        {
                            s.AppendFormat("<option value=\"{0}\">{1}</option>", item2.QuYuId, item2.QuYuName);
                        }

                        s.AppendFormat("</optgroup>");
                    }
                }
            }

            ltrQuYuOption.Text = s.ToString();
        }
        #endregion

        #region protected members        

        /// <summary>
        /// 获取去程交通下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetQuJiaoTongOptions()
        {
            int _quJiaoTongId = Utils.GetInt(Utils.GetQueryStringValue("txtQuJiaoTong"));
            StringBuilder s = new StringBuilder();

            var items = new EyouSoft.BLL.CompanyStructure.BCompanyTraffic().GetList(CurrentUserCompanyID);

            s.Append("<option value=\"\">-请选择-</option>");

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item.TrafficId, item.TrafficId == _quJiaoTongId ? "selected=\"selected\"" : "", item.TrafficName);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取控位号
        /// </summary>
        /// <param name="kongWeiCode">控位号</param>
        /// <param name="kongWeiZhuangTai">控位状态</param>
        /// <returns></returns>
        protected string GetKongWeiCode(object kongWeiCode, object kongWeiZhuangTai)
        {
            if (kongWeiCode == null || kongWeiZhuangTai == null) return string.Empty;

            var _kongWeiZhuangTai = (EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)kongWeiZhuangTai;

            if (_kongWeiZhuangTai == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.正常) return kongWeiCode.ToString();

            return "<b title=\"已核算结束\">" + kongWeiCode.ToString() + "</b>";
        }
        #endregion
    }
}
