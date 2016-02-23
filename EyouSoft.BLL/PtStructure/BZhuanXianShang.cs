using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 专线商相关
    /// </summary>
    public class BZhuanXianShang : BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IZhuanXianShang dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IZhuanXianShang>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BZhuanXianShang() { }
        #endregion

        #region public members
        /// <summary>
        /// 专线商新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertZhuanXianShang(EyouSoft.Model.PtStructure.MZhuanXianShangInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1) return 0;
            info.ZxsId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            int dalRetCode = dal.ZhuanXianShang_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增专线商";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "新增专线商，专线商编号：" + info.ZxsId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 专线商修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateZhuanXianShang(EyouSoft.Model.PtStructure.MZhuanXianShangInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1||string.IsNullOrEmpty(info.ZxsId)) return 0;
            info.IssueTime = DateTime.Now;
            int dalRetCode = dal.ZhuanXianShang_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改专线商";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "修改专线商，专线商编号：" + info.ZxsId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }


        /// <summary>
        /// 专线商删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string zxsId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return 0;
            int dalRetCode = dal.Delete(companyId, zxsId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除专线商";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "删除专线商，专线商编号：" + zxsId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取专线商信息
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZhuanXianShangInfo GetInfo(string zxsId)
        {
            if (string.IsNullOrEmpty(zxsId)) return null;

            return dal.GetInfo(zxsId);
        }

        /// <summary>
        /// 获取专线商集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhuanXianShangInfo> GetZxss(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetZxss(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置专线商状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(int companyId, string zxsId, EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus status)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return 0;

            int dalRetCode = dal.SheZhiStatus(companyId, zxsId, status);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置专线商状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "设置专线商状态，专线商编号：" + zxsId + "，状态：" + status;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 设置专线商积分发放状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="status">积分发放状态</param>
        /// <returns></returns>
        public int SheZhiJiFenStatus(int companyId, string zxsId, EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus status)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return 0;

            int dalRetCode = dal.SheZhiJiFenStatus(companyId, zxsId, status);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置专线商积分发放状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "设置专线商积分发放状态，专线商编号：" + zxsId + "，状态：" + status;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 专线商授权
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="privs1">privs1</param>
        /// <param name="privs2">privs2</param>
        /// <param name="privs3">privs3</param>
        /// <returns></returns>
        public int SheZhiPrivs(int companyId, string zxsId, string privs1, string privs2, string privs3)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return 0;
            int dalRetCode = dal.SheZhiPrivs(companyId, zxsId, privs1, privs2, privs3);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置专线商权限";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "设置专线商权限，专线商编号：" + zxsId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 专线商积分结算新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertJiFenJieSuan(EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.JiFen < 1 || info.JinE <= 0 || info.OperatorId < 1 || string.IsNullOrEmpty(info.ZxsId)) return 0;
            info.JieSuanId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.JiFenJieSuan_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增专线商积分结算信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "新增专线商积分结算信息，结算编号：" + info.JieSuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 专线商积分结算修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateJiFenJieSuan(EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.JiFen < 1 || info.JinE <= 0 || info.OperatorId < 1 || string.IsNullOrEmpty(info.ZxsId) || string.IsNullOrEmpty(info.JieSuanId)) return 0;
            info.JieSuanId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.JiFenJieSuan_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改专线商积分结算信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "修改专线商积分结算信息，结算编号：" + info.JieSuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除专线商积分结算信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <returns></returns>
        public int DeleteJiFenJieSuan(int companyId, string jiFenJieSuanId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(jiFenJieSuanId)) return 0;
            var info = GetJiFenJieSuanInfo(jiFenJieSuanId);
            if (info == null || info.Status != EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批) return -1;

            int dalRetCode = dal.DeleteJiFenJieSuan(companyId, jiFenJieSuanId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除专线商积分结算信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "删除专线商积分结算信息，结算编号：" + jiFenJieSuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取专线商积分结算信息
        /// </summary>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo GetJiFenJieSuanInfo(string jiFenJieSuanId)
        {
            if (string.IsNullOrEmpty(jiFenJieSuanId)) return null;

            return dal.GetJiFenJieSuanInfo(jiFenJieSuanId);
        }

        /// <summary>
        /// 获取专线商积分结算集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo> GetJiFenJieSuans(int companyId, string zxsId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return null;

            return dal.GetJiFenJieSuans(companyId, zxsId);
        }

        /// <summary>
        /// 设置专线商积分结算状态，返回1成功，其它失败
        /// </summary>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <param name="shouKuanStatus">收款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int SheZhiJiFenJieSuanStatus(string jiFenJieSuanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus shouKuanStatus, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(jiFenJieSuanId) || info == null || info.OperatorId < 1) return 0;

            int dalRetCode = dal.SheZhiJiFenJieSuanStatus(jiFenJieSuanId, shouKuanStatus, info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置专线商积分结算状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_专线商管理;
                log.EventMessage = "设置专线商积分结算状态，结算编号：" + jiFenJieSuanId + "，结算状态：" + shouKuanStatus + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取专线商(简)信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZxsInfo> GetZxss1(int companyId, EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo chaXun)
        {
            if (companyId < 1) return null;

            return dal.GetZxss1(companyId, chaXun);
        }

        /// <summary>
        /// 获取专线商积分发放状态
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus GetZxsJiFenStatus(string zxsId)
        {
            if (string.IsNullOrEmpty(zxsId)) return EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用;

            return dal.GetZxsJiFenStatus(zxsId);
        }

        /// <summary>
        /// 获取AJAX自动完成专线商信息信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户单位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo> GetAutocompleteZxss(int companyId, string keHuId, EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsChaXunInfo chaXun)
        {
            if (companyId < 1 || string.IsNullOrEmpty(keHuId)) return null;

            return dal.GetAutocompleteZxss(companyId, keHuId, chaXun);
        }
        #endregion
    }
}
