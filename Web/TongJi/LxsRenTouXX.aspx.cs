using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.EnumType.CompanyStructure;
using System.Text;
using EyouSoft.Model.TongJiStructure;

namespace Web.TongJi
{
    public partial class LxsRenTouXX : BackPage
    {
        #region attributes
        protected int pageSize = 20, pageIndex = 1, recordCount = 0;
        protected string tableTitle = "";
        protected StringBuilder strbu = new StringBuilder();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
            initList();
        }

        #region private members
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            var searchModel = new EyouSoft.Model.TongJiStructure.MLxsRenTouXXChaXunInfo();
            searchModel.YYYY = Utils.GetInt(Utils.GetQueryStringValue("year"));
            searchModel.MM = Utils.GetInt(Utils.GetQueryStringValue("month"));
            searchModel.DiQu = (ChengShiDiQu)Utils.GetInt(Utils.GetQueryStringValue("diqu"));
            searchModel.CityId = Utils.GetInt(Utils.GetQueryStringValue("chengshiID"));
            pageIndex = UtilsCommons.GetPagingIndex();

            #region 处理统计表头
            if ((int)searchModel.DiQu >= 0) tableTitle += searchModel.DiQu.ToString();
            if (searchModel.CityId != 0) tableTitle += "-" + new EyouSoft.BLL.CompanyStructure.City().GetModel(searchModel.CityId).CityName.ToString();
            if (searchModel.YYYY != 0) tableTitle += " " + searchModel.YYYY.ToString() + "年";
            if (searchModel.MM != 0) tableTitle += searchModel.MM.ToString() + "月旅行社人头统计明细";

            lbl_serch.Text += tableTitle;
            #endregion

            var items = new EyouSoft.BLL.TongJiStructure.BLxsRenTou().GetLxsRenTouXXs(CurrentUserCompanyID,CurrentZxsId, pageSize, pageIndex, ref recordCount, searchModel);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();
                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;

