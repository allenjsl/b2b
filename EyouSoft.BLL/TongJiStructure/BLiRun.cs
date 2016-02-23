//利润估算相关信息 汪奇志 2014-10-27
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TongJiStructure
{
    /// <summary>
    /// 利润估算相关信息
    /// </summary>
    public class BLiRun : BLLBase
    {
        private readonly EyouSoft.IDAL.TongJiStructure.ILiRun dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TongJiStructure.ILiRun>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BLiRun() { }
        #endregion

        #region public members
        /*/// <summary>
        /// 获取利润估算表1
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info> GetLiRunGuSuanBiao1s(int companyId, string zxsId, int year)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || year < 2000 || year > 2099) return null;

            return dal.GetLiRunGuSuanBiao1s(companyId, zxsId, year);
        }*/

        /// <summary>
        /// 获取利润估算表1
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">截止日期</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info> GetLiRunGuSuanBiao1s(int companyId, string zxsId, DateTime time1, DateTime time2)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return null;

            if (time1 > time2) return null;

            return dal.GetLiRunGuSuanBiao1s(companyId, zxsId, time1, time2);
        }
        #endregion
    }
}
