using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.DAL.PersonalCenterStructure
{
    using EyouSoft.IDAL.PersonalCenterStructure;
    using EyouSoft.Model.EnumType.TourStructure;
    using EyouSoft.Model.PersonalCenterStructure;
    using EyouSoft.Model.PlanStructure;
    using EyouSoft.Model.TourStructure;
    using EyouSoft.Toolkit;
    using EyouSoft.Toolkit.DAL;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    public class DTranRemind:DALBase,ITranRemind
    {
        private Database _db = null;

        public DTranRemind()
        {
            _db = this.SystemStore;
        }

        /// <summary>
        /// 分页获取收款提醒
        /// </summary>
        /// <param name="pageSize">每页显示数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="searchInfo">查询信息</param>
        /// <returns></returns>
        public IList<MShouKuanTiXingInfo> GetShouKuanTiXings(int pageSize, int pageIndex, ref int recordCount, int companyId, MShouKuanTiXingChaXunInfo searchInfo)
        {
            /*
            var list = new List<ReceiptRemind>();
            const string tableName = "View_ReceiptRemind_GetList";
            const string fields = "Id,[Name],ContactName,Phone,ArrearCash";
            const string orderbyStr = "ArrearCash Desc";
            var strWhere = new StringBuilder();
            strWhere.AppendFormat("ArrearCash > 0 AND CompanyId={0} ", companyId);
            if (searchInfo!=null)
            {
                if (!string.IsNullOrEmpty(searchInfo.QianKuanDanWei))
                {
                    strWhere.AppendFormat("AND [NAME] LIKE '%{0}%' ", searchInfo.QianKuanDanWei);
                }
                if (searchInfo.LSDate.HasValue||searchInfo.LEDate.HasValue)
                {
                    strWhere.AppendFormat("AND EXISTS ( SELECT 1 ");
                    strWhere.AppendFormat("             FROM   dbo.tbl_KongWei K ");
                    strWhere.AppendFormat("                    INNER JOIN dbo.tbl_TourOrder O ON K.KongWeiId = O.TourId ");
                    strWhere.AppendFormat("                                                      AND O.BuyCompanyId = Id ");
                    strWhere.AppendFormat("             WHERE  K.IsDelete = 0 ");
                    if (searchInfo.LSDate.HasValue)
                    {
                        strWhere.AppendFormat("                    AND K.QuDate >= '{0}' ", searchInfo.LSDate);
                    }
                    if (searchInfo.LEDate.HasValue)
                    {
                        strWhere.AppendFormat("                    AND K.QuDate < '{0}'  ", searchInfo.LEDate.Value.AddDays(1));
                    }
                    strWhere.AppendFormat("            ) ");                    
                }
            }
            using (var dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields, strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    list.Add(new ReceiptRemind()
                    {
                        CustomerId = dr["Id"].ToString(),
                        CustomerName = dr["Name"].ToString(),
                        ContactName = dr["ContactName"].ToString(),
                        ContactTel = dr["Phone"].ToString(),
                        ArrearCash = dr.GetDecimal(dr.GetOrdinal("ArrearCash")),
                    });
                }
            }
            return list;*/

            StringBuilder table = new StringBuilder();
            table.AppendFormat(" SELECT A.Id,A.Name,A.ContactName,A.Phone,A.CompanyId ");

            string fields_weishoujine = " ,(SELECT ISNULL(SUM(A1.SumPrice-A1.CheckMoney+A1.ReturnMoney),0)  FROM tbl_TourOrder AS A1 WHERE A1.BuyCompanyId=A.Id AND A1.IsDelete='0' AND A1.OrderStatus={0} AND A1.SumPrice-A1.CheckMoney+A1.ReturnMoney>0 {1}) AS WeiShouJinE ";
            #region sql1
            string sql1 = "";
            if (searchInfo != null)
            {
                if (searchInfo.LSDate.HasValue || searchInfo.LEDate.HasValue)
                {
                    sql1 += " AND EXISTS(SELECT 1 FROM tbl_KongWei AS A2 WHERE A2.KongWeiId=A1.TourId ";
                    if (searchInfo.LSDate.HasValue)
                    {
                        sql1 += string.Format(" AND A2.QuDate>='{0}' ", searchInfo.LSDate.Value);
                    }
                    if (searchInfo.LEDate.HasValue)
                    {
                        sql1 += string.Format(" AND A2.QuDate<='{0}' ", searchInfo.LEDate.Value);
                    }
                    sql1 += " ) ";
                }
                if (!string.IsNullOrEmpty(searchInfo.ZxsId))
                {
                    sql1 += string.Format(" AND A1.ZxsId='{0}' ", searchInfo.ZxsId);
                }
            }
            #endregion
            table.AppendFormat(fields_weishoujine, (int)EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交, sql1);

            table.AppendFormat(" FROM tbl_Customer AS A ");
            table.AppendFormat(" WHERE A.CompanyId={0} ", companyId);
            if (searchInfo != null)
            {
                if (!string.IsNullOrEmpty(searchInfo.QianKuanDanWei))
                {
                    table.AppendFormat(" AND [NAME] LIKE '%{0}%' ", searchInfo.QianKuanDanWei);
                }
            }

            IList<MShouKuanTiXingInfo> items = new List<MShouKuanTiXingInfo>();
            string fields = "*";

            StringBuilder query = new StringBuilder();
            string orderByString = " WeiShouJinE DESC ";
            string sumString = "";
            query.AppendFormat("WeiShouJinE>0");

            using (var rdr = DbHelper.ExecuteReader2(_db, pageSize, pageIndex, ref recordCount, table.ToString(), fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MShouKuanTiXingInfo();

                    item.ArrearCash = rdr.GetDecimal(rdr.GetOrdinal("WeiShouJinE"));
                    item.ContactName = rdr["ContactName"].ToString();
                    item.ContactTel = rdr["Phone"].ToString();
                    item.CustomerId = rdr["Id"].ToString();
                    item.CustomerName = rdr["Name"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 根据客户单位编号、出团时间开始、出团时间结束获取未收款明细
        /// </summary>
        /// <param name="pageSize">每页显示数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="customerId">客户单位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MShouKuanTiXingMingXiInfo> GetShouKuanTiXingMxs(int pageSize, int pageIndex, ref int recordCount, string customerId, MShouKuanTiXingChaXunInfo chaXun)
        {
            var list = new List<MShouKuanTiXingMingXiInfo>();
            const string tableName = "tbl_TourOrder";
            const string fields = "OrderCode,(SELECT C.[Name] FROM dbo.tbl_Customer C WHERE C.Id=BuyCompanyId) AS BuyCompanyName,(SELECT B.Name FROM tbl_CustomerContactInfo AS B WHERE B.Id=BuyOperatorId) AS BuyOperatorName,Adults,Childs,Bears,Accounts,SumPrice,CheckMoney,ReturnMoney,YingErRenShu";
            const string orderbyStr = "SumPrice-CheckMoney+ReturnMoney DESC";
            var strWhere = new StringBuilder();
            strWhere.AppendFormat("SumPrice-CheckMoney+ReturnMoney > 0 AND IsDelete=0 AND OrderStatus={1} AND BuyCompanyId='{0}' ", customerId, (int)OrderStatus.已成交);

            if (chaXun != null)
            {
                if (chaXun.LSDate.HasValue || chaXun.LEDate.HasValue)
                {
                    strWhere.AppendFormat("AND EXISTS ( SELECT 1 FROM   dbo.tbl_KongWei K WHERE  K.IsDelete = 0 AND K.KongWeiId = tbl_TourOrder.TourId");
                    if (chaXun.LSDate.HasValue)
                    {
                        strWhere.AppendFormat(" AND K.QuDate >= '{0}' ", chaXun.LSDate.Value);
                    }
                    if (chaXun.LEDate.HasValue)
                    {
                        strWhere.AppendFormat(" AND K.QuDate < '{0}'  ", chaXun.LEDate.Value.AddDays(1));
                    }
                    strWhere.AppendFormat(" ) ");
                }

                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            using (var dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields, strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    var item = new MShouKuanTiXingMingXiInfo();
                    item.ChengRenShu=dr.GetInt32(dr.GetOrdinal("Adults"));
                    item.DuiFangCaoZuoRenName=dr["BuyOperatorName"].ToString();
                    item.ErTongShu=dr.GetInt32(dr.GetOrdinal("Childs"));
                    item.JiaoYiHao=dr["OrderCode"].ToString();
                    item.JinE=dr.GetDecimal(dr.GetOrdinal("SumPrice"));
                    item.KeHuName=dr["BuyCompanyName"].ToString();
                    item.QuanPeiShu=dr.GetInt32(dr.GetOrdinal("Bears"));
                    item.WeiShouJinE=dr.GetDecimal(dr.GetOrdinal("SumPrice"))-dr.GetDecimal(dr.GetOrdinal("CheckMoney"))+dr.GetDecimal(dr.GetOrdinal("ReturnMoney"));
                    item.YingErShu=dr.GetInt32(dr.GetOrdinal("YingErRenShu"));
                    item.ZhanWeiShu=dr.GetInt32(dr.GetOrdinal("Accounts"));

                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// 分页获取付款提醒
        /// </summary>
        /// <param name="pageSize">每页显示数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="searchInfo">查询实体</param>
        /// <returns></returns>
        public IList<MFuKuanTiXingInfo> GetFuKuanTiXings(int pageSize, int pageIndex, ref int recordCount, int companyId, FuKuanTiXingChaXun searchInfo)
        {
            var list = new List<MFuKuanTiXingInfo>();
            var table = new StringBuilder();
            const string strWhere = "";
            const string fields = "*";
            const string orderbyStr = "WeiZhiFuJinE DESC";

            table.Append(" SELECT  GysId ,GysName ,ContactInfo ,SUM(WeiZhiFuJinE) AS WeiZhiFuJinE");
            table.Append(" FROM    View_PayRemind_GetList");
            table.AppendFormat(" WHERE   CompanyId = {0}",companyId);
            if (searchInfo!=null)
            {
                if (!string.IsNullOrEmpty(searchInfo.ShouKuanDanWei))
                {
                    table.AppendFormat(" AND GysName LIKE '%{0}%'", searchInfo.ShouKuanDanWei);
                }
                if (searchInfo.LSDate.HasValue)
                {
                    table.AppendFormat(" AND QuDate >= '{0}'",searchInfo.LSDate.Value);
                }
                if (searchInfo.LEDate.HasValue)
                {
                    table.AppendFormat(" AND QuDate < '{0}'",searchInfo.LEDate.Value.AddDays(1));
                }
                if (!string.IsNullOrEmpty(searchInfo.ZxsId))
                {
                    table.AppendFormat(" AND ZxsId='{0}' ", searchInfo.ZxsId);
                }
            }
            table.Append(" GROUP BY GysId ,");
            table.Append("         GysName ,");
            table.Append("         ContactInfo");
            table.Append(" HAVING SUM(WeiZhiFuJinE)>0");

            using (var dr = DbHelper.ExecuteReader2(this._db, pageSize, pageIndex, ref recordCount, table.ToString(), fields, strWhere, orderbyStr, ""))
            {
                while (dr.Read())
                {
                    list.Add(new MFuKuanTiXingInfo()
                    {
                        SupplierId = dr["GysId"].ToString(),
                        SupplierName = dr["GysName"].ToString(),
                        ContactName = Utils.GetValueFromXmlByAttribute(dr["ContactInfo"].ToString(), "ContactName"),
                        ContactTel = Utils.GetValueFromXmlByAttribute(dr["ContactInfo"].ToString(), "ContactTel"),
                        PayCash = dr.GetDecimal(dr.GetOrdinal("WeiZhiFuJinE"))
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// 供应商编号、出团时间开始、出团时间结束获取未付款明细
        /// </summary>
        /// <param name="pageSize">每页显示数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="supplierId">供应商编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MFuKuanTiXingMingXiInfo> GetFuKuanTiXingMxs(int pageSize, int pageIndex, ref int recordCount, string supplierId, FuKuanTiXingChaXun chaXun)
        {
            var list = new List<MFuKuanTiXingMingXiInfo>();
            const string tableName = "View_PayRemind_GetList";
            const string fields = "KongWeiCode,RouteName,QuDate,ChengRenShu,ErTongShu,QuPeiShu,JieSuanAmount,WeiZhiFuJinE,YingErShu";
            const string orderbyStr = "WeiZhiFuJinE DESC";
            var strWhere = new StringBuilder();
            strWhere.AppendFormat("WeiZhiFuJinE > 0 AND GysId='{0}' ", supplierId);

            if (chaXun != null)
            {
                if (chaXun.LSDate.HasValue)
                {
                    strWhere.AppendFormat("AND QuDate >= '{0}' ", chaXun.LSDate.Value);
                }
                if (chaXun.LEDate.HasValue)
                {
                    strWhere.AppendFormat("AND QuDate < '{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            using (var dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields, strWhere.ToString(), orderbyStr, ""))
            {
                while (dr.Read())
                {
                    var item = new MFuKuanTiXingMingXiInfo();
                    item.ChengRenShu = dr.GetInt32(dr.GetOrdinal("ChengRenShu"));
                    item.ErTongShu = dr.GetInt32(dr.GetOrdinal("ErTongShu"));
                    item.JinE = dr.GetDecimal(dr.GetOrdinal("JieSuanAmount"));
                    item.KongWeiCode = dr["KongWeiCode"].ToString();
                    item.QuanPeiShu = dr.GetInt32(dr.GetOrdinal("QuPeiShu"));
                    item.QuDate = dr.GetDateTime(dr.GetOrdinal("QuDate"));
                    item.RouteName = dr["RouteName"].ToString();
                    item.WeiZhiFuJinE = dr.GetDecimal(dr.GetOrdinal("WeiZhiFuJinE"));
                    item.YingErShu = dr.GetInt32(dr.GetOrdinal("YingErShu"));

                    list.Add(item);
                }
            }
            return list;
        }
    }
}
