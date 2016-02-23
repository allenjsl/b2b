//财务管理出纳日记账相关数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理出纳日记账相关数据访问类接口
    /// </summary>
    public interface IRiJiZhang
    {
        /// <summary>
        /// 写入出纳日记账信息
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MRiJiZhangInfo info);
        /// <summary>
        /// 获取出纳日记账信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:借方金额合计][1:decimal:贷方金额合计]</param>
        /// <returns></returns>
        IList<MRiJiZhangInfo> GetRiJiZhangs(int companyId, int pageSize, int pageIndex, ref int recordCount, MRiJiZhangChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取余额，未做过任何登记时取所有可用银行账号原始金额合计，已登记取最后一次出纳日记账余额
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        decimal GetYuE(int companyId);
        /// <summary>
        /// 获取出纳日记账信息业务实体
        /// </summary>
        /// <param name="riJiZhangId">日记账编号</param>
        /// <returns></returns>
        MRiJiZhangInfo GetInfo(string riJiZhangId);
        /// <summary>
        /// 修改出纳日记账信息，借贷金额不做修改
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MRiJiZhangInfo info);
    }
}
