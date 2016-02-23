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
    /// 客户关系管理
    /// </summary>
    public class Customer : DALBase, IDAL.CompanyStructure.ICustomer
    {
        #region constructor
        private readonly Database _db;

        public Customer()
        {
            _db = this.SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 根据sqlxml获取联系人信息集合
        /// </summary>
        /// <param name="strSqlXml"></param>
        private IList<CustomerContactInfo> GetContactList(string strSqlXml)
        {
            if (string.IsNullOrEmpty(strSqlXml)) return null;

            var xRoot = XElement.Parse(strSqlXml);
            var xRows = Toolkit.Utils.GetXElements(xRoot, "row");
            if (xRows == null || !xRows.Any()) return null;

            var list = new List<CustomerContactInfo>();
            foreach (var t in xRows)
            {
                if (t == null) continue;

                list.Add(new CustomerContactInfo
                {
                    ContactId = Toolkit.Utils.GetInt(Toolkit.Utils.GetXAttributeValue(t, "ID")),
                    Name = Toolkit.Utils.GetXAttributeValue(t, "Name")
                });
            }

            return list;
        }

        /// <summary>
        /// create lxr xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateLxrXml(IList<EyouSoft.Model.CompanyStructure.CustomerContactInfo> items)
        {            
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append("<info ");
                s.AppendFormat(" LxrId=\"{0}\" ", item.ContactId);
                s.AppendFormat(" XingBie=\"{0}\" ", (int)item.Sex);
                s.AppendFormat(" Status=\"{0}\" ", (int)item.Status);
                if (item.BirthDay.HasValue)
                {
                    s.AppendFormat(" ShengRi=\"{0}\" ", item.BirthDay.Value);
                }
                s.Append(">");
                s.AppendFormat("<ZhiWu><![CDATA[{0}]]></ZhiWu>", item.Job);
                s.AppendFormat("<BuMen><![CDATA[{0}]]></BuMen>", item.DepartId);
                s.AppendFormat("<XingMing><![CDATA[{0}]]></XingMing>", item.Name);
                s.AppendFormat("<DianHua><![CDATA[{0}]]></DianHua>", item.Tel);
                s.AppendFormat("<ShouJi><![CDATA[{0}]]></ShouJi>", item.Mobile);
                s.AppendFormat("<QQ><![CDATA[{0}]]></QQ>", item.qq);
                s.AppendFormat("<Email><![CDATA[{0}]]></Email>", item.Email);
                s.AppendFormat("<Fax><![CDATA[{0}]]></Fax>", item.Fax);
                s.AppendFormat("<WeiXinHao><![CDATA[{0}]]></WeiXinHao>", item.WeiXinHao);
                s.Append("</info>");
            }
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// create yinhangzhaohao xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateYinHangZhaoHaoXml(IList<EyouSoft.Model.CompanyStructure.CustomerBank> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append("<info>");
                s.AppendFormat("<AccountName><![CDATA[{0}]]></AccountName>", item.AccountName);
                s.AppendFormat("<BankName><![CDATA[{0}]]></BankName>", item.BankName);
                s.AppendFormat("<BankNo><![CDATA[{0}]]></BankNo>", item.BankNo);
                s.Append("</info>");
            }
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// create fujian xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateFuJianXml(IList<EyouSoft.Model.CompanyStructure.CompanyFile> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.AppendFormat("<info FileId=\"{0}\" Filepath=\"{1}\" ItemType=\"{2}\">", item.FileId, item.FilePath, (int)item.AnnexType);
                s.Append("</info>");
            }
            s.Append("</root>");
            return s.ToString();
        }
        #endregion

        #region ICustomer members

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CustomerInfo GetCustomerModel(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            #region sql 处理

            var strSql = new StringBuilder();
            strSql.Append(" SELECT A.*,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.ProviceId) AS ProvinceName,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.CityId) AS CityName,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.SaleId) AS Saler  FROM tbl_Customer AS A WHERE A.Id=@Id; ");
            strSql.Append(" SELECT A.*,(SELECT A1.Username FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.YongHuId) AS YongHuMing FROM [tbl_CustomerContactInfo] AS A where A.CustomerId = @Id ORDER BY A.ID ASC; ");
            strSql.Append(" SELECT A.* FROM [tbl_CustomerAccount] AS A where A.Id = @Id; ");
            strSql.Append(" SELECT A.* FROM [tbl_ComapnyFile] AS A WHERE A.ItemId=@Id AND A.[ItemType]=@AnnexType ORDER BY A.[IdentityId] ASC; ");
            #endregion

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            _db.AddInParameter(dc, "Id", DbType.AnsiStringFixedLength, id);
            _db.AddInParameter(dc, "AnnexType", DbType.Byte, (int)EyouSoft.Model.EnumType.CompanyStructure.AnnexType.客户信息);

            CustomerInfo model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                #region 客户基本信息

                if (dr.Read())
                {
                    model = new CustomerInfo();
                    model.Type = (Model.EnumType.CompanyStructure.CustomerType)dr.GetByte(dr.GetOrdinal("Type"));
                    model.Adress = dr["Adress"].ToString();
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.CityName = dr["CityName"].ToString();
                    model.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    model.ContactName = dr["ContactName"].ToString();
                    model.Fax = dr["Fax"].ToString();
                    model.Id = dr.GetString(dr.GetOrdinal("Id"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.Licence = dr["Licence"].ToString();
                    model.Mobile = dr["Mobile"].ToString();
                    model.Name = dr["Name"].ToString();
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    model.Phone = dr["Phone"].ToString();
                    model.PostalCode = dr["PostalCode"].ToString();
                    model.ProviceId = dr.GetInt32(dr.GetOrdinal("ProviceId"));
                    model.ProvinceName = dr["ProvinceName"].ToString();
                    model.Remark = dr["Remark"].ToString();
                    model.SaleId = dr.GetInt32(dr.GetOrdinal("SaleId"));
                    model.Saler = dr["Saler"].ToString();
                    model.IsEnable = dr.GetString(dr.GetOrdinal("IsEnable")) == "1" ? true : false;
                    model.FilePath = dr["FilePath"].ToString();
                    model.FaRenName = dr["FaRenName"].ToString();
                    model.YingYeZhiZhaoHao = dr["YingYeZhiZhaoHao"].ToString();
                    model.GongSiDianHua = dr["GongSiDianHua"].ToString();
                    model.GongSiFax = dr["GongSiFax"].ToString();
                    model.LxrQQ = dr["LxrQQ"].ToString();
                    model.LxrEmail = dr["LxrEmail"].ToString();
                    model.ZxsId = dr["ZxsId"].ToString();
                    model.LaiYuan = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan)dr.GetByte(dr.GetOrdinal("LaiYuan"));
                    model.JianMa = dr["JianMa"].ToString();
                    model.LogoFilepath = dr["Logo"].ToString();
                    model.JieShao = dr["JieShao"].ToString();
                    model.DanJuDaYinMoBan = dr["DanJuDaYinMoBan"].ToString();
                }

                #endregion

                #region 客户联系人信息

                if (model != null)
                {
                    model.CustomerContact = new List<CustomerContactInfo>();
                    dr.NextResult();
                    while (dr.Read())
                    {
                        var item = new CustomerContactInfo();
                        item.CustomerId = model.Id;
                        item.ContactId = dr.GetInt32(dr.GetOrdinal("ID"));
                        item.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                        item.Job = dr["JobId"].ToString();
                        item.DepartId = dr["DepartmentId"].ToString();
                        item.Sex = (Model.EnumType.CompanyStructure.Sex)Toolkit.Utils.GetInt(dr.GetString(dr.GetOrdinal("Sex")));
                        item.Name = dr["Name"].ToString();
                        item.Tel = dr["Tel"].ToString();
                        item.Mobile = dr["Mobile"].ToString();
                        item.qq = dr["QQ"].ToString();
                        item.Email = dr["Email"].ToString();
                        item.Spetialty = dr["Spetialty"].ToString();
                        item.Hobby = dr["Hobby"].ToString();
                        item.Remark = dr["Remark"].ToString();
                        item.Fax = dr["Fax"].ToString();
                        if (!dr.IsDBNull(dr.GetOrdinal("BirthDay"))) item.BirthDay = dr.GetDateTime(dr.GetOrdinal("BirthDay"));
                        item.Status = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus)dr.GetByte(dr.GetOrdinal("Status"));
                        item.YongHuId = dr.GetInt32(dr.GetOrdinal("YongHuId"));
                        item.YongHuMing = dr["YongHuMing"].ToString();
                        item.WeiXinHao = dr["WeiXinHao"].ToString();

                        model.CustomerContact.Add(item);
                    }
                }

                #endregion

                #region 客户银行账户信息

                if (model != null)
                {
                    model.CustomerBank = new List<CustomerBank>();
                    dr.NextResult();
                    while (dr.Read())
                    {
                        var item = new CustomerBank();

                        item.CustomerId = model.Id;
                        item.AccountName = dr["AccountName"].ToString();
                        item.BankName = dr["BankName"].ToString();
                        item.BankNo = dr["BankNo"].ToString();
                        model.CustomerBank.Add(item);
                    }
                }

                #endregion

                #region 附件信息
                var annexs = new List<EyouSoft.Model.CompanyStructure.CompanyFile>();
                dr.NextResult();
                while (dr.Read())
                {
                    annexs.Add(new CompanyFile() { FilePath = dr["FilePath"].ToString() });
                }
                if (model != null) model.Annexs = annexs;
                #endregion
            }

            return model;
        }

        /// <summary>
        /// 按指定条件获取客户资料信息集合
        /// </summary>
        /// <param name="companyId">公司（专线）编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="seachInfo">查询条件业务实体</param>
        /// <returns></returns>
        public IList<CustomerInfo> GetCustomers(int companyId, int pageSize, int pageIndex, ref int recordCount, MCustomerSeachInfo seachInfo)
        {
            if (companyId <= 0 || pageSize <= 0 || pageIndex <= 0) return null;


            #region sql 处理

            string tableName =
                @" SELECT a.[Id],a.[ProviceId],a.[CityId],a.[Type],a.[Name],a.[Licence],a.[Adress],a.[PostalCode],a.[FilePath],a.[SaleId]
                    ,a.[CompanyId],a.[IsEnable],a.[ContactName],a.[Phone],a.[Mobile],a.[Fax],a.[Remark],a.[OperatorId],a.[IssueTime]
                    ,b.ProvinceName,c.CityName,d.ContactName as Saler,a.isdelete
                    ,(select tbl_CustomerContactInfo.ID,[Name] from tbl_CustomerContactInfo where tbl_CustomerContactInfo.CustomerId = a.Id for xml raw,root('Root')) as ContactInfo
                    ,a.ZxsId,a.LaiYuan,a.ShenHeStatus,a.JianMa 
                    FROM [tbl_Customer] AS a  LEFT JOIN tbl_CompanyProvince AS b ON a.ProviceId = b.Id
                    LEFT JOIN tbl_CompanyCity AS c on a.CityId = c.Id
                    LEFT JOIN tbl_CompanyUser AS d ON a.SaleId = d.Id";
            string fileds = " * ";
            string orderByString = " IssueTime desc ";
            var strWhere = new StringBuilder(" IsDelete = '0' ");

            strWhere.AppendFormat(" AND CompanyId={0} ", companyId);

            if (seachInfo != null)
            {
                if (!string.IsNullOrEmpty(seachInfo.CustomerName))
                    strWhere.AppendFormat(" and (Name like '%{0}%' OR JianMa LIKE '%{0}%') ", Toolkit.Utils.ToSqlLike(seachInfo.CustomerName));
                if (!string.IsNullOrEmpty(seachInfo.ContactName))
                    strWhere.AppendFormat(" and ContactName like '%{0}%' ", Toolkit.Utils.ToSqlLike(seachInfo.ContactName));
                if (!string.IsNullOrEmpty(seachInfo.ContactTelephone))
                    strWhere.AppendFormat(" AND (Phone LIKE '%{0}%' OR EXISTS (SELECT 1 FROM tbl_CustomerContactInfo WHERE CustomerId = t129.Id AND (Tel LIKE '%{0}%'))) ", Toolkit.Utils.ToSqlLike(seachInfo.ContactTelephone));
                if (!string.IsNullOrEmpty(seachInfo.Mobile))
                    strWhere.AppendFormat(" AND (Mobile LIKE '%{0}%' OR EXISTS (SELECT 1 FROM tbl_CustomerContactInfo WHERE CustomerId = t129.Id AND (Mobile LIKE '%{0}%'))) ", Toolkit.Utils.ToSqlLike(seachInfo.Mobile));
                if (seachInfo.ProvinceIds != null && seachInfo.ProvinceIds.Any())
                {
                    if (seachInfo.ProvinceIds.Length == 1)
                        strWhere.AppendFormat(" and ProviceId = {0} ", seachInfo.ProvinceIds[0]);
                    else
                        strWhere.AppendFormat(" and ProviceId in ({0}) ", GetIdsByArr(seachInfo.ProvinceIds));
                }
                if (seachInfo.CityIdList != null && seachInfo.CityIdList.Any())
                {
                    if (seachInfo.CityIdList.Length == 1)
                        strWhere.AppendFormat(" and CityId = {0} ", seachInfo.CityIdList[0]);
                    else
                        strWhere.AppendFormat(" and CityId in ({0}) ", GetIdsByArr(seachInfo.CityIdList));
                }

                if (seachInfo.SellerIds != null && seachInfo.SellerIds.Any())
                {
                    if (seachInfo.SellerIds.Length == 1)
                        strWhere.AppendFormat(" and SaleId = {0} ", seachInfo.SellerIds[0]);
                    else
                        strWhere.AppendFormat(" and SaleId in ({0}) ", GetIdsByArr(seachInfo.SellerIds));
                }
                if (!string.IsNullOrEmpty(seachInfo.SellerName))
                {
                    strWhere.AppendFormat(" AND exists (select 1 from tbl_CompanyUser where Id = SaleId and ContactName like '%{0}%' )  ", Toolkit.Utils.ToSqlLike(seachInfo.SellerName));
                }
                if (seachInfo.KeHuLeiXing.HasValue)
                {
                    strWhere.AppendFormat(" AND Type={0} ", (int)seachInfo.KeHuLeiXing.Value);
                }
                if (seachInfo.LaiYuan.HasValue)
                {
                    strWhere.AppendFormat(" AND LaiYuan={0} ", (int)seachInfo.LaiYuan.Value);
                }
                if (seachInfo.ShenHeStatus.HasValue)
                {
                    strWhere.AppendFormat(" AND ShenHeStatus={0} ", (int)seachInfo.ShenHeStatus.Value);
                }
                if (seachInfo.ZhuCeShiJian1.HasValue)
                {
                    strWhere.AppendFormat(" AND IssueTime>'{0}' ", seachInfo.ZhuCeShiJian1.Value.AddMinutes(-1));
                }
                if (seachInfo.ZhuCeShiJian2.HasValue)
                {
                    strWhere.AppendFormat(" AND IssueTime<'{0}' ", seachInfo.ZhuCeShiJian2.Value.AddDays(1).AddMinutes(-1));
                }


                switch (seachInfo.OrderByType)
                {
                    case 0:
                        orderByString = " IssueTime asc ";
                        break;
                    case 1:
                        orderByString = " IssueTime desc ";
                        break;
                    case 2:
                        orderByString = " Name asc ";
                        break;
                    case 3:
                        orderByString = " Name DESC ";
                        break;
                    default:
                        orderByString = " IssueTime desc ";
                        break;
                }
            }

            #endregion

            IList<CustomerInfo> list = new List<CustomerInfo>();

            #region 赋值

            using (IDataReader dr = DbHelper.ExecuteReader2(_db, pageSize, pageIndex, ref recordCount, tableName, fileds
                , strWhere.ToString(), orderByString, string.Empty))
            {
                while (dr.Read())
                {
                    var item = new CustomerInfo();

                    item.Type = (Model.EnumType.CompanyStructure.CustomerType)dr.GetByte(dr.GetOrdinal("Type"));
                    item.Adress = dr["Adress"].ToString();
                    item.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    item.CityName = dr["CityName"].ToString();
                    item.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
                    item.ContactName = dr["ContactName"].ToString();
                    item.Fax = dr["Fax"].ToString();
                    item.Id = dr.GetString(dr.GetOrdinal("Id"));
                    item.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    item.Licence = dr["Licence"].ToString();
                    item.Mobile = dr["Mobile"].ToString();
                    item.Name = dr["Name"].ToString();
                    item.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    item.Phone = dr["Phone"].ToString();
                    item.PostalCode = dr["PostalCode"].ToString();
                    item.ProviceId = dr.GetInt32(dr.GetOrdinal("ProviceId"));
                    item.ProvinceName = dr["ProvinceName"].ToString();
                    item.Remark = dr["Remark"].ToString();
                    item.SaleId = dr.GetInt32(dr.GetOrdinal("SaleId"));
                    item.Saler = dr["Saler"].ToString();
                    item.IsEnable = dr.GetString(dr.GetOrdinal("IsEnable")) == "1" ? true : false;
                    item.FilePath =dr["FilePath"].ToString();
                    item.CustomerContact = this.GetContactList(dr["ContactInfo"].ToString());
                    item.ZxsId = dr["ZxsId"].ToString();
                    item.LaiYuan = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan)dr.GetByte(dr.GetOrdinal("LaiYuan"));
                    item.ShenHeStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus)dr.GetByte(dr.GetOrdinal("ShenHeStatus"));

                    list.Add(item);
                }
            }

            #endregion

            return list;
        }

        /// <summary>
        /// 客户新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int KeHu_CU(EyouSoft.Model.CompanyStructure.CustomerInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_KeHu_CU");
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, info.Id);
            _db.AddInParameter(cmd, "@ProviceId", DbType.Int32, info.ProviceId);
            _db.AddInParameter(cmd, "@CityId", DbType.Int32, info.CityId);
            _db.AddInParameter(cmd, "@Type", DbType.Byte, info.Type);
            _db.AddInParameter(cmd, "@Name", DbType.String, info.Name);
            _db.AddInParameter(cmd, "@Licence", DbType.String, info.Licence);
            _db.AddInParameter(cmd, "@Adress", DbType.String, info.Adress);
            _db.AddInParameter(cmd, "@PostalCode", DbType.String, info.PostalCode);
            _db.AddInParameter(cmd, "@FilePath", DbType.String, info.FilePath);
            _db.AddInParameter(cmd, "@SaleId", DbType.Int32, info.SaleId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@IsEnable", DbType.AnsiStringFixedLength, info.IsEnable);
            _db.AddInParameter(cmd, "@ContactName", DbType.String, info.ContactName);
            _db.AddInParameter(cmd, "@Phone", DbType.String, info.Phone);
            _db.AddInParameter(cmd, "@Mobile", DbType.String, info.Mobile);
            _db.AddInParameter(cmd, "@Fax", DbType.String, info.Fax);
            _db.AddInParameter(cmd, "@Remark", DbType.String, info.Remark);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, info.ZxsId);
            _db.AddInParameter(cmd, "@LaiYuan", DbType.Byte, info.LaiYuan);
            _db.AddInParameter(cmd, "@ShenHeStatus", DbType.Byte, info.ShenHeStatus);
            _db.AddInParameter(cmd, "@ShenHeOperatorId", DbType.Int32, info.ShenHeOperatorId);
            _db.AddInParameter(cmd, "@ShenHeTime", DbType.DateTime, info.ShenHeTime);
            _db.AddInParameter(cmd, "@YingYeZhiZhaoHao", DbType.String, info.YingYeZhiZhaoHao);
            _db.AddInParameter(cmd, "@FaRenName", DbType.String, info.FaRenName);
            _db.AddInParameter(cmd, "@LxrQQ", DbType.String, info.LxrQQ);
            _db.AddInParameter(cmd, "@LxrEmail", DbType.String, info.LxrEmail);
            _db.AddInParameter(cmd, "@GongSiDianHua", DbType.String, info.GongSiDianHua);
            _db.AddInParameter(cmd, "@GongSiFax", DbType.String, info.GongSiFax);
            _db.AddInParameter(cmd, "@JianMa", DbType.String, info.JianMa);
            _db.AddInParameter(cmd, "@LxrXml", DbType.String, CreateLxrXml(info.CustomerContact));
            _db.AddInParameter(cmd, "@YinHangZhangHuXml", DbType.String, CreateYinHangZhaoHaoXml(info.CustomerBank));
            _db.AddInParameter(cmd, "@FuJianXml", DbType.String, CreateFuJianXml(info.Annexs));
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
        /// 删除客户，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">当前操作人ZxsId</param>
        /// <param name="keHuId">客户编号</param>
        /// <returns></returns>
        public int KeHu_D(int companyId, string zxsId, string keHuId)
        {
            var cmd = _db.GetStoredProcCommand("proc_KeHu_D");
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, keHuId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
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
        /// (管理系统)客户联系人用户新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuMing">用户名</param>
        /// <param name="miMa">密码</param>
        /// <param name="md5MiMa">MD5密码</param>
        /// <param name="youXiang">邮箱</param>
        /// <returns></returns>
        public int KeHuLxrYongHu_CU(string keHuId, int lxrId, string yongHuMing, string miMa, string md5MiMa,string youXiang)
        {
            var cmd = _db.GetStoredProcCommand("proc_KeHuLxr_YongHu_CU");
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, keHuId);
            _db.AddInParameter(cmd, "@LxrId", DbType.Int32, lxrId);
            _db.AddInParameter(cmd, "@YongHuMing", DbType.String, yongHuMing);
            _db.AddInParameter(cmd, "@MiMa", DbType.String, miMa);
            _db.AddInParameter(cmd, "@Md5MiMa", DbType.String, md5MiMa);
            _db.AddInParameter(cmd, "@YouXiang", DbType.String, youXiang);
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
        /// (管理系统)客户联系人用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public int KeHulxrYonHu_D(string keHuId, int lxrId, int yongHuId)
        {
            var cmd = _db.GetStoredProcCommand("proc_KeHuLxr_YongHu_D");
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, keHuId);
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

        /// <summary>
        /// 获取客户联系人信息
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <returns></returns>
        public CustomerContactInfo GetKeHuLxrInfo(string keHuId, int lxrId)
        {
            CustomerContactInfo info = null;
            string sql = "SELECT A.* FROM tbl_CustomerContactInfo AS A WHERE A.CustomerId=@KeHuId AND ID=@KeHuLxrId ";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, keHuId);
            _db.AddInParameter(cmd, "KeHuLxrId", DbType.Int32, lxrId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    info = new CustomerContactInfo();
                    info.CustomerId = keHuId;
                    info.ContactId = lxrId;
                    info.CompanyId = rdr.GetInt32(rdr.GetOrdinal("CompanyId"));
                    info.Job = rdr["JobId"].ToString();
                    info.DepartId = rdr["DepartmentId"].ToString();
                    info.Sex = Toolkit.Utils.GetEnumValue<Model.EnumType.CompanyStructure.Sex>(rdr["Sex"].ToString(), EyouSoft.Model.EnumType.CompanyStructure.Sex.男);
                    info.Name = rdr["Name"].ToString();
                    info.Tel = rdr["Tel"].ToString();
                    info.Mobile = rdr["Mobile"].ToString();
                    info.qq = rdr["QQ"].ToString();
                    info.Email = rdr["Email"].ToString();
                    info.Spetialty = rdr["Spetialty"].ToString();
                    info.Hobby = rdr["Hobby"].ToString();
                    info.Remark = rdr["Remark"].ToString();
                    info.Fax = rdr["Fax"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("BirthDay"))) info.BirthDay = rdr.GetDateTime(rdr.GetOrdinal("BirthDay"));
                    info.Status = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.YongHuId = rdr.GetInt32(rdr.GetOrdinal("YongHuId"));
                    info.WeiXinHao = rdr["WeiXinHao"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 注册客户审核，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="shenHeRenId">审核人编号</param>
        /// <param name="sheHeShiJian">审核时间</param>
        /// <returns></returns>
        public int ZhuCeKeHuShenHe(int companyId, string keHuId, int shenHeRenId, DateTime sheHeShiJian)
        {
            string sql = "UPDATE tbl_Customer SET ShenHeStatus=@ShenHeStatus,ShenHeOperatorId=@ShenHeOperatorId,ShenHeTime=@ShenHeTime WHERE Id=@KeHuId AND CompanyId=@CompanyId";
            var cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "ShenHeStatus", DbType.Byte, EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.已审核);
            _db.AddInParameter(cmd, "ShenHeOperatorId", DbType.Int32, shenHeRenId);
            _db.AddInParameter(cmd, "ShenHeTime", DbType.DateTime, sheHeShiJian);
            _db.AddInParameter(cmd, "KeHuId", DbType.AnsiStringFixedLength, keHuId);
            _db.AddInParameter(cmd, "CompanyId", DbType.Int32, companyId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// （平台）客户注册，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int PT_KeHuZhuCe(MKeHuZhuCeInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_KeHu_ZhuCe");
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, info.KeHuId);
            _db.AddInParameter(cmd, "@KeHuName", DbType.String, info.KeHuName);
            _db.AddInParameter(cmd, "@KeHuShengFenId", DbType.Int32, info.KeHuShengFenId);
            _db.AddInParameter(cmd, "@KeHuChengShiId", DbType.Int32, info.KeHuChengShiId);
            _db.AddInParameter(cmd, "@KeHuDiZhi", DbType.String, info.KeHuDiZhi);
            _db.AddInParameter(cmd, "@KeHuDianHua", DbType.String, info.KeHuDianHua);
            _db.AddInParameter(cmd, "@KeHuFax", DbType.String, info.KeHuFax);
            _db.AddInParameter(cmd, "@YongHuMing", DbType.String, info.YongHuMing);
            _db.AddInParameter(cmd, "@YongHuYouXiang", DbType.String, info.YongHuYouXiang);
            _db.AddInParameter(cmd, "@YongHuXingMing", DbType.String, info.YongHuXingMing);
            _db.AddInParameter(cmd, "@YongHuDianHua", DbType.String, info.YongHuDianHua);
            _db.AddInParameter(cmd, "@YongHuShouJi", DbType.String, info.YongHuShouJi);
            _db.AddInParameter(cmd, "@YongHuMiMa", DbType.String, info.YongHuMiMa);
            _db.AddInParameter(cmd, "@YongHuMiMaMd5", DbType.String, info.YongHuMiMaMd5);
            _db.AddInParameter(cmd, "@ShenHeStatus", DbType.Byte, info.ShenHeStatus);
            _db.AddInParameter(cmd, "@LaiYuan", DbType.Byte, info.LaiYuan);
            _db.AddInParameter(cmd, "@LeiXing", DbType.Byte, info.LeiXing);
            _db.AddInParameter(cmd, "@ZhuCeShiJian", DbType.DateTime, info.ZhuCeShiJian);
            _db.AddInParameter(cmd, "@KeHuLxrStatus", DbType.Byte, info.KeHuLxrStatus);
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
        /// （平台）客户资料修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int PT_KeHuXiuGai(EyouSoft.Model.CompanyStructure.CustomerInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_Pt_KeHu_U");
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, info.Id);
            _db.AddInParameter(cmd, "@ShengFenId", DbType.Int32, info.ProviceId);
            _db.AddInParameter(cmd, "@ChengShiId", DbType.Int32, info.CityId);
            _db.AddInParameter(cmd, "@KeHuName", DbType.String, info.Name);
            _db.AddInParameter(cmd, "@XuKeZhengHao", DbType.String, info.Licence);
            _db.AddInParameter(cmd, "@DiZhi", DbType.String, info.Adress);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, info.CompanyId);
            _db.AddInParameter(cmd, "@LxrName", DbType.String, info.ContactName);
            _db.AddInParameter(cmd, "@LxrDianHua", DbType.String, info.Phone);
            _db.AddInParameter(cmd, "@LxrShouJi", DbType.String, info.Mobile);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@YingYeZhiZhaoHao", DbType.String, info.YingYeZhiZhaoHao);
            _db.AddInParameter(cmd, "@FaRenName", DbType.String, info.FaRenName);
            _db.AddInParameter(cmd, "@LxrQQ", DbType.String, info.LxrQQ);
            _db.AddInParameter(cmd, "@LxrEmail", DbType.String, info.LxrEmail);
            _db.AddInParameter(cmd, "@GongSiDianHua", DbType.String, info.GongSiDianHua);
            _db.AddInParameter(cmd, "@GongSiFax", DbType.String, info.GongSiFax);
            _db.AddInParameter(cmd, "@LogoFilepath", DbType.String, info.LogoFilepath);
            _db.AddInParameter(cmd, "@JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "@DanJuDaYinMoBan", DbType.String, info.DanJuDaYinMoBan);
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
        /// 客户联系人新增修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int KeHuLxr_CU(EyouSoft.Model.CompanyStructure.CustomerContactInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_KeHu_Lxr_CU");
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, info.CustomerId);
            _db.AddInParameter(cmd, "@KeHuLxrId", DbType.Int32, info.ContactId);
            _db.AddInParameter(cmd, "@XingMing", DbType.String, info.Name);
            _db.AddInParameter(cmd, "@XingBie", DbType.Byte, info.Sex);
            _db.AddInParameter(cmd, "@BuMen", DbType.String, info.DepartId);
            _db.AddInParameter(cmd, "@ZhiWu", DbType.String, info.Job);
            _db.AddInParameter(cmd, "@ShouJi", DbType.String, info.Mobile);
            _db.AddInParameter(cmd, "@DianHua", DbType.String, info.Tel);
            _db.AddInParameter(cmd, "@Fax", DbType.String, info.Fax);
            _db.AddInParameter(cmd, "@QQ", DbType.String, info.qq);
            _db.AddInParameter(cmd, "@WeiXinHao", DbType.String, info.WeiXinHao);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddOutParameter(cmd, "@KeHuLxrId1", DbType.Int32, 4);
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

            info.ContactId = Convert.ToInt32(_db.GetParameterValue(cmd, "KeHuLxrId1"));

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 客户联系人删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">操作人公司编号</param>
        /// <param name="zxsId">操作人专线商编号</param>
        /// <param name="operatorId">操作人编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="keHulxrId">客户联系人编号</param>
        /// <returns></returns>
        public int KeHuLxr_D(int companyId, string zxsId, int operatorId, string keHuId, int keHulxrId)
        {
            var cmd = _db.GetStoredProcCommand("proc_KeHu_Lxr_D");
            _db.AddInParameter(cmd, "@KeHuId", DbType.AnsiStringFixedLength, keHuId);
            _db.AddInParameter(cmd, "@KeHuLxrId", DbType.Int32, keHulxrId);
            _db.AddInParameter(cmd, "@CompanyId", DbType.Int32, companyId);
            _db.AddInParameter(cmd, "@ZxsId", DbType.AnsiStringFixedLength, zxsId);
            _db.AddInParameter(cmd, "@OperatorId", DbType.Int32, operatorId);
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
        #endregion
    }
}
