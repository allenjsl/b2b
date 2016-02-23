//统计分析-操作人统计 汪奇志 2013-08-06
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
    /// 统计分析-操作人统计
    /// </summary>
    public class DCaoZuoRen : DALBase, EyouSoft.IDAL.TongJiStructure.ICaoZuoRen
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
        public DCaoZuoRen()
        {
            _db = SystemStore;
        }
        #endregion

        #region ICaoZuoRen 成员
        /// <summary>
        /// 统计分析-获取操作人统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MCaoZuoRenInfo> GetCaoZuoRens(int companyId,string zxsId, EyouSoft.Model.TongJiStructure.MCaoZuoRenChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.TongJiStructure.MCaoZuoRenInfo> items = new List<EyouSoft.Model.TongJiStructure.MCaoZuoRenInfo>();
            IDictionary<int, IList<EyouSoft.Model.TongJiStructure.MCaoZuoRenRenShuInfo>> dic = new Dictionary<int, IList<EyouSoft.Model.TongJiStructure.MCaoZuoRenRenShuInfo>>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT A.ZxsOperatorId,A.BusinessType,SUM(Adults) AS ChengRen,SUM(Childs) AS ErTong,SUM(Bears) AS QuanPei,SUM(YingErRenShu) AS YingEr ");
            sql.Append(" ,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.ZxsOperatorId) AS OperatorName ");
            sql.Append(" FROM tbl_TourOrder AS A INNER JOIN tbl_KongWei AS B ");
            sql.Append(" ON A.TourId=B.KongWeiId ");
            if (chaXun != null)
            {
                if (chaXun.LEDate.HasValue)
                {
                    sql.AppendFormat(" AND B.QuDate<'{0}' ", chaXun.LEDate.Value.AddDays(1));
                }
                if (chaXun.LSDate.HasValue)
                {
                    sql.AppendFormat(" AND B.QuDate>'{0}' ", chaXun.LSDate.Value.AddDays(-1));
                }
            }
            sql.AppendFormat(" WHERE A.IsDelete='0' AND A.OrderStatus={0} ", (int)EyouSoft.Model.EnumType.TourStructure.OrderStatus.已成交);
            sql.AppendFormat(" AND A.CompanyId={0} ", companyId);
            sql.AppendFormat(" AND A.SumPrice{0} ", JinETiaoJian);
            sql.AppendFormat(" AND A.ZxsId='{0}' ", zxsId);
            sql.Append(" GROUP By A.ZxsOperatorId,A.BusinessType ");

            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    int operatorId = rdr.GetInt32(rdr.GetOrdinal("ZxsOperatorId"));
                    var item = new EyouSoft.Model.TongJiStructure.MCaoZuoRenRenShuInfo();
                    item.ChengRen = rdr.GetInt32(rdr.GetOrdinal("ChengRen"));
                    item.ErTong = rdr.GetInt32(rdr.GetOrdinal("ErTong"));
                    item.QuanPei = rdr.GetInt32(rdr.GetOrdinal("QuanPei"));
                    item.OperatorName = rdr["OperatorName"].ToString();
                    item.YuWuLeiXing= (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("BusinessType"));
                    item.YingEr = rdr.GetInt32(rdr.GetOrdinal("YingEr"));

                    if (!dic.ContainsKey(operatorId))
                    {
                        dic.Add(operatorId, new List<EyouSoft.Model.TongJiStructure.MCaoZuoRenRenShuInfo>() { item });
                    }
                    else
                    {
                        dic[operatorId].Add(item);
                    }
                }
            }

            if (dic != null && dic.Count > 0)
            {
                foreach (var item1 in dic)
                {
                    var item =new EyouSoft.Model.TongJiStructure.MCaoZuoRenInfo();

                    item.OperatorId = item1.Key;
                    item.OperatorName = item1.Value[0].OperatorName;

                    foreach (var item2 in item1.Value)
                    {
                        switch (item2.YuWuLeiXing)
                        {
                            case EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游: item.T0 = item2; break;
                            case EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店: item.T3 = item2; break;
                            case EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票: item.T1 = item2; break;
                            case EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店: item.T2 = item2; break;
                            case EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制: item.T4 = item2; break;
                            case EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行: item.T5 = item2; break;
                            default: break;
                        }
                    }

                    items.Add(item);
                }
            }

            return items;
        }

        #endregion
    }
}
