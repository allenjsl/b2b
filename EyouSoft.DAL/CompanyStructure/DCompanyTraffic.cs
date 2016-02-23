using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Model.CompanyStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace EyouSoft.DAL.CompanyStructure
{
    /// <summary>
    /// 用户信息数据层
    /// </summary>
    public class DCompanyTraffic : DALBase, IDAL.CompanyStructure.ICompanyTraffic
    {
        private readonly Database _db;

        public DCompanyTraffic()
        {
            _db = this.SystemStore;
        }

        /// <summary>
        /// 验证交通名称是否已经存在，存在返回true
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="name">要验证的交通名称</param>
        /// <param name="id">要排除的交通交通编号</param>
        /// <returns></returns>
        public bool ExistsTrafficName(int companyId, string name, int id)
        {
            if (companyId <= 0 || string.IsNullOrEmpty(name)) return false;

            var strSql = new StringBuilder();
            strSql.Append(
                " select count(*) from tbl_CompanyTraffic where CompanyId = @CompanyId and TrafficName = @TrafficName ");
            if (id > 0)
            {
                strSql.AppendFormat(" and Id <> {0} ", id);
            }
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(dc, "TrafficName", DbType.String, name);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null || Toolkit.Utils.GetInt(obj.ToString()) <= 0) return false;

            return Toolkit.Utils.GetInt(obj.ToString()) > 0;
        }

        /// <summary>
        /// 验证交通是否被使用
        /// </summary>
        /// <param name="ids">交通编号</param>
        /// <returns>返回已经被使用的编号数组</returns>
        public int[] ExistsTraffic(params int[] ids)
        {
            if (ids == null || ids.Length <= 0) return null;

            IList<int> list = new List<int>();
            var strSql = new StringBuilder();
            var strSql2 = new StringBuilder();
            strSql.Append(" select distinct QuJiaoTongId from tbl_KongWei where ");
            strSql2.Append(" select distinct HuiJiaoTongId from tbl_KongWei where ");
            if (ids.Length == 1)
            {
                strSql.AppendFormat(" QuJiaoTongId = {0} ", ids[0]);
                strSql2.AppendFormat(" HuiJiaoTongId = {0} ", ids[0]);
            }
            else
            {
                strSql.AppendFormat(" QuJiaoTongId in ({0}) ", GetIdsByArr(ids));
                strSql2.AppendFormat(" HuiJiaoTongId in ({0}) ", GetIdsByArr(ids));
            }

            DbCommand dc = _db.GetSqlStringCommand(string.Format("{0};{1};", strSql.ToString(), strSql2.ToString()));

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                while (dr.Read())
                {
                    int q = dr.IsDBNull(dr.GetOrdinal("QuJiaoTongId")) ? 0 : dr.GetInt32(dr.GetOrdinal("QuJiaoTongId"));
                    if (q > 0)
                    {
                        if (!list.Contains(q))
                            list.Add(q);
                    }
                }

                dr.NextResult();
                while (dr.Read())
                {
                    int h = dr.IsDBNull(dr.GetOrdinal("HuiJiaoTongId")) ? 0 : dr.GetInt32(dr.GetOrdinal("HuiJiaoTongId"));
                    if (h > 0)
                    {
                        if (!list.Contains(h))
                            list.Add(h);
                    }
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// 添加公司交通信息
        /// </summary>
        /// <param name="model">交通信息实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int AddTraffic(CompanyTraffic model)
        {
            if (model.CompanyId <= 0 || string.IsNullOrEmpty(model.TrafficName)) return 0;

            var strSql = new StringBuilder();
            strSql.Append(" insert into tbl_CompanyTraffic (CompanyId,TrafficName) values (@CompanyId,@TrafficName); ");
            strSql.Append(" select @@identity; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "TrafficName", DbType.String, model.TrafficName);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null || Toolkit.Utils.GetInt(obj.ToString()) <= 0) return -1;

            model.TrafficId = Toolkit.Utils.GetInt(obj.ToString());
            return 1;
        }

        /// <summary>
        /// 修改公司交通信息
        /// </summary>
        /// <param name="model">交通信息实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int UpdateTraffic(CompanyTraffic model)
        {
            if (model.TrafficId <= 0 || string.IsNullOrEmpty(model.TrafficName)) return 0;

            var strSql = new StringBuilder();
            strSql.Append(" update tbl_CompanyTraffic set TrafficName = @TrafficName where Id = @Id ; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.Int32, model.TrafficId);
            _db.AddInParameter(dc, "TrafficName", DbType.String, model.TrafficName);

            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : -1;
        }

        /// <summary>
        /// 删除公司交通信息
        /// </summary>
        /// <param name="ids">交通编号</param>
        /// <returns>返回1成功，其他失败</returns>
        /// <remarks>
        /// 批量删除的情况下，有用到的交通不会被删除且没有提示
        /// </remarks>
        public int DeleteTraffic(params int[] ids)
        {
            if (ids == null || ids.Length <= 0) return 0;

            var strSql = new StringBuilder();
            strSql.Append(" delete from tbl_CompanyTraffic where ");
            if (ids.Length == 1)
            {
                strSql.AppendFormat(" Id = {0} ", ids[0]);
            }
            else
            {
                strSql.AppendFormat(" Id in ({0}) ", GetIdsByArr(ids));
            }

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : -1;
        }

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<CompanyTraffic> GetList(int companyId, int pageSize, int pageIndex, ref int recordCount)
        {
            if (companyId <= 0 || pageSize <= 0 || pageIndex <= 0) return null;

            string tableName = "tbl_CompanyTraffic";
            string fields = "Id,CompanyId,TrafficName";
            var strWhere = new StringBuilder();
            string orderByString = " Id asc ";
            strWhere.AppendFormat(" CompanyId = {0} ", companyId);

            var list = new List<CompanyTraffic>();
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields
                , strWhere.ToString(), orderByString, string.Empty))
            {
                while (dr.Read())
                {
                    list.Add(
                        new CompanyTraffic
                            {
                                TrafficId = dr.GetInt32(dr.GetOrdinal("Id")),
                                CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                                TrafficName =
                                    dr.IsDBNull(dr.GetOrdinal("TrafficName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("TrafficName"))
                            });
                }
            }

            return list;
        }

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<CompanyTraffic> GetList(int companyId)
        {
            if (companyId <= 0) return null;

            var strSql = new StringBuilder();

            strSql.Append(" select Id,CompanyId,TrafficName from tbl_CompanyTraffic ");
            strSql.AppendFormat(" where CompanyId = {0} ", companyId);

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            var list = new List<CompanyTraffic>();
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                while (dr.Read())
                {
                    list.Add(
                        new CompanyTraffic
                        {
                            TrafficId = dr.GetInt32(dr.GetOrdinal("Id")),
                            CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                            TrafficName =
                                dr.IsDBNull(dr.GetOrdinal("TrafficName"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("TrafficName"))
                        });
                }
            }

            return list;
        }

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="id">交通编号</param>
        /// <returns></returns>
        public CompanyTraffic GetModel(int id)
        {
            if (id <= 0) return null;

            var strSql = new StringBuilder();

            strSql.Append(" select Id,CompanyId,TrafficName from tbl_CompanyTraffic where Id = @Id ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            _db.AddInParameter(dc, "Id", DbType.Int32, id);

            CompanyTraffic model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new CompanyTraffic
                        {
                            TrafficId = dr.GetInt32(dr.GetOrdinal("Id")),
                            CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                            TrafficName =
                                dr.IsDBNull(dr.GetOrdinal("TrafficName"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("TrafficName"))
                        };
                }
            }

            return model;
        }
    }
}
