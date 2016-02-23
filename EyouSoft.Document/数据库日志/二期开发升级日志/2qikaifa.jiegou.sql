GO
--PT���

--
GO
SET IDENTITY_INSERT [tbl_Pt_ZhuanXianShang] ON
INSERT [tbl_Pt_ZhuanXianShang] ([ZxsId],[CompanyId],[MingCheng],[ZhuCeHao],[ShuiWuHao],[XuKeZhengHao],[FaRenName],[LxrName],[LxrDianHua],[LxrShouJi],[Fax],[ProvinceId],[CityId],[DiZhi],[Status],[JiFenStatus],[Privs1],[Privs2],[Privs3],[OperatorId],[IssueTime],[IsDelete],[IdentityId],[T1]) VALUES ( N'E8B8FC24-D9D6-4647-834F-9A62920C0CBC',3,N'������Ҽ�����������޹�˾',N'330302000057327',N'330302759052236',N'������ɣ�2009��1137��/L��ZJ01139',N'���',N'���',N'057788662994',N'13968824688',N'0577-88870444',0,0,N'�������µ�·�µϽ�԰9��502��',0,0,N'ALL',N'ALL',N'ALL',0,N'2014-07-09 0:00:00',N'0',1,1)
SET IDENTITY_INSERT [tbl_Pt_ZhuanXianShang] OFF
GO

ALTER TABLE dbo.tbl_CompanyUser ADD
	LeiXing tinyint NOT NULL CONSTRAINT DF_tbl_CompanyUser_LeiXing DEFAULT 0,
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_CompanyUser_ZxsId DEFAULT '',
	KeHuId char(36) NOT NULL CONSTRAINT DF_tbl_CompanyUser_KeHuId DEFAULT '',
	KeHuLxrId int NOT NULL CONSTRAINT DF_tbl_CompanyUser_KeHuLxrId DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'�û�����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'LeiXing'
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'ZxsId'
GO
DECLARE @v sql_variant 
SET @v = N'�ͻ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'KeHuId'
GO
DECLARE @v sql_variant 
SET @v = N'�ͻ���ϵ�˱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'KeHuLxrId'
GO

UPDATE tbl_CompanyUser SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_CompanyDepartment ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_CompanyDepartment_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyDepartment', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_CompanyDepartment SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_SysRoleManage ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_SysRoleManage_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_SysRoleManage', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_SysRoleManage SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_SysHandleLogs ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_SysHandleLogs_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_SysHandleLogs', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_SysHandleLogs SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_SysLoginLog ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_SysLoginLog_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_SysLoginLog', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_SysLoginLog SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_ComJiChuXinXi ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_ComJiChuXinXi_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_ComJiChuXinXi', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_ComJiChuXinXi SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 AND [Type] IN(2,3,4,5,6,7,8)
GO

ALTER TABLE dbo.tbl_News ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_News_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_News', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_News SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 
GO

ALTER TABLE dbo.tbl_Document ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_Document_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Document', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_Document SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 
GO

ALTER TABLE dbo.tbl_WorkExchange ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_WorkExchange_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_WorkExchange', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_WorkExchange SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 
GO

/*
--==================================
--��������-�����������
--�����ˣ�³��Դ
--ʱ�䣺2011-01-19
--==================================
ALTER procedure [dbo].[proc_WorkExchange_Insert]
@CompanyId int,
@Type tinyint,
@Title nvarchar(255),
@Description nvarchar(max),
@OperatorId int,
@CreateTime datetime,
@IsAnonymous char(1),
@FilePath nvarchar(255),
@Result int output,
@ZxsId CHAR(36)
as
begin 
	declare @error int
	set @error=0

	INSERT INTO tbl_WorkExchange
           (CompanyId,[Type],Title,Description,OperatorId,CreateTime,IsAnonymous,FilePath,ZxsId)
     VALUES(@CompanyId,@Type,@Title,@Description,@OperatorId,@CreateTime,@IsAnonymous,@FilePath,@ZxsId)
	 set @error=@error+@@error
	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
	   set @Result=0
	end
	return @Result
end
GO*/

ALTER TABLE dbo.tbl_UserMemorandum ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_UserMemorandum_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_UserMemorandum', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_UserMemorandum SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 
GO

ALTER TABLE dbo.tbl_UserLeave ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_UserLeave_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_UserLeave', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_UserLeave SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 
GO

ALTER TABLE dbo.tbl_Route ADD
	LeiXing tinyint NOT NULL CONSTRAINT DF_tbl_Route_LeiXing DEFAULT 0,
	GuoQiShiJian datetime NULL,
	ZhanDianId int NOT NULL CONSTRAINT DF_tbl_Route_ZhanDianId DEFAULT 0,
	ZxlbId int NOT NULL CONSTRAINT DF_tbl_Route_ZxlbId DEFAULT 0,
	BiaoZhun tinyint NOT NULL CONSTRAINT DF_tbl_Route_BiaoZhun DEFAULT 0,
	JiHeDiDian nvarchar(MAX) NULL,
	JiHeShiJian nvarchar(MAX) NULL,
	SongTuanXinXi nvarchar(MAX) NULL,
	MuDiDiJieTuanFangShi nvarchar(MAX) NULL,
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_Route_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'��·����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'LeiXing'
GO
DECLARE @v sql_variant 
SET @v = N'����ʱ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'GuoQiShiJian'
GO
DECLARE @v sql_variant 
SET @v = N'վ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'ZhanDianId'
GO
DECLARE @v sql_variant 
SET @v = N'ר�������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'ZxlbId'
GO
DECLARE @v sql_variant 
SET @v = N'��·��׼'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'BiaoZhun'
GO
DECLARE @v sql_variant 
SET @v = N'���ϵص�'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'JiHeDiDian'
GO
DECLARE @v sql_variant 
SET @v = N'����ʱ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'JiHeShiJian'
GO
DECLARE @v sql_variant 
SET @v = N'������Ϣ'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'SongTuanXinXi'
GO
DECLARE @v sql_variant 
SET @v = N'Ŀ�ĵؽ��ŷ�ʽ'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'MuDiDiJieTuanFangShi'
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_Route SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 
GO

