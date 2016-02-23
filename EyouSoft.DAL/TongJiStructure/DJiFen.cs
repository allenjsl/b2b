using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.TongJiStructure
{
    /// <summary>
    /// 统计分析-积分相关数据访问类
    /// </summary>
    public class DJiFen : DALBase, EyouSoft.IDAL.TongJiStructure.IJiFen
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetJiFenJieSuanShouKuans = "SELECT * FROM tbl_Pt_FinJiFenJieSuan WHERE CompanyId=@CompanyId AND ZxsId=@ZxsId ORDER BY [IssueTime] DESC";
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
        #endregion

        #region IJiFen 成员
        /// <summary>
        /// 获取积分发放明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:int:实际发放积分数]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiInfo> GetJiFenFaFangMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiChaXunInfo chaXun,out object[] heJi)
        {
            heJi = new object[] { 0 };
            IList<EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiInfo> items = new List<EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_TongJi_JiFenFaFangMingXi";
            string orderByString = " JiFenShiJian DESC ";
            string sumString = "SUM(ShiJiFaFangJiFen) AS ShiJiFaFangJiFenHeJi";

            sql.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (chaXun.JiFenStatus.HasValue)
                {
                    sql.AppendFormat(" AND JiFenStatus={0} ", (int)chaXun.JiFenStatus.Value);
                }
                if (chaXun.QuDate1.HasValue)
                {
                    sql.AppendFormat(" AND QuDate>='{0}' ", chaXun.QuDate1.Value);
                }
                if (chaXun.QuDate2.HasValue)
                {
                    sql.AppendFormat(" AND QuDate<='{0}' ", chaXun.QuDate2.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    sql.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                if (chaXun.JiFenShiJian1.HasValue)
                {
                    sql.AppendFormat(" AND JiFenShiJian>'{0}' ", chaXun.JiFenShiJian1.Value.AddMinutes(-1));
                }
                if (chaXun.JiFenShiJian2.HasValue)
                {
                    sql.AppendFormat(" AND JiFenShiJian<'{0}' ", chaXun.JiFenShiJian2.Value.AddDays(1).AddMinutes(-1));
                }

                if (!string.IsNullOrEmpty(chaXun.KeHuId))
                {
                    sql.AppendFormat(" AND KeHuId='{0}' ", chaXun.KeHuId);
                }
                if (chaXun.YongHuId.HasValue)
                {
                    sql.AppendFormat(" AND YongHuId={0} ", chaXun.YongHuId.Value);
                }
                if (chaXun.KeHuLxrId.HasValue)
                {
                    sql.AppendFormat(" AND KeHuLxrId={0} ", chaXun.KeHuLxrId.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiInfo();

                    info.ChengRenShu = rdr.GetInt32(rdr.GetOrdinal("Adults"));
                    info.DingDanId = rdr["OrderId"].ToString();
                    info.ErTongShu = rdr.GetInt32(rdr.GetOrdinal("Childs"));
                    info.JiFenShiJian = rdr.GetDateTime(rdr.GetOrdinal("JiFenShiJian"));
                    info.JiaoYiHao = rdr["OrderCode"].ToString();
                    info.JiFen = rdr.GetInt32(rdr.GetOrdinal("ShiJiFaFangJiFen"));
                    info.JiFenStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenStatus)rdr.GetByte(rdr.GetOrdinal("JiFenStatus"));
                    info.QuanPeiShu = rdr.GetInt32(rdr.GetOrdinal("Bears"));
                    info.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    info.RouteName = rdr["RouteName"].ToString();
                    info.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("BusinessType"));
                    info.YingErShu = rdr.GetInt32(rdr.GetOrdinal("YingErRenShu"));

                    info.KeHuName = rdr["KeHuName"].ToString();
                    info.YongHuId = rdr.GetInt32(rdr.GetOrdinal("YongHuId"));
                    info.YongHuMing = rdr["YongHuMing"].ToString();
                    info.YongHuXingMing = rdr["YongHuXingMing"].ToString();
                    info.KeHuId = rdr["KeHuId"].ToString();
                    info.KeHuLxrId = rdr.GetInt32(rdr.GetOrdinal("KeHuLxrId"));

                    info.ZxsName = rdr["ZxsName"].ToString();

                    items.Add(info);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShiJiFaFangJiFenHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("ShiJiFaFangJiFenHeJi"));
                }

            }

            return items;
        }

        /// <summary>
        /// 获取积分发放结算明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:int:有效积分合计][1:int:冻结积分合计][2:int:取消积分合计][3:int:结算积分合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiInfo> GetJiFenFaFangJieSuanMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0 };
            IList<EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiInfo> items = new List<EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiInfo>();
            string fields = "ZxsId,MingCheng";
            fields += ",ISNULL((SELECT SUM(A1.ShiJiFaFangJiFen) FROM view_TongJi_JiFenFaFangMingXi AS A1 WHERE A1.ZxsId=tbl_Pt_ZhuanXianShang.ZxsId AND A1.JiFenStatus=1 {0}),0) AS YouXiaoJiFen";
            fields += ",ISNULL((SELECT SUM(A1.ShiJiFaFangJiFen) FROM view_TongJi_JiFenFaFangMingXi AS A1 WHERE A1.ZxsId=tbl_Pt_ZhuanXianShang.ZxsId AND A1.JiFenStatus=0 {0}),0) AS DongJieJiFen";
            fields += ",ISNULL((SELECT SUM(A1.ShiJiFaFangJiFen) FROM view_TongJi_JiFenFaFangMingXi AS A1 WHERE A1.ZxsId=tbl_Pt_ZhuanXianShang.ZxsId AND A1.JiFenStatus=2 {0}),0) AS QuXiaoJiFen";
            fields += ",ISNULL((SELECT SUM(A1.JiFen) FROM tbl_Pt_FinJiFenJieSuan AS A1 WHERE A1.ZxsId=tbl_Pt_ZhuanXianShang.ZxsId {1}),0) AS JieSuanJiFen";

            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_ZhuanXianShang";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(YouXiaoJiFen) AS YouXiaoJiFenHeJi,SUM(DongJieJiFen) AS DongJieJiFenHeJi,SUM(QuXiaoJiFen) AS QuXiaoJiFenHeJi,SUM(JieSuanJiFen) AS JieSuanJiFenHeJi";

            sql.AppendFormat(" CompanyId={0} AND IsDelete='0' ", companyId);

            string sql0 = string.Empty;//关于积分发放
            string sql1 = string.Empty;//关于积分结算

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ZxsName))
                {
                    sql.AppendFormat(" AND ZxsName LIKE '%{0}%' ", chaXun.ZxsName);
                }

                if (chaXun.QuDate1.HasValue)
                {
                    sql0 += string.Format(" AND A1.QuDate>='{0}' ",chaXun.QuDate1.Value);
                }
                if (chaXun.QuDate2.HasValue)
                {
                    sql0 += string.Format(" AND A1.QuDate<='{0}' ", chaXun.QuDate2.Value);
                }
                if (chaXun.FaFangShiJian1.HasValue)
                {
                    sql0 += string.Format(" AND A1.JiFenShiJian>'{0}' ", chaXun.FaFangShiJian1.Value.AddMinutes(-1));
                }
                if (chaXun.FaFangShiJian2.HasValue)
                {
                    sql0 += string.Format(" AND A1.JiFenShiJian<'{0}' ", chaXun.FaFangShiJian2.Value.AddDays(1).AddMinutes(-1));
                }

                if (chaXun.JieSuanShiJian1.HasValue)
                {
                    sql1+=string.Format(" AND A1.IssueTime>'{0}' ",chaXun.JieSuanShiJian1.Value.AddMinutes(-1));
                }
                if (chaXun.JieSuanShiJian2.HasValue)
                {
                    sql1 += string.Format(" AND A1.IssueTime>'{0}' ", chaXun.JieSuanShiJian2.Value.AddDays(1).AddMinutes(-1));
                }
            }

            fields = string.Format(fields, sql0, sql1);

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiInfo();

                    info.DongJieJiFen = rdr.GetInt32(rdr.GetOrdinal("DongJieJiFen"));
                    info.JieSuanJiFen = rdr.GetInt32(rdr.GetOrdinal("JieSuanJiFen"));
                    info.QuXiaoJiFen = rdr.GetInt32(rdr.GetOrdinal("QuXiaoJiFen"));
                    info.YouXiaoJiFen = rdr.GetInt32(rdr.GetOrdinal("YouXiaoJiFen"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                    info.ZxsName = rdr["MingCheng"].ToString();

                    items.Add(info);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YouXiaoJiFenHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("YouXiaoJiFenHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("DongJieJiFenHeJi"))) heJi[1] = rdr.GetInt32(rdr.GetOrdinal("DongJieJiFenHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QuXiaoJiFenHeJi"))) heJi[2] = rdr.GetInt32(rdr.GetOrdinal("QuXiaoJiFenHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JieSuanJiFenHeJi"))) heJi[3] = rdr.GetInt32(rdr.GetOrdinal("JieSuanJiFenHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取积分收付款明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:decimal:借方合计][1:decimal:贷方合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiInfo> GetJiFenShouFuKuanMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M,0M };
            IList<EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiInfo> items = new List<EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_TongJi_JiFenShouFuKuanMingXi";
            string orderByString = " MxShiJian DESC ";
            string sumString = "SUM(JieFangJinE) AS JieFangJinEHeJi,SUM(DaiFangJinE) AS DaiFangJinEHeJi";

            sql.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (chaXun.DengJiRiQi1.HasValue)
                {
                    sql.AppendFormat(" AND MxShiJian>'{0}' ", chaXun.DengJiRiQi1.Value.AddMinutes(-1));
                }
                if (chaXun.DengJiRiQi2.HasValue)
                {
                    sql.AppendFormat(" AND MxShiJian<'{0}' ", chaXun.DengJiRiQi2.Value.AddDays(1).AddMinutes(-1));
                }
                if (chaXun.Status.HasValue)
                {
                    if (chaXun.Status.Value == EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批)
                    {
                        sql.AppendFormat(" AND KuXiangStatus={0} ", (int)chaXun.Status.Value);
                    }
                    else
                    {
                        sql.AppendFormat(" AND KuXiangStatus<>{0} ", (int)EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批);
                    }
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiInfo();

                    info.BeiZhu = rdr["BeiZhu"].ToString();
                    info.DaiFangJinE = rdr.GetDecimal(rdr.GetOrdinal("DaiFangJinE"));
                    info.DengJiRiQi = rdr.GetDateTime(rdr.GetOrdinal("MxShiJian"));
                    info.JieFangJinE = rdr.GetDecimal(rdr.GetOrdinal("JieFangJinE"));
                    info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing)rdr.GetInt32(rdr.GetOrdinal("MxLeiXing"));
                    info.MxId = rdr["MxId"].ToString();
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("KuXiangStatus"));
                    info.WangLaiDanWei = rdr["WangLaiDanWeiName"].ToString();
                    info.YinHangZhaoHao = rdr["YinHangZhangHao"].ToString();
                    info.ZxsId = rdr["ZxsId"].ToString();
                    
                    items.Add(info);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JieFangJinEHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("JieFangJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("DaiFangJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("DaiFangJinEHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 积分结算收款登记、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int JiFenJieSuanShouKuan_CU(EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_JiFenJieSuanShouKuan_CU");
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
        /// 积分结算收款删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="jieSuanId">结算编号</param>
        /// <returns></returns>
        public int JiFenJieSuanShouKuan_D(int companyId, string zxsId, string jieSuanId)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_JiFenJieSuanShouKuan_D");
            _db.AddInParameter(cmd, "@JieSuanId", DbType.AnsiStringFixedLength, jieSuanId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
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
        /// 设置积分结算收款状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="jieSuanId">结算编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">操作人信息</param>
        /// <returns></returns>
        public int SheZhiJiFenJieSuanShouKuanStatus(int companyId, string zxsId, string jieSuanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus status, EyouSoft.Model.FinStructure.MOperatorInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus");
            _db.AddInParameter(cmd, "@JieSuanId", DbType.AnsiStringFixedLength, jieSuanId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "@BeiZhu", DbType.String, info.BeiZhu);
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
        /// 获取积分结算收款集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo> GetJiFenJieSuanShouKuans(int companyId, string zxsId)
        {
            IList<EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo> items = new List<EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo>();
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJiFenJieSuanShouKuans);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo();
                    item.CompanyId = companyId;
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JieSuanBeiZhu = rdr["JieSuanBeiZhu"].ToString();
                    item.JieSuanFangShi = (EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi)rdr.GetByte(rdr.GetOrdinal("JieSuanFangShi"));
                    item.JieSuanId = rdr["JieSuanId"].ToString();
                    item.JieSuanRenName = rdr["JieSuanRenName"].ToString();
                    item.JieSuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("JieSuanRiQi"));
                    item.JieSuanZhangHao = rdr["JieSuanZhangHao"].ToString();
                    item.JiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.ShenPiBeiZhu = rdr["ShenPiBeiZhu"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenPiRenId"))) item.ShenPiRenId = rdr.GetInt32(rdr.GetOrdinal("ShenPiRenId"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ShenPiShiJian"))) item.ShenPiShiJian = rdr.GetDateTime(rdr.GetOrdinal("ShenPiShiJian"));
                    item.Status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.ZxsId = zxsId;
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取专线商结算信息[0:int:有效积分][1:int:结算积分][2:decimal:结算已审批金额][3:decimal:结算未审批金额]
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public object[] GetZxsJieSuanXinXi(int companyId,string zxsId)
        {
            object[] obj = new object[] { 0, 0, 0M, 0M };

            string sql = " SELECT ";
            sql += " ISNULL((SELECT SUM(A1.ShiJiFaFangJiFen) FROM view_TongJi_JiFenFaFangMingXi AS A1 WHERE A1.ZxsId=A.ZxsId AND A1.JiFenStatus=1),0) AS YouXiaoJiFen ";
            //sql += " ,ISNULL((SELECT SUM(A1.ShiJiFaFangJiFen) FROM view_TongJi_JiFenFaFangMingXi AS A1 WHERE A1.ZxsId=A.ZxsId AND A1.JiFenStatus=0),0) AS DongJieJiFen ";
            //sql += " ,ISNULL((SELECT SUM(A1.ShiJiFaFangJiFen) FROM view_TongJi_JiFenFaFangMingXi AS A1 WHERE A1.ZxsId=A.ZxsId AND A1.JiFenStatus=2),0) AS QuXiaoJiFen ";
            sql += " ,ISNULL((SELECT SUM(A1.JiFen) FROM tbl_Pt_FinJiFenJieSuan AS A1 WHERE A1.ZxsId=A.ZxsId),0) AS JieSuanJiFen ";
            sql += " ,ISNULL((SELECT SUM(A1.JinE) FROM tbl_Pt_FinJiFenJieSuan AS A1 WHERE A1.ZxsId=A.ZxsId AND Status=1),0) AS YiShenPiJinE ";
            sql += " ,ISNULL((SELECT SUM(A1.JinE) FROM tbl_Pt_FinJiFenJieSuan AS A1 WHERE A1.ZxsId=A.ZxsId AND Status=0),0) AS WeiShenPiJinE ";
            sql += " FROM tbl_Pt_ZhuanXianShang AS A WHERE A.ZxsId=@ZxsId ";

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    obj[0] = rdr.GetInt32(rdr.GetOrdinal("YouXiaoJiFen"));
                    obj[1] = rdr.GetInt32(rdr.GetOrdinal("JieSuanJiFen"));
                    obj[2] = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    obj[3] = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                }
            }

            return obj;
        }

        /// <summary>
        /// 获取客户用户积分统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:可用积分][1:int:冻结积分][0:int:已使用积分]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenInfo> GetKeHuYongHuJiFens(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0 };
            IList<EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenInfo> items = new List<EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenInfo>();

            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_TongJi_KeHuYongHuJiFen";
            string orderByString = " YongHuId DESC ";
            string sumString = "SUM(KeYongJiFen) AS KeYongJiFenHeJi,SUM(DongJieJiFen) AS DongJieJiFenHeJi,SUM(YiShiYongJiFen) AS YiShiYongJiFenHeJi";

            sql.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.KeHuId))
                {
                    sql.AppendFormat(" AND KeHuId='{0}' ", chaXun.KeHuId);
                }
                if (chaXun.KeHuLxrId.HasValue)
                {
                    sql.AppendFormat(" AND KeHuLxrId={0} ", chaXun.KeHuLxrId.Value);
                }
                if (chaXun.YongHuId.HasValue)
                {
                    sql.AppendFormat(" AND YongHuId={0} ", chaXun.YongHuId.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DongJieJiFen = rdr.GetInt32(rdr.GetOrdinal("DongJieJiFen"));
                    info.KeHuId = rdr["KeHuId"].ToString();
                    info.KeHuLxrId = rdr.GetInt32(rdr.GetOrdinal("KeHuLxrId"));
                    info.KeHuName = rdr["KeHuName"].ToString();
                    info.KeYongJiFen = rdr.GetInt32(rdr.GetOrdinal("KeYongJiFen"));
                    info.YiShiYongJiFen = rdr.GetInt32(rdr.GetOrdinal("YiShiYongJiFen"));
                    info.YongHuDianHua = rdr["YongHuDianHua"].ToString();
                    info.YongHuId = rdr.GetInt32(rdr.GetOrdinal("YongHuId"));
                    info.YongHuMing = rdr["YongHuMing"].ToString();
                    info.YongHuName = rdr["YongHuName"].ToString();
                    info.YongHuShouJi = rdr["YongHuShouJi"].ToString();
                    info.YongHuYouXiang = rdr["YongHuYouXiang"].ToString();

                    items.Add(info);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("KeYongJiFenHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("KeYongJiFenHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("DongJieJiFenHeJi"))) heJi[1] = rdr.GetInt32(rdr.GetOrdinal("DongJieJiFenHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShiYongJiFenHeJi"))) heJi[2] = rdr.GetInt32(rdr.GetOrdinal("YiShiYongJiFenHeJi"));
                }
            }

            return items;
        }
        #endregion
    }
}
