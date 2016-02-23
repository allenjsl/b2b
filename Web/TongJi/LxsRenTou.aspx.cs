using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.EnumType.CompanyStructure;

namespace Web.TongJi
{
    public partial class LxsRenTou : BackPage
    {
        protected StringBuilder strBu = new StringBuilder();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetFormValue("istoxls") == "1") ToXls();
            initList();
        }

        #region   private members
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            bool IsEmpty = true;
            var searchModel = new EyouSoft.Model.TongJiStructure.MCaoZuoRenChaXunInfo();
            int year = Utils.GetInt(Utils.GetQueryStringValue("txtYear")) == 0 ? DateTime.Now.Year : Utils.GetInt(Utils.GetQueryStringValue("txtYear"));

            ltrTableTitle.Text = year.ToString();

            var items = Enum.GetValues(typeof(ChengShiDiQu));
            int[] m1 = new int[4], m2 = new int[4], m3 = new int[4], m4 = new int[4], m5 = new int[4], m6 = new int[4], m7 = new int[4], m8 = new int[4], m9 = new int[4], m10 = new int[4], m11 = new int[4], m12 = new int[4];

            foreach (var j in items)
            {
                var item = new EyouSoft.BLL.TongJiStructure.BLxsRenTou().GetLxsRenTous(CurrentUserCompanyID, CurrentZxsId, year, (ChengShiDiQu)j, new EyouSoft.Model.TongJiStructure.MLxsRenTourChaXunInfo { });
                if (item != null && item.Count > 0)
                {
                    #region
                    int[] i1 = new int[4], i2 = new int[4], i3 = new int[4], i4 = new int[4], i5 = new int[4], i6 = new int[4], i7 = new int[4], i8 = new int[4], i9 = new int[4], i10 = new int[4], i11 = new int[4], i12 = new int[4];
                    int dqhjcr = 0, dqhjer = 0, dqhjqp = 0, dqhjyr = 0, zjhjcr = 0, zjhjer = 0, zjhjqp = 0, zjhjyr = 0;
                    #endregion

                    IsEmpty = false;
                    strBu.AppendFormat("<tr>");
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\" rowspan=\"{1}\"><p> {0}</p> <input  type=\"hidden\" value=\"\" name=\"did\"/></td>", ((ChengShiDiQu)j).ToString(), item.Count + 1);
                    for (int i = 0; i < item.Count; i++)
                    {
                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\" height=\"30\"> {0} </td>", item[i].CityName);
                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\" class=\"yeartd\">{0}</td>", item[i].Year);
                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\" dataMonth=\"1\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M1.ChengRen, item[i].M1.ErTong, item[i].M1.QuanPei, item[i].CityId, (int)j, item[i].M1.YingEr);
                        i1[0] += item[i].M1.ChengRen;
                        i1[1] += item[i].M1.ErTong;
                        i1[2] += item[i].M1.QuanPei;
                        i1[3] += item[i].M1.YingEr;

                        dqhjcr += item[i].M1.ChengRen;
                        dqhjer += item[i].M1.ErTong;
                        dqhjqp += item[i].M1.QuanPei;
                        dqhjyr += item[i].M1.YingEr;
                        m1[0] += item[i].M1.ChengRen;
                        m1[1] += item[i].M1.ErTong;
                        m1[2] += item[i].M1.QuanPei;
                        m1[3] += item[i].M1.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"2\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M2.ChengRen, item[i].M2.ErTong, item[i].M2.QuanPei, item[i].CityId, (int)j, item[i].M2.YingEr);
                        i2[0] += item[i].M2.ChengRen;
                        i2[1] += item[i].M2.ErTong;
                        i2[2] += item[i].M2.QuanPei;
                        i2[3] += item[i].M2.YingEr;
                        dqhjcr += item[i].M2.ChengRen;
                        dqhjer += item[i].M2.ErTong;
                        dqhjqp += item[i].M2.QuanPei;
                        dqhjyr += item[i].M2.YingEr;
                        m2[0] += item[i].M2.ChengRen;
                        m2[1] += item[i].M2.ErTong;
                        m2[2] += item[i].M2.QuanPei;
                        m2[3] += item[i].M2.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"3\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M3.ChengRen, item[i].M3.ErTong, item[i].M3.QuanPei, item[i].CityId, (int)j, item[i].M3.YingEr);
                        i3[0] += item[i].M3.ChengRen;
                        i3[1] += item[i].M3.ErTong;
                        i3[2] += item[i].M3.QuanPei;
                        i3[3] += item[i].M3.YingEr;

                        dqhjcr += item[i].M3.ChengRen;
                        dqhjer += item[i].M3.ErTong;
                        dqhjqp += item[i].M3.QuanPei;
                        dqhjyr += item[i].M3.YingEr;
                        m3[0] += item[i].M3.ChengRen;
                        m3[1] += item[i].M3.ErTong;
                        m3[2] += item[i].M3.QuanPei;
                        m3[3] += item[i].M3.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"4\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M4.ChengRen, item[i].M4.ErTong, item[i].M4.QuanPei, item[i].CityId, (int)j, item[i].M4.YingEr);
                        i4[0] += item[i].M4.ChengRen;
                        i4[1] += item[i].M4.ErTong;
                        i4[2] += item[i].M4.QuanPei;
                        i4[3] += item[i].M4.YingEr;
                        dqhjcr += item[i].M4.ChengRen;
                        dqhjer += item[i].M4.ErTong;
                        dqhjqp += item[i].M4.QuanPei;
                        dqhjyr += item[i].M4.YingEr;
                        m4[0] += item[i].M4.ChengRen;
                        m4[1] += item[i].M4.ErTong;
                        m4[2] += item[i].M4.QuanPei;
                        m4[3] += item[i].M4.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"5\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M5.ChengRen, item[i].M5.ErTong, item[i].M5.QuanPei, item[i].CityId, (int)j, item[i].M5.YingEr);
                        i5[0] += item[i].M5.ChengRen;
                        i5[1] += item[i].M5.ErTong;
                        i5[2] += item[i].M5.QuanPei;
                        i5[3] += item[i].M5.YingEr;

                        dqhjcr += item[i].M5.ChengRen;
                        dqhjer += item[i].M5.ErTong;
                        dqhjqp += item[i].M5.QuanPei;
                        dqhjyr += item[i].M5.YingEr;
                        m5[0] += item[i].M5.ChengRen;
                        m5[1] += item[i].M5.ErTong;
                        m5[2] += item[i].M5.QuanPei;
                        m5[3] += item[i].M5.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"6\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M6.ChengRen, item[i].M6.ErTong, item[i].M6.QuanPei, item[i].CityId, (int)j, item[i].M6.YingEr);
                        i6[0] += item[i].M6.ChengRen;
                        i6[1] += item[i].M6.ErTong;
                        i6[2] += item[i].M6.QuanPei;
                        i6[3] += item[i].M6.YingEr;
                        dqhjcr += item[i].M6.ChengRen;
                        dqhjer += item[i].M6.ErTong;
                        dqhjqp += item[i].M6.QuanPei;
                        dqhjyr += item[i].M6.YingEr;
                        m6[0] += item[i].M6.ChengRen;
                        m6[1] += item[i].M6.ErTong;
                        m6[2] += item[i].M6.QuanPei;
                        m6[3] += item[i].M6.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"7\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M7.ChengRen, item[i].M7.ErTong, item[i].M7.QuanPei, item[i].CityId, (int)j, item[i].M7.YingEr);
                        i7[0] += item[i].M7.ChengRen;
                        i7[1] += item[i].M7.ErTong;
                        i7[2] += item[i].M7.QuanPei;
                        i7[3] += item[i].M7.YingEr;
                        dqhjcr += item[i].M7.ChengRen;
                        dqhjer += item[i].M7.ErTong;
                        dqhjqp += item[i].M7.QuanPei;
                        dqhjyr += item[i].M7.YingEr;
                        m7[0] += item[i].M7.ChengRen;
                        m7[1] += item[i].M7.ErTong;
                        m7[2] += item[i].M7.QuanPei;
                        m7[3] += item[i].M7.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"8\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M8.ChengRen, item[i].M8.ErTong, item[i].M8.QuanPei, item[i].CityId, (int)j, item[i].M8.YingEr);
                        i8[0] += item[i].M8.ChengRen;
                        i8[1] += item[i].M8.ErTong;
                        i8[2] += item[i].M8.QuanPei;
                        i8[3] += item[i].M8.YingEr;
                        dqhjcr += item[i].M8.ChengRen;
                        dqhjer += item[i].M8.ErTong;
                        dqhjqp += item[i].M8.QuanPei;
                        dqhjyr += item[i].M8.YingEr;
                        m8[0] += item[i].M8.ChengRen;
                        m8[1] += item[i].M8.ErTong;
                        m8[2] += item[i].M8.QuanPei;
                        m8[3] += item[i].M8.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"9\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M9.ChengRen, item[i].M9.ErTong, item[i].M9.QuanPei, item[i].CityId, (int)j, item[i].M9.YingEr);
                        i9[0] += item[i].M9.ChengRen;
                        i9[1] += item[i].M9.ErTong;
                        i9[2] += item[i].M9.QuanPei;
                        i9[3] += item[i].M9.YingEr;
                        dqhjcr += item[i].M9.ChengRen;
                        dqhjer += item[i].M9.ErTong;
                        dqhjqp += item[i].M9.QuanPei;
                        dqhjyr += item[i].M9.YingEr;
                        m9[0] += item[i].M9.ChengRen;
                        m9[1] += item[i].M9.ErTong;
                        m9[2] += item[i].M9.QuanPei;
                        m9[3] += item[i].M9.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"10\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M10.ChengRen, item[i].M10.ErTong, item[i].M10.QuanPei, item[i].CityId, (int)j, item[i].M10.YingEr);
                        i10[0] += item[i].M10.ChengRen;
                        i10[1] += item[i].M10.ErTong;
                        i10[2] += item[i].M10.QuanPei;
                        i10[3] += item[i].M10.YingEr;
                        dqhjcr += item[i].M10.ChengRen;
                        dqhjer += item[i].M10.ErTong;
                        dqhjqp += item[i].M10.QuanPei;
                        dqhjyr += item[i].M10.YingEr;
                        m10[0] += item[i].M10.ChengRen;
                        m10[1] += item[i].M10.ErTong;
                        m10[2] += item[i].M10.QuanPei;
                        m10[3] += item[i].M10.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"11\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M11.ChengRen, item[i].M11.ErTong, item[i].M11.QuanPei, item[i].CityId, (int)j, item[i].M11.YingEr);
                        i11[0] += item[i].M11.ChengRen;
                        i11[1] += item[i].M11.ErTong;
                        i11[2] += item[i].M11.QuanPei;
                        i11[3] += item[i].M11.YingEr;
                        dqhjcr += item[i].M11.ChengRen;
                        dqhjer += item[i].M11.ErTong;
                        dqhjqp += item[i].M11.QuanPei;
                        dqhjyr += item[i].M11.YingEr;
                        m11[0] += item[i].M11.ChengRen;
                        m11[1] += item[i].M11.ErTong;
                        m11[2] += item[i].M11.QuanPei;
                        m11[3] += item[i].M11.YingEr;


                        strBu.AppendFormat("<td bgcolor=\"#e3f1fc\" align=\"center\"><a href=\"javascrtipt:;\" class=\"RenTouxx\"  dataMonth=\"12\" datacCid=\"{3}\" dataDid=\"{4}\">{0}+{1}+{5}+{2}</a></td>", item[i].M12.ChengRen, item[i].M12.ErTong, item[i].M12.QuanPei, item[i].CityId, (int)j, item[i].M12.YingEr);
                        i12[0] += item[i].M12.ChengRen;
                        i12[1] += item[i].M12.ErTong;
                        i12[2] += item[i].M12.QuanPei;
                        i12[3] += item[i].M12.YingEr;
                        dqhjcr += item[i].M12.ChengRen;
                        dqhjer += item[i].M12.ErTong;
                        dqhjqp += item[i].M12.QuanPei;
                        dqhjyr += item[i].M12.YingEr;
                        m12[0] += item[i].M12.ChengRen;
                        m12[1] += item[i].M12.ErTong;
                        m12[2] += item[i].M12.QuanPei;
                        m12[3] += item[i].M12.YingEr;

                        strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", dqhjcr, dqhjer, dqhjqp, dqhjyr);
                        strBu.AppendFormat("</tr> ");

                        zjhjcr += dqhjcr;
                        zjhjer += dqhjer;
                        zjhjqp += dqhjqp;
                        zjhjyr += dqhjyr;

                        dqhjcr = 0; dqhjer = 0; dqhjqp = 0; dqhjyr = 0;

                    }

                    strBu.AppendFormat("<tr>");
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\" height=\"30\" colspan=\"2\">小计</td>");
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i1[0], i1[1], i1[2], i1[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i2[0], i2[1], i2[2], i2[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i3[0], i3[1], i3[2], i3[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i4[0], i4[1], i4[2], i4[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i5[0], i5[1], i5[2], i5[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i6[0], i6[1], i6[2], i6[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i7[0], i7[1], i7[2], i7[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i8[0], i8[1], i8[2], i8[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i9[0], i9[1], i9[2], i9[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i10[0], i10[1], i10[2], i10[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i11[0], i11[1], i11[2], i11[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", i12[0], i12[1], i12[2], i12[3]);
                    strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", zjhjcr, zjhjer, zjhjqp, zjhjyr);
                    strBu.AppendFormat("</tr>");
                }
            }

            if (!IsEmpty)
            {
                int crHJ = 0, etHJ = 0, qpHJ = 0, yrHJ = 0;

                crHJ = m1[0] + m2[0] + m3[0] + m4[0] + m5[0] + m6[0] + m7[0] + m8[0] + m9[0] + m10[0] + m11[0] + m12[0];
                etHJ = m1[1] + m2[1] + m3[1] + m4[1] + m5[1] + m6[1] + m7[1] + m8[1] + m9[1] + m10[1] + m11[1] + m12[1];
                qpHJ = m1[2] + m2[2] + m3[2] + m4[2] + m5[2] + m6[2] + m7[2] + m8[2] + m9[2] + m10[2] + m11[2] + m12[2];
                yrHJ = m1[3] + m2[3] + m3[3] + m4[3] + m5[3] + m6[3] + m7[3] + m8[3] + m9[3] + m10[3] + m11[3] + m12[3];


                strBu.AppendFormat("<tr>");
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\" height=\"30\">&nbsp;</td>");
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\" height=\"30\" colspan=\"2\">总计</td>");
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m1[0], m1[1], m1[2], m1[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m2[0], m2[1], m2[2], m2[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m3[0], m3[1], m3[2], m3[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m4[0], m4[1], m4[2], m4[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m5[0], m5[1], m5[2], m5[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m6[0], m6[1], m6[2], m6[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m7[0], m7[1], m7[2], m7[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m8[0], m8[1], m8[2], m8[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m9[0], m9[1], m9[2], m9[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m10[0], m10[1], m10[2], m10[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m11[0], m11[1], m11[2], m11[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", m12[0], m12[1], m12[2], m12[3]);
                strBu.AppendFormat("<td bgcolor=\"#BDDCF4\" align=\"center\">{0}+{1}+{3}+{2}</td>", crHJ, etHJ, qpHJ, yrHJ);
                strBu.AppendFormat("</tr>");
            }


            phEmpty.Visible = IsEmpty;
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_我方操作人统计_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_我方操作人统计_栏目, true);
                }
            }

        }

        /// <summary>
        /// 导出excel
        /// </summary>
        void ToXls()
        {
            ResponseToXls(Request.Form["txtXlsHTML"]);
        }
        #endregion

        #region  protect members
        /// <summary>
        /// 获取年份下拉菜单项
        /// </summary>
        /// <param name="v">选中项的值</param>
        /// <returns></returns>
        protected string GetYearOptions(string v)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</option>");
            int i = 2012;
            int e = DateTime.Now.Year;

            for (; i <= e; i++)
            {
                if (i.ToString() == v)
                {
                    s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
                }
                else
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</option>", i);
                }
            }

            return s.ToString();
        }


        #endregion

    }
}
