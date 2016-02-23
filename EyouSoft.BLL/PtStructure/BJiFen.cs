using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 积分相关
    /// </summary>
    public class BJiFen : BLLBase
    {
        private readonly EyouSoft.IDAL.PtStructure.IJiFen dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IJiFen>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJiFen() { }
        #endregion

        #region public members
        /// <summary>
        /// 积分商品新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertShangPin(EyouSoft.Model.PtStructure.MJiFenShangPinInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || info.JiFen < 1) return 0;

            info.ShangPinId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.ShangPin_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增积分兑换商品";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_积分兑换商品管理;
                log.EventMessage = "新增积分兑换商品，商品编号：" + info.ShangPinId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 积分商品修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateShangPin(EyouSoft.Model.PtStructure.MJiFenShangPinInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || info.JiFen < 1||string.IsNullOrEmpty(info.ShangPinId)) return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.ShangPin_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改积分兑换商品";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_积分兑换商品管理;
                log.EventMessage = "修改积分兑换商品，商品编号：" + info.ShangPinId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 删除积分商品，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="shangPinId">商品编号</param>
        /// <returns></returns>
        public int DeleteShangPin(int companyId, string shangPinId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(shangPinId)) return 0;
            int dalRetCode = dal.DeleteShangPin(companyId, shangPinId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除积分兑换商品";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_积分兑换商品管理;
                log.EventMessage = "删除积分兑换商品，商品编号：" + shangPinId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取积分商品信息
        /// </summary>
        /// <param name="shangPinId">商品编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJiFenShangPinInfo GetShangPinInfo(string shangPinId)
        {
            if (string.IsNullOrEmpty(shangPinId)) return null;

            return dal.GetShangPinInfo(shangPinId);
        }

        /// <summary>
        /// 获取积分商品集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录灵敏</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJiFenShangPinInfo> GetShangPins(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenShangPinChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetShangPins(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// (限平台)积分订单新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertDingDan(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.XiaDanRenId < 1 
                || info.LatestOperatorId < 1 || info.ShuLiang < 1 || info.JiFen1 < 1 
                || info.JiFen2 < 1 || string.IsNullOrEmpty(info.ShangPinId)) return 0;

            info.DingDanId = Guid.NewGuid().ToString();
            info.IssueTime = info.LatestTime = DateTime.Now;
            info.JiFen2 = info.ShuLiang * info.JiFen1;
            info.Status = EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.未确认;

            int dalRetCode = dal.DingDan_CU(info);
            return dalRetCode;
        }

        /// <summary>
        /// (限平台)积分订单修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateDingDan(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.XiaDanRenId < 1
                || info.LatestOperatorId < 1 || info.ShuLiang < 1 || info.JiFen1 < 1
                || info.JiFen2 < 1 || string.IsNullOrEmpty(info.ShangPinId) || string.IsNullOrEmpty(info.DingDanId)) return 0;

            info.IssueTime = info.LatestTime = DateTime.Now;
            info.JiFen2 = info.ShuLiang * info.JiFen1;

            int dalRetCode = dal.DingDan_CU(info);
            return dalRetCode;
        }

        /// <summary>
        /// (限系统)积分订单修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateDingDan1(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.XiaDanRenId < 1
                || info.LatestOperatorId < 1 || info.ShuLiang < 1 || info.JiFen1 < 1
                || info.JiFen2 < 1 || string.IsNullOrEmpty(info.ShangPinId) || string.IsNullOrEmpty(info.DingDanId)) return 0;

            info.IssueTime = info.LatestTime = DateTime.Now;
            info.JiFen2 = info.ShuLiang * info.JiFen1;

            int dalRetCode = dal.DingDan_CU(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "修改积分兑换订单";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_积分兑换订单管理;
                log.EventMessage = "修改积分兑换订单，订单编号：" + info.DingDanId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取积分订单信息
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJiFenDingDanInfo GetDingDanInfo(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return null;

            return dal.GetDingDanInfo(dingDanId);
        }

        /// <summary>
        /// 获取积分订单集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJiFenDingDanInfo> GetDingDans(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenDingDanChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetDingDans(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.DingDanId) || info.LatestOperatorId < 1) return 0;
            info.LatestTime = DateTime.Now;
            info.FuKuanStatus = EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批;
            int dalRetCode = dal.SheZhiDingDanStatus(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置积分兑换订单状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_积分兑换订单管理;
                log.EventMessage = "设置积分兑换订单状态，订单编号：" + info.DingDanId + "，订单状态：" + info.Status + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 设置订单付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="fuKuanStatus">付款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int SheZhiDingDanFuKuanStatus(string dingDanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus fuKuanStatus, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            if (string.IsNullOrEmpty(dingDanId)||info.OperatorId<1) return 0;

            int dalRetCode = dal.SheZhiDingDanFuKuanStatus(dingDanId, fuKuanStatus, info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置积分兑换订单付款状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_积分兑换订单管理;
                log.EventMessage = "设置积分兑换订单付款状态，订单编号：" + dingDanId + "，付款状态：" + fuKuanStatus + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取用户积分明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:积分合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MYongHuJiFenMingXiInfo> GetYongHuJiFenMingXis(int companyId, int yongHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MYongHuJiFenMingXiChaXunInfo chaXun,out object[] heJi)
        {
            heJi = new object[] { 0 };
            if (companyId < 1 || yongHuId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetYongHuJiFenMingXis(companyId, yongHuId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
        }

        /// <summary>
        /// （平台）设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int PT_SheZhiDingDanStatus(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.DingDanId) || info.LatestOperatorId < 1) return 0;
            info.LatestTime = DateTime.Now;
            info.FuKuanStatus = EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批;
            int dalRetCode = dal.SheZhiDingDanStatus(info);

            return dalRetCode;
        }
        #endregion
    }
}
