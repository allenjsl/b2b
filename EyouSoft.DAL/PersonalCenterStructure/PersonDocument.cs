using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using System.Xml.Linq;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.PersonalCenterStructure
{
    /// <summary>
    /// 个人中心-文档管理数据层
    /// </summary>
    /// 鲁功源  2011-01-17
    public class PersonDocument : EyouSoft.Toolkit.DAL.DALBase,EyouSoft.IDAL.PersonalCenterStructure.IPersonDocument
    {
        #region 变量
        private const string Sql_PersonDocument_Delete = "update tbl_Document set IsDelete='1' where DocumentId in({0})";
        //private EyouSoft.Data.EyouSoftTBL dcDal = null;
        private Database _db = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public PersonDocument() {
            _db = this.SystemStore;
            //dcDal = new EyouSoft.Data.EyouSoftTBL(this.SystemStore.ConnectionString);
        }
        #endregion

        #region PersonDocument 成员
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">文档管理实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(EyouSoft.Model.PersonalCenterStructure.PersonDocument model)
        {
            var sql = new StringBuilder();

            sql.Append("DECLARE @IdentityId INT;");
            sql.Append(" INSERT  INTO [tbl_Document]");
            sql.Append("         ( [CompanyId] ,");
            sql.Append("           [DocumentName] ,");
            sql.Append("           [FilePath] ,");
            sql.Append("           [OperatorId],[ZxsId] ");
            sql.Append("         )");
            sql.Append(" VALUES  ( @CompanyId ,");
            sql.Append("           @DocumentName ,");
            sql.Append("           @FilePath ,");
            sql.Append("           @OperatorId,@ZxsId ");
            sql.Append("         );");

            #region 附件信息
            sql.Append(" SELECT @IdentityId=@@IDENTITY; ");

            if (model.Annexs != null && model.Annexs.Count > 0)
            {
                foreach (var item in model.Annexs)
                {
                    if (item == null) continue;
                    if (string.IsNullOrEmpty(item.FileId)) item.FileId = Guid.NewGuid().ToString();
                    sql.AppendFormat("INSERT INTO [tbl_ComapnyFile]([FileId],[CompanyId],[FilePath],[IssueTime],[ItemType],[ItemId]) VALUES('{0}',@CompanyId,'{1}','{2}',@AnnexType,@IdentityId);", item.FileId
                        , item.FilePath
                        , DateTime.Now);
                }
            }
            #endregion

            var dc = this._db.GetSqlStringCommand(sql.ToString());

            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(dc, "DocumentName", DbType.String, model.DocumentName);
            this._db.AddInParameter(dc, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "AnnexType", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.AnnexType.个人中心文档);
            _db.AddInParameter(dc, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);

            return DbHelper.ExecuteSql(dc, this._db) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">文档管理实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Update(EyouSoft.Model.PersonalCenterStructure.PersonDocument model)
        {
            var sql = new StringBuilder();

            sql.Append(" UPDATE  [tbl_Document]");
            sql.Append(" SET     [DocumentName] = @DocumentName ,");
            sql.Append("         [FilePath] = @FilePath ,");
            sql.Append("         [OperatorId] = @OperatorId ");
            sql.Append(" WHERE   DocumentId = @DocumentId;");

            sql.AppendFormat("DELETE FROM [tbl_ComapnyFile] WHERE CompanyId=@CompanyId AND [ItemId]=@DocumentId AND [ItemType]=@AnnexType;");
            if (model.Annexs != null && model.Annexs.Count > 0)
            {
                foreach (var item in model.Annexs)
                {
                    if (item == null) continue;
                    if (string.IsNullOrEmpty(item.FileId)) item.FileId = Guid.NewGuid().ToString();
                    sql.AppendFormat("INSERT INTO [tbl_ComapnyFile]([FileId],[CompanyId],[FilePath],[IssueTime],[ItemType],[ItemId]) VALUES('{0}',@CompanyId,'{1}','{2}',@AnnexType,@DocumentId);", item.FileId
                        , item.FilePath
                        , DateTime.Now);
                }
            }


            var dc = this._db.GetSqlStringCommand(sql.ToString());

            this._db.AddInParameter(dc, "DocumentId", DbType.Int32, model.DocumentId);
            this._db.AddInParameter(dc, "DocumentName", DbType.String, model.DocumentName);
            this._db.AddInParameter(dc, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "AnnexType", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.AnnexType.个人中心文档);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);

            return DbHelper.ExecuteSql(dc, this._db) > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">主键编号集合</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Delete(params string[] Ids)
        {
            string strIds = string.Empty;
            foreach (string str in Ids)
            {
                strIds += str + ",";
            }
            DbCommand dc=this._db.GetSqlStringCommand(string.Format(Sql_PersonDocument_Delete,strIds.TrimEnd(',')));
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Id">主键编号</param>
        /// <returns>文档管理实体</returns>
        public EyouSoft.Model.PersonalCenterStructure.PersonDocument GetModel(int Id)
        {
            var sql =new StringBuilder();
            var mdl = new EyouSoft.Model.PersonalCenterStructure.PersonDocument();

            sql.Append(" SELECT  [DocumentName] ,");
            sql.Append("         [FilePath] ,");
            sql.Append("         [OperatorId] ,");
            sql.Append("         [CreateTime],");
            sql.Append("(select ContactName from tbl_CompanyUser where Id=tbl_Document.OperatorId) as OperatorName ");
            sql.Append(" FROM    [dbo].[tbl_Document]");
            sql.Append(" WHERE   DocumentId = @DocumentId;");

            sql.Append("SELECT [FilePath] FROM [tbl_ComapnyFile] WHERE ItemId=@DocumentId AND [ItemType]=@AnnexType ORDER BY [IdentityId] ASC;");

            var dc = this._db.GetSqlStringCommand(sql.ToString());

            this._db.AddInParameter(dc, "DocumentId", DbType.Int32, Id);
            _db.AddInParameter(dc, "AnnexType", DbType.Byte, (int)EyouSoft.Model.EnumType.CompanyStructure.AnnexType.个人中心文档);

            using (var  dr=DbHelper.ExecuteReader(dc,this._db))
            {
                if (dr.Read())
                {
                    mdl.DocumentName = dr["DocumentName"].ToString();
                    mdl.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    mdl.OperatorName = dr["OperatorName"].ToString();
                    mdl.CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"));
                    mdl.ZxsId = dr["ZxsId"].ToString();
                }

                dr.NextResult();
                mdl.Annexs = new List<EyouSoft.Model.CompanyStructure.CompanyFile>();
                while (dr.Read())
                {
                    mdl.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = dr["FilePath"].ToString() });
                }
            }

            return mdl;
        }
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pageSize">每页现实条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="CompanyId">公司编号 =0返回所有</param>
        /// <param name="OperatorId">上传人编号 =0返回所有</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns>文档管理列表</returns>
        public IList<EyouSoft.Model.PersonalCenterStructure.PersonDocument> GetList(int pageSize, int pageIndex, ref int RecordCount, int CompanyId, int OperatorId,string zxsId)
        {
            IList<EyouSoft.Model.PersonalCenterStructure.PersonDocument> list = new List<EyouSoft.Model.PersonalCenterStructure.PersonDocument>();
            string tableName = "tbl_Document";
            string fields = string.Format("DocumentId,DocumentName,FilePath,OperatorId,(select ContactName from tbl_CompanyUser where Id=tbl_Document.OperatorId) as OperatorName,CreateTime,(SELECT [FilePath] FROM [tbl_ComapnyFile] WHERE ItemId=tbl_Document.DocumentId AND [ItemType]={0} ORDER BY [IdentityId] ASC FOR XML RAW,ROOT('root')) AS AnnexsXML,ZxsId ", (int)EyouSoft.Model.EnumType.CompanyStructure.AnnexType.个人中心文档);
            string orderbyStr = " CreateTime Desc ";
            StringBuilder strWhere = new StringBuilder(" IsDelete='0' ");
            if (CompanyId > 0)
                strWhere.AppendFormat(" and CompanyId={0} ",CompanyId);
            //TODO:根据OperatorId获取相关权限
            if (OperatorId > 0)
                strWhere.AppendFormat("");
            if (!string.IsNullOrEmpty(zxsId))
                strWhere.AppendFormat(" AND ZxsId='{0}' ", zxsId);
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, fields, strWhere.ToString(), orderbyStr,""))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PersonalCenterStructure.PersonDocument model = new EyouSoft.Model.PersonalCenterStructure.PersonDocument();
                    if (!dr.IsDBNull(dr.GetOrdinal("DocumentId")))
                        model.DocumentId = dr.GetInt32(dr.GetOrdinal("DocumentId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DocumentName")))
                        model.DocumentName = dr[dr.GetOrdinal("DocumentName")].ToString();                    
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                        model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorName")))
                        model.OperatorName = dr[dr.GetOrdinal("OperatorName")].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("CreateTime")))
                        model.CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"));
                    model.ZxsId = dr["ZxsId"].ToString();

                    string xml = dr["AnnexsXML"].ToString();
                    model.Annexs = new List<EyouSoft.Model.CompanyStructure.CompanyFile>();
                    if (!string.IsNullOrEmpty(xml))
                    {
                        XElement xroot = XElement.Parse(xml);
                        var xraws = Utils.GetXElements(xroot, "row");

                        foreach (var xraw in xraws)
                        {
                            model.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = Utils.GetXAttributeValue(xraw, "FilePath") });
                        }
                    }

                    list.Add(model);
                    model = null;
                }
            }
            return list;
        }

        #endregion
    }
}
