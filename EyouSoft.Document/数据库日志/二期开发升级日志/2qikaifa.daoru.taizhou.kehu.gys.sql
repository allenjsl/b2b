--654 kehu
--119 gys

--导入台州系统客户

SET XACT_ABORT ON
BEGIN TRAN

DECLARE @FROMCID INT
DECLARE @TOCID INT
DECLARE @NOW DATETIME
DECLARE @ZxsId CHAR(36)

SET @FROMCID=4
SET @TOCID=3
SET @NOW='2014-09-29 11:59:59'
SET @ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC'

DECLARE @TEMP1 TABLE(KeHuId CHAR(36),KeHuName NVARCHAR(255),IdentityId INT IDENTITY)
INSERT INTO @TEMP1(KeHuId,KeHuName)
SELECT Id,Name FROM tbl_Customer WHERE CompanyId=@FROMCID
DECLARE @KEHUCOUNT INT
SELECT @KEHUCOUNT=COUNT(*) FROM @TEMP1

DECLARE @i INT
SET @i=1

DECLARE @SUCCESS INT
SET @SUCCESS=0

WHILE(@i<=@KEHUCOUNT)
BEGIN
	DECLARE @KeHuId CHAR(36)
	DECLARE @KeHuName NVARCHAR(36)
	DECLARE @IsExists CHAR(1)
	SET @IsExists='0'
	
	SELECT @KeHuId=KeHuId,@KeHuName=KeHuName FROM @TEMP1 WHERE IdentityId=@i	
	SET @i=@i+1
	
	IF EXISTS(SELECT 1 FROM tbl_Customer WHERE CompanyId=@TOCID AND Name=@KeHuName)
	BEGIN
		SET @IsExists='1'
	END
	
	IF(@IsExists='1') CONTINUE
	
	DECLARE @NewKeHuId CHAR(36)
	SET @NewKeHuId=NEWID()
	
	DECLARE @ShengFenId INT
	DECLARE @ChengShiId INT
	
	SELECT @ShengFenId=[ProviceId],@ChengShiId=[CityId] FROM [tbl_Customer] WHERE Id=@KeHuId
	
	SELECT @ShengFenId=WZID FROM tbl_CompanyProvince WHERE Id=@ShengFenId
	SELECT @ChengShiId=WZID FROM tbl_CompanyCity WHERE Id=@ChengShiId
	
	SET @ShengFenId=ISNULL(@ShengFenId,0)
	SET @ChengShiId=ISNULL(@ChengShiId,0)
	
	DECLARE @ZeRenXiaoShouId INT
	SET @ZeRenXiaoShouId=0
	DECLARE @CaoZuoRenId INT
	SET @CaoZuoRenId=0
	
	INSERT [tbl_Customer]([Id],[ProviceId],[CityId],[Type],[Name],[Licence],[Adress],[PostalCode],[FilePath],[SaleId],[CompanyId],[IsEnable],[ContactName],[Phone],[Mobile],[Fax],[Remark],[OperatorId],[IssueTime],[IsDelete],[WZID],[ZxsId],[LaiYuan],[ShenHeStatus],[ShenHeOperatorId],[ShenHeTime],[YingYeZhiZhaoHao],[FaRenName],[LxrQQ],[LxrEmail],[GongSiDianHua],[GongSiFax],[JianMa],[Logo],[JieShao],[LatestOperatorId],[LatestTime],[DanJuDaYinMoBan])
	SELECT @NewKeHuId,@ShengFenId,@ChengShiId,[Type],[Name],[Licence],[Adress],[PostalCode],[FilePath],@ZeRenXiaoShouId,@TOCID,[IsEnable],[ContactName],[Phone],[Mobile],[Fax],[Remark],@CaoZuoRenId,@NOW,[IsDelete],'',@ZxsId,[LaiYuan],'1',[ShenHeOperatorId],[ShenHeTime],[YingYeZhiZhaoHao],[FaRenName],[LxrQQ],[LxrEmail],[GongSiDianHua],[GongSiFax],[JianMa],[Logo],[JieShao],@CaoZuoRenId,@NOW,[DanJuDaYinMoBan] 
	FROM [tbl_Customer] WHERE Id=@KeHuId
	
	INSERT INTO tbl_CustomerAccount([Id],[AccountName],[BankName],[BankNo])
	SELECT @NewKeHuId,[AccountName],[BankName],[BankNo]
	FROM tbl_CustomerAccount WHERE Id=@KeHuId
	
	INSERT INTO [tbl_CustomerContactInfo]([CustomerId],[CompanyId],[JobId],[DepartmentId],[Sex],[Name],[Tel],[Mobile],[qq],[BirthDay],[Email],[Spetialty],[Hobby],[Remark],[Fax],[YongHuId],[Status],[WeiXinHao])
	SELECT @NewKeHuId,@TOCID,[JobId],[DepartmentId],[Sex],[Name],[Tel],[Mobile],[qq],[BirthDay],[Email],[Spetialty],[Hobby],[Remark],[Fax],[YongHuId],2,[WeiXinHao]
	FROM [tbl_CustomerContactInfo] WHERE CustomerId=@KeHuId
	
	SET @SUCCESS=@SUCCESS+1
END

