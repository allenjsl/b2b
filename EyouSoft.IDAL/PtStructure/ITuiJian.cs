using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 平台推荐相关interface
    /// </summary>
    public interface ITuiJian
    {
        /// <summary>
        /// 写入平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.PtStructure.MTuiJianInfo info);
        /// <summary>
        /// 修改平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.PtStructure.MTuiJianInfo info);
        /// <summary>
        /// 删除平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="tuiJianId">推荐编号</param>
        /// <returns></returns>
        int Delete(int companyId, string tuiJianId);
        /// <summary>
        /// 获取平台推荐信息
        /// </summary>
        /// <param name="tuiJianId">推荐编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MTuiJianInfo GetInfo(string tuiJianId);
        /// <summary>
        /// 获取平台推荐集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MTuiJianInfo> GetTuiJians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MTuiJianChaXunInfo chaXun);
        /// <summary>
        /// 设置推荐状态，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="tuiJianId">推荐编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiStatus(int companyId, string tuiJianId, EyouSoft.Model.EnumType.PtStructure.TuiJianStatus status);
    }
}
