using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.CompanyStructure
{
    /// <summary>
    /// 消息数据访问类接口
    /// </summary>
    public interface IXiaoXi
    {
        /// <summary>
        /// （管理后台）获取消息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo> GetXiaoXis(int companyId, string zxsId, int yongHuId);
        /// <summary>
        /// （同行后台）获取消息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo> PT_GetXiaoXis(int companyId, string keHuId, int yongHuId);
    }
}
