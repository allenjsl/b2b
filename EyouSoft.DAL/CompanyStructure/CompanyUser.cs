using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;

namespace EyouSoft.DAL.CompanyStructure
{
    /// <summary>
    /// 用户信息数据层
    /// </summary>
    public class CompanyUser : DALBase, IDAL.CompanyStructure.ICompanyUser
    {
        #region 变量

        private const string SqlCompanyUserRemove = "update tbl_CompanyUser set IsDelete = '1' where Id in({0}) AND IsAdmin = '0' ";
        //private const string SqlCompanyUserDelete = " delete tbl_CompanyUser where Id in({0}) ";
        private const string SqlSetUserEnable = " update tbl_CompanyUser set UserStatus = @UserStatus where Id = @Id;";

        private Database _db;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CompanyUser()
        {
            _db = this.SystemStore;


        }
        #endregion

        #region ICompanyUser 成员

        /// <summary>
        /// 判断E-MAIL是否已存在
        /// </summary>
        /// <param name="email">email地址</param>
        /// <param name="userId">当前修改Email的用户ID</param>
        /// <returns></returns>
        public bool IsExistsEmail(string email, int userId,int companyId)
        {
            if (string.IsNullOrEmpty(email)) return false;

            var strSql = new StringBuilder();
            strSql.Append(" select count(Id) from tbl_CompanyUser where ContactEmail = @ContactEmail AND CompanyId=@CompanyId AND IsDelete='0'  ");
            if (userId > 0) strSql.AppendFormat(" and Id <> {0} ", userId);
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "ContactEmail", DbType.String, email);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);

            using (IDataReader rdr = DbHelper.ExecuteReader(dc, _db))
            {
                if (rdr.Read())
                {
                    if (rdr.GetInt32(0) > 0) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="companyId">当前公司编号</param>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        public bool IsExists(int id, string userName, int companyId)
        {
            if (string.IsNullOrEmpty(userName) || companyId <= 0) return false;

            var strSql = new StringBuilder();
            strSql.Append(" select count(Id) from tbl_CompanyUser where UserName = @UserName and CompanyId = @CompanyId AND IsDelete='0' ");
            if (id > 0) strSql.AppendFormat(" and Id <> {0} ", id);
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "UserName", DbType.String, userName);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);

            using (IDataReader rdr = DbHelper.ExecuteReader(dc, _db))
            {
                if (rdr.Read())
                {
                    if (rdr.GetInt32(0) > 0) return true;
                }
            }

            return false;
        }
        
