GO
ALTER TABLE dbo.tbl_CompanyUser ADD
	GysId char(36) NOT NULL CONSTRAINT DF_tbl_CompanyUser_GysId DEFAULT '',
	GysLxrId int NOT NULL CONSTRAINT DF_tbl_CompanyUser_GysLxrId DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'供应商编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'GysId'
GO
DECLARE @v sql_variant 
SET @v = N'供应商联系人编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'GysLxrId'
GO

ALTER TABLE dbo.tbl_SupplierContact ADD
	YongHuId int NOT NULL CONSTRAINT DF_tbl_SupplierContact_YongHuId DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'用户编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_SupplierContact', N'COLUMN', N'YongHuId'
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-12
-- Description:	供应商联系人账号新增、修改
-- =============================================
CREATE PROCEDURE proc_GysLxr_YongHu_CU
	@GysId CHAR(36)
	,@LxrId INT
	,@CaoZuoRenId INT
	,@YongHuMing NVARCHAR(255)
	,@MiMa NVARCHAR(255)
	,@MD5MiMa NVARCHAR(255)
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @YongHuId INT
	DECLARE @CompanyId INT
	DECLARE @ZxsId CHAR(36)
	
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_CompanySupplier WHERE Id=@GysId AND IsDelete='0')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	IF NOT EXISTS(SELECT 1 FROM tbl_SupplierContact WHERE ID=@LxrId AND SupplierId=@GysId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	SELECT @CompanyId=CompanyId,@ZxsId=ZxsId FROM tbl_CompanySupplier WHERE Id=@GysId
	SELECT @YongHuId=YongHuId FROM tbl_SupplierContact WHERE ID=@LxrId
	
	IF EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE CompanyId=@CompanyId AND ID<>@YongHuId AND Username=@YongHuMing)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF(@YongHuId=0)
	BEGIN
		INSERT INTO [tbl_CompanyUser]([CompanyId],[UserName],[Password]
			,[MD5Password],[ContactName],[ContactSex]
			,[ContactTel],[ContactFax],[ContactMobile]
			,[ContactEmail],[QQ],[MSN]
			,[JobName],[LastLoginIP],[LastLoginTime]
			,[RoleID],[PermissionList],[PeopProfile]
			,[Remark],[IsDelete],[UserStatus]
			,[IsAdmin],[IssueTime],[DepartId]
			,[SuperviseDepartId],[OnlineStatus],[OnlineSessionId]
			,[LeiXing],[ZxsId],[KeHuId]
			,[KeHuLxrId],[GysId],[GysLxrId])
		SELECT @CompanyId,@YongHuMing,@MiMa
			,@Md5MiMa,A.ContactName,'1'
			,A.ContactTel,A.ContactFax,A.ContactMobile
			,'',A.QQ,''
			,'','',GETDATE()
			,0,'',''
			,'','0',1
			,'0',GETDATE(),0
			,0,0,''
			,4,'',@ZxsId
			,0,@GysId,@LxrId
		FROM tbl_SupplierContact AS A
		WHERE A.Id=@LxrId
		SET @YongHuId=SCOPE_IDENTITY()
		
		UPDATE tbl_SupplierContact SET YongHuId=@YongHuId WHERE Id=@LxrId
	END
	ELSE
	BEGIN
		IF(LEN(@MiMa)>0 AND LEN(@Md5MiMa)>0)
		BEGIN
			UPDATE [tbl_CompanyUser] SET [Password]=@MiMa,[MD5Password]=@Md5MiMa WHERE Id=@YongHuId
		END
		
		UPDATE tbl_SupplierContact SET YongHuId=@YongHuId WHERE Id=@LxrId
	END
	
	SET @RetCode=1
	RETURN @RetCode
END
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-12
-- Description:	供应商联系人账号删除
-- =============================================
CREATE PROCEDURE [dbo].[proc_GysLxr_YongHu_D]
	@GysId CHAR(36)
	,@LxrId INT
	,@YongHuId INT
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_CompanySupplier WHERE Id=@GysId AND IsDelete='0')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_SupplierContact WHERE ID=@LxrId AND SupplierId=@GysId AND YongHuId=@YongHuId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE Id=@YongHuId AND GysId=GysId)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	
	UPDATE tbl_CompanyUser SET IsDelete='1',Username='_'+CAST(@YongHuId AS NVARCHAR(50))+'_'+Username,ContactEmail='_'+CAST(@YongHuId AS NVARCHAR(50))+'_'+ContactEmail WHERE Id=@YongHuId AND GysId=@GysId
	UPDATE tbl_SupplierContact SET YongHuId=0 WHERE Id=@LxrId AND SupplierId=@GysId
	
	SET @RetCode=1
	RETURN @RetCode	
END
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-12
-- Description: 供应商-用户
-- =============================================
CREATE VIEW [dbo].[view_Gys_YongHu]
AS
SELECT A.Id AS GysLxrId
	,A.SupplierId AS GysId
	,A.CompanyId
	,A.ContactName AS XingMing
	,A.ContactTel AS DianHua
	,A.ContactMobile AS ShouJi
	,A.QQ
	,A.ContactFax
	,A.YongHuId
	,B.UserName AS YongHuMing
	,ISNULL(B.LeiXing,4) AS LeiXing
	,C.UnitName AS GysName
	,B.UserStatus AS YongHuStatus
	,C.SupplierType AS GysLeiXing
	,C.ZxsId
FROM tbl_SupplierContact AS A LEFT OUTER JOIN tbl_CompanyUser AS B
ON A.YongHuId=B.Id AND A.SupplierId=B.GysId AND A.CompanyId=B.CompanyId
LEFT OUTER JOIN tbl_CompanySupplier AS C
ON A.SupplierId=C.Id

GO

/****** Object:  Table [dbo].[tbl_Gys_YongHuLoginLog]    Script Date: 05/13/2015 10:39:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Gys_YongHuLoginLog](
	[LogId] [char](36) NOT NULL,
	[GysId] [char](36) NOT NULL,
	[YongHuId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[LoginTime] [datetime] NOT NULL,
	[LoginIp] [nvarchar](20) NULL,
	[UserAgent] [nvarchar](max) NULL,
	[LoginLeiXing] [tinyint] NOT NULL,
 CONSTRAINT [PK_TBL_GYS_YONGHULOGINLOG] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog', @level2type=N'COLUMN',@level2name=N'LogId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog', @level2type=N'COLUMN',@level2name=N'GysId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog', @level2type=N'COLUMN',@level2name=N'YongHuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog', @level2type=N'COLUMN',@level2name=N'LoginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog', @level2type=N'COLUMN',@level2name=N'LoginIp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求头信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog', @level2type=N'COLUMN',@level2name=N'UserAgent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog', @level2type=N'COLUMN',@level2name=N'LoginLeiXing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商用户登录日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_YongHuLoginLog'
GO
/****** Object:  Default [DF__tbl_Gys_Y__Login__721CCC2B]    Script Date: 05/13/2015 10:39:18 ******/
ALTER TABLE [dbo].[tbl_Gys_YongHuLoginLog] ADD  CONSTRAINT [DF__tbl_Gys_Y__Login__721CCC2B]  DEFAULT (getdate()) FOR [LoginTime]
GO
/****** Object:  Default [DF__tbl_Gys_Y__Login__7310F064]    Script Date: 05/13/2015 10:39:18 ******/
ALTER TABLE [dbo].[tbl_Gys_YongHuLoginLog] ADD  CONSTRAINT [DF__tbl_Gys_Y__Login__7310F064]  DEFAULT ((0)) FOR [LoginLeiXing]
GO