ALTER TABLE dbo.tbl_RouteZhengCe ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_RouteZhengCe_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_RouteZhengCe', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_RouteZhengCe SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 
GO

/*
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�����·����>
-- Result :0:���ʧ�� 1:��ӳɹ�
-- History:
-- 1.2013-01-06 ����@Status
-- =============================================
ALTER proc [dbo].[proc_RouteZhengCe_Add]
	 @Id char(36)			--���߱��
	,@CompanyId int		--��˾���
	,@Title nvarchar(255)	--���߱���
	,@FilePath nvarchar(255)--���߸���
	,@OperatorId int		--�����˱��
	,@Result int output
	,@Status TINYINT--����״̬
	,@ZxsId CHAR(36)
as
begin
	declare @error int
	set @error=0

	INSERT INTO tbl_RouteZhengCe(Id,CompanyId,Title,FilePath,OperatorId,IssueTime,[Status],[ZxsId])
	VALUES(@Id,@CompanyId,@Title,@FilePath,@OperatorId,getdate(),@Status,@ZxsId)
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	
	return @Result
end
GO

-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�����·>
-- Result :0:���ʧ�� 1:��ӳɹ�
-- History:
-- 1.2013-01-28 ����־ ����@Status
-- =============================================
ALTER proc [dbo].[proc_Route_Add]
@RouteId char(36),				--��·��Ʒ���
@CompanyId int,					--��˾���
@RouteName nvarchar(255),		--��·����
@AreaId int,						--��·������
@RouteHeader nvarchar(255),		--��·ҳü
@AreaDesc nvarchar(max),			--��·����
@Days int,						--����
@RoutePic nvarchar(255),			--��·ͼƬ
@TrafficStandard nvarchar(max),	--��ͨ��׼
@StayStandard nvarchar(max),		--ס�ޱ�ע
@DiningStandard nvarchar(max),	--������׼
@AttractionsStandard nvarchar(max), --�����׼
@GuideStandard nvarchar(max),	--���α�׼
@ShoppingStandard nvarchar(max),	-- �����׼
@ChildStandard nvarchar(max),	--��ͯ��׼
@InsuranceDesc nvarchar(max),	--����˵��
@ExpenseRecommend nvarchar(max),	-- �Է��Ƽ�
@Tips nvarchar(max),				--��ܰ��ʾ
@InsideInfo nvarchar(max),		--�ڲ���Ϣ
@RegistrationNotes nvarchar(max), --������֪
@OperatorId char(36),			 --����Ա���
@RoutePlan xml,				     --��·�г̰���<Root><RoutePlan RouteId=\"{0}\" Days=\"{1}\" Content=\"{2}\" FilePath=\"{3}\" /></Root>
@Result int output
,@Status TINYINT --��·״̬
,@LeiXing tinyint
,@GuoQiShiJian datetime
,@ZhanDianId int
,@ZxlbId int
,@BiaoZhun tinyint
,@JiHeDiDian nvarchar(max)
,@JiHeShiJian nvarchar(max)
,@SongTuanXinXi nvarchar(max)
,@MuDiDiJieTuanFangShi nvarchar(max)
,@ZxsId char(36)
as
begin
	declare @error int
	set @error=0
	begin transaction
	INSERT INTO tbl_Route(RouteId,CompanyId,RouteName,AreaId,RouteHeader
		,AreaDesc,Days,RoutePic,TrafficStandard,StayStandard
		,DiningStandard,AttractionsStandard,GuideStandard
		,ShoppingStandard,ChildStandard,InsuranceDesc
		,ExpenseRecommend,Tips,InsideInfo,RegistrationNotes
		,OperatorId,IssueTime,[Status]
		,[LeiXing],[GuoQiShiJian],[ZhanDianId]
		,[ZxlbId],[BiaoZhun],[JiHeDiDian]
		,[JiHeShiJian],[SongTuanXinXi],[MuDiDiJieTuanFangShi]
		,[ZxsId])
     VALUES(@RouteId,@CompanyId,@RouteName,@AreaId,@RouteHeader 
		,@AreaDesc,@Days,@RoutePic,@TrafficStandard,@StayStandard  
		,@DiningStandard,@AttractionsStandard,@GuideStandard 
		,@ShoppingStandard,@ChildStandard,@InsuranceDesc 
		,@ExpenseRecommend,@Tips,@InsideInfo,@RegistrationNotes  
		,@OperatorId,getdate(),@Status
		,@LeiXing,@GuoQiShiJian,@ZhanDianId
		,@ZxlbId,@BiaoZhun,@JiHeDiDian
		,@JiHeShiJian,@SongTuanXinXi,@MuDiDiJieTuanFangShi
		,@ZxsId)
	set @error=@error+@@error
	
	if(@RoutePlan is not null)
	begin
		declare @idoc int
		exec sp_xml_preparedocument @idoc output,@RoutePlan
		INSERT INTO tbl_RoutePlan(RouteId,Days,[Content],FilePath)
		select @RouteId,Days,[Content],FilePath
		from openxml(@idoc,'/Root/RoutePlan')
		with(Days int,[Content] nvarchar(max),FilePath varchar(255))
		set @error=@error+@@error
	end
	
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
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�޸���·>
-- Result :0:�޸�ʧ�� 1:�޸ĳɹ�
-- History:
-- 1.2013-01-28 ����־ ����@Status
-- =============================================
ALTER proc [dbo].[proc_Route_Update]
@RouteId char(36),				--��·��Ʒ���
@CompanyId int,					--��˾���
@RouteName nvarchar(255),		--��·����
@AreaId int,						--��·������
@RouteHeader nvarchar(255),		--��·ҳü
@AreaDesc nvarchar(max),			--��·����
@Days int,						--����
@RoutePic nvarchar(255),			--��·ͼƬ
@TrafficStandard nvarchar(max),	--��ͨ��׼
@StayStandard nvarchar(max),		--ס�ޱ�ע
@DiningStandard nvarchar(max),	--������׼
@AttractionsStandard nvarchar(max), --�����׼
@GuideStandard nvarchar(max),	--���α�׼
@ShoppingStandard nvarchar(max),	-- �����׼
@ChildStandard nvarchar(max),	--��ͯ��׼
@InsuranceDesc nvarchar(max),	--����˵��
@ExpenseRecommend nvarchar(max),	-- �Է��Ƽ�
@Tips nvarchar(max),				--��ܰ��ʾ
@InsideInfo nvarchar(max),		--�ڲ���Ϣ
@RegistrationNotes nvarchar(max), --������֪
@OperatorId char(36),			 --����Ա���
@RoutePlan xml,				     --��·�г̰���<Root><RoutePlan RouteId=\"{0}\" Days=\"{1}\" Content=\"{2}\" FilePath=\"{3}\" /></Root>
@Result int output
,@Status TINYINT --��·״̬
,@LeiXing tinyint
,@GuoQiShiJian datetime
,@ZhanDianId int
,@ZxlbId int
,@BiaoZhun tinyint
,@JiHeDiDian nvarchar(max)
,@JiHeShiJian nvarchar(max)
,@SongTuanXinXi nvarchar(max)
,@MuDiDiJieTuanFangShi nvarchar(max)
,@ZxsId char(36)
as
begin
	declare @error int
	set @error=0
	begin transaction
	UPDATE tbl_Route SET RouteName = @RouteName, 
		AreaId = @AreaId,RouteHeader = @RouteHeader, 
		AreaDesc = @AreaDesc,Days = @Days,RoutePic = @RoutePic, 
		TrafficStandard = @TrafficStandard,StayStandard = @StayStandard,
		DiningStandard = @DiningStandard,AttractionsStandard = @AttractionsStandard,
		GuideStandard = @GuideStandard,ShoppingStandard = @ShoppingStandard,
		ChildStandard = @ChildStandard,InsuranceDesc = @InsuranceDesc,
		ExpenseRecommend = @ExpenseRecommend,Tips = @Tips,
		InsideInfo = @InsideInfo,RegistrationNotes = @RegistrationNotes
		,[Status]=@Status
		,LeiXing=@LeiXing,GuoQiShiJian=@GuoQiShiJian
		,ZhanDianId=@ZhanDianId,ZxlbId=@ZxlbId
		,BiaoZhun=@BiaoZhun,JiHeDiDian=@JiHeDiDian
		,JiHeShiJian=@JiHeShiJian,SongTuanXinXi=@SongTuanXinXi
		,MuDiDiJieTuanFangShi=@MuDiDiJieTuanFangShi,ZxsId=@ZxsId
	WHERE RouteId=@RouteId
	set @error=@error+@@error
	
	delete from tbl_RoutePlan where RouteId=@RouteId
	set @error=@error+@@error
	
	if(@RoutePlan is not null)
	begin
		declare @idoc int
		exec sp_xml_preparedocument @idoc output,@RoutePlan
		INSERT INTO tbl_RoutePlan(RouteId,Days,[Content],FilePath)
		select @RouteId,Days,[Content],FilePath
		from openxml(@idoc,'/Root/RoutePlan')
		with(Days int,[Content] nvarchar(max),FilePath varchar(255))
		set @error=@error+@@error
	end
	
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
-- Author:		���ĳ�
-- Create date: 2011-09-27
-- Description:	������ϵͳ
-- RetCode��1�ɹ� 0ʧ��
-- =============================================
ALTER PROCEDURE [dbo].[proc_Sys_Create]
	@SysId INT OUTPUT,		--ϵͳ���
	@SysName NVARCHAR(50),	--ϵͳ����
	@CompanyId INT OUTPUT,	--��˾���
	@FullName NVARCHAR(100) = '',--��ϵ������
	@Telephone NVARCHAR(20) = '',	--��ϵ�绰
	@Mobile NVARCHAR(20) = '',	--�ֻ�
	@UserId INT OUTPUT,		--����Ա�û����
	@Username NVARCHAR(50),	--����Ա�û���
	@NoEncryptPassword NVARCHAR(50),--����Ա�û���������
	@MD5Password NVARCHAR(50),	--����Ա�û�MD5����
	@IssueTime DATETIME,	--����ʱ��
	@RetCode INT OUTPUT		--���ؽ������
AS
BEGIN

	DECLARE @ErrorCount INT
	DECLARE @DeptId INT	--���ű��
	DECLARE @RoleId INT --��ɫ���
	DECLARE @ZxsId CHAR(36)
	
	SET @ErrorCount = 0
	SET @ZxsId=NEWID()

	BEGIN TRAN
	
	--1.����ϵͳ��Ϣ
	INSERT INTO [tbl_Sys] ([SysName],CreateTime) VALUES (@SysName,@IssueTime)
	SET @ErrorCount = @ErrorCount + @@ERROR
	SET @SysId = @@IDENTITY

	--2.������˾��Ϣ
	INSERT INTO [tbl_CompanyInfo]([CompanyName],[CompanyType],[CompanyEnglishName],[License]
		,[ContactName],[ContactTel],[ContactMobile],[ContactFax]
		,[CompanyAddress],[CompanyZip],[CompanySiteUrl],[SystemId]
		,[IssueTime])
	VALUES(@SysName,'','',''
		,@FullName,@Telephone,@Mobile,''
		,'','','',@SysId
		,@IssueTime)
	SET @ErrorCount = @ErrorCount + @@ERROR
	SET @CompanyId = @@IDENTITY

	--3.�����ܲ���Ϣ
	INSERT INTO [tbl_CompanyDepartment]([DepartName],[PrevDepartId],[DepartManger],[ContactTel]
		,[ContactFax],[Remark],[CompanyId],[OperatorId]
		,[IssueTime],[ZxsId])
	VALUES('�ܲ�',0,0,''
		,'','',@CompanyId,0
		,@IssueTime,@ZxsId)
	SET @ErrorCount = @ErrorCount + @@ERROR 
	SET @DeptId = @@IDENTITY

	--4.��������Ա��ɫ��Ϣ
	INSERT INTO [tbl_SysRoleManage]([RoleName],[RoleChilds],[CompanyId],[IsDelete],[ZxsId])
	VALUES('����Ա','',@CompanyId,'0',@ZxsId)
	SET @ErrorCount = @ErrorCount + @@ERROR 
	SET @RoleId = @@IDENTITY

	--5.��������Ա�˺���Ϣ
	INSERT INTO [tbl_CompanyUser]([CompanyId],[UserName],[Password],[MD5Password]
		,[ContactName],[ContactSex],[ContactTel],[ContactFax]
		,[ContactMobile],[ContactEmail],[QQ],[MSN]
		,[JobName],[LastLoginIP],[LastLoginTime],[RoleID]
		,[PermissionList],[PeopProfile],[Remark],[IsDelete]
		,[UserStatus],[IsAdmin],[IssueTime],[DepartId]
		,[SuperviseDepartId],[OnlineStatus],[OnlineSessionId]
		,[LeiXing],[ZxsId],[KeHuId],[KeHuLxrId])
	VALUES(@CompanyId,@Username,@NoEncryptPassword,@MD5Password
		,@FullName,0,@Telephone,''
		,@Mobile,'','',''
		,'','',NULL,@RoleId
		,'','','','0'
		,1,'1',@IssueTime,@DeptId
		,0,0,'00000000-0000-0000-0000-000000000000'
		,0,@ZxsId,'',0)	
	SET @ErrorCount = @ErrorCount + @@ERROR 
	SET @UserId = @@IDENTITY

	IF(@errorcount=0)--����ϵͳĬ�ϵ�ʡ�ݳ�����Ϣ
	BEGIN
		DECLARE @i INT--������
		DECLARE @ProvinceId INT--��˾ʡ�ݱ��
		DECLARE @ProvinceCount INT--ʡ������
		
		SELECT @ProvinceCount=COUNT(*) FROM [tbl_SysProvince]
		SET @i=1

		WHILE(@i<=@ProvinceCount AND @errorcount=0)
		BEGIN
			INSERT INTO [tbl_CompanyProvince]([ProvinceName],[CompanyId],[OperatorId])
			SELECT [ProvinceName],@CompanyId,0 FROM [tbl_SysProvince] WHERE [Id]=@i
			SET @errorcount=@errorcount+@@ERROR
			SET @ProvinceId=@@IDENTITY			

			INSERT INTO [tbl_CompanyCity] ([ProvinceId],[CityName],[CompanyId],[IsFav],[OperatorId])
			SELECT @ProvinceId,[CityName],@CompanyId,'0',0 FROM [tbl_SysCity] WHERE [ProvinceId]=@i
			SET @errorcount=@errorcount+@@ERROR
			SET @i=@i+1
		END
	END
	
	IF(@errorcount=0)
	BEGIN
		INSERT INTO [tbl_Pt_ZhuanXianShang]([ZxsId],[CompanyId],[MingCheng]
			,[ZhuCeHao],[ShuiWuHao],[XuKeZhengHao]
			,[FaRenName],[LxrName],[LxrDianHua]
			,[LxrShouJi],[LxrQQ],[Fax]
			,[ProvinceId],[CityId],[DiZhi]
			,[Logo],[LianXiFangShi],[YinHangZhangHao]
			,[JieShao],[Status],[JiFenStatus]
			,[Privs1],[Privs2],[Privs3]
			,[OperatorId],[IssueTime],[IsDelete]
			,[T1])
		VALUES(@ZxsId,@CompanyId,@SysName
			,'','',''
			,@FullName,@FullName,@Telephone
			,@Mobile,'',''
			,0,0,''
			,'','',''
			,'',0,0
			,'ALL','ALL','ALL'
			,0,@IssueTime,'0'
			,1)
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@ErrorCount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=0
		RETURN 0
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN 1
END
GO*/

