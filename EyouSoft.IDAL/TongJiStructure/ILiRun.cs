//利润估算相关信息interface 汪奇志 2014-10-27
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.TongJiStructure
{
    /// <summary>
    /// 利润估算相关信息interface
    /// </summary>
    public interface ILiRun
    {
        /*/// <summary>
        /// 获取利润估算表1
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info> GetLiRunGuSuanBiao1s(int companyId, string zxsId, int year);*/
        /// <summary>
        /// 获取利润估算表1
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">截止日期</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info> GetLiRunGuSuanBiao1s(int companyId, string zxsId, DateTime time1, DateTime time2);
    }
}
