//汪奇志 2013-02-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理-资产负债表数据访问类接口
    /// </summary>
    public interface IZiChanFuZhai
    {
        /// <summary>
        /// 是否存在相同的资产负债年月份信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        bool IsExists(int companyId, int year, int month, string ziChanFuZhaiId,string zxsId);
        /// <summary>
        /// 写入资产负债表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MZiChanFuZhaiInfo info);
        /// <summary>
        /// 获取资产负债表信息
        /// </summary>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <returns></returns>
        MZiChanFuZhaiInfo GetInfo(string ziChanFuZhaiId);
        /// <summary>
        /// 更新资产负债表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MZiChanFuZhaiInfo info);
        /// <summary>
        /// 删除资产负债表信息
        /// </summary>
        /// <param name="liRunId">资产负债编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        int Delete(string ziChanFuZhaiId, int companyId);
        /// <summary>
        /// 获取资产负债表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息 [0:decimal:货币资金][1:decimal:应收帐款][2:decimal:其他应收款][3:decimal:预付帐款][4:decimal:应付帐款][5:decimal:预收帐款][6:decimal:实收股本][7:decimal:未分配利润][8:decimal:差额]</param>
        /// <returns></returns>
        IList<MZiChanFuZhaiInfo> GetZiChanFuZhais(int companyId, int pageSize, int pageIndex, ref int recordCount, MZiChanFuZhaiChaXunInfo chaXun, out object[] heJi);

        /// <summary>
        /// 写入修改历史记录信息，返回1成功，其它失败
        /// </summary>
        /// <param name="items">历史记录信息集合</param>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <returns></returns>
        int InsertHistory(IList<MZiChanFuZhaiHistoryInfo> items, string ziChanFuZhaiId);
    }
}
