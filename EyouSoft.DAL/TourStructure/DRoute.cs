using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.TourStructure
{
    public class DRoute : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.TourStructure.IRoute
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DRoute()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 将线路安排转换为xml
        /// </summary>
        /// <param name="list"></param>
        /// <param name="routeId"></param>
        /// <returns></returns>
        private string CreateMRoutePlanXml(IList<EyouSoft.Model.TourStructure.MRoutePlan> list, string routeId)
        {
            if (list == null || list.Count == 0) return null;
            StringBuilder xmlDoc = new StringBuilder();
            xmlDoc.Append("<Root>");
            foreach (EyouSoft.Model.TourStructure.MRoutePlan model in list)
            {
                xmlDoc.AppendFormat("<RoutePlan RouteId=\"{0}\" Days=\"{1}\" Content=\"{2}\" FilePath=\"{3}\" />", routeId, model.Days, Utils.ReplaceXmlSpecialCharacter(model.Content), Utils.ReplaceXmlSpecialCharacter(model.FilePath));
            }
            xmlDoc.Append("</Root>");
            return xmlDoc.ToString();
        }

        /*/// <summary>
        /// 根据线路安排的xml获取集合
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private IList<EyouSoft.Model.TourStructure.MRoutePlan> GetRoutePlanByXml(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;
            IList<EyouSoft.Model.TourStructure.MRoutePlan> list = new List<EyouSoft.Model.TourStructure.MRoutePlan>();
            System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
            var xRows = Utils.GetXElements(xRoot, "row");
            foreach (var xRow in xRows)
            {
                EyouSoft.Model.TourStructure.MRoutePlan item = new EyouSoft.Model.TourStructure.MRoutePlan()
                {
                    RouteId = Utils.GetXAttributeValue(xRow, "RouteId"),
                    Days = Utils.GetInt(Utils.GetXAttributeValue(xRow, "Days")),
                    Content = Utils.GetXAttributeValue(xRow, "Content"),
                    FilePath = Utils.GetXAttributeValue(xRow, "FilePath")
                };

                list.Add(item);
            }
            return list;
        }*/

        /// <summary>
        /// 获取线路行程信息集合
        /// </summary>
        /// <param name="xianLuId">线路编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MRoutePlan> GetXingChengs(string xianLuId)
        {
            DbCommand cmd = _db.GetSqlStringCommand("SELECT A.* FROM tbl_RoutePlan AS A WHERE A.RouteId=@XianLuId ORDER BY A.Days ASC");
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, xianLuId);
            IList<EyouSoft.Model.TourStructure.MRoutePlan> items = new List<EyouSoft.Model.TourStructure.MRoutePlan>();

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MRoutePlan();
                    item.Content = rdr["Content"].ToString();
                    item.Days = rdr.GetInt32(rdr.GetOrdinal("Days"));
                    item.FilePath = rdr["FilePath"].ToString();
                    item.RouteId = xianLuId;

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 创建附件信息XML
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateFuJianXml(IList<EyouSoft.Model.PtStructure.MFuJianInfo> items)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<root>");
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    xml.AppendFormat("<info LeiXing=\"{0}\" Filepath=\"{1}\"><MiaoShu><![CDATA[{2}]]></MiaoShu></info>", item.LeiXing
                        , item.Filepath
                        , item.MiaoShu);
                }
            }
            xml.Append("</root>");
            return xml.ToString();
        }

        /// <summary>
        /// get route fujianx
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetRouteFuJians(string routeId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();

            DbCommand cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_Pt_RouteFuJian WHERE RouteId=@RouteId");
            _db.AddInParameter(cmd, "RouteId", DbType.AnsiStringFixedLength, routeId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MFuJianInfo();
                    item.Filepath = rdr["Filepath"].ToString();
                    item.FuJianId = rdr.GetInt32(rdr.GetOrdinal("FuJianId"));
                    item.LeiXing = rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.MiaoShu = rdr["MiaoShu"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region 线路产品

        /// <summary>
        /// 添加线路
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0：失败 1：成功</returns>
        public int AddRoute(EyouSoft.Model.TourStructure.MRoute model)
        {

            DbCommand cmd = this._db.GetStoredProcCommand("proc_Route_Add");
            this._db.AddInParameter(cmd, "RouteId", DbType.AnsiStringFixedLength, model.RouteId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "RouteName", DbType.String, model.RouteName);
            this._db.AddInParameter(cmd, "AreaId", DbType.Int32, model.AreaId);
            this._db.AddInParameter(cmd, "RouteHeader", DbType.String, model.RouteHeader);
            this._db.AddInParameter(cmd, "AreaDesc", DbType.String, model.AreaDesc);
            this._db.AddInParameter(cmd, "Days", DbType.Int32, model.Days);
            this._db.AddInParameter(cmd, "RoutePic", DbType.String, model.RoutePic);
            this._db.AddInParameter(cmd, "TrafficStandard", DbType.String, model.TrafficStandard);
            this._db.AddInParameter(cmd, "StayStandard", DbType.String, model.StayStandard);
            this._db.AddInParameter(cmd, "DiningStandard", DbType.String, model.DiningStandard);
            this._db.AddInParameter(cmd, "AttractionsStandard", DbType.String, model.AttractionsStandard);
            this._db.AddInParameter(cmd, "GuideStandard", DbType.String, model.GuideStandard);
            this._db.AddInParameter(cmd, "ShoppingStandard", DbType.String, model.ShoppingStandard);
            this._db.AddInParameter(cmd, "ChildStandard", DbType.String, model.ChildStandard);
            this._db.AddInParameter(cmd, "InsuranceDesc", DbType.String, model.InsuranceDesc);
            this._db.AddInParameter(cmd, "ExpenseRecommend", DbType.String, model.ExpenseRecommend);
            this._db.AddInParameter(cmd, "Tips", DbType.String, model.Tips);
            this._db.AddInParameter(cmd, "InsideInfo", DbType.String, model.InsideInfo);
            this._db.AddInParameter(cmd, "RegistrationNotes", DbType.String, model.RegistrationNotes);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "RoutePlan", DbType.Xml, this.CreateMRoutePlanXml(model.RoutePlanList, model.RouteId));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "Status", DbType.Byte, model.Status);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, model.LeiXing);
            _db.AddInParameter(cmd, "GuoQiShiJian", DbType.DateTime, model.GuoQiShiJian);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, model.ZhanDianId);
            _db.AddInParameter(cmd, "ZxlbId", DbType.Int32, model.ZxlbId);
            _db.AddInParameter(cmd, "BiaoZhun", DbType.Byte, model.BiaoZhun);
            _db.AddInParameter(cmd, "JiHeDiDian", DbType.String, model.JiHeDiDian);
            _db.AddInParameter(cmd, "JiHeShiJian", DbType.String, model.JiHeShiJian);
            _db.AddInParameter(cmd, "SongTuanXinXi", DbType.String, model.SongTuanXinXi);
            _db.AddInParameter(cmd, "MuDiDiJieTuanFangShi", DbType.String, model.MuDiDiJieTuanFangShi);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            _db.AddInParameter(cmd, "FengMian", DbType.String, model.FengMian);
            _db.AddInParameter(cmd, "FuJianXml", DbType.String, CreateFuJianXml(model.FuJians));

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));

        }


        /// <summary>
        /// 删除线路产品
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns>-1:该线路下存在订单不允许删除 0：失败 1：成功</returns>
        public int DeleteRouteById(string routeId)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_Route_Delete");
            this._db.AddInParameter(cmd, "RouteId", DbType.AnsiStringFixedLength, routeId);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 修改线路
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0：失败 1：成功</returns>
        public int UpdateRoute(EyouSoft.Model.TourStructure.MRoute model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_Route_Update");
            this._db.AddInParameter(cmd, "RouteId", DbType.AnsiStringFixedLength, model.RouteId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "RouteName", DbType.String, model.RouteName);
            this._db.AddInParameter(cmd, "AreaId", DbType.Int32, model.AreaId);
            this._db.AddInParameter(cmd, "RouteHeader", DbType.String, model.RouteHeader);
            this._db.AddInParameter(cmd, "AreaDesc", DbType.String, model.AreaDesc);
            this._db.AddInParameter(cmd, "Days", DbType.Int32, model.Days);
            this._db.AddInParameter(cmd, "RoutePic", DbType.String, model.RoutePic);
            this._db.AddInParameter(cmd, "TrafficStandard", DbType.String, model.TrafficStandard);
            this._db.AddInParameter(cmd, "StayStandard", DbType.String, model.StayStandard);
            this._db.AddInParameter(cmd, "DiningStandard", DbType.String, model.DiningStandard);
            this._db.AddInParameter(cmd, "AttractionsStandard", DbType.String, model.AttractionsStandard);
            this._db.AddInParameter(cmd, "GuideStandard", DbType.String, model.GuideStandard);
            this._db.AddInParameter(cmd, "ShoppingStandard", DbType.String, model.ShoppingStandard);
            this._db.AddInParameter(cmd, "ChildStandard", DbType.String, model.ChildStandard);
            this._db.AddInParameter(cmd, "InsuranceDesc", DbType.String, model.InsuranceDesc);
            this._db.AddInParameter(cmd, "ExpenseRecommend", DbType.String, model.ExpenseRecommend);
            this._db.AddInParameter(cmd, "Tips", DbType.String, model.Tips);
            this._db.AddInParameter(cmd, "InsideInfo", DbType.String, model.InsideInfo);
            this._db.AddInParameter(cmd, "RegistrationNotes", DbType.String, model.RegistrationNotes);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "RoutePlan", DbType.Xml, this.CreateMRoutePlanXml(model.RoutePlanList, model.RouteId));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "Status", DbType.Byte, model.Status);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, model.LeiXing);
            _db.AddInParameter(cmd, "GuoQiShiJian", DbType.DateTime, model.GuoQiShiJian);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, model.ZhanDianId);
            _db.AddInParameter(cmd, "ZxlbId", DbType.Int32, model.ZxlbId);
            _db.AddInParameter(cmd, "BiaoZhun", DbType.Byte, model.BiaoZhun);
            _db.AddInParameter(cmd, "JiHeDiDian", DbType.String, model.JiHeDiDian);
            _db.AddInParameter(cmd, "JiHeShiJian", DbType.String, model.JiHeShiJian);
            _db.AddInParameter(cmd, "SongTuanXinXi", DbType.String, model.SongTuanXinXi);
            _db.AddInParameter(cmd, "MuDiDiJieTuanFangShi", DbType.String, model.MuDiDiJieTuanFangShi);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            _db.AddInParameter(cmd, "FengMian", DbType.String, model.FengMian);
            _db.AddInParameter(cmd, "FuJianXml", DbType.String, CreateFuJianXml(model.FuJians));

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 根据编号获取model
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MRoute GetRouteById(string routeId)
        {
            EyouSoft.Model.TourStructure.MRoute model = null;
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT RouteId,CompanyId,RouteName,AreaId,RouteHeader,AreaDesc,Days,RoutePic,TrafficStandard ");
            query.Append(" ,StayStandard,DiningStandard,AttractionsStandard,GuideStandard,ShoppingStandard ");
            query.Append(" ,ChildStandard,InsuranceDesc,ExpenseRecommend,Tips,InsideInfo,RegistrationNotes,OperatorId ");
            //query.Append(" ,(SELECT RouteId,Days,[Content],FilePath ");
            //query.Append(" FROM tbl_RoutePlan where RouteId=tbl_Route.RouteId  ORDER BY tbl_Route.Days ASC for xml raw,root('Root')) as RoutePlan ");
            query.Append(" ,Status,[LeiXing],[GuoQiShiJian],[ZhanDianId],[ZxlbId],[BiaoZhun],[JiHeDiDian],[JiHeShiJian],[SongTuanXinXi],[MuDiDiJieTuanFangShi],[ZxsId],[FengMian] ");
            query.Append(" FROM tbl_Route ");
            query.AppendFormat("Where RouteId='{0}' ", routeId);

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "RouteId", DbType.String, routeId);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {

                if (dr != null && dr.Read())
                {
                    model = new EyouSoft.Model.TourStructure.MRoute()
                    {
                        RouteId = dr.GetString(dr.GetOrdinal("RouteId")),
                        RouteName = dr.GetString(dr.GetOrdinal("RouteName")),
                        CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                        AreaId = dr.GetInt32(dr.GetOrdinal("AreaId")),
                        RouteHeader = !dr.IsDBNull(dr.GetOrdinal("RouteHeader")) ? dr.GetString(dr.GetOrdinal("RouteHeader")) : null,
                        AreaDesc = !dr.IsDBNull(dr.GetOrdinal("AreaDesc")) ? dr.GetString(dr.GetOrdinal("AreaDesc")) : null,
                        Days = dr.GetInt32(dr.GetOrdinal("Days")),
                        RoutePic = !dr.IsDBNull(dr.GetOrdinal("RoutePic")) ? dr.GetString(dr.GetOrdinal("RoutePic")) : null,
                        TrafficStandard = !dr.IsDBNull(dr.GetOrdinal("TrafficStandard")) ? dr.GetString(dr.GetOrdinal("TrafficStandard")) : null,
                        StayStandard = !dr.IsDBNull(dr.GetOrdinal("StayStandard")) ? dr.GetString(dr.GetOrdinal("StayStandard")) : null,
                        DiningStandard = !dr.IsDBNull(dr.GetOrdinal("DiningStandard")) ? dr.GetString(dr.GetOrdinal("DiningStandard")) : null,
                        AttractionsStandard = !dr.IsDBNull(dr.GetOrdinal("AttractionsStandard")) ? dr.GetString(dr.GetOrdinal("AttractionsStandard")) : null,
                        GuideStandard = !dr.IsDBNull(dr.GetOrdinal("GuideStandard")) ? dr.GetString(dr.GetOrdinal("GuideStandard")) : null,
                        ShoppingStandard = !dr.IsDBNull(dr.GetOrdinal("ShoppingStandard")) ? dr.GetString(dr.GetOrdinal("ShoppingStandard")) : null,
                        ChildStandard = !dr.IsDBNull(dr.GetOrdinal("ChildStandard")) ? dr.GetString(dr.GetOrdinal("ChildStandard")) : null,
                        InsuranceDesc = !dr.IsDBNull(dr.GetOrdinal("InsuranceDesc")) ? dr.GetString(dr.GetOrdinal("InsuranceDesc")) : null,
                        ExpenseRecommend = !dr.IsDBNull(dr.GetOrdinal("ExpenseRecommend")) ? dr.GetString(dr.GetOrdinal("ExpenseRecommend")) : null,
                        Tips = !dr.IsDBNull(dr.GetOrdinal("Tips")) ? dr.GetString(dr.GetOrdinal("Tips")) : null,
                        InsideInfo = !dr.IsDBNull(dr.GetOrdinal("InsideInfo")) ? dr.GetString(dr.GetOrdinal("InsideInfo")) : null,
                        RegistrationNotes = !dr.IsDBNull(dr.GetOrdinal("RegistrationNotes")) ? dr.GetString(dr.GetOrdinal("RegistrationNotes")) : null,
                        OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetInt32(dr.GetOrdinal("OperatorId")) : 0
                    };
                    model.Status = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)dr.GetByte(dr.GetOrdinal("Status"));
                    model.LeiXing = (EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing)dr.GetByte(dr.GetOrdinal("LeiXing"));
                    if (!dr.IsDBNull(dr.GetOrdinal("GuoQiShiJian"))) model.GuoQiShiJian = dr.GetDateTime(dr.GetOrdinal("GuoQiShiJian"));
                    model.ZhanDianId = dr.GetInt32(dr.GetOrdinal("ZhanDianId"));
                    model.ZxlbId = dr.GetInt32(dr.GetOrdinal("ZxlbId"));
                    model.BiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun)dr.GetByte(dr.GetOrdinal("BiaoZhun"));
                    model.JiHeDiDian = dr["JiHeDiDian"].ToString();
                    model.JiHeShiJian = dr["JiHeShiJian"].ToString();
                    model.SongTuanXinXi = dr["SongTuanXinXi"].ToString();
                    model.MuDiDiJieTuanFangShi = dr["MuDiDiJieTuanFangShi"].ToString();
                    model.ZxsId = dr["ZxsId"].ToString();
                    model.FengMian = dr["FengMian"].ToString();
                }
            }

            if (model != null)
            {
                model.RoutePlanList = GetXingChengs(routeId);
                model.FuJians = GetRouteFuJians(routeId);
            }

            return model;
        }

        /// <summary>
        /// 获取线路产品列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="searchRoute">线路查询实体</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MPageRoute> GetRouteList(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.TourStructure.MSearchRoute searchRoute)
        {
            IList<EyouSoft.Model.TourStructure.MPageRoute> list = null;
            StringBuilder fileds = new StringBuilder();
            fileds.Append(" RouteId,RouteName ");
            fileds.Append(",(select AreaName from tbl_Area where Id=tbl_Route.AreaId) as AreaName ");
            fileds.Append(",Days,IssueTime ");
            fileds.Append(",(select ContactName from tbl_CompanyUser where Id=tbl_Route.OperatorId) as ContactName ");
            fileds.Append(",(select sum(Accounts) from tbl_TourOrder where OrderStatus in (0,1) and RouteId= tbl_Route.RouteId) as TotalAccounts ");
            fileds.Append(",Status,LeiXing,BiaoZhun");
            //fileds.AppendFormat(",(SELECT A1.MingCheng FROM tbl_Pt_ZhanDian AS A1 WHERE A1.ZhanDianId=tbl_Route.ZhanDianId) AS ZhanDianName");
            //fileds.AppendFormat(",(SELECT A1.MingCheng FROM tbl_Pt_ZhuanXianLeiBie AS A1 WHERE A1.ZxlbId=tbl_Route.ZxlbId) AS ZxlbName");
            fileds.Append(",ZxsId");


            string tableName = "tbl_Route";

            //string Identity = "RouteId";
            string OrderByString = "IssueTime desc";

            var query = new StringBuilder();
            query.AppendFormat(" CompanyId = {0} and IsDelete='{1}' ", companyId, 0);
            if (searchRoute != null)
            {
                if (searchRoute.AreaId > 0)
                {
                    query.AppendFormat("  and AreaId={0} ", searchRoute.AreaId);
                }
                if (!string.IsNullOrEmpty(searchRoute.RouteName))
                {
                    query.AppendFormat("  and RouteName like '%{0}%' ", searchRoute.RouteName);
                }
                if (searchRoute.StartDate.HasValue)
                {
                    query.AppendFormat(" AND IssueTime>='{0}' ", searchRoute.StartDate.Value);
                }
                if (searchRoute.EndDate.HasValue)
                {
                    query.AppendFormat(" AND IssueTime<='{0}' ", searchRoute.EndDate.Value.AddDays(1).AddMinutes(-1));
                }
                if (searchRoute.ZhengCeStatus.HasValue)
                {
                    query.AppendFormat(" AND Status={0} ", (int)searchRoute.ZhengCeStatus.Value);
                }
                if (searchRoute.LeiXing.HasValue)
                {
                    query.AppendFormat(" AND LeiXing={0} ", (int)searchRoute.LeiXing.Value);
                }
                if (searchRoute.BiaoZhun.HasValue)
                {
                    query.AppendFormat(" AND BiaoZhun={0} ", (int)searchRoute.BiaoZhun.Value);
                }
                if (!string.IsNullOrEmpty(searchRoute.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", searchRoute.ZxsId);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds.ToString(), query.ToString(), OrderByString, null))
            {
                if (dr != null)
                {
                    list = new List<EyouSoft.Model.TourStructure.MPageRoute>();

                    while (dr.Read())
                    {
                        EyouSoft.Model.TourStructure.MPageRoute model = new EyouSoft.Model.TourStructure.MPageRoute()
                          {
                              RouteId = dr.GetString(dr.GetOrdinal("RouteId")),
                              RouteName = dr.GetString(dr.GetOrdinal("RouteName")),
                              AreaName = !dr.IsDBNull(dr.GetOrdinal("AreaName")) ? dr.GetString(dr.GetOrdinal("AreaName")) : null,
                              Days = dr.GetInt32(dr.GetOrdinal("Days")),
                              IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                              ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : null,
                              TotalAccounts = dr.IsDBNull(dr.GetOrdinal("TotalAccounts")) ? 0 : dr.GetInt32(dr.GetOrdinal("TotalAccounts"))
                          };
                        model.Status = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)dr.GetByte(dr.GetOrdinal("Status"));
                        model.LeiXing = (EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing)dr.GetByte(dr.GetOrdinal("LeiXing"));
                        model.BiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun)dr.GetByte(dr.GetOrdinal("BiaoZhun"));
                        //model.ZhanDianName = dr["ZhanDianName"].ToString();
                        //model.ZxlbName = dr["ZxlbName"].ToString();
                        model.ZxsId=dr["ZxsId"].ToString();
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        #endregion

        #region 政策中心

        /// <summary>
        /// 添加线路政策
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0:失败 1:成功</returns>
        public int AddRouteZhengCe(EyouSoft.Model.TourStructure.MRouteZhengCe model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_RouteZhengCe_Add");
            this._db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, model.Id);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "Title", DbType.String, model.Title);
            this._db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(cmd, "OperatorId", DbType.String, model.OperatorId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, model.Status);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 删除线路政策
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>0:失败 1:成功</returns>
        public int DeleteRouteZhengCe(string id)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_RouteZhengCe_Delete");
            this._db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, id);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 修改线路政策
        /// </summary>
        /// <param name="model"></param>
        /// <returns>0:失败 1:成功</returns>
        public int UpdateRouteZhengCe(EyouSoft.Model.TourStructure.MRouteZhengCe model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_RouteZhengCe_Update");
            this._db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, model.Id);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "Title", DbType.String, model.Title);
            this._db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(cmd, "OperatorId", DbType.String, model.OperatorId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, model.Status);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 根据ID获取线路政策
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.TourStructure.MRouteZhengCe GetRouteZhengCeById(string id)
        {
            Model.TourStructure.MRouteZhengCe model = null;
            string sql = " select * from tbl_RouteZhengCe where Id = @Id ";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            this._db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, id);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (dr.Read())
                {
                    model = new Model.TourStructure.MRouteZhengCe
                    {
                        Id = dr.GetString(dr.GetOrdinal("Id")),
                        CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                        Title = !dr.IsDBNull(dr.GetOrdinal("Title")) ? dr.GetString(dr.GetOrdinal("Title")) : null,
                        FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : null,
                        OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId")),
                        IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                        Status = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)dr.GetByte(dr.GetOrdinal("Status"))
                    };
                }

            }
            return model;
        }

        /// <summary>
        /// 分页获取线路政策
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MRouteZhengCe> GetRouteZhengCeList(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TourStructure.MSeachRouteZhengCe search)
        {
            IList<EyouSoft.Model.TourStructure.MRouteZhengCe> list = null;
            string fileds = "Id,CompanyId,Title,FilePath,OperatorId,IssueTime,(select ContactName from tbl_CompanyUser where Id=tbl_RouteZhengCe.OperatorId) as OperatorName,Status,ZxsId";
            string tableName = "tbl_RouteZhengCe";

            //string Identity = "Id";
            string OrderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Title))
                {
                    query.AppendFormat(" and  Title like '%{0}%'", search.Title);
                }
                if (search.BeginDate.HasValue)
                {
                    query.AppendFormat(" and datediff(day,IssueTime,'{0}')<=0 ", search.BeginDate.Value);
                }
                if (search.EndDate.HasValue)
                {
                    query.AppendFormat(" and datediff(day,IssueTime,'{0}')>=0 ", search.EndDate.Value);
                }
                if (search.Status.HasValue)
                {
                    query.AppendFormat(" AND Status={0} ", (int)search.Status);
                }
                if (!string.IsNullOrEmpty(search.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", search.ZxsId);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), OrderByString, null))
            {
                if (dr != null)
                {
                    list = new List<EyouSoft.Model.TourStructure.MRouteZhengCe>();
                    while (dr.Read())
                    {
                        EyouSoft.Model.TourStructure.MRouteZhengCe model = new EyouSoft.Model.TourStructure.MRouteZhengCe()
                        {
                            Id = dr.GetString(dr.GetOrdinal("Id")),
                            CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                            Title = !dr.IsDBNull(dr.GetOrdinal("Title")) ? dr.GetString(dr.GetOrdinal("Title")) : null,
                            FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : null,
                            OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId")),
                            OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null,
                            Status = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)dr.GetByte(dr.GetOrdinal("Status"))
                        };
                        if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                        model.ZxsId = dr["ZxsId"].ToString();
                        list.Add(model);
                    }
                }
            }
            return list;


        }

        #endregion
    }
}
