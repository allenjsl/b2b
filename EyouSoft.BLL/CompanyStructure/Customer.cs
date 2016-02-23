using System;
using System.Collections.Generic;
using System.Linq;
using EyouSoft.Model.CompanyStructure;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 客户信息管理业务逻辑
    /// </summary>
    public class Customer : BLLBase
    {
        private readonly IDAL.CompanyStructure.ICustomer dal = Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.ICustomer>();

        #region public members
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CustomerInfo GetCustomerModel(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return dal.GetCustomerModel(id);
        }

        /// <summary>
        /// 按指定条件获取客户资料信息集合
        /// </summary>
        /// <param name="companyId">公司（专线）编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="seachInfo">查询条件业务实体</param>
        /// <returns></returns>
        public IList<CustomerInfo> GetCustomers(int companyId, int pageSize, int pageIndex, ref int recordCount, MCustomerSeachInfo seachInfo)
        {
            if (companyId <= 0 || pageSize <= 0 || pageIndex <= 0) return null;

            return dal.GetCustomers(companyId, pageSize, pageIndex, ref recordCount, seachInfo);
        }

        /// <summary>
        /// (管理后台)客户新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertKeHu(EyouSoft.Model.CompanyStructure.CustomerInfo info)
        {
            if (info == null || info.CompanyId < 1) return 0;

            info.Id = Guid.NewGuid().ToString();
            info.IssueTime = info.ShenHeTime = DateTime.Now;

            if (info.Annexs != null && info.Annexs.Count > 0)
            {
                foreach (var item in info.Annexs)
                {
                    item.FileId = Guid.NewGuid().ToString();
                    item.AnnexType = EyouSoft.Model.EnumType.CompanyStructure.AnnexType.客户信息;
                }
            }

            int dalRetCode = dal.KeHu_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增客户";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;
                log.EventMessage = "新增客户，客户编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// (管理后台)客户修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateKeHu(EyouSoft.Model.CompanyStructure.CustomerInfo info)
        {
            if (info == null || info.CompanyId < 1||string.IsNullOrEmpty(info.Id)) return 0;

            info.IssueTime = info.ShenHeTime = DateTime.Now;

            if (info.Annexs != null && info.Annexs.Count > 0)
            {
                foreach (var item in info.Annexs)
                {
                    item.FileId = Guid.NewGuid().ToString();
                    item.AnnexType = EyouSoft.Model.EnumType.CompanyStructure.AnnexType.客户信息;
                }
            }

            int dalRetCode = dal.KeHu_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改客户";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;
                log.EventMessage = "修改客户，客户编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 删除客户，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">当前操作人ZxsId</param>
        /// <param name="keHuId">客户编号</param>
        /// <returns></returns>
        public int DeleteKeHu(int companyId, string zxsId, string keHuId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || string.IsNullOrEmpty(keHuId)) return 0;
            int dalRetCode = dal.KeHu_D(companyId, zxsId, keHuId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除客户";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;
                log.EventMessage = "删除客户，客户编号：" + keHuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// (管理系统)客户联系人用户新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuMing">用户名</param>
        /// <param name="miMa">密码</param>
        /// <param name="md5MiMa">MD5密码</param>
        /// <param name="youXiang">邮箱</param>
        /// <returns></returns>
        public int KeHuLxrYongHu_CU(string keHuId, int lxrId, int yongHuId,string yongHuMing, string miMa, string md5MiMa,string youXiang)
        {
            if (string.IsNullOrEmpty(keHuId) || lxrId < 1 || string.IsNullOrEmpty(yongHuMing)) return 0;
            if (yongHuId == 0 && (string.IsNullOrEmpty(miMa) || string.IsNullOrEmpty(md5MiMa))) return 0;

            int dalRetCode = dal.KeHuLxrYongHu_CU(keHuId, lxrId, yongHuMing, miMa, md5MiMa,youXiang);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "客户联系人用户管理";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;
                log.EventMessage = "客户联系人用户管理，客户编号：" + keHuId + "，联系人编号：" + lxrId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// (管理系统)客户联系人用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public int KeHulxrYonHu_D(string keHuId, int lxrId, int yongHuId)
        {
            if (string.IsNullOrEmpty(keHuId) || lxrId < 1 || yongHuId < 1) return 0;

            int dalRetCode = dal.KeHulxrYonHu_D(keHuId, lxrId, yongHuId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "客户联系人用户删除";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;
                log.EventMessage = "客户联系人用户删除，客户编号：" + keHuId + "，联系人编号：" + lxrId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取客户联系人信息
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <returns></returns>
        public EyouSoft.Model.CompanyStructure.CustomerContactInfo GetKeHuLxrInfo(string keHuId, int lxrId)
        {
            if (string.IsNullOrEmpty(keHuId) || lxrId < 1) return null;

            return dal.GetKeHuLxrInfo(keHuId, lxrId);
        }

        /// <summary>
        /// 注册客户审核，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="shenHeRenId">审核人编号</param>
        /// <returns></returns>
        public int ZhuCeKeHuShenHe(int companyId, string keHuId, int shenHeRenId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(keHuId) || shenHeRenId < 1) return 0;

            int dalRetCode = dal.ZhuCeKeHuShenHe(companyId, keHuId, shenHeRenId, DateTime.Now);

            return dalRetCode;
        }

        /// <summary>
        /// （平台）客户注册，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int PT_KeHuZhuCe(MKeHuZhuCeInfo info)
        {
            if (info == null 
                || info.CompanyId <= 0 
                || string.IsNullOrEmpty(info.KeHuName) 
                || string.IsNullOrEmpty(info.YongHuMing) 
                || string.IsNullOrEmpty(info.YongHuYouXiang) 
                || string.IsNullOrEmpty(info.YongHuXingMing) 
                || string.IsNullOrEmpty(info.YongHuMiMa)) return 0;

            var pwdInfo = new EyouSoft.Model.CompanyStructure.PassWord();
            pwdInfo.NoEncryptPassword = info.YongHuMiMa;

            info.YongHuMiMaMd5 = pwdInfo.MD5Password;

            info.KeHuId = Guid.NewGuid().ToString();
            info.ZhuCeShiJian = DateTime.Now;

            int dalRetCode = dal.PT_KeHuZhuCe(info);

            return dalRetCode;
        }

        /// <summary>
        /// （平台）客户资料修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int PT_KeHuXiuGai(EyouSoft.Model.CompanyStructure.CustomerInfo info)
        {
            if (info == null || info.CompanyId < 1 || string.IsNullOrEmpty(info.Id)) return 0;

            int dalRetCode = dal.PT_KeHuXiuGai(info);

            return dalRetCode;
        }

        /// <summary>
        /// 客户联系人新增修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int KeHuLxr_CU(EyouSoft.Model.CompanyStructure.CustomerContactInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.CustomerId)) return 0;

            int keHuLxrId = info.ContactId;

            int dalRetCode = dal.KeHuLxr_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;

                if (keHuLxrId == 0)
                {
                    log.EventTitle = "客户联系人新增";
                    log.EventMessage = "客户联系人新增，客户编号：" + info.CustomerId + "，联系人编号：" + info.ContactId;
                }
                else
                {
                    log.EventTitle = "客户联系人修改";
                    log.EventMessage = "客户联系人修改，客户编号：" + info.CustomerId + "，联系人编号：" + info.ContactId;
                }

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 客户联系人删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">操作人公司编号</param>
        /// <param name="zxsId">操作人专线商编号</param>
        /// <param name="operatorId">操作人编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="keHulxrId">客户联系人编号</param>
        /// <returns></returns>
        public int KeHuLxr_D(int companyId, string zxsId, int operatorId, string keHuId, int keHulxrId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || operatorId < 1 || string.IsNullOrEmpty(keHuId) || keHulxrId <= 0) return 0;

            int dalRetCode = dal.KeHuLxr_D(companyId, zxsId, operatorId, keHuId, keHulxrId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "客户联系人删除";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;
                log.EventMessage = "客户联系人删除：" + keHuId + "，联系人编号：" + keHulxrId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }
        #endregion
    }
}