ALTER TABLE dbo.tbl_PlanDiJie ADD
	DiJieQueRenStatus int NOT NULL CONSTRAINT DF_tbl_PlanDiJie_DiJieQueRenStatus DEFAULT 0,
	DiJieQueRenRenId int NOT NULL CONSTRAINT DF_tbl_PlanDiJie_DiJieQueRenRenId DEFAULT 0,
	DiJieQueRenTime datetime NULL,
	DiJieRouteName nvarchar(255) NULL,
	DiJieTuanHao nvarchar(255) NULL,
	NeiBuBeiZhu nvarchar(MAX) NULL,
	DaoYouName nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'地接确认状态'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DiJieQueRenStatus'
GO
DECLARE @v sql_variant 
SET @v = N'地接确认人编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DiJieQueRenRenId'
GO
DECLARE @v sql_variant 
SET @v = N'地接确认时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DiJieQueRenTime'
GO
DECLARE @v sql_variant 
SET @v = N'地接线路名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DiJieRouteName'
GO
DECLARE @v sql_variant 
SET @v = N'地接团号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DiJieTuanHao'
GO
DECLARE @v sql_variant 
SET @v = N'安排内部备注'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'NeiBuBeiZhu'
GO
DECLARE @v sql_variant 
SET @v = N'导游姓名'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DaoYouName'
GO

ALTER TABLE dbo.tbl_PlanDiJie ADD
	DiJieCaoZuoRenId int NOT NULL CONSTRAINT DF_tbl_PlanDiJie_DiJieCaoZuoRenId DEFAULT 0,
	DiJieCaoZuoTime datetime NULL
GO
DECLARE @v sql_variant 
SET @v = N'地接操作人编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DiJieCaoZuoRenId'
GO
DECLARE @v sql_variant 
SET @v = N'地接操作时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DiJieCaoZuoTime'
GO

-- =============================================
-- Author:		<王磊>
-- Create date: <2011-11-16>
-- Description:	<添加地接安排>
--Result:
-- -1:已经安排地接的订单 不能重新安排
-- -2:当订单性质为团队时，一次只能选择一个订单进行地接安排
-- -3:当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
-- 1:安排成功 
-- 0:安排失败
-- History:
-- 1.2013-01-15 汪奇志 去掉导游的设置
-- 2.2013-01-24 汪奇志 增加@YouKeXinXi
-- 3.2013-02-26 汪奇志 增加控位状态的控制
-- 4.2015-05-22 汪奇志 增加@NeiBuBeiZhu
-- =============================================
ALTER proc [dbo].[proc_PlanDiJie_Add]
	@PlanId char(36)
	,@CompanyId int
	,@KongWeiId char(36)
	,@JiaoYiHao nvarchar(50) 
	,@GysId char(36)
	,@RouteId char(36) 
	,@LxrName nvarchar(50)
	,@LxrTelephone nvarchar(50)
	,@ChengRenShu int
	,@ErTongShu int
	,@QuPeiShu int 
	,@QuPeiName nvarchar(50)
	--,@DaoYouId int
	,@YongCan nvarchar(255)
	,@JieSuanMX nvarchar(255) 
	,@JieSuanAmount money
	,@JieTuanFangShi nvarchar(255)
	,@OperatorId int
	,@Remark nvarchar(MAX)
	,@OrderIds nvarchar(max)
	,@Result int output
	,@YouKeXinXi NVARCHAR(MAX)--游客信息
	,@ZxsId CHAR(36)
	,@YingErShu INT
	,@NeiBuBeiZhu NVARCHAR(MAX)
as
begin
	declare @error int
	set @error=0

	if exists(select 1 from tbl_PlanDiJIeOrder where OrderId in (select [value] from dbo.fn_split(@OrderIds,',')))
	begin
		set @Result=-1	  --已经安排地接的订单 不能重新安排
		return @Result
	end

	declare @BusinessNature tinyint	--订单性质  散拼 = 0,组团 = 1
	select @BusinessNature=BusinessNature from tbl_TourOrder 
	where OrderId=(select top 1 [value] from dbo.fn_split(@OrderIds,','))

	if(@BusinessNature=1)
	begin
		declare @tuanduiordercount int
		select @tuanduiordercount=count(1) from dbo.fn_split(@OrderIds,',') 
		if(@tuanduiordercount<>1)
		begin
			set @Result=-2	  --当订单性质为团队时，一次只能选择一个订单进行地接安排
			return @Result 
		end
	end

	if(@BusinessNature=0)
	begin
		declare @sanpinordercount int
--		 select @sanpinordercount= count(RouteId) from tbl_TourOrder 
--		 where OrderId in (select [value] from dbo.fn_split(@OrderIds,','))
--		 group by RouteId
		select @sanpinordercount=count(distinct(RouteId)) from tbl_TourOrder
		where OrderId in (select [value] from dbo.fn_split(@OrderIds,','))
		if(@sanpinordercount<>1)
		begin
			set @Result=-3	  --当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
			return @Result 
		end
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END
	
	begin transaction	
	--生成交易号（团号）
	set @JiaoYiHao=dbo.fn_TourCode(@KongWeiId)

	INSERT INTO tbl_PlanDiJie(PlanId,CompanyId,KongWeiId
		,JiaoYiHao,GysId,RouteId
		,LxrName,LxrTelephone,ChengRenShu
		,ErTongShu,QuPeiShu,QuPeiName
		,YongCan,JieSuanMX,JieSuanAmount
		,JieTuanFangShi,OperatorId,Remark
		,IssueTime,[YouKeXinXi],[ZxsId]
		,YingErShu,[NeiBuBeiZhu])
     VALUES(@PlanId,@CompanyId,@KongWeiId
		,@JiaoYiHao,@GysId,@RouteId
		,@LxrName,@LxrTelephone,@ChengRenShu
		,@ErTongShu,@QuPeiShu,@QuPeiName
		,@YongCan,@JieSuanMX,@JieSuanAmount
		,@JieTuanFangShi,@OperatorId,@Remark
		,getdate(),@YouKeXinXi,@ZxsId
		,@YingErShu,@NeiBuBeiZhu)
	set @error=@error+@@error

	IF(@error=0)
	BEGIN
		INSERT INTO tbl_PlanDiJIeOrder(PlanId,OrderId)
		select @PlanId,[value] from dbo.fn_split(@OrderIds,',')
		set @error=@error+@@error
	END
	
	IF(@error<>0)
	BEGIN
		set @Result=0
		rollback transaction
		RETURN @Result
	END

	set @Result=1
	commit transaction
	
	return @Result
end
GO

