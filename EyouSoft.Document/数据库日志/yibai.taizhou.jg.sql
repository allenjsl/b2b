--温州壹佰-台州系统数据导入-库结构修改 
--汪奇志 10 14 2013  4:31PM

ALTER TABLE dbo.tbl_CompanyCity ADD
	WZID int NULL
GO
DECLARE @v sql_variant 
SET @v = N'温州壹佰系统城市编号[供数据导入使用]'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyCity', N'COLUMN', N'WZID'
GO

ALTER TABLE dbo.tbl_CompanyProvince ADD
	WZID int NULL
GO
DECLARE @v sql_variant 
SET @v = N'温州壹佰系统省份编号[供数据导入使用]'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanyProvince', N'COLUMN', N'WZID'
GO

ALTER TABLE dbo.tbl_CompanySupplier ADD
	WZID char(36) NULL
GO
DECLARE @v sql_variant 
SET @v = N'温州壹佰系统供应商编号[供数据导入使用]'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_CompanySupplier', N'COLUMN', N'WZID'
GO

ALTER TABLE dbo.tbl_Customer ADD
	WZID char(36) NULL
GO
DECLARE @v sql_variant 
SET @v = N'温州壹佰系统客户编号[供数据导入使用]'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_Customer', N'COLUMN', N'WZID'
GO
