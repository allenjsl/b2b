//统计分析-旅行社人头统计接口 汪奇志 2013-08-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.TongJiStructure
{
    /// <summary>
    /// 统计分析-旅行社人头统计接口
    /// </summary>
    public interface ILxsRenTou
    {
        /// <summary>
        /// 统计分析-获取旅行社人头统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="year">年份</param>
        /// <param name="diQu">地区</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MLxsRenTouInfo> GetLxsRenTous(int companyId,string zxsId, int year, EyouSoft.Model.EnumType.CompanyStructure.ChengShiDiQu diQu, EyouSoft.Model.TongJiStructure.MLxsRenTourChaXunInfo chaXun);

        /// <summary>
        /// 统计分析-获取旅行社人头统计明细信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MLxsRenTouXXInfo> GetLxsRenTouXXs(int companyId, string zxsId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MLxsRenTouXXChaXunInfo chaXun);
    }
}
