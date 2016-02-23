//付款登记信息相关业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 付款登记信息相关业务逻辑
    /// </summary>
    public class BFuKuan : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IFuKuan dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IFuKuan>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BFuKuan() { }
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
        /// 写入付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MFuKuanInfo info)
        {
            if (info == null || info.CompanyId < 1
                || string.IsNullOrEmpty(info.FuKuanXiangMuId) || info.OperatorId < 1) return 0;

            KuanXiangType[] _types = {KuanXiangType.地接支出付款
                                       ,KuanXiangType.订单退款
                                       ,KuanXiangType.酒店安排付款
                                       ,KuanXiangType.票务安排付款
                                       ,KuanXiangType.票务押金付款
                                       ,KuanXiangType.其它支出付款 };

            if (!_types.Contains(info.KuanXiangType)) return -1;

            info.IssueTime = DateTime.Now;
            info.DengJiId = Guid.NewGuid().ToString();

            if (info.KuanXiangType != KuanXiangType.订单退款)
            {
                var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingFuJinE(info.FuKuanXiangMuId, info.KuanXiangType);
                if (jinE[0] < jinE[1] + jinE[2] + jinE[3] + info.JinE) return -3;
            }

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增付款登记";
                log.ModuleId = GetPrivs2(info.KuanXiangType);
                log.EventMessage = "新增付款登记，付款登记编号：" + info.DengJiId + "，付款项目编号：" + info.FuKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MFuKuanInfo info)
        {
            if (info == null || info.CompanyId < 1
                || string.IsNullOrEmpty(info.FuKuanXiangMuId) || info.OperatorId < 1
                || string.IsNullOrEmpty(info.DengJiId)) return 0;

            KuanXiangType[] _types = {KuanXiangType.地接支出付款
                                       ,KuanXiangType.订单退款
                                       ,KuanXiangType.酒店安排付款
                                       ,KuanXiangType.票务安排付款
                                       ,KuanXiangType.票务押金付款
                                       ,KuanXiangType.其它支出付款 };

            if (!_types.Contains(info.KuanXiangType)) return -1;

            if (dal.GetStatus(info.DengJiId) != KuanXiangStatus.未审批) return -2;

            if (info.KuanXiangType != KuanXiangType.订单退款)
            {
                var jinE = new EyouSoft.BLL.FinStructure.BFin().GetYingFuJinE(info.FuKuanXiangMuId, info.KuanXiangType);
                if (jinE[0] < jinE[1] + jinE[2] + jinE[3] + info.JinE - dal.GetFuKuanJinE(info.DengJiId)) return -3;
            }

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改付款登记";
                log.ModuleId = GetPrivs2(info.KuanXiangType);
                log.EventMessage = "修改付款登记，付款登记编号：" + info.DengJiId + "，付款项目编号：" + info.FuKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <returns></returns>
        public int Delete(string fuKuanId, int companyId, string fuKuanXiangMuId, KuanXiangType kuanXiangType)
        {
            if (string.IsNullOrEmpty(fuKuanId) || companyId < 1 || string.IsNullOrEmpty(fuKuanXiangMuId)) return 0;

            if (dal.GetStatus(fuKuanId) != KuanXiangStatus.未审批) return -2;

            int dalRetCode = dal.Delete(fuKuanId, companyId, fuKuanXiangMuId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除付款登记";
                log.ModuleId = GetPrivs2(kuanXiangType);
                log.EventMessage = "删除付款登记，付款登记编号：" + fuKuanId + "，付款项目编号：" + fuKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取付款登记信息集合
        /// </summary>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <returns></returns>
        public IList<MFuKuanInfo> GetFuKuans(KuanXiangType kuanXiangType, string fuKuanXiangMuId)
        {
            if (string.IsNullOrEmpty(fuKuanXiangMuId)) return null;

            KuanXiangType[] _types = {KuanXiangType.地接支出付款
                                       ,KuanXiangType.订单退款
                                       ,KuanXiangType.酒店安排付款
                                       ,KuanXiangType.票务安排付款
                                       ,KuanXiangType.票务押金付款
                                       ,KuanXiangType.其它支出付款 };

            if (!_types.Contains(kuanXiangType)) return null;

            var items = dal.GetFuKuans(kuanXiangType, fuKuanXiangMuId);

            return items;
        }

        /// <summary>
        /// 付款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ShenPi(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(fuKuanId) || string.IsNullOrEmpty(fuKuanXiangMuId) 
                || info == null || info.OperatorId < 1) return 0;

            KuanXiangType[] _types = {KuanXiangType.地接支出付款
                                       ,KuanXiangType.订单退款
                                       ,KuanXiangType.酒店安排付款
                                       ,KuanXiangType.票务安排付款
                                       ,KuanXiangType.票务押金付款
                                       ,KuanXiangType.其它支出付款 };

            if (!_types.Contains(kuanXiangType)) return -1;

            if (dal.GetStatus(fuKuanId) != KuanXiangStatus.未审批) return -2;

            int dalRetCode = dal.ShenPi(fuKuanId, kuanXiangType, fuKuanXiangMuId, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "付款审批";
                log.ModuleId = GetPrivs2(kuanXiangType);
                log.EventMessage = "付款审批，付款登记编号：" + fuKuanId + "，付款项目编号：" + fuKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 付款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int ZhiFu(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info, DateTime bankDate)
        {
            if (string.IsNullOrEmpty(fuKuanId) || string.IsNullOrEmpty(fuKuanXiangMuId)
                || info == null || info.OperatorId < 1) return 0;

            KuanXiangType[] _types = {KuanXiangType.地接支出付款
                                       ,KuanXiangType.订单退款
                                       ,KuanXiangType.酒店安排付款
                                       ,KuanXiangType.票务安排付款
                                       ,KuanXiangType.票务押金付款
                                       ,KuanXiangType.其它支出付款 };

            if (!_types.Contains(kuanXiangType)) return -1;

            if (kuanXiangType == KuanXiangType.订单退款)
            {
                var shenPiRetCode = ShenPi(fuKuanId, kuanXiangType, fuKuanXiangMuId, info);

                if (shenPiRetCode != 1) return -3;
            }

            if (dal.GetStatus(fuKuanId) != KuanXiangStatus.未支付) return -2;

            int dalRetCode = dal.ZhiFu(fuKuanId, kuanXiangType, fuKuanXiangMuId, info,bankDate);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "付款支付";
                log.ModuleId = GetPrivs2(kuanXiangType);
                log.EventMessage = "付款支付，付款登记编号：" + fuKuanId + "，付款项目编号：" + fuKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取付款审批信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息，[0:decimal:付款金额]</param>
        /// <returns></returns>
        public IList<MLBFuKuanShenPiInfo> GetShenPis(int companyId, int pageSize, int pageIndex, ref int recordCount, MLBFuKuanShenPiChaXunInfo chaXun, out decimal heJiJinE)
        {
            heJiJinE = 0M;

            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            object[] heJi;
            var items = dal.GetShenPis(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
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
        /// 获取付款登记实体
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <returns></returns>
        public MFuKuanInfo GetInfo(string fuKuanId)
        {
            if (string.IsNullOrEmpty(fuKuanId)) return null;

            return dal.GetInfo(fuKuanId);
        }

        /// <summary>
        /// 取消付款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(fuKuanId) || string.IsNullOrEmpty(fuKuanXiangMuId)
                || info == null || info.OperatorId < 1) return 0;

            KuanXiangType[] _types = {KuanXiangType.地接支出付款
                                       ,KuanXiangType.订单退款
                                       ,KuanXiangType.酒店安排付款
                                       ,KuanXiangType.票务安排付款
                                       ,KuanXiangType.票务押金付款
                                       ,KuanXiangType.其它支出付款 };

            if (!_types.Contains(kuanXiangType)) return -1;

            if (dal.GetStatus(fuKuanId) != KuanXiangStatus.未支付) return -2;

            int dalRetCode = dal.QuXiaoShenPi(fuKuanId, kuanXiangType, fuKuanXiangMuId, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消付款审批";
                log.ModuleId = GetPrivs2(kuanXiangType);
                log.EventMessage = "取消付款审批，付款登记编号：" + fuKuanId + "，付款项目编号：" + fuKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消付款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoZhiFu(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(fuKuanId) || string.IsNullOrEmpty(fuKuanXiangMuId)
                || info == null || info.OperatorId < 1) return 0;

            KuanXiangType[] _types = {KuanXiangType.地接支出付款
                                       ,KuanXiangType.订单退款
                                       ,KuanXiangType.酒店安排付款
                                       ,KuanXiangType.票务安排付款
                                       ,KuanXiangType.票务押金付款
                                       ,KuanXiangType.其它支出付款 };

            if (!_types.Contains(kuanXiangType)) return -1;

            if (dal.GetStatus(fuKuanId) != KuanXiangStatus.已支付) return -2;

            int dalRetCode = dal.QuXiaoZhiFu(fuKuanId, kuanXiangType, fuKuanXiangMuId, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "取消付款支付";
                log.ModuleId = GetPrivs2(kuanXiangType);
                log.EventMessage = "取消付款支付，付款登记编号：" + fuKuanId + "，付款项目编号：" + fuKuanXiangMuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);

                if (kuanXiangType == KuanXiangType.订单退款)
                {
                    var shenPiRetCode = QuXiaoShenPi(fuKuanId, kuanXiangType, fuKuanXiangMuId, info);

                    if (shenPiRetCode != 1) return -3;
                }
            }

            return dalRetCode;
        }
        #endregion
    }
}
