using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台推荐相关
    /// </summary>
    public class BTuiJian:BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.ITuiJian dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.ITuiJian>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BTuiJian() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MTuiJianInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;
            info.TuiJianId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增平台推荐";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_平台推荐;
                log.EventMessage = "新增平台推荐，推荐编号：" + info.TuiJianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MTuiJianInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.TuiJianId)) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改平台推荐";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_平台推荐;
                log.EventMessage = "修改平台推荐，推荐编号：" + info.TuiJianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="tuiJianId">推荐编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string tuiJianId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(tuiJianId)) return 0;
            int dalRetCode = dal.Delete(companyId, tuiJianId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除平台推荐";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_平台推荐;
                log.EventMessage = "删除平台推荐，推荐编号：" + tuiJianId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取平台推荐信息
        /// </summary>
        /// <param name="tuiJianId">推荐编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MTuiJianInfo GetInfo(string tuiJianId)
        {
            if (string.IsNullOrEmpty(tuiJianId)) return null;

            return dal.GetInfo(tuiJianId);
        }

        /// <summary>
        /// 获取平台推荐集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MTuiJianInfo> GetTuiJians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MTuiJianChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            return dal.GetTuiJians(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置推荐状态，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="tuiJianId">推荐编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(int companyId, string tuiJianId, EyouSoft.Model.EnumType.PtStructure.TuiJianStatus status)
        {
            if (companyId < 1 || string.IsNullOrEmpty(tuiJianId)) return 0;

            int dalRetCode = dal.SheZhiStatus(companyId, tuiJianId, status);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置推荐状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_平台推荐;
                log.EventMessage = "设置推荐状态，推荐编号：" + tuiJianId + "，状态：" + status + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }
        #endregion
    }
}
