//财务管理-资产负债表相关业务逻辑 汪奇志 2013-02-04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    public class BZiChanFuZhai : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IZiChanFuZhai dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IZiChanFuZhai>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
         public BZiChanFuZhai() { }
        #endregion

        #region private members
         /// <summary>
        /// 是否存在相同的资产负债年月份信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        bool IsExists(int companyId, int year, int month, string ziChanFuZhaiId,string zxsId)
        {
            if (companyId < 1 || year < 1901 || month < 1 || year > 2099 || month > 12) return true;

            return dal.IsExists(companyId, year, month, ziChanFuZhaiId,zxsId);
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入资产负债表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MZiChanFuZhaiInfo info)
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
                log.EventTitle = "新增资产负债表";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_资产负债表;
                log.EventMessage = "新增资产负债表，编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取资产负债表信息
        /// </summary>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <returns></returns>
        public MZiChanFuZhaiInfo GetInfo(string ziChanFuZhaiId)
        {
            if (string.IsNullOrEmpty(ziChanFuZhaiId)) return null;

            return dal.GetInfo(ziChanFuZhaiId);
        }

        /// <summary>
        /// 更新资产负债表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MZiChanFuZhaiInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.Id)) return 0;

            if (IsExists(info.CompanyId, info.Year, info.Month, info.Id,info.ZxsId)) return -1;

            var bianGengInfo = new EyouSoft.Model.TourStructure.MBianGeng();
            bianGengInfo.BianId = info.Id;
            bianGengInfo.BianType = EyouSoft.Model.EnumType.TourStructure.BianType.资产负债表;
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
                log.EventTitle = "修改资产负债表";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_资产负债表;
                log.EventMessage = "修改资产负债表，编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);

                new EyouSoft.BLL.TourStructure.BBianGeng().InsertBianGeng(bianGengInfo);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除资产负债表信息
        /// </summary>
        /// <param name="liRunId">资产负债编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string ziChanFuZhaiId, int companyId)
        {
            if (string.IsNullOrEmpty(ziChanFuZhaiId) || companyId < 1) return 0;

            int dalRetCode = dal.Delete(ziChanFuZhaiId, companyId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除资产负债表";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_资产负债表;
                log.EventMessage = "删除资产负债表，编号：" + ziChanFuZhaiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取资产负债表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息 [0:decimal:货币资金][1:decimal:应收帐款][2:decimal:其他应收款][3:decimal:预付帐款][4:decimal:应付帐款][5:decimal:预收帐款][6:decimal:实收股本][7:decimal:未分配利润][8:decimal:差额]</param>
        /// <returns></returns>
        public IList<MZiChanFuZhaiInfo> GetZiChanFuZhais(int companyId, int pageSize, int pageIndex, ref int recordCount, MZiChanFuZhaiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M, 0M, 0M, 0M, 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            var items = dal.GetZiChanFuZhais(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }
        #endregion
    }
}
