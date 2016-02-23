using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.PtStructure
{
    /// <summary>
    /// 平台推荐相关
    /// </summary>
    public class DTuiJian : DALBase, EyouSoft.IDAL.PtStructure.ITuiJian
    {
        #region static constants
        //static constants
        const string SQL_DELETE_Delete = "DELETE FROM tbl_Pt_TuiJianFuJian WHERE TuiJianId=@TuiJianId;DELETE FROM tbl_Pt_TuiJian WHERE TuiJianId=@TuiJianId AND CompanyId=@CompanyId ";
        const string SQL_SELECT_GetInfo = "SELECT * FROM tbl_Pt_TuiJian WHERE TuiJianId=@TuiJianId";
        const string SQL_SELECT_GetTuiJianFuJians = "SELECT * FROM tbl_Pt_TuiJianFuJian WHERE TuiJianId=@TuiJianId ORDER BY FuJianId ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DTuiJian()
        {
            _db = SystemStore;
        }
        #endregion  
      
        #region private members
        /// <summary>
        /// get tuijian fujians
        /// </summary>
        /// <param name="tuiJianId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetTuiJianFuJians(string tuiJianId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetTuiJianFuJians);
            _db.AddInParameter(cmd, "TuiJianId", DbType.AnsiStringFixedLength, tuiJianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MFuJianInfo();
                    item.Filepath = rdr["Filepath"].ToString();
                    item.FuJianId = rdr.GetInt32(rdr.GetOrdinal("FuJianId"));
                    item.MiaoShu = rdr["MiaoShu"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region ITuiJian 成员
        /// <summary>
        /// 写入平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MTuiJianInfo info)
        {
            #region sql
            string sql = " INSERT INTO [tbl_Pt_TuiJian]([TuiJianId],[CompanyId],[BiaoTi],[NeiRong],[FengMian],[OperatorId],[IssueTime],[PaiXuId],[JianYaoJieShao],[Status]) VALUES (@TuiJianId,@CompanyId,@BiaoTi,@NeiRong,@FengMian,@OperatorId,@IssueTime,@PaiXuId,@JianYaoJieShao,@Status); ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_TuiJianFuJian]([TuiJianId],[LeiXing],[Filepath],[MiaoShu])VALUES(@TuiJianId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "TuiJianId", DbType.AnsiStringFixedLength, info.TuiJianId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "BiaoTi", DbType.String, info.BiaoTi);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "JianYaoJieShao", DbType.String, info.JianYaoJieShao);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 修改平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MTuiJianInfo info)
        {
            #region sql
            string sql = " UPDATE [tbl_Pt_TuiJian] SET [BiaoTi] =@BiaoTi,[NeiRong] =@NeiRong,[FengMian] =@FengMian,[PaiXuId] =@PaiXuId,JianYaoJieShao=@JianYaoJieShao,[Status]=@Status WHERE [TuiJianId] =@TuiJianId ";
            sql += " DELETE FROM [tbl_Pt_TuiJianFuJian] WHERE [TuiJianId]=@TuiJianId; ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_TuiJianFuJian]([TuiJianId],[LeiXing],[Filepath],[MiaoShu])VALUES(@TuiJianId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "TuiJianId", DbType.AnsiStringFixedLength, info.TuiJianId);
            _db.AddInParameter(cmd, "BiaoTi", DbType.String, info.BiaoTi);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "JianYaoJieShao", DbType.String, info.JianYaoJieShao);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 删除平台推荐信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="tuiJianId">推荐编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string tuiJianId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "TuiJianId", DbType.AnsiStringFixedLength, tuiJianId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 获取平台推荐信息
        /// </summary>
        /// <param name="tuiJianId">推荐编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MTuiJianInfo GetInfo(string tuiJianId)
        {
            EyouSoft.Model.PtStructure.MTuiJianInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "TuiJianId", DbType.AnsiStringFixedLength, tuiJianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MTuiJianInfo();

                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.NeiRong = rdr["NeiRong"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.TuiJianId = tuiJianId;
                    info.JianYaoJieShao = rdr["JianYaoJieShao"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.TuiJianStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                }
            }

            if (info != null)
            {
                info.FuJians = GetTuiJianFuJians(tuiJianId);
            }

            return info;
        }

        /// <summary>
        /// 获取平台推荐集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MTuiJianInfo> GetTuiJians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MTuiJianChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MTuiJianInfo> items = new List<EyouSoft.Model.PtStructure.MTuiJianInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_TuiJian";
            string orderByString = " PaiXuId ASC,IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.BiaoTi))
                {
                    sql.AppendFormat(" AND BiaoTi LIKE '%{0}%' ", chaXun.BiaoTi);
                }
                if (chaXun.ShiJian1.HasValue)
                {
                    sql.AppendFormat(" AND IssueTime>'{0}' ", chaXun.ShiJian1.Value.AddMinutes(-1));
                }
                if (chaXun.ShiJian2.HasValue)
                {
                    sql.AppendFormat(" AND IssueTime<'{0}' ", chaXun.ShiJian2.Value.AddDays(1).AddMinutes(-1));
                }
                if (chaXun.Status.HasValue)
                {
                    sql.AppendFormat(" AND Status={0} ", (int)chaXun.Status.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MTuiJianInfo();

                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = companyId;
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.NeiRong = rdr["NeiRong"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.TuiJianId = rdr["TuiJianId"].ToString();
                    info.JianYaoJieShao = rdr["JianYaoJieShao"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.TuiJianStatus)rdr.GetByte(rdr.GetOrdinal("Status"));

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置推荐状态，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="tuiJianId">推荐编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(int companyId, string tuiJianId, EyouSoft.Model.EnumType.PtStructure.TuiJianStatus status)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE tbl_Pt_TuiJian SET Status=@Status WHERE TuiJianId=@TuiJianId AND CompanyId=@CompanyId");
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "TuiJianId", DbType.AnsiStringFixedLength, tuiJianId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }
        #endregion
    }
}
