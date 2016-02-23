using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.PtStructure
{
    public class DJiuDian : DALBase, EyouSoft.IDAL.PtStructure.IJiuDian
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetInfo = "SELECT * FROM tbl_Pt_JiuDian WHERE JiuDianId=@JiuDianId";
        const string SQL_SELECT_GetJiuDianFuJians = "SELECT * FROM tbl_Pt_JiuDianFuJian WHERE JiuDianId=@JiuDianId ORDER BY FuJianId ASC";
        const string SQL_SELECT_GetFangXings = "SELECT * FROM tbl_Pt_JiuDianFangXing WHERE JiuDianId=@JiuDianId ORDER BY PaiXuId ASC,IssueTime DESC";
        const string SQL_SELECT_GetFangXingInfo = "SELECT * FROM tbl_Pt_JiuDianFangXing WHERE FangXingId=@FangXingId";
        const string SQL_SELECT_GetFangXingFuJians = "SELECT * FROM tbl_Pt_JiuDianFangXingFuJian WHERE FangXingId=@FangXingId ORDER BY FuJianId ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJiuDian()
        {
            _db = SystemStore;
        }
        #endregion  
      
        #region private members
        /// <summary>
        /// get jiudian fujians
        /// </summary>
        /// <param name="jiuDianId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetJiuDianFuJians(string jiuDianId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();

            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetJiuDianFuJians);
            _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, jiuDianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MFuJianInfo();
                    item.Filepath = rdr["Filepath"].ToString();
                    item.FuJianId = rdr.GetInt32(rdr.GetOrdinal("FuJianId"));
                    item.MiaoShu = rdr["MiaoShu"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// get jiudian fangxing fujians
        /// </summary>
        /// <param name="jiuDianId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFuJianInfo> GetFangXingFuJians(string fangXingId)
        {
            IList<EyouSoft.Model.PtStructure.MFuJianInfo> items = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();

            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetFangXingFuJians);
            _db.AddInParameter(cmd, "FangXingId", DbType.AnsiStringFixedLength, fangXingId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MFuJianInfo();
                    item.Filepath = rdr["Filepath"].ToString();
                    item.FuJianId = rdr.GetInt32(rdr.GetOrdinal("FuJianId"));
                    item.MiaoShu = rdr["MiaoShu"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region IJiuDian 成员
        /// <summary>
        /// 新增酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MJiuDianInfo info)
        {
            #region sql
            string sql = " INSERT INTO [tbl_Pt_JiuDian]([JiuDianId],[CompanyId],[MingCheng],[ProvinceId],[CityId],[DiZhi],[KaiYeShiJian],[LouCengShuLiang],[ZhuangXiuShiJian],[XingJi],[DianHua],[JianJie],[JiaoTong],[WangLuo],[OperatorId],[IssueTime],[FengMian],[JiuDianYongHuId],[PaiXuId],[JianYaoJieShao]) VALUES (@JiuDianId,@CompanyId,@MingCheng,@ProvinceId,@CityId,@DiZhi,@KaiYeShiJian,@LouCengShuLiang,@ZhuangXiuShiJian,@XingJi,@DianHua,@JianJie,@JiaoTong,@WangLuo,@OperatorId,@IssueTime,@FengMian,@JiuDianYongHuId,@PaiXuId,@JianYaoJieShao); ";

            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_JiuDianFuJian]([JiuDianId],[LeiXing],[Filepath],[MiaoShu])VALUES(@JiuDianId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, info.JiuDianId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "ProvinceId", DbType.Int32, info.ProvinceId);
            _db.AddInParameter(cmd, "CityId", DbType.Int32, info.CityId);
            _db.AddInParameter(cmd, "DiZhi", DbType.String, info.DiZhi);
            _db.AddInParameter(cmd, "KaiYeShiJian", DbType.String, info.KaiYeShiJian);
            _db.AddInParameter(cmd, "LouCengShuLiang", DbType.String, info.LouCengShuLiang);
            _db.AddInParameter(cmd, "ZhuangXiuShiJian", DbType.String, info.ZhuangXiuShiJian);
            _db.AddInParameter(cmd, "XingJi", DbType.Byte, info.XingJi);
            _db.AddInParameter(cmd, "DianHua", DbType.String, info.DianHua);
            _db.AddInParameter(cmd, "JianJie", DbType.String, info.JianJie);
            _db.AddInParameter(cmd, "JiaoTong", DbType.String, info.JiaoTong);
            _db.AddInParameter(cmd, "WangLuo", DbType.String, info.WangLuo);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "JiuDianYongHuId", DbType.Int32, info.JiuDianYongHuId);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "JianYaoJieShao", DbType.String, info.JianYaoJieShao);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 修改酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.PtStructure.MJiuDianInfo info)
        {
            #region sql
            string sql = " UPDATE [tbl_Pt_JiuDian] SET [MingCheng]=@MingCheng,[ProvinceId]=@ProvinceId,[CityId]=@CityId,[DiZhi]=@DiZhi,[KaiYeShiJian]=@KaiYeShiJian,[LouCengShuLiang]=@LouCengShuLiang,[ZhuangXiuShiJian]=@ZhuangXiuShiJian,[XingJi]=@XingJi,[DianHua]=@DianHua,[JianJie]=@JianJie,[JiaoTong]=@JiaoTong,[WangLuo]=@WangLuo,[FengMian]=@FengMian,[JiuDianYongHuId]=@JiuDianYongHuId,[PaiXuId]=@PaiXuId,[JianYaoJieShao]=@JianYaoJieShao WHERE [JiuDianId]=@JiuDianId; ";
            sql += " DELETE FROM tbl_Pt_JiuDianFuJian WHERE JiuDianId=@JiuDianId; ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_JiuDianFuJian]([JiuDianId],[LeiXing],[Filepath],[MiaoShu])VALUES(@JiuDianId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, info.JiuDianId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "ProvinceId", DbType.Int32, info.ProvinceId);
            _db.AddInParameter(cmd, "CityId", DbType.Int32, info.CityId);
            _db.AddInParameter(cmd, "DiZhi", DbType.String, info.DiZhi);
            _db.AddInParameter(cmd, "KaiYeShiJian", DbType.String, info.KaiYeShiJian);
            _db.AddInParameter(cmd, "LouCengShuLiang", DbType.String, info.LouCengShuLiang);
            _db.AddInParameter(cmd, "ZhuangXiuShiJian", DbType.String, info.ZhuangXiuShiJian);
            _db.AddInParameter(cmd, "XingJi", DbType.Byte, info.XingJi);
            _db.AddInParameter(cmd, "DianHua", DbType.String, info.DianHua);
            _db.AddInParameter(cmd, "JianJie", DbType.String, info.JianJie);
            _db.AddInParameter(cmd, "JiaoTong", DbType.String, info.JiaoTong);
            _db.AddInParameter(cmd, "WangLuo", DbType.String, info.WangLuo);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "JiuDianYongHuId", DbType.Int32, info.JiuDianYongHuId);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "JianYaoJieShao", DbType.String, info.JianYaoJieShao);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 删除酒店信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        public int Delete(int companyId, string jiuDianId)
        {
            string sql = " DELETE FROM tbl_Pt_JiuDianFangXingFuJian WHERE FangXingId IN(SELECT FangXingId FROM tbl_Pt_JiuDianFangXing WHERE JiuDianId=@JiuDianId); ";
            sql += " DELETE FROM tbl_Pt_JiuDianFangXing WHERE JiuDianId=@JiuDianId; ";
            sql += " DELETE FROM tbl_Pt_JiuDianFuJian WHERE JiuDianId=@JiuDianId; ";
            sql += " DELETE FROM tbl_Pt_JiuDian WHERE JiuDianId=@JiuDianId; ";

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, jiuDianId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJiuDianInfo GetInfo(string jiuDianId)
        {
            EyouSoft.Model.PtStructure.MJiuDianInfo info = null;
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, jiuDianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MJiuDianInfo();
                    info.CityId = rdr.GetInt32(rdr.GetOrdinal("CityId"));
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.DianHua = rdr["DianHua"].ToString();
                    info.DiZhi = rdr["DiZhi"].ToString();
                    info.FangXings = null;
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JianJie = rdr["JianJie"].ToString();
                    info.JiaoTong = rdr["JiaoTong"].ToString();
                    info.JiuDianId = jiuDianId;
                    info.KaiYeShiJian = rdr["KaiYeShiJian"].ToString();
                    info.LouCengShuLiang = rdr["LouCengShuLiang"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ProvinceId = rdr.GetInt32(rdr.GetOrdinal("ProvinceId"));
                    info.WangLuo = rdr["WangLuo"].ToString();
                    info.XingJi = (EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi)rdr.GetByte(rdr.GetOrdinal("XingJi"));
                    info.ZhuangXiuShiJian = rdr["ZhuangXiuShiJian"].ToString();
                    info.JiuDianYongHuId = rdr.GetInt32(rdr.GetOrdinal("JiuDianYongHuId"));
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.JianYaoJieShao = rdr["JianYaoJieShao"].ToString();
                }
            }

            if (info != null)
            {
                info.FuJians = GetJiuDianFuJians(jiuDianId);
            }

            return info;
        }

        /// <summary>
        /// 获取酒店集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJiuDianInfo> GetJiuDians(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MJiuDianChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MJiuDianInfo> items = new List<EyouSoft.Model.PtStructure.MJiuDianInfo>();
            string fields = "*,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=tbl_Pt_JiuDian.ProvinceId) AS ShengFenName,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=tbl_Pt_JiuDian.CityId) AS ChengShiName";
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_Pt_JiuDian";
            string orderByString = " PaiXuId ASC,IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" CompanyId={0} ", companyId);

            if (chaXun != null)
            {
                if (chaXun.ChengShiId.HasValue)
                {
                    sql.AppendFormat(" AND CityId={0} ", chaXun.ChengShiId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.FangXingMingCheg))
                {
                    sql.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_Pt_JiuDianFangXing AS A1 WHERE A1.JiuDianId=tbl_Pt_JiuDian.JiuDianId AND A1.MingCheng LIKE '%{0}%') ", chaXun.FangXingMingCheg);
                }
                if (!string.IsNullOrEmpty(chaXun.JiuDianMingCheng))
                {
                    sql.AppendFormat(" AND MingCheng LIKE '%{0}%' ", chaXun.JiuDianMingCheng);
                }
                if (chaXun.ShengFenId.HasValue)
                {
                    sql.AppendFormat(" AND ProvinceId={0} ", chaXun.ShengFenId.Value);
                }
                if (chaXun.XingJi.HasValue)
                {
                    sql.AppendFormat(" AND XingJi={0} ", (int)chaXun.XingJi.Value);
                }
                if (chaXun.JiuDianYongHuId.HasValue)
                {
                    sql.AppendFormat(" AND JiuDianYongHuId={0} ", chaXun.JiuDianYongHuId.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MJiuDianInfo();

                    info = new EyouSoft.Model.PtStructure.MJiuDianInfo();
                    info.CityId = rdr.GetInt32(rdr.GetOrdinal("CityId"));
                    info.CompanyId = companyId;
                    info.DianHua = rdr["DianHua"].ToString();
                    info.DiZhi = rdr["DiZhi"].ToString();
                    info.FangXings = null;
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JianJie = rdr["JianJie"].ToString();
                    info.JiaoTong = rdr["JiaoTong"].ToString();
                    info.JiuDianId = rdr["JiuDianId"].ToString();
                    info.KaiYeShiJian = rdr["KaiYeShiJian"].ToString();
                    info.LouCengShuLiang = rdr["LouCengShuLiang"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ProvinceId = rdr.GetInt32(rdr.GetOrdinal("ProvinceId"));
                    info.WangLuo = rdr["WangLuo"].ToString();
                    info.XingJi = (EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi)rdr.GetByte(rdr.GetOrdinal("XingJi"));
                    info.ZhuangXiuShiJian = rdr["ZhuangXiuShiJian"].ToString();

                    info.ShengFenName = rdr["ShengFenName"].ToString();
                    info.ChengShiName = rdr["ChengShiName"].ToString();
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));

                    info.JianYaoJieShao = rdr["JianYaoJieShao"].ToString();

                    items.Add(info);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.FangXings = GetFangXings(item.JiuDianId);
                }
            }

            return items;
        }

        /// <summary>
        /// 新增酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertFangXing(EyouSoft.Model.PtStructure.MJiuDianFangXingInfo info)
        {
            #region sql
            string sql = " INSERT INTO [tbl_Pt_JiuDianFangXing]([FangXingId],[JiuDianId],[MingCheng],[ShuLiang],[MianJi],[LouCeng],[ChuangWeiPeiZhi],[KeFangSheShi],[GuaPaiJiaGe],[JieShao],[FengMian],[OperatorId],[IssueTime],[PaiXuId],[RuZhuRiQi1],[RuZhuRiQi2],[YouHuiJiaGe]) VALUES (@FangXingId,@JiuDianId,@MingCheng,@ShuLiang,@MianJi,@LouCeng,@ChuangWeiPeiZhi,@KeFangSheShi,@GuaPaiJiaGe,@JieShao,@FengMian,@OperatorId,@IssueTime,@PaiXuId,@RuZhuRiQi1,@RuZhuRiQi2,@YouHuiJiaGe); ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_JiuDianFangXingFuJian]([FangXingId],[LeiXing],[Filepath],[MiaoShu])VALUES(@FangXingId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "FangXingId", DbType.AnsiStringFixedLength, info.FangXingId);
            _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, info.JiuDianId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "ShuLiang", DbType.String, info.ShuLiang);
            _db.AddInParameter(cmd, "MianJi", DbType.String, info.MianJi);
            _db.AddInParameter(cmd, "LouCeng", DbType.String, info.LouCeng);
            _db.AddInParameter(cmd, "ChuangWeiPeiZhi", DbType.String, info.ChuangWeiPeiZhi);
            _db.AddInParameter(cmd, "KeFangSheShi", DbType.String, info.KeFangSheShi);
            _db.AddInParameter(cmd, "GuaPaiJiaGe", DbType.Decimal, info.GuaPaiJiaGe);
            _db.AddInParameter(cmd, "JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "RuZhuRiQi1", DbType.DateTime, info.RuZhuRiQi1);
            _db.AddInParameter(cmd, "RuZhuRiQi2", DbType.DateTime, info.RuZhuRiQi2);
            _db.AddInParameter(cmd, "YouHuiJiaGe", DbType.Decimal, info.YouHuiJiaGe);


            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 修改酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int UpdateFangXing(EyouSoft.Model.PtStructure.MJiuDianFangXingInfo info)
        {
            #region sql
            string sql = " UPDATE [tbl_Pt_JiuDianFangXing] SET [MingCheng]=@MingCheng,[ShuLiang]=@ShuLiang,[MianJi]=@MianJi,[LouCeng]=@LouCeng,[ChuangWeiPeiZhi]=@ChuangWeiPeiZhi,[KeFangSheShi]=@KeFangSheShi,[GuaPaiJiaGe]=@GuaPaiJiaGe,[JieShao]=@JieShao,[FengMian]=@FengMian,[PaiXuId]=@PaiXuId,[RuZhuRiQi1]=@RuZhuRiQi1,[RuZhuRiQi2]=@RuZhuRiQi2,[YouHuiJiaGe]=@YouHuiJiaGe WHERE [FangXingId]=@FangXingId; ";
            sql += "DELETE FROM tbl_Pt_JiuDianFangXingFuJian WHERE FangXingId=@FangXingId ";
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    sql += string.Format(" INSERT INTO [tbl_Pt_JiuDianFangXingFuJian]([FangXingId],[LeiXing],[Filepath],[MiaoShu])VALUES(@FangXingId,0,'{0}',''); ", item.Filepath);
                }
            }
            #endregion

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "FangXingId", DbType.AnsiStringFixedLength, info.FangXingId);
            _db.AddInParameter(cmd, "MingCheng", DbType.String, info.MingCheng);
            _db.AddInParameter(cmd, "ShuLiang", DbType.String, info.ShuLiang);
            _db.AddInParameter(cmd, "MianJi", DbType.String, info.MianJi);
            _db.AddInParameter(cmd, "LouCeng", DbType.String, info.LouCeng);
            _db.AddInParameter(cmd, "ChuangWeiPeiZhi", DbType.String, info.ChuangWeiPeiZhi);
            _db.AddInParameter(cmd, "KeFangSheShi", DbType.String, info.KeFangSheShi);
            _db.AddInParameter(cmd, "GuaPaiJiaGe", DbType.Decimal, info.GuaPaiJiaGe);
            _db.AddInParameter(cmd, "JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "FengMian", DbType.String, info.FengMian);
            _db.AddInParameter(cmd, "PaiXuId", DbType.Int32, info.PaiXuId);
            _db.AddInParameter(cmd, "RuZhuRiQi1", DbType.DateTime, info.RuZhuRiQi1);
            _db.AddInParameter(cmd, "RuZhuRiQi2", DbType.DateTime, info.RuZhuRiQi2);
            _db.AddInParameter(cmd, "YouHuiJiaGe", DbType.Decimal, info.YouHuiJiaGe);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 删除酒店房型，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiuDianId">酒店编号</param>
        /// <param name="fangXingId">房型编号</param>
        /// <returns></returns>
        public int DeleteFangXing(int companyId, string jiuDianId, string fangXingId)
        {
            string sql = " DELETE FROM tbl_Pt_JiuDianFangXingFuJian WHERE FangXingId=@FangXingId; ";
            sql += " DELETE FROM tbl_Pt_JiuDianFangXing WHERE FangXingId=@FangXingId AND JiuDianId=@JiuDianId; ";

            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "FangXingId", DbType.AnsiStringFixedLength, fangXingId);
            _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, jiuDianId);

            DbHelper.ExecuteSql(cmd, _db);
            return 1;
        }

        /// <summary>
        /// 获取酒店房型集合
        /// </summary>
        /// <param name="jiuDianId">酒店编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MJiuDianFangXingInfo> GetFangXings(string jiuDianId)
        {
            IList<EyouSoft.Model.PtStructure.MJiuDianFangXingInfo> items =new List<EyouSoft.Model.PtStructure.MJiuDianFangXingInfo>();
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetFangXings);
            _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, jiuDianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.PtStructure.MJiuDianFangXingInfo();
                    info.ChuangWeiPeiZhi = rdr["ChuangWeiPeiZhi"].ToString();
                    info.FangXingId = rdr["FangXingId"].ToString();
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.GuaPaiJiaGe = rdr.GetDecimal(rdr.GetOrdinal("GuaPaiJiaGe"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.JiuDianId = jiuDianId;
                    info.KeFangSheShi = rdr["KeFangSheShi"].ToString();
                    info.LouCeng = rdr["LouCeng"].ToString();
                    info.MianJi = rdr["MianJi"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ShuLiang = rdr["ShuLiang"].ToString();
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.RuZhuRiQi1 = rdr.GetDateTime(rdr.GetOrdinal("RuZhuRiQi1"));
                    info.RuZhuRiQi2 = rdr.GetDateTime(rdr.GetOrdinal("RuZhuRiQi2"));
                    info.YouHuiJiaGe = rdr.GetDecimal(rdr.GetOrdinal("YouHuiJiaGe"));
                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取酒店房型信息
        /// </summary>
        /// <param name="fangXingId">房型编号</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MJiuDianFangXingInfo GetFangXingInfo(string fangXingId)
        {
            EyouSoft.Model.PtStructure.MJiuDianFangXingInfo info = null;
            var cmd = _db.GetSqlStringCommand(SQL_SELECT_GetFangXingInfo);
            _db.AddInParameter(cmd, "FangXingId", DbType.AnsiStringFixedLength, fangXingId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    info = new EyouSoft.Model.PtStructure.MJiuDianFangXingInfo();
                    info.ChuangWeiPeiZhi = rdr["ChuangWeiPeiZhi"].ToString();
                    info.FangXingId = fangXingId;
                    info.FengMian = rdr["FengMian"].ToString();
                    info.FuJians = null;
                    info.GuaPaiJiaGe = rdr.GetDecimal(rdr.GetOrdinal("GuaPaiJiaGe"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JieShao = rdr["JieShao"].ToString();
                    info.JiuDianId = rdr["JiuDianId"].ToString();
                    info.KeFangSheShi = rdr["KeFangSheShi"].ToString();
                    info.LouCeng = rdr["LouCeng"].ToString();
                    info.MianJi = rdr["MianJi"].ToString();
                    info.MingCheng = rdr["MingCheng"].ToString();
                    info.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    info.ShuLiang = rdr["ShuLiang"].ToString();
                    info.PaiXuId = rdr.GetInt32(rdr.GetOrdinal("PaiXuId"));
                    info.RuZhuRiQi1 = rdr.GetDateTime(rdr.GetOrdinal("RuZhuRiQi1"));
                    info.RuZhuRiQi2 = rdr.GetDateTime(rdr.GetOrdinal("RuZhuRiQi2"));
                    info.YouHuiJiaGe = rdr.GetDecimal(rdr.GetOrdinal("YouHuiJiaGe"));
                }
            }

            if (info != null)
            {
                info.FuJians = GetFangXingFuJians(fangXingId);
            }

            return info;
        }
        #endregion
    }
}