-- =============================================
-- Author:		<王磊>
-- Create date: <2011-11-16>
-- Description:	<修改地接安排>
--Result:
--	-1:已经安排地接的订单 不能重新安排
--  -2:当订单性质为团队时，一次只能选择一个订单进行地接安排
--  -3:当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
--1:修改成功 0:修改失败
-- History:
-- 1.2013-01-15 汪奇志 去掉导游的设置
-- 2.2013-01-24 汪奇志 增加@YouKeXinXi
-- 3.2013-02-26 汪奇志 增加控位状态的控制	
-- 4.2015-05-22 汪奇志 增加@NeiBuBeiZhu
-- =============================================
ALTER proc [dbo].[proc_PlanDiJie_Update]
	@PlanId char(36) 
	,@CompanyId int
	,@KongWeiId char(36)
	,@JiaoYiHao nvarchar(50)
	,@GysId char(36)
	,@RouteId char(36)
	,@LxrName nvarchar(50)
	,@LxrTelephone nvarchar(50)
	,@ChengRenShu int
	,@ErTongShu int
	,@QuPeiShu int
	,@QuPeiName nvarchar(50)
	--@DaoYouId int 
	,@YongCan nvarchar(255)
	,@JieSuanMX nvarchar(255)
	,@JieSuanAmount money 
	,@JieTuanFangShi nvarchar(255)
	,@OperatorId int
	,@Remark nvarchar(MAX)
	,@OrderIds nvarchar(max)
	,@Result int output
	,@YouKeXinXi NVARCHAR(MAX)--游客信息
	,@YingErShu INT
	,@NeiBuBeiZhu NVARCHAR(MAX)
as
begin
	declare @error int
	set @error=0

	if exists(select 1 from tbl_PlanDiJIeOrder where PlanId<>@PlanId and OrderId in(select [value] from dbo.fn_split(@OrderIds,',')))
	begin
		set @Result=-1	  --已经安排地接的订单 不能重新安排
		return @Result
	end

	declare @BusinessNature tinyint	--订单性质  散拼 = 0,组团 = 1
	select @BusinessNature=BusinessNature from tbl_TourOrder 
	where OrderId=(select top 1 [value] from dbo.fn_split(@OrderIds,','))

	if(@BusinessNature=1)
	begin
		declare @tuanduiordercount int
		select @tuanduiordercount=count(1) from dbo.fn_split(@OrderIds,',') 
		if(@tuanduiordercount<>1)
		begin
			set @Result=-2	  --当订单性质为团队时，一次只能选择一个订单进行地接安排
			return @Result 
		end
	end

	if(@BusinessNature=0)
	begin
		 declare @sanpinordercount int
--		 select @sanpinordercount= count(RouteId) from tbl_TourOrder 
--		 where OrderId in (select [value] from dbo.fn_split(@OrderIds,','))
--		 group by RouteId
		 select @sanpinordercount=count(distinct(RouteId)) from tbl_TourOrder
		 where OrderId in (select [value] from dbo.fn_split(@OrderIds,','))
		 if(@sanpinordercount<>1)
		 begin
			set @Result=-3	  --当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
			return @Result 
		 end
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END
	
	begin transaction	
	
	UPDATE tbl_PlanDiJie SET GysId = @GysId,LxrName = @LxrName,LxrTelephone = @LxrTelephone
		,ChengRenShu = @ChengRenShu,ErTongShu = @ErTongShu	,QuPeiShu = @QuPeiShu
		,QuPeiName = @QuPeiName,YongCan = @YongCan,JieSuanMX = @JieSuanMX
		,JieSuanAmount = @JieSuanAmount	,JieTuanFangShi = @JieTuanFangShi,Remark = @Remark
		,RouteId=@RouteId,[YouKeXinXi]=@YouKeXinXi,YingErShu=@YingErShu
		,[NeiBuBeiZhu]=@NeiBuBeiZhu
	WHERE PlanId = @PlanId
	set @error=@error+@@error

	DELETE From  tbl_PlanDiJIeOrder where PlanId=@PlanId
	set @error=@error+@@error

	INSERT INTO tbl_PlanDiJIeOrder(PlanId,OrderId)
	select @PlanId,[value] from dbo.fn_split(@OrderIds,',')
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end	
	return @Result
end
GO

-- =============================================
-- Author:		
-- Create date: 
-- Description:已安排地接视图
-- History:
-- 1.2013-01-05 汪奇志 增加[OperatorId],[OperatorName]
-- 2.2013-01-28 汪奇志 SUM(CollectionRefundAmount)
-- 3.2015-01-21 汪奇志 增加A.IssueTime
-- =============================================
ALTER view [dbo].[view_PlanDiJie]
AS
SELECT 
	 A.PlanId
	,A.KongWeiId
	,A.ChengRenShu
	,A.ErTongShu
	,A.QuPeiShu
	,A.JieTuanFangShi
	,A.JieSuanAmount
	,A.JiaoYiHao
	,(SELECT UnitName FROM  tbl_CompanySupplier AS B WHERE B.Id=A.GysId) AS GysName
	,(SELECT RouteName FROM tbl_Route AS B WHERE B.RouteId=A.RouteId) AS RouteName
	--,(SELECT ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.DaoYouId) AS DaoYouName
	,A.DaoYouName
	,(SELECT ISNULL(SUM(CollectionRefundAmount),0) FROM tbl_FinCope AS B WHERE B.CollectionId=A.PlanId AND B.CollectionItem=102 AND B.[Status]=2) AS PayAmount 
	,A.OperatorId
	,(SELECT ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.OperatorId) AS OperatorName
	,A.YingErShu
	,A.IssueTime
	,A.[DiJieQueRenStatus]
	,A.[DiJieQueRenRenId]
	,A.[DiJieQueRenTime]
	,A.[DiJieRouteName]
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.[DiJieQueRenRenId]) AS DiJieQueRenRenName
FROM tbl_PlanDiJie  AS A

GO


ALTER TABLE dbo.tbl_PlanDiJie ADD
	DaoYouName1 nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'导游姓名1（用于防止供应商随意修改导游姓名用）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'DaoYouName1'
GO

--更新地接安排确认状态
UPDATE tbl_PlanDiJie SET DiJieQueRenStatus=1,DiJieQueRenRenId=0,DiJieQueRenTime='2015-05-22'
GO
--更新地接安排导游信息
UPDATE tbl_PlanDiJie SET DaoYouName=B.ContactName,DaoYouName1=B.ContactName 
FROM tbl_PlanDiJie AS A INNER JOIN tbl_CompanyUser AS B
ON A.DaoYouId=B.Id
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2012-11-20
-- Description:应付地接视图
-- History:
-- 1.2013-05-22 汪奇志 增加[DaoYouName]
-- =============================================
ALTER VIEW [dbo].[view_Fin_YingFuDiJie]
AS
SELECT A.PlanId,A.CompanyId,A.KongWeiId
	,A.JiaoYiHao,A.GysId,A.RouteId
	,A.ChengRenShu,A.ErTongShu,A.QuPeiShu
	,A.JieSuanMX,A.JieSuanAmount,A.IssueTime
	,B.KongWeiCode,B.QuTime,B.QuDate,(SELECT TOP 1 C.ContactName,C.ContactTel FROM tbl_SupplierContact C WHERE C.SupplierId=A.GysId ORDER BY C.Id ASC FOR XML RAW,ROOT) AS ContactInfo
	,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=0),0) AS WeiShenPiJinE--未审批金额
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=1),0) AS YiShenPiJinE--已审批(未支付)金额
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=2),0) AS YiZhiFuJinE--已支付金额
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName--供应商名称
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHErE A1.Id=A.DaoYouId) AS DaoYouName--导游姓名
	,B.ZxsId
	,A.YingErShu
	,A.[DiJieQueRenStatus]
	,A.[DiJieQueRenRenId]
	,A.[DiJieQueRenTime]
	,A.[DiJieRouteName]
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.[DiJieQueRenRenId]) AS DiJieQueRenRenName
FROM tbl_PlanDiJie AS A INNER JOIN tbl_KongWei AS B
ON A.KongWeiId=B.KongWeiId

