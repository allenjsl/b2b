--����Ҽ��-̨��ϵͳ���ݵ���-��ṹ�޸� 
--����־ 10 14 2013  4:31PM

ALTER TABLE dbo.tbl_CompanyCity ADD
	WZID int NULL
GO
DECLARE @v sql_variant 
SET @v = N'����Ҽ��ϵͳ���б��[�����ݵ���ʹ��]'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyCity', N'COLUMN', N'WZID'
GO

ALTER TABLE dbo.tbl_CompanyProvince ADD
	WZID int NULL
GO
DECLARE @v sql_variant 
SET @v = N'����Ҽ��ϵͳʡ�ݱ��[�����ݵ���ʹ��]'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyProvince', N'COLUMN', N'WZID'
GO

ALTER TABLE dbo.tbl_CompanySupplier ADD
	WZID char(36) NULL
GO
DECLARE @v sql_variant 
SET @v = N'����Ҽ��ϵͳ��Ӧ�̱��[�����ݵ���ʹ��]'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanySupplier', N'COLUMN', N'WZID'
GO

ALTER TABLE dbo.tbl_Customer ADD
	WZID char(36) NULL
GO
DECLARE @v sql_variant 
SET @v = N'����Ҽ��ϵͳ�ͻ����[�����ݵ���ʹ��]'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'WZID'
GO
