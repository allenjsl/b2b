//供应商用户登录处理类 汪奇志 2015-05-13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EyouSoft.Cache.Facade;

namespace EyouSoft.Security.Membership
{
    /// <summary>
    /// 供应商用户登录处理类
    /// </summary>
    public class GysYongHuProvider
    {
        #region static constants
        /// <summary>
        /// 登录Cookie，用户编号
        /// </summary>
        public const string LoginCookieYongHuId = "JMGLV_GYS_UID";
        /// <summary>
        /// 登录Cookie，用户账号
        /// </summary>
        public const string LoginCookieUsername = "JMGLV_GYS_UN";
        /// <summary>
        /// 登录Cookie，公司编号
        /// </summary>
        public const string LoginCookieCompanyId = "JMGLV_GYS_CID";
        /// <summary>
        /// 登录Cookie，客户编号
        /// </summary>
        public const string LoginCookieGysId = "JMGLV_GYS_GYSID";
        /// <summary>
        /// 登录Cookie，会话标识
        /// </summary>
        public const string LoginCookieSessionId = "JMGLV_GYS_SESSIONID";
        /// <summary>
        /// 登录Cookie，COOKIES保留天数
        /// </summary>
        public const string LoginCookieTian = "JMGLV_GYS_CTIAN";
        #endregion

        #region private members
        /// <summary>
        /// 设置登录用户cache
        /// </summary>
        /// <param name="info">登录用户信息</param>
        static void SetYongHuCache(EyouSoft.Model.SSOStructure.MGysYongHuInfo info)
        {
            string cacheKey = string.Format(Cache.Tag.TagName.GysYongHong, info.CompanyId, info.YongHuId);
            EyouSoftCache.Remove(cacheKey);
            EyouSoftCache.Add(cacheKey, info, DateTime.Now.AddHours(12));
        }

