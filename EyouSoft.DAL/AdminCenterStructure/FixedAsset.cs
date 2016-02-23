using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.AdminCenterStructure
{
    /// <summary>
    /// 行政中心-固定资产管理
    /// </summary>
    public class FixedAsset : DALBase, IDAL.AdminCenterStructure.IFixedAsset
    {
        private readonly Database _db;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FixedAsset()
        {
            _db = this.SystemStore;
        }
        #endregion

        #region 实现接口公共方法
        /// <summary>
        /// 获取固定资产管理实体信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.AdminCenterStructure.FixedAsset GetModel(int companyId, int id)
        {
            if (companyId <= 0 || id <= 0) return null;

            var strSql = new StringBuilder();
            strSql.Append(
                " SELECT [Id],[CompanyId],[AssetNo],[AssetName],[BuyDate],[Cost],[Remark],[IssueTime],[OperatorId] FROM [tbl_FixedAsset] ");
            strSql.Append(" where [CompanyId] = @CompanyId and [Id] = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(dc, "Id", DbType.Int32, id);

            Model.AdminCenterStructure.FixedAsset model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new Model.AdminCenterStructure.FixedAsset
                        {
                            Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                            CompanyId =
                                dr.IsDBNull(dr.GetOrdinal("CompanyId")) ? 0 : dr.GetInt32(dr.GetOrdinal("CompanyId")),
                            AssetNo =
                                dr.IsDBNull(dr.GetOrdinal("AssetNo"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("AssetNo")),
                            AssetName =
                                dr.IsDBNull(dr.GetOrdinal("AssetName"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("AssetName")),
                            Remark =
                                dr.IsDBNull(dr.GetOrdinal("Remark"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Remark")),
                            OperatorId =
                                dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId"))
                        };
                    if (!dr.IsDBNull(dr.GetOrdinal("BuyDate"))) model.BuyDate = dr.GetDateTime(dr.GetOrdinal("BuyDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Cost"))) model.Cost = dr.GetDecimal(dr.GetOrdinal("Cost"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                }
            }

            return model;
        }
        /// <summary>
        /// 获取固定资产管理信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="companyId">公司编号</param>
        /// <param name="fixedAssetNo">固定资产管理编号</param>
        /// <param name="assetName">固定资产名称</param>
        /// <param name="beginStart">会议时间开始</param>
        /// <param name="beginEnd">会议时间结束</param>
        /// <returns></returns>
        public IList<Model.AdminCenterStructure.FixedAsset> GetList(int pageSize, int pageIndex, ref int recordCount, int companyId
            , string fixedAssetNo, string assetName, DateTime? beginStart, DateTime? beginEnd)
        {
            IList<Model.AdminCenterStructure.FixedAsset> resultList;
            string tableName = "tbl_FixedAsset";
            string fields = " [Id],[AssetNo],[AssetName],[BuyDate],[Cost],[Remark] ";
            string query = string.Format("[CompanyId]={0}", companyId);
            if (!string.IsNullOrEmpty(fixedAssetNo))
            {
                query = query + string.Format(" AND AssetNo LIKE '%{0}%' ", Toolkit.Utils.ReplaceXmlSpecialCharacter(fixedAssetNo));
            }
            if (!string.IsNullOrEmpty(assetName))
            {
                query = query + string.Format("AND AssetName LIKE '%{0}%' ", Toolkit.Utils.ReplaceXmlSpecialCharacter(assetName));
            }
            if (beginStart.HasValue)
            {
                query = query + string.Format(" AND DATEDIFF(DAY,'{0}',BuyDate)>=0", beginStart);
            }
            if (beginEnd.HasValue)
            {
                query = query + string.Format(" AND DATEDIFF(DAY,BuyDate,'{0}')>=0", beginEnd);
            }
            string orderByString = " IssueTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query
                , orderByString, string.Empty))
            {
                resultList = new List<Model.AdminCenterStructure.FixedAsset>();
                while (dr.Read())
                {
                    var model = new Model.AdminCenterStructure.FixedAsset
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        AssetName = dr.IsDBNull(dr.GetOrdinal("AssetName")) ? "" : dr.GetString(dr.GetOrdinal("AssetName")),
                        AssetNo = dr.IsDBNull(dr.GetOrdinal("AssetNo")) ? "" : dr.GetString(dr.GetOrdinal("AssetNo")),
                        BuyDate = dr.GetDateTime(dr.GetOrdinal("BuyDate")),
                        Cost = dr.IsDBNull(dr.GetOrdinal("Cost")) ? 0 : dr.GetDecimal(dr.GetOrdinal("Cost")),
                        Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark"))
                    };
                    resultList.Add(model);
                }
            }
            return resultList;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">固定资产管理实体</param>
        /// <returns></returns>
        public bool Add(Model.AdminCenterStructure.FixedAsset model)
        {
            if (model == null) return false;

            var strSql = new StringBuilder();
            strSql.Append(
                " INSERT INTO [tbl_FixedAsset] ([CompanyId],[AssetNo],[AssetName],[BuyDate],[Cost],[Remark],[IssueTime],[OperatorId]) VALUES (@CompanyId,@AssetNo,@AssetName,@BuyDate,@Cost,@Remark,@IssueTime,@OperatorId);select @@identity;  ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "AssetNo", DbType.String, model.AssetNo);
            _db.AddInParameter(dc, "AssetName", DbType.String, model.AssetName);
            _db.AddInParameter(dc, "BuyDate", DbType.DateTime, model.BuyDate);
            if (model.Cost.HasValue)
                _db.AddInParameter(dc, "Cost", DbType.Decimal, model.Cost.Value);
            else _db.AddInParameter(dc, "Cost", DbType.Decimal, DBNull.Value);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null)
            {
                return false;
            }

            model.Id = Toolkit.Utils.GetInt(obj.ToString());
            return true;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">固定资产管理实体</param>
        /// <returns></returns>
        public bool Update(Model.AdminCenterStructure.FixedAsset model)
        {
            if (model == null || model.Id <= 0) return false;

            var strSql = new StringBuilder();
            strSql.Append(
                " UPDATE [tbl_FixedAsset] SET [AssetNo] = @AssetNo,[AssetName] = @AssetName,[BuyDate] = @BuyDate,[Cost] = @Cost,[Remark] = @Remark,[OperatorId] = @OperatorId WHERE [Id] = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            _db.AddInParameter(dc, "AssetNo", DbType.String, model.AssetNo);
            _db.AddInParameter(dc, "AssetName", DbType.String, model.AssetName);
            _db.AddInParameter(dc, "BuyDate", DbType.DateTime, model.BuyDate);
            if (model.Cost.HasValue)
                _db.AddInParameter(dc, "Cost", DbType.Decimal, model.Cost.Value);
            else _db.AddInParameter(dc, "Cost", DbType.Decimal, DBNull.Value);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "Id", DbType.Int32, model.Id);

            return DbHelper.ExecuteSql(dc, _db) > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="id">固定资产管理编号</param>
        /// <returns></returns>
        public bool Delete(int companyId, int id)
        {
            if (companyId <= 0 || id <= 0) return false;

            var strSql = new StringBuilder();
            strSql.Append(" delete from tbl_FixedAsset where CompanyId = @CompanyId and Id = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(dc, "Id", DbType.Int32, id);

            return DbHelper.ExecuteSql(dc, _db) > 0;
        }
        #endregion
    }
}
