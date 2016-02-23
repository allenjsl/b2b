//财务管理-报销管理相关业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 财务管理-报销管理相关业务逻辑
    /// </summary>
    public class BBaoXiao : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IBaoXiao dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IBaoXiao>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BBaoXiao() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MBaoXiaoInfo info)
        {
            if (info == null
                || info.CompanyId < 1 || info.BaoXiaoRenId < 1 || info.OperatorId < 1
                || info.XiaoFeis == null || info.XiaoFeis.Count == 0) return 0;

            info.BaoXiaoId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            info.JinE = 0;
            foreach (var item in info.XiaoFeis)
            {
                info.JinE = info.JinE + item.JinE;
            }

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增报销登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_报销登记表;
                log.EventMessage = "新增报销登记，登记编号：" + info.BaoXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 更新报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MBaoXiaoInfo info)
        {
            if (info == null
                || info.CompanyId < 1 || info.BaoXiaoRenId < 1 || info.OperatorId < 1
                || info.XiaoFeis == null || info.XiaoFeis.Count == 0
                || string.IsNullOrEmpty(info.BaoXiaoId)) return 0;

            var status = dal.GetStatus(info.BaoXiaoId);

            if (status != EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未审批) return -1;

            info.JinE = 0;
            foreach (var item in info.XiaoFeis)
            {
                info.JinE = info.JinE + item.JinE;
            }

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改报销登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_报销登记表;
                log.EventMessage = "修改报销登记，登记编号：" + info.BaoXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string baoXiaoId, int companyId)
        {
            if (string.IsNullOrEmpty(baoXiaoId) || companyId < 1) return 0;

            var status = dal.GetStatus(baoXiaoId);

            if (status != EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未审批) return -1;

            int dalRetCode = dal.Delete(baoXiaoId, companyId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除报销登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_报销登记表;
                log.EventMessage = "删除报销登记，登记编号：" + baoXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取报销登记信息业务实体
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <returns></returns>
        public MBaoXiaoInfo GetInfo(string baoXiaoId)
        {
            if (string.IsNullOrEmpty(baoXiaoId)) return null;

            return dal.GetInfo(baoXiaoId);
        }

        /// <summary>
        /// 获取报销登记信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJiJinE">报销金额合计</param>
        /// <returns></returns>
        public IList<MBaoXiaoInfo> GetBaoXiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MBaoXiaoChaXunInfo chaXun, out decimal heJiJinE)
        {
            heJiJinE = 0M;
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            object[] heJi;
            var items = dal.GetBaoXiaos(companyId, pageSize, pageIndex,ref recordCount, chaXun, out heJi);
            heJiJinE = (decimal)heJi[0];

            if (items != null || items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.ZhangHuName = new BYinHangZhangHu().GetName(item.ZhangHuId, companyId,chaXun.ZxsId);
                }
            }

            return items;
        }

        /// <summary>
        /// 报销审批，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="isTongGuo">是否通过</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ShenPi(string baoXiaoId, bool isTongGuo, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(baoXiaoId) || info == null || info.OperatorId < 1) return 0;

            var _status = dal.GetStatus(baoXiaoId);

            if (_status != EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未审批) return -1;

            var status = isTongGuo ? EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未支付 : EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未通过;
            int dalRetCode = dal.ShenPi(baoXiaoId, status, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "报销审批";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_报销登记表;
                log.EventMessage = "报销审批，登记编号：" + baoXiaoId + "，状态变更为：" + status.ToString() + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 报销支付，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">支付银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int ZhiFu(string baoXiaoId, MOperatorInfo info, string zhangHuId, DateTime bankDate)
        {
            if (string.IsNullOrEmpty(baoXiaoId) || info == null || info.OperatorId < 1 
                || string.IsNullOrEmpty(zhangHuId)) return 0;

            var _status = dal.GetStatus(baoXiaoId);

            if (_status != EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未支付) return -1;

            int dalRetCode = dal.ZhiFu(baoXiaoId, info, zhangHuId, bankDate);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "报销支付";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_报销登记表;
                log.EventMessage = "报销支付，登记编号：" + baoXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消报销支付，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoZhiFu(string baoXiaoId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(baoXiaoId) 
                || info == null 
                || info.OperatorId < 1) return 0;

            var _status = dal.GetStatus(baoXiaoId);

            if (_status != EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.已支付) return -1;

            int dalRetCode = dal.QuXiaoZhiFu(baoXiaoId, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消报销支付";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_报销登记表;
                log.EventMessage = "取消报销支付，报销编号：" + baoXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消报销审批，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string baoXiaoId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(baoXiaoId)
                || info == null
                || info.OperatorId < 1) return 0;

            var _status = dal.GetStatus(baoXiaoId);

            EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus[] status = { EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未支付
                                                                              , EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未通过 };
            if (!status.Contains(_status)) return -1;

            int dalRetCode = dal.QuXiaoShenPi(baoXiaoId, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消报销审批";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_报销登记表;
                log.EventMessage = "取消报销审批，报销编号：" + baoXiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
