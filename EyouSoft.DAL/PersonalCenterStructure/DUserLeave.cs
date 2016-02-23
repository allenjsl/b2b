using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EyouSoft.IDAL.PersonalCenterStructure;
using EyouSoft.Model.EnumType.PersonalCenterStructure;
using EyouSoft.Model.PersonalCenterStructure;
using EyouSoft.Toolkit.DAL;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace EyouSoft.DAL.PersonalCenterStructure
{
    public class DUserLeave : DALBase, IUserLeave
    {
        private Database _db = null;

        public DUserLeave()
        {
            _db = this.SystemStore;
        }

        #region IUserLeave成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl">请假申请</param>
        /// <returns>True：成功 False：失败</returns>
        public bool Add(UserLeave mdl)
        {
            var sql = new StringBuilder();
            sql.Append(" INSERT  INTO [dbo].[tbl_UserLeave]");
            sql.Append("         ( [UserId] ,");
            sql.Append("           [StartDate] ,");
            sql.Append("           [StartTime] ,");
            sql.Append("           [EndDate] ,");
            sql.Append("           [EndTime] ,");
            sql.Append("           [Reason] ,");
            sql.Append("           [Nature] ,");
            sql.Append("           [Situation] ,");
            sql.Append("           [IssueTime] ,");
            sql.Append("           [CompanyId],[ZxsId] ");
            sql.Append("         )");
            sql.Append(" VALUES  ( @UserId ,");
            sql.Append("           @StartDate ,");
            sql.Append("           @StartTime ,");
            sql.Append("           @EndDate ,");
            sql.Append("           @EndTime ,");
            sql.Append("           @Reason ,");
            sql.Append("           @Nature ,");
            sql.Append("           @Situation ,");
            sql.Append("           @IssueTime ,");
            sql.Append("           @CompanyId,@ZxsId ");
            sql.Append("         )");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc, "UserId", DbType.Int32, mdl.UserId);
            this._db.AddInParameter(dc, "StartDate", DbType.DateTime, mdl.StartDate);
            this._db.AddInParameter(dc, "StartTime", DbType.String, mdl.StartTime);
            this._db.AddInParameter(dc, "EndDate", DbType.DateTime, mdl.EndDate);
            this._db.AddInParameter(dc, "EndTime", DbType.String, mdl.EndTime);
            this._db.AddInParameter(dc, "Reason", DbType.String, mdl.Reason);
            this._db.AddInParameter(dc, "Nature", DbType.Byte, (byte)mdl.Nature);
            this._db.AddInParameter(dc, "Situation", DbType.String, mdl.Situation);
            this._db.AddInParameter(dc, "IssueTime", DbType.DateTime, mdl.IssueTime);
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, mdl.CompanyId);
            this._db.AddInParameter(dc, "ZxsId", DbType.AnsiStringFixedLength, mdl.ZxsId);
            return DbHelper.ExecuteSql(dc, this._db) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mdl">请假申请</param>
        /// <returns>-1:已审核不允许删除 1:修改成功 0:修改失败</returns>
        public int Upd(UserLeave mdl)
        {

            var dc = this._db.GetStoredProcCommand("proc_UserLeave_Update");
            this._db.AddInParameter(dc, "Id", DbType.Int32, mdl.LeaveId);
            this._db.AddInParameter(dc, "StartDate", DbType.DateTime, mdl.StartDate);
            this._db.AddInParameter(dc, "StartTime", DbType.String, mdl.StartTime);
            this._db.AddInParameter(dc, "EndDate", DbType.DateTime, mdl.EndDate);
            this._db.AddInParameter(dc, "EndTime", DbType.String, mdl.EndTime);
            this._db.AddInParameter(dc, "Reason", DbType.String, mdl.Reason);
            this._db.AddInParameter(dc, "Nature", DbType.Byte, (byte)mdl.Nature);
            this._db.AddInParameter(dc, "Situation", DbType.String, mdl.Situation);
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(dc, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(dc, "Result"));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>-1:请假已审核不允许删除 1:删除成功 0:删除失败</returns>
        public int Del(int id)
        {
            DbCommand dc = this._db.GetStoredProcCommand("proc_UserLeave_Delete");
            this._db.AddInParameter(dc, "Id", DbType.Int32, id);
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(dc, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(dc, "Result"));
        }

        /*/// <summary>
        /// 审批
        /// </summary>
        /// <param name="mdl">审批信息实体</param>
        /// <returns>True：成功 False：失败</returns>
        public bool SetChk(UserLeave mdl)
        {
            var sql = new StringBuilder();
            sql.Append(" UPDATE  [dbo].[tbl_UserLeave]");
            sql.Append(" SET     [CheckState] = @CheckState ,");
            sql.Append("         [OperatorId] = @OperatorId ,");
            sql.Append("         [CheckRemark] = @CheckRemark ,");
            sql.Append("         [CheckTime] = @CheckTime");
            sql.Append(" WHERE   Id = @Id");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc, "CheckState", DbType.Byte, (byte)mdl.State);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, mdl.OperatorId);
            this._db.AddInParameter(dc, "CheckRemark", DbType.String, mdl.CheckRemark);
            this._db.AddInParameter(dc, "CheckTime", DbType.DateTime, mdl.CheckTime);
            this._db.AddInParameter(dc, "Id", DbType.Int32, mdl.LeaveId);
            return DbHelper.ExecuteSql(dc, this._db) > 0;
        }*/

        /// <summary>
        /// 获取请假申请实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>True：成功 False：失败</returns>
        public UserLeave GetMdl(int id)
        {
            var sql = new StringBuilder();
            var mdl = new UserLeave();

            sql.Append(" SELECT A.* ");
            sql.Append(" ,(SELECT B.ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.OperatorId) AS ShenPiRenName ");
            sql.Append(" ,(SELECT B.ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.UserId) AS QingJiaRenName ");
            sql.Append(" ,(SELECT B.ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.ZuoFeiRenId) AS ZuoFeiRenName ");
            sql.Append(" FROM    [tbl_UserLeave] AS A");
            sql.Append(" WHERE   A.[Id] = @Id ");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc, "Id", DbType.Int32, id);
            using (var dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    mdl.LeaveId = dr.GetInt32(dr.GetOrdinal("Id"));
                    mdl.UserId = dr.GetInt32(dr.GetOrdinal("UserId"));
                    mdl.StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
                    mdl.StartTime = dr["StartTime"].ToString();
                    mdl.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
                    mdl.EndTime = dr["EndTime"].ToString();
                    mdl.Reason = dr["Reason"].ToString();
                    mdl.Nature = (LeaveNature)dr.GetByte(dr.GetOrdinal("Nature"));
                    mdl.Situation = dr["Situation"].ToString();
                    mdl.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    mdl.State = (LeaveState)dr.GetByte(dr.GetOrdinal("CheckState"));
                    mdl.OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetInt32(dr.GetOrdinal("OperatorId")) : 0;
                    mdl.CheckRemark = !dr.IsDBNull(dr.GetOrdinal("CheckRemark")) ? dr["CheckRemark"].ToString() : null;
                    mdl.CheckTime = !dr.IsDBNull(dr.GetOrdinal("CheckTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("CheckTime")) : null;
                    mdl.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));

                    mdl.UserContactName = dr["QingJiaRenName"].ToString();
                    mdl.ShenPiRenName = dr["ShenPiRenName"].ToString();
                    mdl.ZuoFeiBeiZhu = dr["ZuoFeiBeiZhu"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("ZuoFeiRenId"))) mdl.ZuoFeiRenId = dr.GetInt32(dr.GetOrdinal("ZuoFeiRenId"));
                    mdl.ZuoFeiRenName = dr["ZuoFeiRenName"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("ZuoFeiTime"))) mdl.ZuoFeiTime = dr.GetDateTime(dr.GetOrdinal("ZuoFeiTime"));
                    mdl.ZxsId = dr["ZxsId"].ToString();
                }
            }
            return mdl;
        }

        /// <summary>
        /// 获取请假申请列表
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns>请假申请列表</returns>
        public IList<UserLeave> GetLst(int pageSize, int pageIndex, ref int recordCount, int companyId, MQingJiaChaXunInfo chaXun)
        {
            IList<UserLeave> list = new List<UserLeave>();
            const string tableName = "tbl_UserLeave";
            const string fields = "Id,CompanyId,UserId,(select ContactName from tbl_CompanyUser where Id=tbl_UserLeave.UserId) as ContactName,StartDate,StartTime,EndDate,EndTime,IssueTime,Reason,Nature,Situation,CheckState,OperatorId,CheckRemark,CheckTime,ZxsId";
            const string orderbyStr = " IssueTime Desc ";
            var strWhere = new StringBuilder();
            strWhere.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (chaXun.ETime.HasValue || chaXun.STime.HasValue)
                {
                    strWhere.AppendFormat(" AND (1=0 ");
                    if (chaXun.ETime.HasValue)
                    {
                        strWhere.AppendFormat(" OR ('{0}' BETWEEN StartDate AND EndDate) ", chaXun.ETime.Value);
                    }

                    if (chaXun.STime.HasValue)
                    {
                        strWhere.AppendFormat(" OR ('{0}' BETWEEN StartDate AND EndDate) ", chaXun.STime.Value);
                    }
                    strWhere.Append(" ) ");
                }

                if (chaXun.QingJiaRenId.HasValue)
                {
                    strWhere.AppendFormat(" AND UserId={0} ", chaXun.QingJiaRenId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.QingJiaRenName))
                {
                    strWhere.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_CompanyUser AS A WHERE A.Id=tbl_UserLeave.UserId AND A.ContactName LIKE '%{0}%') ", chaXun.QingJiaRenName);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }

            using (var dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields, strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    list.Add(new UserLeave()
                    {
                        LeaveId = dr.GetInt32(dr.GetOrdinal("Id")),
                        CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                        UserId = dr.GetInt32(dr.GetOrdinal("UserId")),
                        UserContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : null,
                        StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate")),
                        StartTime = dr["StartTime"].ToString(),
                        EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate")),
                        EndTime = dr["EndTime"].ToString(),
                        Reason = dr["Reason"].ToString(),
                        Nature = (LeaveNature)dr.GetByte(dr.GetOrdinal("Nature")),
                        Situation = dr["Situation"].ToString(),
                        State = (LeaveState)dr.GetByte(dr.GetOrdinal("CheckState")),
                        OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetInt32(dr.GetOrdinal("OperatorId")) : 0,
                        CheckRemark = !dr.IsDBNull(dr.GetOrdinal("CheckRemark")) ? dr["CheckRemark"].ToString() : null,
                        CheckTime = dr.IsDBNull(dr.GetOrdinal("CheckTime")) ? null : (DateTime?)dr.GetDateTime(dr.GetOrdinal("CheckTime")),
                        IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                        ZxsId = dr["ZxsId"].ToString()
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// 获取请假状态
        /// </summary>
        /// <param name="qingJiaId">请假编号</param>
        /// <returns></returns>
        public LeaveState GetStatus(int qingJiaId)
        {
            LeaveState status = LeaveState.作废;

            var cmd = _db.GetSqlStringCommand("SELECT [CheckState] FROM [tbl_UserLeave] WHERE [Id]=@QingJiaId");
            _db.AddInParameter(cmd, "QingJiaId", DbType.Int32, qingJiaId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    status = (LeaveState)rdr.GetByte(0);
                }
            }

            return status;
        }

        /// <summary>
        /// 请假审批，返回1成功，其它失败
        /// </summary>
        /// <param name="qingJiaId">请假编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ShenPi(int qingJiaId, int companyId, LeaveState status, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE [tbl_UserLeave] SET [OperatorId]=@ShenPiRenId,[CheckRemark]=@ShenPiBeiZhu,[CheckTime]=@ShenPiTime,[CheckState]=@Status WHERE [Id]=@QingJiaId AND [CompanyId]=@CompanyId");
            _db.AddInParameter(cmd, "ShenPiRenId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "ShenPiBeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "ShenPiTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "QingJiaId", DbType.Int32, qingJiaId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 请假作废，返回1成功，其它失败
        /// </summary>
        /// <param name="qingJiaId">请假编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int ZuoFei(int qingJiaId, int companyId, LeaveState status, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE [tbl_UserLeave] SET [ZuoFeiRenId]=@ZuoFeiRenId,[ZuoFeiBeiZhu]=@ZuoFeiBeiZhu,[ZuoFeiTime]=@ZuoFeiTime,[CheckState]=@Status WHERE [Id]=@QingJiaId AND [CompanyId]=@CompanyId");
            _db.AddInParameter(cmd, "ZuoFeiRenId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "ZuoFeiBeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "ZuoFeiTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "QingJiaId", DbType.Int32, qingJiaId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }
        #endregion
    }
}