        /// <summary>
        /// 设置登录Cookies
        /// </summary>
        /// <param name="info">登录用户信息</param>
        static void SetLoginCookies(EyouSoft.Model.SSOStructure.MGysYongHuInfo info, double cookieTian)
        {
            //Cookies生存周期为浏览器进程
            HttpResponse response = HttpContext.Current.Response;

            RemoveLoginCookies();

            var cookie = new HttpCookie(LoginCookieCompanyId);
            cookie.Value = info.CompanyId.ToString();
            cookie.HttpOnly = true;
            if (cookieTian > 0) cookie.Expires = DateTime.Now.AddDays(cookieTian);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieYongHuId);
            cookie.Value = info.YongHuId.ToString();
            cookie.HttpOnly = true;
            if (cookieTian > 0) cookie.Expires = DateTime.Now.AddDays(cookieTian);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieUsername);
            cookie.Value = HttpContext.Current.Server.UrlEncode(info.Username);
            cookie.HttpOnly = true;
            if (cookieTian > 0) cookie.Expires = DateTime.Now.AddDays(cookieTian);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieSessionId);
            cookie.Value = info.OnlineSessionId;
            cookie.HttpOnly = true;
            if (cookieTian > 0) cookie.Expires = DateTime.Now.AddDays(cookieTian);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieGysId);
            cookie.Value = info.GysId;
            cookie.HttpOnly = true;
            if (cookieTian > 0) cookie.Expires = DateTime.Now.AddDays(cookieTian);
            response.AppendCookie(cookie);

            cookie = new HttpCookie(LoginCookieTian);
            cookie.Value = cookieTian.ToString();
            cookie.HttpOnly = true;
            if (cookieTian > 0) cookie.Expires = DateTime.Now.AddDays(cookieTian);
            response.AppendCookie(cookie);

        }

        /// <summary>
        /// remove login cookies
        /// </summary>
        static void RemoveLoginCookies()
        {
            HttpResponse response = HttpContext.Current.Response;

            response.Cookies.Remove(LoginCookieCompanyId);
            response.Cookies.Remove(LoginCookieYongHuId);
            response.Cookies.Remove(LoginCookieUsername);
            response.Cookies.Remove(LoginCookieSessionId);
            response.Cookies.Remove(LoginCookieGysId);
            response.Cookies.Remove(LoginCookieTian);

            DateTime cookiesExpiresDateTime = DateTime.Now.AddDays(-1);

            response.Cookies[LoginCookieCompanyId].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieYongHuId].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieUsername].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieSessionId].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieGysId].Expires = cookiesExpiresDateTime;
            response.Cookies[LoginCookieTian].Expires = cookiesExpiresDateTime;
        }

        /// <summary>
        /// 获取登录用户Cookie信息
        /// </summary>
        /// <param name="name">登录Cookie名称</param>
        /// <returns></returns>
        static string GetCookie(string name)
        {
            HttpRequest request = HttpContext.Current.Request;

            if (request.Cookies[name] == null)
            {
                return string.Empty;
            }

            return HttpContext.Current.Server.UrlDecode(request.Cookies[name].Value);
        }

        /// <summary>
        /// 自动登录处理
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gysId">供应商编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="username">用户名</param>
        static void AutoLogin(int companyId, string gysId, int yongHuId, string username, out EyouSoft.Model.SSOStructure.MGysYongHuInfo yongHuInfo)
        {
            yongHuInfo = null;
            if (companyId < 1 || string.IsNullOrEmpty(gysId) || yongHuId < 1 || string.IsNullOrEmpty(username)) return;

            IGysYongHu dal = new DGysYongHu();
            var yuMingInfo = GetYuMingInfo();
            if (yuMingInfo == null || yuMingInfo.CompanyId < 1 || string.IsNullOrEmpty(yuMingInfo.ErpYuMing)) return;

            yongHuInfo = dal.Login(companyId, username, yongHuId, gysId);

            if (yongHuInfo == null) return;
            if (yongHuInfo.YongHuStaus != Model.EnumType.CompanyStructure.UserStatus.正常) { yongHuInfo = null; return; }

            yongHuInfo.LoginTime = yongHuInfo.LastLoginTime.HasValue ? yongHuInfo.LastLoginTime.Value : DateTime.Now;

            dal.LoginLogwr(yongHuInfo, Model.EnumType.CompanyStructure.UserLoginType.自动登录);

            SetYongHuCache(yongHuInfo);
        }

        /// <summary>
        /// 移除登录用户cache
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="userId">用户编号</param>
        static void RemoveYongHuCache(int companyId, int userId)
        {
            string cacheKey = string.Format(Cache.Tag.TagName.PtYongHong, companyId, userId);

            EyouSoftCache.Remove(cacheKey);
        }
        #endregion

        #region public members
        /// <summary>
        /// 获取当前域名信息
        /// </summary>
        /// <returns></returns>
        public static EyouSoft.Model.PtStructure.MYuMingInfo GetYuMingInfo()
        {
            string s = HttpContext.Current.Request.Url.Host.ToLower();

            var yumings = (IDictionary<string, EyouSoft.Model.PtStructure.MYuMingInfo>)EyouSoftCache.GetCache(EyouSoft.Cache.Tag.TagName.GysPtYuMings);
            EyouSoft.Model.PtStructure.MYuMingInfo info = null;
            yumings = yumings ?? new Dictionary<string, EyouSoft.Model.PtStructure.MYuMingInfo>();
            if (yumings.ContainsKey(s))
            {
                info = yumings[s];
            }
            else
            {
                IGysYongHu dal = new DGysYongHu();
                info = dal.GetYuMingInfo(s);
                if (info != null)
                {
                    yumings.Add(s, info);
                    EyouSoftCache.Add(Cache.Tag.TagName.PtYuMings, yumings);
                }
            }

            return info;
        }

        /// <summary>
        /// 获取域名信息集合
        /// </summary>
        /// <returns></returns>
        public static IList<EyouSoft.Model.PtStructure.MYuMingInfo> GetYuMings()
        {
            IGysYongHu dal = new DGysYongHu();
            var items=dal.GetYuMings();
            return items;
        }

        /// <summary>
        /// 用户登录，返回1登录成功，其它失败
        /// </summary>
        /// <param name="companyId">系统公司编号</param>
        /// <param name="username">用户名</param>
        /// <param name="pwdInfo">登录密码</param>
        /// <param name="yongHuInfo">登录用户信息</param>
        /// <returns></returns>
        public static int Login(int companyId, string username, EyouSoft.Model.CompanyStructure.PassWord pwdInfo, out EyouSoft.Model.SSOStructure.MGysYongHuInfo yongHuInfo, double cookieTian)
        {
            IGysYongHu dal = new DGysYongHu();
            yongHuInfo = null;

            if (companyId <= 0) return 0;
            if (string.IsNullOrEmpty(username)) return -1;
            if (pwdInfo == null || string.IsNullOrEmpty(pwdInfo.MD5Password)) return -2;
            EyouSoft.Model.PtStructure.MYuMingInfo yuMingInfo = GetYuMingInfo();
            if (yuMingInfo == null || yuMingInfo.CompanyId < 1 || string.IsNullOrEmpty(yuMingInfo.ErpYuMing)) return -3;

            yongHuInfo = dal.Login(companyId, username, pwdInfo);
            if (yongHuInfo == null) return -4;

            if (yongHuInfo.YongHuStaus != Model.EnumType.CompanyStructure.UserStatus.正常)
            {
                yongHuInfo = null;
                return -5;
            }

            yongHuInfo.OnlineStatus = Model.EnumType.CompanyStructure.UserOnlineStatus.Online;
            yongHuInfo.OnlineSessionId = Guid.NewGuid().ToString();
            if (!yongHuInfo.LastLoginTime.HasValue) yongHuInfo.LastLoginTime = yongHuInfo.LoginTime;

            dal.LoginLogwr(yongHuInfo, EyouSoft.Model.EnumType.CompanyStructure.UserLoginType.用户登录);

            SetYongHuCache(yongHuInfo);
            SetLoginCookies(yongHuInfo, cookieTian);

            return 1;
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <returns></returns>
        public static EyouSoft.Model.SSOStructure.MGysYongHuInfo GetYongHuInfo()
        {
            EyouSoft.Model.SSOStructure.MGysYongHuInfo info = null;
            int companyId = Toolkit.Utils.GetInt(GetCookie(LoginCookieCompanyId));
            int yongHuId = Toolkit.Utils.GetInt(GetCookie(LoginCookieYongHuId));
            string username = GetCookie(LoginCookieUsername);
            string gysId = GetCookie(LoginCookieGysId);

            if (companyId <= 0
                || yongHuId <= 0
                || string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(gysId))
            {
                return null;
            }

            //从缓存查询登录用户信息
            string cacheKey = string.Format(Cache.Tag.TagName.GysYongHong, companyId, yongHuId);
            //从缓存查询登录用户信息计数器
            int getCacheCount = 2;

            do
            {
                info = (EyouSoft.Model.SSOStructure.MGysYongHuInfo)EyouSoftCache.GetCache(cacheKey);
                getCacheCount--;
            } while (info == null && getCacheCount > 0);

            //缓存中未找到登录用户信息，自动登录处理
            if (info == null)
            {
                AutoLogin(companyId, gysId, yongHuId, username, out info);
            }

            if (info == null) return null;

            return info;
        }

        /// <summary>
        /// 用户是否登录
        /// </summary>
        /// <param name="info">登录用户信息</param>
        /// <returns></returns>
        public static bool IsLogin(out EyouSoft.Model.SSOStructure.MGysYongHuInfo info)
        {
            info = GetYongHuInfo();

            if (info == null) return false;

            return true;
        }

        /// <summary>
        /// 用户是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            var info = GetYongHuInfo();

            if (info == null) return false;

            return true;
        }

        /// <summary>
        /// 用户退出
        /// </summary>
        public static void Logout()
        {
            int companyId = Toolkit.Utils.GetInt(GetCookie(LoginCookieCompanyId));
            int userId = Toolkit.Utils.GetInt(GetCookie(LoginCookieYongHuId));

            if (userId > 0 && companyId > 0)
            {
                RemoveYongHuCache(companyId, userId);
            }

            RemoveLoginCookies();

            IGysYongHu dal = new DGysYongHu();
            dal.SetOnlineStatus(userId, Model.EnumType.CompanyStructure.UserOnlineStatus.Offline, "00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// 获取专线商配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public static EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo GetZxsPeiZhiInfo(int companyId, string zxsId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return null;
            IGysYongHu dal = new DGysYongHu();
            var info = dal.GetZxsPeiZhiInfo(companyId, zxsId);
            return info;
        }

        /// <summary>
        /// 获取系统配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public static EyouSoft.Model.CompanyStructure.CompanyFieldSetting GetXiTongPeiZhiInfo(int companyId)
        {
            if (companyId < 1) return null;

            IGysYongHu dal = new DGysYongHu();
            var info = dal.GetXiTongPeiZhiInfo(companyId);
            return info;
        }
        #endregion
    }
}
