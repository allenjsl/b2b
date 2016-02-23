using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.PtWeb.HuiYuan
{
    /// <summary>
    /// 旅游线路
    /// </summary>
    public partial class XianLu : HuiYuanYeMian
    {
        #region private members
        /// <summary>
        /// 查询-站点编号
        /// </summary>
        protected int CXZdId = 0;
        /// <summary>
        /// 查询-专线类别编号
        /// </summary>
        protected  int CXZxlbId = 0;
        /// <summary>
        /// 查询-专线商编号
        /// </summary>
        protected string CXZxsId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "getgengduoxianlu": GetGengDuoXianLu(); break;
                default: break;
            }

            CXZdId = Utils.GetInt(Utils.GetQueryStringValue("zdid"));
            CXZxlbId = Utils.GetInt(Utils.GetQueryStringValue("zxlbid"));
            CXZxsId = Utils.GetQueryStringValue("zxsid");

            if (CXZdId == 0 || CXZxlbId == 0) Response.Redirect("/huiyuan/");

            InitZxsId();

            //InitZxs();

            InitXianLu();
            InitQuYu();

            ZxsXinXi1.ZxsId = CXZxsId;

            InitBaoJia();
        }

        #region private members
        
        /*/// <summary>
        /// init zxs
        /// </summary>
        void InitZxs()
        {
            var chaXun=new EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo();
            chaXun.ZhanDianId = CXZdId;
            chaXun.ZxlbId = CXZxlbId;

            var items = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetZxss1(SysCompanyId, chaXun);

            StringBuilder s = new StringBuilder();

            string _class = " class=\"on\" ";
            if (!string.IsNullOrEmpty(CXZxsId)) _class = "";
            string url = string.Format("/huiyuan/xianlu.aspx?zdid={0}&zxlbid={1}", CXZdId, CXZxlbId);
            s.AppendFormat("<li><a href=\"{0}\" {2}>{1}</a></li>", url, "全部", _class);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    string _class1 = "";
                    if (item.ZxsId == CXZxsId) _class1 = " class=\"on\" ";
                    string url1 = string.Format("/huiyuan/xianlu.aspx?zdid={0}&zxlbid={1}&zxsid={2}", CXZdId, CXZxlbId, item.ZxsId);
                    s.AppendFormat("<li><a href=\"{0}\" {2}>{1}</a></li>", url1, item.MingCheng, _class1);
                }
            }

            ltrZxs.Text = s.ToString();
        }*/

        /// <summary>
        /// init xianlu
        /// </summary>
        void InitXianLu()
        {
            int recordCount=0;
            int pageSize=15;
            int pageIndex=UtilsCommons.GetPagingIndex();
            var chaXun = GetChaXunInfo();
            var items = new EyouSoft.BLL.PtStructure.BKongWeiXianLu().GetKongWeis(SysCompanyId, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptXianLu.DataSource = items;
                rptXianLu.DataBind();

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo GetChaXunInfo()
        {
            var info =new EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo();

            info.BiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun), Utils.GetQueryStringValue("txtBiaoZhun"));
            info.QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate1"));
            info.QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate2"));
            info.QuYuId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuYu"));
            info.RouteName = Utils.GetQueryStringValue("txtRouteName");
            info.ZhanDianId = CXZdId;
            info.ZxlbId = CXZxlbId;
            info.ZxsId = CXZxsId;

            if (info.RouteName == "单订票")
            {
                info.KongWeiXianLuLeiXing = EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票;
                info.RouteName = string.Empty;
                info.BiaoZhun = null;
            }

            info.ExistsTingShou1 = 1;
            info.ExistsTingShou2 = 1;

            return info;
        }

        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {
            var chaXun = new EyouSoft.Model.CompanyStructure.MQuYuChaXunInfo();
            chaXun.ZhanDianId = CXZdId;
            chaXun.ZxlbId = CXZxlbId;
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetQuYus(SysCompanyId,chaXun);

            if (items != null && items.Count > 0)
            {
                StringBuilder s = new StringBuilder();
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Id, item.AreaName);
                }
                ltrQuYu.Text = s.ToString();
            }
        }

        /// <summary>
        /// get gengduo xianlu
        /// </summary>
        void GetGengDuoXianLu()
        {
            string txtKongWeiId = Utils.GetFormValue("txtKongWeiId");
            var chaXun = new EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo();
            chaXun.BiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun), Utils.GetFormValue("txtBiaoZhun"));
            chaXun.RouteName = Utils.GetFormValue("txtRouteName");
            chaXun.XianLuId1 = Utils.GetFormValue("txtXianLuId");
            if (chaXun.RouteName == "单订票")
            {
                chaXun.KongWeiXianLuLeiXing = EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票;
                chaXun.RouteName = string.Empty;
                chaXun.BiaoZhun = null;
            }

            var items = new EyouSoft.BLL.PtStructure.BKongWeiXianLu().GetKongWeiXianLus(txtKongWeiId, chaXun);

            if (items == null || items.Count == 0) RCWE("[]");

            RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        /// <summary>
        /// init zxsid
        /// </summary>
        void InitZxsId()
        {
            CXZxsId = new EyouSoft.BLL.PtStructure.BPt().GetZxsIdByZxlbId(CXZxlbId, SysCompanyId);
        }

        /// <summary>
        /// init baojia
        /// </summary>
        void InitBaoJia()
        {
            var baoJiaInfo = new EyouSoft.BLL.PtStructure.BBaoJia().GetZuiXinBaoJiaInfo(CXZxsId, CXZxlbId);

            var ziXunChaXun = new EyouSoft.Model.PtStructure.MZiXunChaXunInfo();
            ziXunChaXun.ZhanDianId = CXZdId;
            ziXunChaXun.LeiXing = EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing.平台站点公告;
            ziXunChaXun.Status = EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常;
            int ziXunRecordCount = 0;

            var ziXunItems = new EyouSoft.BLL.PtStructure.BZiXun().GetZiXuns(SysCompanyId, 10, 1, ref ziXunRecordCount, ziXunChaXun);

            if ((baoJiaInfo == null || baoJiaInfo.FuJians == null || baoJiaInfo.FuJians.Count == 0) && (ziXunItems == null || ziXunItems.Count == 0)) return;

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<div class=\"fujian_box mt15\">");

            if (baoJiaInfo != null && baoJiaInfo.FuJians != null && baoJiaInfo.FuJians.Count > 0)
            {
                s.AppendFormat("<div class=\"fujian_txt fontred\" id=\"div_baojia_biaoti\">");
                s.AppendFormat(baoJiaInfo.BiaoTi);
                s.AppendFormat("</div>");
                s.AppendFormat("<a class=\"fujian_btn\" href=\"javascript:void(0)\" id=\"zuixinbaojia_xiazai\">最新报价下载</a>");
            }

            if (ziXunItems != null && ziXunItems.Count > 0)
            {
                s.AppendFormat("<div class=\"gonggao1\">&nbsp;</div>");
                s.AppendFormat("<div id=\"div_gonggao\" class=\"gonggao2\">");
                s.AppendFormat("<ul id=\"ul_gonggao\">");
                foreach (var ziXunItem in ziXunItems)
                {
                    s.AppendFormat("<li><a href=\"{0}\" target=\"_blank\">[{2}] {1}</a></li>", ziXunItem.XXUrl, ziXunItem.BiaoTi, ziXunItem.IssueTime.ToString("yyyy-MM-dd"));
                }
                s.AppendFormat("</ul>");
                s.AppendFormat("</div>");
            }

            s.AppendFormat("</div>");


            if (baoJiaInfo != null && baoJiaInfo.FuJians != null && baoJiaInfo.FuJians.Count > 0)
            {
                s.AppendFormat("<div style=\"display:none\" id=\"i_div_baojiafujian\">");
                s.AppendFormat("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tablelist\" style=\"width:98%;margin:0px auto; margin-bottom:5px;\">");
                s.Append("<tr><th width='30'>序号</th><th>标题</th><th width='60'>下载</th>");
                int i = 1;
                foreach (var item in baoJiaInfo.FuJians)
                {
                    s.Append("<tr class=\"table_tr_item\">");
                    s.AppendFormat("<td style=\"text-align:center;\">{0}</td>", i);
                    s.AppendFormat("<td style=\"text-align:left;\">{0}</td>", item.MiaoShu);
                    s.AppendFormat("<td style=\"text-align:center;\"><a href=\"{0}\" target=\"_blank\">下载</a></td>", ErpUrl + item.Filepath);
                    s.Append("</tr>");
                    i++;
                }
                s.Append("</table>");
                s.AppendFormat("</div>");
            }

            ltrZuiXinBaoJia.Text = s.ToString();
        }
        #endregion

        #region protected members
        /// <summary>
        /// get biaozhun
        /// </summary>
        /// <param name="biaoZhun"></param>
        /// <returns></returns>
        protected string GetBiaoZhun(object biaoZhun,object kongWeiXianLuLeiXing)
        {
            var _kongWeiXianLuLeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)kongWeiXianLuLeiXing;

            if (_kongWeiXianLuLeiXing == EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票)
                return string.Format("<s class=\"icon0{0}\">{1}</s>", 0, "单订票");

            var _biaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun)biaoZhun;
            if (_biaoZhun == EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun.None) return string.Empty;

            return string.Format("<s class=\"icon0{0}\">{1}</s>", (int)_biaoZhun, biaoZhun);
        }

        /// <summary>
        /// 获取操作列
        /// </summary>
        /// <param name="pingTaiShouKeStatus">平台收客状态</param>
        /// <param name="shouKeStatus">专线商收客状态</param>
        /// <param name="pingTaiShengYuShuLiang">平台剩余数量</param>
        /// <returns></returns>
        protected string GetCaoZuo(object pingTaiShouKeStatus, object shouKeStatus, object pingTaiShengYuShuLiang)
        {
            string s = "<a class=\"yudin-btn\" href=\"javascript:void(0)\" data-class=\"yuding\">预定</a>";

            var _pingTaiShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus)pingTaiShouKeStatus;
            var _shouKeStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiStatus)shouKeStatus;
            int _pingTaiShengYuShuLiang = (int)pingTaiShengYuShuLiang;

            if (_shouKeStatus == EyouSoft.Model.EnumType.TourStructure.KongWeiStatus.手动停收)
            {
                s = "<a class=\"red-btn\" href=\"javascript:void(0)\">客满</a>";
                return s;
            }

            if (_pingTaiShouKeStatus == EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus.手动停收)
            {
                s = "<a class=\"red-btn\" href=\"javascript:void(0)\">客满</a>";
                return s;
            }

            if (_pingTaiShengYuShuLiang == 0)
            {
                s = "<a class=\"green-btn\" href=\"javascript:void(0)\" data-class=\"yuding\">申请</a>";
                return s;
            }

            return s;
        }

        /// <summary>
        /// get daying xingcheng
        /// </summary>
        /// <returns></returns>
        protected string GetDaYinXingCheng(object xianLuId, object kongWeiXianLuLeiXing)
        {
            var _kongWeiXianLuLeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)kongWeiXianLuLeiXing;

            if (_kongWeiXianLuLeiXing == EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票) return string.Empty;

            return string.Format("<a class=\"print_btn\" href=\"/danju/xingchengdan.aspx?xianluid={0}\" target=\"_blank\">打印行程</a> <a class=\"print_btn\" href=\"/xianlu/xianluxx.aspx?xlid={0}\" target=\"_blank\">线路详情</a>", xianLuId);
        }

        /// <summary>
        /// get xiandingrenshu
        /// </summary>
        /// <param name="xianDingRenShu"></param>
        /// <returns></returns>
        protected string GetXianDingRenShu(object xianDingRenShu)
        {
            if (xianDingRenShu == null) return string.Empty;

            var _xianDingRenShu = (int)xianDingRenShu;
            if (_xianDingRenShu <= 0) return string.Empty;

            return string.Format("&nbsp;<span style=\"color:#2C6504\">【每单限制总人数不超过{0}人】</span>", _xianDingRenShu);
        }
        #endregion
    }
}
