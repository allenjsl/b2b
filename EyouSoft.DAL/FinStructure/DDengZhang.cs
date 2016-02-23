using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.EnumType.FinStructure;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.FinStructure
{
    /// <summary>
    /// 出纳登帐信息
    /// </summary>
    public class DDengZhang : Toolkit.DAL.DALBase, IDAL.FinStructure.IDengZhang
    {
        #region static constants
        //static constants
        const string SQL_UPDATE_QuXiaoShenPi = "UPDATE [tbl_FinRegister] SET [Status]=@Status WHERE [DengZhangId]=@DengZhangId AND [CompanyId]=@CompanyId;DELETE FROM [tbl_FinCope] WHERE [CollectionId]=@DengZhangId AND [CollectionItem]=@KuanXiangType;";
        #endregion

        #region constructor
        private readonly Database _db;

        public DDengZhang()
        {
            _db = this.SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 创建销账、冲抵编号集合XML
        /// </summary>
        /// <param name="items">销账、冲抵编号集合</param>
        /// <returns></returns>
        string CreateIdXml(string[] items)
        {
            //销账、冲抵编号集合XML:<root><info Id="" /></root>
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            if (items != null && items.Length > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<info Id=\"{0}\" />", item);
                }
            }
            s.Append("</root>");
            return s.ToString();
        }
        #endregion

        #region IDAL.FinStructure.IDengZhang members
        /// <summary>
        /// 添加出纳登账信息
        /// </summary>
        /// <param name="model">添加出纳登帐信息</param>
        /// <returns>返回1成功；其他失败</returns>
        public int AddDengZhang(MChuNaDengZhang model)
        {
            if (model == null || string.IsNullOrEmpty(model.DaoKuanBankId)
                || model.DaoKuanJinE <= 0) return 0;

            if (string.IsNullOrEmpty(model.DengZhangId)) model.DengZhangId = Guid.NewGuid().ToString();
            model.Status = Model.EnumType.FinStructure.KuanXiangStatus.未审批;

            var strSql = new StringBuilder();
            //写登账信息表
            strSql.Append(" INSERT INTO [tbl_FinRegister] ([DengZhangId],[CompanyId],[DaoKuanTime],[DaoKuanJinE],[BankId],[PayType],[Remark],[OperatorId],[IssueTime],[Status],[ZxsId]) VALUES (@DengZhangId,@CompanyId,@DaoKuanTime,@DaoKuanJinE,@BankId,@PayType,@Remark,@OperatorId,@IssueTime,@Status,@ZxsId); ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            //登帐参数
            _db.AddInParameter(dc, "DengZhangId", DbType.AnsiStringFixedLength, model.DengZhangId);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "DaoKuanTime", DbType.DateTime, model.DaoKuanTime);
            _db.AddInParameter(dc, "DaoKuanJinE", DbType.Decimal, model.DaoKuanJinE);
            _db.AddInParameter(dc, "BankId", DbType.AnsiStringFixedLength, model.DaoKuanBankId);
            _db.AddInParameter(dc, "PayType", DbType.Byte, (int)model.FuKuanFangShi);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(dc, "Status", DbType.Byte, (int)model.Status);
            _db.AddInParameter(dc, "ZxsId", DbType.AnsiStringFixedLength,model.ZxsId);

            return Toolkit.DAL.DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : -1;
        }

        /// <summary>
        /// 修改登账信息
        /// </summary>
        /// <param name="model">出纳登帐信息</param>
        /// <returns>
        /// 返回1成功；
        /// 0参数错误；
        /// -1修改失败;
        /// -2登账信息已经审批，不能修改 
        /// </returns>
        public int UpdateDengZhang(MChuNaDengZhang model)
        {
            if (model == null || string.IsNullOrEmpty(model.DaoKuanBankId)
                || model.DaoKuanJinE <= 0 || string.IsNullOrEmpty(model.DengZhangId)) return 0;

            model.Status = Model.EnumType.FinStructure.KuanXiangStatus.未审批;
            var strSql = new StringBuilder();
            strSql.Append(" declare @returnIndex int; ");
            strSql.Append(" set @returnIndex = -1; ");
            strSql.Append(" select @returnIndex = count(*) from [tbl_FinRegister] where [DengZhangId] = @DengZhangId and Status = @Status; ");
            strSql.Append(" if @returnIndex > 0 ");
            strSql.Append(" begin ");
            strSql.Append(" UPDATE [tbl_FinRegister] SET [DaoKuanTime] = @DaoKuanTime,[DaoKuanJinE] = @DaoKuanJinE,[BankId] = @BankId,[PayType] = @PayType,[Remark] = @Remark,[OperatorId] = @OperatorId WHERE [DengZhangId] = @DengZhangId and Status = @Status; ");
            strSql.Append(" end ");
            strSql.Append(" select isnull(@returnIndex,0); ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            //登帐参数
            _db.AddInParameter(dc, "DengZhangId", DbType.AnsiStringFixedLength, model.DengZhangId);
            _db.AddInParameter(dc, "DaoKuanTime", DbType.DateTime, model.DaoKuanTime);
            _db.AddInParameter(dc, "DaoKuanJinE", DbType.Decimal, model.DaoKuanJinE);
            _db.AddInParameter(dc, "BankId", DbType.AnsiStringFixedLength, model.DaoKuanBankId);
            _db.AddInParameter(dc, "PayType", DbType.Byte, (int)model.FuKuanFangShi);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "Status", DbType.Byte, (int)model.Status);

            object obj = Toolkit.DAL.DbHelper.GetSingleBySqlTrans(dc, _db);
            if (obj == null) return -1;

            if (Toolkit.Utils.GetInt(obj.ToString()) <= 0) return -2;

            return 1;
        }

        /// <summary>
        /// 删除出纳登账信息
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <returns>
        /// 1：成功；
        /// 0：参数错误；
        /// -1：删除失败；
        /// -2：单条删除时，要删除的登账信息已审批，不能删除；
        /// -3：多条删除时，删除没有审批的，已经审批的没有删除；
        /// </returns>
        public int DeleteDengZhang(params string[] dengZhangId)
        {
            if (dengZhangId == null || dengZhangId.Length <= 0) return 0;

            var strSql = new StringBuilder();

            strSql.Append(" declare @returnIndex int; ");
            strSql.Append(" declare @Zcout int; ");
            strSql.Append(" declare @YCZCount int; ");
            strSql.Append(" set @returnIndex = -1; ");
            strSql.AppendFormat(" set @Zcout = {0}; ", dengZhangId.Length);
            strSql.AppendFormat(
                " select @YCZCount = count(*) from [tbl_FinRegister] where [DengZhangId] in ({0}) and Status = {1}; ",
                GetIdsByArr(dengZhangId),
                (int)Model.EnumType.FinStructure.KuanXiangStatus.未审批);
            strSql.Append(" if @YCZCount > 0 ");
            strSql.Append(" begin ");
            strSql.AppendFormat(
                " delete from [tbl_FinRegister] where [DengZhangId] in ({0}) and Status = {1}; ",
                GetIdsByArr(dengZhangId),
                (int)Model.EnumType.FinStructure.KuanXiangStatus.未审批);
            strSql.Append(" set @returnIndex = 1; ");
            strSql.Append(" end ");
            strSql.Append(" if isnull(@YCZCount,0) <= 0 ");
            strSql.Append(" begin ");
            strSql.Append(" if @Zcout = 1 set @returnIndex = -2; ");
            strSql.Append(" if @Zcout > 1 set @returnIndex = -3; ");
            strSql.Append(" end ");
            strSql.Append(" select @returnIndex; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            object obj = Toolkit.DAL.DbHelper.GetSingleBySqlTrans(dc, _db);

            if (obj == null) return -1;

            if (Toolkit.Utils.GetInt(obj.ToString()) <= 0) return Toolkit.Utils.GetInt(obj.ToString());

            return 1;
        }

        /// <summary>
        /// 审批出纳登账信息
        /// </summary>
        /// <param name="model">审批信息实体</param>
        /// <param name="dengZhangId">登账编号</param>
        /// <returns>返回1成功；其他失败</returns>
        public int ShenPiDengZhang(MShenPiDengZhang model, params string[] dengZhangId)
        {
            if (model == null || model.OperatorId <= 0 || dengZhangId == null || dengZhangId.Length <= 0) return 0;

            var strSql = new StringBuilder();
            var strSql2 = new StringBuilder();
            DbCommand dc = _db.GetSqlStringCommand("select 1");

            strSql.Append(
                " update [tbl_FinRegister] set ApproverId = @ApproverId,ApproveTime = @ApproveTime,ApproveRemark = @ApproveRemark,[Status] = @Status,[BankDate] = @BankDate where ");
            strSql2.Append(
                    " INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId],[CollectionItem],[CollectionRefundDate],[CollectionRefundOperator],[CollectionRefundOperatorID],[CollectionRefundAmount],[CollectionRefundMode],[CollectionRefundMemo],[BankId],[BankDate],[Status],[ApproverId],[ApproveTime],[ApproveRemark],[PayId],[PayTime],[PayRemark],[OperatorId],[IssueTime],[IsXiaoZhang],[XiaoZhangId],[ZxsId]) ");
            strSql2.Append(
                    " select @DengJiId,a.[CompanyId],a.[DengZhangId],@CollectionItem,a.[DaoKuanTime],(SELECT cu.ContactName FROM tbl_CompanyUser cu WHERE cu.Id = a.[OperatorId]),a.[OperatorId],a.[DaoKuanJinE],a.[PayType],a.[Remark],a.[BankId],@BankDate,@Status2,@ApproverId,@ApproveTime,@ApproveRemark,NULL,NULL,NULL,@ApproverId,@IssueTime,'0',NULL,a.ZxsId ");
            strSql2.Append(" from [tbl_FinRegister] as a where ");
            if (dengZhangId.Length == 1)
            {
                strSql.Append(" DengZhangId = @DengZhangId and [Status] = @Status3 ; ");
                strSql2.Append(" a.DengZhangId = @DengZhangId and a.[Status] = @Status3 ; ");
                _db.AddInParameter(dc, "DengZhangId", DbType.AnsiStringFixedLength, dengZhangId[0]);
                _db.AddInParameter(dc, "DengJiId", DbType.AnsiStringFixedLength, Guid.NewGuid().ToString());

            }
            else
            {
                strSql.AppendFormat(" DengZhangId in ({0}) and [Status] = @Status3 ; ", GetIdsByArr(dengZhangId));
                strSql2.AppendFormat(" a.DengZhangId  in ({0}) and a.[Status] = @Status3 ; ", GetIdsByArr(dengZhangId));

                strSql2.Replace("@DengJiId", "NEWID()");
            }

            strSql2.Append(strSql.ToString());

            _db.AddInParameter(dc, "ApproverId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "ApproveTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(dc, "ApproveRemark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "Status", DbType.Byte, (int)Model.EnumType.FinStructure.KuanXiangStatus.未支付);
            _db.AddInParameter(dc, "Status3", DbType.Byte, (int)Model.EnumType.FinStructure.KuanXiangStatus.未审批);
            _db.AddInParameter(dc, "BankDate", DbType.DateTime, model.BankDate);
            //收支登记表参数
            _db.AddInParameter(dc, "CollectionItem", DbType.Byte, (int)Model.EnumType.FinStructure.KuanXiangType.出纳登账收款);
            _db.AddInParameter(dc, "Status2", DbType.Byte, (int)Model.EnumType.FinStructure.KuanXiangStatus.未支付);
            _db.AddInParameter(dc, "IssueTime", DbType.DateTime, DateTime.Now);

            dc.CommandText = strSql2.ToString();

            return Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, _db) > 0 ? 1 : -1;
        }

        /// <summary>
        /// 获取登账信息列表
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="search">查询实体</param>
        /// <param name="zongJinE">返回总到款金额</param>
        /// <param name="zongXiaoZhangJinE">返回总销账金额</param>
        /// <returns></returns>
        public IList<MChuNaDengZhang> GetChuNaDengZhang(int companyId, int pageSize, int pageIndex, ref int recordCount
            , MSearchChuNaDengZhang search, ref decimal zongJinE, ref decimal zongXiaoZhangJinE)
        {
            if (companyId <= 0) return null;

            pageSize = pageSize <= 0 ? 10 : pageSize;
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;

            zongJinE = 0;
            zongXiaoZhangJinE = 0;
            /*string tableName = "tbl_FinRegister";
            var strFiles = new StringBuilder();
            var strWhere = new StringBuilder();
            string strOrderBy = " DaoKuanTime desc,IssueTime desc ";
            string strSum = " Sum(DaoKuanJinE) as ZJE,Sum(UnCheckMoney) as ZXZJE ";
            strFiles.Append(" [DengZhangId],[CompanyId],[DaoKuanTime],[DaoKuanJinE],[BankId],[PayType],[Remark],[OperatorId],[IssueTime],[ApproverId],[ApproveTime],[ApproveRemark],[Status] ");
            strFiles.Append(" ,(select BankName + '-' + AccountName + '-' + BankNo from tbl_CompanyAccount as ca where ca.Id = [BankId]) as BankName ");
            strFiles.Append(
                " ,(SELECT cu.ContactName FROM tbl_CompanyUser cu WHERE cu.Id = OperatorId) as OperatorName ");
            strFiles.Append(
                " ,(SELECT cu.ContactName FROM tbl_CompanyUser cu WHERE cu.Id = ApproverId) as ApproverName ");
            strFiles.Append(
                " ,(SELECT SUM(UnCheckMoney) FROM tbl_FinRegisterUnCheck AS fuc WHERE fuc.DZId = [DengZhangId]) as UnCheckMoney ");
            strWhere.AppendFormat(" CompanyId = {0} ", companyId);*/


            StringBuilder stable = new StringBuilder();
            stable.Append(" SELECT ");
            stable.Append(" [DengZhangId],[CompanyId],[DaoKuanTime],[DaoKuanJinE],[BankId],[PayType],[Remark],[OperatorId],[IssueTime],[ApproverId],[ApproveTime],[ApproveRemark],[Status] ");
            stable.Append(" ,(select BankName + '-' + AccountName + '-' + BankNo from tbl_CompanyAccount as ca where ca.Id = [BankId]) as BankName ");
            stable.Append(" ,(SELECT cu.ContactName FROM tbl_CompanyUser cu WHERE cu.Id = OperatorId) as OperatorName ");
            stable.Append( " ,(SELECT cu.ContactName FROM tbl_CompanyUser cu WHERE cu.Id = ApproverId) as ApproverName ");
            stable.Append( " ,(SELECT ISNULL(SUM(UnCheckMoney),0) FROM tbl_FinRegisterUnCheck AS fuc WHERE fuc.DZId = [DengZhangId]) as UnCheckMoney ");
            stable.Append(" ,ZxsId ");
            stable.Append(" FROM tbl_FinRegister ");
            stable.AppendFormat(" WHERE CompanyId = {0} ", companyId);
            string fields = "*";
            string strSum = " Sum(DaoKuanJinE) as ZJE,Sum(UnCheckMoney) as ZXZJE ";
            string strOrderBy = " DaoKuanTime desc,IssueTime desc ";
            StringBuilder strWhere = new StringBuilder();

            strWhere.Append(" 1=1 ");

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.BankId) && search.BankId != "0")
                {
                    strWhere.AppendFormat(" and [BankId] = '{0}' ", search.BankId);
                }
                if (search.Status.HasValue)
                {
                    strWhere.AppendFormat(" and [Status] = {0} ", (int)search.Status.Value);
                }
                if (search.StartTime.HasValue)
                {
                    strWhere.AppendFormat(" and datediff(dd,'{0}',DaoKuanTime) >= 0 ", search.StartTime.Value.ToShortDateString());
                }
                if (search.EndTime.HasValue)
                {
                    strWhere.AppendFormat(" and datediff(dd,'{0}',DaoKuanTime) <= 0 ", search.EndTime.Value.ToShortDateString());
                }
                if (search.DaoZhangJinEOperator != QueryOperator.None && search.DaoZhangJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)search.DaoZhangJinEOperator);
                    strWhere.AppendFormat(" AND DaoKuanJinE {0} {1} ", _operator, search.DaoZhangJinE.Value);
                }

                if (search.WeiXiaoZhangJinEOperator != QueryOperator.None && search.WeiXiaoZhangJinE.HasValue)
                {
                    string _operator = GetQueryOperator((int)search.WeiXiaoZhangJinEOperator);
                    strWhere.AppendFormat(" AND DaoKuanJinE-UnCheckMoney {0} {1} ", _operator, search.WeiXiaoZhangJinE.Value);
                }
                if (!string.IsNullOrEmpty(search.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", search.ZxsId);
                }

                if (search.XiaoZhangShiJian1.HasValue || search.XiaoZhangShiJian2.HasValue || (search.XiaoZhangJinE.HasValue && search.XiaoZhangJinEOperator != QueryOperator.None)||(!string.IsNullOrEmpty(search.DuiFangDanWeiLeiXing)&&!string.IsNullOrEmpty(search.DuiFangDanWeiId)))
                {
                    strWhere.AppendFormat(" AND EXISTS(SELECT 1 FROM view_Fin_YiXiaoZhang AS A1 WHERE A1.DZId=t129.DengZhangId ");

                    if (search.XiaoZhangShiJian1.HasValue)
                    {
                        strWhere.AppendFormat(" AND A1.IssueTime>='{0}' ", search.XiaoZhangShiJian1.Value);
                    }
                    if (search.XiaoZhangShiJian2.HasValue)
                    {
                        strWhere.AppendFormat(" AND A1.IssueTime<'{0}' ", search.XiaoZhangShiJian2.Value.AddDays(1));
                    }

                    if (search.XiaoZhangJinEOperator != QueryOperator.None && search.XiaoZhangJinE.HasValue)
                    {
                        string _operator = GetQueryOperator((int)search.XiaoZhangJinEOperator);
                        strWhere.AppendFormat(" AND A1.UnCheckMoney {0} {1} ", _operator, search.XiaoZhangJinE.Value);
                    }

                    if (!string.IsNullOrEmpty(search.DuiFangDanWeiId) && !string.IsNullOrEmpty(search.DuiFangDanWeiLeiXing))
                    {
                        strWhere.AppendFormat(" AND BuyCompanyId='{0}' ", search.DuiFangDanWeiId);
                    }

                    strWhere.AppendFormat(" ) ");
                }
            }

            var list = new List<MChuNaDengZhang>();
            using (IDataReader dr = Toolkit.DAL.DbHelper.ExecuteReader2(_db, pageSize, pageIndex, ref recordCount, stable.ToString(), fields, strWhere.ToString(), strOrderBy, strSum))
            {
                while (dr.Read())
                {
                    list.Add(
                        new MChuNaDengZhang
                            {
                                CompanyId =
                                    dr.IsDBNull(dr.GetOrdinal("CompanyId"))
                                        ? 0
                                        : dr.GetInt32(dr.GetOrdinal("CompanyId")),
                                DaoKuanBankId =
                                    dr.IsDBNull(dr.GetOrdinal("BankId"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("BankId")),
                                DaoKuanBankName =
                                    dr.IsDBNull(dr.GetOrdinal("BankName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("BankName")),
                                DaoKuanJinE =
                                    dr.IsDBNull(dr.GetOrdinal("DaoKuanJinE"))
                                        ? 0
                                        : dr.GetDecimal(dr.GetOrdinal("DaoKuanJinE")),
                                DaoKuanTime = dr.GetDateTime(dr.GetOrdinal("DaoKuanTime")),
                                DengZhangId =
                                    dr.IsDBNull(dr.GetOrdinal("DengZhangId"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("DengZhangId")),
                                FuKuanFangShi =
                                    (Model.EnumType.FinStructure.ShouFuKuanFangShi)dr.GetByte(dr.GetOrdinal("PayType")),
                                OperatorId =
                                    dr.IsDBNull(dr.GetOrdinal("OperatorId"))
                                        ? 0
                                        : dr.GetInt32(dr.GetOrdinal("OperatorId")),
                                OperatorName =
                                    dr.IsDBNull(dr.GetOrdinal("OperatorName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("OperatorName")),
                                Remark =
                                    dr.IsDBNull(dr.GetOrdinal("Remark"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("Remark")),
                                Status =
                                    (Model.EnumType.FinStructure.KuanXiangStatus)dr.GetByte(dr.GetOrdinal("Status")),
                                UnCheckMoney =
                                    dr.IsDBNull(dr.GetOrdinal("UnCheckMoney"))
                                        ? 0
                                        : dr.GetDecimal(dr.GetOrdinal("UnCheckMoney"))
                            });
                }

                dr.NextResult();
                if (dr.Read())
                {
                    zongJinE = dr.IsDBNull(dr.GetOrdinal("ZJE")) ? 0 : dr.GetDecimal(dr.GetOrdinal("ZJE"));
                    zongXiaoZhangJinE = dr.IsDBNull(dr.GetOrdinal("ZXZJE")) ? 0 : dr.GetDecimal(dr.GetOrdinal("ZXZJE"));
                }
            }

            return list;
        }

        /// <summary>
        /// 获取登账信息实体
        /// </summary>
        /// <param name="dengZhangId">登账编号</param>
        /// <returns></returns>
        public MChuNaDengZhang GetChuNaDengZhang(string dengZhangId)
        {
            if (string.IsNullOrEmpty(dengZhangId)) return null;

            var strSql = new StringBuilder();
            strSql.Append(" select  ");
            strSql.Append(" [DengZhangId],[CompanyId],[DaoKuanTime],[DaoKuanJinE],[BankId],[PayType],[Remark],[OperatorId],[IssueTime],[BankDate],[ApproverId],[ApproveTime],[ApproveRemark],[Status],ZxsId ");
            strSql.Append(" ,(select BankName + '-' + AccountName + '-' + BankNo from tbl_CompanyAccount as ca where ca.Id = [BankId]) as BankName ");
            strSql.Append(
                " ,(SELECT cu.ContactName FROM tbl_CompanyUser cu WHERE cu.Id = OperatorId) as OperatorName ");
            strSql.Append(
                " ,(SELECT cu.ContactName FROM tbl_CompanyUser cu WHERE cu.Id = ApproverId) as ApproverName ");
            strSql.Append(
                " ,(SELECT SUM(UnCheckMoney) FROM tbl_FinRegisterUnCheck AS fuc WHERE fuc.DZId = [DengZhangId]) as UnCheckMoney ");
            strSql.Append(" from tbl_FinRegister ");
            strSql.Append(" where [DengZhangId] = @DengZhangId ");
            strSql.Append(" order by DaoKuanTime desc,IssueTime desc ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "DengZhangId", DbType.AnsiStringFixedLength, dengZhangId);

            MChuNaDengZhang model = null;
            using (IDataReader dr = Toolkit.DAL.DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new MChuNaDengZhang
                        {
                            CompanyId =
                                dr.IsDBNull(dr.GetOrdinal("CompanyId")) ? 0 : dr.GetInt32(dr.GetOrdinal("CompanyId")),
                            DaoKuanBankId =
                                dr.IsDBNull(dr.GetOrdinal("BankId"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("BankId")),
                            DaoKuanBankName =
                                dr.IsDBNull(dr.GetOrdinal("BankName"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("BankName")),
                            DaoKuanJinE =
                                dr.IsDBNull(dr.GetOrdinal("DaoKuanJinE"))
                                    ? 0
                                    : dr.GetDecimal(dr.GetOrdinal("DaoKuanJinE")),
                            DaoKuanTime = dr.GetDateTime(dr.GetOrdinal("DaoKuanTime")),
                            DengZhangId =
                                dr.IsDBNull(dr.GetOrdinal("DengZhangId"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("DengZhangId")),
                            FuKuanFangShi =
                                (Model.EnumType.FinStructure.ShouFuKuanFangShi)dr.GetByte(dr.GetOrdinal("PayType")),
                            OperatorId =
                                dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId")),
                            OperatorName =
                                dr.IsDBNull(dr.GetOrdinal("OperatorName"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("OperatorName")),
                            Remark =
                                dr.IsDBNull(dr.GetOrdinal("Remark"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("Remark")),
                            Status = (Model.EnumType.FinStructure.KuanXiangStatus)dr.GetByte(dr.GetOrdinal("Status")),
                            UnCheckMoney =
                                dr.IsDBNull(dr.GetOrdinal("UnCheckMoney"))
                                    ? 0
                                    : dr.GetDecimal(dr.GetOrdinal("UnCheckMoney"))
                        };
                    model.ZxsId = dr["ZxsId"].ToString();

                    if (!dr.IsDBNull(dr.GetOrdinal("Status")) && dr.GetByte(dr.GetOrdinal("Status")) > (int)Model.EnumType.FinStructure.KuanXiangStatus.未审批)
                    {
                        model.ShenPi = new MShenPiDengZhang
                            {
                                BankDate =
                                    dr.IsDBNull(dr.GetOrdinal("BankDate"))
                                        ? DateTime.MinValue
                                        : dr.GetDateTime(dr.GetOrdinal("BankDate")),
                                IssueTime =
                                    dr.IsDBNull(dr.GetOrdinal("ApproveTime"))
                                        ? DateTime.MinValue
                                        : dr.GetDateTime(dr.GetOrdinal("ApproveTime")),
                                OperatorId =
                                    dr.IsDBNull(dr.GetOrdinal("ApproverId"))
                                        ? 0
                                        : dr.GetInt32(dr.GetOrdinal("ApproverId")),
                                OperatorName =
                                    dr.IsDBNull(dr.GetOrdinal("ApproverName"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("ApproverName")),
                                Remark =
                                    dr.IsDBNull(dr.GetOrdinal("ApproveRemark"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("ApproveRemark"))
                            };
                    }
                }
            }

            return model;
        }

        /*/// <summary>
        /// 登账信息销账处理
        /// </summary>
        /// <param name="dengZhangId">登账信息编号</param>
        /// <param name="list">销账实体集合</param>
        /// <returns>
        /// 0：参数验证没通过；
        /// 1：销账成功；
        /// -1：要销账的所有的金额合计大于出纳登帐信息的到款金额
        /// -2：登账信息没有审批，不能销账
        /// -3：销账失败
        /// </returns>
        public int UnCheckDengZhang(string dengZhangId, IList<MXiaoZhang> list)
        {
            if (string.IsNullOrEmpty(dengZhangId) || list == null || !list.Any()) return 0;

            var t = from c in list where c.XiaoZhangJinE > 0 && (!string.IsNullOrEmpty(c.OrderId)) select c;
            if (!t.Any()) return 0;

            var m = t.Sum(c => (c.XiaoZhangJinE));
            if (m <= 0) return 0;

            var strSql = new StringBuilder();
            strSql.Append(" declare @returnIndex int; ");
            strSql.Append(" declare @ZongMoney money; ");
            strSql.Append(" declare @YiXiaoZhangMoney money; ");
            strSql.Append(" declare @Status tinyint; ");
            strSql.Append(" set @returnIndex = -3; ");
            strSql.Append(" set @ZongMoney = 0; ");
            strSql.Append(" set @YiXiaoZhangMoney = 0; ");
            strSql.Append(" set @Status = 0; ");
            strSql.Append(" select @ZongMoney = DaoKuanJinE,@Status = [Status] from tbl_FinRegister where DengZhangId = @DengZhangId; ");
            strSql.Append(" SELECT @YiXiaoZhangMoney = ISNULL(SUM(UnCheckMoney),0) FROM tbl_FinRegisterUnCheck WHERE DZId = @DengZhangId;  ");
            strSql.AppendFormat(
                " if @ZongMoney is not null and (@ZongMoney - @YiXiaoZhangMoney) >= {0} and @Status > {1} ", m, (int)Model.EnumType.FinStructure.KuanXiangStatus.未审批);
            strSql.Append(" begin ");
            foreach (var tmp in list)
            {
                if (tmp == null || string.IsNullOrEmpty(tmp.OrderId) || tmp.XiaoZhangJinE <= 0) continue;

                if (string.IsNullOrEmpty(tmp.XiaoZhangId)) tmp.XiaoZhangId = Guid.NewGuid().ToString();

                tmp.IssueTime = DateTime.Now;

                //写销账信息表 tbl_FinRegisterUnCheck
                strSql.AppendFormat(
                    " insert into tbl_FinRegisterUnCheck (UnCheckId,DZId,OrderId,UnCheckMoney,OperatorId,LeiXing1) values ('{0}',@DengZhangId,'{1}',{2},{3},{4}); ",
                    tmp.XiaoZhangId,
                    tmp.OrderId,
                    tmp.XiaoZhangJinE.ToString("F2"),
                    tmp.OperatorId
                    , (int)tmp.LeiXing1);

                //写订单收入登记明细表 tbl_FinCope
                strSql.Append(
                    " INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId],[CollectionItem],[CollectionRefundDate],[CollectionRefundOperator],[CollectionRefundOperatorID],[CollectionRefundAmount],[CollectionRefundMode],[CollectionRefundMemo],[BankId],[BankDate],[Status],[ApproverId],[ApproveTime],[ApproveRemark],[PayId],[PayTime],[PayRemark],[OperatorId],[IssueTime],[IsXiaoZhang],[XiaoZhangId],[ZxsId]) ");
                strSql.AppendFormat(
                    " select '{0}',a.[CompanyId],'{1}',{2},'{3}','{4}',{5},{6},a.[PayType],'出纳销账订单收款',a.[BankId],a.[BankDate],{7},{8},'{9}','出纳销账订单收款自动审批',NULL,NULL,NULL,{8},'{9}','1','{10}',a.ZxsId ",
                    Guid.NewGuid().ToString(),
                    tmp.OrderId,
                    (int)Model.EnumType.FinStructure.KuanXiangType.订单收款,
                    tmp.IssueTime.ToShortDateString(),
                    tmp.OperatorName,
                    tmp.OperatorId,
                    tmp.XiaoZhangJinE,
                    (int)Model.EnumType.FinStructure.KuanXiangStatus.未支付,
                    tmp.OperatorId,
                    tmp.IssueTime,
                    tmp.XiaoZhangId);
                strSql.Append(" from [tbl_FinRegister] as a where a.DengZhangId = @DengZhangId; ");
                //设置订单的收款金额
                strSql.AppendFormat(" EXEC proc_Fin_SetOrderJinE @OrderId = '{0}' ", tmp.OrderId);
            }
            strSql.Append(" set @returnIndex = 1; ");
            strSql.Append(" end ");
            strSql.AppendFormat(" if (@ZongMoney - @YiXiaoZhangMoney) < {0} set @returnIndex = -1; ", m);
            strSql.AppendFormat(" if @Status <= {0} set @returnIndex = -2; ", (int)Model.EnumType.FinStructure.KuanXiangStatus.未审批);
            strSql.Append(" select @returnIndex; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "DengZhangId", DbType.AnsiStringFixedLength, dengZhangId);

            object obj = Toolkit.DAL.DbHelper.GetSingleBySqlTrans(dc, _db);

            if (obj == null) return -3;

            if (Toolkit.Utils.GetInt(obj.ToString()) <= 0) return Toolkit.Utils.GetInt(obj.ToString());

            return 1;
        }*/

        /// <summary>
        /// 获取已销账信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息[0:decimal:已销账金额]</param>
        /// <returns></returns>
        public IList<MYiXiaoZhangInfo> GetYiXiaoZhangs(int companyId, int pageSize, int pageIndex, ref int recordCount, MYiXiaoZhangChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M };
            IList<MYiXiaoZhangInfo> items = new List<MYiXiaoZhangInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_YiXiaoZhang";
            string orderByString = " [IssueTime] DESC ";
            string sumString = "SUM(UnCheckMoney) AS XiaoZhangJinEHeJi";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.AppendFormat(" CompanyId={0} ", companyId);
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.DengZhangId))
                {
                    query.AppendFormat(" AND DZId='{0}' ", chaXun.DengZhangId);
                }
            }
            #endregion

            using (IDataReader rdr = Toolkit.DAL.DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MYiXiaoZhangInfo();

                    item.DengZhangId = rdr.GetString(rdr.GetOrdinal("DZId"));
                    item.KeHuName = rdr["KeHuName"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.OrderCode = rdr["OrderCode"].ToString();
                    item.RouteName = rdr["RouteName"].ToString();
                    item.ShouKuanId = rdr.GetString(rdr.GetOrdinal("ShouKuanId"));
                    item.XiaoZhangId = rdr.GetString(rdr.GetOrdinal("UnCheckId"));
                    item.XiaoZhangJinE = rdr.GetDecimal(rdr.GetOrdinal("UnCheckMoney"));
                    item.YingShouJinE = rdr.GetDecimal(rdr.GetOrdinal("YingShouJinE"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.LeiXing = (XiaoZhangLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.OperatorName = rdr["OperatorName"].ToString();

                    if (item.LeiXing == XiaoZhangLeiXing.销账)
                    {
                        item.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)rdr.GetByte(rdr.GetOrdinal("YeWuLeiXing"));
                        item.LeiXing1 = (XiaoZhangLeiXing1)rdr.GetByte(rdr.GetOrdinal("LeiXing1"));
                    }

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) heJi[0] = rdr.GetDecimal(0);
                }
            }

            return items;
        }

        /// <summary>
        /// 取消审批，返回1成功，其它失败
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoShenPi(string dengZhangId, int companyId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_QuXiaoShenPi);
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批);
            _db.AddInParameter(cmd, "DengZhangId", DbType.AnsiStringFixedLength, dengZhangId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "KuanXiangType", DbType.Byte, Model.EnumType.FinStructure.KuanXiangType.出纳登账收款);

            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 冲抵，返回1成功，其它失败
        /// </summary>
        /// <param name="info">冲抵信息</param>
        /// <returns></returns>
        public int ChongDi(MChongDiInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_DengZhang_ChongDi");
            _db.AddInParameter(cmd, "ChongDiId", DbType.AnsiStringFixedLength, info.ChongDiId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "DengZhangId", DbType.AnsiStringFixedLength, info.DengZhangId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, XiaoZhangLeiXing.冲抵);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "DanWeiId", DbType.String, info.DanWeiId);
            _db.AddInParameter(cmd, "DanWeiType", DbType.Byte, info.DanWeiType);
            _db.AddInParameter(cmd, "XiangMuId", DbType.Int32, info.XiangMuId);
            _db.AddInParameter(cmd, "QiTaShouRuId", DbType.AnsiStringFixedLength, Guid.NewGuid().ToString());
            _db.AddInParameter(cmd, "QiTaShouZhiType", DbType.Byte, QiTaShouZhiType.收入);
            _db.AddInParameter(cmd, "ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);


            int sqlExceptionCode = 0;

            try
            {
                EyouSoft.Toolkit.DAL.DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /*/// <summary>
        /// 取消销账，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="xiaoZhangId">销账编号集合</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoXiaoZhang(int companyId, string dengZhangId, string[] xiaoZhangId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_QuXiaoXiaoZhang");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "DengZhangId", DbType.AnsiStringFixedLength, dengZhangId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "IdXml", DbType.String, CreateIdXml(xiaoZhangId));
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, XiaoZhangLeiXing.销账);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                EyouSoft.Toolkit.DAL.DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 取消冲抵，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="xiaoZhangId">冲抵编号集合</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        public int QuXiaoChongDi(int companyId, string dengZhangId, string[] xiaoZhangId, MOperatorInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_QuXiaoXiaoZhang");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "DengZhangId", DbType.AnsiStringFixedLength, dengZhangId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "IdXml", DbType.String, CreateIdXml(xiaoZhangId));
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, XiaoZhangLeiXing.冲抵);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                EyouSoft.Toolkit.DAL.DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }*/

        /// <summary>
        /// 取消销账、冲抵，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="xiaoZhangId">销账编号、冲抵编号集合</param>        
        /// <param name="info">相关信息</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        public int QuXiaoXiaoZhang(int companyId, string dengZhangId, string[] xiaoZhangId, MOperatorInfo info, XiaoZhangLeiXing leiXing)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_Fin_DengZhang_QuXiaoXiaoZhang");
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "DengZhangId", DbType.AnsiStringFixedLength, dengZhangId);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.OperatorTime);
            _db.AddInParameter(cmd, "IdXml", DbType.String, CreateIdXml(xiaoZhangId));
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, leiXing);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                EyouSoft.Toolkit.DAL.DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取出纳登账销账订单款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.FinStructure.MXiaoZhangDingDanKuanInfo> GetXiaoZhangDingDanKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.FinStructure.MXiaoZhangDingDanKuanInfo> list = new List<EyouSoft.Model.FinStructure.MXiaoZhangDingDanKuanInfo>();

            string filed = "KongWeiCode,RouteName,QuDate,OrderId,OrderCode,BuyCompanyName,SumPrice,CheckMoney,ReturnMoney,ReceivedMoney,RefundMoney,BusinessType";
            string tableName = "view_TourOrder";
            string OrderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" CompanyId={0} and OrderStatus={1} ", companyId, (int)Model.EnumType.TourStructure.OrderStatus.已成交);

            //未登记金额=合同金额+已登记退款金额-已登记收款金额
            query.AppendFormat(" and  (SumPrice+ReturnMoney-ReceivedMoney)<>0 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.DingDanKuan_KeHuId))
                {
                    query.AppendFormat(" and BuyCompanyId = '{0}' ", chaXun.DingDanKuan_KeHuId);
                }
                if (!string.IsNullOrEmpty(chaXun.DingDanKuan_KeHuName))
                {
                    query.AppendFormat(" and BuyCompanyName like '%{0}%' ", chaXun.DingDanKuan_KeHuName);
                }
                if (chaXun.QuDate1.HasValue)
                {
                    query.AppendFormat(" AND QuDate>'{0}' ", chaXun.QuDate1.Value.AddDays(-1));
                }
                if (chaXun.QuDate2.HasValue)
                {
                    query.AppendFormat(" AND QuDate<'{0}' ", chaXun.QuDate2.Value.AddDays(1));
                }
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, filed, query.ToString(), OrderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.FinStructure.MXiaoZhangDingDanKuanInfo model = new EyouSoft.Model.FinStructure.MXiaoZhangDingDanKuanInfo();

                    model.KongWeiCode = dr["KongWeiCode"].ToString();
                    model.RouteName = dr["RouteName"].ToString();
                    model.QuDate = dr.GetDateTime(dr.GetOrdinal("QuDate"));
                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.OrderCode = dr["OrderCode"].ToString();
                    model.BuyCompanyName = dr["BuyCompanyName"].ToString();
                    model.SumPrice = dr.GetDecimal(dr.GetOrdinal("SumPrice"));
                    model.YiShenPiJinE = dr.GetDecimal(dr.GetOrdinal("CheckMoney"));
                    model.TuiYiShenPiJinE = dr.GetDecimal(dr.GetOrdinal("ReturnMoney"));
                    model.WeiShenPiJinE = dr.GetDecimal(dr.GetOrdinal("ReceivedMoney")) - model.YiShenPiJinE;
                    model.TuiWeiShenPiJinE = dr.GetDecimal(dr.GetOrdinal("RefundMoney")) - model.TuiYiShenPiJinE;
                    model.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType)dr.GetByte(dr.GetOrdinal("BusinessType"));

                    list.Add(model);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取出纳登账销账退票款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MXiaoZhangTuiPiaoKuanInfo> GetXiaoZhangTuiPiaoKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun)
        {
            IList<MXiaoZhangTuiPiaoKuanInfo> items = new List<MXiaoZhangTuiPiaoKuanInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_TuiPiao";
            string orderByString = " TuiTime DESC ";
            string sumString = "";

            #region sql where
            query.AppendFormat(" CompanyId={0} AND TuiAmount-WeiShenPiJinE-YiShenPiJinE>0 ", companyId);
            if (chaXun != null)
            {
                if (chaXun.QuDate1.HasValue)
                {
                    query.AppendFormat(" AND QuDate>='{0}' ", chaXun.QuDate1.Value);
                }
                if (chaXun.QuDate2.HasValue)
                {
                    query.AppendFormat(" AND QuDate<='{0}' ", chaXun.QuDate2.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.TuiPiaoKuan_DaiLiShangName))
                {
                    query.AppendFormat(" AND GysName LIKE '%{0}%' ", chaXun.TuiPiaoKuan_DaiLiShangName);
                }
                if (!string.IsNullOrEmpty(chaXun.TuiPiaoKuan_DingDanHao))
                {
                    query.AppendFormat(" AND OrderCode LIKE '%{0}%' ", chaXun.TuiPiaoKuan_DingDanHao);
                }
                if (!string.IsNullOrEmpty(chaXun.TuiPiaoKuan_GysJiaoYiHao))
                {
                    query.AppendFormat(" AND GysOrderCode LIKE '%{0}%' ", chaXun.TuiPiaoKuan_GysJiaoYiHao);
                }
                if (!string.IsNullOrEmpty(chaXun.TuiPiaoKuan_JiaoYiHao))
                {
                    query.AppendFormat(" AND JiaoYiHao LIKE '%{0}%' ", chaXun.TuiPiaoKuan_JiaoYiHao);
                }                
                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MXiaoZhangTuiPiaoKuanInfo();
                    item.ChengDanFang = rdr["ChengDanFang"].ToString();
                    item.DaiLiShangName = rdr["GysName"].ToString();
                    item.DingDanHao = rdr["OrderCode"].ToString();
                    item.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    item.JingShouRenName = rdr["OperatorName"].ToString();
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.SunShiMingXi = rdr["SunShiMX"].ToString();
                    item.TuiPiaoId = rdr.GetString(rdr.GetOrdinal("TuiId"));
                    item.TuiPiaoRenShu = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    item.TuiPiaoShiJian = rdr.GetDateTime(rdr.GetOrdinal("TuiTime"));
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.YingTuiJinE = rdr.GetDecimal(rdr.GetOrdinal("TuiAmount"));
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.GysJiaoYiHao = rdr["GysOrderCode"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {
                   
                }
            }

            return items;
        }

        /// <summary>
        /// 获取出纳登账销账退回押金信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MXiaoZhangTuiHuiYaJinInfo> GetXiaoZhangTuiHuiYaJins(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun)
        {
            IList<MXiaoZhangTuiHuiYaJinInfo> items = new List<MXiaoZhangTuiHuiYaJinInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_YaJin";
            string orderByString = " IdentityId DESC ";
            string sumString = "";

            #region sql where
            query.AppendFormat(" CompanyId={0} AND TuiYaJinAmount-TuiWeiShenPiJinE-TuiYiShenPiJinE>0 ", companyId);
            if (chaXun != null)
            {
                if (chaXun.QuDate1.HasValue)
                {
                    query.AppendFormat(" AND QuDate>='{0}' ", chaXun.QuDate1.Value);
                }
                if (chaXun.QuDate2.HasValue)
                {
                    query.AppendFormat(" AND QuDate<='{0}' ", chaXun.QuDate2.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.TuiYaJin_DaiLiShangName))
                {
                    query.AppendFormat(" AND GysName LIKE '%{0}%' ", chaXun.TuiYaJin_DaiLiShangName);
                }
                if (!string.IsNullOrEmpty(chaXun.TuiYaJin_GysJiaoYiHao))
                {
                    query.AppendFormat(" AND GysOrderCode LIKE '%{0}%' ", chaXun.TuiYaJin_GysJiaoYiHao);
                }

                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MXiaoZhangTuiHuiYaJinInfo();
                    item.DaiLiId = rdr["DaiLiId"].ToString();
                    item.DaiLiShangName = rdr["GysName"].ToString();
                    item.GysJiaoYiHao = rdr["GysOrderCode"].ToString();
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    item.TuiWeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("TuiWeiShenPiJinE"));
                    item.YaJinJinE = rdr.GetDecimal(rdr.GetOrdinal("YaJinAmount"));
                    item.YingTuiJinE = rdr.GetDecimal(rdr.GetOrdinal("TuiYaJinAmount"));
                    item.TuiYiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("TuiYiShenPiJinE"));

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {

                }
            }

            return items;
        }

        /// <summary>
        /// 获取出纳登账销账团队结算其它收入信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MXiaoZhangJieSuanQiTaShouRuInfo> GetXiaoZhangJieSuanQiTaShouRus(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun)
        {
            IList<MXiaoZhangJieSuanQiTaShouRuInfo> items = new List<MXiaoZhangJieSuanQiTaShouRuInfo>();

            string fields = "*";
            StringBuilder query = new StringBuilder();
            string tableName = "view_Fin_QiTaShouRu";
            string orderByString = " CreateTime DESC ";
            string sumString = "";

            #region sql where
            query.AppendFormat(" CompanyId={0} AND Proceed-YiShenPiJinE-WeiShenPiJinE>0 ", companyId);
            query.AppendFormat(" AND CostType={0} ", (int)QiTaShouZhiType.收入);
            query.AppendFormat(" AND TourId IS NOT NULL AND LEN(TourId)>0 ");
            if (chaXun != null)
            {
                if (chaXun.QuDate1.HasValue)
                {
                    query.AppendFormat(" AND QuDate>='{0}' ", chaXun.QuDate1.Value);
                }
                if (chaXun.QuDate2.HasValue)
                {
                    query.AppendFormat(" AND QuDate<='{0}' ", chaXun.QuDate2.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.JieSuanQiTaShouRu_DuiFangDanWeiName))
                {
                    query.AppendFormat(" AND KeHuName LIKE '%{0}%' ", chaXun.JieSuanQiTaShouRu_DuiFangDanWeiName);
                }

                if (!string.IsNullOrEmpty(chaXun.ZxsId))
                {
                    query.AppendFormat(" AND ZxsId='{0}' ", chaXun.ZxsId);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MXiaoZhangJieSuanQiTaShouRuInfo();
                    item.DuiFangDanWeiName = rdr["KeHuName"].ToString();
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("Proceed"));
                    item.KongWeiCode = rdr["KongWeiCode"].ToString();
                    item.QiTaShouRuId = rdr["Id"].ToString();
                    item.QuDate = rdr.GetDateTime(rdr.GetOrdinal("QuDate"));
                    item.ShouRuShiJian = rdr.GetDateTime(rdr.GetOrdinal("Date"));
                    item.ShouRuXiangMu = rdr["ProceedItem"].ToString();
                    item.WeiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("WeiShenPiJinE"));
                    item.YiShenPiJinE = rdr.GetDecimal(rdr.GetOrdinal("YiShenPiJinE"));
                    item.ShouRuBeiZhu = rdr["Remark"].ToString();

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {

                }
            }

            return items;
        }

        /// <summary>
        /// 出纳登账-销账(订单款、退票款、退回押金、团队结算其它收入)，返回1成功，其它失败
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="operatorId">操作人编号</param>
        /// <param name="leiXing1">销账类型1</param>
        /// <param name="items">销售相关信息集合</param>
        /// <returns></returns>
        public int XiaoZhang(string dengZhangId, int operatorId,EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing1 leiXing1, IList<MXiaoZhang> items)
        {
            #region xml
            StringBuilder s = new StringBuilder();
            s.AppendFormat("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info XiaoZhangId=\"{0}\" GuanLianId=\"{1}\" XiaoZhangJinE=\"{2}\"  />", item.XiaoZhangId, item.OrderId, item.XiaoZhangJinE);
            }
            s.AppendFormat("</root>");
            #endregion

            EyouSoft.Model.EnumType.FinStructure.KuanXiangType kuanXiangType = KuanXiangType.订单收款;

            switch (leiXing1)
            {
                case XiaoZhangLeiXing1.销订单款: kuanXiangType = KuanXiangType.订单收款; break;
                case XiaoZhangLeiXing1.销结算其它收入: kuanXiangType = KuanXiangType.其它收入收款; break;
                case XiaoZhangLeiXing1.销退回押金: kuanXiangType = KuanXiangType.票务押金退还; break;
                case XiaoZhangLeiXing1.销退票款: kuanXiangType = KuanXiangType.票务退款; break;
                default: kuanXiangType = KuanXiangType.订单收款; break;
            }

            var cmd = _db.GetStoredProcCommand("proc_Fin_DengZhang_XiaoZhang");
            _db.AddInParameter(cmd, "@DengZhangId", DbType.AnsiStringFixedLength, dengZhangId);
            _db.AddInParameter(cmd, "@LeiXing1", DbType.Byte, leiXing1);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, operatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(cmd, "@Xml", DbType.String, s.ToString());
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddInParameter(cmd, "@LeiXing", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing.销账);
            _db.AddInParameter(cmd, "@KuanXiangStatus", DbType.Byte, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未支付);
            _db.AddInParameter(cmd, "@KuanXiangType", DbType.Byte, kuanXiangType);


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
        #endregion
    }
}
