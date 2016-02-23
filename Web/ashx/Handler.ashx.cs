using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EyouSoft.Common;

namespace Web.ashx
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
                case "getkehucaozuoren": GetKeHuCaoZuoRen(); break;
                case "getxiaoxi": GetXiaoXi(); break;
                case "getautocompletekehu": GetAutocompleteKeHu(); break;
                case "getkehulxrxinxi": GetKeHuLxrXinXi(); break;
                case "getroutexinxi": GetRouteXinXi(); break;
                case "getautocompletefapiaodingdan": GetAutocompleteFaPiaoDingDan(); break;
                case "getautocompletedaoyou": GetAutocompleteDaoYou(); break;

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
        void NoHandler()
        {
            Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));
        }

        /// <summary>
        /// get kehu caozuoren
        /// </summary>
        void GetKeHuCaoZuoRen()
        {
            string txtKeHuId = Utils.GetQueryStringValue("txtkehuid");
            if (string.IsNullOrEmpty(txtKeHuId)) Utils.RCWE("[]");
            var info = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(txtKeHuId);
            if (info == null || info.CustomerContact == null || info.CustomerContact.Count == 0) Utils.RCWE("[]");

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info.CustomerContact));
        }

        /// <summary>
        /// get xiaoxi
        /// </summary>
        void GetXiaoXi()
        {
            bool privs0 = false, privs1 = false, privs2 = false, privs3 = false, privs4 = false, privs5 = false;
            
            EyouSoft.Model.SSOStructure.MUserInfo uinfo = null;
            var isLogin=EyouSoft.Security.Membership.UserProvider.IsLogin(out uinfo);

            if (!isLogin) Utils.RCWE("[]"); 

            var items = new EyouSoft.BLL.CompanyStructure.BXiaoXi().GetXiaoXis(uinfo.CompanyId, uinfo.ZxsId, uinfo.UserId);

            if (items == null || items.Count == 0)
            {
                items=new List<EyouSoft.Model.CompanyStructure.MXiaoXiInfo>();
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.未确认订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.申请中订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.名单不全订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.预留订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.未处理兑换订单, ShuLiang = 0 });
                items.Add(new EyouSoft.Model.CompanyStructure.MXiaoXiInfo() { LeiXing = EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.未审核注册用户, ShuLiang = 0 });
            }

            privs0 = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_消息提醒_未确认订单);
            privs1 = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_消息提醒_申请中订单);
            privs2 = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_消息提醒_名单不全订单);
            privs3 = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_消息提醒_预留订单);
            privs4 = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_消息提醒_未处理兑换订单);
            privs5 = EyouSoft.Security.Membership.UserProvider.IsPrivs3(uinfo.Privs, (int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_消息提醒_未审核注册用户);

            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].LeiXing == EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.未确认订单 && !privs0) { items.RemoveAt(i); continue; }
                if (items[i].LeiXing == EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.申请中订单 && !privs1) { items.RemoveAt(i); continue; }
                if (items[i].LeiXing == EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.名单不全订单 && !privs2) { items.RemoveAt(i); continue; }
                if (items[i].LeiXing == EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.预留订单 && !privs3) { items.RemoveAt(i); continue; }
                if (items[i].LeiXing == EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.未处理兑换订单 && !privs4) { items.RemoveAt(i); continue; }
                if (items[i].LeiXing == EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing.未审核注册用户 && !privs5) { items.RemoveAt(i); continue; }
            }

            if (items == null || items.Count == 0) Utils.RCWE("[]");

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        /// <summary>
        /// get autocomplete kehu
        /// </summary>
        void GetAutocompleteKeHu()
        {
            EyouSoft.Model.SSOStructure.MUserInfo uinfo = null;
            var isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out uinfo);

            var items = new List<MAjaxAutocompleteKeHuInfo>();
            var info = new MAjaxAutocompleteKeHuInfo();
            info.KeHuId = string.Empty;
            info.KeHuName = "未能找到对应的客户信息";
            items.Add(info);

            if (!isLogin) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items)); 

            int recordCount = 0;
            var chaXun = new EyouSoft.Model.CompanyStructure.MCustomerSeachInfo();
            chaXun.ShenHeStatus = EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.已审核;
            chaXun.CustomerName = Utils.GetQueryStringValue("q");
            chaXun.OrderByType = 1;
            var items1 = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomers(uinfo.CompanyId, 10, 1, ref recordCount, chaXun);

            if (items1 == null || items1.Count == 0) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));

            items = new List<MAjaxAutocompleteKeHuInfo>();
            foreach (var item in items1)
            {
                var info1 = new MAjaxAutocompleteKeHuInfo();
                info1.KeHuId = item.Id;
                info1.KeHuName = item.Name;
                items.Add(info1);
            }

            EyouSoft.Common.Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        /// <summary>
        /// get kehulxr xinxi
        /// </summary>
        void GetKeHuLxrXinXi()
        {
            EyouSoft.Model.SSOStructure.MUserInfo uinfo = null;
            var isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out uinfo);
            var info = new MAjaxKeHuLxrInfo();

            if (!isLogin) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));

            int keHuLxrId = Utils.GetInt(Utils.GetFormValue("txtKeHuLxrId"));
            string txtKeHuId = Utils.GetFormValue("txtKeHuId");
            var info1 = new EyouSoft.BLL.CompanyStructure.Customer().GetKeHuLxrInfo(txtKeHuId, keHuLxrId);

            if (info1 == null) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));

            info.DianHua = info1.Tel;
            info.Fax = info1.Fax;
            info.ShouJi = info1.Mobile;
            info.XingMing = info1.Name;

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
        }

        /// <summary>
        /// get route xinxi
        /// </summary>
        void GetRouteXinXi()
        {
            var info = new MAjaxRouteInfo();
            EyouSoft.Model.SSOStructure.MUserInfo uinfo = null;
            var isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out uinfo);

            if (!isLogin) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));

            string txtRouteId = Utils.GetFormValue("txtRouteId");
            string txtXianLuId = Utils.GetFormValue("txtXianLuId"); Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));

            if (string.IsNullOrEmpty(txtRouteId) && string.IsNullOrEmpty(txtXianLuId)) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));

            if (!string.IsNullOrEmpty(txtXianLuId))
            {
                var info1 = new EyouSoft.BLL.TourStructure.BTour().GetKongWeiXianLuInfo(txtXianLuId);
                if (info1 != null) txtRouteId = info1.RouteId;
            }

            if (string.IsNullOrEmpty(txtRouteId)) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));

            var info2 = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(txtRouteId);
            if (info2 == null) Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));

            info.JiHeDiDian = info2.JiHeDiDian;
            info.JiHeShiJian = info2.JiHeShiJian;
            info.MuDiDiJieTuanFangShi = info2.MuDiDiJieTuanFangShi;
            info.SongTuanXinXi = info2.SongTuanXinXi;

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
        }

        /// <summary>
        /// get autocomplete fapiao dindan
        /// </summary>
        void GetAutocompleteFaPiaoDingDan()
        {
            EyouSoft.Model.SSOStructure.MUserInfo uinfo = null;
            var isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out uinfo);

            IList<EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo> items = new List<EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo>();

            if (!isLogin)
            {
                items.Add(new EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo() { DingDanId = "", DingDanHao = "未能找对对应的订单" });

                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
            }

            var chaXun = new EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingChaXunDanInfo();

            chaXun.DingDanHao = Utils.GetQueryStringValue("q");
            chaXun.KeHuId = Utils.GetQueryStringValue("kehuid");
            chaXun.TopExpression = 10;
            chaXun.DingDanId0 = Utils.GetQueryStringValue("dingdanid");
            chaXun.NotInDingDanId=new List<string>();            
            var txtNotInDingDanId = Utils.GetQueryStringValue("notindingdanid");

            if (!string.IsNullOrEmpty(txtNotInDingDanId))
            {
                var _items = txtNotInDingDanId.Split(',');

                if (_items != null && _items.Length > 0)
                {
                    foreach (var item in _items)
                    {
                        if (item != chaXun.DingDanId0) chaXun.NotInDingDanId.Add(item);
                    }
                }
            }

            if (string.IsNullOrEmpty(chaXun.KeHuId))
            {
                items.Add(new EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo() { DingDanId = "", DingDanHao = "请先选择客户单位" });

                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
            }

            var items1 = new EyouSoft.BLL.FinStructure.BFaPiao().GetAutocompleteFaPiaoDingDans(uinfo.CompanyId, uinfo.ZxsId, chaXun);

            if (items1 != null && items1.Count >0)
            {
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items1));
            }

            items.Add(new EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo() { DingDanId = "", DingDanHao = "未能找对对应的订单" });
            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        /// <summary>
        /// get autocomplete daoyou
        /// </summary>
        void GetAutocompleteDaoYou()
        {
            int companyId = 0;
            int recordCount = 0;            
            var chaXun = new EyouSoft.Model.GysStructure.MGysZhuTiDaoYouChaXunInfo();

            chaXun.GysZhuTiId = string.Empty;
            chaXun.DaoYouName = Utils.GetQueryStringValue("q");
            chaXun.GysId = Utils.GetQueryStringValue("q1");

            EyouSoft.Model.SSOStructure.MUserInfo loginYongHuInfo = null;
            var isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out loginYongHuInfo);
            if (isLogin)
            {
                companyId = loginYongHuInfo.CompanyId;
            }

            var items = new EyouSoft.BLL.GysStructure.BGysZhuTi().GetZhuTiDaoYous(companyId, 10, 1, ref recordCount, chaXun);
            if (items == null || items.Count == 0)
            {
                items = new List<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo>();
                items.Add(new EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo() { DaoYouName = "未匹配到导游，请直接录入，建议录入格式如：张姐 13812345678" });
            }

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }
        #endregion


        #region AJAX线路信息业务实体
        /// <summary>
        /// AJAX线路信息业务实体
        /// </summary>
        class MAjaxRouteInfo
        {
            /// <summary>
            /// default constructor
            /// </summary>
            public MAjaxRouteInfo()
            {
                this.JiHeShiJian = string.Empty;
                this.JiHeDiDian = string.Empty;
                this.SongTuanXinXi = string.Empty;
                this.MuDiDiJieTuanFangShi = string.Empty;
            }

            /// <summary>
            /// 集合地点
            /// </summary>
            public string JiHeDiDian { get; set; }
            /// <summary>
            /// 集合时间
            /// </summary>
            public string JiHeShiJian { get; set; }
            /// <summary>
            /// 送团信息
            /// </summary>
            public string SongTuanXinXi { get; set; }
            /// <summary>
            /// 目的地接团方式
            /// </summary>
            public string MuDiDiJieTuanFangShi { get; set; }
        }
        #endregion

        #region AJAX客户联系人信息业务实体
        /// <summary>
        /// AJAX客户联系人信息业务实体
        /// </summary>
        class MAjaxKeHuLxrInfo
        {
            /// <summary>
            /// default constructor
            /// </summary>
            public MAjaxKeHuLxrInfo()
            {
                this.XingMing = string.Empty;
                this.DianHua = string.Empty;
                this.ShouJi = string.Empty;
                this.Fax = string.Empty;
            }

            /// <summary>
            /// 姓名
            /// </summary>
            public string XingMing { get; set; }
            /// <summary>
            /// 电话
            /// </summary>
            public string DianHua { get; set; }
            /// <summary>
            /// 手机
            /// </summary>
            public string ShouJi { get; set; }
            /// <summary>
            /// 传真
            /// </summary>
            public string Fax { get; set; }
        }
        #endregion

        #region AJAX自动完成客户信息业务实体
        /// <summary>
        /// AJAX自动完成客户信息业务实体
        /// </summary>
        class MAjaxAutocompleteKeHuInfo
        {
            public string KeHuId { get; set; }
            public string KeHuName { get; set; }
        }
        #endregion
    }
}