GO

ALTER TABLE dbo.tbl_Pt_YuMing ADD
	LeiXing int NOT NULL CONSTRAINT DF_tbl_Pt_YuMing_LeiXing DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'域名类型'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Pt_YuMing', N'COLUMN', N'LeiXing'
GO
UPDATE tbl_Pt_YuMing SET LeiXing=1
GO


/****** Object:  Table [dbo].[tbl_Gys_ZhuTi]    Script Date: 05/25/2015 11:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Gys_ZhuTi](
	[GysId] [char](36) NOT NULL,
	[LeiXing] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ZxsId] [char](36) NOT NULL,
	[GysName] [nvarchar](255) NULL,
	[ShengFenId] [int] NOT NULL,
	[ChengShiId] [int] NOT NULL,
	[JieShao] [nvarchar](max) NULL,
	[CaoZuoRenId] [int] NOT NULL,
	[IssueTime] [datetime] NOT NULL,
	[IsDelete] [char](1) NOT NULL,
	[LxrName] [nvarchar](255) NULL,
	[LxrDianHua] [nvarchar](255) NULL,
	[LxrShouJi] [nvarchar](255) NULL,
	[DiZhi] [nvarchar](255) NULL,
	[Fax] [nvarchar](255) NULL,
 CONSTRAINT [PK_TBL_GYS_ZHUTI] PRIMARY KEY CLUSTERED 
(
	[GysId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商主体编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'GysId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'LeiXing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主专线商编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'ZxsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商主体名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'GysName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'ShengFenId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'ChengShiId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商介绍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'JieShao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'CaoZuoRenId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'IssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'LxrName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'LxrDianHua'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'LxrShouJi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'DiZhi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi', @level2type=N'COLUMN',@level2name=N'Fax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商主体信息（不同专线商有各自不同的供应商，供应商主体用于统一各专线商的供应商信息）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi'
GO
/****** Object:  Table [dbo].[tbl_Gys_ZhuTi_GuanXi]    Script Date: 05/25/2015 11:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Gys_ZhuTi_GuanXi](
	[IdentityId] [int] IDENTITY(1,1) NOT NULL,
	[GysId1] [char](36) NOT NULL,
	[GysId2] [char](36) NOT NULL,
 CONSTRAINT [PK_TBL_GYS_ZHUTI_GUANXI] PRIMARY KEY CLUSTERED 
(
	[IdentityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_GuanXi', @level2type=N'COLUMN',@level2name=N'IdentityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商编号1（供应商主体编号）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_GuanXi', @level2type=N'COLUMN',@level2name=N'GysId1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商编号2（供应商资源编号）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_GuanXi', @level2type=N'COLUMN',@level2name=N'GysId2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商主体与供应商关系信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_GuanXi'
GO
/****** Object:  Table [dbo].[tbl_Gys_ZhuTi_Lxr]    Script Date: 05/25/2015 11:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Gys_ZhuTi_Lxr](
	[LxrId] [int] IDENTITY(1,1) NOT NULL,
	[GysId] [char](36) NOT NULL,
	[LxrName] [nvarchar](255) NULL,
	[LxrDianHua] [nvarchar](255) NULL,
	[LxrShouJi] [nvarchar](255) NULL,
	[LxrFax] [nvarchar](255) NULL,
	[LxrBuMen] [nvarchar](255) NULL,
	[LxrZhiWu] [nvarchar](255) NULL,
	[LxrQQ] [nvarchar](255) NULL,
	[LxrWeiXin] [nvarchar](255) NULL,
	[IsDelete] [char](1) NOT NULL,
	[CaoZuoRenId] [int] NOT NULL,
	[IssueTime] [datetime] NOT NULL,
	[YongHuId] [int] NOT NULL,
 CONSTRAINT [PK_TBL_GYS_ZHUTI_LXR] PRIMARY KEY CLUSTERED 
(
	[LxrId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商主体编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'GysId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrDianHua'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrShouJi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrFax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrBuMen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人职务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrZhiWu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrQQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人微信' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'LxrWeiXin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'CaoZuoRenId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'IssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr', @level2type=N'COLUMN',@level2name=N'YongHuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商主体联系人信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Gys_ZhuTi_Lxr'
GO
/****** Object:  View [dbo].[view_Gys_XuanYong]    Script Date: 05/25/2015 11:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-15
-- Description: 选用供应商视图
-- =============================================
CREATE VIEW [dbo].[view_Gys_XuanYong]
AS
SELECT A.Id AS GysId
	,A.CompanyId
	,A.ProvinceId AS ShengFenId
	,A.CityId AS ChengShiId
	,A.UnitName AS GysName
	,A.SupplierType AS LeiXing
	,A.ZxsId
	,A.IssueTime
	,B.MingCheng AS ZxsName
	,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.ProvinceId) AS ShengFenName
	,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.CityId) AS ChengShiName
	,(SELECT TOP(1) A1.ContactName FROM tbl_SupplierContact AS A1 WHERE A1.SupplierId=A.Id ORDER BY Id ASC) AS LxrName
	,(SELECT TOP(1) A1.ContactTel FROM tbl_SupplierContact AS A1 WHERE A1.SupplierId=A.Id ORDER BY Id ASC) AS LxrDianHua
	,(SELECT TOP(1) A1.ContactMobile FROM tbl_SupplierContact AS A1 WHERE A1.SupplierId=A.Id ORDER BY Id ASC) AS LxrShouJi
	,(SELECT TOP(1) A1.ContactFax FROM tbl_SupplierContact AS A1 WHERE A1.SupplierId=A.Id ORDER BY Id ASC) AS Fax
	,ISNULL((SELECT A1.GysId1 FROM tbl_Gys_ZhuTi_GuanXi AS A1 INNER JOIN tbl_Gys_ZhuTi AS B1 ON A1.GysId1=B1.GysId AND B1.IsDelete='0'  WHERE A1.GysId2=A.Id ),'') AS GysZhuTiId--供应商主体编号（已被该供应商主体关联）
FROM tbl_CompanySupplier AS A INNER JOIN tbl_Pt_ZhuanXianShang AS B
ON A.ZxsId=B.ZxsId AND B.IsDelete='0'
WHERE A.IsDelete='0'
GO
/****** Object:  View [dbo].[view_Gys_DiJieAnPai]    Script Date: 05/25/2015 11:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-17
-- Description: 供应商主体-地接安排信息
-- History:
-- =============================================
CREATE VIEW [dbo].[view_Gys_DiJieAnPai]
AS
SELECT A.PlanId,A.CompanyId,A.KongWeiId
	,A.JiaoYiHao,A.GysId,A.RouteId
	,A.ChengRenShu,A.ErTongShu,A.QuPeiShu
	,A.JieSuanMX,A.JieSuanAmount,A.IssueTime
	,B.KongWeiCode,B.QuTime,B.QuDate
	,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS ZxsRouteName
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=0),0) AS WeiShenPiJinE--未审批金额
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=1),0) AS YiShenPiJinE--已审批(未支付)金额
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=2),0) AS YiZhiFuJinE--已支付金额
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName--供应商名称
	--,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.DaoYouId) AS DaoYouName--导游姓名
	,B.ZxsId
	,A.YingErShu
	,D.GysId AS GysZhuTiId
	,D.GysName AS GysZhuTiName
	,E.MingCheng AS ZxsName
	,A.OperatorId AS ZxsCaoZuoRenId
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS ZxsCaoZuoRenName
	,A.DiJieQueRenStatus
	,A.DiJieQueRenRenId
	,A.DiJieQueRenTime
	,A.DiJieRouteName
	,A.DiJieTuanHao
	,A.NeiBuBeiZhu
	,A.DaoYouName
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.DiJieQueRenRenId) AS DiJieQueRenRenName
FROM tbl_PlanDiJie AS A INNER JOIN tbl_KongWei AS B
ON A.KongWeiId=B.KongWeiId INNER JOIN tbl_Gys_ZhuTi_GuanXi AS C
ON A.GysId=C.GysId2 INNER JOIN tbl_Gys_ZhuTi AS D
ON C.GysId1=D.GysId AND D.IsDelete='0'  INNER JOIN tbl_Pt_ZhuanXianShang AS E
ON A.ZxsId=E.ZxsId
GO
/****** Object:  StoredProcedure [dbo].[proc_Gys_DiJieJiHua_U]    Script Date: 05/25/2015 11:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-17
-- Description:	供应商-地接社设置计划信息
-- =============================================
CREATE PROCEDURE [dbo].[proc_Gys_DiJieJiHua_U]
	@AnPaiId CHAR(36)
	,@DiJieRouteName NVARCHAR(255)
	,@DiJieTuanHao NVARCHAR(255)
	,@DaoYouName NVARCHAR(255)
	,@GysZhuTiId CHAR(36)
	,@CaoZuoRenId INT
	,@CaoZuoTime DATETIME
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @GysId CHAR(36)--地接社编号
	DECLARE @KongWeiId CHAR(36)
	DECLARE @KongWeiZhuangTai INT
	DECLARE @DaoYouName1 NVARCHAR(255)
	
	IF NOT EXISTS(SELECT 1 FROM tbl_PlanDiJie WHERE PlanId=@AnPaiId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @GysId=GysId,@KongWeiId=KongWeiId,@DaoYouName1=DaoYouName1 FROM tbl_PlanDiJie WHERE PlanId=@AnPaiId
	SELECT @KongWeiZhuangTai=KongWeiZhuangTai FROM tbl_KongWei WHERE KongWeiId=@KongWeiId
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi_GuanXi AS A1 INNER JOIN tbl_Gys_ZhuTi AS B1 ON A1.GysId1=B1.GysId AND B1.IsDelete='0' WHERE A1.GysId1=@GysZhuTiId AND A1.GysId2=@GysId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END	
	
	/*IF(@KongWeiZhuangTai=1)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END*/
	
	UPDATE tbl_PlanDiJie SET DiJieRouteName=@DiJieRouteName
		,DiJieTuanHao=@DiJieTuanHao,DaoYouName=@DaoYouName
		,DiJieCaoZuoRenId=@CaoZuoRenId,DiJieCaoZuoTime=@CaoZuoTime
	WHERE PlanId=@AnPaiId
	
	IF(@DaoYouName1 IS NULL OR LEN(@DaoYouName1)=0)
	BEGIN
		UPDATE tbl_PlanDiJie SET DaoYouName1=@DaoYouName
		WHERE PlanId=@AnPaiId
	END
	
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GysZhuTi_Lxr_CU]    Script Date: 05/25/2015 11:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-14
-- Description:	供应商主体联系人新增、修改
-- =============================================
CREATE PROCEDURE [dbo].[proc_GysZhuTi_Lxr_CU]
	@LxrId INT
	,@GysId CHAR(36)
	,@LxrName NVARCHAR(255)
	,@LxrDianHua NVARCHAR(255)
	,@LxrShouJi NVARCHAR(255)
	,@LxrFax NVARCHAR(255)
	,@LxrBuMen NVARCHAR(255)
	,@LxrZhiWu NVARCHAR(255)
	,@LxrQQ NVARCHAR(255)
	,@LxrWeiXin NVARCHAR(255)
	,@CaoZuoRenId INT
	,@IssueTime DATETIME
	,@YongHuMing NVARCHAR(255)
	,@MiMa NVARCHAR(255)
	,@Md5MiMa NVARCHAR(255)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @FS CHAR(1)
	DECLARE @CompanyId INT
	DECLARE @YongHuId INT
	DECLARE @ZxsId CHAR(36)
	SET @FS='C'
	SET @YongHuId=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi WHERE GysId=@GysId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi_Lxr WHERE GysId=@GysId AND LXrId=@LxrId)
	BEGIN
		SET @FS='U'
		SELECT @YongHuId=YongHuId FROM tbl_Gys_ZhuTi_Lxr WHERE GysId=@GysId AND LXrId=@LxrId
	END
	
	SELECT @CompanyId=CompanyId,@ZxsId=ZxsId FROM tbl_Gys_ZhuTi WHERE GysId=@GysId
	
	IF EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE CompanyId=@CompanyId AND Username=@YongHuMing AND Id<>@YongHuId AND IsDelete='0')
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_Gys_ZhuTi_Lxr]([GysId],[LxrName],[LxrDianHua]
			,[LxrShouJi],[LxrFax],[LxrBuMen]
			,[LxrZhiWu],[LxrQQ],[LxrWeiXin]
			,[IsDelete],[CaoZuoRenId],[IssueTime]
			,[YongHuId])
		VALUES(@GysId,@LxrName,@LxrDianHua
			,@LxrShouJi,@LxrFax,@LxrBuMen
			,@LxrZhiWu,@LxrQQ,@LxrWeiXin
			,'0',@CaoZuoRenId,@IssueTime
			,@YongHuId)
		SET @LxrId=SCOPE_IDENTITY()
			
		INSERT INTO [tbl_CompanyUser]([CompanyId],[UserName],[Password]
			,[MD5Password],[ContactName],[ContactSex]
			,[ContactTel],[ContactFax],[ContactMobile]
			,[ContactEmail],[QQ],[MSN]
			,[JobName],[LastLoginIP],[LastLoginTime]
			,[RoleID],[PermissionList],[PeopProfile]
			,[Remark],[IsDelete],[UserStatus]
			,[IsAdmin],[IssueTime],[DepartId]
			,[SuperviseDepartId],[OnlineStatus],[OnlineSessionId]
			,[LeiXing],[ZxsId],[KeHuId]
			,[KeHuLxrId],[GysId],[GysLxrId])
		VALUES(@CompanyId,@YongHuMing,@MiMa
			,@Md5MiMa,@LxrName,'1'
			,@LxrDianHua,@LxrFax,@LxrShouJi
			,'',@LxrQQ,''
			,'','',GETDATE()
			,0,'',''
			,'','0',1
			,'0',GETDATE(),0
			,0,0,''
			,4,@ZxsId,''
			,0,@GysId,@LxrId)
			
		SET @YongHuId=SCOPE_IDENTITY()
		
		UPDATE [tbl_Gys_ZhuTi_Lxr] SET [YongHuId]=@YongHuId WHERE LxrId=@LxrId
	END
	
	IF(@FS='U')
	BEGIN
		UPDATE [tbl_Gys_ZhuTi_Lxr] SET [LxrName]=@LxrName,[LxrDianHua]=@LxrDianHua
			,[LxrShouJi]=@LxrShouJi,[LxrFax]=@LxrFax,[LxrBuMen]=@LxrBuMen
			,[LxrZhiWu]=@LxrZhiWu,[LxrQQ]=@LxrQQ,[LxrWeiXin]=@LxrWeiXin
		WHERE LxrId=@LxrId
		
		UPDATE tbl_CompanyUser SET [ContactName]=@Lxrname,[ContactTel]=@LxrDianHua
			,[ContactFax]=@LxrFax,[ContactMobile]=@LxrShouJi
			,[QQ]=@LxrQQ
		WHERE Id=@YongHuId
		
		IF(@MiMa IS NOT NULL AND @Md5MiMa IS NOT NULL AND LEN(@MiMa)>0 AND LEN(@Md5MiMa)>0)
		BEGIN
			UPDATE [tbl_CompanyUser] SET [Password]=@MiMa,[MD5Password]=@Md5MiMa WHERE Id=@YongHuId
		END
	END
	
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GysZhuTi_D]    Script Date: 05/25/2015 11:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-14
-- Description:	供应商主体删除
-- =============================================
CREATE PROCEDURE [dbo].[proc_GysZhuTi_D]
	@GysId CHAR(36)
	,@CompanyId INT
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi WHERE GysId=@GysId AND CompanyId=@CompanyId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi_Lxr WHERE GysId=@GysId AND IsDelete='0')
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	UPDATE tbl_Gys_ZhuTi SEt IsDelete='1' WHERE GysId=@GysId
	
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GysZhuTi_CU]    Script Date: 05/25/2015 11:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-14
-- Description:	供应商主体新增、修改
-- =============================================
CREATE PROCEDURE [dbo].[proc_GysZhuTi_CU]
	@GysId CHAR(36)
	,@LeiXing INT
	,@CompanyId INT
	,@ZxsId CHAR(36)
	,@GysName NVARCHAR(255)
	,@ShengFenId INT
	,@ChengShiId INT
	,@JieShao NVARCHAR(MAX)
	,@CaoZuoRenId INT
	,@IssueTime DATETIME
	,@LxrName NVARCHAR(255)
	,@LxrDianHua NVARCHAR(255)
	,@LxrShouJi NVARCHAR(255)
	,@DiZhi NVARCHAR(255)
	,@Fax NVARCHAR(255)
	,@GysGuanXiXml NVARCHAR(MAX)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @FS CHAR(1)
	DECLARE @hdoc INT
	DECLARE @TEMP_TBL_GUANXI TABLE(GysId CHAR(36))
	SET @FS='C'
	
	IF EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi WHERE GysId=@GysId AND CompanyId=@CompanyId)
	BEGIN
		SET @FS='U'
	END
	
	IF(@GysGuanXiXml IS NOT NULL AND LEN(@GysGuanXiXml)>0)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@GysGuanXiXml
		INSERT INTO @TEMP_TBL_GUANXI(GysId)
		SELECT GysId FROM OPENXML(@hdoc,'/root/info',3)
		WITH(GysId CHAR(36))
		EXEC sp_xml_removedocument @hdoc
	END
	
	DELETE FROM @TEMP_TBL_GUANXI WHERE EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi_GuanXi AS A1 INNER JOIN tbl_Gys_ZhuTi AS B1 ON A1.GysId1=B1.GysId AND B1.IsDelete='0' WHERE A1.GysId1<>@GysId AND A1.GysId2 IN(SELECT GysId FROM @TEMP_TBL_GUANXI))
	
	IF(@FS='C')
	BEGIN
		INSERT INTO [tbl_Gys_ZhuTi]([GysId],[LeiXing],[CompanyId]
			,[ZxsId],[GysName],[ShengFenId]
			,[ChengShiId],[JieShao],[CaoZuoRenId]
			,[IssueTime],[IsDelete],[LxrName]
			,[LxrDianHua],[LxrShouJi],[DiZhi]
			,[Fax])
		VALUES(@GysId,@LeiXing,@CompanyId
			,@ZxsId,@GysName,@ShengFenId
			,@ChengShiId,@JieShao,@CaoZuoRenId
			,@IssueTime,'0',@LxrName
			,@LxrDianHua,@LxrShouJi,@DiZhi
			,@Fax)
	END
	
	IF(@FS='U')
	BEGIN
		UPDATE [tbl_Gys_ZhuTi] SET [GysName]=@GysName
		,[ShengFenId]=@ShengFenId,[ChengShiId]=@ChengShiId
		,[JieShao]=@JieShao,[LxrName]=@LxrName
		,[LxrDianHua]=@LxrDianHua,[LxrShouJi]=@LxrShouJi
		,[DiZhi]=@DiZhi,[Fax]=@Fax
		WHERE GysId=@GysId
	END
	
	DELETE FROM tbl_Gys_ZhuTi_GuanXi WHERE GysId1=@GysId
	
	IF EXISTS(SELECT 1 FROM @TEMP_TBL_GUANXI)
	BEGIN
		INSERT INTO tbl_Gys_ZhuTi_GuanXi(GysId1,GysId2)
		SELECT @GysId,GysId FROM @TEMP_TBL_GUANXI
	END	
	
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Gys_DiJieJiHua_SheZhiQueRenStatus]    Script Date: 05/25/2015 11:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-22
-- Description:	供应商-地接社设置计划状态
-- =============================================
CREATE PROCEDURE [dbo].[proc_Gys_DiJieJiHua_SheZhiQueRenStatus]
	@AnPaiId CHAR(36)
	,@Status INT
	,@GysZhuTiId CHAR(36)
	,@CaoZuoRenId INT
	,@CaoZuoTime DATETIME
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @GysId CHAR(36)--地接社编号
	
	IF NOT EXISTS(SELECT 1 FROM tbl_PlanDiJie WHERE PlanId=@AnPaiId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @GysId=GysId FROM tbl_PlanDiJie WHERE PlanId=@AnPaiId
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi_GuanXi AS A1 INNER JOIN tbl_Gys_ZhuTi AS B1 ON A1.GysId1=B1.GysId AND B1.IsDelete='0' WHERE A1.GysId1=@GysZhuTiId AND A1.GysId2=@GysId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END	
	
	UPDATE tbl_PlanDiJie SET DiJieQueRenStatus=@Status
		,DiJieQueRenRenId=@CaoZuoRenId
		,DiJieQueRenTime=@CaoZuoTime
	WHERE PlanId=@AnPaiId
	
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GysZhuTi_Lxr_D]    Script Date: 05/25/2015 11:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-14
-- Description:	供应商主体联系人删除
-- =============================================
CREATE PROCEDURE [dbo].[proc_GysZhuTi_Lxr_D]
	@LxrId INT
	,@GysId CHAR(36)
	,@YongHuId INT
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Gys_ZhuTi_Lxr WHERE LxrId=@LxrId AND GysId=@GysId AND YongHuId=@YongHuId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	UPDATE tbl_Gys_ZhuTi_Lxr SET IsDelete='1' WHERE LxrId=@LxrId	
	UPDATE tbl_CompanyUser SET IsDelete='1',Username='_'+CAST(@YongHuId AS NVARCHAR(50))+'_'+Username,ContactEmail='_'+CAST(@YongHuId AS NVARCHAR(50))+'_'+ContactEmail WHERE Id=@YongHuId
	
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** Object:  Default [DF__tbl_Gys_Z__LeiXi__3D3EEF98]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi] ADD  CONSTRAINT [DF__tbl_Gys_Z__LeiXi__3D3EEF98]  DEFAULT ((0)) FOR [LeiXing]
GO
/****** Object:  Default [DF__tbl_Gys_Z__Sheng__3E3313D1]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi] ADD  CONSTRAINT [DF__tbl_Gys_Z__Sheng__3E3313D1]  DEFAULT ((0)) FOR [ShengFenId]
GO
/****** Object:  Default [DF__tbl_Gys_Z__Cheng__3F27380A]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi] ADD  CONSTRAINT [DF__tbl_Gys_Z__Cheng__3F27380A]  DEFAULT ((0)) FOR [ChengShiId]
GO
/****** Object:  Default [DF__tbl_Gys_Z__CaoZu__401B5C43]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi] ADD  CONSTRAINT [DF__tbl_Gys_Z__CaoZu__401B5C43]  DEFAULT ((0)) FOR [CaoZuoRenId]
GO
/****** Object:  Default [DF__tbl_Gys_Z__Issue__410F807C]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi] ADD  CONSTRAINT [DF__tbl_Gys_Z__Issue__410F807C]  DEFAULT (getdate()) FOR [IssueTime]
GO
/****** Object:  Default [DF__tbl_Gys_Z__IsDel__4203A4B5]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi] ADD  CONSTRAINT [DF__tbl_Gys_Z__IsDel__4203A4B5]  DEFAULT ('0') FOR [IsDelete]
GO
/****** Object:  Default [DF__tbl_Gys_Z__IsDel__47BC7E0B]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi_Lxr] ADD  CONSTRAINT [DF__tbl_Gys_Z__IsDel__47BC7E0B]  DEFAULT ('0') FOR [IsDelete]
GO
/****** Object:  Default [DF__tbl_Gys_Z__CaoZu__48B0A244]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi_Lxr] ADD  CONSTRAINT [DF__tbl_Gys_Z__CaoZu__48B0A244]  DEFAULT ((0)) FOR [CaoZuoRenId]
GO
/****** Object:  Default [DF__tbl_Gys_Z__Issue__49A4C67D]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi_Lxr] ADD  CONSTRAINT [DF__tbl_Gys_Z__Issue__49A4C67D]  DEFAULT (getdate()) FOR [IssueTime]
GO
/****** Object:  Default [DF__tbl_Gys_Z__YongH__4A98EAB6]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi_Lxr] ADD  CONSTRAINT [DF__tbl_Gys_Z__YongH__4A98EAB6]  DEFAULT ((0)) FOR [YongHuId]
GO
/****** Object:  ForeignKey [FK_TBL_GYS_ZHUTI_GUANXI_REFERENCE_TBL_GYS_ZHUTI]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi_GuanXi]  WITH CHECK ADD  CONSTRAINT [FK_TBL_GYS_ZHUTI_GUANXI_REFERENCE_TBL_GYS_ZHUTI] FOREIGN KEY([GysId1])
REFERENCES [dbo].[tbl_Gys_ZhuTi] ([GysId])
GO
ALTER TABLE [dbo].[tbl_Gys_ZhuTi_GuanXi] CHECK CONSTRAINT [FK_TBL_GYS_ZHUTI_GUANXI_REFERENCE_TBL_GYS_ZHUTI]
GO
/****** Object:  ForeignKey [FK_TBL_GYS_ZHUTI_LXR_REFERENCE_TBL_GYS_ZHUTI]    Script Date: 05/25/2015 11:19:49 ******/
ALTER TABLE [dbo].[tbl_Gys_ZhuTi_Lxr]  WITH CHECK ADD  CONSTRAINT [FK_TBL_GYS_ZHUTI_LXR_REFERENCE_TBL_GYS_ZHUTI] FOREIGN KEY([GysId])
REFERENCES [dbo].[tbl_Gys_ZhuTi] ([GysId])
GO
ALTER TABLE [dbo].[tbl_Gys_ZhuTi_Lxr] CHECK CONSTRAINT [FK_TBL_GYS_ZHUTI_LXR_REFERENCE_TBL_GYS_ZHUTI]
GO

