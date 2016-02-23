//汪奇志 2014-08-22 平台促销数据访问类
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
    /// 平台促销数据访问类
    /// </summary>
    public class DCuXiao: DALBase, EyouSoft.IDAL.PtStructure.ICuXiao
    {
        #region static constants
        //static constants
        const string SQL_DELETE_Delete = "DELETE FROM tbl_Pt_CuXiaoFuJian WHERE CuXiaoId=@CuXiaoId;DELETE FROM tbl_Pt_CuXiao WHERE CuXiaoId=@CuXiaoId AND CompanyId=@CompanyId ";
        const string SQL_SELECT_GetInfo = "SELECT * FROM tbl_Pt_CuXiao WHERE CuXiaoId=@CuXiaoId";
        const string SQL_SELECT_GetCuXiaoFuJians = "SELECT * FROM tbl_Pt_CuXiaoFuJian WHERE CuXiaoId=@CuXiaoId ORDER BY FuJianId ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DCuXiao()
        {
            _db = SystemStore;
        }
        #endregion  
      
        #region private members
        /// <summary>
        /// get cuxiao fujians
        /// </summary>
        /// <param name="cuXiaoId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetCuXiaoFuJians(string cuXiaoId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetCuXiaoFuJians);
            _db.AddInParameter(cmd, "CuXiaoId", DbType.AnsiStringFixedLength, cuXiaoId);

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

        #region ICuXiao 成员
        /// <summary>
        /// 写入促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MCuXiaoInfo info)
        {
            #region sql
            string sql = " INSERT INTO [tbl_Pt_CuXiao]([CuXiaoId],[CompanyId],[BiaoTi],[NeiRong],[FengMian],[OperatorId],[IssueTime],[PaiXuId],[ShiJian1],[ShiJian2],[JianYaoJieShao],[Status]) VALUES (@CuXiaoId,@CompanyId,@BiaoTi,@NeiRong,@FengMian,@OperatorId,@IssueTime,@PaiXuId,@ShiJian1,@ShiJian2,@JianYaoJieShao,@Status); ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_CuXiaoFuJian]([CuXiaoId],[LeiXing],[Filepath],[MiaoShu])VALUES(@CuXiaoId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CuXiaoId", DbType.AnsiStringFixedLength, info.CuXiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "BiaoTi", DbType.String, info.BiaoTi);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "ShiJian1", DbType.DateTime, info.ShiJian1);
            _db.AddInParameter(cmd, "ShiJian2", DbType.DateTime, info.ShiJian2);
            _db.AddInParameter(cmd, "JianYaoJieShao", DbType.String, info.JianYaoJieShao);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 修改促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MCuXiaoInfo info)
        {
            #region sql
            string sql = " UPDATE [tbl_Pt_CuXiao] SET [BiaoTi] =@BiaoTi,[NeiRong] =@NeiRong,[FengMian] =@FengMian,[PaiXuId] =@PaiXuId,[ShiJian1]=@ShiJian1,[ShiJian2]=@ShiJian2,JianYaoJieShao=@JianYaoJieShao,[Status]=@Status WHERE [CuXiaoId] =@CuXiaoId ";
            sql += " DELETE FROM [tbl_Pt_CuXiaoFuJian] WHERE [CuXiaoId]=@CuXiaoId; ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_CuXiaoFuJian]([CuXiaoId],[LeiXing],[Filepath],[MiaoShu])VALUES(@CuXiaoId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CuXiaoId", DbType.AnsiStringFixedLength, info.CuXiaoId);
            _db.AddInParameter(cmd, "BiaoTi", DbType.String, info.BiaoTi);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "ShiJian1", DbType.DateTime, info.ShiJian1);
            _db.AddInParameter(cmd, "ShiJian2", DbType.DateTime, info.ShiJian2);
            _db.AddInParameter(cmd, "JianYaoJieShao", DbType.String, info.JianYaoJieShao);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 删除促销信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="cuXiaoId">促销编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string cuXiaoId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "CuXiaoId", DbType.AnsiStringFixedLength, cuXiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 获取促销信息
        /// </summary>
        /// <param name="cuXiaoId">促销编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MCuXiaoInfo GetInfo(string cuXiaoId)
        {
            EyouSoft.Model.PtStructure.MCuXiaoInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "CuXiaoId", DbType.AnsiStringFixedLength, cuXiaoId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MCuXiaoInfo();

                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.NeiRong = rdr["NeiRong"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.CuXiaoId = cuXiaoId;
                    info.ShiJian1 = rdr.GetDateTime(rdr.GetOrdinal("ShiJian1"));
                    info.ShiJian2 = rdr.GetDateTime(rdr.GetOrdinal("ShiJian2"));
                    info.JianYaoJieShao = rdr["JianYaoJieShao"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                }
            }

            if (info != null)
            {
                info.FuJians = GetCuXiaoFuJians(cuXiaoId);
            }

            return info;
        }

        /// <summary>
        /// 获取促销信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MCuXiaoInfo> GetCuXiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MCuXiaoChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MCuXiaoInfo> items = new List<EyouSoft.Model.PtStructure.MCuXiaoInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_CuXiao";
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
                    var info = new EyouSoft.Model.PtStructure.MCuXiaoInfo();

                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = companyId;
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.NeiRong = rdr["NeiRong"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.CuXiaoId = rdr["CuXiaoId"].ToString();
                    info.ShiJian1 = rdr.GetDateTime(rdr.GetOrdinal("ShiJian1"));
                    info.ShiJian2 = rdr.GetDateTime(rdr.GetOrdinal("ShiJian2"));
                    info.JianYaoJieShao = rdr["JianYaoJieShao"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置促销状态，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="cuXiaoId">促销编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(int companyId, string cuXiaoId, EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus status)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE tbl_Pt_CuXiao SET Status=@Status WHERE CuXiaoId=@CuXiaoId AND CompanyId=@CompanyId");
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "CuXiaoId", DbType.AnsiStringFixedLength, cuXiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }
        #endregion
    }
}
