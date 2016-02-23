//财务管理-资产负债表相关数据访问类 汪奇志 2013-02-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Toolkit.DAL;
using EyouSoft.IDAL.FinStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 财务管理-资产负债表相关数据访问类
    /// </summary>
    public class DZiChanFuZhai : DALBase, IZiChanFuZhai
    {
        #region static constants
        //static constants
        const string SQL_SELECT_IsExists = "SELECT COUNT(*) FROM [tbl_FinZiChanFuZhai] WHERE [CompanyId]=@CompanyId AND [Year]=@Year AND [Month]=@Month AND ZxsId=@ZxsId";
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_FinZiChanFuZhai]([Id],[CompanyId],[Year],[Month],[HuoBiZiJin],[YingShouZhangKuan],[QiTaYingShouKuan],[YuFuZhangKuan],[QiTaYuFu],[YingFuZhangKuan],[QiTaYingFuKuan],[YuShouZhangKuan],[QiTaYuShou],[ShiShouGuBen],[WeiFenPeiLiRun],[ChaE],[BeiZhu],[OperatorId],[IssueTime],[YMD],[YingShouTuanKuan],[YingShouYaJinTuiKuan],[YingShouJiuDianTuiKuan],[YingShouTuiPiaoKuan],[YingShouQiTa],[ZhiLiangBaoZhengJin],[GeRenJieKuan],[GongYingShangYaJin],[JiuDianYaJin],[ZuTuanSheYaJin],[QTYSQiTa],[YuFuDiJieKuan],[YuFuJiPiaoKuan],[YuFuJiaoTongYaJinKuan],[YuFuJiuDianKuan],[YingFuDiJieKuan],[YingFuJiPiaoKuan],[YingFuJiuDianKuan],[YuShouTuanKuan],[YuShouTuiPiaoKuan],[ZanShiJieKuan],[LeiJiWeiFenPeiLiRun],[BenYueWeiFenPeiLiRun],[YingShouZhangKuanBeiZhu],[QiTaYingShouKuanBeiZhu],[YuFuZhangKuanBeiZhu],[YingFuZhangKuanBeiZhu],[YuShouZhangKuanBeiZhu],[ShiShouGuBenBeiZhu],[ZxsId]) VALUES (@Id,@CompanyId,@Year,@Month,@HuoBiZiJin,@YingShouZhangKuan,@QiTaYingShouKuan,@YuFuZhangKuan,@QiTaYuFu,@YingFuZhangKuan,@QiTaYingFuKuan,@YuShouZhangKuan,@QiTaYuShou,@ShiShouGuBen,@WeiFenPeiLiRun,@ChaE,@BeiZhu,@OperatorId,@IssueTime,@YMD,@YingShouTuanKuan,@YingShouYaJinTuiKuan,@YingShouJiuDianTuiKuan,@YingShouTuiPiaoKuan,@YingShouQiTa,@ZhiLiangBaoZhengJin,@GeRenJieKuan,@GongYingShangYaJin,@JiuDianYaJin,@ZuTuanSheYaJin,@QTYSQiTa,@YuFuDiJieKuan,@YuFuJiPiaoKuan,@YuFuJiaoTongYaJinKuan,@YuFuJiuDianKuan,@YingFuDiJieKuan,@YingFuJiPiaoKuan,@YingFuJiuDianKuan,@YuShouTuanKuan,@YuShouTuiPiaoKuan,@ZanShiJieKuan,@LeiJiWeiFenPeiLiRun,@BenYueWeiFenPeiLiRun,@YingShouZhangKuanBeiZhu,@QiTaYingShouKuanBeiZhu,@YuFuZhangKuanBeiZhu,@YingFuZhangKuanBeiZhu,@YuShouZhangKuanBeiZhu,@ShiShouGuBenBeiZhu,@ZxsId)";
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_FinZiChanFuZhai] WHERE [Id]=@Id";
        const string SQL_UPDATE_Update = "UPDATE [tbl_FinZiChanFuZhai] SET [Year] = @Year,[Month] = @Month,[HuoBiZiJin] = @HuoBiZiJin,[YingShouZhangKuan] = @YingShouZhangKuan,[QiTaYingShouKuan] = @QiTaYingShouKuan,[YuFuZhangKuan] = @YuFuZhangKuan,[QiTaYuFu] = @QiTaYuFu,[YingFuZhangKuan] = @YingFuZhangKuan,[QiTaYingFuKuan] = @QiTaYingFuKuan,[YuShouZhangKuan] = @YuShouZhangKuan,[QiTaYuShou] = @QiTaYuShou,[ShiShouGuBen] = @ShiShouGuBen,[WeiFenPeiLiRun] = @WeiFenPeiLiRun,[ChaE] = @ChaE,[BeiZhu] = @BeiZhu,[YMD]=@YMD,[YingShouTuanKuan] = @YingShouTuanKuan,[YingShouYaJinTuiKuan] = @YingShouYaJinTuiKuan,[YingShouJiuDianTuiKuan] = @YingShouJiuDianTuiKuan,[YingShouTuiPiaoKuan] = @YingShouTuiPiaoKuan,[YingShouQiTa] = @YingShouQiTa,[ZhiLiangBaoZhengJin] = @ZhiLiangBaoZhengJin,[GeRenJieKuan] = @GeRenJieKuan,[GongYingShangYaJin] = @GongYingShangYaJin,[JiuDianYaJin] = @JiuDianYaJin,[ZuTuanSheYaJin] = @ZuTuanSheYaJin,[QTYSQiTa] = @QTYSQiTa,[YuFuDiJieKuan] = @YuFuDiJieKuan,[YuFuJiPiaoKuan] = @YuFuJiPiaoKuan,[YuFuJiaoTongYaJinKuan] = @YuFuJiaoTongYaJinKuan,[YuFuJiuDianKuan] = @YuFuJiuDianKuan,[YingFuDiJieKuan] = @YingFuDiJieKuan,[YingFuJiPiaoKuan] = @YingFuJiPiaoKuan,[YingFuJiuDianKuan] = @YingFuJiuDianKuan,[YuShouTuanKuan] = @YuShouTuanKuan,[YuShouTuiPiaoKuan] = @YuShouTuiPiaoKuan,[ZanShiJieKuan] = @ZanShiJieKuan,[LeiJiWeiFenPeiLiRun] = @LeiJiWeiFenPeiLiRun,[BenYueWeiFenPeiLiRun] = @BenYueWeiFenPeiLiRun,[YingShouZhangKuanBeiZhu] = @YingShouZhangKuanBeiZhu,[QiTaYingShouKuanBeiZhu] = @QiTaYingShouKuanBeiZhu,[YuFuZhangKuanBeiZhu] = @YuFuZhangKuanBeiZhu,[YingFuZhangKuanBeiZhu] = @YingFuZhangKuanBeiZhu,[YuShouZhangKuanBeiZhu] = @YuShouZhangKuanBeiZhu,[ShiShouGuBenBeiZhu] = @ShiShouGuBenBeiZhu WHERE [Id]=@Id";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_FinZiChanFuZhai] WHERE [Id]=@Id AND [CompanyId]=@CompanyId";
        const string SQL_SELECT_GetZiChanFuZhaiHistorys = "SELECT * FROM [tbl_FinZiChanFuZhaiHistory] WHERE [ZiChanFuZhaiId]=@ZiChanFuZhaiId AND [IsDelete]='0' ORDER BY [IdentityId] ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DZiChanFuZhai()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 获取资产负债表修改记录信息集合
        /// </summary>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <returns></returns>
        IList<MZiChanFuZhaiHistoryInfo> GetZiChanFuZhaiHistorys(string ziChanFuZhaiId)
        {
            IList<MZiChanFuZhaiHistoryInfo> items = new List<MZiChanFuZhaiHistoryInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZiChanFuZhaiHistorys);
            _db.AddInParameter(cmd, "ZiChanFuZhaiId", DbType.AnsiStringFixedLength, ziChanFuZhaiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MZiChanFuZhaiHistoryInfo();

                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.NeiRong = rdr["NeiRong"].ToString();
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.Time = rdr.GetDateTime(rdr.GetOrdinal("Time"));
                    item.XiangMu = rdr["XiangMu"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region IZiChanFuZhai 成员
        /// <summary>
        /// 是否存在相同的资产负债年月份信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public bool IsExists(int companyId, int year, int month, string ziChanFuZhaiId,string zxsId)
        {
            string sql = SQL_SELECT_IsExists;
            if (!string.IsNullOrEmpty(ziChanFuZhaiId)) sql += " AND [Id]<>@Id ";

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "Year", DbType.Int32, year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, month);
            if (!string.IsNullOrEmpty(ziChanFuZhaiId)) _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, ziChanFuZhaiId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetInt32(0) == 1;
                }
            }

            return false;
        }

        /// <summary>
        /// 写入资产负债表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MZiChanFuZhaiInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.Id);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "Year", DbType.Int32, info.Year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, info.Month);
            _db.AddInParameter(cmd, "HuoBiZiJin", DbType.Decimal, info.HuoBiZiJin);
            _db.AddInParameter(cmd, "YingShouZhangKuan", DbType.Decimal, info.YingShouZhangKuan);
            _db.AddInParameter(cmd, "QiTaYingShouKuan", DbType.Decimal, info.QiTaYingShouKuan);
            _db.AddInParameter(cmd, "YuFuZhangKuan", DbType.Decimal, info.YuFuZhangKuan);
            _db.AddInParameter(cmd, "QiTaYuFu", DbType.Decimal, info.QiTaYuFu);
            _db.AddInParameter(cmd, "YingFuZhangKuan", DbType.Decimal, info.YingFuZhangKuan);
            _db.AddInParameter(cmd, "QiTaYingFuKuan", DbType.Decimal, info.QiTaYingFuKuan);
            _db.AddInParameter(cmd, "YuShouZhangKuan", DbType.Decimal, info.YuShouZhangKuan);
            _db.AddInParameter(cmd, "QiTaYuShou", DbType.Decimal, info.QiTaYuShou);
            _db.AddInParameter(cmd, "ShiShouGuBen", DbType.Decimal, info.ShiShouGuBen);
            _db.AddInParameter(cmd, "WeiFenPeiLiRun", DbType.Decimal, info.WeiFenPeiLiRun);
            _db.AddInParameter(cmd, "ChaE", DbType.Decimal, info.ChaE);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "YMD", DbType.DateTime, new DateTime(info.Year, info.Month, 1));
            _db.AddInParameter(cmd, "YingShouTuanKuan", DbType.Decimal, info.YingShouTuanKuan);
            _db.AddInParameter(cmd, "YingShouYaJinTuiKuan", DbType.Decimal, info.YingShouYaJinTuiKuan);
            _db.AddInParameter(cmd, "YingShouJiuDianTuiKuan", DbType.Decimal, info.YingShouJiuDianTuiKuan);
            _db.AddInParameter(cmd, "YingShouTuiPiaoKuan", DbType.Decimal, info.YingShouTuiPiaoKuan);
            _db.AddInParameter(cmd, "YingShouQiTa", DbType.Decimal, info.YingShouQiTa);
            _db.AddInParameter(cmd, "ZhiLiangBaoZhengJin", DbType.Decimal, info.ZhiLiangBaoZhengJin);
            _db.AddInParameter(cmd, "GeRenJieKuan", DbType.Decimal, info.GeRenJieKuan);
            _db.AddInParameter(cmd, "GongYingShangYaJin", DbType.Decimal, info.GongYingShangYaJin);
            _db.AddInParameter(cmd, "JiuDianYaJin", DbType.Decimal, info.JiuDianYaJin);
            _db.AddInParameter(cmd, "ZuTuanSheYaJin", DbType.Decimal, info.ZuTuanSheYaJin);
            _db.AddInParameter(cmd, "QTYSQiTa", DbType.Decimal, info.QTYSQiTa);
            _db.AddInParameter(cmd, "YuFuDiJieKuan", DbType.Decimal, info.YuFuDiJieKuan);
            _db.AddInParameter(cmd, "YuFuJiPiaoKuan", DbType.Decimal, info.YuFuJiPiaoKuan);
            _db.AddInParameter(cmd, "YuFuJiaoTongYaJinKuan", DbType.Decimal, info.YuFuJiaoTongYaJinKuan);
            _db.AddInParameter(cmd, "YuFuJiuDianKuan", DbType.Decimal, info.YuFuJiuDianKuan);
            _db.AddInParameter(cmd, "YingFuDiJieKuan", DbType.Decimal, info.YingFuDiJieKuan);
            _db.AddInParameter(cmd, "YingFuJiPiaoKuan", DbType.Decimal, info.YingFuJiPiaoKuan);
            _db.AddInParameter(cmd, "YingFuJiuDianKuan", DbType.Decimal, info.YingFuJiuDianKuan);
            _db.AddInParameter(cmd, "YuShouTuanKuan", DbType.Decimal, info.YuShouTuanKuan);
            _db.AddInParameter(cmd, "YuShouTuiPiaoKuan", DbType.Decimal, info.YuShouTuiPiaoKuan);
            _db.AddInParameter(cmd, "ZanShiJieKuan", DbType.Decimal, info.ZanShiJieKuan);
            _db.AddInParameter(cmd, "LeiJiWeiFenPeiLiRun", DbType.Decimal, info.LeiJiWeiFenPeiLiRun);
            _db.AddInParameter(cmd, "BenYueWeiFenPeiLiRun", DbType.Decimal, info.BenYueWeiFenPeiLiRun);
            _db.AddInParameter(cmd, "YingShouZhangKuanBeiZhu", DbType.String, info.YingShouZhangKuanBeiZhu);
            _db.AddInParameter(cmd, "QiTaYingShouKuanBeiZhu", DbType.String, info.QiTaYingShouKuanBeiZhu);
            _db.AddInParameter(cmd, "YuFuZhangKuanBeiZhu", DbType.String, info.YuFuZhangKuanBeiZhu);
            _db.AddInParameter(cmd, "YingFuZhangKuanBeiZhu", DbType.String, info.YingFuZhangKuanBeiZhu);
            _db.AddInParameter(cmd, "YuShouZhangKuanBeiZhu", DbType.String, info.YuShouZhangKuanBeiZhu);
            _db.AddInParameter(cmd, "ShiShouGuBenBeiZhu", DbType.String, info.ShiShouGuBenBeiZhu);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取资产负债表信息
        /// </summary>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <returns></returns>
        public MZiChanFuZhaiInfo GetInfo(string ziChanFuZhaiId)
        {
            MZiChanFuZhaiInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, ziChanFuZhaiId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MZiChanFuZhaiInfo();

                    info.BeiZhu = rdr["BeiZhu"].ToString();
                    info.ChaE = rdr.GetDecimal(rdr.GetOrdinal("ChaE"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.HuoBiZiJin = rdr.GetDecimal(rdr.GetOrdinal("HuoBiZiJin"));
                    info.Id = rdr.GetString(rdr.GetOrdinal("Id"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.Month = rdr.GetInt32(rdr.GetOrdinal("Month"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.QiTaYingFuKuan = rdr.GetDecimal(rdr.GetOrdinal("QiTaYingFuKuan"));
                    info.QiTaYingShouKuan = rdr.GetDecimal(rdr.GetOrdinal("QiTaYingShouKuan"));
                    info.QiTaYuFu = rdr.GetDecimal(rdr.GetOrdinal("QiTaYuFu"));
                    info.QiTaYuShou = rdr.GetDecimal(rdr.GetOrdinal("QiTaYuShou"));
                    info.ShiShouGuBen = rdr.GetDecimal(rdr.GetOrdinal("ShiShouGuBen"));
                    info.WeiFenPeiLiRun = rdr.GetDecimal(rdr.GetOrdinal("WeiFenPeiLiRun"));
                    info.Year = rdr.GetInt32(rdr.GetOrdinal("Year"));
                    info.YingFuZhangKuan = rdr.GetDecimal(rdr.GetOrdinal("YingFuZhangKuan"));
                    info.YingShouZhangKuan = rdr.GetDecimal(rdr.GetOrdinal("YingShouZhangKuan"));
                    info.YuFuZhangKuan = rdr.GetDecimal(rdr.GetOrdinal("YuFuZhangKuan"));
                    info.YuShouZhangKuan = rdr.GetDecimal(rdr.GetOrdinal("YuShouZhangKuan"));
                    info.YMD = rdr.GetDateTime(rdr.GetOrdinal("YMD"));

                    info.YingShouTuanKuan = rdr.GetDecimal(rdr.GetOrdinal("YingShouTuanKuan"));
                    info.YingShouYaJinTuiKuan = rdr.GetDecimal(rdr.GetOrdinal("YingShouYaJinTuiKuan"));
                    info.YingShouJiuDianTuiKuan = rdr.GetDecimal(rdr.GetOrdinal("YingShouJiuDianTuiKuan"));
                    info.YingShouTuiPiaoKuan = rdr.GetDecimal(rdr.GetOrdinal("YingShouTuiPiaoKuan"));
                    info.YingShouQiTa = rdr.GetDecimal(rdr.GetOrdinal("YingShouQiTa"));
                    info.ZhiLiangBaoZhengJin = rdr.GetDecimal(rdr.GetOrdinal("ZhiLiangBaoZhengJin"));
                    info.GeRenJieKuan = rdr.GetDecimal(rdr.GetOrdinal("GeRenJieKuan"));
                    info.GongYingShangYaJin = rdr.GetDecimal(rdr.GetOrdinal("GongYingShangYaJin"));
                    info.JiuDianYaJin = rdr.GetDecimal(rdr.GetOrdinal("JiuDianYaJin"));
                    info.ZuTuanSheYaJin = rdr.GetDecimal(rdr.GetOrdinal("ZuTuanSheYaJin"));
                    info.QTYSQiTa = rdr.GetDecimal(rdr.GetOrdinal("QTYSQiTa"));
                    info.YuFuDiJieKuan = rdr.GetDecimal(rdr.GetOrdinal("YuFuDiJieKuan"));
                    info.YuFuJiPiaoKuan = rdr.GetDecimal(rdr.GetOrdinal("YuFuJiPiaoKuan"));
                    info.YuFuJiaoTongYaJinKuan = rdr.GetDecimal(rdr.GetOrdinal("YuFuJiaoTongYaJinKuan"));
                    info.YuFuJiuDianKuan = rdr.GetDecimal(rdr.GetOrdinal("YuFuJiuDianKuan"));
                    info.YingFuDiJieKuan = rdr.GetDecimal(rdr.GetOrdinal("YingFuDiJieKuan"));
                    info.YingFuJiPiaoKuan = rdr.GetDecimal(rdr.GetOrdinal("YingFuJiPiaoKuan"));
                    info.YingFuJiuDianKuan = rdr.GetDecimal(rdr.GetOrdinal("YingFuJiuDianKuan"));
                    info.YuShouTuanKuan = rdr.GetDecimal(rdr.GetOrdinal("YuShouTuanKuan"));
                    info.YuShouTuiPiaoKuan = rdr.GetDecimal(rdr.GetOrdinal("YuShouTuiPiaoKuan"));
                    info.ZanShiJieKuan = rdr.GetDecimal(rdr.GetOrdinal("ZanShiJieKuan"));
                    info.LeiJiWeiFenPeiLiRun = rdr.GetDecimal(rdr.GetOrdinal("LeiJiWeiFenPeiLiRun"));
                    info.BenYueWeiFenPeiLiRun = rdr.GetDecimal(rdr.GetOrdinal("BenYueWeiFenPeiLiRun"));
                    info.YingShouZhangKuanBeiZhu = rdr["YingShouZhangKuanBeiZhu"].ToString();
                    info.QiTaYingShouKuanBeiZhu = rdr["QiTaYingShouKuanBeiZhu"].ToString(); 
                    info.YuFuZhangKuanBeiZhu = rdr["YuFuZhangKuanBeiZhu"].ToString();
                    info.YingFuZhangKuanBeiZhu = rdr["YingFuZhangKuanBeiZhu"].ToString();
                    info.YuShouZhangKuanBeiZhu = rdr["YuShouZhangKuanBeiZhu"].ToString(); 
                    info.ShiShouGuBenBeiZhu = rdr["ShiShouGuBenBeiZhu"].ToString();

                    info.Historys = GetZiChanFuZhaiHistorys(info.Id);
                }
            }

            return info;
        }

        /// <summary>
        /// 更新资产负债表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MZiChanFuZhaiInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.Id);
            _db.AddInParameter(cmd, "Year", DbType.Int32, info.Year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, info.Month);
            _db.AddInParameter(cmd, "HuoBiZiJin", DbType.Decimal, info.HuoBiZiJin);
            _db.AddInParameter(cmd, "YingShouZhangKuan", DbType.Decimal, info.YingShouZhangKuan);
            _db.AddInParameter(cmd, "QiTaYingShouKuan", DbType.Decimal, info.QiTaYingShouKuan);
            _db.AddInParameter(cmd, "YuFuZhangKuan", DbType.Decimal, info.YuFuZhangKuan);
            _db.AddInParameter(cmd, "QiTaYuFu", DbType.Decimal, info.QiTaYuFu);
            _db.AddInParameter(cmd, "YingFuZhangKuan", DbType.Decimal, info.YingFuZhangKuan);
            _db.AddInParameter(cmd, "QiTaYingFuKuan", DbType.Decimal, info.QiTaYingFuKuan);
            _db.AddInParameter(cmd, "YuShouZhangKuan", DbType.Decimal, info.YuShouZhangKuan);
            _db.AddInParameter(cmd, "QiTaYuShou", DbType.Decimal, info.QiTaYuShou);
            _db.AddInParameter(cmd, "ShiShouGuBen", DbType.Decimal, info.ShiShouGuBen);
            _db.AddInParameter(cmd, "WeiFenPeiLiRun", DbType.Decimal, info.WeiFenPeiLiRun);
            _db.AddInParameter(cmd, "ChaE", DbType.Decimal, info.ChaE);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "YMD", DbType.DateTime, new DateTime(info.Year, info.Month, 1));
            _db.AddInParameter(cmd, "YingShouTuanKuan", DbType.Decimal, info.YingShouTuanKuan);
            _db.AddInParameter(cmd, "YingShouYaJinTuiKuan", DbType.Decimal, info.YingShouYaJinTuiKuan);
            _db.AddInParameter(cmd, "YingShouJiuDianTuiKuan", DbType.Decimal, info.YingShouJiuDianTuiKuan);
            _db.AddInParameter(cmd, "YingShouTuiPiaoKuan", DbType.Decimal, info.YingShouTuiPiaoKuan);
            _db.AddInParameter(cmd, "YingShouQiTa", DbType.Decimal, info.YingShouQiTa);
            _db.AddInParameter(cmd, "ZhiLiangBaoZhengJin", DbType.Decimal, info.ZhiLiangBaoZhengJin);
            _db.AddInParameter(cmd, "GeRenJieKuan", DbType.Decimal, info.GeRenJieKuan);
            _db.AddInParameter(cmd, "GongYingShangYaJin", DbType.Decimal, info.GongYingShangYaJin);
            _db.AddInParameter(cmd, "JiuDianYaJin", DbType.Decimal, info.JiuDianYaJin);
            _db.AddInParameter(cmd, "ZuTuanSheYaJin", DbType.Decimal, info.ZuTuanSheYaJin);
            _db.AddInParameter(cmd, "QTYSQiTa", DbType.Decimal, info.QTYSQiTa);
            _db.AddInParameter(cmd, "YuFuDiJieKuan", DbType.Decimal, info.YuFuDiJieKuan);
            _db.AddInParameter(cmd, "YuFuJiPiaoKuan", DbType.Decimal, info.YuFuJiPiaoKuan);
            _db.AddInParameter(cmd, "YuFuJiaoTongYaJinKuan", DbType.Decimal, info.YuFuJiaoTongYaJinKuan);
            _db.AddInParameter(cmd, "YuFuJiuDianKuan", DbType.Decimal, info.YuFuJiuDianKuan);
            _db.AddInParameter(cmd, "YingFuDiJieKuan", DbType.Decimal, info.YingFuDiJieKuan);
            _db.AddInParameter(cmd, "YingFuJiPiaoKuan", DbType.Decimal, info.YingFuJiPiaoKuan);
            _db.AddInParameter(cmd, "YingFuJiuDianKuan", DbType.Decimal, info.YingFuJiuDianKuan);
            _db.AddInParameter(cmd, "YuShouTuanKuan", DbType.Decimal, info.YuShouTuanKuan);
            _db.AddInParameter(cmd, "YuShouTuiPiaoKuan", DbType.Decimal, info.YuShouTuiPiaoKuan);
            _db.AddInParameter(cmd, "ZanShiJieKuan", DbType.Decimal, info.ZanShiJieKuan);
            _db.AddInParameter(cmd, "LeiJiWeiFenPeiLiRun", DbType.Decimal, info.LeiJiWeiFenPeiLiRun);
            _db.AddInParameter(cmd, "BenYueWeiFenPeiLiRun", DbType.Decimal, info.BenYueWeiFenPeiLiRun);
            _db.AddInParameter(cmd, "YingShouZhangKuanBeiZhu", DbType.String, info.YingShouZhangKuanBeiZhu);
            _db.AddInParameter(cmd, "QiTaYingShouKuanBeiZhu", DbType.String, info.QiTaYingShouKuanBeiZhu);
            _db.AddInParameter(cmd, "YuFuZhangKuanBeiZhu", DbType.String, info.YuFuZhangKuanBeiZhu);
            _db.AddInParameter(cmd, "YingFuZhangKuanBeiZhu", DbType.String, info.YingFuZhangKuanBeiZhu);
            _db.AddInParameter(cmd, "YuShouZhangKuanBeiZhu", DbType.String, info.YuShouZhangKuanBeiZhu);
            _db.AddInParameter(cmd, "ShiShouGuBenBeiZhu", DbType.String, info.ShiShouGuBenBeiZhu);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 删除资产负债表信息
        /// </summary>
        /// <param name="liRunId">资产负债编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string ziChanFuZhaiId, int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, ziChanFuZhaiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取资产负债表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息 [0:decimal:货币资金][1:decimal:应收帐款][2:decimal:其他应收款][3:decimal:预付帐款][4:decimal:应付帐款][5:decimal:预收帐款][6:decimal:实收股本][7:decimal:未分配利润][8:decimal:差额]</param>
        /// <returns></returns>
        public IList<MZiChanFuZhaiInfo> GetZiChanFuZhais(int companyId, int pageSize, int pageIndex, ref int recordCount, MZiChanFuZhaiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M, 0M, 0M, 0M, 0M, 0M };
            IList<MZiChanFuZhaiInfo> items = new List<MZiChanFuZhaiInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_FinZiChanFuZhai";
            string orderByString = " [Year] DESC,[Month] DESC ";
            string sumString = "SUM(HuoBiZiJin) AS HuoBiZiJinHeJi,SUM(YingShouZhangKuan) AS YingShouZhangKuanHeJi";
            sumString += ",SUM(QiTaYingShouKuan) AS QiTaYingShouKuanHeJi,SUM(YuFuZhangKuan) AS YuFuZhangKuanHeJi";
            sumString += ",SUM(YingFuZhangKuan) AS YingFuZhangKuanHeJi,SUM(YuShouZhangKuan) YuShouZhangKuanHeJi";
            sumString += ",SUM(ShiShouGuBen) AS ShiShouGuBenHeJi,SUM(WeiFenPeiLiRun) AS WeiFenPeiLiRunHeJi";
            sumString += ",SUM(ChaE) AS ChaEHeJi";

            #region fields
            fields.Append(" * ");
            fields.AppendFormat(",(SELECT COUNT(*) FROM tbl_BianGeng AS A WHERE A.BianId=tbl_FinZiChanFuZhai.Id AND A.BianType={0}) AS BianGengCiShu", (int)EyouSoft.Model.EnumType.TourStructure.BianType.资产负债表);
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (chaXun.Year.HasValue)
                {
                    query.AppendFormat(" AND [Year]={0} ", chaXun.Year.Value);
                }
                if (chaXun.Month.HasValue)
                {
                    query.AppendFormat(" AND [Month]={0} ", chaXun.Month.Value);
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
                    var item = new MZiChanFuZhaiInfo();

                    item.BeiZhu = rdr["BeiZhu"].ToString();
                    item.ChaE = rdr.GetDecimal(rdr.GetOrdinal("ChaE"));
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.HuoBiZiJin = rdr.GetDecimal(rdr.GetOrdinal("HuoBiZiJin"));
                    item.Id = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.Month = rdr.GetInt32(rdr.GetOrdinal("Month"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.QiTaYingFuKuan = rdr.GetDecimal(rdr.GetOrdinal("QiTaYingFuKuan"));
                    item.QiTaYingShouKuan = rdr.GetDecimal(rdr.GetOrdinal("QiTaYingShouKuan"));
                    item.QiTaYuFu = rdr.GetDecimal(rdr.GetOrdinal("QiTaYuFu"));
                    item.QiTaYuShou = rdr.GetDecimal(rdr.GetOrdinal("QiTaYuShou"));
                    item.ShiShouGuBen = rdr.GetDecimal(rdr.GetOrdinal("ShiShouGuBen"));
                    item.WeiFenPeiLiRun = rdr.GetDecimal(rdr.GetOrdinal("WeiFenPeiLiRun"));
                    item.Year = rdr.GetInt32(rdr.GetOrdinal("Year"));
                    item.YingFuZhangKuan = rdr.GetDecimal(rdr.GetOrdinal("YingFuZhangKuan"));
                    item.YingShouZhangKuan = rdr.GetDecimal(rdr.GetOrdinal("YingShouZhangKuan"));
                    item.YuFuZhangKuan = rdr.GetDecimal(rdr.GetOrdinal("YuFuZhangKuan"));
                    item.YuShouZhangKuan = rdr.GetDecimal(rdr.GetOrdinal("YuShouZhangKuan"));
                    item.YMD = rdr.GetDateTime(rdr.GetOrdinal("YMD"));
                    item.IsBianGeng = rdr.GetInt32(rdr.GetOrdinal("BianGengCiShu")) > 0;

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("HuoBiZiJinHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("HuoBiZiJinHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingShouZhangKuanHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("YingShouZhangKuanHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QiTaYingShouKuanHeJi"))) heJi[2] = rdr.GetDecimal(rdr.GetOrdinal("QiTaYingShouKuanHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YuFuZhangKuanHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("YuFuZhangKuanHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingFuZhangKuanHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("YingFuZhangKuanHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YuShouZhangKuanHeJi"))) heJi[5] = rdr.GetDecimal(rdr.GetOrdinal("YuShouZhangKuanHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShiShouGuBenHeJi"))) heJi[6] = rdr.GetDecimal(rdr.GetOrdinal("ShiShouGuBenHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("WeiFenPeiLiRunHeJi"))) heJi[7] = rdr.GetDecimal(rdr.GetOrdinal("WeiFenPeiLiRunHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChaEHeJi"))) heJi[8] = rdr.GetDecimal(rdr.GetOrdinal("ChaEHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 写入修改历史记录信息，返回1成功，其它失败
        /// </summary>
        /// <param name="items">历史记录信息集合</param>
        /// <param name="ziChanFuZhaiId">资产负债编号</param>
        /// <returns></returns>
        public int InsertHistory(IList<MZiChanFuZhaiHistoryInfo> items, string ziChanFuZhaiId)
        {
            DbCommand cmd = _db.GetSqlStringCommand("SELECT 1");
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE tbl_FinZiChanFuZhaiHistory SET [IsDelete]='1' WHERE [ZiChanFuZhaiId]=@ZiChanFuZhaiId AND [IdentityId] NOT IN(0");
            _db.AddInParameter(cmd, "ZiChanFuZhaiId", DbType.AnsiStringFixedLength, ziChanFuZhaiId);
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    sql.Append("," + item.IdentityId);
                }
            }
            sql.Append(");");

            if (items != null && items.Count > 0)
            {
                int i = 0;
                foreach (var item in items)
                {
                    if (item.IdentityId == 0)
                    {
                        sql.AppendFormat("INSERT INTO [tbl_FinZiChanFuZhaiHistory]([ZiChanFuZhaiId],[Time],[XiangMu],[NeiRong],[IssueTime],[OperatorId],[IsDelete])VALUES(@ZiChanFuZhaiId,@Time{0},@XiangMu{0},@NeiRong{0},@IssueTime{0},@OperatorId{0},'0');", i);
                        _db.AddInParameter(cmd, "Time" + i, DbType.DateTime, item.Time);
                        _db.AddInParameter(cmd, "XiangMu" + i, DbType.String, item.XiangMu);
                        _db.AddInParameter(cmd, "NeiRong" + i, DbType.String, item.NeiRong);
                        _db.AddInParameter(cmd, "IssueTime" + i, DbType.DateTime, item.IssueTime);
                        _db.AddInParameter(cmd, "OperatorId" + i, DbType.Int32, item.OperatorId);
                    }
                    else
                    {
                        sql.AppendFormat("UPDATE [tbl_FinZiChanFuZhaiHistory] SET [Time]=@Time{0},[XiangMu]=@XiangMu{0},[NeiRong]=@NeiRong{0} WHERE [IdentityId]=@IdentityId{0}", i);
                        _db.AddInParameter(cmd, "Time" + i, DbType.DateTime, item.Time);
                        _db.AddInParameter(cmd, "XiangMu" + i, DbType.String, item.XiangMu);
                        _db.AddInParameter(cmd, "NeiRong" + i, DbType.String, item.NeiRong);
                        _db.AddInParameter(cmd, "IdentityId" + i, DbType.Int32, item.IdentityId);

                    }

                    i++;
                }
            }

            cmd.CommandText = sql.ToString();

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }
        #endregion
    }
}
