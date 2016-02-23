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
    /// 平台相关
    /// </summary>
    public class DPt : DALBase, EyouSoft.IDAL.PtStructure.IPt
    {
        #region static constants
        //static constants
        const string SQL_INSERT_UPDATE_SheZhiKvInfo = "IF NOT EXISTS(SELECT 1 FROM [tbl_Pt_KV] WHERE [CompanyId]=@CompanyId AND [K]=@K AND [K1]=@K1) INSERT INTO [tbl_Pt_KV]([CompanyId],[K],[V],[OperatorId],[IssueTime],[K1]) VALUES (@CompanyId,@K,@V,@OperatorId,@IssueTime,@K1) ELSE UPDATE [tbl_Pt_KV] SET [V]=@V WHERE [CompanyId]=@CompanyId AND [K]=@K AND [K1]=@K1";
        const string SQL_SELECT_GetKvInfo = "SELECT * FROM [tbl_Pt_KV] WHERE [CompanyId]=@CompanyId AND [K]=@K AND [K1]=@K1";
        const string SQL_SELECT_GetZhanDianInfo = "SELECT * FROM tbl_Pt_ZhanDian WHERE ZhanDianId=@ZhanDianId";
        const string SQL_SELECT_GetZhuanXianLeiBieInfo = "SELECT * FROM tbl_Pt_ZhuanXianLeiBie WHERE ZxlbId=@ZxlbId";
        const string SQL_SELECT_GetZhanDianXzqhdms = "SELECT * FROM tbl_Pt_ZhanDianXzqhdm WHERE ZhanDianId=@ZhanDianId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DPt()
        {
            _db = SystemStore;
        }
        #endregion        

        #region private members
        /// <summary>
        /// 获取专线类别集合1
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo1> GetZhuanXianLeiBies1(int companyId, EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo chaXun)
        {
            #region sql
            string sql = " SELECT A.ZxlbId,A.MingCheng FROM tbl_Pt_ZhuanXianLeiBie AS A INNER JOIN tbl_Pt_ZhanDian AS B ON A.ZhanDianId=B.ZhanDianId WHERE A.CompanyId=@CompanyId AND A.IsDelete='0' ";
            if (chaXun != null)
            {
                if (chaXun.ZhanDianId.HasValue)
                {
                    sql += string.Format(" AND A.ZhanDianId={0} ", chaXun.ZhanDianId.Value);
                }
                if (chaXun.Status.HasValue)
                {
                    sql += string.Format(" AND A.Status={0} ", (int)chaXun.Status.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    sql += string.Format(" AND EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianShangZhanDian AS A1 WHERE A1.ZxlbId=A.ZxlbId AND A1.ZxsId='{0}') ", chaXun.ZxsId);
                }
                if (chaXun.T2.HasValue)
                {
                    sql += string.Format(" AND A.T2={0} ", (int)chaXun.T2);
                }
            }
            sql += " ORDER BY B.PaiXuId ASC,A.PaiXuId ASC,A.ZxlbId ASC ";
            #endregion

            IList<EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo1> items = new List<EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo1>();
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo1();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// create xzqhdm xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateXzqhdmXml(IList<string> items)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<root>");
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    xml.AppendFormat("<info><Xzqhdm><![CDATA[{0}]]></Xzqhdm></info>", item);
                }
            }
            xml.Append("</root>");
            return xml.ToString();
        }

        /// <summary>
        /// get zhandian xzqhdm
        /// </summary>
        /// <param name="zhanDianId"></param>
        /// <returns></returns>
        IList<string> GetZhanDianXzqhdms(int zhanDianId)
        {
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZhanDianXzqhdms);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, zhanDianId);

            var items = new List<string>();
            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    items.Add(rdr["Xzqhdm"].ToString());
                }
            }

            return items;
        }
        #endregion

        #region IPt 成员
        /// <summary>
        /// 设置KV信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int SheZhiKvInfo(EyouSoft.Model.PtStructure.MKvInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_UPDATE_SheZhiKvInfo);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "K", DbType.String, info.K);
            _db.AddInParameter(cmd, "V", DbType.String, info.V);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "K1", DbType.Int32, info.K);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取KV信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="k">key</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MKvInfo GetKvInfo(int companyId, EyouSoft.Model.EnumType.PtStructure.KvKey k)
        {
            EyouSoft.Model.PtStructure.MKvInfo info = new EyouSoft.Model.PtStructure.MKvInfo();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetKvInfo);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "K", DbType.String, k);
            _db.AddInParameter(cmd, "K1", DbType.Int32, k);

            info.CompanyId=companyId;
            info.K=k;
            info.V = string.Empty;

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info.V = rdr["V"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 站点新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int ZhanDian_CU(EyouSoft.Model.PtStructure.MZhanDianInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Pt_ZhanDian_CU");
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, info.ZhanDianId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddOutParameter(cmd, "RetZhanDianId", DbType.Int32, 4);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "XzqhdmXml", DbType.String, CreateXzqhdmXml(info.Xzqhdms));

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

            if (info.ZhanDianId == 0)
            {
                info.ZhanDianId = Convert.ToInt32(_db.GetParameterValue(cmd, "RetZhanDianId"));
            }

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 站点删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zhanDianId">站点编号</param>
        /// <returns></returns>
        public int ZhanDian_D(int companyId, int zhanDianId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Pt_ZhanDian_D");
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, zhanDianId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, 0);
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
        /// 获取站点信息
        /// </summary>
        /// <param name="zhanDianId">站点编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZhanDianInfo GetZhanDianInfo(int zhanDianId)
        {
            EyouSoft.Model.PtStructure.MZhanDianInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZhanDianInfo);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, zhanDianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MZhanDianInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ZhanDianId = zhanDianId;
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                }
            }

            if (info != null) info.Xzqhdms = GetZhanDianXzqhdms(info.ZhanDianId);

            return info;
        }

        /// <summary>
        /// 获取站点集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhanDianInfo> GetZhanDians(int companyId, EyouSoft.Model.PtStructure.MZhanDianChaXunInfo chaXun)
        {
            #region sql
            string sql = " SELECT * FROM tbl_Pt_ZhanDian WHERE CompanyId=@CompanyId AND IsDelete='0' ";
            if (chaXun != null)
            {

            }
            sql += " ORDER BY PaiXuId ASC,ZhanDianId ASC ";
            #endregion

            IList<EyouSoft.Model.PtStructure.MZhanDianInfo> items = new List<EyouSoft.Model.PtStructure.MZhanDianInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MZhanDianInfo();
                    info.CompanyId = companyId;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 专线类别新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int ZhuanXianLeiBie_CU(EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianLeiBie_CU");
            _db.AddInParameter(cmd, "ZxlbId", DbType.Int32, info.ZxlbId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, info.ZhanDianId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddOutParameter(cmd, "RetZxlbId", DbType.Int32, 4);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "T2", DbType.Byte, info.T2);

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

            if (info.ZxlbId == 0)
            {
                info.ZxlbId = Convert.ToInt32(_db.GetParameterValue(cmd, "RetZxlbId"));
            }

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 专线类别删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxlbId">专线类别编号</param>
        /// <returns></returns>
        public int ZhuanXianLeiBie_D(int companyId, int zxlbId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianLeiBie_D");
            _db.AddInParameter(cmd, "ZxlbId", DbType.Int32, zxlbId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, 0);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, DateTime.Now);
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
        /// 获取专线类别信息
        /// </summary>
        /// <param name="zxlbId">专线类别编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo GetZhuanXianLeiBieInfo(int zxlbId)
        {
            EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZhuanXianLeiBieInfo);
            _db.AddInParameter(cmd, "ZxlbId", DbType.Int32, zxlbId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    info.ZxlbId = zxlbId;
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.T2 = (EyouSoft.Model.EnumType.PtStructure.ZxsT2)rdr.GetByte(rdr.GetOrdinal("T2"));

                }
            }

            return info;
        }

        /// <summary>
        /// 获取专线类别集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo> GetZhuanXianLeiBies(int companyId, EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo chaXun)
        {
            #region sql
            string sql = " SELECT A.*,B.MingCheng AS ZhanDianMingCheng  ";
            sql += " ,( ";
            sql += " SELECT COUNT(*) FROM tbl_Pt_ZhuanXianShangZhanDian AS A1 WHERE A1.ZxlbId=A.ZxlbId ";

            if (chaXun != null && !string.IsNullOrEmpty(chaXun.ShiYongShuLiangZxsId))
            {
                sql += string.Format(" AND A1.ZxsId<>'{0}' ", chaXun.ShiYongShuLiangZxsId);
            }

            sql += " ) AS ShiYongShuLiang ";
            sql += " FROM tbl_Pt_ZhuanXianLeiBie AS A INNER JOIN tbl_Pt_ZhanDian AS B ON A.ZhanDianId=B.ZhanDianId ";
            sql += "  WHERE A.CompanyId=@CompanyId AND A.IsDelete='0' ";
            if (chaXun != null)
            {
                if (chaXun.ZhanDianId.HasValue)
                {
                    sql += string.Format(" AND A.ZhanDianId={0} ", chaXun.ZhanDianId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.MingCheng))
                {
                    sql += string.Format(" AND A.MingCheng LIKE '%{0}%' ", chaXun.MingCheng);
                }
            }
            sql += " ORDER BY B.PaiXuId ASC,A.PaiXuId ASC,A.ZxlbId ASC ";
            #endregion

            IList<EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo> items = new List<EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo();
                    info.CompanyId = companyId;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    info.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));

                    info.ZhanDianMingCheng = rdr["ZhanDianMingCheng"].ToString();

                    info.ShiYongShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShiYongShuLiang"));
                    info.T2 = (EyouSoft.Model.EnumType.PtStructure.ZxsT2)rdr.GetByte(rdr.GetOrdinal("T2"));

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取站点信息集合（含专线类别信息）
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> GetZhanDians1(int companyId)
        {
            #region sql
            string sql = " SELECT ZhanDianId,MingCheng FROM tbl_Pt_ZhanDian WHERE CompanyId=@CompanyId AND IsDelete='0' ";
            sql += " ORDER BY PaiXuId ASC,ZhanDianId ASC ";
            #endregion

            IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> items = new List<EyouSoft.Model.PtStructure.MZhanDianInfo1>();
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MZhanDianInfo1();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    items.Add(info);
                }
            }

            if (items != null && items.Count > 0)
            {
                var zxlbChaXun = new EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo();
                zxlbChaXun.Status= EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus.启用;
                zxlbChaXun.T2 = EyouSoft.Model.EnumType.PtStructure.ZxsT2.默认;

                foreach (var item in items)
                {
                    zxlbChaXun.ZhanDianId = item.ZhanDianId;

                    item.Zxlbs = GetZhuanXianLeiBies1(companyId, zxlbChaXun);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取平台域名信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="leiXing">域名类型</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MYuMingInfo> GetYuMings(int? companyId,EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing? leiXing)
        {
            IList<EyouSoft.Model.PtStructure.MYuMingInfo> items = new List<EyouSoft.Model.PtStructure.MYuMingInfo>();
            string sql = " SELECT * FROM tbl_Pt_YuMing WHERE 1=1 ";
            if (companyId.HasValue) sql += " AND CompanyId=@CompanyId ";
            if (leiXing.HasValue) sql += " AND LeiXing=@LeiXing ";

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            if (companyId.HasValue)
            {
                _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId.Value);
            }
            if (leiXing.HasValue)
            {
                _db.AddInParameter(cmd, "LeiXing", DbType.Int32, leiXing.Value);
            }

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MYuMingInfo();
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.ErpYuMing = rdr["ErpYuMing"].ToString();
                    item.YuMing = rdr["YuMing"].ToString();
                    item.ZxsId = rdr["ZxsId"].ToString();
                    item.LeiXing = (EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing)rdr.GetInt32(rdr.GetOrdinal("LeiXing"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取专线商站点信息集合（含专线类别信息）
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> GetZxsZhanDians(int companyId, string zxsId)
        {
            IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> items = new List<EyouSoft.Model.PtStructure.MZhanDianInfo1>();
            string sql = " SELECT A.ZhanDianId,A.MingCheng FROM tbl_Pt_ZhanDian AS A WHERE A.CompanyId=@CompanyId AND A.IsDelete='0' ";
            if (!string.IsNullOrEmpty(zxsId))
            {
                sql += " AND EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianShangZhanDian AS A1 WHERE A1.ZhanDianId=A.ZhanDianId AND A1.ZxsId=@ZxsId) ";
            }
            var cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MZhanDianInfo1();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    items.Add(info);
                }
            }

            if (items != null && items.Count > 0)
            {
                var zxlbChaXun = new EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo();
                zxlbChaXun.Status = EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus.启用;
                zxlbChaXun.ZxsId = zxsId;

                foreach (var item in items)
                {
                    zxlbChaXun.ZhanDianId = item.ZhanDianId;

                    item.Zxlbs = GetZhuanXianLeiBies1(companyId, zxlbChaXun);
                }
            }

            return items;
        }

        /// <summary>
        /// 根据专线类别编号获取专线商编号
        /// </summary>
        /// <param name="zxlbId">专线类别编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public string GetZxsIdByZxlbId(int zxlbId,int companyId)
        {
            string zxsId = string.Empty;
            var cmd = _db.GetSqlStringCommand(" SELECT A.ZxsId FROM [tbl_Pt_ZhuanXianShangZhanDian] AS A WHERE A.ZxlbId=@ZxlbId AND EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianShang AS A1 WHERE A1.ZxsId=A.ZxsId AND A1.CompanyId=@CompanyId) ");
            _db.AddInParameter(cmd, "ZxlbId", DbType.Int32, zxlbId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    zxsId = rdr[0].ToString();
                }
            }

            return zxsId;
        }
        #endregion
    }
}
