//财务管理其它支出相关数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理其它支出相关数据访问类接口
    /// </summary>
    public interface IQiTaZhiChu
    {
        /// <summary>
        /// 写入其它支出信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MQiTaZhiChuInfo info);
        /*/// <summary>
        /// 获取金额信息
        /// </summary>
        /// <param name="zhiChuId">其它支出登记编号</param>
        /// <param name="jinE">金额信息[0:decimal:应付金额][1:decimal:已支付金额][2:decimal:已审批金额][3:decimal:未审批金额]</param>
        /// <returns></returns>
        void GetJinE(string zhiChuId, out decimal[] jinE);*/
        /// <summary>
        /// 修改其它支出信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MQiTaZhiChuInfo info);
        /// <summary>
        /// 删除其它支出信息，返回1成功，其它失败
        /// </summary>
        /// <param name="zhiChuId">其它支出登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        int Delete(string zhiChuId, int companyId);
        /// <summary>
        /// 获取其它支出信息业务实体
        /// </summary>
        /// <param name="zhiChuId">其它支出登记编号</param>
        /// <returns></returns>
        MQiTaZhiChuInfo GetInfo(string zhiChuId);
        /// <summary>
        /// 获取其它支出信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:应付合计] [1:decimal:已支付金额合计][2:decimal:已审批金额合计][3:未审批金额合计]</param>
        /// <returns></returns>
        IList<MQiTaZhiChuInfo> GetQiTaZhiChus(int companyId, int pageSize, int pageIndex, ref int recordCount, MQiTaShouZhiChaXunInfo chaXun, out decimal[] heJi);
        /// <summary>
        /// 获取控位其它支出信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        IList<MQiTaZhiChuInfo> GetKongWeiQiTaZhiChus(string kongWeiId);
    }
}
