using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.AdminCenterStructure
{
    /// <summary>
    /// 行政中心-人事档案DAL
    /// </summary>
    public class PersonnelInfo : DALBase, IDAL.AdminCenterStructure.IPersonnelInfo
    {
        private readonly Database _db;
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public PersonnelInfo()
        {
            _db = this.SystemStore;
        }
        #endregion

        #region 实现接口公共方法
        /// <summary>
        /// 获取认识档案信息实体
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="personId">职员编号</param>
        /// <returns></returns>
        public Model.AdminCenterStructure.PersonnelInfo GetModel(int companyId, int personId)
        {
            Model.AdminCenterStructure.PersonnelInfo model = null;
            if (companyId <= 0 || personId <= 0) return model;

            var strSql = new StringBuilder();

            strSql.Append(" SELECT [Id],[CompanyId],[ArchiveNo],[UserName],[ContactSex],[CardId],[CardPath],[BirthDate],[PhotoPath],[DepartmentId],[DutyId],[PersonalType],[IsLeave],[EntryDate],[ServiceYear],[LeaveDate],[IsMarried],[National],[Birthplace],[Politic],[ContactTel],[ContactMobile],[QQ],[MSN],[Email],[ContactAddress],[Remark],[IssueTime],[OperatorId],(SELECT [Id],[DepartName] FROM tbl_CompanyDepartment a WHERE a.[id] IN(select [value] from  dbo.fn_split([tbl_PersonnelInfo].[DepartmentId],',')) AND [CompanyId]=@companyid FOR XML Raw,Root('Department'))AS [DepartmentXML],(SELECT [JobName] FROM [tbl_DutyManager] b WHERE b.[id]=[tbl_PersonnelInfo].[dutyid] AND [CompanyId]=@companyid) AS [DutyName],DATEDIFF(YEAR,ISNULL(EntryDate,getdate()),getdate()) AS [WorkYear],WeiXinHao  FROM [tbl_PersonnelInfo] ");
            strSql.Append(" where CompanyId = @CompanyId and Id = @Id;  ");
            strSql.Append(" select [Id],[PersonId],[StartDate],[EndDate],[Degree],[Professional],[SchoolName],[StudyStatus],[Remark] from tbl_SchoolInfo where PersonId = @Id; ");
            strSql.Append(" select [Id],[PersonId],[StartDate],[EndDate],[WorkPlace],[WorkUnit],[TakeUp],[Remark] from tbl_PersonalHistory where PersonId = @Id; ");
            strSql.Append(" SELECT * FROM tbl_PersonnelYinHangZhangHu WHERE Id=@Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(dc, "Id", DbType.Int32, personId);

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                #region 人事档案信息

                if (dr.Read())
                {
                    model = new Model.AdminCenterStructure.PersonnelInfo
                        {
                            Id = personId,
                            CompanyId = companyId,
                            ArchiveNo =
                                dr.IsDBNull(dr.GetOrdinal("ArchiveNo"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("ArchiveNo")),
                            UserName =
                                dr.IsDBNull(dr.GetOrdinal("UserName"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("UserName")),
                            CardId =
                                dr.IsDBNull(dr.GetOrdinal("CardId"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("CardId")),
                            CardPath =
                                dr.IsDBNull(dr.GetOrdinal("CardPath"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("CardPath")),
                            PhotoPath =
                                dr.IsDBNull(dr.GetOrdinal("PhotoPath"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("PhotoPath")),
                            DepartmentId =
                                dr.IsDBNull(dr.GetOrdinal("DepartmentId"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("DepartmentId")),
                            DutyId = dr.IsDBNull(dr.GetOrdinal("DutyId")) ? 0 : dr.GetInt32(dr.GetOrdinal("DutyId")),
                            National =
                                dr.IsDBNull(dr.GetOrdinal("National"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("National")),
                            Birthplace =
                                dr.IsDBNull(dr.GetOrdinal("Birthplace"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Birthplace")),
                            Politic =
                                dr.IsDBNull(dr.GetOrdinal("Politic"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Politic")),
                            ContactTel =
                                dr.IsDBNull(dr.GetOrdinal("ContactTel"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("ContactTel")),
                            ContactMobile =
                                dr.IsDBNull(dr.GetOrdinal("ContactMobile"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("ContactMobile")),
                            QQ = dr.IsDBNull(dr.GetOrdinal("QQ")) ? string.Empty : dr.GetString(dr.GetOrdinal("QQ")),
                            MSN = dr.IsDBNull(dr.GetOrdinal("MSN")) ? string.Empty : dr.GetString(dr.GetOrdinal("MSN")),
                            Email =
                                dr.IsDBNull(dr.GetOrdinal("Email")) ? string.Empty : dr.GetString(dr.GetOrdinal("Email")),
                            ContactAddress =
                                dr.IsDBNull(dr.GetOrdinal("ContactAddress"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("ContactAddress")),
                            Remark =
                                dr.IsDBNull(dr.GetOrdinal("Remark"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Remark")),
                            OperatorId =
                                dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId")),
                            DepartmentList = this.GetDepartmentList(dr["DepartmentXML"].ToString()),
                            DutyName = dr["DutyName"].ToString(),
                            WorkYear = dr.GetInt32(dr.GetOrdinal("WorkYear"))
                        };
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactSex")))
                        model.ContactSex = (Model.EnumType.CompanyStructure.Sex)dr.GetInt32(dr.GetOrdinal("ContactSex"));
                    if (!dr.IsDBNull(dr.GetOrdinal("BirthDate")))
                        model.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("PersonalType")))
                        model.PersonalType = (Model.EnumType.AdminCenterStructure.PersonalType)dr.GetInt32(dr.GetOrdinal("PersonalType"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsLeave")))
                        model.IsLeave = dr.GetInt32(dr.GetOrdinal("IsLeave")) == 1;
                    if (!dr.IsDBNull(dr.GetOrdinal("EntryDate")))
                        model.EntryDate = dr.GetDateTime(dr.GetOrdinal("EntryDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ServiceYear")))
                        model.ServiceYear = dr.GetDateTime(dr.GetOrdinal("ServiceYear"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LeaveDate")))
                        model.LeaveDate = dr.GetDateTime(dr.GetOrdinal("LeaveDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsMarried")))
                        model.IsMarried = dr.GetInt32(dr.GetOrdinal("IsMarried")) == 1;
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.WeiXinHao = dr["WeiXinHao"].ToString();
                }

                #endregion

                if (model != null)
                {
                    #region 学历信息

                    model.SchoolList = new List<Model.AdminCenterStructure.SchoolInfo>();
                    dr.NextResult();
                    while (dr.Read())
                    {
                        var tmp = new Model.AdminCenterStructure.SchoolInfo();
                        if (!dr.IsDBNull(dr.GetOrdinal("Id"))) tmp.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                        tmp.PersonId = model.Id;
                        if (!dr.IsDBNull(dr.GetOrdinal("StartDate"))) tmp.StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
                        if (!dr.IsDBNull(dr.GetOrdinal("EndDate"))) tmp.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
                        if (!dr.IsDBNull(dr.GetOrdinal("Degree")))
                            tmp.Degree =
                                (Model.EnumType.AdminCenterStructure.DegreeType)dr.GetByte(dr.GetOrdinal("Degree"));
                        if (!dr.IsDBNull(dr.GetOrdinal("Professional"))) tmp.Professional = dr.GetString(dr.GetOrdinal("Professional"));
                        if (!dr.IsDBNull(dr.GetOrdinal("SchoolName"))) tmp.SchoolName = dr.GetString(dr.GetOrdinal("SchoolName"));
                        if (!dr.IsDBNull(dr.GetOrdinal("StudyStatus")))
                            tmp.StudyStatus = dr.GetByte(dr.GetOrdinal("StudyStatus")) == 1;
                        if (!dr.IsDBNull(dr.GetOrdinal("Remark"))) tmp.Remark = dr.GetString(dr.GetOrdinal("Remark"));

                        model.SchoolList.Add(tmp);
                    }

                    #endregion

                    #region 个人履历信息

                    model.HistoryList = new List<Model.AdminCenterStructure.PersonalHistory>();
                    dr.NextResult();
                    while (dr.Read())
                    {
                        var tmp2 = new Model.AdminCenterStructure.PersonalHistory();

                        if (!dr.IsDBNull(dr.GetOrdinal("Id"))) tmp2.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                        tmp2.PersonId = model.Id;
                        if (!dr.IsDBNull(dr.GetOrdinal("StartDate"))) tmp2.StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
                        if (!dr.IsDBNull(dr.GetOrdinal("EndDate"))) tmp2.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
                        if (!dr.IsDBNull(dr.GetOrdinal("WorkPlace"))) tmp2.WorkPlace = dr.GetString(dr.GetOrdinal("WorkPlace"));
                        if (!dr.IsDBNull(dr.GetOrdinal("WorkUnit"))) tmp2.WorkUnit = dr.GetString(dr.GetOrdinal("WorkUnit"));
                        if (!dr.IsDBNull(dr.GetOrdinal("TakeUp"))) tmp2.TakeUp = dr.GetString(dr.GetOrdinal("TakeUp"));
                        if (!dr.IsDBNull(dr.GetOrdinal("Remark"))) tmp2.Remark = dr.GetString(dr.GetOrdinal("Remark"));

                        model.HistoryList.Add(tmp2);
                    }

                    #endregion

                    #region 银行账户
                    model.YinHangZhangHus = new List<EyouSoft.Model.CompanyStructure.CompanyAccountBase>();
                    dr.NextResult();
                    while (dr.Read())
                    {
                        var tmp3 = new EyouSoft.Model.CompanyStructure.CompanyAccountBase();
                        tmp3.AccountName = dr["AccountName"].ToString();
                        tmp3.BankName = dr["BankName"].ToString();
                        tmp3.BankNo = dr["BankNo"].ToString();
                        model.YinHangZhangHus.Add(tmp3);
                    }
                    #endregion

                }
            }

            return model;
        }

        /// <summary>
        /// 获取人事档案列表信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="reCordCount"></param>
        /// <param name="companyId">公司编号</param>
        /// <param name="searchInfo"></param>
        /// <returns></returns>
        public IList<Model.AdminCenterStructure.PersonnelInfo> GetList(int pageSize, int pageIndex, ref int reCordCount
            , int companyId, Model.AdminCenterStructure.PersonnelSearchInfo searchInfo)
        {
            IList<Model.AdminCenterStructure.PersonnelInfo> resultList;
            #region SQL处理
            string tableName = "tbl_PersonnelInfo";
            string orderByString = " IssueTime DESC";
            var fields = new StringBuilder();
            fields.Append("[Id],[ArchiveNo],[BirthDate],[UserName],[ContactSex],MSN,QQ,EntryDate,DepartmentId,");
            fields.AppendFormat("(SELECT [Id],[DepartName] FROM tbl_CompanyDepartment a WHERE a.[id] IN(select [value] from  dbo.fn_split([tbl_PersonnelInfo].[DepartmentId],',')) AND [CompanyId]={0} FOR XML Raw,Root('Department'))AS [DepartmentXML],", companyId);
            fields.AppendFormat("(SELECT [JobName] FROM [tbl_DutyManager] b WHERE b.[id]=[tbl_PersonnelInfo].[dutyid] AND [CompanyId]={0}) AS [DutyName],", companyId);
            fields.Append("(SELECT DATEDIFF(YEAR,ISNULL(EntryDate,getdate()),getdate())) AS [WorkYear],[ContactTel],[ContactMobile],[Email],[WeiXinHao]");
            var query = new StringBuilder();
            query.AppendFormat("[CompanyId]={0}", companyId);
            if (!string.IsNullOrEmpty(searchInfo.ArchiveNo))
            {
                query.AppendFormat(" AND ArchiveNo like'%{0}%'", searchInfo.ArchiveNo);
            }
            if (!string.IsNullOrEmpty(searchInfo.UserName))
            {
                query.AppendFormat(" AND UserName like'%{0}%'", searchInfo.UserName);
            }
            if (searchInfo.IsLeave.HasValue)
            {
                query.AppendFormat(" AND IsLeave={0}", searchInfo.IsLeave == true ? 1 : 0);
            }
            if (searchInfo.IsMarried.HasValue)
            {
                query.AppendFormat(" AND IsMarried={0}", searchInfo.IsMarried == true ? 1 : 0);
            }
            if (searchInfo.DutyId.HasValue)
            {
                query.AppendFormat(" AND DutyId={0}", searchInfo.DutyId);
            }
            if (searchInfo.BirthDateFrom.HasValue)
            {
                query.AppendFormat(" AND DATEDIFF(DAY,'{0}',BirthDate)>=0", searchInfo.BirthDateFrom);
            }
            if (searchInfo.BirthDateTo.HasValue)
            {
                query.AppendFormat(" AND DATEDIFF(DAY,BirthDate,'{0}')>=0", searchInfo.BirthDateTo);
            }
            if (searchInfo.PersonalType.HasValue && ((int)searchInfo.PersonalType) >= 0)
            {
                query.AppendFormat(" AND PersonalType={0}", (int)searchInfo.PersonalType);
            }
            if (searchInfo.ContactSex.HasValue && ((int)searchInfo.ContactSex) > 0)
            {
                query.AppendFormat(" AND ContactSex={0}", (int)searchInfo.ContactSex);
            }
            if (searchInfo.WorkYearFrom.HasValue && searchInfo.WorkYearFrom >= 0)
            {
                query.AppendFormat(" AND DATEDIFF(YEAR,isnull(EntryDate,getdate()),getdate())>={0}", searchInfo.WorkYearFrom);
            }
            if (searchInfo.WorkYearTo.HasValue && searchInfo.WorkYearTo >= 0)
            {
                query.AppendFormat(" AND DATEDIFF(YEAR,isnull(EntryDate,getdate()),getdate())<={0}", searchInfo.WorkYearTo);
            }
            #endregion
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref reCordCount, tableName, fields.ToString()
                , query.ToString(), orderByString, string.Empty))
            {
                resultList = new List<Model.AdminCenterStructure.PersonnelInfo>();
                while (dr.Read())
                {
                    var model = new Model.AdminCenterStructure.PersonnelInfo()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        ArchiveNo = dr.IsDBNull(dr.GetOrdinal("ArchiveNo")) ? "" : dr.GetString(dr.GetOrdinal("ArchiveNo")),
                        MSN = dr.IsDBNull(dr.GetOrdinal("MSN")) ? "" : dr.GetString(dr.GetOrdinal("MSN")),
                        QQ = dr.IsDBNull(dr.GetOrdinal("QQ")) ? "" : dr.GetString(dr.GetOrdinal("QQ")),
                        UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName")),
                        ContactSex = (Model.EnumType.CompanyStructure.Sex)Enum.Parse(typeof(Model.EnumType.CompanyStructure.Sex), dr.GetInt32(dr.GetOrdinal("ContactSex")).ToString()),
                        DepartmentList = this.GetDepartmentList(dr["DepartmentXML"].ToString()),
                        DepartmentId = dr["DepartmentId"].ToString(),
                        DutyName = dr.IsDBNull(dr.GetOrdinal("DutyName")) ? "" : dr.GetString(dr.GetOrdinal("DutyName")),
                        WorkYear = dr.IsDBNull(dr.GetOrdinal("WorkYear")) ? 0 : Convert.ToInt32(dr["WorkYear"].ToString()),
                        ContactTel = dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? "" : dr.GetString(dr.GetOrdinal("ContactTel")),
                        ContactMobile = dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? "" : dr.GetString(dr.GetOrdinal("ContactMobile")),
                        Email = dr.IsDBNull(dr.GetOrdinal("Email")) ? "" : dr.GetString(dr.GetOrdinal("Email"))
                    };
                    if (dr.IsDBNull(dr.GetOrdinal("EntryDate")))
                    {
                        model.EntryDate = null;
                    }
                    else
                    {
                        model.EntryDate = dr.GetDateTime(dr.GetOrdinal("EntryDate"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("BirthDate")))
                    {
                        model.BirthDate = null;
                    }
                    else
                    {
                        model.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
                    }
                    model.WeiXinHao = dr["WeiXinHao"].ToString();
                    resultList.Add(model);
                }
            };
            return resultList;
        }
        /// <summary>
        /// 获取通讯录信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="reCordCount"></param>
        /// <param name="companyId"></param>
        /// <param name="userName">姓名</param>
        /// <param name="departmentId">部门编号</param>
        /// <param name="deptNm">部门名称(部门编号为null或0时用部门名称模糊查询)</param>
        /// <param name="s">是否离职（0：所有 1：在职 2：离职）</param>
        /// <returns></returns>
        public IList<Model.AdminCenterStructure.PersonnelInfo> GetList(int pageSize, int pageIndex, ref int reCordCount
            , int companyId, string userName, int? departmentId, string deptNm, string s)
        {
            IList<Model.AdminCenterStructure.PersonnelInfo> resultList;
            #region SQL处理
            string tableName = "tbl_PersonnelInfo";
            var fields = new StringBuilder();
            fields.Append("[Id],[UserName],[ContactTel],ContactSex,[ContactMobile],[Email],[QQ],[MSN],WeiXinHao,");
            fields.AppendFormat("(SELECT [Id],[DepartName] FROM tbl_CompanyDepartment a WHERE a.[id] IN(select [value] from  dbo.fn_split([tbl_PersonnelInfo].[DepartmentId],',')) AND [CompanyId]={0} FOR XML Raw,Root('Department'))AS [DepartmentXML] ", companyId);
            var query = new StringBuilder();
            query.AppendFormat("[CompanyId]={0} ", companyId);
            if (s == "1")
            {
                query.Append(" AND IsLeave=0 ");
            }
            if (s == "2")
            {
                query.Append(" AND IsLeave=1 ");
            }
            if (!string.IsNullOrEmpty(userName))
            {
                query.AppendFormat(" AND UserName like'%{0}%'", userName);
            }
            if (departmentId.HasValue && departmentId > 0)
            {
                query.AppendFormat(" AND EXISTS(SELECT 1 FROM dbo.fn_split(DepartmentId,',') WHERE [VALUE]='{0}')", departmentId);
            }
            else if (!string.IsNullOrEmpty(deptNm))
            {
                query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_CompanyDepartment d where d.id in (select [value] from dbo.fn_split(DepartmentId,',')) and d.DepartName like '%{0}%')", Utils.ToSqlLike(deptNm));                
            }
            string orderByString = " IssueTime DESC";
            #endregion
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref reCordCount, tableName, fields.ToString()
                , query.ToString(), orderByString, string.Empty))
            {
                resultList = new List<Model.AdminCenterStructure.PersonnelInfo>();
                while (dr.Read())
                {
                    var model = new Model.AdminCenterStructure.PersonnelInfo()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName")),
                        ContactSex = (Model.EnumType.CompanyStructure.Sex)Enum.Parse(typeof(Model.EnumType.CompanyStructure.Sex), dr.GetInt32(dr.GetOrdinal("ContactSex")).ToString()),
                        DepartmentList = this.GetDepartmentList(dr["DepartmentXML"].ToString()),
                        ContactTel = dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? "" : dr.GetString(dr.GetOrdinal("ContactTel")),
                        ContactMobile = dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? "" : dr.GetString(dr.GetOrdinal("ContactMobile")),
                        Email = dr.IsDBNull(dr.GetOrdinal("Email")) ? "" : dr.GetString(dr.GetOrdinal("Email")),
                        QQ = dr.IsDBNull(dr.GetOrdinal("QQ")) ? "" : dr.GetString(dr.GetOrdinal("QQ")),
                        MSN = dr.IsDBNull(dr.GetOrdinal("MSN")) ? "" : dr.GetString(dr.GetOrdinal("MSN"))
                    };
                    model.YinHangZhangHus = GetYinHangZhangHus(model.Id);
                    model.WeiXinHao = dr["WeiXinHao"].ToString();
                    resultList.Add(model);
                }
            };
            return resultList;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model">职工档案信息实体</param>
        /// <returns></returns>
        public bool Add(Model.AdminCenterStructure.PersonnelInfo model)
        {
            if (model == null || model.CompanyId <= 0) return false;

            var strSql = new StringBuilder();

            DbCommand dc = _db.GetSqlStringCommand("select 1");

            #region sql处理

            strSql.Append(" declare @PersonId int; ");
            strSql.Append(" INSERT INTO [tbl_PersonnelInfo] ([CompanyId],[ArchiveNo],[UserName],[ContactSex],[CardId],[CardPath],[BirthDate],[PhotoPath],[DepartmentId],[DutyId],[PersonalType],[IsLeave],[EntryDate],[ServiceYear],[LeaveDate],[IsMarried],[National],[Birthplace],[Politic],[ContactTel],[ContactMobile],[QQ],[MSN],[Email],[ContactAddress],[Remark],[IssueTime],[OperatorId],[WeiXinHao]) VALUES (@CompanyId,@ArchiveNo,@UserName,@ContactSex,@CardId,@CardPath,@BirthDate,@PhotoPath,@DepartmentId,@DutyId,@PersonalType,@IsLeave,@EntryDate,@ServiceYear,@LeaveDate,@IsMarried,@National,@Birthplace,@Politic,@ContactTel,@ContactMobile,@QQ,@MSN,@Email,@ContactAddress,@Remark,@IssueTime,@OperatorId,@WeiXinHao); ");
            strSql.Append(" select @PersonId = @@Identity; ");

            if (model.SchoolList != null && model.SchoolList.Any())
            {
                for (int i = 0; i < model.SchoolList.Count; i++)
                {
                    if (model.SchoolList[i] == null) continue;
                    strSql.AppendFormat(
                        " INSERT INTO [tbl_SchoolInfo] ([PersonId],[StartDate],[EndDate],[Degree],[Professional],[SchoolName],[StudyStatus],[Remark])  VALUES (@PersonId,@StartDate{0},@EndDate{0},{1},'{2}','{3}',{4},'{5}'); ",
                        i,
                        (int)model.SchoolList[i].Degree,
                        model.SchoolList[i].Professional,
                        model.SchoolList[i].SchoolName,
                        model.SchoolList[i].StudyStatus ? 1 : 0,
                        model.SchoolList[i].Remark);
                    if (model.SchoolList[i].StartDate.HasValue)
                        _db.AddInParameter(dc, string.Format("StartDate{0}", i), DbType.DateTime, model.SchoolList[i].StartDate.Value);
                    else _db.AddInParameter(dc, string.Format("StartDate{0}", i), DbType.DateTime, DBNull.Value);
                    if (model.SchoolList[i].EndDate.HasValue)
                        _db.AddInParameter(dc, string.Format("EndDate{0}", i), DbType.DateTime, model.SchoolList[i].EndDate.Value);
                    else _db.AddInParameter(dc, string.Format("EndDate{0}", i), DbType.DateTime, DBNull.Value);
                }
            }

            if (model.HistoryList != null && model.HistoryList.Any())
            {
                for (int i = 0; i < model.HistoryList.Count; i++)
                {
                    if (model.HistoryList[i] == null) continue;
                    strSql.AppendFormat(
                        " INSERT INTO [tbl_PersonalHistory] ([PersonId],[StartDate],[EndDate],[WorkPlace],[WorkUnit],[TakeUp],[Remark])  VALUES (@PersonId,@HStartDate{0},@HEndDate{0},'{1}','{2}','{3}','{4}'); ",
                        i,
                        model.HistoryList[i].WorkPlace,
                        model.HistoryList[i].WorkUnit,
                        model.HistoryList[i].TakeUp,
                        model.HistoryList[i].Remark);
                    if (model.HistoryList[i].StartDate.HasValue)
                        _db.AddInParameter(dc, string.Format("HStartDate{0}", i), DbType.DateTime, model.HistoryList[i].StartDate.Value);
                    else _db.AddInParameter(dc, string.Format("HStartDate{0}", i), DbType.DateTime, DBNull.Value);
                    if (model.HistoryList[i].EndDate.HasValue)
                        _db.AddInParameter(dc, string.Format("HEndDate{0}", i), DbType.DateTime, model.HistoryList[i].EndDate.Value);
                    else _db.AddInParameter(dc, string.Format("HEndDate{0}", i), DbType.DateTime, DBNull.Value);
                }
            }

            if (model.YinHangZhangHus != null && model.YinHangZhangHus.Count > 0)
            {
                for (int i = 0; i < model.YinHangZhangHus.Count; i++)
                {
                    if (model.YinHangZhangHus[i] == null) continue;

                    strSql.AppendFormat(" INSERT INTO [tbl_PersonnelYinHangZhangHu]([Id],[BankName],[AccountName],[BankNo])VALUES(@PersonId,@BankName{0},@AccountName{0},@BankNo{0}); ", i);

                    _db.AddInParameter(dc, string.Format("BankName{0}", i), DbType.String, model.YinHangZhangHus[i].BankName);
                    _db.AddInParameter(dc, string.Format("AccountName{0}", i), DbType.String, model.YinHangZhangHus[i].AccountName);
                    _db.AddInParameter(dc, string.Format("BankNo{0}", i), DbType.String, model.YinHangZhangHus[i].BankNo);

                }
            }

            strSql.Append(" select @PersonId; ");

            #endregion

            dc.CommandText = strSql.ToString();

            #region 参数赋值

            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "ArchiveNo", DbType.String, model.ArchiveNo);
            _db.AddInParameter(dc, "UserName", DbType.String, model.UserName);
            _db.AddInParameter(dc, "ContactSex", DbType.Int32, (int)model.ContactSex);
            _db.AddInParameter(dc, "CardId", DbType.String, model.CardId);
            _db.AddInParameter(dc, "CardPath", DbType.String, model.CardPath);
            if (model.BirthDate.HasValue)
                _db.AddInParameter(dc, "BirthDate", DbType.DateTime, model.BirthDate.Value);
            else _db.AddInParameter(dc, "BirthDate", DbType.DateTime, DBNull.Value);
            _db.AddInParameter(dc, "PhotoPath", DbType.String, model.PhotoPath);
            _db.AddInParameter(dc, "DepartmentId", DbType.String, model.DepartmentId);
            if (model.DutyId.HasValue)
                _db.AddInParameter(dc, "DutyId", DbType.Int32, model.DutyId.Value);
            else _db.AddInParameter(dc, "DutyId", DbType.Int32, DBNull.Value);
            _db.AddInParameter(dc, "PersonalType", DbType.Int32, (int)model.PersonalType);
            _db.AddInParameter(dc, "IsLeave", DbType.Int32, model.IsLeave ? 1 : 0);
            if (model.EntryDate.HasValue)
                _db.AddInParameter(dc, "EntryDate", DbType.DateTime, model.EntryDate.Value);
            else _db.AddInParameter(dc, "EntryDate", DbType.DateTime, DBNull.Value);
            if (model.ServiceYear.HasValue)
                _db.AddInParameter(dc, "ServiceYear", DbType.DateTime, model.ServiceYear.Value);
            else _db.AddInParameter(dc, "ServiceYear", DbType.DateTime, DBNull.Value);
            if (model.LeaveDate.HasValue)
                _db.AddInParameter(dc, "LeaveDate", DbType.DateTime, model.LeaveDate.Value);
            else _db.AddInParameter(dc, "LeaveDate", DbType.DateTime, DBNull.Value);
            _db.AddInParameter(dc, "IsMarried", DbType.Int32, model.IsMarried ? 1 : 0);
            _db.AddInParameter(dc, "National", DbType.String, model.National);
            _db.AddInParameter(dc, "Birthplace", DbType.String, model.Birthplace);
            _db.AddInParameter(dc, "Politic", DbType.String, model.Politic);
            _db.AddInParameter(dc, "ContactTel", DbType.String, model.ContactTel);
            _db.AddInParameter(dc, "ContactMobile", DbType.String, model.ContactMobile);
            _db.AddInParameter(dc, "QQ", DbType.String, model.QQ);
            _db.AddInParameter(dc, "MSN", DbType.String, model.MSN);
            _db.AddInParameter(dc, "Email", DbType.String, model.Email);
            _db.AddInParameter(dc, "ContactAddress", DbType.String, model.ContactAddress);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "WeiXinHao", DbType.String, model.WeiXinHao);

            #endregion

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null)
            {
                return false;
            }

            model.Id = Toolkit.Utils.GetInt(obj.ToString());
            return true;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">职工档案信息实体</param>
        /// <returns></returns>
        public bool Update(Model.AdminCenterStructure.PersonnelInfo model)
        {
            if (model == null || model.Id <= 0) return false;

            var strSql = new StringBuilder();

            DbCommand dc = _db.GetSqlStringCommand("select 1");

            #region sql处理

            strSql.Append(" if exists (select 1 from tbl_PersonnelInfo where Id=@Id and CardPath <> @CardPath) ");
            strSql.Append(" begin ");
            strSql.Append(
                " insert into tbl_SysDeletedFileQue (FilePath) select CardPath from tbl_PersonnelInfo where Id=@Id and CardPath <> @CardPath; ");
            strSql.Append(" end ");
            strSql.Append(" if exists (select 1 from tbl_PersonnelInfo where Id=@Id and PhotoPath <> @PhotoPath) ");
            strSql.Append(" begin ");
            strSql.Append(
                " insert into tbl_SysDeletedFileQue (FilePath) select PhotoPath from tbl_PersonnelInfo where Id=@Id and PhotoPath <> @PhotoPath; ");
            strSql.Append(" end ");
            strSql.Append(" UPDATE [tbl_PersonnelInfo] SET [ArchiveNo]=@ArchiveNo,[UserName]=@UserName,[ContactSex]=@ContactSex,[CardId]=@CardId,[CardPath]=@CardPath,[BirthDate]=@BirthDate,[PhotoPath]=@PhotoPath,[DepartmentId]=@DepartmentId,[DutyId]=@DutyId,[PersonalType]=@PersonalType,[IsLeave]=@IsLeave,[EntryDate]=@EntryDate,[ServiceYear]=@ServiceYear,[LeaveDate]=@LeaveDate,[IsMarried]=@IsMarried,[National]=@National,[Birthplace]=@Birthplace,[Politic]=@Politic,[ContactTel]=@ContactTel,[ContactMobile]=@ContactMobile,[QQ]=@QQ,[MSN]=@MSN,[Email]=@Email,[ContactAddress]=@ContactAddress,[Remark]=@Remark,[OperatorId]=@OperatorId,WeiXinHao=@WeiXinHao WHERE Id=@Id; delete tbl_SchoolInfo where PersonId=@Id;delete from [tbl_PersonalHistory] where PersonId = @Id;DELETE FROM tbl_PersonnelYinHangZhangHu WHERE Id=@Id; ");

            if (model.SchoolList != null)
            {
                if (model.SchoolList.Any())
                {
                    for (int i = 0; i < model.SchoolList.Count; i++)
                    {
                        if (model.SchoolList[i] == null) continue;
                        strSql.AppendFormat(
                            " INSERT INTO [tbl_SchoolInfo] ([PersonId],[StartDate],[EndDate],[Degree],[Professional],[SchoolName],[StudyStatus],[Remark])  VALUES (@Id,@StartDate{0},@EndDate{0},{1},'{2}','{3}',{4},'{5}'); ",
                            i,
                            (int)model.SchoolList[i].Degree,
                            model.SchoolList[i].Professional,
                            model.SchoolList[i].SchoolName,
                            model.SchoolList[i].StudyStatus ? 1 : 0,
                            model.SchoolList[i].Remark);
                        if (model.SchoolList[i].StartDate.HasValue)
                            _db.AddInParameter(dc, string.Format("StartDate{0}", i), DbType.DateTime, model.SchoolList[i].StartDate.Value);
                        else _db.AddInParameter(dc, string.Format("StartDate{0}", i), DbType.DateTime, DBNull.Value);
                        if (model.SchoolList[i].EndDate.HasValue)
                            _db.AddInParameter(dc, string.Format("EndDate{0}", i), DbType.DateTime, model.SchoolList[i].EndDate.Value);
                        else _db.AddInParameter(dc, string.Format("EndDate{0}", i), DbType.DateTime, DBNull.Value);
                    }
                }
                //else
                //{
                //    strSql.Append(" delete from [tbl_SchoolInfo] where PersonId = @Id; ");
                //}
            }
            if (model.HistoryList != null)
            {
                if (model.HistoryList.Any())
                {
                    for (int i = 0; i < model.HistoryList.Count; i++)
                    {
                        if (model.HistoryList[i] == null) continue;
                        strSql.AppendFormat(
                            " INSERT INTO [tbl_PersonalHistory] ([PersonId],[StartDate],[EndDate],[WorkPlace],[WorkUnit],[TakeUp],[Remark])  VALUES (@Id,@HStartDate{0},@HEndDate{0},'{1}','{2}','{3}','{4}'); ",
                            i,
                            model.HistoryList[i].WorkPlace,
                            model.HistoryList[i].WorkUnit,
                            model.HistoryList[i].TakeUp,
                            model.HistoryList[i].Remark);
                        if (model.HistoryList[i].StartDate.HasValue)
                            _db.AddInParameter(dc, string.Format("HStartDate{0}", i), DbType.DateTime, model.HistoryList[i].StartDate.Value);
                        else _db.AddInParameter(dc, string.Format("HStartDate{0}", i), DbType.DateTime, DBNull.Value);
                        if (model.HistoryList[i].EndDate.HasValue)
                            _db.AddInParameter(dc, string.Format("HEndDate{0}", i), DbType.DateTime, model.HistoryList[i].EndDate.Value);
                        else _db.AddInParameter(dc, string.Format("HEndDate{0}", i), DbType.DateTime, DBNull.Value);
                    }
                }
                //else
                //{
                //    strSql.Append(" delete from [tbl_PersonalHistory] where PersonId = @Id; ");
                //}
            }

            if (model.YinHangZhangHus != null && model.YinHangZhangHus.Count > 0)
            {
                for (int i = 0; i < model.YinHangZhangHus.Count; i++)
                {
                    if (model.YinHangZhangHus[i] == null) continue;

                    strSql.AppendFormat(" INSERT INTO [tbl_PersonnelYinHangZhangHu]([Id],[BankName],[AccountName],[BankNo])VALUES(@Id,@BankName{0},@AccountName{0},@BankNo{0}); ", i);

                    _db.AddInParameter(dc, string.Format("BankName{0}", i), DbType.String, model.YinHangZhangHus[i].BankName);
                    _db.AddInParameter(dc, string.Format("AccountName{0}", i), DbType.String, model.YinHangZhangHus[i].AccountName);
                    _db.AddInParameter(dc, string.Format("BankNo{0}", i), DbType.String, model.YinHangZhangHus[i].BankNo);

                }
            }

            #endregion

            dc.CommandText = strSql.ToString();

            #region 参数赋值

            _db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            _db.AddInParameter(dc, "ArchiveNo", DbType.String, model.ArchiveNo);
            _db.AddInParameter(dc, "UserName", DbType.String, model.UserName);
            _db.AddInParameter(dc, "ContactSex", DbType.Int32, (int)model.ContactSex);
            _db.AddInParameter(dc, "CardId", DbType.String, model.CardId);
            _db.AddInParameter(dc, "CardPath", DbType.String, model.CardPath);
            if (model.BirthDate.HasValue)
                _db.AddInParameter(dc, "BirthDate", DbType.DateTime, model.BirthDate.Value);
            else _db.AddInParameter(dc, "BirthDate", DbType.DateTime, DBNull.Value);
            _db.AddInParameter(dc, "PhotoPath", DbType.String, model.PhotoPath);
            _db.AddInParameter(dc, "DepartmentId", DbType.String, model.DepartmentId);
            if (model.DutyId.HasValue)
                _db.AddInParameter(dc, "DutyId", DbType.Int32, model.DutyId.Value);
            else _db.AddInParameter(dc, "DutyId", DbType.Int32, DBNull.Value);
            _db.AddInParameter(dc, "PersonalType", DbType.Int32, (int)model.PersonalType);
            _db.AddInParameter(dc, "IsLeave", DbType.Int32, model.IsLeave ? 1 : 0);
            if (model.EntryDate.HasValue)
                _db.AddInParameter(dc, "EntryDate", DbType.DateTime, model.EntryDate.Value);
            else _db.AddInParameter(dc, "EntryDate", DbType.DateTime, DBNull.Value);
            if (model.ServiceYear.HasValue)
                _db.AddInParameter(dc, "ServiceYear", DbType.DateTime, model.ServiceYear.Value);
            else _db.AddInParameter(dc, "ServiceYear", DbType.DateTime, DBNull.Value);
            if (model.LeaveDate.HasValue)
                _db.AddInParameter(dc, "LeaveDate", DbType.DateTime, model.LeaveDate.Value);
            else _db.AddInParameter(dc, "LeaveDate", DbType.DateTime, DBNull.Value);
            _db.AddInParameter(dc, "IsMarried", DbType.Int32, model.IsMarried ? 1 : 0);
            _db.AddInParameter(dc, "National", DbType.String, model.National);
            _db.AddInParameter(dc, "Birthplace", DbType.String, model.Birthplace);
            _db.AddInParameter(dc, "Politic", DbType.String, model.Politic);
            _db.AddInParameter(dc, "ContactTel", DbType.String, model.ContactTel);
            _db.AddInParameter(dc, "ContactMobile", DbType.String, model.ContactMobile);
            _db.AddInParameter(dc, "QQ", DbType.String, model.QQ);
            _db.AddInParameter(dc, "MSN", DbType.String, model.MSN);
            _db.AddInParameter(dc, "Email", DbType.String, model.Email);
            _db.AddInParameter(dc, "ContactAddress", DbType.String, model.ContactAddress);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "WeiXinHao", DbType.String, model.WeiXinHao);

            #endregion

            return DbHelper.ExecuteSqlTrans(dc, _db) > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="personId">员工编号</param>
        /// <returns></returns>
        public bool Delete(int companyId, params int[] personId)
        {
            if (companyId <= 0 || personId == null || personId.Length <= 0) return false;

            string cmdText = string.Empty;
            cmdText +=
                string.Format(
                    " insert into tbl_SysDeletedFileQue (FilePath) select CardPath from tbl_PersonnelInfo where CompanyId = {0} and Id in ({1}); ",
                    companyId,
                    GetIdsByArr(personId));
            cmdText +=
                string.Format(
                    " insert into tbl_SysDeletedFileQue (FilePath) select PhotoPath from tbl_PersonnelInfo where CompanyId = {0} and Id in ({1}); ",
                    companyId,
                    GetIdsByArr(personId));
            cmdText += string.Format(" DELETE FROM tbl_AttendanceInfo WHERE StaffNo IN({0}) AND CompanyId={1};DELETE FROM tbl_SchoolInfo WHERE PersonId IN({0});DELETE FROM tbl_PersonalHistory WHERE PersonId IN({0});DELETE FROM tbl_PersonnelYinHangZhangHu WHERE Id IN({0});DELETE FROM tbl_PersonnelInfo WHERE Id  IN({0}) AND CompanyId={1};", Toolkit.Utils.GetSqlIdStrByArray(personId), companyId);

            DbCommand cmd = _db.GetSqlStringCommand(cmdText);

            return DbHelper.ExecuteSqlTrans(cmd, _db) > 0;
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 生成部门集合List
        /// </summary>
        /// <param name="departMentXml">要分析的XML字符串</param>
        /// <returns></returns>
        private IList<Model.CompanyStructure.Department> GetDepartmentList(string departMentXml)
        {
            if (string.IsNullOrEmpty(departMentXml)) return null;
            XElement root = XElement.Parse(departMentXml);
            var xRow = root.Elements("row");
            IList<Model.CompanyStructure.Department> resultList = new List<Model.CompanyStructure.Department>();
            foreach (var tmp1 in xRow)
            {
                var model = new Model.CompanyStructure.Department
                    {
                        Id = Toolkit.Utils.GetInt(Toolkit.Utils.GetXAttributeValue(tmp1, "Id")),
                        DepartName = Toolkit.Utils.GetXAttributeValue(tmp1, "DepartName")
                    };
                resultList.Add(model);
            }
            return resultList;
        }

        /// <summary>
        /// 获取银行账户信息集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.CompanyAccountBase> GetYinHangZhangHus(int id)
        {
            IList<EyouSoft.Model.CompanyStructure.CompanyAccountBase> items = new List<EyouSoft.Model.CompanyStructure.CompanyAccountBase>();
            string cmdText = "SELECT * FROM tbl_PersonnelYinHangZhangHu WHERE Id=@Id";
            DbCommand cmd = _db.GetSqlStringCommand(cmdText);
            _db.AddInParameter(cmd, "Id", DbType.Int32, id);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.CompanyAccountBase();

                    item.AccountName = rdr["AccountName"].ToString();
                    item.BankName = rdr["BankName"].ToString();
                    item.BankNo = rdr["BankNo"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion 私有方法
    }
}
