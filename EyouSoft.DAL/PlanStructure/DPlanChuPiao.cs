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
    public class DPlanChuPiao : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.PlanStructure.IPlanChuPiao
    {
        #region 初始化db
        private Microsoft.Practices.EnterpriseLibrary.Data.Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DPlanChuPiao()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 添加押金登记
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:押金金额不能小于已登记的付款金额
        ///	-2:退回金额不能小于已登记的收款金额
        ///	-3:添加成功
        ///	-4:添加失败			
        /// </returns>
        public int YajinDengji(EyouSoft.Model.PlanStructure.MYaJinDengJi model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_KongWeiYajin");
            this._db.AddInParameter(cmd, "DaiLiId", DbType.AnsiStringFixedLength, model.DaiLiId);
            this._db.AddInParameter(cmd, "YaJinAmount", DbType.Currency, model.YaJinAmount);
            this._db.AddInParameter(cmd, "YaJinBeiZhu", DbType.String, model.YaJinBeiZhu);
            this._db.AddInParameter(cmd, "YaJinOperatorId", DbType.Int32, model.YaJinOperatorId);
            this._db.AddInParameter(cmd, "TuiYaJinAmount", DbType.Currency, model.TuiYaJinAmount);
            this._db.AddInParameter(cmd, "TuiYaJinBeiZhu", DbType.String, model.TuiYaJinBeiZhu);
            this._db.AddInParameter(cmd, "TuiTime", DbType.DateTime, model.TuiTime.HasValue ? (DateTime?)model.TuiTime : null);
            this._db.AddInParameter(cmd, "TuiYaJinOperatorId", DbType.Int32, model.TuiYaJinOperatorId);


            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 押金登记的列表（代理商信息）
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MYaJin> GetYaJinList(string kongWeiId)
        {

            IList<EyouSoft.Model.PlanStructure.MYaJin> list = null;

            StringBuilder query = new StringBuilder();
            query.Append("SELECT DaiLiId,GysName,Price,ShuLiang");
            query.Append(",GysOrderCode,YaJinAmount,YaJinBeiZhu");
            query.Append(",YaJinOperatorId,TuiYaJinAmount,TuiYaJinBeiZhu");
            query.Append(",TuiTime,TuiYaJinOperatorId,CheckMoney,ReturnMoney,YiChuPiao,ContactName,ContactTel,ShiXian ");
            query.Append(" FROM view_KongWeiYajin ");
            query.Append(" Where KongWeiId=@KongWeiId ORDER BY IdentityId ASC");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (dr != null)
                {
                    list = new List<EyouSoft.Model.PlanStructure.MYaJin>();
                    while (dr.Read())
                    {
                        EyouSoft.Model.PlanStructure.MYaJin model = new EyouSoft.Model.PlanStructure.MYaJin
                        {

                            DaiLiId = dr.GetString(dr.GetOrdinal("DaiLiId")),
                            GysName = !dr.IsDBNull(dr.GetOrdinal("GysName")) ? dr.GetString(dr.GetOrdinal("GysName")) : null,
                            Price = dr.GetDecimal(dr.GetOrdinal("Price")),
                            ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang")),
                            GysOrderCode = !dr.IsDBNull(dr.GetOrdinal("GysOrderCode")) ? dr.GetString(dr.GetOrdinal("GysOrderCode")) : null,
                            YaJinAmount = dr.GetDecimal(dr.GetOrdinal("YaJinAmount")),
                            YaJinBeiZhu = !dr.IsDBNull(dr.GetOrdinal("YaJinBeiZhu")) ? dr.GetString(dr.GetOrdinal("YaJinBeiZhu")) : null,
                            TuiYaJinOperatorId = !dr.IsDBNull(dr.GetOrdinal("TuiYaJinOperatorId")) ? dr.GetInt32(dr.GetOrdinal("TuiYaJinOperatorId")) : 0,
                            TuiYaJinAmount = dr.GetDecimal(dr.GetOrdinal("TuiYaJinAmount")),
                            TuiYaJinBeiZhu = !dr.IsDBNull(dr.GetOrdinal("TuiYaJinBeiZhu")) ? dr.GetString(dr.GetOrdinal("TuiYaJinBeiZhu")) : null,
                            TuiTime = !dr.IsDBNull(dr.GetOrdinal("TuiTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("TuiTime")) : null,
                            CheckMoney = dr.GetDecimal(dr.GetOrdinal("CheckMoney")),
                            ReturnMoney = dr.GetDecimal(dr.GetOrdinal("ReturnMoney")),
                            YaJinOperatorId = !dr.IsDBNull(dr.GetOrdinal("YaJinOperatorId")) ? dr.GetInt32(dr.GetOrdinal("YaJinOperatorId")) : 0,
                            YiChuPiao = dr.GetInt32(dr.GetOrdinal("YiChuPiao")),
                            ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : null,
                            ContactTel = !dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? dr.GetString(dr.GetOrdinal("ContactTel")) : null,
                            ShiXian = !dr.IsDBNull(dr.GetOrdinal("ShiXian")) ? dr.GetString(dr.GetOrdinal("ShiXian")) : null
                        };

                        list.Add(model);
                    }
                }
            }

            return list;
        }


        /// <summary>
        /// 添加安排出票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:出票数量大于剩余数量
        /// -2:当前操作存在不能正常出票游客	
        /// -3:添加成功
        /// -4:添加失败	
        /// </returns>
        public int AddPlanChuPiao(EyouSoft.Model.PlanStructure.MPlanChuPiao model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanChuPiao_Add");
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, model.PlanId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "JiaoYiHao", DbType.String, model.JiaoYiHao);
            this._db.AddInParameter(cmd, "DaiLiId", DbType.AnsiStringFixedLength, model.DaiLiId);
            this._db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, model.GysId);
            this._db.AddInParameter(cmd, "ShuLiang", DbType.Int32, model.ShuLiang);
            this._db.AddInParameter(cmd, "JieSuanMX", DbType.String, model.JieSuanMX);
            this._db.AddInParameter(cmd, "JieSuanAmount", DbType.Currency, model.JieSuanAmount);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "Traveller", DbType.Xml, GreatePlanChuPiaoYouKeXml(model.TravellerList, model.PlanId));
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }


        /// <summary>
        /// 修改安排出票
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:出票数量大于剩余数量
        /// -2:当前操作存在不能正常出票游客
        /// -3:修改成功
        /// -4:修改失败	
        /// -81:存在付款登记的出票安排不允许修改代理商信息
        /// </returns>
        public int UpdatePlanChuPiao(EyouSoft.Model.PlanStructure.MPlanChuPiao model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanChuPiao_Update");
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, model.PlanId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "JiaoYiHao", DbType.String, model.JiaoYiHao);
            this._db.AddInParameter(cmd, "DaiLiId", DbType.AnsiStringFixedLength, model.DaiLiId);
            this._db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, model.GysId);
            this._db.AddInParameter(cmd, "ShuLiang", DbType.Int32, model.ShuLiang);
            this._db.AddInParameter(cmd, "JieSuanMX", DbType.String, model.JieSuanMX);
            this._db.AddInParameter(cmd, "JieSuanAmount", DbType.Currency, model.JieSuanAmount);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "Traveller", DbType.Xml, GreatePlanChuPiaoYouKeXml(model.TravellerList, model.PlanId));

            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }


        /// <summary>
        /// 删除出票安排
        /// </summary>
        /// <param name="planId"></param>
        /// <returns>
        /// -1:已存在付款登记的出票安排，不可删除。
        /// -2:删除成功
        /// -3:删除失败		
        /// -4：存在退票安排，不可删除
        /// </returns>
        public int DeletePlanChuPiao(string planId)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanChuPiao_Delete");
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, planId);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 获取出票安排的信息
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public EyouSoft.Model.PlanStructure.MPlanChuPiao GetPlanChuPiaoById(string planId)
        {

            EyouSoft.Model.PlanStructure.MPlanChuPiao model = null;

            StringBuilder query = new StringBuilder();
            query.Append("SELECT PlanId,CompanyId,KongWeiId,JiaoYiHao,DaiLiId,GysId,ShuLiang,");
            query.Append("JieSuanMX,JieSuanAmount,Remark,FilePath,OperatorId,");
            query.Append("(select PlanId,YouKeId,OrderId from tbl_PlanChuPiaoYouKe ");
            query.Append("where PlanId=tbl_PlanChuPiao.PlanId for xml raw,root('Root')) as Traveller ");
            query.Append(" FROM tbl_PlanChuPiao ");
            query.Append(" Where PlanId=@PlanId ");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, planId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.PlanStructure.MPlanChuPiao
                    {
                        PlanId = dr.GetString(dr.GetOrdinal("PlanId")),
                        CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                        KongWeiId = dr.GetString(dr.GetOrdinal("KongWeiId")),
                        JiaoYiHao = !dr.IsDBNull(dr.GetOrdinal("JiaoYiHao")) ? dr.GetString(dr.GetOrdinal("JiaoYiHao")) : null,
                        DaiLiId = !dr.IsDBNull(dr.GetOrdinal("DaiLiId")) ? dr.GetString(dr.GetOrdinal("DaiLiId")) : string.Empty,
                        GysId = dr.GetString(dr.GetOrdinal("GysId")),
                        ShuLiang = !dr.IsDBNull(dr.GetOrdinal("ShuLiang")) ? dr.GetInt32(dr.GetOrdinal("ShuLiang")) : 0,
                        JieSuanMX = !dr.IsDBNull(dr.GetOrdinal("JieSuanMX")) ? dr.GetString(dr.GetOrdinal("JieSuanMX")) : null,
                        JieSuanAmount = !dr.IsDBNull(dr.GetOrdinal("JieSuanAmount")) ? dr.GetDecimal(dr.GetOrdinal("JieSuanAmount")) : 0,
                        Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null,
                        FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : null,
                        OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"))

                    };
                    model.TravellerList = new List<EyouSoft.Model.PlanStructure.MPlanYouKe>();
                    model.TravellerList = !dr.IsDBNull(dr.GetOrdinal("Traveller")) ? GetPlanYouKeByXml(dr.GetString(dr.GetOrdinal("Traveller"))) : null;
                }
            }
            return model;

        }

        /// <summary>
        /// 获取已安排出票列表
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MPlan_ChuPiao> GetPlanChuPiaoList(string kongWeiId)
        {
            IList<EyouSoft.Model.PlanStructure.MPlan_ChuPiao> list = new List<EyouSoft.Model.PlanStructure.MPlan_ChuPiao>();
            StringBuilder query = new StringBuilder();

            query.Append(" select ");
            query.Append("PlanId,KongWeiId,JiaoYiHao,");
            query.Append("(select UnitName from tbl_CompanySupplier  where Id=tbl_PlanChuPiao.GysId) as DaiLiName,");
            query.Append("(select GysOrderCode from tbl_KongWeiDaiLi where DaiLiId=tbl_PlanChuPiao.DaiLiId) as GysOrderCode,");
            query.Append("(select Price from tbl_KongWeiDaiLi where DaiLiId=tbl_PlanChuPiao.DaiLiId) as Price,");
            query.Append("ShuLiang,JieSuanMX,JieSuanAmount,");
            query.AppendFormat("(select Sum(CollectionRefundAmount) from tbl_FinCope where CollectionId=tbl_PlanChuPiao.PlanId and CollectionItem={0} and Status=2) as PayMoney,", (int)EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务安排付款);
            query.Append("Remark,FilePath");
            query.Append(" ,(SELECT ContactName FROM tbl_CompanyUser AS B WHERE B.Id=tbl_PlanChuPiao.OperatorId) AS OperatorName ");
            query.Append(" ,IssueTime ");
            query.Append(" from  tbl_PlanChuPiao  ");
            query.Append(" Where KongWeiId=@KongWeiId ");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PlanStructure.MPlan_ChuPiao model = new EyouSoft.Model.PlanStructure.MPlan_ChuPiao();
                    model.PlanId = dr.GetString(dr.GetOrdinal("PlanId"));
                    model.JiaoYiHao = !dr.IsDBNull(dr.GetOrdinal("JiaoYiHao")) ? dr.GetString(dr.GetOrdinal("JiaoYiHao")) : string.Empty;
                    model.DaiLiName = !dr.IsDBNull(dr.GetOrdinal("DaiLiName")) ? dr.GetString(dr.GetOrdinal("DaiLiName")) : string.Empty;
                    model.GysOrderCode = !dr.IsDBNull(dr.GetOrdinal("GysOrderCode")) ? dr.GetString(dr.GetOrdinal("GysOrderCode")) : string.Empty;
                    model.Price = !dr.IsDBNull(dr.GetOrdinal("Price")) ? dr.GetDecimal(dr.GetOrdinal("Price")) : 0;
                    model.ShuLiang = !dr.IsDBNull(dr.GetOrdinal("ShuLiang")) ? dr.GetInt32(dr.GetOrdinal("ShuLiang")) : 0;
                    model.JieSuanMX = !dr.IsDBNull(dr.GetOrdinal("JieSuanMX")) ? dr.GetString(dr.GetOrdinal("JieSuanMX")) : string.Empty;
                    model.JieSuanAmount = !dr.IsDBNull(dr.GetOrdinal("JieSuanAmount")) ? dr.GetDecimal(dr.GetOrdinal("JieSuanAmount")) : 0;
                    model.PayMoney = !dr.IsDBNull(dr.GetOrdinal("PayMoney")) ? dr.GetDecimal(dr.GetOrdinal("PayMoney")) : 0;
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : string.Empty;
                    model.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : string.Empty;
                    model.OperatorName = dr["OperatorName"].ToString();
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
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
        private string GreatePlanChuPiaoYouKeXml(IList<EyouSoft.Model.PlanStructure.MPlanYouKe> list, string planId)
        {
            if (list == null || list.Count == 0) return null;
            StringBuilder xmlDoc = new StringBuilder();
            xmlDoc.Append("<Root>");
            foreach (EyouSoft.Model.PlanStructure.MPlanYouKe model in list)
            {
                xmlDoc.AppendFormat("<Traveller PlanId=\"{0}\" YouKeId=\"{1}\" OrderId=\"{2}\" />", planId, model.YouKeId, model.OrderId);
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
