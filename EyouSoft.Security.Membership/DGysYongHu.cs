//供应商用户登录处理DAL 汪奇志 2015-05-13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using EyouSoft.Toolkit;

namespace EyouSoft.Security.Membership
{
    /// <summary>
    /// 供应商用户登录处理DAL
    /// </summary>
    internal class DGysYongHu : DALBase, IGysYongHu
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetYuMingInfo = "SELECT * FROM tbl_Pt_YuMing WHERE YuMing=@YuMing AND LeiXing=@LeiXing";
        const string SQL_SELECT_Login = "SELECT CompanyId,GysId,GysLxrId,LastLoginIP,LastLoginTime,OnlineSessionId,OnlineStatus,UserName,ContactName,Id,UserStatus,ContactMobile,ContactTel FROM [tbl_CompanyUser] ";
        const string SQL_INSERT_LoginLogwr = "INSERT INTO [tbl_Gys_YongHuLoginLog]([LogId],[GysId],[YongHuId],[CompanyId],[LoginTime],[LoginIp],[UserAgent],[LoginLeiXing]) VALUES (@LogId,@GysId,@YongHuId,@CompanyId,@LoginTime,@LoginIp,@UserAgent,@LoginLeiXing);";
        const string SQL_SELECT_GetGysInfo = "SELECT * FROM tbl_Gys_ZhuTi WHERE GysId=@GysId";
        const string SQL_UPDATE_SetOnlineStatus = "UPDATE [tbl_CompanyUser] SET [OnlineStatus]=@OnlineStatus,[OnlineSessionId]=@OnlineSessionId WHERE [Id]=@YongHuId";
        const string SQL_SELECT_GetZhanDianIdByXzqhdm = "SELECT ZhanDianId FROM tbl_Pt_ZhanDianXzqhdm WHERE Xzqhdm=@Xzqhdm;SELECT ZhanDianId FROM tbl_Pt_ZhanDianXzqhdm WHERE Xzqhdm=@Xzqhdm1;SELECT ZhanDianId FROM tbl_Pt_ZhanDianXzqhdm WHERE Xzqhdm=@Xzqhdm2";
        const string SQL_SELECT_GetZxsPeiZhiInfo = "SELECT * FROM tbl_Pt_ZxsKV WHERE CompanyId=@CompanyId AND ZxsId=@ZxsId";
        const string SQL_SELECT_GetXiTongPeiZhiInfo = "SELECT [FieldName],[FieldValue] FROM tbl_CompanySetting WHERE [Id]=@CompanyId;";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DGysYongHu()
        {
            _db = SystemStore;
        }
        #endregion 

