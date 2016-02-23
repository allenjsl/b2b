//汪奇志 2013-02-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理-利润表数据访问类接口
    /// </summary>
    public interface ILiRun
    {
        /// <summary>
        /// 是否存在相同的利润年月份信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="liRunId">利润编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        bool IsExists(int companyId, int year, int month, string liRunId,string zxsId);
        /// <summary>
        /// 写入利润表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MLiRunInfo info);
        /// <summary>
        /// 获取利润表信息
        /// </summary>
        /// <param name="liRunId">利润编号</param>
        /// <returns></returns>
        MLiRunInfo GetInfo(string liRunId);
        /// <summary>
        /// 更新利润表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MLiRunInfo info);
        /// <summary>
        /// 删除利润表信息
        /// </summary>
        /// <param name="liRunId">利润编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        int Delete(string liRunId, int companyId);
        /// <summary>
        /// 获取利润表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息 [0:decimal:团队结算毛利合计] [1:decimal:报销费用合计][2:decimal:营业外收入合计][3:decimal:营业外支出合计][4:decimal:纯利润合计][5:decimal:主营业务收入合计][6:decimal:主营业务支出合计][7:decimal:其它损失合计]</param>
        /// <returns></returns>
        IList<MLiRunInfo> GetLiRuns(int companyId, int pageSize, int pageIndex, ref int recordCount, MLiRunChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 写入修改历史记录信息，返回1成功，其它失败
        /// </summary>
        /// <param name="items">历史记录信息集合</param>
        /// <param name="liRunId">利润编号</param>
        /// <returns></returns>
        int InsertHistory(IList<MLiRunHistoryInfo> items, string liRunId);
    }
}
