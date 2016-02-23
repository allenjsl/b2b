using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台景点相关
    /// </summary>
    public class BJingDian : BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IJingDian dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IJingDian>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJingDian() { }
        #endregion

        #region public members
        /// <summary>
        /// 新增景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MJingDianInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 ) return 0;
            info.JingDianId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增平台景点";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_景点管理;
                log.EventMessage = "新增平台景点，景点编号：" + info.JingDianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }


        /// <summary>
        /// 修改景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MJingDianInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.JingDianId)) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改平台景点";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_景点管理;
                log.EventMessage = "修改平台景点，景点编号：" + info.JingDianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 删除景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jingDianId">景点编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string jingDianId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(jingDianId)) return 0;
            int dalRetCode = dal.Delete(companyId, jingDianId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除平台景点";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_景点管理;
                log.EventMessage = "删除平台景点，景点编号：" + jingDianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <param name="jingDianId">景点编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJingDianInfo GetInfo(string jingDianId)
        {
            if (string.IsNullOrEmpty(jingDianId)) return null;

            return dal.GetInfo(jingDianId);
        }

        /// <summary>
        /// 获取景点集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJingDianInfo> GetJingDians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJingDianChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            return dal.GetJingDians(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获取景点区域集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJingDianQuYuInfo> GetJingDianQuYus(int companyId)
        {
            if (companyId < 1) return null;

            return dal.GetJingDianQuYus(companyId);
        }

        /// <summary>
        /// 写入景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertJingDianQuYu(EyouSoft.Model.PtStructure.MJingDianQuYuInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.InsertJingDianQuYu(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "添加平台景点区域";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_景点管理;
                log.EventMessage = "添加平台景点区域，景点区域编号：" + info.QuYuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 修改景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateJingDianQuYu(EyouSoft.Model.PtStructure.MJingDianQuYuInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1||info.QuYuId<1) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.UpdateJingDianQuYu(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改平台景点区域";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_景点管理;
                log.EventMessage = "修改平台景点区域，景点区域编号：" + info.QuYuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }
        /// <summary>
        /// 删除景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">区域编号</param>
        /// <returns></returns>
        public int DeleteJingDianQuYu(int companyId, int quYuId)
        {
            if (companyId < 1 || quYuId < 1) return 0;

            int dalRetCode = dal.DeleteJingDianQuYu(companyId, quYuId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除平台景点区域";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_景点管理;
                log.EventMessage = "删除平台景点区域，景点区域编号：" + quYuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取景点区域信息实体
        /// </summary>
        /// <param name="quYuId">区域编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJingDianQuYuInfo GetJingDianQuYuInfo(int quYuId)
        {
            if (quYuId < 1) return null;
            return dal.GetJingDianQuYuInfo(quYuId);
        }

         /// <summary>
        /// 是否存在相同的景点区域名称
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">区域编号</param>
        /// <param name="mingCheng">区域名称</param>
        /// <returns></returns>
        public bool IsExistsJingDianQuYu(int companyId, int quYuId, string mingCheng)
        {
            if (companyId < 1 || string.IsNullOrEmpty(mingCheng)) return true;

            return dal.IsExistsJingDianQuYu(companyId, quYuId, mingCheng);
        }

        /// <summary>
        /// 是否存在景点(或相同的景点名称)
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">景点区域编号</param>
        /// <param name="jingDianId">景点编号</param>
        /// <param name="mingCheng">景点名称</param>
        /// <returns></returns>
        public bool IsExistsJingDian(int companyId, int quYuId, int jingDianId, string mingCheng)
        {
            if (companyId < 1 || quYuId < 1) return true;

            return dal.IsExistsJingDian(companyId, quYuId, jingDianId, mingCheng);
        }
        #endregion
    }
}
