//收款相关信息数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 收款相关信息数据访问类接口
    /// </summary>
    public interface IShouKuan
    {
        /// <summary>
        /// 写入收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MShouKuanInfo info);
        /// <summary>
        /// 修改收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MShouKuanInfo info);
        /// <summary>
        /// 删除收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <returns></returns>
        int Delete(string shouKuanId, int companyId, string shouKuanXiangMuId);
        /// <summary>
        /// 获取收款登记信息集合
        /// </summary>
        /// <param name="shouXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <returns></returns>
        IList<MShouKuanInfo> GetShouKuans(KuanXiangType kuanXiangType, string shouKuanXiangMuId);
        /// <summary>
        /// 获取收款登记状态
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <returns></returns>
        KuanXiangStatus GetStatus(string shouKuanId);
        /// <summary>
        /// 收款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="kuanXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="bankDate">银行业务日期</param>
        /// <returns></returns>
        int ShenPi(string shouKuanId, KuanXiangType kuanXiangType, string shouKuanXiangMuId, MOperatorInfo info, DateTime bankDate);
        /// <summary>
        /// 获取收款信息实体
        /// </summary>
        /// <param name="shouKuanId">收款编号</param>
        /// <returns></returns>
        MShouKuanInfo GetInfo(string shouKuanId);
        /// <summary>
        /// 获取收款登记金额
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <returns></returns>
        decimal GetShouKuanJinE(string shouKuanId);
        /// <summary>
        /// 取消收款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="kuanXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoShenPi(string shouKuanId, KuanXiangType kuanXiangType, string shouKuanXiangMuId, MOperatorInfo info);
    }
}
