using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.DAL.PersonalCenterStructure
{
    using System.Data;

    using EyouSoft.IDAL.PersonalCenterStructure;
    using EyouSoft.Model.EnumType.PersonalCenterStructure;
    using EyouSoft.Model.PersonalCenterStructure;
    using EyouSoft.Toolkit.DAL;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    public class DUserMemo:DALBase,IUserMemo
    {
        private Database _db = null;

        public DUserMemo()
        {
            _db = this.SystemStore;
        }

        #region IUserMemo 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl">个人备忘实体</param>
        /// <returns>True：成功 False：失败</returns>
        public bool Add(UserMemorandum mdl)
        {
            var sql = new StringBuilder();
            sql.Append(" INSERT  INTO [dbo].[tbl_UserMemorandum]");
            sql.Append("         ( [CompanyId] ,");
            sql.Append("           [UserId] ,");
            sql.Append("           [Title] ,");
            sql.Append("           [Content] ,");
            sql.Append("           [AlertTime] ,");
            sql.Append("           [State] ,");
            sql.Append("           [IssueTime],[ZxsId] ");
            sql.Append("         )");
            sql.Append(" VALUES  ( @CompanyId ,");
            sql.Append("           @UserId ,");
            sql.Append("           @Title ,");
            sql.Append("           @Content ,");
            sql.Append("           @AlertTime ,");
            sql.Append("           @State ,");
            sql.Append("           @IssueTime,@ZxsId ");
            sql.Append("         )");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc,"CompanyId",DbType.Int32,mdl.CompanyId);
            this._db.AddInParameter(dc,"UserId",DbType.Int32,mdl.UserId);
            this._db.AddInParameter(dc,"Title",DbType.String,mdl.Title);
            this._db.AddInParameter(dc,"Content",DbType.String,mdl.Content);
            this._db.AddInParameter(dc,"AlertTime",DbType.DateTime,mdl.AlertTime);
            this._db.AddInParameter(dc,"State",DbType.Byte,(int)mdl.State);
            this._db.AddInParameter(dc,"IssueTime",DbType.DateTime,mdl.IssueTime);
            this._db.AddInParameter(dc, "ZxsId", DbType.AnsiStringFixedLength, mdl.ZxsId);
            return DbHelper.ExecuteSql(dc,this._db)>0;
        }

        /// <summary>
        ///修改
        /// </summary>
        /// <param name="mdl">个人备忘实体</param>
        /// <returns>True：成功 False：失败</returns>
        public bool Upd(UserMemorandum mdl)
        {
            var sql = new StringBuilder();
            sql.Append(" UPDATE  [dbo].[tbl_UserMemorandum]");
            sql.Append(" SET     [Title] = @Title ,");
            sql.Append("         [Content] = @Content ,");
            sql.Append("         [AlertTime] = @AlertTime ,");
            sql.Append("         [State] = @State");
            sql.Append(" WHERE   Id = @Id");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc, "Id", DbType.Int32, mdl.Id);
            this._db.AddInParameter(dc, "Title", DbType.String, mdl.Title);
            this._db.AddInParameter(dc, "Content", DbType.String, mdl.Content);
            this._db.AddInParameter(dc, "AlertTime", DbType.DateTime, mdl.AlertTime);
            this._db.AddInParameter(dc, "State", DbType.Byte, (int)mdl.State);
            return DbHelper.ExecuteSql(dc,this._db)>0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>True：成功 False：失败</returns>
        public bool Del(int id)
        {
            var sql = new StringBuilder("DELETE  FROM [dbo].[tbl_UserMemorandum] WHERE   Id = @Id");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc,"Id",DbType.Int32,id);
            return DbHelper.ExecuteSql(dc,this._db)>0;
        }

        /// <summary>
        /// 获取个人备忘实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>个人备忘实体</returns>
        public UserMemorandum GetMdl(int id)
        {
            var sql = new StringBuilder();
            var mdl = new UserMemorandum();
            sql.Append(" SELECT  [Id] ,");
            sql.Append("         [CompanyId] ,");
            sql.Append("         [UserId] ,");
            sql.Append("         [Title] ,");
            sql.Append("         [Content] ,");
            sql.Append("         [AlertTime] ,");
            sql.Append("         [State] ,");
            sql.Append("         [IssueTime],[ZxsId] ");
            sql.Append(" FROM    [dbo].[tbl_UserMemorandum]");
            sql.Append(" WHERE   Id = @Id");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc,"Id",DbType.Int32,id);
            using (var dr=DbHelper.ExecuteReader(dc,this._db))
            {
                while (dr.Read())
                {
                    mdl.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    mdl.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    mdl.UserId = dr.GetInt32(dr.GetOrdinal("UserId"));
                    mdl.Title = dr["Title"].ToString();
                    mdl.Content = dr["Content"].ToString();
                    mdl.AlertTime = dr.GetDateTime(dr.GetOrdinal("AlertTime"));
                    mdl.State = (MemorandumState)dr.GetByte(dr.GetOrdinal("State"));
                    mdl.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    mdl.ZxsId = dr["ZxsId"].ToString();
                }
            }
            return mdl;
        }

        /// <summary>
        /// 获取个人备忘列表
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="operatorId">当前操作者编号</param>
        /// <param name="search">搜索实体</param>
        /// <returns>个人备忘列表</returns>
        public IList<UserMemorandum> GetLst(int pageSize, int pageIndex, ref int recordCount, int companyId, int operatorId,UserMemoSearch search)
        {
            IList<UserMemorandum> list = new List<UserMemorandum>();
            string tableName = "tbl_UserMemorandum";
            string fields = "Id,CompanyId,UserId,Title,Content,AlertTime,State,IssueTime,ZxsId";
            string orderbyStr = " IssueTime Desc ";
            StringBuilder strWhere = new StringBuilder();
            if (companyId > 0)
                strWhere.AppendFormat("CompanyId={0} ", companyId);
            //TODO:根据OperatorId获取相关权限
            if (operatorId > 0)
                strWhere.AppendFormat("AND UserId={0} ",operatorId);
            if (search!=null)
            {
                if (!string.IsNullOrEmpty(search.Title))
                {
                    strWhere.AppendFormat("AND Title LIKE '%{0}%' ", search.Title);
                }
                if (search.MemoTimeS.HasValue)
                {
                    strWhere.AppendFormat("AND AlertTime >= '{0}' ", search.MemoTimeS);
                }
                if (search.MemoTimeE.HasValue)
                {
                    strWhere.AppendFormat("AND AlertTime < '{0}' ", search.MemoTimeE.Value.AddDays(1));                    
                }
                if (!string.IsNullOrEmpty(search.ZxsId))
                {
                    strWhere.AppendFormat("AND ZxsId='{0}' ", search.ZxsId);
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields, strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    list.Add(new UserMemorandum()
                        {
                            Id = dr.GetInt32(dr.GetOrdinal("Id")),
                            CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                            UserId = dr.GetInt32(dr.GetOrdinal("UserId")),
                            Title = dr["Title"].ToString(),
                            Content = dr["Content"].ToString(),
                            AlertTime = dr.GetDateTime(dr.GetOrdinal("AlertTime")),
                            State = (MemorandumState)dr.GetByte(dr.GetOrdinal("State")),
                            IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                            ZxsId = dr["ZxsId"].ToString()
                        });
                }
            }
            return list;
        }

        #endregion
    }
}
