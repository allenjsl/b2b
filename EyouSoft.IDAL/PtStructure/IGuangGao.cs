using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 平台广告信息相关interface
    /// </summary>
    public interface IGuangGao
    {
        /// <summary>
        /// 新增广告，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.PtStructure.MGuangGaoInfo info);
        /// <summary>
        /// 修改广告，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.PtStructure.MGuangGaoInfo info);
        /// <summary>
        /// 删除广告，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="guangGaoId">广告编号</param>
        /// <returns></returns>
        int Delete(int companyId, string guangGaoId);
        /// <summary>
        /// 获取广告信息
        /// </summary>
        /// <param name="guangGaoId">广告编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MGuangGaoInfo GetInfo(string guangGaoId);
        /// <summary>
        /// 获取广告集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MGuangGaoInfo> GetGuangGaos(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo chaXun);
        /// <summary>
        /// 设置广告状态，返回1成功，其它失败
        /// </summary>
        /// <param name="guangGaoId">广告编号</param>
        /// <param name="status">广告状态</param>
        /// <returns></returns>
        int SheZhiGuangGaoStatus(string guangGaoId, EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus status);
    } 
}
