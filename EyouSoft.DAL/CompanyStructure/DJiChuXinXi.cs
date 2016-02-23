//公司基础信息相关数据访问类 汪奇志 2013-01-06 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Toolkit.DAL;
using EyouSoft.IDAL.CompanyStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.CompanyStructure
{
    /// <summary>
    /// 公司基础信息相关数据访问类
    /// </summary>
    public class DJiChuXinXi : DALBase, IJiChuXinXi
    {
        #region static constants
        //static constants
        //const string SQL_INSERT_Insert = "INSERT INTO [tbl_ComJiChuXinXi]([CompanyId],[Name],[Type],[IssueTime],[OperatorId],[T1],[T2],[ZxsId]) VALUES (@CompanyId,@Name,@Type,@IssueTime,@OperatorId,@T1,@T2,@ZxsId)";
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_ComJiChuXinXi] WHERE [Id]=@Id";
        //const string SQL_UPDATE_Update = "UPDATE [tbl_ComJiChuXinXi] SET [Name]=@Name,[T1]=@T1,[T2]=@T2 WHERE [Id]=@Id AND [CompanyId]=@CompanyId";
        //const string SQL_DELETE_Delete = "DELETE FROM [tbl_ComJiChuXinXi] WHERE [Id]=@Id AND [CompanyId]=@CompanyId AND NOT EXISTS(SELECT 1 FROM tbl_FinOther AS A1 WHERE A1.XiangMuId=[tbl_ComJiChuXinXi].[Id])";
        const string SQL_UPDATE_Delete = "DECLARE @RetCode INT;SET @RetCode=0;IF EXISTS(SELECT 1 FROM [tbl_FinOther] WHERE [XiangMuId]=@Id) BEGIN; SET @RetCode=-99; END; ELSE BEGIN; UPDATE [tbl_ComJiChuXinXi] SET [IsDelete]='1' WHERE [Id]=@Id AND [CompanyId]=@CompanyId;SET @RetCode=1; END;SELECT @RetCode;";
        const string SQL_SELECT_GetJiChuXinXis = "SELECT * FROM [tbl_ComJiChuXinXi] WHERE [CompanyId]=@CompanyId AND [Type]=@Type AND [IsDelete]='0' ";
        const string SQL_SELECT_GetJiChuXinXiQuYus = "SELECT * FROM [tbl_ComJiChuXinXiQuYu] WHERE XinXiId=@XinXiId ORDER BY IdentityId ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJiChuXinXi()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// create jichuxinxi quyu xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateJiChuXinXiQuYuXml(IList<EyouSoft.Model.CompanyStructure.MJiChuXinXiQuYuInfo> items)
        {
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info QuYuId=\"{0}\"></info>", item.QuYuId);
            }
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// get jichuxinxi quyus
        /// </summary>
        /// <param name="xinXiId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.MJiChuXinXiQuYuInfo> GetJiChuXinXiQuYus(int xinXiId)
        {
            IList<EyouSoft.Model.CompanyStructure.MJiChuXinXiQuYuInfo> items = new List<EyouSoft.Model.CompanyStructure.MJiChuXinXiQuYuInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJiChuXinXiQuYus);
            _db.AddInParameter(cmd, "XinXiId", DbType.Int32, xinXiId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.MJiChuXinXiQuYuInfo();
                    item.QuYuId = rdr.GetInt32(rdr.GetOrdinal("QuYuId"));
                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region IJiChuXinXi 成员
        /*/// <summary>
        /// 写入公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">业务实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "Name", DbType.String, info.Name);
            _db.AddInParameter(cmd, "Type", DbType.Byte, info.Type);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "T1", DbType.Byte, info.T1);
            _db.AddInParameter(cmd, "T2", DbType.Byte, info.T2);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }*/

        /// <summary>
        /// 获取公司基础信息业务实体
        /// </summary>
        /// <param name="id">自增编号</param>
        /// <returns></returns>
        public EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo GetInfo(int id)
        {
            EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo info = null; 
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "Id", DbType.Int32, id);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.Name = rdr["Name"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.Type = (EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType)rdr.GetByte(rdr.GetOrdinal("Type"));
                    info.T1 = (EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1)rdr.GetByte(rdr.GetOrdinal("T1"));
                    info.T2 = (EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2)rdr.GetByte(rdr.GetOrdinal("T2"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            if (info != null)
            {
                info.QuYus = GetJiChuXinXiQuYus(info.Id);
            }

            return info;
        }

        /*/// <summary>
        /// 更新公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">业务实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "Name", DbType.String, info.Name);
            _db.AddInParameter(cmd, "Id", DbType.Int32, info.Id);
            _db.AddInParameter(cmd, "T1", DbType.Byte, info.T1);
            _db.AddInParameter(cmd, "T2", DbType.Byte, info.T2);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }*/

        /// <summary>
        /// 删除公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="id">自增编号</param>
        /// <returns></returns>
        public int Delete(int companyId, int id)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Delete);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "Id", DbType.Int32, id);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetInt32(0);
                }
            }

            return -100;
        }

        /// <summary>
        /// 获取公司基础信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="type">类型</param>
        /// <param name="t1">t1</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo> GetJiChuXinXis(int companyId, EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType type, EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1? t1,string zxsId)
        {
            IList<EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo> items = new List<EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo>();

            string s = SQL_SELECT_GetJiChuXinXis;
            if (t1.HasValue) s += " AND [T1]=@T1 ";
            if (!string.IsNullOrEmpty(zxsId)) s += " AND [ZxsId]=@ZxsId ";

            DbCommand cmd = _db.GetSqlStringCommand(s);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "Type", DbType.Byte, type);

            if (t1.HasValue) _db.AddInParameter(cmd, "T1", DbType.Byte, t1.Value);
            if (!string.IsNullOrEmpty(zxsId)) _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.Name = rdr["Name"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.Type = (EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType)rdr.GetByte(rdr.GetOrdinal("Type"));
                    info.T1 = (EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1)rdr.GetByte(rdr.GetOrdinal("T1"));
                    info.T2 = (EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2)rdr.GetByte(rdr.GetOrdinal("T2"));
                    info.ZxsId = rdr["ZxsId"].ToString();

                    items.Add(info);
                }
            }

            if (items != null && items.Count > 0 && (type == EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次 || type == EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程班次))
            {
                foreach (var item in items)
                {
                    item.QuYus = GetJiChuXinXiQuYus(item.Id);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取公司基础信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="type">类型</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo> GetJiChuXinXis(int companyId, EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType type, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MJiChuXinXiChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo> items = new List<EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo>();

            string fields = "*";
            string tableName = "tbl_ComJiChuXinXi";
            string orderByString = " [IssueTime] DESC ";
            string sumString = string.Empty;
            string sqlWhere = string.Format(" CompanyId={0} AND IsDelete='0' ", companyId);
            sqlWhere += string.Format(" AND Type={0} ", (int)type);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    sqlWhere += string.Format(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, sqlWhere, orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.Name = rdr["Name"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.Type = (EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType)rdr.GetByte(rdr.GetOrdinal("Type"));
                    info.T1 = (EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1)rdr.GetByte(rdr.GetOrdinal("T1"));
                    info.T2 = (EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2)rdr.GetByte(rdr.GetOrdinal("T2"));
                    info.ZxsId = rdr["ZxsId"].ToString();

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 公司基础信息添加、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">puws</param>
        /// <returns></returns>
        public int JiChuXinXi_CU(EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ComJiChuXinXi_CU");
            _db.AddInParameter(cmd, "XinXiId", DbType.Int32, info.Id);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "Name", DbType.String, info.Name);
            _db.AddInParameter(cmd, "Type", DbType.Byte, info.Type);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "T1", DbType.Byte, info.T1);
            _db.AddInParameter(cmd, "T2", DbType.Byte, info.T2);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);
            _db.AddInParameter(cmd, "QuYuXml", DbType.String, CreateJiChuXinXiQuYuXml(info.QuYus));
            _db.AddOutParameter(cmd, "RetXinXiId", DbType.Int32, 4);
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

            if (info.Id == 0)
            {
                info.Id = Convert.ToInt32(_db.GetParameterValue(cmd, "RetXinXiId"));
            }

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }
        #endregion
    }
}
