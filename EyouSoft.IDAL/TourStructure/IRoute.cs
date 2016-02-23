using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.TourStructure;

namespace EyouSoft.IDAL.TourStructure
{
    public interface IRoute
    {
        #region 线路产品

        int AddRoute(MRoute model);

        int DeleteRouteById(string routeId);

        int UpdateRoute(MRoute model);

        MRoute GetRouteById(string routeId);

        IList<MPageRoute> GetRouteList(int companyId, int pageSize, int pageIndex, ref int recordCount, MSearchRoute model);

        #endregion

        #region 政策中心

        int AddRouteZhengCe(MRouteZhengCe model);

        int DeleteRouteZhengCe(string id);

        int UpdateRouteZhengCe(MRouteZhengCe model);

        MRouteZhengCe GetRouteZhengCeById(string id);

        IList<MRouteZhengCe> GetRouteZhengCeList(int companyId, int pageSize, int pageIndex, ref int recordCount, MSeachRouteZhengCe search);

        #endregion
      
    }
}
