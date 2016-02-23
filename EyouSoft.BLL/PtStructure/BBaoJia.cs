//汪奇志 2014-10-21 报价信息相关
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 报价信息相关
    /// </summary>
    public class BBaoJia : BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IBaoJia dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IBaoJia>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BBaoJia() { }
        #endregion

        #region public members
        /// <summary>
        /// 报价信息新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int BaoJia_C(EyouSoft.Model.PtStructure.MBaoJiaInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.ZxsId)) return 0;
            info.IssueTime = DateTime.Now;
            info.BaoJiaId = Guid.NewGuid().ToString();

            int dalRetCode = dal.BaoJia_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增报价信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_最新报价;
                log.EventMessage = "新增报价信息，报价编号：" + info.BaoJiaId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 报价信息修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int BaoJia_U(EyouSoft.Model.PtStructure.MBaoJiaInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.ZxsId)||string.IsNullOrEmpty(info.BaoJiaId)) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.BaoJia_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改报价信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_最新报价;
                log.EventMessage = "修改报价信息，报价编号：" + info.BaoJiaId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 删除报价信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        public int BaoJia_D(int companyId, string zxsId, string baoJiaId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || string.IsNullOrEmpty(baoJiaId)) return 0;

            int dalRetCode = dal.BaoJia_D(companyId, zxsId, baoJiaId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除报价信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_最新报价;
                log.EventMessage = "删除报价信息，报价编号：" + baoJiaId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取报价信息
        /// </summary>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MBaoJiaInfo GetInfo(string baoJiaId)
        {
            if (string.IsNullOrEmpty(baoJiaId)) return null;

            return dal.GetInfo(baoJiaId);
        }

        /// <summary>
        /// 获取报价集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MBaoJiaInfo> GetBaoJias(int companyId, string zxsId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MBaoJiaChaXunInfo chaXun)
        {
            if (companyId < 1 ||string.IsNullOrEmpty(zxsId)|| !ValidPaging(pageSize, pageIndex)) return null;
            return dal.GetBaoJias(companyId, zxsId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 获取最新报价信息
        /// </summary>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MBaoJiaInfo GetZuiXinBaoJiaInfo(string zxsId, int zxlbId)
        {
            if (string.IsNullOrEmpty(zxsId) || zxlbId < 1) return null;

            return dal.GetZuiXinBaoJiaInfo(zxsId, zxlbId);
        }
        #endregion
    }
}