SET IDENTITY_INSERT [tbl_SysPrivs2] ON
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 80,5,'地接社账号管理','',0,'0')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 81,5,'地接社主体管理','',0,'1')
SET IDENTITY_INSERT [tbl_SysPrivs2] OFF
GO

GO
SET IDENTITY_INSERT [tbl_SysPrivs3] ON
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 333,30,'账号管理',0,'0',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 334,30,'账号新增',0,'0',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 335,30,'账号修改',0,'0',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 336,30,'账号删除',0,'0',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 337,80,'栏目',0,'0',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 338,80,'账号管理',0,'0',0)


INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 339,81,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 340,81,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 341,81,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 342,81,'删除',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 343,81,'账号新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 344,81,'账号修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 345,81,'账号删除',0,'1',0)
SET IDENTITY_INSERT [tbl_SysPrivs3] OFF
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-12
-- Description: 供应商-用户
-- =============================================
ALTER VIEW [dbo].[view_Gys_YongHu]
AS
SELECT A.LxrId AS GysLxrId
	,A.GysId
	,B.CompanyId
	,A.LxrName AS XingMing
	,A.LxrDianHua AS DianHua
	,A.LxrShouJi AS ShouJi
	,A.LxrQQ AS QQ
	,A.LxrFax
	,A.YongHuId
	,B.UserName AS YongHuMing
	,ISNULL(B.LeiXing,4) AS LeiXing
	,C.GysName AS GysName
	,B.UserStatus AS YongHuStatus
	,C.LeiXing AS GysLeiXing
	,C.ZxsId
