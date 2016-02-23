//付款登记信息数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 付款登记信息数据访问类接口
    /// </summary>
    public interface IFuKuan
    {
        /// <summary>
        /// 写入付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MFuKuanInfo info);
        /// <summary>
        /// 修改付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MFuKuanInfo info);
        /// <summary>
        /// 删除付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <returns></returns>
        int Delete(string fuKuanId, int companyId, string fuKuanXiangMuId);
        /// <summary>
        /// 获取付款登记信息集合
        /// </summary>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <returns></returns>
        IList<MFuKuanInfo> GetFuKuans(KuanXiangType kuanXiangType, string fuKuanXiangMuId);
        /// <summary>
        /// 获取付款登记状态
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <returns></returns>
        KuanXiangStatus GetStatus(string fuKuanId);
        /// <summary>
        /// 付款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int ShenPi(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info);
        /// <summary>
        /// 付款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        int ZhiFu(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info, DateTime bankDate);
        /// <summary>
        /// 获取付款审批信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息，[0:decimal:付款金额]</param>
        /// <returns></returns>
        IList<MLBFuKuanShenPiInfo> GetShenPis(int companyId, int pageSize, int pageIndex, ref int recordCount, MLBFuKuanShenPiChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取付款登记实体
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <returns></returns>
        MFuKuanInfo GetInfo(string fuKuanId);
        /// <summary>
        /// 获取付款登记金额
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <returns></returns>
        decimal GetFuKuanJinE(string fuKuanId);
        /// <summary>
        /// 取消付款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoShenPi(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info);
        /// <summary>
        /// 取消付款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoZhiFu(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info);
    }
}
