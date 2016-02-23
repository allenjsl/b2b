using System.Collections.Generic;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Text;
using System;

namespace EyouSoft.DAL.CompanyStructure
{
    /// <summary>
    /// 城市管理DAL
    /// </summary>
    public class City : DALBase, IDAL.CompanyStructure.ICity
    {
        #region static constants

        private const string SqlSelectIsexists = " select count(*) from tbl_CompanyCity where CityName = @cityName and CompanyId = @companyId and Id != @Id ";
        private const string SqlInsertCity = " insert into tbl_CompanyCity (ProvinceId,CityName,CompanyId,IsFav,OperatorId,DiQu) values(@ProvinceId,@CityName,@CompanyId,@IsFav,@OperatorId,@DiQu);select @@identity; ";
        private const string SqlUpdateCity = " update tbl_CompanyCity set ProvinceId = @ProvinceId,CityName = @CityName,DiQu=@DiQu where Id = @Id";
        private const string SqlSelectCity = " select Id,ProvinceId,CityName,CompanyId,IsFav,OperatorId,IssueTime,DiQu from tbl_CompanyCity where Id = @Id ";
        private const string SqlDeleteCity = " delete from tbl_CompanyCity WHERE Id=@CityId AND NOT EXISTS(SELECT 1 FROM tbl_Customer WHERE CityId=@CityId) AND NOT EXISTS(SELECT 1 FROM tbl_KongWei WHERE (QuDepCityId=@CityId OR QuArrCityId=@CityId OR HuiDepCityId=@CityId OR HuiArrCityId=@CityId)) AND NOT EXISTS(SELECT 1 FROM tbl_CompanySupplier WHERE CityId=@CityId) ";
        //private const string SqlGetList = " select Id,ProvinceId,CityName,CompanyId,IsFav,OperatorId,IssueTime from tbl_CompanyCity where CompanyId = @CompanyId and ProvinceId = @ProvinceId ";

        private readonly Database _db;

        #endregion

        #region 构造函数
        public City()
        {
            this._db = SystemStore;
        }
        #endregion

        #region ICity 成员

        /// <summary>
        /// 验证城市名是否已经存在
        /// </summary>
        /// <param name="cityName">城市名称</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="cityId">城市编号</param>
        /// <returns>true:已存在 false:不存在</returns>
        public bool IsExists(string cityName, int companyId, int cityId)
        {
            if (string.IsNullOrEmpty(cityName) || companyId <= 0) return true;

            bool isExists = false;
            DbCommand cmd = this._db.GetSqlStringCommand(SqlSelectIsexists);

            this._db.AddInParameter(cmd, "cityName", DbType.String, cityName);
            this._db.AddInParameter(cmd, "companyId", DbType.Int32, companyId);
            this._db.AddInParameter(cmd, "Id", DbType.Int32, cityId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    isExists = rdr.GetInt32(0) > 0 ? true : false;
                }
            }

            return isExists;
        }

