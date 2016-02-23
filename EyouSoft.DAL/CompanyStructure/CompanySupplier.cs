using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using EyouSoft.Model.CompanyStructure;
using System.Xml.Linq;

namespace EyouSoft.DAL.CompanyStructure
{
    /// <summary>
    /// 供应商信息数据层
    /// </summary>
    public class CompanySupplier : DALBase, IDAL.CompanyStructure.ICompanySupplier
    {
        private readonly Database _db;

        public CompanySupplier()
        {
            _db = this.SystemStore;
        }

        #region 接口成员

        /// <summary>
        /// 验证供应商是否已被使用，返回被使用的供应商编号集合
        /// </summary>
        /// <param name="ids">要验证的供应商编号集合</param>
        /// <returns></returns>
        public string[] ExistsYsy(params string[] ids)
        {
            if (ids == null || ids.Length <= 0) return null;

            var strSql = new StringBuilder();
            if (ids.Length == 1)
            {
                strSql.AppendFormat(" select distinct GysId from tbl_PlanDiJie where GysId = '{0}'; ", ids[0]);
                strSql.AppendFormat(" select distinct GysId from tbl_PlanChuPiao where GysId = '{0}'; ", ids[0]);
                strSql.AppendFormat(" select distinct GYSId from tbl_TourOrderHotelPlan where GYSId = '{0}'; ", ids[0]);
                strSql.AppendFormat(
                    " select distinct CustromCId from tbl_FinOther where CustromType = {0} and CustromCId = '{1}'; ",
                    (int)Model.EnumType.FinStructure.QiTaShouZhiKeHuType.供应商,
                    ids[0]);
            }
            else
            {
                strSql.AppendFormat(
                    " select distinct GysId from tbl_PlanDiJie where GysId in ({0}); ", GetIdsByArr(ids));
                strSql.AppendFormat(" select distinct GysId from tbl_PlanChuPiao where GysId in ({0}); ", GetIdsByArr(ids));
                strSql.AppendFormat(" select distinct GYSId from tbl_TourOrderHotelPlan where GysId in ({0}); ", GetIdsByArr(ids));
                strSql.AppendFormat(
                    " select distinct CustromCId from tbl_FinOther where CustromType = {0} and CustromCId in ({1}); ",
                    (int)Model.EnumType.FinStructure.QiTaShouZhiKeHuType.供应商,
                    GetIdsByArr(ids));
            }

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());


            var list = new List<string>();
            string t;
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                        list.Add(dr.GetString(0));
                }

                dr.NextResult();
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        t = dr.GetString(0);

                        if (list.Contains(t)) continue;

