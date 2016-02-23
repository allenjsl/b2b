//订单回访信息数据访问类 汪奇志 2012-11-23
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

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 订单回访信息数据访问类
    /// </summary>
    public class DHuiFang : DALBase, IHuiFang
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_TourOrderHuiFang]([HuiFangId],[OrderId],[Time],[ShenFen],[XingMing],[Telephone],[JieGuo],[OperatorId],[IssueTime]) VALUES (@HuiFangId,@OrderId,@Time,@ShenFen,@XingMing,@Telephone,@JieGuo,@OperatorId,@IssueTime)";
        const string SQL_UPDATE_Update = "UPDATE [tbl_TourOrderHuiFang] SET [Time] = @Time,[ShenFen] = @ShenFen,[XingMing] = @XingMing,[Telephone] =@Telephone,[JieGuo] = @JieGuo WHERE  [HuiFangId] = @HuiFangId";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_TourOrderHuiFang] WHERE [HuiFangId]=@HuiFangId";
        const string SQL_SELECT_GetHuiFangs = "SELECT * FROM [tbl_TourOrderHuiFang] WHERE [OrderId]=@OrderId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DHuiFang()
        {
            _db = SystemStore;
        }
        #endregion

        #region EyouSoft.Toolkit.DAL.IHuiFang 成员
        /// <summary>
        /// 写入回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MHuiFangInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);
            _db.AddInParameter(cmd, "HuiFangId", DbType.AnsiStringFixedLength, info.HuiFangId);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, info.OrderId);
            _db.AddInParameter(cmd, "Time", DbType.DateTime, info.Time);
            _db.AddInParameter(cmd, "ShenFen", DbType.String, info.ShenFen);
            _db.AddInParameter(cmd, "XingMing", DbType.String, info.XingMing);
            _db.AddInParameter(cmd, "Telephone", DbType.String, info.Telephone);
            _db.AddInParameter(cmd, "JieGuo", DbType.String, info.JieGuo);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 修改回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MHuiFangInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);
            _db.AddInParameter(cmd, "HuiFangId", DbType.AnsiStringFixedLength, info.HuiFangId);
            _db.AddInParameter(cmd, "Time", DbType.DateTime, info.Time);
            _db.AddInParameter(cmd, "ShenFen", DbType.String, info.ShenFen);
            _db.AddInParameter(cmd, "XingMing", DbType.String, info.XingMing);
            _db.AddInParameter(cmd, "Telephone", DbType.String, info.Telephone);
            _db.AddInParameter(cmd, "JieGuo", DbType.String, info.JieGuo);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 删除回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="huiFangId">回访编号</param>
        /// <returns></returns>
        public int Delete(string huiFangId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);
            _db.AddInParameter(cmd, "HuiFangId", DbType.AnsiStringFixedLength, huiFangId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取回访信息集合
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public IList<MHuiFangInfo> GetHuiFangs(string orderId)
        {
            IList<MHuiFangInfo> items = new List<MHuiFangInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetHuiFangs);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MHuiFangInfo();
                    item.HuiFangId = rdr.GetString(rdr.GetOrdinal("HuiFangId"));
                    item.IssueTime=rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JieGuo = rdr["JieGuo"].ToString();
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.OrderId = orderId;
                    item.ShenFen = rdr["ShenFen"].ToString();
                    item.Telephone = rdr["Telephone"].ToString();
                    item.Time = rdr.GetDateTime(rdr.GetOrdinal("Time"));
                    item.XingMing = rdr["XingMing"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        #endregion
    }
}
