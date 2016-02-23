//专线商权限模板相关interface 汪奇志 2014-10-22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 专线商权限模板相关interface
    /// </summary>
    public interface IZxsPrivsMoBan
    {
        /// <summary>
        /// 写入权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo info);
        /// <summary>
        /// 修改权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo info);
        /// <summary>
        /// 删除权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="moBanId">模板编号</param>
        /// <returns></returns>
        int Delete(int companyId, string moBanId);
        /// <summary>
        /// 获取模板信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo> GetMoBans(int companyId);
        /// <summary>
        /// 获取模板信息
        /// </summary>
        /// <param name="moBanId">模板编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo GetInfo(string moBanId);
        /// <summary>
        /// 设置模板权限，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="moBanId">模板编号</param>
        /// <param name="privs1">一级栏目</param>
        /// <param name="privs2">二级栏目</param>
        /// <param name="privs3">明细权限</param>
        /// <returns></returns>
        int SheZhiPrivs(int companyId, string moBanId, string privs1, string privs2, string privs3);
    }
}
