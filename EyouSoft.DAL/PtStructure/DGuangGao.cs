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
    /// 平台广告信息相关
    /// </summary>
    public class DGuangGao : DALBase,EyouSoft.IDAL.PtStructure.IGuangGao
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_Pt_GuangGao]([GuangGaoId],[CompanyId],[WeiZhi],[MingCheng],[Filepath],[Url],[NeiRong],[IssueTime],[OperatorId],[PaiXuId],[Status]) VALUES (@GuangGaoId,@CompanyId,@WeiZhi,@MingCheng,@Filepath,@Url,@NeiRong,@IssueTime,@OperatorId,@PaiXuId,@Status);";
        const string SQL_UPDATE_Update = "UPDATE [tbl_Pt_GuangGao] SET [WeiZhi]=@WeiZhi,[MingCheng]=@MingCheng,[Filepath]=@Filepath,[Url]=@Url,[NeiRong]=@NeiRong,[PaiXuId]=@PaiXuId,[Status]=@Status WHERE [GuangGaoId]=@GuangGaoId;";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_Pt_GuangGaoFuJian] WHERE [GuangGaoId]=@GuangGaoId;DELETE FROM [tbl_Pt_GuangGao] WHERE [GuangGaoId]=@GuangGaoId";
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_Pt_GuangGao] WHERE [GuangGaoId]=@GuangGaoId";
        const string SQL_SELECT_GetGuangGaoFuJians = "SELECT * FROM tbl_Pt_GuangGaoFuJian WHERE GuangGaoId=@GuangGaoId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DGuangGao()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// get guanggao fujians
        /// </summary>
        /// <param name="guangGaoId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetGuangGaoFuJians(string guangGaoId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();

            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetGuangGaoFuJians);
            _db.AddInParameter(cmd, "GuangGaoId", DbType.AnsiStringFixedLength, guangGaoId);

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

        #region IGuangGao 成员
        /// <summary>
        /// 新增广告，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MGuangGaoInfo info)
        {
            string sql = SQL_INSERT_Insert;
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_GuangGaoFuJian]([GuangGaoId],[LeiXing],[Filepath],[MiaoShu])VALUES(@GuangGaoId,0,'{0}',''); ", item.Filepath);
                }
            }

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "GuangGaoId", DbType.AnsiStringFixedLength, info.GuangGaoId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "WeiZhi", DbType.Byte, info.WeiZhi);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "Filepath", DbType.String, info.Filepath);
            _db.AddInParameter(cmd, "Url", DbType.String, info.Url);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 修改广告，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MGuangGaoInfo info)
        {
            string sql = SQL_UPDATE_Update;
            sql += " DELETE FROM [tbl_Pt_GuangGaoFuJian] WHERE [GuangGaoId]=@GuangGaoId; ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_GuangGaoFuJian]([GuangGaoId],[LeiXing],[Filepath],[MiaoShu])VALUES(@GuangGaoId,0,'{0}',''); ", item.Filepath);
                }
            }

            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "GuangGaoId", DbType.AnsiStringFixedLength, info.GuangGaoId);
            _db.AddInParameter(cmd, "WeiZhi", DbType.Byte, info.WeiZhi);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "Filepath", DbType.String, info.Filepath);
            _db.AddInParameter(cmd, "Url", DbType.String, info.Url);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 删除广告，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="guangGaoId">广告编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string guangGaoId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "GuangGaoId", DbType.AnsiStringFixedLength, guangGaoId);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 获取广告信息
        /// </summary>
        /// <param name="guangGaoId">广告编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MGuangGaoInfo GetInfo(string guangGaoId)
        {
            EyouSoft.Model.PtStructure.MGuangGaoInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "GuangGaoId", DbType.AnsiStringFixedLength, guangGaoId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MGuangGaoInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.Filepath = rdr["Filepath"].ToString();
                    info.GuangGaoId = guangGaoId;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.NeiRong = rdr["NeiRong"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.Url = rdr["Url"].ToString();
                    info.WeiZhi = (EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi)rdr.GetByte(rdr.GetOrdinal("WeiZhi"));
                    info.Status= (EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                }
            }

            if (info != null) info.FuJians = GetGuangGaoFuJians(guangGaoId);

            return info;
        }

        /// <summary>
        /// 获取广告集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MGuangGaoInfo> GetGuangGaos(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MGuangGaoInfo> items = new List<EyouSoft.Model.PtStructure.MGuangGaoInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_GuangGao";
            string orderByString = " PaiXuId ASC,IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.MingCheng))
                {
                    sql.AppendFormat(" AND MingCheng LIKE '%{0}%' ", chaXun.MingCheng);
                }
                if (chaXun.WeiZhi.HasValue)
                {
                    sql.AppendFormat(" AND WeiZhi={0} ", (int)chaXun.WeiZhi.Value);
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
                    var info = new EyouSoft.Model.PtStructure.MGuangGaoInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.Filepath = rdr["Filepath"].ToString();
                    info.GuangGaoId = rdr["GuangGaoId"].ToString();
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.NeiRong = rdr["NeiRong"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.Url = rdr["Url"].ToString();
                    info.WeiZhi = (EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi)rdr.GetByte(rdr.GetOrdinal("WeiZhi"));
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus)rdr.GetByte(rdr.GetOrdinal("Status"));

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置广告状态，返回1成功，其它失败
        /// </summary>
        /// <param name="guangGaoId">广告编号</param>
        /// <param name="status">广告状态</param>
        /// <returns></returns>
        public int SheZhiGuangGaoStatus(string guangGaoId, EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus status)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE [tbl_Pt_GuangGao] SET [Status]=@Status WHERE GuangGaoId=@GuangGaoId");
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "GuangGaoId", DbType.AnsiStringFixedLength, guangGaoId);
            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }
        #endregion
    }
}
