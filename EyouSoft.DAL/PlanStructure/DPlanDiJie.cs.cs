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
    public class DPlanDiJie : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.PlanStructure.IPlanDiJie
    {
        #region static constants
        //static constants
        const string SQL_UPDATE_SetDaoYou = "UPDATE [tbl_PlanDiJie] SET [DaoYouId]=@DaoYouId WHERE [PlanId]=@AnPaiId";
        #endregion

        #region 初始化db
        private Microsoft.Practices.EnterpriseLibrary.Data.Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DPlanDiJie()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 数组转换为字符串
        /// </summary>
        /// <param name="OrderIds"></param>
        /// <returns></returns>
        private string GetStringByArray(params string[] OrderIds)
        {
            string Ids = string.Empty;
            if (OrderIds != null)
            {
                foreach (string id in OrderIds)
                {
                    Ids += id + ",";
                }
                Ids = Ids.Substring(0, Ids.Length - 1);
            }
            return Ids;
        }

        /// <summary>
        /// 根据xml获取地接安排的订单
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private string[] GetOrderIdByXml(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;
            string[] orderIds = null;
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);
            System.Xml.XmlNode nodes = doc.SelectSingleNode("Root");

            if (nodes != null && nodes.HasChildNodes)
            {
                orderIds = new string[nodes.ChildNodes.Count];
                for (int i = 0; i < nodes.ChildNodes.Count; i++)
                {
                    System.Xml.XmlNode item = nodes.ChildNodes[i];
                    orderIds[i] = item.Attributes["OrderId"].Value;
                }
            }

            return orderIds;

        }

        #endregion

        #region IPlanDiJie 成员

        /// <summary>
        /// 添加地接安排
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:已经安排地接的订单 不能重新安排
        /// -2:当订单性质为团队时，一次只能选择一个订单进行地接安排
        /// -3:当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
        /// 1:安排成功 0:安排失败</returns>
        public int AddPlanDiJie(EyouSoft.Model.PlanStructure.MPlanDiJie model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanDiJie_Add");
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, model.PlanId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "JiaoYiHao", DbType.String, model.JiaoYiHao);
            this._db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, model.GysId);
            this._db.AddInParameter(cmd, "RouteId", DbType.AnsiStringFixedLength, model.RouteId);
            this._db.AddInParameter(cmd, "LxrName", DbType.String, model.LxrName);
            this._db.AddInParameter(cmd, "LxrTelephone", DbType.String, model.LxrTelephone);
            this._db.AddInParameter(cmd, "ChengRenShu", DbType.Int32, model.ChengRenShu);
            this._db.AddInParameter(cmd, "ErTongShu", DbType.Int32, model.ErTongShu);
            this._db.AddInParameter(cmd, "QuPeiShu", DbType.Int32, model.QuPeiShu);
            this._db.AddInParameter(cmd, "QuPeiName", DbType.String, model.QuPeiName);
            //this._db.AddInParameter(cmd, "DaoYouId", DbType.Int32, model.DaoYouId);
            this._db.AddInParameter(cmd, "YongCan", DbType.String, model.YongCan);
            this._db.AddInParameter(cmd, "JieSuanMX", DbType.String, model.JieSuanMX);
            this._db.AddInParameter(cmd, "JieSuanAmount", DbType.Currency, model.JieSuanAmount);
            this._db.AddInParameter(cmd, "JieTuanFangShi", DbType.String, model.JieTuanFangShi);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "OrderIds", DbType.String, GetStringByArray(model.OrderId)); 
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "YouKeXinXi", DbType.String, model.YouKeXinXi);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);
            _db.AddInParameter(cmd, "YingErShu", DbType.Int32, model.YingErShu);
            _db.AddInParameter(cmd, "NeiBuBeiZhu", DbType.String, model.NeiBuBeiZhu);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));

        }

        /// <summary>
        /// 删除地接安排
        /// </summary>
        /// <param name="planId"></param>
        /// <returns>1:删除成功 0:修改失败,-1：已经登记过付款的安排项不允许删除。。</returns>
        public int DeletePlanDiJie(string planId)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanDiJie_Delete");
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, planId);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));

        }


        /// <summary>
        /// 修改地接安排
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:已经安排地接的订单 不能重新安排
        /// -2:当订单性质为团队时，一次只能选择一个订单进行地接安排
        /// -3:当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
        /// 1:修改成功 0:修改失败</returns>
        public int UpdatePlanDiJie(EyouSoft.Model.PlanStructure.MPlanDiJie model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_PlanDiJie_Update");
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, model.PlanId);
            this._db.AddInParameter(cmd, "CompanyId", DbType.Int32, model.CompanyId);
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, model.KongWeiId);
            this._db.AddInParameter(cmd, "JiaoYiHao", DbType.String, model.JiaoYiHao);
            this._db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, model.GysId);
            this._db.AddInParameter(cmd, "RouteId", DbType.AnsiStringFixedLength, model.RouteId);
            this._db.AddInParameter(cmd, "LxrName", DbType.String, model.LxrName);
            this._db.AddInParameter(cmd, "LxrTelephone", DbType.String, model.LxrTelephone);
            this._db.AddInParameter(cmd, "ChengRenShu", DbType.Int32, model.ChengRenShu);
            this._db.AddInParameter(cmd, "ErTongShu", DbType.Int32, model.ErTongShu);
            this._db.AddInParameter(cmd, "QuPeiShu", DbType.Int32, model.QuPeiShu);
            this._db.AddInParameter(cmd, "QuPeiName", DbType.String, model.QuPeiName);
            //this._db.AddInParameter(cmd, "DaoYouId", DbType.Int32, model.DaoYouId);
            this._db.AddInParameter(cmd, "YongCan", DbType.String, model.YongCan);
            this._db.AddInParameter(cmd, "JieSuanMX", DbType.String, model.JieSuanMX);
            this._db.AddInParameter(cmd, "JieSuanAmount", DbType.Currency, model.JieSuanAmount);
            this._db.AddInParameter(cmd, "JieTuanFangShi", DbType.String, model.JieTuanFangShi);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "OrderIds", DbType.String, GetStringByArray(model.OrderId));  
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "YouKeXinXi", DbType.String, model.YouKeXinXi);
            _db.AddInParameter(cmd, "YingErShu", DbType.Int32, model.YingErShu);
            _db.AddInParameter(cmd, "NeiBuBeiZhu", DbType.String, model.NeiBuBeiZhu);

            DbHelper.RunProcedureWithResult(cmd, _db);
            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 获取地接安排信息
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public EyouSoft.Model.PlanStructure.MPlanDiJie GetPlanDiJieById(string planId)
        {
            EyouSoft.Model.PlanStructure.MPlanDiJie model = null;

            StringBuilder query = new StringBuilder();
            query.Append("SELECT A.* ");
            query.Append(",(SELECT A1.OrderId FROM tbl_PlanDiJIeOrder AS A1 WHERE A1.PlanId=A.PlanId for xml raw,root('Root')) AS OrderId");
            query.Append(",(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE  A1.Id=A.GysId) AS GysName");
            //query.Append("(select A1.ContactName from tbl_CompanyUser AS A1 where A1.Id=A.DaoYouId) as DaoYouName ");
            query.Append(" ,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName ");
            query.Append(" ,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.DiJieQueRenRenId) AS DiJieQueRenRenName ");
            query.Append(",(SELECT A1.MingCheng FROM tbl_Pt_ZhuanXianShang AS A1 WHERE A1.ZxsId=A.ZxsId) AS ZxsName");
            query.Append(",(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName");
            query.Append("  FROM tbl_PlanDiJie AS A");
            query.Append(" Where A.PlanId=@PlanId");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, planId);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.PlanStructure.MPlanDiJie
                    {
                        PlanId = dr.GetString(dr.GetOrdinal("PlanId")),
                        CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                        KongWeiId = !dr.IsDBNull(dr.GetOrdinal("KongWeiId")) ? dr.GetString(dr.GetOrdinal("KongWeiId")) : null,
                        JiaoYiHao = !dr.IsDBNull(dr.GetOrdinal("JiaoYiHao")) ? dr.GetString(dr.GetOrdinal("JiaoYiHao")) : null,
                        GysId = !dr.IsDBNull(dr.GetOrdinal("GysId")) ? dr.GetString(dr.GetOrdinal("GysId")) : null,
                        RouteId = !dr.IsDBNull(dr.GetOrdinal("RouteId")) ? dr.GetString(dr.GetOrdinal("RouteId")) : null,
                        LxrName = !dr.IsDBNull(dr.GetOrdinal("LxrName")) ? dr.GetString(dr.GetOrdinal("LxrName")) : null,
                        LxrTelephone = !dr.IsDBNull(dr.GetOrdinal("LxrTelephone")) ? dr.GetString(dr.GetOrdinal("LxrTelephone")) : null,
                        ChengRenShu = dr.GetInt32(dr.GetOrdinal("ChengRenShu")),
                        ErTongShu = dr.GetInt32(dr.GetOrdinal("ErTongShu")),
                        QuPeiShu = dr.GetInt32(dr.GetOrdinal("QuPeiShu")),
                        QuPeiName = !dr.IsDBNull(dr.GetOrdinal("QuPeiName")) ? dr.GetString(dr.GetOrdinal("QuPeiName")) : null,
                        DaoYouId = !dr.IsDBNull(dr.GetOrdinal("DaoYouId")) ? dr.GetInt32(dr.GetOrdinal("DaoYouId")) : 0,
                        YongCan = !dr.IsDBNull(dr.GetOrdinal("YongCan")) ? dr.GetString(dr.GetOrdinal("YongCan")) : null,
                        JieSuanMX = !dr.IsDBNull(dr.GetOrdinal("JieSuanMX")) ? dr.GetString(dr.GetOrdinal("JieSuanMX")) : null,
                        JieSuanAmount = dr.GetDecimal(dr.GetOrdinal("JieSuanAmount")),
                        OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId")),
                        Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null,
                        DaoYouName = !dr.IsDBNull(dr.GetOrdinal("DaoYouName")) ? dr.GetString(dr.GetOrdinal("DaoYouName")) : null,
                        GysName = !dr.IsDBNull(dr.GetOrdinal("GysName")) ? dr.GetString(dr.GetOrdinal("GysName")) : null,
                        JieTuanFangShi = !dr.IsDBNull(dr.GetOrdinal("JieTuanFangShi")) ? dr.GetString(dr.GetOrdinal("JieTuanFangShi")) : ""
                    };
                    model.OrderId = new string[] { };
                    model.OrderId = !dr.IsDBNull(dr.GetOrdinal("OrderId")) ? GetOrderIdByXml(dr.GetString(dr.GetOrdinal("OrderId"))) : null;
                    model.OperatorName = dr["OperatorName"].ToString();
                    model.YouKeXinXi = dr["YouKeXinXi"].ToString();
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.YingErShu = dr.GetInt32(dr.GetOrdinal("YingErShu"));

                    model.DiJieQueRenRenId = dr.GetInt32(dr.GetOrdinal("DiJieQueRenRenId"));
                    model.DiJieQueRenRenName = dr["DiJieQueRenRenName"].ToString();
                    model.DiJieQueRenStatus = (EyouSoft.Model.EnumType.TourStructure.QueRenStatus)dr.GetInt32(dr.GetOrdinal("DiJieQueRenStatus"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DiJieQueRenTime"))) model.DiJieQueRenTime = dr.GetDateTime(dr.GetOrdinal("DiJieQueRenTime"));
                    model.DiJieRouteName = dr["DiJieRouteName"].ToString();
                    model.DiJieTuanHao = dr["DiJieTuanHao"].ToString();
                    model.ZxsId = dr["ZxsId"].ToString();
                    model.ZxsName = dr["ZxsName"].ToString();
                    model.RouteName = dr["RouteName"].ToString();
                    model.NeiBuBeiZhu = dr["NeiBuBeiZhu"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 已安排地接列表
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MPlan_DiJie> GetPlanDiJieList(string kongWeiId)
        {
            IList<EyouSoft.Model.PlanStructure.MPlan_DiJie> list = new List<EyouSoft.Model.PlanStructure.MPlan_DiJie>();
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT * ");
            query.Append("  FROM view_PlanDiJie ");
            query.Append(" Where KongWeiId=@KongWeiId ORDER BY IssueTime ASC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PlanStructure.MPlan_DiJie model = new EyouSoft.Model.PlanStructure.MPlan_DiJie();

                    model.PlanId = dr.GetString(dr.GetOrdinal("PlanId"));
                    model.KongWeiId = dr.GetString(dr.GetOrdinal("KongWeiId"));
                    model.KongWeiCode = !dr.IsDBNull(dr.GetOrdinal("JiaoYiHao")) ? dr.GetString(dr.GetOrdinal("JiaoYiHao")) : null;
                    model.GysName = !dr.IsDBNull(dr.GetOrdinal("GysName")) ? dr.GetString(dr.GetOrdinal("GysName")) : null;
                    model.ChengRenShu = dr.GetInt32(dr.GetOrdinal("ChengRenShu"));
                    model.ErTongShu = dr.GetInt32(dr.GetOrdinal("ErTongShu"));
                    model.QuPeiShu = dr.GetInt32(dr.GetOrdinal("QuPeiShu"));
                    model.RouteName = !dr.IsDBNull(dr.GetOrdinal("RouteName")) ? dr.GetString(dr.GetOrdinal("RouteName")) : null;
                    model.DaoYouName = !dr.IsDBNull(dr.GetOrdinal("DaoYouName")) ? dr.GetString(dr.GetOrdinal("DaoYouName")) : null;
                    model.JieTuanFangShi = !dr.IsDBNull(dr.GetOrdinal("JieTuanFangShi")) ? dr.GetString(dr.GetOrdinal("JieTuanFangShi")) : null;
                    model.JieSuanAmount = dr.GetDecimal(dr.GetOrdinal("JieSuanAmount"));
                    model.PayAmount = !dr.IsDBNull(dr.GetOrdinal("PayAmount")) ? dr.GetDecimal(dr.GetOrdinal("PayAmount")) : 0;
                    model.OperatorName = dr["OperatorName"].ToString();
                    model.YingErShu = dr.GetInt32(dr.GetOrdinal("YingErShu"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));

                    model.DiJieQueRenRenId = dr.GetInt32(dr.GetOrdinal("DiJieQueRenRenId"));
                    model.DiJieQueRenRenName = dr["DiJieQueRenRenName"].ToString();
                    model.DiJieQueRenStatus = (EyouSoft.Model.EnumType.TourStructure.QueRenStatus)dr.GetInt32(dr.GetOrdinal("DiJieQueRenStatus"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DiJieQueRenTime"))) model.DiJieQueRenTime = dr.GetDateTime(dr.GetOrdinal("DiJieQueRenTime"));

                    list.Add(model);
                }
            }
            return list;

        }


        /// <summary>
        /// 获取已安排地接的订单信息
        /// </summary>
        /// <param name="PlanId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MDiJieOrder> GetDiJieOrder(string PlanId)
        {

            IList<EyouSoft.Model.PlanStructure.MDiJieOrder> list = new List<EyouSoft.Model.PlanStructure.MDiJieOrder>();
            StringBuilder query = new StringBuilder();
            query.Append("select OrderId, OrderCode,BusinessNature,");
            query.Append("(SELECT B.RouteName FROM tbl_Route AS B WHERE B.RouteId=A.RouteId) AS RouteName,");
            query.Append("(select Name from tbl_Customer as B where B.Id=A.BuyCompanyId) as BuyCompanyName,");
            query.Append("Adults,Childs,Bears,Accounts,PriceDetials,SumPrice,A.YingErRenShu");
            query.Append(" from tbl_TourOrder as A ");
            query.Append(" where OrderId in (select OrderId from tbl_PlanDiJIeOrder where PlanId=@PlanId) ");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "PlanId", DbType.AnsiStringFixedLength, PlanId);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.PlanStructure.MDiJieOrder model = new EyouSoft.Model.PlanStructure.MDiJieOrder();
                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));

                    model.BusinessNature = (EyouSoft.Model.EnumType.TourStructure.BusinessNature)dr.GetByte(dr.GetOrdinal("BusinessNature"));
                    model.Adults = dr.GetInt32(dr.GetOrdinal("Adults"));
                    model.Childs = dr.GetInt32(dr.GetOrdinal("Childs"));
                    model.Bears = dr.GetInt32(dr.GetOrdinal("Bears"));
                    model.Accounts = dr.GetInt32(dr.GetOrdinal("Accounts"));

                    model.BuyCompanyName = !dr.IsDBNull(dr.GetOrdinal("BuyCompanyName")) ? dr.GetString(dr.GetOrdinal("BuyCompanyName")) : null;

                    model.RouteName = !dr.IsDBNull(dr.GetOrdinal("RouteName")) ? dr.GetString(dr.GetOrdinal("RouteName")) : null;
                    model.PriceDetials = dr.GetString(dr.GetOrdinal("PriceDetials"));
                    model.SumPrice = dr.GetDecimal(dr.GetOrdinal("SumPrice"));
                    model.YingErShu = dr.GetInt32(dr.GetOrdinal("YingErRenShu"));

                    list.Add(model);

                }
            }
            return list;

        }

        /// <summary>
        /// 设置地接安排导游，返回1成功，其它失败
        /// </summary>
        /// <param name="anPaiId">地接安排编号</param>
        /// <param name="daoYouId">导游编号</param>
        /// <returns></returns>
        public int SetDaoYou(string anPaiId, int daoYouId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SetDaoYou);
            _db.AddInParameter(cmd, "DaoYouId", DbType.Int32, daoYouId);
            _db.AddInParameter(cmd, "AnPaiId", DbType.AnsiStringFixedLength, anPaiId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }        

        /// <summary>
        /// 地接平台-获取地接安排信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:成人数合计][1:int:儿童数合计][2:int:全陪数合计][3:decimal:结算金额合计][4:decimal:已支付金额合计][5:decimal:已审批金额合计][6:decimal:未审批金额合计][7:int:婴儿数合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiInfo> GYS_GetDiJieAnPais(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0M, 0M, 0M, 0M,0 };
            var items = new List<EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Gys_DiJieAnPai";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(ChengRenShu) AS ChengRenShuHeJi,SUM(ErTongShu) AS ErTongShuHeJi,SUM(QuPeiShu) AS QuanPeiShuHeJi,SUM(JieSuanAmount) AS JieSuanJinEHeJi,SUM(YiZhiFuJinE) AS YiZhiFuJinEHeJi,SUM(YiShenPiJinE) AS YiShenPiJinEHeJi,SUM(WeiShenPiJinE) AS WeiShenPiJinEHeJi,SUM(YingErShu) AS YingErShuHeJi";

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ZxsName))
                {
                    query.AppendFormat(" AND  ZxsName LIKE '%{0}%' ", chaXun.ZxsName);
                }
                if (!string.IsNullOrEmpty(chaXun.GysId))
                {
                    query.AppendFormat(" AND GysZhuTiId='{0}' ", chaXun.GysId);
                }
                if (!string.IsNullOrEmpty(chaXun.DiJieRouteName))
                {
                    query.AppendFormat(" AND DiJieRouteName LIKE '%{0}%' ", chaXun.DiJieRouteName);
                }
                if (chaXun.QuDate1.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.QuDate1.Value.AddDays(-1));
                }
                if (chaXun.QuDate2.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.QuDate2.Value.AddDays(1));
                }
                if (chaXun.JieQingStatus.HasValue)
                {
                    if (chaXun.JieQingStatus.Value == EyouSoft.Model.EnumType.FinStructure.JieQingStatus.未结清)
                    {
                        query.Append(" AND JieSuanAmount-YiZhiFuJinE<>0 ");
                    }
                    else if (chaXun.JieQingStatus.Value ==  EyouSoft.Model.EnumType.FinStructure.JieQingStatus.已结清)
                    {
                        query.Append(" AND JieSuanAmount-YiZhiFuJinE=0 ");
                    }
                }
                if (!string.IsNullOrEmpty(chaXun.DiJieTuanHao))
                {
                    query.AppendFormat(" AND DiJieTuanHao LIKE '%{0}%' ", chaXun.DiJieTuanHao);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsRouteName))
                {
                    query.AppendFormat(" AND RouteName LIKE '%{0}%' ", chaXun.ZxsRouteName);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsTuanHao))
                {
                    query.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", chaXun.ZxsTuanHao);
                }
                if (chaXun.QueRenStatus.HasValue)
                {
                    query.AppendFormat(" AND DiJieQueRenStatus={0} ", (int)chaXun.QueRenStatus.Value);
                }
            }
            #endregion

            #region paixu
            if (chaXun != null)
            {
                switch (chaXun.PaiXuLeiXing)
                {
                    case 0: orderByString = " IssueTime DESC "; break;
                    case 1: orderByString = " IssueTime ASC "; break;
                    case 2: orderByString = " QuDate DESC "; break;
                    case 3: orderByString = " QuDate ASC "; break;
                    default: orderByString = " IssueTime DESC "; break;
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiInfo();

                    item.AnPaiId = rdr.GetString(rdr.GetOrdinal("PlanId"));
                    item.DiJieQueRenRenId = rdr.GetInt32(rdr.GetOrdinal("DiJieQueRenRenId"));
                    item.DiJieQueRenRenName = rdr["DiJieQueRenRenId"].ToString();
                    item.DiJieQueRenStatus = (EyouSoft.Model.EnumType.TourStructure.QueRenStatus)rdr.GetInt32(rdr.GetOrdinal("DiJieQueRenStatus"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("DiJieQueRenTime"))) item.DiJieQueRenTime = rdr.GetDateTime(rdr.GetOrdinal("DiJieQueRenTime"));                    
                    item.DiJieRouteName = rdr["DiJieRouteName"].ToString();
                    item.DiJieTuanHao = rdr["DiJieTuanHao"].ToString();
                    item.JieSuanMingXi = rdr["JieSuanMX"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JieSuanAmount"));
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.RenShuCR = rdr.GetInt32(rdr.GetOrdinal("ChengRenShu"));
                    item.RenShuET = rdr.GetInt32(rdr.GetOrdinal("ErTongShu"));
                    item.RenShuQP = rdr.GetInt32(rdr.GetOrdinal("QuPeiShu"));
                    item.RenShuYE = rdr.GetInt32(rdr.GetOrdinal("YingErShu"));
                    item.YiShouJinE = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinE"));
                    item.ZxsCaoZuoRenId = rdr.GetInt32(rdr.GetOrdinal("ZxsCaoZuoRenId"));
                    item.ZxsCaoZuoRenName = rdr["ZxsCaoZuoRenName"].ToString();
                    item.ZxsCaoZuoTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.ZxsId = rdr["ZxsId"].ToString();
                    item.ZxsName = rdr["ZxsName"].ToString();
                    item.ZxsRouteName = rdr["ZxsRouteName"].ToString();
                    item.ZxsTuanHao = rdr["JiaoYiHao"].ToString();

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChengRenShuHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("ChengRenShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ErTongShuHeJi"))) heJi[1] = rdr.GetInt32(rdr.GetOrdinal("ErTongShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QuanPeiShuHeJi"))) heJi[2] = rdr.GetInt32(rdr.GetOrdinal("QuanPeiShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JieSuanJinEHeJi"))) heJi[3] = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiZhiFuJinEHeJi"))) heJi[4] = rdr.GetDecimal(rdr.GetOrdinal("YiZhiFuJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShenPiJinEHeJi"))) heJi[5] = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("WeiShenPiJinEHeJi"))) heJi[6] = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingErShuHeJi"))) heJi[7] = rdr.GetInt32(rdr.GetOrdinal("YingErShuHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 地接平台-地接社设置计划信息
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int GYS_DiJieJiHua_U(EyouSoft.Model.PlanStructure.MGYS_DiJieAnPaiJiHuaInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Gys_DiJieJiHua_U");

            _db.AddInParameter(cmd, "@AnPaiId", DbType.AnsiStringFixedLength, info.AnPaiId);
            _db.AddInParameter(cmd, "@DiJieRouteName", DbType.String, info.DiJieRouteName);
            _db.AddInParameter(cmd, "@DiJieTuanHao", DbType.String, info.DiJieTuanHao);
            _db.AddInParameter(cmd, "@DaoYouName", DbType.String, info.DaoYouName);
            _db.AddInParameter(cmd, "@GysZhuTiId", DbType.AnsiStringFixedLength, info.GysId);
            _db.AddInParameter(cmd, "@CaoZuoRenId", DbType.Int32, info.CaoZuoRenId);
            _db.AddInParameter(cmd, "@CaoZuoTime", DbType.DateTime, info.CaoZuoTime);
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
        /// 地接平台-地接社设置计划状态
        /// </summary>
        /// <param name="anPaiId">安排编号</param>
        /// <param name="status">确认状态</param>
        /// <param name="gysId">供应商主体编号</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="caoZuoTime">操作时间</param>
        /// <returns></returns>
        public int GYS_DiJieSheZhiQueRenStatus(string anPaiId, EyouSoft.Model.EnumType.TourStructure.QueRenStatus status, string gysId, int caoZuoRenId, DateTime caoZuoTime)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Gys_DiJieJiHua_SheZhiQueRenStatus");

            _db.AddInParameter(cmd, "@AnPaiId", DbType.AnsiStringFixedLength, anPaiId);
            _db.AddInParameter(cmd, "@Status", DbType.Int32, status);
            _db.AddInParameter(cmd, "@GysZhuTiId", DbType.AnsiStringFixedLength, gysId);
            _db.AddInParameter(cmd, "@CaoZuoRenId", DbType.Int32, caoZuoRenId);
            _db.AddInParameter(cmd, "@CaoZuoTime", DbType.DateTime, caoZuoTime);
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
        /// 设置地接安排导游，返回1成功，其它失败
        /// </summary>
        /// <param name="anPaiId">地接安排编号</param>
        /// <param name="daoYouName">导游</param>
        /// <returns></returns>
        public int SetDaoYou(string anPaiId, string daoYouName)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE [tbl_PlanDiJie] SET [DaoYouName]=@DaoYouName,[DaoYouName1]=@DaoYouName WHERE [PlanId]=@AnPaiId");
            _db.AddInParameter(cmd, "DaoYouName", DbType.String, daoYouName);
            _db.AddInParameter(cmd, "AnPaiId", DbType.AnsiStringFixedLength, anPaiId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }
        #endregion
    }
}
