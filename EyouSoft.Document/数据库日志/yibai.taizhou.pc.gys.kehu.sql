--温州壹佰-台州系统数据导入-供应商、客户、基础数据导入 
--汪奇志 10 14 2013  4:31PM

DECLARE @YuanCompanyId INT
DECLARE @ToCompanyId INT
DEClARE @Time DATETIME

SET @YuanCompanyId=3
SET @ToCompanyId=4
SET @Time='2013-10-14 00:00:08'

--省份城市
DELETE FROM [tbl_CompanyCity] WHERE CompanyId=@ToCompanyId
DELETE FROM [tbl_CompanyProvince] WHERE CompanyId=@ToCompanyId

DECLARE @i INT--计数器
DECLARE @ProvinceId INT--公司省份编号
DECLARE @ProvinceCount INT--省份数量
DECLARE @table TABLE(IdentityId INT IDENTITY,[Id] INT
,[ProvinceName] NVARCHAR(255))

INSERT INTO @table(id,provincename)
SELECT id,provincename
FROM [tbl_CompanyProvince] where CompanyId=@YuanCompanyId

SELECT @ProvinceCount=COUNT(*) FROM @table
SET @i=1

WHILE(@i<=@ProvinceCount)
BEGIN
	INSERT INTO [tbl_CompanyProvince]([ProvinceName],[CompanyId],[OperatorId],issuetime,wzid)
	SELECT [ProvinceName],@ToCompanyId,0,@Time,id FROM @table WHERE IdentityId=@i	
	SET @ProvinceId=@@IDENTITY			

	INSERT INTO [tbl_CompanyCity] ([ProvinceId],[CityName],[CompanyId],[IsFav],[OperatorId],issuetime,diqu,wzid)
	SELECT @ProvinceId,[CityName],@ToCompanyId,IsFav,0,@Time,diqu,id FROM tbl_CompanyCity WHERE [ProvinceId]=(SELECT Id FROM @table WHERE IdentityId=@i)
	SET @i=@i+1
END


--供应商
INSERT INTO [tbl_CompanySupplier]([Id],[ProvinceId],[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],[CompanyId],[OperatorId],[IssueTime],[IsDelete],[WZID])
SELECT NEWID(),ISNULL((SELECT A1.Id FROM tbl_CompanyProvince AS A1 WHERE A1.WZID=A.ProvinceId),0),ISNULL((SELECT A1.Id FROM tbl_CompanyCity AS A1 WHERE A1.WZID=A.[CityId]),0),A.[UnitName],A.[SupplierType],A.[LicenseKey],A.[AgreementFile],A.[UnitAddress],A.[UnitPolicy],A.[Remark],@ToCompanyId,0,@Time,A.[IsDelete],A.[Id]
FROM [tbl_CompanySupplier] AS A 
WHERE A.CompanyId=@YuanCompanyId

INSERT INTO [tbl_SupplierContact]([CompanyId],[SupplierId],[ContactName],[JobTitle],[ContactFax],[ContactTel],[ContactMobile],[QQ],[Email])
SELECT @ToCompanyId,B.Id,A.[ContactName],A.[JobTitle],A.[ContactFax],A.[ContactTel],A.[ContactMobile],A.[QQ],A.[Email]
FROM [tbl_SupplierContact] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.WZID

INSERT INTO [tbl_SupplierAccessory]([SupplierId],[PicName],[PicPath])
SELECT B.Id,A.[PicName],A.[PicPath]
FROM [tbl_SupplierAccessory] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.WZID

INSERT INTO [tbl_SupplierSpot]([SupplierId],[Star],[TourGuide],[TeamPrice],[TravelerPrice])
SELECT B.Id,A.[Star],A.[TourGuide],A.[TeamPrice],A.[TravelerPrice]
FROM [tbl_SupplierSpot] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.WZID

INSERT INTO [tbl_SupplierBank]([SupplierId],[AccountName],[Bank],[BankAccount])
SELECT B.Id,A.[AccountName],A.[Bank],A.[BankAccount]
FROM [tbl_SupplierBank] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.WZID

INSERT INTO [tbl_SupplierHotel]([SupplierId],[Star],[Introduce],[TourGuide])
SELECT B.Id,A.[Star],A.[Introduce],A.[TourGuide]
FROM [tbl_SupplierHotel] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.WZID

INSERT INTO [tbl_SupplierHotelRoomType]([SupplierId],[Name],[SellingPrice],[AccountingPrice],[IsBreakfast])
SELECT B.Id,A.[Name],A.[SellingPrice],A.[AccountingPrice],A.[IsBreakfast]
FROM [tbl_SupplierHotelRoomType] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.WZID


