using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.SSOStructure
{
    /// <summary>
    /// 同行用户信息业务实体
    /// </summary>
    public class MTongHangYongHuInfo
    {
        /// <summary>
        /// 系统公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string XingMing { get; set; }
        /// <summary>
        /// 最后登录Ip
        /// </summary>
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户联系人编号
        /// </summary>
        public int KeHuLxrId { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 用户在线状态
        /// </summary>
        public EnumType.CompanyStructure.UserOnlineStatus OnlineStatus { get; set; }
        /// <summary>
        /// 用户会话状态标识
        /// </summary>
        public string OnlineSessionId { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public EnumType.CompanyStructure.UserStatus YongHuStaus { get; set; }
        /// <summary>
        /// 客户审核状态
        /// </summary>
        public EnumType.CompanyStructure.KeHuShenHeStatus KeHuShenHeStatus { get; set; }
        /// <summary>
        /// 联系手机
        /// </summary>
        public string ShouJi { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string DianHua { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 客户logo
        /// </summary>
        public string KeHuLogo { get; set; }
        /// <summary>
        /// 客户地址
        /// </summary>
        public string KeHuDiZhi { get; set; }
        /// <summary>
        /// 单据抬头名称
        /// </summary>
        public string DanJuTaiTouMingCheng { get; set; }
        /// <summary>
        /// 单据抬头地址
        /// </summary>
        public string DanJuTaiTouDiZhi { get; set; }
        /// <summary>
        /// 客户打印单据模板
        /// </summary>
        public string KeHuDanJuDaYinMoBan { get; set; }
        /// <summary>
        /// 单据打印模板
        /// </summary>
        public string DanJuDaYinMoBan { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        public string KeHuDianHua { get; set; }
        /// <summary>
        /// 单据抬头电话
        /// </summary>
        public string DanJuTaiTouDianHua { get; set; }
    }
}
