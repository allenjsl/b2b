//专线商权限模板相关 汪奇志 2014-10-22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 专线商权限模板相关
    /// </summary>
    public class BZxsPrivsMoBan
    {
        private readonly EyouSoft.IDAL.PtStructure.IZxsPrivsMoBan dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IZxsPrivsMoBan>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BZxsPrivsMoBan() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;

            info.IssueTime = DateTime.Now;
            info.MoBanId = Guid.NewGuid().ToString();

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增专线商权限模板";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "新增专线商权限模板，模板编号：" + info.MoBanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.MoBanId)) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改专线商权限模板";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "修改专线商权限模板，模板编号：" + info.MoBanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="moBanId">模板编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string moBanId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(moBanId)) return 0;

            int dalRetCode = dal.Delete(companyId, moBanId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除专线商权限模板";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "删除专线商权限模板，模板编号：" + moBanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取模板信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo> GetMoBans(int companyId)
        {
            if (companyId < 1) return null;
            return dal.GetMoBans(companyId);
        }

        /// <summary>
        /// 获取模板信息
        /// </summary>
        /// <param name="moBanId">模板编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo GetInfo(string moBanId)
        {
            if (string.IsNullOrEmpty(moBanId)) return null;
            return dal.GetInfo(moBanId);
        }

        /// <summary>
        /// 设置模板权限，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="moBanId">模板编号</param>
        /// <param name="privs1">一级栏目</param>
        /// <param name="privs2">二级栏目</param>
        /// <param name="privs3">明细权限</param>
        /// <returns></returns>
        public int SheZhiPrivs(int companyId, string moBanId, string privs1, string privs2, string privs3)
        {
            if (companyId < 1 || string.IsNullOrEmpty(moBanId)) return 0;
            int dalRetCode = dal.SheZhiPrivs(companyId, moBanId, privs1,privs2,privs3);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置专线商权限模板具体权限";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "设置专线商权限模板具体权限，模板编号：" + moBanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }
        #endregion
    }
}
