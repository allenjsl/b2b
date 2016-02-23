//报价信息相关interface 汪奇志 2014-10-21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 报价信息相关interface
    /// </summary>
    public interface IBaoJia
    {
        /// <summary>
        /// 报价信息新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int BaoJia_CU(EyouSoft.Model.PtStructure.MBaoJiaInfo info);
        /// <summary>
        /// 删除报价信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        int BaoJia_D(int companyId, string zxsId, string baoJiaId);
        /// <summary>
        /// 获取报价信息
        /// </summary>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MBaoJiaInfo GetInfo(string baoJiaId);
        /// <summary>
        /// 获取报价集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MBaoJiaInfo> GetBaoJias(int companyId, string zxsId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MBaoJiaChaXunInfo chaXun);
        /// <summary>
        /// 获取最新报价信息
        /// </summary>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MBaoJiaInfo GetZuiXinBaoJiaInfo(string zxsId, int zxlbId);
    }
}