ALTER TABLE dbo.tbl_Area ADD
	ZhanDianId int NOT NULL CONSTRAINT DF_tbl_Area_ZhanDianId DEFAULT 0,
	ZxlbId int NOT NULL CONSTRAINT DF_tbl_Area_ZxlbId DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'վ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Area', N'COLUMN', N'ZhanDianId'
GO
DECLARE @v sql_variant 
SET @v = N'ר�������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Area', N'COLUMN', N'ZxlbId'
GO

ALTER TABLE dbo.tbl_KongWei ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_KongWei_ZxsId DEFAULT '',
	ZhanDianId int NOT NULL CONSTRAINT DF_tbl_KongWei_ZhanDianId DEFAULT 0,
	ZxlbId int NOT NULL CONSTRAINT DF_tbl_KongWei_ZxlbId DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_KongWei', N'COLUMN', N'ZxsId'
GO
DECLARE @v sql_variant 
SET @v = N'վ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_KongWei', N'COLUMN', N'ZhanDianId'
GO
DECLARE @v sql_variant 
SET @v = N'ר�������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_KongWei', N'COLUMN', N'ZxlbId'
GO

UPDATE tbl_KongWei SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3 
GO

UPDATE tbl_KongWei SET TianShu=DATEDIFF(DAY,QuDate,HuiDate)+1 WHERE KongWeiType=0 AND TianShu=-1 AND HuiDate IS NOT NULL
GO

