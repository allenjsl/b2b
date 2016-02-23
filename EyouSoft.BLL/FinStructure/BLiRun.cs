//财务管理-利润表相关业务逻辑 汪奇志 2013-02-04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 财务管理-利润表相关业务逻辑
    /// </summary>
    public class BLiRun : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.ILiRun dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.ILiRun>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BLiRun() { }
        #endregion

        #region private members
        /// <summary>
        /// 是否存在相同的利润年月份信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="liRunId">利润编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        bool IsExists(int companyId, int year, int month, string liRunId,string zxsId)
        {
            if (companyId < 1 || year < 1901 || month < 1 || year > 2099 || month > 12) return true;

            return dal.IsExists(companyId, year, month, liRunId,zxsId);
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入利润表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MLiRunInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;
            info.Id = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            if (IsExists(info.CompanyId, info.Year, info.Month, string.Empty,info.ZxsId)) return -1;

            if (info.Historys != null && info.Historys.Count > 0)
            {
                foreach (var item in info.Historys)
                {
                    item.IssueTime = DateTime.Now;
                }
            }

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                dal.InsertHistory(info.Historys, info.Id);

                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增利润表";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_利润表;
                log.EventMessage = "新增利润表，编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取利润表信息
        /// </summary>
        /// <param name="liRunId">利润编号</param>
        /// <returns></returns>
        public MLiRunInfo GetInfo(string liRunId)
        {
            if (string.IsNullOrEmpty(liRunId)) return null;

            return dal.GetInfo(liRunId);
        }

        /// <summary>
        /// 更新利润表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MLiRunInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.Id)) return 0;

            if (IsExists(info.CompanyId, info.Year, info.Month, info.Id,info.ZxsId)) return -1;

            var bianGengInfo = new EyouSoft.Model.TourStructure.MBianGeng();
            bianGengInfo.BianId = info.Id;
            bianGengInfo.BianType = EyouSoft.Model.EnumType.TourStructure.BianType.利润表;
            bianGengInfo.OperatorId = info.OperatorId;
            bianGengInfo.Url = new EyouSoft.Toolkit.request(info.PageUri, 1024, 768, 1024, 768, info.CompanyId, System.Web.HttpContext.Current.Request.Cookies).SavePageAsImg();

            if (info.Historys != null && info.Historys.Count > 0)
            {
                foreach (var item in info.Historys)
                {
                    item.IssueTime = DateTime.Now;
                }
            }

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                dal.InsertHistory(info.Historys, info.Id);

                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改利润表";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_利润表;
                log.EventMessage = "修改利润表，编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);

                new EyouSoft.BLL.TourStructure.BBianGeng().InsertBianGeng(bianGengInfo);
            }

            return dalRetCode;
        }
        /// <summary>
        /// 删除利润表信息
        /// </summary>
        /// <param name="liRunId">利润编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string liRunId, int companyId)
        {
            if (string.IsNullOrEmpty(liRunId) || companyId < 1) return 0;

            int dalRetCode = dal.Delete(liRunId, companyId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除利润表";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_利润表;
                log.EventMessage = "删除利润表，编号：" + liRunId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取利润表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息 [0:decimal:团队结算毛利合计] [1:decimal:报销费用合计][2:decimal:营业外收入合计][3:decimal:营业外支出合计][4:decimal:纯利润合计][5:decimal:主营业务收入合计][6:decimal:主营业务支出合计][7:decimal:其它损失合计]</param>
        /// <returns></returns>
        public IList<MLiRunInfo> GetLiRuns(int companyId, int pageSize, int pageIndex, ref int recordCount, MLiRunChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M, 0M, 0M, 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            var items = dal.GetLiRuns(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }
        #endregion
    }
}
