//财务管理其它收入相关数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理其它收入相关数据访问类接口
    /// </summary>
    public interface IQiTaShouRu
    {
        /// <summary>
        /// 写入其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MQiTaShouRuInfo info);
        /*/// <summary>
        /// 获取金额信息
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <param name="jinE">金额信息[0:decimal:应收金额][1:decimal:已审批金额][2:decimal:未审批金额]</param>
        /// <returns></returns>
        void GetJinE(string shouRuId, out decimal[] jinE);*/
        /// <summary>
        /// 修改其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MQiTaShouRuInfo info);
        /// <summary>
        /// 删除其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        int Delete(string shouRuId, int companyId);
        /// <summary>
        /// 获取其它收入信息业务实体
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <returns></returns>
        MQiTaShouRuInfo GetInfo(string shouRuId);
        /// <summary>
        /// 获取其它收入信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:应收合计] [1:decimal:已审批金额合计][2:decimal:未审批金额合计]</param>
        /// <returns></returns>
        IList<MQiTaShouRuInfo> GetQiTaShouRus(int companyId, int pageSize, int pageIndex, ref int recordCount, MQiTaShouZhiChaXunInfo chaXun, out decimal[] heJi);
        /// <summary>
        /// 获取控位其它收入信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        IList<MQiTaShouRuInfo> GetKongWeiQiTaShouRus(string kongWeiId);
    }
}