ALTER TABLE dbo.tbl_KongWeiDaiLi ADD
	MoBanId char(36) NOT NULL CONSTRAINT DF_tbl_KongWeiDaiLi_MoBanId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'����ģ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_KongWeiDaiLi', N'COLUMN', N'MoBanId'
GO

UPDATE tbl_KongWeiDaiLi SET MoBanId=NEWID()
GO

ALTER TABLE dbo.tbl_TourOrder ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_TourOrder_ZxsId DEFAULT '',
	LatestOperatorId int NOT NULL CONSTRAINT DF_tbl_TourOrder_LatestOperatorId DEFAULT 0,
	LatestTime datetime NOT NULL CONSTRAINT DF_tbl_TourOrder_LatestTime DEFAULT getdate(),
	XiaDanLeiXing tinyint NOT NULL CONSTRAINT DF_tbl_TourOrder_XiaDanLeiXing DEFAULT 0,
	XianLuId char(36) NOT NULL CONSTRAINT DF_tbl_TourOrder_XianLuId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'ZxsId'
GO
DECLARE @v sql_variant 
SET @v = N'�������˱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'LatestOperatorId'
GO
DECLARE @v sql_variant 
SET @v = N'������ʱ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'LatestTime'
GO
DECLARE @v sql_variant 
SET @v = N'�µ�����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'XiaDanLeiXing'
GO
DECLARE @v sql_variant 
SET @v = N'��·��Ʒ���'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'XianLuId'
GO

