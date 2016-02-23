using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.AdminCenterStructure
{
    /// <summary>
    /// 行政中心-合同管理DAL
    /// </summary>
    public class ContractInfo : DALBase, IDAL.AdminCenterStructure.IContractInfo
    {
        private readonly Database _db;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ContractInfo()
        {
            _db = this.SystemStore;
        }
        #endregion

        #region 实现接口公共方法
        /// <summary>
        /// 获取合同管理实体信息
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.AdminCenterStructure.ContractInfo GetModel(int CompanyId, int Id)
        {
            Model.AdminCenterStructure.ContractInfo model = null;
            if (CompanyId <= 0 || Id <= 0) return model;

            var strSql = new StringBuilder();
            strSql.Append(
                " SELECT [Id],[CompanyId],[StaffNo],[StaffName],[BeginDate],[EndDate],[ContractStatus],[Remark],[OperatorId],[IssueTime] FROM [tbl_ContractInfo] where CompanyId = @CompanyId and Id = @Id ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.Int32, Id);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, CompanyId);

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new Model.AdminCenterStructure.ContractInfo();
                    if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                        model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                        model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("StaffNo")))
                        model.StaffNo = dr.GetString(dr.GetOrdinal("StaffNo"));
                    if (!dr.IsDBNull(dr.GetOrdinal("StaffName")))
                        model.StaffName = dr.GetString(dr.GetOrdinal("StaffName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("BeginDate")))
                        model.BeginDate = dr.GetDateTime(dr.GetOrdinal("BeginDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("EndDate")))
                        model.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContractStatus")))
                        model.ContractStatus =
                            (Model.EnumType.AdminCenterStructure.ContractStatus)
                            dr.GetInt32(dr.GetOrdinal("ContractStatus"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        model.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                        model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                }
            }

            return model;
        }
        /// <summary>
        /// 获取合同信息集合
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="CompanyId">公司编号</param>
        /// <param name="SearchInfo">合同管理查询实体</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.AdminCenterStructure.ContractInfo> GetList(int PageSize, int PageIndex, ref int RecordCount, int CompanyId, EyouSoft.Model.AdminCenterStructure.ContractSearchInfo SearchInfo)
        {
            IList<EyouSoft.Model.AdminCenterStructure.ContractInfo> ResultList = null;
            string tableName = "tbl_ContractInfo";
            string fields = " [Id],[StaffNo],[StaffName],[BeginDate],[EndDate],[ContractStatus],[Remark] ";
            string query = string.Format("[CompanyId]={0}", CompanyId);
            if (!string.IsNullOrEmpty(SearchInfo.StaffNo))
            {
                query = query + string.Format("AND StaffNo LIKE '%{0}%' ", SearchInfo.StaffNo);
            }
            if (!string.IsNullOrEmpty(SearchInfo.StaffName))
            {
                query = query + string.Format("AND StaffName LIKE '%{0}%' ", EyouSoft.Toolkit.Utils.ReplaceXmlSpecialCharacter(SearchInfo.StaffName));
            }
            if (SearchInfo.BeginFrom.HasValue)
            {
                query = query + string.Format(" AND DATEDIFF(DAY,'{0}',BeginDate)>=0", SearchInfo.BeginFrom);
            }
            if (SearchInfo.BeginTo.HasValue)
            {
                query = query + string.Format(" AND DATEDIFF(DAY,BeginDate,'{0}')>=0", SearchInfo.BeginTo);
            }
            if (SearchInfo.EndFrom.HasValue)
            {
                query = query + string.Format(" AND DATEDIFF(DAY,'{0}',EndDate)>=0", SearchInfo.EndFrom);
            }
            if (SearchInfo.EndTo.HasValue)
            {
                query = query + string.Format(" AND DATEDIFF(DAY,EndDate,'{0}')>=0", SearchInfo.EndTo);
            }
            string orderByString = " IssueTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, PageSize, PageIndex, ref RecordCount, tableName, fields, query
                , orderByString, string.Empty))
            {
                ResultList = new List<EyouSoft.Model.AdminCenterStructure.ContractInfo>();
                while (dr.Read())
                {
                    EyouSoft.Model.AdminCenterStructure.ContractInfo model = new EyouSoft.Model.AdminCenterStructure.ContractInfo()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        BeginDate = dr.GetDateTime(dr.GetOrdinal("BeginDate")),
                        EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate")),
                        ContractStatus = (EyouSoft.Model.EnumType.AdminCenterStructure.ContractStatus)Enum.Parse(typeof(EyouSoft.Model.EnumType.AdminCenterStructure.ContractStatus), dr.GetInt32(dr.GetOrdinal("ContractStatus")).ToString()),
                        Remark = dr.IsDBNull(dr.GetOrdinal("Remark")) ? "" : dr.GetString(dr.GetOrdinal("Remark")),
                        StaffName = dr.IsDBNull(dr.GetOrdinal("StaffName")) ? "" : dr.GetString(dr.GetOrdinal("StaffName")),
                        StaffNo = dr.GetString(dr.GetOrdinal("StaffNo"))
                    };
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">合同信息实体</param>
        /// <returns></returns>
        public bool Add(Model.AdminCenterStructure.ContractInfo model)
        {
            if (model == null) return false;

            var strSql = new StringBuilder();

            strSql.Append(" INSERT INTO [tbl_ContractInfo] ([CompanyId],[StaffNo],[StaffName],[BeginDate],[EndDate],[ContractStatus],[Remark],[OperatorId],[IssueTime]) VALUES (@CompanyId,@StaffNo,@StaffName,@BeginDate,@EndDate,@ContractStatus,@Remark,@OperatorId,@IssueTime);select @@identity; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "StaffNo", DbType.String, model.StaffNo);
            _db.AddInParameter(dc, "StaffName", DbType.String, model.StaffName);
            _db.AddInParameter(dc, "BeginDate", DbType.DateTime, model.BeginDate);
            _db.AddInParameter(dc, "EndDate", DbType.DateTime, model.EndDate);
            _db.AddInParameter(dc, "ContractStatus", DbType.Int32, (int)model.ContractStatus);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
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
        public bool Update(Model.AdminCenterStructure.ContractInfo model)
        {
            if (model == null || model.Id <= 0) return false;

            var strSql = new StringBuilder();

            strSql.Append(
                " update [tbl_ContractInfo] set [StaffNo] = @StaffNo,[StaffName] = @StaffName,[BeginDate] = @BeginDate,[EndDate] = @EndDate,[ContractStatus] = @ContractStatus,[Remark] = @Remark,[OperatorId] = @OperatorId where [CompanyId] = @CompanyId and [Id] = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "StaffNo", DbType.String, model.StaffNo);
            _db.AddInParameter(dc, "StaffName", DbType.String, model.StaffName);
            _db.AddInParameter(dc, "BeginDate", DbType.DateTime, model.BeginDate);
            _db.AddInParameter(dc, "EndDate", DbType.DateTime, model.EndDate);
            _db.AddInParameter(dc, "ContractStatus", DbType.Int32, (int)model.ContractStatus);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);

            return DbHelper.ExecuteSql(dc, _db) > 0;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="CompanyId">公司编号</param>
        /// <param name="Id">合同信息编号</param>
        /// <returns></returns>
        public bool Delete(int CompanyId, int Id)
        {
            if (CompanyId <= 0 || Id <= 0) return false;

            string strSql = " delete from [tbl_ContractInfo] where [CompanyId] = @CompanyId and [Id] = @Id; ";
            DbCommand dc = _db.GetSqlStringCommand(strSql);
            _db.AddInParameter(dc, "Id", DbType.Int32, Id);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, CompanyId);

            return DbHelper.ExecuteSql(dc, _db) > 0;
        }
        #endregion
    }
}
