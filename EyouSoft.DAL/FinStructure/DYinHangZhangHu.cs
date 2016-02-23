//公司银行账户相关信息数据访问类 汪奇志 2012-11-19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.EnumType.CompanyStructure;
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
    /// 公司银行账户相关信息数据访问类
    /// </summary>
    public class DYinHangZhangHu : DALBase, IYinHangZhangHu
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_CompanyAccount]([Id],[CompanyId],[AccountType],[AccountName],[BankName],[BankNo],[AccountState],[AccountMoney],[FilePath],[IssueTime],[OperatorId],[LastOperatorId],[ZxsId],[LeiXing]) VALUES (@Id,@CompanyId,@AccountType,@AccountName,@BankName,@BankNo,@AccountState,@AccountMoney,@FilePath,@IssueTime,@OperatorId,@OperatorId,@ZxsId,@LeiXing)";
        const string SQL_UPDATE_Update = "UPDATE [tbl_CompanyAccount] SET [AccountType]=@AccountType,[AccountName]=@AccountName,[BankName]=@BankName,[BankNo]=@BankNo,[AccountMoney]=@AccountMoney,[FilePath]=@FilePath,LeiXing=@LeiXing WHERE [Id]=@Id";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_CompanyAccount] WHERE [Id]=@Id AND [CompanyId]=@CompanyId";
        const string SQL_SELECT_GetZhangHus = " SELECT * FROM [tbl_CompanyAccount] WHERE [CompanyId]=@CompanyId AND ZxsId=@ZxsId ";
        const string SQL_UPDATE_SetStatus = "UPDATE [tbl_CompanyAccount] SET [AccountState]=@Status,[LastOperatorId]=@OperatorId,[LastOperationTime]=@OperatorTime,[LastOperationRemark]=@OperatorBeiZhu WHERE [Id]=@Id";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DYinHangZhangHu()
        {
            _db = SystemStore;
        }
        #endregion

        #region IYinHangZhangHu 成员
        /// <summary>
        /// 写入公司银行账信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(CompanyAccount info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.Id);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "AccountType", DbType.Byte, info.AccountType);
            _db.AddInParameter(cmd, "AccountName", DbType.String, info.AccountName);
            _db.AddInParameter(cmd, "BankName", DbType.String, info.BankName);
            _db.AddInParameter(cmd, "BankNo", DbType.String, info.BankNo);
            _db.AddInParameter(cmd, "AccountState", DbType.Byte, info.AccountState);
            _db.AddInParameter(cmd, "AccountMoney", DbType.Decimal, info.AccountMoney);
            _db.AddInParameter(cmd, "FilePath", DbType.String, info.FilePath);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, info.LeiXing);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 修改公司银行账信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(CompanyAccount info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.Id);
            _db.AddInParameter(cmd, "AccountType", DbType.Byte, info.AccountType);
            _db.AddInParameter(cmd, "AccountName", DbType.String, info.AccountName);
            _db.AddInParameter(cmd, "BankName", DbType.String, info.BankName);
            _db.AddInParameter(cmd, "BankNo", DbType.String, info.BankNo);
            _db.AddInParameter(cmd, "AccountMoney", DbType.Decimal, info.AccountMoney);
            _db.AddInParameter(cmd, "FilePath", DbType.String, info.FilePath);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, info.LeiXing);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 删除公司银行账信息，返回1成功，其它失败
        /// </summary>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string zhangHuId, int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, zhangHuId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取公司所有银行账户信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<CompanyAccount> GetZhangHus(int companyId,string zxsId)
        {
            IList<CompanyAccount> items = new List<CompanyAccount>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZhangHus);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new CompanyAccount();

                    item.AccountMoney = rdr.GetDecimal(rdr.GetOrdinal("AccountMoney"));
                    item.AccountName = rdr["AccountName"].ToString();
                    item.AccountState = (AccountState)rdr.GetByte(rdr.GetOrdinal("AccountState"));
                    item.AccountType = (AccountType)rdr.GetByte(rdr.GetOrdinal("AccountType"));
                    item.BankName = rdr["BankName"].ToString();
                    item.BankNo = rdr["BankNo"].ToString();
                    item.CompanyId = companyId;
                    item.FilePath = rdr["FilePath"].ToString();
                    item.Id = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.LeiXing = (EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置公司银行账户状态，返回1成功，其它失败
        /// </summary>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int SetStatus(string zhangHuId, AccountState status, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SetStatus);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, zhangHuId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "OperatorTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "OperatorBeiZhu", DbType.Byte, info.BeiZhu);


            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 是否存在相同的银行账号
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zhanghuId">银行账户编号</param>
        /// <param name="zhangHao">银行账号</param>
        /// <param name="leiXing">账户类型</param>
        /// <returns></returns>
        public bool IsExistsZhangHao(int companyId, string zhanghuId, string zhangHao,EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing leiXing)
        {
            string s = "SELECT COUNT(*) FROM [tbl_CompanyAccount] WHERE [CompanyId]=@CompanyId AND [BankNo]=@ZhangHao AND LeiXing=@LeiXing";
            if (!string.IsNullOrEmpty(zhanghuId)) s += " AND [Id]<>@ZhangHuId ";

            DbCommand cmd = _db.GetSqlStringCommand(s);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "ZhangHao", DbType.String, zhangHao);
            _db.AddInParameter(cmd, "ZhangHuId", DbType.AnsiStringFixedLength, zhanghuId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, leiXing);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetInt32(0) > 0;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取公司所有银行账户信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<CompanyAccount> GetZhangHus1(int companyId, string zxsId, EyouSoft.Model.CompanyStructure.MYinHangZhangHuChaXunInfo chaXun)
        {
            IList<CompanyAccount> items = new List<CompanyAccount>();
            string sql = SQL_SELECT_GetZhangHus;

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.KaiHuYinHang))
                {
                    sql += string.Format(" AND BankName LIKE '%{0}%' ", chaXun.KaiHuYinHang);
                }
                if (chaXun.LeiXing.HasValue)
                {
                    sql += string.Format(" AND LeiXing={0} ",(int)chaXun.LeiXing.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.MingCheng))
                {
                    sql += string.Format(" AND AccountName LIKE '%{0}%' ", chaXun.MingCheng);
                }
                if (chaXun.XingZhi.HasValue)
                {
                    sql += string.Format(" AND AccountType={0} ", (int)chaXun.XingZhi.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.YinHangZhangHao))
                {
                    sql += string.Format(" AND BankNo LIKE '%{0}%' ", chaXun.YinHangZhangHao);
                }
                if (chaXun.Status.HasValue)
                {
                    sql += string.Format(" AND AccountState={0} ", (int)chaXun.Status.Value);
                }
            }

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new CompanyAccount();

                    item.AccountMoney = rdr.GetDecimal(rdr.GetOrdinal("AccountMoney"));
                    item.AccountName = rdr["AccountName"].ToString();
                    item.AccountState = (AccountState)rdr.GetByte(rdr.GetOrdinal("AccountState"));
                    item.AccountType = (AccountType)rdr.GetByte(rdr.GetOrdinal("AccountType"));
                    item.BankName = rdr["BankName"].ToString();
                    item.BankNo = rdr["BankNo"].ToString();
                    item.CompanyId = companyId;
                    item.FilePath = rdr["FilePath"].ToString();
                    item.Id = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.LeiXing = (EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));

                    items.Add(item);
                }
            }
            return items;
        }
        #endregion
    }
}
