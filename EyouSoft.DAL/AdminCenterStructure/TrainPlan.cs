using System;
using System.Data;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;


namespace EyouSoft.DAL.AdminCenterStructure
{
    /// <summary>
    /// 行政中心-培训计划
    /// </summary>
    public class TrainPlan : DALBase, IDAL.AdminCenterStructure.ITrainPlan
    {
        private readonly Database _db;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public TrainPlan()
        {
            _db = this.SystemStore;
        }
        #endregion 构造函数

        #region 实现接口公共方法
        /// <summary>
        /// 获取培训计划实体信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="id">培训编号（主键）</param>
        /// <returns></returns>
        public Model.AdminCenterStructure.TrainPlan GetModel(int companyId, int id)
        {
            if (companyId <= 0 || id <= 0) return null;

            Model.AdminCenterStructure.TrainPlan model = null;
            string strSql = "SELECT [Id],[PlanTitle],[PlanContent],OperatorId,[OperatorName],IssueTime,TrainPlanFile,(SELECT [AcceptType],[AcceptId] FROM [tbl_TrainPlanAccepts] WHERE TrainPlanId=[tbl_TrainPlan].[Id] FOR XML Raw,Root('Root')) AS TrainPlanAcceptXML FROM tbl_TrainPlan WHERE CompanyId=@CompanyId AND Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            this._db.AddInParameter(dc, "Id", DbType.Int32, id);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    model = new Model.AdminCenterStructure.TrainPlan
                    {
                        CompanyId = companyId,
                        IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                        TrainPlanFile = dr.IsDBNull(dr.GetOrdinal("TrainPlanFile")) ? "" : dr.GetString(dr.GetOrdinal("TrainPlanFile")),
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId")),
                        OperatorName = dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? "" : dr.GetString(dr.GetOrdinal("OperatorName")),
                        PlanContent = dr.IsDBNull(dr.GetOrdinal("PlanContent")) ? "" : dr.GetString(dr.GetOrdinal("PlanContent")),
                        PlanTitle = dr.IsDBNull(dr.GetOrdinal("PlanTitle")) ? "" : dr.GetString(dr.GetOrdinal("PlanTitle")),
                        AcceptList = GetAcceptList(dr["TrainPlanAcceptXML"].ToString())
                    };
                    foreach (Model.AdminCenterStructure.TrainPlanAccepts item in model.AcceptList)
                    {
                        if (item.AcceptType != Model.EnumType.AdminCenterStructure.AcceptType.所有)
                        {
                            if (item.AcceptType == Model.EnumType.AdminCenterStructure.AcceptType.指定部门)
                            {
                                Model.CompanyStructure.Department depart = this.GetDepartInfo(item.AcceptId);
                                if (depart != null)
                                {
                                    item.AcceptName = depart.DepartName;
                                }
                            }
                            else
                            {
                                Model.CompanyStructure.ContactPersonInfo person = this.GetUserContact(item.AcceptId);
                                if (person != null)
                                {
                                    item.AcceptName = person.ContactName;
                                }
                            }
                        }
                    }
                }
            }
            return model;
        }
        /// <summary>
        /// 获取培训计划信息集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="companyId">公司编号</param>    
        /// <param name="userId">当前用户编号</param> 
        /// <param name="departmentId">部门编号</param> 
        /// <returns></returns>
        public IList<Model.AdminCenterStructure.TrainPlan> GetList(int pageSize, int pageIndex, ref int recordCount, int companyId
            , int userId, int departmentId)
        {
            IList<Model.AdminCenterStructure.TrainPlan> resultList;
            string tableName = "tbl_TrainPlan";
            string fields = "[Id],[PlanTitle],[PlanContent],[OperatorName],IssueTime,(SELECT [AcceptType],[AcceptId] FROM [tbl_TrainPlanAccepts] WHERE TrainPlanId=[tbl_TrainPlan].[Id] FOR XML Raw,Root('Root')) AS TrainPlanAcceptXML";
            StringBuilder query = new StringBuilder();
            query.AppendFormat(" [CompanyId]={0} AND ", companyId);
            query.Append(" ( exists(SELECT 1 FROM tbl_TrainPlanAccepts WHERE TrainPlanId=[tbl_TrainPlan].[id] AND AcceptType=0) OR ");
            query.AppendFormat(" exists(SELECT 1 FROM tbl_TrainPlanAccepts WHERE TrainPlanId=[tbl_TrainPlan].[id] AND AcceptType=1 AND AcceptId={0}) OR ", departmentId);
            query.AppendFormat(" exists(SELECT 1 FROM tbl_TrainPlanAccepts WHERE TrainPlanId=[tbl_TrainPlan].[id] AND AcceptType=2 AND AcceptId={0}) OR OperatorId = {0} ) ", userId);
            string orderByString = " IssueTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, string.Empty))
            {
                resultList = new List<Model.AdminCenterStructure.TrainPlan>();
                while (dr.Read())
                {
                    var model = new Model.AdminCenterStructure.TrainPlan
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        OperatorName = dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? "" : dr.GetString(dr.GetOrdinal("OperatorName")),
                        PlanContent = dr.IsDBNull(dr.GetOrdinal("PlanContent")) ? "" : dr.GetString(dr.GetOrdinal("PlanContent")),
                        PlanTitle = dr.IsDBNull(dr.GetOrdinal("PlanTitle")) ? "" : dr.GetString(dr.GetOrdinal("PlanTitle")),
                        IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                        AcceptList = GetAcceptList(dr["TrainPlanAcceptXML"].ToString())
                    };
                    resultList.Add(model);
                }
            }
            return resultList;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">培训计划实体</param>
        /// <returns></returns>
        public bool Add(Model.AdminCenterStructure.TrainPlan model)
        {
            if (model == null) return false;

            bool isTrue = false;
            string trainPlanAcceptXml = CreateTrainPlanAcceptXML(model.AcceptList);
            DbCommand dc = this._db.GetStoredProcCommand("proc_TrainPlan_Insert");
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(dc, "PlanTitle", DbType.AnsiString, model.PlanTitle);
            this._db.AddInParameter(dc, "PlanContent", DbType.AnsiString, model.PlanContent);
            this._db.AddInParameter(dc, "TrainPlanFile", DbType.AnsiString, model.TrainPlanFile);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(dc, "OperatorName", DbType.AnsiString, model.OperatorName);
            this._db.AddInParameter(dc, "TrainPlanAcceptXML", DbType.AnsiString, trainPlanAcceptXml);
            this._db.AddInParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            object result = this._db.GetParameterValue(dc, "Result");
            if (!result.Equals(null))
            {
                isTrue = int.Parse(result.ToString()) > 0 ? true : false;
            }
            return isTrue;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">培训计划实体</param>
        /// <returns></returns>
        public bool Update(Model.AdminCenterStructure.TrainPlan model)
        {
            if (model == null || model.Id <= 0) return false;

            bool isTrue = false;
            string trainPlanAcceptXml = CreateTrainPlanAcceptXML(model.AcceptList);
            DbCommand dc = this._db.GetStoredProcCommand("proc_TrainPlan_Update");
            this._db.AddInParameter(dc, "TrainPlanId", DbType.Int32, model.Id);
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(dc, "PlanTitle", DbType.AnsiString, model.PlanTitle);
            this._db.AddInParameter(dc, "PlanContent", DbType.AnsiString, model.PlanContent);
            this._db.AddInParameter(dc, "TrainPlanFile", DbType.AnsiString, model.TrainPlanFile);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(dc, "OperatorName", DbType.AnsiString, model.OperatorName);
            this._db.AddInParameter(dc, "TrainPlanAcceptXML", DbType.AnsiString, trainPlanAcceptXml);
            this._db.AddInParameter(dc, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            object result = this._db.GetParameterValue(dc, "Result");
            if (!result.Equals(null))
            {
                isTrue = int.Parse(result.ToString()) > 0 ? true : false;
            }
            return isTrue;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public bool Delete(int companyId, int id)
        {
            if (companyId <= 0 || id <= 0) return false;

            bool isTrue = false;
            DbCommand dc = this._db.GetStoredProcCommand("proc_TrainPlan_Delete");
            this._db.AddInParameter(dc, "TrainPlanId", DbType.Int32, id);
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, companyId);
            this._db.AddInParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            object result = this._db.GetParameterValue(dc, "Result");
            if (!result.Equals(null))
            {
                isTrue = int.Parse(result.ToString()) > 0 ? true : false;
            }
            return isTrue;
        }
        #endregion 实现接口公共方法

        #region 私有方法
        /// <summary>
        /// 生成XML
        /// </summary>
        /// <param name="acceptList">培训计划接受人信息集合</param>
        /// <returns></returns>
        private string CreateTrainPlanAcceptXML(IList<Model.AdminCenterStructure.TrainPlanAccepts> acceptList)
        {
            if (acceptList == null) return "";
            var strBuild = new StringBuilder();
            strBuild.Append("<ROOT>");
            foreach (Model.AdminCenterStructure.TrainPlanAccepts model in acceptList)
            {
                strBuild.AppendFormat("<TrainPlanAccept AcceptId=\"{0}\"", model.AcceptId);
                strBuild.AppendFormat(" AcceptType=\"{0}\" ", (int)model.AcceptType);
                strBuild.AppendFormat(" TrainPlanId=\"{0}\" /> ", model.TrainPlanId);
            }
            strBuild.Append("</ROOT>");
            return strBuild.ToString();
        }
        /// <summary>
        /// 获取接受对象集合
        /// </summary>
        /// <param name="acceptXml">XML字符串</param>
        /// <returns></returns>
        private IList<Model.AdminCenterStructure.TrainPlanAccepts> GetAcceptList(string acceptXml)
        {
            if (string.IsNullOrEmpty(acceptXml)) return null;
            var resultList = new List<Model.AdminCenterStructure.TrainPlanAccepts>();
            XElement root = XElement.Parse(acceptXml);
            var xRow = root.Elements("row");
            foreach (var tmp1 in xRow)
            {
                var model = new Model.AdminCenterStructure.TrainPlanAccepts
                    {
                        AcceptId = Toolkit.Utils.GetInt(Toolkit.Utils.GetXAttributeValue(tmp1, "AcceptId")),
                        AcceptType =
                            (Model.EnumType.AdminCenterStructure.AcceptType)
                            Toolkit.Utils.GetInt(
                                Toolkit.Utils.GetXAttributeValue(tmp1, "AcceptType"))
                    };
                resultList.Add(model);
            }
            return resultList;
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="id">部门编号</param>
        /// <returns></returns>
        private Model.CompanyStructure.Department GetDepartInfo(int id)
        {
            Model.CompanyStructure.Department departmentModel = null;
            DbCommand cmd = this._db.GetSqlStringCommand(" select Id,DepartName,PrevDepartId,DepartManger,ContactTel,ContactFax,Remark,CompanyId,OperatorId,IssueTime from tbl_CompanyDepartment where Id = @Id; ");
            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    departmentModel = new Model.CompanyStructure.Department
                    {
                        Id = rdr.GetInt32(rdr.GetOrdinal("Id")),
                        DepartName = rdr.GetString(rdr.GetOrdinal("DepartName")),
                        DepartManger =
                            rdr.IsDBNull(rdr.GetOrdinal("DepartManger"))
                                ? 0
                                : rdr.GetInt32(rdr.GetOrdinal("DepartManger")),
                        PrevDepartId = rdr.GetInt32(rdr.GetOrdinal("PrevDepartId")),
                        ContactTel =
                            rdr.IsDBNull(rdr.GetOrdinal("ContactTel"))
                                ? ""
                                : rdr.GetString(rdr.GetOrdinal("ContactTel")),
                        ContactFax =
                            rdr.IsDBNull(rdr.GetOrdinal("ContactFax"))
                                ? ""
                                : rdr.GetString(rdr.GetOrdinal("ContactFax")),
                        Remark = rdr.IsDBNull(rdr.GetOrdinal("Remark")) ? "" : rdr.GetString(rdr.GetOrdinal("Remark")),
                        CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId")),
                        OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId")),
                        IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"))
                    };
                }
            }

            return departmentModel;
        }

        /// <summary>
        /// 获取用户联系人信息
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        private Model.CompanyStructure.ContactPersonInfo GetUserContact(int id)
        {
            Model.CompanyStructure.ContactPersonInfo model = null;
            if (id <= 0) return model;

            DbCommand cmd = _db.GetSqlStringCommand(" select * from tbl_CompanyUser where Id = @Id ");
            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);
            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    model = new Model.CompanyStructure.ContactPersonInfo();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ContactEmail")))
                        model.ContactEmail = rdr.GetString(rdr.GetOrdinal("ContactEmail"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ContactFax")))
                        model.ContactFax = rdr.GetString(rdr.GetOrdinal("ContactFax"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ContactMobile")))
                        model.ContactMobile = rdr.GetString(rdr.GetOrdinal("ContactMobile"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ContactName")))
                        model.ContactName = rdr.GetString(rdr.GetOrdinal("ContactName"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ContactSex")))
                        model.ContactSex =
                            (Model.EnumType.CompanyStructure.Sex)
                            Enum.Parse(
                                typeof(Model.EnumType.CompanyStructure.Sex),
                                Toolkit.Utils.GetInt(rdr.GetString(rdr.GetOrdinal("ContactSex"))).ToString());
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ContactTel")))
                        model.ContactTel = rdr.GetString(rdr.GetOrdinal("ContactTel"));
                    model.JobName = rdr.IsDBNull(rdr.GetOrdinal("JobName")) ? "" : rdr.GetString(rdr.GetOrdinal("JobName"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("MSN")))
                        model.MSN = rdr.GetString(rdr.GetOrdinal("MSN"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("PeopProfile")))
                        model.PeopProfile = rdr.GetString(rdr.GetOrdinal("PeopProfile"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QQ")))
                        model.QQ = rdr.GetString(rdr.GetOrdinal("QQ"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("Remark")))
                        model.Remark = rdr.GetString(rdr.GetOrdinal("Remark"));
                }
            }

            return model;
        }

        #endregion 私有方法
    }
}