UPDATE tbl_TourOrder SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC',LatestOperatorId=OperatorId, LatestTime=IssueTime
WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_CompanySupplier ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_CompanySupplier_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanySupplier', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_CompanySupplier SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

GO
ALTER TABLE dbo.tbl_Customer ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_Customer_ZxsId DEFAULT '',
	LaiYuan tinyint NOT NULL CONSTRAINT DF_tbl_Customer_LaiYuan DEFAULT 0,
	ShenHeStatus tinyint NOT NULL CONSTRAINT DF_tbl_Customer_ShenHeStatus DEFAULT 0,
	ShenHeOperatorId int NOT NULL CONSTRAINT DF_tbl_Customer_ShenHeOperatorId DEFAULT 0,
	ShenHeTime datetime NOT NULL CONSTRAINT DF_tbl_Customer_ShenHeTime DEFAULT getdate(),
	YingYeZhiZhaoHao nvarchar(50) NULL,
	FaRenName nvarchar(50) NULL,
	LxrQQ nvarchar(50) NULL,
	LxrEmail nvarchar(50) NULL,
	GongSiDianHua nvarchar(50) NULL,
	GongSiFax nvarchar(50) NULL,
	JianMa nvarchar(50) NULL
GO
DECLARE @v sql_variant 
SET @v = N'��Ҫ��ϵ�˵绰'
EXECUTE sp_updateextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'Phone'
GO
DECLARE @v sql_variant 
SET @v = N'��Ҫ��ϵ���ֻ�'
EXECUTE sp_updateextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'Mobile'
GO
DECLARE @v sql_variant 
SET @v = N'��Ҫ��ϵ�˴���'
EXECUTE sp_updateextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'Fax'
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'ZxsId'
GO
DECLARE @v sql_variant 
SET @v = N'�ͻ���Դ'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'LaiYuan'
GO
DECLARE @v sql_variant 
SET @v = N'���״̬'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'ShenHeStatus'
GO
DECLARE @v sql_variant 
SET @v = N'����˱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'ShenHeOperatorId'
GO
DECLARE @v sql_variant 
SET @v = N'���ʱ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'ShenHeTime'
GO
DECLARE @v sql_variant 
SET @v = N'Ӫҵִ�պ�'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'YingYeZhiZhaoHao'
GO
DECLARE @v sql_variant 
SET @v = N'��������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'FaRenName'
GO
DECLARE @v sql_variant 
SET @v = N'��Ҫ��ϵ��QQ'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'LxrQQ'
GO
DECLARE @v sql_variant 
SET @v = N'��Ҫ��ϵ������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'LxrEmail'
GO
DECLARE @v sql_variant 
SET @v = N'��˾�绰'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'GongSiDianHua'
GO
DECLARE @v sql_variant 
SET @v = N'��˾����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'GongSiFax'
GO
DECLARE @v sql_variant 
SET @v = N'����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'JianMa'
GO

UPDATE tbl_Customer SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC',ShenHeStatus=1 WHERE CompanyId=3
GO

GO
ALTER TABLE dbo.tbl_CustomerContactInfo ADD
	YongHuId int NOT NULL CONSTRAINT DF_tbl_CustomerContactInfo_YongHuId DEFAULT 0,
	Status tinyint NOT NULL CONSTRAINT DF_tbl_CustomerContactInfo_Status DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'�û����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CustomerContactInfo', N'COLUMN', N'YongHuId'