                rpts.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;
            }
            else
            {
                rpts.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_旅行社人头统计_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
        }
        #endregion

        #region  protect members
        /// <summary>
        /// 根据类型输出html
        /// </summary>
        /// <param name="obj">统计明细列表</param>
        /// <returns></returns>
        protected string getHtml(object t0, object t1, object t2, object t3, object t4, object keHuName, object DingDans,object t5)
        {
            IList<MLxsRenTouXXOrderInfo> t0s = (IList<MLxsRenTouXXOrderInfo>)t0;
            IList<MLxsRenTouXXOrderInfo> t1s = (IList<MLxsRenTouXXOrderInfo>)t1;
            IList<MLxsRenTouXXOrderInfo> t2s = (IList<MLxsRenTouXXOrderInfo>)t2;
            IList<MLxsRenTouXXOrderInfo> t3s = (IList<MLxsRenTouXXOrderInfo>)t3;
            IList<MLxsRenTouXXOrderInfo> t4s = (IList<MLxsRenTouXXOrderInfo>)t4;
            IList<MLxsRenTouXXOrderInfo> t5s = (IList<MLxsRenTouXXOrderInfo>)t5;

            StringBuilder strHTML = new StringBuilder();
            if (t0s != null && t0s.Count > 0)
            {

                int[] tongji = new int[4];
                for (int t = 0; t < t0s.Count; t++)
                {
                    tongji[0] += t0s[t].ChengRen;
                    tongji[1] += t0s[t].ErTong;
                    tongji[2] += t0s[t].QuanPei;
                    tongji[3] += t0s[t].YingEr;
                }

                for (int i = 0; i < t0s.Count; i++)
                {
                    strHTML.AppendFormat("<tr>");
                    if (i == 0)
                    {
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#e3f1fc\" rowspan=\"{0}\">{1}</td>", getCount(DingDans), keHuName);
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}</td>", t0s.Count, t0s[0].YeWuLeiXing.ToString());
                    }

                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" style='height:30px;'>{0}</td>", t0s[i].QuDate.ToString("yyyy-MM-dd"));
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t0s[i].RouteName);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}+{1}+{3}+{2}</td>", t0s[i].ChengRen, t0s[i].ErTong, t0s[i].QuanPei,t0s[i].YingEr);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t0s[i].DuiFangCaoZuoRenName);

                    if (i == 0)
                    {
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}+{2}+{4}+{3}</td>", t0s.Count, tongji[0], tongji[1], tongji[2],tongji[3]);
                    }

                    strHTML.AppendFormat(" </tr>");
                }
            }

            if (t1s != null && t1s.Count > 0)
            {

                int[] tongji = new int[4];
                for (int t = 0; t < t1s.Count; t++)
                {
                    tongji[0] += t1s[t].ChengRen;
                    tongji[1] += t1s[t].ErTong;
                    tongji[2] += t1s[t].QuanPei;
                    tongji[3] += t1s[t].YingEr;
                }

                for (int i = 0; i < t1s.Count; i++)
                {
                    bool b = false;
                    if (string.IsNullOrEmpty(strHTML.ToString())) b = true;
                    strHTML.AppendFormat("<tr>");

                    if (i == 0)
                    {
                        if (b) strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#e3f1fc\" rowspan=\"{0}\">{1}</td>", getCount(DingDans), keHuName);
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}</td>", t1s.Count, t1s[0].YeWuLeiXing.ToString());
                    }

                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" style='height:30px;'>{0}</td>", t1s[i].QuDate.ToString("yyyy-MM-dd"));
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t1s[i].RouteName);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}+{1}+{3}+{2}</td>", t1s[i].ChengRen, t1s[i].ErTong, t1s[i].QuanPei, t1s[i].YingEr);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t1s[i].DuiFangCaoZuoRenName);

                    if (i == 0)
                    {
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}+{2}+{4}+{3}</td>", t1s.Count, tongji[0], tongji[1], tongji[2], tongji[3]);
                    }

                    strHTML.AppendFormat(" </tr>");
                }
            }

            if (t2s != null && t2s.Count > 0)
            {

                int[] tongji = new int[4];
                for (int t = 0; t < t2s.Count; t++)
                {
                    tongji[0] += t2s[t].ChengRen;
                    tongji[1] += t2s[t].ErTong;
                    tongji[2] += t2s[t].QuanPei;
                    tongji[3] += t2s[t].YingEr;
                }

                for (int i = 0; i < t2s.Count; i++)
                {
                    bool b = false;
                    if (string.IsNullOrEmpty(strHTML.ToString())) b = true;
                    strHTML.AppendFormat("<tr>");
                    if (i == 0)
                    {
                        if (b) strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#e3f1fc\" rowspan=\"{0}\">{1}</td>", getCount(DingDans), keHuName);
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}</td>", t2s.Count, t2s[0].YeWuLeiXing.ToString());
                    }

                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" style='height:30px;'>{0}</td>", t2s[i].QuDate.ToString("yyyy-MM-dd"));
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t2s[i].RouteName);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}+{1}+{3}+{2}</td>", t2s[i].ChengRen, t2s[i].ErTong, t2s[i].QuanPei, t2s[i].YingEr);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t2s[i].DuiFangCaoZuoRenName);

                    if (i == 0)
                    {
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}+{2}+{4}+{3}</td>", t2s.Count, tongji[0], tongji[1], tongji[2], tongji[3]);
                    }

                    strHTML.AppendFormat(" </tr>");
                }
            }

            if (t3s != null && t3s.Count > 0)
            {

                int[] tongji = new int[4];
                for (int t = 0; t < t3s.Count; t++)
                {
                    tongji[0] += t3s[t].ChengRen;
                    tongji[1] += t3s[t].ErTong;
                    tongji[2] += t3s[t].QuanPei;
                    tongji[3] += t3s[t].YingEr;
                }

                for (int i = 0; i < t3s.Count; i++)
                {
                    bool b = false;
                    if (string.IsNullOrEmpty(strHTML.ToString())) b = true;
                    strHTML.AppendFormat("<tr>");
                    if (i == 0)
                    {
                        if (b) strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#e3f1fc\" rowspan=\"{0}\">{1}</td>", getCount(DingDans), keHuName);
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}</td>", t3s.Count, t3s[0].YeWuLeiXing.ToString());
                    }

                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" style='height:30px;'>{0}</td>", t3s[i].QuDate.ToString("yyyy-MM-dd"));
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t3s[i].RouteName);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}+{1}+{3}+{2}</td>", t3s[i].ChengRen, t3s[i].ErTong, t3s[i].QuanPei, t3s[i].YingEr);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t3s[i].DuiFangCaoZuoRenName);

                    if (i == 0)
                    {
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}+{2}+{4}+{3}</td>", t3s.Count, tongji[0], tongji[1], tongji[2], tongji[3]);
                    }

                    strHTML.AppendFormat(" </tr>");
                }
            }

            if (t4s != null && t4s.Count > 0)
            {

                int[] tongji = new int[4];
                for (int t = 0; t < t4s.Count; t++)
                {
                    tongji[0] += t4s[t].ChengRen;
                    tongji[1] += t4s[t].ErTong;
                    tongji[2] += t4s[t].QuanPei;
                    tongji[3] += t4s[t].YingEr;
                }

                for (int i = 0; i < t4s.Count; i++)
                {
                    bool b = false;
                    if (string.IsNullOrEmpty(strHTML.ToString())) b = true;
                    strHTML.AppendFormat("<tr>");
                    if (i == 0)
                    {
                        if (b) strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#e3f1fc\" rowspan=\"{0}\">{1}</td>", getCount(DingDans), keHuName);
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}</td>", t4s.Count, t4s[0].YeWuLeiXing.ToString());
                    }

                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" style='height:30px;'>{0}</td>", t4s[i].QuDate.ToString("yyyy-MM-dd"));
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t4s[i].RouteName);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}+{1}+{3}+{2}</td>", t4s[i].ChengRen, t4s[i].ErTong, t4s[i].QuanPei, t4s[i].YingEr);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t4s[i].DuiFangCaoZuoRenName);

                    if (i == 0)
                    {
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}+{2}+{4}+{3}</td>", t4s.Count, tongji[0], tongji[1], tongji[2], tongji[3]);
                    }

                    strHTML.AppendFormat(" </tr>");
                }
            }

            if (t5s != null && t5s.Count > 0)
            {

                int[] tongji = new int[4];
                for (int t = 0; t < t5s.Count; t++)
                {
                    tongji[0] += t5s[t].ChengRen;
                    tongji[1] += t5s[t].ErTong;
                    tongji[2] += t5s[t].QuanPei;
                    tongji[3] += t5s[t].YingEr;
                }

                for (int i = 0; i < t5s.Count; i++)
                {
                    bool b = false;
                    if (string.IsNullOrEmpty(strHTML.ToString())) b = true;
                    strHTML.AppendFormat("<tr>");
                    if (i == 0)
                    {
                        if (b) strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#e3f1fc\" rowspan=\"{0}\">{1}</td>", getCount(DingDans), keHuName);
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}</td>", t5s.Count, t5s[0].YeWuLeiXing.ToString());
                    }

                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" style='height:30px;'>{0}</td>", t5s[i].QuDate.ToString("yyyy-MM-dd"));
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t5s[i].RouteName);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}+{1}+{3}+{2}</td>", t5s[i].ChengRen, t5s[i].ErTong, t5s[i].QuanPei, t5s[i].YingEr);
                    strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\">{0}</td>", t5s[i].DuiFangCaoZuoRenName);

                    if (i == 0)
                    {
                        strHTML.AppendFormat("<td align=\"center\" bgcolor=\"#E3F1FC\" rowspan={0}>{1}+{2}+{4}+{3}</td>", t5s.Count, tongji[0], tongji[1], tongji[2], tongji[3]);
                    }

                    strHTML.AppendFormat(" </tr>");
                }
            }

            return strHTML.ToString();
        }

        /// <summary>
        /// 返回组团社跨行数
        /// </summary>
        /// <param name="obj">订单数</param>
        /// <returns></returns>
        protected int getCount(object obj)
        {
            IList<MLxsRenTouXXOrderInfo> count = (IList<MLxsRenTouXXOrderInfo>)obj;
            if (count == null) return 1;
            return count.Count;
        }
        #endregion


    }
}
