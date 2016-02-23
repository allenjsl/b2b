//财务管理-工资管理相关业务逻辑类 汪奇志 2013-08-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 财务管理-工资管理相关业务逻辑类
    /// </summary>
    public class BGongZi : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IGongZi dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IGongZi>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BGongZi() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.FinStructure.MGongZiInfo info)
        {
            if (info == null
                || info.CompanyId < 1
                || info.YuanGongId < 1
                || info.Year < 2000
                || info.Month < 1
                || info.Month > 12
                || info.OperatorId < 1) return 0;

            info.GongZiId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            info.Status = EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未审批;

            bool isExists = dal.IsExists(info.CompanyId, info.YuanGongId, info.Year, info.Month, string.Empty,info.FaFangLeiXing,info.ZxsId);
            if (isExists) return -1;

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增工资登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_工资管理;
                log.EventMessage = "新增工资登记，登记编号：" + info.GongZiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.FinStructure.MGongZiInfo info)
        {
            if (info == null
                || info.CompanyId < 1
                || info.YuanGongId < 1
                || info.Year < 2000
                || info.Month < 1
                || info.Month > 12
                || info.OperatorId < 1
                || string.IsNullOrEmpty(info.GongZiId)) return 0;

            info.IssueTime = DateTime.Now;

            bool isExists = dal.IsExists(info.CompanyId, info.YuanGongId, info.Year, info.Month, info.GongZiId, info.FaFangLeiXing,info.ZxsId);
            if (isExists) return -1;

            var yuanInfo = dal.GetInfo(info.GongZiId);
            if (yuanInfo == null || yuanInfo.Status != EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未审批) return -2;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改工资登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_工资管理;
                log.EventMessage = "修改工资登记，登记编号：" + info.GongZiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gongZiId">工资编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string gongZiId)
        {
            if (companyId < 1
                || string.IsNullOrEmpty(gongZiId)) return 0;

            var yuanInfo = dal.GetInfo(gongZiId);
            if (yuanInfo == null || yuanInfo.Status != EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未审批) return -1;

            int dalRetCode = dal.Delete(companyId, gongZiId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除工资登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_工资管理;
                log.EventMessage = "删除工资登记，登记编号：" +gongZiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 工资审批
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <param name="operatorInfo">操作人信息</param>
        /// <returns></returns>
        public int ShenPi(string gongZiId, EyouSoft.Model.FinStructure.MOperatorInfo operatorInfo)
        {
            if (string.IsNullOrEmpty(gongZiId) || operatorInfo == null || operatorInfo.OperatorId < 1) return 0;

            var yuanInfo = GetInfo(gongZiId);
            if (yuanInfo == null || yuanInfo.Status != EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未审批) return -1;

            int dalRetCode = dal.SetStatus(gongZiId, EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未支付, operatorInfo, string.Empty, null);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "审批工资登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_工资管理;
                log.EventMessage = "审批工资登记，登记编号：" + gongZiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消工资审批
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <param name="operatorInfo">操作人信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string gongZiId, EyouSoft.Model.FinStructure.MOperatorInfo operatorInfo)
        {
            if (string.IsNullOrEmpty(gongZiId) || operatorInfo == null || operatorInfo.OperatorId < 1) return 0;

            var yuanInfo = GetInfo(gongZiId);
            if (yuanInfo == null || yuanInfo.Status != EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未支付) return -1;

            int dalRetCode = dal.SetStatus(gongZiId, EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未审批, operatorInfo, string.Empty, null);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消审批工资登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_工资管理;
                log.EventMessage = "取消审批工资登记，登记编号：" + gongZiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 工资支付
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <param name="operatorInfo">操作人信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int ZhiFu(string gongZiId, EyouSoft.Model.FinStructure.MOperatorInfo operatorInfo, string zhangHuId, DateTime bankDate)
        {
            if (string.IsNullOrEmpty(gongZiId) || operatorInfo == null || operatorInfo.OperatorId < 1 || string.IsNullOrEmpty(zhangHuId)) return 0;

            var yuanInfo = GetInfo(gongZiId);
            if (yuanInfo == null || yuanInfo.Status != EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未支付) return -1;

            int dalRetCode = dal.SetStatus(gongZiId, EyouSoft.Model.EnumType.FinStructure.GongZiStatus.已支付, operatorInfo, zhangHuId, bankDate);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "支付工资登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_工资管理;
                log.EventMessage = "支付工资登记，登记编号：" + gongZiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消工资支付
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <param name="operatorInfo">操作人信息</param>
        /// <returns></returns>
        public int QuXiaoZhiFu(string gongZiId, EyouSoft.Model.FinStructure.MOperatorInfo operatorInfo)
        {
            if (string.IsNullOrEmpty(gongZiId) || operatorInfo == null || operatorInfo.OperatorId < 1 ) return 0;

            var yuanInfo = GetInfo(gongZiId);
            if (yuanInfo == null || yuanInfo.Status != EyouSoft.Model.EnumType.FinStructure.GongZiStatus.已支付) return -1;

            int dalRetCode = dal.SetStatus(gongZiId, EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未支付, operatorInfo, string.Empty, null);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消支付工资登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_工资管理;
                log.EventMessage = "取消支付工资登记，登记编号：" + gongZiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        
        /// <summary>
        /// 获取工资信息业务实体
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <returns></returns>
        public EyouSoft.Model.FinStructure.MGongZiInfo GetInfo(string gongZiId)
        {
            if (string.IsNullOrEmpty(gongZiId)) return null;

            return dal.GetInfo(gongZiId);
        }

        /// <summary>
        /// 获取工资信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.FinStructure.MGongZiInfo> GetGongZis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.FinStructure.MGongZiChaXunInfo chaXun, out EyouSoft.Model.FinStructure.MGongZiHeJiInfo heJi)
        {
            heJi = new EyouSoft.Model.FinStructure.MGongZiHeJiInfo();
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            var items = dal.GetGongZis(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }

        #endregion
    }
}
