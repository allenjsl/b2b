//公司银行账户相关信息业务逻辑类 汪奇志 2012-11-19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.EnumType.CompanyStructure;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 公司银行账户相关信息业务逻辑类
    /// </summary>
    public class BYinHangZhangHu : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IYinHangZhangHu dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IYinHangZhangHu>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BYinHangZhangHu() { }
        #endregion

        #region internal  members
        /// <summary>
        /// 获取银行账户名称
        /// </summary>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        internal string GetName(string zhangHuId, int companyId,string zxsId)
        {
            if (string.IsNullOrEmpty(zhangHuId) || companyId < 1) return string.Empty;
            
            string _name=string.Empty;
            var items=GetZhangHus(companyId,zxsId,null) ;

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.Id == zhangHuId)
                    {
                        _name = item.BankName + "-" + item.AccountName + "-" + item.BankNo;
                    }
                }
            }

            return _name;
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入公司银行账信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(CompanyAccount info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;

            if (dal.IsExistsZhangHao(info.CompanyId, string.Empty, info.BankNo,info.LeiXing)) return -2;

            info.Id = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            info.AccountState = AccountState.未审批;

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                string cacheName = string.Format(Cache.Tag.TagName.ZxsYinHangZhangHu, info.ZxsId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(cacheName);
                EyouSoft.BLL.PtStructure.BTongZhi.RemoveCache(info.CompanyId, cacheName);

                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增公司银行账户";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_银行账号表;
                log.EventMessage = "新增公司银行账户，银行账户编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改公司银行账信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(CompanyAccount info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1
                || string.IsNullOrEmpty(info.Id)) return 0;

            if (GetStatus(info.Id, info.CompanyId,info.ZxsId) != AccountState.未审批) return -1;
            if (dal.IsExistsZhangHao(info.CompanyId, info.Id, info.BankNo,info.LeiXing)) return -2;

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                string cacheName = string.Format(Cache.Tag.TagName.ZxsYinHangZhangHu, info.ZxsId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(cacheName);
                EyouSoft.BLL.PtStructure.BTongZhi.RemoveCache(info.CompanyId, cacheName);

                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改公司银行账户";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_银行账号表;
                log.EventMessage = "修改公司银行账户，银行账户编号：" + info.Id + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除公司银行账信息，返回1成功，其它失败
        /// </summary>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public int Delete(string zhangHuId, int companyId,string zxsId)
        {
            if (string.IsNullOrEmpty(zhangHuId) || companyId < 1) return 0;
            if (GetStatus(zhangHuId, companyId,zxsId) != AccountState.未审批) return -1;

            int dalRetCode = dal.Delete(zhangHuId, companyId);

            if (dalRetCode == 1)
            {
                string cacheName = string.Format(Cache.Tag.TagName.ZxsYinHangZhangHu, zxsId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(cacheName);
                EyouSoft.BLL.PtStructure.BTongZhi.RemoveCache(companyId, cacheName);

                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除公司银行账户";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_银行账号表;
                log.EventMessage = "删除公司银行账户，银行账户编号：" + zhangHuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取公司银行账户状态
        /// </summary>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public AccountState GetStatus(string zhangHuId, int companyId,string zxsId)
        {
            if (string.IsNullOrEmpty(zhangHuId) || companyId < 1) return AccountState.不可用;
            var status = AccountState.不可用;

            var items = GetZhangHus(companyId,zxsId,null);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.Id == zhangHuId) { status = item.AccountState; break; }
                }
            }

            return status;
            //return dal.GetStatus(zhangHuId);
        }

        /// <summary>
        /// 获取公司所有银行账户信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="leiXing">银行账户类型</param>
        /// <returns></returns>
        public IList<CompanyAccount> GetZhangHus(int companyId,string zxsId,EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing? leiXing)
        {
            if (companyId < 1) return null;

            string cacheName = string.Format(Cache.Tag.TagName.ZxsYinHangZhangHu, zxsId);
            var items = (IList<CompanyAccount>)EyouSoft.Cache.Facade.EyouSoftCache.GetCache(cacheName);

            if (items == null)
            {
                items = dal.GetZhangHus(companyId, zxsId);

                EyouSoft.Cache.Facade.EyouSoftCache.Add(cacheName, items);
            }

            if (leiXing.HasValue && items != null && items.Count > 0)
            {
                IList<CompanyAccount> items1 = new List<CompanyAccount>();
                foreach (var item in items)
                {
                    if (item.LeiXing == leiXing.Value) items1.Add(item);
                }
                return items1;
            }

            return items;
        }

        /// <summary>
        /// 设置公司银行账户状态，返回1成功，其它失败
        /// </summary>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">相关信息</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public int SetStatus(string zhangHuId, AccountState status, MOperatorInfo info, int companyId,string zxsId)
        {
            if (string.IsNullOrEmpty(zhangHuId) || info == null || info.OperatorId < 1) return 0;

            if (status == AccountState.未审批) return -1;

            int dalRetCode = dal.SetStatus(zhangHuId, status, info);

            if (dalRetCode == 1)
            {
                string cacheName = string.Format(Cache.Tag.TagName.ZxsYinHangZhangHu, zxsId);
                EyouSoft.Cache.Facade.EyouSoftCache.Remove(cacheName);
                EyouSoft.BLL.PtStructure.BTongZhi.RemoveCache(companyId, cacheName);

                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置公司银行账户状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_银行账号表;
                log.EventMessage = "设置公司银行账户状态，银行账户编号：" + zhangHuId + "，状态设置为：" + status.ToString() + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取公司银行账户信息
        /// </summary>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public CompanyAccount GetInfo(string zhangHuId, int companyId,string zxsId)
        {
            if (string.IsNullOrEmpty(zhangHuId) || companyId < 1) return null;
            var items = GetZhangHus(companyId,zxsId,null);
            if (items == null || items.Count == 0) return null;

            CompanyAccount info=null;

            foreach (var item in items)
            {
                if (item.Id == zhangHuId) { info = item; break; }
            }

            return info;
        }

        /// <summary>
        /// 获取公司所有银行账户信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<CompanyAccount> GetZhangHus1(int companyId, string zxsId, EyouSoft.Model.CompanyStructure.MYinHangZhangHuChaXunInfo chaXun)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return null;

            return dal.GetZhangHus1(companyId, zxsId, chaXun);
        }
        #endregion
    }
}