PRINT '成功导入'+CAST(@SUCCESS AS NVARCHAR(10))+'个客户'

COMMIT TRAN
SET XACT_ABORT OFF

GO



--导入台州系统供应商
SET XACT_ABORT ON
BEGIN TRAN

DECLARE @FROMCID INT
DECLARE @TOCID INT
DECLARE @NOW DATETIME
DECLARE @ZxsId CHAR(36)

SET @FROMCID=4
SET @TOCID=3
SET @NOW='2014-09-29 11:59:59'
SET @ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC'

DECLARE @TEMP1 TABLE(GysId CHAR(36),GysName NVARCHAR(255),IdentityId INT IDENTITY)
INSERT INTO @TEMP1(GysId,GysName)
SELECT Id,UnitName FROM tbl_CompanySupplier WHERE CompanyId=@FROMCID
DECLARE @GYSCOUNT INT
SELECT @GYSCOUNT=COUNT(*) FROM @TEMP1

DECLARE @i INT
SET @i=1

DECLARE @SUCCESS INT
SET @SUCCESS=0

WHILE(@i<=@GYSCOUNT)
BEGIN
	DECLARE @GysId CHAR(36)
	DECLARE @GysName NVARCHAR(36)
	DECLARE @IsExists CHAR(1)
	SET @IsExists='0'
	
	SELECT @GysId=GysId,@GysName=GysName FROM @TEMP1 WHERE IdentityId=@i	
	SET @i=@i+1
	
	IF EXISTS(SELECT 1 FROM tbl_CompanySupplier WHERE CompanyId=@TOCID AND UnitName=@GysName)
	BEGIN
		SET @IsExists='1'
	END
	
	IF(@IsExists='1') CONTINUE
	
	DECLARE @NewGysId CHAR(36)
	SET @NewGysId=NEWID()
	
	DECLARE @ShengFenId INT
	DECLARE @ChengShiId INT
	
	SELECT @ShengFenId=[ProvinceId],@ChengShiId=[CityId] FROM tbl_CompanySupplier WHERE Id=@GysId
	
	SELECT @ShengFenId=WZID FROM tbl_CompanyProvince WHERE Id=@ShengFenId
	SELECT @ChengShiId=WZID FROM tbl_CompanyCity WHERE Id=@ChengShiId
	
	SET @ShengFenId=ISNULL(@ShengFenId,0)
	SET @ChengShiId=ISNULL(@ChengShiId,0)
	
	DECLARE @CaoZuoRenId INT
	SET @CaoZuoRenId=0
	
	INSERT INTO [tbl_CompanySupplier]([Id],[ProvinceId],[CityId],[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],[CompanyId],[OperatorId],[IssueTime],[IsDelete],[WZID],[ZxsId])
	SELECT @NewGysId,@ShengFenId,@ChengShiId,[UnitName],[SupplierType],[LicenseKey],[AgreementFile],[UnitAddress],[UnitPolicy],[Remark],@TOCID,@CaoZuoRenId,@NOW,[IsDelete],'',@ZxsId
	FROM [tbl_CompanySupplier] WHERE Id=@GysId
	
	INSERT INTO [tbl_SupplierContact]([CompanyId],[SupplierId],[ContactName],[JobTitle],[ContactFax],[ContactTel],[ContactMobile],[QQ],[Email])
	SELECT @TOCID,@NewGysId,[ContactName],[JobTitle],[ContactFax],[ContactTel],[ContactMobile],[QQ],[Email]
	FROM [tbl_SupplierContact] WHERE [SupplierId]=@GysId
	
	INSERT INTO[tbl_SupplierAccessory]([SupplierId],[PicName],[PicPath])
	SELECT [SupplierId],[PicName],[PicPath]
	FROM [tbl_SupplierAccessory] WHERE [SupplierId]=@GysId
	
	INSERT INTO [tbl_SupplierSpot]([SupplierId],[Star],[TourGuide],[TeamPrice],[TravelerPrice])
	SELECT @NewGysId,[Star],[TourGuide],[TeamPrice],[TravelerPrice]
	FROM [tbl_SupplierSpot] WHERE [SupplierId]=@GysId
	
	INSERT INTO [tbl_SupplierBank]([SupplierId],[AccountName],[Bank],[BankAccount])
	SELECT @NewGysId,[AccountName],[Bank],[BankAccount]
	FROM [tbl_SupplierBank] WHERE [SupplierId]=@GysId
	
	INSERT INTO [tbl_SupplierHotel]([SupplierId],[Star],[Introduce],[TourGuide])
	SELECT @NewGysId,[Star],[Introduce],[TourGuide]
	FROM [tbl_SupplierHotel] WHERE [SupplierId]=@GysId
	
	INSERT INTO [tbl_SupplierHotelRoomType]([SupplierId],[Name],[SellingPrice],[AccountingPrice],[IsBreakfast])
	SELECT @NewGysId,[Name],[SellingPrice],[AccountingPrice],[IsBreakfast]
FROM [tbl_SupplierHotelRoomType] WHERE [SupplierId]=@GysId
	
	SET @SUCCESS=@SUCCESS+1
END


PRINT '成功导入'+CAST(@SUCCESS AS NVARCHAR(10))+'个供应商'
COMMIT TRAN
SET XACT_ABORT OFF

GO
