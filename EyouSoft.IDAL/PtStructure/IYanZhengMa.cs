//汪奇志 2014-09-15 平台验证码相关数据访问类
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 验证码相关interface
    /// </summary>
    public interface IYanZhengMa
    {
        /// <summary>
        /// 写入验证码信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.PtStructure.MYanZhengMaInfo info);
        /// <summary>
        /// 获取验证码信息
        /// </summary>
        /// <param name="yanZhengMaId">验证码编号</param>
        /// <param name="yanZhengMa">验证码</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MYanZhengMaInfo GetInfo(string yanZhengMaId, string yanZhengMa, EyouSoft.Model.EnumType.PtStructure.YanZhengMaLeiXing leiXing);
        /// <summary>
        /// 设置验证码状态，返回1成功，其它失败
        /// </summary>
        /// <param name="yanZhengMaId">验证码编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SetStatus(string yanZhengMaId, EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus status);
    }
}
