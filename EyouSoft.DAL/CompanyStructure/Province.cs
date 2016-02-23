using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.CompanyStructure
{
    /// <summary>
    /// 省份管理DAL
    /// </summary>
    public class Province : DALBase, IDAL.CompanyStructure.IProvince
    {
        #region static constants
        private const string SqlSelectIsexists = " select count(*) from tbl_CompanyProvince where ProvinceName = @ProvinceName and CompanyId = @CompanyId and Id != @Id ";
        private const string SqlInsertProvince = " insert into tbl_CompanyProvince (ProvinceName,CompanyId,OperatorId) values(@ProvinceName,@CompanyId,@OperatorId); select @@identity; ";
        private const string SqlUpdateProvinc = " update tbl_CompanyProvince set ProvinceName = @ProvinceName where Id = @Id ";
        private const string SqlSelectProvinc = " select Id,ProvinceName,CompanyId,OperatorId,IssueTime from tbl_CompanyProvince where Id = @Id ";

        private readonly Database _db;
        #endregion

        #region 构造函数
        public Province()
        {
            this._db = this.SystemStore;
        }
        #endregion

        #region IProvince 成员

        /// <summary>
        /// 验证省份名是否已经存在
        /// </summary>
        /// <param name="provinceName">省份名称</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="provinceId">省份编号</param>
        /// <returns>true:已存在 false:不存在</returns>
        public bool IsExists(string provinceName, int companyId, int provinceId)
        {
            bool isExists = false;
            DbCommand cmd = this._db.GetSqlStringCommand(SqlSelectIsexists);

            this._db.AddInParameter(cmd, "ProvinceName", DbType.String, provinceName);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            this._db.AddInParameter(cmd, "Id", DbType.Int32, provinceId);

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
        /// 添加省份
        /// </summary>
        /// <param name="model">省份实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(Model.CompanyStructure.Province model)
        {
            DbCommand cmd = this._db.GetSqlStringCommand(SqlInsertProvince);

            this._db.AddInParameter(cmd, "ProvinceName", DbType.String, model.ProvinceName);
            this._db.AddInParameter(cmd, "CompanyId", DbType.String, model.CompanyId);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);

            object obj = DbHelper.GetSingle(cmd, this._db);
            if (obj == null)
            {
                model.Id = 0;
                return false;
            }

            model.Id = Toolkit.Utils.GetInt(obj.ToString());
            return true;
        }

        /// <summary>
        /// 修改省份
        /// </summary>
        /// <param name="model">省份实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Update(Model.CompanyStructure.Province model)
        {
            DbCommand cmd = this._db.GetSqlStringCommand(SqlUpdateProvinc);
            this._db.AddInParameter(cmd, "ProvinceName", DbType.String, model.ProvinceName);
            this._db.AddInParameter(cmd, "Id", DbType.Int32, model.Id);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 获取省份实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.Province GetModel(int id)
        {
            Model.CompanyStructure.Province provinceModel = null;
            DbCommand cmd = this._db.GetSqlStringCommand(SqlSelectProvinc);
            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    provinceModel = new Model.CompanyStructure.Province
                        {
                            Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                            ProvinceName = rdr.GetString(rdr.GetOrdinal("ProvinceName")),
                            CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId")),
                            OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId")),
                            IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"))
                        };
                }
            }

            return provinceModel;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">省份编号</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Delete(int id)
        {
            DbCommand cmd = _db.GetSqlStringCommand("DELETE FROM tbl_CompanyProvince WHERE Id=@ProvinceId AND NOT EXISTS(SELECT 1 FROM tbl_CompanyCity WHERE ProvinceId=@ProvinceId)");
            _db.AddInParameter(cmd, "ProvinceId", DbType.Int32, id);
            
            return DbHelper.ExecuteSql(cmd, _db) > 0 ? true : false;
        }

        /// <summary>
        /// 获取某个公司所有省份的信息包括城市
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.Province> GetProvinceInfo(int companyId)
        {
            IList<Model.CompanyStructure.Province> lsProvince = new List<Model.CompanyStructure.Province>();
            var strSql = new StringBuilder();
            strSql.Append(" select Id,ProvinceName,CompanyId,OperatorId,IssueTime ");
            strSql.Append(
                " ,(select Id as CityId,CityName as CityName,IsFav from tbl_CompanyCity as b where b.ProvinceId = tbl_CompanyProvince.Id and b.CompanyId = @CompanyId for xml raw,root('Root')) as CityInfo ");
            strSql.Append(" from tbl_CompanyProvince where CompanyId=@CompanyId ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (rdr.Read())
                {
                    var provinceModel = new Model.CompanyStructure.Province
                        {
                            Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                            ProvinceName = rdr.GetString(rdr.GetOrdinal("ProvinceName")),
                            CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId")),
                            OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId")),
                            IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"))
                        };

                    if (!rdr.IsDBNull(rdr.GetOrdinal("CityInfo")))
                        provinceModel.CityList = GetCityListByXMl(rdr.GetString(rdr.GetOrdinal("CityInfo")));
                    lsProvince.Add(provinceModel);
                }
            }

            return lsProvince;
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 根据城市XML生成城市信息集合
        /// </summary>
        /// <param name="xml">城市XML</param>
        /// <returns></returns>
        private IList<Model.CompanyStructure.City> GetCityListByXMl(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;

            var xRoot = XElement.Parse(xml);
            var xRows = Toolkit.Utils.GetXElements(xRoot, "row");
            if (xRows == null || !xRows.Any()) return null;

            IList<Model.CompanyStructure.City> list = new List<Model.CompanyStructure.City>();
            foreach (var t in xRows)
            {
                if (t == null) continue;

                list.Add(new Model.CompanyStructure.City
                    {
                        Id = Toolkit.Utils.GetInt(Toolkit.Utils.GetXAttributeValue(t, "CityId")),
                        CityName = Toolkit.Utils.GetXAttributeValue(t, "CityName"),
                        IsFav = this.GetBoolean(Toolkit.Utils.GetXAttributeValue(t, "IsFav"))
                    });
            }

            return list;
        }

        #endregion
    }
}
