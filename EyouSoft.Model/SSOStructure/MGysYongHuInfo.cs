//供应商用户信息业务实体 汪奇志 2015-05-12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.SSOStructure
{
    /// <summary>
    /// 供应商用户信息业务实体
    /// </summary>
    public class MGysYongHuInfo
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
        /// 供应商主体编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 供应商主体联系人编号
        /// </summary>
        public int GysLxrId { get; set; }
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
        /// 联系手机
        /// </summary>
        public string ShouJi { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string DianHua { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 供应商类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.SupplierType GysLeiXing { get; set; }
    }
}
