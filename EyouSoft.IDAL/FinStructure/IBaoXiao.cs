//财务管理-报销管理相关数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理-报销管理相关数据访问类接口
    /// </summary>
    public interface IBaoXiao
    {
        /// <summary>
        /// 写入报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MBaoXiaoInfo info);
        /// <summary>
        /// 更新报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MBaoXiaoInfo info);
        /// <summary>
        /// 删除报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        int Delete(string baoXiaoId, int companyId);
        /// <summary>
        /// 获取报销登记信息业务实体
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <returns></returns>
        MBaoXiaoInfo GetInfo(string baoXiaoId);
        /// <summary>
        /// 获取报销登记信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息，[0:decimal:报销金额]</param>
        /// <returns></returns>
        IList<MBaoXiaoInfo> GetBaoXiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MBaoXiaoChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 报销审批，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="status">审批状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int ShenPi(string baoXiaoId, Model.EnumType.FinStructure.BaoXiaoStatus status, MOperatorInfo info);
        /// <summary>
        /// 报销支付，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">支付银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        int ZhiFu(string baoXiaoId, MOperatorInfo info, string zhangHuId, DateTime bankDate);
        /// <summary>
        /// 获取报销登记状态
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <returns></returns>
        Model.EnumType.FinStructure.BaoXiaoStatus GetStatus(string baoXiaoId);
        /// <summary>
        /// 取消报销支付，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoZhiFu(string baoXiaoId, MOperatorInfo info);
        /// <summary>
        /// 取消报销审批，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoShenPi(string baoXiaoId, MOperatorInfo info);
    }
}