GO
DECLARE @v sql_variant 
SET @v = N'��ϵ��״̬'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CustomerContactInfo', N'COLUMN', N'Status'
GO
UPDATE tbl_CustomerContactInfo SET Status=2 WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinLoan ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinLoan_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinLoan', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_FinLoan SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinApply ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinApply_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinApply', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_FinApply SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_CompanyAccount ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_CompanyAccount_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyAccount', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_CompanyAccount SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinOther ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinOther_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinOther', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_FinOther SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinCope ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinCope_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinCope', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_FinCope SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinYinHangHeDui ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinYinHangHeDui_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinYinHangHeDui', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_FinYinHangHeDui SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinRegister ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinRegister_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinRegister', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_FinRegister SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinRiJiZhang ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinRiJiZhang_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinRiJiZhang', N'COLUMN', N'ZxsId'
GO

UPDATE tbl_FinRiJiZhang SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinFaPiao ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinFaPiao_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinFaPiao', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_FinFaPiao SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinLiRun ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinLiRun_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinLiRun', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_FinLiRun SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinZiChanFuZhai ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinZiChanFuZhai_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinZiChanFuZhai', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_FinZiChanFuZhai SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_FinGongZi ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_FinGongZi_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinGongZi', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_FinGongZi SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_PlanDiJie ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_PlanDiJie_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_PlanDiJie SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_PlanChuPiao ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_PlanChuPiao_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanChuPiao', N'COLUMN', N'ZxsId'
GO
UPDATE tbl_PlanChuPiao SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE CompanyId=3
GO

ALTER TABLE dbo.tbl_TourOrder ADD
	YingErRenShu int NOT NULL CONSTRAINT DF_tbl_TourOrder_YingErRenShu DEFAULT 0,
	BuZhanWeiRenShu int NOT NULL CONSTRAINT DF_tbl_TourOrder_BuZhanWeiRenShu DEFAULT 0,
	ChengRenJiaGe money NOT NULL CONSTRAINT DF_tbl_TourOrder_ChengRenJiaGe DEFAULT 0,
	ErTongJiaGe money NOT NULL CONSTRAINT DF_tbl_TourOrder_ErTongJiaGe DEFAULT 0,
	QuanPeiJiaGe money NOT NULL CONSTRAINT DF_tbl_TourOrder_QuanPeiJiaGe DEFAULT 0,
	YingErJiaGe money NOT NULL CONSTRAINT DF_tbl_TourOrder_YingErJiaGe DEFAULT 0,
	JiaJinE money NOT NULL CONSTRAINT DF_tbl_TourOrder_JiaJinE DEFAULT 0,
	JianJinE money NOT NULL CONSTRAINT DF_tbl_TourOrder_JianJinE DEFAULT 0,
	JiaBeiZhu nvarchar(MAX) NULL,
	JianBeiZhu nvarchar(MAX) NULL,
	BuFangChaRenShu int NOT NULL CONSTRAINT DF_tbl_TourOrder_BuFangChaRenShu DEFAULT 0,
	TuiFangChaRenShu int NOT NULL CONSTRAINT DF_tbl_TourOrder_TuiFangChaRenShu DEFAULT 0,
	BuFangChaJiaGe money NOT NULL CONSTRAINT DF_tbl_TourOrder_BuFangChaJiaGe DEFAULT 0,
	TuiFangChaJiaGe money NOT NULL CONSTRAINT DF_tbl_TourOrder_TuiFangChaJiaGe DEFAULT 0,
	DingDanJinE money NOT NULL CONSTRAINT DF_tbl_TourOrder_DingDanJinE DEFAULT 0,
	JiFen1 int NOT NULL CONSTRAINT DF_tbl_TourOrder_JiFen DEFAULT 0,
	JiFen2 int NOT NULL CONSTRAINT DF_tbl_TourOrder_JiFen2 DEFAULT 0,
	XiaDanBeiZhu nvarchar(MAX) NULL,
	YuanYin1 NVARCHAR(MAX) NULL,
	YuanYin2 NVARCHAR(MAX) NULL	
GO
DECLARE @v sql_variant 
SET @v = N'�ϼƽ��������+-��������+-�˲����'
EXECUTE sp_updateextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'SumPrice'
GO
DECLARE @v sql_variant 
SET @v = N'Ӥ������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'YingErRenShu'
GO
DECLARE @v sql_variant 
SET @v = N'��ռλ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'BuZhanWeiRenShu'
GO
DECLARE @v sql_variant 
SET @v = N'���˵���'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'ChengRenJiaGe'
GO
DECLARE @v sql_variant 
SET @v = N'��ͯ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'ErTongJiaGe'
GO
DECLARE @v sql_variant 
SET @v = N'ȫ�㵥��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'QuanPeiJiaGe'
GO
DECLARE @v sql_variant 
SET @v = N'Ӥ������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'YingErJiaGe'
GO
DECLARE @v sql_variant 
SET @v = N'���ӽ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'JiaJinE'
GO
DECLARE @v sql_variant 
SET @v = N'���ٽ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'JianJinE'
GO
DECLARE @v sql_variant 
SET @v = N'���ӽ�ע'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'JiaBeiZhu'
GO
DECLARE @v sql_variant 
SET @v = N'���ٽ�ע'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'JianBeiZhu'
GO
DECLARE @v sql_variant 
SET @v = N'����������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'BuFangChaRenShu'
GO
DECLARE @v sql_variant 
SET @v = N'�˷�������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'TuiFangChaRenShu'
GO
DECLARE @v sql_variant 
SET @v = N'�������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'BuFangChaJiaGe'
GO
DECLARE @v sql_variant 
SET @v = N'�˷����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'TuiFangChaJiaGe'
GO
DECLARE @v sql_variant 
SET @v = N'�����������˲���������������ã�'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'DingDanJinE'
GO
DECLARE @v sql_variant 
SET @v = N'���˻���'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'JiFen1'
GO
DECLARE @v sql_variant 
SET @v = N'�����ܼ�'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'JiFen2'
GO
DECLARE @v sql_variant 
SET @v = N'�µ���ע'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'XiaDanBeiZhu'
GO
DECLARE @v sql_variant 
SET @v = N'ȡ��ԭ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'YuanYin1'
GO
DECLARE @v sql_variant 
SET @v = N'�ܾ�ԭ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'YuanYin2'
GO
UPDATE tbl_TourOrder SET DingDanJinE=SumPrice
GO

