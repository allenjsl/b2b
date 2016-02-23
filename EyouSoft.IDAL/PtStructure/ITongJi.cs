using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 平台统计相关interface
    /// </summary>
    public interface ITongJi
    {
        /// <summary>
        /// 获取积分发放明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJiFenFaFangMxInfo> GetJiFenFaFangMxs(int companyId, string zxsId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenFaFangMxChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 积分发放结算统计集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJiFenFaFangJieSuanTjInfo> GetJiFenFaFangJieSuanTjs(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenFaFangJieSuanTjChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 积分收付款明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJiFenShouFuKuanMxInfo> GetJiFenShouFuKuanMxs(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenShouFuKuanMxChaXunInfo chaXun, out object[] heJi);
    }
}
