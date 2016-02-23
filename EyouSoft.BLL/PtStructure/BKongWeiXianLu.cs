//平台-控位线路相关业务逻辑 汪奇志 2014-09-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台-控位线路相关业务逻辑
    /// </summary>
    public class BKongWeiXianLu : BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IKongWeiXianLu dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IKongWeiXianLu>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BKongWeiXianLu() { }
        #endregion

        #region public members
        /// <summary>
        /// 获取控位线路集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo> GetKongWeis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetKongWeis(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获取控位下线路集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo> GetKongWeiXianLus(string kongWeiId, EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;

            return dal.GetKongWeiXianLus(kongWeiId, chaXun);
        }

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
        public IList<EyouSoft.Model.PtStructure.MDingDanLbInfo> GetDingDans(int companyId, string keHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MDingDanLbChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0, 0, 0M, 0M };

            if (companyId < 1 || string.IsNullOrEmpty(keHuId)) return null;

            return dal.GetDingDans(companyId, keHuId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
        }

        /// <summary>
        /// 获取关联控位线路产品集合
        /// </summary>
        /// <param name="xianLuId">控位线路产品编号</param>
        /// <param name="quDate1">关联产品去程日期-起</param>
        /// <param name="quDate2">关联产品去程日期-止</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MGuanLianKongWeiXianLuInfo> GetGuanLianKongWeiXianLus(string xianLuId, DateTime quDate1, DateTime quDate2)
        {
            if (string.IsNullOrEmpty(xianLuId)) return null;

            if (quDate1.Year < 2000 || quDate1.Year > 2099 || quDate2.Year < 2000 || quDate2.Year > 2099) return null;

            return dal.GetGuanLianKongWeiXianLus(xianLuId, quDate1, quDate2);
        }
        #endregion
    }
}
