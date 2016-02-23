//汪奇志 2014-10-21 报价信息相关
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
    /// 报价信息相关
    /// </summary>
    public class DBaoJia : DALBase, EyouSoft.IDAL.PtStructure.IBaoJia
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
        public DBaoJia()
        {
            _db = SystemStore;
        }
        #endregion  
      
        #region private members
        /// <summary>
        /// create fujian xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateFuJianXml(IList<EyouSoft.Model.PtStructure.MFuJianInfo> items)
        {
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append("<info  ");
                s.AppendFormat(" LeiXing=\"{0}\" ", (int)item.LeiXing);
                s.AppendFormat(" Filepath=\"{0}\" ", item.Filepath);
                s.Append(" >");
                s.AppendFormat("<MiaoShu><![CDATA[{0}]]></MiaoShu>", item.MiaoShu);
                s.AppendFormat("</info>");
            }
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// get baojia fujians
        /// </summary>
        /// <param name="baoJiaId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetBaoJiaFuJians(string baoJiaId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();

            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_Pt_BaoJiaFuJian WHERE BaoJiaId=@BaoJiaId ORDER BY FuJianId ASC ");
            _db.AddInParameter(cmd, "BaoJiaId", DbType.AnsiStringFixedLength, baoJiaId);

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

        #region IBaoJia 成员
        /// <summary>
        /// 报价信息新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int BaoJia_CU(EyouSoft.Model.PtStructure.MBaoJiaInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Pt_BaoJia_CU");
            _db.AddInParameter(cmd, "@BaoJiaId", DbType.AnsiStringFixedLength, info.BaoJiaId);
            _db.AddInParameter(cmd, "@BiaoTi", DbType.String, info.BiaoTi);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);
            _db.AddInParameter(cmd, "@ZxlbId", DbType.Int32,info.ZxlbId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@FuJianXml", DbType.String, CreateFuJianXml(info.FuJians));
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
        /// 删除报价信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        public int BaoJia_D(int companyId, string zxsId, string baoJiaId)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE tbl_Pt_BaoJia SET IsDelete='1' WHERE BaoJiaId=@BaoJiaId AND CompanyId=@CompanyId AND ZxsId=@ZxsId ");
            _db.AddInParameter(cmd, "@BaoJiaId", DbType.AnsiStringFixedLength, baoJiaId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 获取报价信息
        /// </summary>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MBaoJiaInfo GetInfo(string baoJiaId)
        {
            EyouSoft.Model.PtStructure.MBaoJiaInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_Pt_BaoJia WHERE BaoJiaId=@BaoJiaId");
            _db.AddInParameter(cmd, "@BaoJiaId", DbType.AnsiStringFixedLength, baoJiaId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MBaoJiaInfo();

                    info.BaoJiaId = baoJiaId;
                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            if (info != null)
            {
                info.FuJians = GetBaoJiaFuJians(baoJiaId);
            }

            return info;
        }

        /// <summary>
        /// 获取报价集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MBaoJiaInfo> GetBaoJias(int companyId, string zxsId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MBaoJiaChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MBaoJiaInfo> items = new List<EyouSoft.Model.PtStructure.MBaoJiaInfo>();

            string fields = "*,(SELECT A1.MingCheng FROM tbl_Pt_ZhuanXianLeiBie AS A1 WHERE A1.ZxlbId=tbl_Pt_BaoJia.ZxlbId) AS ZxlbName";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_BaoJia";
            string orderByString = " IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" CompanyId={0} AND IsDelete='0' ", companyId);
            sql.AppendFormat(" AND ZxsId='{0}' ", zxsId);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.BiaoTi))
                {
                    sql.AppendFormat(" AND BiaoTi LIKE '%{0}%' ", chaXun.BiaoTi);
                }
                if (chaXun.ZxlbId.HasValue)
                {
                    sql.AppendFormat(" AND ZxlbId={0} ", chaXun.ZxlbId.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MBaoJiaInfo();

                    info.BaoJiaId = rdr["BaoJiaId"].ToString();
                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = companyId;
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));
                    info.ZxsId = zxsId;
                    info.ZxlbName = rdr["ZxlbName"].ToString();

                    items.Add(info);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.FuJians = GetBaoJiaFuJians(item.BaoJiaId);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取最新报价信息
        /// </summary>
        /// <param name="baoJiaId">报价编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MBaoJiaInfo GetZuiXinBaoJiaInfo(string zxsId,int zxlbId)
        {
            EyouSoft.Model.PtStructure.MBaoJiaInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT TOP(1) * FROM tbl_Pt_BaoJia WHERE ZxsId=@ZxsId AND ZxlbId=@ZxlbId AND IsDelete='0' ORDER BY IssueTime DESC");
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@ZxlbId", DbType.Int32, zxlbId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MBaoJiaInfo();

                    info.BaoJiaId = rdr["BaoJiaId"].ToString();
                    info.BiaoTi = rdr["BiaoTi"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ZxlbId = rdr.GetInt32(rdr.GetOrdinal("ZxlbId"));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            if (info != null)
            {
                info.FuJians = GetBaoJiaFuJians(info.BaoJiaId);
            }

            return info;
        }
        #endregion
    }
}
