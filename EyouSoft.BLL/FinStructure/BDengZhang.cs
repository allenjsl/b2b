using System;
using System.Collections.Generic;
using System.Linq;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 出纳登账业务逻辑
    /// </summary>
    public class BDengZhang : BLLBase
    {
        private readonly IDAL.FinStructure.IDengZhang _dal =
            Component.Factory.ComponentFactory.CreateDAL<IDAL.FinStructure.IDengZhang>();

        #region public members
        /// <summary>
        /// 添加出纳登账信息
        /// </summary>
        /// <param name="model">添加出纳登帐信息</param>
        /// <returns>返回1成功；其他失败</returns>
        public int AddDengZhang(MChuNaDengZhang model)
        {
            if (model == null || string.IsNullOrEmpty(model.DaoKuanBankId)
                || model.DaoKuanJinE <= 0) return 0;

            model.DengZhangId = Guid.NewGuid().ToString();
            model.Status = Model.EnumType.FinStructure.KuanXiangStatus.未审批;

            int dalRetCode = _dal.AddDengZhang(model);

            if (dalRetCode == 1)
            {
                var log = new Model.CompanyStructure.SysHandleLogs
                    {
                        EventTitle = "登记出纳登账信息",
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账,
                        EventMessage = "登记出纳登账信息，出纳登账编号：" + model.DengZhangId + "。"
                    };

                new CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改登账信息
        /// </summary>
        /// <param name="model">出纳登帐信息</param>
        /// <returns>
        /// 返回1成功；
        /// 0参数错误；
        /// -1修改失败;
        /// -2登账信息已经审批，不能修改 
        /// </returns>
        public int UpdateDengZhang(MChuNaDengZhang model)
        {
            if (model == null || string.IsNullOrEmpty(model.DaoKuanBankId) || model.DaoKuanJinE <= 0
                || string.IsNullOrEmpty(model.DengZhangId)) return 0;

            model.Status = Model.EnumType.FinStructure.KuanXiangStatus.未审批;

            int dalRetCode = _dal.UpdateDengZhang(model);

            if (dalRetCode == 1)
            {
                var log = new Model.CompanyStructure.SysHandleLogs
                {
                    EventTitle = "修改出纳登账信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账,
                    EventMessage = "修改出纳登账信息，出纳登账编号：" + model.DengZhangId + "。"
                };

                new CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除出纳登账信息
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <returns>
        /// 1：成功；
        /// 0：参数错误；
        /// -1：删除失败；
        /// -2：单条删除时，要删除的登账信息已审批，不能删除；
        /// -3：多条删除时，删除没有审批的，已经审批的没有删除；
        /// </returns>
        public int DeleteDengZhang(params string[] dengZhangId)
        {
            if (dengZhangId == null || dengZhangId.Length <= 0) return 0;

            int dalRetCode = _dal.DeleteDengZhang(dengZhangId);

            if (dalRetCode == 1 || dalRetCode == -3)
            {
                var log = new Model.CompanyStructure.SysHandleLogs
                {
                    EventTitle = "删除出纳登账信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账,
                    EventMessage = "删除出纳登账信息，出纳登账编号：" + this.GetIdsByArr(dengZhangId) + "。"
                };

                new CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 审批出纳登账信息
        /// </summary>
        /// <param name="model">审批信息实体</param>
        /// <param name="dengZhangId">登账编号</param>
        /// <returns>返回1成功；其他失败</returns>
        public int ShenPiDengZhang(MShenPiDengZhang model, params string[] dengZhangId)
        {
            if (model == null || model.OperatorId <= 0 || dengZhangId == null || dengZhangId.Length <= 0) return 0;

            int dalRetCode = _dal.ShenPiDengZhang(model, dengZhangId);

            if (dalRetCode == 1)
            {
                var log = new Model.CompanyStructure.SysHandleLogs
                {
                    EventTitle = "审批出纳登账信息",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账,
                    EventMessage = "审批出纳登账信息，出纳登账编号：" + this.GetIdsByArr(dengZhangId) + "。"
                };

                new CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取登账信息列表
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="search">查询实体</param>
        /// <param name="zongJinE">返回总到款金额</param>
        /// <param name="zongXiaoZhangJinE">返回总销账金额</param>
        /// <returns></returns>
        public IList<MChuNaDengZhang> GetChuNaDengZhang(int companyId, int pageSize, int pageIndex, ref int recordCount
            , MSearchChuNaDengZhang search, ref decimal zongJinE, ref decimal zongXiaoZhangJinE)
        {
            if (companyId <= 0) return null;

            if (!this.ValidPaging(pageSize, pageIndex)) return null;

            return _dal.GetChuNaDengZhang(
                companyId, pageSize, pageIndex, ref recordCount, search, ref zongJinE, ref zongXiaoZhangJinE);
        }

        /// <summary>
        /// 获取登账信息实体
        /// </summary>
        /// <param name="dengZhangId">登账编号</param>
        /// <returns></returns>
        public MChuNaDengZhang GetChuNaDengZhang(string dengZhangId)
        {
            if (string.IsNullOrEmpty(dengZhangId)) return null;

            return _dal.GetChuNaDengZhang(dengZhangId);
        }

        /*/// <summary>
        /// 登账信息销账处理
        /// </summary>
        /// <param name="dengZhangId">登账信息编号</param>
        /// <param name="list">销账实体集合</param>
        /// <returns>
        /// 0：参数验证没通过；
        /// 1：销账成功；
        /// -1：要销账的所有的金额合计大于出纳登帐信息的到款金额
        /// -2：登账信息没有审批，不能销账
        /// -3：销账失败
        /// </returns>
        public int UnCheckDengZhang(string dengZhangId, IList<MXiaoZhang> list)
        {
            if (string.IsNullOrEmpty(dengZhangId) || list == null || !list.Any()) return 0;

            int dalRetCode = _dal.UnCheckDengZhang(dengZhangId, list);

            if (dalRetCode == 1)
            {
                var log = new Model.CompanyStructure.SysHandleLogs
                    {
                        EventTitle = "出纳登账销账",
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账,
                        EventMessage = "出纳登账销账操作，出纳登账编号：" + dengZhangId + "。"
                    };

                new CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }*/

        /// <summary>
        /// 获取已销账信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息[0:decimal:已销账金额]</param>
        /// <returns></returns>
        public IList<MYiXiaoZhangInfo> GetYiXiaoZhangs(int companyId, int pageSize, int pageIndex, ref int recordCount, MYiXiaoZhangChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return _dal.GetYiXiaoZhangs(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
        }

        /// <summary>
        /// 取消审批，返回1成功，其它失败
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string dengZhangId, int companyId, MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(dengZhangId) || companyId < 1) return 0;

            var info1 = GetChuNaDengZhang(dengZhangId);
            if (info1 == null) return -1;

            if (info1.Status == EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批) return -2;
            if (info1.UnCheckMoney > 0) return -3;

            int dalRetCode = _dal.QuXiaoShenPi(dengZhangId, companyId, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "出纳登账取消审批";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账;
                log.EventMessage = "出纳登账取消审批，登账编号：" + dengZhangId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 冲抵，返回1成功，其它失败
        /// </summary>
        /// <param name="info">冲抵信息</param>
        /// <returns></returns>
        public int ChongDi(MChongDiInfo info)
        {
            if (info == null 
                || info.CompanyId < 1 
                || string.IsNullOrEmpty(info.DengZhangId) 
                || info.JinE <= 0 
                || info.OperatorId < 1) return 0;

            info.ChongDiId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = _dal.ChongDi(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "出纳登账冲抵";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账;
                log.EventMessage = "出纳登账冲抵，冲抵编号：" + info.ChongDiId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消销账，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="xiaoZhangId">销账编号集合</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoXiaoZhang(int companyId, string dengZhangId, string[] xiaoZhangId, MOperatorInfo info)
        {
            if (companyId < 1 
                || string.IsNullOrEmpty(dengZhangId) 
                || xiaoZhangId == null 
                || xiaoZhangId.Length == 0 
                || info == null 
                || info.OperatorId < 1) return 0;

            int dalRetCode = _dal.QuXiaoXiaoZhang(companyId, dengZhangId, xiaoZhangId, info, EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing.销账);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "出纳登账取消销账";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账;
                log.EventMessage = "出纳登账取消销账，登账编号：" + dengZhangId + "，销账编号：" + EyouSoft.Toolkit.Utils.GetSqlInExpression(xiaoZhangId) + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 取消冲抵，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="xiaoZhangId">冲抵编号集合</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoChongDi(int companyId, string dengZhangId, string[] xiaoZhangId, MOperatorInfo info)
        {
            if (companyId < 1
                || string.IsNullOrEmpty(dengZhangId)
                || xiaoZhangId == null
                || xiaoZhangId.Length == 0
                || info == null
                || info.OperatorId < 1) return 0;

            int dalRetCode = _dal.QuXiaoXiaoZhang(companyId, dengZhangId, xiaoZhangId, info, EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing.冲抵);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "出纳登账取消冲抵";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账;
                log.EventMessage = "出纳登账取消冲抵，登账编号：" + dengZhangId + "，销账编号：" + EyouSoft.Toolkit.Utils.GetSqlInExpression(xiaoZhangId) + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取出纳登账销账订单款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.FinStructure.MXiaoZhangDingDanKuanInfo> GetXiaoZhangDingDanKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun)
        {
            if (companyId < 1 || chaXun == null || string.IsNullOrEmpty(chaXun.ZxsId) || !ValidPaging(pageSize, pageIndex)) return null;

            return _dal.GetXiaoZhangDingDanKuans(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获取出纳登账销账退票款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MXiaoZhangTuiPiaoKuanInfo> GetXiaoZhangTuiPiaoKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun)
        {
            if (companyId < 1 || chaXun == null || string.IsNullOrEmpty(chaXun.ZxsId) || !ValidPaging(pageSize, pageIndex)) return null;

            return _dal.GetXiaoZhangTuiPiaoKuans(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获取出纳登账销账退回押金信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MXiaoZhangTuiHuiYaJinInfo> GetXiaoZhangTuiHuiYaJins(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun)
        {
            if (companyId < 1 || chaXun == null || string.IsNullOrEmpty(chaXun.ZxsId) || !ValidPaging(pageSize, pageIndex)) return null;

            return _dal.GetXiaoZhangTuiHuiYaJins(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获取出纳登账销账团队结算其它收入信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MXiaoZhangJieSuanQiTaShouRuInfo> GetXiaoZhangJieSuanQiTaShouRus(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun)
        {
            if (companyId < 1 || chaXun == null || string.IsNullOrEmpty(chaXun.ZxsId)|| !ValidPaging(pageSize, pageIndex)) return null;

            return _dal.GetXiaoZhangJieSuanQiTaShouRus(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 出纳登账-销账(订单款、退票款、退回押金、团队结算其它收入)，返回1成功，其它失败
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="operatorId">操作人编号</param>
        /// <param name="leiXing1">销账类型1</param>
        /// <param name="items">销售相关信息集合</param>
        /// <returns></returns>
        public int XiaoZhang(string dengZhangId, int operatorId, EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing1 leiXing1, IList<MXiaoZhang> items)
        {
            if (string.IsNullOrEmpty(dengZhangId) || operatorId < 1 || items == null || items.Count == 0) return 0;

            string _xiaoZhangIds = string.Empty;
            foreach (var item in items)
            {
                item.XiaoZhangId = Guid.NewGuid().ToString();
                _xiaoZhangIds += item.XiaoZhangId + ",";
            }

            int dalRetCode = _dal.XiaoZhang(dengZhangId, operatorId, leiXing1, items);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "出纳登账-销账("+leiXing1+")";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.财务管理_出纳登账;
                log.EventMessage = "出纳登账-销账(" + leiXing1 + ")，登账编号：" + dengZhangId + "销账编号：" + _xiaoZhangIds;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
