using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.TourStructure
{
    public interface ITourOrder
    {
        /// <summary>
        /// 添加订单，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddTourOrder(EyouSoft.Model.TourStructure.MTourOrder model);
        /// <summary>
        /// 修改订单，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateTourOrder(EyouSoft.Model.TourStructure.MTourOrder model);

        IList<EyouSoft.Model.TourStructure.MRoute_TourOrder> GetTourOrderList(int companyId,int pageSize, int pageIndex, ref int recordCount, string routeId);

        IList<EyouSoft.Model.TourStructure.MTourOrder> GetTourOrderList(string tourId);

        EyouSoft.Model.TourStructure.MTourOrder GetTourOrderById(string orderId);

        /// <summary>
        /// 设置订单状态（取消、拒绝、恢复），返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="status">订单状态</param>
        /// <param name="yuanYin">原因</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="caoZuoLaiYuan">操作来源 0:系统 1:平台</param>
        /// <returns></returns>
        int SheZhiDingDanStatus(string dingDanId, EyouSoft.Model.EnumType.TourStructure.OrderStatus status, string yuanYin, int caoZuoRenId, int caoZuoLaiYuan);

        /// <summary>
        /// （平台）线路订单新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int PT_DingDan_CU(EyouSoft.Model.TourStructure.MTourOrder info);

        /// <summary>
        /// get youkes
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> GetYouKes(string dingDanId);
    }
}
