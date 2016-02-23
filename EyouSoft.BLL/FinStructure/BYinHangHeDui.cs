//银行核对相关信息业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 银行核对相关信息业务逻辑
    /// </summary>
    public class BYinHangHeDui : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IYinHangHeDui dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IYinHangHeDui>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BYinHangHeDui() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MYinHangHeDuiInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1
                || info.ZhangHus == null || info.ZhangHus.Count == 0) return 0;

            info.HeDuiId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            info.DaiFangZongE = 0;
            info.JieFangZongE = 0;
            info.YinHangZongE = 0;
            foreach (var item in info.ZhangHus)
            {
                info.DaiFangZongE = info.DaiFangZongE + item.DaiFangJinE;
                info.JieFangZongE = info.JieFangZongE + item.JieFangJinE;
                info.YinHangZongE = info.YinHangZongE + item.YuE;
            }

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增银行核对信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_银行核对表;
                log.EventMessage = "新增银行核对信息，银行核对登记编号：" + info.HeDuiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MYinHangHeDuiInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1
                || info.ZhangHus == null || info.ZhangHus.Count == 0
                || string.IsNullOrEmpty(info.HeDuiId)) return 0;

            if (dal.GetStatus(info.HeDuiId) == EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus.已确认) return -1;

            info.DaiFangZongE = 0;
            info.JieFangZongE = 0;
            info.YinHangZongE = 0;
            foreach (var item in info.ZhangHus)
            {
                info.DaiFangZongE = info.DaiFangZongE + item.DaiFangJinE;
                info.JieFangZongE = info.JieFangZongE + item.JieFangJinE;
                info.YinHangZongE = info.YinHangZongE + item.YuE;
            }

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改银行核对信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_银行核对表;
                log.EventMessage = "修改银行核对信息，银行核对登记编号：" + info.HeDuiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string heDuiId, int companyId)
        {
            if (string.IsNullOrEmpty(heDuiId) || companyId < 1) return 0;

            if (dal.GetStatus(heDuiId) == EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus.已确认) return -1;

            int dalRetCode = dal.Delete(heDuiId, companyId);


            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除银行核对信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_银行核对表;
                log.EventMessage = "删除银行核对信息，银行核对登记编号：" + heDuiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取银行核对信息
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public MYinHangHeDuiInfo GetInfo(string heDuiId,int companyId)
        {
            if (string.IsNullOrEmpty(heDuiId)) return null;

            var info = dal.GetInfo(heDuiId);

            if (info != null && info.ZhangHus != null && info.ZhangHus.Count > 0)
            {
                var bYinHangZhangHu = new EyouSoft.BLL.FinStructure.BYinHangZhangHu();
                foreach (var item in info.ZhangHus)
                {
                    var _item = bYinHangZhangHu.GetInfo(item.ZhangHuId, companyId, info.ZxsId);

                    if (_item != null)
                    {
                        item.ZhangHuName = _item.AccountName;
                        item.YinHangName = _item.BankName;
                        item.ZhangHao = _item.BankNo;
                    }
                }
            }

            return info;
        }

        /// <summary>
        /// 获取银行核对状态
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <returns></returns>
        public EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus GetStatus(string heDuiId)
        {
            if (string.IsNullOrEmpty(heDuiId)) return EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus.已确认;

            return dal.GetStatus(heDuiId);
        }

        /// <summary>
        /// 获取银行核对信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<MYinHangHeDuiInfo> GetHeDuis(int companyId, int pageSize, int pageIndex, ref int recordCount, MYinHangHeDuiChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            var items = dal.GetHeDuis(companyId, pageSize, pageIndex, ref recordCount, chaXun);

            return items;
        }

        /// <summary>
        /// 银行核对信息确认
        /// </summary>
        /// <param name="heDuiId">银行核对登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QueRen(string heDuiId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(heDuiId) || info == null || info.OperatorId < 1) return 0;

            int dalRetCode = dal.QueRen(heDuiId, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "确认银行核对信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_银行核对表;
                log.EventMessage = "确认银行核对信息，银行核对登记编号：" + heDuiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