FROM tbl_Gys_ZhuTi_Lxr AS A LEFT OUTER JOIN tbl_CompanyUser AS B
ON A.YongHuId=B.Id AND A.GysId=B.GysId
INNER JOIN tbl_Gys_ZhuTi AS C
ON A.GysId=C.GysId
WHERE A.IsDelete='0'
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2012-11-20
-- Description:应付地接视图
-- History:
-- 1.2013-05-22 汪奇志 增加[DaoYouName]
-- =============================================
ALTER VIEW [dbo].[view_Fin_YingFuDiJie]
AS
SELECT A.PlanId,A.CompanyId,A.KongWeiId
	,A.JiaoYiHao,A.GysId,A.RouteId
	,A.ChengRenShu,A.ErTongShu,A.QuPeiShu
	,A.JieSuanMX,A.JieSuanAmount,A.IssueTime
	,B.KongWeiCode,B.QuTime,B.QuDate,(SELECT TOP 1 C.ContactName,C.ContactTel FROM tbl_SupplierContact C WHERE C.SupplierId=A.GysId ORDER BY C.Id ASC FOR XML RAW,ROOT) AS ContactInfo
	,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=0),0) AS WeiShenPiJinE--未审批金额
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=1),0) AS YiShenPiJinE--已审批(未支付)金额
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=2),0) AS YiZhiFuJinE--已支付金额
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName--供应商名称
	--,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHErE A1.Id=A.DaoYouId) AS DaoYouName--导游姓名
	,A.DaoYouName
	,B.ZxsId
	,A.YingErShu
	,A.[DiJieQueRenStatus]
	,A.[DiJieQueRenRenId]
	,A.[DiJieQueRenTime]
	,A.[DiJieRouteName]
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.[DiJieQueRenRenId]) AS DiJieQueRenRenName
FROM tbl_PlanDiJie AS A INNER JOIN tbl_KongWei AS B
ON A.KongWeiId=B.KongWeiId