--客户
INSERT INTO [tbl_Customer]([Id],[ProviceId],[CityId],[Type],[Name],[Licence],[Adress],[PostalCode],[FilePath],[SaleId],[CompanyId],[IsEnable],[ContactName],[Phone],[Mobile],[Fax],[Remark],[OperatorId],[IssueTime],[IsDelete],[WZID])
SELECT NEWID(),ISNULL((SELECT A1.Id FROM tbl_CompanyProvince AS A1 WHERE A1.WZID=A.ProviceId),0),ISNULL((SELECT A1.Id FROM tbl_CompanyCity AS A1 WHERE A1.WZID=A.[CityId]),0),A.[Type],A.[Name],A.[Licence],A.[Adress],A.[PostalCode],A.[FilePath],0,@ToCompanyId,A.[IsEnable],A.[ContactName],A.[Phone],A.[Mobile],A.[Fax],A.[Remark],0,@Time,A.[IsDelete],A.Id
FROM [tbl_Customer] AS A 
WHERE A.CompanyId=@YuanCompanyId

INSERT INTO [tbl_CustomerContactInfo]([CustomerId],[CompanyId],[JobId],[DepartmentId],[Sex],[Name],[Tel],[Mobile],[qq],[BirthDay],[Email],[Spetialty],[Hobby],[Remark],[Fax])
SELECT B.Id,@ToCompanyId,A.[JobId],A.[DepartmentId],A.[Sex],A.[Name],A.[Tel],A.[Mobile],A.[qq],A.[BirthDay],A.[Email],A.[Spetialty],A.[Hobby],A.[Remark],A.[Fax]
FROM [tbl_CustomerContactInfo] AS A INNER JOIN [tbl_Customer] AS B
ON A.[CustomerId]=B.[WZID]

INSERT INTO [tbl_CustomerAccount]([Id],[AccountName],[BankName],[BankNo])
SELECT B.[Id],A.[AccountName],A.[BankName],A.[BankNo]
FROM [tbl_CustomerAccount] AS A INNER JOIN [tbl_Customer] AS B
ON A.[Id]=B.[WZID]

--其它基础数据
INSERT INTO [tbl_Area]([AreaName],[CompanyId],[OperatorId],[IssueTime],[IsDelete],[SortId])
SELECT A.[AreaName],@ToCompanyId,0,@Time,[IsDelete],[SortId]
FROM [tbl_Area] AS A WHERE A.CompanyId=@YuanCompanyId

INSERT INTO [tbl_CompanyTraffic]([CompanyId],[TrafficName])
SELECT @ToCompanyId,A.[TrafficName]
FROM [tbl_CompanyTraffic] AS A WHERE A.CompanyId=@YuanCompanyId

INSERT INTO [tbl_ComJiChuXinXi]([CompanyId],[Name],[Type],[IssueTime],[OperatorId],[T1],[IsDelete],[T2])
SELECT @ToCompanyId,A.[Name],A.[Type],@Time,0,A.[T1],A.[IsDelete],A.[T2]
FROM [tbl_ComJiChuXinXi] AS A WHERE A.CompanyId=@YuanCompanyId

/*
select * from tbl_companycity where companyid=3
select * from tbl_companyprovince where companyid=3
select * from tbl_companysupplier where companyid=3
select * from tbl_customer where companyid=3

SELECT 3,B.Id,A.[ContactName],A.[JobTitle],A.[ContactFax],A.[ContactTel],A.[ContactMobile],A.[QQ],A.[Email]
FROM [tbl_SupplierContact] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.Id
WHERE B.CompanyId=3

SELECT B.Id,A.[PicName],A.[PicPath]
FROM [tbl_SupplierAccessory] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.Id
WHERE B.CompanyId=3

SELECT B.Id,A.[Star],A.[TourGuide],A.[TeamPrice],A.[TravelerPrice]
FROM [tbl_SupplierSpot] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.Id
WHERE B.Companyid=3

SELECT B.Id,A.[AccountName],A.[Bank],A.[BankAccount]
FROM [tbl_SupplierBank] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.Id
WHERE B.Companyid=3

SELECT B.Id,A.[Star],A.[Introduce],A.[TourGuide]
FROM [tbl_SupplierHotel] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.Id
WHERE B.Companyid=3

SELECT B.Id,A.[Name],A.[SellingPrice],A.[AccountingPrice],A.[IsBreakfast]
FROM [tbl_SupplierHotelRoomType] AS A INNER JOIN [tbl_CompanySupplier] AS B
ON A.SupplierId=B.Id
WHERE B.Companyid=3


SELECT B.Id,A.[JobId],A.[DepartmentId],A.[Sex],A.[Name],A.[Tel],A.[Mobile],A.[qq],A.[BirthDay],A.[Email],A.[Spetialty],A.[Hobby],A.[Remark],A.[Fax]
FROM [tbl_CustomerContactInfo] AS A INNER JOIN [tbl_Customer] AS B
ON A.[CustomerId]=B.[Id]
where b.companyid=3

SELECT B.[Id],A.[AccountName],A.[BankName],A.[BankNo]
FROM [tbl_CustomerAccount] AS A INNER JOIN [tbl_Customer] AS B
ON A.[Id]=B.[Id]
where b.companyid=3

select * from [tbl_Area] where companyid=3
select * from [tbl_CompanyTraffic] where companyid=3
select * from [tbl_ComJiChuXinXi] where companyid=3 and isdelete='0'
*/