        #region private members
        /// <summary>
        /// read yonghu info
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        EyouSoft.Model.SSOStructure.MGysYongHuInfo ReadYongHuInfo(DbCommand cmd)
        {
            EyouSoft.Model.SSOStructure.MGysYongHuInfo info = null;
            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.SSOStructure.MGysYongHuInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.GysId = rdr["GysId"].ToString();
                    info.GysLxrId = rdr.GetInt32(rdr.GetOrdinal("GysLxrId"));
                    info.LastLoginIp = rdr["LastLoginIP"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("LastLoginTime"))) info.LastLoginTime = rdr.GetDateTime(rdr.GetOrdinal("LastLoginTime"));
                    info.LoginTime = DateTime.Now;
                    info.OnlineSessionId = rdr["OnlineSessionId"].ToString();
                    info.OnlineStatus = (EyouSoft.Model.EnumType.CompanyStructure.UserOnlineStatus)rdr.GetByte(rdr.GetOrdinal("OnlineStatus"));
                    info.Username = rdr["UserName"].ToString();
                    info.XingMing = rdr["ContactName"].ToString();
                    info.YongHuId = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    info.YongHuStaus = (EyouSoft.Model.EnumType.CompanyStructure.UserStatus)rdr.GetByte(rdr.GetOrdinal("UserStatus"));
                    info.DianHua = rdr["ContactTel"].ToString();
                    info.ShouJi = rdr["ContactMobile"].ToString();
                }
            }

            if (info != null)
            {
                var gysInfo = GetGysInfo(info.GysId);
                if (gysInfo != null)
                {
                    info.GysName = gysInfo[0].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// get gys info
        /// </summary>
        /// <param name="gysId"></param>
        /// <returns></returns>
        object[] GetGysInfo(string gysId)
        {
            object[] obj = new object[] { "" };
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetGysInfo);
            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, gysId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    obj[0] = rdr["GysName"].ToString();
                }
            }

            return obj;
        }
        #endregion

        #region IGysYongHu 成员
        /// <summary>
        /// 获取域名信息
        /// </summary>
        /// <param name="yuMing">域名</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MYuMingInfo GetYuMingInfo(string yuMing)
        {
            EyouSoft.Model.PtStructure.MYuMingInfo info = null;
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetYuMingInfo);
            _db.AddInParameter(cmd, "YuMing", DbType.String, yuMing);
            _db.AddInParameter(cmd, "LeiXing", DbType.Int32, EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing.地接平台);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MYuMingInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.ErpYuMing = rdr["ErpYuMing"].ToString();
                    info.YuMing = yuMing;
                    info.ZxsId = rdr["ZxsId"].ToString();
                    info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing)rdr.GetInt32(rdr.GetOrdinal("LeiXing"));
                }
            }

            return info;
        }

        /// <summary>
        /// 获取域名信息集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MYuMingInfo> GetYuMings()
        {
            var items = new List<EyouSoft.Model.PtStructure.MYuMingInfo>();

            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_Pt_YuMing WHERE LeiXing=@LeiXing");
            _db.AddInParameter(cmd, "LeiXing", DbType.Int32, EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing.地接平台);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MYuMingInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.ErpYuMing = rdr["ErpYuMing"].ToString();
                    info.YuMing = rdr["YuMing"].ToString();
                    info.ZxsId = rdr["ZxsId"].ToString();
                    info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing)rdr.GetInt32(rdr.GetOrdinal("LeiXing"));
                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 用户登录，根据系统公司编号、用户名、用户密码获取用户信息
        /// </summary>
        /// <param name="companyId">系统公司编号</param>
        /// <param name="username">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        public EyouSoft.Model.SSOStructure.MGysYongHuInfo Login(int companyId, string username, EyouSoft.Model.CompanyStructure.PassWord pwd)
        {
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_Login + " WHERE [CompanyId]=@CID AND [UserName]=@UN AND [MD5Password]=@MD5PWD AND [IsDelete]='0' AND LeiXing=@LeiXing ");
            _db.AddInParameter(cmd, "CID", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "UN", DbType.String, username);
            _db.AddInParameter(cmd, "MD5PWD", DbType.String, pwd.MD5Password);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.供应商用户);

            return ReadYongHuInfo(cmd);
        }

        /// <summary>
        /// 用户登录，根据系统公司编号、用户名、用户编号、客户编号获取用户信息
        /// </summary>
        /// <param name="companyId">系统公司编号</param>
        /// <param name="username">登录账号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.SSOStructure.MGysYongHuInfo Login(int companyId, string username, int yongHuId, string gysId)
        {
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_Login + " WHERE [CompanyId]=@CID AND [UserName]=@UN AND [GysId]=@GysId AND [Id]=@YongHuId AND [IsDelete]='0' AND LeiXing=@LeiXing ");
            _db.AddInParameter(cmd, "CID", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "UN", DbType.String, username);
            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, gysId);
            _db.AddInParameter(cmd, "YongHuId", DbType.Int32, yongHuId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.供应商用户);

            return ReadYongHuInfo(cmd);
        }

        /// <summary>
        /// 写登录日志，用户登录时更新最后登录时间、在线状态、会话标识
        /// </summary>
        /// <param name="info">登录用户信息</param>
        /// <param name="loginType">登录类型</param>
        public void LoginLogwr(EyouSoft.Model.SSOStructure.MGysYongHuInfo info, Model.EnumType.CompanyStructure.UserLoginType loginType)
        {
            string cmdText = SQL_INSERT_LoginLogwr;

            if (loginType == EyouSoft.Model.EnumType.CompanyStructure.UserLoginType.用户登录)
            {
                cmdText += "UPDATE [tbl_CompanyUser] SET [LastLoginTime]=@LoginTime,[OnlineStatus]=@OnlineStatus,[OnlineSessionId]=@OnlineSessionId,[LastLoginIP]=@LoginIp WHERE [Id]=@YongHuId;";
            }

            DbCommand cmd = _db.GetSqlStringCommand(cmdText);

            _db.AddInParameter(cmd, "LogId", DbType.AnsiStringFixedLength, Guid.NewGuid().ToString());
            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, info.GysId);
            _db.AddInParameter(cmd, "YongHuId", DbType.Int32, info.YongHuId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "LoginTime", DbType.DateTime, info.LoginTime);
            _db.AddInParameter(cmd, "LoginIp", DbType.String, Utils.GetRemoteIP());
            _db.AddInParameter(cmd, "UserAgent", DbType.String, new EyouSoft.Toolkit.BrowserInfo().ToJsonString());
            _db.AddInParameter(cmd, "LoginLeiXing", DbType.Byte, loginType);
            _db.AddInParameter(cmd, "OnlineStatus", DbType.Byte, info.OnlineStatus);
            _db.AddInParameter(cmd, "OnlineSessionId", DbType.AnsiStringFixedLength, info.OnlineSessionId);

            DbHelper.ExecuteSql(cmd, _db);
        }

        /// <summary>
        /// 设置用户在线状态，返回1成功，其它失败
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="status">在线状态</param>
        /// <param name="onlineSessionId">用户会话状态标识</param>
        /// <returns></returns>
        public int SetOnlineStatus(int yongHuId, Model.EnumType.CompanyStructure.UserOnlineStatus status, string onlineSessionId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SetOnlineStatus);
            _db.AddInParameter(cmd, "OnlineStatus", DbType.Byte, status);
            _db.AddInParameter(cmd, "YongHuId", DbType.Int32, yongHuId);
            _db.AddInParameter(cmd, "OnlineSessionId", DbType.AnsiString, onlineSessionId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取专线商配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo GetZxsPeiZhiInfo(int companyId, string zxsId)
        {
            EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo info = new EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo();
            info.CompanyId = companyId;
            info.ZxsId = zxsId;

            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZxsPeiZhiInfo);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, zxsId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    string k = rdr["K"].ToString();
                    string v = rdr["V"].ToString();

                    if (string.IsNullOrEmpty(k)) continue;

                    switch (k)
                    {
                        case "DaYinMoBanFilepath": info.DaYinMoBanFilepath = v; break;
                        case "DaYinYeJiaoFilepath": info.DaYinYeJiaoFilepath = v; break;
                        case "DaYinYeMeiFilepath": info.DaYinYeMeiFilepath = v; break;
                        case "LogoFilepath": info.LogoFilepath = v; break;
                        case "SFKYHZH": info.SFKYHZH = v; break;
                        case "SFKZFFS": info.SFKZFFS = v; break;
                        case "TuZhangFilepath": info.TuZhangFilepath = v; break;
                        default: break;
                    }
                }
            }

            return info;
        }

        /// <summary>
        /// 获取系统配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public EyouSoft.Model.CompanyStructure.CompanyFieldSetting GetXiTongPeiZhiInfo(int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetXiTongPeiZhiInfo);
            _db.AddInParameter(cmd, "CompanyId", DbType.AnsiStringFixedLength, companyId);

            var setting = new EyouSoft.Model.CompanyStructure.CompanyFieldSetting();

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    string key = rdr["FieldName"].ToString();
                    string value = rdr["FieldValue"].ToString();

                    if (string.IsNullOrEmpty(key)) continue;

                    #region 配置键为字符串处理
                    switch (key)
                    {
                        //case "ReservationTime": setting.ReservationTime = Utils.GetInt(value); break;
                        //case "CompanyLogo": setting.CompanyLogo = value; break;
                        //case "PrintHeader": setting.PageHeadFile = value; break;
                        //case "PrintFooter": setting.PageFootFile = value; break;
                        //case "PrintTemplate": setting.TemplateFile = value; break;
                        //case "CompanyStamp": setting.CompanyStamp = value; break;
                        case "UserLoginLimitType": setting.UserLoginLimitType = (Model.EnumType.CompanyStructure.UserLoginLimitType)Utils.GetInt(value); break;
                        case "PrintPageWidth": setting.PrintPageWidth = Utils.GetInt(value); break;
                        case "SysLogoFilepath": setting.SysLogoFilepath = value; break;
                        //case "SFKYHZH": setting.SFKYHZH = value; break;
                        //case "SFKZFFS": setting.SFKZFFS = value; break;
                        default: break;
                    }
                    #endregion
                }

                setting.CompanyId = companyId;
            }

            return setting;
        }
        #endregion
    }
}
