//财务管理-报销管理相关数据访问类 汪奇志 2012-11-19
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
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 财务管理-报销管理相关数据访问类
    /// </summary>
    public class DBaoXiao : DALBase, IBaoXiao
    {
        #region static constants
        //static constants
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_FinApplyDetail] WHERE [Id]=@BaoXiaoId;DELETE FROM [tbl_FinApply] WHERE Id=@BaoXiaoId AND [CompanyId]=@CompanyId";
        const string SQL_SELECT_GetInfo = "SELECT A.*,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.[Id]=A.ApplyerId) AS BaoXiaoRenName,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.[Id]=A.ApproverId) AS ShenPiRenName,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.[Id]=A.PayId) AS ZhiFuRenName FROM [tbl_FinApply] AS A WHERE A.[Id]=@BaoXiaoId";
        const string SQL_SELECT_GetXiaoFeis = "SELECT * FROM [tbl_FinApplyDetail] WHERE [Id]=@BaoXiaoId";        
        const string SQL_SELECT_GetStatus = "SELECT [State] FROM [tbl_FinApply] WHERE [Id]=@BaoXiaoId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DBaoXiao()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 创建报销消费明细XML
        /// </summary>
        /// <param name="items">集合</param>
        /// <returns></returns>
        string CreateXiaFeisXml(IList<EyouSoft.Model.FinStructure.MBaoXiaoXiaoFeiInfo> items)
        {
            //XML:<root><info XiaoFeiRiQi="" JinE="" XiaoFeiType="" XiaoFeiBeiZhu="" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();

            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info XiaoFeiRiQi=\"{0}\" JinE=\"{1}\" XiaoFeiType=\"{2}\" XiaoFeiBeiZhu=\"{3}\" />", item.XiaoFeiRiQi
                    , item.JinE, (int)item.XiaoFeiType, Utils.ReplaceXmlSpecialCharacter(item.XiaoFeiBeiZhu));
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 创建报销消费明细集合
        /// </summary>
        /// <param name="baoXiaoId">报销编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.FinStructure.MBaoXiaoXiaoFeiInfo> GetXiaoFeis(string baoXiaoId)
        {
            IList<EyouSoft.Model.FinStructure.MBaoXiaoXiaoFeiInfo> items = new List<EyouSoft.Model.FinStructure.MBaoXiaoXiaoFeiInfo>();

            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetXiaoFeis);
            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, baoXiaoId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.FinStructure.MBaoXiaoXiaoFeiInfo();

                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("CostAmount"));
                    item.XiaoFeiBeiZhu = rdr["CostRemark"].ToString();
                    item.XiaoFeiRiQi = rdr.GetDateTime(rdr.GetOrdinal("CostDate"));
                    item.XiaoFeiType = (EyouSoft.Model.EnumType.FinStructure.BaoXiaoXiaoFeiType)rdr.GetByte(rdr.GetOrdinal("CostType"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region EyouSoft.IDAL.FinStructure.IBaoXiao 成员
        /// <summary>
        /// 写入报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MBaoXiaoInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_BaoXiao_Insert");

            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, info.BaoXiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "BaoXiaoRiQi", DbType.DateTime, info.BaoXiaoRiQi);
            _db.AddInParameter(cmd, "BaoXiaoRenId", DbType.Int32, info.BaoXiaoRenId);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "MxXml", DbType.String, CreateXiaFeisXml(info.XiaoFeis));
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
        /// 更新报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MBaoXiaoInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_BaoXiao_Update");

            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, info.BaoXiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "BaoXiaoRiQi", DbType.DateTime, info.BaoXiaoRiQi);
            _db.AddInParameter(cmd, "BaoXiaoRenId", DbType.Int32, info.BaoXiaoRenId);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "MxXml", DbType.String, CreateXiaFeisXml(info.XiaoFeis));
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
        /// 删除报销登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string baoXiaoId, int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);

            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, baoXiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取报销登记信息业务实体
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <returns></returns>
        public MBaoXiaoInfo GetInfo(string baoXiaoId)
        {
            MBaoXiaoInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);

            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, baoXiaoId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MBaoXiaoInfo();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("BankDate"))) info.BankDate = rdr.GetDateTime(rdr.GetOrdinal("BankDate"));
                    info.BaoXiaoId = rdr.GetString(rdr.GetOrdinal("Id"));
                    info.BaoXiaoRenId = rdr.GetInt32(rdr.GetOrdinal("ApplyerId"));
                    info.BaoXiaoRenName = rdr["BaoXiaoRenName"].ToString();
                    info.BaoXiaoRiQi = rdr.GetDateTime(rdr.GetOrdinal("ApplyDate"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("ApplyAmount"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ShenHeBeiZhu = rdr["ApproveRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproverId"))) info.ShenHeRenId = rdr.GetInt32(rdr.GetOrdinal("ApproverId"));
                    info.ShenHeRenName = rdr["ShenPiRenName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproveTime"))) info.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ApproveTime"));
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus)rdr.GetByte(rdr.GetOrdinal("State"));
                    info.XiaoFeis = null;
                    info.ZhangHuId = rdr["BankId"].ToString();
                    info.ZhiFuBeiZhu = rdr["PayRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayId"))) info.ZhiFuRenId = rdr.GetInt32(rdr.GetOrdinal("PayId"));
                    info.ZhiFuRenName = rdr["ZhiFuRenName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayTime"))) info.ZhiFuTime = rdr.GetDateTime(rdr.GetOrdinal("PayTime"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            if (info != null)
            {
                info.XiaoFeis = GetXiaoFeis(baoXiaoId);
            }

            return info;
        }

        /// <summary>
        /// 获取报销登记信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息，[0:decimal:报销金额]</param>
        /// <returns></returns>
        public IList<MBaoXiaoInfo> GetBaoXiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MBaoXiaoChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M };
            IList<MBaoXiaoInfo> items = new List<MBaoXiaoInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_FinApply";
            string orderByString = " [IssueTime] DESC ";
            string sumString = "SUM(ApplyAmount) AS BaoXiaoJinEHeJi";

            #region fields
            fields.Append(" Id,ApplyDate,ApplyerId,ApplyAmount,State,PayTime,BankId,BankDate ");
            fields.Append(" ,(SELECT B.ContactName FROM [tbl_CompanyUser] AS B WHERE B.[Id]=tbl_FinApply.ApplyerId) AS BaoXiaoRenName ");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.BaoXiaoRenName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_CompanyUser AS A WHERE A.Id=tbl_FinApply.ApplyerId AND A.ContactName LIKE '%{0}%') ", chaXun.BaoXiaoRenName);
                }
                if (chaXun.ERiQi.HasValue)
                {
                    query.AppendFormat(" AND ApplyDate<'{0}' ", chaXun.ERiQi.Value.AddDays(1));
                }
                if (chaXun.SRiQi.HasValue)
                {
                    query.AppendFormat(" AND ApplyDate>'{0}' ", chaXun.SRiQi.Value.AddDays(-1));
                }
                if (chaXun.XiaoFeiType.HasValue)
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_FinApplyDetail AS A WHERE A.Id=tbl_FinApply.Id AND A.CostType={0}) ", (int)chaXun.XiaoFeiType.Value);
                }
                if (chaXun.BaoXiaoJinEOperator != QueryOperator.None && chaXun.BaoXiaoJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.BaoXiaoJinEOperator);
                    query.AppendFormat(" AND ApplyAmount {0} {1} ", _operator, chaXun.BaoXiaoJinE.Value);
                }
                if (chaXun.BaoXiaoStatus.HasValue)
                {
                    query.AppendFormat(" AND State={0} ", (int)chaXun.BaoXiaoStatus.Value);
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
                    var item = new MBaoXiaoInfo();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("BankDate"))) item.BankDate = rdr.GetDateTime(rdr.GetOrdinal("BankDate"));
                    item.BaoXiaoId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.BaoXiaoRenId = rdr.GetInt32(rdr.GetOrdinal("ApplyerId"));
                    item.BaoXiaoRenName = rdr["BaoXiaoRenName"].ToString();
                    item.BaoXiaoRiQi = rdr.GetDateTime(rdr.GetOrdinal("ApplyDate"));
                    item.CompanyId = companyId;
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("ApplyAmount"));
                    item.Status = (EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus)rdr.GetByte(rdr.GetOrdinal("State"));
                    //item.XiaoFeis = GetXiaoFeis(item.BaoXiaoId);
                    item.ZhangHuId = rdr["BankId"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayTime"))) item.ZhiFuTime = rdr.GetDateTime(rdr.GetOrdinal("PayTime"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) heJi[0] = rdr.GetDecimal(0);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.XiaoFeis = GetXiaoFeis(item.BaoXiaoId);
                }
            }

            return items;
        }

        /// <summary>
        /// 报销审批，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="status">审批状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ShenPi(string baoXiaoId, EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus status, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_BaoXiao_SetStatus");
            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, baoXiaoId);
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
        /// 报销支付，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="zhangHuId">支付银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int ZhiFu(string baoXiaoId, MOperatorInfo info, string zhangHuId, DateTime bankDate)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_BaoXiao_SetStatus");
            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, baoXiaoId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.已支付);
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
        /// 获取报销登记状态
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <returns></returns>
        public EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus GetStatus(string baoXiaoId)
        {
            var status = EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未通过;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetStatus);
            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, baoXiaoId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    status = (EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus)rdr.GetByte(0);
                }
            }

            return status;
        }

        /// <summary>
        /// 取消报销支付，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoZhiFu(string baoXiaoId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_BaoXiao_SetStatus");
            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, baoXiaoId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未支付);
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
        /// 取消报销审批，返回1成功，其它失败
        /// </summary>
        /// <param name="baoXiaoId">报销登记编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string baoXiaoId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_BaoXiao_SetStatus");
            _db.AddInParameter(cmd, "BaoXiaoId", DbType.AnsiStringFixedLength, baoXiaoId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未审批);
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
