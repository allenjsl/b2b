//财务管理发票相关数据访问类 汪奇志 2012-11-19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using EyouSoft.IDAL.FinStructure;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 财务管理发票相关数据访问类
    /// </summary>
    public class DFaPiao : DALBase, IFaPiao
    {
        #region static constants
        //static constants
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_FinFaPiaoMx] WHERE [DengJiId]=@FaPiaoId;DELETE FROM [tbl_FinFaPiao] WHERE [DengJiId]=@FaPiaoId AND [CompanyId]=@CompanyId";
        const string SQL_SELECT_GetInfo = "SELECT A.*,(SELECT B.Name FROM tbl_Customer AS B WHERE B.Id=A.KeHuId) AS KeHuName FROM [tbl_FinFaPiao] AS A WHERE A.[DengJiId]=@FaPiaoId";
        const string SQL_SELECT_GetFaPiaoMxs = "SELECT * FROM [tbl_FinFaPiaoMx] WHERE [DengJiId]=@FaPiaoId";
        const string SQL_SELECT_GetFaSongShuLiang = "SELECT COUNT(*) AS ShuLiang FROM [tbl_FinFaPiaoMx] WHERE [DengJiId]=@FaPiaoId AND [Status]=@Status";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DFaPiao()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 创建发票明细XML
        /// </summary>
        /// <param name="items">集合</param>
        /// <returns></returns>
        string CreateFaPiaoMxsXml(IList<EyouSoft.Model.FinStructure.MFaPiaoMXInfo> items)
        {
            //XML:<root><info MxId="" ChuTuanRiQi="" JinE="" Status="" FaSongTime="" FaSongFangShi="" YouJiGongSiName="" YouJiDanHao="" QianShouRenName="" QianShouTime="" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();

            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append("<info ");
                s.AppendFormat("MxId=\"{0}\" ", item.MXId);
                s.AppendFormat("ChuTuanRiQi=\"{0}\" ", item.ChuTuanRiQi);
                s.AppendFormat("JinE=\"{0}\" ", item.JinE);
                s.AppendFormat("Status=\"{0}\" ", (int)item.Status);
                if (item.FaSongTime.HasValue) s.AppendFormat("FaSongTime=\"{0}\" ", item.FaSongTime.Value);                
                if (item.QianShouTime.HasValue) s.AppendFormat("QianShouTime=\"{0}\" ", item.QianShouTime.Value);
                s.AppendFormat("MingXiId=\"{0}\" ", item.MingXiId);
                s.AppendFormat("DingDanId=\"{0}\" ", item.DingDanId);
                s.AppendFormat("DingDanHao=\"{0}\" ", item.DingDanHao);
                s.Append(">");

                s.AppendFormat("<FaSongFangShi><![CDATA[{0}]]></FaSongFangShi>", item.FaSongFangShi);
                s.AppendFormat("<YouJiGongSiName><![CDATA[{0}]]></YouJiGongSiName>", item.YouJiGongSiName);
                s.AppendFormat("<YouJiDanHao><![CDATA[{0}]]></YouJiDanHao>", item.YouJiDanHao);
                s.AppendFormat("<QianShouRenName><![CDATA[{0}]]></QianShouRenName>", item.QianShouRenName);

                s.AppendFormat("<TaiTou><![CDATA[{0}]]></TaiTou>", item.TaiTou);
                s.AppendFormat("<KaiPiaoDanWei><![CDATA[{0}]]></KaiPiaoDanWei>", item.KaiPiaoDanWei);
                s.AppendFormat("<FaPiaoHao><![CDATA[{0}]]></FaPiaoHao>", item.FaPiaoHao);
                s.AppendFormat("<MingXi><![CDATA[{0}]]></MingXi>", item.MingXi);


                s.Append("</info>");
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 获取发票明细信息集合
        /// </summary>
        /// <param name="faPiaoId">发票登记编号</param>
        /// <returns></returns>
        IList<MFaPiaoMXInfo> GetFaPiaoMxs(string faPiaoId)
        {
            IList<MFaPiaoMXInfo> items = new List<MFaPiaoMXInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetFaPiaoMxs);
            _db.AddInParameter(cmd, "FaPiaoId", DbType.AnsiStringFixedLength, faPiaoId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MFaPiaoMXInfo();
                    item.ChuTuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("ChuTuanRiQi"));
                    item.FaSongFangShi = rdr["SongChuFangShi"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("SongChuTime"))) item.FaSongTime = rdr.GetDateTime(rdr.GetOrdinal("SongChuTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.MXId = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    item.QianShouRenName = rdr["QianShouRenName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QianShouTime"))) item.QianShouTime = rdr.GetDateTime(rdr.GetOrdinal("QianShouTime"));
                    item.Status = (EyouSoft.Model.EnumType.FinStructure.FaPiaoFaSongStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.YouJiDanHao = rdr["YouJiDanHao"].ToString();
                    item.YouJiGongSiName = rdr["YouJiGongSiName"].ToString();

                    item.MingXiId = rdr["MingXiId"].ToString();
                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.TaiTou = rdr["TaiTou"].ToString();
                    item.KaiPiaoDanWei = rdr["KaiPiaoDanWei"].ToString();
                    item.FaPiaoHao = rdr["FaPiaoHao"].ToString();
                    item.MingXi = rdr["MingXi"].ToString();
                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.ZxsId = rdr["ZxsId"].ToString();
                    item.DingDanHao = rdr["DingDanHao"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// get ajax autocomplete fapiao dingdan info
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <returns></returns>
        EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo GetAjaxAutocompleteFaPiaoDingDanInfo(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return null;
            EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM view_Fin_FaPiaoDingDan WHERE DingDanId=@DingDanId AND MxId IS NOT NULL ");

            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MAjaxAutocompleteFaPiaoDingDanInfo();

                    info.DingDanHao = rdr["DingDanHao"].ToString();
                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                }
            }

            return info;
        }
        #endregion

        #region EyouSoft.IDAL.FinStructure.IFaPiao 成员
        /// <summary>
        /// 发票登记，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MFaPiaoInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_FaPiao_Insert");

            _db.AddInParameter(cmd, "FaPiaoId", DbType.AnsiStringFixedLength, info.FaPiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "ShenQingRiQi", DbType.DateTime, info.ShenQingRiQi);
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, info.KeHuId);
            _db.AddInParameter(cmd, "TaiTou", DbType.String, info.TaiTou);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "XiangMuMingXi", DbType.String, info.XiangMuMingXi);
            _db.AddInParameter(cmd, "KaiJuDanWeiName", DbType.String, info.KaiJuDanWeiName);
            _db.AddInParameter(cmd, "FaPiaoHao", DbType.String, info.FaPiaoHao);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "MxXml", DbType.String, CreateFaPiaoMxsXml(info.Mxs));
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

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
        /// 发票删除，返回1成功，其它失败
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Update(MFaPiaoInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_FaPiao_Update");

            _db.AddInParameter(cmd, "FaPiaoId", DbType.AnsiStringFixedLength, info.FaPiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "ShenQingRiQi", DbType.DateTime, info.ShenQingRiQi);
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, info.KeHuId);
            _db.AddInParameter(cmd, "TaiTou", DbType.String, info.TaiTou);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "XiangMuMingXi", DbType.String, info.XiangMuMingXi);
            _db.AddInParameter(cmd, "KaiJuDanWeiName", DbType.String, info.KaiJuDanWeiName);
            _db.AddInParameter(cmd, "FaPiaoHao", DbType.String, info.FaPiaoHao);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "MxXml", DbType.String, CreateFaPiaoMxsXml(info.Mxs));
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

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
        /// 发票删除，返回1成功，其它失败
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string faPiaoId, int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);

            _db.AddInParameter(cmd, "FaPiaoId", DbType.AnsiStringFixedLength, faPiaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取发票信息
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <returns></returns>
        public MFaPiaoInfo GetInfo(string faPiaoId)
        {
            MFaPiaoInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "FaPiaoId", DbType.AnsiStringFixedLength, faPiaoId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MFaPiaoInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.FaPiaoHao = rdr["FaPiaoHao"].ToString();
                    info.FaPiaoId = faPiaoId;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.KaiJuDanWeiName = rdr["KaiJuDanWeiName"].ToString();
                    info.KeHuId = rdr.GetString(rdr.GetOrdinal("KeHuId")).ToString();
                    info.KeHuName = rdr["KeHuName"].ToString();
                    info.Mxs = null;
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ShenQingRiQi = rdr.GetDateTime(rdr.GetOrdinal("ShenQingRiQi"));
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.FaPiaoFaSongStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.TaiTou = rdr["TaiTou"].ToString();
                    info.XiangMuMingXi = rdr["MingXi"].ToString();
                }
            }

            if (info != null) info.Mxs = GetFaPiaoMxs(faPiaoId);

            return info;
        }

        /// <summary>
        /// 获取发票信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息，[0:decimal:发票金额]</param>
        /// <returns></returns>
        public IList<MFaPiaoInfo> GetFaPiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MFaPiaoChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M };
            IList<MFaPiaoInfo> items = new List<MFaPiaoInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_FinFaPiao";
            string orderByString = " [IssueTime] DESC ";
            string sumString = "SUM(JinE) AS JinEHeJi";

            #region fields
            fields.Append(" DengJiId,KeHuId,TaiTou,JinE,Status,CompanyId,FaPiaoHao,IssueTime ");
            fields.Append(" ,(SELECT B.Name FROM tbl_Customer AS B WHERE B.Id=tbl_FinFaPiao.KeHuId) AS KeHuName  ");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.KeHuName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_Customer AS B WHERE B.Id=tbl_FinFaPiao.KeHuId AND B.[Name] LIKE '%{0}%') ", chaXun.KeHuName);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                if (chaXun.QuDate1.HasValue || chaXun.QuDate2.HasValue || !string.IsNullOrEmpty(chaXun.DingDanHao)||!string.IsNullOrEmpty(chaXun.FaPiaoHao))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_FinFaPiaoMx AS A1 WHERE A1.DengJiId=tbl_FinFaPiao.DengJiId ");

                    if (chaXun.QuDate1.HasValue)
                    {
                        query.AppendFormat(" AND A1.ChuTuanRiQi>'{0}' ", chaXun.QuDate1.Value.AddDays(-1));
                    }
                    if (chaXun.QuDate2.HasValue)
                    {
                        query.AppendFormat(" AND A1.ChuTuanRiQi<'{0}' ", chaXun.QuDate2.Value.AddDays(1));
                    }
                    if (!string.IsNullOrEmpty(chaXun.DingDanHao))
                    {
                        query.AppendFormat(" AND DingDanHao LIKE '%{0}%' ", chaXun.DingDanHao);
                    }
                    if (!string.IsNullOrEmpty(chaXun.FaPiaoHao))
                    {
                        query.AppendFormat(" AND FaPiaoHao LIKE '%{0}%' ", chaXun.FaPiaoHao);
                    }

                    query.AppendFormat(" ) ");
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MFaPiaoInfo();

                    item.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    item.FaPiaoHao = rdr["FaPiaoHao"].ToString();
                    item.FaPiaoId = rdr.GetString(rdr.GetOrdinal("DengJiId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.KeHuId = rdr.GetString(rdr.GetOrdinal("KeHuId")).ToString();
                    item.KeHuName = rdr["KeHuName"].ToString();
                    item.Status = (EyouSoft.Model.EnumType.FinStructure.FaPiaoFaSongStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.TaiTou = rdr["TaiTou"].ToString();                    

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) heJi[0] = rdr.GetDecimal(0);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.Mxs = GetFaPiaoMxs(item.FaPiaoId);
                }
            }

            return items;
        }

        /// <summary>
        /// 修改发票明细，返回1成功，其它失败
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <param name="items">发票明细信息集合</param>
        /// <returns></returns>
        public int UpdateMingXis(string faPiaoId, IList<MFaPiaoMXInfo> items)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_FaPiao_UpdateMxs");

            _db.AddInParameter(cmd, "FaPiaoId", DbType.AnsiStringFixedLength, faPiaoId);
            _db.AddInParameter(cmd, "MxXml", DbType.String, CreateFaPiaoMxsXml(items));
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
        /// 获取发票发送数量
        /// </summary>
        /// <param name="faPiaoId">发票编号</param>
        /// <returns></returns>
        public int GetFaSongShuLiang(string faPiaoId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetFaSongShuLiang);
            _db.AddInParameter(cmd, "FaPiaoId", DbType.AnsiStringFixedLength, faPiaoId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, FaPiaoFaSongStatus.已送出);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read()) return rdr.GetInt32(0);
            }

            return 0;
        }

        /// <summary>
        /// 获取自动完成发票订单信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo> GetAutocompleteFaPiaoDingDans(int companyId, string zxsId, EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingChaXunDanInfo chaXun)
        {
            IList<EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo> items = new List<EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo>();

            int topExpression = 10;

            #region sql
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat(" SELECT TOP(@TopExpression) A.* FROM view_Fin_FaPiaoDingDan AS A ");

            sql.AppendFormat(" WHERE A.CompanyId=@CompanyId AND A.ZxsId=@ZxsId AND A.MxId IS NULL ");
            sql.AppendFormat(" AND A.OrderStatus={0} ", (int)EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.KeHuId))
                {
                    sql.AppendFormat(" AND KeHuId='{0}' ", chaXun.KeHuId);
                }
                if (chaXun.NotInDingDanId != null && chaXun.NotInDingDanId.Count > 0)
                {
                    sql.AppendFormat(" AND DingDanId NOT IN({0}) ", Utils.GetSqlInExpression(chaXun.NotInDingDanId));
                }
                if (!string.IsNullOrEmpty(chaXun.DingDanHao))
                {
                    sql.AppendFormat(" AND DingDanHao LIKE'{0}%' ", chaXun.DingDanHao);
                }
                if (chaXun.TopExpression > 0) topExpression = chaXun.TopExpression;
            }

            sql.AppendFormat(" ORDER BY A.IssueTime DESC ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());

            _db.AddInParameter(cmd, "TopExpression", DbType.Int32, topExpression);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo();

                    item.DingDanHao = rdr["DingDanHao"].ToString();
                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));

                    items.Add(item);
                }
            }

            if ((items == null || items.Count == 0)&&chaXun!=null&&!string.IsNullOrEmpty(chaXun.DingDanId0))
            {
                if (items == null) items =new List<EyouSoft.Model.FinStructure.MAjaxAutocompleteFaPiaoDingDanInfo>();

                var item = GetAjaxAutocompleteFaPiaoDingDanInfo(chaXun.DingDanId0);
                if (item != null) items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// 获取发票明细信息
        /// </summary>
        /// <param name="mxId">明细编号</param>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public MFaPiaoMXInfo GetFaPiaoMxInfo(int mxId,string dingDanId)
        {
            string sql = " SELECT * FROM tbl_FinFaPiaoMx WHERE 1=1 ";

            if (mxId > 0)
            {
                sql += " AND Id=@MxId ";
            }

            if (!string.IsNullOrEmpty(dingDanId))
            {
                sql += " AND DingDanId=@DingDanId ";
            }

            MFaPiaoMXInfo info = null;
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "MxId", DbType.Int32, mxId);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MFaPiaoMXInfo();

                    info.ChuTuanRiQi = rdr.GetDateTime(rdr.GetOrdinal("ChuTuanRiQi"));
                    info.FaSongFangShi = rdr["SongChuFangShi"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("SongChuTime"))) info.FaSongTime = rdr.GetDateTime(rdr.GetOrdinal("SongChuTime"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.MXId = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    info.QianShouRenName = rdr["QianShouRenName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QianShouTime"))) info.QianShouTime = rdr.GetDateTime(rdr.GetOrdinal("QianShouTime"));
                    info.Status = (EyouSoft.Model.EnumType.FinStructure.FaPiaoFaSongStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.YouJiDanHao = rdr["YouJiDanHao"].ToString();
                    info.YouJiGongSiName = rdr["YouJiGongSiName"].ToString();

                    info.MingXiId = rdr["MingXiId"].ToString();
                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.TaiTou = rdr["TaiTou"].ToString();
                    info.KaiPiaoDanWei = rdr["KaiPiaoDanWei"].ToString();
                    info.FaPiaoHao = rdr["FaPiaoHao"].ToString();
                    info.MingXi = rdr["MingXi"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                    info.DingDanHao = rdr["DingDanHao"].ToString();

                }
            }

            return info;
        }
        #endregion
    }
}
