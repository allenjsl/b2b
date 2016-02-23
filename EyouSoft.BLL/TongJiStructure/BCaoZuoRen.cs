//统计分析-操作人统计 汪奇志 2013-08-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TongJiStructure
{
    /// <summary>
    /// 统计分析-操作人统计
    /// </summary>
    public class BCaoZuoRen : BLLBase
    {
        private readonly EyouSoft.IDAL.TongJiStructure.ICaoZuoRen dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TongJiStructure.ICaoZuoRen>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BCaoZuoRen() { }
        #endregion

        #region public members
        /// <summary>
        /// 统计分析-获取操作人统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MCaoZuoRenInfo> GetCaoZuoRens(int companyId,string zxsId, EyouSoft.Model.TongJiStructure.MCaoZuoRenChaXunInfo chaXun)
        {
            if (companyId < 1||string.IsNullOrEmpty(zxsId)) return null;

            return dal.GetCaoZuoRens(companyId,zxsId, chaXun);
        }
        #endregion
    }
}
