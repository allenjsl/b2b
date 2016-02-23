using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台相关
    /// </summary>
    public class BPt : BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IPt dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IPt>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BPt() { }
        #endregion

        #region internal members
        /// <summary>
        /// 获取平台域名信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="leiXing">域名类型</param>
        /// <returns></returns>
        internal IList<EyouSoft.Model.PtStructure.MYuMingInfo> GetYuMings(int companyId,EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing leiXing)
        {
            return dal.GetYuMings(companyId, leiXing);
        }
        #endregion

        #region public members
        /// <summary>
        /// 设置KV信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int SheZhiKvInfo(EyouSoft.Model.PtStructure.MKvInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.SheZhiKvInfo(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置平台key-value信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_基础信息;
                log.EventMessage = "设置平台key-value信息，key：" + (int)info.K + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取KV信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="k">key</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MKvInfo GetKvInfo(int companyId, EyouSoft.Model.EnumType.PtStructure.KvKey k)
        {
            var info = new EyouSoft.Model.PtStructure.MKvInfo();
            info.CompanyId = companyId;
            info.K = k;

            if (companyId < 1) return info;

            info = dal.GetKvInfo(companyId, k);

            return info;
        }

        /// <summary>
        /// 站点新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertZhanDian(EyouSoft.Model.PtStructure.MZhanDianInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.MingCheng)) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.ZhanDian_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增站点信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_基础信息;
                log.EventMessage = "新增站点信息，站点编号：" + info.ZhanDianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            if (dalRetCode == 1)
            {
                string key = string.Format(EyouSoft.Cache.Tag.TagName.PtZhanDian, info.CompanyId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(key);
                BTongZhi.RemoveCache(info.CompanyId, key);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 站点修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateZhanDian(EyouSoft.Model.PtStructure.MZhanDianInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.MingCheng)||info.ZhanDianId<1) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.ZhanDian_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改站点信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_基础信息;
                log.EventMessage = "修改站点信息，站点编号：" + info.ZhanDianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            if (dalRetCode == 1)
            {
                string key = string.Format(EyouSoft.Cache.Tag.TagName.PtZhanDian, info.CompanyId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(key);
                BTongZhi.RemoveCache(info.CompanyId, key);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 站点删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zhanDianId">站点编号</param>
        /// <returns></returns>
        public int DeleteZhanDian(int companyId, int zhanDianId)
        {
            if (companyId < 1 || zhanDianId < 1) return 0;
            int dalRetCode = dal.ZhanDian_D(companyId, zhanDianId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除站点信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_基础信息;
                log.EventMessage = "删除站点信息，站点编号：" + zhanDianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            if (dalRetCode == 1)
            {
                string key = string.Format(EyouSoft.Cache.Tag.TagName.PtZhanDian, companyId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(key);
                BTongZhi.RemoveCache(companyId, key);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取站点信息
        /// </summary>
        /// <param name="zhanDianId">站点编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZhanDianInfo GetZhanDianInfo(int zhanDianId)
        {
            if (zhanDianId < 1) return null;

            return dal.GetZhanDianInfo(zhanDianId);
        }

        /// <summary>
        /// 获取站点集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhanDianInfo> GetZhanDians(int companyId, EyouSoft.Model.PtStructure.MZhanDianChaXunInfo chaXun)
        {
            if (companyId < 1) return null;

            return dal.GetZhanDians(companyId, chaXun);
        }

        /// <summary>
        /// 专线类别新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertZhuanXianLeiBie(EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.ZhanDianId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.MingCheng)) return 0;

            int dalRetCode = dal.ZhuanXianLeiBie_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增专线类别信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线类别管理;
                log.EventMessage = "新增专线类别信息，专线类别编号：" + info.ZxlbId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            if (dalRetCode == 1)
            {
                string key = string.Format(EyouSoft.Cache.Tag.TagName.PtZhanDian, info.CompanyId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(key);
                BTongZhi.RemoveCache(info.CompanyId, key);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 专线类别修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateZhuanXianLeiBie(EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.ZhanDianId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.MingCheng) || info.ZxlbId < 1) return 0;

            int dalRetCode = dal.ZhuanXianLeiBie_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改专线类别信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线类别管理;
                log.EventMessage = "修改专线类别信息，专线类别编号：" + info.ZxlbId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            if (dalRetCode == 1)
            {
                string key = string.Format(EyouSoft.Cache.Tag.TagName.PtZhanDian, info.CompanyId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(key);
                BTongZhi.RemoveCache(info.CompanyId, key);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 专线类别删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxlbId">专线类别编号</param>
        /// <returns></returns>
        public int DeleteZhuanXianLeiBie(int companyId, int zxlbId)
        {
            if (companyId < 1 || zxlbId < 1) return 0;

            int dalRetCode = dal.ZhuanXianLeiBie_D(companyId, zxlbId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除专线类别信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线类别管理;
                log.EventMessage = "删除专线类别信息，专线类别编号：" + zxlbId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            if (dalRetCode == 1)
            {
                string key = string.Format(EyouSoft.Cache.Tag.TagName.PtZhanDian, companyId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(key);
                BTongZhi.RemoveCache(companyId, key);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取专线类别信息
        /// </summary>
        /// <param name="zxlbId">专线类别编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo GetZhuanXianLeiBieInfo(int zxlbId)
        {
            if (zxlbId < 1) return null;
            return dal.GetZhuanXianLeiBieInfo(zxlbId);
        }

        /// <summary>
        /// 获取专线类别集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo> GetZhuanXianLeiBies(int companyId, EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo chaXun)
        {
            if (companyId < 1) return null;

            return dal.GetZhuanXianLeiBies(companyId, chaXun);
        }

        /// <summary>
        /// 获取站点信息集合（含专线类别信息）
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> GetZhanDians1(int companyId)
        {
            if (companyId < 1) return null;

            var cacheName = string.Format(EyouSoft.Cache.Tag.TagName.PtZhanDian, companyId);

            var items=(IList<EyouSoft.Model.PtStructure.MZhanDianInfo1>)EyouSoft.Cache.Facade.EyouSoftCache.GetCache(cacheName);

            if (items == null || items.Count == 0)
            {
                items = dal.GetZhanDians1(companyId);

                EyouSoft.Cache.Facade.EyouSoftCache.Add(cacheName, items);
            }

            IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> items1 = new List<EyouSoft.Model.PtStructure.MZhanDianInfo1>();

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    items1.Add(item);
                }
            }

            return items1;
        }

        /// <summary>
        /// remove cache
        /// </summary>
        /// <param name="key"> Key of item to remove from cache</param>
        /// <returns></returns>
        public int RemoveCache(string key)
        {
            if (string.IsNullOrEmpty(key)) return 0;

            EyouSoft.Cache.Facade.EyouSoftCache.Remove(key);

            return 1;
        }

        /// <summary>
        /// 获取专线商站点信息集合（含专线类别信息）
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> GetZxsZhanDians(int companyId, string zxsId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return null;

            return dal.GetZxsZhanDians(companyId, zxsId);
        }



        /// <summary>
        /// 根据专线类别编号获取专线商编号
        /// </summary>
        /// <param name="zxlbId">专线类别编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public string GetZxsIdByZxlbId(int zxlbId, int companyId)
        {
            if (zxlbId < 1 || companyId < 1) return string.Empty;

            return dal.GetZxsIdByZxlbId(zxlbId, companyId);
        }
        #endregion
    }
}
