//供应商主体相关BLL 汪奇志 2015-05-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.GysStructure
{
    /// <summary>
    /// 供应商主体相关BLL 
    /// </summary>
    public class BGysZhuTi : BLLBase
    {
        private readonly EyouSoft.IDAL.GysStructure.IGysZhuTi dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.GysStructure.IGysZhuTi>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BGysZhuTi() { }
        #endregion

        #region public members
        /// <summary>
        /// 供应商主体新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int GysZhuTi_C(EyouSoft.Model.GysStructure.MGysZhuTiInfo info)
        {
            if (info == null 
                || string.IsNullOrEmpty(info.GysName) 
                || string.IsNullOrEmpty(info.ZxsId) 
                || info.CompanyId < 1 
                || info.CaoZuoRenId < 1) return 0;

            info.GysId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            
            int dalRetCode = dal.GysZhuTi_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增供应商主体信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.资源管理_地接社主体管理;
                log.EventMessage = "新增供应商主体信息，供应商编号：" + info.GysId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 供应商主体修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int GysZhuTi_U(EyouSoft.Model.GysStructure.MGysZhuTiInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.GysName)
                || string.IsNullOrEmpty(info.ZxsId)
                || info.CompanyId < 1
                || info.CaoZuoRenId < 1
                ||string.IsNullOrEmpty(info.GysId)) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.GysZhuTi_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改供应商主体信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.资源管理_地接社主体管理;
                log.EventMessage = "修改供应商主体信息，供应商编号：" + info.GysId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 供应商主体删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        public int GysZhuTi_D(int companyId, string gysId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(gysId)) return 0;
            int dalRetCode = dal.GysZhuTi_D(companyId, gysId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除供应商主体信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.资源管理_地接社主体管理;
                log.EventMessage = "删除供应商主体信息，供应商编号：" + gysId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取供应商主体信息业务实体
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        public EyouSoft.Model.GysStructure.MGysZhuTiInfo GetInfo(string gysId)
        {
            if (string.IsNullOrEmpty(gysId)) return null;
            var info = dal.GetInfo(gysId);
            return info;
        }

        /// <summary>
        /// 获取供应商主体信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MGysZhuTiInfo> GetGysZhuTis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MGysZhuTiChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetGysZhuTis(companyId, pageSize, pageIndex, ref recordCount, chaXun);

            return items;
        }
        
        /// <summary>
        /// 获取供应商主体联系人信息集合
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo> GetGysLxrs(string gysId)
        {
            if (string.IsNullOrEmpty(gysId)) return null;

            var items = dal.GetGysLxrs(gysId);
            return items;
        }

        /// <summary>
        /// 供应商主体联系人信息新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int GysZhuTi_Lxr_C(EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo info)
        {
            if (info == null 
                || string.IsNullOrEmpty(info.GysId) 
                || string.IsNullOrEmpty(info.YongHuMing) 
                || string.IsNullOrEmpty(info.MiMa) 
                || string.IsNullOrEmpty(info.Md5MiMa) 
                || string.IsNullOrEmpty(info.LxrName) 
                || info.CaoZuoRenId < 1) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.GysZhuTi_Lxr_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增供应商主体账号";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.资源管理_地接社主体管理;
                log.EventMessage = "新增供应商主体账号，联系人编号：" + info.LxrId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 供应商主体联系人信息修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int GysZhuTi_Lxr_U(EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo info)
        {
            if (info == null
                || string.IsNullOrEmpty(info.GysId)
                || string.IsNullOrEmpty(info.LxrName)
                || info.CaoZuoRenId < 1
                || info.LxrId < 1
                || info.YongHuId < 1) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.GysZhuTi_Lxr_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改供应商主体账号";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.资源管理_地接社主体管理;
                log.EventMessage = "修改供应商主体账号，联系人编号：" + info.LxrId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 供应商主体联系人信息删除，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">联系人用户编号</param>
        /// <returns></returns>
        public int GysZhuTi_lxr_D(string gysId, int lxrId, int yongHuId)
        {
            if (string.IsNullOrEmpty(gysId) || lxrId < 1 || yongHuId < 1) return 0;

            int dalRetCode = dal.GysZhuTi_lxr_D(gysId, lxrId, yongHuId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除供应商主体账号";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.资源管理_地接社主体管理;
                log.EventMessage = "删除供应商主体账号，联系人编号：" + lxrId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取选用的供应商信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MXuanYongGysInfo> GetXuanYongGyss(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MXuanYongGysChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetXuanYongGyss(companyId, pageSize, pageIndex, ref recordCount, chaXun);
            return items;
        }

        /// <summary>
        /// 获取供应商主体导游信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gysId">供应商主体编号</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo> GetZhuTiDaoYous(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MGysZhuTiDaoYouChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo> items = null;
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            if (chaXun != null && string.IsNullOrEmpty(chaXun.GysZhuTiId) && (!string.IsNullOrEmpty(chaXun.GysId)))
            {
                chaXun.GysZhuTiId = dal.GetGysZhuTiIdByGysId(companyId, chaXun.GysId);
            }

            if (chaXun != null && string.IsNullOrEmpty(chaXun.GysZhuTiId) && (!string.IsNullOrEmpty(chaXun.GysId)))
            {
                items = dal.GetGysDaoYous(companyId, pageSize, pageIndex, ref recordCount, chaXun);
            }
            else
            {
                items = dal.GetZhuTiDaoYous(companyId, pageSize, pageIndex, ref recordCount, chaXun);
            }

            return items;
        }
        #endregion
    }
}
