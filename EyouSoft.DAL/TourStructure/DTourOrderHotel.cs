using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.TourStructure
{
    public class DTourOrderHotel : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.TourStructure.ITourOrderHotel
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetPlanHotelMxs = "SELECT * FROM [tbl_PlanHotelMX] WHERE [AnPaiId]=@AnPaiId AND [IsDelete]='0' ORDER BY [IdentityId] ASC";
        
        #endregion

        #region 初始化db

        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DTourOrderHotel()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region privatem members
        /// <summary>
        /// create youke xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateYouKeXml(IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append(" <info ");
                s.AppendFormat(" TravellerId=\"{0}\" ", item.TravellerId);
                s.AppendFormat(" TravellerType=\"{0}\" ", (int)item.TravellerType);
                s.AppendFormat(" CardType=\"{0}\" ", (int)item.CardType);
                s.AppendFormat(" Gender=\"{0}\" ", (int)item.Sex);
                s.AppendFormat(" Status=\"{0}\" ", (int)item.TravellerStatus);
                s.AppendFormat(" TicketType=\"{0}\" ", (int)item.TicketType);
                s.Append(" > ");

                s.AppendFormat("<TravellerName><![CDATA[{0}]]></TravellerName>", item.TravellerName);
                s.AppendFormat("<CardNumber><![CDATA[{0}]]></CardNumber>", item.CardNumber);
                s.AppendFormat("<Contact><![CDATA[{0}]]></Contact>", item.Contact);

                s.Append("</info>");
            }
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// create jiudiananpai xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateJiuDianAnPaiXml(IList<EyouSoft.Model.TourStructure.MTourOrderHotelPlan> items)
        {
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();

            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append(" <info ");
                s.AppendFormat(" Id=\"{0}\" ", item.Id);
                if (item.CheckInDate.HasValue) s.AppendFormat(" CheckInDate=\"{0}\" ", item.CheckInDate.Value);
                if (item.CheckOutDate.HasValue) s.AppendFormat(" CheckOutDate=\"{0}\" ", item.CheckOutDate.Value);
                s.AppendFormat(" GYSId=\"{0}\" ", item.GYSId);
                s.AppendFormat(" SideOperatorId=\"{0}\" ", item.SideOperatorId);
                s.AppendFormat(" SettleAmount=\"{0}\" ", item.SettleAmount);
                s.Append(" > ");

                s.AppendFormat("<Room><![CDATA[{0}]]></Room>", item.Room);
                s.AppendFormat("<Remark><![CDATA[{0}]]></Remark>", item.Remark);
                s.AppendFormat("<RoomNights><![CDATA[{0}]]></RoomNights>", item.RoomNights);
                s.AppendFormat("<HumorWas><![CDATA[{0}]]></HumorWas>", item.HumorWas);
                s.AppendFormat("<HotelName><![CDATA[{0}]]></HotelName>", item.HotelName);
                s.AppendFormat("<SettleDetail><![CDATA[{0}]]></SettleDetail>", item.SettleDetail);
                s.AppendFormat("<PlanRemark><![CDATA[{0}]]></PlanRemark>", item.PlanRemark);
                s.AppendFormat("<PlanDetail><![CDATA[{0}]]></PlanDetail>", item.PlanDetail);
                s.AppendFormat("<FileInfo><![CDATA[{0}]]></FileInfo>", item.FileInfo);

                s.Append("</info>");
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 创建酒店安排明细信息XML
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        string CreateJiuDianAnPaiMxXml(EyouSoft.Model.TourStructure.MTourOrderHotel info)
        {
            StringBuilder s = new StringBuilder();
            if (info == null
                || info.TourOrderHotelPlanList == null
                || info.TourOrderHotelPlanList.Count == 0) return string.Empty;

            s.Append("<root>");
            foreach (var item in info.TourOrderHotelPlanList)
            {
                if (item.AnPaiMxs != null && item.AnPaiMxs.Count > 0)
                {
                    foreach (var item1 in item.AnPaiMxs)
                    {
                        s.AppendFormat("<info KongWeiId=\"{0}\" ", info.KongWeiId);
                        s.AppendFormat(" OrderId=\"{0}\" ", info.OrderId);
                        s.AppendFormat(" AnPaiId=\"{0}\" ", item.Id);
                        if (!string.IsNullOrEmpty(item1.RuZhuTime)) s.AppendFormat(" RuZhuTime=\"{0}\" ", item1.RuZhuTime);
                        if (!string.IsNullOrEmpty(item1.TuiFangTime)) s.AppendFormat(" TuiFangTime=\"{0}\" ", item1.TuiFangTime);
                        s.Append(" >");

                        s.AppendFormat("<FangXing><![CDATA[{0}]]></FangXing>", item1.FangXing);
                        s.AppendFormat("<YaoQiuBeiZhu><![CDATA[{0}]]></YaoQiuBeiZhu>", item1.YaoQiuBeiZhu);
                        s.AppendFormat("<JianYe><![CDATA[{0}]]></JianYe>", item1.JianYe);
                        s.AppendFormat("<QuFangFangShi><![CDATA[{0}]]></QuFangFangShi>", item1.QuFangFangShi);
                        s.AppendFormat("<JiuDianName><![CDATA[{0}]]></JiuDianName>", item1.JiuDianName);

                        s.Append("</info>");
                    }
                }
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 获取酒店安排明细信息集合
        /// </summary>
        /// <param name="anPaiId">安排编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MPlanHotelMxInfo> GetJiuDianAnPaiMxs(string anPaiId)
        {
            IList<EyouSoft.Model.TourStructure.MPlanHotelMxInfo> items = new List<EyouSoft.Model.TourStructure.MPlanHotelMxInfo>();

            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetPlanHotelMxs);
            _db.AddInParameter(cmd, "AnPaiId", DbType.AnsiStringFixedLength, anPaiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MPlanHotelMxInfo();
                    item.AnPaiId = anPaiId;
                    item.FangXing = rdr["FangXing"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.JianYe = rdr["JianYe"].ToString();
                    item.JiuDianName = rdr["JiuDianName"].ToString();
                    item.KognWeiId = rdr.GetString(rdr.GetOrdinal("KongWeiId"));
                    item.OrderId = rdr.GetString(rdr.GetOrdinal("OrderId"));
                    item.QuFangFangShi = rdr["QuFangFangShi"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("RuZhuTime"))) item.RuZhuTime = rdr.GetDateTime(rdr.GetOrdinal("RuZhuTime")).ToString("yyyy-MM-dd");
                    if (!rdr.IsDBNull(rdr.GetOrdinal("TuiFangTime"))) item.TuiFangTime = rdr.GetDateTime(rdr.GetOrdinal("TuiFangTime")).ToString("yyyy-MM-dd");
                    item.YaoQiuBeiZhu = rdr["YaoQiuBeiZhu"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// get youkes
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> GetYouKes(string dingDanId)
        {
            IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> items = new List<EyouSoft.Model.TourStructure.MTourOrderTraveller>();
            string sql = "SELECT * FROM tbl_TourOrderTraveller WHERE OrderId=@DingDanId ORDER BY SortId ASC";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MTourOrderTraveller();
                    item.CardNumber = rdr["CardNumber"].ToString();
                    item.CardType = (EyouSoft.Model.EnumType.TourStructure.CardType)rdr.GetByte(rdr.GetOrdinal("CardType"));
                    item.Contact = rdr["Contact"].ToString();
                    item.OrderId = dingDanId;
                    item.Sex = (EyouSoft.Model.EnumType.CompanyStructure.Sex)rdr.GetByte(rdr.GetOrdinal("Gender"));
                    item.TicketType = (EyouSoft.Model.EnumType.TourStructure.TicketType)rdr.GetByte(rdr.GetOrdinal("TicketType"));
                    item.TourId = rdr["TourId"].ToString();
                    item.TravellerId = rdr["TravellerId"].ToString();
                    item.TravellerName = rdr["TravellerName"].ToString();
                    item.TravellerStatus = (EyouSoft.Model.EnumType.TourStructure.TravellerStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.TravellerType = (EyouSoft.Model.EnumType.TourStructure.TravellerType)rdr.GetByte(rdr.GetOrdinal("TravellerType"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// get jiudiananpais
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MTourOrderHotelPlan> GetJiuDianAnPais(string dingDanId)
        {
            IList<EyouSoft.Model.TourStructure.MTourOrderHotelPlan> items = new List<EyouSoft.Model.TourStructure.MTourOrderHotelPlan>();
            string sql = "SELECT A.*,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName,(SELECT COUNT(*) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id) AS ShouZhiDengJiShuLiang FROM tbl_TourOrderHotelPlan AS A WHERE A.OrderId=@DingDanId AND A.IsDelete='0' ORDER BY A.SortId ASC";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MTourOrderHotelPlan();
                    item.AnPaiMxs = null;
                    if (!rdr.IsDBNull(rdr.GetOrdinal("CheckInDate"))) item.CheckInDate = rdr.GetDateTime(rdr.GetOrdinal("CheckInDate"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("CheckOutDate"))) item.CheckOutDate = rdr.GetDateTime(rdr.GetOrdinal("CheckOutDate"));
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.FileInfo = rdr["FileInfo"].ToString();
                    item.GYSId = rdr["GYSId"].ToString();
                    item.GYSName = rdr["GysName"].ToString();
                    item.HotelName = rdr["HotelName"].ToString();
                    item.HumorWas = rdr["HumorWas"].ToString();
                    item.Id = rdr["Id"].ToString();
                    item.IsShouZhi = rdr.GetInt32(rdr.GetOrdinal("ShouZhiDengJiShuLiang")) > 0;
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.OrderId = dingDanId;
                    item.PlanDetail = rdr["PlanDetail"].ToString();
                    item.PlanRemark = rdr["PlanRemark"].ToString();
                    item.Remark = rdr["Remark"].ToString();
                    item.Room = rdr["Room"].ToString();
                    item.RoomNights = rdr["RoomNights"].ToString();
                    item.SettleAmount = rdr.GetDecimal(rdr.GetOrdinal("SettleAmount"));
                    item.SettleDetail = rdr["SettleDetail"].ToString();
                    item.SideOperatorId = rdr.GetInt32(rdr.GetOrdinal("SideOperatorId"));
                    item.TourId = rdr["TourId"].ToString();
                    items.Add(item);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.AnPaiMxs = GetJiuDianAnPaiMxs(item.Id);
                }
            }

            return items;
        }
        #endregion

        #region ITourOrderHotel 成员
        /// <summary>
        /// (管理系统)添加代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTourOrderHotel(EyouSoft.Model.TourStructure.MTourOrderHotel model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_TourOrderHotel_Add");
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "BusinessType", DbType.Byte, (int)EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店);
            this._db.AddInParameter(cmd, "BusinessNature", DbType.Byte, (int)EyouSoft.Model.EnumType.TourStructure.BusinessNature.组团);
            this._db.AddInParameter(cmd, "OrderId", DbType.String, model.OrderId);
            this._db.AddInParameter(cmd, "QuDate", DbType.Date, model.QuDate.Value);
            this._db.AddInParameter(cmd, "Adults", DbType.Int32, model.Adults);
            this._db.AddInParameter(cmd, "Childs", DbType.Int32, model.Childs);
            this._db.AddInParameter(cmd, "BuyCompanyId", DbType.AnsiStringFixedLength, model.BuyCompanyId);
            this._db.AddInParameter(cmd, "BuyOperatorId", DbType.Int32, model.BuyOperatorId);
            this._db.AddInParameter(cmd, "PriceDetials", DbType.String, model.PriceDetials);
            this._db.AddInParameter(cmd, "SumPrice", DbType.Decimal, model.SumPrice);
            this._db.AddInParameter(cmd, "PriceRemark", DbType.String, model.PriceRemark);
            this._db.AddInParameter(cmd, "SpecialAskRemark", DbType.String, model.SpecialAskRemark);
            this._db.AddInParameter(cmd, "OperatoRemark", DbType.String, model.OperatoRemark);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "YouKeXml", DbType.String, CreateYouKeXml(model.TourOrderTravellerList));
            this._db.AddInParameter(cmd, "JiuDianAnPaiXml", DbType.String, CreateJiuDianAnPaiXml(model.TourOrderHotelPlanList));          
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "PlanHotelMxXml", DbType.String, CreateJiuDianAnPaiMxXml(model));
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            _db.AddInParameter(cmd, "LatestOperatorId", DbType.Int32, model.LatestOperatorId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, model.LatestTime);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 删除代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public int DeleteTourOrderHotel(string kongWeiId)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_TourOrderHotel_Delete");
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// (管理系统)修改代订酒店，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateTourOrderHotel(EyouSoft.Model.TourStructure.MTourOrderHotel model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_TourOrderHotel_Update");
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "OrderId", DbType.String, model.OrderId);
            this._db.AddInParameter(cmd, "QuDate", DbType.Date, model.QuDate.Value);
            this._db.AddInParameter(cmd, "Adults", DbType.Int32, model.Adults);
            this._db.AddInParameter(cmd, "Childs", DbType.Int32, model.Childs);
            this._db.AddInParameter(cmd, "BuyCompanyId", DbType.AnsiStringFixedLength, model.BuyCompanyId);
            this._db.AddInParameter(cmd, "BuyOperatorId", DbType.Int32, model.BuyOperatorId);
            this._db.AddInParameter(cmd, "PriceDetials", DbType.String, model.PriceDetials);
            this._db.AddInParameter(cmd, "SumPrice", DbType.Decimal, model.SumPrice);
            this._db.AddInParameter(cmd, "PriceRemark", DbType.String, model.PriceRemark);
            this._db.AddInParameter(cmd, "SpecialAskRemark", DbType.String, model.SpecialAskRemark);
            this._db.AddInParameter(cmd, "OperatoRemark", DbType.String, model.OperatoRemark);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "YouKeXml", DbType.String, CreateYouKeXml(model.TourOrderTravellerList));
            this._db.AddInParameter(cmd, "JiuDianAnPaiXml", DbType.String, CreateJiuDianAnPaiXml(model.TourOrderHotelPlanList));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "PlanHotelMxXml", DbType.String, CreateJiuDianAnPaiMxXml(model));
            _db.AddInParameter(cmd, "LatestOperatorId", DbType.Int32, model.LatestOperatorId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, model.LatestTime);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 获取代订酒店的实体
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MTourOrderHotel GetTourOrderHotel(string kongWeiId)
        {
            EyouSoft.Model.TourStructure.MTourOrderHotel model = null;
            StringBuilder query = new StringBuilder();
            query.Append("SELECT QuDate,OrderId,OrderCode,CompanyId,TourId,BusinessType,Adults,Childs");
            query.Append(",Accounts,BuyCompanyId,BuyOperatorId,PriceDetials,SumPrice");
            query.Append(",PriceRemark,OperatoRemark,OperatorId");
            query.Append(" ,SpecialAskRemark,BuyCompanyName,BuyOperatorName ");
            query.Append(" ,IssueTime,ZxsId ");
            query.Append("  FROM view_TourOrderHotel");
            query.Append(" Where TourId=@TourId");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "TourId", DbType.AnsiStringFixedLength, kongWeiId);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.TourStructure.MTourOrderHotel
                    {
                        OrderId =dr["OrderId"].ToString(),
                        OrderCode = dr["OrderCode"].ToString(),
                        CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                        KongWeiId = dr["TourId"].ToString(),
                        Adults = dr.GetInt32(dr.GetOrdinal("Adults")),
                        Childs = dr.GetInt32(dr.GetOrdinal("Childs")),
                        BuyCompanyId = dr["BuyCompanyId"].ToString(),
                        BuyOperatorId = dr.GetInt32(dr.GetOrdinal("BuyOperatorId")),
                        PriceDetials = dr["PriceDetials"].ToString(),
                        SumPrice = dr.GetDecimal(dr.GetOrdinal("SumPrice")),
                        PriceRemark = dr["PriceRemark"].ToString(),
                        OperatoRemark = dr["OperatoRemark"].ToString(),
                        SpecialAskRemark = dr["SpecialAskRemark"].ToString(),
                        OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"))
                    };
                    if (!dr.IsDBNull(dr.GetOrdinal("BuyCompanyName"))) model.BuyCompanyName = dr.GetString(dr.GetOrdinal("BuyCompanyName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("BuyOperatorName"))) model.BuyOperator = dr.GetString(dr.GetOrdinal("BuyOperatorName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("QuDate"))) model.QuDate = dr.GetDateTime(dr.GetOrdinal("QuDate"));
                    
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.ZxsId = dr["ZxsId"].ToString();
                }
            }

            if (model != null)
            {
                model.TourOrderHotelPlanList = GetJiuDianAnPais(model.OrderId);
                model.TourOrderTravellerList = GetYouKes(model.OrderId);
            }

            return model;
        }

        /// <summary>
        /// 代订酒店分页显示信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MTour_OrderHotel> GetTourOrderHotel(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            EyouSoft.Model.TourStructure.MSearchTourOrderHotel search)
        {
            IList<EyouSoft.Model.TourStructure.MTour_OrderHotel> list = new List<EyouSoft.Model.TourStructure.MTour_OrderHotel>();


            StringBuilder fields = new StringBuilder();
            fields.Append("OrderId,OrderCode,TourId,");
            fields.Append("(select Name from tbl_Customer where Id=tbl_TourOrder.BuyCompanyId) as BuyCompanyName,");
            fields.Append("(select Name from tbl_CustomerContactInfo where Id = tbl_TourOrder.BuyOperatorId) as BuyOperatorName,");
            fields.Append("(select top 1 HotelName from tbl_TourOrderHotelPlan where OrderId=tbl_TourOrder.OrderId order by sortId asc )as HotelName,");
            fields.Append("(select ContactName from tbl_CompanyUser where Id=tbl_TourOrder.OperatorId)as OperatorName");
            fields.Append(",(SELECT KongWeiZhuangTai FROM tbl_KongWei AS A WHERE A.KongWeiId=tbl_TourOrder.TourId) AS KongWeiZhuangTai");
            fields.Append(",ZxsId");
            string tableName = "tbl_TourOrder";
            string orderString = " IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" CompanyId={0} and BusinessType={1} and IsDelete='{2}' ", companyId, (int)EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店, 0);

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.OrderCode))
                {
                    query.AppendFormat(" and OrderCode like '%{0}%' ", search.OrderCode);
                }

                if (!string.IsNullOrEmpty(search.HotelName)||!string.IsNullOrEmpty(search.JiaoYiHao))
                {
                    query.Append(" AND EXISTS( SELECT 1 FROM tbl_TourOrderHotelPlan AS B WHERE B.OrderId=tbl_TourOrder.OrderId ");
                    if (!string.IsNullOrEmpty(search.HotelName))
                    {
                        query.AppendFormat(" AND HotelName LIKE '%{0}%' ", search.HotelName);
                    }
                    if (!string.IsNullOrEmpty(search.JiaoYiHao))
                    {
                        query.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", search.JiaoYiHao);
                    }
                    query.Append(" ) ");
                }

                if (!string.IsNullOrEmpty(search.TravellerName))
                {
                    query.AppendFormat("and exists(select 1 from tbl_TourOrderTraveller where OrderId=tbl_TourOrder.OrderId and TravellerName like '%{0}%')", search.TravellerName);
                }

                if (search.LBeginDate.HasValue || search.LEndDate.HasValue || search.KongWeiZhuangTai.HasValue)
                {
                    query.Append(" AND EXISTS(SELECT 1 FROM tbl_KongWei AS A WHERE A.KongWeiId=tbl_TourOrder.TourId ");
                    if (search.LBeginDate.HasValue)
                    {
                        query.AppendFormat(" AND A.QuDate>'{0}'", search.LBeginDate.Value.AddDays(-1));
                    }
                    if (search.LEndDate.HasValue)
                    {
                        query.AppendFormat(" AND A.QuDate<'{0}'", search.LEndDate.Value.AddDays(1));
                    }
                    if (search.KongWeiZhuangTai.HasValue)
                    {
                        query.AppendFormat(" AND A.KongWeiZhuangTai={0}", (int)search.KongWeiZhuangTai.Value);
                    }
                    query.Append(")");
                }

                if (!string.IsNullOrEmpty(search.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", search.ZxsId);
                }
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.TourStructure.MTour_OrderHotel model = new EyouSoft.Model.TourStructure.MTour_OrderHotel
                    {
                        OrderId = dr.GetString(dr.GetOrdinal("OrderId")),
                        BuyCompanyName = dr["BuyCompanyName"].ToString(),
                        BuyOperatorName = dr["BuyOperatorName"].ToString(),
                        HotelName = dr["HotelName"].ToString(),
                        KongWeiId = dr.GetString(dr.GetOrdinal("TourId")),
                        OperatorName = dr["OperatorName"].ToString(),
                        OrderCode = dr["OrderCode"].ToString()
                    };

                    if (!dr.IsDBNull(dr.GetOrdinal("KongWeiZhuangTai")))
                        model.KongWeiZhuangTai = (EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)dr.GetByte(dr.GetOrdinal("KongWeiZhuangTai"));

                    model.ZxsId = dr["ZxsId"].ToString();

                    list.Add(model);
                }
            }

            return list;
        }

        #endregion
    }
}
