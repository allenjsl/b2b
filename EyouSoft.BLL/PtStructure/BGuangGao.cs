using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台广告信息相关
    /// </summary>
    public class BGuangGao : BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IGuangGao dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IGuangGao>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BGuangGao() { }
        #endregion

        #region public members
        /// <summary>
        /// 新增广告，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MGuangGaoInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;

            info.GuangGaoId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增平台广告";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_广告管理;
                log.EventMessage = "新增平台广告，广告编号：" + info.GuangGaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改广告，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MGuangGaoInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.GuangGaoId)) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改平台广告";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_广告管理;
                log.EventMessage = "修改平台广告，广告编号：" + info.GuangGaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除广告，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="guangGaoId">广告编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string guangGaoId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(guangGaoId)) return 0;

            int dalRetCode = dal.Delete(companyId,guangGaoId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除平台广告";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_广告管理;
                log.EventMessage = "删除平台广告，广告编号：" + guangGaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取广告信息
        /// </summary>
        /// <param name="guangGaoId">广告编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MGuangGaoInfo GetInfo(string guangGaoId)
        {
            if (string.IsNullOrEmpty(guangGaoId)) return null;

            return dal.GetInfo(guangGaoId);
        }

        /// <summary>
        /// 获取广告集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MGuangGaoInfo> GetGuangGaos(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetGuangGaos(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置广告状态，返回1成功，其它失败
        /// </summary>
        /// <param name="guangGaoId">广告编号</param>
        /// <param name="status">广告状态</param>
        /// <returns></returns>
        public int SheZhiGuangGaoStatus(string guangGaoId, EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus status)
        {
            if (string.IsNullOrEmpty(guangGaoId)) return 0;

            int dalRetCode = dal.SheZhiGuangGaoStatus(guangGaoId, status);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置平台广告状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_广告管理;
                log.EventMessage = "设置平台广告状态，广告编号：" + guangGaoId + "，广告状态：" + status + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
