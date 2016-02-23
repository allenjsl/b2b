//银行核对相关信息数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    public interface IYinHangHeDui
    {
        /// <summary>
        /// 写入银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MYinHangHeDuiInfo info);
        /// <summary>
        /// 修改银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MYinHangHeDuiInfo info);
        /// <summary>
        /// 删除银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        int Delete(string heDuiId, int companyId);
        /// <summary>
        /// 获取银行核对信息
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <returns></returns>
        MYinHangHeDuiInfo GetInfo(string heDuiId);
        /// <summary>
        /// 获取银行核对状态
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <returns></returns>
        EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus GetStatus(string heDuiId);
        /// <summary>
        /// 获取银行核对信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        IList<MYinHangHeDuiInfo> GetHeDuis(int companyId, int pageSize, int pageIndex, ref int recordCount, MYinHangHeDuiChaXunInfo chaXun);
        /// <summary>
        /// 银行核对信息确认
        /// </summary>
        /// <param name="heDuiId">银行核对登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QueRen(string heDuiId, MOperatorInfo info);
    }
}
