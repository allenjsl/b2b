//利润估算相关信息 汪奇志 2014-10-27
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
    /// 利润估算相关信息
    /// </summary>
    public class DLiRun : DALBase, EyouSoft.IDAL.TongJiStructure.ILiRun
    {
        #region static constants
        //static constants
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DLiRun()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        #endregion

        #region ILiRun 成员
        /*
        /// <summary>
        /// 获取利润估算表1
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info> GetLiRunGuSuanBiao1s(int companyId, string zxsId, int year)
        {
            IList<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info> items = new List<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info>();
            for (var i = 1; i <= 12; i++)
            {
                var item = new EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info();
                item.Year = year;
                item.Month = i;
                items.Add(item);
            }

            DateTime t1 = new DateTime(year, 1, 1).AddSeconds(-1);
            DateTime t2 = new DateTime(year, 1, 1).AddYears(1);

            #region sql
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" SELECT YEAR(RiQi) AS YYYY,MONTH(RiQi) AS MM,LeiXing,SUM(JinE) AS JinE ");
            sql.AppendFormat(" FROM [view_TongJi_LiRunGuSuanBiao1] ");

            sql.AppendFormat(" WHERE CompanyId={0} ", companyId);
            sql.AppendFormat(" AND ZxsId='{0}' ", zxsId);
            sql.AppendFormat(" AND RiQi>'{0}' ", t1);
            sql.AppendFormat(" AND RiQi<'{0}' ", t2);

            sql.AppendFormat(" GROUP BY YEAR(RiQi),MONTH(RiQi),LeiXing ");

            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    int _mm = rdr.GetInt32(rdr.GetOrdinal("MM"));
                    int _leiXing = rdr.GetInt32(rdr.GetOrdinal("LeiXing"));
                    decimal _jinE = 0;
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JinE"))) _jinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));

                    var item = items[_mm - 1];

                    switch (_leiXing)
                    {
                        case 1: item.JieSuanShouRuJinE = _jinE; break;
                        case 2: item.JieSuanZhiChuJinE = _jinE; break;
                        case 3: item.YingYeWaiShouRuJinE = _jinE; break;
                        case 4: item.BaoXiaoJinE = _jinE; break;
                        case 5: item.GongZiJinE = _jinE; break;
                    }
                }
            }

            return items;
        }
        */

        /// <summary>
        /// 获取利润估算表1
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">截止日期</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info> GetLiRunGuSuanBiao1s(int companyId, string zxsId, DateTime time1, DateTime time2)
        {
            List<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info> items = new List<EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info>();

            int year1 = time1.Year;
            int year2 = time2.Year;
            int month1 = time1.Month;
            int month2 = time2.Month;

            for (var i = year1; i <= year2; i++)
            {
                int j = 1;
                int k = 12;
                if (i == year1 && i == year2)
                {
                    j = month1;
                    k = month2;
                }
                else if (i == year1)
                {
                    j = month1;
                    k = 12;
                }
                else if (i == year2)
                {
                    j = 1;
                    k = month2;
                }
                else
                {
                    j = 1;
                    k = 12;
                }

                for (; j <= k; j++)
                {
                    var item = new EyouSoft.Model.TongJiStructure.MLiRunGuSuanBiao1Info();
                    item.Year = i;
                    item.Month = j;
                    items.Add(item);
                }
            }

            #region sql
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" SELECT YEAR(RiQi) AS YYYY,MONTH(RiQi) AS MM,LeiXing,SUM(JinE) AS JinE ");
            sql.AppendFormat(" FROM [view_TongJi_LiRunGuSuanBiao1] ");

            sql.AppendFormat(" WHERE CompanyId={0} ", companyId);
            sql.AppendFormat(" AND ZxsId='{0}' ", zxsId);
            sql.AppendFormat(" AND RiQi>'{0}' ", time1.AddSeconds(-1));
            sql.AppendFormat(" AND RiQi<'{0}' ", time2.AddDays(1));

            sql.AppendFormat(" GROUP BY YEAR(RiQi),MONTH(RiQi),LeiXing ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    int _yyyy = rdr.GetInt32(rdr.GetOrdinal("YYYY"));
                    int _mm = rdr.GetInt32(rdr.GetOrdinal("MM"));
                    int _leiXing = rdr.GetInt32(rdr.GetOrdinal("LeiXing"));
                    decimal _jinE = 0;
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JinE"))) _jinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));

                    var item = items.FindLast(tmp => tmp.Year == _yyyy && tmp.Month == _mm);

                    switch (_leiXing)
                    {
                        case 1: item.JieSuanShouRuJinE = _jinE; break;
                        case 2: item.JieSuanZhiChuJinE = _jinE; break;
                        case 3: item.YingYeWaiShouRuJinE = _jinE; break;
                        case 4: item.BaoXiaoJinE = _jinE; break;
                        case 5: item.GongZiJinE = _jinE; break;
                    }
                }
            }

            return items;
        }
        #endregion
    }
}
