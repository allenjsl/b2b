//财务管理出纳日记账相关数据访问类 汪奇志 2012-11-19
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
    /// 财务管理出纳日记账相关业务逻辑
    /// </summary>
    public class DRiJiZhang : DALBase, IRiJiZhang
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_FinRiJiZhang] WHERE [DengJiId]=@DengJiId";
        const string SQL_UPDATE_Update = "UPDATE [tbl_FinRiJiZhang] SET  [XiangMu] = @XiangMu,[YeWuRiQi] = @YeWuRiQi,[PingZhengHao] = @PingZhengHao,[ZhangHuId] = @ZhangHuId,[WangLaiDanWei] = @WangLaiDanWei,[MingXi] = @MingXi,[WangLaiDanWeiLeiXing] = @WangLaiDanWeiLeiXing,[WangLaiDanWeiId] = @WangLaiDanWeiId,[YeWuRiQi1] = @YeWuRiQi1 WHERE [DengJiId]=@DengJiId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DRiJiZhang()
        {
            _db = SystemStore;
        }
        #endregion

        #region IRiJiZhang 成员
        /// <summary>
        /// 写入出纳日记账信息
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MRiJiZhangInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_RiJiZhang_Insert");
            _db.AddInParameter(cmd, "RiJiId", DbType.AnsiStringFixedLength, info.RiJiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "DengJiRiQi", DbType.DateTime, info.DengJiRiQi);
            _db.AddInParameter(cmd, "XiangMu", DbType.Byte, info.XiangMu);
            _db.AddInParameter(cmd, "YeWuRiQi", DbType.String,info.YeWuRiQi);
            _db.AddInParameter(cmd, "PingZhengHao", DbType.String, info.PingZhengHao);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, info.ZhangHuId);
            _db.AddInParameter(cmd, "WangLaiDanWei", DbType.String, info.WangLaiDanWei);
            _db.AddInParameter(cmd, "MingXi", DbType.String, info.MingXi);
            _db.AddInParameter(cmd, "JieFangJinE", DbType.Decimal, info.JieFangJinE);
            _db.AddInParameter(cmd, "DaiFangJinE", DbType.Decimal,info.DaiFangJinE);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime,info.IssueTime);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "WangLaiDanWeiLeiXing", DbType.Byte, info.WangLaiDanWeiLeiXing);
            _db.AddInParameter(cmd, "WangLaiDanWeiId", DbType.AnsiStringFixedLength, info.WangLaiDanWeiId);
            _db.AddInParameter(cmd, "YeWuRiQi1", DbType.DateTime, info.YeWuRiQi1);
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
        /// 获取出纳日记账信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:借方金额合计][1:decimal:贷方金额合计]</param>
        /// <returns></returns>
        public IList<MRiJiZhangInfo> GetRiJiZhangs(int companyId, int pageSize, int pageIndex, ref int recordCount, MRiJiZhangChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M };

            IList<MRiJiZhangInfo> items = new List<MRiJiZhangInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_FinRiJiZhang";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(JieFangJinE) AS JieFangJinEHeJi,SUM(DaiFangJinE) AS DaiFangJinEHeJi";

            
            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (chaXun.EDengJiRiQi.HasValue)
                {
                    query.AppendFormat(" AND DengJiRiQi<'{0}' ", chaXun.EDengJiRiQi.Value.AddDays(1));
                }
                if (chaXun.SDengJiRiQi.HasValue)
                {
                    query.AppendFormat(" AND DengJiRiQi>='{0}' ", chaXun.SDengJiRiQi.Value);
                }
                if (chaXun.EYeWuRiQi.HasValue)
                {
                    query.AppendFormat(" AND YeWuRiQi1<'{0}' ", chaXun.EYeWuRiQi.Value.AddDays(1));
                }
                if (chaXun.SYeWuRiQi.HasValue)
                {
                    query.AppendFormat(" AND YeWuRiQi1>'{0}' ", chaXun.SYeWuRiQi.Value.AddDays(-1));
                }
                if (!string.IsNullOrEmpty(chaXun.PingZhengHao))
                {
                    query.AppendFormat(" AND PingZhengHao LIKE '%{0}%' ", chaXun.PingZhengHao);
                }
                if (chaXun.XiangMu.HasValue)
                {
                    query.AppendFormat(" AND XiangMu={0} ", (int)chaXun.XiangMu.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.YinHangZhangHuId))
                {
                    query.AppendFormat(" AND ZhangHuId='{0}' ", chaXun.YinHangZhangHuId);
                }
                if (chaXun.DaiFangJinEOperator != EyouSoft.Model.EnumType.FinStructure.QueryOperator.None && chaXun.DaiFangJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.DaiFangJinEOperator);
                    query.AppendFormat(" AND DaiFangJinE {0} {1} ", _operator, chaXun.DaiFangJinE.Value);
                }
                if (chaXun.JieFangJinEOperator != EyouSoft.Model.EnumType.FinStructure.QueryOperator.None && chaXun.JieFangJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.JieFangJinEOperator);
                    query.AppendFormat(" AND JieFangJinE {0} {1} ", _operator, chaXun.JieFangJinE.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.WangLaiDanWeiName))
                {
                    query.AppendFormat(" AND WangLaiDanWei LIKE '%{0}%' ", chaXun.WangLaiDanWeiName);
                }
                if (!string.IsNullOrEmpty(chaXun.WangLaiDanWeiId) && chaXun.WangLaiDanWeiLeiXing.HasValue)
                {
                    query.AppendFormat(" AND WangLaiDanWeiLeiXing={0} AND WangLaiDanWeiId='{1}' ", (int)chaXun.WangLaiDanWeiLeiXing.Value, chaXun.WangLaiDanWeiId);
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
                    var item = new MRiJiZhangInfo();

                    item.CompanyId = companyId;
                    item.DaiFangJinE = rdr.GetDecimal(rdr.GetOrdinal("DaiFangJinE"));
                    item.DengJiRiQi = rdr.GetDateTime(rdr.GetOrdinal("DengJiRiQi"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JieFangJinE = rdr.GetDecimal(rdr.GetOrdinal("JieFangJinE"));
                    item.MingXi = rdr["MingXi"].ToString();
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.PingZhengHao = rdr["PingZhengHao"].ToString();
                    item.RiJiId = rdr.GetString(rdr.GetOrdinal("DengJiId"));
                    item.WangLaiDanWei = rdr["WangLaiDanWei"].ToString();
                    item.XiangMu = (EyouSoft.Model.EnumType.FinStructure.RiJiZhangXiangMu)rdr.GetByte(rdr.GetOrdinal("XiangMu"));
                    item.YeWuRiQi1 = rdr.GetDateTime(rdr.GetOrdinal("YeWuRiQi1"));
                    item.YuE = rdr.GetDecimal(rdr.GetOrdinal("YuE"));
                    item.ZhangHuId = rdr["ZhangHuId"].ToString();

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
        /// 获取余额，未做过任何登记时取所有可用银行账号原始金额合计，已登记取最后一次出纳日记账余额
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public decimal GetYuE(int companyId)
        {
            decimal yuE = 0;
            StringBuilder s = new StringBuilder();

            s.Append(" IF EXISTS(SELECT 1 FROM tbl_FinRiJiZhang WHERE CompanyId=@CompanyId) ");
            s.Append(" BEGIN ");
            s.Append(" SELECT YuE FROM tbl_FinRiJiZhang WHERE CompanyId=@CompanyId ORDER BY IssueTime DESC ");
            s.Append(" END ");
            s.Append(" ELSE ");
            s.Append(" BEGIN ");
            s.Append(" SELECT SUM(AccountMoney) AS YuE FROM tbl_CompanyAccount WHERE CompanyId=@CompanyId AND AccountState IN(@Status1,@Status2) ");
            s.Append(" END ");

            DbCommand cmd = _db.GetSqlStringCommand(s.ToString());
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "Status1", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用);
            _db.AddInParameter(cmd, "Status2", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.AccountState.不可用);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) yuE = rdr.GetDecimal(0);
                }
            }

            return yuE;
        }

        /// <summary>
        /// 获取出纳日记账信息业务实体
        /// </summary>
        /// <param name="riJiZhangId">日记账编号</param>
        /// <returns></returns>
        public MRiJiZhangInfo GetInfo(string riJiZhangId)
        {
            MRiJiZhangInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, riJiZhangId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd,_db))
            {
                if (rdr.Read())
                {
                    info = new MRiJiZhangInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DaiFangJinE = rdr.GetDecimal(rdr.GetOrdinal("DaiFangJinE"));
                    info.DengJiRiQi = rdr.GetDateTime(rdr.GetOrdinal("DengJiRiQi"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieFangJinE = rdr.GetDecimal(rdr.GetOrdinal("JieFangJinE"));
                    info.MingXi = rdr["MingXi"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PingZhengHao = rdr["PingZhengHao"].ToString();
                    info.RiJiId = rdr.GetString(rdr.GetOrdinal("DengJiId"));
                    info.WangLaiDanWei = rdr["WangLaiDanWei"].ToString();
                    info.XiangMu = (EyouSoft.Model.EnumType.FinStructure.RiJiZhangXiangMu)rdr.GetByte(rdr.GetOrdinal("XiangMu"));
                    info.YeWuRiQi1 = rdr.GetDateTime(rdr.GetOrdinal("YeWuRiQi1"));
                    info.YuE = rdr.GetDecimal(rdr.GetOrdinal("YuE"));
                    info.ZhangHuId = rdr["ZhangHuId"].ToString();
                    info.WangLaiDanWeiId = rdr["WangLaiDanWeiId"].ToString();
                    info.WangLaiDanWeiLeiXing = (EyouSoft.Model.EnumType.FinStructure.RiJiZhangDanWeiType)rdr.GetByte(rdr.GetOrdinal("WangLaiDanWeiLeiXing"));
                }
            }

            return info;
        }

        /// <summary>
        /// 修改出纳日记账信息，借贷金额不做修改
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MRiJiZhangInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);

            _db.AddInParameter(cmd, "DengJiId", DbType.AnsiStringFixedLength, info.RiJiId);
            _db.AddInParameter(cmd, "XiangMu", DbType.Byte, info.XiangMu);
            _db.AddInParameter(cmd, "YeWuRiQi", DbType.String, info.YeWuRiQi);
            _db.AddInParameter(cmd, "PingZhengHao", DbType.String, info.PingZhengHao);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, info.ZhangHuId);
            _db.AddInParameter(cmd, "WangLaiDanWei", DbType.String, info.WangLaiDanWei);
            _db.AddInParameter(cmd, "MingXi", DbType.String, info.MingXi);
            _db.AddInParameter(cmd, "WangLaiDanWeiLeiXing", DbType.Byte, info.WangLaiDanWeiLeiXing);
            _db.AddInParameter(cmd, "WangLaiDanWeiId", DbType.AnsiStringFixedLength, info.WangLaiDanWeiId);
            _db.AddInParameter(cmd, "YeWuRiQi1", DbType.DateTime, info.YeWuRiQi1);
                
            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }
        #endregion
    }
}