        /*/// <summary>
        /// 真实删除用户信息
        /// </summary>
        /// <param name="userIdList">用户ID列表</param>
        /// <returns></returns>
        public bool Delete(params int[] userIdList)
        {
            if (userIdList == null || userIdList.Length <= 0) return false;

            DbCommand dc = this._db.GetSqlStringCommand(string.Format(SqlCompanyUserDelete, GetIdsByArr(userIdList)));
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }*/

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model">用户信息实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(Model.CompanyStructure.CompanyUser model)
        {
            if (model == null || model.PassWordInfo == null || model.PersonInfo == null) return false;

            var strSql = new StringBuilder();

            #region sql 拼接

            strSql.Append(" declare @userId int; ");
            strSql.Append(
                @" INSERT INTO [tbl_CompanyUser]
                    ([CompanyId],[UserName],[Password],[MD5Password],[ContactName],[ContactSex],[ContactTel],[ContactFax],[ContactMobile]
                    ,[ContactEmail],[QQ],[MSN],[JobName],[RoleID],[PermissionList],[PeopProfile],[Remark]
                    ,[IsDelete],[UserStatus],[IsAdmin],[IssueTime],[DepartId],[SuperviseDepartId],[OnlineStatus],[OnlineSessionId],[ZxsId],[LeiXing],[KeHuId],[KeHuLxrId],[WeiXinHao]) ");
            strSql.Append(" VALUES ");
            strSql.Append(
                @" (@CompanyId,@UserName,@Password,@MD5Password,@ContactName,@ContactSex,@ContactTel,@ContactFax,@ContactMobile
                    ,@ContactEmail,@QQ,@MSN,@JobName,@RoleID,@PermissionList,@PeopProfile,@Remark
                    ,@IsDelete,@UserStatus,@IsAdmin,@IssueTime,@DepartId,@SuperviseDepartId,@OnlineStatus,@OnlineSessionId,@ZxsId,@LeiXing,'',0,@WeiXinHao); ");
            strSql.Append(" select @userId = @@identity; ");
            if (model.UserBank != null && model.UserBank.Any())
            {
                foreach (var t in model.UserBank)
                {
                    if (string.IsNullOrEmpty(t.BankName)
                        || string.IsNullOrEmpty(t.BankNo)
                        || string.IsNullOrEmpty(t.AccountName)) continue;

                    if (string.IsNullOrEmpty(t.UserBankId)) t.UserBankId = Guid.NewGuid().ToString();

                    strSql.AppendFormat(
                        " insert into tbl_UserAccount (Id,UserId,AccountName,BankName,BankNo) values ('{0}',@userId,'{1}','{2}','{3}'); ",
                        t.UserBankId,
                        t.AccountName,
                        t.BankName,
                        t.BankNo);
                }
            }

            strSql.Append(" select @userId; ");

            #endregion

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            #region 参数 赋值

            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "UserName", DbType.String, model.UserName);
            _db.AddInParameter(dc, "Password", DbType.String, model.PassWordInfo.NoEncryptPassword);
            _db.AddInParameter(dc, "MD5Password", DbType.String, model.PassWordInfo.MD5Password);
            _db.AddInParameter(dc, "ContactName", DbType.String, model.PersonInfo.ContactName);
            _db.AddInParameter(dc, "ContactSex", DbType.AnsiStringFixedLength, (int)model.PersonInfo.ContactSex);
            _db.AddInParameter(dc, "ContactTel", DbType.String, model.PersonInfo.ContactTel);
            _db.AddInParameter(dc, "ContactFax", DbType.String, model.PersonInfo.ContactFax);
            _db.AddInParameter(dc, "ContactMobile", DbType.String, model.PersonInfo.ContactMobile);
            _db.AddInParameter(dc, "ContactEmail", DbType.String, model.PersonInfo.ContactEmail);
            _db.AddInParameter(dc, "QQ", DbType.String, model.PersonInfo.QQ);
            _db.AddInParameter(dc, "MSN", DbType.String, model.PersonInfo.MSN);
            _db.AddInParameter(dc, "JobName", DbType.String, model.PersonInfo.JobName);
            _db.AddInParameter(dc, "RoleID", DbType.Int32, model.RoleID);
            _db.AddInParameter(dc, "PermissionList", DbType.String, model.PermissionList);
            _db.AddInParameter(dc, "PeopProfile", DbType.String, model.PersonInfo.PeopProfile);
            _db.AddInParameter(dc, "Remark", DbType.String, model.PersonInfo.Remark);
            _db.AddInParameter(dc, "IsDelete", DbType.AnsiStringFixedLength, '0');
            _db.AddInParameter(dc, "UserStatus", DbType.Byte, (int)Model.EnumType.CompanyStructure.UserStatus.正常);
            _db.AddInParameter(dc, "IsAdmin", DbType.AnsiStringFixedLength, model.IsAdmin ? "1" : "0");
            _db.AddInParameter(dc, "IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(dc, "DepartId", DbType.Int32, model.DepartId);
            _db.AddInParameter(dc, "SuperviseDepartId", DbType.Int32, model.SuperviseDepartId);
            _db.AddInParameter(dc, "OnlineStatus", DbType.Byte, (int)Model.EnumType.CompanyStructure.UserOnlineStatus.Offline);
            _db.AddInParameter(dc, "OnlineSessionId", DbType.AnsiStringFixedLength, string.Empty);
            _db.AddInParameter(dc, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            _db.AddInParameter(dc, "LeiXing", DbType.Byte,model.LeiXing);
            _db.AddInParameter(dc, "WeiXinHao", DbType.String, model.WeiXinHao);
            #endregion

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null || Toolkit.Utils.GetInt(obj.ToString()) <= 0)
            {
                return false;
            }

            model.ID = Toolkit.Utils.GetInt(obj.ToString());
            return true;
        }
        /// <summary>
        /// 修改用户基本信息[不更改密码]
        /// </summary>
        /// <param name="model">用户信息实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Update(Model.CompanyStructure.CompanyUser model)
        {
            if (model == null || model.PassWordInfo == null || model.PersonInfo == null || model.ID <= 0) return false;

            var strSql = new StringBuilder();

            #region sql 拼接

            strSql.Append(
                @" UPDATE [tbl_CompanyUser] SET 
                [UserName] = @UserName,[ContactName] = @ContactName,
                [ContactSex] = @ContactSex,[ContactTel] = @ContactTel,[ContactFax] = @ContactFax,[ContactMobile] = @ContactMobile,
                [ContactEmail] = @ContactEmail,[QQ] = @QQ,[MSN] = @MSN,[JobName] = @JobName,[PeopProfile] = @PeopProfile,
                [Remark] = @Remark,[DepartId] = @DepartId,[SuperviseDepartId] = @SuperviseDepartId,WeiXinHao=@WeiXinHao ");
            strSql.Append("  WHERE Id = @Id; ");

            if (model.UserBank != null && model.UserBank.Any())
            {
                var list = new List<string>();
                foreach (var t in model.UserBank)
                {
                    if (string.IsNullOrEmpty(t.BankName)
                        || string.IsNullOrEmpty(t.BankNo)
                        || string.IsNullOrEmpty(t.AccountName)) continue;

                    if (string.IsNullOrEmpty(t.UserBankId)) t.UserBankId = Guid.NewGuid().ToString();

                    //存在则修改账户，不存在则新增账户
                    strSql.AppendFormat(
                        " if exists (select 1 from tbl_UserAccount as a where a.UserId = @Id and a.Id = '{0}' ) ",
                        t.UserBankId);
                    strSql.Append(" begin ");
                    strSql.AppendFormat(
                        " update tbl_UserAccount set AccountName = '{0}',BankName = '{1}',BankNo = '{2}' where UserId = @Id and Id = '{3}'; ",
                        t.AccountName,
                        t.BankName,
                        t.BankNo,
                        t.UserBankId);
                    strSql.Append(" end ");
                    strSql.Append(" else ");
                    strSql.Append(" begin ");
                    strSql.AppendFormat(
                        " insert into tbl_UserAccount (Id,UserId,AccountName,BankName,BankNo) values ('{0}',@Id,'{1}','{2}','{3}'); ",
                        t.UserBankId,
                        t.AccountName,
                        t.BankName,
                        t.BankNo);
                    strSql.Append(" end ");

                    list.Add(t.UserBankId);
                }

                //删除不包含在集合之内的
                strSql.AppendFormat(
                    " delete from tbl_UserAccount where UserId = @Id and Id not in ({0}) ", GetIdsByArr(list.ToArray()));
            }

            #endregion

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            #region 参数 赋值

            _db.AddInParameter(dc, "UserName", DbType.String, model.UserName);
            _db.AddInParameter(dc, "ContactName", DbType.String, model.PersonInfo.ContactName);
            _db.AddInParameter(dc, "ContactSex", DbType.AnsiStringFixedLength, (int)model.PersonInfo.ContactSex);
            _db.AddInParameter(dc, "ContactTel", DbType.String, model.PersonInfo.ContactTel);
            _db.AddInParameter(dc, "ContactFax", DbType.String, model.PersonInfo.ContactFax);
            _db.AddInParameter(dc, "ContactMobile", DbType.String, model.PersonInfo.ContactMobile);
            _db.AddInParameter(dc, "ContactEmail", DbType.String, model.PersonInfo.ContactEmail);
            _db.AddInParameter(dc, "QQ", DbType.String, model.PersonInfo.QQ);
            _db.AddInParameter(dc, "MSN", DbType.String, model.PersonInfo.MSN);
            _db.AddInParameter(dc, "JobName", DbType.String, model.PersonInfo.JobName);
            _db.AddInParameter(dc, "PeopProfile", DbType.String, model.PersonInfo.PeopProfile);
            _db.AddInParameter(dc, "Remark", DbType.String, model.PersonInfo.Remark);
            _db.AddInParameter(dc, "DepartId", DbType.Int32, model.DepartId);
            _db.AddInParameter(dc, "SuperviseDepartId", DbType.Int32, model.SuperviseDepartId);
            _db.AddInParameter(dc, "Id", DbType.Int32, model.ID);
            _db.AddInParameter(dc, "WeiXinHao", DbType.String, model.WeiXinHao);

            #endregion

            return DbHelper.ExecuteSqlTrans(dc, _db) > 0 ? true : false;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="password">密码实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool UpdatePassWord(int id, Model.CompanyStructure.PassWord password)
        {
            if (id <= 0 || password == null || string.IsNullOrEmpty(password.NoEncryptPassword)
                || string.IsNullOrEmpty(password.MD5Password)) return false;

            DbCommand dc =
                _db.GetSqlStringCommand(
                    " Update tbl_CompanyUser set Password = @Password,MD5Password = @MD5Password where Id = @Id ");

            #region 参数 赋值

            _db.AddInParameter(dc, "Password", DbType.String, password.NoEncryptPassword);
            _db.AddInParameter(dc, "MD5Password", DbType.String, password.MD5Password);
            _db.AddInParameter(dc, "Id", DbType.Int32, id);

            #endregion

            return DbHelper.ExecuteSqlTrans(dc, _db) > 0 ? true : false;
        }
        /// <summary>
        /// 根据用户编号获取用户信息实体
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>用户信息实体</returns>
        public Model.CompanyStructure.CompanyUser GetUserInfo(int userId)
        {
            if (userId <= 0) return null;

            var strSql = new StringBuilder();
            strSql.Append(" SELECT A.*,(SELECT A1.DepartName FROM tbl_CompanyDepartment AS A1 WHERE A1.Id=A.DepartId) AS DeptName,(SELECT A1.Status FROM [tbl_CustomerContactInfo] AS A1 WHERE A1.YongHuId=A.Id) AS KeHuLxrStatus FROM [tbl_CompanyUser] AS A where A.[Id]=@Id; ");
            strSql.Append(" SELECT A.* FROM [tbl_UserAccount] AS A where A.UserId = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.Int32, userId);

            Model.CompanyStructure.CompanyUser model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new Model.CompanyStructure.CompanyUser();
                    model.PassWordInfo = new EyouSoft.Model.CompanyStructure.PassWord();
                    model.PersonInfo = new EyouSoft.Model.CompanyStructure.ContactPersonInfo();

                    #region 用户信息

                    if (!dr.IsDBNull(dr.GetOrdinal("Id"))) model.ID = dr.GetInt32(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId"))) model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UserName"))) model.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Password")))
                        model.PassWordInfo.NoEncryptPassword = dr.GetString(dr.GetOrdinal("Password"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactName")))
                        model.PersonInfo.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactSex")))
                        model.PersonInfo.ContactSex =
                            (Model.EnumType.CompanyStructure.Sex)
                            Toolkit.Utils.GetInt(dr.GetString(dr.GetOrdinal("ContactSex")));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactTel")))
                        model.PersonInfo.ContactTel = dr.GetString(dr.GetOrdinal("ContactTel"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactFax")))
                        model.PersonInfo.ContactFax = dr.GetString(dr.GetOrdinal("ContactFax"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactMobile")))
                        model.PersonInfo.ContactMobile = dr.GetString(dr.GetOrdinal("ContactMobile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactEmail")))
                        model.PersonInfo.ContactEmail = dr.GetString(dr.GetOrdinal("ContactEmail"));
                    if (!dr.IsDBNull(dr.GetOrdinal("QQ")))
                        model.PersonInfo.QQ = dr.GetString(dr.GetOrdinal("QQ"));
                    if (!dr.IsDBNull(dr.GetOrdinal("MSN")))
                        model.PersonInfo.MSN = dr.GetString(dr.GetOrdinal("MSN"));
                    if (!dr.IsDBNull(dr.GetOrdinal("JobName")))
                        model.PersonInfo.JobName = dr.GetString(dr.GetOrdinal("JobName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LastLoginIP"))) model.LastLoginIP = dr.GetString(dr.GetOrdinal("LastLoginIP"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LastLoginTime"))) model.LastLoginTime = dr.GetDateTime(dr.GetOrdinal("LastLoginTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("RoleID"))) model.RoleID = dr.GetInt32(dr.GetOrdinal("RoleID"));
                    if (!dr.IsDBNull(dr.GetOrdinal("PermissionList"))) model.PermissionList = dr.GetString(dr.GetOrdinal("PermissionList"));
                    if (!dr.IsDBNull(dr.GetOrdinal("PeopProfile")))
                        model.PersonInfo.PeopProfile = dr.GetString(dr.GetOrdinal("PeopProfile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        model.PersonInfo.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                        model.IsDeleted = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                    if (!dr.IsDBNull(dr.GetOrdinal("UserStatus")))
                        model.UserStatus =
                            (Model.EnumType.CompanyStructure.UserStatus)
                            dr.GetByte(dr.GetOrdinal("UserStatus"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsAdmin")))
                        model.IsAdmin = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsAdmin")));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DepartId"))) model.DepartId = dr.GetInt32(dr.GetOrdinal("DepartId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SuperviseDepartId")))
                        model.SuperviseDepartId = dr.GetInt32(dr.GetOrdinal("SuperviseDepartId"));
                    model.DepartName = dr["DeptName"].ToString();
                    model.ZxsId = dr["ZxsId"].ToString();

                    model.WeiXinHao = dr["WeiXinHao"].ToString();
                    model.BuMenName = dr["BuMenName"].ToString();
                    model.DanJuTaiTouMingCheng = dr["DanJuTaiTouMingCheng"].ToString();
                    model.DanJuTaiTouDiZhi = dr["DanJuTaiTouDiZhi"].ToString();
                    model.KeHuLxrId = dr.GetInt32(dr.GetOrdinal("KeHuLxrId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("KeHuLxrStatus"))) model.KeHuLxrStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus)dr.GetByte(dr.GetOrdinal("KeHuLxrStatus"));
                    model.KeYongJiFen = dr.GetInt32(dr.GetOrdinal("KeYongJiFen"));
                    model.DongJieJiFen = dr.GetInt32(dr.GetOrdinal("DongJieJiFen"));
                    model.WeiXinHao = dr["WeiXinHao"].ToString();
                    model.LeiXing = (EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing)dr.GetByte(dr.GetOrdinal("LeiXing"));
                    model.DanJuDaYinMoBan = dr["DanJuDaYinMoBan"].ToString();
                    model.DanJuTaiTouDianHua = dr["DanJuTaiTouDianHua"].ToString();

                    model.KeHuId = dr["KeHuId"].ToString();

                    #endregion
                }

                if (model != null)
                {
                    dr.NextResult();

                    model.UserBank = new List<Model.CompanyStructure.UserBank>();
                    while (dr.Read())
                    {
                        #region 用户账户信息

                        model.UserBank.Add(
                            new Model.CompanyStructure.UserBank
                            {
                                UserBankId =
                                    dr.IsDBNull(dr.GetOrdinal("Id")) ? string.Empty : dr.GetString(dr.GetOrdinal("Id")),
                                UserId = userId,
                                AccountName =
                                    dr.IsDBNull(dr.GetOrdinal("AccountName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("AccountName")),
                                BankName =
                                    dr.IsDBNull(dr.GetOrdinal("BankName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("BankName")),
                                BankNo =
                                    dr.IsDBNull(dr.GetOrdinal("BankNo"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("BankNo")),
                            });

                        #endregion
                    }
                }
            }

            return model;
        }

        /*/// <summary>
        /// 根据用户名及密码获取用户信息实体
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">MD5密码</param>
        /// <returns>用户信息实体</returns>
        public Model.CompanyStructure.CompanyUser GetUserInfo(string userName, string pwd)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd)) return null;

            var strSql = new StringBuilder();
            strSql.Append(
                " SELECT top 1 [Id],[CompanyId],[UserName],[Password],[MD5Password],[ContactName],[ContactSex],[ContactTel],[ContactFax],[ContactMobile],[ContactEmail],[QQ],[MSN],[JobName],[LastLoginIP],[LastLoginTime],[RoleID],[PermissionList],[PeopProfile],[Remark],[IsDelete],[UserStatus],[IsAdmin],[IssueTime],[DepartId],[SuperviseDepartId] FROM [tbl_CompanyUser] where UserName = @UserName and MD5Password = @MD5Password; ");
            strSql.Append(" SELECT [Id],[AccountName],[BankName],[BankNo] FROM [tbl_UserAccount] where UserId = (select top 1 Id FROM [tbl_CompanyUser] where UserName = @UserName and MD5Password = @MD5Password) ; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "UserName", DbType.String, userName);
            _db.AddInParameter(dc, "MD5Password", DbType.String, pwd);

            Model.CompanyStructure.CompanyUser model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new Model.CompanyStructure.CompanyUser();

                    #region 用户信息

                    if (!dr.IsDBNull(dr.GetOrdinal("Id"))) model.ID = dr.GetInt32(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId"))) model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UserName"))) model.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Password")))
                        model.PassWordInfo.NoEncryptPassword = dr.GetString(dr.GetOrdinal("Password"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactName")))
                        model.PersonInfo.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactSex")))
                        model.PersonInfo.ContactSex =
                            (Model.EnumType.CompanyStructure.Sex)
                            Toolkit.Utils.GetInt(dr.GetString(dr.GetOrdinal("ContactSex")));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactTel")))
                        model.PersonInfo.ContactTel = dr.GetString(dr.GetOrdinal("ContactTel"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactFax")))
                        model.PersonInfo.ContactFax = dr.GetString(dr.GetOrdinal("ContactFax"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactMobile")))
                        model.PersonInfo.ContactMobile = dr.GetString(dr.GetOrdinal("ContactMobile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactEmail")))
                        model.PersonInfo.ContactEmail = dr.GetString(dr.GetOrdinal("ContactEmail"));
                    if (!dr.IsDBNull(dr.GetOrdinal("QQ")))
                        model.PersonInfo.QQ = dr.GetString(dr.GetOrdinal("QQ"));
                    if (!dr.IsDBNull(dr.GetOrdinal("MSN")))
                        model.PersonInfo.MSN = dr.GetString(dr.GetOrdinal("MSN"));
                    if (!dr.IsDBNull(dr.GetOrdinal("JobName")))
                        model.PersonInfo.JobName = dr.GetString(dr.GetOrdinal("JobName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LastLoginIP"))) model.LastLoginIP = dr.GetString(dr.GetOrdinal("LastLoginIP"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LastLoginTime"))) model.LastLoginTime = dr.GetDateTime(dr.GetOrdinal("LastLoginTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("RoleID"))) model.RoleID = dr.GetInt32(dr.GetOrdinal("RoleID"));
                    if (!dr.IsDBNull(dr.GetOrdinal("PermissionList"))) model.PermissionList = dr.GetString(dr.GetOrdinal("PermissionList"));
                    if (!dr.IsDBNull(dr.GetOrdinal("PeopProfile")))
                        model.PersonInfo.PeopProfile = dr.GetString(dr.GetOrdinal("PeopProfile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        model.PersonInfo.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                        model.IsDeleted = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                    if (!dr.IsDBNull(dr.GetOrdinal("UserStatus")))
                        model.UserStatus =
                            (Model.EnumType.CompanyStructure.UserStatus)
                            dr.GetByte(dr.GetOrdinal("UserStatus"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsAdmin")))
                        model.IsAdmin = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsAdmin")));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DepartId"))) model.DepartId = dr.GetInt32(dr.GetOrdinal("DepartId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SuperviseDepartId")))
                        model.SuperviseDepartId = dr.GetInt32(dr.GetOrdinal("SuperviseDepartId"));

                    #endregion
                }

                if (model != null)
                {
                    dr.NextResult();

                    model.UserBank = new List<Model.CompanyStructure.UserBank>();
                    while (dr.Read())
                    {
                        #region 用户账户信息

                        model.UserBank.Add(
                            new Model.CompanyStructure.UserBank
                            {
                                UserBankId =
                                    dr.IsDBNull(dr.GetOrdinal("Id")) ? string.Empty : dr.GetString(dr.GetOrdinal("Id")),
                                UserId = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("UserId")),
                                AccountName =
                                    dr.IsDBNull(dr.GetOrdinal("AccountName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("AccountName")),
                                BankName =
                                    dr.IsDBNull(dr.GetOrdinal("BankName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("BankName")),
                                BankNo =
                                    dr.IsDBNull(dr.GetOrdinal("BankNo"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("BankNo")),
                            });

                        #endregion
                    }
                }
            }

            return model;
        }*/
        
        /*/// <summary>
        /// 获取指定公司的管理员账户
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns>管理员用户信息实体</returns>
        public Model.CompanyStructure.CompanyUser GetAdminModel(int companyId)
        {
            if (companyId <= 0) return null;

            var strSql = new StringBuilder();
            strSql.AppendFormat(
                " SELECT top 1 [Id],[CompanyId],[UserName],[Password],[MD5Password],[ContactName],[ContactSex],[ContactTel],[ContactFax],[ContactMobile],[ContactEmail],[QQ],[MSN],[JobName],[LastLoginIP],[LastLoginTime],[RoleID],[PermissionList],[PeopProfile],[Remark],[IsDelete],[UserStatus],[IsAdmin],[IssueTime],[DepartId],[SuperviseDepartId] FROM [tbl_CompanyUser] where [CompanyId]=@CompanyId and IsAdmin = '1' and IsDelete = '0' and UserStatus = {0} order by IssueTime asc; ",
                Model.EnumType.CompanyStructure.UserStatus.正常);
            strSql.AppendFormat(
                " SELECT [Id],[AccountName],[BankName],[BankNo] FROM [tbl_UserAccount] where UserId = (select [Id] FROM [tbl_CompanyUser] where [CompanyId]=@CompanyId and IsAdmin = '1' and IsDelete = '0' and UserStatus = {0} order by IssueTime asc); ",
                Model.EnumType.CompanyStructure.UserStatus.正常);

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);

            Model.CompanyStructure.CompanyUser model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new Model.CompanyStructure.CompanyUser();

                    #region 用户信息

                    if (!dr.IsDBNull(dr.GetOrdinal("Id"))) model.ID = dr.GetInt32(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId"))) model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UserName"))) model.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Password")))
                        model.PassWordInfo.NoEncryptPassword = dr.GetString(dr.GetOrdinal("Password"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactName")))
                        model.PersonInfo.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactSex")))
                        model.PersonInfo.ContactSex =
                            (Model.EnumType.CompanyStructure.Sex)
                            Toolkit.Utils.GetInt(dr.GetString(dr.GetOrdinal("ContactSex")));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactTel")))
                        model.PersonInfo.ContactTel = dr.GetString(dr.GetOrdinal("ContactTel"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactFax")))
                        model.PersonInfo.ContactFax = dr.GetString(dr.GetOrdinal("ContactFax"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactMobile")))
                        model.PersonInfo.ContactMobile = dr.GetString(dr.GetOrdinal("ContactMobile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactEmail")))
                        model.PersonInfo.ContactEmail = dr.GetString(dr.GetOrdinal("ContactEmail"));
                    if (!dr.IsDBNull(dr.GetOrdinal("QQ")))
                        model.PersonInfo.QQ = dr.GetString(dr.GetOrdinal("QQ"));
                    if (!dr.IsDBNull(dr.GetOrdinal("MSN")))
                        model.PersonInfo.MSN = dr.GetString(dr.GetOrdinal("MSN"));
                    if (!dr.IsDBNull(dr.GetOrdinal("JobName")))
                        model.PersonInfo.JobName = dr.GetString(dr.GetOrdinal("JobName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LastLoginIP"))) model.LastLoginIP = dr.GetString(dr.GetOrdinal("LastLoginIP"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LastLoginTime"))) model.LastLoginTime = dr.GetDateTime(dr.GetOrdinal("LastLoginTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("RoleID"))) model.RoleID = dr.GetInt32(dr.GetOrdinal("RoleID"));
                    if (!dr.IsDBNull(dr.GetOrdinal("PermissionList"))) model.PermissionList = dr.GetString(dr.GetOrdinal("PermissionList"));
                    if (!dr.IsDBNull(dr.GetOrdinal("PeopProfile")))
                        model.PersonInfo.PeopProfile = dr.GetString(dr.GetOrdinal("PeopProfile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        model.PersonInfo.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                        model.IsDeleted = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                    if (!dr.IsDBNull(dr.GetOrdinal("UserStatus")))
                        model.UserStatus =
                            (Model.EnumType.CompanyStructure.UserStatus)
                            dr.GetByte(dr.GetOrdinal("UserStatus"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsAdmin")))
                        model.IsAdmin = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsAdmin")));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DepartId"))) model.DepartId = dr.GetInt32(dr.GetOrdinal("DepartId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SuperviseDepartId")))
                        model.SuperviseDepartId = dr.GetInt32(dr.GetOrdinal("SuperviseDepartId"));

                    #endregion
                }

                if (model != null)
                {
                    dr.NextResult();

                    model.UserBank = new List<Model.CompanyStructure.UserBank>();
                    while (dr.Read())
                    {
                        #region 用户账户信息

                        model.UserBank.Add(
                            new Model.CompanyStructure.UserBank
                            {
                                UserBankId =
                                    dr.IsDBNull(dr.GetOrdinal("Id")) ? string.Empty : dr.GetString(dr.GetOrdinal("Id")),
                                UserId = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("UserId")),
                                AccountName =
                                    dr.IsDBNull(dr.GetOrdinal("AccountName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("AccountName")),
                                BankName =
                                    dr.IsDBNull(dr.GetOrdinal("BankName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("BankName")),
                                BankNo =
                                    dr.IsDBNull(dr.GetOrdinal("BankNo"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("BankNo")),
                            });

                        #endregion
                    }
                }
            }

            return model;
        }*/

        /// <summary>
        /// 获取指定公司的所有用户信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.CompanyUser> GetList(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QueryCompanyUser model)
        {
            if (companyId <= 0 || pageSize <= 0 || pageIndex <= 0) return null;

            IList<Model.CompanyStructure.CompanyUser> totals = new List<Model.CompanyStructure.CompanyUser>();

            #region sql 拼接

            string tableName = " tbl_CompanyUser ";
            string orderByString = "IssueTime DESC";
            var fields = new StringBuilder();
            fields.Append(" Id,CompanyId,UserName,Password,MD5Password,ContactName,ContactSex,ContactTel,ContactFax,ContactMobile,ContactEmail,QQ,MSN,JobName,LastLoginIP,LastLoginTime,RoleID,PermissionList,PeopProfile,Remark,IsDelete,UserStatus,IsAdmin,IssueTime,DepartId,SuperviseDepartId,(select DepartName from tbl_CompanyDepartment as b where b.Id = tbl_CompanyUser.DepartId) as DepartName,(select DepartName from tbl_CompanyDepartment as b where b.Id = tbl_CompanyUser.SuperviseDepartId) as SuperviseDepartName,WeiXinHao ");

            var cmdQuery = new StringBuilder();
            cmdQuery.AppendFormat(" CompanyId = {0} ", companyId);
            if (model != null)
            {
                if (model.IsDelete.HasValue)
                {
                    cmdQuery.AppendFormat(" and IsDelete = '{0}' ", model.IsDelete.Value ? "1" : "0");
                }
                else
                {
                    cmdQuery.Append(" and IsDelete = '0' ");
                }
                if (model.IsAdmin.HasValue)
                {
                    cmdQuery.AppendFormat(" and IsAdmin = '{0}' ", model.IsAdmin.Value ? "1" : "0");
                }
                if (model.UserId != null && model.UserId.Length > 0)
                {
                    cmdQuery.AppendFormat(" and Id in ({0}) ", GetIdsByArr(model.UserId));
                }
                if (model.DepartId != null && model.DepartId.Length > 0)
                {
                    cmdQuery.AppendFormat(" and DepartId in ({0}) ", GetIdsByArr(model.DepartId));
                }
                if (!string.IsNullOrEmpty(model.UserName))
                {
                    cmdQuery.AppendFormat(" and UserName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.UserName));
                }
                if (!string.IsNullOrEmpty(model.ContactName))
                {
                    cmdQuery.AppendFormat(" and ContactName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.ContactName));
                }
                if (model.UserStatus != null && model.UserStatus.Length > 0)
                {
                    if (model.UserStatus.Length == 1)
                    {
                        cmdQuery.AppendFormat(" and UserStatus = {0} ", (int)model.UserStatus[0]);
                    }
                    else
                    {

                        string strIds = string.Empty;
                        foreach (var t in model.UserStatus)
                        {
                            strIds += ((int)t) + ",";
                        }
                        if (!string.IsNullOrEmpty(strIds)) strIds = strIds.TrimEnd(',');
                        cmdQuery.AppendFormat(" and UserStatus in ({0}) ", strIds);
                    }
                }
                if (!string.IsNullOrEmpty(model.ZxsId))
                {
                    cmdQuery.AppendFormat(" AND ZxsId='{0}' ", model.ZxsId);
                }
                if (model.BuMenId.HasValue)
                {
                    cmdQuery.AppendFormat(" AND DepartId={0} ", model.BuMenId.Value);
                }
                if (model.LeiXing.HasValue)
                {
                    cmdQuery.AppendFormat(" AND LeiXing={0} ", (int)model.LeiXing.Value);
                }
            }

            #endregion

            Model.CompanyStructure.CompanyUser companyUserModel;
            using (IDataReader rdr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString()
                , cmdQuery.ToString(), orderByString, string.Empty))
            {
                while (rdr.Read())
                {
                    #region 用户基本信息

                    companyUserModel = new Model.CompanyStructure.CompanyUser
                        {
                            ID = rdr.GetInt32(rdr.GetOrdinal("ID")),
                            CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId")),
                            UserName = rdr.GetString(rdr.GetOrdinal("UserName")),
                            DepartName =
                                rdr.IsDBNull(rdr.GetOrdinal("DepartName"))
                                    ? string.Empty
                                    : rdr.GetString(rdr.GetOrdinal("DepartName")),
                            IsAdmin = rdr.GetString(rdr.GetOrdinal("IsAdmin")) == "1" ? true : false,
                            IsDeleted = rdr.GetString(rdr.GetOrdinal("IsDelete")) == "1" ? true : false,
                            UserStatus =
                                (Model.EnumType.CompanyStructure.UserStatus)rdr.GetByte(rdr.GetOrdinal("UserStatus")),
                            IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime")),
                            LastLoginIP = rdr.IsDBNull(rdr.GetOrdinal("LastLoginIP")) ? "" : rdr["LastLoginIP"].ToString(),
                            LastLoginTime = rdr.GetDateTime(rdr.GetOrdinal("LastLoginTime")),
                            PermissionList =
                                rdr.IsDBNull(rdr.GetOrdinal("PermissionList"))
                                    ? ""
                                    : rdr.GetString(rdr.GetOrdinal("PermissionList")),
                            RoleID = rdr.GetInt32(rdr.GetOrdinal("RoleID")),
                            SuperviseDepartId = rdr.GetInt32(rdr.GetOrdinal("SuperviseDepartId")),
                            SuperviseDepartName =
                                rdr.IsDBNull(rdr.GetOrdinal("SuperviseDepartName"))
                                    ? string.Empty
                                    : rdr.GetString(rdr.GetOrdinal("SuperviseDepartName"))
                        };
                    companyUserModel.UserName = rdr.GetString(rdr.GetOrdinal("UserName"));
                    companyUserModel.WeiXinHao = rdr["WeiXinHao"].ToString();
                    #endregion

                    //用户密码信息
                    companyUserModel.PassWordInfo = new Model.CompanyStructure.PassWord
                    {
                        NoEncryptPassword = rdr.GetString(rdr.GetOrdinal("Password"))
                    };

                    #region 联系人信息
                    companyUserModel.PersonInfo = new Model.CompanyStructure.ContactPersonInfo
                    {
                        ContactEmail = rdr.IsDBNull(rdr.GetOrdinal("ContactEmail")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactEmail")),
                        ContactFax = rdr.IsDBNull(rdr.GetOrdinal("ContactFax")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactFax")),
                        ContactMobile = rdr.IsDBNull(rdr.GetOrdinal("ContactMobile")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactMobile")),
                        ContactName = rdr.IsDBNull(rdr.GetOrdinal("ContactName")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactName")),
                        ContactSex = (Model.EnumType.CompanyStructure.Sex)Enum.Parse(typeof(Model.EnumType.CompanyStructure.Sex), rdr.GetString(rdr.GetOrdinal("ContactSex"))),
                        ContactTel = rdr.IsDBNull(rdr.GetOrdinal("ContactTel")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactTel")),
                        JobName = rdr.IsDBNull(rdr.GetOrdinal("JobName")) ? "" : rdr.GetString(rdr.GetOrdinal("JobName")),
                        MSN = rdr.IsDBNull(rdr.GetOrdinal("MSN")) ? "" : rdr.GetString(rdr.GetOrdinal("MSN")),
                        PeopProfile = rdr.IsDBNull(rdr.GetOrdinal("PeopProfile")) ? "" : rdr.GetString(rdr.GetOrdinal("PeopProfile")),
                        QQ = rdr.IsDBNull(rdr.GetOrdinal("QQ")) ? "" : rdr.GetString(rdr.GetOrdinal("QQ")),
                        Remark = rdr.IsDBNull(rdr.GetOrdinal("Remark")) ? "" : rdr.GetString(rdr.GetOrdinal("Remark")),
                    };
                    #endregion

                    totals.Add(companyUserModel);
                }
            }

            return totals;
        }

        /// <summary>
        /// 获取指定公司的所有用户信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="model">查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.CompanyUser> GetList(int companyId, Model.CompanyStructure.QueryCompanyUser model)
        {
            if (companyId <= 0) return null;

            IList<Model.CompanyStructure.CompanyUser> totals = new List<Model.CompanyStructure.CompanyUser>();

            #region sql 拼接

            var strSql = new StringBuilder();
            strSql.Append(" select ");
            strSql.Append(" Id,CompanyId,UserName,Password,MD5Password,ContactName,ContactSex,ContactTel,ContactFax,ContactMobile,ContactEmail,QQ,MSN,JobName,LastLoginIP,LastLoginTime,RoleID,PermissionList,PeopProfile,Remark,IsDelete,UserStatus,IsAdmin,IssueTime,DepartId,SuperviseDepartId,(select DepartName from tbl_CompanyDepartment as b where b.Id = tbl_CompanyUser.DepartId) as DepartName,(select DepartName from tbl_CompanyDepartment as b where b.Id = tbl_CompanyUser.SuperviseDepartId) as SuperviseDepartName ");
            strSql.Append(" from tbl_CompanyUser ");
            strSql.AppendFormat(" WHERE CompanyId = {0}", companyId);
            if (model != null)
            {
                if (model.IsDelete.HasValue)
                {
                    strSql.AppendFormat(" and IsDelete = '{0}' ", model.IsDelete.Value ? "1" : "0");
                }
                else
                {
                    strSql.Append(" and IsDelete = '0' ");
                }
                if(model.IsAdmin.HasValue)
                {
                    strSql.AppendFormat(" and IsAdmin = '{0}' ", model.IsAdmin.Value ? "1" : "0");
                }
                if (model.UserId != null && model.UserId.Length > 0)
                {
                    strSql.AppendFormat(" and Id in ({0}) ", GetIdsByArr(model.UserId));
                }
                if (model.DepartId != null && model.DepartId.Length > 0)
                {
                    strSql.AppendFormat(" and DepartId in ({0}) ", GetIdsByArr(model.DepartId));
                }
                if (!string.IsNullOrEmpty(model.UserName))
                {
                    strSql.AppendFormat(" and UserName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.UserName));
                }
                if (!string.IsNullOrEmpty(model.ContactName))
                {
                    strSql.AppendFormat(" and ContactName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.ContactName));
                }
                if (model.UserStatus != null && model.UserStatus.Length > 0)
                {
                    if (model.UserStatus.Length == 1)
                    {
                        strSql.AppendFormat(" and UserStatus = {0} ", (int)model.UserStatus[0]);
                    }
                    else
                    {

                        string strIds = string.Empty;
                        foreach (var t in model.UserStatus)
                        {
                            strIds += ((int)t) + ",";
                        }
                        if (!string.IsNullOrEmpty(strIds)) strIds = strIds.TrimEnd(',');
                        strSql.AppendFormat(" and UserStatus in ({0}) ", strIds);
                    }
                }
                if (!string.IsNullOrEmpty(model.ZxsId))
                {
                    strSql.AppendFormat(" AND ZxsId='{0}' ",model.ZxsId);
                }
                if (model.LeiXing.HasValue)
                {
                    strSql.AppendFormat(" AND LeiXing={0} ", (int)model.LeiXing.Value);
                }
            }

            strSql.Append(" order by IssueTime desc ");

            #endregion

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            Model.CompanyStructure.CompanyUser companyUserModel;
            using (IDataReader rdr = DbHelper.ExecuteReader(dc, _db))
            {
                while (rdr.Read())
                {
                    #region 用户基本信息

                    companyUserModel = new Model.CompanyStructure.CompanyUser
                    {
                        ID = rdr.GetInt32(rdr.GetOrdinal("ID")),
                        CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId")),
                        UserName = rdr.GetString(rdr.GetOrdinal("UserName")),
                        DepartName =
                            rdr.IsDBNull(rdr.GetOrdinal("DepartName"))
                                ? string.Empty
                                : rdr.GetString(rdr.GetOrdinal("DepartName")),
                        IsAdmin = rdr.GetString(rdr.GetOrdinal("IsAdmin")) == "1" ? true : false,
                        IsDeleted = rdr.GetString(rdr.GetOrdinal("IsDelete")) == "1" ? true : false,
                        UserStatus =
                            (Model.EnumType.CompanyStructure.UserStatus)rdr.GetByte(rdr.GetOrdinal("UserStatus")),
                        IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime")),
                        LastLoginIP = rdr.IsDBNull(rdr.GetOrdinal("LastLoginIP")) ? "" : rdr["LastLoginIP"].ToString(),
                        LastLoginTime = rdr.GetDateTime(rdr.GetOrdinal("LastLoginTime")),
                        PermissionList =
                            rdr.IsDBNull(rdr.GetOrdinal("PermissionList"))
                                ? ""
                                : rdr.GetString(rdr.GetOrdinal("PermissionList")),
                        RoleID = rdr.GetInt32(rdr.GetOrdinal("RoleID")),
                        SuperviseDepartId = rdr.GetInt32(rdr.GetOrdinal("SuperviseDepartId")),
                        SuperviseDepartName =
                            rdr.IsDBNull(rdr.GetOrdinal("SuperviseDepartName"))
                                ? string.Empty
                                : rdr.GetString(rdr.GetOrdinal("SuperviseDepartName"))
                    };
                    companyUserModel.UserName = rdr.GetString(rdr.GetOrdinal("UserName"));
                    #endregion

                    //用户密码信息
                    companyUserModel.PassWordInfo = new Model.CompanyStructure.PassWord
                    {
                        NoEncryptPassword = rdr.GetString(rdr.GetOrdinal("Password"))
                    };

                    #region 联系人信息
                    companyUserModel.PersonInfo = new Model.CompanyStructure.ContactPersonInfo
                    {
                        ContactEmail = rdr.IsDBNull(rdr.GetOrdinal("ContactEmail")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactEmail")),
                        ContactFax = rdr.IsDBNull(rdr.GetOrdinal("ContactFax")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactFax")),
                        ContactMobile = rdr.IsDBNull(rdr.GetOrdinal("ContactMobile")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactMobile")),
                        ContactName = rdr.IsDBNull(rdr.GetOrdinal("ContactName")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactName")),
                        ContactSex = (Model.EnumType.CompanyStructure.Sex)Enum.Parse(typeof(Model.EnumType.CompanyStructure.Sex), rdr.GetString(rdr.GetOrdinal("ContactSex"))),
                        ContactTel = rdr.IsDBNull(rdr.GetOrdinal("ContactTel")) ? "" : rdr.GetString(rdr.GetOrdinal("ContactTel")),
                        JobName = rdr.IsDBNull(rdr.GetOrdinal("JobName")) ? "" : rdr.GetString(rdr.GetOrdinal("JobName")),
                        MSN = rdr.IsDBNull(rdr.GetOrdinal("MSN")) ? "" : rdr.GetString(rdr.GetOrdinal("MSN")),
                        PeopProfile = rdr.IsDBNull(rdr.GetOrdinal("PeopProfile")) ? "" : rdr.GetString(rdr.GetOrdinal("PeopProfile")),
                        QQ = rdr.IsDBNull(rdr.GetOrdinal("QQ")) ? "" : rdr.GetString(rdr.GetOrdinal("QQ")),
                        Remark = rdr.IsDBNull(rdr.GetOrdinal("Remark")) ? "" : rdr.GetString(rdr.GetOrdinal("Remark")),
                    };
                    #endregion

                    totals.Add(companyUserModel);
                }
            }

            return totals;
        }

        /// <summary>
        /// 设置用户启用状态
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="status">用户状态</param>
        /// <returns>true:成功 false:失败</returns>
        public bool SetEnable(int id, Model.EnumType.CompanyStructure.UserStatus status)
        {
            if (id <= 0) return false;

            DbCommand cmd = this._db.GetSqlStringCommand(SqlSetUserEnable);
            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);
            this._db.AddInParameter(cmd, "UserStatus", DbType.Byte, (int)status);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleId">角色编号</param>
        /// <param name="permissionList">权限集合</param>
        /// <returns>是否成功</returns>
        public bool SetPermission(int userId, int roleId, params string[] permissionList)
        {
            if (userId <= 0 || permissionList == null) return false;

            string permissionStr = string.Empty;
            foreach (string str in permissionList)
            {
                permissionStr += str + ",";
            }
            permissionStr = permissionStr.Trim(',');

            var strSql = new StringBuilder();
            strSql.Append(" update tbl_CompanyUser set RoleID = @RoleId,PermissionList = @PermissionList where Id = @Id ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.Int32, userId);
            this._db.AddInParameter(cmd, "RoleId", DbType.Int32, roleId);
            this._db.AddInParameter(cmd, "PermissionList", DbType.String, permissionStr);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? true : false;
        }

        /// <summary>
        /// （平台）员工新增修改
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int PT_YuanGong_CU(EyouSoft.Model.CompanyStructure.CompanyUser info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_YuanGong_CU");
            _db.AddInParameter(cmd, "@YongHuId", DbType.Int32, info.ID);
            _db.AddInParameter(cmd, "@YongHuMing", DbType.String, info.UserName);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, info.KeHuId);
            _db.AddInParameter(cmd, "@MiMa", DbType.String, info.MiMa);
            _db.AddInParameter(cmd, "@MiMaMd5", DbType.String, info.MiMaMd5);
            _db.AddInParameter(cmd, "@YuanMiMaMd5", DbType.String, info.YuanMiMaMd5);
            _db.AddInParameter(cmd, "@XingMing", DbType.String, info.PersonInfo.ContactName);
            _db.AddInParameter(cmd, "@XingBie", DbType.Byte, info.PersonInfo.ContactSex);
            _db.AddInParameter(cmd, "@ShouJi", DbType.String, info.PersonInfo.ContactMobile);
            _db.AddInParameter(cmd, "@DianHua", DbType.String, info.PersonInfo.ContactTel);
            _db.AddInParameter(cmd, "@Fax", DbType.String, info.PersonInfo.ContactFax);
            _db.AddInParameter(cmd, "@YouXiang", DbType.String, info.PersonInfo.ContactEmail);
            _db.AddInParameter(cmd, "@QQ", DbType.String, info.PersonInfo.QQ);
            _db.AddInParameter(cmd, "@WeiXinHao", DbType.String, info.WeiXinHao);
            _db.AddInParameter(cmd, "@BuMenName", DbType.String, info.BuMenName);
            _db.AddInParameter(cmd, "@ZhiWu", DbType.String, info.PersonInfo.JobName);
            _db.AddInParameter(cmd, "@DanJuTaiTouMingCheng", DbType.String, info.DanJuTaiTouMingCheng);
            _db.AddInParameter(cmd, "@DanJuTaiTouDiZhi", DbType.String, info.DanJuTaiTouDiZhi);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "@KeHuLxrId", DbType.Int32, info.KeHuLxrId);
            _db.AddInParameter(cmd, "@DanJuDaYinMoBan", DbType.String, info.DanJuDaYinMoBan);
            _db.AddInParameter(cmd, "@DanJuTaiTouDianHua", DbType.String, info.DanJuTaiTouDianHua);
            _db.AddInParameter(cmd, "@KeHuLxrStatus", DbType.Byte, info.KeHuLxrStatus);

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
        /// （平台）获取员工信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.CompanyUser> PT_GetYuanGongs(int companyId, string keHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.CompanyStructure.CompanyUser> items = new List<EyouSoft.Model.CompanyStructure.CompanyUser>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Pt_YongHu";
            string orderByString = " KeHuLxrId DESC ";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            query.AppendFormat(" AND KeHuId='{0}' ", keHuId);
            query.AppendFormat(" AND LeiXing={0} ", (int)EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.同行用户);

            if (chaXun != null)
            {
                
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.CompanyUser();
                    item.PersonInfo = new EyouSoft.Model.CompanyStructure.ContactPersonInfo();

                    item.ID = rdr.GetInt32(rdr.GetOrdinal("YongHuId"));
                    item.UserName = rdr["YongHuMing"].ToString();
                    item.PersonInfo.ContactName = rdr["XingMing"].ToString();
                    item.PersonInfo.ContactSex = EyouSoft.Toolkit.Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.Sex>(rdr["XingBie"].ToString(), EyouSoft.Model.EnumType.CompanyStructure.Sex.未知);
                    item.PersonInfo.ContactTel = rdr["DianHua"].ToString();
                    item.PersonInfo.ContactMobile = rdr["ShouJi"].ToString();
                    item.PersonInfo.QQ = rdr["QQ"].ToString();
                    item.PersonInfo.JobName = rdr["ZhiWu"].ToString();
                    item.WeiXinHao = rdr["WeiXinHao"].ToString();
                    item.BuMenName = rdr["BuMenName"].ToString();
                    item.KeHuId = rdr["KeHuId"].ToString();
                    item.KeHuLxrId=rdr.GetInt32(rdr.GetOrdinal("KeHuLxrId"));
                    item.PersonInfo.ContactEmail = rdr["YouXiang"].ToString();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("KeHuLxrStatus"))) item.KeHuLxrStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus)rdr.GetByte(rdr.GetOrdinal("KeHuLxrStatus"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// （平台）员工删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="keHuLxrId">客户联系人编号</param>
        /// <returns></returns>
        public int PT_YuanGong_D(int companyId, string keHuId, int yongHuId, int keHuLxrId)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_YuanGong_D");
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, keHuId);
            _db.AddInParameter(cmd, "@KeHuLxrId", DbType.Int32, keHuLxrId);
            _db.AddInParameter(cmd, "@YongHuId", DbType.Int32, yongHuId);
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
        /// 获取用户积分信息
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public EyouSoft.Model.CompanyStructure.MYongHuJiFenInfo GetYongHuJiFenInfo(int yongHuId)
        {
            var info = new EyouSoft.Model.CompanyStructure.MYongHuJiFenInfo();

            string sql = " SELECT A.KeYongJiFen,A.DongJieJiFen ";
            sql += " ,ISNULL((SELECT SUM(JiFen) FROM tbl_Pt_YongHuJiFenMingXi AS A1 WHERE A1.YongHuId=A.Id AND A1.Status=1 AND A1.GuanLianLeiXing=1),0) AS YiShiYongJiFen ";
            sql += " FROM tbl_CompanyUser AS A WHERE A.Id=@YongHuId ";

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "YongHuId", DbType.Int32, yongHuId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info.KeYongJiFen = rdr.GetInt32(rdr.GetOrdinal("KeYongJiFen"));
                    info.DongJieJiFen = rdr.GetInt32(rdr.GetOrdinal("DongJieJiFen"));
                    info.YiShiYongJiFen = rdr.GetInt32(rdr.GetOrdinal("YiShiYongJiFen"));
                }
            }

            return info;
        }

        /// <summary>
        /// 根据关键字获取用户信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="s">关键字(用户名或邮箱)</param>
        /// <returns></returns>
        public EyouSoft.Model.CompanyStructure.MYongHuJianYaoXinXiInfo GetYongHuInfo(int companyId, string s)
        {
            EyouSoft.Model.CompanyStructure.MYongHuJianYaoXinXiInfo info = null;
            string sql = "SELECT Id,UserName,ContactEmail,LeiXing FROM tbl_CompanyUser WHERE CompanyId=@CompanyId AND (UserName=@S OR ContactEmail=@S)";
            var cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "S", DbType.String, s);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.CompanyStructure.MYongHuJianYaoXinXiInfo();
                    info.LeiXing = (EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.YongHuId = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    info.YongHuMing = rdr["UserName"].ToString();
                    info.YouXiang = rdr["ContactEmail"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 设置用户密码，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="miMa">新密码</param>
        /// <param name="miMaMd5">新密码MD5</param>
        /// <returns></returns>
        public int SheZhiMiMa(int companyId, int yongHuId, string miMa, string miMaMd5)
        {
            string sql = "UPDATE tbl_CompanyUser SET Password=@MiMa,MD5Password=@MiMaMd5 WHERE CompanyId=@CompanyId AND Id=@YongHuId";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "YongHuId", DbType.Int32, yongHuId);
            _db.AddInParameter(cmd, "MiMa", DbType.String, miMa);
            _db.AddInParameter(cmd, "MiMaMd5", DbType.String, miMaMd5);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 获取客户账号信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.CompanyUser> GetKeHuYongHus(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.CompanyStructure.CompanyUser> items = new List<EyouSoft.Model.CompanyStructure.CompanyUser>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Pt_YongHu";
            string orderByString = " KeHuLxrId DESC ";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} AND YongHuId>0 ", companyId);
            query.AppendFormat(" AND LeiXing={0} ", (int)EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.同行用户);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.KeHuName))
                {
                    query.AppendFormat(" AND KeHuName LIKE '%{0}%' ", chaXun.KeHuName);
                }
                if (!string.IsNullOrEmpty(chaXun.YongHuMing))
                {
                    query.AppendFormat(" AND YongHuMing LIKE '%{0}%' ", chaXun.YongHuMing);
                }
                if (!string.IsNullOrEmpty(chaXun.YongHuXingMing))
                {
                    query.AppendFormat(" AND XingMing LIKE '%{0}%' ", chaXun.YongHuXingMing);
                }
                if (chaXun.YongHuStatus.HasValue)
                {
                    query.AppendFormat(" AND YongHuStatus={0} ", (int)chaXun.YongHuStatus.Value);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.CompanyUser();
                    item.PersonInfo = new EyouSoft.Model.CompanyStructure.ContactPersonInfo();

                    item.ID = rdr.GetInt32(rdr.GetOrdinal("YongHuId"));
                    item.UserName = rdr["YongHuMing"].ToString();
                    item.PersonInfo.ContactName = rdr["XingMing"].ToString();
                    item.PersonInfo.ContactSex = EyouSoft.Toolkit.Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.Sex>(rdr["XingBie"].ToString(), EyouSoft.Model.EnumType.CompanyStructure.Sex.未知);
                    item.PersonInfo.ContactTel = rdr["DianHua"].ToString();
                    item.PersonInfo.ContactMobile = rdr["ShouJi"].ToString();
                    item.PersonInfo.QQ = rdr["QQ"].ToString();
                    item.PersonInfo.JobName = rdr["ZhiWu"].ToString();
                    item.WeiXinHao = rdr["WeiXinHao"].ToString();
                    item.BuMenName = rdr["BuMenName"].ToString();
                    item.KeHuId = rdr["KeHuId"].ToString();
                    item.KeHuLxrId = rdr.GetInt32(rdr.GetOrdinal("KeHuLxrId"));
                    item.PersonInfo.ContactEmail = rdr["YouXiang"].ToString();

                    if (!rdr.IsDBNull(rdr.GetOrdinal("KeHuLxrStatus"))) item.KeHuLxrStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus)rdr.GetByte(rdr.GetOrdinal("KeHuLxrStatus"));

                    item.KeHuName = rdr["KeHuName"].ToString();
                    item.UserStatus = (EyouSoft.Model.EnumType.CompanyStructure.UserStatus)rdr.GetByte(rdr.GetOrdinal("YongHuStatus"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public int YongHu_D(int companyId, string zxsId, int yongHuId)
        {
            var cmd = _db.GetStoredProcCommand("proc_YongHu_D");
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@YongHuId", DbType.Int32, yongHuId);
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
        /// 获取供应商账号信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.CompanyUser> GetGysYongHus(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MGysYongHuChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.CompanyStructure.CompanyUser> items = new List<EyouSoft.Model.CompanyStructure.CompanyUser>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Gys_YongHu";
            string orderByString = " GysLxrId DESC ";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} AND YongHuId>0 ", companyId);
            query.AppendFormat(" AND LeiXing={0} ", (int)EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.供应商用户);

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND GysName LIKE '%{0}%' ", chaXun.GysName);
                }
                if (!string.IsNullOrEmpty(chaXun.YongHuMing))
                {
                    query.AppendFormat(" AND YongHuMing LIKE '%{0}%' ", chaXun.YongHuMing);
                }
                if (!string.IsNullOrEmpty(chaXun.YongHuXingMing))
                {
                    query.AppendFormat(" AND XingMing LIKE '%{0}%' ", chaXun.YongHuXingMing);
                }
                if (chaXun.YongHuStatus.HasValue)
                {
                    query.AppendFormat(" AND YongHuStatus={0} ", (int)chaXun.YongHuStatus.Value);
                }
                if (chaXun.GysLeiXing.HasValue)
                {
                    query.AppendFormat(" AND GysLeiXing={0} ", (int)chaXun.GysLeiXing.Value);
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
                    var item = new EyouSoft.Model.CompanyStructure.CompanyUser();
                    item.PersonInfo = new EyouSoft.Model.CompanyStructure.ContactPersonInfo();

                    item.ID = rdr.GetInt32(rdr.GetOrdinal("YongHuId"));
                    item.UserName = rdr["YongHuMing"].ToString();
                    item.PersonInfo.ContactName = rdr["XingMing"].ToString();
                    item.PersonInfo.ContactTel = rdr["DianHua"].ToString();
                    item.PersonInfo.ContactMobile = rdr["ShouJi"].ToString();
                    item.PersonInfo.QQ = rdr["QQ"].ToString();
                    item.GysId = rdr["GysId"].ToString();
                    item.GysLxrId = rdr.GetInt32(rdr.GetOrdinal("GysLxrId"));
                    item.GysName = rdr["GysName"].ToString();
                    item.UserStatus = (EyouSoft.Model.EnumType.CompanyStructure.UserStatus)rdr.GetByte(rdr.GetOrdinal("YongHuStatus"));

                    items.Add(item);
                }
            }

            return items;
        }

        #endregion
    }
}
