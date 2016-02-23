using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.TourStructure
{
    public class DTourOrder : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.TourStructure.ITourOrder
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
        public DTourOrder()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region 私有方法
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
        string CreateJiuDianAnPaiMxXml(EyouSoft.Model.TourStructure.MTourOrder info)
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
                        s.AppendFormat("<info KongWeiId=\"{0}\" ", info.TourId);
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
        public IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> GetYouKes(string dingDanId)
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

        /// <summary>
        /// create youke xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateYouKeXml1(IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append(" <info ");
                s.AppendFormat(" YouKeId=\"{0}\" ", item.TravellerId);
                s.AppendFormat(" YouKeLeiXing=\"{0}\" ", (int)item.TravellerType);
                s.AppendFormat(" YouKeZhengJianLeiXing=\"{0}\" ", (int)item.CardType);
                s.AppendFormat(" YouKeXingBie=\"{0}\" ", (int)item.Sex);
                s.Append(" > ");

                s.AppendFormat("<YouKeXingMing><![CDATA[{0}]]></YouKeXingMing>", item.TravellerName);
                s.AppendFormat("<YouKeZhengJianHaoMa><![CDATA[{0}]]></YouKeZhengJianHaoMa>", item.CardNumber);
                s.AppendFormat("<YouKeLianXiFangShi><![CDATA[{0}]]></YouKeLianXiFangShi>", item.Contact);

                s.Append("</info>");
            }
            s.Append("</root>");
            return s.ToString();
        }
        #endregion

        #region ITourOrder 成员

        /// <summary>
        /// 添加订单，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTourOrder(EyouSoft.Model.TourStructure.MTourOrder model)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_TourOrder_Add");
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            _db.AddInParameter(cmd, "OrderCode", DbType.String, model.OrderCode);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(cmd, "TourId", DbType.AnsiStringFixedLength, model.TourId);
            _db.AddInParameter(cmd, "BusinessType", DbType.Byte, (int)model.BusinessType);
            _db.AddInParameter(cmd, "BusinessNature", DbType.Byte, (int)model.BusinessNature);
            _db.AddInParameter(cmd, "Adults", DbType.Int32, model.Adults);
            _db.AddInParameter(cmd, "Childs", DbType.Int32, model.Childs);
            _db.AddInParameter(cmd, "Bears", DbType.Int32, model.Bears);
            _db.AddInParameter(cmd, "Accounts", DbType.Int32, model.Accounts);
            _db.AddInParameter(cmd, "BuyCompanyId", DbType.AnsiStringFixedLength, model.BuyCompanyId);
            _db.AddInParameter(cmd, "BuyOperatorId", DbType.Int32, model.BuyOperatorId);
            _db.AddInParameter(cmd, "RouteId", DbType.AnsiStringFixedLength, model.RouteId);
            _db.AddInParameter(cmd, "PriceDetials", DbType.String, model.PriceDetials);
            _db.AddInParameter(cmd, "SumPrice", DbType.Currency, model.SumPrice);
            _db.AddInParameter(cmd, "PriceRemark", DbType.String, model.PriceRemark);
            _db.AddInParameter(cmd, "CongregationPlace", DbType.String, model.CongregationPlace);
            _db.AddInParameter(cmd, "CongregationTime", DbType.String, model.CongregationTime);
            _db.AddInParameter(cmd, "SendTourInfo", DbType.String, model.SendTourInfo);
            _db.AddInParameter(cmd, "WelcomeWay", DbType.String, model.WelcomeWay);
            _db.AddInParameter(cmd, "SpecialAskRemark", DbType.String, model.SpecialAskRemark);
            _db.AddInParameter(cmd, "GroundRemark", DbType.String, model.GroundRemark);
            _db.AddInParameter(cmd, "OperatoRemark", DbType.String, model.OperatoRemark);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(cmd, "OrderStatus", DbType.Byte, (int)model.OrderStatus);
            _db.AddInParameter(cmd, "SaveSeatDate", DbType.DateTime, model.SaveSeatDate.HasValue ? (DateTime?)model.SaveSeatDate.Value : null);
            _db.AddInParameter(cmd, "YouKeXml", DbType.String, CreateYouKeXml(model.TourOrderTravellerList));
            _db.AddInParameter(cmd, "JiuDianAnPaiXml", DbType.String, CreateJiuDianAnPaiXml(model.TourOrderHotelPlanList));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "JiuDianAnPaiMxXml", DbType.String, CreateJiuDianAnPaiMxXml(model));
            _db.AddInParameter(cmd, "BiaoShiYanSe", DbType.AnsiString, model.BiaoShiYanSe);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            _db.AddInParameter(cmd, "XiaDanLeiXing", DbType.Byte, model.XiaDanLeiXing);
            _db.AddInParameter(cmd, "LatestOperatorId", DbType.Int32, model.LatestOperatorId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, model.LatestTime);
            _db.AddInParameter(cmd, "YingErRenShu", DbType.Int32, model.YingErRenShu);
            _db.AddInParameter(cmd, "BuFangChaRenShu", DbType.Int32, model.BuFangChaRenShu);
            _db.AddInParameter(cmd, "TuiFangChaRenShu", DbType.Int32, model.TuiFangChaRenShu);
            _db.AddInParameter(cmd, "JiaJinE", DbType.Decimal, model.JiaJinE);
            _db.AddInParameter(cmd, "JianJinE", DbType.Decimal, model.JianJinE);
            _db.AddInParameter(cmd, "JiaBeiZhu", DbType.String, model.JiaBeiZhu);
            _db.AddInParameter(cmd, "JianBeiZhu", DbType.String, model.JianBeiZhu);
            _db.AddInParameter(cmd, "DingDanJinE", DbType.Decimal, model.DingDanJinE);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, model.XianLuId);
            _db.AddInParameter(cmd, "ChengRenJiaGe", DbType.Decimal, model.ChengRenJiaGe);
            _db.AddInParameter(cmd, "ErTongJiaGe", DbType.Decimal, model.ErTongJiaGe);
            _db.AddInParameter(cmd, "YingErJiaGe", DbType.Decimal, model.YingErJiaGe);
            _db.AddInParameter(cmd, "QuanPeiJiaGe", DbType.Decimal, model.QuanPeiJiaGe);
            _db.AddInParameter(cmd, "TuiFangChaJiaGe", DbType.Decimal, model.TuiFangChaJiaGe);
            _db.AddInParameter(cmd, "BuFangChaJiaGe", DbType.Decimal, model.BuFangChaJiaGe);
            _db.AddInParameter(cmd, "JiFen1", DbType.Int32, model.JiFen1);
            _db.AddInParameter(cmd, "JiFen2", DbType.Int32, model.JiFen2);
            _db.AddInParameter(cmd, "BuZhanWeiRenShu", DbType.Int32, model.BuZhanWeiRenShu);
            _db.AddInParameter(cmd, "XiaDanBeiZhu", DbType.String, model.XiaDanBeiZhu);
            _db.AddInParameter(cmd, "JiaGeMingXi", DbType.String, model.JiaGeMingXi);
            _db.AddInParameter(cmd, "@DingDanLxrXingMing", DbType.String, model.DingDanLxrXingMing);
            _db.AddInParameter(cmd, "@DingDanLxrShouJi", DbType.String, model.DingDanLxrShouJi);
            _db.AddInParameter(cmd, "@DingDanLxrDianHua", DbType.String, model.DingDanLxrDianHua);
            _db.AddInParameter(cmd, "@DingDanLxrFax", DbType.String, model.DingDanLxrFax);
            _db.AddInParameter(cmd, "@JiFenXianShiBiaoShi", DbType.Byte, model.JiFenXianShiBiaoShi);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 修改订单，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateTourOrder(EyouSoft.Model.TourStructure.MTourOrder model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_TourOrder_Update");
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(cmd, "OrderCode", DbType.String, model.OrderCode);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "TourId", DbType.AnsiStringFixedLength, model.TourId);
            this._db.AddInParameter(cmd, "BusinessType", DbType.Byte, (int)model.BusinessType);
            this._db.AddInParameter(cmd, "BusinessNature", DbType.Byte, (int)model.BusinessNature);
            this._db.AddInParameter(cmd, "Adults", DbType.Int32, model.Adults);
            this._db.AddInParameter(cmd, "Childs", DbType.Int32, model.Childs);
            this._db.AddInParameter(cmd, "Bears", DbType.Int32, model.Bears);
            this._db.AddInParameter(cmd, "Accounts", DbType.Int32, model.Accounts);
            this._db.AddInParameter(cmd, "BuyCompanyId", DbType.AnsiStringFixedLength, model.BuyCompanyId);
            this._db.AddInParameter(cmd, "BuyOperatorId", DbType.Int32, model.BuyOperatorId);
            this._db.AddInParameter(cmd, "RouteId", DbType.AnsiStringFixedLength, model.RouteId);
            this._db.AddInParameter(cmd, "PriceDetials", DbType.String, model.PriceDetials);
            this._db.AddInParameter(cmd, "SumPrice", DbType.Currency, model.SumPrice);
            this._db.AddInParameter(cmd, "PriceRemark", DbType.String, model.PriceRemark);
            this._db.AddInParameter(cmd, "CongregationPlace", DbType.String, model.CongregationPlace);
            this._db.AddInParameter(cmd, "CongregationTime", DbType.String, model.CongregationTime);
            this._db.AddInParameter(cmd, "SendTourInfo", DbType.String, model.SendTourInfo);
            this._db.AddInParameter(cmd, "WelcomeWay", DbType.String, model.WelcomeWay);
            this._db.AddInParameter(cmd, "SpecialAskRemark", DbType.String, model.SpecialAskRemark);
            this._db.AddInParameter(cmd, "GroundRemark", DbType.String, model.GroundRemark);
            this._db.AddInParameter(cmd, "OperatoRemark", DbType.String, model.OperatoRemark);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "OrderStatus", DbType.Byte, (int)model.OrderStatus);
            this._db.AddInParameter(cmd, "SaveSeatDate", DbType.DateTime, DBNull.Value);
            this._db.AddInParameter(cmd, "YouKeXml", DbType.String, CreateYouKeXml(model.TourOrderTravellerList));
            this._db.AddInParameter(cmd, "JiuDianAnPaiXml", DbType.String, CreateJiuDianAnPaiXml(model.TourOrderHotelPlanList));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "PlanHotelMxXML", DbType.String, CreateJiuDianAnPaiMxXml(model));
            _db.AddInParameter(cmd, "BiaoShiYanSe", DbType.AnsiString, model.BiaoShiYanSe);
            _db.AddInParameter(cmd, "LatestOperatorId", DbType.Int32, model.LatestOperatorId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, model.LatestTime);
            _db.AddInParameter(cmd, "YingErRenShu", DbType.Int32, model.YingErRenShu);
            _db.AddInParameter(cmd, "BuFangChaRenShu", DbType.Int32, model.BuFangChaRenShu);
            _db.AddInParameter(cmd, "TuiFangChaRenShu", DbType.Int32, model.TuiFangChaRenShu);
            _db.AddInParameter(cmd, "JiaJinE", DbType.Decimal, model.JiaJinE);
            _db.AddInParameter(cmd, "JianJinE", DbType.Decimal, model.JianJinE);
            _db.AddInParameter(cmd, "JiaBeiZhu", DbType.String, model.JiaBeiZhu);
            _db.AddInParameter(cmd, "JianBeiZhu", DbType.String, model.JianBeiZhu);
            _db.AddInParameter(cmd, "DingDanJinE", DbType.Decimal, model.DingDanJinE);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, model.XianLuId);
            _db.AddInParameter(cmd, "ChengRenJiaGe", DbType.Decimal, model.ChengRenJiaGe);
            _db.AddInParameter(cmd, "ErTongJiaGe", DbType.Decimal, model.ErTongJiaGe);
            _db.AddInParameter(cmd, "YingErJiaGe", DbType.Decimal, model.YingErJiaGe);
            _db.AddInParameter(cmd, "QuanPeiJiaGe", DbType.Decimal, model.QuanPeiJiaGe);
            _db.AddInParameter(cmd, "TuiFangChaJiaGe", DbType.Decimal, model.TuiFangChaJiaGe);
            _db.AddInParameter(cmd, "BuFangChaJiaGe", DbType.Decimal, model.BuFangChaJiaGe);
            _db.AddInParameter(cmd, "JiFen1", DbType.Int32, model.JiFen1);
            _db.AddInParameter(cmd, "JiFen2", DbType.Int32, model.JiFen2);
            _db.AddInParameter(cmd, "BuZhanWeiRenShu", DbType.Int32, model.BuZhanWeiRenShu);
            _db.AddInParameter(cmd, "XiaDanBeiZhu", DbType.String, model.XiaDanBeiZhu);
            _db.AddInParameter(cmd, "JiaGeMingXi", DbType.String, model.JiaGeMingXi);
            _db.AddInParameter(cmd, "@DingDanLxrXingMing", DbType.String, model.DingDanLxrXingMing);
            _db.AddInParameter(cmd, "@DingDanLxrShouJi", DbType.String, model.DingDanLxrShouJi);
            _db.AddInParameter(cmd, "@DingDanLxrDianHua", DbType.String, model.DingDanLxrDianHua);
            _db.AddInParameter(cmd, "@DingDanLxrFax", DbType.String, model.DingDanLxrFax);
            _db.AddInParameter(cmd, "@JiFenXianShiBiaoShi", DbType.Byte, model.JiFenXianShiBiaoShi);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 根据线路编号获取订单列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MRoute_TourOrder> GetTourOrderList(int companyId, int pageSize, int pageIndex, ref int recordCount, string routeId)
        {
            IList<EyouSoft.Model.TourStructure.MRoute_TourOrder> list = null;
            StringBuilder fileds = new StringBuilder();
            fileds.Append("OrderId,OrderCode,BuyOperatorId,Adults,Childs,Bears,Accounts,PriceDetials,SumPrice");
            fileds.Append(",(select Name from tbl_CustomerContactInfo where Id=tbl_TourOrder.BuyOperatorId) as BuyOperatorName");
            fileds.Append( " ,(select [Name] from tbl_Customer where tbl_Customer.Id = tbl_TourOrder.BuyCompanyId) as BuyCompanyName ");
            fileds.Append(" ,YingErRenShu,JiaGeMingXi ");
            string tableName = "tbl_TourOrder";

            string OrderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" CompanyId={0} and IsDelete='{1}' and RouteId='{2}' ", companyId, 0, routeId);

            list = new List<EyouSoft.Model.TourStructure.MRoute_TourOrder>();
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds.ToString(), query.ToString(), OrderByString, null))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        var model = new Model.TourStructure.MRoute_TourOrder
                            {
                                OrderId = dr.GetString(dr.GetOrdinal("OrderId")),
                                OrderCode = dr.GetString(dr.GetOrdinal("OrderCode")),
                                Adults = dr.GetInt32(dr.GetOrdinal("Adults")),
                                Childs = dr.GetInt32(dr.GetOrdinal("Childs")),
                                Bears = dr.GetInt32(dr.GetOrdinal("Bears")),
                                Accounts = dr.GetInt32(dr.GetOrdinal("Accounts")),
                                BuyOperatorName = dr.GetString(dr.GetOrdinal("BuyOperatorName")),
                                PriceDetials = dr.GetString(dr.GetOrdinal("PriceDetials")),
                                SumPrice = dr.GetDecimal(dr.GetOrdinal("SumPrice")),
                                BuyCompanyName = dr["BuyCompanyName"].ToString()
                            };
                        model.YingErRenShu = dr.GetInt32(dr.GetOrdinal("YingErRenShu"));
                        model.JiaGeMingXi = dr["JiaGeMingXi"].ToString();

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 根据团队编号获取订单集合
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MTourOrder> GetTourOrderList(string tourId)
        {

            IList<EyouSoft.Model.TourStructure.MTourOrder> list = new List<EyouSoft.Model.TourStructure.MTourOrder>();

            StringBuilder query = new StringBuilder();
            query.Append("SELECT OrderId,OrderCode,CompanyId,TourId,BusinessType,BusinessNature,Adults,Childs");
            query.Append(",Bears,Accounts,BuyCompanyId,BuyCompanyName,BuyOperatorId,BuyOperatorName");
            query.Append(",RouteId,RouteName,PriceDetials,SumPrice,PriceRemark,CongregationPlace");
            query.Append(",CongregationTime,SendTourInfo,WelcomeWay,SpecialAskRemark,GroundRemark");
            query.Append(",OperatoRemark,OperatorId,OperatorName,OrderStatus,SaveSeatDate,IssueTime");
            query.Append(",CheckMoney,ReturnMoney,ReceivedMoney,RefundMoney");
            query.Append(",BiaoShiYanSe");
            query.Append(",YingErRenShu,LatestOperatorName,LatestTime,JiaGeMingXi ");
            query.Append(" FROM view_TourOrder ");
            query.Append(" Where TourId=@tourId ");
            query.Append(" order by IssueTime desc ");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());

            this._db.AddInParameter(cmd, "TourId", DbType.AnsiStringFixedLength, tourId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {

                while (dr.Read())
                {
                    EyouSoft.Model.TourStructure.MTourOrder model = new EyouSoft.Model.TourStructure.MTourOrder();

                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    model.TourId = dr.GetString(dr.GetOrdinal("TourId"));
                    model.BusinessType = (EyouSoft.Model.EnumType.TourStructure.BusinessType)dr.GetByte(dr.GetOrdinal("BusinessType"));
                    model.BusinessNature = !dr.IsDBNull(dr.GetOrdinal("BusinessNature")) ? (EyouSoft.Model.EnumType.TourStructure.BusinessNature?)dr.GetByte(dr.GetOrdinal("BusinessNature")) : null;
                    model.Adults = dr.GetInt32(dr.GetOrdinal("Adults"));
                    model.Childs = dr.GetInt32(dr.GetOrdinal("Childs"));
                    model.Bears = dr.GetInt32(dr.GetOrdinal("Bears"));
                    model.Accounts = dr.GetInt32(dr.GetOrdinal("Accounts"));
                    model.BuyCompanyId = dr.GetString(dr.GetOrdinal("BuyCompanyId"));
                    model.BuyCompanyName = dr["BuyCompanyName"].ToString();
                    model.BuyOperatorId = dr.GetInt32(dr.GetOrdinal("BuyOperatorId"));
                    model.BuyOperatorName = dr["BuyOperatorName"].ToString();
                    model.RouteId = dr["RouteId"].ToString();
                    model.RouteName = dr["RouteName"].ToString();
                    model.PriceDetials = dr["PriceDetials"].ToString();
                    model.SumPrice = dr.GetDecimal(dr.GetOrdinal("SumPrice"));
                    model.PriceRemark = dr["PriceRemark"].ToString();
                    model.CongregationPlace = dr["CongregationPlace"].ToString();
                    model.CongregationTime = dr["CongregationTime"].ToString();
                    model.SendTourInfo = dr["SendTourInfo"].ToString();
                    model.WelcomeWay = dr["WelcomeWay"].ToString();
                    model.SpecialAskRemark = dr["SpecialAskRemark"].ToString();
                    model.GroundRemark = dr["GroundRemark"].ToString();
                    model.OperatoRemark = dr["OperatoRemark"].ToString();
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = dr["OperatorName"].ToString();
                    model.OrderStatus = (EyouSoft.Model.EnumType.TourStructure.OrderStatus)dr.GetByte(dr.GetOrdinal("OrderStatus"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SaveSeatDate"))) model.SaveSeatDate = dr.GetDateTime(dr.GetOrdinal("SaveSeatDate"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.CheckMoney = dr.GetDecimal(dr.GetOrdinal("CheckMoney"));
                    model.ReceivedMoney = dr.GetDecimal(dr.GetOrdinal("ReceivedMoney"));
                    model.RefundMoney = dr.GetDecimal(dr.GetOrdinal("RefundMoney"));
                    model.ReturnMoney = dr.GetDecimal(dr.GetOrdinal("ReturnMoney"));

                    model.BiaoShiYanSe = dr["BiaoShiYanSe"].ToString();
                    model.YingErRenShu = dr.GetInt32(dr.GetOrdinal("YingErRenShu"));
                    model.LatestTime = dr.GetDateTime(dr.GetOrdinal("LatestTime"));
                    model.LatestOperatorName = dr["LatestOperatorName"].ToString();
                    model.JiaGeMingXi = dr["JiaGeMingXi"].ToString();

                    list.Add(model);
                }
            }

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    item.TourOrderTravellerList = GetYouKes(item.OrderId);
                    item.TourOrderHotelPlanList = GetJiuDianAnPais(item.OrderId);
                }
            }

            return list;
        }

        /// <summary>
        /// 根据订单编号获取订单实体
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MTourOrder GetTourOrderById(string orderId)
        {
            EyouSoft.Model.TourStructure.MTourOrder model = null;

            StringBuilder query = new StringBuilder();
            query.Append("SELECT * ");
            query.Append(" FROM view_TourOrder ");
            query.Append(" Where OrderId=@OrderId");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());

            this._db.AddInParameter(cmd, "orderId", DbType.AnsiStringFixedLength, orderId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.TourStructure.MTourOrder();

                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    model.TourId = dr.GetString(dr.GetOrdinal("TourId"));
                    model.BusinessType = (EyouSoft.Model.EnumType.TourStructure.BusinessType)dr.GetByte(dr.GetOrdinal("BusinessType"));
                    model.BusinessNature = (EyouSoft.Model.EnumType.TourStructure.BusinessNature)dr.GetByte(dr.GetOrdinal("BusinessNature"));
                    model.Adults = dr.GetInt32(dr.GetOrdinal("Adults"));
                    model.Childs = dr.GetInt32(dr.GetOrdinal("Childs"));
                    model.Bears = dr.GetInt32(dr.GetOrdinal("Bears"));
                    model.Accounts = dr.GetInt32(dr.GetOrdinal("Accounts"));
                    model.BuyCompanyId = dr.GetString(dr.GetOrdinal("BuyCompanyId"));
                    model.BuyCompanyName = dr["BuyCompanyName"].ToString();
                    model.BuyOperatorId = dr.GetInt32(dr.GetOrdinal("BuyOperatorId"));
                    model.BuyOperatorName = dr["BuyOperatorName"].ToString();
                    model.RouteId = dr["RouteId"].ToString();
                    model.RouteName = dr["RouteName"].ToString();
                    model.PriceDetials = dr.GetString(dr.GetOrdinal("PriceDetials"));
                    model.SumPrice = dr.GetDecimal(dr.GetOrdinal("SumPrice"));
                    model.PriceRemark = dr["PriceRemark"].ToString();
                    model.CongregationPlace = dr["CongregationPlace"].ToString();
                    model.CongregationTime = dr["CongregationTime"].ToString();
                    model.SendTourInfo = dr["SendTourInfo"].ToString();
                    model.WelcomeWay = dr["WelcomeWay"].ToString();
                    model.SpecialAskRemark = dr["SpecialAskRemark"].ToString();
                    model.GroundRemark = dr["GroundRemark"].ToString();
                    model.OperatoRemark = dr["OperatoRemark"].ToString();
                    model.OperatorId = dr.GetOrdinal("OperatorId");
                    model.OperatorName = dr["OperatorName"].ToString();
                    model.OrderStatus = (EyouSoft.Model.EnumType.TourStructure.OrderStatus)dr.GetByte(dr.GetOrdinal("OrderStatus"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SaveSeatDate"))) model.SaveSeatDate = dr.GetDateTime(dr.GetOrdinal("SaveSeatDate"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.CheckMoney = dr.GetDecimal(dr.GetOrdinal("CheckMoney"));
                    model.ReceivedMoney = dr.GetDecimal(dr.GetOrdinal("ReceivedMoney"));
                    model.RefundMoney = dr.GetDecimal(dr.GetOrdinal("RefundMoney"));
                    model.ReturnMoney = dr.GetDecimal(dr.GetOrdinal("ReturnMoney"));
                    model.BiaoShiYanSe = dr["BiaoShiYanSe"].ToString();

                    model.ZxsId = dr["ZxsId"].ToString();
                    model.LatestOperatorId = dr.GetInt32(dr.GetOrdinal("LatestOperatorId"));
                    model.LatestTime = dr.GetDateTime(dr.GetOrdinal("LatestTime"));
                    model.XiaDanLeiXing = (EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing)dr.GetByte(dr.GetOrdinal("XiaDanLeiXing"));
                    model.XianLuId = dr["XianLuId"].ToString().Trim();
                    model.YingErRenShu = dr.GetInt32(dr.GetOrdinal("YingErRenShu"));
                    model.BuZhanWeiRenShu = dr.GetInt32(dr.GetOrdinal("BuZhanWeiRenShu"));
                    model.ChengRenJiaGe = dr.GetDecimal(dr.GetOrdinal("ChengRenJiaGe"));
                    model.ErTongJiaGe = dr.GetDecimal(dr.GetOrdinal("ErTongJiaGe"));
                    model.QuanPeiJiaGe = dr.GetDecimal(dr.GetOrdinal("QuanPeiJiaGe"));
                    model.YingErJiaGe = dr.GetDecimal(dr.GetOrdinal("YingErJiaGe"));
                    model.JiaJinE = dr.GetDecimal(dr.GetOrdinal("JiaJinE"));
                    model.JianJinE = dr.GetDecimal(dr.GetOrdinal("JianJinE"));
                    model.JiaBeiZhu = dr["JiaBeiZhu"].ToString();
                    model.JianBeiZhu = dr["JianBeiZhu"].ToString();
                    model.BuZhanWeiRenShu = dr.GetInt32(dr.GetOrdinal("BuZhanWeiRenShu"));
                    model.BuFangChaRenShu = dr.GetInt32(dr.GetOrdinal("BuFangChaRenShu"));
                    model.TuiFangChaRenShu = dr.GetInt32(dr.GetOrdinal("TuiFangChaRenShu"));
                    model.BuFangChaJiaGe = dr.GetDecimal(dr.GetOrdinal("BuFangChaJiaGe"));
                    model.TuiFangChaJiaGe = dr.GetDecimal(dr.GetOrdinal("TuiFangChaJiaGe"));
                    model.DingDanJinE = dr.GetDecimal(dr.GetOrdinal("DingDanJinE"));
                    model.JiFen1 = dr.GetInt32(dr.GetOrdinal("JiFen1"));
                    model.JiFen2 = dr.GetInt32(dr.GetOrdinal("JiFen2"));
                    model.XiaDanBeiZhu = dr["XiaDanBeiZhu"].ToString();
                    model.YuanYin1 = dr["YuanYin1"].ToString();
                    model.YuanYin2 = dr["YuanYin2"].ToString();
                    model.LatestOperatorName = dr["LatestOperatorName"].ToString();

                    model.JiaGeMingXi = dr["JiaGeMingXi"].ToString();
                    model.DingDanLxrXingMing = dr["DingDanLxrXingMing"].ToString();
                    model.DingDanLxrShouJi = dr["DingDanLxrShouJi"].ToString();
                    model.DingDanLxrDianHua = dr["DingDanLxrDianHua"].ToString();
                    model.DingDanLxrFax = dr["DingDanLxrFax"].ToString();
                    model.JiFenXianShiBiaoShi = (EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi)dr.GetByte(dr.GetOrdinal("JiFenXianShiBiaoShi"));
                }
            }

            if (model != null)
            {
                model.TourOrderTravellerList = GetYouKes(model.OrderId);
                model.TourOrderHotelPlanList = GetJiuDianAnPais(model.OrderId);
            }

            return model;
        }

        /// <summary>
        /// 设置订单状态（取消、拒绝、恢复），返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="status">订单状态</param>
        /// <param name="yuanYin">原因</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="caoZuoLaiYuan">操作来源 0:系统 1:平台</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(string dingDanId, EyouSoft.Model.EnumType.TourStructure.OrderStatus status, string yuanYin, int caoZuoRenId,int caoZuoLaiYuan)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_TourOrder_SheZhiDingDanStatus");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "@YuanYin", DbType.String, yuanYin);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "@CaoZuoRenId", DbType.Int32, caoZuoRenId);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "@CaoZuoShiJian", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(cmd, "@CaoZuoLaiYuan", DbType.Int32, caoZuoLaiYuan);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// （平台）线路订单新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int PT_DingDan_CU(EyouSoft.Model.TourStructure.MTourOrder info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_XianLuDingDan_CU");
            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, info.OrderId);
            _db.AddInParameter(cmd, "@YeWuLeiXing", DbType.Byte, info.BusinessType);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@XianLuId", DbType.AnsiStringFixedLength, info.XianLuId);
            _db.AddInParameter(cmd, "@KongWeiId", DbType.AnsiStringFixedLength, info.TourId);
            _db.AddInParameter(cmd, "@RouteId", DbType.AnsiStringFixedLength, info.RouteId);
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, info.BuyCompanyId);
            _db.AddInParameter(cmd, "@XiaDanRenId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@KeHuLxrId", DbType.Int32, info.BuyOperatorId);
            _db.AddInParameter(cmd, "@ChengRenShu", DbType.Int32, info.Adults);
            _db.AddInParameter(cmd, "@ErTongShu", DbType.Int32, info.Childs);
            _db.AddInParameter(cmd, "@YingErShu", DbType.Int32, info.YingErRenShu);
            _db.AddInParameter(cmd, "@QuanPeiShu", DbType.Int32, info.Bears);
            _db.AddInParameter(cmd, "@BuZhanWeiShu", DbType.Int32, info.BuZhanWeiRenShu);
            _db.AddInParameter(cmd, "@ZhanWeiShu", DbType.Int32, info.Accounts);
            _db.AddInParameter(cmd, "@BuFangChaShu", DbType.Int32, info.BuFangChaRenShu);
            _db.AddInParameter(cmd, "@TuiFangChaShu", DbType.Int32, info.TuiFangChaRenShu);
            _db.AddInParameter(cmd, "@ChengRenJiaGe", DbType.Decimal, info.ChengRenJiaGe);
            _db.AddInParameter(cmd, "@ErTongJiaGe", DbType.Decimal, info.ErTongJiaGe);
            _db.AddInParameter(cmd, "@YingErJiaGe", DbType.Decimal, info.YingErJiaGe);
            _db.AddInParameter(cmd, "@QuanPeiJiaGe", DbType.Decimal, info.QuanPeiJiaGe);
            _db.AddInParameter(cmd, "@TuiFangChaJiaGe", DbType.Decimal, info.TuiFangChaJiaGe);
            _db.AddInParameter(cmd, "@BuFangChaJiaGe", DbType.Decimal, info.BuFangChaJiaGe);
            _db.AddInParameter(cmd, "@JiFen1", DbType.Int32, info.JiFen1);
            _db.AddInParameter(cmd, "@JiFen2", DbType.Int32, info.JiFen2);
            _db.AddInParameter(cmd, "@DingDanJinE", DbType.Decimal, info.DingDanJinE);
            _db.AddInParameter(cmd, "@JinE", DbType.Decimal, info.SumPrice);
            _db.AddInParameter(cmd, "@JiaGeMingXi", DbType.String, info.JiaGeMingXi);
            _db.AddInParameter(cmd, "@DingDanLxrXingMing", DbType.String, info.DingDanLxrXingMing);
            _db.AddInParameter(cmd, "@DingDanLxrShouJi", DbType.String, info.DingDanLxrShouJi);
            _db.AddInParameter(cmd, "@DingDanLxrDianHua", DbType.String, info.DingDanLxrDianHua);
            _db.AddInParameter(cmd, "@DingDanLxrFax", DbType.String, info.DingDanLxrFax);
            _db.AddInParameter(cmd, "@XiaDanBeiZhu", DbType.String, info.XiaDanBeiZhu);
            _db.AddInParameter(cmd, "@YouKeXml", DbType.String, CreateYouKeXml1(info.TourOrderTravellerList));
            _db.AddInParameter(cmd, "@DingDanStatus", DbType.Byte, info.OrderStatus);
            _db.AddInParameter(cmd, "@DingDanLaiYuan", DbType.Byte, info.XiaDanLeiXing);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);            
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        #endregion
    }
}
