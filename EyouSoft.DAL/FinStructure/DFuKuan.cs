//付款登记信息相关数据访问类 汪奇志 2012-11-19
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
    /// 付款登记信息相关数据访问类
    /// </summary>
    public class DFuKuan : DALBase, IFuKuan
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetFuKuans = "SELECT * FROM [tbl_FinCope] WHERE [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType ";
        const string SQL_SELECT_GetStatus = "SELECT [Status] FROM [tbl_FinCope] WHERE [Id]=@DengJiId";
        const string SQL_SELECT_GetInfo = "SELECT A.*,(SELECT B.ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.ApproverId) AS ShenHeRenName,(SELECT B.ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.PayId) AS ZhiFuRenName FROM [tbl_FinCope] AS A WHERE A.[Id]=@FuKuanId";
        const string SQL_SELECT_GetFuKuanJinE = "SELECT [CollectionRefundAmount] FROM [tbl_FinCope] WHERE [Id]=@FuKuanId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DFuKuan()
        {
            _db = SystemStore;
        }
        #endregion

        #region EyouSoft.IDAL.FinStructure.IFuKuan 成员
        /// <summary>
        /// 写入付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MFuKuanInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_Insert");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, info.DengJiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, info.FuKuanXiangMuId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, info.KuanXiangType);
            _db.AddInParameter(cmd, "RiQi", DbType.DateTime, info.FuKuanRiQi);
            _db.AddInParameter(cmd, "XingMing", DbType.String, info.FuKuanRenName);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "FangShi", DbType.Byte, info.FangShi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.FuKuanBeiZhu);
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
        /// 修改付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MFuKuanInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_Update");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, info.DengJiId);
            _db.AddInParameter(cmd, "RiQi", DbType.DateTime, info.FuKuanRiQi);
            _db.AddInParameter(cmd, "XingMing", DbType.String, info.FuKuanRenName);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "FangShi", DbType.Byte, info.FangShi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.FuKuanBeiZhu);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, info.ZhangHuId);
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
        /// 删除付款登记信息，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <returns></returns>
        public int Delete(string fuKuanId, int companyId, string fuKuanXiangMuId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_Delete");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, fuKuanId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "XiangMuId", DbType.String, fuKuanXiangMuId);
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
        /// 获取付款登记信息集合
        /// </summary>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <returns></returns>
        public IList<MFuKuanInfo> GetFuKuans(KuanXiangType kuanXiangType, string fuKuanXiangMuId)
        {
            IList<MFuKuanInfo> items = new List<MFuKuanInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetFuKuans);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, fuKuanXiangMuId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, kuanXiangType);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MFuKuanInfo();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("BankDate"))) item.BankDate = rdr.GetDateTime(rdr.GetOrdinal("BankDate"));
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.DengJiId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.FangShi = (ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("CollectionRefundMode"));
                    item.FuKuanBeiZhu = rdr["CollectionRefundMemo"].ToString();
                    item.FuKuanRenName = rdr["CollectionRefundOperator"].ToString();
                    item.FuKuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("CollectionRefundDate"));
                    item.FuKuanXiangMuId = fuKuanXiangMuId;
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("CollectionRefundAmount"));
                    item.KuanXiangType = kuanXiangType;
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.ShenHeBeiZhu = rdr["ApproveRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproverId"))) item.ShenHeRenId = rdr.GetInt32(rdr.GetOrdinal("ApproverId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproveTime"))) item.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ApproveTime"));
                    item.Status = (KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.ZhangHuId = rdr["BankId"].ToString();
                    item.ZhiFuBeiZhu = rdr["PayRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayId"))) item.ZhiFuRenId = rdr.GetInt32(rdr.GetOrdinal("PayId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayTime"))) item.ZhiFuTime = rdr.GetDateTime(rdr.GetOrdinal("PayTime"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取付款登记状态
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <returns></returns>
        public KuanXiangStatus GetStatus(string fuKuanId)
        {
            var status = KuanXiangStatus.已支付;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetStatus);
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, fuKuanId);

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
        /// 付款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ShenPi(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_SetStatus");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, fuKuanId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, kuanXiangType);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, fuKuanXiangMuId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "OperatorBeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, DBNull.Value);
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
        /// 付款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        public int ZhiFu(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info, DateTime bankDate)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_SetStatus");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, fuKuanId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, kuanXiangType);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, fuKuanXiangMuId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "OperatorBeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, bankDate);
            _db.AddInParameter(cmd, "Status", DbType.Byte, KuanXiangStatus.已支付);
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
        /// 获取付款审批信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息，[0:decimal:付款金额]</param>
        /// <returns></returns>
        public IList<MLBFuKuanShenPiInfo> GetShenPis(int companyId, int pageSize, int pageIndex, ref int recordCount, MLBFuKuanShenPiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M };
            IList<MLBFuKuanShenPiInfo> items = new List<MLBFuKuanShenPiInfo>();

            string fields = "CollectionItem,JiaoYiHao,WangLaiDanWeiName,IssueTime,CollectionRefundDate,CollectionRefundOperator,CollectionRefundAmount,CollectionRefundMode,CollectionRefundMemo,Status,BankId,CollectionId,Id,PayTime";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_FuKuanShenPi";
            string orderByString = " SortId ASC,IssueTime DESC ";
            string sumString = "SUM(CollectionRefundAmount) AS JinEHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND WangLaiDanWeiName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.JiaoYiHao))
                {
                    query.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", chaXun.JiaoYiHao);
                }
                if (chaXun.KuanXiangType.HasValue)
                {
                    query.AppendFormat(" AND CollectionItem={0} ", (int)chaXun.KuanXiangType.Value);
                }
                if (chaXun.FuKuanJinEOperator != QueryOperator.None && chaXun.FuKuanJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.FuKuanJinEOperator);
                    query.AppendFormat(" AND CollectionRefundAmount {0} {1} ", _operator, chaXun.FuKuanJinE.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                if (chaXun.FuKuanShiJian1.HasValue)
                {
                    query.AppendFormat(" AND CollectionRefundDate>='{0}' ", chaXun.FuKuanShiJian1.Value);
                }
                if (chaXun.FuKuanShiJian2.HasValue)
                {
                    query.AppendFormat(" AND CollectionRefundDate<='{0}' ", chaXun.FuKuanShiJian2.Value);
                }
                if (chaXun.FuKuanStatus.HasValue)
                {
                    query.AppendFormat(" AND Status={0} ", (int)chaXun.FuKuanStatus.Value);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MLBFuKuanShenPiInfo();

                    item.KuanXiangType = (KuanXiangType)rdr.GetByte(rdr.GetOrdinal("CollectionItem"));
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.GysName = rdr["WangLaiDanWeiName"].ToString();
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayTime"))) item.ZhiFuTime = rdr.GetDateTime(rdr.GetOrdinal("PayTime"));
                    item.FuKuanRenName = rdr["CollectionRefundOperator"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("CollectionRefundAmount"));
                    item.FangShi = (ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("CollectionRefundMode"));
                    item.FuKuanBeiZhu = rdr["CollectionRefundMemo"].ToString();
                    item.Status = (KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.ZhangHuId = rdr["BankId"].ToString();
                    item.FuKuanXiangMuId = rdr.GetString(rdr.GetOrdinal("CollectionId"));
                    item.DengJiId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.FuKuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("CollectionRefundDate"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JinEHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("JinEHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取付款登记实体
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <returns></returns>
        public MFuKuanInfo GetInfo(string fuKuanId)
        {
            MFuKuanInfo item = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "FuKuanId", DbType.AnsiStringFixedLength, fuKuanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    item = new MFuKuanInfo();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("BankDate"))) item.BankDate = rdr.GetDateTime(rdr.GetOrdinal("BankDate"));
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.DengJiId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.FangShi = (ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("CollectionRefundMode"));
                    item.FuKuanBeiZhu = rdr["CollectionRefundMemo"].ToString();
                    item.FuKuanRenName = rdr["CollectionRefundOperator"].ToString();
                    item.FuKuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("CollectionRefundDate"));
                    item.FuKuanXiangMuId = rdr.GetString(rdr.GetOrdinal("CollectionId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("CollectionRefundAmount"));
                    item.KuanXiangType = (KuanXiangType)rdr.GetByte(rdr.GetOrdinal("CollectionItem"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.ShenHeBeiZhu = rdr["ApproveRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproverId"))) item.ShenHeRenId = rdr.GetInt32(rdr.GetOrdinal("ApproverId"));
                    item.ShenHeRenName = rdr["ShenHeRenName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ApproveTime"))) item.ShenHeTime = rdr.GetDateTime(rdr.GetOrdinal("ApproveTime"));
                    item.Status = (KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.ZhangHuId = rdr["BankId"].ToString();
                    item.ZhiFuBeiZhu = rdr["PayRemark"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayId"))) item.ZhiFuRenId = rdr.GetInt32(rdr.GetOrdinal("PayId"));
                    item.ZhiFuRenName = rdr["ZhiFuRenName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PayTime"))) item.ZhiFuTime = rdr.GetDateTime(rdr.GetOrdinal("PayTime"));
                }
            }

            return item;
        }

        /// <summary>
        /// 获取付款登记金额
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <returns></returns>
        public decimal GetFuKuanJinE(string fuKuanId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetFuKuanJinE);
            _db.AddInParameter(cmd, "FuKuanId", DbType.AnsiStringFixedLength, fuKuanId);

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
        /// 取消付款审批，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_SetStatus");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, fuKuanId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, kuanXiangType);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, fuKuanXiangMuId);
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

        /// <summary>
        /// 取消付款支付，返回1成功，其它失败
        /// </summary>
        /// <param name="fuKuanId">付款登记编号</param>
        /// <param name="kuanXiangType">付款登记款项类型</param>
        /// <param name="fuKuanXiangMuId">付款项目编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoZhiFu(string fuKuanId, KuanXiangType kuanXiangType, string fuKuanXiangMuId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_ShouFuKuan_SetStatus");
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, fuKuanId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, kuanXiangType);
            _db.AddInParameter(cmd, "XiangMuId", DbType.AnsiStringFixedLength, fuKuanXiangMuId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "OperatorBeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "BankDate", DbType.DateTime, DBNull.Value);
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
        #endregion
    }
}
