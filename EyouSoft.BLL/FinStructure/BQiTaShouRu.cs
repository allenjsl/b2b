﻿//财务管理其它收入相关业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 财务管理其它收入相关业务逻辑
    /// </summary>
    public class BQiTaShouRu:BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IQiTaShouRu dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IQiTaShouRu>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BQiTaShouRu() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MQiTaShouRuInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.KeHuId)) return 0;

            if (!string.IsNullOrEmpty(info.KongWeiId)) if (new EyouSoft.BLL.TourStructure.BTour().GetKongWeiZhuangTai(info.KongWeiId) == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束) return -19;

            info.IssueTime = DateTime.Now;
            info.ShouRuId = Guid.NewGuid().ToString();

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增其它收入";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_其他收入表;
                log.EventMessage = "新增其它收入，其它收入登记编号：" + info.ShouRuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /*/// <summary>
        /// 获取金额信息
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <param name="jinE">金额信息[0:decimal:应收金额][1:decimal:已审批金额][2:decimal:未审批金额]</param>
        /// <returns></returns>
        public void GetJinE(string shouRuId, out decimal[] jinE)
        {
            jinE = new decimal[] { 0M, 0M, 0M };
            if (string.IsNullOrEmpty(shouRuId)) return;

            dal.GetJinE(shouRuId, out jinE);
        }*/

        /// <summary>
        /// 修改其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MQiTaShouRuInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.KeHuId)
                || string.IsNullOrEmpty(info.ShouRuId)) return 0;

            decimal[] jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingShouJinE(info.ShouRuId, EyouSoft.Model.EnumType.FinStructure.KuanXiangType.其它收入收款);

            if (info.JinE < jinE[1] + jinE[2]) return -1;

            if (!string.IsNullOrEmpty(info.KongWeiId)) if (new EyouSoft.BLL.TourStructure.BTour().GetKongWeiZhuangTai(info.KongWeiId) == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束) return -19;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改其它收入";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_其他收入表;
                log.EventMessage = "修改其它收入，其它收入登记编号：" + info.ShouRuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string shouRuId, int companyId)
        {
            if (string.IsNullOrEmpty(shouRuId) || companyId < 1) return 0;

            var info = GetInfo(shouRuId);
            if (info == null) return -2;
            if (info.IsChongDi) return -3;

            decimal[] jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingShouJinE(shouRuId, EyouSoft.Model.EnumType.FinStructure.KuanXiangType.其它收入收款);

            if (jinE[1] + jinE[2]>0) return -1;

            int dalRetCode = dal.Delete(shouRuId, companyId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除其它收入";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_其他收入表;
                log.EventMessage = "删除其它收入，其它收入登记编号：" + shouRuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取其它收入信息业务实体
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <returns></returns>
        public MQiTaShouRuInfo GetInfo(string shouRuId)
        {
            if (string.IsNullOrEmpty(shouRuId)) return null;

            return dal.GetInfo(shouRuId);
        }

        /// <summary>
        /// 获取其它收入信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:应收合计] [1:decimal:已审批金额合计][2:decimal:未审批金额合计]</param>
        /// <returns></returns>
        public IList<MQiTaShouRuInfo> GetQiTaShouRus(int companyId, int pageSize, int pageIndex, ref int recordCount, MQiTaShouZhiChaXunInfo chaXun, out decimal[] heJi)
        {
            heJi = new decimal[] { 0M, 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            var items = dal.GetQiTaShouRus(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }

        /// <summary>
        /// 获取控位其它收入信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<MQiTaShouRuInfo> GetKongWeiQiTaShouRus(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;

            return dal.GetKongWeiQiTaShouRus(kongWeiId);
        }
        #endregion
    }
}
