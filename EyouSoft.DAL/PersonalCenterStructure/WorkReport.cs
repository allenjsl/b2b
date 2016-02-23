using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using System.IO;
using EyouSoft.Toolkit;
using System.Xml.Linq;
using EyouSoft.Model.PersonalCenterStructure;
namespace EyouSoft.DAL.PersonalCenterStructure
{
    /// <summary>
    /// 工作汇报数据层
    /// </summary>
    /// 鲁功源  2011-01-20
    public class WorkReport : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.PersonalCenterStructure.IWorkReport
    {
        #region 变量
        private const string Sql_WorkReport_Delete = "update tbl_WorkReport set IsDelete='1' where ReportId in({0})";
        //private EyouSoft.Data.EyouSoftTBL dcDal = null;
        private Database _db = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkReport()
        {
            _db = this.SystemStore;
            //dcDal = new EyouSoft.Data.EyouSoftTBL(this.SystemStore.ConnectionString);
        }
        #endregion

        #region IWorkReport 成员
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">工作汇报实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(EyouSoft.Model.PersonalCenterStructure.WorkReport model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_WorkReport_Add");
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "Title", DbType.String, model.Title);
            this._db.AddInParameter(cmd, "Description", DbType.String, model.Description);
            this._db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(cmd, "DepartmentId", DbType.Int32, model.DepartmentId);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "ReportingTime", DbType.DateTime, model.ReportingTime);
            this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)model.Status);
            this._db.AddInParameter(cmd, "WorkType", DbType.Byte, (int)model.WorkType);
            this._db.AddInParameter(cmd, "AcceptPeople", DbType.Xml, CreateAcceptXML(model.AcceptList));
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) == 1 ? true : false;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">工作汇报实体</param>
        /// <returns>1:修改成功 0:修改失败 -1:已审核的不允许修改</returns>
        public int Update(EyouSoft.Model.PersonalCenterStructure.WorkReport model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_WorkReport_Update");
            this._db.AddInParameter(cmd, "Id", DbType.Int32, model.ReportId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "Title", DbType.String, model.Title);
            this._db.AddInParameter(cmd, "Description", DbType.String, model.Description);
            this._db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(cmd, "DepartmentId", DbType.Int32, model.DepartmentId);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "ReportingTime", DbType.DateTime, model.ReportingTime);
            this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)model.Status);
            this._db.AddInParameter(cmd, "WorkType", DbType.Byte, (int)model.WorkType);
            this._db.AddInParameter(cmd, "AcceptPeople", DbType.Xml, CreateAcceptXML(model.AcceptList));
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>1:删除成功 0:删除失败 -1已审核的不允许删除</returns>
        public int Delete(int id)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_WorkReport_Delete");
            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));

        }
        /// <summary>
        /// 设置审核状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns>true:成功 false:失败</returns>
        public bool SetChecked(EyouSoft.Model.PersonalCenterStructure.WorkReport model)
        {
            var sql = new StringBuilder();

            sql.Append(" UPDATE  [dbo].[tbl_WorkReport]");
            sql.Append(" SET     [Status] = @Status ,");
            sql.Append("         [Comment] = @Comment ,");
            sql.Append("         [CheckerId] = @CheckerId ,");
            sql.Append("         [CheckTime] = @CheckTime");
            sql.Append(" WHERE   ReportId = @ReportId");

            var dc = this._db.GetSqlStringCommand(sql.ToString());

            this._db.AddInParameter(dc, "ReportId", DbType.Int32, model.ReportId);
            this._db.AddInParameter(dc, "Status", DbType.Byte, (int)model.Status);
            this._db.AddInParameter(dc, "Comment", DbType.String, model.Comment);
            this._db.AddInParameter(dc, "CheckerId", DbType.Int32, model.CheckerId);
            this._db.AddInParameter(dc, "CheckTime", DbType.DateTime, model.CheckTime);

            return DbHelper.ExecuteSql(dc, this._db) > 0;
        }
        /// <summary>
        /// 获取工作汇报实体
        /// </summary>
        /// <param name="Id">主键编号</param>
        /// <returns>工作汇报实体</returns>
        public EyouSoft.Model.PersonalCenterStructure.WorkReport GetModel(int Id)
        {
            var sql = new StringBuilder();
            var mdl = new EyouSoft.Model.PersonalCenterStructure.WorkReport();
            sql.Append(" SELECT ReportId,CompanyId,Title,Description ");
            sql.Append(" ,FilePath,DepartmentId,OperatorId ");
            sql.Append(",(select ContactName from tbl_CompanyUser as d where Id=a.OperatorId) as OperatorName");
            sql.Append(" ,ReportingTime");
            sql.Append(" ,Status");
            sql.Append("  ,Comment");
            sql.Append(" ,CheckerId");
            sql.Append(" ,CheckTime");
            sql.Append("  ,(select PlanId,AccetpId,");
            sql.Append(" (select ContactName from tbl_CompanyUser as b where Id=c.AccetpId )");
            sql.Append(" as AccetpName from tbl_WorkPlanAccept as c where PlanId=a.ReportId ");
            sql.Append(" and WorkType=0 and CompanyId=a.CompanyId  for xml raw,root('Root') ) as Accepter");
            sql.Append(" FROM tbl_WorkReport as a");
            sql.Append(" WHERE   ReportId = @ReportId");
            var dc = this._db.GetSqlStringCommand(sql.ToString());
            this._db.AddInParameter(dc, "ReportId", DbType.Int32, Id);
            using (var dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    mdl.ReportId = dr.GetInt32(dr.GetOrdinal("ReportId"));
                    mdl.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    mdl.Title = dr["Title"].ToString();
                    mdl.Description = dr["Description"].ToString();
                    mdl.FilePath = dr["FilePath"].ToString();
                    mdl.DepartmentId = dr.GetInt32(dr.GetOrdinal("DepartmentId"));
                    mdl.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    mdl.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    mdl.ReportingTime = dr.GetDateTime(dr.GetOrdinal("ReportingTime"));
                    mdl.Status = (EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState)dr.GetByte(dr.GetOrdinal("Status"));
                    mdl.Comment = !dr.IsDBNull(dr.GetOrdinal("Comment")) ? dr["Comment"].ToString() : null;
                    mdl.CheckerId = !dr.IsDBNull(dr.GetOrdinal("CheckerId")) ? dr.GetInt32(dr.GetOrdinal("CheckerId")) : 0;
                    mdl.CheckTime = dr.IsDBNull(dr.GetOrdinal("CheckTime")) ? null : (DateTime?)dr.GetDateTime(dr.GetOrdinal("CheckTime"));
                    mdl.AcceptList = new List<WorkPlanAccept>();
                    mdl.AcceptList = !dr.IsDBNull(dr.GetOrdinal("Accepter")) ? GetWorkPlanAcceptLst(dr.GetString(dr.GetOrdinal("Accepter"))) : null;
                }
            }
            return mdl;
        }
        /// <summary>
        /// 分页工作交流集合
        /// </summary>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="CompanyId">公司编号 </param>
        /// <param name="OperatorId">操作人编号=0返回所有</param>
        /// <param name="QueryInfo">工作汇报查询实体</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PersonalCenterStructure.WorkReport> GetList(int pageSize, int pageIndex, ref int RecordCount, int CompanyId, int OperatorId, EyouSoft.Model.PersonalCenterStructure.QueryWorkReport QueryInfo)
        {
            IList<EyouSoft.Model.PersonalCenterStructure.WorkReport> list = new List<EyouSoft.Model.PersonalCenterStructure.WorkReport>();
            string tableName = "tbl_WorkReport";
            string fields = "ReportId,Title,ReportingTime,(select ContactName from tbl_CompanyUser where Id=tbl_WorkReport.OperatorId) as OperatorName,Status,(select DepartName from tbl_CompanyDepartment where Id=tbl_WorkReport.DepartmentId) as DepartName ";
            string orderbyStr = " ReportingTime DESC ";
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" CompanyId={0} and  IsDelete='0' ", CompanyId);
            if (!string.IsNullOrEmpty(QueryInfo.Title))
            {
                strWhere.AppendFormat(" and Title like '%{0}%' ", QueryInfo.Title);
            }
            if (QueryInfo.DepartmentId != 0)
            {
                strWhere.AppendFormat(" and DepartmentId={0} ", QueryInfo.DepartmentId);
            }
            if (!string.IsNullOrEmpty(QueryInfo.OperatorName))
            {
                strWhere.AppendFormat(" and exists(select 1 from tbl_CompanyUser where Id=tbl_WorkReport.OperatorId and ContactName like '%{0}%')", QueryInfo.OperatorName);
            }
            if (QueryInfo.CreateSDate.HasValue)
            {
                strWhere.AppendFormat(" and datediff(dd,ReportingTime,'{0}')<=0 ", QueryInfo.CreateSDate.Value.ToString());
            }

            if (QueryInfo.CreateEDate.HasValue)
            {
                strWhere.AppendFormat(" and datediff(dd,ReportingTime,'{0}')>=0 ", QueryInfo.CreateEDate.Value.ToString());
            }



            //if (CompanyId > 0)
            //{
            //    strWhere.AppendFormat(" and CompanyId={0} ", CompanyId);
            //}
            //if (OperatorId > 0)
            //{
            //    //strWhere.AppendFormat(" and ((dbo.fn_ValidUserLevDepartManagers({0},OperatorId)>0) OR (OperatorId={0})) ", OperatorId);
            //}
            //if (QueryInfo != null)
            //{
            //    if (!string.IsNullOrEmpty(QueryInfo.Title))
            //        strWhere.AppendFormat(" and Title like '%{0}%' ", QueryInfo.Title);

            //    if (!string.IsNullOrEmpty(QueryInfo.OperatorName))
            //        strWhere.AppendFormat(" and OperatorName like '%{0}%' ", QueryInfo.OperatorName);

            //    if (QueryInfo.DepartmentId > 0)
            //        strWhere.AppendFormat(" and DepartmentId={0} ", QueryInfo.DepartmentId);

            //    if (QueryInfo.CreateSDate.HasValue)
            //        strWhere.AppendFormat(" and datediff(dd,ReportingTime,'{0}')<=0 ", QueryInfo.CreateSDate.Value.ToString());

            //    if (QueryInfo.CreateEDate.HasValue)
            //        strWhere.AppendFormat(" and datediff(dd,ReportingTime,'{0}')>=0 ", QueryInfo.CreateEDate.Value.ToString());
            //}
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, fields, strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PersonalCenterStructure.WorkReport model = new EyouSoft.Model.PersonalCenterStructure.WorkReport();
                    if (!dr.IsDBNull(dr.GetOrdinal("ReportId")))
                        model.ReportId = dr.GetInt32(dr.GetOrdinal("ReportId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Title")))
                        model.Title = dr[dr.GetOrdinal("Title")].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorName")))
                        model.OperatorName = dr[dr.GetOrdinal("OperatorName")].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("DepartName")))
                        model.DepartmentName = dr[dr.GetOrdinal("DepartName")].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("Status")))
                        model.Status = (EyouSoft.Model.EnumType.PersonalCenterStructure.CheckState)int.Parse(dr[dr.GetOrdinal("Status")].ToString());
                    if (!dr.IsDBNull(dr.GetOrdinal("ReportingTime")))
                        model.ReportingTime = dr.GetDateTime(dr.GetOrdinal("ReportingTime"));
                    list.Add(model);
                    model = null;
                }
            }
            return list;
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="DepartId">部门编号</param>
        /// <returns></returns>
        private string GetDepartName(int DepartId)
        {
            string DepartName = string.Empty;
            EyouSoft.Model.CompanyStructure.Department departModel = new DAL.CompanyStructure.Department().GetModel(DepartId);
            if (departModel != null)
                DepartName = departModel.DepartName;
            departModel = null;
            return DepartName;
        }

        /// <summary>
        /// 创建接收对象XML
        /// </summary>
        /// <returns></returns>
        private string CreateAcceptXML(IList<EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept> list)
        {
            if (list == null) return null;
            if (list.Count == 0) return null;
            StringBuilder strXML = new StringBuilder("<ROOT>");
            foreach (EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept model in list)
            {
                strXML.AppendFormat("<AcceptInfo AccetpId=\"{0}\"  />", model.AccetpId);
            }
            strXML.Append("</ROOT>");
            return strXML.ToString();
        }

        /// <summary>
        /// xml to list
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private static IList<WorkPlanAccept> GetWorkPlanAcceptLst(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return null;
            }
            var x = XElement.Parse(xml);
            var r = Utils.GetXElements(x, "row");
            return r.Select(i => new WorkPlanAccept
            {
                PlanId = Utils.GetInt(Utils.GetXAttributeValue(i, "PlanId")),
                AccetpId = Utils.GetInt(Utils.GetXAttributeValue(i, "AccetpId")),
                AccetpName = Utils.GetXAttributeValue(i, "AccetpName")
            }).ToList();
        }
        #endregion
    }
}
