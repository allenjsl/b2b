//供应商主体相关DAL 汪奇志 2015-05-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.GysStructure
{
    /// <summary>
    /// 供应商主体相关DAL
    /// </summary>
    public class DGysZhuTi : DALBase, EyouSoft.IDAL.GysStructure.IGysZhuTi
    {
        #region static constants
        //static constants
        
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DGysZhuTi()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// create gyszhuti guanxi xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateGysZhuTiGuanXiXml(IList<EyouSoft.Model.GysStructure.MGysZhuTiGuanXiInfo> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();
            s.AppendFormat("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info GysId=\"{0}\" />", item.GysId);
            }
            s.AppendFormat("</root>");
            return s.ToString();
        }

        /// <summary>
        /// get gyszhuti guanxi
        /// </summary>
        /// <param name="gysId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.GysStructure.MGysZhuTiGuanXiInfo> GetGysZhuTiGuanXis(string gysId)
        {
            var items = new List<EyouSoft.Model.GysStructure.MGysZhuTiGuanXiInfo>();

            var cmd = _db.GetSqlStringCommand("SELECT A.*,B.UnitName AS GysName FROM tbl_Gys_ZhuTi_GuanXi AS A INNER JOIN tbl_CompanySupplier AS B ON A.GysId2=B.Id WHERE A.GysId1=@GysId1");
            _db.AddInParameter(cmd, "@GysId1", DbType.AnsiStringFixedLength, gysId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.GysStructure.MGysZhuTiGuanXiInfo();
                    item.GysId = rdr["GysId2"].ToString();
                    item.GysName = rdr["GysName"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region IGysZhuTi 成员
        /// <summary>
        /// 供应商主体新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int GysZhuTi_CU(EyouSoft.Model.GysStructure.MGysZhuTiInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_GysZhuTi_CU");
            _db.AddInParameter(cmd, "@GysId", DbType.AnsiStringFixedLength, info.GysId);
            _db.AddInParameter(cmd, "@LeiXing", DbType.Int32, info.LeiXing);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);
            _db.AddInParameter(cmd, "@GysName", DbType.String, info.GysName);
            _db.AddInParameter(cmd, "@ShengFenId", DbType.Int32, info.ShengFenId);
            _db.AddInParameter(cmd, "@ChengShiId", DbType.Int32, info.ChengShiId);
            _db.AddInParameter(cmd, "@JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "@CaoZuoRenId", DbType.Int32, info.CaoZuoRenId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@LxrName", DbType.String, info.LxrName);
            _db.AddInParameter(cmd, "@LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "@LxrShouJi", DbType.String, info.LxrShouJi);
            _db.AddInParameter(cmd, "@DiZhi", DbType.String, info.DiZhi);
            _db.AddInParameter(cmd, "@Fax", DbType.String, info.Fax);
            _db.AddInParameter(cmd, "@GysGuanXiXml", DbType.String, CreateGysZhuTiGuanXiXml(info.GuanXis));
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
        /// 供应商主体删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        public int GysZhuTi_D(int companyId, string gysId)
        {
            var cmd = _db.GetStoredProcCommand("proc_GysZhuTi_D");
            _db.AddInParameter(cmd, "@GysId", DbType.AnsiStringFixedLength, gysId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
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
        /// 获取供应商主体信息业务实体
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        public EyouSoft.Model.GysStructure.MGysZhuTiInfo GetInfo(string gysId)
        {
            EyouSoft.Model.GysStructure.MGysZhuTiInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_Gys_ZhuTi WHERE GysId=@GysId");
            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, gysId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.GysStructure.MGysZhuTiInfo();
                    info.CaoZuoRenId = rdr.GetInt32(rdr.GetOrdinal("CaoZuoRenId"));
                    info.ChengShiId = rdr.GetInt32(rdr.GetOrdinal("ChengShiId"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DiZhi = rdr["DiZhi"].ToString();
                    info.Fax = rdr["Fax"].ToString();
                    info.GysId = rdr["GysId"].ToString();
                    info.GysName = rdr["GysName"].ToString();
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.LeiXing = (EyouSoft.Model.EnumType.CompanyStructure.SupplierType)rdr.GetInt32(rdr.GetOrdinal("LeiXing"));
                    info.LxrDianHua = rdr["LxrDianHua"].ToString();
                    info.LxrName = rdr["LxrName"].ToString();
                    info.LxrShouJi = rdr["LxrShouJi"].ToString();
                    info.ShengFenId = rdr.GetInt32(rdr.GetOrdinal("ShengFenId"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            if (info != null)
            {
                info.GuanXis = GetGysZhuTiGuanXis(gysId);
            }

            return info;
        }

        /// <summary>
        /// 获取供应商主体信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MGysZhuTiInfo> GetGysZhuTis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MGysZhuTiChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.GysStructure.MGysZhuTiInfo> items = new List<EyouSoft.Model.GysStructure.MGysZhuTiInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_Gys_ZhuTi";
            string orderByString = " IssueTime DESC ";
            string sumString = "";

            #region fields
            fields.Append("*,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=tbl_Gys_ZhuTi.ShengFenId) AS ShengFenName,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=tbl_Gys_ZhuTi.ChengShiId) AS ChengShiName");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} AND IsDelete='0' ", companyId);
            if (chaXun != null)
            {
                if (chaXun.ChengShiId.HasValue)
                {
                    query.AppendFormat(" AND ChengShiId={0} ", chaXun.ChengShiId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND GysName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.LxrName))
                {
                    query.AppendFormat(" AND (LxrName LIKE '%{0}%' OR EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi_Lxr AS A1 WHERE A1.GysId=tbl_Gys_ZhuTi.GysId AND A1.LxrName LIKE '%{0}%' AND A1.IsDelete='0')) ", chaXun.LxrName);
                }
                if (chaXun.ShengFenId.HasValue)
                {
                    query.AppendFormat(" AND ShengFenId={0} ", chaXun.ShengFenId.Value);
                }
                if (chaXun.LeiXing.HasValue)
                {
                    query.AppendFormat(" AND LeiXing={0} ", (int)chaXun.LeiXing.Value);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.GysStructure.MGysZhuTiInfo();
                    info.CaoZuoRenId = rdr.GetInt32(rdr.GetOrdinal("CaoZuoRenId"));
                    info.ChengShiId = rdr.GetInt32(rdr.GetOrdinal("ChengShiId"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DiZhi = rdr["DiZhi"].ToString();
                    info.Fax = rdr["Fax"].ToString();
                    info.GysId = rdr["GysId"].ToString();
                    info.GysName = rdr["GysName"].ToString();
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.LeiXing = (EyouSoft.Model.EnumType.CompanyStructure.SupplierType)rdr.GetInt32(rdr.GetOrdinal("LeiXing"));
                    info.LxrDianHua = rdr["LxrDianHua"].ToString();
                    info.LxrName = rdr["LxrName"].ToString();
                    info.LxrShouJi = rdr["LxrShouJi"].ToString();
                    info.ShengFenId = rdr.GetInt32(rdr.GetOrdinal("ShengFenId"));
                    info.ZxsId = rdr["ZxsId"].ToString();

                    info.ShengFenName = rdr["ShengFenName"].ToString();
                    info.ChengShiName = rdr["ChengShiName"].ToString();

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取供应商主体联系人信息集合
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo> GetGysLxrs(string gysId)
        {
            IList<EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo> items = new List<EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo>();

            var cmd = _db.GetSqlStringCommand("SELECT A.*,B.Username AS YongHuMing FROM tbl_Gys_ZhuTi_Lxr AS A INNER JOIN tbl_CompanyUser AS B ON A.GysId=B.GysId AND A.LxrId=B.GysLxrId AND A.YongHuId=B.Id AND B.LeiXing=@LeiXing WHERE A.IsDelete='0' AND A.GysId=@GysId ORDER BY A.LxrId ASC");
            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, gysId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Int32, EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.供应商用户);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo();
                    item.CaoZuoRenId = rdr.GetInt32(rdr.GetOrdinal("CaoZuoRenId"));
                    item.GysId = rdr["GysId"].ToString();
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.LxrBuMen = rdr["LxrBuMen"].ToString();
                    item.LxrDianHua = rdr["LxrDianHua"].ToString();
                    item.LxrFax = rdr["LxrFax"].ToString();
                    item.LxrId = rdr.GetInt32(rdr.GetOrdinal("LxrId"));
                    item.LxrName = rdr["LxrName"].ToString();
                    item.LxrQQ = rdr["LxrQQ"].ToString();
                    item.LxrShouJi = rdr["LxrShouJi"].ToString();
                    item.LxrWeiXin = rdr["LxrWeiXin"].ToString();
                    item.LxrZhiWu = rdr["LxrZhiWu"].ToString();
                    item.YongHuId = rdr.GetInt32(rdr.GetOrdinal("YongHuId"));
                    item.YongHuMing = rdr["YongHuMing"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 供应商主体联系人信息新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int GysZhuTi_Lxr_CU(EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_GysZhuTi_Lxr_CU");
            _db.AddInParameter(cmd, "@LxrId", DbType.AnsiStringFixedLength, info.LxrId);
            _db.AddInParameter(cmd, "@GysId", DbType.AnsiStringFixedLength, info.GysId);
            _db.AddInParameter(cmd, "@LxrName", DbType.String, info.LxrName);
            _db.AddInParameter(cmd, "@LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "@LxrShouJi", DbType.String, info.LxrShouJi);
            _db.AddInParameter(cmd, "@LxrFax", DbType.String, info.LxrFax);
            _db.AddInParameter(cmd, "@LxrBuMen", DbType.String, info.LxrBuMen);
            _db.AddInParameter(cmd, "@LxrZhiWu", DbType.String, info.LxrZhiWu);
            _db.AddInParameter(cmd, "@LxrQQ", DbType.String, info.LxrQQ);
            _db.AddInParameter(cmd, "@LxrWeiXin", DbType.String, info.LxrWeiXin);
            _db.AddInParameter(cmd, "@CaoZuoRenId", DbType.Int32, info.CaoZuoRenId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@YongHuMing", DbType.String, info.YongHuMing);
            _db.AddInParameter(cmd, "@MiMa", DbType.String, info.MiMa);
            _db.AddInParameter(cmd, "@Md5MiMa", DbType.String, info.Md5MiMa);
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
        /// 供应商主体联系人信息删除，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">联系人用户编号</param>
        /// <returns></returns>
        public int GysZhuTi_lxr_D(string gysId, int lxrId, int yongHuId)
        {
            var cmd = _db.GetStoredProcCommand("proc_GysZhuTi_Lxr_D");
            _db.AddInParameter(cmd, "@LxrId", DbType.Int32,lxrId);
            _db.AddInParameter(cmd, "@GysId", DbType.AnsiStringFixedLength, gysId);
            _db.AddInParameter(cmd, "@YongHuId", DbType.Int32, yongHuId);
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
        /// 获取选用的供应商信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MXuanYongGysInfo> GetXuanYongGyss(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MXuanYongGysChaXunInfo chaXun)
        {
            var items = new List<EyouSoft.Model.GysStructure.MXuanYongGysInfo>();
            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Gys_XuanYong";
            string orderByString = " ShengFenId ASC,ChengShiId ASC,GysName ASC ";
            string sumString = "";

            #region fields
            fields.Append("*");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (chaXun.ChengShiId.HasValue)
                {
                    query.AppendFormat(" AND ChengShiId={0} ", chaXun.ChengShiId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND GysName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.LxrName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_SupplierContact AS A1 WHERE A1.SupplierId=view_Gys_XuanYong.GysId AND A1.ContactName LIKE '%{0}%') ", chaXun.LxrName);
                }
                if (chaXun.ShengFenId.HasValue)
                {
                    query.AppendFormat(" AND ShengFenId={0} ", chaXun.ShengFenId.Value);
                }
                if (chaXun.LeiXing.HasValue)
                {
                    query.AppendFormat(" AND LeiXing={0} ", (int)chaXun.LeiXing.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.GysStructure.MXuanYongGysInfo();
                    info.ChengShiId = rdr.GetInt32(rdr.GetOrdinal("ChengShiId"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.Fax = rdr["Fax"].ToString();
                    info.GysId = rdr["GysId"].ToString();
                    info.GysName = rdr["GysName"].ToString();
                    info.LeiXing = (EyouSoft.Model.EnumType.CompanyStructure.SupplierType)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.LxrDianHua = rdr["LxrDianHua"].ToString();
                    info.LxrName = rdr["LxrName"].ToString();
                    info.LxrShouJi = rdr["LxrShouJi"].ToString();
                    info.ShengFenId = rdr.GetInt32(rdr.GetOrdinal("ShengFenId"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                    info.ZxsName = rdr["ZxsName"].ToString();
                    info.ShengFenName = rdr["ShengFenName"].ToString();
                    info.ChengShiName = rdr["ChengShiName"].ToString();
                    info.GysZhuTiId = rdr["GysZhuTiId"].ToString();

                    items.Add(info);
                }
            }
            return items;
        }

        /// <summary>
        /// 获取供应商主体导游信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo> GetZhuTiDaoYous(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MGysZhuTiDaoYouChaXunInfo chaXun)
        {
            var items = new List<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo>();
            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Gys_DaoYou";
            string orderByString = "DaoYouName ASC";
            string sumString = "";

            #region fields
            fields.Append("*");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.DaoYouName))
                {
                    query.AppendFormat(" AND DaoYouName LIKE '%{0}%' ", chaXun.DaoYouName);
                }
                if (!string.IsNullOrEmpty(chaXun.GysZhuTiId))
                {
                    query.AppendFormat(" AND GysId='{0}' ", chaXun.GysZhuTiId);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo();
                    info.DaoYouName = rdr["DaoYouName"].ToString();
                    items.Add(info);
                }
            }
            return items;
        }

        /// <summary>
        /// 获取供应商主体导游信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo> GetGysDaoYous(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MGysZhuTiDaoYouChaXunInfo chaXun)
        {
            var items = new List<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo>();
            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Gys_DaoYou_DiJieShe";
            string orderByString = "DaoYouName ASC";
            string sumString = "";

            #region fields
            fields.Append("*");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.DaoYouName))
                {
                    query.AppendFormat(" AND DaoYouName LIKE '%{0}%' ", chaXun.DaoYouName);
                }
                if (!string.IsNullOrEmpty(chaXun.GysId))
                {
                    query.AppendFormat(" AND GysId='{0}' ", chaXun.GysId);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo();
                    info.DaoYouName = rdr["DaoYouName"].ToString();
                    items.Add(info);
                }
            }
            return items;
        }

        /// <summary>
        /// 根据供应商编号获取供应商主体编号
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        public string GetGysZhuTiIdByGysId(int companyId, string gysId)
        {
            string _s = string.Empty;
            var cmd = _db.GetSqlStringCommand("SELECT A.GysId1 FROM tbl_Gys_ZhuTi_GuanXi AS A INNER JOIN tbl_Gys_ZhuTi AS B ON A.GysId1=B.GysId AND B.IsDelete='0' WHERE A.GysId2=@GysId2 ");
            _db.AddInParameter(cmd, "@GysId2", DbType.AnsiStringFixedLength, gysId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    _s = rdr["GysId1"].ToString();
                }
            }

            return _s;
        }
        #endregion
    }
}
