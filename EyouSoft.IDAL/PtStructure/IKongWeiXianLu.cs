//平台-控位线路相关数据访问类接口 汪奇志 2014-09-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 平台-控位线路相关数据访问类接口
    /// </summary>
    public interface IKongWeiXianLu
    {
        /// <summary>
        /// 获取控位线路集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo> GetKongWeis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo chaXun);
        /// <summary>
        /// 获取控位下线路集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo> GetKongWeiXianLus(string kongWeiId, EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo chaXun);
        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:成人数][1:int:儿童数][2:int:婴儿数][3:int:全陪数][4:int:占位数][5:decimal:总金额][6:decimal:已支付金额]</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MDingDanLbInfo> GetDingDans(int companyId, string keHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MDingDanLbChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取关联控位线路产品集合
        /// </summary>
        /// <param name="xianLuId">控位线路产品编号</param>
        /// <param name="quDate1">关联产品去程日期-起</param>
        /// <param name="quDate2">关联产品去程日期-止</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MGuanLianKongWeiXianLuInfo> GetGuanLianKongWeiXianLus(string xianLuId, DateTime quDate1, DateTime quDate2);
    }
}
