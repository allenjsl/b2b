using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.PtStructure
{
    /// <summary>
    /// 专线商相关
    /// </summary>
    public class DZhuanXianShang : DALBase, EyouSoft.IDAL.PtStructure.IZhuanXianShang
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetInfo = "SELECT * FROM tbl_Pt_ZhuanXianShang WHERE ZxsId=@ZxsId";
        const string SQL_SELECT_GetZhanDians = "SELECT * FROM tbl_Pt_ZhuanXianShangZhanDian WHERE ZxsId=@ZxsId ORDER BY IdentityId ASC";
        const string SQL_SELECT_GetQQs = "SELECT * FROM tbl_Pt_ZhuanXianShangQQ WHERE ZxsId=@ZxsId ORDER BY IdentityId ASC";
        const string SQL_SELECT_GetJiFenJieSuans = "SELECT * FROM tbl_Pt_FinJiFenJieSuan WHERE ZxsId=@ZxsId ORDER BY IssueTime DESC";
        const string SQL_SELECT_GetJiFenJieSuanInfo = "SELECT * FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DZhuanXianShang()
        {
            _db = SystemStore;
        }
        #endregion  
      
        #region private members
        /// <summary>
        /// create zhandians xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateZhanDiansXml(IList<EyouSoft.Model.PtStructure.MZhuanXianShangZhanDianInfo> items)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<root>");
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    xml.AppendFormat("<info ZhanDianId=\"{0}\" ZxlbId=\"{1}\"></info>", item.ZhanDianId
                        , item.ZxlbId);
                }
            }
            xml.Append("</root>");
            return xml.ToString();
        }

        /// <summary>
        /// create qqs xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateQQsXml(IList<EyouSoft.Model.PtStructure.MZhuanXianShangQQInfo> items)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<root>");
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    xml.AppendFormat("<info><MiaoShu><![CDATA[{0}]]></MiaoShu><QQ><![CDATA[{1}]]></QQ></info>", item.MiaoShu
                        , item.QQ);
                }
            }
            xml.Append("</root>");
            return xml.ToString();
        }

        /// <summary>
        /// get zhandians
        /// </summary>
        /// <param name="zxsId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhuanXianShangZhanDianInfo> GetZhanDians(string zxsId)
        {
            IList<EyouSoft.Model.PtStructure.MZhuanXianShangZhanDianInfo> items = new List<EyouSoft.Model.PtStructure.MZhuanXianShangZhanDianInfo>();
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZhanDians);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MZhuanXianShangZhanDianInfo();

                    item.ZhanDianId = rdr.GetInt32(rdr.GetOrdinal("ZhanDianId"));
                    item.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// get qqs
        /// </summary>
        /// <param name="zxsId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhuanXianShangQQInfo> GetQQs(string zxsId)
        {
            IList<EyouSoft.Model.PtStructure.MZhuanXianShangQQInfo> items = new List<EyouSoft.Model.PtStructure.MZhuanXianShangQQInfo>();
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetQQs);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MZhuanXianShangQQInfo();

                    item.MiaoShu = rdr["MiaoShu"].ToString();
                    item.QQ = rdr["QQ"].ToString();
                    items.Add(item);
                }
            }
            return items;
        }

        /// <summary>
        /// get zxs guanliyuan info
        /// </summary>
        /// <param name="zxsId"></param>
        /// <returns></returns>
        object[] GetZxsGuanLiYuanInfo(string zxsId)
        {
            object[] info = new object[] { "" };
            var cmd = _db.GetSqlStringCommand("SELECT Username FROM tbl_CompanyUser WHERE ZxsId=@ZxsId AND IsAdmin='1' ");
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info[0] = rdr["Username"].ToString();
                }
            }

            return info;
        }
        #endregion

        #region IZhuanXianShang 成员
        /// <summary>
        /// 专线商新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int ZhuanXianShang_CU(EyouSoft.Model.PtStructure.MZhuanXianShangInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianShang_CU");
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "@ZhuCeHao", DbType.String, info.ZhuCeHao);
            _db.AddInParameter(cmd, "@ShuiWuHao", DbType.String, info.ShuiWuHao);
            _db.AddInParameter(cmd, "@XuKeZhengHao", DbType.String, info.XuKeZhengHao);
            _db.AddInParameter(cmd, "@FaRenName", DbType.String, info.FaRenName);
            _db.AddInParameter(cmd, "@LxrName", DbType.String, info.LxrName);
            _db.AddInParameter(cmd, "@LXrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "@LxrShouJi", DbType.String, info.LxrShouJi);
            _db.AddInParameter(cmd, "@LxrQQ", DbType.String, info.LxrQQ);
            _db.AddInParameter(cmd, "@Fax", DbType.String, info.Fax);
            _db.AddInParameter(cmd, "@ProvinceId", DbType.Int32, info.ProvinceId);
            _db.AddInParameter(cmd, "@CityId", DbType.Int32, info.CityId);
            _db.AddInParameter(cmd, "@DiZhi", DbType.String, info.DiZhi);
            _db.AddInParameter(cmd, "@Logo", DbType.String, info.Logo);            
            _db.AddInParameter(cmd, "@LianXiFangShi", DbType.String, info.LianXiFangShi);
            _db.AddInParameter(cmd, "@YinHangZhangHao", DbType.String, info.YinHangZhangHao);
            _db.AddInParameter(cmd, "@JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "@JiFenStatus", DbType.Byte, info.JiFenStatus);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@ZhanDianXml", DbType.String, CreateZhanDiansXml(info.ZhanDians));
            _db.AddInParameter(cmd, "@QQXml", DbType.String, CreateQQsXml(info.QQs));
            _db.AddInParameter(cmd, "@Username", DbType.String, info.GuanLiYuanUsername);

            if (info.GuanLiYuanPassword != null)
            {
                _db.AddInParameter(cmd, "@NoEncryptPassword", DbType.String, info.GuanLiYuanPassword.NoEncryptPassword);
                _db.AddInParameter(cmd, "@MD5Password", DbType.String, info.GuanLiYuanPassword.MD5Password);
            }
            else
            {
                _db.AddInParameter(cmd, "@NoEncryptPassword", DbType.String, DBNull.Value);
                _db.AddInParameter(cmd, "@MD5Password", DbType.String, DBNull.Value);
            }
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "@PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "@T2", DbType.Byte, info.T2);

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
        /// 专线商删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string zxsId)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianShang_D");
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, 0);
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
        /// 获取专线商信息
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZhuanXianShangInfo GetInfo(string zxsId)
        {
            EyouSoft.Model.PtStructure.MZhuanXianShangInfo info = null;
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MZhuanXianShangInfo();
                    info.CityId = rdr.GetInt32(rdr.GetOrdinal("CityId"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DiZhi = rdr["DiZhi"].ToString();
                    info.FaRenName = rdr["FaRenName"].ToString();
                    info.Fax = rdr["Fax"].ToString();
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.JiFenStatus = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus)rdr.GetByte(rdr.GetOrdinal("JiFenStatus"));
                    info.LianXiFangShi = rdr["LianXiFangShi"].ToString();
                    info.Logo = rdr["Logo"].ToString();
                    info.LxrDianHua = rdr["LxrDianHua"].ToString();
                    info.LxrName = rdr["LxrName"].ToString();
                    info.LxrQQ = rdr["LxrQQ"].ToString();
                    info.LxrShouJi = rdr["LxrShouJi"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.Privs1 = rdr["Privs1"].ToString();
                    info.Privs2 = rdr["Privs2"].ToString();
                    info.Privs3 = rdr["Privs3"].ToString();
                    info.ProvinceId = rdr.GetInt32(rdr.GetOrdinal("ProvinceId"));
                    info.QQs = null;
                    info.ShuiWuHao = rdr["ShuiWuHao"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.T1 = (EyouSoft.Model.EnumType.PtStructure.ZxsT1)rdr.GetByte(rdr.GetOrdinal("T1"));
                    info.XuKeZhengHao = rdr["XuKeZhengHao"].ToString();
                    info.YinHangZhangHao = rdr["YinHangZhangHao"].ToString();
                    info.ZhanDians = null;
                    info.ZhuCeHao = rdr["ZhuCeHao"].ToString();
                    info.ZxsId = zxsId;
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.T2 = (EyouSoft.Model.EnumType.PtStructure.ZxsT2)rdr.GetByte(rdr.GetOrdinal("T2"));
                }
            }

            if (info != null)
            {
                info.QQs = GetQQs(zxsId);
                info.ZhanDians = GetZhanDians(zxsId);

                var guanLiYuanInfo = GetZxsGuanLiYuanInfo(zxsId);
                if (guanLiYuanInfo != null)
                {
                    info.GuanLiYuanUsername = guanLiYuanInfo[0].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取专线商集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZhuanXianShangInfo> GetZxss(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MZhuanXianShangInfo> items = new List<EyouSoft.Model.PtStructure.MZhuanXianShangInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_ZhuanXianShang";
            string orderByString = " PaiXuId ASC,IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" CompanyId={0} AND IsDelete='0' ", companyId);

            if (chaXun != null)
            {
                if (chaXun.ZhanDianId.HasValue||chaXun.ZxlbId.HasValue)
                {
                    sql.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianShangZhanDian AS A1 WHERE A1.ZxsId=tbl_Pt_ZhuanXianShang.ZxsId ");
                    if (chaXun.ZhanDianId.HasValue)
                    {
                        sql.AppendFormat(" AND A1.ZhanDianId={0} ", chaXun.ZhanDianId.Value);
                    }
                    if (chaXun.ZxlbId.HasValue)
                    {
                        sql.AppendFormat(" AND ZxlbId={0} ", chaXun.ZxlbId.Value);
                    }
                    if (!string.IsNullOrEmpty(chaXun.MingCheng))
                    {
                        sql.AppendFormat(" AND MingCheng like '%{0}%'", chaXun.MingCheng);
                    }
                    sql.AppendFormat(" ) ");
                }
                if (chaXun.ZxsStatus.HasValue)
                {
                    sql.AppendFormat(" AND Status={0} ", (int)chaXun.ZxsStatus.Value);
                }
                if (chaXun.T2.HasValue)
                {
                    sql.AppendFormat(" AND T2={0} ", (int)chaXun.T2.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MZhuanXianShangInfo();
                    info.CityId = rdr.GetInt32(rdr.GetOrdinal("CityId"));
                    info.CompanyId = companyId;
                    info.DiZhi = rdr["DiZhi"].ToString();
                    info.FaRenName = rdr["FaRenName"].ToString();
                    info.Fax = rdr["Fax"].ToString();
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.JiFenStatus = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus)rdr.GetByte(rdr.GetOrdinal("JiFenStatus"));
                    info.LianXiFangShi = rdr["LianXiFangShi"].ToString();
                    info.Logo = rdr["Logo"].ToString();
                    info.LxrDianHua = rdr["LxrDianHua"].ToString();
                    info.LxrName = rdr["LxrName"].ToString();
                    info.LxrQQ = rdr["LxrQQ"].ToString();
                    info.LxrShouJi = rdr["LxrShouJi"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.Privs1 = rdr["Privs1"].ToString();
                    info.Privs2 = rdr["Privs2"].ToString();
                    info.Privs3 = rdr["Privs3"].ToString();
                    info.ProvinceId = rdr.GetInt32(rdr.GetOrdinal("ProvinceId"));
                    info.QQs = null;
                    info.ShuiWuHao = rdr["ShuiWuHao"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.T1 = (EyouSoft.Model.EnumType.PtStructure.ZxsT1)rdr.GetByte(rdr.GetOrdinal("T1"));
                    info.XuKeZhengHao = rdr["XuKeZhengHao"].ToString();
                    info.YinHangZhangHao = rdr["YinHangZhangHao"].ToString();
                    info.ZhanDians = null;
                    info.ZhuCeHao = rdr["ZhuCeHao"].ToString();
                    info.ZxsId = rdr["ZxsId"].ToString();
                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置专线商状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(int companyId, string zxsId, EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus status)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianShang_SheZhiStatus");
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, status);
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
        /// 设置专线商积分发放状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="status">积分发放状态</param>
        /// <returns></returns>
        public int SheZhiJiFenStatus(int companyId, string zxsId, EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus status)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianShang_SheZhiJiFenStatus");
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@JiFenStatus", DbType.Byte, status);
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
        /// 专线商授权
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="privs1">privs1</param>
        /// <param name="privs2">privs2</param>
        /// <param name="privs3">privs3</param>
        /// <returns></returns>
        public int SheZhiPrivs(int companyId, string zxsId, string privs1, string privs2, string privs3)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianShang_SheZhiPrivs");
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@Privs1", DbType.String, privs1);
            _db.AddInParameter(cmd, "@Privs2", DbType.String, privs2);
            _db.AddInParameter(cmd, "@Privs3", DbType.String, privs3);
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
        /// 专线商积分结算新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int JiFenJieSuan_CU(EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianShang_JiFenJieSuan_CU");
            _db.AddInParameter(cmd, "@JieSuanId", DbType.AnsiStringFixedLength, info.JieSuanId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@JieSuanRiQi", DbType.DateTime, info.JieSuanRiQi);
            _db.AddInParameter(cmd, "@JieSuanRenName", DbType.String, info.JieSuanRenName);
            _db.AddInParameter(cmd, "@JiFen", DbType.Int32, info.JiFen);
            _db.AddInParameter(cmd, "@JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "@JieSuanFangShi", DbType.Byte, info.JieSuanFangShi);
            _db.AddInParameter(cmd, "@JieSuanZhangHao", DbType.String, info.JieSuanZhangHao);
            _db.AddInParameter(cmd, "@JieSuanBeiZhu", DbType.String, info.JieSuanBeiZhu);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
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
        /// 删除专线商积分结算信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <returns></returns>
        public int DeleteJiFenJieSuan(int companyId, string jiFenJieSuanId)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianShang_JiFenJieSuan_D");
            _db.AddInParameter(cmd, "@JieSuanId", DbType.AnsiStringFixedLength, jiFenJieSuanId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, string.Empty);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, 0);
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
        /// 获取专线商积分结算信息
        /// </summary>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo GetJiFenJieSuanInfo(string jiFenJieSuanId)
        {
            EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo info = null;
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJiFenJieSuanInfo);
            _db.AddInParameter(cmd, "JieSuanId", DbType.AnsiStringFixedLength, jiFenJieSuanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieSuanBeiZhu = rdr["JieSuanBeiZhu"].ToString();
                    info.JieSuanFangShi = (EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("JieSuanFangShi"));
                    info.JieSuanId = jiFenJieSuanId;
                    info.JieSuanRenName = rdr["JieSuanRenName"].ToString();
                    info.JieSuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("JieSuanRiQi"));
                    info.JieSuanZhangHao = rdr["JieSuanZhangHao"].ToString();
                    info.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ShenPiBeiZhu = rdr["ShenPiBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenPiRenId"))) info.ShenPiRenId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenPiShiJian"))) info.ShenPiShiJian = rdr.GetDateTime(rdr.GetOrdinal("ShenPiShiJian"));
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取专线商积分结算集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo> GetJiFenJieSuans(int companyId, string zxsId)
        {
            IList<EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo> items = new List<EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo>();
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJiFenJieSuans);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo();

                    info.CompanyId = companyId;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieSuanBeiZhu = rdr["JieSuanBeiZhu"].ToString();
                    info.JieSuanFangShi = (EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("JieSuanFangShi"));
                    info.JieSuanId = rdr["JieSuanId"].ToString();
                    info.JieSuanRenName = rdr["JieSuanRenName"].ToString();
                    info.JieSuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("JieSuanRiQi"));
                    info.JieSuanZhangHao = rdr["JieSuanZhangHao"].ToString();
                    info.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ShenPiBeiZhu = rdr["ShenPiBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenPiRenId"))) info.ShenPiRenId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenPiShiJian"))) info.ShenPiShiJian = rdr.GetDateTime(rdr.GetOrdinal("ShenPiShiJian"));
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.ZxsId = zxsId;
                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置专线商积分结算状态，返回1成功，其它失败
        /// </summary>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <param name="shouKuanStatus">收款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int SheZhiJiFenJieSuanStatus(string jiFenJieSuanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus shouKuanStatus, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus");
            _db.AddInParameter(cmd, "@JieSuanId", DbType.AnsiStringFixedLength, jiFenJieSuanId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, string.Empty);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, 0);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, shouKuanStatus);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.OperatorTime);
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
        /// 获取专线商(简)信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZxsInfo> GetZxss1(int companyId, EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MZxsInfo> items = new List<EyouSoft.Model.PtStructure.MZxsInfo>();
            #region sql
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT A.ZxsId,A.MingCheng FROM tbl_Pt_ZhuanXianShang AS A ");
            sql.Append(" WHERE A.CompanyId=@CompanyId AND IsDelete='0' AND A.Status=@Status ");

            if (chaXun != null)
            {
                if (chaXun.ZhanDianId.HasValue || chaXun.ZxlbId.HasValue)
                {
                    sql.Append(" AND EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianShangZhanDian AS B WHERE B.ZxsId=A.ZxsId ");

                    if (chaXun.ZhanDianId.HasValue)
                    {
                        sql.AppendFormat(" AND B.ZhanDianId={0} ", chaXun.ZhanDianId.Value);
                    }

                    if (chaXun.ZxlbId.HasValue)
                    {
                        sql.AppendFormat(" AND B.ZxlbId={0} ", chaXun.ZxlbId.Value);
                    }

                    sql.Append(" ) ");
                }
            }

            sql.Append(" ORDER BY A.PaiXuId ASC ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus.启用);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MZxsInfo();
                    item.ZxsId = rdr["ZxsId"].ToString();
                    item.MingCheng = rdr["MingCheng"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取专线商积分发放状态
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus GetZxsJiFenStatus(string zxsId)
        {
            var status = EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用;
            string sql = "SELECT JiFenStatus FROM tbl_Pt_ZhuanXianShang WHERE ZxsId=@ZxsId";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd,_db))
            {
                if (rdr.Read())
                {
                    status = (EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus)rdr.GetByte(0);
                }
            }

            return status;
        }

        /// <summary>
        /// 获取AJAX自动完成专线商信息信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户单位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo> GetAutocompleteZxss(int companyId, string keHuId, EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo> items = new List<EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo>();

            int topExpression = 10;

            #region sql
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TOP(@TopExpression) ZxsId,MingCheng FROM tbl_Pt_ZhuanXianShang AS A ");
            sql.Append(" WHERE A.CompanyId=@CompanyId AND A.IsDelete='0' ");
            sql.Append(" AND EXISTS(SELECT 1 FROM tbl_TourOrder AS A1 WHERE A1.ZxsId=A.ZxsId AND A1.IsDelete='0' AND A1.CompanyId=@CompanyId AND A1.BuyCompanyId=@KeHuId) ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ZxsName))
                {
                    sql.AppendFormat(" AND MingCheng LIKE '%{0}%'  ", chaXun.ZxsName);
                }

                if (chaXun.TopExpression > 0) topExpression = chaXun.TopExpression;
            }
            sql.Append(" ORDER BY A.PaiXuId ASC ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "TopExpression", DbType.Int32, topExpression);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, keHuId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo();
                    item.ZxsId = rdr["ZxsId"].ToString();
                    item.ZxsName = rdr["MingCheng"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }
        #endregion
    }
}
