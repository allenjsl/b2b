//财务管理发票相关数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理发票相关数据访问类接口
    /// </summary>
    public interface IFaPiao
    {
        /// <summary>
        /// 发票登记，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MFaPiaoInfo info);
        /// <summary>
        /// 发票修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MFaPiaoInfo info);
        /// <summary>
        /// 发票删除，返回1成功，其它失败
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        int Delete(string faPiaoId, int companyId);
        /// <summary>
        /// 获取发票信息
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <returns></returns>
        MFaPiaoInfo GetInfo(string faPiaoId);
        /// <summary>
        /// 获取发票信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息，[0:decimal:发票金额]</param>
        /// <returns></returns>
        IList<MFaPiaoInfo> GetFaPiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MFaPiaoChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 修改发票明细，返回1成功，其它失败
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <param name="items">发票明细信息集合</param>
        /// <returns></returns>
        int UpdateMingXis(string faPiaoId, IList<MFaPiaoMXInfo> items);
        /// <summary>
        /// 获取发票发送数量
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <returns></returns>
        int GetFaSongShuLiang(string faPiaoId);
        /// <summary>
        /// 获取自动完成发票订单信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo> GetAutocompleteFaPiaoDingDans(int companyId, string zxsId, EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingChaXunDanInfo chaXun);

        /// <summary>
        /// 获取发票明细信息
        /// </summary>
        /// <param name="mxId">明细编号</param>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        MFaPiaoMXInfo GetFaPiaoMxInfo(int mxId, string dingDanId);
    }
}
