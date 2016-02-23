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
    /// 同行用户登录数据访问类
    /// </summary>
    internal class DTongHangYongHu : DALBase, ITongHangYongHu
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetYuMingInfo = "SELECT * FROM tbl_Pt_YuMing WHERE YuMing=@YuMing AND LeiXing=@LeiXing";
        const string SQL_SELECT_Login = "SELECT CompanyId,KeHuId,KeHuLxrId,LastLoginIP,LastLoginTime,OnlineSessionId,OnlineStatus,UserName,ContactName,Id,UserStatus,ContactMobile,ContactTel,DanJuTaiTouMingCheng,DanJuTaiTouDiZhi,DanJuDaYinMoBan,DanJuTaiTouDianHua FROM [tbl_CompanyUser] ";
        const string SQL_INSERT_LoginLogwr = "INSERT INTO [tbl_Pt_YongHuLoginLog]([LogId],[KeHuId],[YongHuId],[CompanyId],[LoginTime],[LoginIp],[UserAgent],[LoginLeiXing]) VALUES (@LogId,@KeHuId,@YongHuId,@CompanyId,@LoginTime,@LoginIp,@UserAgent,@LoginLeiXing);";
        const string SQL_SELECT_GetKeHuInfo = "SELECT * FROM tbl_Customer WHERE Id=@KeHuId";
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
        public DTongHangYongHu()
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
        EyouSoft.Model.SSOStructure.MTongHangYongHuInfo ReadYongHuInfo(DbCommand cmd)
        {
            EyouSoft.Model.SSOStructure.MTongHangYongHuInfo info = null;
            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.SSOStructure.MTongHangYongHuInfo();

                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.KeHuId = rdr["KeHuId"].ToString();
                    info.KeHuLxrId = rdr.GetInt32(rdr.GetOrdinal("KeHuLxrId"));
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
                    info.DanJuTaiTouDiZhi = rdr["DanJuTaiTouDiZhi"].ToString();
                    info.DanJuTaiTouMingCheng = rdr["DanJuTaiTouMingCheng"].ToString();
                    info.DanJuDaYinMoBan = rdr["DanJuDaYinMoBan"].ToString();
                    info.DanJuTaiTouDianHua = rdr["DanJuTaiTouDianHua"].ToString();
                }
            }

            if (info != null)
            {
                var keHuInfo = GetKeHuInfo(info.KeHuId);
                if (keHuInfo != null)
                {
                    info.KeHuShenHeStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus)(byte)keHuInfo[0];
                    info.KeHuName = keHuInfo[1].ToString();
                    info.KeHuLogo = keHuInfo[2].ToString();
                    info.KeHuDiZhi = keHuInfo[3].ToString();
                    info.KeHuDanJuDaYinMoBan = keHuInfo[4].ToString();
                    info.KeHuDianHua = keHuInfo[5].ToString();
                }
                else
                {
                    info.KeHuShenHeStatus = EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.未审核;
                    info.KeHuName = string.Empty;
                    info.KeHuLogo = string.Empty;
                    info.KeHuDiZhi = string.Empty;
                    info.KeHuDanJuDaYinMoBan = string.Empty;
                    info.KeHuDianHua = string.Empty;
                }
            }

            return info;
        }

        /// <summary>
        /// get kehu info
        /// </summary>
        /// <param name="keHuId"></param>
        /// <returns></returns>
        object[] GetKeHuInfo(string keHuId)
        {
            object[] obj = new object[] { 0, "", "", "", "", "" };
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetKeHuInfo);
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, keHuId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    obj[0] = rdr.GetByte(rdr.GetOrdinal("ShenHeStatus"));
                    obj[1] = rdr["Name"].ToString();
                    obj[2] = rdr["Logo"].ToString();
                    obj[3] = rdr["Adress"].ToString();
                    obj[4] = rdr["DanJuDaYinMoBan"].ToString();
                    obj[5] = rdr["GongSiDianHua"].ToString();
                }
            }

            return obj;
        }
        #endregion

        #region ITongHangYongHu 成员
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
            _db.AddInParameter(cmd, "LeiXing", DbType.Int32, EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing.同行平台);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MYuMingInfo();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.ErpYuMing = rdr["ErpYuMing"].ToString();
                    info.YuMing = yuMing;
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 用户登录，根据系统公司编号、用户名、用户密码获取用户信息
        /// </summary>
        /// <param name="companyId">系统公司编号</param>
        /// <param name="username">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        public EyouSoft.Model.SSOStructure.MTongHangYongHuInfo Login(int companyId, string username, EyouSoft.Model.CompanyStructure.PassWord pwd)
        {
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_Login + " WHERE [CompanyId]=@CID AND [UserName]=@UN AND [MD5Password]=@MD5PWD AND [IsDelete]='0' AND LeiXing=@LeiXing ");
            _db.AddInParameter(cmd, "CID", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "UN", DbType.String, username);
            _db.AddInParameter(cmd, "MD5PWD", DbType.String, pwd.MD5Password);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.同行用户);

            return ReadYongHuInfo(cmd);
        }

        /// <summary>
        /// 用户登录，根据系统公司编号、用户名、用户编号、客户编号获取用户信息
        /// </summary>
        /// <param name="companyId">系统公司编号</param>
        /// <param name="username">登录账号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <returns></returns>
        public EyouSoft.Model.SSOStructure.MTongHangYongHuInfo Login(int companyId, string username, int yongHuId, string keHuId)
        {
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_Login + " WHERE [CompanyId]=@CID AND [UserName]=@UN AND [KeHuId]=@KeHuId AND [Id]=@YongHuId AND [IsDelete]='0' AND LeiXing=@LeiXing ");
            _db.AddInParameter(cmd, "CID", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "UN", DbType.String, username);
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, keHuId);
            _db.AddInParameter(cmd, "YongHuId", DbType.Int32, yongHuId);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.同行用户);

            return ReadYongHuInfo(cmd);
        }

        /// <summary>
        /// 写登录日志，用户登录时更新最后登录时间、在线状态、会话标识
        /// </summary>
        /// <param name="info">登录用户信息</param>
        /// <param name="loginType">登录类型</param>
        public void LoginLogwr(EyouSoft.Model.SSOStructure.MTongHangYongHuInfo info, Model.EnumType.CompanyStructure.UserLoginType loginType)
        {
            string cmdText = SQL_INSERT_LoginLogwr;

            if (loginType == EyouSoft.Model.EnumType.CompanyStructure.UserLoginType.用户登录)
            {
                cmdText += "UPDATE [tbl_CompanyUser] SET [LastLoginTime]=@LoginTime,[OnlineStatus]=@OnlineStatus,[OnlineSessionId]=@OnlineSessionId,[LastLoginIP]=@LoginIp WHERE [Id]=@YongHuId;";
            }

            DbCommand cmd = _db.GetSqlStringCommand(cmdText);

            _db.AddInParameter(cmd, "LogId", DbType.AnsiStringFixedLength, Guid.NewGuid().ToString());
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, info.KeHuId);
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
        /// 根据行政区划代码获取站点编号
        /// </summary>
        /// <param name="xzqhdm">行政区划代码</param>
        /// <returns></returns>
        public int GetZhanDianIdByXzqhdm(string xzqhdm)
        {
            string xzqhdm1 = xzqhdm;
            string xzqhdm2 = xzqhdm;

            if (xzqhdm1.Length > 4) xzqhdm1 = xzqhdm1.Substring(0, 4);
            if (xzqhdm2.Length > 2) xzqhdm2 = xzqhdm2.Substring(0, 2);

            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetZhanDianIdByXzqhdm);
            _db.AddInParameter(cmd, "Xzqhdm", DbType.String, xzqhdm);
            _db.AddInParameter(cmd, "Xzqhdm1", DbType.String, xzqhdm1);
            _db.AddInParameter(cmd, "Xzqhdm2", DbType.String, xzqhdm2);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetInt32(0);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    return rdr.GetInt32(0);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    return rdr.GetInt32(0);
                }
            }

            return 0;
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
