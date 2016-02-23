using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Security.Membership
{
    /// <summary>
    /// 同行用户登录处理数据访问接口
    /// </summary>
    internal interface ITongHangYongHu
    {
        /// <summary>
        /// 获取域名信息
        /// </summary>
        /// <param name="yuMing">域名</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MYuMingInfo GetYuMingInfo(string yuMing);
        /// <summary>
        /// 用户登录，根据系统公司编号、用户名、用户密码获取用户信息
        /// </summary>
        /// <param name="companyId">系统公司编号</param>
        /// <param name="username">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        EyouSoft.Model.SSOStructure.MTongHangYongHuInfo Login(int companyId, string username, EyouSoft.Model.CompanyStructure.PassWord pwd);
        /// <summary>
        /// 用户登录，根据系统公司编号、用户名、用户编号、客户编号获取用户信息
        /// </summary>
        /// <param name="companyId">系统公司编号</param>
        /// <param name="username">登录账号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <returns></returns>
        EyouSoft.Model.SSOStructure.MTongHangYongHuInfo Login(int companyId, string username, int yongHuId, string keHuId);
        /// <summary>
        /// 写登录日志，用户登录时更新最后登录时间、在线状态、会话标识
        /// </summary>
        /// <param name="info">登录用户信息</param>
        /// <param name="loginType">登录类型</param>
        void LoginLogwr(EyouSoft.Model.SSOStructure.MTongHangYongHuInfo info, Model.EnumType.CompanyStructure.UserLoginType loginType);

        /// <summary>
        /// 设置用户在线状态，返回1成功，其它失败
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="status">在线状态</param>
        /// <param name="onlineSessionId">用户会话状态标识</param>
        /// <returns></returns>
        int SetOnlineStatus(int yongHuId, Model.EnumType.CompanyStructure.UserOnlineStatus status, string onlineSessionId);
        /// <summary>
        /// 根据行政区划代码获取站点编号
        /// </summary>
        /// <param name="xzqhdm">行政区划代码</param>
        /// <returns></returns>
        int GetZhanDianIdByXzqhdm(string xzqhdm);
        /// <summary>
        /// 获取专线商配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo GetZxsPeiZhiInfo(int companyId, string zxsId);

        /// <summary>
        /// 获取系统配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.CompanyFieldSetting GetXiTongPeiZhiInfo(int companyId);
    }
}
