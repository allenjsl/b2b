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
    /// 平台资讯相关
    /// </summary>
    public class DZiXun : DALBase, EyouSoft.IDAL.PtStructure.IZiXun
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_Pt_ZiXun]([ZiXunId],[CompanyId],[LeiXing],[BiaoTi],[NeiRong],[IssueTime],[OperatorId],[JianYaoJieShao],[FengMian],[ZhanDianId],[Status]) VALUES (@ZiXunId,@CompanyId,@LeiXing,@BiaoTi,@NeiRong,@IssueTime,@OperatorId,@JianYaoJieShao,@FengMian,@ZhanDianId,@Status);";
        const string SQL_UPDATE_Update = "UPDATE [tbl_Pt_ZiXun] SET [LeiXing]=@LeiXing,[BiaoTi]=@BiaoTi,[NeiRong]=@NeiRong,JianYaoJieShao=@JianYaoJieShao,[FengMian]=@FengMian,[ZhanDianId]=@ZhanDianId,[Status]=@Status WHERE [ZiXunId]=@ZiXunId;";
        const string SQL_DELETE_Delete = "DELETE FROM tbl_Pt_ZiXunFuJian WHERE ZiXunId=@ZiXunId;DELETE FROM tbl_Pt_ZiXun WHERE [ZiXunId]=@ZiXunId AND CompanyId=@CompanyId";
        const string SQL_SELECT_GetInfo = "SELECT * FROM tbl_Pt_ZiXun WHERE [ZiXunId]=@ZiXunId";
        const string SQL_SELECT_GetZiXunFuJians = "SELECT * FROM tbl_Pt_ZiXunFuJian WHERE ZiXunId=@ZiXunId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DZiXun()
        {
            _db = SystemStore;
        }
        #endregion        

        #region private members
        /// <summary>
        /// get zixun fujians
        /// </summary>
        /// <param name="ziXunId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetZiXunFuJians(string ziXunId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();

            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZiXunFuJians);
            _db.AddInParameter(cmd, "ZiXunId", DbType.AnsiStringFixedLength, ziXunId);

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

        #region IZiXun 成员

        /// <summary>
        /// 写入资讯信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MZiXunInfo info)
        {
            string sql = SQL_INSERT_Insert;
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_ZiXunFuJian]([ZiXunId],[LeiXing],[Filepath],[MiaoShu])VALUES(@ZiXunId,0,'{0}',''); ", item.Filepath);
                }
            }

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "ZiXunId", DbType.AnsiStringFixedLength, info.ZiXunId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, info.LeiXing);
            _db.AddInParameter(cmd, "BiaoTi", DbType.String, info.BiaoTi);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "JianYaoJieShao", DbType.String, info.JianYaoJieShao);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, info.ZhanDianId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);            

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 修改资讯信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MZiXunInfo info)
        {
            string sql = SQL_UPDATE_Update;
            sql += " DELETE FROM [tbl_Pt_ZiXunFuJian] WHERE [ZiXunId]=@ZiXunId; ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_ZiXunFuJian]([ZiXunId],[LeiXing],[Filepath],[MiaoShu])VALUES(@ZiXunId,0,'{0}',''); ", item.Filepath);
                }
            }

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "ZiXunId", DbType.AnsiStringFixedLength, info.ZiXunId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, info.LeiXing);
            _db.AddInParameter(cmd, "BiaoTi", DbType.String, info.BiaoTi);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "JianYaoJieShao", DbType.String, info.JianYaoJieShao);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, info.ZhanDianId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 删除资讯信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="ziXunId">资讯编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string ziXunId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "ZiXunId", DbType.AnsiStringFixedLength, ziXunId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取资讯信息
        /// </summary>
        /// <param name="ziXunId">资讯编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZiXunInfo GetInfo(string ziXunId)
        {
            EyouSoft.Model.PtStructure.MZiXunInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "ZiXunId", DbType.AnsiStringFixedLength, ziXunId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MZiXunInfo();

                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.NeiRong = rdr["NeiRong"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ZiXunId = rdr["ZiXunId"].ToString();
                    info.JianYaoJieShao = rdr["JianYaoJieShao"].ToString();
                    info.FengMian = rdr["FengMian"].ToString();
                    info.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.ZiXunStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                }
            }

            if (info != null) info.FuJians = GetZiXunFuJians(ziXunId);

            return info;
        }

        /// <summary>
        /// 获取资讯集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZiXunInfo> GetZiXuns(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MZiXunChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MZiXunInfo> items = new List<EyouSoft.Model.PtStructure.MZiXunInfo>();
            string fields = "*";
            fields += ",(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=tbl_Pt_ZiXun.OperatorId) AS OperatorName";
            fields += ",(SELECT A1.MingCheng FROM tbl_Pt_ZhanDian AS A1 WHERE A1.ZhanDianId=tbl_Pt_ZiXun.ZhanDianId) AS ZhanDianName";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_ZiXun";
            string orderByString = " IssueTime DESC ";
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
                if (chaXun.LeiXing.HasValue)
                {
                    sql.AppendFormat(" AND LeiXing={0} ", (int)chaXun.LeiXing.Value);
                }
                if (chaXun.Status.HasValue)
                {
                    sql.AppendFormat(" AND Status={0} ", (int)chaXun.Status.Value);
                }
                if (chaXun.ZhanDianId.HasValue)
                {
                    sql.AppendFormat(" AND (ZhanDianId={0} OR ZhanDianId=0) ", chaXun.ZhanDianId.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MZiXunInfo();

                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.NeiRong = rdr["NeiRong"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ZiXunId = rdr["ZiXunId"].ToString();

                    info.OperatorName = rdr["OperatorName"].ToString();
                    info.JianYaoJieShao = rdr["JianYaoJieShao"].ToString();
                    info.FengMian = rdr["FengMian"].ToString();
                    info.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.ZiXunStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.ZhanDianName = rdr["ZhanDianName"].ToString();

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置资讯状态，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="ziXunId">资讯编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(int companyId, string ziXunId, EyouSoft.Model.EnumType.PtStructure.ZiXunStatus status)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE tbl_Pt_ZiXun SET Status=@Status WHERE ZiXunId=@ZiXunId AND CompanyId=@CompanyId");
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZiXunId", DbType.AnsiStringFixedLength, ziXunId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }
        #endregion
    }
}
