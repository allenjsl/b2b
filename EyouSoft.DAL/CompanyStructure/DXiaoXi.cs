using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.CompanyStructure
{
    /// <summary>
    /// 消息数据访问类
    /// </summary>
    public class DXiaoXi : DALBase, EyouSoft.IDAL.CompanyStructure.IXiaoXi
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
        public DXiaoXi()
        {
            _db = SystemStore;
        }
        #endregion

        #region IXiaoXi 成员
        /// <summary>
        /// （管理后台）获取消息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo> GetXiaoXis(int companyId, string zxsId, int yongHuId)
        {
            var cmd = _db.GetStoredProcCommand("proc_XiaoXi_GetZxsXiaoXi");
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@YongHuId", DbType.Int32, yongHuId);

            IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo> items = new List<EyouSoft.Model.CompanyStructure.MXiaoXiInfo>();

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.MXiaoXiInfo();
                    item.LeiXing = (EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// （同行后台）获取消息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo> PT_GetXiaoXis(int companyId, string keHuId, int yongHuId)
        {
            var cmd = _db.GetStoredProcCommand("proc_XiaoXi_GetKeHuXiaoXi");
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, keHuId);
            _db.AddInParameter(cmd, "@YongHuId", DbType.Int32, yongHuId);

            IList<EyouSoft.Model.CompanyStructure.MXiaoXiInfo> items = new List<EyouSoft.Model.CompanyStructure.MXiaoXiInfo>();

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.CompanyStructure.MXiaoXiInfo();
                    item.LeiXing = (EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    items.Add(item);
                }
            }

            return items;
        }

        #endregion
    }
}
