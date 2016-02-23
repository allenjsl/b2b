using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Common.Function;
using System.Text;

namespace Web.SystemSet
{
    public partial class CityManage : BackPage
    {
        #region attributes
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;

        protected string proAndCityHtml;//城市省份列表html
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            string method = Utils.GetQueryStringValue("method");
            int id = Utils.GetInt(Utils.GetQueryStringValue("id"));//省份或城市Id
            //获取当前操作
            bool result = false;
            if (method != "")
            {
                if (this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_城市管理栏目))
                {
                    switch (method)
                    {
                        case "delCity"://删除城市
                            result = new EyouSoft.BLL.CompanyStructure.City().Delete(id);
                            break;
                        case "delPro"://删除省份
                            result = new EyouSoft.BLL.CompanyStructure.Province().Delete(id);
                            break;
                        default: break;
                    }
                }
                Utils.ResponseMeg(result, result ? "" : "操作失败！");
                return;
            }

            if (Utils.GetQueryStringValue("dotype") == "shezhileixing") SheZhiLeiXing();

            //绑定城市省份数据
            GetProAndCityHTML();
        }

        #region private members
        /// <summary>
        /// 绑定城市省份数据
        /// </summary>
        void GetProAndCityHTML()
        {
            int itemIndex2 = 1;

            var chaXun = new EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo();
            chaXun.LeiXing1 = 1;
            chaXun.LeiXing = 0;
            var items = new EyouSoft.BLL.CompanyStructure.City().GetShengFens(CurrentUserCompanyID, chaXun);

            var proList = SelfExportPage.GetList(pageIndex, pageSize, out recordCount, items);
            if (proList != null && proList.Count > 0)
            {
                StringBuilder proBuilder = new StringBuilder();
                int itemIndex = 1;
                itemIndex2 = (pageIndex - 1) * pageSize;
                foreach (var pro in proList)
                {
                    itemIndex2++;
                    proBuilder.AppendFormat("<tr class='{3}'>" +
                        "<td {0} align=\"center\" valign=\"top\">{1}</td>" +
                        "<td {0} align=\"center\" valign=\"top\"><strong><a href=\"javascript:;\" onclick=\"return CityManage.updatePro('{4}');\">{2}</a></strong> <a href=\"javascript:;\" onclick=\"return CityManage.delPro('{4}',this);\">[删除]</a></td>",
                        (pro.ChengShis != null && pro.ChengShis.Count > 0) ? "rowspan='" + pro.ChengShis.Count + "'" : "", itemIndex2, pro.ShengFenName, itemIndex2 % 2 == 0 ? "even" : "odd", pro.ShengFenId);
                    if (pro.ChengShis != null && pro.ChengShis.Count > 0)
                    {
                        foreach (var c in pro.ChengShis)
                        {
                            if (itemIndex != 1)
                                proBuilder.AppendFormat("<tr class='{0}'>", itemIndex2 % 2 == 0 ? "even" : "odd");

                            proBuilder.AppendFormat("<td align=\"center\" ><a href=\"javascript:;\" onclick=\"return CityManage.updateCity('{0}');\">{1}</a></td>", c.ChengShiId, c.ChengShiName);
                            proBuilder.AppendFormat("<td align=\"center\" >");
                            proBuilder.AppendFormat("<a href=\"javascript:;\" onclick=\"return CityManage.delCity('{0}',this);\">删除</a>&nbsp;&nbsp;", c.ChengShiId);
                            if (c.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing.显示)
                            {
                                proBuilder.AppendFormat("<a href=\"javascript:void(0);\" data-chengshiid=\"{0}\" data-fs=\"yincang\" class=\"shezhileixing\">隐藏</a>", c.ChengShiId);
                            }
                            if (c.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing.隐藏)
                            {
                                proBuilder.AppendFormat("<a href=\"javascript:void(0);\" data-chengshiid=\"{0}\" data-fs=\"xianshi\" class=\"shezhileixing\">显示</a>", c.ChengShiId);
                            }
                            proBuilder.AppendFormat("</td>");
                            proBuilder.AppendFormat("</tr>");

                            itemIndex++;
                        }
                    }
                    else
                    {
                        proBuilder.Append("<td align=\"center\" >&nbsp;</td><td align=\"center\" bgcolor=\"#E3F1FC\">&nbsp;</td></tr>");
                    }
                    itemIndex = 1;
                }
                proAndCityHtml = proBuilder.ToString();
                BindExportPage();
            }
            else
            {
                proAndCityHtml = "<tr><td colspan='5' align='center'>对不起，暂无城市省份信息！</td></tr>";
                ExporPageInfoSelect1.Visible = false;
            }

        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_栏目))
            {
                RCWE("没有权限");
            }

            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_城市管理栏目))
            {

            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_线路区域栏目))
            {
                Response.Redirect("/SystemSet/LineManage.aspx");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_交通信息栏目))
            {
                Response.Redirect("/SystemSet/TrafficManage.aspx");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_其它收入项目栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=9");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_其它支出项目栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=10");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_送团信息栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=6");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_目的地接团方式栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=7");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_用餐标准栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=8");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_去程班次栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=2");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_回程班次栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=3");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_集合地点栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=4");
            }
            else if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_集合时间栏目))
            {
                Response.Redirect("/SystemSet/jichuxinxi.aspx?jichuxinxitype=5");
            }
            else
            {
                RCWE("没有权限");
            }
        }

        /// <summary>
        /// shezhi leixing
        /// </summary>
        void SheZhiLeiXing()
        {
            int txtChengShiId = Utils.GetInt(Utils.GetFormValue("txtChengShiId"));
            string txtFS = Utils.GetFormValue("txtFS");

            if (txtChengShiId < 1) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求。"));

            var _leiXing = EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing.显示;

            if (txtFS == "yincang") _leiXing = EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing.隐藏;

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.City().SheZhiLeiXing(CurrentUserCompanyID, txtChengShiId, _leiXing);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
