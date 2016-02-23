using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Collections.Generic;
using EyouSoft.Model.TourStructure;
using System.Text;
using EyouSoft.Model.EnumType.TourStructure;

namespace Web.TeamPlan
{
    public partial class changguiList : BackPage
    {
        #region attributes
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
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
        /// <summary>
        /// 控位修改权限
        /// </summary>
        bool Privs_XiuGai = false;
        /// <summary>
        /// 查询-控位显示状态
        /// </summary>
        protected string CX_XianShiStatus = "";
        /// <summary>
        /// 权限-隐藏控位
        /// </summary>
        bool Privs_YinCangKongWei = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            InitPrivs();
            if (dotype != null && dotype.Length > 0)
            {
                AJAX(dotype, id);
            }

            InitQuYu();
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        #region private members
        private void PageInit()
        {
            EyouSoft.BLL.TourStructure.BTour bll = new EyouSoft.BLL.TourStructure.BTour();
            EyouSoft.Model.TourStructure.MSearchKongWei modelsearch = new EyouSoft.Model.TourStructure.MSearchKongWei();
            modelsearch.BuyCompanyName = Utils.GetQueryStringValue("txtunitname");
            modelsearch.JiaoYiHao = Utils.GetQueryStringValue("txtjiaoyinum");
            modelsearch.GysOrderCode = Utils.GetQueryStringValue("txtbianma");
            modelsearch.KongWeiCode = Utils.GetQueryStringValue("txtkongwei");
            modelsearch.LBeginDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtstartdate"));
            modelsearch.LEndDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtenddate"));
            modelsearch.OrderCode = Utils.GetQueryStringValue("txtordernum");
            modelsearch.TravellerName = Utils.GetQueryStringValue("txtcustomer");
            modelsearch.AreaId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuYu"));
            modelsearch.QuJiaoTongId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuJiaoTong"));
            modelsearch.QuDepProvinceId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuDepProvince"));
            modelsearch.QuDepCityId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuDepCity"));
            modelsearch.QuArrProvinceId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuArrProvince"));
            modelsearch.QuArrCityId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuArrCity"));
            modelsearch.KongWeiZhuangTai = (KongWeiZhuangTai?)Utils.GetEnumValueNull(typeof(KongWeiZhuangTai), Utils.GetQueryStringValue("txtKongWeiZhuangTai"));
            modelsearch.ZxsId = CurrentZxsId;
            modelsearch.PiCiCode = Utils.GetQueryStringValue("txtPiCiCode");
            modelsearch.XianLuCode = Utils.GetQueryStringValue("txtXianLuCode");

            modelsearch.DingDanStatus = (EyouSoft.Model.EnumType.TourStructure.OrderStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.OrderStatus), Utils.GetQueryStringValue("txtDingDanStatus"));
            modelsearch.ShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiStatus), Utils.GetQueryStringValue("txtShouKeStatus"));
            modelsearch.PingTaiShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus), Utils.GetQueryStringValue("txtPingTaiShouKeStatus"));
            modelsearch.XianShiStatus= (EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus), Utils.GetQueryStringValue("txtXianShiStatus"));

            if (!string.IsNullOrEmpty(modelsearch.PiCiCode)) pageSize = 31;

            if (Utils.GetQueryStringValue("txtIsChaXun") != "1")
            {
                modelsearch.XianShiStatus = EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus.显示;
            }

            if (modelsearch.XianShiStatus.HasValue)
            {
                CX_XianShiStatus = ((int)modelsearch.XianShiStatus.Value).ToString();
            }

            pageIndex = Utils.GetInt(Request.QueryString["Page"], 1);

            object[] heJi;

            IList<EyouSoft.Model.TourStructure.MPageKongWei> list = bll.GetKongWei(this.SiteUserInfo.CompanyId, pageSize, pageIndex, ref recordCount, modelsearch, out heJi);
            if (list != null && list.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.rptList.DataSource = list;
                this.rptList.DataBind();
                BindExportPage();

                ltrShiShouShuLiang.Text = heJi[0].ToString();
                ltrShiJiChuPiaoShuLiang.Text = heJi[1].ToString();
            }
            else
            {
                phHeJi.Visible = false;
            }

        }

        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType, string id)
        {
            string msg = string.Empty;
            //对应执行操作
            switch (doType.ToLower())
            {
                case "delete":
                    //判断权限
                    if (this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_删除))
                    {
                        msg = this.DeleteData(id);
                    }
                    else msg = UtilsCommons.AjaxReturnJson("0", "没有操作权限");
                    break;
                case "hesuanjieshu": HeSuanJieShu(); break;
                case "quxiaohesuanjieshu": QuXiaoHeSuanJieShu(); break;
                case "getcaozuobeizhu": GetCaoZuoBeiZhu(); break;
                case "shezhipingtaishoukestatus": SheZhiPingTaiShouKeStatus(); break;
                case "shezhishoukestatus": SheZhiShouKeStatus(); break;
                case "shezhixianshistatus": SheZhiXianShiStatus(); break;
                default:
                    msg = UtilsCommons.AjaxReturnJson("0", "错误的请求");
                    break;
            }
            //返回ajax操作结果
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private string DeleteData(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                EyouSoft.BLL.TourStructure.BTour bll = new EyouSoft.BLL.TourStructure.BTour();
                int result = bll.DeleteKongWei(id);
                if (result == 1)
                {
                    return UtilsCommons.AjaxReturnJson("1", "删除成功");
                }
                else if (result == -1)
                {
                    return UtilsCommons.AjaxReturnJson("0", "控位存在订单不允许删除!");
                }
                else if (result == -2)
                {
                    return UtilsCommons.AjaxReturnJson("0", "控位存在地接安排不允许删除!");
                }
                else if (result == -3)
                {
                    return UtilsCommons.AjaxReturnJson("0", "控位存在出票安排不允许删除!");
                }
                else if (result == -4)
                {
                    return UtilsCommons.AjaxReturnJson("0", "控位代理商存在押金登记不允许删除!");
                }
                else if (result == -19)
                {
                    return UtilsCommons.AjaxReturnJson("0", "操作失败：该控位已核算结束!");
                }
                else
                {
                    return UtilsCommons.AjaxReturnJson("0", "删除失败!");
                }
            }
            else
            {
                return UtilsCommons.AjaxReturnJson("0", "无效的团队信息!");
            }
        }

        /// <summary>
        /// 权限判断
        /// </summary>
        private void InitPrivs()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_栏目, false);
                return;
            }

            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_团队结算)) Privs_TuanDuiJieSuan = '1';

            Privs_HeSuanJieShu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_核算结束);
            Privs_QuXiaoHeSuanJieShu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_取消核算结束);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改);

            phHeSuanJieShu.Visible = Privs_HeSuanJieShu;
            phQuXiaoHeSuanJieShu.Visible = Privs_QuXiaoHeSuanJieShu;

            Privs_YinCangKongWei = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_隐藏控位);
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
                bll.SetKongWeiZhuangTai(item, KongWeiZhuangTai.核算结束, CurrentUserCompanyID, CurrentZxsId, BusinessType.常规旅游);
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
                bll.SetKongWeiZhuangTai(item, KongWeiZhuangTai.正常, CurrentUserCompanyID, CurrentZxsId, BusinessType.常规旅游);
            }

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功：已取消核算结束。"));
        }

        /// <summary>
        /// get caozuobeizhu
        /// </summary>
        void GetCaoZuoBeiZhu()
        {
            string kongWeiId = Utils.GetQueryStringValue("kongweiid");
            var chaXun = new EyouSoft.Model.TourStructure.MKongWeiBeiZhuChaXunInfo();
            chaXun.Status = 0;
            var items = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiBeiZhus(kongWeiId, chaXun);
            StringBuilder s = new StringBuilder();
            s.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0' class='pp-tableclass'>");
            s.Append("<tr class='pp-table-title'><th width='30'>序号</th><th width='65'>操作时间</th><th width='60'>操作人</th><th>操作内容</th></tr>");

            if (items != null && items.Count > 0)
            {
                int i = 1;
                foreach (var item in items)
                {
                    s.Append("<tr class=''>");
                    s.AppendFormat("<td>{0}</td>", i);
                    s.AppendFormat("<td>{0}</td>", item.IssueTime.ToString("yyyy-MM-dd"));
                    s.AppendFormat("<td>{0}</td>", item.OperatorName);
                    s.AppendFormat("<td style='text-align:left;'>{0}</td>", EyouSoft.Common.Function.StringValidate.TextToHtml(item.NeiRong));
                    s.Append("</tr>");
                    i++;
                }
            }
            else
            {
                s.Append("<tr><td colspan='4'>暂无有效操作备注信息</td></tr>");
            }
            s.Append("</table>");
            RCWE(s.ToString());
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

        /// <summary>
        /// shezhi pingtai shouke status
        /// </summary>
        void SheZhiPingTaiShouKeStatus()
        {
            if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string[] items = Utils.GetFormValues("txtKongWeiId[]");
            string txtStatus=Utils.GetFormValue("txtStatus");

            if (items == null || items.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：错误的请求。"));

            var status = EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus.正常收客;
            if (txtStatus == "tingshou") status = PingTaiShouKeStatus.手动停收;

            var bll = new EyouSoft.BLL.TourStructure.BTour();
            foreach (var item in items)
            {
                bll.SheZhiPingTaiShouKeStatus(CurrentZxsId, item, status);
            }

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
        }

        /// <summary>
        /// shezhi shouke status
        /// </summary>
        void SheZhiShouKeStatus()
        {
            if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string[] items = Utils.GetFormValues("txtKongWeiId[]");
            string txtStatus = Utils.GetFormValue("txtStatus");

            if (items == null || items.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：错误的请求。"));

            var status = EyouSoft.Model.EnumType.TourStructure.KongWeiStatus.正常收客;
            if (txtStatus == "tingshou") status = KongWeiStatus.手动停收;

            var bll = new EyouSoft.BLL.TourStructure.BTour();
            foreach (var item in items)
            {
                bll.UpdateKongWeiShouKeStatus(item, status);
            }

            RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
        }

        /// <summary>
        /// shezhi xianshi status
        /// </summary>
        void SheZhiXianShiStatus()
        {
            if (!Privs_YinCangKongWei) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string txtKongWeiId = Utils.GetFormValue("txtKongWeiId");
            string txtFS = Utils.GetFormValue("txtFS");

            var xianShiStatus = EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus.显示;
            if (txtFS == "yincang") xianShiStatus= KongWeiXianShiStatus.隐藏;

            var bllRetCode = new EyouSoft.BLL.TourStructure.BTour().SheZhiKongWeiXianShiStatus(CurrentZxsId,txtKongWeiId, xianShiStatus);
            if (bllRetCode==1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }
        #endregion

        #region protected members
        protected string GetChuPiaoList(string kongweiId)
        {
            EyouSoft.BLL.TourStructure.BTour b = new EyouSoft.BLL.TourStructure.BTour();
            IList<EyouSoft.Model.TourStructure.MKongWeiDaiLi> list = b.GetKongWeiDaiLiById(kongweiId);

            StringBuilder str = new StringBuilder();
            str.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'><tr class='pp-table-title'><th>代理商</th><th>订单号或编码</th><th>联系人</th><th >联系电话</th><th>价格</th><th>数量</th><th>出票时限</th><th>备注</th><th>押金金额</th></tr>");
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    str.AppendFormat("<tr class=''><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td></tr>"
                        , list[i].GysName
                        , list[i].GysOrderCode
                        , list[i].LxrName, list[i].LxrTelephone
                        , list[i].Price.ToString("f2")
                        , list[i].ShuLiang.ToString()
                        , list[i].ShiXian, list[i].Remark
                        , list[i].YaJinAmount.ToString("f2"));
                }
            }
            else
            {
                str.Append("<tr class=''><td colspan='9'>无联系人信息</td></tr>");
            }
            str.Append("</table>");
            return str.ToString();
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }

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

            var _kongWeiZhuangTai = (KongWeiZhuangTai)kongWeiZhuangTai;

            if (_kongWeiZhuangTai == KongWeiZhuangTai.正常) return kongWeiCode.ToString();

            return "<b title=\"已核算结束\">" + kongWeiCode.ToString() + "</b>";
        }

        /// <summary>
        /// get shouke status
        /// </summary>
        /// <param name="shouKeStatus"></param>
        /// <param name="pingTaiShouKeStatus"></param>
        /// <returns></returns>
        protected string GetShouKeStatus(object shouKeStatus,object pingTaiShouKeStatus)
        {
            var _shouKeStatus = (KongWeiStatus)shouKeStatus;
            var _pingTaiShouKeStatus = (PingTaiShouKeStatus)pingTaiShouKeStatus;
            string s = "";

            switch (_shouKeStatus)
            {
                case KongWeiStatus.手动停收: s = "<br/><span class='tings'>系统停收</span>"; break;
                case KongWeiStatus.自动客满: s = "<br/><span class='keman'>自动客满</span>"; break;
                default: break;
            }

            switch (_pingTaiShouKeStatus)
            {
                case PingTaiShouKeStatus.手动停收: s += "<br/><span class='tings'>平台停收</span>"; break;
                default: break;
            }
            return s;
        }

        /// <summary>
        /// get xianshi status
        /// </summary>
        /// <param name="xianShiStatus"></param>
        /// <returns></returns>
        protected string GetXianShiStatus(object xianShiStatus)
        {
            if (!Privs_YinCangKongWei) return string.Empty;

            var _xianShiStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus)xianShiStatus;

            if (_xianShiStatus == KongWeiXianShiStatus.显示)
            {
                return " | <a href=\"javascript:void(0)\" class=\"xianshistatus\" data-fs=\"yincang\">隐藏控位</a>";
            }

            return " | <a href=\"javascript:void(0)\" class=\"xianshistatus\" data-fs=\"xianshi\">显示控位</a>";
        }
        #endregion
    }
}
