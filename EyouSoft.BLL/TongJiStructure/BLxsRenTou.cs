//统计分析-旅行社人头统计 汪奇志 2013-08-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TongJiStructure
{
    /// <summary>
    /// 统计分析-旅行社人头统计
    /// </summary>
    public class BLxsRenTou : BLLBase
    {
        private readonly EyouSoft.IDAL.TongJiStructure.ILxsRenTou dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TongJiStructure.ILxsRenTou>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BLxsRenTou() { }
        #endregion

        #region public members
        /// <summary>
        /// 统计分析-获取旅行社人头统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="year">年份</param>
        /// <param name="diQu">地区</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MLxsRenTouInfo> GetLxsRenTous(int companyId, string zxsId, int year, EyouSoft.Model.EnumType.CompanyStructure.ChengShiDiQu diQu, EyouSoft.Model.TongJiStructure.MLxsRenTourChaXunInfo chaXun)
        {
            if (companyId < 1
                || string.IsNullOrEmpty(zxsId)
                || year < 2000
                || year > 9999) return null;

            return dal.GetLxsRenTous(companyId,zxsId, year, diQu, chaXun);
        }

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
        public IList<EyouSoft.Model.TongJiStructure.MLxsRenTouXXInfo> GetLxsRenTouXXs(int companyId, string zxsId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MLxsRenTouXXChaXunInfo chaXun)
        {
            if (companyId < 1
                ||string.IsNullOrEmpty(zxsId)
                || !ValidPaging(pageSize, pageIndex)
                || chaXun == null
                || chaXun.CityId < 1
                || chaXun.YYYY < 2000
                || chaXun.YYYY > 9999
                || chaXun.MM < 1
                || chaXun.MM > 12) return null;

            return dal.GetLxsRenTouXXs(companyId,zxsId, pageSize, pageIndex, ref recordCount, chaXun);
        }
        #endregion
    }
}
