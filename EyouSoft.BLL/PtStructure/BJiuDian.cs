using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    public class BJiuDian : BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IJiuDian dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IJiuDian>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJiuDian() { }
        #endregion

        #region public members
        /// <summary>
        /// 新增酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MJiuDianInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;
            info.JiuDianId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增平台酒店";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_酒店管理;
                log.EventMessage = "新增平台酒店，酒店编号：" + info.JiuDianId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 修改酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MJiuDianInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.JiuDianId)) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改平台酒店";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_酒店管理;
                log.EventMessage = "修改平台酒店，酒店编号：" + info.JiuDianId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 删除酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string jiuDianId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(jiuDianId)) return 0;

            var fangXings = GetFangXings(jiuDianId);
            if (fangXings != null && fangXings.Count > 0) return -99;

            int dalRetCode = dal.Delete(companyId, jiuDianId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除平台酒店";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_酒店管理;
                log.EventMessage = "新增平台酒店，酒店编号：" + jiuDianId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJiuDianInfo GetInfo(string jiuDianId)
        {
            if (string.IsNullOrEmpty(jiuDianId)) return null;
            return dal.GetInfo(jiuDianId);
        }

        /// <summary>
        /// 获取酒店集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJiuDianInfo> GetJiuDians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiuDianChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            return dal.GetJiuDians(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }
        
        /// <summary>
        /// 新增酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertFangXing(EyouSoft.Model.PtStructure.MJiuDianFangXingInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.JiuDianId) || info.OperatorId < 1) return 0;
            info.FangXingId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.InsertFangXing(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增平台酒店房型";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_酒店管理;
                log.EventMessage = "新增平台酒店房型，房型编号：" + info.FangXingId + "，酒店编号：" + info.JiuDianId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 修改酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateFangXing(EyouSoft.Model.PtStructure.MJiuDianFangXingInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.JiuDianId) || info.OperatorId < 1||string.IsNullOrEmpty(info.FangXingId)) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.UpdateFangXing(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改平台酒店房型";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_酒店管理;
                log.EventMessage = "修改平台酒店房型，房型编号：" + info.FangXingId + "，酒店编号：" + info.JiuDianId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 删除酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiuDianId">酒店编号</param>
        /// <param name="fangXingId">房型编号</param>
        /// <returns></returns>
        public int DeleteFangXing(int companyId, string jiuDianId, string fangXingId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(jiuDianId) || string.IsNullOrEmpty(fangXingId)) return 0;
            int dalRetCode = dal.DeleteFangXing(companyId, jiuDianId, fangXingId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除平台酒店房型";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_酒店管理;
                log.EventMessage = "删除平台酒店房型，房型编号：" + fangXingId + "，酒店编号：" + jiuDianId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取酒店房型集合
        /// </summary>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJiuDianFangXingInfo> GetFangXings(string jiuDianId)
        {
            if (string.IsNullOrEmpty(jiuDianId)) return null;

            return dal.GetFangXings(jiuDianId);
        }

        /// <summary>
        /// 获取酒店房型信息
        /// </summary>
        /// <param name="fangXingId">房型编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJiuDianFangXingInfo GetFangXingInfo(string fangXingId)
        {
            if (string.IsNullOrEmpty(fangXingId)) return null;
            return dal.GetFangXingInfo(fangXingId);
        }
        #endregion
    }
}
