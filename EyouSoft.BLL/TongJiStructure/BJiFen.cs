using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TongJiStructure
{
    /// <summary>
    /// 统计分析-积分相关业务逻辑
    /// </summary>
    public class BJiFen : BLLBase
    {
        private readonly EyouSoft.IDAL.TongJiStructure.IJiFen dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TongJiStructure.IJiFen>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJiFen() { }
        #endregion

        #region public members
        /// <summary>
        /// 获取积分发放明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:int:实际发放积分数]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiInfo> GetJiFenFaFangMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0 };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex) || chaXun == null || string.IsNullOrEmpty(chaXun.ZxsId)) return null;

            return dal.GetJiFenFaFangMingXis(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
        }

        /// <summary>
        /// 获取积分发放结算明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:int:有效积分合计][1:int:冻结积分合计][2:int:取消积分合计][3:int:结算积分合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiInfo> GetJiFenFaFangJieSuanMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0 };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetJiFenFaFangJieSuanMingXis(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
        }

        /// <summary>
        /// 获取积分收付款明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:decimal:借方合计][1:decimal:贷方合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiInfo> GetJiFenShouFuKuanMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetJiFenShouFuKuanMingXis(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
        }


        /// <summary>
        /// 积分结算收款登记，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertJiFenJieSuanShouKuan(EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo info)
        {
            if (info == null || info.CompanyId < 1 || string.IsNullOrEmpty(info.ZxsId) || info.OperatorId < 1 || info.JinE <= 0) return 0;

            info.JieSuanId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            info.Status = EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批;

            int dalRetCode = dal.JiFenJieSuanShouKuan_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增积分结算收款";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.统计分析_积分发放结算统计表;
                log.EventMessage = "新增积分结算收款，结算编号：" + info.JieSuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 积分结算收款修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateJiFenJieSuanShouKuan(EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo info)
        {
            if (info == null || info.CompanyId < 1 || string.IsNullOrEmpty(info.ZxsId) || info.OperatorId < 1 || info.JinE <= 0 || string.IsNullOrEmpty(info.JieSuanId)) return 0;

            int dalRetCode = dal.JiFenJieSuanShouKuan_CU(info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改积分结算收款";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.统计分析_积分发放结算统计表;
                log.EventMessage = "修改积分结算收款，结算编号：" + info.JieSuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 积分结算收款删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="jieSuanId">结算编号</param>
        /// <returns></returns>
        public int DeleteJiFenJieSuanShouKuan(int companyId, string zxsId, string jieSuanId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || string.IsNullOrEmpty(jieSuanId)) return 0;

            int dalRetCode = dal.JiFenJieSuanShouKuan_D(companyId, zxsId, jieSuanId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除积分结算收款";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.统计分析_积分发放结算统计表;
                log.EventMessage = "删除积分结算收款，结算编号：" + jieSuanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 设置积分结算收款状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="jieSuanId">结算编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">操作人信息</param>
        /// <returns></returns>
        public int SheZhiJiFenJieSuanShouKuanStatus(int companyId, string zxsId, string jieSuanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus status, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || string.IsNullOrEmpty(jieSuanId) || info == null || info.OperatorId < 1) return 0;

            int dalRetCode = dal.SheZhiJiFenJieSuanShouKuanStatus(companyId, zxsId, jieSuanId, status, info);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置积分结算收款状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.统计分析_积分收付款明细表;
                log.EventMessage = "设置积分结算收款状态，结算编号：" + jieSuanId + "，状态：" + status + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取积分结算收款集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo> GetJiFenJieSuanShouKuans(int companyId, string zxsId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return null;

            return dal.GetJiFenJieSuanShouKuans(companyId, zxsId);
        }

        /// <summary>
        /// 获取专线商结算信息[0:int:有效积分][1:int:结算积分][2:decimal:结算已审批金额][3:decimal:结算未审批金额]
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public object[] GetZxsJieSuanXinXi(int companyId, string zxsId)
        {
            object[] obj = new object[] { 0, 0, 0M, 0M };
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return obj;

            return dal.GetZxsJieSuanXinXi(companyId, zxsId);
        }

        /// <summary>
        /// 获取客户用户积分统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:可用积分][1:int:冻结积分][0:int:已使用积分]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenInfo> GetKeHuYongHuJiFens(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0 };

            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetKeHuYongHuJiFens(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
        }
        #endregion
    }
}
