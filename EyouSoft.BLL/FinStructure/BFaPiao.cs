//财务管理发票相关业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 财务管理发票相关业务逻辑
    /// </summary>
    public class BFaPiao : BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IFaPiao dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IFaPiao>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BFaPiao() { }
        #endregion

        #region public members
        /// <summary>
        /// 发票登记，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MFaPiaoInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1
                || info.Mxs == null || info.Mxs.Count == 0 || string.IsNullOrEmpty(info.KeHuId)) return 0;

            info.FaPiaoId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            info.JinE = 0;
            foreach (var item in info.Mxs)
            {
                item.MingXiId = Guid.NewGuid().ToString();
                info.JinE = info.JinE + item.JinE;
            }

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增发票登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_发票管理;
                log.EventMessage = "新增发票登记，发票编号：" + info.FaPiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 发票修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MFaPiaoInfo info)
        {
            if (info == null || info.OperatorId < 1
                || info.Mxs == null || info.Mxs.Count == 0
                || string.IsNullOrEmpty(info.FaPiaoId)) return 0;

            info.JinE = 0;
            foreach (var item in info.Mxs)
            {
                if (string.IsNullOrEmpty(item.MingXiId)) item.MingXiId = Guid.NewGuid().ToString();
                info.JinE = info.JinE + item.JinE;
            }

            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改发票登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_发票管理;
                log.EventMessage = "修改发票登记，发票编号：" + info.FaPiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 发票删除，返回1成功，其它失败
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string faPiaoId, int companyId)
        {
            if (string.IsNullOrEmpty(faPiaoId) || companyId < 1) return 0;

            if (dal.GetFaSongShuLiang(faPiaoId) > 0) return -1;

            int dalRetCode = dal.Delete(faPiaoId, companyId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除发票登记";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_发票管理;
                log.EventMessage = "删除发票登记，发票编号：" + faPiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取发票信息
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <returns></returns>
        public MFaPiaoInfo GetInfo(string faPiaoId)
        {
            if (string.IsNullOrEmpty(faPiaoId)) return null;

            return dal.GetInfo(faPiaoId);
        }

        /// <summary>
        /// 获取发票信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJiJinE">发票金额</param>
        /// <returns></returns>
        public IList<MFaPiaoInfo> GetFaPiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MFaPiaoChaXunInfo chaXun, out decimal heJiJinE)
        {
            heJiJinE = 0M;

            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            object[] heJi;
            var items = dal.GetFaPiaos(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
            heJiJinE = (decimal)heJi[0];

            return items;
        }
        /// <summary>
        /// 修改发票明细，返回1成功，其它失败
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <param name="items">发票明细信息集合</param>
        /// <returns></returns>
        public int UpdateMingXis(string faPiaoId, IList<MFaPiaoMXInfo> items)
        {
            if (string.IsNullOrEmpty(faPiaoId)) return 0;

            bool _b = true;
            foreach (var item in items)
            {
                if (item.MXId < 1) { _b = false; break; }
            }
            if (!_b) return -1;

            int dalRetCode = dal.UpdateMingXis(faPiaoId, items);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改发票发送信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_发票管理;
                log.EventMessage = "修改发票发送信息，发票编号：" + faPiaoId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取自动完成发票订单信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo> GetAutocompleteFaPiaoDingDans(int companyId, string zxsId, EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingChaXunDanInfo chaXun)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return null;

            return dal.GetAutocompleteFaPiaoDingDans(companyId, zxsId, chaXun);
        }

        /// <summary>
        /// 获取发票明细信息
        /// </summary>
        /// <param name="mxId">明细编号</param>
        /// <returns></returns>
        public MFaPiaoMXInfo GetFaPiaoMxInfoByMxId(int mxId)
        {
            return dal.GetFaPiaoMxInfo(mxId, string.Empty);
        }

        /// <summary>
        /// 获取发票明细信息
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public MFaPiaoMXInfo GetFaPiaoMxInfoByDingDanId(string dingDanId)
        {
            return dal.GetFaPiaoMxInfo(0, dingDanId);
        }
        #endregion
    }
}
