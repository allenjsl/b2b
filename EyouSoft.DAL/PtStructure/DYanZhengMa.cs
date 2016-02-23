//汪奇志 2014-09-15 平台验证码相关数据访问类
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
    /// 平台验证码相关数据访问类
    /// </summary>
    public class DYanZhengMa:DALBase, EyouSoft.IDAL.PtStructure.IYanZhengMa
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
        public DYanZhengMa()
        {
            _db = SystemStore;
        }
        #endregion  
      
        #region private members
        #endregion

        #region IYanZhengMa 成员
        /// <summary>
        /// 写入验证码信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MYanZhengMaInfo info)
        {
            string sql = "UPDATE tbl_Pt_YanZhengMa SET [Status]=@Status1 WHERE YongHuId=@YongHuId AND LeiXing=@LeiXing AND [Status]=@Status2;";
            sql += "INSERT INTO [tbl_Pt_YanZhengMa]([YanZhengMaId],[YanZhengMa],[LeiXing],[IssueTime],[Status],[YongHuId]) VALUES (@YanZhengMaId,@YanZhengMa,@LeiXing,@IssueTime,@Status,@YongHuId);";
            var cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "Status1", DbType.Byte, EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus.已过期);
            _db.AddInParameter(cmd, "YongHuId", DbType.Int32, info.YongHuId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, info.LeiXing);
            _db.AddInParameter(cmd, "Status2", DbType.Byte, EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus.有效);
            _db.AddInParameter(cmd, "YanZhengMaId", DbType.AnsiStringFixedLength, info.YanZhengMaId);
            _db.AddInParameter(cmd, "YanZhengMa", DbType.String, info.YanZhengMa);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 获取验证码信息
        /// </summary>
        /// <param name="yanZhengMaId">验证码编号</param>
        /// <param name="yanZhengMa">验证码</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MYanZhengMaInfo GetInfo(string yanZhengMaId, string yanZhengMa, EyouSoft.Model.EnumType.PtStructure.YanZhengMaLeiXing leiXing)
        {
            EyouSoft.Model.PtStructure.MYanZhengMaInfo info = null;
            string sql = "SELECT * FROM tbl_Pt_YanZhengMa WHERE YanZhengMaId=@YanZhengMaId AND YanZhengMa=@YanZhengMa AND LeiXing=@LeiXing";
            var cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "YanZhengMaId", DbType.AnsiStringFixedLength, yanZhengMaId);
            _db.AddInParameter(cmd, "YanZhengMa", DbType.String, yanZhengMa);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, leiXing);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MYanZhengMaInfo();

                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.YanZhengMaLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.Status = (EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.YanZhengMa = rdr["YanZhengMa"].ToString();
                    info.YanZhengMaId = rdr["YanZhengMaId"].ToString();
                    info.YongHuId = rdr.GetInt32(rdr.GetOrdinal("YongHuId"));
                }
            }

            return info;
        }

        /// <summary>
        /// 设置验证码状态，返回1成功，其它失败
        /// </summary>
        /// <param name="yanZhengMaId">验证码编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SetStatus(string yanZhengMaId, EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus status)
        {
            string sql = "UPDATE tbl_Pt_YanZhengMa SET [Status]=@Status WHERE YanZhengMaId=@YanZhengMaId";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "YanZhengMaId", DbType.AnsiStringFixedLength, yanZhengMaId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        #endregion
    }
}
