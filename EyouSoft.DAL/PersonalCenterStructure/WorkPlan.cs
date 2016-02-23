using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
namespace EyouSoft.DAL.PersonalCenterStructure
{
    using System.Xml.Linq;

    using EyouSoft.Model.PersonalCenterStructure;
    using EyouSoft.Toolkit;

    public class WorkPlan : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.PersonalCenterStructure.IWorkPlan
    {
        #region 变量
        private const string Sql_WorkPlan_Delete = "update tbl_WorkPlan set IsDelete='1' where PlanId in({0})";
        //private EyouSoft.Data.EyouSoftTBL dcDal = null;
        private Database _db = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkPlan()
        {
            _db = this.SystemStore;
            //dcDal = new EyouSoft.Data.EyouSoftTBL(this.SystemStore.ConnectionString);
        }
        #endregion

        #region IWorkPlan 成员
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">工作计划实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(EyouSoft.Model.PersonalCenterStructure.WorkPlan model)
        {
            DbCommand dc = this._db.GetStoredProcCommand("proc_WorkPlan_Insert");
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(dc, "Title", DbType.String, model.Title);
            this._db.AddInParameter(dc, "Description", DbType.String, model.Description);
            this._db.AddInParameter(dc, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(dc, "ExpectedDate", DbType.DateTime, model.ExpectedDate);
            this._db.AddInParameter(dc, "ActualDate", DbType.DateTime, model.ActualDate);
            this._db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(dc, "OperatorName", DbType.String, model.OperatorName);
            this._db.AddInParameter(dc, "Status", DbType.Byte, (int)model.Status);
            this._db.AddInParameter(dc, "WorkType", DbType.Byte, (int)model.WorkType);
            this._db.AddInParameter(dc, "AcceptXML", DbType.String, this.CreateAcceptXML(model.AcceptList));
            this._db.AddInParameter(dc, "PlanNO", DbType.String, model.PlanNO);
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            return Utils.GetInt(this._db.GetParameterValue(dc, "Result").ToString()) == 1 ? true : false;

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">工作计划实体</param>
        /// <returns> -1:审核 不允许修改 1:修改成功 0:修改失败</returns>
        public int Update(EyouSoft.Model.PersonalCenterStructure.WorkPlan model)
        {
            DbCommand dc = this._db.GetStoredProcCommand("proc_WorkPlan_Update");
            this._db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(dc, "Title", DbType.String, model.Title);
            this._db.AddInParameter(dc, "Description", DbType.String, model.Description);
            this._db.AddInParameter(dc, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(dc, "ExpectedDate", DbType.DateTime, model.ExpectedDate);
            this._db.AddInParameter(dc, "ActualDate", DbType.DateTime, model.ActualDate);
            this._db.AddInParameter(dc, "PlanId", DbType.Int32, model.PlanId);
            this._db.AddInParameter(dc, "Status", DbType.Byte, (int)model.Status);
            this._db.AddInParameter(dc, "WorkType", DbType.Byte, (int)model.WorkType);
            this._db.AddInParameter(dc, "AcceptXML", DbType.String, this.CreateAcceptXML(model.AcceptList));
            this._db.AddInParameter(dc, "PlanNO", DbType.String, model.PlanNO);
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            return Utils.GetInt(this._db.GetParameterValue(dc, "Result").ToString());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns>1:删除成功 0:删除失败 -1已审核的不允许删除</returns>
        public int Delete(int id)
        {
            DbCommand dc = this._db.GetStoredProcCommand("proc_WorkPlan_Delete");
            this._db.AddInParameter(dc, "Id", DbType.Int32, id);
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            return Utils.GetInt(this._db.GetParameterValue(dc, "Result").ToString());

        }

        /// <summary>
        /// 审核工作计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Check(EyouSoft.Model.PersonalCenterStructure.WorkPlan model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_WorkPlan_Check");
            this._db.AddInParameter(cmd, "PlanId", DbType.Int32, model.PlanId);
            this._db.AddInParameter(cmd, "CheckId", DbType.Int32, model.CheckId);
            this._db.AddInParameter(cmd, "ManagerComment", DbType.String, model.ManagerComment);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(cmd, this._db);
            object obj = this._db.GetParameterValue(cmd, "Result");
            return int.Parse(obj.ToString()) > 0 ? true : false;
        }

        /// <summary>
        /// 获取交流专区实体
        /// </summary>
        /// <param name="Id">主键编号</param>
        /// <returns>交流专区实体</returns>
        public EyouSoft.Model.PersonalCenterStructure.WorkPlan GetModel(int Id)
        {
            var sql = new StringBuilder();
            var mdl = new EyouSoft.Model.PersonalCenterStructure.WorkPlan();

            sql.Append(" SELECT  [PlanId],[PlanNO],");
            sql.Append("         [Title] ,");
            sql.Append("         [Description] ,");
            sql.Append("         [FilePath] ,");
            sql.Append("         [Remark] ,");
            sql.Append("         [OperatorId] ,");
            sql.Append("         (select ContactName from tbl_CompanyUser where Id=tbl_WorkPlan.OperatorId) as OperatorName ,");
            sql.Append("         [ExpectedDate] ,");
            sql.Append("         [ActualDate] ,");
            sql.Append("         [Status] ,");
            sql.Append("         [DepartmentComment] ,");
            sql.Append("         [ManagerComment] ,");
            sql.Append("         [CreateTime] ,");
            sql.Append("         [LastTime] ,");
            sql.AppendFormat("         (SELECT *,(select ContactName from tbl_CompanyUser where Id=tbl_WorkPlanAccept.AccetpId) as AccetpName FROM dbo.tbl_WorkPlanAccept  WHERE PlanId=tbl_WorkPlan.PlanId and CompanyId=tbl_WorkPlan.CompanyId and WorkType={0} for xml raw,root('Root')) as AcceptList,", (int)EyouSoft.Model.EnumType.PersonalCenterStructure.WorkType.工作计划);
            sql.Append("IsCheck,CheckId,(select ContactName from tbl_CompanyUser where Id=tbl_WorkPlan.CheckId) as CheckName,CheckDate");
            sql.Append(" FROM    [dbo].[tbl_WorkPlan]");
            sql.Append(" WHERE   PlanId = @PlanId");

            var dc = this._db.GetSqlStringCommand(sql.ToString());

            this._db.AddInParameter(dc, "PlanId", DbType.Int32, Id);

            using (var dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    mdl.PlanId = dr.GetInt32(dr.GetOrdinal("PlanId"));
                    mdl.PlanNO = !dr.IsDBNull(dr.GetOrdinal("PlanNO")) ? dr.GetString(dr.GetOrdinal("PlanNO")) : null;
                    mdl.Title = !dr.IsDBNull(dr.GetOrdinal("Title")) ? dr.GetString(dr.GetOrdinal("Title")) : null;
                    mdl.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : null;
                    mdl.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : null;
                    mdl.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null;
                    mdl.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    mdl.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    mdl.ExpectedDate = !dr.IsDBNull(dr.GetOrdinal("ExpectedDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("ExpectedDate")) : null;
                    mdl.ActualDate = !dr.IsDBNull(dr.GetOrdinal("ActualDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("ActualDate")) : null;
                    mdl.Status = (EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState)dr.GetByte(dr.GetOrdinal("Status"));
                    mdl.DepartmentComment = !dr.IsDBNull(dr.GetOrdinal("DepartmentComment")) ? dr.GetString(dr.GetOrdinal("DepartmentComment")) : null;
                    mdl.ManagerComment = !dr.IsDBNull(dr.GetOrdinal("ManagerComment")) ? dr.GetString(dr.GetOrdinal("ManagerComment")) : null;
                    mdl.CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"));
                    mdl.LastTime = !dr.IsDBNull(dr.GetOrdinal("LastTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("LastTime")) : null;
                    mdl.AcceptList = GetWorkPlanAcceptLst(dr["AcceptList"].ToString());
                    mdl.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1" ? true : false;
                    mdl.CheckId = !dr.IsDBNull(dr.GetOrdinal("CheckId")) ? dr.GetInt32(dr.GetOrdinal("CheckId")) : 0;
                    mdl.CheckName = !dr.IsDBNull(dr.GetOrdinal("CheckName")) ? dr.GetString(dr.GetOrdinal("CheckName")) : null;
                    mdl.CheckDate = !dr.IsDBNull(dr.GetOrdinal("CheckDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("CheckDate")) : null;
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
        /// <param name="CompanyId">公司编号 =0返回所有</param>
        /// <param name="OperatorId">操作人编号</param>
        /// <param name="QueryInfo">工作计划查询实体</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PersonalCenterStructure.WorkPlan> GetList(int pageSize, int pageIndex, ref int RecordCount, int CompanyId, int OperatorId, EyouSoft.Model.PersonalCenterStructure.QueryWorkPlan QueryInfo)
        {
            IList<EyouSoft.Model.PersonalCenterStructure.WorkPlan> list = new List<EyouSoft.Model.PersonalCenterStructure.WorkPlan>();
            string tableName = "tbl_WorkPlan";
            StringBuilder fileds = new StringBuilder();
            fileds.Append("   [PlanId],[PlanNO] ,");
            fileds.Append("   [Title] ,");
            fileds.Append("   [Description] ,");
            fileds.Append("         [FilePath] ,");
            fileds.Append("         [Remark] ,");
            fileds.Append("         [OperatorId] ,");
            fileds.Append("         (select ContactName from tbl_CompanyUser where Id=tbl_WorkPlan.OperatorId) as OperatorName ,");
            fileds.Append("         [ExpectedDate] ,");
            fileds.Append("         [ActualDate] ,");
            fileds.Append("         [Status] ,");
            fileds.Append("         [DepartmentComment] ,");
            fileds.Append("         [ManagerComment] ,");
            fileds.Append("         [CreateTime] ,");
            fileds.Append("         [LastTime] ,");
            fileds.AppendFormat("         (SELECT * FROM dbo.tbl_WorkPlanAccept  WHERE PlanId=tbl_WorkPlan.PlanId and CompanyId=tbl_WorkPlan.CompanyId and WorkType={0} for xml raw,root('Root')) as AcceptList,", (int)EyouSoft.Model.EnumType.PersonalCenterStructure.WorkType.工作计划);
            fileds.Append("IsCheck,CheckId,(select ContactName from tbl_CompanyUser where Id=tbl_WorkPlan.CheckId) as CheckName,CheckDate");


            string orderbyStr = " CreateTime DESC ";
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" CompanyId={0} and IsDelete='0' ", CompanyId);
            if (!string.IsNullOrEmpty(QueryInfo.Title))
            {
                strWhere.AppendFormat(" and Title like '%{0}%' ", QueryInfo.Title);
            }
            if (!string.IsNullOrEmpty(QueryInfo.OperatorName))
            {
                strWhere.AppendFormat(" and exists(select 1 from tbl_CompanyUser where Id=tbl_WorkPlan.OperatorId and ContactName like '%{0}%') ", QueryInfo.OperatorName);
            }

            if (QueryInfo.Status.HasValue)
            {
                strWhere.AppendFormat(" and Status ={0} ", (int)QueryInfo.Status.Value);
            }

            if (QueryInfo.EYuJiTime.HasValue)
            {
                strWhere.AppendFormat(" and ExpectedDate<'{0}' ", QueryInfo.EYuJiTime.Value.AddDays(1));
            }
            if (QueryInfo.Status.HasValue)
            {
                strWhere.AppendFormat(" and Status={0} ", (int)QueryInfo.Status.Value);
            }
            if (QueryInfo.SYuJiTime.HasValue)
            {
                strWhere.AppendFormat(" and ExpectedDate>'{0}' ", QueryInfo.SYuJiTime.Value.AddDays(-1));
            }

            ////if (CompanyId > 0)s
            ////    strWhere.AppendFormat(" and CompanyId={0} ", CompanyId);
            ////if (OperatorId > 0)
            ////{
            ////    strWhere.AppendFormat(" and ((PlanId in(select PlanId from tbl_WorkPlanAccept where AccetpId={0})) OR (OperatorId={0}) OR (dbo.fn_ValidUserLevDepartManagers({0},OperatorId)>0))", OperatorId);
            ////}
            ////if (QueryInfo != null)
            ////{
            ////    if (!string.IsNullOrEmpty(QueryInfo.Title))
            ////        strWhere.AppendFormat(" and Title like '%{0}%' ", QueryInfo.Title);
            ////    if (!string.IsNullOrEmpty(QueryInfo.OperatorName))
            ////        strWhere.AppendFormat(" and OperatorName like '%{0}%' ", QueryInfo.OperatorName);
            ////    if (QueryInfo.LastSTime.HasValue)
            ////        strWhere.AppendFormat(" and datediff(dd,LastTime,'{0}')<=0 ", QueryInfo.LastSTime.Value.ToString());
            ////    if (QueryInfo.LastETime.HasValue)
            ////        strWhere.AppendFormat(" and datediff(dd,LastTime,'{0}')>=0 ", QueryInfo.LastETime.Value.ToString());
            ////    if (QueryInfo.Status.HasValue)
            ////        strWhere.AppendFormat(" and Status={0} ", (int)QueryInfo.Status.Value);
            ////}
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, fileds.ToString(), strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PersonalCenterStructure.WorkPlan mdl = new EyouSoft.Model.PersonalCenterStructure.WorkPlan();
                    mdl.PlanId = dr.GetInt32(dr.GetOrdinal("PlanId"));
                    mdl.PlanNO = !dr.IsDBNull(dr.GetOrdinal("PlanNO")) ? dr.GetString(dr.GetOrdinal("PlanNO")) : null;
                    mdl.Title = !dr.IsDBNull(dr.GetOrdinal("Title")) ? dr.GetString(dr.GetOrdinal("Title")) : null;
                    mdl.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : null;
                    mdl.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : null;
                    mdl.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null;
                    mdl.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    mdl.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    mdl.ExpectedDate = !dr.IsDBNull(dr.GetOrdinal("ExpectedDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("ExpectedDate")) : null;
                    mdl.ActualDate = !dr.IsDBNull(dr.GetOrdinal("ActualDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("ActualDate")) : null;
                    mdl.Status = (EyouSoft.Model.EnumType.PersonalCenterStructure.PlanCheckState)dr.GetByte(dr.GetOrdinal("Status"));
                    mdl.DepartmentComment = !dr.IsDBNull(dr.GetOrdinal("DepartmentComment")) ? dr.GetString(dr.GetOrdinal("DepartmentComment")) : null;
                    mdl.ManagerComment = !dr.IsDBNull(dr.GetOrdinal("ManagerComment")) ? dr.GetString(dr.GetOrdinal("ManagerComment")) : null;
                    mdl.CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"));
                    mdl.LastTime = !dr.IsDBNull(dr.GetOrdinal("LastTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("LastTime")) : null;
                    mdl.AcceptList = GetWorkPlanAcceptLst(dr["AcceptList"].ToString());
                    mdl.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1" ? true : false;
                    mdl.CheckId = !dr.IsDBNull(dr.GetOrdinal("CheckId")) ? dr.GetInt32(dr.GetOrdinal("CheckId")) : 0;
                    mdl.CheckName = !dr.IsDBNull(dr.GetOrdinal("CheckName")) ? dr.GetString(dr.GetOrdinal("CheckName")) : null;
                    mdl.CheckDate = !dr.IsDBNull(dr.GetOrdinal("CheckDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("CheckDate")) : null;
                    list.Add(mdl);
                }
            }
            return list;
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 创建接收对象XML
        /// </summary>
        /// <returns></returns>
        private string CreateAcceptXML(IList<EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept> list)
        {
            StringBuilder strXML = new StringBuilder("<ROOT>");
            foreach (EyouSoft.Model.PersonalCenterStructure.WorkPlanAccept model in list)
            {
                strXML.AppendFormat("<AcceptInfo AccetpId=\"{0}\" />", model.AccetpId);
            }
            strXML.Append("</ROOT>");
            return strXML.ToString();
        }
        /// <summary>
        /// 根据接收对象编号获取接收名称
        /// </summary>
        /// <param name="AcceptId">接收对象编号</param>
        /// <returns></returns>
        private static string GetAcceptName(int AcceptId)
        {
            string AcceptName = string.Empty;
            var userModel = new DAL.CompanyStructure.CompanyUser().GetUserInfo(AcceptId);
            if (userModel != null)
                AcceptName = userModel.UserName;
            userModel = null;
            return AcceptName;
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
                AccetpName = Utils.GetXAttributeValue(i, "AccetpName"),
            }).ToList();
        }
        #endregion
    }
}
