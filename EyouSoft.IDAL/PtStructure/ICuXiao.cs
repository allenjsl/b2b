//汪奇志 2014-08-22 平台促销数据访问类接口
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 平台促销数据访问类接口
    /// </summary>
    public interface ICuXiao
    {
        /// <summary>
        /// 写入促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.PtStructure.MCuXiaoInfo info);
        /// <summary>
        /// 修改促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.PtStructure.MCuXiaoInfo info);
        /// <summary>
        /// 删除促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="cuXiaoId">促销编号</param>
        /// <returns></returns>
        int Delete(int companyId, string cuXiaoId);
        /// <summary>
        /// 获取促销信息
        /// </summary>
        /// <param name="cuXiaoId">促销编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MCuXiaoInfo GetInfo(string cuXiaoId);
        /// <summary>
        /// 获取促销信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MCuXiaoInfo> GetCuXiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MCuXiaoChaXunInfo chaXun);
        /// <summary>
        /// 设置促销状态，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="cuXiaoId">促销编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiStatus(int companyId, string cuXiaoId, EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus status);
    }
}
