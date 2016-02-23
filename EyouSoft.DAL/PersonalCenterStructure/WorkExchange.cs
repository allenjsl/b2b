using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
namespace EyouSoft.DAL.PersonalCenterStructure
{
    using System.Xml.Linq;

    using EyouSoft.Model.EnumType.PersonalCenterStructure;
    using EyouSoft.Model.PersonalCenterStructure;
    using EyouSoft.Toolkit;

    /// <summary>
    /// 个人中心-交流专区数据层
    /// </summary>
    /// 鲁功源 2011-01-17
    public class WorkExchange : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.PersonalCenterStructure.IWorkExchange
    {
        #region 变量
        private const string Sql_WorkExchange_Delete = "update tbl_WorkExchange set IsDelete='1' where ExchangeId in({0})";
        //private EyouSoft.Data.EyouSoftTBL dcDal = null;
        private Database _db = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkExchange()
        {
            _db = this.SystemStore;
            //dcDal = new EyouSoft.Data.EyouSoftTBL(this.SystemStore.ConnectionString);
        }
        #endregion

        #region IWorkExchange 成员
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">交流专区实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(EyouSoft.Model.PersonalCenterStructure.WorkExchange model)
        {
            DbCommand dc = this._db.GetStoredProcCommand("proc_WorkExchange_Insert");
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(dc, "Type", DbType.Byte, (int)model.Type);
            this._db.AddInParameter(dc, "Title", DbType.String, model.Title);
            this._db.AddInParameter(dc, "Description", DbType.String, model.Description);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(dc, "CreateTime", DbType.DateTime, model.CreateTime);
            this._db.AddInParameter(dc, "IsAnonymous", DbType.String, model.IsAnonymous ? "1" : "0");
            this._db.AddInParameter(dc, "FilePath", DbType.String, model.FilePath);
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            this._db.AddInParameter(dc, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            DbHelper.RunProcedure(dc, this._db);
            object obj = this._db.GetParameterValue(dc, "Result");
            return int.Parse(obj.ToString()) > 0 ? true : false;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">交流专区实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Update(EyouSoft.Model.PersonalCenterStructure.WorkExchange model)
        {
            DbCommand dc = this._db.GetStoredProcCommand("proc_WorkExchange_Update");
            this._db.AddInParameter(dc, "ExchangeId", DbType.Int32, model.ExchangeId);
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(dc, "Type", DbType.Byte, (int)model.Type);
            this._db.AddInParameter(dc, "Title", DbType.String, model.Title);
            this._db.AddInParameter(dc, "Description", DbType.String, model.Description);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(dc, "CreateTime", DbType.DateTime, model.CreateTime);
            this._db.AddInParameter(dc, "IsAnonymous", DbType.String, model.IsAnonymous ? "1" : "0");
            this._db.AddInParameter(dc, "FilePath", DbType.String, model.FilePath);
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            object obj = this._db.GetParameterValue(dc, "Result");
            return int.Parse(obj.ToString()) > 0 ? true : false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">主键编号</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Delete(int Id)
        {
            string sql = "Update tbl_WorkExchange set IsDelete='1' WHERE  ExchangeId=@ExchangeId ";
            DbCommand dc = this._db.GetSqlStringCommand(sql);
            this._db.AddInParameter(dc, "ExchangeId", DbType.Int32, Id);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 获取交流专区实体
        /// </summary>
        /// <param name="Id">主键编号</param>
        /// <returns>交流专区实体</returns>
        public EyouSoft.Model.PersonalCenterStructure.WorkExchange GetModel(int Id)
        {
            var sql = new StringBuilder();
            var mdl = new EyouSoft.Model.PersonalCenterStructure.WorkExchange();

            sql.Append(" SELECT ExchangeId, [Type] ,");
            sql.Append("         [Title] ,");
            sql.Append("         [Description] ,");
            sql.Append("         [OperatorId] ,");
            sql.Append("(select ContactName from tbl_CompanyUser where Id=tbl_WorkExchange.OperatorId) as [OperatorName] ,");
            sql.Append("         [CreateTime] ,");
            sql.Append("         [IsAnonymous] ,");
            sql.Append("         [Clicks] ,");
            sql.Append("         [Replys],");
            sql.Append("         [FilePath],");
            sql.Append("         AcceptList=(SELECT * FROM dbo.tbl_WorkExchangeAccept A WHERE A.ExchangeId=ExchangeId FOR XML RAW,ROOT),");
            sql.Append("         ReplyList=(SELECT * FROM dbo.tbl_WorkExchangeReply B WHERE B.ExchangeId=ExchangeId FOR XML RAW,ROOT)");
            sql.Append(" ,ZxsId ");
            sql.Append(" FROM    [dbo].[tbl_WorkExchange]");
            sql.Append(" WHERE   ExchangeId = @ExchangeId");

            var dc = this._db.GetSqlStringCommand(sql.ToString());

            this._db.AddInParameter(dc, "ExchangeId", DbType.Int32, Id);

            using (var dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    mdl.ExchangeId = dr.GetInt32(dr.GetOrdinal("ExchangeId"));
                    mdl.Type = (Model.EnumType.PersonalCenterStructure.ExchangeType)dr.GetByte(dr.GetOrdinal("Type"));
                    mdl.Title = dr["Title"].ToString();
                    mdl.Description = dr["Description"].ToString();
                    mdl.OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetInt32(dr.GetOrdinal("OperatorId")) : 0;
                    mdl.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr["OperatorName"].ToString() : null;
                    mdl.CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"));
                    mdl.IsAnonymous = dr["IsAnonymous"].ToString() == "1";
                    mdl.Clicks = dr.GetInt32(dr.GetOrdinal("Clicks"));
                    mdl.Replys = dr.GetInt32(dr.GetOrdinal("Replys"));
                    mdl.AcceptList = GetWorkExchangeAcceptLst(dr["AcceptList"].ToString());
                    mdl.ReplyList = GetWorkExchangeReplyLst(dr["ReplyList"].ToString());
                    mdl.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : null;
                    mdl.ZxsId = dr["ZxsId"].ToString();
                }
            }

            return mdl;
        }

        /// <summary>
        /// 分页获取回复列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="CompanyId"></param>
        /// <param name="ExchangeId"></param>
        /// <returns></returns>
        public IList<WorkExchangeReply> GetList(int CompanyId, int ExchangeId, int pageSize, int pageIndex, ref int RecordCount)
        {
            IList<WorkExchangeReply> list = new List<WorkExchangeReply>();

            StringBuilder field = new StringBuilder();
            field.Append("ReplyId,ExchangeId,Description,OperatorId,ReplyTime ,IsAnonymous,");
            field.Append("(select ContactName from tbl_CompanyUser where Id=tbl_WorkExchangeReply.OperatorId) as OperatorName");

            string tableName = "tbl_WorkExchangeReply";
            string orderbyStr = " ReplyTime ASC";

            StringBuilder query = new StringBuilder();
            query.AppendFormat("ExchangeId={0} and IsDelete='0' ", ExchangeId);

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, field.ToString(), query.ToString(), orderbyStr, null))
            {
                while (dr.Read())
                {
                    WorkExchangeReply model = new WorkExchangeReply
                    {
                        ReplyId = dr.GetInt32(dr.GetOrdinal("ReplyId")),
                        ExchangeId = dr.GetInt32(dr.GetOrdinal("ExchangeId")),
                        Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : null,
                        OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId")),
                        OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null,
                        ReplyTime = dr.GetDateTime(dr.GetOrdinal("ReplyTime")),
                        IsAnonymous = dr.GetString(dr.GetOrdinal("IsAnonymous")) == "1"

                    };
                    list.Add(model);
                }
            }
            return list;


        }
        
        /*/// <summary>
        /// 分页获取交流专区列表
        /// </summary>
        /// <param name="pageSize">每页现实条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="CompanyId">公司编号 =0返回所有</param>
        /// <param name="OperatorId">操作人编号 =0返回所有</param>
        /// <returns>交流专区列表</returns>
        public IList<EyouSoft.Model.PersonalCenterStructure.WorkExchange> GetList(int pageSize, int pageIndex, ref int RecordCount, int CompanyId, int OperatorId)
        {
            IList<EyouSoft.Model.PersonalCenterStructure.WorkExchange> list = new List<EyouSoft.Model.PersonalCenterStructure.WorkExchange>();
            string tableName = "tbl_WorkExchange";
            string fields = "ExchangeId,Title,OperatorName,IsAnonymous,Clicks,Replys,CreateTime";
            string orderbyStr = " CreateTime DESC ";
            StringBuilder strWhere = new StringBuilder(" IsDelete='0' ");
            if (CompanyId > 0)
                strWhere.AppendFormat(" and CompanyId={0} ", CompanyId);
            //TODO:需根据OperatorId查询对应的权限集合
            if (OperatorId > 0)
                strWhere.AppendFormat("");
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, fields, strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PersonalCenterStructure.WorkExchange model = new EyouSoft.Model.PersonalCenterStructure.WorkExchange();
                    model.ExchangeId = dr.GetInt32(dr.GetOrdinal("ExchangeId"));
                    model.Title = dr[dr.GetOrdinal("Title")].ToString();
                    model.OperatorName = dr[dr.GetOrdinal("OperatorName")].ToString();
                    model.IsAnonymous = dr[dr.GetOrdinal("IsAnonymous")].ToString() == "1" ? true : false;
                    model.Clicks = dr.GetInt32(dr.GetOrdinal("Clicks"));
                    model.Replys = dr.GetInt32(dr.GetOrdinal("Replys"));
                    model.CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"));
                    list.Add(model);
                    model = null;
                }
            }
            return list;
        }*/


        /// <summary>
        /// 分页获取交流专区列表
        /// </summary>
        /// <param name="pageSize">每页现实条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="CompanyId">公司编号 =0返回所有</param>
        /// <param name="OperatorId">操作人编号 =0返回所有</param>
        /// <returns>交流专区列表</returns>
        public IList<EyouSoft.Model.PersonalCenterStructure.WorkExchange> GetList(
            int pageSize,
            int pageIndex,
            ref int RecordCount,
            int CompanyId,
            int OperatorId,
            WorkExchangeSearch search)
        {
            IList<EyouSoft.Model.PersonalCenterStructure.WorkExchange> list = new List<EyouSoft.Model.PersonalCenterStructure.WorkExchange>();
            string tableName = "tbl_WorkExchange";
            StringBuilder fileds = new StringBuilder();
            fileds.Append("ExchangeId,CompanyId,[Type],Title,Description,OperatorId");
            fileds.Append(",(select ContactName from tbl_CompanyUser where Id=tbl_WorkExchange.OperatorId) as OperatorName");
            fileds.Append(",CreateTime,IsAnonymous,Clicks,Replys,ZxsId ");

            string orderbyStr = " CreateTime DESC ";
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" CompanyId={0} and IsDelete='0' ", CompanyId);

            if (!string.IsNullOrEmpty(search.Title))
            {
                strWhere.AppendFormat(" and Title like '%{0}%' ", search.Title);
            }

            if (search.Type.HasValue)
            {
                strWhere.AppendFormat(" and Type={0} ", (int)search.Type.Value);
            }

            if (search.CBeginDate.HasValue)
            {
                strWhere.AppendFormat(" and datediff(day,CreateTime,'{0}')<=0", search.CBeginDate.Value);
            }
            if (search.CEndDate.HasValue)
            {
                strWhere.AppendFormat(" and datediff(day,CreateTime,'{0}')>=0", search.CEndDate.Value);
            }
            if (!string.IsNullOrEmpty(search.ZxsId))
            {
                strWhere.AppendFormat(" AND ZxsId='{0}' ", search.ZxsId);
            }



            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, fileds.ToString(), strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PersonalCenterStructure.WorkExchange model = new EyouSoft.Model.PersonalCenterStructure.WorkExchange();
                    model.ExchangeId = dr.GetInt32(dr.GetOrdinal("ExchangeId"));
                    model.Title = dr[dr.GetOrdinal("Title")].ToString();
                    model.Type = (EyouSoft.Model.EnumType.PersonalCenterStructure.ExchangeType)dr.GetByte(dr.GetOrdinal("Type"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr[dr.GetOrdinal("OperatorName")].ToString() : null;
                    model.IsAnonymous = dr[dr.GetOrdinal("IsAnonymous")].ToString() == "1" ? true : false;
                    model.Clicks = dr.GetInt32(dr.GetOrdinal("Clicks"));
                    model.Replys = dr.GetInt32(dr.GetOrdinal("Replys"));
                    model.CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"));
                    model.ZxsId = dr["ZxsId"].ToString();
                    list.Add(model);
                    model = null;
                }
            }
            return list;
        }

