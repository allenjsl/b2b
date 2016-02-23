//收款相关信息业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 收款相关信息业务逻辑
    /// </summary>
    public class BShouKuan
    {
        private readonly EyouSoft.IDAL.FinStructure.IShouKuan dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IShouKuan>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BShouKuan() { }
        #endregion

        #region private members
        /// <summary>
        /// 获取二级栏目
        /// </summary>
        /// <param name="kuanXiangType">收付款登记类型</param>
        /// <returns></returns>
        EyouSoft.Model.EnumType.PrivsStructure.Privs2 GetPrivs2(KuanXiangType kuanXiangType)
        {
            var privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.None;

            switch (kuanXiangType)
            {
                case KuanXiangType.报销支付:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_报销登记表;
                    break;
                case KuanXiangType.地接支出付款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_应付地接费;
                    break;
                case KuanXiangType.订单收款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_销售收款;
                    break;
                case KuanXiangType.订单退款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_销售收款;
                    break;
                case KuanXiangType.借款归还:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                    break;
                case KuanXiangType.借款支付:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_借款登记表;
                    break;
                case KuanXiangType.酒店安排付款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_预订酒店应付费;
                    break;
                case KuanXiangType.票务安排付款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_应付交通费;
                    break;
                case KuanXiangType.票务退款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_应付交通费;
                    break;
                case KuanXiangType.票务押金付款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_应付交通费;
                    break;
                case KuanXiangType.票务押金退还:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_应付交通费;
                    break;
                case KuanXiangType.其它收入收款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_其他收入表;
                    break;
                case KuanXiangType.其它支出付款:
                    privs2 = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_其他支出表;
                    break;
            }

            return privs2;
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MShouKuanInfo info)
        {
            if (info == null || info.CompanyId < 1
                || string.IsNullOrEmpty(info.ShouKuanXiangMuId) || info.OperatorId < 1) return 0;

            KuanXiangType[] _types = {KuanXiangType.订单收款
                                       ,KuanXiangType.票务押金退还
                                       ,KuanXiangType.票务退款
                                       ,KuanXiangType.其它收入收款 };

            if (!_types.Contains(info.KuanXiangType)) return -1;

            if (info.KuanXiangType == KuanXiangType.票务押金退还)
            {
                var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingShouJinE(info.ShouKuanXiangMuId, info.KuanXiangType);
                if (jinE[0] < jinE[1] + jinE[2] + info.JinE) return -3;
            }

            info.IssueTime = DateTime.Now;
            info.DengJiId = Guid.NewGuid().ToString();

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增收款登记";
                log.ModuleId = GetPrivs2(info.KuanXiangType);
                log.EventMessage = "新增收款登记，收款登记编号：" + info.DengJiId + "，收款项目编号：" + info.ShouKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MShouKuanInfo info)
        {
            if (info == null || info.CompanyId < 1
                || string.IsNullOrEmpty(info.ShouKuanXiangMuId) || info.OperatorId < 1
                || string.IsNullOrEmpty(info.DengJiId)) return 0;

            KuanXiangType[] _types = {KuanXiangType.订单收款
                                       ,KuanXiangType.票务押金退还
                                       ,KuanXiangType.票务退款
                                       ,KuanXiangType.其它收入收款 };

            if (!_types.Contains(info.KuanXiangType)) return -1;

            if (dal.GetStatus(info.DengJiId) != KuanXiangStatus.未审批) return -2;

            if (info.KuanXiangType == KuanXiangType.票务押金退还)
            {
                var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingShouJinE(info.ShouKuanXiangMuId, info.KuanXiangType);
                if (jinE[0] < jinE[1] + jinE[2] + info.JinE - dal.GetShouKuanJinE(info.DengJiId)) return -3;
            }

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改收款登记";
                log.ModuleId = GetPrivs2(info.KuanXiangType);
                log.EventMessage = "修改收款登记，收款登记编号：" + info.DengJiId + "，收款项目编号：" + info.ShouKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <returns></returns>
        public int Delete(string shouKuanId, int companyId, string shouKuanXiangMuId, KuanXiangType kuanXiangType)
        {
            if (string.IsNullOrEmpty(shouKuanId) || companyId < 1 || string.IsNullOrEmpty(shouKuanXiangMuId)) return 0;

            if (dal.GetStatus(shouKuanId) != KuanXiangStatus.未审批) return -2;

            int dalRetCode = dal.Delete(shouKuanId, companyId, shouKuanXiangMuId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除收款登记";
                log.ModuleId = GetPrivs2(kuanXiangType);
                log.EventMessage = "删除收款登记，收款登记编号：" + shouKuanId + "，收款项目编号：" + shouKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取收款登记信息集合
        /// </summary>
        /// <param name="shouXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <returns></returns>
        public IList<MShouKuanInfo> GetShouKuans(KuanXiangType kuanXiangType, string shouKuanXiangMuId)
        {
            if (string.IsNullOrEmpty(shouKuanXiangMuId)) return null;

            KuanXiangType[] _types = {KuanXiangType.订单收款
                                       ,KuanXiangType.票务押金退还
                                       ,KuanXiangType.票务退款
                                       ,KuanXiangType.其它收入收款 };


            if (!_types.Contains(kuanXiangType)) return null;

            var items = dal.GetShouKuans(kuanXiangType, shouKuanXiangMuId);

            return items;
        }

        /// <summary>
        /// 收款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="kuanXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="bankDate">银行业务日期</param>
        /// <returns></returns>
        public int ShenPi(string shouKuanId, KuanXiangType kuanXiangType, string shouKuanXiangMuId, MOperatorInfo info, DateTime bankDate)
        {
            if (string.IsNullOrEmpty(shouKuanId) || string.IsNullOrEmpty(shouKuanXiangMuId)
                            || info == null || info.OperatorId < 1) return 0;

            KuanXiangType[] _types = {KuanXiangType.订单收款
                                       ,KuanXiangType.票务押金退还
                                       ,KuanXiangType.票务退款
                                       ,KuanXiangType.其它收入收款 };


            if (!_types.Contains(kuanXiangType)) return -1;

            if (dal.GetStatus(shouKuanId) != KuanXiangStatus.未审批) return -2;

            int dalRetCode = dal.ShenPi(shouKuanId, kuanXiangType, shouKuanXiangMuId, info, bankDate);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "收款审批";
                log.ModuleId = GetPrivs2(kuanXiangType);
                log.EventMessage = "收款审批，收款登记编号：" + shouKuanId + "，收款项目编号：" + shouKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取收款信息实体
        /// </summary>
        /// <param name="shouKuanId">收款编号</param>
        /// <returns></returns>
        public MShouKuanInfo GetInfo(string shouKuanId)
        {
            if (string.IsNullOrEmpty(shouKuanId)) return null;

            return dal.GetInfo(shouKuanId);
        }

        /// <summary>
        /// 收款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="kuanXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string shouKuanId, KuanXiangType kuanXiangType, string shouKuanXiangMuId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(shouKuanId) || string.IsNullOrEmpty(shouKuanXiangMuId)
                            || info == null || info.OperatorId < 1) return 0;

            KuanXiangType[] _types = {KuanXiangType.订单收款
                                       ,KuanXiangType.票务押金退还
                                       ,KuanXiangType.票务退款
                                       ,KuanXiangType.其它收入收款 };


            if (!_types.Contains(kuanXiangType)) return -1;

            if (dal.GetStatus(shouKuanId) != KuanXiangStatus.未支付) return -2;

            int dalRetCode = dal.QuXiaoShenPi(shouKuanId, kuanXiangType, shouKuanXiangMuId, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消收款审批";
                log.ModuleId = GetPrivs2(kuanXiangType);
                log.EventMessage = "取消收款审批，收款登记编号：" + shouKuanId + "，收款项目编号：" + shouKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
