using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 平台景点相关interface
    /// </summary>
    public interface IJingDian
    {
        /// <summary>
        /// 新增景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.PtStructure.MJingDianInfo info);
        /// <summary>
        /// 修改景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.PtStructure.MJingDianInfo info);
        /// <summary>
        /// 删除景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jingDianId">景点编号</param>
        /// <returns></returns>
        int Delete(int companyId,string jingDianId);
        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <param name="jingDianId">景点编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJingDianInfo GetInfo(string jingDianId);
        /// <summary>
        /// 获取景点集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJingDianInfo> GetJingDians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJingDianChaXunInfo chaXun);
        /// <summary>
        /// 获取景点区域集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJingDianQuYuInfo> GetJingDianQuYus(int companyId);

        /// <summary>
        /// 写入景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int InsertJingDianQuYu(EyouSoft.Model.PtStructure.MJingDianQuYuInfo info);
        /// <summary>
        /// 修改景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int UpdateJingDianQuYu(EyouSoft.Model.PtStructure.MJingDianQuYuInfo info);
        /// <summary>
        /// 删除景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">区域编号</param>
        /// <returns></returns>
        int DeleteJingDianQuYu(int companyId, int quYuId);
        /// <summary>
        /// 获取景点区域信息实体
        /// </summary>
        /// <param name="quYuId">区域编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJingDianQuYuInfo GetJingDianQuYuInfo(int quYuId);
        /// <summary>
        /// 是否存在相同的景点区域名称
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">区域编号</param>
        /// <param name="mingCheng">区域名称</param>
        /// <returns></returns>
        bool IsExistsJingDianQuYu(int companyId, int quYuId, string mingCheng);
        /// <summary>
        /// 是否存在景点(或相同的景点名称)
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">景点区域编号</param>
        /// <param name="jingDianId">景点编号</param>
        /// <param name="mingCheng">景点名称</param>
        /// <returns></returns>
        bool IsExistsJingDian(int companyId, int quYuId, int jingDianId, string mingCheng);
    }
}
