//平台-控位线路相关数据访问类 汪奇志 2014-09-01
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
    /// <summary>
    /// 平台-控位线路相关数据访问类
    /// </summary>
    public class DKongWeiXianLu : DALBase, EyouSoft.IDAL.PtStructure.IKongWeiXianLu
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
        public DKongWeiXianLu()
        {
            _db = SystemStore;
        }
        #endregion        

        #region private members
        /// <summary>
        /// get kongwei moren xianlu
        /// </summary>
        /// <param name="info"></param>
        void GetKongWeiXianLu(EyouSoft.Model.PtStructure.MKongWeiXianLuInfo info,EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo chaXun)
        {
            if (info == null || string.IsNullOrEmpty(info.KongWeiId)) return;

            #region sql
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TOP 1 * FROM view_Pt_KongWeiXianLu WHERE KongWeiId=@KongWeiId ");

            if (chaXun != null)
            {
                if (chaXun.BiaoZhun.HasValue)
                {
                    sql.AppendFormat(" AND BiaoZhun={0} ", (int)chaXun.BiaoZhun.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.RouteName))
                {
                    sql.AppendFormat(" AND RouteName LIKE '%{0}%' ", chaXun.RouteName);
                }
                if (chaXun.KongWeiXianLuLeiXing.HasValue)
                {
                    sql.AppendFormat(" AND LeiXing={0} ", (int)chaXun.KongWeiXianLuLeiXing.Value);
                }
                if (chaXun.KongWeiXianLuStatus.HasValue)
                {
                    sql.AppendFormat(" AND Status={0} ", (int)chaXun.KongWeiXianLuStatus);
                }
            }

            

            sql.Append(" ORDER BY PaiXuId ASC, IdentityId ASC ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, info.KongWeiId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info.XianLuJieSuanJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe1"));
                    info.XianLuJieSuanJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe2"));
                    info.XianLuJiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    info.KongWeiXianLuLeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    info.XianLuMenShiJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe1"));
                    info.XianLuMenShiJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe2"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("BiaoZhun"))) info.XianLuBiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun)rdr.GetByte(rdr.GetOrdinal("BiaoZhun"));
                    info.XianLuFengMian = rdr["FengMian"].ToString();
                    info.XianLuId = rdr["XianLuId"].ToString();
                    info.XianLuName = rdr["RouteName"].ToString();
                    info.XianDingRenShu = rdr.GetInt32(rdr.GetOrdinal("XianDingRenShu"));
                }
            }
        }
        #endregion

        #region IKongWeiXianLu 成员
        /// <summary>
        /// 获取控位线路集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo> GetKongWeis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo> items = new List<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Pt_KongWei";
            string orderByString = " QuDate ASC ";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (chaXun.BiaoZhun.HasValue || !string.IsNullOrEmpty(chaXun.RouteName)||chaXun.KongWeiXianLuLeiXing.HasValue||chaXun.KongWeiXianLuStatus.HasValue)
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM view_Pt_KongWeiXianLu AS A1 WHERE A1.KongWeiId=view_Pt_KongWei.KongWeiId  ");
                    if (chaXun.BiaoZhun.HasValue)
                    {
                        query.AppendFormat(" AND A1.BiaoZhun={0} ", (int)chaXun.BiaoZhun.Value);
                    }
                    if (!string.IsNullOrEmpty(chaXun.RouteName))
                    {
                        query.AppendFormat(" AND A1.RouteName LIKE '%{0}%' ", chaXun.RouteName);
                    }
                    if (chaXun.KongWeiXianLuLeiXing.HasValue)
                    {
                        query.AppendFormat(" AND A1.LeiXing={0} ", (int)chaXun.KongWeiXianLuLeiXing.Value);
                    }
                    if (chaXun.KongWeiXianLuStatus.HasValue)
                    {
                        query.AppendFormat(" AND A1.Status={0} ", (int)chaXun.KongWeiXianLuStatus);
                    }
                    query.AppendFormat(" ) ");
                }
                if (chaXun.QuDate1.HasValue)
                {
                    query.AppendFormat(" AND QuDate>='{0}' ", chaXun.QuDate1.Value);
                }
                if (chaXun.QuDate2.HasValue)
                {
                    query.AppendFormat(" AND QuDate<='{0}' ", chaXun.QuDate2.Value);
                }
                if (chaXun.QuYuId.HasValue)
                {
                    query.AppendFormat(" AND AreaId={0} ", chaXun.QuYuId.Value);
                }
                if (chaXun.ZhanDianId.HasValue)
                {
                    query.AppendFormat(" AND ZhanDianId={0} ", chaXun.ZhanDianId.Value);
                }
                if (chaXun.ZxlbId.HasValue)
                {
                    query.AppendFormat(" AND ZxlbId={0} ", chaXun.ZxlbId);
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                if (chaXun.ExistsTingShou1 == 0)
                {
                    query.AppendFormat(" AND ShouKeStatus IN(0,2)  ");
                }
                if (chaXun.ExistsTingShou2 == 0)
                {
                    query.AppendFormat(" AND PingTaiShouKeStatus=0  ");
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MKongWeiXianLuInfo();

                    item.HuiBanCi = rdr["HuiBanCi"].ToString();
                    item.HuiChuFaDiChengShiName = rdr["HuiChuFaDiChengShiName"].ToString();
                    item.HuiChuFaDiShengFenName = rdr["HuiChuFaDiShengFenName"].ToString();
                    item.HuiJiaoTongName = rdr["HuiJiaoTongName"].ToString();
                    item.HuiMuDiDiChengShiName = rdr["HuiMuDiDiChengShiName"].ToString();
                    item.HuiMuDiDiShengFenName = rdr["HuiMuDiDiShengFenName"].ToString();
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.KongWeiShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    item.QuBanCi = rdr["QuBanCi"].ToString();
                    item.QuChuFaDiChengShiName = rdr["QuChuFaDiChengShiName"].ToString();
                    item.QuChuFaDiShengFenName = rdr["QuChuFaDiShengFenName"].ToString();
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.QuJiaoTongName = rdr["QuJiaoTongName"].ToString();
                    item.QuMuDiDiChengShiName = rdr["QuMuDiDiChengShiName"].ToString();
                    item.QuMuDiDiShengFenName = rdr["QuMuDiDiShengFenName"].ToString();
                    item.QuYuId = rdr.GetInt32(rdr.GetOrdinal("AreaId"));
                    item.QuYuName = rdr["QuYuName"].ToString();
                    item.TianShu = rdr.GetInt32(rdr.GetOrdinal("TianShu"));
                    item.YiZhanWeiShuLiang = rdr.GetInt32(rdr.GetOrdinal("YiZhanWeiShuLiang"));
                    item.PingTaiShuLiang = rdr.GetInt32(rdr.GetOrdinal("PingTaiShuLiang"));

                    item.ShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiStatus)rdr.GetByte(rdr.GetOrdinal("ShouKeStatus"));
                    item.PingTaiShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus)rdr.GetByte(rdr.GetOrdinal("PingTaiShouKeStatus"));

                    items.Add(item);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    GetKongWeiXianLu(item,chaXun);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取控位下线路集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo> GetKongWeiXianLus(string kongWeiId, EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo> items = new List<EyouSoft.Model.PtStructure.MKongWeiXianLuInfo>();
            #region sql
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM view_Pt_KongWeiXianLu WHERE KongWeiId=@KongWeiId");

            if (chaXun != null)
            {
                if (chaXun.BiaoZhun.HasValue)
                {
                    sql.AppendFormat(" AND BiaoZhun={0} ", (int)chaXun.BiaoZhun.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.RouteName))
                {
                    sql.AppendFormat(" AND RouteName LIKE '%{0}%' ", chaXun.RouteName);
                }
                if (!string.IsNullOrEmpty(chaXun.XianLuId1))
                {
                    sql.AppendFormat(" AND XianLuId<>'{0}' ", chaXun.XianLuId1);
                }
                if (chaXun.KongWeiXianLuLeiXing.HasValue)
                {
                    sql.AppendFormat(" AND LeiXing={0} ", (int)chaXun.KongWeiXianLuLeiXing.Value);
                }
                if (chaXun.KongWeiXianLuStatus.HasValue)
                {
                    sql.AppendFormat(" AND Status={0} ", (int)chaXun.KongWeiXianLuStatus);
                }
            }

            sql.Append(" ORDER BY PaiXuId ASC, IdentityId ASC ");
            #endregion

            var cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "KongWeiId", DbType.AnsiStringFixedLength, kongWeiId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MKongWeiXianLuInfo();

                    item.XianLuJieSuanJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe1"));
                    item.XianLuJieSuanJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe2"));
                    item.XianLuJiFen = rdr.GetInt32(rdr.GetOrdinal("JiFen"));
                    item.KongWeiXianLuLeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.XianLuMenShiJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe1"));
                    item.XianLuMenShiJiaGe2 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe2"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("BiaoZhun"))) item.XianLuBiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun)rdr.GetByte(rdr.GetOrdinal("BiaoZhun"));
                    item.XianLuFengMian = rdr["FengMian"].ToString();
                    item.XianLuId = rdr["XianLuId"].ToString();
                    item.XianLuName = rdr["RouteName"].ToString();
                    item.XianDingRenShu = rdr.GetInt32(rdr.GetOrdinal("XianDingRenShu"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:成人数][1:int:儿童数][2:int:婴儿数][3:int:全陪数][4:int:占位数][5:decimal:总金额][6:decimal:已支付金额]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MDingDanLbInfo> GetDingDans(int companyId, string keHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MDingDanLbChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0, 0, 0M, 0M };
            IList<EyouSoft.Model.PtStructure.MDingDanLbInfo> items = new List<EyouSoft.Model.PtStructure.MDingDanLbInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Pt_DingDan";
            string orderByString = " IssueTime DESC ";
            string sumString = "SUM(Adults) AS ChengRenShuHeJi,SUM(Childs) AS ErTongShuHeJi,SUM(YingErRenShu) AS YingErShuHeJi,SUM(Bears) AS QuanPeiShuHeJi,SUM(Accounts) AS ZhanWeiShuHeJi,SUM(SumPrice) JinEHeJi,SUM(CheckMoney) AS YiShouJiEHeJi,SUM(ReturnMoney) AS YiTuiJinEHeJi";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            query.AppendFormat(" AND BuyCompanyId='{0}' ", keHuId);
            if (chaXun != null)
            {
                if (chaXun.DingDanStatus.HasValue)
                {
                    query.AppendFormat(" AND OrderStatus={0} ", (int)chaXun.DingDanStatus.Value);
                }
                if (chaXun.JieQingStatus.HasValue)
                {
                    if (chaXun.JieQingStatus.Value == 0)
                    {
                        query.Append(" AND SumPrice-CheckMoney+ReturnMoney<>0 ");
                    }
                    else if (chaXun.JieQingStatus.Value == 1)
                    {
                        query.Append(" AND SumPrice-CheckMoney+ReturnMoney=0 ");
                    }
                }
                if (chaXun.QuDate1.HasValue)
                {
                    query.AppendFormat(" AND QuDate>='{0}' ", chaXun.QuDate1.Value);
                }
                if (chaXun.QuDate2.HasValue)
                {
                    query.AppendFormat(" AND QuDate<='{0}' ", chaXun.QuDate2.Value);
                }
                if (chaXun.YeWuLeiXing.HasValue)
                {
                    query.AppendFormat(" AND BusinessType={0} ", (int)chaXun.YeWuLeiXing.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.YouKeName))
                {
                    query.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_TourOrderTraveller AS A WHERE A.OrderId=view_TourOrder.OrderId AND A.TravellerName LIKE '%{0}%') ", chaXun.YouKeName);
                }

                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
                else if (!string.IsNullOrEmpty(chaXun.ZxsName))
                {
                    query.AppendFormat(" AND ZxsName LIKE '%{0}%' ", chaXun.ZxsName);
                }

                if (chaXun.XiaDanShiJian0.HasValue)
                {
                    query.AppendFormat(" AND IssueTime>'{0}' ", chaXun.XiaDanShiJian0.Value);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MDingDanLbInfo();

                    item.ChengRenShu = rdr.GetInt32(rdr.GetOrdinal("Adults"));
                    item.DingDanId = rdr["OrderId"].ToString();
                    item.DingDanStatus = (EyouSoft.Model.EnumType.TourStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("OrderStatus"));
                    item.ErTongShu = rdr.GetInt32(rdr.GetOrdinal("Childs"));
                    item.JiaoYiHao = rdr["OrderCode"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("SumPrice"));
                    item.KeHuLxrId = rdr.GetInt32(rdr.GetOrdinal("BuyOperatorId"));
                    item.KeHuLxrName = rdr["KeHuLxrName"].ToString();
                    item.QuanPeiShu = rdr.GetInt32(rdr.GetOrdinal("Bears"));
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.RotueName = rdr["RouteName"].ToString();
                    item.XiaDanLeiXing = (EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing)rdr.GetByte(rdr.GetOrdinal("XiaDanLeiXing"));
                    item.XiaDanRenId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));                    
                    item.XiaDanRenName = rdr["XiaDanRenName"].ToString();
                    item.XiaDanShiJian = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("BusinessType"));
                    item.YingErShu = rdr.GetInt32(rdr.GetOrdinal("YingErRenShu"));
                    item.YiZhiFuJinE = rdr.GetDecimal(rdr.GetOrdinal("CheckMoney")) - rdr.GetDecimal(rdr.GetOrdinal("ReturnMoney"));
                    item.ZxsCaoZuoRenId = rdr.GetInt32(rdr.GetOrdinal("LatestOperatorId"));
                    item.ZxsCaoZuoRenName = rdr["LatestOperatorName"].ToString();
                    item.ZxsCaoZuoShiJian = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    item.ZxsId = rdr["ZxsId"].ToString();
                    item.ZxsName = rdr["ZxsName"].ToString();
                    item.JiFen1 = rdr.GetInt32(rdr.GetOrdinal("JiFen1"));
                    item.JiFen2 = rdr.GetInt32(rdr.GetOrdinal("JiFen2"));
                    item.YuanYin1 = rdr["YuanYin1"].ToString();
                    item.JiFenXianShiBiaoShi = (EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi)rdr.GetByte(rdr.GetOrdinal("JiFenXianShiBiaoShi"));

                    if (!rdr.IsDBNull(rdr.GetOrdinal("FaPiaoMxId"))) item.FaPiaoMxId = rdr.GetInt32(rdr.GetOrdinal("FaPiaoMxId"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ChengRenShuHeJi"))) heJi[0] = rdr.GetInt32(rdr.GetOrdinal("ChengRenShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ErTongShuHeJi"))) heJi[1] = rdr.GetInt32(rdr.GetOrdinal("ErTongShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YingErShuHeJi"))) heJi[2] = rdr.GetInt32(rdr.GetOrdinal("YingErShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("QuanPeiShuHeJi"))) heJi[3] = rdr.GetInt32(rdr.GetOrdinal("QuanPeiShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("ZhanWeiShuHeJi"))) heJi[4] = rdr.GetInt32(rdr.GetOrdinal("ZhanWeiShuHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("JinEHeJi"))) heJi[5] = rdr.GetDecimal(rdr.GetOrdinal("JinEHeJi"));

                    decimal _YiShouJiEHeJi = 0, _YiTuiJinEHeJi = 0;

                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiShouJiEHeJi"))) _YiShouJiEHeJi = rdr.GetDecimal(rdr.GetOrdinal("YiShouJiEHeJi"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YiTuiJinEHeJi"))) _YiTuiJinEHeJi = rdr.GetDecimal(rdr.GetOrdinal("YiTuiJinEHeJi"));

                    heJi[6] = _YiShouJiEHeJi - _YiTuiJinEHeJi;
                }
            }

            return items;
        }

        /// <summary>
        /// 获取关联控位线路产品集合
        /// </summary>
        /// <param name="xianLuId">控位线路产品编号</param>
        /// <param name="quDate1">关联产品去程日期-起</param>
        /// <param name="quDate2">关联产品去程日期-止</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.PtStructure.MGuanLianKongWeiXianLuInfo> GetGuanLianKongWeiXianLus(string xianLuId, DateTime quDate1, DateTime quDate2)
        {
            IList<EyouSoft.Model.PtStructure.MGuanLianKongWeiXianLuInfo> items = new List<EyouSoft.Model.PtStructure.MGuanLianKongWeiXianLuInfo>();
            var cmd = _db.GetStoredProcCommand("proc_Pt_GetGuanLianKongWeiXianLu");
            _db.AddInParameter(cmd, "@XianLuId", DbType.AnsiStringFixedLength, xianLuId);
            _db.AddInParameter(cmd, "@QuDate1", DbType.DateTime, quDate1);
            _db.AddInParameter(cmd, "@QuDate2", DbType.DateTime, quDate2);

            using (var rdr = DbHelper.RunReaderProcedure(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.PtStructure.MGuanLianKongWeiXianLuInfo();
                    item.JieSuanJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("JieSuanJiaGe1"));
                    item.KongWeiId = rdr["KongWeiId"].ToString();
                    item.KongWeiXianLuLeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)rdr.GetByte(rdr.GetOrdinal("KongWeiXianLuLeiXing"));
                    item.MenShiJiaGe1 = rdr.GetDecimal(rdr.GetOrdinal("MenShiJiaGe1"));
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    item.XianLuId = rdr["XianLuId"].ToString();
                    item.YiZhanWeiShuLiang = rdr.GetInt32(rdr.GetOrdinal("YiZhanWeiShuLiang"));
                    item.PingTaiShuLiang = rdr.GetInt32(rdr.GetOrdinal("PingTaiShuLiang"));
                    item.PingTaiShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus)rdr.GetByte(rdr.GetOrdinal("PingTaiShouKeStatus"));
                    item.ShouKeStatus = (EyouSoft.Model.EnumType.TourStructure.KongWeiStatus)rdr.GetByte(rdr.GetOrdinal("ShouKeStatus"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion
    }
}
