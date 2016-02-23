using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台资讯相关
    /// </summary>
    public class BZiXun:BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IZiXun dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IZiXun>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BZiXun() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入资讯信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MZiXunInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;

            info.ZiXunId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增平台旅游资讯";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_旅游资讯;
                log.EventMessage = "新增平台旅游资讯，资讯编号：" + info.ZiXunId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改资讯信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MZiXunInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.ZiXunId)) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode=dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改平台旅游资讯";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_旅游资讯;
                log.EventMessage = "修改平台旅游资讯，资讯编号：" + info.ZiXunId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除资讯信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="ziXunId">资讯编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string ziXunId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(ziXunId)) return 0;

            int dalRetCode = dal.Delete(companyId, ziXunId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除平台旅游资讯";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_旅游资讯;
                log.EventMessage = "删除平台旅游资讯，资讯编号：" + ziXunId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取资讯信息
        /// </summary>
        /// <param name="ziXunId">资讯编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZiXunInfo GetInfo(string ziXunId)
        {
            if (string.IsNullOrEmpty(ziXunId)) return null;
            return dal.GetInfo(ziXunId);
        }

        /// <summary>
        /// 获取资讯集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZiXunInfo> GetZiXuns(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MZiXunChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            return dal.GetZiXuns(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置资讯状态，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="ziXunId">资讯编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(int companyId, string ziXunId, EyouSoft.Model.EnumType.PtStructure.ZiXunStatus status)
        {
            if (companyId < 1 || string.IsNullOrEmpty(ziXunId)) return 0;

            int dalRetCode = dal.SheZhiStatus(companyId, ziXunId, status);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置资讯状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_旅游资讯;
                log.EventMessage = "设置资讯状态，资讯编号：" + ziXunId + "，状态：" + status + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }
        #endregion
    }
}
