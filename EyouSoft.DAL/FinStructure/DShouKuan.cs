//收款相关信息数据访问类 汪奇志 2012-11-19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.FinStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using EyouSoft.IDAL.FinStructure;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 收款相关信息数据访问类
    /// </summary>
    public class DShouKuan : DALBase, IShouKuan
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetShouKuans = "SELECT * FROM [tbl_FinCope] WHERE [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType ";
        const string SQL_SELECT_GetStatus = "SELECT [Status] FROM [tbl_FinCope] WHERE [Id]=@DengJiId";
        const string SQL_SELECT_GetInfo = "SELECT A.*,(SELECT ContactName FROM tbl_CompanyUser AS B WHERE A.ApproverId=B.Id) AS ShenHeRenname FROM [tbl_FinCope] AS A WHERE A.Id=@Id";
        const string SQL_SELECT_GetShouKuanJinE = "SELECT [CollectionRefundAmount] FROM [tbl_FinCope] WHERE [Id]=@ShouKuanId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DShouKuan()
        {
            _db = SystemStore;
        }
        #endregion

        #region IShouKuan 成员
        /// <summary>
        /// 写入收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MShouKuanInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_Insert");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, info.DengJiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, info.ShouKuanXiangMuId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, info.KuanXiangType);
            _db.AddInParameter(cmd, "RiQi", DbType.DateTime, info.ShouKuanRiQi);
            _db.AddInParameter(cmd, "XingMing", DbType.String, info.ShouKuanRenName);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "FangShi", DbType.Byte, info.FangShi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.ShouKuanBeiZhu);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, info.ZhangHuId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, KuanXiangStatus.未审批);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
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
        /// 修改收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MShouKuanInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_Update");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, info.DengJiId);
            _db.AddInParameter(cmd, "RiQi", DbType.DateTime, info.ShouKuanRiQi);
            _db.AddInParameter(cmd, "XingMing", DbType.String, info.ShouKuanRenName);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "FangShi", DbType.Byte, info.FangShi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.ShouKuanBeiZhu);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, info.ZhangHuId);
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
        /// 删除收款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <returns></returns>
        public int Delete(string shouKuanId, int companyId, string shouKuanXiangMuId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_Delete");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, shouKuanId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "XiangMuId", DbType.String, shouKuanXiangMuId);
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
        /// 获取收款登记信息集合
        /// </summary>
        /// <param name="shouXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <returns></returns>
        public IList<MShouKuanInfo> GetShouKuans(KuanXiangType kuanXiangType, string shouKuanXiangMuId)
        {
            IList<MShouKuanInfo> items = new List<MShouKuanInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetShouKuans);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, shouKuanXiangMuId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, kuanXiangType);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MShouKuanInfo();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("BankDate"))) item.BankDate = rdr.GetDateTime(rdr.GetOrdinal("BankDate"));
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.DengJiId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.FangShi = (ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("CollectionRefundMode"));
                    item.ShouKuanBeiZhu = rdr["CollectionRefundMemo"].ToString();
                    item.ShouKuanRenName = rdr["CollectionRefundOperator"].ToString();
                    item.ShouKuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("CollectionRefundDate"));
                    item.ShouKuanXiangMuId = shouKuanXiangMuId;
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("CollectionRefundAmount"));
                    item.KuanXiangType = kuanXiangType;
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.ShenHeBeiZhu = rdr["ApproveRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproverId"))) item.ShenHeRenId = rdr.GetInt32(rdr.GetOrdinal("ApproverId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproveTime"))) item.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ApproveTime"));
                    item.Status = (KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.ZhangHuId = rdr["BankId"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取收款登记状态
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <returns></returns>
        public KuanXiangStatus GetStatus(string shouKuanId)
        {
            var status = KuanXiangStatus.未支付;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetStatus);
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, shouKuanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    status = (KuanXiangStatus)rdr.GetByte(0);
                }
            }

            return status;
        }

        /// <summary>
        /// 收款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="kuanXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="bankDate">银行业务日期</param>
        /// <returns></returns>
        public int ShenPi(string shouKuanId, KuanXiangType kuanXiangType, string shouKuanXiangMuId, MOperatorInfo info, DateTime bankDate)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_SetStatus");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, shouKuanId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, kuanXiangType);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, shouKuanXiangMuId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "OperatorBeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, bankDate);
            _db.AddInParameter(cmd, "Status", DbType.Byte, KuanXiangStatus.未支付);
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
        /// 获取收款信息实体
        /// </summary>
        /// <param name="shouKuanId">收款编号</param>
        /// <returns></returns>
        public MShouKuanInfo GetInfo(string shouKuanId)
        {
            MShouKuanInfo item =null;;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, shouKuanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    item = new MShouKuanInfo();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("BankDate"))) item.BankDate = rdr.GetDateTime(rdr.GetOrdinal("BankDate"));
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.DengJiId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.FangShi = (ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("CollectionRefundMode"));
                    item.ShouKuanBeiZhu = rdr["CollectionRefundMemo"].ToString();
                    item.ShouKuanRenName = rdr["CollectionRefundOperator"].ToString();
                    item.ShouKuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("CollectionRefundDate"));
                    item.ShouKuanXiangMuId = rdr.GetString(rdr.GetOrdinal("CollectionId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("CollectionRefundAmount"));
                    item.KuanXiangType = (KuanXiangType)rdr.GetByte(rdr.GetOrdinal("CollectionItem"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.ShenHeBeiZhu = rdr["ApproveRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproverId"))) item.ShenHeRenId = rdr.GetInt32(rdr.GetOrdinal("ApproverId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproveTime"))) item.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ApproveTime"));
                    item.ShenHeRenName = rdr["ShenHeRenname"].ToString();
                    item.Status = (KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.ZhangHuId = rdr["BankId"].ToString();
                    item.IsXiaoZhang = rdr.GetString(rdr.GetOrdinal("IsXiaoZhang")) == "1";
                }
            }

            return item;
        }

        /// <summary>
        /// 获取收款登记金额
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <returns></returns>
        public decimal GetShouKuanJinE(string shouKuanId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetShouKuanJinE);
            _db.AddInParameter(cmd, "ShouKuanId", DbType.AnsiStringFixedLength, shouKuanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetDecimal(0);
                }
            }

            return 0M;
        }

        /// <summary>
        /// 取消收款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="shouKuanId">收款登记编号</param>
        /// <param name="kuanXiangType">收款登记款项类型</param>
        /// <param name="shouKuanXiangMuId">收款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string shouKuanId, KuanXiangType kuanXiangType, string shouKuanXiangMuId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_SetStatus");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, shouKuanId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, kuanXiangType);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, shouKuanXiangMuId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "OperatorBeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, DBNull.Value);
            _db.AddInParameter(cmd, "Status", DbType.Byte, KuanXiangStatus.未审批);
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
