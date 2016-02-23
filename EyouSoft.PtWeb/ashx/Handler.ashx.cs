using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.PtWeb.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Handler : IHttpHandler
    {
        HttpContext context = null;
        public void ProcessRequest(HttpContext _context)
        {
            context = _context;
            string dotype = Utils.GetQueryStringValue("dotype");

            switch (dotype)
            {
                case "getgscx": GetGSCX(); break;
                case "getjiudianchengshi": GetJiuDianChengShi(); break;
                case "tonghangyonghuislogin": TongHangYongHuIsLogin(); break;
                case "removecache": RemoveCache(); break;
                case "getxiaoxi": GetXiaoXi(); break;
                case "getguanliankongweixianlu": GetGuanLianKongWeiXianLu(); break;
                case "getfangxingfujian": GetFangXingFuJian(); break;
                case "getautocompletezxs": GetAutocompleteZxs(); break;
                default: NoHandler(); break;
            }
        }

        #region IsReusable
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region private members
        /// <summary>
        /// no handler
        /// </summary>
        void NoHandler() { Utils.RCWE("{}"); }

        /// <summary>
        /// get guojia shengfen chengshi xianqu
        /// </summary>
        void GetGSCX()
        {
            int companyId = 0;
            string zxsId = string.Empty;

            var yuMingInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetYuMingInfo();            
            companyId = yuMingInfo.CompanyId;

            string getType = Utils.GetQueryStringValue("get");
            StringBuilder sb = new StringBuilder();

            var chaXun = new EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo();
            chaXun.LeiXing1 = 0;
            chaXun.LeiXing = 0;
            chaXun.ShengFenId = Utils.GetIntNull(Utils.GetQueryStringValue("pid"));
            chaXun.ZxsId = zxsId;

            if (Utils.GetInt(Utils.GetQueryStringValue("isCy"), 0) == 1) chaXun.LeiXing = 1;

            if (getType == "p")
            {
                var items = new EyouSoft.BLL.CompanyStructure.City().GetShengFens(companyId, chaXun);

                if (items != null && items.Count > 0)
                {
                    sb.Append("{\"list\":[");
                    for (int i = 0; i < items.Count; i++)
                    {
                        sb.Append("{\"id\":\"" + items[i].ShengFenId.ToString() + "\",\"name\":\"" + items[i].ShengFenName + "\"},");
                    }
                    if (sb.Length > 1)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append("]}");
                }
                else
                {
                    sb.Append("{\"list\":[]}");
                }
            }

            if (getType == "c")
            {
                var items = new EyouSoft.BLL.CompanyStructure.City().GetChengShis(companyId, chaXun);
                if (items != null && items.Count > 0)
                {
                    sb.Append("{\"list\":[");
                    for (int i = 0; i < items.Count; i++)
                    {
                        sb.Append("{\"id\":\"" + items[i].ChengShiId.ToString() + "\",\"name\":\"" + items[i].ChengShiName + "\"},");
                    }
                    if (sb.Length > 1)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append("]}");
                }
                else
                {
                    sb.Append("{\"list\":[]}");
                }
            }

            if (string.IsNullOrEmpty(sb.ToString())) sb.Append("{\"list\":[]}");

            Utils.RCWE(sb.ToString());
        }

        /// <summary>
        /// tonghang yonghu is login
        /// </summary>
        void TongHangYongHuIsLogin()
        {
            EyouSoft.Model.SSOStructure.MTongHangYongHuInfo yongHuInfo;
            bool isLogin = EyouSoft.Security.Membership.TongHangYongHuProvider.IsLogin(out yongHuInfo);

            var output = new System.Text.StringBuilder();
            output.Append("{");

            output.AppendFormat("\"retCode\":{0}", "1");
            output.AppendFormat(",\"isLogin\":{0}", isLogin ? "true" : "false");
            output.AppendFormat(",\"token\":\"{0}\"", isLogin ? yongHuInfo.YongHuId.ToString() : "");

            output.Append("}");

            Utils.RCWE(output.ToString());
        }

        /// <summary>
        /// remove cache
        /// </summary>
        void RemoveCache()
        {
            string _key = Utils.GetQueryStringValue("key");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BPt().RemoveCache(_key);

            Utils.RCWE(bllRetCode.ToString());
        }

        /// <summary>
        /// get xiaoxi
        /// </summary>
        void GetXiaoXi()
        {
            EyouSoft.Model.SSOStructure.MTongHangYongHuInfo yongHuInfo = null;
            var isLogin = EyouSoft.Security.Membership.TongHangYongHuProvider.IsLogin(out yongHuInfo);

            if (!isLogin) Utils.RCWE("[]");

            var items = new EyouSoft.BLL.CompanyStructure.BXiaoXi().PT_GetXiaoXis(yongHuInfo.CompanyId, yongHuInfo.KeHuId, yongHuInfo.YongHuId);

            if (items == null || items.Count == 0)
            {
                items = new List<EyouSoft.Model.CompanyStructure.MXiaoXiInfo>();
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.未确认订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.申请中订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.名单不全订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.预留订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.未处理兑换订单, ShuLiang = 0 });
            }

            if (items == null || items.Count == 0) Utils.RCWE("[]");
            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        /// <summary>
        /// 获取关联控位线路产品
        /// </summary>
        void GetGuanLianKongWeiXianLu()
        {
            string txtXianLuId = Utils.GetFormValue("txtXianLuId");
            DateTime? txtRiQi = Utils.GetDateTimeNullable(Utils.GetFormValue("txtRiQi"));

            if (string.IsNullOrEmpty(txtXianLuId) || !txtRiQi.HasValue) Utils.RCWE("[]");

            DateTime riQi1 = new DateTime(txtRiQi.Value.Year, txtRiQi.Value.Month, 1);
            DateTime riQi2 = riQi1.AddMonths(1).AddDays(-1);

            var items = new EyouSoft.BLL.PtStructure.BKongWeiXianLu().GetGuanLianKongWeiXianLus(txtXianLuId, riQi1, riQi2);
            if (items == null || items.Count == 0) Utils.RCWE("[]");

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        /// <summary>
        /// get jiudan chengshi
        /// </summary>
        void GetJiuDianChengShi()
        {
            var yuMingInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetYuMingInfo();

            var chaXun = new EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo();
            chaXun.LeiXing1 = 0;
            chaXun.LeiXing = 0;
            chaXun.TopExpression = 15;
            chaXun.ChengShiName = Utils.GetQueryStringValue("keyword");

            var items = new EyouSoft.BLL.CompanyStructure.City().GetChengShis(yuMingInfo.CompanyId, chaXun);

            if (items == null || items.Count == 0) Utils.RCWE("[]");

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        /// <summary>
        /// get fangxing fujian
        /// </summary>
        void GetFangXingFuJian()
        {
            string output = "[]";
            var fangXingId = Utils.GetQueryStringValue("fangxingid");

            var info = new EyouSoft.BLL.PtStructure.BJiuDian().GetFangXingInfo(fangXingId);
            if (info != null && info.FuJians != null && info.FuJians.Count > 0)
            {
                output = Newtonsoft.Json.JsonConvert.SerializeObject(info.FuJians);
            }

            Utils.RCWE(output);
        }

        /// <summary>
        /// get autocomplete kehu
        /// </summary>
        void GetAutocompleteZxs()
        {
            EyouSoft.Model.SSOStructure.MTongHangYongHuInfo yongHuInfo = null;
            var isLogin = EyouSoft.Security.Membership.TongHangYongHuProvider.IsLogin(out yongHuInfo);

            IList<EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo> items = new List<EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo>();
            var info = new EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo();
            info.ZxsId = string.Empty;
            info.ZxsName = "未能找到对应的专线商信息";
            items.Add(info);

            if (!isLogin) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));

            var chaXun = new EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsChaXunInfo();
            chaXun.TopExpression = 15;
            chaXun.ZxsName = Utils.GetQueryStringValue("q");
            var items1 = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetAutocompleteZxss(yongHuInfo.CompanyId, yongHuInfo.KeHuId, chaXun);

            if (items1 != null && items1.Count > 0) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items1));

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }
        #endregion
    }
}