GO
--以上日志已更新 汪奇志 05 26 2015  6:16PM
GO

-- =============================================
-- Author:		汪奇志
-- Create date: 2015-05-27
-- Description: 供应商主体-导游
-- History:
-- =============================================
CREATE VIEW [dbo].[view_Gys_DaoYou]
AS
SELECT A.DaoYouName
	,C.GysId --供应商主体编号
	,C.CompanyId
FROM tbl_plandijie AS A INNER JOIN tbl_Gys_ZhuTi_GuanXi AS B	
ON A.GysId=B.GysId2 INNER JOIN tbl_Gys_ZhuTi AS C 
ON B.GysId1=C.GysId AND C.IsDelete='0'
WHERE A.DaoYouName IS NOT NULL AND A.DaoYouName>''
GROUP BY C.CompanyID,C.GysId,A.DaoYouName
GO

-- =============================================
-- Author:		<王磊>
-- Create date: <2011-11-16>
-- Description:	<修改地接安排>
--Result:
--	-1:已经安排地接的订单 不能重新安排
--  -2:当订单性质为团队时，一次只能选择一个订单进行地接安排
--  -3:当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
--1:修改成功 0:修改失败
-- History:
-- 1.2013-01-15 汪奇志 去掉导游的设置
-- 2.2013-01-24 汪奇志 增加@YouKeXinXi
-- 3.2013-02-26 汪奇志 增加控位状态的控制	
-- 4.2015-05-22 汪奇志 增加@NeiBuBeiZhu
-- =============================================
ALTER proc [dbo].[proc_PlanDiJie_Update]
	@PlanId char(36) 
	,@CompanyId int
	,@KongWeiId char(36)
	,@JiaoYiHao nvarchar(50)
	,@GysId char(36)
	,@RouteId char(36)
	,@LxrName nvarchar(50)
	,@LxrTelephone nvarchar(50)
	,@ChengRenShu int
	,@ErTongShu int
	,@QuPeiShu int
	,@QuPeiName nvarchar(50)
	--@DaoYouId int 
	,@YongCan nvarchar(255)
	,@JieSuanMX nvarchar(255)
	,@JieSuanAmount money 
	,@JieTuanFangShi nvarchar(255)
	,@OperatorId int
	,@Remark nvarchar(MAX)
	,@OrderIds nvarchar(max)
	,@Result int output
	,@YouKeXinXi NVARCHAR(MAX)--游客信息
	,@YingErShu INT
	,@NeiBuBeiZhu NVARCHAR(MAX)
