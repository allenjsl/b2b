using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PlanStructure
{
    public interface IPlanDiJie
    {
        int AddPlanDiJie(EyouSoft.Model.PlanStructure.MPlanDiJie model);

        int DeletePlanDiJie(string planId);

        int UpdatePlanDiJie(EyouSoft.Model.PlanStructure.MPlanDiJie model);

        EyouSoft.Model.PlanStructure.MPlanDiJie GetPlanDiJieById(string planId);

        IList<EyouSoft.Model.PlanStructure.MPlan_DiJie> GetPlanDiJieList(string kongWeiId);        

        IList<EyouSoft.Model.PlanStructure.MDiJieOrder> GetDiJieOrder(string PlanId);
        /// <summary>
        /// 设置地接安排导游，返回1成功，其它失败
        /// </summary>
        /// <param name="anPaiId">地接安排编号</param>
        /// <param name="daoYouId">导游编号</param>
        /// <returns></returns>
        int SetDaoYou(string anPaiId, int daoYouId);

        /// <summary>
        /// 地接平台-获取地接安排信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiInfo> GYS_GetDiJieAnPais(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiChaXunInfo chaXun,out object[] heJi);

        /// <summary>
        /// 地接平台-地接社设置计划信息
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int GYS_DiJieJiHua_U(EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiJiHuaInfo info);
        /// <summary>
        /// 地接平台-地接社设置计划状态
        /// </summary>
        /// <param name="anPaiId">安排编号</param>
        /// <param name="status">确认状态</param>
        /// <param name="gysId">供应商主体编号</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="caoZuoTime">操作时间</param>
        /// <returns></returns>
        int GYS_DiJieSheZhiQueRenStatus(string anPaiId, EyouSoft.Model.EnumType.TourStructure.QueRenStatus status, string gysId, int caoZuoRenId, DateTime caoZuoTime);

        /// <summary>
        /// 设置地接安排导游，返回1成功，其它失败
        /// </summary>
        /// <param name="anPaiId">地接安排编号</param>
        /// <param name="daoYouName">导游</param>
        /// <returns></returns>
        int SetDaoYou(string anPaiId, string daoYouName);
    }
}
