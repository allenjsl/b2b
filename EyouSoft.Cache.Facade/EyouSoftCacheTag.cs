using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Cache.Tag
{
    /// <summary>
    /// 缓存标签
    /// </summary>
    public static class TagName
    {
        /// <summary>
        /// 系统域名 WZYB/SYS/DOMAIN/{0}
        /// </summary>
        public const string SysDomain = "WZYB/SYS/DOMAIN/{0}";
        /// <summary>
        /// 系统域名集合 WZYB/SYS/DOMAINS
        /// </summary>
        public const string SysDomains = "WZYB/SYS/DOMAINS";
        /// <summary>
        /// 登录用户 WZYB/COM/{0}/USER/{1}
        /// </summary>
        public const string ComUser = "WZYB/COM/{0}/USER/{1}";
        /// <summary>
        /// 公司配置 WZYB/COM/{0}/SETTING
        /// </summary>
        public const string ComSetting = "WZYB/COM/{0}/SETTING";
        /// <summary>
        /// 专线商银行账户 WZYB/ZXS/{0}/YINHANGZHANGHU
        /// </summary>
        public const string ZxsYinHangZhangHu = "WZYB/ZXS/{0}/YINHANGZHANGHU";
        /// <summary>
        /// 系统维护
        /// </summary>
        public const string SysWeiHu = "WZYB/SYS/WEIHU";
        /// <summary>
        /// 专线商配置WZYB/COM/{0}/ZXS/{0}/PEIZHI
        /// </summary>
        public const string ZxsPeiZhi = "WZYB/COM/{0}/ZXS/{1}/PEIZHI";
        /// <summary>
        /// 专线商消息WZYB/COM/{0}/ZXS/{1}/XIAOXI
        /// </summary>
        public const string ZxsXiaoXi = "WZYB/COM/{0}/ZXS/{1}/XIAOXI";
        /// <summary>
        /// 平台用户消息WZYB/COM/{0}/KEHU/{1}/YONGHU/{2}/XIAOXI
        /// </summary>
        public const string KeHuXiaoXi = "WZYB/COM/{0}/KEHU/{1}/YONGHU/{2}/XIAOXI";


        /// <summary>
        /// 平台域名集合 WZYB/PT/YUMINGS
        /// </summary>
        public const string PtYuMings = "WZYB/PT/YUMINGS";
        /// <summary>
        /// 平台登录用户 WZYB/PT/COM/{0}/YONGHU/{1}
        /// </summary>
        public const string PtYongHong = "WZYB/PT/COM/{0}/YONGHU/{1}";
        /// <summary>
        /// 平台站点信息 WZYB/PT/COM/{0}/ZHANDIAN
        /// </summary>
        public const string PtZhanDian = "WZYB/PT/COM/{0}/ZHANDIAN";

        /// <summary>
        /// 平台登录用户 WZYB/GYS/COM/{0}/YONGHU/{1}
        /// </summary>
        public const string GysYongHong = "WZYB/GYS/COM/{0}/YONGHU/{1}";
        /// <summary>
        /// 供应商平台域名集合 WZYB/GYSPT/YUMINGS
        /// </summary>
        public const string GysPtYuMings="WZYB/GYSPT/YUMINGS";
    }
}
