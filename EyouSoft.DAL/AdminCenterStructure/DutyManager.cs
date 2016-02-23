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
    /// 行政中心-职务管理DAL
    /// </summary>
    public class DutyManager : DALBase, IDAL.AdminCenterStructure.IDutyManager
    {
        private readonly Database _db;
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public DutyManager()
        {
            _db = this.SystemStore;
        }
        #endregion

        #region 实现接口公共方法
        /// <summary>
        /// 获取职务信息实体
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dutyId">职务编号</param>
        /// <returns></returns>
        public Model.AdminCenterStructure.DutyManager GetModel(int companyId, int dutyId)
        {
            if (companyId <= 0 || dutyId <= 0) return null;

            var strSql = new StringBuilder();
            Model.AdminCenterStructure.DutyManager model = null;

            strSql.Append(
                " SELECT [Id],[CompanyId],[JobName],[Help],[Requirement],[Remark],[OperatorId],[IssueTime]  FROM [tbl_DutyManager] ");
            strSql.Append(" where [CompanyId] = @CompanyId and [Id] = @Id ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.Int32, dutyId);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new Model.AdminCenterStructure.DutyManager
                        {
                            CompanyId = companyId,
                            Id = dutyId,
                            JobName =
                                dr.IsDBNull(dr.GetOrdinal("JobName"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("JobName")),
                            Help = dr.IsDBNull(dr.GetOrdinal("Help")) ? string.Empty : dr.GetString(dr.GetOrdinal("Help")),
                            Requirement =
                                dr.IsDBNull(dr.GetOrdinal("Requirement"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Requirement")),
                            Remark =
                                dr.IsDBNull(dr.GetOrdinal("Remark"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Remark")),
                            OperatorId =
                                dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId")),
                        };
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                }
            }

            return model;
        }

        /// <summary>
        /// 获取公司职务信息集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<Model.AdminCenterStructure.DutyManager> GetList(int pageSize, int pageIndex, ref int recordCount, int companyId)
        {
            IList<Model.AdminCenterStructure.DutyManager> resultList;
            string tableName = "tbl_DutyManager";
            string fields = "[Id],[Help],[JobName],[Remark],[Requirement]";
            string query = string.Format("[CompanyId]={0}", companyId);
            string orderByString = " IssueTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query
                , orderByString, string.Empty))
            {
                resultList = new List<Model.AdminCenterStructure.DutyManager>();
                while (dr.Read())
                {
                    var model = new Model.AdminCenterStructure.DutyManager
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        Help = dr.IsDBNull(dr.GetOrdinal("Help")) ? "" : dr.GetString(dr.GetOrdinal("Help")),
                        JobName = dr.GetString(dr.GetOrdinal("JobName")),
                        Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark")),
                        Requirement = dr.IsDBNull(dr.GetOrdinal("Requirement")) ? "" : dr.GetString(dr.GetOrdinal("Requirement"))
                    };
                    resultList.Add(model);
                }
            };
            return resultList;
        }
        /// <summary>
        /// 获取所有职务信息（职务名称和ID值）
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<Model.AdminCenterStructure.DutyManager> GetList(int companyId)
        {
            IList<Model.AdminCenterStructure.DutyManager> resultList;
            string strSql = string.Format("SELECT [ID],[JobName] FROM [tbl_DutyManager] WHERE [CompanyId]={0} Order BY IssueTime DESC", companyId);
            DbCommand dc = this._db.GetSqlStringCommand(strSql);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                resultList = new List<Model.AdminCenterStructure.DutyManager>();
                while (dr.Read())
                {
                    var model = new Model.AdminCenterStructure.DutyManager
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        JobName = dr.GetString(dr.GetOrdinal("JobName")),
                    };
                    resultList.Add(model);
                }
            };
            return resultList;
        }
        /// <summary>
        /// 判断是否已经有用户已经使用该职务
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dutyId">职务编号</param>
        /// <returns></returns>
        public bool IsHasBeenUsed(int companyId, int dutyId)
        {
            if (companyId <= 0 || dutyId <= 0) return false;

            var strSql = new StringBuilder();

            strSql.Append(" select count(*) from tbl_PersonnelInfo where CompanyId = @CompanyId and DutyId = @DutyId; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(dc, "DutyId", DbType.Int32, dutyId);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null)
            {
                return false;
            }

            return Toolkit.Utils.GetInt(obj.ToString()) > 0;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">公司账户信息实体</param>
        /// <returns>0:失败，1：成功，-1：职务名称重复</returns>
        public int Add(Model.AdminCenterStructure.DutyManager model)
        {
            if (model == null || string.IsNullOrEmpty(model.JobName)) return 0;
            if (this.IsExists(model.JobName, 0, model.CompanyId))
            {
                return -1;
            }

            var strSql = new StringBuilder();

            strSql.Append(" INSERT INTO [tbl_DutyManager] ([CompanyId],[JobName],[Help],[Requirement],[Remark],[OperatorId],[IssueTime]) VALUES (@CompanyId,@JobName,@Help,@Requirement,@Remark,@OperatorId,@IssueTime);select @@identity; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "JobName", DbType.String, model.JobName);
            _db.AddInParameter(dc, "Help", DbType.String, model.Help);
            _db.AddInParameter(dc, "Requirement", DbType.String, model.Requirement);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "IssueTime", DbType.DateTime, DateTime.Now);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null)
            {
                return -2;
            }

            model.Id = Toolkit.Utils.GetInt(obj.ToString());
            return 1;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">公司账户信息实体</param>
        /// <returns></returns>
        public int Update(Model.AdminCenterStructure.DutyManager model)
        {
            if (model == null || model.Id <= 0 || model.CompanyId <= 0 || string.IsNullOrEmpty(model.JobName)) return 0;
            if (this.IsExists(model.JobName, model.Id, model.CompanyId))
            {
                return -1;
            }

            var strSql = new StringBuilder();
            strSql.Append(
                " UPDATE [tbl_DutyManager] SET [JobName] = @JobName,[Help] = @Help,[Requirement] = @Requirement,[Remark] = @Remark,[OperatorId] = @OperatorId WHERE Id = @Id ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "JobName", DbType.String, model.JobName);
            _db.AddInParameter(dc, "Help", DbType.String, model.Help);
            _db.AddInParameter(dc, "Requirement", DbType.String, model.Requirement);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "Id", DbType.Int32, model.Id);

            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : -2;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dutyId"></param>
        /// <returns></returns>
        public bool Delete(int companyId, int dutyId)
        {
            if (companyId <= 0 || dutyId <= 0) return false;

            var strSql = new StringBuilder();
            strSql.Append(" delete from  tbl_DutyManager where CompanyId = @CompanyId and Id = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(dc, "Id", DbType.Int32, dutyId);

            return DbHelper.ExecuteSql(dc, _db) > 0;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 判断是否存在重复的职务名称
        /// </summary>
        /// <param name="jobName">职务名称</param>
        /// <param name="id">职务ID</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        private bool IsExists(string jobName, int id, int companyId)
        {
            int count = 0;
            string strSql = " SELECT COUNT(1) FROM tbl_DutyManager WHERE JobName=@JobName AND CompanyId=@CompanyId ";
            if (id > 0)
            {
                strSql += " AND [ID]<>@Id";
            }
            DbCommand dc = this._db.GetSqlStringCommand(strSql);
            if (id > 0)
            {
                this._db.AddInParameter(dc, "Id", DbType.Int32, id);
            }
            this._db.AddInParameter(dc, "JobName", DbType.String, jobName);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    count = Convert.ToInt32(dr[0].ToString());
                }
            }
            return count > 0;
        }
        #endregion 私有方法
    }
}
