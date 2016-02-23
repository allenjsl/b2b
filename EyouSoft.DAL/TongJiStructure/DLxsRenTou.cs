//统计分析-旅行社人头统计 汪奇志 2013-08-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.TongJiStructure
{
    /// <summary>
    /// 统计分析-旅行社人头统计
    /// </summary>
    public class DLxsRenTou : DALBase, EyouSoft.IDAL.TongJiStructure.ILxsRenTou
    {
        #region static constants
        //static constants
        const string JinETiaoJian = ">1000";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DLxsRenTou()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 获取统计分析-旅行社人头统计明细订单信息集合
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MLxsRenTouXXOrderInfo> GetLxsRenTouXXOrders(string keHuId, EyouSoft.Model.TongJiStructure.MLxsRenTouXXChaXunInfo chaXun)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT A.Adults,A.Childs,A.Bears,A.BusinessType,B.QuDate,A.YingErRenShu ");
            sql.Append(" ,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName ");
            sql.Append(" ,(SELECT A1.Name FROM tbl_CustomerContactInfo AS A1 WHERE A1.Id=A.BuyOperatorId) AS DuiFangCaoZuoRenName ");
            sql.Append(" FROM tbl_TourOrder AS A INNER JOIN tbl_KongWei AS B ");
            sql.Append(" ON A.TourId=B.KongWeiId ");

            if (chaXun != null)
            {
                DateTime t = new DateTime(chaXun.YYYY, chaXun.MM, 1);
                sql.AppendFormat(" AND B.QuDate>'{0}' AND B.QuDate<'{1}' ", t.AddDays(-1), t.AddMonths(1));
            }

            sql.AppendFormat(" WHERE A.OrderStatus={0} AND A.IsDelete='0' ", (int)EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交);
            sql.AppendFormat(" AND A.BuyCompanyId='{0}' ", keHuId);
            sql.AppendFormat(" AND A.SumPrice{0} ", JinETiaoJian);

            IList<EyouSoft.Model.TongJiStructure.MLxsRenTouXXOrderInfo> items = new List<EyouSoft.Model.TongJiStructure.MLxsRenTouXXOrderInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TongJiStructure.MLxsRenTouXXOrderInfo();

                    item.ChengRen = rdr.GetInt32(rdr.GetOrdinal("Adults"));
                    item.DuiFangCaoZuoRenName = rdr["DuiFangCaoZuoRenName"].ToString();
                    item.ErTong = rdr.GetInt32(rdr.GetOrdinal("Childs"));
                    item.QuanPei = rdr.GetInt32(rdr.GetOrdinal("Bears"));
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.RouteName = rdr["RouteName"].ToString();
                    item.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("BusinessType"));
                    item.YingEr = rdr.GetInt32(rdr.GetOrdinal("YingErRenShu"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region ILxsRenTou 成员
        /// <summary>
        /// 统计分析-获取旅行社人头统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="year">年份</param>
        /// <param name="diQu">地区</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MLxsRenTouInfo> GetLxsRenTous(int companyId,string zxsId, int year, EyouSoft.Model.EnumType.CompanyStructure.ChengShiDiQu diQu, EyouSoft.Model.TongJiStructure.MLxsRenTourChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.TongJiStructure.MLxsRenTouInfo> items = new List<EyouSoft.Model.TongJiStructure.MLxsRenTouInfo>();
            IDictionary<int, IList<EyouSoft.Model.TongJiStructure.MLxsRenTouRenShuInfo>> dic = new Dictionary<int, IList<EyouSoft.Model.TongJiStructure.MLxsRenTouRenShuInfo>>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT A.CityId,YEAR(C.QuDate) AS YYYY,MONTH(C.QuDate) AS MM,SUM(B.Adults) AS ChengRen,SUM(B.Childs) AS ErTong,SUM(B.Bears) AS QuanPei,SUM(B.YingErRenShu) AS YingEr ");
            sql.Append(" ,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.CityId) AS CityName ");
            sql.Append(" FROM tbl_Customer AS A INNER JOIN tbl_TourOrder AS B ");
            sql.AppendFormat(" ON A.Id=B.BuyCompanyId AND B.OrderStatus={0} AND B.IsDelete='0' AND B.SumPrice{1} INNER JOIN tbl_KongWei AS C ", (int)EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交, JinETiaoJian);
            sql.AppendFormat(" ON B.TourId=C.KongWeiId AND C.ZxsId='{0}'  ", zxsId);
            sql.AppendFormat(" AND C.QuDate>'{0}-12-31' AND C.QuDate<'{1}-01-01' ", year - 1, year + 1);
            sql.Append(" INNER JOIN tbl_CompanyCity AS D ");
            sql.AppendFormat(" ON D.Id=A.CityId AND D.DiQu={0} ", (int)diQu);
            sql.Append(" WHERE A.IsDelete='0' ");
            sql.AppendFormat(" AND A.CompanyId={0} ", companyId);
            sql.Append(" GROUP BY A.CityId,YEAR(C.QuDate),MONTH(C.QuDate) ");

            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());
            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TongJiStructure.MLxsRenTouRenShuInfo();
                    int cityId = rdr.GetInt32(rdr.GetOrdinal("CityId"));
                    item.ChengRen = rdr.GetInt32(rdr.GetOrdinal("ChengRen"));
                    item.ErTong = rdr.GetInt32(rdr.GetOrdinal("ErTong"));
                    item.QuanPei = rdr.GetInt32(rdr.GetOrdinal("QuanPei"));
                    item.MM = rdr.GetInt32(rdr.GetOrdinal("MM"));
                    item.YYYY = rdr.GetInt32(rdr.GetOrdinal("YYYY"));
                    item.CityName = rdr["CityName"].ToString();
                    item.YingEr = rdr.GetInt32(rdr.GetOrdinal("YingEr"));

                    if (!dic.ContainsKey(cityId))
                    {
                        dic.Add(cityId, new List<EyouSoft.Model.TongJiStructure.MLxsRenTouRenShuInfo>() { item });
                    }
                    else
                    {
                        dic[cityId].Add(item);
                    }
                }
            }

            if (dic != null && dic.Count > 0)
            {
                foreach (var item1 in dic)
                {
                    var item = new EyouSoft.Model.TongJiStructure.MLxsRenTouInfo();
                    item.Year = year;
                    item.CityId = item1.Key;
                    item.CityName = item1.Value[0].CityName;

                    foreach (var item2 in item1.Value)
                    {
                        switch (item2.MM)
                        {
                            case 1: item.M1 = item2; break;
                            case 2: item.M2 = item2; break;
                            case 3: item.M3 = item2; break;
                            case 4: item.M4 = item2; break;
                            case 5: item.M5 = item2; break;
                            case 6: item.M6 = item2; break;
                            case 7: item.M7 = item2; break;
                            case 8: item.M8 = item2; break;
                            case 9: item.M9 = item2; break;
                            case 10: item.M10 = item2; break;
                            case 11: item.M11 = item2; break;
                            case 12: item.M12 = item2; break;
                            default: break;
                        }
                    }

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 统计分析-获取旅行社人头统计明细信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MLxsRenTouXXInfo> GetLxsRenTouXXs(int companyId,string zxsId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MLxsRenTouXXChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.TongJiStructure.MLxsRenTouXXInfo> items = new List<EyouSoft.Model.TongJiStructure.MLxsRenTouXXInfo>();
            StringBuilder fields = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Customer";
            string orderByString = " IssueTime DESC ";
            string heJiString = "";

            #region fields
            fields.Append(" Id,Name ");
            #endregion

            #region sql
            sql.AppendFormat(" CompanyId={0} AND IsDelete='0' ", companyId);
            if (chaXun != null)
            {
                DateTime t = new DateTime(chaXun.YYYY, chaXun.MM, 1);
                sql.AppendFormat(" AND CityId={0} ", chaXun.CityId);
                sql.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_TourOrder AS A1 WHERE A1.BuyCompanyId=tbl_Customer.Id AND A1.OrderStatus={0} AND A1.IsDelete='0' AND A1.SumPrice{1} AND EXISTS(SELECT 1 FROM tbl_KongWei AS A2 WHERE A2.KongWeiId=A1.TourId AND A2.QuDate>'{2}' AND A2.QuDate<'{3}' AND A2.ZxsId='{4}')) ", (int)EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交, JinETiaoJian, t.AddDays(-1), t.AddMonths(1),zxsId);
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, heJiString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.TongJiStructure.MLxsRenTouXXInfo();
                    item.KeHuId = rdr["Id"].ToString();
                    item.keHuName = rdr["Name"].ToString();

                    items.Add(item);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.DingDans = GetLxsRenTouXXOrders(item.KeHuId, chaXun);
                }
            }

            return items;
        }
        #endregion
    }
}
