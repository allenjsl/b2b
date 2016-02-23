using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.CompanyStructure
{
    /// <summary>
    /// 公司线路区域DAL
    /// </summary>
    public class Area : DALBase, IDAL.CompanyStructure.IArea
    {
        #region static constants        
        /// <summary>
        /// 线路区域查询
        /// </summary>
        private const string SqlAreaSelect = @" select * from tbl_Area ";

        private readonly Database _db;
        #endregion

        #region 构造函数
        public Area()
        {
            this._db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// get quyu shengfenchengshis
        /// </summary>
        /// <param name="quYuId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.MXianLuQuYuShengFenChengShiInfo> GetQuYuShengFenChengShis(int quYuId)
        {
            IList<EyouSoft.Model.CompanyStructure.MXianLuQuYuShengFenChengShiInfo> items = new List<EyouSoft.Model.CompanyStructure.MXianLuQuYuShengFenChengShiInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT A.*,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.ShengFenId) AS ShengFenMingCheng,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.ChengShiId) AS ChengShiMingCheng FROM tbl_Pt_QuYuShengFenChengShi AS A WHERE A.QuYuId=@QuYuId ORDER BY A.IdentityId ASC");
            _db.AddInParameter(cmd, "QuYuId", DbType.Int32, quYuId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.MXianLuQuYuShengFenChengShiInfo();
                    item.ChengShiId = rdr.GetInt32(rdr.GetOrdinal("ChengShiId"));
                    item.LeiXing = (EyouSoft.Model.EnumType.PtStructure.QuYuShengFenChengShiLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.ShengFenId = rdr.GetInt32(rdr.GetOrdinal("ShengFenId"));
                    item.ChengShiMingCheng = rdr["ChengShiMingCheng"].ToString();
                    item.ShengFenMingCheng = rdr["ShengFenMingCheng"].ToString();
                    items.Add(item);
                }
            }
            return items;
        }

        /// <summary>
        /// create quyu shengfen chengshi xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateQuYuShengFenChengShiXml(IList<EyouSoft.Model.CompanyStructure.MXianLuQuYuShengFenChengShiInfo> items)
        {
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();

            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info ShengFenId=\"{0}\" ChengShiId=\"{1}\" LeiXing=\"{2}\" />", item.ShengFenId, item.ChengShiId, (int)item.LeiXing);
            }
            s.Append("</root>");
            return s.ToString();
        }
        #endregion

        #region IArea 成员

        /// <summary>
        /// 获取线路区域实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.Area GetModel(int id)
        {
            Model.CompanyStructure.Area areaModel = null;
            DbCommand cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_Area WHERE Id = @Id ");
            _db.AddInParameter(cmd, "Id", DbType.Int32, id);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    #region 线路区域信息
                    areaModel = new Model.CompanyStructure.Area
                        {
                            Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                            AreaName = rdr.GetString(rdr.GetOrdinal("AreaName")),
                            CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId")),
                            OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId")),
                            IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime")),
                            IsDelete = Convert.ToBoolean(rdr.GetOrdinal("IsDelete")),
                            SortId = rdr.GetInt32(rdr.GetOrdinal("SortId"))
                        };
                    areaModel.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    areaModel.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));
                    areaModel.ZxsId = rdr["ZxsId"].ToString();
                    #endregion
                }
            }

            if (areaModel != null)
            {
                areaModel.ShengFenChengShis = GetQuYuShengFenChengShis(id);
            }

            return areaModel;
        }

        /// <summary>
        /// 分页获取公司线路区域集合
        /// </summary>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns>公司线路区域集合</returns>
        public IList<Model.CompanyStructure.Area> GetList(int pageSize, int pageIndex, ref int recordCount, int companyId,string zxsId)
        {
            IList<Model.CompanyStructure.Area> totals = new List<Model.CompanyStructure.Area>();

            string tableName = "tbl_Area";
            string orderByString = "ZhanDianId ASC,ZxlbId ASC,SortId ASC,IssueTime desc";
            var fields = new StringBuilder();
            fields.Append(" Id, AreaName, CompanyId, OperatorId, IssueTime,IsDelete,");
            fields.Append(" SortId,ZhanDianId,ZxlbId ");
            fields.Append(",(SELECT A1.MingCheng FROM tbl_Pt_ZhanDian AS A1 WHERE A1.ZhanDianId=tbl_Area.ZhanDianId) AS ZhanDianMingCheng");
            fields.Append(",(SELECT A1.MingCheng FROM tbl_Pt_ZhuanXianLeiBie AS A1 WHERE A1.ZxlbId=tbl_Area.ZxlbId) AS ZxlbMingCheng");
            fields.AppendFormat(",ZxsId");

            var cmdQuery = new StringBuilder(" IsDelete = '0' ");
            cmdQuery.AppendFormat(" and CompanyId = {0} AND ZxsId='{1}' ", companyId,zxsId);

            using (IDataReader rdr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString()
                , cmdQuery.ToString(), orderByString, string.Empty))
            {
                while (rdr.Read())
                {
                    var areaInfo = new Model.CompanyStructure.Area
                        {
                            Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                            AreaName = rdr.GetString(rdr.GetOrdinal("AreaName")),
                            CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId")),
                            OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId")),
                            IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime")),
                            IsDelete = Convert.ToBoolean(rdr.GetOrdinal("IsDelete")),
                            SortId = rdr.GetInt32(rdr.GetOrdinal("SortId"))
                        };
                    areaInfo.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    areaInfo.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));
                    areaInfo.ZhanDianMingCheng = rdr["ZhanDianMingCheng"].ToString();
                    areaInfo.ZxlbMingCheng = rdr["ZxlbMingCheng"].ToString();
                    areaInfo.ZxsId = rdr["ZxsId"].ToString();

                    totals.Add(areaInfo);
                }
            }

            return totals;
        }

        /// <summary>
        /// 获取专线商所有线路区域信息
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.Area> GetQuYusByZxsId(string zxsId)
        {
            var items = new List<Model.CompanyStructure.Area>();

            DbCommand cmd = _db.GetSqlStringCommand("SELECT Id,AreaName FROM tbl_Area WHERE ZxsId = @ZxsId AND IsDelete = '0' ORDER BY [SortId] ASC");
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (rdr.Read())
                {
                    var item = new Model.CompanyStructure.Area();
                    item.Id= rdr.GetInt32(rdr.GetOrdinal("Id"));
                    item.AreaName=rdr["AreaName"].ToString();
                    items.Add(item);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.ShengFenChengShis = GetQuYuShengFenChengShis(item.Id);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取专线商站点、专线类别、线路区域集合
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MZxsZhanDianInfo> GetZxsZhanDians(string zxsId)
        {
            List<EyouSoft.Model.CompanyStructure.MZxsZhanDianInfo> items = new List<EyouSoft.Model.CompanyStructure.MZxsZhanDianInfo>();
            string sql = " SELECT A.ZhanDianId,A.ZxlbId,B.MingCheng AS ZhanDianName,C.MingCheng AS ZxlbName,D.Id AS QuYuId,D.Areaname AS QuYuName FROM tbl_Pt_ZhuanXianShangZhanDian AS A ";
            sql += " INNER JOIN tbl_Pt_ZhanDian AS B ON A.ZhanDianId=B.ZhanDianId AND B.IsDelete='0' ";
            sql += " INNER JOIN tbl_Pt_ZhuanXianLeiBie AS C ON A.ZxlbId=C.ZxlbId AND C.IsDelete='0' ";
            sql += " INNER JOIN tbl_Area AS D ON D.ZxlbId=A.ZxlbId AND D.IsDelete='0' AND D.ZxsId=@ZxsId ";
            sql += " WHERE A.ZxsId=@ZxsId ";
            sql += " ORDER BY B.PaiXuId ASC,B.ZhanDianId ASC,C.PaiXuId ASC,C.ZxlbId ASC,D.SortId ASC,D.Id ASC ";

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = items.FindLast(tmp =>
                    {
                        if (tmp.ZhanDianId == rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"))) return true;
                        return false;
                    });

                    if (item == null)
                    {
                        item = new EyouSoft.Model.CompanyStructure.MZxsZhanDianInfo();
                        item.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                        item.ZhanDianName = rdr["ZhanDianName"].ToString();
                        item.Zxlbs=new List<EyouSoft.Model.CompanyStructure.MZxsZxlbInfo>();
                        items.Add(item);
                    }

                    var item1 = item.Zxlbs.FindLast(tmp =>
                    {
                        if (tmp.ZxlbId == rdr.GetInt32(rdr.GetOrdinal("ZxlbId"))) return true;
                        return false;
                    });

                    if (item1 == null)
                    {
                        item1 = new EyouSoft.Model.CompanyStructure.MZxsZxlbInfo();
                        item1.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));
                        item1.ZxlbName = rdr["ZxlbName"].ToString();
                        item1.QuYus = new List<EyouSoft.Model.CompanyStructure.MZxsQuYuInfo>();

                        item.Zxlbs.Add(item1);
                    }

                    var item2 = new EyouSoft.Model.CompanyStructure.MZxsQuYuInfo();
                    item2.QuYuId = rdr.GetInt32(rdr.GetOrdinal("QuYuId"));
                    item2.QuYuName = rdr["QuYuName"].ToString();

                    item1.QuYus.Add(item2);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取线路区域集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.Area> GetQuYus(int companyId, EyouSoft.Model.CompanyStructure.MQuYuChaXunInfo chaXun)
        {
            IList<Model.CompanyStructure.Area> items = new List<Model.CompanyStructure.Area>();
            #region sql
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" SELECT * FROM tbl_Area WHERE CompanyId=@CompanyId AND IsDelete='0' ");
            if (chaXun != null)
            {
                if (chaXun.ZhanDianId.HasValue)
                {
                    sql.AppendFormat(" AND ZhanDianId={0} ", chaXun.ZhanDianId.Value);
                }
                if (chaXun.ZxlbId.HasValue)
                {
                    sql.AppendFormat(" AND ZxlbId={0} ", chaXun.ZxlbId.Value);
                }
            }
            sql.AppendFormat(" ORDER BY [SortId] ASC,Id ASC ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new Model.CompanyStructure.Area();
                    item.Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    item.AreaName = rdr["AreaName"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 线路区域新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int QuYu_CU(EyouSoft.Model.CompanyStructure.Area info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_QuYu_CU");
            _db.AddInParameter(cmd, "@QuYuId", DbType.Int32, info.Id);
            _db.AddInParameter(cmd, "@QuYuName", DbType.String, info.AreaName);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime,info.IssueTime);
            _db.AddInParameter(cmd, "@PaiXuId", DbType.Int32,info.SortId);
            _db.AddInParameter(cmd, "@ZhanDianId", DbType.Int32, info.ZhanDianId);
            _db.AddInParameter(cmd, "@ZxlbId", DbType.Int32, info.ZxlbId);
            _db.AddInParameter(cmd, "@ShengFenChengShiXml", DbType.String, CreateQuYuShengFenChengShiXml(info.ShengFenChengShis));
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);
            _db.AddOutParameter(cmd, "@RetQuYuId", DbType.Int32, 4);


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
                info.Id = Convert.ToInt32(_db.GetParameterValue(cmd, "RetQuYuId"));
            }

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 线路区域删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="quYuId">线路区域编号</param>
        /// <returns></returns>
        public int QuYu_D(int companyId, string zxsId, int quYuId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_QuYu_D");
            _db.AddInParameter(cmd, "@QuYuId", DbType.Int32, quYuId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

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
