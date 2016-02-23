//财务管理借款相关数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理借款相关数据访问类接口
    /// </summary>
    public interface IJieKuan
    {
        /// <summary>
        /// 写入借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MJieKuanInfo info);
        /// <summary>
        /// 修改借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MJieKuanInfo info);
        /// <summary>
        /// 删除借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        int Delete(string jieKuanId, int companyId);
        /// <summary>
        /// 获取借款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:借款金额] [1:decimal:归还金额]</param>
        /// <returns></returns>
        IList<MJieKuanInfo> GetJieKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MJieKuanChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取借款信息实体
        /// </summary>
        /// <param name="jieKuanId">借款编号</param>
        /// <returns></returns>
        MJieKuanInfo GetInfo(string jieKuanId);
        /// <summary>
        /// 获取借款状态
        /// </summary>
        /// <param name="jieKuanId">借款编号</param>
        /// <returns></returns>
        EyouSoft.Model.EnumType.FinStructure.JieKuanStatus GetStatus(string jieKuanId);
        /// <summary>
        /// 借款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int ShenPi(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info);
        /// <summary>
        /// 借款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        int ZhiFu(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info, string zhangHuId, DateTime bankDate);
        /// <summary>
        /// 借款归还，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        int GuiHuan(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info, string zhangHuId, DateTime bankDate);
        /// <summary>
        /// 取消归还，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoGuiHuan(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info);

        /// <summary>
        /// 取消支付，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoZhiFu(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info);

        /// <summary>
        /// 取消审批，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoShenPi(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info);
    }
}
