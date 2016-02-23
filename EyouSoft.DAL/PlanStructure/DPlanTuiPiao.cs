using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.PlanStructure
{
    public class DPlanTuiPiao : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.PlanStructure.IPlanTuiPiao
    {

        #region 初始化db
        private Microsoft.Practices.EnterpriseLibrary.Data.Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DPlanTuiPiao()
        {
            _db = base.SystemStore;
        }
        #endregion


        /// <summary>
        /// 添加退票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:存在不能正常退票的游客
        /// -2:添加成功
        /// -3:添加失败			
        /// </returns>
        public int AddPlanTuiPiao(EyouSoft.Model.PlanStructure.MPlanTuiPiao model)
        {

            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanTuiPiao_Add");
            this._db.AddInParameter(cmd, "TuiId", DbType.AnsiStringFixedLength, model.TuiId);
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, model.PlanId);
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(cmd, "ShuLiang", DbType.Int32, model.ShuLiang);
            this._db.AddInParameter(cmd, "TuiTime", DbType.DateTime, model.TuiTime.HasValue ? (DateTime?)model.TuiTime.Value : null);
            this._db.AddInParameter(cmd, "SunShiMX", DbType.String, model.SunShiMX);
            this._db.AddInParameter(cmd, "SunShiAmount", DbType.Currency, model.SunShiAmount);
            this._db.AddInParameter(cmd, "ChengDanFang", DbType.String, model.ChengDanFang);
            this._db.AddInParameter(cmd, "TuiAmount", DbType.Currency, model.TuiAmount);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "Traveller", DbType.Xml, GreatePlanTuiPiaoYouKeXml(model.TravellerList, model.TuiId));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 修改退票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:存在不能正常退票的游客
        /// -2:添加成功
        /// -3:添加失败	
        /// </returns>
        public int UpdatePlanTuiPiao(EyouSoft.Model.PlanStructure.MPlanTuiPiao model)
        {

            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanTuiPiao_Update");
            this._db.AddInParameter(cmd, "TuiId", DbType.AnsiStringFixedLength, model.TuiId);
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, model.PlanId);
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(cmd, "ShuLiang", DbType.Int32, model.ShuLiang);
            this._db.AddInParameter(cmd, "TuiTime", DbType.DateTime, model.TuiTime.HasValue ? (DateTime?)model.TuiTime.Value : null);
            this._db.AddInParameter(cmd, "SunShiMX", DbType.String, model.SunShiMX);
            this._db.AddInParameter(cmd, "SunShiAmount", DbType.Currency, model.SunShiAmount);
            this._db.AddInParameter(cmd, "ChengDanFang", DbType.String, model.ChengDanFang);
            this._db.AddInParameter(cmd, "TuiAmount", DbType.Currency, model.TuiAmount);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "Traveller", DbType.Xml, GreatePlanTuiPiaoYouKeXml(model.TravellerList, model.TuiId));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }


        /// <summary>
        /// 删除退票
        /// </summary>
        /// <param name="tuiId"></param>
        /// <returns>
        /// -1:已经存在收款登记的退票项，不允许删除
        /// -2:删除成功
        /// -3:删除失败	
        /// </returns>
        public int DeletePlanTuiPiao(string tuiId)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanTuiPiao_Delete");
            this._db.AddInParameter(cmd, "TuiId", DbType.AnsiStringFixedLength, tuiId);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 根据退票编号获取退票实体
        /// </summary>
        /// <param name="tuiId"></param>
        /// <returns></returns>
        public EyouSoft.Model.PlanStructure.MPlanTuiPiao GetPlanTuiPiaoById(string tuiId)
        {
            EyouSoft.Model.PlanStructure.MPlanTuiPiao model = null;

            StringBuilder query = new StringBuilder();
            query.Append("SELECT TuiId,PlanId,KongWeiId,OrderId,TuiTime");
            query.Append(",ShuLiang,SunShiMX,SunShiAmount,ChengDanFang");
            query.Append(",TuiAmount,Remark,OperatorId,");
            query.Append("(SELECT TuiId,YouKeId,OrderId FROM tbl_PlanTuiPiaoYouKe  WHERE TuiId=@TuiId for xml raw,root('Root') ) as Traveller,  ");
            query.Append("(select ContactName from tbl_CompanyUser where Id=tbl_PlanTuiPiao.OperatorId) as OperatorName,");
            query.Append("(select (select Name from tbl_Customer where Id=BuyCompanyId) from tbl_TourOrder where OrderId=tbl_PlanTuiPiao.OrderId) as BuyCompanyName");
            query.Append(" FROM tbl_PlanTuiPiao ");
            query.Append(" Where TuiId=@TuiId");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "TuiId", DbType.AnsiStringFixedLength, tuiId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.PlanStructure.MPlanTuiPiao();

                    model.TuiId = dr.GetString(dr.GetOrdinal("TuiId"));
                    model.PlanId = dr.GetString(dr.GetOrdinal("PlanId"));
                    model.KongWeiId = dr.GetString(dr.GetOrdinal("KongWeiId"));
                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.TuiTime = !dr.IsDBNull(dr.GetOrdinal("TuiTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("TuiTime")) : null;
                    model.ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang"));
                    model.SunShiMX = !dr.IsDBNull(dr.GetOrdinal("SunShiMX")) ? dr.GetString(dr.GetOrdinal("SunShiMX")) : null;
                    model.SunShiAmount = dr.GetDecimal(dr.GetOrdinal("SunShiAmount"));
                    model.ChengDanFang = !dr.IsDBNull(dr.GetOrdinal("ChengDanFang")) ? dr.GetString(dr.GetOrdinal("ChengDanFang")) : null;
                    model.TuiAmount = dr.GetDecimal(dr.GetOrdinal("TuiAmount"));
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null;
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    model.BuyCompanyName = !dr.IsDBNull(dr.GetOrdinal("BuyCompanyName")) ? dr.GetString(dr.GetOrdinal("BuyCompanyName")) : null;
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;

                    model.TravellerList = new List<EyouSoft.Model.PlanStructure.MPlanYouKe>();
                    model.TravellerList = !dr.IsDBNull(dr.GetOrdinal("Traveller")) ? GetPlanYouKeByXml(dr.GetString(dr.GetOrdinal("Traveller"))) : null;
                }
            }

            return model;
        }


        /// <summary>
        /// 获取退票列表
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MPlan_TuiPiao> GetPlanTuiPiaoList(string planId)
        {
            IList<EyouSoft.Model.PlanStructure.MPlan_TuiPiao> list = new List<EyouSoft.Model.PlanStructure.MPlan_TuiPiao>();

            StringBuilder query = new StringBuilder();
            query.Append("SELECT TuiId,PlanId,KongWeiId,OrderId,TuiTime");
            query.Append(",ShuLiang,SunShiMX,SunShiAmount,ChengDanFang");
            query.Append(",TuiAmount,Remark,");
            query.Append("(select ContactName from tbl_CompanyUser where Id=tbl_PlanTuiPiao.OperatorId) as OperatorName,");
            query.Append("(select (select Name from tbl_Customer where Id=BuyCompanyId) from tbl_TourOrder where OrderId=tbl_PlanTuiPiao.OrderId) as BuyCompanyName");
            query.Append(" FROM tbl_PlanTuiPiao ");
            query.Append("Where PlanId=@PlanId");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, planId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PlanStructure.MPlan_TuiPiao model = new EyouSoft.Model.PlanStructure.MPlan_TuiPiao
                    {
                        TuiId = dr.GetString(dr.GetOrdinal("TuiId")),
                        PlanId = dr.GetString(dr.GetOrdinal("PlanId")),
                        KongWeiId = dr.GetString(dr.GetOrdinal("KongWeiId")),
                        OrderId = dr.GetString(dr.GetOrdinal("OrderId")),
                        TuiTime = !dr.IsDBNull(dr.GetOrdinal("TuiTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("TuiTime")) : null,
                        ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang")),
                        SunShiMX = !dr.IsDBNull(dr.GetOrdinal("SunShiMX")) ? dr.GetString(dr.GetOrdinal("SunShiMX")) : null,
                        SunShiAmount = dr.GetDecimal(dr.GetOrdinal("SunShiAmount")),
                        ChengDanFang = !dr.IsDBNull(dr.GetOrdinal("ChengDanFang")) ? dr.GetString(dr.GetOrdinal("ChengDanFang")) : null,
                        TuiAmount = dr.GetDecimal(dr.GetOrdinal("TuiAmount")),
                        Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null,
                        OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null,
                        BuyCompanyName = !dr.IsDBNull(dr.GetOrdinal("BuyCompanyName")) ? dr.GetString(dr.GetOrdinal("BuyCompanyName")) : null

                    };
                    list.Add(model);
                }
            }
            return list;
        }



        #region 私有方法
        /// <summary>
        /// 创建出票游客的xml
        /// </summary>
        /// <param name="list"></param>
        /// <param name="planId"></param>
        /// <returns></returns>
        private string GreatePlanTuiPiaoYouKeXml(IList<EyouSoft.Model.PlanStructure.MPlanYouKe> list, string tuiId)
        {
            if (list == null || list.Count == 0) return null;
            StringBuilder xmlDoc = new StringBuilder();
            xmlDoc.Append("<Root>");
            foreach (EyouSoft.Model.PlanStructure.MPlanYouKe model in list)
            {
                xmlDoc.AppendFormat("<Traveller TuiId=\"{0}\" YouKeId=\"{1}\" OrderId=\"{2}\" />", tuiId, model.YouKeId, model.OrderId);
            }
            xmlDoc.Append("</Root>");
            return xmlDoc.ToString();
        }

        /// <summary>
        /// 获取游客的xml
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private IList<EyouSoft.Model.PlanStructure.MPlanYouKe> GetPlanYouKeByXml(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;
            IList<EyouSoft.Model.PlanStructure.MPlanYouKe> list = new List<EyouSoft.Model.PlanStructure.MPlanYouKe>();
            System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
            var xRows = Utils.GetXElements(xRoot, "row");
            foreach (var xRow in xRows)
            {
                EyouSoft.Model.PlanStructure.MPlanYouKe item = new EyouSoft.Model.PlanStructure.MPlanYouKe
                {
                    Id = Utils.GetXAttributeValue(xRow, "PlanId"),
                    YouKeId = Utils.GetXAttributeValue(xRow, "YouKeId"),
                    OrderId = Utils.GetXAttributeValue(xRow, "OrderId")
                };

                list.Add(item);
            }
            return list;
        }

        #endregion
    }
}
