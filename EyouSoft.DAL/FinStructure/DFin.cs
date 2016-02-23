//财务管理相关数据访问类 汪奇志 2012-11-19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using EyouSoft.IDAL.FinStructure;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 财务管理相关数据访问类
    /// </summary>
    public class DFin : DALBase, IFin
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetJiPiaoAnPaiYouKes = "SELECT B.TravellerName,B.TravellerType,B.CardType,B.CardNumber,B.Gender,B.Contact FROM tbl_PlanChuPiaoYouKe AS A INNER JOIN tbl_TourOrderTraveller AS B ON A.YouKeId=B.TravellerId AND B.TicketType=1 WHERE A.PlanId=@AnPaiId ORDER BY B.SortId ASC";
        const string SQL_SELECT_GetJiPiaoTuiPiaoYouKes = "SELECT B.TravellerName,B.TravellerType,B.CardType,B.CardNumber,B.Gender,B.Contact FROM tbl_PlanTuiPiaoYouKe AS A INNER JOIN tbl_TourOrderTraveller AS B ON A.YouKeId=B.TravellerId AND B.TicketType=2 WHERE A.TuiId=@TuiPiaoId ORDER BY B.SortId ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DFin()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 获取机票安排游客信息集合
        /// </summary>
        /// <param name="anPaiId">机票安排编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> GetJiPiaoAnPaiYouKes(string anPaiId)
        {
            IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> items = new List<EyouSoft.Model.TourStructure.MTourOrderTraveller>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJiPiaoAnPaiYouKes);
            _db.AddInParameter(cmd, "AnPaiId", DbType.AnsiStringFixedLength, anPaiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MTourOrderTraveller();

                    item.CardNumber = rdr["CardNumber"].ToString();
                    item.CardType = (EyouSoft.Model.EnumType.TourStructure.CardType)rdr.GetByte(rdr.GetOrdinal("CardType"));
                    item.Contact = rdr["Contact"].ToString();
                    item.Sex = (EyouSoft.Model.EnumType.CompanyStructure.Sex)rdr.GetByte(rdr.GetOrdinal("Gender"));
                    item.TravellerName = rdr["TravellerName"].ToString();
                    item.TravellerType = (EyouSoft.Model.EnumType.TourStructure.TravellerType)rdr.GetByte(rdr.GetOrdinal("TravellerType"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取机票安排退票游客信息集合
        /// </summary>
        /// <param name="jiPiaoTuiPiaoId">机票安排退票编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> GetJiPiaoTuiPiaoYouKes(string jiPiaoTuiPiaoId)
        {
            IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> items = new List<EyouSoft.Model.TourStructure.MTourOrderTraveller>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJiPiaoTuiPiaoYouKes);
            _db.AddInParameter(cmd, "TuiPiaoId", DbType.AnsiStringFixedLength, jiPiaoTuiPiaoId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MTourOrderTraveller();

                    item.CardNumber = rdr["CardNumber"].ToString();
                    item.CardType = (EyouSoft.Model.EnumType.TourStructure.CardType)rdr.GetByte(rdr.GetOrdinal("CardType"));
                    item.Contact = rdr["Contact"].ToString();
                    item.Sex = (EyouSoft.Model.EnumType.CompanyStructure.Sex)rdr.GetByte(rdr.GetOrdinal("Gender"));
                    item.TravellerName = rdr["TravellerName"].ToString();
                    item.TravellerType = (EyouSoft.Model.EnumType.TourStructure.TravellerType)rdr.GetByte(rdr.GetOrdinal("TravellerType"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region EyouSoft.IDAL.FinStructure.IFin 成员
        /// <summary>
        /// 获取银行余额信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="time">截止时间</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<MYinHangYuEInfo> GetYinHangYuE(int companyId, DateTime time,string zxsId)
        {
            IList<MYinHangYuEInfo> items = new List<MYinHangYuEInfo>();
            StringBuilder sql = new StringBuilder();

            #region SQL
            sql.Append(" SELECT A.Id,A.AccountName,A.BankName,A.BankNo,A.AccountMoney,A.AccountState ");
            sql.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CompanyId=A.Companyid AND B.BankId=A.Id AND B.CollectionItem IN({0},{1},{2},{3},{4},{5}) AND B.Status={6} AND B.BankDate<=@Time AND B.IsXiaoZhang='0') AS ShouRuJinE ", (int)KuanXiangType.订单收款
                , (int)KuanXiangType.借款归还, (int)KuanXiangType.票务退款, (int)KuanXiangType.票务押金退还, (int)KuanXiangType.其它收入收款, (int)KuanXiangType.出纳登账收款, (int)KuanXiangStatus.未支付);
            sql.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CompanyId=A.Companyid AND B.BankId=A.Id AND B.CollectionItem IN({0},{1},{2},{3},{4},{5},{6},{7},{8}) AND B.Status={9} AND B.BankDate<=@Time AND B.IsXiaoZhang='0') AS ZhiChuJinE ", (int)KuanXiangType.报销支付
                , (int)KuanXiangType.地接支出付款, (int)KuanXiangType.订单退款, (int)KuanXiangType.借款支付, (int)KuanXiangType.酒店安排付款, (int)KuanXiangType.票务安排付款, (int)KuanXiangType.票务押金付款, (int)KuanXiangType.其它支出付款, (int)KuanXiangType.工资支付, (int)KuanXiangStatus.已支付);
            sql.Append(" FROM tbl_CompanyAccount AS A ");
            sql.AppendFormat(" WHERE A.CompanyId=@CompanyId AND A.AccountState<>@Status AND A.ZxsId=@ZxsId AND A.LeiXing=@LeiXing ");
            #endregion

            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "Time", DbType.DateTime, time);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.AccountState.未审批);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.收付款账户);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    decimal yuanShiJinE = 0, shouRuJinE = 0, zhiChuJinE = 0;
                    var item = new MYinHangYuEInfo();
                    item.KaiHuHang = rdr["BankName"].ToString();
                    item.MingCheng = rdr["AccountName"].ToString();
                    item.ZhangHao = rdr["BankNo"].ToString();
                    item.ZhangHuId = rdr.GetString(rdr.GetOrdinal("Id"));
                    yuanShiJinE = rdr.GetDecimal(rdr.GetOrdinal("AccountMoney"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShouRuJinE"))) shouRuJinE = rdr.GetDecimal(rdr.GetOrdinal("ShouRuJinE"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhiChuJinE"))) zhiChuJinE = rdr.GetDecimal(rdr.GetOrdinal("ZhiChuJinE"));
                    item.YuE = yuanShiJinE + shouRuJinE - zhiChuJinE;

                    var status = (EyouSoft.Model.EnumType.CompanyStructure.AccountState)rdr.GetByte(rdr.GetOrdinal("AccountState"));
                    if (status == EyouSoft.Model.EnumType.CompanyStructure.AccountState.不可用 && item.YuE == 0) continue;

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取银行明细信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:借方金额合计][1:decimal:贷方金额合计]</param>
        /// <returns></returns>
        public IList<MYinHangMingXiInfo> GetYinHangMingXi(int companyId, int pageSize, int pageIndex, ref int recordCount, MYinHangMingXiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M };
            IList<MYinHangMingXiInfo> items = new List<MYinHangMingXiInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_YinHangMingXi";
            string orderByString = " BankDate DESC ";
            string sumString = "SUM(JieFangJinE) AS JieFangJinEHeJi,SUM(DaiFangJinE) AS DaiFangJinEHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            query.Append(" AND IsXiaoZhang='0' ");
            if (chaXun != null)
            {
                if (chaXun.EBankDate.HasValue)
                {
                    query.AppendFormat(" AND BankDate<'{0}' ", chaXun.EBankDate.Value.AddDays(1));
                }
                if (chaXun.SBankDate.HasValue)
                {
                    query.AppendFormat(" AND BankDate>'{0}' ", chaXun.SBankDate.Value.AddDays(-1));
                }
                if (!string.IsNullOrEmpty(chaXun.YinHangZhangHuId))
                {
                    query.AppendFormat(" AND BankId='{0}' ", chaXun.YinHangZhangHuId);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MYinHangMingXiInfo();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("BankDate"))) item.BankDate = rdr.GetDateTime(rdr.GetOrdinal("BankDate"));
                    item.BeiZhu = rdr["BeiZhu"].ToString();
                    item.DaiFangJinE = rdr.GetDecimal(rdr.GetOrdinal("DaiFangJinE"));
                    item.JieFangJinE = rdr.GetDecimal(rdr.GetOrdinal("JieFangJinE"));
                    item.KuanXiangType = (KuanXiangType)rdr.GetByte(rdr.GetOrdinal("KuanXiangType"));
                    item.MingXiId = string.Empty;
                    item.WangLaiDanWeiName = rdr["WangLaiDanWeiName"].ToString();
                    item.ZhangHuId = rdr.GetString(rdr.GetOrdinal("BankId"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JieFangJinEHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("JieFangJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("DaiFangJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("DaiFangJinEHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取订单中心列表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:成人数合计][1:int:儿童数合计][2:int:全陪数合计][3:int:占位数合计][4:decimal:订单金额合计][5:int:婴儿数量合计]</param>
        /// <returns></returns>
        public IList<MOrderInfo> GetOrders(int companyId, int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0, 0M,0 };
            IList<MOrderInfo> items = new List<MOrderInfo>();

            string fields = "Adults,Childs,PriceDetials,SumPrice,BuyCompanyId,BuyOperatorId,BuyOperatorName,BuyCompanyName,TourId,QuDate,OperatorId,OperatorName,OrderCode,OrderId,Bears,RouteName,OrderStatus,BusinessType,Accounts,YouKeName,SaveSeatDate,BiaoShiYanSe,YingErRenShu,IssueTime,LatestTime,LatestOperatorName,JiaGeMingXi,FaPiaoMxId,FaPiaoJinE";
            StringBuilder query = new StringBuilder();
            string tableName = "view_TourOrder";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(Adults) AS ChengRenShuHeJi,SUM(Childs) AS ErTongShuHeJi,SUM(Bears) AS QuanPeiShuHeJi,SUM(Accounts) ZhanWeiShuHeJi,SUM(SumPrice) AS JinEHeJi,SUM(YingErRenShu) AS YingErRenShuHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (chaXun.KeHuCityId.HasValue)
                {
                    query.AppendFormat(" AND KeHuCityId={0} ", chaXun.KeHuCityId);
                }
                if (!string.IsNullOrEmpty(chaXun.keHuName))
                {
                    query.AppendFormat(" AND BuyCompanyName LIKE '%{0}%' ", chaXun.keHuName);
                }
                if (chaXun.KeHuProvinceId.HasValue)
                {
                    query.AppendFormat(" AND KeHuProvinceId ={0} ", chaXun.KeHuProvinceId.Value);
                }
                if (chaXun.LEDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (chaXun.LSDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.LSDate.Value.AddDays(-1));
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorName))
                {
                    query.AppendFormat(" AND OperatorName LIKE '%{0}%' ", chaXun.OperatorName);
                }
                if (!string.IsNullOrEmpty(chaXun.OrderCode))
                {
                    query.AppendFormat(" AND OrderCode LIKE '%{0}%' ", chaXun.OrderCode);
                }
                if (chaXun.Status.HasValue)
                {
                    query.AppendFormat(" AND OrderStatus={0} ", (int)chaXun.Status.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.YouKeName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_TourOrderTraveller AS A WHERE A.OrderId=view_TourOrder.OrderId AND A.TravellerName LIKE '%{0}%') ", chaXun.YouKeName);
                }
                if (chaXun.YeWuLeiXing.HasValue)
                {
                    query.AppendFormat(" AND BusinessType={0} ", (int)chaXun.YeWuLeiXing.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                if (!string.IsNullOrEmpty(chaXun.RouteName))
                {
                    if (chaXun.RouteName == "单订票")
                    {
                        query.AppendFormat(" AND BusinessType={0} ", (int)EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票);
                    }
                    else if (chaXun.RouteName == "票务酒店")
                    {
                        query.AppendFormat(" AND BusinessType={0} ", (int)EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店);
                    }
                    else if (chaXun.RouteName == "代订酒店")
                    {
                        query.AppendFormat(" AND BusinessType={0} ", (int)EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店);
                    }
                    else
                    {
                        query.AppendFormat(" AND RouteName LIKE '%{0}%' ", chaXun.RouteName);
                    }
                }
                if (chaXun.QuYuId.HasValue)
                {
                    query.AppendFormat(" AND AreaId={0} ", chaXun.QuYuId.Value);
                }
                if (chaXun.QuJiaoTongId.HasValue)
                {
                    query.AppendFormat(" AND QuJiaoTongId={0} ", chaXun.QuJiaoTongId.Value);
                }
            }
            #endregion

            #region paixu
            if (chaXun != null)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 0: orderByString = " IssueTime DESC "; break;
                    case 1: orderByString = " IssueTime ASC "; break;
                    case 2: orderByString = " QuDate DESC "; break;
                    case 3: orderByString = " QuDate ASC "; break;
                    default: orderByString = " IssueTime DESC "; break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MOrderInfo();

                    item.ChengRenShu = rdr.GetInt32(rdr.GetOrdinal("Adults"));
                    item.ErTongShu = rdr.GetInt32(rdr.GetOrdinal("Childs"));
                    item.JiaGeMingXi = rdr["PriceDetials"].ToString();
                    item.JiaGeMingXi1 = rdr["JiaGeMingXi"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("SumPrice"));
                    item.KeHuId = rdr.GetString(rdr.GetOrdinal("BuyCompanyId"));
                    item.KeHuLxrId = rdr.GetInt32(rdr.GetOrdinal("BuyOperatorId"));
                    item.KeHuLxrName = rdr["BuyOperatorName"].ToString();
                    item.KeHuName = rdr["BuyCompanyName"].ToString();
                    item.KongWeiId = rdr["TourId"].ToString();
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.OperatorName = rdr["OperatorName"].ToString();
                    item.OrderCode = rdr["OrderCode"].ToString();
                    item.OrderId = rdr.GetString(rdr.GetOrdinal("OrderId"));
                    item.QuanPeiShu = rdr.GetInt32(rdr.GetOrdinal("Bears"));
                    item.RouteName = rdr["RouteName"].ToString();
                    item.Status = (EyouSoft.Model.EnumType.TourStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("OrderStatus"));
                    item.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("BusinessType"));
                    item.ZhanWeiShu = rdr.GetInt32(rdr.GetOrdinal("Accounts"));
                    item.YouKeName = rdr["YouKeName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("SaveSeatDate"))) item.LiuWeiDaoQiTime = rdr.GetDateTime(rdr.GetOrdinal("SaveSeatDate"));
                    item.BiaoShiYanSe = rdr["BiaoShiYanSe"].ToString();
                    item.YingErRenShu = rdr.GetInt32(rdr.GetOrdinal("YingErRenShu"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.LatestOperatorName = rdr["LatestOperatorName"].ToString();
                    item.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));

                    if (!rdr.IsDBNull(rdr.GetOrdinal("FaPiaoMxId"))) item.FaPiaoMxId = rdr.GetInt32(rdr.GetOrdinal("FaPiaoMxId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FaPiaoJinE"))) item.FaPiaoJinE = rdr.GetDecimal(rdr.GetOrdinal("FaPiaoJinE"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChengRenShuHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("ChengRenShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ErTongShuHeJi"))) heJi[1] = rdr.GetInt32(rdr.GetOrdinal("ErTongShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QuanPeiShuHeJi"))) heJi[2] = rdr.GetInt32(rdr.GetOrdinal("QuanPeiShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhanWeiShuHeJi"))) heJi[3] = rdr.GetInt32(rdr.GetOrdinal("ZhanWeiShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JinEHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("JinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingErRenShuHeJi"))) heJi[5] = rdr.GetInt32(rdr.GetOrdinal("YingErRenShuHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取销售收款列表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:成人数合计][1:int:儿童数合计][2:int:全陪数合计][3:int:占位数合计][4:decimal:订单金额合计][5:decimal:收款已审核金额合计][6:decimal:收款未审核金额合计][7:decimal:退款已审核金额合计][8:decimal:退款未审核金额合计][9:int:婴儿人数合计]</param>
        /// <returns></returns>
        public IList<MYingShouInfo> GetYingShou(int companyId, int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0, 0M, 0M, 0M, 0M, 0M,0 };
            IList<MYingShouInfo> items = new List<MYingShouInfo>();

            string fields = "Adults,Childs,PriceDetials,SumPrice,BuyCompanyId,BuyOperatorId,BuyOperatorName,BuyCompanyName,TourId,QuDate,OperatorId,OperatorName,OrderCode,OrderId,Bears,RouteName,OrderStatus,BusinessType,Accounts,ReceivedMoney,CheckMoney,RefundMoney,ReturnMoney,YouKeName,BiaoShiYanSe,YingErRenShu,IssueTime,LatestTime,LatestOperatorName,JiaGeMingXi";
            StringBuilder query = new StringBuilder();
            string tableName = "view_TourOrder";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(Adults) AS ChengRenShuHeJi,SUM(Childs) AS ErTongShuHeJi,SUM(Bears) AS QuanPeiShuHeJi,SUM(Accounts) ZhanWeiShuHeJi,SUM(SumPrice) AS JinEHeJi,SUM(CheckMoney) AS ShouYiShenHeJinEHeJi,SUM(ReceivedMoney-CheckMoney) AS ShouWeiShenHeJinEHeJi,SUM(ReturnMoney) AS TuiYiShenHeJinEHeJi,SUM(RefundMoney-ReturnMoney) AS TuiWeiShenHeJinEHeJi,SUM(YingErRenShu) AS YingErRenShuHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            query.AppendFormat(" AND OrderStatus={0} ", (int)EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交);
            if (chaXun != null)
            {
                if (chaXun.KeHuCityId.HasValue)
                {
                    query.AppendFormat(" AND KeHuCityId={0} ", chaXun.KeHuCityId);
                }
                if (!string.IsNullOrEmpty(chaXun.keHuName))
                {
                    query.AppendFormat(" AND BuyCompanyName LIKE '%{0}%' ", chaXun.keHuName);
                }
                if (chaXun.KeHuProvinceId.HasValue)
                {
                    query.AppendFormat(" AND KeHuProvinceId ={0} ", chaXun.KeHuProvinceId.Value);
                }
                if (chaXun.LEDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (chaXun.LSDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.LSDate.Value.AddDays(-1));
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorName))
                {
                    query.AppendFormat(" AND OperatorName LIKE '%{0}%' ", chaXun.OperatorName);
                }
                if (!string.IsNullOrEmpty(chaXun.OrderCode))
                {
                    query.AppendFormat(" AND OrderCode LIKE '%{0}%' ", chaXun.OrderCode);
                }
                if (chaXun.Status.HasValue)
                {
                    query.AppendFormat(" AND OrderStatus={0} ", (int)chaXun.Status.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.YouKeName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_TourOrderTraveller AS A WHERE A.OrderId=view_TourOrder.OrderId AND A.TravellerName LIKE '%{0}%') ", chaXun.YouKeName);
                }
                if (chaXun.YingShouJinEOperator != QueryOperator.None && chaXun.YingShouJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.YingShouJinEOperator);
                    query.AppendFormat(" AND SumPrice {0} {1} ", _operator, chaXun.YingShouJinE.Value);
                }
                if (chaXun.JieQingStatus.HasValue)
                {
                    if (chaXun.JieQingStatus.Value == 0)
                    {
                        query.Append(" AND SumPrice-CheckMoney+ReturnMoney<>0 ");
                    }
                    else if (chaXun.JieQingStatus.Value == 1)
                    {
                        query.Append(" AND SumPrice-CheckMoney+ReturnMoney=0 ");
                    }
                }

                if (chaXun.DanBiShouKuanJinEOperator != QueryOperator.None && chaXun.DanBiShouKuanJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.DanBiShouKuanJinEOperator);
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_FinCope AS A WHERE A.CollectionId=view_TourOrder.OrderId AND A.CollectionRefundAmount {0} {1} AND A.CollectionItem={2}) ", _operator, chaXun.DanBiShouKuanJinE.Value, (int)KuanXiangType.订单收款);
                }

                if (chaXun.WeiShouJinEOperator != QueryOperator.None && chaXun.WeiShouJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.WeiShouJinEOperator);
                    query.AppendFormat(" AND SumPrice-CheckMoney+ReturnMoney {0} {1} ", _operator, chaXun.WeiShouJinE.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                if (chaXun.TuiKuanJinEOperator != QueryOperator.None && chaXun.TuiKuanJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.TuiKuanJinEOperator);
                    query.AppendFormat(" AND RefundMoney {0} {1} ", _operator, chaXun.TuiKuanJinE.Value);
                }

            }
            #endregion

            #region paixu
            if (chaXun != null)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 0: orderByString = " IssueTime DESC "; break;
                    case 1: orderByString = " IssueTime ASC "; break;
                    case 2: orderByString = " QuDate DESC "; break;
                    case 3: orderByString = " QuDate ASC "; break;
                    default: orderByString = " IssueTime DESC "; break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MYingShouInfo();

                    item.ChengRenShu = rdr.GetInt32(rdr.GetOrdinal("Adults"));
                    item.ErTongShu = rdr.GetInt32(rdr.GetOrdinal("Childs"));
                    item.JiaGeMingXi = rdr["PriceDetials"].ToString();
                    item.JiaGeMingXi1 = rdr["JiaGeMingXi"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("SumPrice"));
                    item.KeHuId = rdr.GetString(rdr.GetOrdinal("BuyCompanyId"));
                    item.KeHuLxrId = rdr.GetInt32(rdr.GetOrdinal("BuyOperatorId"));
                    item.KeHuLxrName = rdr["BuyOperatorName"].ToString();
                    item.KeHuName = rdr["BuyCompanyName"].ToString();
                    item.KongWeiId = rdr["TourId"].ToString();
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.OperatorName = rdr["OperatorName"].ToString();
                    item.OrderCode = rdr["OrderCode"].ToString();
                    item.OrderId = rdr.GetString(rdr.GetOrdinal("OrderId"));
                    item.QuanPeiShu = rdr.GetInt32(rdr.GetOrdinal("Bears"));
                    item.RouteName = rdr["RouteName"].ToString();
                    item.ShouWeiShenHeJinE = rdr.GetDecimal(rdr.GetOrdinal("ReceivedMoney")) - rdr.GetDecimal(rdr.GetOrdinal("CheckMoney"));
                    item.ShouYiShenHeJinE = rdr.GetDecimal(rdr.GetOrdinal("CheckMoney"));
                    item.Status = (EyouSoft.Model.EnumType.TourStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("OrderStatus"));
                    item.TuiWeiShenHeJinE = rdr.GetDecimal(rdr.GetOrdinal("RefundMoney")) - rdr.GetDecimal(rdr.GetOrdinal("ReturnMoney"));
                    item.TuiYiShenHeJinE = rdr.GetDecimal(rdr.GetOrdinal("ReturnMoney"));
                    item.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("BusinessType"));
                    item.ZhanWeiShu = rdr.GetInt32(rdr.GetOrdinal("Accounts"));
                    item.YouKeName = rdr["YouKeName"].ToString();
                    item.BiaoShiYanSe = rdr["BiaoShiYanSe"].ToString();
                    item.YingErRenShu = rdr.GetInt32(rdr.GetOrdinal("YingErRenShu"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.LatestOperatorName = rdr["LatestOperatorName"].ToString();
                    item.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChengRenShuHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("ChengRenShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ErTongShuHeJi"))) heJi[1] = rdr.GetInt32(rdr.GetOrdinal("ErTongShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QuanPeiShuHeJi"))) heJi[2] = rdr.GetInt32(rdr.GetOrdinal("QuanPeiShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhanWeiShuHeJi"))) heJi[3] = rdr.GetInt32(rdr.GetOrdinal("ZhanWeiShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JinEHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("JinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShouYiShenHeJinEHeJi"))) heJi[5] = rdr.GetDecimal(rdr.GetOrdinal("ShouYiShenHeJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShouWeiShenHeJinEHeJi"))) heJi[6] = rdr.GetDecimal(rdr.GetOrdinal("ShouWeiShenHeJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("TuiYiShenHeJinEHeJi"))) heJi[7] = rdr.GetDecimal(rdr.GetOrdinal("TuiYiShenHeJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("TuiWeiShenHeJinEHeJi"))) heJi[8] = rdr.GetDecimal(rdr.GetOrdinal("TuiWeiShenHeJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingErRenShuHeJi"))) heJi[9] = rdr.GetInt32(rdr.GetOrdinal("YingErRenShuHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取应付地接费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:成人数合计][1:int:儿童数合计][2:int:全陪数合计][3:decimal:结算金额合计][4:decimal:已支付金额合计][5:decimal:已审批金额合计][6:decimal:未审批金额合计][7:int:婴儿数合计]</param>
        /// <returns></returns>
        public IList<MYingFuDiJieInfo> GetYingFuDiJie(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0M, 0M, 0M, 0M, 0 };
            IList<MYingFuDiJieInfo> items = new List<MYingFuDiJieInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_YingFuDiJie";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(ChengRenShu) AS ChengRenShuHeJi,SUM(ErTongShu) AS ErTongShuHeJi,SUM(QuPeiShu) AS QuanPeiShuHeJi,SUM(JieSuanAmount) AS JieSuanJinEHeJi,SUM(YiZhiFuJinE) AS YiZhiFuJinEHeJi,SUM(YiShenPiJinE) AS YiShenPiJinEHeJi,SUM(WeiShenPiJinE) AS WeiShenPiJinEHeJi,SUM(YingErShu) AS YingErShuHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND  GysName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.JiaoYiHao))
                {
                    query.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", chaXun.JiaoYiHao);
                }
                if (!string.IsNullOrEmpty(chaXun.KongWeiCode))
                {
                    query.AppendFormat(" AND KongWeiCode LIKE '%{0}%' ", chaXun.KongWeiCode);
                }
                if (chaXun.LEDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (chaXun.LSDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.LSDate.Value.AddDays(-1));
                }
                if (chaXun.YingFuJinEOperator != QueryOperator.None && chaXun.YingFuJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.YingFuJinEOperator);
                    query.AppendFormat(" AND JieSuanAmount {0} {1} ", _operator, chaXun.YingFuJinE.Value);
                }
                if (chaXun.JieQingStatus.HasValue)
                {
                    if (chaXun.JieQingStatus.Value == 0)
                    {
                        query.Append(" AND JieSuanAmount-YiZhiFuJinE<>0 ");
                    }
                    else if (chaXun.JieQingStatus.Value == 1)
                    {
                        query.Append(" AND JieSuanAmount-YiZhiFuJinE=0 ");
                    }
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                if (!string.IsNullOrEmpty(chaXun.RouteName))
                {
                    query.AppendFormat(" AND RouteName LIKE '%{0}%' ", chaXun.RouteName);
                }
            }
            #endregion

            #region paixu
            if (chaXun != null)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 0: orderByString = " IssueTime DESC "; break;
                    case 1: orderByString = " IssueTime ASC "; break;
                    case 2: orderByString = " QuDate DESC "; break;
                    case 3: orderByString = " QuDate ASC "; break;
                    default: orderByString = " IssueTime DESC "; break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MYingFuDiJieInfo();

                    item.ChengRenShu = rdr.GetInt32(rdr.GetOrdinal("ChengRenShu"));
                    item.ErTongShu = rdr.GetInt32(rdr.GetOrdinal("ErTongShu"));
                    item.GysId = rdr.GetString(rdr.GetOrdinal("GysId"));
                    item.GysName = rdr["GysName"].ToString();
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.JieSuanJinE = rdr.GetDecimal(rdr.GetOrdinal("JieSuanAmount"));
                    item.JieSuanMingXi = rdr["JieSuanMX"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.PlanId = rdr.GetString(rdr.GetOrdinal("PlanId"));
                    item.QuanPeiShu = rdr.GetInt32(rdr.GetOrdinal("QuPeiShu"));
                    item.RouteName = rdr["RouteName"].ToString();
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.YiZhiFuJinE = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinE"));
                    item.DaoYouName = rdr["DaoYouName"].ToString();
                    item.YingErShu = rdr.GetInt32(rdr.GetOrdinal("YingErShu"));

                    item.DiJieQueRenRenId = rdr.GetInt32(rdr.GetOrdinal("DiJieQueRenRenId"));
                    item.DiJieQueRenRenName = rdr["DiJieQueRenRenName"].ToString();
                    item.DiJieQueRenStatus = (EyouSoft.Model.EnumType.TourStructure.QueRenStatus)rdr.GetInt32(rdr.GetOrdinal("DiJieQueRenStatus"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("DiJieQueRenTime"))) item.DiJieQueRenTime = rdr.GetDateTime(rdr.GetOrdinal("DiJieQueRenTime"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChengRenShuHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("ChengRenShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ErTongShuHeJi"))) heJi[1] = rdr.GetInt32(rdr.GetOrdinal("ErTongShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QuanPeiShuHeJi"))) heJi[2] = rdr.GetInt32(rdr.GetOrdinal("QuanPeiShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JieSuanJinEHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiZhiFuJinEHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShenPiJinEHeJi"))) heJi[5] = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("WeiShenPiJinEHeJi"))) heJi[6] = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingErShuHeJi"))) heJi[7] = rdr.GetInt32(rdr.GetOrdinal("YingErShuHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取应付交通费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:出票数合计][1:decimal:结算金额合计][2:decimal:已支付金额合计][3:decimal:已审批金额合计][4:decimal:未审批金额合计]</param>
        /// <returns></returns>
        public IList<MYingFuJiaoTongInfo> GetYingFuJiaoTong(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0M, 0M, 0M, 0M };
            IList<MYingFuJiaoTongInfo> items = new List<MYingFuJiaoTongInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_YingFuJiaoTong";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(ShuLiang) AS ShuLiangHeJi,SUM(JieSuanAmount) AS JieSuanJinEHeJi,SUM(YiZhiFuJinE) AS YiZhiFuJinEHeJi,SUM(YiShenPiJinE) AS YiShenPiJinEHeJi,SUM(WeiShenPiJinE) AS WeiShenPiJinEHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND  GysName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.JiaoYiHao))
                {
                    query.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", chaXun.JiaoYiHao);
                }
                if (!string.IsNullOrEmpty(chaXun.KongWeiCode))
                {
                    query.AppendFormat(" AND KongWeiCode LIKE '%{0}%' ", chaXun.KongWeiCode);
                }
                if (chaXun.LEDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (chaXun.LSDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.LSDate.Value.AddDays(-1));
                }
                if (!string.IsNullOrEmpty(chaXun.GysJiaoYiHao))
                {
                    query.AppendFormat(" AND GysOrderCode LIKE '%{0}%' ", chaXun.GysJiaoYiHao);
                }
                if (chaXun.YingFuJinEOperator != QueryOperator.None && chaXun.YingFuJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.YingFuJinEOperator);
                    query.AppendFormat(" AND JieSuanAmount {0} {1} ", _operator, chaXun.YingFuJinE.Value);
                }
                if (chaXun.JieQingStatus.HasValue)
                {
                    if (chaXun.JieQingStatus.Value == 0)
                    {
                        query.Append(" AND JieSuanAmount-YiZhiFuJinE<>0 ");
                    }
                    else if (chaXun.JieQingStatus.Value == 1)
                    {
                        query.Append(" AND JieSuanAmount-YiZhiFuJinE=0 ");
                    }
                }
                if (chaXun.QuJiaoTongId.HasValue)
                {
                    query.AppendFormat(" AND QuJiaoTongId={0} ", chaXun.QuJiaoTongId);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            #endregion

            #region paixu
            if (chaXun != null)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 0: orderByString = " IssueTime DESC "; break;
                    case 1: orderByString = " IssueTime ASC "; break;
                    case 2: orderByString = " QuDate DESC "; break;
                    case 3: orderByString = " QuDate ASC "; break;
                    default: orderByString = " IssueTime DESC "; break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MYingFuJiaoTongInfo();

                    item.ChuPiaoShu = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    item.GysId = rdr.GetString(rdr.GetOrdinal("GysId"));
                    item.GysName = rdr["GysName"].ToString();
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.JieSuanJinE = rdr.GetDecimal(rdr.GetOrdinal("JieSuanAmount"));
                    item.JieSuanMingXi = rdr["JieSuanMX"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.PlanId = rdr.GetString(rdr.GetOrdinal("PlanId"));
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.YiZhiFuJinE = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinE"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShuLiangHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("ShuLiangHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JieSuanJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiZhiFuJinEHeJi"))) heJi[2] = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShenPiJinEHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("WeiShenPiJinEHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinEHeJi"));
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.YouKes = GetJiPiaoAnPaiYouKes(item.PlanId);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取应付酒店费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:结算金额合计][1:decimal:已支付金额合计][2:decimal:已审批金额合计][3:decimal:未审批金额合计]</param>
        /// <returns></returns>
        public IList<MYingFuJiuDianInfo> GetYingFuJiuDian(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M };
            IList<MYingFuJiuDianInfo> items = new List<MYingFuJiuDianInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_YingFuJiuDian";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(JieSuanAmount) AS JieSuanJinEHeJi,SUM(YiZhiFuJinE) AS YiZhiFuJinEHeJi,SUM(YiShenPiJinE) AS YiShenPiJinEHeJi,SUM(WeiShenPiJinE) AS WeiShenPiJinEHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND  GysName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.JiaoYiHao))
                {
                    query.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", chaXun.JiaoYiHao);
                }
                if (!string.IsNullOrEmpty(chaXun.KongWeiCode))
                {
                    query.AppendFormat(" AND KongWeiCode LIKE '%{0}%' ", chaXun.KongWeiCode);
                }
                if (chaXun.LEDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (chaXun.LSDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.LSDate.Value.AddDays(-1));
                }
                if (chaXun.YingFuJinEOperator != QueryOperator.None && chaXun.YingFuJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.YingFuJinEOperator);
                    query.AppendFormat(" AND JieSuanAmount {0} {1} ", _operator, chaXun.YingFuJinE.Value);
                }
                if (chaXun.JieQingStatus.HasValue)
                {
                    if (chaXun.JieQingStatus.Value == 0)
                    {
                        query.Append(" AND JieSuanAmount-YiZhiFuJinE<>0 ");
                    }
                    else if (chaXun.JieQingStatus.Value == 1)
                    {
                        query.Append(" AND JieSuanAmount-YiZhiFuJinE=0 ");
                    }
                }
                if (!string.IsNullOrEmpty(chaXun.JiuDianName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_PlanHotelMX AS A WHERE A.AnPaiId=view_Fin_YingFuJiuDian.PlanId AND A.JiuDianName LIKE '%{0}%') ", chaXun.JiuDianName);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            #endregion

            #region paixu
            if (chaXun != null)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 0: orderByString = " IssueTime DESC "; break;
                    case 1: orderByString = " IssueTime ASC "; break;
                    case 2: orderByString = " QuDate DESC "; break;
                    case 3: orderByString = " QuDate ASC "; break;
                    default: orderByString = " IssueTime DESC "; break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MYingFuJiuDianInfo();

                    item.GysId = rdr.GetString(rdr.GetOrdinal("GysId"));
                    item.GysName = rdr["GysName"].ToString();
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.JieSuanJinE = rdr.GetDecimal(rdr.GetOrdinal("JieSuanAmount"));
                    item.JieSuanMingXi = rdr["JieSuanMX"].ToString();
                    item.JiuDianName = rdr["HotelName"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.PlanId = rdr.GetString(rdr.GetOrdinal("PlanId"));
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.YiZhiFuJinE = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinE"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JieSuanJinEHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiZhiFuJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShenPiJinEHeJi"))) heJi[2] = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("WeiShenPiJinEHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinEHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取押金登记表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:押金金额合计][1:decimal:已支付押金金额合计][2:decimal:已审批押金金额合计][3:decimal:未审批押金金额合计][4:decimal:应退押金金额合计][5:decimal:已审批退回押金金额合计][6:decimal:未审批退回押金金额合计]</param>
        /// <returns></returns>
        public IList<MYaJinInfo> GetYaJins(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M, 0M, 0M, 0M };
            IList<MYaJinInfo> items = new List<MYaJinInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_YaJin";
            string orderByString = " IdentityId DESC ";
            string sumString = "SUM(YaJinAmount) AS YaJinJinEHeJi,SUM(YiZhiFuJinE) AS YiZhiFuJinEHeJi,SUM(YiShenPiJinE) AS YiShenPiJinEHeJi,SUM(WeiShenPiJinE) AS WeiShenPiJinEHeJi,SUM(TuiYaJinAmount) AS TuiYaJinAmountHeJi,SUM(TuiYiShenPiJinE) AS TuiYiShenPiJinEHeJi,SUM(TuiWeiShenPiJinE) AS TuiWeiShenPiJinEHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND  GysName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.GysJiaoYiHao))
                {
                    query.AppendFormat(" AND GysOrderCode LIKE '%{0}%' ", chaXun.GysJiaoYiHao);
                }
                if (!string.IsNullOrEmpty(chaXun.KongWeiCode))
                {
                    query.AppendFormat(" AND KongWeiCode LIKE '%{0}%' ", chaXun.KongWeiCode);
                }
                if (chaXun.LEDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (chaXun.LSDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.LSDate.Value.AddDays(-1));
                }
                if (chaXun.YingTuiYaJinOperator != QueryOperator.None && chaXun.YingTuiYaJinJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.YingTuiYaJinOperator);
                    query.AppendFormat(" AND TuiYaJinAmount {0} {1} ", _operator, chaXun.YingTuiYaJinJinE.Value);
                }
                if (chaXun.TuiYiShenPiYaJinOperator != QueryOperator.None && chaXun.TuiYiShenPiYaJinJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.TuiYiShenPiYaJinOperator);
                    query.AppendFormat(" AND TuiYiShenPiJinE {0} {1} ", _operator, chaXun.TuiYiShenPiYaJinJinE.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }

                if (chaXun.YingFuJinEOperator != QueryOperator.None && chaXun.YingFuJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.YingFuJinEOperator);
                    query.AppendFormat(" AND YaJinAmount {0} {1} ", _operator, chaXun.YingFuJinE.Value);
                }

                if (chaXun.YiZhiFuJinEOperator != QueryOperator.None && chaXun.YiZhiFuJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.YiZhiFuJinEOperator);
                    query.AppendFormat(" AND YiZhiFuJinE {0} {1} ", _operator, chaXun.YiZhiFuJinE.Value);
                }

                if (chaXun.WeiZhiFuJinEOperator != QueryOperator.None && chaXun.WeiZhiFuJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.WeiZhiFuJinEOperator);
                    query.AppendFormat(" AND YaJinAmount-YiZhiFuJinE {0} {1} ", _operator, chaXun.WeiZhiFuJinE.Value);
                }
            }
            #endregion

            #region paixu
            if (chaXun != null)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 0: orderByString = " IdentityId DESC "; break;
                    case 1: orderByString = " IdentityId ASC "; break;
                    case 2: orderByString = " QuDate DESC "; break;
                    case 3: orderByString = " QuDate ASC "; break;
                    default: orderByString = " IdentityId DESC "; break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MYaJinInfo();

                    item.GysId = rdr.GetString(rdr.GetOrdinal("GysId"));
                    item.GysName = rdr["GysName"].ToString();
                    item.GysJiaoYiHao = rdr["GysOrderCode"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.PlanId = rdr.GetString(rdr.GetOrdinal("DaiLiId"));
                    item.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    item.TuiWeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("TuiWeiShenPiJinE"));
                    item.TuiYiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("TuiYiShenPiJinE"));
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.YaJinJinE = rdr.GetDecimal(rdr.GetOrdinal("YaJinAmount"));
                    item.YingTuiJinE = rdr.GetDecimal(rdr.GetOrdinal("TuiYaJinAmount"));
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.YiZhiFuJinE = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinE"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YaJinJinEHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("YaJinJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiZhiFuJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShenPiJinEHeJi"))) heJi[2] = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("WeiShenPiJinEHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("TuiYaJinAmountHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("TuiYaJinAmountHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("TuiYiShenPiJinEHeJi"))) heJi[5] = rdr.GetDecimal(rdr.GetOrdinal("TuiYiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("TuiWeiShenPiJinEHeJi"))) heJi[6] = rdr.GetDecimal(rdr.GetOrdinal("TuiWeiShenPiJinEHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取退票登记表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:退票人数合计][1:decimal:损失金额合计][2:decimal:应退金额合计][3:decimal:已审批金额][4:decimal:未审批金额]</param>
        /// <returns></returns>
        public IList<MTuiPiaoInfo> GetTuiPiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0M, 0M, 0M, 0M };
            IList<MTuiPiaoInfo> items = new List<MTuiPiaoInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_TuiPiao";
            string orderByString = " TuiTime DESC ";
            string sumString = "SUM(ShuLiang) AS ShuLiangHeJi,SUM(SunShiAmount) AS SunShiJinEHeJi,SUM(TuiAmount) AS YingTuiJinEHeJi,SUM(YiShenPiJinE) AS YiShenPiJinEHeJi,SUM(WeiShenPiJinE) AS WeiShenPiJinEHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.GysJiaoYiHao))
                {
                    query.AppendFormat(" AND  GysOrderCode LIKE '%{0}%' ", chaXun.GysJiaoYiHao);
                }
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND  GysName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.JiaoYiHao))
                {
                    query.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", chaXun.JiaoYiHao);
                }
                if (!string.IsNullOrEmpty(chaXun.KongWeiCode))
                {
                    query.AppendFormat(" AND KongWeiCode LIKE '%{0}%' ", chaXun.KongWeiCode);
                }
                if (chaXun.LEDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (chaXun.LSDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.LSDate.Value.AddDays(-1));
                }
                if (chaXun.TuiPiaoYingTuiOperator != QueryOperator.None && chaXun.TuiPiaoYingTuiJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.TuiPiaoYingTuiOperator);
                    query.AppendFormat(" AND TuiAmount {0} {1}", _operator, chaXun.TuiPiaoYingTuiJinE.Value);
                }
                if (chaXun.TuiPiaoYiTuiJinEOperator != QueryOperator.None && chaXun.TuiPiaoYiTuiJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.TuiPiaoYiTuiJinEOperator);
                    query.AppendFormat(" AND YiShenPiJinE {0} {1}", _operator, chaXun.TuiPiaoYiTuiJinE.Value);
                }
                if (chaXun.TuiPiaoWeiTuiJinEOperator != QueryOperator.None && chaXun.TuiPiaoWeiTuiJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.TuiPiaoWeiTuiJinEOperator);
                    query.AppendFormat(" AND ((TuiAmount-YiShenPiJinE) {0} {1})", _operator, chaXun.TuiPiaoWeiTuiJinE.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                if (!string.IsNullOrEmpty(chaXun.YouKeName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_PlanTuiPiaoYouKe AS A1 INNER JOIN tbl_TourOrderTraveller AS B1 ON A1.YouKeId=B1.TravellerId AND B1.TravellerName LIKE '%{0}%' WHERE A1.TuiId=view_Fin_TuiPiao.TuiId) ", chaXun.YouKeName);
                }
            }
            #endregion

            #region paixu
            if (chaXun != null)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 0: orderByString = " TuiTime DESC "; break;
                    case 1: orderByString = " TuiTime ASC "; break;
                    case 2: orderByString = " QuDate DESC "; break;
                    case 3: orderByString = " QuDate ASC "; break;
                    default: orderByString = " TuiTime DESC "; break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MTuiPiaoInfo();

                    item.ChengDanFang = rdr["ChengDanFang"].ToString();
                    item.GysId = rdr.GetString(rdr.GetOrdinal("GysId"));
                    item.GysJiaoYiHao = rdr["GysOrderCode"].ToString();
                    item.GysName = rdr["GysName"].ToString();
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.OperatorName = rdr["OperatorName"].ToString();
                    item.OrderCode = rdr["OrderCode"].ToString();
                    item.OrderId = rdr.GetString(rdr.GetOrdinal("OrderId"));
                    item.PlanId = rdr.GetString(rdr.GetOrdinal("PlanId"));
                    item.SunShiJinE = rdr.GetDecimal(rdr.GetOrdinal("SunShiAmount"));
                    item.SunShiMingXi = rdr["SunShiMX"].ToString();
                    item.TuiRenShu = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    item.TuiTime = rdr.GetDateTime(rdr.GetOrdinal("TuiTime"));
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.YingTuiJinE = rdr.GetDecimal(rdr.GetOrdinal("TuiAmount"));
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.TuiPiaoId = rdr.GetString(rdr.GetOrdinal("TuiId"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShuLiangHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("ShuLiangHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("SunShiJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("SunShiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingTuiJinEHeJi"))) heJi[2] = rdr.GetDecimal(rdr.GetOrdinal("YingTuiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShenPiJinEHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("WeiShenPiJinEHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinEHeJi"));
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.YouKes = GetJiPiaoTuiPiaoYouKes(item.TuiPiaoId);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取应付金额信息，[0:decimal:结算金额][1:decimal:已支付金额][2:decimal:已审批金额][3:decimal:未审批金额]
        /// </summary>
        /// <param name="xmid">支出项目编号</param>
        /// <param name="kuanXiangType">款项类型</param>
        /// <returns></returns>
        public decimal[] GetYingFuJinE(string xmid, KuanXiangType kuanXiangType)
        {
            decimal[] jinE = { 0M, 0M, 0M, 0M };

            StringBuilder s = new StringBuilder();
            s.Append(" SELECT ");
            switch (kuanXiangType)
            {
                case KuanXiangType.地接支出付款: s.AppendFormat(" A.JieSuanAmount "); break;
                case KuanXiangType.订单退款: s.AppendFormat(" CAST(0 AS MONEY) AS YingFuJinE  "); break;
                case KuanXiangType.酒店安排付款: s.AppendFormat(" A.SettleAmount "); break;
                case KuanXiangType.票务安排付款: s.AppendFormat(" A.JieSuanAmount "); break;
                case KuanXiangType.票务押金付款: s.AppendFormat(" A.YaJinAmount "); break;
                case KuanXiangType.其它支出付款: s.AppendFormat(" A.Proceed "); break;
            }

            s.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CollectionId=@XMID AND B.Status=@Status1 AND B.CollectionItem=@KuangXiangType) AS YiZhiFuJinE ");
            s.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CollectionId=@XMID AND B.Status=@Status2 AND B.CollectionItem=@KuangXiangType) AS YiShenPiJinE ");
            s.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CollectionId=@XMID AND B.Status=@Status3 AND B.CollectionItem=@KuangXiangType) AS WeiShenPiJinE ");

            switch (kuanXiangType)
            {
                case KuanXiangType.地接支出付款: s.AppendFormat("  FROM tbl_PlanDiJie AS A WHERE A.PlanId=@XMID "); break;
                case KuanXiangType.订单退款: break;
                case KuanXiangType.酒店安排付款: s.AppendFormat(" FROM tbl_TourOrderHotelPlan AS A WHERE A.Id=@XMID "); break;
                case KuanXiangType.票务安排付款: s.AppendFormat(" FROM tbl_PlanChuPiao AS A WHERE A.PlanId=@XMID "); break;
                case KuanXiangType.票务押金付款: s.AppendFormat(" FROM tbl_KongWeiDaiLi AS A WHERE A.DaiLiId=@XMID "); break;
                case KuanXiangType.其它支出付款: s.AppendFormat(" FROM tbl_FinOther AS A WHERE A.Id=@XMID "); break;
            }

            DbCommand cmd = _db.GetSqlStringCommand(s.ToString());
            _db.AddInParameter(cmd, "XMID", DbType.AnsiStringFixedLength, xmid);
            _db.AddInParameter(cmd, "Status1", DbType.Byte, KuanXiangStatus.已支付);
            _db.AddInParameter(cmd, "Status2", DbType.Byte, KuanXiangStatus.未支付);
            _db.AddInParameter(cmd, "Status3", DbType.Byte, KuanXiangStatus.未审批);
            _db.AddInParameter(cmd, "KuangXiangType", DbType.Byte, kuanXiangType);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) jinE[0] = rdr.GetDecimal(0);
                    if (!rdr.IsDBNull(1)) jinE[1] = rdr.GetDecimal(1);
                    if (!rdr.IsDBNull(2)) jinE[2] = rdr.GetDecimal(2);
                    if (!rdr.IsDBNull(3)) jinE[3] = rdr.GetDecimal(3);
                }
            }

            return jinE;
        }

        /// <summary>
        /// 获取应收金额信息，[0:decimal:应收金额][1:decimal:已审批金额][2:decimal:未审批金额]
        /// </summary>
        /// <param name="xmid">收入项目编号</param>
        /// <param name="kuanXiangType">款项类型</param>
        /// <returns></returns>
        public decimal[] GetYingShouJinE(string xmid, KuanXiangType kuanXiangType)
        {
            var jinE = new decimal[] { 0M, 0M, 0M };
            StringBuilder s = new StringBuilder();
            s.Append(" SELECT ");
            switch (kuanXiangType)
            {
                case KuanXiangType.订单收款: s.Append(" A.SumPrice "); break;
                case KuanXiangType.票务退款: s.Append(" A.TuiAmount "); break;
                case KuanXiangType.票务押金退还: s.Append(" A.TuiYaJinAmount "); break;
                case KuanXiangType.其它收入收款: s.Append(" A.Proceed "); break;
            }

            s.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CollectionId=@XMID AND B.Status=@Status1 AND B.CollectionItem=@KuangXiangType) AS YiShenPiJinE ");
            s.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CollectionId=@XMID AND B.Status=@Status2 AND B.CollectionItem=@KuangXiangType) AS WeiShenPiJinE ");

            switch (kuanXiangType)
            {
                case KuanXiangType.订单收款: s.Append(" FROM tbl_TourOrder AS A WHERE A.OrderId=@XMID "); break;
                case KuanXiangType.票务退款: s.Append(" FROM tbl_PlanTuiPiao AS A WHERE A.TuiId=@XMID "); break;
                case KuanXiangType.票务押金退还: s.Append(" FROM tbl_KongWeiDaiLi AS A WHERE A.DaiLiId=@XMID "); break;
                case KuanXiangType.其它收入收款: s.Append(" FROM tbl_FinOther AS A WHERE A.Id=@XMID "); break;
            }

            DbCommand cmd = _db.GetSqlStringCommand(s.ToString());
            _db.AddInParameter(cmd, "XMID", DbType.AnsiStringFixedLength, xmid);
            _db.AddInParameter(cmd, "Status1", DbType.Byte, KuanXiangStatus.未支付);
            _db.AddInParameter(cmd, "Status2", DbType.Byte, KuanXiangStatus.未审批);
            _db.AddInParameter(cmd, "KuangXiangType", DbType.Byte, kuanXiangType);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) jinE[0] = rdr.GetDecimal(0);
                    if (!rdr.IsDBNull(1)) jinE[1] = rdr.GetDecimal(1);
                    if (!rdr.IsDBNull(2)) jinE[2] = rdr.GetDecimal(2);
                }
            }

            return jinE;
        }

        /// <summary>
        /// 获取控位收入信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<MKongWeiShouRuInfo> GetKongWeiShouRus(string kongWeiId)
        {
            IList<MKongWeiShouRuInfo> items = new List<MKongWeiShouRuInfo>();

            DbCommand cmd = _db.GetSqlStringCommand("SELECT * FROM [view_Fin_KongWeiShouRu] WHERE [KongWeiId]=@KongWeiId ORDER BY IssueTime");
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MKongWeiShouRuInfo();

                    item.JiaGeMingXi = rdr["JiaGeMingXi"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.KeHuName = rdr["KeHuName"].ToString();
                    item.KuanXiangType = (KuanXiangType)rdr.GetInt32(rdr.GetOrdinal("KuanXiangType"));
                    item.OrderCode = rdr["OrderCode"].ToString();
                    item.XiangMuId = rdr.GetString(rdr.GetOrdinal("XiangMuId"));
                    item.JiaGeMingXi1 = rdr["JiaGeMingXi1"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取控位支出信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<MKongWeiZhiChuInfo> GetKongWeiZhiChus(string kongWeiId)
        {
            IList<MKongWeiZhiChuInfo> items = new List<MKongWeiZhiChuInfo>();

            DbCommand cmd = _db.GetSqlStringCommand("SELECT * FROM [view_Fin_KongWeiZhiChu] WHERE [KongWeiId]=@KongWeiId ORDER BY IssueTime");
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MKongWeiZhiChuInfo();

                    item.JieSuanMingXi = rdr["JieSuanMX"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.GysName = rdr["GysName"].ToString();
                    item.KuanXiangType = (KuanXiangType)rdr.GetInt32(rdr.GetOrdinal("KuanXiangType"));
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.XiangMuId = rdr.GetString(rdr.GetOrdinal("XiangMuId"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取团队结算汇总表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息,[0:decimal:收入金额合计][1:decimal:其它收入金额合计][2:decimal:支出金额合计][3:decimal:其它支出金额合计][4:int:数量合计][5:int:占位数量合计]</param>
        /// <returns></returns>
        public IList<MTuanDuiJieSuanInfo> GetTuanDuiJieSuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MTuanDuiJieSuanChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M, 0, 0 };
            IList<MTuanDuiJieSuanInfo> items = new List<MTuanDuiJieSuanInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_TuanDuiJieSuan";
            string orderByString = " QuDate DESC ";
            string sumString = "SUM(ShouRuJinE) AS ShouRuJinEHeJi,SUM(QiTaShouRuJinE) AS QiTaShouRuJinEHeJi,SUM(ZhiChuJinE) AS ZhiChuJinEHeJi,SUM(QiTaZhiChuJinE) AS QiTaZhiChuJinEHeJi,SUM(ShuLiang) AS ShuLiangHeJi,SUM(ZhanWeiShuLiang) AS ZhanWeiShuLiangHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (chaXun.EQuDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.EQuDate.Value.AddDays(1));
                }
                if (chaXun.SQuDate.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.SQuDate.Value.AddDays(-1));
                }
                if (chaXun.AreaId.HasValue && chaXun.AreaId.Value > 0)
                {
                    query.AppendFormat(" AND AreaId={0} ", chaXun.AreaId.Value);
                }

                if (chaXun.QuJiaoTongId.HasValue && chaXun.QuJiaoTongId.Value > 0)
                {
                    query.AppendFormat(" AND QuJiaoTongId={0} ", chaXun.QuJiaoTongId.Value);
                }

                if (chaXun.QuDepProvinceId.HasValue && chaXun.QuDepProvinceId.Value > 0)
                {
                    query.AppendFormat(" AND QuDepProvinceId={0} ", chaXun.QuDepProvinceId.Value);
                }

                if (chaXun.QuDepCityId.HasValue && chaXun.QuDepCityId.Value > 0)
                {
                    query.AppendFormat(" AND QuDepCityId={0} ", chaXun.QuDepCityId.Value);
                }

                if (chaXun.QuArrProvinceId.HasValue && chaXun.QuArrProvinceId.Value > 0)
                {
                    query.AppendFormat(" AND QuArrProvinceId={0} ", chaXun.QuArrProvinceId.Value);
                }

                if (chaXun.QuArrCityId.HasValue && chaXun.QuArrCityId.Value > 0)
                {
                    query.AppendFormat(" AND QuArrCityId={0} ", chaXun.QuArrCityId.Value);
                }
                if (chaXun.KongWeiZhuangTai.HasValue)
                {
                    query.AppendFormat(" AND KongWeiZhuangTai={0} ", (int)chaXun.KongWeiZhuangTai.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }

            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MTuanDuiJieSuanInfo();

                    item.AreaName = rdr["AreaName"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.KongWeiId = rdr.GetString(rdr.GetOrdinal("KongWeiId"));
                    item.KongWeiType = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("KongWeiType"));
                    item.QiTaShouRuJinE = rdr.GetDecimal(rdr.GetOrdinal("QiTaShouRuJinE"));
                    item.QiTaZhiChuJinE = rdr.GetDecimal(rdr.GetOrdinal("QiTaZhiChuJinE"));
                    item.QuArrCityName = rdr["QuArrCityName"].ToString();
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.QuDepCityName = rdr["QuDepCityName"].ToString();
                    item.QuJiaoTongName = rdr["QuJiaoTongName"].ToString();
                    item.ShouRuJinE = rdr.GetDecimal(rdr.GetOrdinal("ShouRuJinE"));
                    item.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    item.ZhanWeiShuLiang = rdr.GetInt32(rdr.GetOrdinal("ZhanWeiShuLiang"));
                    item.ZhiChuJinE = rdr.GetDecimal(rdr.GetOrdinal("ZhiChuJinE"));
                    item.KongWeiZhuangTai = (EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)rdr.GetByte(rdr.GetOrdinal("KongWeiZhuangTai"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShouRuJinEHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("ShouRuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QiTaShouRuJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("QiTaShouRuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhiChuJinEHeJi"))) heJi[2] = rdr.GetDecimal(rdr.GetOrdinal("ZhiChuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QiTaZhiChuJinEHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("QiTaZhiChuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShuLiangHeJi"))) heJi[4] = rdr.GetInt32(rdr.GetOrdinal("ShuLiangHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhanWeiShuLiangHeJi"))) heJi[5] = rdr.GetInt32(rdr.GetOrdinal("ZhanWeiShuLiangHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取催款单集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MCuiKuanDanInfo> GetCuiKuanDans(int companyId, MCuiKuanDanChaXunInfo chaXun)
        {
            IList<MCuiKuanDanInfo> items = new List<MCuiKuanDanInfo>();

            #region sql
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT A.OrderId,A.OrderCode,A.QuDate ");
            sql.Append(" ,A.BuyOperatorName AS KeHuLxrName ");
            sql.Append(" ,A.RouteName ");
            sql.Append(" ,A.SumPrice AS JinE ");
            sql.Append(" ,A.CheckMoney AS YiShouJinE ");
            sql.Append(" ,A.ReturnMoney AS YiTuiJinE ");
            sql.Append(" ,A.Adults,A.Childs,A.Bears,A.YingErRenShu ");
            sql.Append(" ,A.PriceDetials,A.BusinessType,A.JiaGeMingXi ");
            sql.Append(" ,(SELECT TOP 1 A1.TravellerName FROM tbl_TourOrderTraveller AS A1 WHERE A1.OrderId=A.OrderId ORDER BY SortId ASC) AS YouKeName ");
            sql.Append(" FROM view_TourOrder AS A ");
            sql.Append(" WHERE A.CompanyId=@CompanyId AND A.ZxsId=@ZxsId AND A.BuyCompanyId=@KeHuId ");
            sql.Append(" AND A.SumPrice-A.CheckMoney+A.ReturnMoney<>0 ");
            sql.AppendFormat(" AND A.OrderStatus={0} ", (int)EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交);

            if (chaXun.QuDate1.HasValue)
            {
                sql.AppendFormat(" AND A.QuDate>'{0}' ", chaXun.QuDate1.Value.AddDays(-1));
            }
            if (chaXun.QuDate2.HasValue)
            {
                sql.AppendFormat(" AND A.QuDate<'{0}' ", chaXun.QuDate2.Value.AddDays(1));
            }
            if (chaXun.KeHuLxrId.HasValue)
            {
                sql.AppendFormat(" AND A.BuyOperatorId={0} ", chaXun.KeHuLxrId.Value);
            }

            sql.Append(" ORDER BY A.IssueTime ASC ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, chaXun.ZxsId);
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, chaXun.KeHuId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MCuiKuanDanInfo();

                    item.ChengRenShu = rdr.GetInt32(rdr.GetOrdinal("Adults"));
                    item.DingDanHao = rdr["OrderCode"].ToString();
                    item.ErTongShu = rdr.GetInt32(rdr.GetOrdinal("Childs"));
                    item.JiaGeMingXi = rdr["PriceDetials"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.QuanPeiShu = rdr.GetInt32(rdr.GetOrdinal("Bears"));
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.RouteName = rdr["RouteName"].ToString();
                    item.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("BusinessType"));
                    item.YingErShu = rdr.GetInt32(rdr.GetOrdinal("YingErRenShu"));
                    item.YiShouJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShouJinE"))-rdr.GetDecimal(rdr.GetOrdinal("YiTuiJinE"));
                    item.YouKeName = rdr["YouKeName"].ToString();
                    item.KeHuLxrName = rdr["KeHuLxrName"].ToString();
                    item.JiaGeMingXi1 = rdr["JiaGeMingXi"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion
    }
}