        /// <summary>
        /// 添加城市
        /// </summary>
        /// <param name="model">城市实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(Model.CompanyStructure.City model)
        {
            if (model == null || string.IsNullOrEmpty(model.CityName)) return false;

            DbCommand cmd = this._db.GetSqlStringCommand(SqlInsertCity);

            this._db.AddInParameter(cmd, "ProvinceId", DbType.String, model.ProvinceId);
            this._db.AddInParameter(cmd, "CityName", DbType.String, model.CityName);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "IsFav", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsFav));
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(cmd, "DiQu", DbType.Byte, model.DiQu);

            object obj = DbHelper.GetSingle(cmd, this._db);
            if (obj == null) return false;

            model.Id = Toolkit.Utils.GetInt(obj.ToString());
            return true;
        }

        /// <summary>
        /// 修改城市
        /// </summary>
        /// <param name="model">城市实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Update(Model.CompanyStructure.City model)
        {
            if (model == null || model.Id <= 0) return false;

            DbCommand cmd = this._db.GetSqlStringCommand(SqlUpdateCity);
            this._db.AddInParameter(cmd, "ProvinceId", DbType.Int32, model.ProvinceId);
            this._db.AddInParameter(cmd, "CityName", DbType.String, model.CityName);
            this._db.AddInParameter(cmd, "Id", DbType.Int32, model.Id);
            _db.AddInParameter(cmd, "DiQu", DbType.Byte, model.DiQu);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 获取城市实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.City GetModel(int id)
        {
            if (id <= 0) return null;

            Model.CompanyStructure.City cityModel = null;
            DbCommand cmd = this._db.GetSqlStringCommand(SqlSelectCity);
            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    cityModel = new Model.CompanyStructure.City
                        {
                            Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                            ProvinceId = rdr.GetInt32(rdr.GetOrdinal("ProvinceId")),
                            CityName = rdr.GetString(rdr.GetOrdinal("CityName")),
                            CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId")),
                            IsFav = this.GetBoolean(rdr.GetString(rdr.GetOrdinal("IsFav"))),
                            OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId")),
                            IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime")),
                            DiQu = (EyouSoft.Model.EnumType.CompanyStructure.ChengShiDiQu)rdr.GetByte(rdr.GetOrdinal("DiQu"))
                        };
                }
            }

            return cityModel;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">城市编号</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Delete(int id)
        {
            DbCommand dc = _db.GetSqlStringCommand(SqlDeleteCity);
            _db.AddInParameter(dc, "CityId", DbType.Int32, id);

            return DbHelper.ExecuteSql(dc, _db) > 0 ? true : false;
        }

        /// <summary>
        /// 设置常用城市，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chengShiId">城市编号</param>
        /// <returns></returns>
        public int SheZhiChangYongChengShi(int companyId, string zxsId, int chengShiId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ChengShi_SheZhiChangYong");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "ZxsId", DbType.String, zxsId);
            _db.AddInParameter(cmd, "ChengShiid", DbType.Int32, chengShiId);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取省份信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MShengFenInfo> GetShengFens(int companyId, EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.CompanyStructure.MShengFenInfo> items = new List<EyouSoft.Model.CompanyStructure.MShengFenInfo>();

            #region sql
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat(" SELECT A.Id,A.ProvinceName FROM tbl_CompanyProvince AS A WHERE A.CompanyId=@CompanyId ");

            if (chaXun != null)
            {
                if (chaXun.ChengShiId.HasValue)
                {
                    sql.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_CompanyCity AS A1 WHERE A1.ProvinceId=A.Id AND A1.Id={0}) ", chaXun.ChengShiId.Value);
                }
                if (chaXun.ShengFenId.HasValue)
                {
                    sql.AppendFormat(" AND A.Id={0} ", chaXun.ShengFenId.Value);
                }

                if (chaXun.LeiXing == 1)
                {
                    if (!string.IsNullOrEmpty(chaXun.ZxsId))
                    {
                        sql.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_CompanyCity AS A1 WHERE A1.ProvinceId=A.Id AND (EXISTS(SELECT 1 FROM tbl_ZxsChangYongChengShi AS A2 WHERE A2.ChengShiId=A1.Id AND A2.ZxsId='{0}')) ) ", chaXun.ZxsId);
                    }
                    else
                    {
                        sql.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_CompanyCity AS A1 WHERE A1.ProvinceId=A.Id AND (EXISTS(SELECT 1 FROM tbl_ZxsChangYongChengShi AS A2 WHERE A2.ChengShiId=A1.Id)) ) ");
                    }
                }
            }

            sql.AppendFormat(" ORDER BY A.Id ASC ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.MShengFenInfo();

                    item.ShengFenId = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    item.ShengFenName = rdr["ProvinceName"].ToString();

                    items.Add(item);
                }
            }

            if (items != null && items.Count > 0 && chaXun.LeiXing1 == 1)
            {
                foreach (var item in items)
                {
                    chaXun.ShengFenId = item.ShengFenId;

                    item.ChengShis = GetChengShis(companyId, chaXun);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取城市信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MChengShiInfo> GetChengShis(int companyId, EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.CompanyStructure.MChengShiInfo> items = new List<EyouSoft.Model.CompanyStructure.MChengShiInfo>();

            #region sql
            int topExpression = 0;
            if (chaXun != null && chaXun.TopExpression > 0) topExpression = chaXun.TopExpression;
            StringBuilder sql = new StringBuilder();
            if (topExpression < 1)
            {
                sql.AppendFormat(" SELECT A.Id,A.CityName,A.LeiXing FROM tbl_CompanyCity AS A INNER JOIN tbl_CompanyProvince AS B ");
            }
            else
            {
                sql.AppendFormat(" SELECT TOP({0}) A.Id,A.CityName FROM tbl_CompanyCity AS A INNER JOIN tbl_CompanyProvince AS B ", topExpression);
            }
            sql.AppendFormat(" ON A.ProvinceId=B.Id AND B.CompanyId=@CompanyId ");

            if (chaXun != null)
            {
                if (chaXun.ChengShiId.HasValue)
                {
                    sql.AppendFormat(" AND A.Id={0} ", chaXun.ChengShiId);
                }
                if (chaXun.ShengFenId.HasValue)
                {
                    sql.AppendFormat(" AND A.ProvinceId={0} ", chaXun.ShengFenId.Value);
                }
                if (chaXun.LeiXing == 1)
                {
                    if (!string.IsNullOrEmpty(chaXun.ZxsId))
                    {
                        sql.AppendFormat(" AND (EXISTS(SELECT 1 FROM tbl_ZxsChangYongChengShi AS A1 WHERE A1.ChengShiId=A.Id AND A1.ZxsId='{0}') ) ", chaXun.ZxsId);
                    }
                    else
                    {
                        sql.AppendFormat(" AND (EXISTS(SELECT 1 FROM tbl_ZxsChangYongChengShi AS A1 WHERE A1.ChengShiId=A.Id) ) ");
                    }
                }
                if (!string.IsNullOrEmpty(chaXun.ChengShiName))
                {
                    sql.AppendFormat(" AND A.CityName LIKE '%{0}%' ", chaXun.ChengShiName);
                }
                if (chaXun.LeiXing2.HasValue)
                {
                    sql.AppendFormat(" AND A.LeiXing={0} ", (int)chaXun.LeiXing2.Value);
                }
            }

            sql.AppendFormat(" ORDER BY A.Id ASC ");

            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.MChengShiInfo();

                    item.ChengShiId = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    item.ChengShiName = rdr["CityName"].ToString();
                    item.LeiXing = (EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置城市类型，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chengShiId">城市编号</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        public int SheZhiLeiXing(int companyId, int chengShiId, EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing leiXing)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE tbl_CompanyCity SET LeiXing=@LeiXing WHERE Id=@ChengShiId AND CompanyId=@CompanyId");
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, leiXing);
            _db.AddInParameter(cmd, "ChengShiId", DbType.Int32, chengShiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }
        #endregion
    }
}
