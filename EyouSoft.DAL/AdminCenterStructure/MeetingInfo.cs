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
    /// 行政中心-会议记录
    /// </summary>
    public class MeetingInfo : DALBase, IDAL.AdminCenterStructure.IMeetingInfo
    {
        private readonly Database _db;
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public MeetingInfo()
        {
            _db = this.SystemStore;
        }
        #endregion

        #region 实现接口公共方法
        /// <summary>
        /// 获取会议记录管理实体信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.AdminCenterStructure.MeetingInfo GetModel(int companyId, int id)
        {
            Model.AdminCenterStructure.MeetingInfo model = null;
            if (companyId <= 0 || id <= 0) return model;

            var strSql = new StringBuilder();

            strSql.Append(
                " SELECT [Id],[CompanyId],[MetttingNo],[Title],[Personal],[BeginDate],[EndDate],[Location],[Remark],[IssueTime],[OperatorId] FROM [tbl_MeetingInfo] where Id = @Id and CompanyId = @CompanyId; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.Int32, id);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new Model.AdminCenterStructure.MeetingInfo
                        {
                            Id = id,
                            CompanyId = companyId,
                            MetttingNo =
                                dr.IsDBNull(dr.GetOrdinal("MetttingNo"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("MetttingNo")),
                            Title =
                                dr.IsDBNull(dr.GetOrdinal("Title")) ? string.Empty : dr.GetString(dr.GetOrdinal("Title")),
                            Personal =
                                dr.IsDBNull(dr.GetOrdinal("Personal"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Personal")),
                            Location =
                                dr.IsDBNull(dr.GetOrdinal("Location"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Location")),
                            Remark =
                                dr.IsDBNull(dr.GetOrdinal("Remark"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Remark")),
                            OperatorId =
                                dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId"))
                        };
                    if (!dr.IsDBNull(dr.GetOrdinal("BeginDate"))) model.BeginDate = dr.GetDateTime(dr.GetOrdinal("BeginDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("EndDate"))) model.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                }
            }

            return model;
        }
        /// <summary>
        /// 获取会议记录管理信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="companyId">公司编号</param>
        /// <param name="meetingNo">会议编号</param>
        /// <param name="meetingTile">会议主题</param>
        /// <param name="beginStart">会议时间开始</param>
        /// <param name="beginEnd">会议时间结束</param>
        /// <returns></returns>
        public IList<Model.AdminCenterStructure.MeetingInfo> GetList(int pageSize, int pageIndex, ref int recordCount, int companyId
            , string meetingNo, string meetingTile, DateTime? beginStart, DateTime? beginEnd)
        {
            IList<Model.AdminCenterStructure.MeetingInfo> resultList;
            string tableName = "tbl_MeetingInfo";
            string fields = " [Id],[MetttingNo],[Title],[Personal],[BeginDate],[EndDate],[Location],[Remark] ";
            string query = string.Format("[CompanyId]={0}", companyId);
            if (!string.IsNullOrEmpty(meetingNo))
            {
                query = query + string.Format(" AND MetttingNo LIKE'%{0}%'", Toolkit.Utils.ReplaceXmlSpecialCharacter(meetingNo));
            }
            if (!string.IsNullOrEmpty(meetingTile))
            {
                query = query + string.Format(" AND Title LIKE'%{0}%'", Toolkit.Utils.ReplaceXmlSpecialCharacter(meetingTile));
            }
            if (beginStart.HasValue)
            {
                query = query + string.Format(" AND DATEDIFF(mi,'{0}',BeginDate)>=0", beginStart);
            }
            if (beginEnd.HasValue)
            {
                query = query + string.Format(" AND DATEDIFF(mi,BeginDate,'{0}')>=0", beginEnd);
            }
            string orderByString = " IssueTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query
                , orderByString, string.Empty))
            {
                resultList = new List<Model.AdminCenterStructure.MeetingInfo>();
                while (dr.Read())
                {
                    var model = new Model.AdminCenterStructure.MeetingInfo
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        BeginDate = dr.GetDateTime(dr.GetOrdinal("BeginDate")),
                        EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate")),
                        Location = dr.IsDBNull(dr.GetOrdinal("Location")) ? "" : dr.GetString(dr.GetOrdinal("Location")),
                        MetttingNo = dr.IsDBNull(dr.GetOrdinal("MetttingNo")) ? "" : dr.GetString(dr.GetOrdinal("MetttingNo")),
                        Personal = dr.IsDBNull(dr.GetOrdinal("Personal")) ? "" : dr.GetString(dr.GetOrdinal("Personal")),
                        Title = dr.IsDBNull(dr.GetOrdinal("Title")) ? "" : dr.GetString(dr.GetOrdinal("Title")),
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
        /// <param name="model">会议记录管理实体</param>
        /// <returns></returns>
        public bool Add(Model.AdminCenterStructure.MeetingInfo model)
        {
            if (model == null) return false;

            var strSql = new StringBuilder();

            strSql.Append(" INSERT INTO [tbl_MeetingInfo] ([CompanyId],[MetttingNo],[Title],[Personal],[BeginDate],[EndDate],[Location],[Remark],[IssueTime],[OperatorId]) VALUES (@CompanyId,@MetttingNo,@Title,@Personal,@BeginDate,@EndDate,@Location,@Remark,@IssueTime,@OperatorId);SELECT @@identity; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "MetttingNo", DbType.String, model.MetttingNo);
            _db.AddInParameter(dc, "Title", DbType.String, model.Title);
            _db.AddInParameter(dc, "Personal", DbType.String, model.Personal);
            _db.AddInParameter(dc, "BeginDate", DbType.DateTime, model.BeginDate);
            _db.AddInParameter(dc, "EndDate", DbType.DateTime, model.EndDate);
            _db.AddInParameter(dc, "Location", DbType.String, model.Location);
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
        /// <param name="model">会议记录管理实体</param>
        /// <returns></returns>
        public bool Update(Model.AdminCenterStructure.MeetingInfo model)
        {
            if (model == null || model.Id <= 0) return false;

            var strSql = new StringBuilder();

            strSql.Append(" UPDATE [tbl_MeetingInfo] SET [MetttingNo] = @MetttingNo,[Title] = @Title,[Personal] = @Personal,[BeginDate] = @BeginDate,[EndDate] = @EndDate,[Location] = @Location,[Remark] = @Remark,[OperatorId] = @OperatorId WHERE Id = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            _db.AddInParameter(dc, "MetttingNo", DbType.String, model.MetttingNo);
            _db.AddInParameter(dc, "Title", DbType.String, model.Title);
            _db.AddInParameter(dc, "Personal", DbType.String, model.Personal);
            _db.AddInParameter(dc, "BeginDate", DbType.DateTime, model.BeginDate);
            _db.AddInParameter(dc, "EndDate", DbType.DateTime, model.EndDate);
            _db.AddInParameter(dc, "Location", DbType.String, model.Location);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);

            return DbHelper.ExecuteSql(dc, _db) > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="id">会议记录管理编号</param>
        /// <returns></returns>
        public bool Delete(int companyId, int id)
        {
            if (companyId <= 0 || id <= 0) return false;

            var strSql = new StringBuilder();

            strSql.Append(" delete from tbl_MeetingInfo where CompanyId = @CompanyId and Id = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.Int32, id);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(dc, _db) > 0;
        }
        #endregion
    }
}
