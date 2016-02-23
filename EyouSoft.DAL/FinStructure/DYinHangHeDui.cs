//银行核对相关信息数据访问类 汪奇志 2012-11-19
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

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 银行核对相关信息数据访问类
    /// </summary>
    public class DYinHangHeDui : DALBase, IYinHangHeDui
    {
        #region static constants
        //static constants
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_FinYinHangHeDuiMx] WHERE [HeDuiId]=@HeDuiId;DELETE FROM [tbl_FinYinHangHeDui] WHERE [HeDuiId]=@HeDuiId AND [CompanyId]=@CompanyId";
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_FinYinHangHeDui] WHERE [HeDuiId]=@HeDuiId";
        const string SQL_SELECT_GetYinHangHeDuiZhangHus = "SELECT * FROM [tbl_FinYinHangHeDuiMx] WHERE [HeDuiId]=@HeDuiId";
        const string SQL_SELECT_GetStatus = "SELECT [Status] FROM [tbl_FinYinHangHeDui] WHERE [HeDuiId]=@HeDuiId";
        const string SQL_UPDATE_QueRen = "UPDATE [tbl_FinYinHangHeDui] SET [SheHeOperatorId]=@OperatorId,[ShenHeTime]=@OperatorTime,[Status]=@Status WHERE [HeDuiId]=@HeDuiId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DYinHangHeDui()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 创建银行核对账户XML
        /// </summary>
        /// <param name="items">items</param>
        /// <returns></returns>
        string CreateYinHangZhangHuXml(IList<MYinHangHeDuiZhangHuInfo> items)
        {
            //XML:<root><info ZhangHuId="银行账户编号" YuE="余额(业务日期前一天)" JieFangJinE="借方金额(业务日期)" DaiFangJinE="贷方金额(业务日期)" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info ZhangHuId=\"{0}\" YuE=\"{1}\" JieFangJinE=\"{2}\" DaiFangJinE=\"{3}\" />", item.ZhangHuId
                    , item.YuE
                    , item.JieFangJinE
                    , item.DaiFangJinE);
            }
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// 获取银行核对账户信息集合
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <returns></returns>
        IList<MYinHangHeDuiZhangHuInfo> GetYinHangHeDuiZhangHus(string heDuiId)
        {
            IList<MYinHangHeDuiZhangHuInfo> items = new List<MYinHangHeDuiZhangHuInfo>();

            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetYinHangHeDuiZhangHus);
            _db.AddInParameter(cmd, "HeDuiId", DbType.AnsiStringFixedLength, heDuiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MYinHangHeDuiZhangHuInfo();
                    item.DaiFangJinE = rdr.GetDecimal(rdr.GetOrdinal("DaiFangJinE"));
                    item.JieFangJinE = rdr.GetDecimal(rdr.GetOrdinal("JieFangJinE"));
                    item.YuE = rdr.GetDecimal(rdr.GetOrdinal("YuE"));
                    item.ZhangHuId = rdr.GetString(rdr.GetOrdinal("ZhangHuId"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region EyouSoft.IDAL.FinStructure.IYinHangHeDui 成员
        /// <summary>
        /// 写入银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MYinHangHeDuiInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_YinHangHeDui_Insert");
            _db.AddInParameter(cmd, "HeDuiId", DbType.AnsiStringFixedLength, info.HeDuiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "YeWuRiQi", DbType.DateTime, info.YeWuRiQi);
            _db.AddInParameter(cmd, "JieFangZongE", DbType.Decimal, info.JieFangZongE);
            _db.AddInParameter(cmd, "DaiFangZongE", DbType.Decimal, info.DaiFangZongE);
            _db.AddInParameter(cmd, "LiuShuiZongE", DbType.Decimal, info.LiuShuiZongE);
            _db.AddInParameter(cmd, "YinHangZongE", DbType.Decimal, info.YinHangZongE);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus.未确认);
            _db.AddInParameter(cmd, "ZhangHuXml", DbType.String, CreateYinHangZhangHuXml(info.ZhangHus));
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

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
        /// 修改银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MYinHangHeDuiInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_YinHangHeDui_Update");
            _db.AddInParameter(cmd, "HeDuiId", DbType.AnsiStringFixedLength, info.HeDuiId);
            _db.AddInParameter(cmd, "YeWuRiQi", DbType.DateTime, info.YeWuRiQi);
            _db.AddInParameter(cmd, "JieFangZongE", DbType.Decimal, info.JieFangZongE);
            _db.AddInParameter(cmd, "DaiFangZongE", DbType.Decimal, info.DaiFangZongE);
            _db.AddInParameter(cmd, "LiuShuiZongE", DbType.Decimal, info.LiuShuiZongE);
            _db.AddInParameter(cmd, "YinHangZongE", DbType.Decimal, info.YinHangZongE);
            _db.AddInParameter(cmd, "ZhangHuXml", DbType.String, CreateYinHangZhangHuXml(info.ZhangHus));
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

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
        /// 删除银行核对信息，返回1成功，其它失败
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string heDuiId, int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "HeDuiId", DbType.AnsiStringFixedLength, heDuiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取银行核对信息
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <returns></returns>
        public MYinHangHeDuiInfo GetInfo(string heDuiId)
        {
            MYinHangHeDuiInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "HeDuiId", DbType.AnsiStringFixedLength, heDuiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MYinHangHeDuiInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DaiFangZongE = rdr.GetDecimal(rdr.GetOrdinal("DaiFangZongE"));
                    info.HeDuiId = heDuiId;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieFangZongE = rdr.GetDecimal(rdr.GetOrdinal("JieFangZongE"));
                    info.LiuShuiZongE = rdr.GetDecimal(rdr.GetOrdinal("LiuShuiZongE"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("SheHeOperatorId"))) info.ShenHeOperatorId = rdr.GetInt32(rdr.GetOrdinal("SheHeOperatorId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenHeTime"))) info.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ShenHeTime"));
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.YeWuRiQi = rdr.GetDateTime(rdr.GetOrdinal("YeWuRiQi"));
                    info.YinHangZongE = rdr.GetDecimal(rdr.GetOrdinal("YinHangZongE"));
                    info.ZhangHus = null;
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            if (info != null) info.ZhangHus = GetYinHangHeDuiZhangHus(heDuiId);

            return info;
        }

        /// <summary>
        /// 获取银行核对状态
        /// </summary>
        /// <param name="heDuiId">银行核对编号</param>
        /// <returns></returns>
        public EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus GetStatus(string heDuiId)
        {
            EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus status = EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus.已确认;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetStatus);
            _db.AddInParameter(cmd, "HeDuiId", DbType.AnsiStringFixedLength, heDuiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    status = (EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus)rdr.GetByte(0);
                }
            }

            return status;
        }

        /// <summary>
        /// 获取银行核对信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<MYinHangHeDuiInfo> GetHeDuis(int companyId, int pageSize, int pageIndex, ref int recordCount, MYinHangHeDuiChaXunInfo chaXun)
        {
            IList<MYinHangHeDuiInfo> items = new List<MYinHangHeDuiInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_FinYinHangHeDui";
            string orderByString = " YeWuRiQi DESC ";
            string sumString = string.Empty;

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (chaXun.EYeWuRiQi.HasValue)
                {
                    query.AppendFormat(" AND YeWuRiQi<'{0}' ", chaXun.EYeWuRiQi.Value.AddDays(1));
                }
                if (chaXun.SYeWuRiQi.HasValue)
                {
                    query.AppendFormat(" AND YeWuRiQi>'{0}' ", chaXun.SYeWuRiQi.Value.AddDays(-1));
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
                    var item = new MYinHangHeDuiInfo();

                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.DaiFangZongE = rdr.GetDecimal(rdr.GetOrdinal("DaiFangZongE"));
                    item.HeDuiId = rdr.GetString(rdr.GetOrdinal("HeDuiId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JieFangZongE = rdr.GetDecimal(rdr.GetOrdinal("JieFangZongE"));
                    item.LiuShuiZongE = rdr.GetDecimal(rdr.GetOrdinal("LiuShuiZongE"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("SheHeOperatorId"))) item.ShenHeOperatorId = rdr.GetInt32(rdr.GetOrdinal("SheHeOperatorId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenHeTime"))) item.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ShenHeTime"));
                    item.Status = (EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.YeWuRiQi = rdr.GetDateTime(rdr.GetOrdinal("YeWuRiQi"));
                    item.YinHangZongE = rdr.GetDecimal(rdr.GetOrdinal("YinHangZongE"));
                    item.ZxsId = rdr["ZxsId"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 银行核对信息确认
        /// </summary>
        /// <param name="heDuiId">银行核对登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QueRen(string heDuiId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_QueRen);

            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.YinHangHeDuiStatus.已确认);
            _db.AddInParameter(cmd, "HeDuiId", DbType.AnsiStringFixedLength, heDuiId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        #endregion
    }
}