as
begin
	declare @error int
	set @error=0

	if exists(select 1 from tbl_PlanDiJIeOrder where PlanId<>@PlanId and OrderId in(select [value] from dbo.fn_split(@OrderIds,',')))
	begin
		set @Result=-1	  --已经安排地接的订单 不能重新安排
		return @Result
	end

	declare @BusinessNature tinyint	--订单性质  散拼 = 0,组团 = 1
	select @BusinessNature=BusinessNature from tbl_TourOrder 
	where OrderId=(select top 1 [value] from dbo.fn_split(@OrderIds,','))

	if(@BusinessNature=1)
	begin
		declare @tuanduiordercount int
		select @tuanduiordercount=count(1) from dbo.fn_split(@OrderIds,',') 
		if(@tuanduiordercount<>1)
		begin
			set @Result=-2	  --当订单性质为团队时，一次只能选择一个订单进行地接安排
			return @Result 
		end
	end

	if(@BusinessNature=0)
	begin
		 declare @sanpinordercount int
--		 select @sanpinordercount= count(RouteId) from tbl_TourOrder 
--		 where OrderId in (select [value] from dbo.fn_split(@OrderIds,','))
--		 group by RouteId
		 select @sanpinordercount=count(distinct(RouteId)) from tbl_TourOrder
		 where OrderId in (select [value] from dbo.fn_split(@OrderIds,','))
		 if(@sanpinordercount<>1)
		 begin
			set @Result=-3	  --当订单性质为散拼时，可选择相同线路下的多个订单进行地接安排
			return @Result 
		 end
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END
	
	begin transaction	
	
	UPDATE tbl_PlanDiJie SET GysId = @GysId,LxrName = @LxrName,LxrTelephone = @LxrTelephone
		,ChengRenShu = @ChengRenShu,ErTongShu = @ErTongShu	,QuPeiShu = @QuPeiShu
		,QuPeiName = @QuPeiName,YongCan = @YongCan,JieSuanMX = @JieSuanMX
		,JieSuanAmount = @JieSuanAmount	,JieTuanFangShi = @JieTuanFangShi,Remark = @Remark
		,RouteId=@RouteId,[YouKeXinXi]=@YouKeXinXi,YingErShu=@YingErShu
		,[NeiBuBeiZhu]=@NeiBuBeiZhu,[DiJieQueRenStatus]=0
	WHERE PlanId = @PlanId
	set @error=@error+@@error

	DELETE From  tbl_PlanDiJIeOrder where PlanId=@PlanId
	set @error=@error+@@error

	INSERT INTO tbl_PlanDiJIeOrder(PlanId,OrderId)
	select @PlanId,[value] from dbo.fn_split(@OrderIds,',')
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end	
	return @Result
end
GO
--以上日志已更新 汪奇志 05 27 2015  2:10PM
GO




-- =============================================
-- Author:		汪奇志
-- Create date: 2015-06-19
-- Description: 供应商主体-导游(当地接社未分配到指定主体时供专线商管理平台选用导游时使用)
-- History:
-- =============================================
CREATE VIEW [dbo].[view_Gys_DaoYou_DiJieShe]
AS
SELECT A.DaoYouName
	,A.CompanyId
	,A.GysId--供应商编号（即地接社编号）
FROM tbl_plandijie AS A 
WHERE A.DaoYouName IS NOT NULL AND A.DaoYouName>''
GROUP BY A.CompanyID,A.GysId,A.DaoYouName

GO
--以上日志已更新 汪奇志 06 19 2015  4:22PM
GO