        /// <summary>
        /// 更新浏览次数
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool SetClicks(int Id)
        {
            var sql = new StringBuilder("UPDATE dbo.tbl_WorkExchange SET Clicks=Clicks+1 WHERE ExchangeId=@ExchangeId");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc, "ExchangeId", DbType.Int32, Id);
            return DbHelper.ExecuteSql(dc, this._db) > 0;
        }
        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="model">交流专区回复实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool AddReply(EyouSoft.Model.PersonalCenterStructure.WorkExchangeReply model)
        {
            var sql = new StringBuilder();

            sql.Append(" INSERT  INTO [dbo].[tbl_WorkExchangeReply]");
            sql.Append("         ( [ExchangeId] ,");
            sql.Append("           [Description] ,");
            sql.Append("           [OperatorId] ,");
            sql.Append("           [OperatorName] ,");
            sql.Append("           [ReplyTime] ,");
            sql.Append("           [IsAnonymous] ");
            sql.Append("         )");
            sql.Append(" VALUES  ( @ExchangeId ,");
            sql.Append("           @Description ,");
            sql.Append("           @OperatorId ,");
            sql.Append("           @OperatorName ,");
            sql.Append("           @ReplyTime ,");
            sql.Append("           @IsAnonymous ");
            sql.Append("         )");
            sql.Append(" UPDATE dbo.tbl_WorkExchange SET Replys=Replys+1 WHERE ExchangeId=@ExchangeId");

            var dc = this._db.GetSqlStringCommand(sql.ToString());

            this._db.AddInParameter(dc, "ExchangeId", DbType.Int32, model.ExchangeId);
            this._db.AddInParameter(dc, "Description", DbType.String, model.Description);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(dc, "OperatorName", DbType.String, model.OperatorName);
            this._db.AddInParameter(dc, "ReplyTime", DbType.DateTime, model.ReplyTime);
            this._db.AddInParameter(dc, "IsAnonymous", DbType.AnsiStringFixedLength, model.IsAnonymous ? "1" : "0");

            return DbHelper.ExecuteSqlTrans(dc, this._db) > 0;
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 创建接收对象XML
        /// </summary>
        /// <returns></returns>
        private string CreateAcceptXML(IList<EyouSoft.Model.PersonalCenterStructure.WorkExchangeAccept> list)
        {
            if (list == null || list.Count == 0)
                return string.Empty;
            StringBuilder strXML = new StringBuilder("<ROOT>");
            foreach (EyouSoft.Model.PersonalCenterStructure.WorkExchangeAccept model in list)
            {
                strXML.AppendFormat("<AcceptInfo AcceptType=\"{0}\" AcceptId=\"{1}\" />", (int)model.AcceptType, model.AcceptId);
            }
            strXML.Append("</ROOT>");
            return strXML.ToString();
        }
        /// <summary>
        /// 根据接收对象类型和编号获取接收名称
        /// </summary>
        /// <param name="AcceptId">接收对象编号</param>
        /// <param name="AcceptType">接收对象类型</param>
        /// <returns></returns>
        private string GetAcceptName(int AcceptId, EyouSoft.Model.EnumType.PersonalCenterStructure.AcceptType AcceptType)
        {
            string AcceptName = string.Empty;
            switch (AcceptType)
            {
                case EyouSoft.Model.EnumType.PersonalCenterStructure.AcceptType.指定部门:
                    EyouSoft.Model.CompanyStructure.Department departModel = new DAL.CompanyStructure.Department().GetModel(AcceptId);
                    if (departModel != null)
                        AcceptName = departModel.DepartName;
                    departModel = null;
                    break;
                case EyouSoft.Model.EnumType.PersonalCenterStructure.AcceptType.指定人:
                    var userModel = new DAL.CompanyStructure.CompanyUser().GetUserInfo(AcceptId);
                    if (userModel != null)
                        AcceptName = userModel.UserName;
                    userModel = null;
                    break;
            }
            return AcceptName;
        }

        /// <summary>
        /// xml to list
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private static IList<WorkExchangeAccept> GetWorkExchangeAcceptLst(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }
            var x = XElement.Parse(xml);
            var r = Utils.GetXElements(x, "row");
            return r.Select(i => new WorkExchangeAccept
            {
                ExchangeId = Utils.GetInt(Utils.GetXAttributeValue(i, "ExchangeId")),
                AcceptType = (AcceptType)Utils.GetInt(Utils.GetXAttributeValue(i, "AcceptType")),
                AcceptId = Utils.GetInt(Utils.GetXAttributeValue(i, "AcceptId")),
            }).ToList();
        }

        /// <summary>
        /// xml to list
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private static IList<WorkExchangeReply> GetWorkExchangeReplyLst(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }
            var x = XElement.Parse(xml);
            var r = Utils.GetXElements(x, "row");
            return r.Select(i => new WorkExchangeReply
            {
                ExchangeId = Utils.GetInt(Utils.GetXAttributeValue(i, "ExchangeId")),
                ReplyId = Utils.GetInt(Utils.GetXAttributeValue(i, "ReplyId")),
                Description = Utils.GetXAttributeValue(i, "Description"),
                OperatorId = Utils.GetInt(Utils.GetXAttributeValue(i, "OperatorId")),
                OperatorName = Utils.GetXAttributeValue(i, "OperatorName"),
                ReplyTime = Utils.GetDateTime(Utils.GetXAttributeValue(i, "ReplyTime")),
                IsAnonymous = Utils.GetXAttributeValue(i, "IsAnonymous") == "1",
                IsDelete = Utils.GetXAttributeValue(i, "IsDelete") == "1",
            }).ToList();
        }
        #endregion

    }
}
