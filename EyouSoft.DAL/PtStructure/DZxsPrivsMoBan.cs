//专线商权限模板相关 汪奇志 2014-10-22
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
    /// 专线商权限模板相关
    /// </summary>
    public class DZxsPrivsMoBan : DALBase, EyouSoft.IDAL.PtStructure.IZxsPrivsMoBan
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
        public DZxsPrivsMoBan()
        {
            _db = SystemStore;
        }
        #endregion   
     
        #region private members

        #endregion


        #region IZxsPrivsMoBan 成员
        /// <summary>
        /// 写入权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo info)
        {
            var cmd = _db.GetSqlStringCommand("INSERT INTO [tbl_Pt_ZxsPrivsMoBan]([MoBanId],[MingCheng],[Privs1],[Privs2],[Privs3],[CompanyId],[OperatorId],[IssueTime])VALUES(@MoBanId,@MingCheng,@Privs1,@Privs2,@Privs3,@CompanyId,@OperatorId,@IssueTime)");

            _db.AddInParameter(cmd, "MoBanId", DbType.AnsiStringFixedLength, info.MoBanId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "Privs1", DbType.String, info.Privs1);
            _db.AddInParameter(cmd, "Privs2", DbType.String, info.Privs2);
            _db.AddInParameter(cmd, "Privs3", DbType.String, info.Privs3);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 修改权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo info)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE [tbl_Pt_ZxsPrivsMoBan] SET [MingCheng]=@MingCheng WHERE [MoBanId]=@MoBanId AND CompanyId=@CompanyId");

            _db.AddInParameter(cmd, "MoBanId", DbType.AnsiStringFixedLength, info.MoBanId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 删除权限模板信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="moBanId">模板编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string moBanId)
        {
            var cmd = _db.GetSqlStringCommand("DELETE FROM [tbl_Pt_ZxsPrivsMoBan] WHERE [MoBanId]=@MoBanId AND CompanyId=@CompanyId");

            _db.AddInParameter(cmd, "MoBanId", DbType.AnsiStringFixedLength, moBanId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 获取模板信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo> GetMoBans(int companyId)
        {
            IList<EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo> items = new List<EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM [tbl_Pt_ZxsPrivsMoBan] WHERE CompanyId=@CompanyId ORDER BY IssueTime ASC");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo();
                    item.CompanyId = companyId;
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.MingCheng = rdr["MingCheng"].ToString();
                    item.MoBanId = rdr["MoBanId"].ToString();
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.Privs1 = rdr["Privs1"].ToString();
                    item.Privs2 = rdr["Privs2"].ToString();
                    item.Privs3 = rdr["Privs3"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取模板信息
        /// </summary>
        /// <param name="moBanId">模板编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo GetInfo(string moBanId)
        {
            EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM [tbl_Pt_ZxsPrivsMoBan] WHERE MoBanId=@MoBanId");
            _db.AddInParameter(cmd, "MoBanId", DbType.AnsiStringFixedLength, moBanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MZxsPrivsMoBanInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.MoBanId = rdr["MoBanId"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.Privs1 = rdr["Privs1"].ToString();
                    info.Privs2 = rdr["Privs2"].ToString();
                    info.Privs3 = rdr["Privs3"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 设置模板权限，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="moBanId">模板编号</param>
        /// <param name="privs1">一级栏目</param>
        /// <param name="privs2">二级栏目</param>
        /// <param name="privs3">明细权限</param>
        /// <returns></returns>
        public int SheZhiPrivs(int companyId, string moBanId, string privs1, string privs2, string privs3)
        {
            var cmd = _db.GetSqlStringCommand("UPDATE [tbl_Pt_ZxsPrivsMoBan] SET Privs1=@Privs1,Privs2=@Privs2,Privs3=@Privs3 WHERE MoBanId=@MoBanId AND CompanyId=@CompanyId");
            _db.AddInParameter(cmd, "Privs1", DbType.String, privs1);
            _db.AddInParameter(cmd, "Privs2", DbType.String, privs2);
            _db.AddInParameter(cmd, "Privs3", DbType.String, privs3);
            _db.AddInParameter(cmd, "MoBanId", DbType.AnsiStringFixedLength, moBanId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        #endregion
    }
}
