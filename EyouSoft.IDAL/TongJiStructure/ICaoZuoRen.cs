//统计分析-操作人统计接口 汪奇志 2013-08-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.TongJiStructure
{
    /// <summary>
    /// 统计分析-操作人统计接口
    /// </summary>
    public interface ICaoZuoRen
    {
        /// <summary>
        /// 统计分析-获取操作人统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MCaoZuoRenInfo> GetCaoZuoRens(int companyId,string zxsId, EyouSoft.Model.TongJiStructure.MCaoZuoRenChaXunInfo chaXun);
    }
}
