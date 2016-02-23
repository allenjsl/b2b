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
    /// 积分相关
    /// </summary>
    public class DJiFen : DALBase, EyouSoft.IDAL.PtStructure.IJiFen
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetShangPinInfo = "SELECT * FROM tbl_Pt_JiFenShangPin WHERE ShangPinId=@ShangPinId";
        const string SQL_SELECT_GetShangPinFuJians = "SELECT * FROM tbl_Pt_JiFenShangPinFuJian WHERE ShangPinId=@ShangPinId ORDER BY FuJianId ASC";
        const string SQL_SELECT_GetDingDanInfo = "SELECT * FROM view_Pt_JiFenDingDan WHERE DingDanId=@DingDanId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJiFen()
        {
            _db = SystemStore;
        }
        #endregion  
      
        #region private members
        /// <summary>
        /// create fujians xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateFuJiansXml(IList<EyouSoft.Model.PtStructure.MFuJianInfo> items)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<root>");
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    xml.AppendFormat("<info LeiXing=\"{0}\" Filepath=\"{1}\"><MiaoShu><![CDATA[{2}]]></MiaoShu></info>", item.LeiXing
                        , item.Filepath
                        , item.MiaoShu);
                }
            }
            xml.Append("</root>");
            return xml.ToString();
        }

        /// <summary>
        /// get shangpin fujians
        /// </summary>
        /// <param name="shangPinId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetShangPinFuJians(string shangPinId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetShangPinFuJians);
            _db.AddInParameter(cmd, "ShangPinId", DbType.AnsiStringFixedLength, shangPinId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MFuJianInfo();
                    item.Filepath = rdr["Filepath"].ToString();
                    item.FuJianId = rdr.GetInt32(rdr.GetOrdinal("FuJianId"));
                    item.MiaoShu = rdr["MiaoShu"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region IJiFen 成员
        /// <summary>
        /// 积分商品新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int ShangPin_CU(EyouSoft.Model.PtStructure.MJiFenShangPinInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_JiFenShangPin_CU");
            _db.AddInParameter(cmd, "@ShangPinId", DbType.AnsiStringFixedLength, info.ShangPinId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "@JiaGe", DbType.Decimal, info.JiaGe);
            _db.AddInParameter(cmd, "@JiFen", DbType.Int32, info.JiFen);
            _db.AddInParameter(cmd, "@LeiXing", DbType.Byte, info.LeiXing);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "@FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "@MiaoShu", DbType.String, info.MiaoShu);
            _db.AddInParameter(cmd, "@DuiHuanXuZhi", DbType.String, info.DuiHuanXuZhi);
            _db.AddInParameter(cmd, "@PeiSongShuoMing", DbType.String, info.PeiSongShuoMing);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@FuJianXml", DbType.String, CreateFuJiansXml(info.FuJians));
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
        /// 删除积分商品，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="shangPinId">商品编号</param>
        /// <returns></returns>
        public int DeleteShangPin(int companyId, string shangPinId)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_JiFenShangPin_D");
            _db.AddInParameter(cmd, "@ShangPinId", DbType.AnsiStringFixedLength, shangPinId);
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
        /// 获取积分商品信息
        /// </summary>
        /// <param name="shangPinId">商品编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJiFenShangPinInfo GetShangPinInfo(string shangPinId)
        {
            EyouSoft.Model.PtStructure.MJiFenShangPinInfo info = null;
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetShangPinInfo);
            _db.AddInParameter(cmd, "ShangPinId", DbType.AnsiStringFixedLength, shangPinId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MJiFenShangPinInfo();

                    info.BianMa = rdr["BianMa"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DuiHuanXuZhi = rdr["DuiHuanXuZhi"].ToString();
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JiaGe = rdr.GetDecimal(rdr.GetOrdinal("JiaGe"));
                    info.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.MiaoShu = rdr["MiaoShu"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PeiSongShuoMing = rdr["PeiSongShuoMing"].ToString();
                    info.ShangPinId = shangPinId;
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                }
            }

            if (info != null)
            {
                info.FuJians = GetShangPinFuJians(shangPinId);
            }

            return info;
        }

        /// <summary>
        /// 获取积分商品集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录灵敏</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJiFenShangPinInfo> GetShangPins(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenShangPinChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MJiFenShangPinInfo> items = new List<EyouSoft.Model.PtStructure.MJiFenShangPinInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_JiFenShangPin";
            string orderByString = " IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" CompanyId={0} AND IsDelete='0' ", companyId);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.BianMa))
                {
                    sql.AppendFormat(" AND BianMa='{0}' ", chaXun.BianMa);
                }
                if (chaXun.LeiXing.HasValue)
                {
                    sql.AppendFormat(" AND LeiXing={0} ", (int)chaXun.LeiXing.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.MingCheng))
                {
                    sql.AppendFormat(" AND MingCheng LIKE '%{0}%' ", chaXun.MingCheng);
                }
                if (chaXun.Status.HasValue)
                {
                    sql.AppendFormat(" AND Status={0} ", (int)chaXun.Status.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MJiFenShangPinInfo();

                    info = new EyouSoft.Model.PtStructure.MJiFenShangPinInfo();
                    info.BianMa = rdr["BianMa"].ToString();
                    info.CompanyId = companyId;
                    info.DuiHuanXuZhi = rdr["DuiHuanXuZhi"].ToString();
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JiaGe = rdr.GetDecimal(rdr.GetOrdinal("JiaGe"));
                    info.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.MiaoShu = rdr["MiaoShu"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PeiSongShuoMing = rdr["PeiSongShuoMing"].ToString();
                    info.ShangPinId = rdr["ShangPinId"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 积分订单新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int DingDan_CU(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_JiFenDingDan_CU");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@ShangPinId", DbType.AnsiStringFixedLength, info.ShangPinId);
            _db.AddInParameter(cmd, "@ShuLiang", DbType.Int32, info.ShuLiang);
            _db.AddInParameter(cmd, "@JiFen1", DbType.Int32, info.JiFen1);
            _db.AddInParameter(cmd, "@JiFen2", DbType.Int32, info.JiFen2);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "@LxrXingMing", DbType.String, info.LxrXingMing);
            _db.AddInParameter(cmd, "@LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "@LxrProvinceId", DbType.Int32, info.LxrProvinceId);
            _db.AddInParameter(cmd, "@LxrCityId", DbType.Int32, info.LxrCityId);
            _db.AddInParameter(cmd, "@LxrDiZhi", DbType.String, info.LxrDiZhi);
            _db.AddInParameter(cmd, "@LxrShouJi", DbType.String, info.LxrShouJi);
            _db.AddInParameter(cmd, "@LxrYouXiang", DbType.String, info.LxrYouXiang);
            _db.AddInParameter(cmd, "@XiaDanBeiZhu", DbType.String, info.XiaDanBeiZhu);
            _db.AddInParameter(cmd, "@LxrYouBian", DbType.String, info.LxrYouBian);
            _db.AddInParameter(cmd, "@XiaDanRenId", DbType.Int32, info.XiaDanRenId);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.LatestOperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.LatestTime);
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
        /// 获取积分订单信息
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJiFenDingDanInfo GetDingDanInfo(string dingDanId)
        {
            EyouSoft.Model.PtStructure.MJiFenDingDanInfo info = null;
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetDingDanInfo);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MJiFenDingDanInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DingDanId = dingDanId;
                    info.FuKuanBeiZhu = rdr["FuKuanBeiZhu"].ToString();
                    info.FuKuanDuiFangDanWei = rdr["FuKuanDuiFangDanWei"].ToString();
                    info.FuKuanFangShi = (EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("FuKuanFangShi"));
                    info.FuKuanJinE = rdr.GetDecimal(rdr.GetOrdinal("FuKuanJinE"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanOperatorId"))) info.FuKuanOperatorId = rdr.GetInt32(rdr.GetOrdinal("FuKuanOperatorId"));
                    info.FuKuanShenPiBeiZhu = rdr["FuKuanShenPiBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanShenPiRenId"))) info.FuKuanShenPiRenId = rdr.GetInt32(rdr.GetOrdinal("FuKuanShenPiRenId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanShenPiShiJian"))) info.FuKuanShenPiShiJian = rdr.GetDateTime(rdr.GetOrdinal("FuKuanShenPiShiJian"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanShiJian"))) info.FuKuanShiJian = rdr.GetDateTime(rdr.GetOrdinal("FuKuanShiJian"));
                    info.FuKuanStatus = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanTime"))) info.FuKuanTime = rdr.GetDateTime(rdr.GetOrdinal("FuKuanTime"));
                    info.FuKuanZhangHao = rdr["FuKuanZhangHao"].ToString();
                    info.FuKuanZhiFuBeiZhu = rdr["FuKuanZhiFuBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanZhiFuRenId"))) info.FuKuanZhiFuRenId = rdr.GetInt32(rdr.GetOrdinal("FuKuanZhiFuRenId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanZhiFuShiJian"))) info.FuKuanZhiFuShiJian = rdr.GetDateTime(rdr.GetOrdinal("FuKuanZhiFuShiJian"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    info.JiFen1 = rdr.GetInt32(rdr.GetOrdinal("JiFen1"));
                    info.JiFen2 = rdr.GetInt32(rdr.GetOrdinal("JiFen2"));
                    info.KuaiDi = rdr["KuaiDi"].ToString();
                    info.LatestOperatorId = rdr.GetInt32(rdr.GetOrdinal("LatestOperatorId"));
                    info.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    info.LxrCityId = rdr.GetInt32(rdr.GetOrdinal("LxrCityId"));
                    info.LxrDianHua = rdr["LxrDianHua"].ToString();
                    info.LxrDiZhi = rdr["LxrDiZhi"].ToString();
                    info.LxrProvinceId = rdr.GetInt32(rdr.GetOrdinal("LxrProvinceId"));
                    info.LxrXingMing = rdr["LxrXingMing"].ToString();
                    info.ShangPinId = rdr["ShangPinId"].ToString();
                    info.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.XiaDanBeiZhu = rdr["XiaDanBeiZhu"].ToString();
                    info.XiaDanRenId = rdr.GetInt32(rdr.GetOrdinal("XiaDanRenId"));

                    info.LxrShouJi = rdr["LxrShouJi"].ToString();
                    info.LxrYouXiang = rdr["LxrYouXiang"].ToString();
                    info.LxrYouBian = rdr["LxrYouBian"].ToString();

                    info.XiaDanRenKeHuName = rdr["XiaDanRenKeHuName"].ToString();
                    info.XiaDanRenXingMing = rdr["XiaDanRenXingMing"].ToString();
                    info.XiaDanRenYongHuMing = rdr["XiaDanRenYongHuMing"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取积分订单集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJiFenDingDanInfo> GetDingDans(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiFenDingDanChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MJiFenDingDanInfo> items = new List<EyouSoft.Model.PtStructure.MJiFenDingDanInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_Pt_JiFenDingDan";
            string orderByString = " IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.JiaoYiHao))
                {
                    sql.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", chaXun.JiaoYiHao);
                }
                if (!string.IsNullOrEmpty(chaXun.ShangPinBianMa))
                {
                    sql.AppendFormat(" AND ShangPinBianMa='{0}' ", chaXun.ShangPinBianMa);
                }
                if (chaXun.ShangPinLeiXing.HasValue)
                {
                    sql.AppendFormat(" AND ShangPinLeiXing={0} ", (int)chaXun.ShangPinLeiXing.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ShangPinMingCheng))
                {
                    sql.AppendFormat(" AND ShangPinMingCheng LIKE '%{0}%' ", chaXun.ShangPinMingCheng);
                }
                if (chaXun.Status.HasValue)
                {
                    sql.AppendFormat(" AND Status={0} ", (int)chaXun.Status.Value);
                }
                if (chaXun.XiaDanShiJian1.HasValue)
                {
                    sql.AppendFormat(" AND IssueTime>'{0}' ", chaXun.XiaDanShiJian1.Value.AddMinutes(-1));
                }
                if (chaXun.XiaDanShiJian2.HasValue)
                {
                    sql.AppendFormat(" AND IssueTime<'{0}' ", chaXun.XiaDanShiJian2.Value.AddDays(1).AddMinutes(-1));
                }
                if (chaXun.FuKuanStatus.HasValue)
                {
                    sql.AppendFormat(" AND FuKuanStatus={0} ", (int)chaXun.FuKuanStatus.Value);
                }
                if (chaXun.XiaDanRenId.HasValue)
                {
                    sql.AppendFormat(" AND XiaDanRenId={0} ", chaXun.XiaDanRenId.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MJiFenDingDanInfo();
                    info.CompanyId = companyId;
                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.FuKuanBeiZhu = rdr["FuKuanBeiZhu"].ToString();
                    info.FuKuanDuiFangDanWei = rdr["FuKuanDuiFangDanWei"].ToString();
                    info.FuKuanFangShi = (EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("FuKuanFangShi"));
                    info.FuKuanJinE = rdr.GetDecimal(rdr.GetOrdinal("FuKuanJinE"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanOperatorId"))) info.FuKuanOperatorId = rdr.GetInt32(rdr.GetOrdinal("FuKuanOperatorId"));
                    info.FuKuanShenPiBeiZhu = rdr["FuKuanShenPiBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanShenPiRenId"))) info.FuKuanShenPiRenId = rdr.GetInt32(rdr.GetOrdinal("FuKuanShenPiRenId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanShenPiShiJian"))) info.FuKuanShenPiShiJian = rdr.GetDateTime(rdr.GetOrdinal("FuKuanShenPiShiJian"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanShiJian"))) info.FuKuanShiJian = rdr.GetDateTime(rdr.GetOrdinal("FuKuanShiJian"));
                    info.FuKuanStatus = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanTime"))) info.FuKuanTime = rdr.GetDateTime(rdr.GetOrdinal("FuKuanTime"));
                    info.FuKuanZhangHao = rdr["FuKuanZhangHao"].ToString();
                    info.FuKuanZhiFuBeiZhu = rdr["FuKuanZhiFuBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanZhiFuRenId"))) info.FuKuanZhiFuRenId = rdr.GetInt32(rdr.GetOrdinal("FuKuanZhiFuRenId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("FuKuanZhiFuShiJian"))) info.FuKuanZhiFuShiJian = rdr.GetDateTime(rdr.GetOrdinal("FuKuanZhiFuShiJian"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    info.JiFen1 = rdr.GetInt32(rdr.GetOrdinal("JiFen1"));
                    info.JiFen2 = rdr.GetInt32(rdr.GetOrdinal("JiFen2"));
                    info.KuaiDi = rdr["KuaiDi"].ToString();
                    info.LatestOperatorId = rdr.GetInt32(rdr.GetOrdinal("LatestOperatorId"));
                    info.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    info.LxrCityId = rdr.GetInt32(rdr.GetOrdinal("LxrCityId"));
                    info.LxrDianHua = rdr["LxrDianHua"].ToString();
                    info.LxrDiZhi = rdr["LxrDiZhi"].ToString();
                    info.LxrProvinceId = rdr.GetInt32(rdr.GetOrdinal("LxrProvinceId"));
                    info.LxrXingMing = rdr["LxrXingMing"].ToString();
                    info.ShangPinId = rdr["ShangPinId"].ToString();
                    info.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.XiaDanBeiZhu = rdr["XiaDanBeiZhu"].ToString();
                    info.XiaDanRenId = rdr.GetInt32(rdr.GetOrdinal("XiaDanRenId"));

                    info.ShangPinMingCheng = rdr["ShangPinMingCheng"].ToString();
                    info.ShangPinBianMa = rdr["ShangPinBianMa"].ToString();
                    info.LxrShouJi = rdr["LxrShouJi"].ToString();
                    info.LxrYouXiang = rdr["LxrYouXiang"].ToString();
                    info.LxrYouBian = rdr["LxrYouBian"].ToString();

                    info.XiaDanRenKeHuName = rdr["XiaDanRenKeHuName"].ToString();
                    info.XiaDanRenXingMing = rdr["XiaDanRenXingMing"].ToString();
                    info.XiaDanRenYongHuMing = rdr["XiaDanRenYongHuMing"].ToString();

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_JiFenDingDan_SheZhiStatus");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "@KuaiDi", DbType.String, info.KuaiDi);
            _db.AddInParameter(cmd, "@FuKuanShiJian", DbType.DateTime, info.FuKuanShiJian);
            _db.AddInParameter(cmd, "@FuKuanJinE", DbType.Decimal, info.FuKuanJinE);
            _db.AddInParameter(cmd, "@FuKuanFangShi", DbType.Byte, info.FuKuanFangShi);
            _db.AddInParameter(cmd, "@FuKuanZhangHao", DbType.String, info.FuKuanZhangHao);
            _db.AddInParameter(cmd, "@FuKuanDuiFangDanWei", DbType.String, info.FuKuanDuiFangDanWei);
            _db.AddInParameter(cmd, "@FuKuanBeiZhu", DbType.String, info.FuKuanBeiZhu);
            _db.AddInParameter(cmd, "@FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.LatestOperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.LatestTime);
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
        /// 设置订单付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="fuKuanStatus">付款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int SheZhiDingDanFuKuanStatus(string dingDanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus fuKuanStatus, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_JiFenDingDan_SheZhiFuKuanStatus");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "@OperatorBeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "@FuKuanStatus", DbType.Byte, fuKuanStatus);
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
        /// 获取用户积分明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:积分合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MYongHuJiFenMingXiInfo> GetYongHuJiFenMingXis(int companyId, int yongHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MYongHuJiFenMingXiChaXunInfo chaXun,out object[] heJi)
        {
            heJi = new object[] { 0 };
            IList<EyouSoft.Model.PtStructure.MYongHuJiFenMingXiInfo> items = new List<EyouSoft.Model.PtStructure.MYongHuJiFenMingXiInfo>();

            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_YongHu_JiFenMingXi";
            string orderByString = " JiFenMingXiId DESC ";
            string sumString = "SUM(JiFen) AS JiFenHeJi";

            sql.AppendFormat(" CompanyId={0} ", companyId);
            sql.AppendFormat(" AND YongHuId={0} ", yongHuId);
            sql.AppendFormat(" AND Status<>{0} ", (int)EyouSoft.Model.EnumType.PtStructure.JiFenStatus.删除);

            if (chaXun != null)
            {
                if (chaXun.JiFenLeiXing.HasValue)
                {
                    sql.AppendFormat(" AND GuanLianLeiXing ={0} ", (int)chaXun.JiFenLeiXing.Value);
                }
                if (chaXun.JiFenShiJian1.HasValue)
                {
                    sql.AppendFormat(" AND JiFenShiJian>'{0}' ", chaXun.JiFenShiJian1.Value.AddMinutes(-1));
                }
                if (chaXun.JiFenShiJian2.HasValue)
                {
                    sql.AppendFormat(" AND JiFenShiJian<'{0}' ", chaXun.JiFenShiJian2.Value.AddDays(1).AddMinutes(-1));
                }
                if (chaXun.JiFenStatus.HasValue)
                {
                    sql.AppendFormat(" AND Status ={0} ", (int)chaXun.JiFenStatus.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MYongHuJiFenMingXiInfo();

                    item.GuanLianChanPinBianHao = rdr["ChanPinBianHao"].ToString();
                    item.GuanLianChanPinName = rdr["ChanPinName"].ToString();
                    item.GuanLianId = rdr["GuanLianId"].ToString();
                    item.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    item.JiFenLeiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing)rdr.GetByte(rdr.GetOrdinal("GuanLianLeiXing"));
                    item.JiFenShiJian = rdr.GetDateTime(rdr.GetOrdinal("JiFenShiJian"));
                    item.JiFenStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.YongHuId = yongHuId;
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YeWuLeiXing"))) item.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("YeWuLeiXing"));

                    item.FaFangZxsId = rdr["FaFangZxsId"].ToString();
                    item.FaFangZxsName = rdr["FaFangZxsName"].ToString();

                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JiFenHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("JiFenHeJi"));
                }

            }

            return items;
        }
        #endregion
    }
}
