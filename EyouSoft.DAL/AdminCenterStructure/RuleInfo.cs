using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.AdminCenterStructure
{
    public class RuleInfo : DALBase, IDAL.AdminCenterStructure.IRuleInfo
    {
        private readonly Database _db;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public RuleInfo()
        {
            _db = this.SystemStore;
        }
        #endregion 构造函数

        #region 实现接口公共方法
        /// <summary>
        /// 获取规章制度实体信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.AdminCenterStructure.RuleInfo GetModel(int companyId, int id)
        {
            Model.AdminCenterStructure.RuleInfo model = null;
            if (companyId <= 0 || id <= 0) return model;

            var strSql = new StringBuilder();

            strSql.Append(
                " SELECT [Id],[CompanyId],[RoleNo],[Title],[RoleContent],[FilePath],[OperatorId],[IssueTime] FROM [tbl_RuleInfo] ");
            strSql.Append(" where CompanyId = @CompanyId and Id = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            _db.AddInParameter(dc, "Id", DbType.Int32, id);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new Model.AdminCenterStructure.RuleInfo
                        {
                            Id = id,
                            CompanyId = companyId,
                            RoleNo =
                                dr.IsDBNull(dr.GetOrdinal("RoleNo"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("RoleNo")),
                            Title =
                                dr.IsDBNull(dr.GetOrdinal("Title")) ? string.Empty : dr.GetString(dr.GetOrdinal("Title")),
                            RoleContent =
                                dr.IsDBNull(dr.GetOrdinal("RoleContent"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("RoleContent")),
                            FilePath =
                                dr.IsDBNull(dr.GetOrdinal("FilePath"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("FilePath")),
                            OperatorId =
                                dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId"))
                        };
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                }
            }

            return model;
        }

        /// <summary>
        /// 获取规章制度信息集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="companyId"></param>
        /// <param name="ruleNo">规章制度编号</param>
        /// <param name="title">规章制度标题</param>      
        /// <returns></returns>
        public IList<Model.AdminCenterStructure.RuleInfo> GetList(int pageSize, int pageIndex, ref int recordCount, int companyId
            , string ruleNo, string title)
        {
            IList<Model.AdminCenterStructure.RuleInfo> resultList;
            string tableName = "tbl_RuleInfo";
            string fields = " [Id],[Title],RoleNo";
            string query = string.Format("[CompanyId]={0}", companyId);
            if (!string.IsNullOrEmpty(ruleNo))
            {
                query = query + string.Format(" AND RoleNo LIKE '%{0}%' ", Toolkit.Utils.ReplaceXmlSpecialCharacter(ruleNo));
            }
            if (!string.IsNullOrEmpty(title))
            {
                query = query + string.Format(" AND Title LIKE '%{0}%' ", Toolkit.Utils.ReplaceXmlSpecialCharacter(title));
            }
            string orderByString = " IssueTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query
                , orderByString, string.Empty))
            {
                resultList = new List<Model.AdminCenterStructure.RuleInfo>();
                while (dr.Read())
                {
                    var model = new Model.AdminCenterStructure.RuleInfo
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        Title = dr.IsDBNull(dr.GetOrdinal("Title")) ? "" : dr.GetString(dr.GetOrdinal("Title")),
                        RoleNo = dr.IsDBNull(dr.GetOrdinal("RoleNo")) ? "" : dr.GetString(dr.GetOrdinal("RoleNo"))
                    };
                    resultList.Add(model);
                }
            }
            return resultList;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">合同信息实体</param>
        /// <returns></returns>
        public bool Add(Model.AdminCenterStructure.RuleInfo model)
        {
            if (model == null || model.CompanyId <= 0) return false;

            var strSql = new StringBuilder();

            strSql.Append(" INSERT INTO [tbl_RuleInfo] ([CompanyId],[RoleNo],[Title],[RoleContent],[FilePath],[OperatorId],[IssueTime])     VALUES (@CompanyId,@RoleNo,@Title,@RoleContent,@FilePath,@OperatorId,@IssueTime); ");
            strSql.Append(" select @@Identity; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "RoleNo", DbType.String, model.RoleNo);
            _db.AddInParameter(dc, "Title", DbType.String, model.Title);
            _db.AddInParameter(dc, "RoleContent", DbType.String, model.RoleContent);
            _db.AddInParameter(dc, "FilePath", DbType.String, model.FilePath);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "IssueTime", DbType.DateTime, DateTime.Now);

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
        /// <param name="model">合同信息实体</param>
        /// <returns></returns>
        public bool Update(Model.AdminCenterStructure.RuleInfo model)
        {
            if (model == null || model.Id <= 0) return false;

            var strSql = new StringBuilder();

            strSql.Append(" UPDATE [tbl_RuleInfo]  SET [RoleNo] = @RoleNo,[Title] = @Title,[RoleContent] = @RoleContent,[FilePath] = @FilePath,[OperatorId] = @OperatorId WHERE Id = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            _db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            _db.AddInParameter(dc, "RoleNo", DbType.String, model.RoleNo);
            _db.AddInParameter(dc, "Title", DbType.String, model.Title);
            _db.AddInParameter(dc, "RoleContent", DbType.String, model.RoleContent);
            _db.AddInParameter(dc, "FilePath", DbType.String, model.FilePath);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);

            return DbHelper.ExecuteSql(dc, _db) > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="id">规章制度编号</param>
        /// <returns></returns>
        public bool Delete(int companyId, int id)
        {
            if (companyId <= 0 || id <= 0) return false;

            var strSql = new StringBuilder();

            strSql.Append(
                " insert into tbl_SysDeletedFileQue (FilePath) select FilePath from tbl_RuleInfo where Id = @Id and [CompanyId] = @CompanyId and FilePath is not null and len(FilePath) > 0; ");
            strSql.Append(" delete from [tbl_RuleInfo]  WHERE Id = @Id and [CompanyId] = @CompanyId; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            _db.AddInParameter(dc, "Id", DbType.Int32, id);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSqlTrans(dc, _db) > 0;
        }
        #endregion 实现接口公共方法
    }
}
