﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PersonalCenterStructure
{
    using EyouSoft.Model.PersonalCenterStructure;
    using EyouSoft.Model.PlanStructure;
    using EyouSoft.Model.TourStructure;

    public interface ITranRemind
    {
        /// <summary>
        /// 分页获取收款提醒
        /// </summary>
        /// <param name="pageSize">每页显示数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="searchInfo">查询信息</param>
        /// <returns></returns>
        IList<MShouKuanTiXingInfo> GetShouKuanTiXings(int pageSize, int pageIndex, ref int recordCount, int companyId, MShouKuanTiXingChaXunInfo searchInfo);

        /// <summary>
        /// 根据客户单位编号、出团时间开始、出团时间结束获取未收款明细
        /// </summary>
        /// <param name="pageSize">每页显示数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="customerId">客户单位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MShouKuanTiXingMingXiInfo> GetShouKuanTiXingMxs(
            int pageSize, int pageIndex, ref int recordCount, string customerId, MShouKuanTiXingChaXunInfo chaXun);

        /// <summary>
        /// 分页获取付款提醒
        /// </summary>
        /// <param name="pageSize">每页显示数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="searchInfo">查询实体</param>
        /// <returns></returns>
        IList<MFuKuanTiXingInfo> GetFuKuanTiXings(int pageSize, int pageIndex, ref int recordCount, int companyId, FuKuanTiXingChaXun searchInfo);

        /// <summary>
        /// 供应商编号、出团时间开始、出团时间结束获取未付款明细
        /// </summary>
        /// <param name="pageSize">每页显示数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="supplierId">供应商编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MFuKuanTiXingMingXiInfo> GetFuKuanTiXingMxs(
            int pageSize, int pageIndex, ref int recordCount, string supplierId, FuKuanTiXingChaXun chaXun);
    }
}
