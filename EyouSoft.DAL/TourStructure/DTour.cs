using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.TourStructure
{
    public class DTour : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.TourStructure.ITour
    {
        #region static constants
        //static constants
        //const string SQL_UPDATE_SetKongWeiZhuangTai = "UPDATE [tbl_KongWei] SET [KongWeiZhuangTai]=@KongWeiZhuangTai WHERE [KongWeiId]=@KongWeiId";
        const string SQL_SELECT_GetKongWeiZhuangTai = "SELECT [KongWeiZhuangTai] FROM [tbl_KongWei] WHERE [KongWeiId]=@KongWeiId";
        #endregion

        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DTour()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 计划控位代理商信息Xml
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        string CreateKongWeiDaiLisXml(IList<EyouSoft.Model.TourStructure.MBaseKongWeiDaiLi> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append("<info ");
                s.AppendFormat("DaiLiId=\"{0}\" ", item.DaiLiId);
                s.AppendFormat("GysId=\"{0}\" ", item.GysId);
                s.AppendFormat("GysOrderCode=\"{0}\" ", item.GysOrderCode);
                s.AppendFormat("LxrName=\"{0}\" ", Utils.ReplaceXmlSpecialCharacter(item.LxrName));
                s.AppendFormat("LxrTelephone=\"{0}\" ", item.LxrTelephone);
                s.AppendFormat("Price=\"{0}\" ", item.Price);
                s.AppendFormat("ShuLiang=\"{0}\" ", item.ShuLiang);
                s.AppendFormat("ShiXian=\"{0}\" ", item.ShiXian);
                s.AppendFormat("Remark=\"{0}\" ", Utils.ReplaceXmlSpecialCharacter(item.Remark));
                s.AppendFormat(" MoBanId=\"{0}\" ", item.MoBanId);
                s.Append(" />");
            }
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// get kongweidailis
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MBaseKongWeiDaiLi> GetKongWeiDaiLis(string kongWeiId)
        {
            IList<EyouSoft.Model.TourStructure.MBaseKongWeiDaiLi> items = new List<EyouSoft.Model.TourStructure.MBaseKongWeiDaiLi>();
            string sql = "SELECT A.*,(SELECT UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName FROM tbl_KongweiDaiLi AS A WHERE A.KongWeiId=@KongWeiId AND A.IsDelete='0' ORDER BY A.IdentityId ASC ";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MBaseKongWeiDaiLi();
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.DaiLiId = rdr["DaiLiId"].ToString();
                    item.GysId = rdr["GysId"].ToString();
                    item.GysName = rdr["GysName"].ToString();
                    item.GysOrderCode = rdr["GysOrderCode"].ToString();
                    item.KongWeiId = kongWeiId;
                    item.LxrName = rdr["LxrName"].ToString();
                    item.LxrTelephone = rdr["LxrTelephone"].ToString();
                    item.MoBanId = rdr["MoBanId"].ToString();
                    item.Price = rdr.GetDecimal(rdr.GetOrdinal("Price"));
                    item.Remark = rdr["Remark"].ToString();
                    item.ShiXian = rdr["ShiXian"].ToString();
                    item.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));

                    items.Add(item);
                }
            }


            return items;
        }

        /// <summary>
        /// create kongweixianlus xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateKongWeiXianLusXml(IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> items)
        {
            StringBuilder s = new StringBuilder();
            if (items != null && items.Count > 0)
            {
                s.Append("<root>");
                foreach (var item in items)
                {
                    s.Append("<info ");
                    s.AppendFormat(" BuFangChaJiaGe=\"{0}\" ", item.BuFangChaJiaGe);
                    s.AppendFormat(" JieSuanJiaGe1=\"{0}\" ", item.JieSuanJiaGe1);
                    s.AppendFormat(" JieSuanJiaGe2=\"{0}\" ", item.JieSuanJiaGe2);
                    s.AppendFormat(" JieSuanJiaGe3=\"{0}\" ", item.JieSuanJiaGe3);
                    s.AppendFormat(" JiFen=\"{0}\" ", item.JiFen);
                    s.AppendFormat(" LeiXing=\"{0}\" ", (int)item.LeiXing);
                    s.AppendFormat(" MenShiJiaGe1=\"{0}\" ", item.MenShiJiaGe1);
                    s.AppendFormat(" MenShiJiaGe2=\"{0}\" ", item.MenShiJiaGe2);
                    s.AppendFormat(" MenShiJiaGe3=\"{0}\" ", item.MenShiJiaGe3);
                    s.AppendFormat(" PaiXuId=\"{0}\" ", item.PaiXuId);
                    s.AppendFormat(" QuanPeiJiaGe=\"{0}\" ", item.QuanPeiJiaGe);
                    s.AppendFormat(" RouteId=\"{0}\" ", item.RouteId);
                    s.AppendFormat(" Status=\"{0}\" ", (int)item.Status);
                    s.AppendFormat(" TuiFangChaJiaGe=\"{0}\" ", item.TuiFangChaJiaGe);
                    s.AppendFormat(" XianLuId=\"{0}\" ", item.XianLuId);
                    s.AppendFormat(" XianDingRenShu=\"{0}\" ", item.XianDingRenShu);
                    s.AppendFormat(" ZuiXiaoRenShu=\"{0}\" ", item.ZuiXiaoRenShu);

                    s.Append(" /> ");
                }
                s.Append("</root>");
            }
            return s.ToString();
        }

        /// <summary>
        /// 创建航段信息xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateHangDuanXml(IList<EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo> items)
        {
            StringBuilder s = new StringBuilder();

            if (items == null || items.Count == 0) return string.Empty;

            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append("<info ");
                s.AppendFormat(" RiQi=\"{0}\" ", item.RiQi);
                s.AppendFormat(" JiaoTongId=\"{0}\" ", item.JiaoTongId);
                s.AppendFormat(" ChuFaShengFenId=\"{0}\" ", item.ChuFaShengFenId);
                s.AppendFormat(" ChuFaChengShiId=\"{0}\" ", item.ChuFaChengShiId);
                s.AppendFormat(" MuDiDiShengFenId=\"{0}\" ", item.MuDiDiShengFenId);
                s.AppendFormat(" MuDiDiChengShiId=\"{0}\" ", item.MuDiDiChengShiId);
                s.Append(">");
                s.AppendFormat("<BanCi><![CDATA[{0}]]></BanCi>", item.BanCi);
                s.AppendFormat("<BeiZhu><![CDATA[{0}]]></BeiZhu>", item.BeiZhu);
                s.Append("</info>");
            }
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// 获取控位航段信息集合
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo> GetKongWeiHangDuans(string kongWeiId)
        {
            var cmd = _db.GetSqlStringCommand("SELECT * FROM view_KongWei_HangDuan WHERE KongWeiId=@KongWeiId ORDER BY IdentityId ASC");
            IList<EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo> items = new List<EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo>();
            _db.AddInParameter(cmd,"KongWeiId",DbType.AnsiStringFixedLength,kongWeiId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo();
                    item.BanCi = rdr["BanCi"].ToString();
                    item.BeiZhu = rdr["BeiZhu"].ToString();
                    item.ChuFaChengShiId = rdr.GetInt32(rdr.GetOrdinal("ChuFaChengShiId"));
                    item.ChuFaChengShiName = rdr["ChuFaChengShiName"].ToString();
                    item.ChuFaShengFenId = rdr.GetInt32(rdr.GetOrdinal("ChuFaShengFenId"));
                    item.ChuFaShengFenName = rdr["ChuFaShengFenName"].ToString();
                    item.JiaoTongId = rdr.GetInt32(rdr.GetOrdinal("JiaoTongId"));
                    item.JiaoTongName = rdr["JiaoTongName"].ToString();
                    item.MuDiDiChengShiId = rdr.GetInt32(rdr.GetOrdinal("MuDiDiChengShiId"));
                    item.MuDiDiChengShiName = rdr["MuDiDiChengShiName"].ToString();
                    item.MuDiDiShengFenId = rdr.GetInt32(rdr.GetOrdinal("MuDiDiShengFenId"));
                    item.MuDiDiShengFenName = rdr["MuDiDiShengFenName"].ToString();
                    item.RiQi = rdr.GetDateTime(rdr.GetOrdinal("RiQi"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region ITour 成员
        /// <summary>
        /// 添加控位，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddKongWei(EyouSoft.Model.TourStructure.MKongWei model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_KongWei_Add");
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "KongWeiType", DbType.Byte, (int)model.KongWeiType);
            this._db.AddInParameter(cmd, "ShuLiang", DbType.Int32, model.ShuLiang);
            this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)model.KongWeiStatus);
            this._db.AddInParameter(cmd, "AreaId", DbType.Int32, model.AreaId);
            this._db.AddInParameter(cmd, "QuDate", DbType.DateTime, model.QuDate.HasValue ? (DateTime?)model.QuDate.Value : null);
            this._db.AddInParameter(cmd, "QuJiaoTongId", DbType.Int32, model.QuJiaoTongId);
            this._db.AddInParameter(cmd, "QuDepProvinceId", DbType.Int32, model.QuDepProvinceId);
            this._db.AddInParameter(cmd, "QuDepCityId", DbType.Int32, model.QuDepCityId);
            this._db.AddInParameter(cmd, "QuArrProvinceId", DbType.Int32, model.QuArrProvinceId);
            this._db.AddInParameter(cmd, "QuArrCityId", DbType.Int32, model.QuArrCityId);
            this._db.AddInParameter(cmd, "QuBanCi", DbType.String, model.QuBanCi);
            this._db.AddInParameter(cmd, "QuTime", DbType.String, model.QuTime);
            this._db.AddInParameter(cmd, "HuiDate", DbType.DateTime, model.HuiDate.HasValue ? (DateTime?)model.HuiDate : null);
            this._db.AddInParameter(cmd, "HuiJiaoTongId", DbType.Int32, model.HuiJiaoTongId);
            this._db.AddInParameter(cmd, "HuiDepProvinceId", DbType.Int32, model.HuiDepProvinceId);
            this._db.AddInParameter(cmd, "HuiDepCityId", DbType.Int32, model.HuiDepCityId);
            this._db.AddInParameter(cmd, "HuiArrProvinceId", DbType.Int32, model.HuiArrProvinceId);
            this._db.AddInParameter(cmd, "HuiArrCityId", DbType.Int32, model.HuiArrCityId);
            this._db.AddInParameter(cmd, "HuiBanCi", DbType.String, model.HuiBanCi);
            this._db.AddInParameter(cmd, "HuiTime", DbType.String, model.HuiTime);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "DaiLiXml", DbType.String, CreateKongWeiDaiLisXml(model.KongWeiDaiLiList));

            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "TianShu", DbType.Int32, model.TianShu);
            _db.AddInParameter(cmd, "MoBanId", DbType.AnsiStringFixedLength, model.MoBanId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, model.ZhanDianId);
            _db.AddInParameter(cmd, "ZxlbId", DbType.Int32, model.ZxlbId);
            _db.AddInParameter(cmd, "@XianLuXml", DbType.String, CreateKongWeiXianLusXml(model.XianLus));
            _db.AddInParameter(cmd, "PingTaiShuLiang", DbType.Int32, model.PingTaiShuLiang);
            _db.AddInParameter(cmd, "HangDuanXml", DbType.String, CreateHangDuanXml(model.HangDuans));

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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 删除控位，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public int DeleteKongWei(string kongWeiId)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_KongWei_Delete");
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 修改控位，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateKongWeid(EyouSoft.Model.TourStructure.MKongWei model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_KongWei_Update");
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "ShuLiang", DbType.Int32, model.ShuLiang);
            this._db.AddInParameter(cmd, "AreaId", DbType.Int32, model.AreaId);
            this._db.AddInParameter(cmd, "QuDate", DbType.DateTime, model.QuDate.HasValue ? (DateTime?)model.QuDate.Value : null);
            this._db.AddInParameter(cmd, "QuJiaoTongId", DbType.Int32, model.QuJiaoTongId);
            this._db.AddInParameter(cmd, "QuDepProvinceId", DbType.Int32, model.QuDepProvinceId);
            this._db.AddInParameter(cmd, "QuDepCityId", DbType.Int32, model.QuDepCityId);
            this._db.AddInParameter(cmd, "QuArrProvinceId", DbType.Int32, model.QuArrProvinceId);
            this._db.AddInParameter(cmd, "QuArrCityId", DbType.Int32, model.QuArrCityId);
            this._db.AddInParameter(cmd, "QuBanCi", DbType.String, model.QuBanCi);
            this._db.AddInParameter(cmd, "QuTime", DbType.String, model.QuTime);
            this._db.AddInParameter(cmd, "HuiDate", DbType.DateTime, model.HuiDate.HasValue ? (DateTime?)model.HuiDate : null);
            this._db.AddInParameter(cmd, "HuiJiaoTongId", DbType.Int32, model.HuiJiaoTongId);
            this._db.AddInParameter(cmd, "HuiDepProvinceId", DbType.Int32, model.HuiDepProvinceId);
            this._db.AddInParameter(cmd, "HuiDepCityId", DbType.Int32, model.HuiDepCityId);
            this._db.AddInParameter(cmd, "HuiArrProvinceId", DbType.Int32, model.HuiArrProvinceId);
            this._db.AddInParameter(cmd, "HuiArrCityId", DbType.Int32, model.HuiArrCityId);
            this._db.AddInParameter(cmd, "HuiBanCi", DbType.String, model.HuiBanCi);
            this._db.AddInParameter(cmd, "HuiTime", DbType.String, model.HuiTime);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "DaiLiXml", DbType.String, CreateKongWeiDaiLisXml(model.KongWeiDaiLiList));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "TianShu", DbType.Int32, model.TianShu);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            _db.AddInParameter(cmd, "ZhanDianId", DbType.Int32, model.ZhanDianId);
            _db.AddInParameter(cmd, "ZxlbId", DbType.Int32, model.ZxlbId);
            _db.AddInParameter(cmd, "@XianLuXml", DbType.String, CreateKongWeiXianLusXml(model.XianLus));
            _db.AddInParameter(cmd, "PingTaiShuLiang", DbType.Int32, model.PingTaiShuLiang);
            _db.AddInParameter(cmd, "HangDuanXml", DbType.String, CreateHangDuanXml(model.HangDuans));
            _db.AddInParameter(cmd, "ShiFouXGDLS", DbType.AnsiStringFixedLength, model.ShiFouXGDLS ? "1" : "0");

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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 修改空位状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <param name="kongWeiStatus"></param>
        /// <returns></returns>
        public int UpdateKongWeiShouKeStatus(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiStatus kongWeiStatus)
        {

            DbCommand cmd = this._db.GetStoredProcCommand("proc_KongWei_UpdateStatus");
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)kongWeiStatus);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 获取控位实体
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MKongWei GetKongWeiById(string kongWeiId)
        {
            EyouSoft.Model.TourStructure.MKongWei model = null;
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT A.* ");
            query.Append(" ,(SELECT A1.TrafficName FROM tbl_CompanyTraffic AS A1 WHERE A1.Id=A.QuJiaoTongId) AS QuJiaoTongName ");
            query.Append(" ,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.QuDepProvinceId) AS QuChuFaDiShengFenName ");
            query.Append(" ,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.QuDepCityId) AS QuChuFaDiChengShiName ");
            query.Append(" ,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.QuArrProvinceId) AS QuMuDiDiShengFenName ");
            query.Append(" ,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.QuArrCityId) AS QuMuDiDiChengShiName ");
            query.Append(" ,(SELECT A1.TrafficName FROM tbl_CompanyTraffic AS A1 WHERE A1.Id=A.HuiJiaoTongId) AS HuiJiaoTongName ");
            query.Append(" ,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.HuiDepProvinceId) AS HuiChuFaDiShengFenName ");
            query.Append(" ,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.HuiDepCityId) AS HuiChuFaDiChengShiName ");
            query.Append(" ,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.HuiArrProvinceId) AS HuiMuDiDiShengFenName ");
            query.Append(" ,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.HuiArrCityId) AS HuiMuDiDiChengShiName ");
            query.Append(",(SELECT ISNULL(SUM(Adults+Childs+YingErRenShu+Bears),0) FROM tbl_TourOrder AS A1 WHERE A1.TourId=@KongWeiId AND A1.IsDelete='0' AND A1.OrderStatus IN(0,1,4,5)) AS YouXiaoShouKeRenShu");
            query.Append(" FROM tbl_KongWei AS A WHERE A.KongWeiId=@KongWeiId ");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.TourStructure.MKongWei();

                    model.KongWeiId = dr.GetString(dr.GetOrdinal("KongWeiId"));
                    model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    model.KongWeiType = (EyouSoft.Model.EnumType.TourStructure.BusinessType)dr.GetByte(dr.GetOrdinal("KongWeiType"));
                    model.KongWeiCode = !dr.IsDBNull(dr.GetOrdinal("KongWeiCode")) ? dr.GetString(dr.GetOrdinal("KongWeiCode")) : null;
                    model.ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang"));
                    model.KongWeiStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiStatus)dr.GetByte(dr.GetOrdinal("Status"));
                    model.AreaId = dr.GetInt32(dr.GetOrdinal("AreaId"));
                    model.QuDate = !dr.IsDBNull(dr.GetOrdinal("QuDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("QuDate")) : null;
                    model.QuJiaoTongId = dr.GetInt32(dr.GetOrdinal("QuJiaoTongId"));
                    model.QuDepProvinceId = dr.GetInt32(dr.GetOrdinal("QuDepProvinceId"));
                    model.QuDepCityId = dr.GetInt32(dr.GetOrdinal("QuDepCityId"));
                    model.QuArrProvinceId = dr.GetInt32(dr.GetOrdinal("QuArrProvinceId"));
                    model.QuArrCityId = dr.GetInt32(dr.GetOrdinal("QuArrCityId"));
                    model.QuBanCi = !dr.IsDBNull(dr.GetOrdinal("QuBanCi")) ? dr.GetString(dr.GetOrdinal("QuBanCi")) : null;
                    model.QuTime = !dr.IsDBNull(dr.GetOrdinal("QuTime")) ? dr.GetString(dr.GetOrdinal("QuTime")) : null;
                    model.HuiDate = !dr.IsDBNull(dr.GetOrdinal("HuiDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("HuiDate")) : null;
                    model.HuiJiaoTongId = !dr.IsDBNull(dr.GetOrdinal("HuiJiaoTongId")) ? dr.GetInt32(dr.GetOrdinal("HuiJiaoTongId")) : 0;
                    model.HuiDepProvinceId = !dr.IsDBNull(dr.GetOrdinal("HuiDepProvinceId")) ? dr.GetInt32(dr.GetOrdinal("HuiDepProvinceId")) : 0;
                    model.HuiDepCityId = !dr.IsDBNull(dr.GetOrdinal("HuiDepCityId")) ? dr.GetInt32(dr.GetOrdinal("HuiDepCityId")) : 0;
                    model.HuiArrProvinceId = !dr.IsDBNull(dr.GetOrdinal("HuiArrProvinceId")) ? dr.GetInt32(dr.GetOrdinal("HuiArrProvinceId")) : 0;
                    model.HuiArrCityId = !dr.IsDBNull(dr.GetOrdinal("HuiArrCityId")) ? dr.GetInt32(dr.GetOrdinal("HuiArrCityId")) : 0;
                    model.HuiBanCi = !dr.IsDBNull(dr.GetOrdinal("HuiBanCi")) ? dr.GetString(dr.GetOrdinal("HuiBanCi")) : null;
                    model.HuiTime = !dr.IsDBNull(dr.GetOrdinal("HuiTime")) ? dr.GetString(dr.GetOrdinal("HuiTime")) : null;
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    model.KongWeiZhuangTai = (EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)dr.GetByte(dr.GetOrdinal("KongWeiZhuangTai"));
                    model.TianShu = dr.GetInt32(dr.GetOrdinal("TianShu"));

                    model.QuJiaoTongName = dr["QuJiaoTongName"].ToString();
                    model.QuChuFaDiShengFenName = dr["QuChuFaDiShengFenName"].ToString();
                    model.QuDepCityName = dr["QuChuFaDiChengShiName"].ToString();
                    model.QuMuDiDiShengFenName = dr["QuMuDiDiShengFenName"].ToString();
                    model.QuArrCityName = dr["QuMuDiDiChengShiName"].ToString();
                    model.HuiJiaoTongName = dr["HuiJiaoTongName"].ToString();
                    model.HuiChuFaDiShengFenName = dr["HuiChuFaDiShengFenName"].ToString();
                    model.HuiDepCityName = dr["HuiChuFaDiChengShiName"].ToString();
                    model.HuiMuDiDiShengFenName = dr["HuiMuDiDiShengFenName"].ToString();
                    model.HuiArrCityName = dr["HuiMuDiDiChengShiName"].ToString();

                    model.ZxsId = dr["ZxsId"].ToString();
                    model.PingTaiShuLiang = dr.GetInt32(dr.GetOrdinal("PingTaiShuLiang"));
                    model.YouXiaoShouKeRenShu = dr.GetInt32(dr.GetOrdinal("YouXiaoShouKeRenShu"));
                    model.XianShiStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus)dr.GetByte(dr.GetOrdinal("XianShiStatus"));
                    model.PingTaiShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus)dr.GetByte(dr.GetOrdinal("PingTaiShouKeStatus"));
                }
            }

            if (model != null)
            {
                model.KongWeiDaiLiList = GetKongWeiDaiLis(kongWeiId);
                model.XianLus = GetKongWeiXianLus(kongWeiId);
                model.HangDuans = GetKongWeiHangDuans(kongWeiId);
            }

            return model;
        }

        /// <summary>
        /// 分页获取控位列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <param name="heJi">合计信息 [0:int:实收数量合计] [1:int:实际出票数量合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MPageKongWei> GetKongWei(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            EyouSoft.Model.TourStructure.MSearchKongWei search, out object[] heJi)
        {
            heJi = new object[] { 0, 0 };
            IList<EyouSoft.Model.TourStructure.MPageKongWei> list = new List<EyouSoft.Model.TourStructure.MPageKongWei>();

            #region fields
            StringBuilder fileds = new StringBuilder();
            fileds.Append("KongWeiId,QuDate,KongWeiCode,KongWeiType,AreaId,Status,");
            fileds.Append("(select AreaName from tbl_Area where Id=tbl_KongWei.AreaId) as AreaName,");
            fileds.Append("(select TrafficName from tbl_CompanyTraffic where  Id=tbl_KongWei.QuJiaoTongId) as QuJiaoTongName,");
            fileds.Append("(select CityName from tbl_CompanyCity where Id=tbl_KongWei.QuDepCityId) as QuDepCityName,");
            fileds.Append("(select CityName from tbl_CompanyCity where Id=tbl_KongWei.QuArrCityId) as QuArrCityName,");
            fileds.Append("ShuLiang,");
            fileds.Append("(select isnull(sum(Accounts),0) from tbl_TourOrder where TourId=tbl_KongWei.KongWeiId and OrderStatus=1 and IsDelete='0') as ShiShouShuLiang,");
            fileds.Append("(select isnull(sum(Accounts),0) from tbl_TourOrder where TourId=tbl_KongWei.KongWeiId and OrderStatus=0 and IsDelete='0') as YuLiuShuLiang");
            fileds.Append(" ,(SELECT ISNULL(SUM(A.ShuLiang),0) FROM tbl_PlanChuPiao AS A WHERE A.KongWeiId=tbl_KongWei.KongWeiId) AS ShiJiChuPiaoShuLiang ");
            fileds.Append(",KongWeiZhuangTai");
            fileds.Append(",MoBanId,ZxsId");
            fileds.Append(",(SELECT A.PiCiCode FROM tbl_Pt_KongWeiMoBan AS A WHERE A.MoBanId=tbl_KongWei.MoBanId) AS PiCiCode ");
            fileds.Append(",(select TrafficName from tbl_CompanyTraffic where  Id=tbl_KongWei.HuiJiaoTongId) as HuiJiaoTongName");
            fileds.Append(",(select CityName from tbl_CompanyCity where Id=tbl_KongWei.HuiDepCityId) as HuiDepCityName");
            fileds.Append(",(select CityName from tbl_CompanyCity where Id=tbl_KongWei.HuiArrCityId) as HuiArrCityName");
            fileds.Append(",QuBanCi,HuiBanCi");
            fileds.Append(",(SELECT ISNULL(SUM(A.Accounts),0) FROM tbl_TourOrder AS A WHERE A.TourId=tbl_KongWei.KongWeiId AND A.OrderStatus=5 AND A.IsDelete='0') AS MingDanBuQuanShuLiang");
            fileds.Append(",(SELECT ISNULL(SUM(A.Accounts),0) FROM tbl_TourOrder AS A WHERE A.TourId=tbl_KongWei.KongWeiId AND A.OrderStatus=4 AND A.IsDelete='0') AS WeiQueRenShuLiang");
            fileds.Append(",(SELECT ISNULL(SUM(A.Accounts),0) FROM tbl_TourOrder AS A WHERE A.TourId=tbl_KongWei.KongWeiId AND A.OrderStatus=6 AND A.IsDelete='0') AS ShenQingShuLiang");
            fileds.Append(",PingTaiShuLiang,PingTaiShouKeStatus,XianShiStatus");
            #endregion

            string tableName = "tbl_KongWei";
            string OrderByString = " IsChuTuan asc,QuDate asc ";
            string heJiString = "SUM(ShiShouShuLiang) ShiShouShuLiangHeJi,SUM(ShiJiChuPiaoShuLiang) AS ShiJiChuPiaoShuLiangHeJi";

            #region sql
            StringBuilder query = new StringBuilder();
            query.AppendFormat(" CompanyId={0} and IsDelete='{1}' and KongWeiType<>{2}", companyId, 0, (int)EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店);

            if (search != null)
            {
                if (search.LBeginDate.HasValue)
                {
                    query.AppendFormat(" and datediff(day,QuDate,'{0}')<=0 ", search.LBeginDate.Value);
                }
                if (search.LEndDate.HasValue)
                {
                    query.AppendFormat(" and datediff(day,QuDate,'{0}')>=0 ", search.LEndDate.Value);
                }
                if (!string.IsNullOrEmpty(search.KongWeiCode))
                {
                    query.AppendFormat(" and KongWeiCode like '%{0}%' ", search.KongWeiCode);
                }
                if (!string.IsNullOrEmpty(search.OrderCode))
                {
                    query.AppendFormat(" and exists(select 1 from tbl_TourOrder where TourId=tbl_KongWei.KongWeiId and OrderCode like '%{0}%') ", search.OrderCode);
                }
                if (!string.IsNullOrEmpty(search.GysOrderCode))
                {
                    query.AppendFormat(" and exists(select 1 from tbl_KongWeiDaiLi where KongWeiId=tbl_KongWei.KongWeiId and GysOrderCode like '%{0}%') ", search.GysOrderCode);
                }
                if (!string.IsNullOrEmpty(search.JiaoYiHao))
                {
                    query.Append(" and ( ");
                    query.AppendFormat(" exists(select 1 from tbl_PlanChuPiao where KongWeiId=tbl_KongWei.KongWeiId and JiaoYiHao like '%{0}%' ) ", search.JiaoYiHao);
                    query.AppendFormat(" OR EXISTS(SELECT 1 FROM tbl_PlanDiJie AS B WHERE B.KongWeiId=tbl_KongWei.KongWeiId AND B.JiaoYiHao LIKE '%{0}%' ) ", search.JiaoYiHao);
                    query.AppendFormat(" OR EXISTS(SELECT 1 FROM tbl_TourOrderHotelPlan AS B WHERE B.TourId=tbl_KongWei.KongWeiId AND B.JiaoYiHao LIKE '%{0}%' AND B.IsDelete='0') ", search.JiaoYiHao);
                    query.Append(" ) ");
                }
                if (!string.IsNullOrEmpty(search.BuyCompanyName))
                {
                    query.AppendFormat(" and exists(select 1 from  tbl_TourOrder inner join tbl_Customer on tbl_TourOrder.BuyCompanyId=tbl_Customer.Id  where TourId=tbl_KongWei.KongWeiId and tbl_Customer.Name like '%{0}%')", search.BuyCompanyName);
                }
                if (!string.IsNullOrEmpty(search.TravellerName))
                {
                    query.AppendFormat(" and exists(select 1 from tbl_TourOrderTraveller where tbl_TourOrderTraveller.TourId=tbl_KongWei.KongWeiId and TravellerName like '%{0}%') ", search.TravellerName);
                }
                if (search.AreaId.HasValue && search.AreaId.Value > 0)
                {
                    query.AppendFormat(" AND AreaId={0} ", search.AreaId.Value);
                }
                if (search.QuJiaoTongId.HasValue && search.QuJiaoTongId.Value > 0)
                {
                    query.AppendFormat(" AND QuJiaoTongId={0} ", search.QuJiaoTongId.Value);
                }
                if (search.QuDepProvinceId.HasValue && search.QuDepProvinceId.Value > 0)
                {
                    query.AppendFormat(" AND QuDepProvinceId={0} ", search.QuDepProvinceId.Value);
                }
                if (search.QuDepCityId.HasValue && search.QuDepCityId.Value > 0)
                {
                    query.AppendFormat(" AND QuDepCityId={0} ", search.QuDepCityId.Value);
                }
                if (search.QuArrProvinceId.HasValue && search.QuArrProvinceId.Value > 0)
                {
                    query.AppendFormat(" AND QuArrProvinceId={0} ", search.QuArrProvinceId.Value);
                }
                if (search.QuArrCityId.HasValue && search.QuArrCityId.Value > 0)
                {
                    query.AppendFormat(" AND QuArrCityId={0} ", search.QuArrCityId.Value);
                }
                if (search.KongWeiZhuangTai.HasValue)
                {
                    query.AppendFormat(" AND KongWeiZhuangTai={0} ", (int)search.KongWeiZhuangTai.Value);
                }
                if (!string.IsNullOrEmpty(search.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", search.ZxsId);
                }
                if (!string.IsNullOrEmpty(search.PiCiCode))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_Pt_KongWeiMoBan AS A WHERE A.MoBanId=tbl_KongWei.MoBanId AND A.PiCiCode='{0}') ", search.PiCiCode);
                }
                if (search.DingDanStatus.HasValue)
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_TourOrder AS A WHERE A.TourId=tbl_KongWei.KongWeiId AND A.OrderStatus={0}) ", (int)search.DingDanStatus.Value);
                }
                if (!string.IsNullOrEmpty(search.XianLuCode))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_Pt_KongWeiXianLu AS A WHERE A.KongWeiId=tbl_KongWei.KongWeiId AND A.XianLuCode LIKE '%{0}%') ", search.XianLuCode);
                }
                if (search.ShouKeStatus.HasValue)
                {
                    query.AppendFormat(" AND Status={0} ", (int)search.ShouKeStatus.Value);
                }
                if (search.PingTaiShouKeStatus.HasValue)
                {
                    query.AppendFormat(" AND PingTaiShouKeStatus={0} ", (int)search.PingTaiShouKeStatus.Value);
                }
                if (search.XianShiStatus.HasValue)
                {
                    query.AppendFormat(" AND XianShiStatus={0} ", (int)search.XianShiStatus.Value);
                }
            }
            #endregion

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds.ToString(), query.ToString(), OrderByString, heJiString))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.TourStructure.MPageKongWei model = new EyouSoft.Model.TourStructure.MPageKongWei
                    {
                        KongWeiId = dr.GetString(dr.GetOrdinal("KongWeiId")),
                        AreaId = dr.GetInt32(dr.GetOrdinal("AreaId")),
                        QuDate = dr.GetDateTime(dr.GetOrdinal("QuDate")),
                        KongWeiCode = dr.GetString(dr.GetOrdinal("KongWeiCode")),
                        KongWeiType = (EyouSoft.Model.EnumType.TourStructure.BusinessType)dr.GetByte(dr.GetOrdinal("KongWeiType")),
                        AreaName = !dr.IsDBNull(dr.GetOrdinal("AreaName")) ? dr.GetString(dr.GetOrdinal("AreaName")) : null,
                        QuJiaoTongName = dr["QuJiaoTongName"].ToString(),
                        QuDepCityName = !dr.IsDBNull(dr.GetOrdinal("QuDepCityName")) ? dr.GetString(dr.GetOrdinal("QuDepCityName")) : null,
                        QuArrCityName = !dr.IsDBNull(dr.GetOrdinal("QuArrCityName")) ? dr.GetString(dr.GetOrdinal("QuArrCityName")) : null,
                        ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang")),
                        ShiShouShuLiang = dr.GetInt32(dr.GetOrdinal("ShiShouShuLiang")),
                        YuLiuShuLiang = dr.GetInt32(dr.GetOrdinal("YuLiuShuLiang")),
                        KongWeiStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiStatus)dr.GetByte(dr.GetOrdinal("Status")),
                        KongWeiZhuangTai = (EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)dr.GetByte(dr.GetOrdinal("KongWeiZhuangTai"))
                    };
                    model.ShiJiChuPiaoShuLiang = dr.GetInt32(dr.GetOrdinal("ShiJiChuPiaoShuLiang"));
                    model.MoBanId = dr["MoBanId"].ToString();
                    model.PiCiCode = dr["PiCiCode"].ToString();
                    model.HuiJiaoTongName = dr["HuiJiaoTongName"].ToString();
                    model.HuiDepCityName = dr["HuiDepCityName"].ToString();
                    model.HuiArrCityName = dr["HuiArrCityName"].ToString();
                    model.QuBanCi = dr["QuBanCi"].ToString();
                    model.HuiBanCi = dr["HuiBanCi"].ToString();

                    model.MingDanBuQuanShuLiang = dr.GetInt32(dr.GetOrdinal("MingDanBuQuanShuLiang"));
                    model.WeiQueRenShuLiang = dr.GetInt32(dr.GetOrdinal("WeiQueRenShuLiang"));
                    model.ShenQingShuLiang = dr.GetInt32(dr.GetOrdinal("ShenQingShuLiang"));
                    model.PingTaiShuLiang = dr.GetInt32(dr.GetOrdinal("PingTaiShuLiang"));
                    model.PingTaiShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus)dr.GetByte(dr.GetOrdinal("PingTaiShouKeStatus"));
                    model.XianShiStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus)dr.GetByte(dr.GetOrdinal("XianShiStatus"));

                    list.Add(model);
                }

                dr.NextResult();

                if (dr.Read())
                {
                    if (!dr.IsDBNull(dr.GetOrdinal("ShiShouShuLiangHeJi"))) heJi[0] = dr.GetInt32(dr.GetOrdinal("ShiShouShuLiangHeJi"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ShiJiChuPiaoShuLiangHeJi"))) heJi[1] = dr.GetInt32(dr.GetOrdinal("ShiJiChuPiaoShuLiangHeJi"));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据控位编号 获取计划控位代理商信息表
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiDaiLi> GetKongWeiDaiLiById(string kongWeiId)
        {
            IList<EyouSoft.Model.TourStructure.MKongWeiDaiLi> list = new List<EyouSoft.Model.TourStructure.MKongWeiDaiLi>();

            StringBuilder query = new StringBuilder();
            query.Append(" SELECT A.* ");
            query.Append(" ,(select A1.UnitName from  tbl_CompanySupplier AS A1 where A1.Id=A.GysId) as GysName ");
            query.Append(" ,(select sum(A1.ShuLiang) from tbl_PlanChuPiao AS A1 where A1.DaiLiId=A.DaiLiId) as YiChuPiaoShuLiang ");
            query.Append(" FROM tbl_KongWeiDaiLi AS A ");
            query.Append("Where A.KongWeiId=@KongWeiId ORDER BY A.IdentityId ASC");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.TourStructure.MKongWeiDaiLi model = new EyouSoft.Model.TourStructure.MKongWeiDaiLi();
                    model.DaiLiId = dr.GetString(dr.GetOrdinal("DaiLiId"));
                    model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    model.KongWeiId = dr.GetString(dr.GetOrdinal("KongWeiId"));
                    model.GysId = !dr.IsDBNull(dr.GetOrdinal("GysId")) ? dr.GetString(dr.GetOrdinal("GysId")) : string.Empty;
                    model.GysName = !dr.IsDBNull(dr.GetOrdinal("GysName")) ? dr.GetString(dr.GetOrdinal("GysName")) : string.Empty;
                    model.GysOrderCode = !dr.IsDBNull(dr.GetOrdinal("GysOrderCode")) ? dr.GetString(dr.GetOrdinal("GysOrderCode")) : string.Empty;
                    model.LxrName = !dr.IsDBNull(dr.GetOrdinal("LxrName")) ? dr.GetString(dr.GetOrdinal("LxrName")) : string.Empty;
                    model.LxrTelephone = !dr.IsDBNull(dr.GetOrdinal("LxrTelephone")) ? dr.GetString(dr.GetOrdinal("LxrTelephone")) : string.Empty;
                    model.Price = !dr.IsDBNull(dr.GetOrdinal("Price")) ? dr.GetDecimal(dr.GetOrdinal("Price")) : 0;
                    model.ShuLiang = !dr.IsDBNull(dr.GetOrdinal("ShuLiang")) ? dr.GetInt32(dr.GetOrdinal("ShuLiang")) : 0;
                    model.ShiXian = !dr.IsDBNull(dr.GetOrdinal("ShiXian")) ? dr.GetString(dr.GetOrdinal("ShiXian")) : string.Empty;
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : string.Empty;
                    model.YaJinAmount = !dr.IsDBNull(dr.GetOrdinal("YaJinAmount")) ? dr.GetDecimal(dr.GetOrdinal("YaJinAmount")) : 0;
                    model.YaJinBeiZhu = !dr.IsDBNull(dr.GetOrdinal("YaJinBeiZhu")) ? dr.GetString(dr.GetOrdinal("YaJinBeiZhu")) : string.Empty;
                    model.YaJinOperatorId = !dr.IsDBNull(dr.GetOrdinal("YaJinOperatorId")) ? dr.GetInt32(dr.GetOrdinal("YaJinOperatorId")) : 0;
                    model.TuiYaJinAmount = !dr.IsDBNull(dr.GetOrdinal("TuiYaJinAmount")) ? dr.GetDecimal(dr.GetOrdinal("TuiYaJinAmount")) : 0;
                    model.TuiYaJinBeiZhu = !dr.IsDBNull(dr.GetOrdinal("TuiYaJinBeiZhu")) ? dr.GetString(dr.GetOrdinal("TuiYaJinBeiZhu")) : string.Empty;
                    model.TuiTime = !dr.IsDBNull(dr.GetOrdinal("TuiTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("TuiTime")) : null;
                    model.TuiYaJinOperatorId = !dr.IsDBNull(dr.GetOrdinal("TuiYaJinOperatorId")) ? dr.GetInt32(dr.GetOrdinal("TuiYaJinOperatorId")) : 0;
                    model.YiChuPiaoShuLiang = !dr.IsDBNull(dr.GetOrdinal("YiChuPiaoShuLiang")) ? dr.GetInt32(dr.GetOrdinal("YiChuPiaoShuLiang")) : 0;

                    list.Add(model);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取控位剩余数量
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public int GetShengYuShuLiang(string kongWeiId)
        {
            StringBuilder s = new StringBuilder();
            s.Append(" SELECT A.ShuLiang ");
            s.Append(" ,(SELECT ISNULL(SUM(A1.Accounts),0) FROM tbl_TourOrder AS A1 WHERE A1.TourId=A.KongWeiId AND A1.IsDelete='0' AND A1.OrderStatus IN (@Status1,@Status2) ) AS ZhanWeiShuLiang ");
            s.Append(" ,(SELECT ISNULL(SUM(A1.ShuLiang),0) FROM tbl_PlanChuPiao AS A1 WHERE A1.KongWeiId=A.KongWeiId) AS ShiJiChuPiaoShuLiang ");
            s.Append(" FROM tbl_KongWei AS A ");
            s.Append(" WHERE A.KongWeiId=@KongWeiId ");

            DbCommand cmd = _db.GetSqlStringCommand(s.ToString());
            _db.AddInParameter(cmd, "Status1", DbType.Byte, EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交);
            _db.AddInParameter(cmd, "Status2", DbType.Byte, EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    int kongWeiShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    int zhanWeiShuLiang = rdr.GetInt32(rdr.GetOrdinal("ZhanWeiShuLiang"));
                    int shiJiChuPiaoShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShiJiChuPiaoShuLiang"));

                    if (shiJiChuPiaoShuLiang > zhanWeiShuLiang) return kongWeiShuLiang - shiJiChuPiaoShuLiang;

                    return kongWeiShuLiang - zhanWeiShuLiang;
                }
            }

            return 0;
        }

        /*/// <summary>
        /// 设置控位状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="zhuangTai">控位状态</param>
        /// <returns></returns>
        public int SetKongWeiZhuangTai(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai zhuangTai)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SetKongWeiZhuangTai);
            _db.AddInParameter(cmd, "KongWeiZhuangTai", DbType.Byte, zhuangTai);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }*/

        /// <summary>
        /// 设置控位状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="zhuangTai">控位状态</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public int SetKongWeiZhuangTai(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai zhuangTai, int companyId, string zxsId)
        {
            var cmd = _db.GetStoredProcCommand("proc_KongWei_SheZhiZhuangTai");
            _db.AddInParameter(cmd, "@KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@ZhuangTai", DbType.Byte, zhuangTai);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

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
        /// 获取控位状态
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai GetKongWeiZhuangTai(string kongWeiId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetKongWeiZhuangTai);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return (EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)rdr.GetByte(0);
                }
            }

            return EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束;
        }

        /// <summary>
        /// 新增控位操作备注，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertKongWeiBeiZhu(EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo info)
        {
            string sql = "INSERT INTO [tbl_Pt_KongWeiBeiZhu]([BeiZhuId],[KongWeiId],[NeiRong],[IssueTime],[OperatorId],[Status],[LatestOperatorId],[LatestTime]) VALUES(@BeiZhuId,@KongWeiId,@NeiRong,@IssueTime,@OperatorId,@Status,@LatestOperatorId,@LatestTime)";
            var cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "BeiZhuId", DbType.AnsiStringFixedLength, info.BeiZhuId);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, info.KongWeiId);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "LatestOperatorId", DbType.Int32, info.LatestOperatorId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取控位操作备注集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo> GetKongWeiBeiZhus(string kongWeiId,EyouSoft.Model.TourStructure.MKongWeiBeiZhuChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo> items = new List<EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo>();
            string sql = " SELECT A.*,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.LatestOperatorId) AS LatestOperatorName FROM [tbl_Pt_KongWeiBeiZhu] AS A WHERE A.KongWeiId=@KongWeiId ";
            if (chaXun != null)
            {
                if (chaXun.Status.HasValue)
                {
                    sql += string.Format(" AND Status={0} ", chaXun.Status.Value);
                }
            }
            sql += " ORDER BY A.IdentityId ASC ";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo();
                    item.BeiZhuId = rdr["BeiZhuId"].ToString();
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.KongWeiId = kongWeiId;
                    item.LatestOperatorId = rdr.GetInt32(rdr.GetOrdinal("LatestOperatorId"));
                    item.LatestOperatorName = rdr["LatestOperatorName"].ToString();
                    item.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    item.NeiRong = rdr["NeiRong"].ToString();
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.OperatorName = rdr["OperatorName"].ToString();
                    item.Status = rdr.GetByte(rdr.GetOrdinal("Status"));
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置控位操作备注状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="beiZhuId">操作备注编号</param>
        /// <param name="status">状态 0:有效 1:失效</param>
        /// <param name="operatorId">操作员编号</param>
        /// <param name="shiJian">操作时间</param>
        /// <returns></returns>
        public int SheZhiKongWeiBeiZhuStatus(string kongWeiId, string beiZhuId, int status, int operatorId, DateTime shiJian)
        {
            string sql = "UPDATE tbl_Pt_KongWeiBeiZhu SET Status=@Status,LatestOperatorId=@LatestOperatorId,LatestTime=@LatestTime WHERE BeiZhuId=@BeiZhuId";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "LatestOperatorId", DbType.Int32, operatorId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, shiJian);
            _db.AddInParameter(cmd, "BeiZhuId", DbType.AnsiStringFixedLength, beiZhuId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 根据控位编号集合获取控位日期集合
        /// </summary>
        /// <param name="kongWeiIds">控位编号集合</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiRiQiInfo> GetKongWeisRiQis(IList<string> kongWeiIds)
        {
            IList<EyouSoft.Model.TourStructure.MKongWeiRiQiInfo> items = new List<EyouSoft.Model.TourStructure.MKongWeiRiQiInfo>();
            string sql = string.Format("SELECT QuDate,KongWeiId FROM tbl_KongWei WHERE KongWeiId IN({0}) ORDER BY QuDate ASC", Utils.GetSqlInExpression(kongWeiIds));

            var cmd = _db.GetSqlStringCommand(sql);
            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MKongWeiRiQiInfo();
                    item.KongWeiId = rdr[1].ToString();
                    item.QuDate = rdr.GetDateTime(0);
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取控位线路产品集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> GetKongWeiXianLus(string kongWeiId)
        {
            IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> items = new List<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo>();
            string sql = "SELECT *,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName FROM tbl_Pt_KongWeiXianLu AS A WHERE A.KongWeiId =@KongWeiId ORDER BY A.KongWeiId ASC, A.PaiXuId ASC";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item =new EyouSoft.Model.TourStructure.MKongWeiXianLuInfo();
                    item.BuFangChaJiaGe = rdr.GetDecimal(rdr.GetOrdinal("BuFangChaJiaGe"));
                    item.JieSuanJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe1"));
                    item.JieSuanJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe2"));
                    item.JieSuanJiaGe3 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe3"));
                    item.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    item.KongWeiId = kongWeiId;
                    item.LeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.MenShiJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe1"));
                    item.MenShiJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe2"));
                    item.MenShiJiaGe3 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe3"));
                    item.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    item.QuanPeiJiaGe = rdr.GetDecimal(rdr.GetOrdinal("QuanPeiJiaGe"));
                    item.RouteId = rdr["RouteId"].ToString();
                    item.Status = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.TuiFangChaJiaGe = rdr.GetDecimal(rdr.GetOrdinal("TuiFangChaJiaGe"));
                    item.XianLuCode = rdr["XianLuCode"].ToString();
                    item.XianLuId = rdr["XianLuId"].ToString();
                    item.RouteName = rdr["RouteName"].ToString();
                    item.XianDingRenShu = rdr.GetInt32(rdr.GetOrdinal("XianDingRenShu"));
                    item.ZuiXiaoRenShu = rdr.GetInt32(rdr.GetOrdinal("ZuiXiaoRenShu"));

                    items.Add(item);
                }
            }            

            return items;
        }

        /// <summary>
        /// 获取控位线路产品集合
        /// </summary>
        /// <param name="kongWeiIds">控位编号集合</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> GetKongWeisXianLus(IList<string> kongWeiIds)
        {
            IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> items = new List<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo>();
            string sql = "SELECT *,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName FROM tbl_Pt_KongWeiXianLu AS A WHERE A.KongWeiId IN({0}) ORDER BY A.KongWeiId ASC, A.PaiXuId ASC";
            sql = string.Format(sql, Utils.GetSqlInExpression(kongWeiIds));
            var cmd = _db.GetSqlStringCommand(sql);
            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TourStructure.MKongWeiXianLuInfo();
                    item.BuFangChaJiaGe = rdr.GetDecimal(rdr.GetOrdinal("BuFangChaJiaGe"));
                    item.JieSuanJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe1"));
                    item.JieSuanJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe2"));
                    item.JieSuanJiaGe3 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe3"));
                    item.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.LeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.MenShiJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe1"));
                    item.MenShiJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe2"));
                    item.MenShiJiaGe3 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe3"));
                    item.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    item.QuanPeiJiaGe = rdr.GetDecimal(rdr.GetOrdinal("QuanPeiJiaGe"));
                    item.RouteId = rdr["RouteId"].ToString();
                    item.Status = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.TuiFangChaJiaGe = rdr.GetDecimal(rdr.GetOrdinal("TuiFangChaJiaGe"));
                    item.XianLuCode = rdr["XianLuCode"].ToString();
                    item.XianLuId = rdr["XianLuId"].ToString();

                    item.RouteName = rdr["RouteName"].ToString();
                    item.XianDingRenShu = rdr.GetInt32(rdr.GetOrdinal("XianDingRenShu"));
                    item.ZuiXiaoRenShu = rdr.GetInt32(rdr.GetOrdinal("ZuiXiaoRenShu"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取控位线路信息
        /// </summary>
        /// <param name="kongWeiXianLuId">控位线路编号</param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MKongWeiXianLuInfo GetKongWeiXianLuInfo(string kongWeiXianLuId)
        {
            EyouSoft.Model.TourStructure.MKongWeiXianLuInfo info = null;
            string sql = "SELECT *,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName,(SELECT A1.ZxsId FROM tbl_KongWei AS A1 WHERE A1.KongWeiId=A.KongWeiId) AS ZxsId FROM tbl_Pt_KongWeiXianLu AS A WHERE A.XianLuId =@XianLuId";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "XianLuId", DbType.AnsiStringFixedLength, kongWeiXianLuId);


            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    info = new EyouSoft.Model.TourStructure.MKongWeiXianLuInfo();
                    info.BuFangChaJiaGe = rdr.GetDecimal(rdr.GetOrdinal("BuFangChaJiaGe"));
                    info.JieSuanJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe1"));
                    info.JieSuanJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe2"));
                    info.JieSuanJiaGe3 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe3"));
                    info.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    info.KongWeiId = rdr["KongWeiId"].ToString();
                    info.LeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.MenShiJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe1"));
                    info.MenShiJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe2"));
                    info.MenShiJiaGe3 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe3"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.QuanPeiJiaGe = rdr.GetDecimal(rdr.GetOrdinal("QuanPeiJiaGe"));
                    info.RouteId = rdr["RouteId"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.TuiFangChaJiaGe = rdr.GetDecimal(rdr.GetOrdinal("TuiFangChaJiaGe"));
                    info.XianLuCode = rdr["XianLuCode"].ToString();
                    info.XianLuId = rdr["XianLuId"].ToString();
                    info.RouteName = rdr["RouteName"].ToString();
                    info.ZxsId = rdr["ZxsId"].ToString();
                    info.XianDingRenShu = rdr.GetInt32(rdr.GetOrdinal("XianDingRenShu"));
                    info.ZuiXiaoRenShu = rdr.GetInt32(rdr.GetOrdinal("ZuiXiaoRenShu"));
                }
            }

            return info;
        }

        /// <summary>
        /// 设置平台收客状态，返回1成功，其它失败
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="status">平台收客状态</param>
        /// <returns></returns>
        public int SheZhiPingTaiShouKeStatus(string zxsId, string kongWeiId, EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus status)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE tbl_KongWei SET PingTaiShouKeStatus=@Status WHERE KongWeiId=@KongWeiId AND ZxsId=@ZxsId");
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 设置平台控位数量，返回1成功，其它失败
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="pingTaiShuLiang">平台数量</param>
        /// <returns></returns>
        public int SheZhiPingTaiShuLiang(string zxsId, string kongWeiId, int pingTaiShuLiang)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE tbl_KongWei SET PingTaiShuLiang=@PingTaiShuLiang WHERE KongWeiId=@KongWeiId AND ZxsId=@ZxsId");
            _db.AddInParameter(cmd, "PingTaiShuLiang", DbType.Int32, pingTaiShuLiang);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 设置控位显示状态
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="xianShiStatus">显示状态</param>
        /// <returns></returns>
        public int SheZhiKongWeiXianShiStatus(string zxsId, string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus xianShiStatus)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE tbl_KongWei SET XianShiStatus=@XianShiStatus WHERE ZxsId=@ZxsId AND KongWeiId=@KongWeiId");
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            _db.AddInParameter(cmd, "XianShiStatus", DbType.Byte, xianShiStatus);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }
        #endregion
    }
}
