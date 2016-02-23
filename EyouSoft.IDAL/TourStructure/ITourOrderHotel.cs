using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.TourStructure
{
    public interface ITourOrderHotel
    {
        /// <summary>
        /// (管理系统)添加代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddTourOrderHotel(EyouSoft.Model.TourStructure.MTourOrderHotel model);
        /// <summary>
        /// 删除代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        int DeleteTourOrderHotel(string kongWeiId);
        /// <summary>
        /// (管理系统)修改代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateTourOrderHotel(EyouSoft.Model.TourStructure.MTourOrderHotel model);

        EyouSoft.Model.TourStructure.MTourOrderHotel GetTourOrderHotel(string kongWeiId);

        IList<EyouSoft.Model.TourStructure.MTour_OrderHotel> GetTourOrderHotel(
            int companyId, 
            int pageSize, 
            int pageIndex, 
            ref int recordCount, 
            EyouSoft.Model.TourStructure.MSearchTourOrderHotel search);
    }
}
