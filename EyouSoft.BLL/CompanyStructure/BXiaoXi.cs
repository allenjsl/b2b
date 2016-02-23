using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 消息业务逻辑类
    /// </summary>
    public class BXiaoXi : BLLBase
    {
        private readonly EyouSoft.IDAL.CompanyStructure.IXiaoXi dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.CompanyStructure.IXiaoXi>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BXiaoXi() { }
        #endregion

        #region public members
        /// <summary>
        /// （管理后台）获取消息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo> GetXiaoXis(int companyId, string zxsId, int yongHuId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || yongHuId < 1) return null;

            string cacheKey = string.Format(EyouSoft.Cache.Tag.TagName.ZxsXiaoXi,companyId,zxsId);
            var items = (IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo>)EyouSoft.Cache.Facade.EyouSoftCache.GetCache(cacheKey);

            if (items == null || items.Count == 0)
            {
                items = dal.GetXiaoXis(companyId, zxsId, yongHuId);

                EyouSoft.Cache.Facade.EyouSoftCache.Add(cacheKey, items, DateTime.Now.AddMinutes(2));
            }

            return items;
        }

        /// <summary>
        /// （同行后台）获取消息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo> PT_GetXiaoXis(int companyId, string keHuId, int yongHuId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(keHuId) || yongHuId < 1) return null;

            string cacheKey = string.Format(EyouSoft.Cache.Tag.TagName.KeHuXiaoXi, companyId, keHuId,yongHuId);
            var items = (IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo>)EyouSoft.Cache.Facade.EyouSoftCache.GetCache(cacheKey);

            if (items == null || items.Count == 0)
            {
                items = dal.PT_GetXiaoXis(companyId, keHuId, yongHuId);

                EyouSoft.Cache.Facade.EyouSoftCache.Add(cacheKey, items, DateTime.Now.AddMinutes(2));
            }

            return items;
        }
        #endregion
    }
}
