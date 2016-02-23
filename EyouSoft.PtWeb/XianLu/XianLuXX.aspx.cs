using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.XianLu
{
    public partial class XianLuXX : QianTaiYeMian
    {
        #region attributes
        protected DateTime datetime = DateTime.Now;
        protected int nian = DateTime.Now.Year;
        protected int yue = DateTime.Now.Month;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.IsXianShiHeFu = false;

            string time2 = Utils.GetFormValue("rilinianyue");
            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "qianrili": 
                    GetRiLi(time2, 1); break;
                case "hourili":
                    GetRiLi(time2, 2); break;
                default: break;
            }
            if (Request.QueryString["xlid"] != "")
            {
                InitXianLu();
            }
        }

        #region private members
        void InitXianLu()
        {
            string xlid = Request.QueryString["xlid"];
            #region //获取出发时间
            if (!string.IsNullOrEmpty(Request.QueryString["chufatime"]))
            {
                DateTime dtime = Convert.ToDateTime(Request.QueryString["chufatime"]);
                if (dtime > DateTime.Now && dtime.Month > DateTime.Now.Month)
                {
                    datetime = dtime.AddDays(1 - dtime.Day);
                }
                else if (dtime >= DateTime.Now && dtime.Month == DateTime.Now.Month)
                {
                    datetime = DateTime.Now;
                }
                else
                {
                    datetime = DateTime.Now;
                }
            }
            #endregion
            var list = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiXianLuInfo(xlid);
            if (list != null)
            {
                Line_Name.Text = list.RouteName;
                Line_Title.Text = list.RouteName;
                ChanPin_BIanHao.Text = list.XianLuCode;
                ChengRenJia.Text = list.MenShiJiaGe1.ToString("f2");
                ErTongJia.Text = list.MenShiJiaGe2.ToString("f2");
                var item = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(list.RouteId);
                if (item != null)
                {
                    SongTuanXinXi.Text = item.SongTuanXinXi;
                    TianShu.Text = item.Days.ToString();
                    JiHeShiJian.Text = item.JiHeShiJian.ToString();
                    JiHeDiDian.Text = item.JiHeDiDian;
                    JieTuanFangShi.Text = item.MuDiDiJieTuanFangShi;
                    XingCheng.DataSource = item.RoutePlanList;
                    XingCheng.DataBind();
                    JiaoTongBiaoZhun.Text = item.TrafficStandard;
                    ZhuSuBiaoZhun.Text = item.StayStandard;
                    CanYinBiaoZhun.Text = item.DiningStandard;
                    JingDianBiaoZhun.Text = item.AttractionsStandard;
                    DaoYouFuWu.Text = item.GuideStandard;
                    GouWuShuoMing.Text = item.ShoppingStandard;
                    ErTongBiaoZhun.Text = item.ChildStandard;
                    BaoXianShuoMing.Text = item.InsuranceDesc;
                    ZiFeiTuiJian.Text = item.ExpenseRecommend;
                    BaoMingXuZhi.Text = item.RegistrationNotes;
                    RepImage.DataSource = item.FuJians;
                    picList.DataSource = item.FuJians;
                    picList.DataBind();
                    RepImage.DataBind();

                    Title = item.RouteName;
                }
                var kongweiInfo = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiById(list.KongWeiId);
                if (kongweiInfo != null)
                {
                    QuChengJiaoTong.Text = kongweiInfo.QuJiaoTongName + "  " + kongweiInfo.QuBanCi;
                    HuiChengJiaoTong.Text = kongweiInfo.HuiJiaoTongName + "  " + kongweiInfo.HuiBanCi;
                    ChuFaRiQi.Text = Convert.ToDateTime(kongweiInfo.QuDate).ToShortDateString();
                    HuiChengRiQi.Text = Convert.ToDateTime(kongweiInfo.HuiDate).ToShortDateString();
                    string province = "";
                    string city = "";
                    province = kongweiInfo.HuiChuFaDiShengFenName;
                    city = kongweiInfo.HuiDepCityName;
                    if (province != "" && city != "")
                    {
                        HuiChengChuFaDi.Text = province + "-" + city;
                    }
                    else
                    {
                        HuiChengChuFaDi.Text = province + city;
                    }
                    province = kongweiInfo.HuiMuDiDiShengFenName;
                    city = kongweiInfo.HuiArrCityName;
                    if (province != "" && city != "")
                    {
                        HuiChengMuDiDi.Text = province + "-" + city;
                    }
                    else
                    {
                        HuiChengMuDiDi.Text = province + city;
                    }
                    province = kongweiInfo.QuChuFaDiShengFenName;
                    city = kongweiInfo.QuDepCityName;
                    if (province != "" && city != "")
                    {
                        ChuFaDi.Text = province + "-" + city;
                    }
                    else
                    {
                        ChuFaDi.Text = province + city;
                    }
                    province = kongweiInfo.QuMuDiDiShengFenName;
                    city = kongweiInfo.QuArrCityName;
                    if (province != "" && city != "")
                    {
                        MuDiDi.Text = province + "-" + city;
                    }
                    else
                    {
                        MuDiDi.Text = province + city;
                    }
                }

                GouMaiShu.Text = kongweiInfo.YouXiaoShouKeRenShu.ToString();


                RiLiDay.Text = GetRiLi(kongweiInfo.QuDate.ToString(), 3);
                nian = Convert.ToDateTime(kongweiInfo.QuDate).Year;
                yue = Convert.ToDateTime(kongweiInfo.QuDate).Month;
                datetime = Convert.ToDateTime(kongweiInfo.QuDate);
            }
        }
        /// <summary>
        /// 获取一周中的第几天
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        int WeeKOfDays(DayOfWeek week)
        {
            switch (week)
            {
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                case DayOfWeek.Sunday:
                    return 0;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 获取当前月总天数
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        int MonthDays(DateTime time)
        {
            switch (time.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if (DateTime.IsLeapYear(time.Year))
                        return 29;
                    else
                        return 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 0;
            }
        }

        string GetRiLi(string time, int cate)
        {
            string riliul = "";
            string xlid = Request.QueryString["xlid"];
            DateTime time2 = Convert.ToDateTime(time);
            DateTime time1 = Convert.ToDateTime(time);
            if (cate == 1)//cate=1，前一个月；cate=2，后一个月
            {
                time1 = time1.AddDays(1 - time1.Day).AddMonths(-1);
                if (time1 < DateTime.Now)
                {
                    time1 = DateTime.Now.AddDays(1);
                }
            }
            else if (cate == 2)
            {
                time1 = time1.AddDays(1 - time1.Day).AddMonths(1);
                if (time1 < DateTime.Now)
                {
                    time1 = DateTime.Now;
                }
            }
            else if (cate == 3)
            {
                time1 = time1.AddDays(1 - time1.Day);
                if (time1 < DateTime.Now)
                {
                    time1 = DateTime.Now.AddDays(1);
                }
            }
            var rililist = new EyouSoft.BLL.PtStructure.BKongWeiXianLu().GetGuanLianKongWeiXianLus(xlid, time1.AddDays(-1).AddSeconds(1), time1.AddDays(1 - time1.Day).AddMonths(1).AddDays(-1).AddSeconds(1));
            DayOfWeek week = time1.AddDays(1 - time1.Day).DayOfWeek;
            int WeekOfDay = WeeKOfDays(week);//一周中的第几天
            int LastWeekDay = WeeKOfDays(time1.AddDays(1 - time1.Day).AddMonths(1).AddDays(-1).DayOfWeek);
            int MonthDay = MonthDays(time1);
            for (int i = 0; i < WeekOfDay; i++)
            {
                riliul += "<li><div class=\"calendar_box\"><span></span></div></li>";
            }
            if (rililist.Count > 0)
            {
                for (int i = 1; i < time1.Day; i++)
                {
                    if (i < 10)
                    {
                        riliul += "<li><div class=\"calendar_box\"><span>0" + i + "</span></div></li>";
                    }
                    else
                    {
                        riliul += "<li><div class=\"calendar_box\"><span>" + i + "</span></div></li>";
                    }
                }
                for (int i = time1.Day; i <= MonthDay; i++)
                {
                    bool isfind = false;
                    int t = 0;
                    for (t=0; t < rililist.Count; t++)
                    {
                        if (rililist[t].QuDate.Day == i)
                        {
                            isfind = true;
                            break;
                        }
                    }
                    if (isfind)
                    {
                        if (i < 10)
                        {
                            if (i == time2.Day && cate==3)
                            {
                                riliul += "<li class=\"current_bg\"><a href=\"XianLuXX.aspx?xlid=" + rililist[t].XianLuId + "\"><div class=\"calendar_box\"><span>0" + i + "</span>"
                                         + "<span class=\"fontyellow\">¥" + Convert.ToInt32(rililist[t].MenShiJiaGe1) + "</span><span class=\"fontgreen\">余" + rililist[t].PingTaiShengYuShuLiang + "</span></div></a></li>";
                            }
                            else
                            {
                                riliul += "<li><a href=\"XianLuXX.aspx?xlid=" + rililist[t].XianLuId + "\"><div class=\"calendar_box\"><span>0" + i + "</span>"
                                                                         + "<span class=\"fontyellow\">¥" + Convert.ToInt32(rililist[t].MenShiJiaGe1) + "</span><span class=\"fontgreen\">余" + rililist[t].PingTaiShengYuShuLiang + "</span></div></a></li>";
                            }
                        }
                        else
                        {
                            if (i == time2.Day && cate == 3)
                            {
                                riliul += "<li class=\"current_bg\"><a href=\"XianLuXX.aspx?xlid=" + rililist[t].XianLuId + "\"><div class=\"calendar_box\"><span>" + i + "</span>"
                                         + "<span class=\"fontyellow\">¥" + Convert.ToInt32(rililist[t].MenShiJiaGe1) + "</span><span class=\"fontgreen\">余" + rililist[t].PingTaiShengYuShuLiang + "</span></div></a></li>";
                            }
                            else
                            {
                                riliul += "<li><a href=\"XianLuXX.aspx?xlid=" + rililist[t].XianLuId + "\"><div class=\"calendar_box\"><span>" + i + "</span>"
                                         + "<span class=\"fontyellow\">¥" + Convert.ToInt32(rililist[t].MenShiJiaGe1) + "</span><span class=\"fontgreen\">余" + rililist[t].PingTaiShengYuShuLiang + "</span></div></a></li>";
                            }
                        }
                    }
                    else
                    {
                        if (i < 10)
                        {
                            riliul += "<li><div class=\"calendar_box\"><span>0" + i + "</span></div></li>";
                        }
                        else
                        {
                            riliul += "<li><div class=\"calendar_box\"><span>" + i + "</span></div></li>";
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i <= MonthDay; i++)
                {
                    if (i < 10)
                    {
                        riliul += "<li><div class=\"calendar_box\"><span>0" + i + "</span></div></li>";
                    }
                    else
                    {
                        riliul += "<li><div class=\"calendar_box\"><span>" + i + "</span></div></li>";
                    }
                }
            }

            for (int i = LastWeekDay+1; i < 7; i++)
            {
                riliul += "<li><div class=\"calendar_box\"><span></span></div></li>";
            }
            if (cate != 3)
            {
                RCWE(riliul);
            }
            return riliul;
        }
        #endregion
    }
}