                        list.Add(t);
                    }
                }

                dr.NextResult();
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        t = dr.GetString(0);

                        if (list.Contains(t)) continue;

                        list.Add(t);
                    }
                }

                dr.NextResult();
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        t = dr.GetString(0);

                        if (list.Contains(t)) continue;

                        list.Add(t);
                    }
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// 添加供应商信息
        /// </summary>
        /// <param name="model">供应商信息基类</param>
        /// <returns>返回1成功，其他失败</returns>
        public int AddSupplier(SupplierBasic model)
        {
            if (model == null || string.IsNullOrEmpty(model.UnitName)) return 0;

            if (string.IsNullOrEmpty(model.Id)) model.Id = Guid.NewGuid().ToString();

            var strSql = new StringBuilder();
            DbCommand dc = _db.GetSqlStringCommand("select 1");

            #region sql处理

            strSql.Append(
                @" INSERT INTO [tbl_CompanySupplier] ([Id],[ProvinceId],[CityId],[UnitName],[SupplierType]
                        ,[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],[CompanyId],[OperatorId],[IssueTime],[IsDelete],ZxsId) 
                    VALUES (@Id,@ProvinceId,@CityId,@UnitName,@SupplierType,@LicenseKey,@AgreementFile
                        ,@UnitAddress,@UnitPolicy,@Remark,@CompanyId,@OperatorId,@IssueTime,@IsDelete,@ZxsId); ");

            #region 账号信息

            if (model.SupplierBank != null && model.SupplierBank.Any())
            {
                foreach (var t in model.SupplierBank)
                {
                    if (t == null) continue;

                    strSql.AppendFormat(
                        " INSERT INTO [tbl_SupplierBank] ([SupplierId],[AccountName],[Bank],[BankAccount]) VALUES (@Id,'{0}','{1}','{2}'); ",
                        t.AccountName,
                        t.BankName,
                        t.BankNo);
                }
            }

            #endregion

            #region 图片信息

            if (model.SupplierPic != null && model.SupplierPic.Any())
            {
                foreach (var t in model.SupplierPic)
                {
                    if (t == null) continue;

                    strSql.AppendFormat(
                        " INSERT INTO [tbl_SupplierAccessory] ([SupplierId],[PicName],[PicPath]) VALUES (@Id,'{0}','{1}'); ",
                        t.PicName,
                        t.PicPath);
                }
            }

            #endregion

            #region 联系人信息

            if (model.SupplierContact != null && model.SupplierContact.Any())
            {
                foreach (var t in model.SupplierContact)
                {
                    if (t == null) continue;

                    strSql.AppendFormat(
                        " INSERT INTO [tbl_SupplierContact] ([CompanyId],[SupplierId],[ContactName],[JobTitle],[ContactFax],[ContactTel],[ContactMobile],[QQ],[Email]) VALUES (@CompanyId,@Id,'{0}','{1}','{2}','{3}','{4}','{5}','{6}'); ",
                        t.ContactName,
                        t.JobTitle,
                        t.ContactFax,
                        t.ContactTel,
                        t.ContactMobile,
                        t.Qq,
                        t.Email);
                }
            }

            #endregion

            #region 附件信息
            if (model.Annexs != null && model.Annexs.Count > 0)
            {
                foreach (var item in model.Annexs)
                {
                    if (item == null) continue;
                    if (string.IsNullOrEmpty(item.FileId)) item.FileId = Guid.NewGuid().ToString();
                    strSql.AppendFormat("INSERT INTO [tbl_ComapnyFile]([FileId],[CompanyId],[FilePath],[IssueTime],[ItemType],[ItemId]) VALUES('{0}',@CompanyId,'{1}','{2}',@AnnexType,@Id);", item.FileId
                        , item.FilePath
                        , DateTime.Now);
                }
            }
            #endregion

            #region 根据类型写子表信息

            switch (model.SupplierType)
            {
                case Model.EnumType.CompanyStructure.SupplierType.地接:
                case Model.EnumType.CompanyStructure.SupplierType.票务:
                case Model.EnumType.CompanyStructure.SupplierType.其他:
                    break;
                case Model.EnumType.CompanyStructure.SupplierType.酒店:
                    var tmph = (SupplierHotel)model;
                    strSql.AppendFormat(
                        " INSERT INTO [tbl_SupplierHotel] ([SupplierId],[Star],[Introduce],[TourGuide]) VALUES (@Id,{0},'{1}','{2}'); ",
                        (int)tmph.Star,
                        tmph.Introduce,
                        tmph.TourGuide);
                    if (tmph.RoomTypes != null && tmph.RoomTypes.Any())
                    {
                        foreach (var t in tmph.RoomTypes)
                        {
                            if (t == null) continue;

                            strSql.AppendFormat(
                                " INSERT INTO [tbl_SupplierHotelRoomType] ([SupplierId],[Name],[SellingPrice],[AccountingPrice],[IsBreakfast]) VALUES (@Id,'{0}',{1},{2},'{3}'); ",
                                t.Name,
                                t.SellingPrice,
                                t.AccountingPrice,
                                t.IsBreakfast ? "1" : "0");
                        }
                    }
                    break;
                case Model.EnumType.CompanyStructure.SupplierType.景点:
                    var tmpj = (SupplierSpot)model;
                    strSql.AppendFormat(
                        " INSERT INTO [tbl_SupplierSpot] ([SupplierId],[Star],[TourGuide],[TeamPrice],[TravelerPrice]) VALUES (@Id,{0},'{1}',{2},{3}) ",
                        (int)tmpj.Start,
                        tmpj.TourGuide,
                        tmpj.TeamPrice,
                        tmpj.TravelerPrice);
                    break;
            }

            #endregion

            #endregion

            dc.CommandText = strSql.ToString();

            _db.AddInParameter(dc, "Id", DbType.AnsiStringFixedLength, model.Id);
            _db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
            _db.AddInParameter(dc, "CityId", DbType.Int32, model.CityId);
            _db.AddInParameter(dc, "UnitName", DbType.String, model.UnitName);
            _db.AddInParameter(dc, "SupplierType", DbType.Byte, (int)model.SupplierType);
            _db.AddInParameter(dc, "LicenseKey", DbType.String, model.LicenseKey);
            _db.AddInParameter(dc, "AgreementFile", DbType.String, model.AgreementFile);
            _db.AddInParameter(dc, "UnitAddress", DbType.String, model.UnitAddress);
            _db.AddInParameter(dc, "UnitPolicy", DbType.String, model.UnitPolicy);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(dc, "IsDelete", DbType.AnsiStringFixedLength, "0");
            _db.AddInParameter(dc, "AnnexType", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.AnnexType.资源信息);
            _db.AddInParameter(dc, "ZxsId", DbType.AnsiStringFixedLength, model.ZxsId);

            return DbHelper.ExecuteSqlTrans(dc, _db) > 0 ? 1 : 0;
        }

        /// <summary>
        /// 修改供应商信息
        /// </summary>
        /// <param name="model">供应商信息基类</param>
        /// <returns>返回1成功，其他失败</returns>
        public int UpdateSupplier(SupplierBasic model)
        {
            if (model == null || string.IsNullOrEmpty(model.Id)) return 0;

            var strSql = new StringBuilder();
            DbCommand dc = _db.GetSqlStringCommand("select 1");

            #region sql处理

            strSql.Append(
                " UPDATE [tbl_CompanySupplier] SET [ProvinceId] = @ProvinceId,[CityId] = @CityId,[UnitName] = @UnitName,[LicenseKey] = @LicenseKey,[AgreementFile] = @AgreementFile,[UnitAddress] = @UnitAddress,[UnitPolicy] = @UnitPolicy,[Remark] = @Remark,[OperatorId] = @OperatorId WHERE [Id] = @Id ");

            #region 账号信息

            if (model.SupplierBank != null)
            {
                strSql.Append(" delete from [tbl_SupplierBank] where [SupplierId] = @Id; ");

                if (model.SupplierBank.Any())
                {
                    foreach (var t in model.SupplierBank)
                    {
                        if (t == null) continue;

                        strSql.AppendFormat(
                            " INSERT INTO [tbl_SupplierBank] ([SupplierId],[AccountName],[Bank],[BankAccount]) VALUES (@Id,'{0}','{1}','{2}'); ",
                            t.AccountName,
                            t.BankName,
                            t.BankNo);
                    }
                }
            }

            #endregion

            #region 图片信息

            if (model.SupplierPic != null)
            {
                if (model.SupplierPic.Any())
                {
                    var r = from c in model.SupplierPic where c.Id > 0 select c.Id;
                    if (r.Any())
                    {
                        strSql.AppendFormat(" insert into tbl_SysDeletedFileQue (FilePath) select [PicPath] from [tbl_SupplierAccessory] where [SupplierId] = @Id  and [Id] not in ({0}); ", this.GetIdsByArr(r.ToArray()));
                        strSql.AppendFormat(
                            " delete from [tbl_SupplierAccessory] where [SupplierId] = @Id and [Id] not in ({0}); ",
                            this.GetIdsByArr(r.ToArray()));
                    }
                    else
                    {
                        strSql.Append("  insert into tbl_SysDeletedFileQue (FilePath) select [PicPath] from [tbl_SupplierAccessory] where [SupplierId] = @Id ; ");
                        strSql.AppendFormat(" delete from [tbl_SupplierAccessory] where [SupplierId] = @Id ; ");
                    }
                    foreach (var t in model.SupplierPic)
                    {
                        if (t == null) continue;

                        //存在则修改，不存在则删除，存在的情况下路径有变更，将旧的路径写入待删除文件表
                        strSql.AppendFormat(
                            " if exists (select 1 from [tbl_SupplierAccessory] where [SupplierId] = @Id and [Id] = {0}) ",
                            t.Id);
                        strSql.Append(" begin ");
                        strSql.AppendFormat(
                            "  if exists (select 1 from [tbl_SupplierAccessory] where [SupplierId] = @Id and [Id] = {0} and [PicPath] <> '{1}')  ",
                            t.Id,
                            t.PicPath);
                        strSql.Append(" begin ");
                        strSql.AppendFormat(
                            " insert into tbl_SysDeletedFileQue (FilePath) select [PicPath] from [tbl_SupplierAccessory] where [SupplierId] = @Id and [Id] = {0}; ",
                            t.Id);
                        strSql.Append(" end ");
                        strSql.AppendFormat(
                            " update [tbl_SupplierAccessory] set [PicName] = '{0}',[PicPath] = '{1}' where [SupplierId] = @Id and [Id] = {2}; ",
                            t.PicName,
                            t.PicPath,
                            t.Id);
                        strSql.Append(" end ");
                        strSql.Append(" else ");
                        strSql.Append(" begin ");
                        strSql.AppendFormat(
                            " INSERT INTO [tbl_SupplierAccessory] ([SupplierId],[PicName],[PicPath]) VALUES (@Id,'{0}','{1}'); ",
                            t.PicName,
                            t.PicPath);
                        strSql.Append(" end ");
                    }
                }
                else
                {
                    strSql.Append(" insert into tbl_SysDeletedFileQue (FilePath) select [PicPath] from [tbl_SupplierAccessory] where [SupplierId] = @Id;");
                    strSql.Append(" delete from [tbl_SupplierAccessory] where [SupplierId] = @Id; ");
                }
            }

            #endregion

            #region 联系人信息

            if (model.SupplierContact != null)
            {
                string ids = string.Empty;
                foreach (var item in model.SupplierContact)
                {
                    if (item.Id > 0) ids += item.Id + ",";
                }
                if (!string.IsNullOrEmpty(ids)) ids = ids.Trim(',');
                if (!string.IsNullOrEmpty(ids))
                {
                    strSql.AppendFormat(" DELETE FROM [tbl_SupplierContact] WHERE [SupplierId] = @Id AND Id NOT IN({0}) AND NOT EXISTS(SELECT 1 FROM tbl_TourOrderHotelPlan WHERE SideOperatorId=tbl_SupplierContact.Id) AND YongHuId=0; ", ids);
                }

                if (model.SupplierContact.Any())
                {
                    foreach (var t in model.SupplierContact)
                    {
                        if (t == null) continue;

                        if (t.Id == 0)
                        {
                            strSql.AppendFormat(
                                " INSERT INTO [tbl_SupplierContact] ([CompanyId],[SupplierId],[ContactName],[JobTitle],[ContactFax],[ContactTel],[ContactMobile],[QQ],[Email]) VALUES (@CompanyId,@Id,'{0}','{1}','{2}','{3}','{4}','{5}','{6}'); ",
                                t.ContactName,
                                t.JobTitle,
                                t.ContactFax,
                                t.ContactTel,
                                t.ContactMobile,
                                t.Qq,
                                t.Email);
                        }
                        else
                        {
                            strSql.AppendFormat(
                                " UPDATE [tbl_SupplierContact] SET [ContactName] = '{0}',[JobTitle] = '{1}',[ContactFax] = '{2}',[ContactTel] = '{3}',[ContactMobile] = '{4}',[QQ] = '{5}',[Email] = '{6}' WHERE Id={7}; ",
                                t.ContactName,
                                t.JobTitle,
                                t.ContactFax,
                                t.ContactTel,
                                t.ContactMobile,
                                t.Qq,
                                t.Email,
                                t.Id);
                        }
                    }
                }

            }

            #endregion

            #region 附件信息
            strSql.AppendFormat("DELETE FROM [tbl_ComapnyFile] WHERE CompanyId=@CompanyId AND [ItemId]=@Id AND [ItemType]=@AnnexType;");
            if (model.Annexs != null && model.Annexs.Count > 0)
            {
                foreach (var item in model.Annexs)
                {
                    if (item == null) continue;
                    if (string.IsNullOrEmpty(item.FileId)) item.FileId = Guid.NewGuid().ToString();
                    strSql.AppendFormat("INSERT INTO [tbl_ComapnyFile]([FileId],[CompanyId],[FilePath],[IssueTime],[ItemType],[ItemId]) VALUES('{0}',@CompanyId,'{1}','{2}',@AnnexType,@Id);", item.FileId
                        , item.FilePath
                        , DateTime.Now);
                }
            }
            #endregion

            #region 根据类型写子表信息

            switch (model.SupplierType)
            {
                case Model.EnumType.CompanyStructure.SupplierType.地接:
                case Model.EnumType.CompanyStructure.SupplierType.票务:
                case Model.EnumType.CompanyStructure.SupplierType.其他:
                    break;
                case Model.EnumType.CompanyStructure.SupplierType.酒店:
                    var tmph = (SupplierHotel)model;
                    strSql.AppendFormat(
                        " update [tbl_SupplierHotel] set [Star] = {0},[Introduce] = '{1}',[TourGuide] = '{2}' where [SupplierId] = @Id; ",
                        (int)tmph.Star,
                        tmph.Introduce,
                        tmph.TourGuide);
                    if (tmph.RoomTypes != null)
                    {
                        strSql.Append(" delete from [tbl_SupplierHotelRoomType] where [SupplierId] = @Id; ");

                        if (tmph.RoomTypes.Any())
                        {
                            foreach (var t in tmph.RoomTypes)
                            {
                                if (t == null) continue;

                                strSql.AppendFormat(
                                    " INSERT INTO [tbl_SupplierHotelRoomType] ([SupplierId],[Name],[SellingPrice],[AccountingPrice],[IsBreakfast]) VALUES (@Id,'{0}',{1},{2},'{3}'); ",
                                    t.Name,
                                    t.SellingPrice,
                                    t.AccountingPrice,
                                    t.IsBreakfast ? "1" : "0");
                            }
                        }
                    }
                    break;
                case Model.EnumType.CompanyStructure.SupplierType.景点:
                    var tmpj = (SupplierSpot)model;
                    strSql.AppendFormat(
                        " update [tbl_SupplierSpot] set [Star] = {0},[TourGuide] = '{1}',[TeamPrice] = {2},[TravelerPrice] = {3} where [SupplierId] = @Id; ",
                        (int)tmpj.Start,
                        tmpj.TourGuide,
                        tmpj.TeamPrice,
                        tmpj.TravelerPrice);
                    break;
            }

            #endregion

            #endregion

            dc.CommandText = strSql.ToString();

            _db.AddInParameter(dc, "Id", DbType.AnsiStringFixedLength, model.Id);
            _db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
            _db.AddInParameter(dc, "CityId", DbType.Int32, model.CityId);
            _db.AddInParameter(dc, "UnitName", DbType.String, model.UnitName);
            _db.AddInParameter(dc, "LicenseKey", DbType.String, model.LicenseKey);
            _db.AddInParameter(dc, "AgreementFile", DbType.String, model.AgreementFile);
            _db.AddInParameter(dc, "UnitAddress", DbType.String, model.UnitAddress);
            _db.AddInParameter(dc, "UnitPolicy", DbType.String, model.UnitPolicy);
            _db.AddInParameter(dc, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(dc, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(dc, "CompanyId", DbType.Int32, model.CompanyId);
            _db.AddInParameter(dc, "AnnexType", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.AnnexType.资源信息);

            return DbHelper.ExecuteSqlTrans(dc, _db) > 0 ? 1 : -1;
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="ids">供应商编号集合</param>
        /// <returns>返回1成功，其他失败</returns>
        public int DeleteSupplier(params string[] ids)
        {
            if (ids == null || ids.Length <= 0) return 0;

            var strSql = new StringBuilder();

            strSql.Append(" update tbl_CompanySupplier set IsDelete = '1' where  ");

            if (ids.Length == 1)
            {
                strSql.AppendFormat(" Id = '{0}' ", ids[0]);
            }
            else
            {
                strSql.AppendFormat(" Id in ({0}) ", GetIdsByArr(ids));
            }

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            return DbHelper.ExecuteSqlTrans(dc, _db) > 0 ? 1 : 0;
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="id">供应商编号</param>
        /// <returns></returns>
        public SupplierBasic GetSupplier(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            SupplierLocal tmpl = null;
            SupplierTicket tmpt = null;
            SupplierOther tmpo = null;
            SupplierHotel tmph = null;
            SupplierSpot tmps = null;
            var supplierType = Model.EnumType.CompanyStructure.SupplierType.地接;

            var strSql = new StringBuilder();

            strSql.Append(
                " SELECT a.[Id],a.[ProvinceId],a.[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],a.[CompanyId],a.[OperatorId],a.[IssueTime],a.[IsDelete],b.ProvinceName,c.CityName,a.ZxsId ");
            strSql.Append(
                " FROM [tbl_CompanySupplier] AS a LEFT JOIN tbl_CompanyProvince AS b ON a.ProvinceId = b.Id LEFT JOIN tbl_CompanyCity AS c ON a.CityId = c.Id ");
            strSql.Append(" where a.[Id] = @Id; ");
            strSql.Append(" SELECT [Id],[SupplierId],[PicName],[PicPath] FROM [tbl_SupplierAccessory] where [SupplierId] = @Id; ");
            strSql.Append(" SELECT A.*,(SELECT A1.Username FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.YongHuId) AS YongHuMing FROM [tbl_SupplierContact] AS A where A.[SupplierId] = @Id; ");
            strSql.Append(
                " SELECT [SupplierId],[AccountName],[Bank],[BankAccount] FROM [tbl_SupplierBank] where [SupplierId] = @Id; ");
            strSql.Append("SELECT [FilePath] FROM [tbl_ComapnyFile] WHERE ItemId=@Id AND [ItemType]=@AnnexType ORDER BY [IdentityId] ASC;");
            

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.AnsiStringFixedLength, id);
            _db.AddInParameter(dc, "AnnexType", DbType.Byte, (int)EyouSoft.Model.EnumType.CompanyStructure.AnnexType.资源信息);

            var model = new SupplierBasic();

            #region 基本信息

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                #region 基本信息

                if (dr.Read())
                {
                    supplierType =
                        (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));

                    switch (supplierType)
                    {
                        case Model.EnumType.CompanyStructure.SupplierType.地接:
                            tmpl = new SupplierLocal();

                            #region 基本信息

                            if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                                tmpl.Id = dr.GetString(dr.GetOrdinal("Id"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                                tmpl.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                                tmpl.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                                tmpl.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                                tmpl.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                                tmpl.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                                tmpl.SupplierType =
                                    (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                            if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                                tmpl.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                            if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                                tmpl.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                                tmpl.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                                tmpl.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                            if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                                tmpl.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                                tmpl.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                                tmpl.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                                tmpl.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                                tmpl.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                            tmpl.ZxsId = dr["ZxsId"].ToString();
                            #endregion

                            break;
                        case Model.EnumType.CompanyStructure.SupplierType.票务:
                            tmpt = new SupplierTicket();

                            #region 基本信息

                            if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                                tmpt.Id = dr.GetString(dr.GetOrdinal("Id"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                                tmpt.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                                tmpt.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                                tmpt.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                                tmpt.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                                tmpt.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                                tmpt.SupplierType =
                                    (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                            if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                                tmpt.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                            if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                                tmpt.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                                tmpt.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                                tmpt.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                            if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                                tmpt.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                                tmpt.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                                tmpt.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                                tmpt.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                                tmpt.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                            tmpt.ZxsId = dr["ZxsId"].ToString();
                            #endregion

                            break;
                        case Model.EnumType.CompanyStructure.SupplierType.其他:
                            tmpo = new SupplierOther();

                            #region 基本信息

                            if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                                tmpo.Id = dr.GetString(dr.GetOrdinal("Id"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                                tmpo.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                                tmpo.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                                tmpo.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                                tmpo.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                                tmpo.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                                tmpo.SupplierType =
                                    (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                            if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                                tmpo.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                            if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                                tmpo.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                                tmpo.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                                tmpo.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                            if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                                tmpo.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                                tmpo.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                                tmpo.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                                tmpo.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                                tmpo.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                            tmpo.ZxsId = dr["ZxsId"].ToString();

                            #endregion

                            break;
                        case Model.EnumType.CompanyStructure.SupplierType.酒店:
                            tmph = new SupplierHotel();

                            #region 基本信息

                            if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                                tmph.Id = dr.GetString(dr.GetOrdinal("Id"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                                tmph.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                                tmph.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                                tmph.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                                tmph.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                                tmph.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                                tmph.SupplierType =
                                    (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                            if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                                tmph.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                            if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                                tmph.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                                tmph.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                                tmph.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                            if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                                tmph.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                                tmph.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                                tmph.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                                tmph.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                                tmph.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                            tmph.ZxsId = dr["ZxsId"].ToString();

                            #endregion

                            break;

                        case Model.EnumType.CompanyStructure.SupplierType.景点:
                            tmps = new SupplierSpot();

                            #region 基本信息

                            if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                                tmps.Id = dr.GetString(dr.GetOrdinal("Id"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                                tmps.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                                tmps.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                                tmps.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                                tmps.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                                tmps.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                            if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                                tmps.SupplierType =
                                    (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                            if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                                tmps.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                            if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                                tmps.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                                tmps.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                            if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                                tmps.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                            if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                                tmps.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                            if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                                tmps.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                                tmps.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                                tmps.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                            if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                                tmps.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                            tmps.ZxsId = dr["ZxsId"].ToString();

                            #endregion

                            break;

                    }
                }

                #endregion

                #region 附件信息

                switch (supplierType)
                {
                    case Model.EnumType.CompanyStructure.SupplierType.地接:
                        if (tmpl == null) break;

                        #region 附件信息

                        tmpl.SupplierPic = new List<SupplierPic>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpl.SupplierPic.Add(
                                new SupplierPic
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    PicName =
                                        dr.IsDBNull(dr.GetOrdinal("PicName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicName")),
                                    PicPath =
                                        dr.IsDBNull(dr.GetOrdinal("PicPath"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicPath")),
                                    SupplierId = tmpl.Id
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.票务:
                        if (tmpt == null) break;

                        #region 附件信息

                        tmpt.SupplierPic = new List<SupplierPic>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpt.SupplierPic.Add(
                                new SupplierPic
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    PicName =
                                        dr.IsDBNull(dr.GetOrdinal("PicName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicName")),
                                    PicPath =
                                        dr.IsDBNull(dr.GetOrdinal("PicPath"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicPath")),
                                    SupplierId = tmpt.Id
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.其他:
                        if (tmpo == null) break;

                        #region 附件信息

                        tmpo.SupplierPic = new List<SupplierPic>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpo.SupplierPic.Add(
                                new SupplierPic
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    PicName =
                                        dr.IsDBNull(dr.GetOrdinal("PicName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicName")),
                                    PicPath =
                                        dr.IsDBNull(dr.GetOrdinal("PicPath"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicPath")),
                                    SupplierId = tmpo.Id
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.酒店:
                        if (tmph == null) break;

                        #region 附件信息

                        tmph.SupplierPic = new List<SupplierPic>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmph.SupplierPic.Add(
                                new SupplierPic
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    PicName =
                                        dr.IsDBNull(dr.GetOrdinal("PicName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicName")),
                                    PicPath =
                                        dr.IsDBNull(dr.GetOrdinal("PicPath"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicPath")),
                                    SupplierId = tmph.Id
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.景点:
                        if (tmps == null) break;

                        #region 附件信息

                        tmps.SupplierPic = new List<SupplierPic>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmps.SupplierPic.Add(
                                new SupplierPic
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    PicName =
                                        dr.IsDBNull(dr.GetOrdinal("PicName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicName")),
                                    PicPath =
                                        dr.IsDBNull(dr.GetOrdinal("PicPath"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("PicPath")),
                                    SupplierId = tmps.Id
                                });
                        }

                        #endregion

                        break;
                }



                #endregion

                #region 联系人信息

                switch (supplierType)
                {
                    case Model.EnumType.CompanyStructure.SupplierType.地接:
                        if (tmpl == null) break;

                        #region 联系人信息

                        tmpl.SupplierContact = new List<SupplierContact>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpl.SupplierContact.Add(
                                new SupplierContact
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    CompanyId = tmpl.CompanyId,
                                    SupplierId = tmpl.Id,
                                    ContactName = dr["ContactName"].ToString(),
                                    JobTitle = dr["JobTitle"].ToString(),
                                    ContactFax = dr["ContactFax"].ToString(),
                                    ContactTel = dr["ContactTel"].ToString(),
                                    ContactMobile = dr["ContactMobile"].ToString(),
                                    Qq = dr["QQ"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    YongHuId = dr.GetInt32(dr.GetOrdinal("YongHuId")),
                                    YongHuMing = dr["YongHuMing"].ToString()
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.票务:
                        if (tmpt == null) break;

                        #region 联系人信息

                        tmpt.SupplierContact = new List<SupplierContact>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpt.SupplierContact.Add(
                                new SupplierContact
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    CompanyId = tmpt.CompanyId,
                                    SupplierId = tmpt.Id,
                                    ContactName =
                                        dr.IsDBNull(dr.GetOrdinal("ContactName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactName")),
                                    JobTitle =
                                        dr.IsDBNull(dr.GetOrdinal("JobTitle"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("JobTitle")),
                                    ContactFax =
                                        dr.IsDBNull(dr.GetOrdinal("ContactFax"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactFax")),
                                    ContactTel =
                                        dr.IsDBNull(dr.GetOrdinal("ContactTel"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactTel")),
                                    ContactMobile =
                                        dr.IsDBNull(dr.GetOrdinal("ContactMobile"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactMobile")),
                                    Qq = dr.IsDBNull(dr.GetOrdinal("QQ")) ? string.Empty : dr.GetString(dr.GetOrdinal("QQ")),
                                    Email =
                                        dr.IsDBNull(dr.GetOrdinal("Email"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Email"))
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.其他:
                        if (tmpo == null) break;

                        #region 联系人信息

                        tmpo.SupplierContact = new List<SupplierContact>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpo.SupplierContact.Add(
                                new SupplierContact
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    CompanyId = tmpo.CompanyId,
                                    SupplierId = tmpo.Id,
                                    ContactName =
                                        dr.IsDBNull(dr.GetOrdinal("ContactName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactName")),
                                    JobTitle =
                                        dr.IsDBNull(dr.GetOrdinal("JobTitle"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("JobTitle")),
                                    ContactFax =
                                        dr.IsDBNull(dr.GetOrdinal("ContactFax"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactFax")),
                                    ContactTel =
                                        dr.IsDBNull(dr.GetOrdinal("ContactTel"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactTel")),
                                    ContactMobile =
                                        dr.IsDBNull(dr.GetOrdinal("ContactMobile"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactMobile")),
                                    Qq = dr.IsDBNull(dr.GetOrdinal("QQ")) ? string.Empty : dr.GetString(dr.GetOrdinal("QQ")),
                                    Email =
                                        dr.IsDBNull(dr.GetOrdinal("Email"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Email"))
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.酒店:
                        if (tmph == null) break;

                        #region 联系人信息

                        tmph.SupplierContact = new List<SupplierContact>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmph.SupplierContact.Add(
                                new SupplierContact
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    CompanyId = tmph.CompanyId,
                                    SupplierId = tmph.Id,
                                    ContactName =
                                        dr.IsDBNull(dr.GetOrdinal("ContactName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactName")),
                                    JobTitle =
                                        dr.IsDBNull(dr.GetOrdinal("JobTitle"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("JobTitle")),
                                    ContactFax =
                                        dr.IsDBNull(dr.GetOrdinal("ContactFax"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactFax")),
                                    ContactTel =
                                        dr.IsDBNull(dr.GetOrdinal("ContactTel"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactTel")),
                                    ContactMobile =
                                        dr.IsDBNull(dr.GetOrdinal("ContactMobile"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactMobile")),
                                    Qq = dr.IsDBNull(dr.GetOrdinal("QQ")) ? string.Empty : dr.GetString(dr.GetOrdinal("QQ")),
                                    Email =
                                        dr.IsDBNull(dr.GetOrdinal("Email"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Email"))
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.景点:
                        if (tmps == null) break;

                        #region 联系人信息

                        tmps.SupplierContact = new List<SupplierContact>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmps.SupplierContact.Add(
                                new SupplierContact
                                {
                                    Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id")),
                                    CompanyId = tmps.CompanyId,
                                    SupplierId = tmps.Id,
                                    ContactName =
                                        dr.IsDBNull(dr.GetOrdinal("ContactName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactName")),
                                    JobTitle =
                                        dr.IsDBNull(dr.GetOrdinal("JobTitle"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("JobTitle")),
                                    ContactFax =
                                        dr.IsDBNull(dr.GetOrdinal("ContactFax"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactFax")),
                                    ContactTel =
                                        dr.IsDBNull(dr.GetOrdinal("ContactTel"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactTel")),
                                    ContactMobile =
                                        dr.IsDBNull(dr.GetOrdinal("ContactMobile"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("ContactMobile")),
                                    Qq = dr.IsDBNull(dr.GetOrdinal("QQ")) ? string.Empty : dr.GetString(dr.GetOrdinal("QQ")),
                                    Email =
                                        dr.IsDBNull(dr.GetOrdinal("Email"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Email"))
                                });
                        }

                        #endregion

                        break;
                }



                #endregion

                #region 银行账号信息

                switch (supplierType)
                {
                    case Model.EnumType.CompanyStructure.SupplierType.地接:
                        if (tmpl == null) break;

                        #region 银行账号信息

                        tmpl.SupplierBank = new List<SupplierBank>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpl.SupplierBank.Add(
                                new SupplierBank
                                {
                                    SupplierId = tmpl.Id,
                                    AccountName =
                                        dr.IsDBNull(dr.GetOrdinal("AccountName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("AccountName")),
                                    BankName =
                                        dr.IsDBNull(dr.GetOrdinal("Bank"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Bank")),
                                    BankNo =
                                        dr.IsDBNull(dr.GetOrdinal("BankAccount"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("BankAccount"))
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.票务:
                        if (tmpt == null) break;

                        #region 银行账号信息

                        tmpt.SupplierBank = new List<SupplierBank>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpt.SupplierBank.Add(
                                new SupplierBank
                                {
                                    SupplierId = tmpt.Id,
                                    AccountName =
                                        dr.IsDBNull(dr.GetOrdinal("AccountName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("AccountName")),
                                    BankName =
                                        dr.IsDBNull(dr.GetOrdinal("Bank"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Bank")),
                                    BankNo =
                                        dr.IsDBNull(dr.GetOrdinal("BankAccount"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("BankAccount"))
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.其他:
                        if (tmpo == null) break;

                        #region 银行账号信息

                        tmpo.SupplierBank = new List<SupplierBank>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmpo.SupplierBank.Add(
                                new SupplierBank
                                {
                                    SupplierId = tmpo.Id,
                                    AccountName =
                                        dr.IsDBNull(dr.GetOrdinal("AccountName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("AccountName")),
                                    BankName =
                                        dr.IsDBNull(dr.GetOrdinal("Bank"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Bank")),
                                    BankNo =
                                        dr.IsDBNull(dr.GetOrdinal("BankAccount"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("BankAccount"))
                                });
                        }

                        #endregion

                        break;

                    case Model.EnumType.CompanyStructure.SupplierType.酒店:
                        if (tmph == null) break;

                        #region 银行账号信息

                        tmph.SupplierBank = new List<SupplierBank>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmph.SupplierBank.Add(
                                new SupplierBank
                                {
                                    SupplierId = tmph.Id,
                                    AccountName =
                                        dr.IsDBNull(dr.GetOrdinal("AccountName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("AccountName")),
                                    BankName =
                                        dr.IsDBNull(dr.GetOrdinal("Bank"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Bank")),
                                    BankNo =
                                        dr.IsDBNull(dr.GetOrdinal("BankAccount"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("BankAccount"))
                                });
                        }

                        #endregion

                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.景点:
                        if (tmps == null) break;

                        #region 银行账号信息

                        tmps.SupplierBank = new List<SupplierBank>();
                        dr.NextResult();
                        while (dr.Read())
                        {
                            tmps.SupplierBank.Add(
                                new SupplierBank
                                {
                                    SupplierId = tmps.Id,
                                    AccountName =
                                        dr.IsDBNull(dr.GetOrdinal("AccountName"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("AccountName")),
                                    BankName =
                                        dr.IsDBNull(dr.GetOrdinal("Bank"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("Bank")),
                                    BankNo =
                                        dr.IsDBNull(dr.GetOrdinal("BankAccount"))
                                            ? string.Empty
                                            : dr.GetString(dr.GetOrdinal("BankAccount"))
                                });
                        }

                        #endregion

                        break;

                }

                #endregion

                #region 附件信息
                var annexs = new List<EyouSoft.Model.CompanyStructure.CompanyFile>();
                dr.NextResult();
                while (dr.Read())
                {
                    annexs.Add(new CompanyFile() { FilePath = dr["FilePath"].ToString() });
                }

                switch (supplierType)
                {
                    case Model.EnumType.CompanyStructure.SupplierType.地接:
                        if (tmpl == null) break;
                        tmpl.Annexs = annexs;
                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.票务:
                        if (tmpt == null) break;
                        tmpt.Annexs = annexs;
                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.其他:
                        if (tmpo == null) break;
                        tmpo.Annexs = annexs;
                        break;

                    case Model.EnumType.CompanyStructure.SupplierType.酒店:
                        if (tmph == null) break;
                        tmph.Annexs = annexs;
                        break;
                    case Model.EnumType.CompanyStructure.SupplierType.景点:
                        if (tmps == null) break;
                        tmps.Annexs = annexs;
                        break;
                }
                

                #endregion

                if (supplierType == Model.EnumType.CompanyStructure.SupplierType.酒店 && tmph != null)
                {
                    GetHotelInfo(tmph.Id, ref tmph);
                }
                if (supplierType == Model.EnumType.CompanyStructure.SupplierType.景点 && tmps != null)
                {
                    GetSpotInfo(tmps.Id, ref tmps);
                }

                switch (supplierType)
                {
                    case Model.EnumType.CompanyStructure.SupplierType.地接: model = tmpl; break;
                    case Model.EnumType.CompanyStructure.SupplierType.票务: model = tmpt; break;
                    case Model.EnumType.CompanyStructure.SupplierType.其他: model = tmpo; break;
                    case Model.EnumType.CompanyStructure.SupplierType.酒店: model = tmph; break;
                    case Model.EnumType.CompanyStructure.SupplierType.景点: model = tmps; break;
                }

                return model;
            }

            #endregion

        }

        /// <summary>
        /// 获取地接信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">地接社查询实体</param>
        /// <returns></returns>
        public IList<SupplierLocal> GetSupplierLocal(int companyId, int pageSize, int pageIndex, ref int recordCount
            , QuerySupplierLocal model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            #region sql处理

            var tableName = new StringBuilder();
            tableName.Append(
                "SELECT a.[Id],a.[ProvinceId],a.[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],a.[CompanyId],a.[OperatorId],a.[IssueTime],[IsDelete],b.ProvinceName,c.CityName");
            tableName.Append(
                " ,(select Id,ContactName,ContactFax,ContactTel,ContactMobile from tbl_SupplierContact where tbl_SupplierContact.SupplierId = a.Id FOR XML RAW,ROOT('Root')) AS ContactInfo ");
            tableName.AppendFormat(" ,a.ZxsId ");
            tableName.Append(
                " FROM [tbl_CompanySupplier] AS a LEFT JOIN tbl_CompanyProvince AS b ON a.ProvinceId = b.Id LEFT JOIN tbl_CompanyCity AS c on a.CityId = c.Id");
            string fileds = "[Id],[ProvinceId],[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],[CompanyId],[OperatorId],[IssueTime],[IsDelete],ProvinceName,CityName,ContactInfo,ZxsId ";
            string orderByStr = " IssueTime desc ";
            var strWhere = new StringBuilder(" [IsDelete] = '0' ");
            strWhere.AppendFormat(" and [CompanyId] = {0} ", companyId);
            strWhere.AppendFormat(" and [SupplierType] = {0} ", (int)Model.EnumType.CompanyStructure.SupplierType.地接);

            if (model != null)
            {
                if (model.ProvinceId != null && model.ProvinceId.Any())
                {
                    if (model.ProvinceId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [ProvinceId] = {0} ", model.ProvinceId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [ProvinceId] in ({0}) ", GetIdsByArr(model.ProvinceId));
                    }
                }
                if (model.CityId != null && model.CityId.Any())
                {
                    if (model.CityId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [CityId] = {0} ", model.CityId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [CityId] in ({0}) ", GetIdsByArr(model.CityId));
                    }
                }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    strWhere.AppendFormat(" and UnitName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.Name));
                }
                if (!string.IsNullOrEmpty(model.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", model.ZxsId);
                }

                switch (model.OrderByIndex)
                {
                    case 0:
                        orderByStr = " IssueTime asc ";
                        break;
                    case 1:
                        orderByStr = " IssueTime desc ";
                        break;
                    default:
                        orderByStr = " IssueTime desc ";
                        break;
                }
            }

            #endregion

            var list = new List<SupplierLocal>();

            #region 取值

            using (IDataReader dr = DbHelper.ExecuteReader2(_db, pageSize, pageIndex, ref recordCount, tableName.ToString(), fileds
                , strWhere.ToString(), orderByStr, string.Empty))
            {
                while (dr.Read())
                {
                    var t = new SupplierLocal();

                    if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                        t.Id = dr.GetString(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                        t.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                        t.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                        t.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                        t.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                        t.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                        t.SupplierType =
                            (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                        t.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                    if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                        t.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                        t.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                        t.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        t.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                        t.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                        t.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        t.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                        t.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactInfo")))
                        t.SupplierContact = this.GetSupplierContact(dr.GetString(dr.GetOrdinal("ContactInfo")));

                    list.Add(t);
                }
            }

            #endregion

            return list;
        }

        /// <summary>
        /// 获取票务信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">票务查询实体</param>
        /// <returns></returns>
        public IList<SupplierTicket> GetSupplierTicket(int companyId, int pageSize, int pageIndex, ref int recordCount
            , QuerySupplierTicket model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            #region sql处理

            var tableName = new StringBuilder();
            tableName.Append(
                "SELECT a.[Id],a.[ProvinceId],a.[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],a.[CompanyId],a.[OperatorId],a.[IssueTime],[IsDelete],b.ProvinceName,c.CityName");
            tableName.Append(
                " ,(select Id,ContactName,ContactFax,ContactTel,ContactMobile from tbl_SupplierContact where tbl_SupplierContact.SupplierId = a.Id FOR XML RAW,ROOT('Root')) AS ContactInfo ");
            tableName.AppendFormat(" ,a.ZxsId ");
            tableName.Append(
                " FROM [tbl_CompanySupplier] AS a LEFT JOIN tbl_CompanyProvince AS b ON a.ProvinceId = b.Id LEFT JOIN tbl_CompanyCity AS c on a.CityId = c.Id");
            string fileds = "[Id],[ProvinceId],[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],[CompanyId],[OperatorId],[IssueTime],[IsDelete],ProvinceName,CityName,ContactInfo,ZxsId ";
            string orderByStr = " IssueTime desc ";
            var strWhere = new StringBuilder(" [IsDelete] = '0' ");
            strWhere.AppendFormat(" and [CompanyId] = {0} ", companyId);
            strWhere.AppendFormat(" and [SupplierType] = {0} ", (int)Model.EnumType.CompanyStructure.SupplierType.票务);

            if (model != null)
            {
                if (model.ProvinceId != null && model.ProvinceId.Any())
                {
                    if (model.ProvinceId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [ProvinceId] = {0} ", model.ProvinceId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [ProvinceId] in ({0}) ", GetIdsByArr(model.ProvinceId));
                    }
                }
                if (model.CityId != null && model.CityId.Any())
                {
                    if (model.CityId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [CityId] = {0} ", model.CityId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [CityId] in ({0}) ", GetIdsByArr(model.CityId));
                    }
                }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    strWhere.AppendFormat(" and UnitName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.Name));
                }
                if (!string.IsNullOrEmpty(model.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", model.ZxsId);
                }

                switch (model.OrderByIndex)
                {
                    case 0:
                        orderByStr = " IssueTime asc ";
                        break;
                    case 1:
                        orderByStr = " IssueTime desc ";
                        break;
                    default:
                        orderByStr = " IssueTime desc ";
                        break;
                }
            }

            #endregion

            var list = new List<SupplierTicket>();

            #region 取值

            using (IDataReader dr = DbHelper.ExecuteReader2(_db, pageSize, pageIndex, ref recordCount, tableName.ToString(), fileds
                , strWhere.ToString(), orderByStr, string.Empty))
            {
                while (dr.Read())
                {
                    var t = new SupplierTicket();

                    if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                        t.Id = dr.GetString(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                        t.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                        t.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                        t.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                        t.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                        t.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                        t.SupplierType =
                            (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                        t.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                    if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                        t.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                        t.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                        t.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        t.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                        t.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                        t.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        t.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                        t.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactInfo")))
                        t.SupplierContact = this.GetSupplierContact(dr.GetString(dr.GetOrdinal("ContactInfo")));
                    t.ZxsId = dr["ZxsId"].ToString();

                    list.Add(t);
                }
            }

            #endregion

            return list;
        }

        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">酒店查询实体</param>
        /// <returns></returns>
        public IList<SupplierHotel> GetSupplierHotel(int companyId, int pageSize, int pageIndex, ref int recordCount
            , QuerySupplierHotel model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            #region sql处理

            var tableName = new StringBuilder();
            tableName.Append(
                "SELECT a.[Id],a.[ProvinceId],a.[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],a.[CompanyId],a.[OperatorId],a.[IssueTime],[IsDelete],b.ProvinceName,c.CityName");
            tableName.Append(" ,d.Star ");
            tableName.Append(
                " ,(select Id,ContactName,ContactFax,ContactTel,ContactMobile from tbl_SupplierContact where tbl_SupplierContact.SupplierId = a.Id FOR XML RAW,ROOT('Root')) AS ContactInfo ");
            tableName.AppendFormat(" ,a.ZxsId ");
            tableName.Append(
                " FROM [tbl_CompanySupplier] AS a LEFT JOIN tbl_CompanyProvince AS b ON a.ProvinceId = b.Id LEFT JOIN tbl_CompanyCity AS c on a.CityId = c.Id LEFT JOIN tbl_SupplierHotel AS d ON a.Id = d.SupplierId ");
            string fileds = "[Id],[ProvinceId],[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],[CompanyId],[OperatorId],[IssueTime],[IsDelete],ProvinceName,CityName,Star,ContactInfo,ZxsId ";
            string orderByStr = " IssueTime desc ";
            var strWhere = new StringBuilder(" [IsDelete] = '0' ");
            strWhere.AppendFormat(" and [CompanyId] = {0} ", companyId);
            strWhere.AppendFormat(" and [SupplierType] = {0} ", (int)Model.EnumType.CompanyStructure.SupplierType.酒店);

            if (model != null)
            {
                if (model.ProvinceId != null && model.ProvinceId.Any())
                {
                    if (model.ProvinceId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [ProvinceId] = {0} ", model.ProvinceId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [ProvinceId] in ({0}) ", GetIdsByArr(model.ProvinceId));
                    }
                }
                if (model.CityId != null && model.CityId.Any())
                {
                    if (model.CityId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [CityId] = {0} ", model.CityId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [CityId] in ({0}) ", GetIdsByArr(model.CityId));
                    }
                }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    strWhere.AppendFormat(" and UnitName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.Name));
                }
                if (model.Star.HasValue)
                {
                    strWhere.AppendFormat(" and Star = {0} ", (int)model.Star.Value);
                }
                if (!string.IsNullOrEmpty(model.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", model.ZxsId);
                }

                switch (model.OrderByIndex)
                {
                    case 0:
                        orderByStr = " IssueTime asc ";
                        break;
                    case 1:
                        orderByStr = " IssueTime desc ";
                        break;
                    default:
                        orderByStr = " IssueTime desc ";
                        break;
                }
            }

            #endregion

            var list = new List<SupplierHotel>();

            #region 取值

            using (IDataReader dr = DbHelper.ExecuteReader2(_db, pageSize, pageIndex, ref recordCount, tableName.ToString(), fileds
                , strWhere.ToString(), orderByStr, string.Empty))
            {
                while (dr.Read())
                {
                    var t = new SupplierHotel();

                    if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                        t.Id = dr.GetString(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                        t.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                        t.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                        t.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                        t.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                        t.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                        t.SupplierType =
                            (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                        t.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                    if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                        t.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                        t.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                        t.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        t.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                        t.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                        t.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        t.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                        t.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactInfo")))
                        t.SupplierContact = this.GetSupplierContact(dr.GetString(dr.GetOrdinal("ContactInfo")));
                    if (!dr.IsDBNull(dr.GetOrdinal("Star")))
                        t.Star = (Model.EnumType.CompanyStructure.HotelStar)dr.GetByte(dr.GetOrdinal("Star"));
                    t.ZxsId = dr["ZxsId"].ToString();
                    list.Add(t);
                }
            }

            #endregion

            return list;
        }

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">景点查询实体</param>
        /// <returns></returns>
        public IList<SupplierSpot> GetSupplierSpot(int companyId, int pageSize, int pageIndex, ref int recordCount
            , QuerySupplierSpot model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            #region sql处理

            var tableName = new StringBuilder();
            tableName.Append(
                "SELECT a.[Id],a.[ProvinceId],a.[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],a.[CompanyId],a.[OperatorId],a.[IssueTime],[IsDelete],b.ProvinceName,c.CityName");
            tableName.Append(" ,d.Star,d.TeamPrice,d.TravelerPrice ");
            tableName.Append(
                " ,(select Id,ContactName,ContactFax,ContactTel,ContactMobile from tbl_SupplierContact where tbl_SupplierContact.SupplierId = a.Id FOR XML RAW,ROOT('Root')) AS ContactInfo ");
            tableName.AppendFormat(" ,a.ZxsId ");
            tableName.Append(
                " FROM [tbl_CompanySupplier] AS a LEFT JOIN tbl_CompanyProvince AS b ON a.ProvinceId = b.Id LEFT JOIN tbl_CompanyCity AS c on a.CityId = c.Id LEFT JOIN tbl_SupplierSpot AS d on a.Id = d.SupplierId ");
            string fileds = "[Id],[ProvinceId],[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],[CompanyId],[OperatorId],[IssueTime],[IsDelete],ProvinceName,CityName,Star,TeamPrice,TravelerPrice,ContactInfo,ZxsId ";
            string orderByStr = " IssueTime desc ";
            var strWhere = new StringBuilder(" [IsDelete] = '0' ");
            strWhere.AppendFormat(" and [CompanyId] = {0} ", companyId);
            strWhere.AppendFormat(" and [SupplierType] = {0} ", (int)Model.EnumType.CompanyStructure.SupplierType.景点);

            if (model != null)
            {
                if (model.ProvinceId != null && model.ProvinceId.Any())
                {
                    if (model.ProvinceId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [ProvinceId] = {0} ", model.ProvinceId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [ProvinceId] in ({0}) ", GetIdsByArr(model.ProvinceId));
                    }
                }
                if (model.CityId != null && model.CityId.Any())
                {
                    if (model.CityId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [CityId] = {0} ", model.CityId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [CityId] in ({0}) ", GetIdsByArr(model.CityId));
                    }
                }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    strWhere.AppendFormat(" and UnitName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.Name));
                }
                if (model.Star.HasValue)
                {
                    strWhere.AppendFormat(" and Star = {0} ", (int)model.Star.Value);
                }
                if (!string.IsNullOrEmpty(model.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", model.ZxsId);
                }

                switch (model.OrderByIndex)
                {
                    case 0:
                        orderByStr = " IssueTime asc ";
                        break;
                    case 1:
                        orderByStr = " IssueTime desc ";
                        break;
                    default:
                        orderByStr = " IssueTime desc ";
                        break;
                }
            }

            #endregion

            var list = new List<SupplierSpot>();

            #region 取值

            using (IDataReader dr = DbHelper.ExecuteReader2(_db, pageSize, pageIndex, ref recordCount, tableName.ToString(), fileds
                , strWhere.ToString(), orderByStr, string.Empty))
            {
                while (dr.Read())
                {
                    var t = new SupplierSpot();

                    if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                        t.Id = dr.GetString(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                        t.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                        t.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                        t.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                        t.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                        t.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                        t.SupplierType =
                            (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                        t.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                    if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                        t.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                        t.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                        t.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        t.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                        t.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                        t.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        t.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                        t.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactInfo")))
                        t.SupplierContact = this.GetSupplierContact(dr.GetString(dr.GetOrdinal("ContactInfo")));
                    if (!dr.IsDBNull(dr.GetOrdinal("Star")))
                        t.Start = (Model.EnumType.CompanyStructure.ScenicSpotStar)dr.GetByte(dr.GetOrdinal("Star"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TeamPrice")))
                        t.TeamPrice = dr.GetDecimal(dr.GetOrdinal("TeamPrice"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TravelerPrice")))
                        t.TravelerPrice = dr.GetDecimal(dr.GetOrdinal("TravelerPrice"));
                    t.ZxsId = dr["ZxsId"].ToString();

                    list.Add(t);
                }
            }

            #endregion

            return list;
        }

        /// <summary>
        /// 获取其他信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">其他查询实体</param>
        /// <returns></returns>
        public IList<SupplierOther> GetSupplierOther(int companyId, int pageSize, int pageIndex, ref int recordCount
            , QuerySupplierOther model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            #region sql处理

            var tableName = new StringBuilder();
            tableName.Append(
                "SELECT a.[Id],a.[ProvinceId],a.[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],a.[CompanyId],a.[OperatorId],a.[IssueTime],[IsDelete],b.ProvinceName,c.CityName");
            tableName.Append(
                " ,(select ContactName,ContactFax,ContactTel,ContactMobile from tbl_SupplierContact where tbl_SupplierContact.SupplierId = a.Id FOR XML RAW,ROOT('Root')) AS ContactInfo ");
            tableName.AppendFormat(" ,a.ZxsId ");
            tableName.Append(
                " FROM [tbl_CompanySupplier] AS a LEFT JOIN tbl_CompanyProvince AS b ON a.ProvinceId = b.Id LEFT JOIN tbl_CompanyCity AS c on a.CityId = c.Id");
            string fileds = "[Id],[ProvinceId],[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],[CompanyId],[OperatorId],[IssueTime],[IsDelete],ProvinceName,CityName,ContactInfo,ZxsId ";
            string orderByStr = " IssueTime desc ";
            var strWhere = new StringBuilder(" [IsDelete] = '0' ");
            strWhere.AppendFormat(" and [CompanyId] = {0} ", companyId);
            strWhere.AppendFormat(" and [SupplierType] = {0} ", (int)Model.EnumType.CompanyStructure.SupplierType.其他);

            if (model != null)
            {
                if (model.ProvinceId != null && model.ProvinceId.Any())
                {
                    if (model.ProvinceId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [ProvinceId] = {0} ", model.ProvinceId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [ProvinceId] in ({0}) ", GetIdsByArr(model.ProvinceId));
                    }
                }
                if (model.CityId != null && model.CityId.Any())
                {
                    if (model.CityId.Length == 1)
                    {
                        strWhere.AppendFormat(" and [CityId] = {0} ", model.CityId[0]);
                    }
                    else
                    {
                        strWhere.AppendFormat(" and [CityId] in ({0}) ", GetIdsByArr(model.CityId));
                    }
                }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    strWhere.AppendFormat(" and UnitName like '%{0}%' ", Toolkit.Utils.ToSqlLike(model.Name));
                }
                if (!string.IsNullOrEmpty(model.ZxsId))
                {
                    strWhere.AppendFormat(" AND ZxsId='{0}' ", model.ZxsId);
                }

                switch (model.OrderByIndex)
                {
                    case 0:
                        orderByStr = " IssueTime asc ";
                        break;
                    case 1:
                        orderByStr = " IssueTime desc ";
                        break;
                    default:
                        orderByStr = " IssueTime desc ";
                        break;
                }
            }

            #endregion

            var list = new List<SupplierOther>();

            #region 取值

            using (IDataReader dr = DbHelper.ExecuteReader2(_db, pageSize, pageIndex, ref recordCount, tableName.ToString(), fileds
                , strWhere.ToString(), orderByStr, string.Empty))
            {
                while (dr.Read())
                {
                    var t = new SupplierOther();

                    if (!dr.IsDBNull(dr.GetOrdinal("Id")))
                        t.Id = dr.GetString(dr.GetOrdinal("Id"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceId")))
                        t.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProvinceName")))
                        t.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityId")))
                        t.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CityName")))
                        t.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitName")))
                        t.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("SupplierType")))
                        t.SupplierType =
                            (Model.EnumType.CompanyStructure.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LicenseKey")))
                        t.LicenseKey = dr.GetString(dr.GetOrdinal("LicenseKey"));
                    if (!dr.IsDBNull(dr.GetOrdinal("AgreementFile")))
                        t.AgreementFile = dr.GetString(dr.GetOrdinal("AgreementFile"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitAddress")))
                        t.UnitAddress = dr.GetString(dr.GetOrdinal("UnitAddress"));
                    if (!dr.IsDBNull(dr.GetOrdinal("UnitPolicy")))
                        t.UnitPolicy = dr.GetString(dr.GetOrdinal("UnitPolicy"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Remark")))
                        t.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                        t.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("OperatorId")))
                        t.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                        t.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IsDelete")))
                        t.IsDelete = this.GetBoolean(dr.GetString(dr.GetOrdinal("IsDelete")));
                    if (!dr.IsDBNull(dr.GetOrdinal("ContactInfo")))
                        t.SupplierContact = this.GetSupplierContact(dr.GetString(dr.GetOrdinal("ContactInfo")));
                    t.ZxsId = dr["ZxsId"].ToString();

                    list.Add(t);
                }
            }

            #endregion

            return list;
        }


        /// <summary>
        /// 根据供应商编号获取联系人集合
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IList<SupplierContact> GetSupplierContactById(string Id)
        {
            IList<SupplierContact> list = new List<SupplierContact>();

            string sql = "SELECT A.*,(SELECT A1.Username FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.YongHuId) AS YongHuMing FROM [tbl_SupplierContact] AS A where A.[SupplierId] = @SupplierId";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            this._db.AddInParameter(cmd, "SupplierId", DbType.AnsiStringFixedLength, Id);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    SupplierContact model = new SupplierContact
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId")),
                        SupplierId = dr.GetString(dr.GetOrdinal("SupplierId")),
                        ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : null,
                        ContactFax = !dr.IsDBNull(dr.GetOrdinal("ContactFax")) ? dr.GetString(dr.GetOrdinal("ContactFax")) : null,
                        ContactMobile = !dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? dr.GetString(dr.GetOrdinal("ContactMobile")) : null,
                        ContactTel = !dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? dr.GetString(dr.GetOrdinal("ContactTel")) : null,
                        Email = !dr.IsDBNull(dr.GetOrdinal("Email")) ? dr.GetString(dr.GetOrdinal("Email")) : null,
                        JobTitle = !dr.IsDBNull(dr.GetOrdinal("JobTitle")) ? dr.GetString(dr.GetOrdinal("JobTitle")) : null,
                        Qq = !dr.IsDBNull(dr.GetOrdinal("Qq")) ? dr.GetString(dr.GetOrdinal("Qq")) : null,
                        YongHuId = dr.GetInt32(dr.GetOrdinal("YongHuId")),
                        YongHuMing = dr["YongHuMing"].ToString()
                    };
                    list.Add(model);
                }
            }
            return list;
        }

        #endregion

        #region 私有成员

        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="id">酒店供应商编号</param>
        /// <param name="model">酒店供应商实体</param>
        /// <returns></returns>
        private void GetHotelInfo(string id, ref SupplierHotel model)
        {
            if (string.IsNullOrEmpty(id) || model == null) return;

            var strSql = new StringBuilder();
            strSql.Append(
                " SELECT [SupplierId],[Star],[Introduce],[TourGuide] FROM [tbl_SupplierHotel] where [SupplierId] = @Id; ");
            strSql.Append(
                " SELECT [RoomTypeId],[SupplierId],[Name],[SellingPrice],[AccountingPrice],[IsBreakfast] FROM [tbl_SupplierHotelRoomType]  where [SupplierId] = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.AnsiStringFixedLength, id);

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    if (!dr.IsDBNull(dr.GetOrdinal("Star")))
                        model.Star = (Model.EnumType.CompanyStructure.HotelStar)dr.GetByte(dr.GetOrdinal("Star"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Introduce")))
                        model.Introduce = dr.GetString(dr.GetOrdinal("Introduce"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TourGuide")))
                        model.TourGuide = dr.GetString(dr.GetOrdinal("TourGuide"));
                }

                if (model.RoomTypes == null) model.RoomTypes = new List<SupplierHotelRoomType>();
                dr.NextResult();
                while (dr.Read())
                {
                    model.RoomTypes.Add(
                        new SupplierHotelRoomType
                            {
                                RoomTypeId =
                                    dr.IsDBNull(dr.GetOrdinal("RoomTypeId"))
                                        ? 0
                                        : dr.GetInt32(dr.GetOrdinal("RoomTypeId")),
                                Name =
                                    dr.IsDBNull(dr.GetOrdinal("Name"))
                                        ? string.Empty
                                        : dr.GetString(dr.GetOrdinal("Name")),
                                SellingPrice =
                                    dr.IsDBNull(dr.GetOrdinal("SellingPrice"))
                                        ? 0
                                        : dr.GetDecimal(dr.GetOrdinal("SellingPrice")),
                                AccountingPrice =
                                    dr.IsDBNull(dr.GetOrdinal("AccountingPrice"))
                                        ? 0
                                        : dr.GetDecimal(dr.GetOrdinal("AccountingPrice")),
                                IsBreakfast =
                                    dr.IsDBNull(dr.GetOrdinal("SellingPrice"))
                                        ? false
                                        : this.GetBoolean(dr.GetString(dr.GetOrdinal("IsBreakfast")))
                            });
                }
            }
        }

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <param name="id">景点供应商编号</param>
        /// <param name="model">景点供应商实体</param>
        private void GetSpotInfo(string id, ref SupplierSpot model)
        {
            if (string.IsNullOrEmpty(id) || model == null) return;

            var strSql = new StringBuilder();
            strSql.Append(
                " SELECT [SupplierId],[Star],[TourGuide],[TeamPrice],[TravelerPrice] FROM [tbl_SupplierSpot] where [SupplierId] = @Id; ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Id", DbType.AnsiStringFixedLength, id);

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    if (!dr.IsDBNull(dr.GetOrdinal("Star")))
                        model.Start = (Model.EnumType.CompanyStructure.ScenicSpotStar)dr.GetByte(dr.GetOrdinal("Star"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TourGuide")))
                        model.TourGuide = dr.GetString(dr.GetOrdinal("TourGuide"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TeamPrice")))
                        model.TeamPrice = dr.GetDecimal(dr.GetOrdinal("TeamPrice"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TravelerPrice")))
                        model.TravelerPrice = dr.GetDecimal(dr.GetOrdinal("TravelerPrice"));
                }
            }
        }

        /// <summary>
        /// 根据sqlxml生成联系人信息集合 
        /// </summary>
        /// <param name="sqlXMl">sqlxml</param>
        /// <returns></returns>
        private IList<SupplierContact> GetSupplierContact(string sqlXMl)
        {
            if (string.IsNullOrEmpty(sqlXMl)) return null;

            var xRoot = XElement.Parse(sqlXMl);
            var xRows = Toolkit.Utils.GetXElements(xRoot, "row");
            if (xRows == null || !xRows.Any()) return null;

            return (from t in xRows
                    where t != null
                    select
                        new SupplierContact
                            {
                                ContactName = Toolkit.Utils.GetXAttributeValue(t, "ContactName"),
                                ContactFax = Toolkit.Utils.GetXAttributeValue(t, "ContactFax"),
                                ContactTel = Toolkit.Utils.GetXAttributeValue(t, "ContactTel"),
                                ContactMobile = Toolkit.Utils.GetXAttributeValue(t, "ContactMobile"),
                                Id = Toolkit.Utils.GetInt(Toolkit.Utils.GetXAttributeValue(t, "Id"))
                            }).ToList();
        }

        #endregion

        /// <summary>
        /// (管理系统)供应商联系人用户新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="yongHuMing">用户名</param>
        /// <param name="miMa">密码</param>
        /// <param name="md5MiMa">MD5密码</param>
        /// <returns></returns>
        public int GysLxrYongHu_CU(string gysId, int lxrId, int caoZuoRenId, string yongHuMing, string miMa, string md5MiMa)
        {
            var cmd = _db.GetStoredProcCommand("proc_GysLxr_YongHu_CU");
            _db.AddInParameter(cmd, "@GysId", DbType.AnsiStringFixedLength, gysId);
            _db.AddInParameter(cmd, "@LxrId", DbType.Int32, lxrId);
            _db.AddInParameter(cmd, "@YongHuMing", DbType.String, yongHuMing);
            _db.AddInParameter(cmd, "@MiMa", DbType.String, miMa);
            _db.AddInParameter(cmd, "@Md5MiMa", DbType.String, md5MiMa);
            _db.AddInParameter(cmd, "@CaoZuoRenId", DbType.Int32, caoZuoRenId);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

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

        /// <summary>
        /// (管理系统)供应商联系人用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public int GysLxrYonHu_D(string gysId, int lxrId, int yongHuId)
        {
            var cmd = _db.GetStoredProcCommand("proc_GysLxr_YongHu_D");
            _db.AddInParameter(cmd, "@GysId", DbType.AnsiStringFixedLength, gysId);
            _db.AddInParameter(cmd, "@LxrId", DbType.Int32, lxrId);
            _db.AddInParameter(cmd, "@YongHuId", DbType.Int32, yongHuId);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

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
    }
}