GO
ALTER TABLE dbo.tbl_FinRegisterUnCheck ADD
	LeiXing1 tinyint NOT NULL CONSTRAINT DF_tbl_FinRegisterUnCheck_LeiXing1 DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'��������1'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_FinRegisterUnCheck', N'COLUMN', N'LeiXing1'
GO

UPDATE tbl_FinRegisterUnCheck SET LeiXing1=1 WHERE LeiXing=0
GO

/*
ALTER TABLE dbo.tbl_CompanySetting ADD
	ZxsId char(36) NOT NULL CONSTRAINT DF_tbl_CompanySetting_ZxsId DEFAULT ''
GO
DECLARE @v sql_variant 
SET @v = N'ר���̱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanySetting', N'COLUMN', N'ZxsId'
GO
ALTER TABLE dbo.tbl_CompanySetting
	DROP CONSTRAINT PK_TBL_COMPANYSETTING
GO
ALTER TABLE dbo.tbl_CompanySetting ADD CONSTRAINT
	PK_TBL_COMPANYSETTING PRIMARY KEY CLUSTERED 
	(
	Id,
	FieldName,
	ZxsId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

UPDATE tbl_CompanySetting SET ZxsId='E8B8FC24-D9D6-4647-834F-9A62920C0CBC' WHERE Id=3
GO*/


INSERT INTO tbl_Pt_ZxsKV(CompanyId,ZxsId,K,V) VALUES(3,'E8B8FC24-D9D6-4647-834F-9A62920C0CBC','LogoFilepath','/images/logo.png')
INSERT INTO tbl_Pt_ZxsKV(CompanyId,ZxsId,K,V) VALUES(3,'E8B8FC24-D9D6-4647-834F-9A62920C0CBC','TuZhangFilepath','/UploadFiles/3/2013/1/201301240923288138797.png')
INSERT INTO tbl_Pt_ZxsKV(CompanyId,ZxsId,K,V) VALUES(3,'E8B8FC24-D9D6-4647-834F-9A62920C0CBC','SFKYHZH','5d503028-c8bb-41a1-aa2b-912035ccb0f3')
INSERT INTO tbl_Pt_ZxsKV(CompanyId,ZxsId,K,V) VALUES(3,'E8B8FC24-D9D6-4647-834F-9A62920C0CBC','SFKZFFS','0')
GO

INSERT INTO [tbl_CompanySetting](Id,FieldName,FieldValue)VALUES(3,'SysLogoFilepath','/images/logo.2014.png')
GO

ALTER TABLE dbo.tbl_CompanyAccount ADD
	LeiXing tinyint NOT NULL CONSTRAINT DF_tbl_CompanyAccount_LeiXing DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'�˻�����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyAccount', N'COLUMN', N'LeiXing'
GO

SET IDENTITY_INSERT [tbl_Pt_JingDianQuYu] ON
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 1,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 2,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 3,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 4,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 5,3,N'������',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 6,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 7,3,N'�Ĵ�',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 8,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 9,3,N'ɽ��',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 10,3,N'�㶫',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 11,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 12,3,N'���ɹ�',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 13,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 14,3,N'����',0)
INSERT [tbl_Pt_JingDianQuYu] ([QuYuId],[CompanyId],[MingCheng],[PaiXuId]) VALUES ( 15,3,N'ɽ��',0)
SET IDENTITY_INSERT [tbl_Pt_JingDianQuYu] OFF
GO

ALTER TABLE dbo.tbl_PlanDiJie ADD
	YingErShu int NOT NULL CONSTRAINT DF_tbl_PlanDiJie_YingErShu DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'Ӥ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PlanDiJie', N'COLUMN', N'YingErShu'
GO

ALTER TABLE dbo.tbl_Route ADD
	FengMian nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'��·����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Route', N'COLUMN', N'FengMian'
GO

ALTER TABLE dbo.tbl_Customer ADD
	Logo nvarchar(255) NULL,
	JieShao nvarchar(MAX) NULL,
	LatestOperatorId int NOT NULL CONSTRAINT DF_tbl_Customer_LatestOperatorId DEFAULT 0,
	LatestTime datetime NOT NULL CONSTRAINT DF_tbl_Customer_LatestTime DEFAULT getdate()
GO
DECLARE @v sql_variant 
SET @v = N'�ͻ�logo'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'Logo'
GO
DECLARE @v sql_variant 
SET @v = N'�ͻ�����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'JieShao'
GO
DECLARE @v sql_variant 
SET @v = N'�������˱��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'LatestOperatorId'
GO
DECLARE @v sql_variant 
SET @v = N'������ʱ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'LatestTime'
GO

UPDATE tbl_Customer SET LatestOperatorId=OperatorId,LatestTime=IssueTime 
GO

ALTER TABLE dbo.tbl_CompanyUser ADD
	WeiXinHao nvarchar(50) NULL,
	BuMenName nvarchar(255) NULL,
	DanJuTaiTouMingCheng nvarchar(255) NULL,
	DanJuTaiTouDiZhi nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'΢�ź�'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'WeiXinHao'
