using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 积分相关interface
    /// </summary>
    public interface IJiFen
    {
        /// <summary>
        /// 积分商品新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int ShangPin_CU(EyouSoft.Model.PtStructure.MJiFenShangPinInfo info);
        /// <summary>
        /// 删除积分商品，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="shangPinId">商品编号</param>
        /// <returns></returns>
        int DeleteShangPin(int companyId, string shangPinId);
        /// <summary>
        /// 获取积分商品信息
        /// </summary>
        /// <param name="shangPinId">商品编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiFenShangPinInfo GetShangPinInfo(string shangPinId);
        /// <summary>
        /// 获取积分商品集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录灵敏</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJiFenShangPinInfo> GetShangPins(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenShangPinChaXunInfo chaXun);
        /// <summary>
        /// 积分订单新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int DingDan_CU(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info);
        /// <summary>
        /// 获取积分订单信息
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiFenDingDanInfo GetDingDanInfo(string dingDanId);
        /// <summary>
        /// 获取积分订单集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MJiFenDingDanInfo> GetDingDans(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenDingDanChaXunInfo chaXun);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int SheZhiDingDanStatus(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info);
        /// <summary>
        /// 设置订单付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="fuKuanStatus">付款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int SheZhiDingDanFuKuanStatus(string dingDanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus fuKuanStatus, EyouSoft.Model.FinStructure.MOperatorInfo info);
        /// <summary>
        /// 获取用户积分明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:积分合计]</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MYongHuJiFenMingXiInfo> GetYongHuJiFenMingXis(int companyId, int yongHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MYongHuJiFenMingXiChaXunInfo chaXun,out object[] heJi);
    }
}
