//财务管理借款相关数据访问类 汪奇志 2012-11-19
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
    /// 财务管理借款相关数据访问类
    /// </summary>
    public class DJieKuan : DALBase, IJieKuan
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_FinLoan]([Id],[CompanyId],[LoanerId],[LoanTime],[LoanRemark],[Status],[OperatorId],[IssueTime],[JinE],[ZxsId]) VALUES (@Id,@CompanyId,@LoanerId,@LoanTime,@LoanRemark,@Status,@OperatorId,@IssueTime,@JinE,@ZxsId)";
        const string SQL_UPDATE_Update = "UPDATE [tbl_FinLoan] SET [JinE]=@JinE,[LoanerId]=@LoanerId,[LoanTime]=@LoanTime,[LoanRemark]=@LoanRemark WHERE [Id]=@Id";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_FinLoan] WHERE [Id]=@Id AND CompanyId=@CompanyId";
        const string SQL_SELECT_GetStatus = "SELECT [Status] FROM [tbl_FinLoan] WHERE Id=@JieKuanId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJieKuan()
        {
            _db = SystemStore;
        }
        #endregion
        
        #region EyouSoft.IDAL.FinStructure.IJieKuan 成员
        /// <summary>
        /// 写入借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MJieKuanInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.JieKuanId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "LoanerId", DbType.Int32, info.JieKuanRenId);
            _db.AddInParameter(cmd, "LoanTime", DbType.DateTime, info.JieKuanRiQi);
            _db.AddInParameter(cmd, "LoanRemark", DbType.String, info.JieKuanYuanYin);
            _db.AddInParameter(cmd, "Status", DbType.Byte, JieKuanStatus.未审批);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 修改借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MJieKuanInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.JieKuanId);
            _db.AddInParameter(cmd, "LoanerId", DbType.Int32, info.JieKuanRenId);
            _db.AddInParameter(cmd, "LoanTime", DbType.DateTime, info.JieKuanRiQi);
            _db.AddInParameter(cmd, "LoanRemark", DbType.String, info.JieKuanYuanYin);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 删除借款信息，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string jieKuanId, int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, jieKuanId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取借款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:借款金额] [1:decimal:归还金额]</param>
        /// <returns></returns>
        public IList<MJieKuanInfo> GetJieKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MJieKuanChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M };
            IList<MJieKuanInfo> items = new List<MJieKuanInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_FinLoan";
            string orderByString = " LoanTime DESC ";
            string sumString = "SUM(JinE) AS JieKuanJinEHeJi,SUM(ReturnAmount) AS GuiHuanJinEHeJi";

            fields.Append(" Id,LoanTime,JinE,LoanRemark,Status,ReturnTime,ReturnAmount ");
            fields.Append(" ,(SELECT A.ContactName FROM tbl_CompanyUser AS A WHERE A.Id=tbl_FinLoan.LoanerId) AS JieKuanRenName ");

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (chaXun.ERiQi.HasValue)
                {
                    query.AppendFormat(" AND LoanTime<'{0}' ", chaXun.ERiQi.Value.AddDays(1));
                }
                if (chaXun.JieKuanRenId.HasValue)
                {
                    query.AppendFormat(" AND LoanerId={0} ", chaXun.JieKuanRenId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.JieKuanRenName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_CompanyUser AS A WHERE A.Id=tbl_FinLoan.LoanerId AND A.ContactName LIKE '%{0}%') ", chaXun.JieKuanRenName);
                }
                if (chaXun.SRiQi.HasValue)
                {
                    query.AppendFormat(" AND LoanTime>'{0}' ", chaXun.SRiQi.Value.AddDays(-1));
                }
                if (chaXun.Status.HasValue)
                {
                    query.AppendFormat(" AND Status={0} ", (int)chaXun.Status.Value);
                }
                if (chaXun.JieKuanJinEOperator != QueryOperator.None && chaXun.JieKuanJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.JieKuanJinEOperator);
                    query.AppendFormat(" AND JinE {0} {1} ", _operator, chaXun.JieKuanJinE.Value);
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
                    var item = new MJieKuanInfo();

                    item.JieKuanId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.CompanyId = companyId;
                    item.JieKuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("LoanTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.JieKuanYuanYin = rdr["LoanRemark"].ToString();
                    item.JieKuanRenName = rdr["JieKuanRenName"].ToString();
                    item.Status = (JieKuanStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ReturnTime"))) item.GuiHuanTime = rdr.GetDateTime(rdr.GetOrdinal("ReturnTime"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JieKuanJinEHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("JieKuanJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("GuiHuanJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("GuiHuanJinEHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取借款信息实体
        /// </summary>
        /// <param name="jieKuanId">借款编号</param>
        /// <returns></returns>
        public MJieKuanInfo GetInfo(string jieKuanId)
        {
            MJieKuanInfo info = null;
            StringBuilder s = new StringBuilder();
            s.Append(" SELECT A.* ");
            s.Append(" ,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.Id=A.LoanerId) AS JieKuanRenName ");
            s.Append(" ,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.Id=A.ApproverId) AS ShenPiRenName ");
            s.Append(" ,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.Id=A.PayId) AS ZhiFuRenName ");
            s.Append(" ,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.Id=A.ReturnId) AS GuiHuanRenName ");
            s.Append(" FROM [tbl_FinLoan] AS A WHERE A.[Id]=@JieKuanId");

            DbCommand cmd = _db.GetSqlStringCommand(s.ToString());
            _db.AddInParameter(cmd, "JieKuanId", DbType.AnsiStringFixedLength, jieKuanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MJieKuanInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayBankDate"))) info.FuKuanBankDate = rdr.GetDateTime(rdr.GetOrdinal("PayBankDate"));
                    info.FuKuanZhangHuId = rdr["PayBankId"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ReturnBankDate"))) info.GuiHuanBankDate = rdr.GetDateTime(rdr.GetOrdinal("ReturnBankDate"));
                    info.GuiHuanBeiZhu = rdr["ReturnRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ReturnId"))) info.GuiHuanOperatorId = rdr.GetInt32(rdr.GetOrdinal("ReturnId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ReturnTime"))) info.GuiHuanTime = rdr.GetDateTime(rdr.GetOrdinal("ReturnTime"));
                    info.GuiHuanZhangHuId = rdr["ReturnBankId"].ToString();
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieKuanId = jieKuanId;
                    info.JieKuanRenId = rdr.GetInt32(rdr.GetOrdinal("LoanerId"));
                    info.JieKuanRenName = rdr["JieKuanRenName"].ToString();
                    info.JieKuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("LoanTime"));
                    info.JieKuanYuanYin = rdr["LoanRemark"].ToString();
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ShenHeBeiZhu = rdr["ApproveRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproverId"))) info.ShenHeRenId = rdr.GetInt32(rdr.GetOrdinal("ApproverId"));
                    info.ShenHeRenName = rdr["ShenPiRenName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproveTime"))) info.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ApproveTime"));
                    info.Status = (JieKuanStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.ZhiFuBeiZhu = rdr["PayRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayId"))) info.ZhiFuRenId = rdr.GetInt32(rdr.GetOrdinal("PayId"));
                    info.ZhiFuRenName = rdr["ZhiFuRenName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayTime"))) info.ZhiFuTime = rdr.GetDateTime(rdr.GetOrdinal("PayTime"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取借款状态
        /// </summary>
        /// <param name="jieKuanId">借款编号</param>
        /// <returns></returns>
        public EyouSoft.Model.EnumType.FinStructure.JieKuanStatus GetStatus(string jieKuanId)
        {
            JieKuanStatus status = JieKuanStatus.未通过;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetStatus);
            _db.AddInParameter(cmd, "JieKuanId", DbType.AnsiStringFixedLength, jieKuanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    status = (JieKuanStatus)rdr.GetByte(0);
                }
            }

            return status;
        }

        /// <summary>
        /// 借款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ShenPi(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_JieKuan_SetStatus");
            _db.AddInParameter(cmd, "JieKuanId", DbType.AnsiStringFixedLength, jieKuanId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, DBNull.Value);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, DBNull.Value);
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
        /// 借款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int ZhiFu(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info, string zhangHuId, DateTime bankDate)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_JieKuan_SetStatus");
            _db.AddInParameter(cmd, "JieKuanId", DbType.AnsiStringFixedLength, jieKuanId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, zhangHuId);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, bankDate);
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
        /// 借款归还，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int GuiHuan(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info, string zhangHuId, DateTime bankDate)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_JieKuan_SetStatus");
            _db.AddInParameter(cmd, "JieKuanId", DbType.AnsiStringFixedLength, jieKuanId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, zhangHuId);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, bankDate);
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
        /// 取消归还，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoGuiHuan(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_JieKuan_SetStatus");
            _db.AddInParameter(cmd, "JieKuanId", DbType.AnsiStringFixedLength, jieKuanId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, DBNull.Value);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, DBNull.Value);
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
        /// 取消支付，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoZhiFu(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_JieKuan_SetStatus");
            _db.AddInParameter(cmd, "JieKuanId", DbType.AnsiStringFixedLength, jieKuanId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, DBNull.Value);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, DBNull.Value);
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
        /// 取消审批，返回1成功，其它失败
        /// </summary>
        /// <param name="jieKuanId">借款登记编号</param>
        /// <param name="status">借款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string jieKuanId, EyouSoft.Model.EnumType.FinStructure.JieKuanStatus status, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_JieKuan_SetStatus");
            _db.AddInParameter(cmd, "JieKuanId", DbType.AnsiStringFixedLength, jieKuanId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, DBNull.Value);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, DBNull.Value);
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
        #endregion
    }
}