GO
DECLARE @v sql_variant 
SET @v = N'���ţ����в���'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'BuMenName'
GO
DECLARE @v sql_variant 
SET @v = N'����̧ͷ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'DanJuTaiTouMingCheng'
GO
DECLARE @v sql_variant 
SET @v = N'����̧ͷ��ַ'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'DanJuTaiTouDiZhi'
GO

ALTER TABLE dbo.tbl_CustomerContactInfo ADD
	WeiXinHao nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'΢�ź�'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CustomerContactInfo', N'COLUMN', N'WeiXinHao'
GO

ALTER TABLE dbo.tbl_CompanyUser ADD
	KeYongJiFen int NOT NULL CONSTRAINT DF_tbl_CompanyUser_KeYongJiFen DEFAULT 0,
	DongJieJiFen int NOT NULL CONSTRAINT DF_tbl_CompanyUser_DongJieJiFen DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'��ǰ���û���'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'KeYongJiFen'
GO
DECLARE @v sql_variant 
SET @v = N'��ǰ�������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'DongJieJiFen'
GO

ALTER TABLE dbo.tbl_TourOrder ADD
	JiaGeMingXi nvarchar(MAX) NULL,
	DingDanLxrXingMing nvarchar(255) NULL,
	DingDanLxrShouJi nvarchar(255) NULL,
	DingDanLxrDianHua nvarchar(255) NULL,
	DingDanLxrFax nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'�۸���ϸ'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'JiaGeMingXi'
GO
DECLARE @v sql_variant 
SET @v = N'������ϵ������'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'DingDanLxrXingMing'
GO
DECLARE @v sql_variant 
SET @v = N'������ϵ���ֻ�'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'DingDanLxrShouJi'
GO
DECLARE @v sql_variant 
SET @v = N'������ϵ�˵绰'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'DingDanLxrDianHua'
GO
DECLARE @v sql_variant 
SET @v = N'������ϵ�˴���'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_TourOrder', N'COLUMN', N'DingDanLxrFax'
GO

INSERT [tbl_Pt_KV] ([CompanyId],[K],[V],[OperatorId],[IssueTime],[K1]) VALUES ( 3,N'�һ�����SMTP������',N'smtp.163.com',0,N'2014-09-15',9)
INSERT [tbl_Pt_KV] ([CompanyId],[K],[V],[OperatorId],[IssueTime],[K1]) VALUES ( 3,N'�һ����뷢���������˺�',N'jmglv_noreply@163.com',0,N'2014-09-15',10)
INSERT [tbl_Pt_KV] ([CompanyId],[K],[V],[OperatorId],[IssueTime],[K1]) VALUES ( 3,N'�һ����뷢������������',N'jmglv123456',0,N'2014-09-15',11)
INSERT [tbl_Pt_KV] ([CompanyId],[K],[V],[OperatorId],[IssueTime],[K1]) VALUES ( 3,N'�һ������ʼ�����',N'<span style="color:#2672ec;font-size:31px;">��â��������-�һ�������֤��</span><br/>��ʹ��������֤��Ϊ����˻��������롣<br/>�����֤�����£�<b><%=YanZhengMaZhanWeiFu%></b><br/>�����û�������һ����룬���Ժ��Ըõ����ʼ��������û������ڳ������������Լ�������ʱ�������������ĵ����ʼ���ַ��<br/>лл!<br/>��â��������',0,N'2014-09-15',12)
INSERT [tbl_Pt_KV] ([CompanyId],[K],[V],[OperatorId],[IssueTime],[K1]) VALUES ( 3,N'�һ������ʼ�����',N'�һ�������֤��-��â��������',0,N'2014-09-15',13)
INSERT [tbl_Pt_KV] ([CompanyId],[K],[V],[OperatorId],[IssueTime],[K1]) VALUES ( 3,N'�һ����뷢������ʾ��',N'��â��������',0,N'2014-09-15',14)
GO

ALTER TABLE dbo.tbl_PersonnelInfo ADD
	WeiXinHao nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'΢�ź�'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_PersonnelInfo', N'COLUMN', N'WeiXinHao'
GO
--������־�Ѹ��� ����־ 09 19 2014  5:34PM
GO

GO
ALTER TABLE dbo.tbl_KongWei ADD
	PingTaiShuLiang int NOT NULL CONSTRAINT DF_tbl_KongWei_PingTaiShuLiang DEFAULT 0,
	PingTaiShouKeStatus tinyint NOT NULL CONSTRAINT DF_tbl_KongWei_PingTaiShouKeStatus DEFAULT 0
GO
DECLARE @v sql_variant 
SET @v = N'ƽ̨��λ����(����ͬ��ƽ̨����չʾ�Ŀ�λ��)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_KongWei', N'COLUMN', N'PingTaiShuLiang'
GO
DECLARE @v sql_variant 
SET @v = N'ƽ̨��λ�տ�״̬(����ͬ��ƽ̨��λ�տ�״̬)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_KongWei', N'COLUMN', N'PingTaiShouKeStatus'
GO

ALTER TABLE dbo.tbl_Customer ADD
	DanJuDaYinMoBan nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'���ݴ�ӡģ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'DanJuDaYinMoBan'
GO

ALTER TABLE dbo.tbl_CompanyUser ADD
	DanJuDaYinMoBan nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'���ݴ�ӡģ��'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'DanJuDaYinMoBan'
GO

ALTER TABLE dbo.tbl_CompanyUser ADD
	DanJuTaiTouDianHua nvarchar(255) NULL
GO
DECLARE @v sql_variant 
SET @v = N'����̧ͷ�绰'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyUser', N'COLUMN', N'DanJuTaiTouDianHua'
GO

UPDATE tbl_KongWei SET PingTaiShuLiang=ShuLiang WHERE CompanyId=3
GO
