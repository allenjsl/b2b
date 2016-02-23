//财务管理-工资管理相关数据访问类 汪奇志 2013-08-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Toolkit.DAL;
using EyouSoft.IDAL.FinStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 财务管理-工资管理相关数据访问类
    /// </summary>
    public class DGongZi : DALBase, IGongZi
    {
        #region static constants
        //static constants
        const string SQL_SELECT_IsExists = "SELECT COUNT(*) FROM [tbl_FinGongZi] WHERE [IsDelete]='0' AND [CompanyId]=@CompanyId AND [YuanGongId]=@YuanGongId AND [Year]=@Year AND [Month]=@Month AND FaFangLeiXing=@FaFangLeiXing AND ZxsId=@ZxsId";
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_FinGongZi]([GongZiId],[CompanyId],[YuanGongId],[Year],[Month],[YMD],[JiBenGongZi],[GongLingBuTie],[ShengHuoFeiBuTie],[SheBaoBuTie],[GangWeiBuTie],[JiDuJiangJin],[SheBaoKouChu],[GongZiHeJi],[ShengHuoFeiKouChu],[ShengHuoFeiBeiZhu],[ChiDaoKouChu],[ChiDaoBeiZhu],[QiTaKouChu],[QiTaBeiZhu],[JiDuJiangJinBeiZhu],[ShiFaGongZi],[BeiZhu],[Status],[ShenHeOperatorId],[ShenHeTime],[ShenHeBeiZhu],[ZhiFuOperatorId],[ZhiFuTime],[ZhiFuBeiZhu],[ZhangHuId],[YingHangTime],[FaFangTime],[OperatorId],[IssueTime],[IsDelete],[FaFangLeiXing],[ZxsId]) VALUES (@GongZiId,@CompanyId,@YuanGongId,@Year,@Month,@YMD,@JiBenGongZi,@GongLingBuTie,@ShengHuoFeiBuTie,@SheBaoBuTie,@GangWeiBuTie,@JiDuJiangJin,@SheBaoKouChu,@GongZiHeJi,@ShengHuoFeiKouChu,@ShengHuoFeiBeiZhu,@ChiDaoKouChu,@ChiDaoBeiZhu,@QiTaKouChu,@QiTaBeiZhu,@JiDuJiangJinBeiZhu,@ShiFaGongZi,@BeiZhu,@Status,@ShenHeOperatorId,@ShenHeTime,@ShenHeBeiZhu,@ZhiFuOperatorId,@ZhiFuTime,@ZhiFuBeiZhu,@ZhangHuId,@YingHangTime,@FaFangTime,@OperatorId,@IssueTime,@IsDelete,@FaFangLeiXing,@ZxsId)";
        const string SQL_UPDATE_Update = "UPDATE [tbl_FinGongZi] SET [YuanGongId]=@YuanGongId,[Year]=@Year,[Month]=@Month,[YMD]=@YMD,[JiBenGongZi]=@JiBenGongZi,[GongLingBuTie]=@GongLingBuTie,[ShengHuoFeiBuTie]=@ShengHuoFeiBuTie,[SheBaoBuTie]=@SheBaoBuTie,[GangWeiBuTie]=@GangWeiBuTie,[JiDuJiangJin]=@JiDuJiangJin,[SheBaoKouChu]=@SheBaoKouChu,[GongZiHeJi]=@GongZiHeJi,[ShengHuoFeiKouChu]=@ShengHuoFeiKouChu,[ShengHuoFeiBeiZhu]=@ShengHuoFeiBeiZhu,[ChiDaoKouChu]=@ChiDaoKouChu,[ChiDaoBeiZhu]=@ChiDaoBeiZhu,[QiTaKouChu]=@QiTaKouChu,[QiTaBeiZhu]=@QiTaBeiZhu,[JiDuJiangJinBeiZhu]=@JiDuJiangJinBeiZhu,[ShiFaGongZi]=@ShiFaGongZi,[BeiZhu]=@BeiZhu,[FaFangTime]=@FaFangTime,[FaFangLeiXing]=@FaFangLeiXing WHERE [GongZiId]=@GongZiId";
        const string SQL_UPDATE_Delete = "UPDATE [tbl_FinGongZi] SET [IsDelete]='1' WHERE [CompanyId]=@CompanyId AND [GongZiId]=@GongZiId";
        const string SQL_SELECT_GetInfo = "SELECT *,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.[Id]=tbl_FinGongZi.YuanGongId) AS YuanGongName,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.[Id]=tbl_FinGongZi.ShenHeOperatorId) AS ShenHeOperatorName,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.[Id]=tbl_FinGongZi.ZhiFuOperatorId) AS ZhiFuOperatorName FROM [tbl_FinGongZi] WHERE [GongZiId]=@GongZiId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DGongZi()
        {
            _db = SystemStore;
        }
        #endregion

        #region IGongZi 成员
        /// <summary>
        /// 是否存在相同的工资年月份信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yuanGongId">员工编号</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="gongZiId">工资编号</param>
        /// <param name="faFangLeiXing">工资发放类型</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public bool IsExists(int companyId, int yuanGongId, int year, int month, string gongZiId, EyouSoft.Model.EnumType.FinStructure.GongZiFaFangLeiXing faFangLeiXing,string zxsId)
        {
            string sql = SQL_SELECT_IsExists;
            if (!string.IsNullOrEmpty(gongZiId)) sql += " AND [GongZiId]<>@GongZiId ";

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "YuanGongId", DbType.Int32, yuanGongId);
            _db.AddInParameter(cmd, "Year", DbType.Int32, year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, month);
            _db.AddInParameter(cmd, "FaFangLeiXing", DbType.Byte, faFangLeiXing);
            if (!string.IsNullOrEmpty(gongZiId)) _db.AddInParameter(cmd, "GongZiId", DbType.AnsiStringFixedLength, gongZiId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetInt32(0) == 1;
                }
            }

            return false;
        }

        /// <summary>
        /// 写入工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MGongZiInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);
            _db.AddInParameter(cmd, "GongZiId", DbType.AnsiStringFixedLength, info.GongZiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "YuanGongId", DbType.Int32, info.YuanGongId);
            _db.AddInParameter(cmd, "Year", DbType.Int32, info.Year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, info.Month);
            _db.AddInParameter(cmd, "YMD", DbType.DateTime, new DateTime(info.Year, info.Month, 1));
            _db.AddInParameter(cmd, "JiBenGongZi", DbType.Decimal, info.JiBenGongZi);
            _db.AddInParameter(cmd, "GongLingBuTie", DbType.Decimal, info.GongLingBuTie);
            _db.AddInParameter(cmd, "ShengHuoFeiBuTie", DbType.Decimal, info.ShengHuoFeiBuTie);
            _db.AddInParameter(cmd, "SheBaoBuTie", DbType.Decimal, info.SheBaoBuTie);
            _db.AddInParameter(cmd, "GangWeiBuTie", DbType.Decimal, info.GangWeiBuTie);
            _db.AddInParameter(cmd, "JiDuJiangJin", DbType.Decimal, info.JiDuJiangJin);
            _db.AddInParameter(cmd, "SheBaoKouChu", DbType.Decimal, info.SheBaoKouChu);
            _db.AddInParameter(cmd, "GongZiHeJi", DbType.Decimal, info.GongZiHeJi);
            _db.AddInParameter(cmd, "ShengHuoFeiKouChu", DbType.Decimal, info.ShengHuoFeiKouChu);
            _db.AddInParameter(cmd, "ShengHuoFeiBeiZhu", DbType.String, info.ShengHuoFeiBeiZhu);
            _db.AddInParameter(cmd, "ChiDaoKouChu", DbType.Decimal, info.ChiDaoKouChu);
            _db.AddInParameter(cmd, "ChiDaoBeiZhu", DbType.String, info.ChiDaoBeiZhu);
            _db.AddInParameter(cmd, "QiTaKouChu", DbType.Decimal, info.QiTaKouChu);
            _db.AddInParameter(cmd, "QiTaBeiZhu", DbType.String, info.QiTaBeiZhu);
            _db.AddInParameter(cmd, "JiDuJiangJinBeiZhu", DbType.String, info.JiDuJiangJinBeiZhu);
            _db.AddInParameter(cmd, "ShiFaGongZi", DbType.Decimal, info.ShiFaGongZi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "ShenHeOperatorId", DbType.Int32, DBNull.Value);
            _db.AddInParameter(cmd, "ShenHeTime", DbType.DateTime, DBNull.Value);
            _db.AddInParameter(cmd, "ShenHeBeiZhu", DbType.String, DBNull.Value);
            _db.AddInParameter(cmd, "ZhiFuOperatorId", DbType.Int32, DBNull.Value);
            _db.AddInParameter(cmd, "ZhiFuTime", DbType.DateTime, DBNull.Value);
            _db.AddInParameter(cmd, "ZhiFuBeiZhu", DbType.String, DBNull.Value);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, DBNull.Value);
            _db.AddInParameter(cmd, "YingHangTime", DbType.DateTime, DBNull.Value);
            _db.AddInParameter(cmd, "FaFangTime", DbType.DateTime, info.FaFangTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "IsDelete", DbType.AnsiStringFixedLength, "0");
            _db.AddInParameter(cmd, "FaFangLeiXIng", DbType.Byte, info.FaFangLeiXing);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 修改工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MGongZiInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);
            _db.AddInParameter(cmd, "GongZiId", DbType.AnsiStringFixedLength, info.GongZiId);
            _db.AddInParameter(cmd, "YuanGongId", DbType.Int32, info.YuanGongId);
            _db.AddInParameter(cmd, "Year", DbType.Int32, info.Year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, info.Month);
            _db.AddInParameter(cmd, "YMD", DbType.DateTime, new DateTime(info.Year, info.Month, 1));
            _db.AddInParameter(cmd, "JiBenGongZi", DbType.Decimal, info.JiBenGongZi);
            _db.AddInParameter(cmd, "GongLingBuTie", DbType.Decimal, info.GongLingBuTie);
            _db.AddInParameter(cmd, "ShengHuoFeiBuTie", DbType.Decimal, info.ShengHuoFeiBuTie);
            _db.AddInParameter(cmd, "SheBaoBuTie", DbType.Decimal, info.SheBaoBuTie);
            _db.AddInParameter(cmd, "GangWeiBuTie", DbType.Decimal, info.GangWeiBuTie);
            _db.AddInParameter(cmd, "JiDuJiangJin", DbType.Decimal, info.JiDuJiangJin);
            _db.AddInParameter(cmd, "SheBaoKouChu", DbType.Decimal, info.SheBaoKouChu);
            _db.AddInParameter(cmd, "GongZiHeJi", DbType.Decimal, info.GongZiHeJi);
            _db.AddInParameter(cmd, "ShengHuoFeiKouChu", DbType.Decimal, info.ShengHuoFeiKouChu);
            _db.AddInParameter(cmd, "ShengHuoFeiBeiZhu", DbType.String, info.ShengHuoFeiBeiZhu);
            _db.AddInParameter(cmd, "ChiDaoKouChu", DbType.Decimal, info.ChiDaoKouChu);
            _db.AddInParameter(cmd, "ChiDaoBeiZhu", DbType.String, info.ChiDaoBeiZhu);
            _db.AddInParameter(cmd, "QiTaKouChu", DbType.Decimal, info.QiTaKouChu);
            _db.AddInParameter(cmd, "QiTaBeiZhu", DbType.String, info.QiTaBeiZhu);
            _db.AddInParameter(cmd, "JiDuJiangJinBeiZhu", DbType.String, info.JiDuJiangJinBeiZhu);
            _db.AddInParameter(cmd, "ShiFaGongZi", DbType.Decimal, info.ShiFaGongZi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "FaFangTime", DbType.DateTime, info.FaFangTime);
            _db.AddInParameter(cmd, "FaFangLeiXIng", DbType.Byte, info.FaFangLeiXing);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 删除工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gongZiId">工资编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string gongZiId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Delete);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "GongZiId", DbType.AnsiStringFixedLength, gongZiId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 设置工资状态
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <param name="status">状态</param>
        /// <param name="operatorInfo">操作人信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int SetStatus(string gongZiId, EyouSoft.Model.EnumType.FinStructure.GongZiStatus status, MOperatorInfo operatorInfo, string zhangHuId, DateTime? bankDate)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_GongZi_SetStatus");
            _db.AddInParameter(cmd, "GongZiId", DbType.AnsiStringFixedLength, gongZiId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, operatorInfo.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, operatorInfo.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, operatorInfo.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, zhangHuId);
            if (bankDate.HasValue) _db.AddInParameter(cmd, "YingHangTime", DbType.DateTime, bankDate.Value);
            else _db.AddInParameter(cmd, "YingHangTime", DbType.DateTime, DBNull.Value);
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
        /// 获取工资信息业务实体
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <returns></returns>
        public MGongZiInfo GetInfo(string gongZiId)
        {
            MGongZiInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "GongZiId", DbType.String, gongZiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MGongZiInfo();

                    info.BeiZhu = rdr["BeiZhu"].ToString();
                    info.ChiDaoBeiZhu = rdr["ChiDaoBeiZhu"].ToString();
                    info.ChiDaoKouChu = rdr.GetDecimal(rdr.GetOrdinal("ChiDaoKouChu"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.FaFangTime = rdr.GetDateTime(rdr.GetOrdinal("FaFangTime"));
                    info.GangWeiBuTie = rdr.GetDecimal(rdr.GetOrdinal("GangWeiBuTie"));
                    info.GongLingBuTie = rdr.GetDecimal(rdr.GetOrdinal("GongLingBuTie"));
                    info.GongZiHeJi = rdr.GetDecimal(rdr.GetOrdinal("GongZiHeJi"));
                    info.GongZiId = gongZiId;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JiBenGongZi = rdr.GetDecimal(rdr.GetOrdinal("JiBenGongZi"));
                    info.JiDuJiangJin = rdr.GetDecimal(rdr.GetOrdinal("JiDuJiangJin"));
                    info.JiDuJiangJinBeiZhu = rdr["JiDuJiangJinBeiZhu"].ToString();
                    info.Month = rdr.GetInt32(rdr.GetOrdinal("Month"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.QiTaBeiZhu = rdr["QiTaBeiZhu"].ToString();
                    info.QiTaKouChu = rdr.GetDecimal(rdr.GetOrdinal("QiTaKouChu"));
                    info.SheBaoBuTie = rdr.GetDecimal(rdr.GetOrdinal("SheBaoBuTie"));
                    info.SheBaoKouChu = rdr.GetDecimal(rdr.GetOrdinal("SheBaoKouChu"));
                    info.ShengHuoFeiBeiZhu = rdr["ShengHuoFeiBeiZhu"].ToString();
                    info.ShengHuoFeiBuTie = rdr.GetDecimal(rdr.GetOrdinal("ShengHuoFeiBuTie"));
                    info.ShengHuoFeiKouChu = rdr.GetDecimal(rdr.GetOrdinal("ShengHuoFeiKouChu"));
                    info.ShenHeBeiZhu = rdr["ShenHeBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenHeOperatorId"))) info.ShenHeOperatorId = rdr.GetInt32(rdr.GetOrdinal("ShenHeOperatorId"));
                    info.ShenHeOperatorName = rdr["ShenHeOperatorName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenHeTime"))) info.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ShenHeTime"));
                    info.ShiFaGongZi = rdr.GetDecimal(rdr.GetOrdinal("ShiFaGongZi"));
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.GongZiStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.Year = rdr.GetInt32(rdr.GetOrdinal("Year"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingHangTime"))) info.YingHangTime = rdr.GetDateTime(rdr.GetOrdinal("YingHangTime"));
                    info.YMD = rdr.GetDateTime(rdr.GetOrdinal("YMD"));
                    info.YuanGongId = rdr.GetInt32(rdr.GetOrdinal("YuanGongId"));
                    info.YuanGongName = rdr["YuanGongName"].ToString();
                    info.ZhangHuId = rdr["ZhangHuId"].ToString();
                    info.ZhiFuBeiZhu = rdr["ZhiFuBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhiFuOperatorId"))) info.ZhiFuOperatorId = rdr.GetInt32(rdr.GetOrdinal("ZhiFuOperatorId"));
                    info.ZhiFuOperatorName = rdr["ZhiFuOperatorName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhiFuTime"))) info.ZhiFuTime = rdr.GetDateTime(rdr.GetOrdinal("ZhiFuTime"));
                    info.FaFangLeiXing = (EyouSoft.Model.EnumType.FinStructure.GongZiFaFangLeiXing)rdr.GetByte(rdr.GetOrdinal("FaFangLeiXing"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取工资信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息</param>
        /// <returns></returns>
        public IList<MGongZiInfo> GetGongZis(int companyId, int pageSize, int pageIndex, ref int recordCount, MGongZiChaXunInfo chaXun, out MGongZiHeJiInfo heJi)
        {
            heJi = new MGongZiHeJiInfo();
            IList<MGongZiInfo> items = new List<MGongZiInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_FinGongZi";
            string orderByString = " [YMD] DESC ";
            string sumString = "SUM(JiBenGongZi) AS JiBenGongZi,SUM(GongLingBuTie) AS GongLingBuTie";
            sumString += ",SUM(ShengHuoFeiBuTie) AS ShengHuoFeiBuTie,SUM(SheBaoBuTie) AS SheBaoBuTie";
            sumString += ",SUM(GangWeiBuTie) AS GangWeiBuTie,SUM(JiDuJiangJin) AS JiDuJiangJin";
            sumString += ",SUM(SheBaoKouChu) AS SheBaoKouChu,SUM(GongZiHeJi) AS GongZiHeJi";
            sumString += ",SUM(ShengHuoFeiKouChu) AS ShengHuoFeiKouChu,SUM(ChiDaoKouChu) AS ChiDaoKouChu";
            sumString += ",SUM(QiTaKouChu) AS QiTaKouChu,SUM(ShiFaGongZi) AS ShiFaGongZi";

            #region fields
            fields.Append(" GongZiId,YuanGongId,Year,Month,YMD,JiBenGongZi,GongLingBuTie,ShengHuoFeiBuTie,SheBaoBuTie,GangWeiBuTie,JiDuJiangJin,SheBaoKouChu,GongZiHeJi,ShengHuoFeiKouChu,ChiDaoKouChu,QiTaKouChu,ShiFaGongZi,BeiZhu,Status,CompanyId,FaFangTime,IssueTime ");
            fields.Append(" ,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.[Id]=tbl_FinGongZi.YuanGongId) AS YuanGongName ");
            fields.Append(",FaFangLeiXing,ZxsId");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} AND IsDelete='0' ", companyId);
            if (chaXun != null)
            {
                if (chaXun.SMonth.HasValue)
                {
                    query.AppendFormat(" AND Month>={0} ", chaXun.SMonth.Value);
                }
                if (chaXun.SYear.HasValue)
                {
                    query.AppendFormat(" AND Year>={0} ", chaXun.SYear.Value);
                }

                if (chaXun.EMonth.HasValue)
                {
                    query.AppendFormat(" AND Month<={0} ", chaXun.EMonth.Value);
                }
                if (chaXun.EYear.HasValue)
                {
                    query.AppendFormat(" AND Year<={0} ", chaXun.EYear.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.YuanGongName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_CompanyUser AS A WHERE A.Id=tbl_FinGongZi.YuanGongId AND A.ContactName LIKE '%{0}%') ", chaXun.YuanGongName);
                }
                if (chaXun.FaFangLeiXing.HasValue)
                {
                    query.AppendFormat(" AND FaFangLeiXing={0} ", (int)chaXun.FaFangLeiXing.Value);
                }
                if (chaXun.YuanGongId.HasValue)
                {
                    query.AppendFormat(" AND YuanGongId={0} ", (int)chaXun.YuanGongId.Value);
                }
                if (chaXun.Status.HasValue)
                {
                    query.AppendFormat(" AND Status={0} ", (int)chaXun.Status.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new MGongZiInfo();

                    info.BeiZhu = rdr["BeiZhu"].ToString();
                    info.ChiDaoKouChu = rdr.GetDecimal(rdr.GetOrdinal("ChiDaoKouChu"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.FaFangTime = rdr.GetDateTime(rdr.GetOrdinal("FaFangTime"));
                    info.GangWeiBuTie = rdr.GetDecimal(rdr.GetOrdinal("GangWeiBuTie"));
                    info.GongLingBuTie = rdr.GetDecimal(rdr.GetOrdinal("GongLingBuTie"));
                    info.GongZiHeJi = rdr.GetDecimal(rdr.GetOrdinal("GongZiHeJi"));
                    info.GongZiId = rdr["GongZiId"].ToString();
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JiBenGongZi = rdr.GetDecimal(rdr.GetOrdinal("JiBenGongZi"));
                    info.JiDuJiangJin = rdr.GetDecimal(rdr.GetOrdinal("JiDuJiangJin"));
                    info.Month = rdr.GetInt32(rdr.GetOrdinal("Month"));
                    info.QiTaKouChu = rdr.GetDecimal(rdr.GetOrdinal("QiTaKouChu"));
                    info.SheBaoBuTie = rdr.GetDecimal(rdr.GetOrdinal("SheBaoBuTie"));
                    info.SheBaoKouChu = rdr.GetDecimal(rdr.GetOrdinal("SheBaoKouChu"));
                    info.ShengHuoFeiBuTie = rdr.GetDecimal(rdr.GetOrdinal("ShengHuoFeiBuTie"));
                    info.ShengHuoFeiKouChu = rdr.GetDecimal(rdr.GetOrdinal("ShengHuoFeiKouChu"));
                    info.ShiFaGongZi = rdr.GetDecimal(rdr.GetOrdinal("ShiFaGongZi"));
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.GongZiStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.Year = rdr.GetInt32(rdr.GetOrdinal("Year"));
                    info.YMD = rdr.GetDateTime(rdr.GetOrdinal("YMD"));
                    info.YuanGongId = rdr.GetInt32(rdr.GetOrdinal("YuanGongId"));
                    info.YuanGongName = rdr["YuanGongName"].ToString();
                    info.FaFangLeiXing = (EyouSoft.Model.EnumType.FinStructure.GongZiFaFangLeiXing)rdr.GetByte(rdr.GetOrdinal("FaFangLeiXing"));
                    info.ZxsId = rdr["ZxsId"].ToString();

                    items.Add(info);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JiBenGongZi"))) heJi.JiBenGongZi = rdr.GetDecimal(rdr.GetOrdinal("JiBenGongZi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("GongLingBuTie"))) heJi.GongLingBuTie = rdr.GetDecimal(rdr.GetOrdinal("GongLingBuTie"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShengHuoFeiBuTie"))) heJi.ShengHuoFeiBuTie = rdr.GetDecimal(rdr.GetOrdinal("ShengHuoFeiBuTie"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("SheBaoBuTie"))) heJi.SheBaoBuTie = rdr.GetDecimal(rdr.GetOrdinal("SheBaoBuTie"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("GangWeiBuTie"))) heJi.GangWeiBuTie = rdr.GetDecimal(rdr.GetOrdinal("GangWeiBuTie"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JiDuJiangJin"))) heJi.JiDuJiangJin = rdr.GetDecimal(rdr.GetOrdinal("JiDuJiangJin"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("SheBaoKouChu"))) heJi.SheBaoKouChu = rdr.GetDecimal(rdr.GetOrdinal("SheBaoKouChu"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("GongZiHeJi"))) heJi.GongZiHeJi = rdr.GetDecimal(rdr.GetOrdinal("GongZiHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShengHuoFeiKouChu"))) heJi.ShengHuoFeiKouChu = rdr.GetDecimal(rdr.GetOrdinal("ShengHuoFeiKouChu"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChiDaoKouChu"))) heJi.ChiDaoKouChu = rdr.GetDecimal(rdr.GetOrdinal("ChiDaoKouChu"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QiTaKouChu"))) heJi.QiTaKouChu = rdr.GetDecimal(rdr.GetOrdinal("QiTaKouChu"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShiFaGongZi"))) heJi.ShiFaGongZi = rdr.GetDecimal(rdr.GetOrdinal("ShiFaGongZi"));
                }
            }

            return items;
        }

        #endregion
    }
}
