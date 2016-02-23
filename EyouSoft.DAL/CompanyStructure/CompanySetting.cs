using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace EyouSoft.DAL.CompanyStructure
{
    using System;
    using System.Data;

    /// <summary>
    /// 公司系统配置DAL
    /// </summary>
    public class CompanySetting : Toolkit.DAL.DALBase, IDAL.CompanyStructure.ICompanySetting
    {
        #region static constants

        private const string SqlBcthSetSeting = "if not exists(select 1 from tbl_CompanySetting where id = {0} and fieldname = '{1}') begin 	insert into tbl_CompanySetting(id,fieldname,fieldvalue) values({0},'{1}','{2}') end else begin update tbl_CompanySetting set fieldvalue='{2}' where id = {0} and fieldname = '{1}' end ;";

        //private const string SqlGetValue = "select FieldValue from tbl_CompanySetting where Id = @Id and FieldName = @FieldName";
        //private const string SqlSetSetting = " delete tbl_CompanySetting where Id = @CompanyId and FieldName = @FieldName; insert into tbl_CompanySetting(id,FieldName,FieldValue) values(@CompanyId,@FieldName,@FieldValue);";

        private readonly Database _db;
        #endregion

        #region 构造函数

        public CompanySetting()
        {
            this._db = SystemStore;
        }

        #endregion

        #region ICompanySetting 成员

        /*/// <summary>
        /// 设置系统配置信息
        /// </summary>
        /// <param name="model">系统配置实体</param>
        /// <returns>true：成功 false:失败</returns>
        public bool SetCompanySetting(Model.CompanyStructure.CompanyFieldSetting model)
        {
            if (model == null) return false;

            var strSql = new StringBuilder();
            if (model.ReservationTime > 0)
                strSql.AppendFormat(SqlBcthSetSeting, model.CompanyId, "ReservationTime", model.ReservationTime);
            strSql.AppendFormat(SqlBcthSetSeting, model.CompanyId, "CompanyLogo", model.CompanyLogo);
            strSql.AppendFormat(SqlBcthSetSeting, model.CompanyId, "PrintHeader", model.PageHeadFile);
            strSql.AppendFormat(SqlBcthSetSeting, model.CompanyId, "PrintFooter", model.PageFootFile);
            strSql.AppendFormat(SqlBcthSetSeting, model.CompanyId, "PrintTemplate", model.TemplateFile);
            strSql.AppendFormat(SqlBcthSetSeting, model.CompanyId, "CompanyStamp", model.CompanyStamp);
            //strSql.AppendFormat(SqlBcthSetSeting, model.CompanyId, "UserLoginLimitType", (int)model.UserLoginLimitType);

            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            return Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }*/

        /*/// <summary>
        /// 获取指定公司的配置信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="fileKey"></param>
        /// <returns></returns>
        public string GetValue(int companyId, string fileKey)
        {
            if (companyId <= 0 || string.IsNullOrEmpty(fileKey)) return string.Empty;

            string fieldValue = string.Empty;
            DbCommand cmd = this._db.GetSqlStringCommand(SqlGetValue);
            this._db.AddInParameter(cmd, "Id", DbType.Int32, companyId);
            this._db.AddInParameter(cmd, "FieldName", DbType.String, fileKey);

            using (IDataReader rdr = Toolkit.DAL.DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    fieldValue = rdr.IsDBNull(rdr.GetOrdinal("FieldValue"))
                                     ? string.Empty
                                     : rdr.GetString(rdr.GetOrdinal("FieldValue"));
                }
            }

            return fieldValue;
        }

        /// <summary>
        /// 设置指定公司的配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="fieldKey">配置key</param>
        /// <param name="fieldValue">配置value</param>
        /// <returns></returns>
        public bool SetValue(int companyId, string fieldKey, string fieldValue)
        {
            if (companyId <= 0 || string.IsNullOrEmpty(fieldKey)) return false;

            DbCommand dc = this._db.GetSqlStringCommand(SqlSetSetting);
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            this._db.AddInParameter(dc, "FieldName", DbType.String, fieldKey);
            this._db.AddInParameter(dc, "FieldValue", DbType.String, fieldValue);
            return Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }*/

        /// <summary>
        /// 设置专线商配置信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int SheZhiZxsPeiZhi(EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo info)
        {
            var cmd = _db.GetSqlStringCommand("PRINT 1");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

            string sql1 = "IF NOT EXISTS(SELECT 1 FROM tbl_Pt_ZxsKV WHERE CompanyId = @CompanyId AND ZxsId=@ZxsId AND K = @K{0}) BEGIN INSERT INTO tbl_Pt_ZxsKV(CompanyId,ZxsId,K,V) VALUES(@CompanyId,@ZxsId,@K{0},@V{0}) END ELSE BEGIN UPDATE tbl_Pt_ZxsKV SET V=@V{0} WHERE CompanyID = @CompanyId AND ZxsId=@ZxsId AND K=@K{0} END;";
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat(sql1, "0");
            _db.AddInParameter(cmd, "K0", DbType.String, "DaYinMoBanFilepath");
            _db.AddInParameter(cmd, "V0", DbType.String, info.DaYinMoBanFilepath);

            sql.AppendFormat(sql1, "1");
            _db.AddInParameter(cmd, "K1", DbType.String, "DaYinYeJiaoFilepath");
            _db.AddInParameter(cmd, "V1", DbType.String, info.DaYinYeJiaoFilepath);

            sql.AppendFormat(sql1, "2");
            _db.AddInParameter(cmd, "K2", DbType.String, "DaYinYeMeiFilepath");
            _db.AddInParameter(cmd, "V2", DbType.String, info.DaYinYeMeiFilepath);

            sql.AppendFormat(sql1, "3");
            _db.AddInParameter(cmd, "K3", DbType.String, "LogoFilepath");
            _db.AddInParameter(cmd, "V3", DbType.String, info.LogoFilepath);

            sql.AppendFormat(sql1, "4");
            _db.AddInParameter(cmd, "K4", DbType.String, "TuZhangFilepath");
            _db.AddInParameter(cmd, "V4", DbType.String, info.TuZhangFilepath);

            cmd.CommandText = sql.ToString();

            Toolkit.DAL.DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }
        #endregion
    }
}
