//财务管理其它收入相关数据访问类 汪奇志 2012-11-19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using EyouSoft.IDAL.FinStructure;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 财务管理其它收入相关数据访问类
    /// </summary>
    public class DQiTaShouRu:DALBase,IQiTaShouRu
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_FinOther]([Id],[CompanyId],[TourId],[CostType],[CustromType],[CustromCId],[ProceedItem],[Proceed],[Date],[Remark],[OperatorId],[CreateTime],[XiangMuId],[ZxsID]) VALUES (@Id,@CompanyId,@TourId,@CostType,@CustromType,@CustromCId,@ProceedItem,@Proceed,@Date,@Remark,@OperatorId,@CreateTime,@XiangMuId,@ZxsId) ";
        const string SQL_UPDATE_Update = "UPDATE [tbl_FinOther] SET [CustromType] = @CustromType,[CustromCId] = @CustromCId,[ProceedItem] = @ProceedItem,[Proceed] = @Proceed,[Date] = @Date,[Remark] = @Remark,[XiangMuId]=@XiangMuId WHERE [Id] = @Id";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_FinOther] WHERE [Id]=@Id AND [CompanyId]=@CompanyId";
        const string SQL_SELECT_GetInfo = "SELECT A.* FROM [view_Fin_QiTaShouZhi] AS A WHERE A.[Id]=@Id";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DQiTaShouRu()
        {
            _db = SystemStore;
        }
        #endregion

        #region EyouSoft.IDAL.FinStructure.IQiTaShouRu 成员
        /// <summary>
        /// 写入其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MQiTaShouRuInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.ShouRuId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "TourId", DbType.AnsiStringFixedLength, info.KongWeiId);
            _db.AddInParameter(cmd, "CostType", DbType.Byte, info.Type);
            _db.AddInParameter(cmd, "CustromType", DbType.Byte, info.KeHuType);
            _db.AddInParameter(cmd, "CustromCId", DbType.AnsiStringFixedLength, info.KeHuId);
            _db.AddInParameter(cmd, "ProceedItem", DbType.String, info.XiangMu);
            _db.AddInParameter(cmd, "Proceed", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "Date", DbType.DateTime, info.ShiJian);
            _db.AddInParameter(cmd, "Remark", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "CreateTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "XiangMuId", DbType.Int32, info.XiangMuId);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /*/// <summary>
        /// 获取金额信息
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <param name="jinE">金额信息[0:decimal:应收金额][1:decimal:已审批金额][2:decimal:未审批金额]</param>
        /// <returns></returns>
        public void GetJinE(string shouRuId, out decimal[] jinE)
        {
            jinE = new decimal[] { 0M, 0M, 0M };
            StringBuilder s = new StringBuilder();

            s.AppendFormat(" SELECT A.Proceed ");
            s.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CollectionId=A.Id AND B.Status=@Status1 AND B.CollectionItem=@KuangXiangType) AS YiShenPiJinE ");
            s.AppendFormat(" ,(SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS B WHERE B.CollectionId=A.Id AND B.Status=@Status2 AND B.CollectionItem=@KuangXiangType) AS WeiShenPiJinE ");
            s.AppendFormat(" FROM tbl_FinOther AS A WHERE A.Id=@Id ");

            DbCommand cmd = _db.GetSqlStringCommand(s.ToString());
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, shouRuId);
            _db.AddInParameter(cmd, "Status1", DbType.Byte, KuanXiangStatus.未支付);
            _db.AddInParameter(cmd, "Status2", DbType.Byte, KuanXiangStatus.未审批);
            _db.AddInParameter(cmd, "KuangXiangType", DbType.Byte, KuanXiangType.其它收入收款);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) jinE[0] = rdr.GetDecimal(0);
                    if (!rdr.IsDBNull(1)) jinE[1] = rdr.GetDecimal(1);
                    if (!rdr.IsDBNull(2)) jinE[2] = rdr.GetDecimal(2);
                }
            }

        }*/

        /// <summary>
        /// 修改其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MQiTaShouRuInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, info.ShouRuId);
            _db.AddInParameter(cmd, "CustromType", DbType.Byte, info.KeHuType);
            _db.AddInParameter(cmd, "CustromCId", DbType.AnsiStringFixedLength, info.KeHuId);
            _db.AddInParameter(cmd, "ProceedItem", DbType.String, info.XiangMu);
            _db.AddInParameter(cmd, "Proceed", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "Date", DbType.DateTime, info.ShiJian);
            _db.AddInParameter(cmd, "Remark", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "XiangMuId", DbType.Int32, info.XiangMuId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 删除其它收入信息，返回1成功，其它失败
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int Delete(string shouRuId, int companyId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, shouRuId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取其它收入信息业务实体
        /// </summary>
        /// <param name="shouRuId">其它收入登记编号</param>
        /// <returns></returns>
        public MQiTaShouRuInfo GetInfo(string shouRuId)
        {
            MQiTaShouRuInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, shouRuId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MQiTaShouRuInfo();

                    info.BeiZhu = rdr["Remark"].ToString();
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("CreateTime"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("Proceed"));
                    info.KeHuId = rdr.GetString(rdr.GetOrdinal("CustromCId"));
                    info.KeHuName = rdr["KeHuName"].ToString();
                    info.KeHuType = (QiTaShouZhiKeHuType)rdr.GetByte(rdr.GetOrdinal("CustromType"));
                    info.KongWeiId = rdr["TourId"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ShiJian = rdr.GetDateTime(rdr.GetOrdinal("Date"));
                    info.ShouRuId = shouRuId;
                    info.XiangMu = rdr["ProceedItem"].ToString();
                    info.XiangMuId = rdr.GetInt32(rdr.GetOrdinal("XiangMuId"));
                    info.IsChongDi = GetBoolean(rdr.GetString(rdr.GetOrdinal("IsChongDi")));
                    info.ZxsId = rdr["ZxsId"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取其它收入信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:应收合计] [1:decimal:已审批金额合计][2:decimal:未审批金额合计]</param>
        /// <returns></returns>
        public IList<MQiTaShouRuInfo> GetQiTaShouRus(int companyId, int pageSize, int pageIndex, ref int recordCount, MQiTaShouZhiChaXunInfo chaXun, out decimal[] heJi)
        {
            heJi = new decimal[] { 0M, 0M, 0M };

            IList<MQiTaShouRuInfo> items = new List<MQiTaShouRuInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_QiTaShouRu";
            string orderByString = " CreateTime DESC ";
            string sumString = "SUM(Proceed) AS YingShouJinEHeJi,SUM(YiShenPiJinE) AS YiShenPiJinEHeJi,SUM(WeiShenPiJinE) AS WeiShenPiJinEHeJi";

            fields.Append("Id,ProceedItem,Proceed,Remark,KeHuName,CompanyId,CreateTime,Date");
            //fields.AppendFormat(",ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A WHERE A.CollectionId=view_Fin_QiTaShouZhi.Id AND A.Status={0} AND A.CollectionItem={1}),0) AS YiShenPiJinE", (int)KuanXiangStatus.未支付, (int)KuanXiangType.其它收入收款);
            //fields.AppendFormat(",ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A WHERE A.CollectionId=view_Fin_QiTaShouZhi.Id AND A.Status={0} AND A.CollectionItem={1}),0) AS WeiShenPiJinE", (int)KuanXiangStatus.未审批, (int)KuanXiangType.其它收入收款);
            fields.Append(",YiShenPiJinE,WeiShenPiJinE");
            fields.Append(",TourId");
            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            query.AppendFormat(" AND CostType={0} ", (int)QiTaShouZhiType.收入);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.DanWeiName))
                {
                    query.AppendFormat(" AND KeHuName LIKE '%{0}%' ", chaXun.DanWeiName);
                }
                if (chaXun.EShiJian.HasValue)
                {
                    query.AppendFormat(" AND Date<'{0}' ", chaXun.EShiJian.Value.AddDays(1));
                }
                if (chaXun.SShiJian.HasValue)
                {
                    query.AppendFormat(" AND Date>'{0}' ", chaXun.SShiJian.Value.AddDays(-1));
                }
                if (!string.IsNullOrEmpty(chaXun.XiangMu))
                {
                    query.AppendFormat(" AND ProceedItem LIKE '%{0}%' ", chaXun.XiangMu);
                }
                if (chaXun.JinEOperator != QueryOperator.None && chaXun.JinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)chaXun.JinEOperator);
                    query.AppendFormat(" AND Proceed {0} {1} ", _operator, chaXun.JinE.Value);
                }
                if (chaXun.XiangMuId.HasValue)
                {
                    query.AppendFormat(" AND XiangMuId ={0} ", chaXun.XiangMuId.Value);
                }
                if (chaXun.JieQingStatus.HasValue)
                {
                    if (chaXun.JieQingStatus.Value == 0)
                    {
                        query.Append(" AND Proceed-YiShenPiJinE<>0 ");
                    }
                    else if (chaXun.JieQingStatus.Value == 1)
                    {
                        query.Append(" AND Proceed-YiShenPiJinE=0 ");
                    }
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
                    var item = new MQiTaShouRuInfo();

                    item.ShouRuId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.XiangMu = rdr["ProceedItem"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("Proceed"));
                    item.BeiZhu = rdr["Remark"].ToString();
                    item.KeHuName = rdr["KeHuName"].ToString();
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.ShiJian = rdr.GetDateTime(rdr.GetOrdinal("Date"));
                    item.KongWeiId = rdr["TourId"].ToString();

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingShouJinEHeJi"))) heJi[0] = rdr.GetDecimal(rdr.GetOrdinal("YingShouJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShenPiJinEHeJi"))) heJi[1] = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("WeiShenPiJinEHeJi"))) heJi[2] = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinEHeJi"));
                }
            }

            return items;
        }

        /// <summary>
        /// 获取控位其它收入信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<MQiTaShouRuInfo> GetKongWeiQiTaShouRus(string kongWeiId)
        {
            IList<MQiTaShouRuInfo> items = new List<MQiTaShouRuInfo>();

            StringBuilder s = new StringBuilder();
            s.Append(" SELECT ");
            s.Append(" Id,ProceedItem,Proceed,Remark,KeHuName,CompanyId,CreateTime,Date ");
            s.AppendFormat(" ,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A WHERE A.CollectionId=view_Fin_QiTaShouZhi.Id AND A.Status={0} AND A.CollectionItem={1}),0) AS YiShenPiJinE ", (int)KuanXiangStatus.未支付, (int)KuanXiangType.其它收入收款);
            s.AppendFormat(" ,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A WHERE A.CollectionId=view_Fin_QiTaShouZhi.Id AND A.Status={0} AND A.CollectionItem={1}),0) AS WeiShenPiJinE ", (int)KuanXiangStatus.未审批, (int)KuanXiangType.其它收入收款);
            s.Append(" FROM view_Fin_QiTaShouZhi ");

            s.AppendFormat(" WHERE TourId='{0}' ", kongWeiId);
            s.AppendFormat(" AND CostType={0} ", (int)QiTaShouZhiType.收入);

            DbCommand cmd = _db.GetSqlStringCommand(s.ToString());

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd,_db))
            {
                while (rdr.Read())
                {
                    var item = new MQiTaShouRuInfo();

                    item.ShouRuId = rdr.GetString(rdr.GetOrdinal("Id"));
                    item.XiangMu = rdr["ProceedItem"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("Proceed"));
                    item.BeiZhu = rdr["Remark"].ToString();
                    item.KeHuName = rdr["KeHuName"].ToString();
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.ShiJian = rdr.GetDateTime(rdr.GetOrdinal("Date"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion
    }
}
