using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 平台酒店相关interface
    /// </summary>
    public interface IJiuDian
    {
        /// <summary>
        /// 新增酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.PtStructure.MJiuDianInfo info);
        /// <summary>
        /// 修改酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.PtStructure.MJiuDianInfo info);
        /// <summary>
        /// 删除酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        int Delete(int companyId, string jiuDianId);
        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiuDianInfo GetInfo(string jiuDianId);
        /// <summary>
        /// 获取酒店集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJiuDianInfo> GetJiuDians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiuDianChaXunInfo chaXun);
        /// <summary>
        /// 新增酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int InsertFangXing(EyouSoft.Model.PtStructure.MJiuDianFangXingInfo info);
        /// <summary>
        /// 修改酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int UpdateFangXing(EyouSoft.Model.PtStructure.MJiuDianFangXingInfo info);
        /// <summary>
        /// 删除酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiuDianId">酒店编号</param>
        /// <param name="fangXingId">房型编号</param>
        /// <returns></returns>
        int DeleteFangXing(int companyId, string jiuDianId, string fangXingId);
        /// <summary>
        /// 获取酒店房型集合
        /// </summary>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJiuDianFangXingInfo> GetFangXings(string jiuDianId);
        /// <summary>
        /// 获取酒店房型信息
        /// </summary>
        /// <param name="fangXingId">房型编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiuDianFangXingInfo GetFangXingInfo(string fangXingId);
    }
}
