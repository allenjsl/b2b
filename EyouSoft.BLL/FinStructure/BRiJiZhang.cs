//财务管理出纳日记账相关业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 财务管理出纳日记账相关业务逻辑
    /// </summary>
    public class BRiJiZhang : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IRiJiZhang dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IRiJiZhang>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BRiJiZhang() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入出纳日记账信息
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MRiJiZhangInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.ZhangHuId)) return 0;
            if (info.JieFangJinE > 0 && info.DaiFangJinE > 0) return -1;
            if (info.JieFangJinE == 0 && info.DaiFangJinE == 0) return -2;

            info.RiJiId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增出纳日记账";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_出纳日记账;
                log.EventMessage = "新增出纳日记账，日记账登记编号：" + info.RiJiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取出纳日记账信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<MRiJiZhangInfo> GetRiJiZhangs(int companyId, int pageSize, int pageIndex, ref int recordCount, MRiJiZhangChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            object[] heJi;

            var items = dal.GetRiJiZhangs(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.ZhangHuName = new BLL.FinStructure.BYinHangZhangHu().GetName(item.ZhangHuId, companyId,chaXun.ZxsId);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取余额，未做过任何登记时取所有可用银行账号原始金额合计，已登记取最后一次出纳日记账余额
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public decimal GetYuE(int companyId)
        {
            if (companyId < 1) return 0;

            return dal.GetYuE(companyId);
        }

        /// <summary>
        /// 获取出纳日记账信息业务实体
        /// </summary>
        /// <param name="riJiZhangId">日记账编号</param>
        /// <returns></returns>
        public MRiJiZhangInfo GetInfo(string riJiZhangId)
        {
            if (string.IsNullOrEmpty(riJiZhangId)) return null;

            return dal.GetInfo(riJiZhangId);
        }

        /// <summary>
        /// 修改出纳日记账信息，借贷金额不做修改
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MRiJiZhangInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.ZhangHuId) || string.IsNullOrEmpty(info.RiJiId)) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改出纳日记账";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_出纳日记账;
                log.EventMessage = "修改出纳日记账，日记账登记编号：" + info.RiJiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
