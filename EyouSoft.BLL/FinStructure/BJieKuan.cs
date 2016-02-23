//财务管理借款相关业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 财务管理借款相关业务逻辑
    /// </summary>
    public class BJieKuan : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IJieKuan dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IJieKuan>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJieKuan() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MJieKuanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1
                || info.JieKuanRenId < 1) return 0;

            info.IssueTime = DateTime.Now;
            info.JieKuanId = Guid.NewGuid().ToString();

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增借款登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "新增借款登记，借款登记编号：" + info.JieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MJieKuanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1
                || info.JieKuanRenId < 1 || string.IsNullOrEmpty(info.JieKuanId)) return 0;

            if (dal.GetStatus(info.JieKuanId) != EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未审批) return -1;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改借款登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "修改借款登记，借款登记编号：" + info.JieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string jieKuanId, int companyId)
        {
            if (string.IsNullOrEmpty(jieKuanId) || companyId < 1) return 0;

            if (dal.GetStatus(jieKuanId) != EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未审批) return -1;

            int dalRetCode = dal.Delete(jieKuanId, companyId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除借款登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "删除借款登记，借款登记编号：" + jieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取借款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:借款金额] [1:decimal:归还金额]</param>
        /// <returns></returns>
        public IList<MJieKuanInfo> GetJieKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MJieKuanChaXunInfo chaXun, out decimal[] heJi)
        {
            heJi = new decimal[] { 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            object[] _heJi;
            var items = dal.GetJieKuans(companyId, pageSize, pageIndex, ref recordCount, chaXun, out  _heJi);
            heJi[0] = (decimal)_heJi[0];
            heJi[1] = (decimal)_heJi[1];

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.FuKuanZhangHuName = new BYinHangZhangHu().GetName(item.FuKuanZhangHuId, companyId,chaXun.ZxsId);
                    item.GuiHuanZhangHuName = new BYinHangZhangHu().GetName(item.GuiHuanZhangHuId, companyId,chaXun.ZxsId);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取借款信息实体
        /// </summary>
        /// <param name="jieKuanId">借款编号</param>
        /// <returns></returns>
        public MJieKuanInfo GetInfo(string jieKuanId)
        {
            if (string.IsNullOrEmpty(jieKuanId)) return null;

            var info = dal.GetInfo(jieKuanId);

            if (info != null)
            {
                info.FuKuanZhangHuName = new BYinHangZhangHu().GetName(info.FuKuanZhangHuId, info.CompanyId,info.ZxsId);
                info.GuiHuanZhangHuName = new BYinHangZhangHu().GetName(info.GuiHuanZhangHuId, info.CompanyId,info.ZxsId);
            }

            return dal.GetInfo(jieKuanId);
        }

        /// <summary>
        /// 借款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="isTongGuo">是否通过</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ShenPi(string jieKuanId, bool isTongGuo, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(jieKuanId) || info == null || info.OperatorId < 1) return 0;
            var istatus = dal.GetStatus(jieKuanId);
            if (istatus != EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未审批) return -1;

            var tostatus = isTongGuo ? EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未支付 : EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未通过;

            int dalRetCode = dal.ShenPi(jieKuanId, tostatus, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "借款审批";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "借款审批，借款登记编号：" + jieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 借款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int ZhiFu(string jieKuanId, MOperatorInfo info, string zhangHuId, DateTime bankDate)
        {
            if (string.IsNullOrEmpty(jieKuanId) || info == null || info.OperatorId < 1 || string.IsNullOrEmpty(zhangHuId)) return 0;
            var istatus = dal.GetStatus(jieKuanId);
            if (istatus != EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未支付) return -1;

            var tostatus = EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已支付;

            int dalRetCode = dal.ZhiFu(jieKuanId, tostatus, info, zhangHuId, bankDate);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "借款支付";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "借款支付，借款登记编号：" + jieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 借款归还，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int GuiHuan(string jieKuanId, MOperatorInfo info, string zhangHuId, DateTime bankDate)
        {
            if (string.IsNullOrEmpty(jieKuanId) || info == null || info.OperatorId < 1 || string.IsNullOrEmpty(zhangHuId)) return 0;
            var istatus = dal.GetStatus(jieKuanId);
            if (istatus != EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已支付) return -1;

            var tostatus = EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已归还;

            int dalRetCode = dal.ZhiFu(jieKuanId, tostatus, info, zhangHuId, bankDate);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "借款归还";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "借款归还，借款登记编号：" + jieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消借款归还，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoGuiHuan(string jieKuanId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(jieKuanId) || info == null || info.OperatorId < 1) return 0;
            var istatus = dal.GetStatus(jieKuanId);
            if (istatus != EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已归还) return -1;

            var tostatus = EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已支付;

            int dalRetCode = dal.QuXiaoGuiHuan(jieKuanId, tostatus, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消借款归还";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "取消借款归还，借款登记编号：" + jieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消借款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoZhiFu(string jieKuanId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(jieKuanId) || info == null || info.OperatorId < 1) return 0;
            var istatus = dal.GetStatus(jieKuanId);
            if (istatus != EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已支付) return -1;

            var tostatus = EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未支付;

            int dalRetCode = dal.QuXiaoZhiFu(jieKuanId, tostatus, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消借款支付";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "取消借款支付，借款登记编号：" + jieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消借款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string jieKuanId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(jieKuanId) || info == null || info.OperatorId < 1) return 0;
            EyouSoft.Model.EnumType.FinStructure.JieKuanStatus[] _status = { EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未通过
                                                                               , EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未支付 };
            var istatus = dal.GetStatus(jieKuanId);
            if (!_status.Contains(istatus)) return -1;

            var tostatus = EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未审批;

            int dalRetCode = dal.QuXiaoShenPi(jieKuanId, tostatus, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消借款审批";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                log.EventMessage = "取消借款审批，借款登记编号：" + jieKuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
