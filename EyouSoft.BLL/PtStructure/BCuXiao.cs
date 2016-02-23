//汪奇志 2014-08-22 平台促销业务逻辑
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台促销业务逻辑
    /// </summary>
    public class BCuXiao:BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.ICuXiao dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.ICuXiao>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BCuXiao() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MCuXiaoInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;
            info.CuXiaoId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增促销信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_促销信息;
                log.EventMessage = "新增促销信息，促销编号：" + info.CuXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MCuXiaoInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.CuXiaoId)) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改促销信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_促销信息;
                log.EventMessage = "修改促销信息，促销编号：" + info.CuXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="cuXiaoId">促销编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string cuXiaoId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(cuXiaoId)) return 0;
            int dalRetCode = dal.Delete(companyId, cuXiaoId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除促销信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_促销信息;
                log.EventMessage = "删除促销信息，促销编号：" + cuXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取促销信息
        /// </summary>
        /// <param name="cuXiaoId">促销编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MCuXiaoInfo GetInfo(string cuXiaoId)
        {
            if (string.IsNullOrEmpty(cuXiaoId)) return null;

            return dal.GetInfo(cuXiaoId);
        }

        /// <summary>
        /// 获取促销信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MCuXiaoInfo> GetCuXiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MCuXiaoChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            return dal.GetCuXiaos(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置促销状态，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="cuXiaoId">促销编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(int companyId, string cuXiaoId, EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus status)
        {
            if (companyId < 1 || string.IsNullOrEmpty(cuXiaoId)) return 0;

            int dalRetCode = dal.SheZhiStatus(companyId, cuXiaoId, status);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置促销状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_促销信息;
                log.EventMessage = "设置促销状态，促销编号：" + cuXiaoId + "，状态：" + status + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }
        #endregion
    }
}
