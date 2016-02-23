//财务管理-利润表相关数据访问类 汪奇志 2013-02-01
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
    /// 财务管理-利润表相关数据访问类
    /// </summary>
    public class DLiRun : DALBase, ILiRun
    {
        #region static constants
        //static constants
        const string SQL_SELECT_IsExists = "SELECT COUNT(*) FROM [tbl_FinLiRun] WHERE [CompanyId]=@CompanyId AND [Year]=@Year AND [Month]=@Month AND ZxsId=@ZxsId";
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_FinLiRun]([Id],[CompanyId],[Year],[Month],[TuanDuiJieSuanMaoLi],[BaoXiaoFeiYong],[YingYeWaiShouRu],[YingYeWaiZhiChu],[ChunLiRun],[BeiZhu],[OperatorId],[IssueTime],[YMD],[ZhuYingYeWuShouRu],[ZhuYingYeWuZhiChu],[DanFangYingShouKuan],[DanDingPiaoYingShouKuan],[PiaoWuJiuDianYingShouKuan],[ChangGuiLvYouYingShouKuan],[TeShuLvYouYingShouKuan],[TuiPiaoShouRu],[QiTaZhuYingYeWuShouRu],[DiJieKuan],[JiPiaoKuan],[JiaoTongYaJin],[JiuDianKuan],[QiTaZhuYingYeWuZhiChu],[YingHangLiXiShouRu],[FangZuShouRu],[GongYingShangFanYong],[HaiKouGongSiFanYong],[QiTaYingYeWaiShouRu],[QiTaSunShi],[ZhuYingYeWuShouRuBeiZhu],[ZhuYingYeWuZhiChuBeiZhu],[YingYeWaiShouRuBeiZhu],[YingYeWaiZhiChuBeiZhu],[QiTaSunShiBeiZhu],[ZxsId])VALUES(@Id,@CompanyId,@Year,@Month,@TuanDuiJieSuanMaoLi,@BaoXiaoFeiYong,@YingYeWaiShouRu,@YingYeWaiZhiChu,@ChunLiRun,@BeiZhu,@OperatorId,@IssueTime,@YMD,@ZhuYingYeWuShouRu,@ZhuYingYeWuZhiChu,@DanFangYingShouKuan,@DanDingPiaoYingShouKuan,@PiaoWuJiuDianYingShouKuan,@ChangGuiLvYouYingShouKuan,@TeShuLvYouYingShouKuan,@TuiPiaoShouRu,@QiTaZhuYingYeWuShouRu,@DiJieKuan,@JiPiaoKuan,@JiaoTongYaJin,@JiuDianKuan,@QiTaZhuYingYeWuZhiChu,@YingHangLiXiShouRu,@FangZuShouRu,@GongYingShangFanYong,@HaiKouGongSiFanYong,@QiTaYingYeWaiShouRu,@QiTaSunShi,@ZhuYingYeWuShouRuBeiZhu,@ZhuYingYeWuZhiChuBeiZhu,@YingYeWaiShouRuBeiZhu,@YingYeWaiZhiChuBeiZhu,@QiTaSunShiBeiZhu,@ZxsId)";
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_FinLiRun] WHERE [Id]=@Id";
        const string SQL_UPDATE_Update = "UPDATE [tbl_FinLiRun] SET [Year] = @Year,[Month] = @Month,[TuanDuiJieSuanMaoLi] = @TuanDuiJieSuanMaoLi,[BaoXiaoFeiYong] = @BaoXiaoFeiYong,[YingYeWaiShouRu] = @YingYeWaiShouRu,[YingYeWaiZhiChu] = @YingYeWaiZhiChu,[ChunLiRun] = @ChunLiRun,[BeiZhu] = @BeiZhu,[YMD]=@YMD,[ZhuYingYeWuShouRu] = @ZhuYingYeWuShouRu,[ZhuYingYeWuZhiChu] = @ZhuYingYeWuZhiChu,[DanFangYingShouKuan] = @DanFangYingShouKuan,[DanDingPiaoYingShouKuan] = @DanDingPiaoYingShouKuan,[PiaoWuJiuDianYingShouKuan] = @PiaoWuJiuDianYingShouKuan,[ChangGuiLvYouYingShouKuan] = @ChangGuiLvYouYingShouKuan,[TeShuLvYouYingShouKuan] = @TeShuLvYouYingShouKuan,[TuiPiaoShouRu] = @TuiPiaoShouRu,[QiTaZhuYingYeWuShouRu] = @QiTaZhuYingYeWuShouRu,[DiJieKuan] = @DiJieKuan,[JiPiaoKuan] = @JiPiaoKuan,[JiaoTongYaJin] = @JiaoTongYaJin,[JiuDianKuan] = @JiuDianKuan,[QiTaZhuYingYeWuZhiChu] = @QiTaZhuYingYeWuZhiChu,[YingHangLiXiShouRu] = @YingHangLiXiShouRu,[FangZuShouRu] = @FangZuShouRu,[GongYingShangFanYong] = @GongYingShangFanYong,[HaiKouGongSiFanYong] = @HaiKouGongSiFanYong,[QiTaYingYeWaiShouRu] = @QiTaYingYeWaiShouRu,[QiTaSunShi] = @QiTaSunShi,[ZhuYingYeWuShouRuBeiZhu] = @ZhuYingYeWuShouRuBeiZhu,[ZhuYingYeWuZhiChuBeiZhu] = @ZhuYingYeWuZhiChuBeiZhu,[YingYeWaiShouRuBeiZhu] = @YingYeWaiShouRuBeiZhu,[YingYeWaiZhiChuBeiZhu] = @YingYeWaiZhiChuBeiZhu,[QiTaSunShiBeiZhu] = @QiTaSunShiBeiZhu WHERE [Id] = @Id";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_FinLiRun] WHERE [Id]=@Id AND [CompanyId]=@CompanyId";
        const string SQL_SELECT_GetLiRunHistorys = "SELECT * FROM [tbl_FinLiRunHistory] WHERE [LiRunId]=@LiRunId AND [IsDelete]='0' ORDER BY [IdentityId] ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DLiRun()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 获取利润表修改记录信息集合
        /// </summary>
        /// <param name="liRunId">利润编号</param>
        /// <returns></returns>
        IList<MLiRunHistoryInfo> GetLiRunHistorys(string liRunId)
        {
            IList<MLiRunHistoryInfo> items = new List<MLiRunHistoryInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetLiRunHistorys);
            _db.AddInParameter(cmd, "LiRunId", DbType.AnsiStringFixedLength, liRunId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MLiRunHistoryInfo();

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

        #region ILiRun 成员
        /// <summary>
        /// 是否存在相同的利润年月份信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="liRunId">利润编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public bool IsExists(int companyId, int year, int month, string liRunId,string zxsId)
        {
            string sql = SQL_SELECT_IsExists;
            if (!string.IsNullOrEmpty(liRunId)) sql += " AND [Id]<>@Id ";

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "Year", DbType.Int32, year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, month);
            if (!string.IsNullOrEmpty(liRunId)) _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, liRunId);
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
        /// 写入利润表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MLiRunInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.Id);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "Year", DbType.Int32, info.Year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, info.Month);
            _db.AddInParameter(cmd, "TuanDuiJieSuanMaoLi", DbType.Decimal, info.TuanDuiJieSuanMaoLi);
            _db.AddInParameter(cmd, "BaoXiaoFeiYong", DbType.Decimal, info.BaoXiaoFeiYong);
            _db.AddInParameter(cmd, "YingYeWaiShouRu", DbType.Decimal, info.YingYeWaiShouRu);
            _db.AddInParameter(cmd, "YingYeWaiZhiChu", DbType.Decimal, info.YingYeWaiZhiChu);
            _db.AddInParameter(cmd, "ChunLiRun", DbType.Decimal, info.ChunLiRun);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "YMD", DbType.DateTime, new DateTime(info.Year, info.Month, 1));
            _db.AddInParameter(cmd, "ZhuYingYeWuShouRu", DbType.Decimal, info.ZhuYingYeWuShouRu);
            _db.AddInParameter(cmd, "ZhuYingYeWuZhiChu", DbType.Decimal, info.ZhuYingYeWuZhiChu);
            _db.AddInParameter(cmd, "DanFangYingShouKuan", DbType.Decimal, info.DanFangYingShouKuan);
            _db.AddInParameter(cmd, "DanDingPiaoYingShouKuan", DbType.Decimal, info.DanDingPiaoYingShouKuan);
            _db.AddInParameter(cmd, "PiaoWuJiuDianYingShouKuan", DbType.Decimal, info.PiaoWuJiuDianYingShouKuan);
            _db.AddInParameter(cmd, "ChangGuiLvYouYingShouKuan", DbType.Decimal, info.ChangGuiLvYouYingShouKuan);
            _db.AddInParameter(cmd, "TeShuLvYouYingShouKuan", DbType.Decimal, info.TeShuLvYouYingShouKuan);
            _db.AddInParameter(cmd, "TuiPiaoShouRu", DbType.Decimal, info.TuiPiaoShouRu);
            _db.AddInParameter(cmd, "QiTaZhuYingYeWuShouRu", DbType.Decimal, info.QiTaZhuYingYeWuShouRu);
            _db.AddInParameter(cmd, "DiJieKuan", DbType.Decimal, info.DiJieKuan);
            _db.AddInParameter(cmd, "JiPiaoKuan", DbType.Decimal, info.JiPiaoKuan);
            _db.AddInParameter(cmd, "JiaoTongYaJin", DbType.Decimal, info.JiaoTongYaJin);
            _db.AddInParameter(cmd, "JiuDianKuan", DbType.Decimal, info.JiuDianKuan);
            _db.AddInParameter(cmd, "QiTaZhuYingYeWuZhiChu", DbType.Decimal, info.QiTaZhuYingYeWuZhiChu);
            _db.AddInParameter(cmd, "YingHangLiXiShouRu", DbType.Decimal, info.YingHangLiXiShouRu);
            _db.AddInParameter(cmd, "FangZuShouRu", DbType.Decimal, info.FangZuShouRu);
            _db.AddInParameter(cmd, "GongYingShangFanYong", DbType.Decimal, info.GongYingShangFanYong);
            _db.AddInParameter(cmd, "HaiKouGongSiFanYong", DbType.Decimal, info.HaiKouGongSiFanYong);
            _db.AddInParameter(cmd, "QiTaYingYeWaiShouRu", DbType.Decimal, info.QiTaYingYeWaiShouRu);
            _db.AddInParameter(cmd, "QiTaSunShi", DbType.Decimal, info.QiTaSunShi);
            _db.AddInParameter(cmd, "ZhuYingYeWuShouRuBeiZhu", DbType.String, info.ZhuYingYeWuShouRuBeiZhu);
            _db.AddInParameter(cmd, "ZhuYingYeWuZhiChuBeiZhu", DbType.String, info.ZhuYingYeWuZhiChuBeiZhu);
            _db.AddInParameter(cmd, "YingYeWaiShouRuBeiZhu", DbType.String, info.YingYeWaiShouRuBeiZhu);
            _db.AddInParameter(cmd, "YingYeWaiZhiChuBeiZhu", DbType.String, info.YingYeWaiZhiChuBeiZhu);
            _db.AddInParameter(cmd, "QiTaSunShiBeiZhu", DbType.String, info.QiTaSunShiBeiZhu);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取利润表信息
        /// </summary>
        /// <param name="liRunId">利润编号</param>
        /// <returns></returns>
        public MLiRunInfo GetInfo(string liRunId)
        {
            MLiRunInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, liRunId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MLiRunInfo();

                    info.BaoXiaoFeiYong = rdr.GetDecimal(rdr.GetOrdinal("BaoXiaoFeiYong"));
                    info.BeiZhu = rdr["BeiZhu"].ToString();
                    info.ChunLiRun = rdr.GetDecimal(rdr.GetOrdinal("ChunLiRun"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.Id = liRunId;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.Month = rdr.GetInt32(rdr.GetOrdinal("Month"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.TuanDuiJieSuanMaoLi = rdr.GetDecimal(rdr.GetOrdinal("TuanDuiJieSuanMaoLi"));
                    info.Year = rdr.GetInt32(rdr.GetOrdinal("Year"));
                    info.YingYeWaiShouRu = rdr.GetDecimal(rdr.GetOrdinal("YingYeWaiShouRu"));
                    info.YingYeWaiZhiChu = rdr.GetDecimal(rdr.GetOrdinal("YingYeWaiZhiChu"));
                    info.YMD = rdr.GetDateTime(rdr.GetOrdinal("YMD"));

                    info.ZhuYingYeWuShouRu = rdr.GetDecimal(rdr.GetOrdinal("ZhuYingYeWuShouRu"));
                    info.ZhuYingYeWuZhiChu = rdr.GetDecimal(rdr.GetOrdinal("ZhuYingYeWuZhiChu"));
                    info.DanFangYingShouKuan = rdr.GetDecimal(rdr.GetOrdinal("DanFangYingShouKuan"));
                    info.DanDingPiaoYingShouKuan = rdr.GetDecimal(rdr.GetOrdinal("DanDingPiaoYingShouKuan"));
                    info.PiaoWuJiuDianYingShouKuan = rdr.GetDecimal(rdr.GetOrdinal("PiaoWuJiuDianYingShouKuan"));
                    info.ChangGuiLvYouYingShouKuan = rdr.GetDecimal(rdr.GetOrdinal("ChangGuiLvYouYingShouKuan"));
                    info.TeShuLvYouYingShouKuan = rdr.GetDecimal(rdr.GetOrdinal("TeShuLvYouYingShouKuan"));
                    info.TuiPiaoShouRu = rdr.GetDecimal(rdr.GetOrdinal("TuiPiaoShouRu"));
                    info.QiTaZhuYingYeWuShouRu = rdr.GetDecimal(rdr.GetOrdinal("QiTaZhuYingYeWuShouRu"));
                    info.DiJieKuan = rdr.GetDecimal(rdr.GetOrdinal("DiJieKuan"));
                    info.JiPiaoKuan = rdr.GetDecimal(rdr.GetOrdinal("JiPiaoKuan"));
                    info.JiaoTongYaJin = rdr.GetDecimal(rdr.GetOrdinal("JiaoTongYaJin"));
                    info.JiuDianKuan = rdr.GetDecimal(rdr.GetOrdinal("JiuDianKuan"));
                    info.QiTaZhuYingYeWuZhiChu = rdr.GetDecimal(rdr.GetOrdinal("QiTaZhuYingYeWuZhiChu"));
                    info.YingHangLiXiShouRu = rdr.GetDecimal(rdr.GetOrdinal("YingHangLiXiShouRu"));
                    info.FangZuShouRu = rdr.GetDecimal(rdr.GetOrdinal("FangZuShouRu"));
                    info.GongYingShangFanYong = rdr.GetDecimal(rdr.GetOrdinal("GongYingShangFanYong"));
                    info.HaiKouGongSiFanYong = rdr.GetDecimal(rdr.GetOrdinal("HaiKouGongSiFanYong"));
                    info.QiTaYingYeWaiShouRu = rdr.GetDecimal(rdr.GetOrdinal("QiTaYingYeWaiShouRu"));
                    info.QiTaSunShi = rdr.GetDecimal(rdr.GetOrdinal("QiTaSunShi"));
                    info.ZhuYingYeWuShouRuBeiZhu = rdr["ZhuYingYeWuShouRuBeiZhu"].ToString(); 
                    info.ZhuYingYeWuZhiChuBeiZhu = rdr["ZhuYingYeWuZhiChuBeiZhu"].ToString(); 
                    info.YingYeWaiShouRuBeiZhu = rdr["YingYeWaiShouRuBeiZhu"].ToString();
                    info.YingYeWaiZhiChuBeiZhu = rdr["YingYeWaiZhiChuBeiZhu"].ToString();
                    info.QiTaSunShiBeiZhu = rdr["QiTaSunShiBeiZhu"].ToString();

                    info.Historys = GetLiRunHistorys(info.Id);
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 更新利润表信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MLiRunInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.Id);
            _db.AddInParameter(cmd, "Year", DbType.Int32, info.Year);
            _db.AddInParameter(cmd, "Month", DbType.Int32, info.Month);
            _db.AddInParameter(cmd, "TuanDuiJieSuanMaoLi", DbType.Decimal, info.TuanDuiJieSuanMaoLi);
            _db.AddInParameter(cmd, "BaoXiaoFeiYong", DbType.Decimal, info.BaoXiaoFeiYong);
            _db.AddInParameter(cmd, "YingYeWaiShouRu", DbType.Decimal, info.YingYeWaiShouRu);
            _db.AddInParameter(cmd, "YingYeWaiZhiChu", DbType.Decimal, info.YingYeWaiZhiChu);
            _db.AddInParameter(cmd, "ChunLiRun", DbType.Decimal, info.ChunLiRun);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "YMD", DbType.DateTime, new DateTime(info.Year, info.Month, 1));
            _db.AddInParameter(cmd, "ZhuYingYeWuShouRu", DbType.Decimal, info.ZhuYingYeWuShouRu);
            _db.AddInParameter(cmd, "ZhuYingYeWuZhiChu", DbType.Decimal, info.ZhuYingYeWuZhiChu);
            _db.AddInParameter(cmd, "DanFangYingShouKuan", DbType.Decimal, info.DanFangYingShouKuan);
            _db.AddInParameter(cmd, "DanDingPiaoYingShouKuan", DbType.Decimal, info.DanDingPiaoYingShouKuan);
            _db.AddInParameter(cmd, "PiaoWuJiuDianYingShouKuan", DbType.Decimal, info.PiaoWuJiuDianYingShouKuan);
            _db.AddInParameter(cmd, "ChangGuiLvYouYingShouKuan", DbType.Decimal, info.ChangGuiLvYouYingShouKuan);
            _db.AddInParameter(cmd, "TeShuLvYouYingShouKuan", DbType.Decimal, info.TeShuLvYouYingShouKuan);
            _db.AddInParameter(cmd, "TuiPiaoShouRu", DbType.Decimal, info.TuiPiaoShouRu);
            _db.AddInParameter(cmd, "QiTaZhuYingYeWuShouRu", DbType.Decimal, info.QiTaZhuYingYeWuShouRu);
            _db.AddInParameter(cmd, "DiJieKuan", DbType.Decimal, info.DiJieKuan);
            _db.AddInParameter(cmd, "JiPiaoKuan", DbType.Decimal, info.JiPiaoKuan);
            _db.AddInParameter(cmd, "JiaoTongYaJin", DbType.Decimal, info.JiaoTongYaJin);
            _db.AddInParameter(cmd, "JiuDianKuan", DbType.Decimal, info.JiuDianKuan);
            _db.AddInParameter(cmd, "QiTaZhuYingYeWuZhiChu", DbType.Decimal, info.QiTaZhuYingYeWuZhiChu);
            _db.AddInParameter(cmd, "YingHangLiXiShouRu", DbType.Decimal, info.YingHangLiXiShouRu);
            _db.AddInParameter(cmd, "FangZuShouRu", DbType.Decimal, info.FangZuShouRu);
            _db.AddInParameter(cmd, "GongYingShangFanYong", DbType.Decimal, info.GongYingShangFanYong);
            _db.AddInParameter(cmd, "HaiKouGongSiFanYong", DbType.Decimal, info.HaiKouGongSiFanYong);
            _db.AddInParameter(cmd, "QiTaYingYeWaiShouRu", DbType.Decimal, info.QiTaYingYeWaiShouRu);
            _db.AddInParameter(cmd, "QiTaSunShi", DbType.Decimal, info.QiTaSunShi);
            _db.AddInParameter(cmd, "ZhuYingYeWuShouRuBeiZhu", DbType.String, info.ZhuYingYeWuShouRuBeiZhu);
            _db.AddInParameter(cmd, "ZhuYingYeWuZhiChuBeiZhu", DbType.String, info.ZhuYingYeWuZhiChuBeiZhu);
            _db.AddInParameter(cmd, "YingYeWaiShouRuBeiZhu", DbType.String, info.YingYeWaiShouRuBeiZhu);
            _db.AddInParameter(cmd, "YingYeWaiZhiChuBeiZhu", DbType.String, info.YingYeWaiZhiChuBeiZhu);
            _db.AddInParameter(cmd, "QiTaSunShiBeiZhu", DbType.String, info.QiTaSunShiBeiZhu);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 删除利润表信息
        /// </summary>
        /// <param name="liRunId">利润编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string liRunId, int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, liRunId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取利润表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息 [0:decimal:团队结算毛利合计] [1:decimal:报销费用合计][2:decimal:营业外收入合计][3:decimal:营业外支出合计][4:decimal:纯利润合计][5:decimal:主营业务收入合计][6:decimal:主营业务支出合计][7:decimal:其它损失合计]</param>
        /// <returns></returns>
        public IList<MLiRunInfo> GetLiRuns(int companyId, int pageSize, int pageIndex, ref int recordCount, MLiRunChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M, 0M, 0M, 0M, 0M };
            IList<MLiRunInfo> items = new List<MLiRunInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_FinLiRun";
            string orderByString = " [Year] DESC,[Month] DESC ";
            string sumString = "SUM(TuanDuiJieSuanMaoLi) AS TuanDuiJieSuanMaoLiHeJi,SUM(BaoXiaoFeiYong) AS BaoXiaoFeiYongHeJi,SUM(YingYeWaiShouRu) AS YingYeWaiShouRuHeJi,SUM(YingYeWaiZhiChu) AS YingYeWaiZhiChuHeJi,SUM(ChunLiRun) AS ChunLiRunHeJi";
            sumString += ",SUM(ZhuYingYeWuShouRu) AS ZhuYingYeWuShouRuHeJi,SUM(ZhuYingYeWuZhiChu) AS ZhuYingYeWuZhiChuHeJi,SUM(QiTaSunShi) AS QiTaSunShiHeJi";

            #region fields
            fields.Append(" * ");
            fields.AppendFormat(",(SELECT COUNT(*) FROM tbl_BianGeng AS A WHERE A.BianId=tbl_FinLiRun.Id AND A.BianType={0}) AS BianGengCiShu", (int)EyouSoft.Model.EnumType.TourStructure.BianType.利润表);
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
                    var item = new MLiRunInfo();

                    item.BaoXiaoFeiYong = rdr.GetDecimal(rdr.GetOrdinal("BaoXiaoFeiYong"));
                    item.BeiZhu = rdr["BeiZhu"].ToString();
                    item.ChunLiRun = rdr.GetDecimal(rdr.GetOrdinal("ChunLiRun"));
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.Id = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.Month = rdr.GetInt32(rdr.GetOrdinal("Month"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.TuanDuiJieSuanMaoLi = rdr.GetDecimal(rdr.GetOrdinal("TuanDuiJieSuanMaoLi"));
                    item.Year = rdr.GetInt32(rdr.GetOrdinal("Year"));
                    item.YingYeWaiShouRu = rdr.GetDecimal(rdr.GetOrdinal("YingYeWaiShouRu"));
                    item.YingYeWaiZhiChu = rdr.GetDecimal(rdr.GetOrdinal("YingYeWaiZhiChu"));
                    item.YMD = rdr.GetDateTime(rdr.GetOrdinal("YMD"));

                    item.ZhuYingYeWuShouRu = rdr.GetDecimal(rdr.GetOrdinal("ZhuYingYeWuShouRu"));
                    item.ZhuYingYeWuZhiChu = rdr.GetDecimal(rdr.GetOrdinal("ZhuYingYeWuZhiChu"));
                    item.QiTaSunShi = rdr.GetDecimal(rdr.GetOrdinal("QiTaSunShi"));
                    item.IsBianGeng = rdr.GetInt32(rdr.GetOrdinal("BianGengCiShu")) > 0;

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("TuanDuiJieSuanMaoLiHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("TuanDuiJieSuanMaoLiHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("BaoXiaoFeiYongHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("BaoXiaoFeiYongHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingYeWaiShouRuHeJi"))) heJi[2] = rdr.GetDecimal(rdr.GetOrdinal("YingYeWaiShouRuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingYeWaiZhiChuHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("YingYeWaiZhiChuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChunLiRunHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("ChunLiRunHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhuYingYeWuShouRuHeJi"))) heJi[5] = rdr.GetDecimal(rdr.GetOrdinal("ZhuYingYeWuShouRuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhuYingYeWuZhiChuHeJi"))) heJi[6] = rdr.GetDecimal(rdr.GetOrdinal("ZhuYingYeWuZhiChuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QiTaSunShiHeJi"))) heJi[7] = rdr.GetDecimal(rdr.GetOrdinal("QiTaSunShiHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 写入修改历史记录信息，返回1成功，其它失败
        /// </summary>
        /// <param name="items">历史记录信息集合</param>
        /// <param name="liRunId">利润编号</param>
        /// <returns></returns>
        public int InsertHistory(IList<MLiRunHistoryInfo> items, string liRunId)
        {
            DbCommand cmd = _db.GetSqlStringCommand("SELECT 1");
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE tbl_FinLiRunHistory SET [IsDelete]='1' WHERE [LiRunId]=@LiRunId AND [IdentityId] NOT IN(0");
            _db.AddInParameter(cmd, "LiRunId", DbType.AnsiStringFixedLength, liRunId);
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
                        sql.AppendFormat("INSERT INTO [tbl_FinLiRunHistory]([LiRunId],[Time],[XiangMu],[NeiRong],[IssueTime],[OperatorId],[IsDelete])VALUES(@LiRunId,@Time{0},@XiangMu{0},@NeiRong{0},@IssueTime{0},@OperatorId{0},'0');", i);
                        _db.AddInParameter(cmd, "Time" + i, DbType.DateTime, item.Time);
                        _db.AddInParameter(cmd, "XiangMu" + i, DbType.String, item.XiangMu);
                        _db.AddInParameter(cmd, "NeiRong" + i, DbType.String, item.NeiRong);
                        _db.AddInParameter(cmd, "IssueTime" + i, DbType.DateTime, item.IssueTime);
                        _db.AddInParameter(cmd, "OperatorId" + i, DbType.Int32, item.OperatorId);
                    }
                    else
                    {
                        sql.AppendFormat("UPDATE [tbl_FinLiRunHistory] SET [Time]=@Time{0},[XiangMu]=@XiangMu{0},[NeiRong]=@NeiRong{0} WHERE [IdentityId]=@IdentityId{0}", i);
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
