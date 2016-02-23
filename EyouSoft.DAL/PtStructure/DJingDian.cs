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
    /// 平台景点相关
    /// </summary>
    public class DJingDian : DALBase, EyouSoft.IDAL.PtStructure.IJingDian
    {
        #region static constants
        //static constants
        const string SQL_DELETE_Delete = "DELETE FROM tbl_Pt_JingDianFuJian WHERE JingDianId=@JingDianId;DELETE FROM tbl_Pt_JingDian WHERE JingDianId=@JingDianId AND CompanyId=@CompanyId;";
        const string SQL_SELECT_GetInfo = "SELECT * FROM tbl_Pt_JingDian WHERE JingDianId=@JingDianId";
        const string SQL_SELECT_GetJingDianFuJians = "SELECT * FROM tbl_Pt_JingDianFuJian WHERE JingDianId=@JingDianId";
        const string SQL_SELECT_GetJingDianQuYus = "SELECT * FROM tbl_Pt_JingDianQuYu WHERE CompanyId=@CompanyId AND IsDelete='0' ORDER BY PaiXuId ASC, QuYuId ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJingDian()
        {
            _db = SystemStore;
        }
        #endregion  
      
        #region private members
        /// <summary>
        /// get jingdian fujians
        /// </summary>
        /// <param name="jingDianId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetJingDianFuJians(string jingDianId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();

            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJingDianFuJians);
            _db.AddInParameter(cmd, "JingDianId", DbType.AnsiStringFixedLength, jingDianId);

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

        #region IJingDian 成员
        /// <summary>
        /// 新增景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MJingDianInfo info)
        {
            #region sql
            string sql = " INSERT INTO [tbl_Pt_JingDian]([JingDianId],[CompanyId],[MingCheng],[QuYuId],[JieShao],[OperatorId],[IssueTime],[FengMian],[PaiXuId],[JingDianYongHuId],[DiZhi]) VALUES (@JingDianId,@CompanyId,@MingCheng,@QuYuId,@JieShao,@OperatorId,@IssueTime,@FengMian,@PaiXuId,@JingDianYongHuId,@DiZhi); ";

            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_JingDianFuJian]([JingDianId],[LeiXing],[Filepath],[MiaoShu])VALUES(@JingDianId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "JingDianId", DbType.AnsiStringFixedLength, info.JingDianId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "QuYuId", DbType.Int32, info.QuYuId);
            _db.AddInParameter(cmd, "JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "JingDianYongHuId", DbType.Int32, info.JingDianYongHuId);
            _db.AddInParameter(cmd, "DiZhi", DbType.String, info.DiZhi);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 修改景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MJingDianInfo info)
        {
            #region sql
            string sql = " UPDATE [tbl_Pt_JingDian] SET [MingCheng]=@MingCheng,[QuYuId]=@QuYuId,[JieShao]=@JieShao,[FengMian]=@FengMian,[PaiXuId]=@PaiXuId,[JingDianYongHuId]=@JingDianYongHuId,[DiZhi]=@DiZhi WHERE [JingDianId]=@JingDianId; ";
            sql += " DELETE FROM tbl_Pt_JingDianFuJian WHERE JingDianId=@JingDianId; ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_JingDianFuJian]([JingDianId],[LeiXing],[Filepath],[MiaoShu])VALUES(@JingDianId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "JingDianId", DbType.AnsiStringFixedLength, info.JingDianId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "QuYuId", DbType.Int32, info.QuYuId);
            _db.AddInParameter(cmd, "JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "JingDianYongHuId", DbType.Int32, info.JingDianYongHuId);
            _db.AddInParameter(cmd, "DiZhi", DbType.String, info.DiZhi);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 删除景点信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jingDianId">景点编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string jingDianId)
        {
            var cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "JingDianId", DbType.AnsiStringFixedLength, jingDianId);
            _db.AddInParameter(cmd, "CompanyId", DbType.String, companyId);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <param name="jingDianId">景点编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJingDianInfo GetInfo(string jingDianId)
        {
            EyouSoft.Model.PtStructure.MJingDianInfo info = null;
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "JingDianId", DbType.AnsiStringFixedLength, jingDianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MJingDianInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.JingDianId = jingDianId;
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.QuYuId = rdr.GetInt32(rdr.GetOrdinal("QuYuId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.JingDianYongHuId = rdr.GetInt32(rdr.GetOrdinal("JingDianYongHuId"));
                    info.DiZhi = rdr["DiZhi"].ToString();
                }
            }

            if (info != null)
            {
                info.FuJians = GetJingDianFuJians(jingDianId);
            }

            return info;
        }

        /// <summary>
        /// 获取景点集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJingDianInfo> GetJingDians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJingDianChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MJingDianInfo> items = new List<EyouSoft.Model.PtStructure.MJingDianInfo>();
            string fields = "*,(SELECT A1.MingCheng FROM tbl_Pt_JingDianQuYu AS A1 WHERE A1.QuYuId=tbl_Pt_JingDian.QuYuId) AS JingDianQuYuMingCheng";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_JingDian";
            string orderByString = " PaiXuId ASC,IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (chaXun.JingDianQuYuId.HasValue)
                {
                    sql.AppendFormat(" AND QuYuId={0} ", chaXun.JingDianQuYuId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.MingCheng))
                {
                    sql.AppendFormat(" AND MingCheng LIKE '%{0}%' ", chaXun.MingCheng);
                }
                if (chaXun.JingDianYongHuId.HasValue)
                {
                    sql.AppendFormat(" AND JingDianYongHuId={0} ", chaXun.JingDianYongHuId.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MJingDianInfo();

                    info.CompanyId = companyId;
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.JingDianId = rdr["JingDianId"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.QuYuId = rdr.GetInt32(rdr.GetOrdinal("QuYuId"));
                    info.QuYuMingCheng = rdr["JingDianQuYuMingCheng"].ToString();
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取景点区域集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJingDianQuYuInfo> GetJingDianQuYus(int companyId)
        {
            IList<EyouSoft.Model.PtStructure.MJingDianQuYuInfo> items = new List<EyouSoft.Model.PtStructure.MJingDianQuYuInfo>();
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJingDianQuYus);
            _db.AddInParameter(cmd, "CompanyId", DbType.AnsiStringFixedLength, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MJingDianQuYuInfo();

                    item.CompanyId = companyId;
                    item.MingCheng = rdr["MingCheng"].ToString();
                    item.QuYuId = rdr.GetInt32(rdr.GetOrdinal("QuYuId"));
                    item.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 写入景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertJingDianQuYu(EyouSoft.Model.PtStructure.MJingDianQuYuInfo info)
        {
            var cmd = _db.GetSqlStringCommand("DECLARE @QuYuId INT;INSERT INTO [tbl_Pt_JingDianQuYu]([CompanyId],[MingCheng],[PaiXuId],[OperatorId],[IssueTime],[IsDelete])VALUES(@CompanyId,@MingCheng,@PaiXuId,@OperatorId,@IssueTime,@IsDelete);SET @QuYuId=@@identity;SELECT @QuYuId;");

            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "IsDelete", DbType.AnsiStringFixedLength, "0");

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) info.QuYuId = rdr.GetInt32(0);
                }
            }

            if (info.QuYuId > 0) return 1;
            return -100;
        }

        /// <summary>
        /// 修改景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateJingDianQuYu(EyouSoft.Model.PtStructure.MJingDianQuYuInfo info)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE [tbl_Pt_JingDianQuYu] SET [MingCheng]=@MingCheng,[PaiXuId]=@PaiXuId WHERE QuYuId=@QuYuId AND CompanyId=@CompanyId");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "QuYuId", DbType.Int32, info.QuYuId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 删除景点区域信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">区域编号</param>
        /// <returns></returns>
        public int DeleteJingDianQuYu(int companyId, int quYuId)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE [tbl_Pt_JingDianQuYu] SET IsDelete='1' WHERE QuYuId=@QuYuId AND CompanyId=@CompanyId");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "QuYuId", DbType.Int32, quYuId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取景点区域信息实体
        /// </summary>
        /// <param name="quYuId">区域编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJingDianQuYuInfo GetJingDianQuYuInfo(int quYuId)
        {
            EyouSoft.Model.PtStructure.MJingDianQuYuInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_Pt_JingDianQuYu WHERE QuYuId=@QuYuId");
            _db.AddInParameter(cmd, "QuYuId", DbType.Int32, quYuId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MJingDianQuYuInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.QuYuId = rdr.GetInt32(rdr.GetOrdinal("QuYuId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                }
            }

            return info;
        }

        /// <summary>
        /// 是否存在相同的景点区域名称
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">区域编号</param>
        /// <param name="mingCheng">区域名称</param>
        /// <returns></returns>
        public bool IsExistsJingDianQuYu(int companyId, int quYuId, string mingCheng)
        {
            var cmd = _db.GetSqlStringCommand("SELECT COUNT(*) FROM tbl_Pt_JingDianQuYu WHERE CompanyId=@CompanyId AND QuYuId<>@QuYuId AND MingCheng=@MingCheng");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, mingCheng);
            _db.AddInParameter(cmd, "QuYuId", DbType.Int32, quYuId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (rdr.GetInt32(0) > 0) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否存在景点(或相同的景点名称)
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="quYuId">景点区域编号</param>
        /// <param name="jingDianId">景点编号</param>
        /// <param name="mingCheng">景点名称</param>
        /// <returns></returns>
        public bool IsExistsJingDian(int companyId, int quYuId, int jingDianId, string mingCheng)
        {
            string sql = " SELECT COUNT(*) FROM tbl_Pt_JingDian WHERE CompanyId=@CompanyId AND QuYuId=@QuYuId ";

            if (jingDianId > 0)
            {
                sql += " AND JingDianId<>@JingDianId ";
            }
            if (!string.IsNullOrEmpty(mingCheng))
            {
                sql += " AND MingCheng=@MingCheng ";
            }

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, mingCheng);
            _db.AddInParameter(cmd, "QuYuId", DbType.Int32, quYuId);
            _db.AddInParameter(cmd, "JingDianId", DbType.Int32, jingDianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (rdr.GetInt32(0) > 0) return true;
                }
            }

            return false;

        }
        #endregion
    }
}
