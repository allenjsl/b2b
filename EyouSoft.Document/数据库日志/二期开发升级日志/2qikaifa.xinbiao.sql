if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_CuXiaoFuJian') and o.name = 'FK_TBL_PT_CUXIAOFUJIAN_REFERENCE_TBL_PT_CUXIAO')
alter table tbl_Pt_CuXiaoFuJian
   drop constraint FK_TBL_PT_CUXIAOFUJIAN_REFERENCE_TBL_PT_CUXIAO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_GuangGaoFuJian') and o.name = 'FK_TBL_PT_GUANGGAOFUJIAN_REFERENCE_TBL_PT_GUANGGAO')
alter table tbl_Pt_GuangGaoFuJian
   drop constraint FK_TBL_PT_GUANGGAOFUJIAN_REFERENCE_TBL_PT_GUANGGAO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_JiFenDingDanLiShiLiShi') and o.name = 'FK_TBL_PT_JIFENDINGDANLISHILISHI_REFERENCE_TBL_PT_JIFENDINGDAN')
alter table tbl_Pt_JiFenDingDanLiShiLiShi
   drop constraint FK_TBL_PT_JIFENDINGDANLISHILISHI_REFERENCE_TBL_PT_JIFENDINGDAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_JiFenShangPinFuJian') and o.name = 'FK_TBL_PT_JIFENSHANGPINFUJIAN_REFERENCE_TBL_PT_JIFENSHANGPIN')
alter table tbl_Pt_JiFenShangPinFuJian
   drop constraint FK_TBL_PT_JIFENSHANGPINFUJIAN_REFERENCE_TBL_PT_JIFENSHANGPIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_JingDianFuJian') and o.name = 'FK_TBL_PT_JINGDIANFUJIAN_REFERENCE_TBL_PT_JINGDIAN')
alter table tbl_Pt_JingDianFuJian
   drop constraint FK_TBL_PT_JINGDIANFUJIAN_REFERENCE_TBL_PT_JINGDIAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_JiuDianFangXing') and o.name = 'FK_TBL_PT_JIUDIANFANGXING_REFERENCE_TBL_PT_JIUDIAN')
alter table tbl_Pt_JiuDianFangXing
   drop constraint FK_TBL_PT_JIUDIANFANGXING_REFERENCE_TBL_PT_JIUDIAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_JiuDianFangXingFuJian') and o.name = 'FK_TBL_PT_JIUDIANFANGXINGFUJIAN_REFERENCE_TBL_PT_JIUDIANFANGXING')
alter table tbl_Pt_JiuDianFangXingFuJian
   drop constraint FK_TBL_PT_JIUDIANFANGXINGFUJIAN_REFERENCE_TBL_PT_JIUDIANFANGXING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_JiuDianFuJian') and o.name = 'FK_TBL_PT_JIUDIANFUJIAN_REFERENCE_TBL_PT_JIUDIAN')
alter table tbl_Pt_JiuDianFuJian
   drop constraint FK_TBL_PT_JIUDIANFUJIAN_REFERENCE_TBL_PT_JIUDIAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_TuiJianFuJian') and o.name = 'FK_TBL_PT_TUIJIANFUJIAN_REFERENCE_TBL_PT_TUIJIAN')
alter table tbl_Pt_TuiJianFuJian
   drop constraint FK_TBL_PT_TUIJIANFUJIAN_REFERENCE_TBL_PT_TUIJIAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_ZhuanXaingShangZhanDian') and o.name = 'FK_TBL_PT_ZHUANXAINGSHANGZHANDIAN_REFERENCE_TBL_PT_ZHUANXIANSHANG')
alter table tbl_Pt_ZhuanXaingShangZhanDian
   drop constraint FK_TBL_PT_ZHUANXAINGSHANGZHANDIAN_REFERENCE_TBL_PT_ZHUANXIANSHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_ZhuanXianShangQQ') and o.name = 'FK_TBL_PT_ZHUANXIANSHANGQQ_REFERENCE_TBL_PT_ZHUANXIANSHANG')
alter table tbl_Pt_ZhuanXianShangQQ
   drop constraint FK_TBL_PT_ZHUANXIANSHANGQQ_REFERENCE_TBL_PT_ZHUANXIANSHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_Pt_ZiXunFuJian') and o.name = 'FK_TBL_PT_ZIXUNFUJIAN_REFERENCE_TBL_PT_ZIXUN')
alter table tbl_Pt_ZiXunFuJian
   drop constraint FK_TBL_PT_ZIXUNFUJIAN_REFERENCE_TBL_PT_ZIXUN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_CuXiao')
            and   type = 'U')
   drop table tbl_Pt_CuXiao
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_CuXiaoFuJian')
            and   type = 'U')
   drop table tbl_Pt_CuXiaoFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_FinJiFenJieSuan')
            and   type = 'U')
   drop table tbl_Pt_FinJiFenJieSuan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_GuangGao')
            and   type = 'U')
   drop table tbl_Pt_GuangGao
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_GuangGaoFuJian')
            and   type = 'U')
   drop table tbl_Pt_GuangGaoFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JiFenDingDan')
            and   type = 'U')
   drop table tbl_Pt_JiFenDingDan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JiFenDingDanLiShiLiShi')
            and   type = 'U')
   drop table tbl_Pt_JiFenDingDanLiShiLiShi
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JiFenShangPin')
            and   type = 'U')
   drop table tbl_Pt_JiFenShangPin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JiFenShangPinFuJian')
            and   type = 'U')
   drop table tbl_Pt_JiFenShangPinFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JingDian')
            and   type = 'U')
   drop table tbl_Pt_JingDian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JingDianFuJian')
            and   type = 'U')
   drop table tbl_Pt_JingDianFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JingDianQuYu')
            and   type = 'U')
   drop table tbl_Pt_JingDianQuYu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JiuDian')
            and   type = 'U')
   drop table tbl_Pt_JiuDian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JiuDianFangXing')
            and   type = 'U')
   drop table tbl_Pt_JiuDianFangXing
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JiuDianFangXingFuJian')
            and   type = 'U')
   drop table tbl_Pt_JiuDianFangXingFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_JiuDianFuJian')
            and   type = 'U')
   drop table tbl_Pt_JiuDianFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_KV')
            and   type = 'U')
   drop table tbl_Pt_KV
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_KongWeiBeiZhu')
            and   type = 'U')
   drop table tbl_Pt_KongWeiBeiZhu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_KongWeiMoBan')
            and   type = 'U')
   drop table tbl_Pt_KongWeiMoBan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_KongWeiXianLu')
            and   type = 'U')
   drop table tbl_Pt_KongWeiXianLu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_QuYuShengFenChengShi')
            and   type = 'U')
   drop table tbl_Pt_QuYuShengFenChengShi
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_RouteFuJian')
            and   type = 'U')
   drop table tbl_Pt_RouteFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_TuiJian')
            and   type = 'U')
   drop table tbl_Pt_TuiJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_TuiJianFuJian')
            and   type = 'U')
   drop table tbl_Pt_TuiJianFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_YanZhengMa')
            and   type = 'U')
   drop table tbl_Pt_YanZhengMa
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_YongHuJiFenMingXi')
            and   type = 'U')
   drop table tbl_Pt_YongHuJiFenMingXi
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_YongHuLoginLog')
            and   type = 'U')
   drop table tbl_Pt_YongHuLoginLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_YuMing')
            and   type = 'U')
   drop table tbl_Pt_YuMing
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZhanDian')
            and   type = 'U')
   drop table tbl_Pt_ZhanDian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZhanDianXzqhdm')
            and   type = 'U')
   drop table tbl_Pt_ZhanDianXzqhdm
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZhuanXaingShangZhanDian')
            and   type = 'U')
   drop table tbl_Pt_ZhuanXaingShangZhanDian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZhuanXianLeiBie')
            and   type = 'U')
   drop table tbl_Pt_ZhuanXianLeiBie
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZhuanXianShang')
            and   type = 'U')
   drop table tbl_Pt_ZhuanXianShang
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZhuanXianShangQQ')
            and   type = 'U')
   drop table tbl_Pt_ZhuanXianShangQQ
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZiXun')
            and   type = 'U')
   drop table tbl_Pt_ZiXun
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZiXunFuJian')
            and   type = 'U')
   drop table tbl_Pt_ZiXunFuJian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Pt_ZxsKV')
            and   type = 'U')
   drop table tbl_Pt_ZxsKV
go

/*==============================================================*/
/* Table: tbl_Pt_CuXiao                                         */
/*==============================================================*/
create table tbl_Pt_CuXiao (
   CuXiaoId             char(36)             not null,
   CompanyId            int                  not null,
   BiaoTi               nvarchar(255)        null,
   NeiRong              nvarchar(max)        null,
   FengMian             nvarchar(255)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   IdentityId           int                  identity,
   PaiXuId              int                  not null default 0,
   ShiJian1             datetime             not null default getdate(),
   ShiJian2             datetime             not null default getdate(),
   JianYaoJieShao       nvarchar(max)        null,
   constraint PK_TBL_PT_CUXIAO primary key (CuXiaoId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ̨������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'CuXiaoId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'BiaoTi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'NeiRong'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'FengMian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ֵ',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʼʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'ShiJian1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'ShiJian2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ҫ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiao', 'column', 'JianYaoJieShao'
go

/*==============================================================*/
/* Table: tbl_Pt_CuXiaoFuJian                                   */
/*==============================================================*/
create table tbl_Pt_CuXiaoFuJian (
   FuJianId             int                  identity,
   CuXiaoId             char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ̨����������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiaoFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiaoFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiaoFuJian', 'column', 'CuXiaoId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiaoFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiaoFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_CuXiaoFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_FinJiFenJieSuan                                */
/*==============================================================*/
create table tbl_Pt_FinJiFenJieSuan (
   JieSuanId            char(36)             not null,
   ZxsId                char(36)             not null,
   CompanyId            int                  not null,
   JieSuanRiQi          datetime             not null,
   JieSuanRenName       nvarchar(255)        null,
   JiFen                int                  not null default 0,
   JinE                 money                not null default 0,
   JieSuanFangShi       tinyint              not null default 0,
   JieSuanZhangHao      nvarchar(255)        null,
   JieSuanBeiZhu        nvarchar(255)        null,
   Status               tinyint              not null default 0,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   ShenPiRenId          int                  null,
   ShenPiBeiZhu         nvarchar(255)        null,
   ShenPiShiJian        datetime             null,
   constraint PK_TBL_PT_FINJIFENJIESUAN primary key (JieSuanId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���̻��ֽ�����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'JieSuanId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���̱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'ZxsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'JieSuanRiQi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'JieSuanRenName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'JiFen'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'JinE'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�տʽ',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'JieSuanFangShi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�տ��˺�',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'JieSuanZhangHao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���㱸ע',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'JieSuanBeiZhu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'ShenPiRenId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ע',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'ShenPiBeiZhu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_FinJiFenJieSuan', 'column', 'ShenPiShiJian'
go

/*==============================================================*/
/* Table: tbl_Pt_GuangGao                                       */
/*==============================================================*/
create table tbl_Pt_GuangGao (
   GuangGaoId           char(36)             not null,
   CompanyId            int                  not null,
   WeiZhi               tinyint              not null default 0,
   MingCheng            nvarchar(255)        null,
   Filepath             nvarchar(255)        null,
   Url                  nvarchar(255)        null,
   NeiRong              nvarchar(max)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           int                  not null,
   PaiXuId              int                  not null default 0,
   Status               tinyint              not null default 0,
   constraint PK_TBL_PT_GUANGGAO primary key (GuangGaoId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨�����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'GuangGaoId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���λ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'WeiZhi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͼƬ',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'Url'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'NeiRong'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGao', 'column', 'Status'
go

/*==============================================================*/
/* Table: tbl_Pt_GuangGaoFuJian                                 */
/*==============================================================*/
create table tbl_Pt_GuangGaoFuJian (
   FuJianId             int                  identity,
   GuangGaoId           char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_GUANGGAOFUJIAN primary key (FuJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨��渽����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGaoFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGaoFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGaoFuJian', 'column', 'GuangGaoId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGaoFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGaoFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_GuangGaoFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_JiFenDingDan                                   */
/*==============================================================*/
create table tbl_Pt_JiFenDingDan (
   DingDanId            char(36)             not null,
   CompanyId            int                  not null,
   ShangPinId           char(36)             not null,
   JiaoYiHao            nvarchar(255)        null,
   ShuLiang             int                  not null default 0,
   JiFen1               int                  not null default 0,
   JiFen2               int                  not null default 0,
   Status               tinyint              not null default 0,
   LxrXingMing          nvarchar(255)        null,
   LxrDianHua           nvarchar(255)        null,
   LxrShouJi            nvarchar(255)        null,
   LxrYouXiang          nvarchar(255)        null,
   LxrProvinceId        int                  not null default 0,
   LxrCityId            int                  not null default 0,
   LxrDiZhi             nvarchar(255)        null,
   LxrYouBian           nvarchar(255)        null,
   XiaDanBeiZhu         nvarchar(255)        null,
   XiaDanRenId          int                  not null,
   IssueTime            datetime             not null default getdate(),
   KuaiDi               nvarchar(255)        null,
   FuKuanShiJian        datetime             null,
   FuKuanJinE           money                not null default 0,
   FuKuanFangShi        tinyint              not null default 0,
   FuKuanZhangHao       nvarchar(255)        null,
   FuKuanDuiFangDanWei  nvarchar(255)        null,
   FuKuanBeiZhu         nvarchar(255)        null,
   FuKuanOperatorId     int                  null,
   FuKuanTime           datetime             null,
   FuKuanStatus         tinyint              not null default 0,
   FuKuanShenPiRenId    int                  null,
   FuKuanShenPiShiJian  datetime             null,
   FuKuanShenPiBeiZhu   nvarchar(255)        null,
   FuKuanZhiFuRenId     int                  null,
   FuKuanZhiFuShiJian   datetime             null,
   FuKuanZhiFuBeiZhu    nvarchar(255)        null,
   IdentityId           int                  identity,
   LatestOperatorId     int                  not null default 0,
   LatestTime           datetime             not null default getdate(),
   constraint PK_TBL_PT_JIFENDINGDAN primary key (DingDanId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨���ֶ�����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'DingDanId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'ShangPinId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'JiaoYiHao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�һ�����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'ShuLiang'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�һ�����(����)',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'JiFen1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�һ�����(��)',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'JiFen2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LxrXingMing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ�˵绰',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LxrDianHua'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ���ֻ�',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LxrShouJi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LxrYouXiang'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ��ʡ�ݱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LxrProvinceId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ�˳��б��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LxrCityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ�˵�ַ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LxrDiZhi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ���ʱ�',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LxrYouBian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�µ���ע',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'XiaDanBeiZhu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�µ��˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'XiaDanRenId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�µ�ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'KuaiDi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanShiJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanJinE'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʽ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanFangShi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����˺�',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanZhangHao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Է���λ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanDuiFangDanWei'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ע',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanBeiZhu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanOperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanStatus'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���������˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanShenPiRenId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanShenPiShiJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������ע',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanShenPiBeiZhu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����֧���˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanZhiFuRenId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����֧��ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanZhiFuShiJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����֧����ע',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'FuKuanZhiFuBeiZhu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LatestOperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDan', 'column', 'LatestTime'
go

/*==============================================================*/
/* Table: tbl_Pt_JiFenDingDanLiShiLiShi                         */
/*==============================================================*/
create table tbl_Pt_JiFenDingDanLiShiLiShi (
   JiLuId               int                  identity,
   DingDanId            char(36)             not null,
   Status               tinyint              not null,
   FuKuanStatus         tinyint              not null,
   BeiZhu               nvarchar(255)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_JIFENDINGDANLISHILIS primary key (JiLuId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨���ֶ�����ʷ��¼��Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��¼���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi', 'column', 'JiLuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi', 'column', 'DingDanId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi', 'column', 'FuKuanStatus'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ע',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi', 'column', 'BeiZhu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenDingDanLiShiLiShi', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_JiFenShangPin                                  */
/*==============================================================*/
create table tbl_Pt_JiFenShangPin (
   ShangPinId           char(36)             not null,
   CompanyId            int                  not null,
   BianMa               nvarchar(255)        null,
   MingCheng            nvarchar(255)        null,
   JiaGe                money                not null default 0,
   JiFen                int                  not null default 0,
   LeiXing              tinyint              not null default 0,
   Status               tinyint              not null default 0,
   FengMian             nvarchar(255)        null,
   MiaoShu              nvarchar(max)        null,
   DuiHuanXuZhi         nvarchar(max)        null,
   PeiSongShuoMing      nvarchar(max)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   IsDelete             char(1)              not null default '0',
   constraint PK_TBL_PT_JIFENSHANGPIN primary key (ShangPinId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨������Ʒ��Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'ShangPinId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'BianMa'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г��۸�',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'JiaGe'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�һ�����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'JiFen'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'FengMian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'MiaoShu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�һ���֪',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'DuiHuanXuZhi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����˵��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'PeiSongShuoMing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPin', 'column', 'IsDelete'
go

/*==============================================================*/
/* Table: tbl_Pt_JiFenShangPinFuJian                            */
/*==============================================================*/
create table tbl_Pt_JiFenShangPinFuJian (
   FuJianId             int                  identity,
   ShangPinId           char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_JIFENSHANGPINFUJIAN primary key (FuJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨������Ʒ������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPinFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPinFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPinFuJian', 'column', 'ShangPinId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPinFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPinFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiFenShangPinFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_JingDian                                       */
/*==============================================================*/
create table tbl_Pt_JingDian (
   JingDianId           char(36)             not null,
   CompanyId            int                  not null,
   MingCheng            nvarchar(255)        null,
   QuYuId               int                  not null default 0,
   JieShao              nvarchar(max)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   IdentityId           int                  identity,
   FengMian             nvarchar(255)        null,
   PaiXuId              int                  not null default 0,
   JingDianYongHuId     int                  not null default 0,
   DiZhi                nvarchar(255)        null,
   constraint PK_TBL_PT_JINGDIAN primary key (JingDianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'JingDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'QuYuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'JieShao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'FengMian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����û����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'JingDianYongHuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ַ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDian', 'column', 'DiZhi'
go

/*==============================================================*/
/* Table: tbl_Pt_JingDianFuJian                                 */
/*==============================================================*/
create table tbl_Pt_JingDianFuJian (
   FuJianId             int                  identity,
   JingDianId           char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_JINGDIANFUJIAN primary key (FuJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨���㸽����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianFuJian', 'column', 'JingDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_JingDianQuYu                                   */
/*==============================================================*/
create table tbl_Pt_JingDianQuYu (
   QuYuId               int                  identity,
   CompanyId            int                  not null,
   MingCheng            nvarchar(255)        not null,
   PaiXuId              int                  not null default 0,
   OperatorId           int                  not null default 0,
   IssueTime            datetime             not null default getdate(),
   IsDelete             char(1)              not null default '0',
   constraint PK_TBL_PT_JINGDIANQUYU primary key (QuYuId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianQuYu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianQuYu', 'column', 'QuYuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianQuYu', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianQuYu', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianQuYu', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianQuYu', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianQuYu', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JingDianQuYu', 'column', 'IsDelete'
go

/*==============================================================*/
/* Table: tbl_Pt_JiuDian                                        */
/*==============================================================*/
create table tbl_Pt_JiuDian (
   JiuDianId            char(36)             not null,
   CompanyId            int                  not null,
   MingCheng            nvarchar(255)        null,
   ProvinceId           int                  not null default 0,
   CityId               int                  not null default 0,
   DiZhi                nvarchar(255)        null,
   KaiYeShiJian         nvarchar(255)        null,
   LouCengShuLiang      nvarchar(255)        null,
   ZhuangXiuShiJian     nvarchar(255)        null,
   XingJi               tinyint              not null default 0,
   DianHua              nvarchar(255)        null,
   JianJie              nvarchar(max)        null,
   JiaoTong             nvarchar(max)        null,
   WangLuo              nvarchar(max)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   IdentityId           int                  identity,
   FengMian             nvarchar(255)        null,
   JiuDianYongHuId      int                  not null default 0,
   PaiXuId              int                  not null default 0,
   JianYaoJieShao       nvarchar(max)        null,
   constraint PK_TBL_PT_JIUDIAN primary key (JiuDianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨�Ƶ���Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'JiuDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ�����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʡ�ݱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'ProvinceId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���б��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'CityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ��ַ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'DiZhi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ҵʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'KaiYeShiJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '¥������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'LouCengShuLiang'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'װ��ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'ZhuangXiuShiJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ��Ǽ�',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'XingJi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ�绰',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'DianHua'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'JianJie'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ͨ��Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'JiaoTong'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ʩ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'WangLuo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'FengMian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ��û����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'JiuDianYongHuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ҫ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDian', 'column', 'JianYaoJieShao'
go

/*==============================================================*/
/* Table: tbl_Pt_JiuDianFangXing                                */
/*==============================================================*/
create table tbl_Pt_JiuDianFangXing (
   FangXingId           char(36)             not null,
   JiuDianId            char(36)             not null,
   MingCheng            nvarchar(255)        null,
   ShuLiang             nvarchar(255)        null,
   MianJi               nvarchar(255)        null,
   LouCeng              nvarchar(255)        null,
   ChuangWeiPeiZhi      nvarchar(255)        null,
   KeFangSheShi         nvarchar(255)        null,
   GuaPaiJiaGe          money                not null default 0,
   JieShao              nvarchar(255)        null,
   IdentityId           int                  identity,
   FengMian             nvarchar(255)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   PaiXuId              int                  not null default 0,
   RuZhuRiQi1           datetime             not null default getdate(),
   RuZhuRiQi2           datetime             not null default getdate(),
   YouHuiJiaGe          money                not null default 0,
   constraint PK_TBL_PT_JIUDIANFANGXING primary key (FangXingId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨�Ƶ귿����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'FangXingId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'JiuDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'ShuLiang'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'MianJi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����¥��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'LouCeng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'ChuangWeiPeiZhi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ͷ���ʩ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'KeFangSheShi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���Ƽ۸�',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'GuaPaiJiaGe'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͽ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'JieShao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͷ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'FengMian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ס������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'RuZhuRiQi1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ס����ֹ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'RuZhuRiQi2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Żݼ�',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXing', 'column', 'YouHuiJiaGe'
go

/*==============================================================*/
/* Table: tbl_Pt_JiuDianFangXingFuJian                          */
/*==============================================================*/
create table tbl_Pt_JiuDianFangXingFuJian (
   FuJianId             int                  identity,
   FangXingId           char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_JIUDIANFANGXINGFUJIA primary key (FuJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨�Ƶ귿�͸�����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXingFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXingFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ͱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXingFuJian', 'column', 'FangXingId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXingFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXingFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFangXingFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_JiuDianFuJian                                  */
/*==============================================================*/
create table tbl_Pt_JiuDianFuJian (
   FuJianId             int                  identity,
   JiuDianId            char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_JIUDIANFUJIAN primary key (FuJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨�Ƶ긽����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƶ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFuJian', 'column', 'JiuDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_JiuDianFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_KV                                             */
/*==============================================================*/
create table tbl_Pt_KV (
   CompanyId            int                  not null,
   K                    nvarchar(50)         not null,
   V                    nvarchar(max)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   K1                   int                  not null default 0
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_KV'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KV', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'K',
   'user', @CurrentUser, 'table', 'tbl_Pt_KV', 'column', 'K'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'V',
   'user', @CurrentUser, 'table', 'tbl_Pt_KV', 'column', 'V'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KV', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KV', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'K1',
   'user', @CurrentUser, 'table', 'tbl_Pt_KV', 'column', 'K1'
go

/*==============================================================*/
/* Table: tbl_Pt_KongWeiBeiZhu                                  */
/*==============================================================*/
create table tbl_Pt_KongWeiBeiZhu (
   IdentityId           int                  identity,
   BeiZhuId             char(36)             not null,
   KongWeiId            char(36)             not null,
   NeiRong              nvarchar(max)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           int                  not null,
   Status               tinyint              not null default 0,
   LatestOperatorId     int                  not null,
   LatestTime           datetime             not null default getdate(),
   constraint PK_TBL_PT_KONGWEIBEIZHU primary key (IdentityId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ƻ�λ������ע',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ע���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'BeiZhuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'KongWeiId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע����',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'NeiRong'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������˱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'LatestOperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiBeiZhu', 'column', 'LatestTime'
go

/*==============================================================*/
/* Table: tbl_Pt_KongWeiMoBan                                   */
/*==============================================================*/
create table tbl_Pt_KongWeiMoBan (
   IdentityId           int                  identity,
   CompanyId            int                  null,
   ZxsId                char(36)             null,
   MoBanId              char(36)             not null,
   PiCiCode             nvarchar(50)         null,
   PiCiXuHao            int                  null,
   IssueTime            datetime             null,
   constraint PK_TBL_PT_KONGWEIMOBAN primary key (MoBanId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ƻ�λģ����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiMoBan'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiMoBan', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiMoBan', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���̱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiMoBan', 'column', 'ZxsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ģ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiMoBan', 'column', 'MoBanId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ģ�����δ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiMoBan', 'column', 'PiCiCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ģ���������',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiMoBan', 'column', 'PiCiXuHao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ģ��ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiMoBan', 'column', 'IssueTime'
go

/*==============================================================*/
/* Table: tbl_Pt_KongWeiXianLu                                  */
/*==============================================================*/
create table tbl_Pt_KongWeiXianLu (
   IdentityId           int                  identity,
   XianLuId             char(36)             not null,
   LeiXing              tinyint              not null default 0,
   KongWeiId            char(36)             not null,
   RouteId              char(36)             not null,
   MenShiJiaGe1         money                not null default 0,
   MenShiJiaGe2         money                not null default 0,
   MenShiJiaGe3         money                not null default 0,
   JieSuanJiaGe1        money                not null default 0,
   JieSuanJiaGe2        money                not null default 0,
   JieSuanJiaGe3        money                not null default 0,
   QuanPeiJiaGe         money                not null default 0,
   BuFangChaJiaGe       money                not null default 0,
   TuiFangChaJiaGe      money                not null default 0,
   JiFen                int                  not null default 0,
   Status               tinyint              not null default 0,
   PaiXuId              int                  not null default 0,
   XianLuCode           nvarchar(50)         null,
   constraint PK_TBL_PT_KONGWEIXIANLU primary key (IdentityId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ƻ�λ��·��Ʒ��Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λ��·��Ʒ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'XianLuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·��Ʒ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'KongWeiId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'RouteId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���г��˼�',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'MenShiJiaGe1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ж�ͯ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'MenShiJiaGe2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ӥ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'MenShiJiaGe3'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������˼�',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'JieSuanJiaGe1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ͯ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'JieSuanJiaGe2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ӥ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'JieSuanJiaGe3'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ȫ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'QuanPeiJiaGe'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'BuFangChaJiaGe'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˷����',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'TuiFangChaJiaGe'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'JiFen'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ֵ',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·��Ʒ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_KongWeiXianLu', 'column', 'XianLuCode'
go

/*==============================================================*/
/* Table: tbl_Pt_QuYuShengFenChengShi                           */
/*==============================================================*/
create table tbl_Pt_QuYuShengFenChengShi (
   IdentityId           int                  identity,
   QuYuId               int                  not null,
   ShengFenId           int                  not null,
   ChengShiId           int                  not null,
   LeiXing              tinyint              not null default 0,
   constraint PK_TBL_PT_QUYUSHENGFENCHENGSHI primary key (IdentityId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·����ʡ�ݳ�����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_QuYuShengFenChengShi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_QuYuShengFenChengShi', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·������',
   'user', @CurrentUser, 'table', 'tbl_Pt_QuYuShengFenChengShi', 'column', 'QuYuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʡ�ݱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_QuYuShengFenChengShi', 'column', 'ShengFenId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���б��',
   'user', @CurrentUser, 'table', 'tbl_Pt_QuYuShengFenChengShi', 'column', 'ChengShiId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����(0:ȥ�̳����� 1:ȥ��Ŀ�ĵ�)',
   'user', @CurrentUser, 'table', 'tbl_Pt_QuYuShengFenChengShi', 'column', 'LeiXing'
go

/*==============================================================*/
/* Table: tbl_Pt_RouteFuJian                                    */
/*==============================================================*/
create table tbl_Pt_RouteFuJian (
   FuJianId             int                  identity,
   RouteId              char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_ROUTEFUJIAN primary key (FuJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_RouteFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_RouteFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·���',
   'user', @CurrentUser, 'table', 'tbl_Pt_RouteFuJian', 'column', 'RouteId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_RouteFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_RouteFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_RouteFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_TuiJian                                        */
/*==============================================================*/
create table tbl_Pt_TuiJian (
   TuiJianId            char(36)             not null,
   CompanyId            int                  not null,
   BiaoTi               nvarchar(255)        null,
   NeiRong              nvarchar(max)        null,
   FengMian             nvarchar(255)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   IdentityId           int                  identity,
   PaiXuId              int                  not null default 0,
   JianYaoJieShao       nvarchar(max)        null,
   constraint PK_TBL_PT_TUIJIAN primary key (TuiJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨ƽ̨�Ƽ���Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƽ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'TuiJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƽ�����',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'BiaoTi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƽ�����',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'NeiRong'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƽ�����',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'FengMian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ֵ',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ҫ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJian', 'column', 'JianYaoJieShao'
go

/*==============================================================*/
/* Table: tbl_Pt_TuiJianFuJian                                  */
/*==============================================================*/
create table tbl_Pt_TuiJianFuJian (
   FuJianId             int                  identity,
   TuiJianId            char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_TUIJIANFUJIAN primary key (FuJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨ƽ̨�Ƽ�������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJianFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJianFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƽ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJianFuJian', 'column', 'TuiJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJianFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJianFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_TuiJianFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_YanZhengMa                                     */
/*==============================================================*/
create table tbl_Pt_YanZhengMa (
   YanZhengMaId         char(36)             not null,
   YanZhengMa           nvarchar(50)         not null,
   LeiXing              tinyint              not null default 0,
   IssueTime            datetime             not null default getdate(),
   Status               tinyint              not null default 0,
   YongHuId             int                  not null default 0,
   IdentityId           int                  identity,
   constraint PK_TBL_PT_YANZHENGMA primary key (YanZhengMaId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��֤����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_YanZhengMa'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��֤����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YanZhengMa', 'column', 'YanZhengMaId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��֤��',
   'user', @CurrentUser, 'table', 'tbl_Pt_YanZhengMa', 'column', 'YanZhengMa'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YanZhengMa', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_YanZhengMa', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_YanZhengMa', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YanZhengMa', 'column', 'YongHuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_YanZhengMa', 'column', 'IdentityId'
go

/*==============================================================*/
/* Table: tbl_Pt_YongHuJiFenMingXi                              */
/*==============================================================*/
create table tbl_Pt_YongHuJiFenMingXi (
   IdentityId           int                  identity,
   CompanyId            int                  not null,
   YongHuId             int                  not null,
   JiFen                int                  not null default 0,
   Status               tinyint              not null default 0,
   IssueTime            datetime             not null default getdate(),
   GuanLianLeiXing      tinyint              not null default 0,
   GuanLianId           char(36)             not null,
   ShengXiaoShiJian     datetime             null,
   constraint PK_TBL_PT_YONGHUJIFENMINGXI primary key (IdentityId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û�������ϸ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'YongHuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'JiFen'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'GuanLianLeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'GuanLianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Чʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuJiFenMingXi', 'column', 'ShengXiaoShiJian'
go

/*==============================================================*/
/* Table: tbl_Pt_YongHuLoginLog                                 */
/*==============================================================*/
create table tbl_Pt_YongHuLoginLog (
   LogId                char(36)             not null,
   KeHuId               char(36)             not null,
   YongHuId             int                  not null,
   CompanyId            int                  not null,
   LoginTime            datetime             not null default getdate(),
   LoginIp              nvarchar(20)         null,
   UserAgent            nvarchar(max)        null,
   LoginLeiXing         tinyint              not null default 0,
   constraint PK_TBL_PT_YONGHULOGINLOG primary key (LogId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ̨�û���¼��־',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��־���',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog', 'column', 'LogId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ͻ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog', 'column', 'KeHuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog', 'column', 'YongHuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��¼ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog', 'column', 'LoginTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��¼IP',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog', 'column', 'LoginIp'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ͷ��Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog', 'column', 'UserAgent'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��¼����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YongHuLoginLog', 'column', 'LoginLeiXing'
go

/*==============================================================*/
/* Table: tbl_Pt_YuMing                                         */
/*==============================================================*/
create table tbl_Pt_YuMing (
   IdentityId           int                  identity,
   YuMing               nvarchar(50)         not null,
   CompanyId            int                  not null,
   ErpYuMing            nvarchar(50)         not null,
   ZxsId                char(36)             not null,
   IssueTime            datetime             not null default getdate(),
   constraint PK_TBL_PT_YUMING primary key (YuMing)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƽ̨������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_YuMing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_YuMing', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YuMing', 'column', 'YuMing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_YuMing', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ϵͳ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_YuMing', 'column', 'ErpYuMing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ר���̱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_YuMing', 'column', 'ZxsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_YuMing', 'column', 'IssueTime'
go

/*==============================================================*/
/* Table: tbl_Pt_ZhanDian                                       */
/*==============================================================*/
create table tbl_Pt_ZhanDian (
   ZhanDianId           int                  identity,
   CompanyId            int                  not null,
   MingCheng            nvarchar(255)        not null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           int                  not null,
   PaiXuId              int                  not null default 0,
   IsDelete             char(1)              not null default '0',
   constraint PK_TBL_PT_ZHANDIAN primary key (ZhanDianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'վ����Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'վ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDian', 'column', 'ZhanDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDian', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'վ������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDian', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDian', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDian', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDian', 'column', 'PaiXuId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDian', 'column', 'IsDelete'
go

/*==============================================================*/
/* Table: tbl_Pt_ZhanDianXzqhdm                                 */
/*==============================================================*/
create table tbl_Pt_ZhanDianXzqhdm (
   IdentityId           int                  identity,
   ZhanDianId           int                  not null,
   Xzqhdm               nvarchar(50)         not null,
   constraint PK_TBL_PT_ZHANDIANXZQHDM primary key (IdentityId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'վ����������������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDianXzqhdm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDianXzqhdm', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'վ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDianXzqhdm', 'column', 'ZhanDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhanDianXzqhdm', 'column', 'Xzqhdm'
go

/*==============================================================*/
/* Table: tbl_Pt_ZhuanXaingShangZhanDian                        */
/*==============================================================*/
create table tbl_Pt_ZhuanXaingShangZhanDian (
   IdentityId           int                  identity,
   ZxsId                char(36)             not null,
   ZhanDianId           int                  not null,
   ZxlbId               int                  not null,
   constraint PK_TBL_PT_ZHUANXAINGSHANGZHAND primary key (IdentityId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר����վ��ר�������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXaingShangZhanDian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXaingShangZhanDian', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���̱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXaingShangZhanDian', 'column', 'ZxsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'վ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXaingShangZhanDian', 'column', 'ZhanDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXaingShangZhanDian', 'column', 'ZxlbId'
go

/*==============================================================*/
/* Table: tbl_Pt_ZhuanXianLeiBie                                */
/*==============================================================*/
create table tbl_Pt_ZhuanXianLeiBie (
   ZxlbId               int                  identity,
   CompanyId            int                  not null,
   ZhanDianId           int                  not null,
   MingCheng            nvarchar(255)        not null,
   Status               tinyint              not null default 0,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   IsDelete             char(1)              not null default '0',
   PaiXuId              int                  not null default 0,
   constraint PK_TBL_PT_ZHUANXIANLEIBIE primary key (ZxlbId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר�������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'ZxlbId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'վ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'ZhanDianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'IsDelete'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ֵ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianLeiBie', 'column', 'PaiXuId'
go

/*==============================================================*/
/* Table: tbl_Pt_ZhuanXianShang                                 */
/*==============================================================*/
create table tbl_Pt_ZhuanXianShang (
   ZxsId                char(36)             not null,
   CompanyId            int                  not null,
   MingCheng            nvarchar(255)        null,
   ZhuCeHao             nvarchar(255)        null,
   ShuiWuHao            nvarchar(255)        null,
   XuKeZhengHao         nvarchar(255)        null,
   FaRenName            nvarchar(255)        null,
   LxrName              nvarchar(255)        null,
   LxrDianHua           nvarchar(255)        null,
   LxrShouJi            nvarchar(255)        null,
   LxrQQ                nvarchar(255)        null,
   Fax                  nvarchar(255)        null,
   ProvinceId           int                  not null default 0,
   CityId               int                  not null default 0,
   DiZhi                nvarchar(255)        null,
   Logo                 nvarchar(255)        null,
   LianXiFangShi        nvarchar(max)        null,
   YinHangZhangHao      nvarchar(max)        null,
   JieShao              nvarchar(max)        null,
   Status               tinyint              not null default 0,
   JiFenStatus          tinyint              not null default 0,
   Privs1               nvarchar(max)        null,
   Privs2               nvarchar(max)        null,
   Privs3               nvarchar(max)        null,
   OperatorId           int                  not null,
   IssueTime            datetime             not null default getdate(),
   IsDelete             char(1)              not null default '0',
   IdentityId           int                  identity,
   T1                   tinyint              not null default 0,
   constraint PK_TBL_PT_ZHUANXIANSHANG primary key (ZxsId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���̱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'ZxsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'MingCheng'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ע���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'ZhuCeHao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '˰���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'ShuiWuHao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���֤��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'XuKeZhengHao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'FaRenName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'LxrName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ�˵绰',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'LxrDianHua'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ���ֻ�',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'LxrShouJi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ��QQ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'LxrQQ'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���̹�˾����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'Fax'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʡ�ݱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'ProvinceId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���б��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'CityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾��ַ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'DiZhi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾logo',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'Logo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϵ��ʽ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'LianXiFangShi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����˺�',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'YinHangZhangHao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'JieShao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ַ���״̬',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'JiFenStatus'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'һ����Ŀ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'Privs1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Ŀ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'Privs2'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϸȨ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'Privs3'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'IsDelete'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'T1(����)',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShang', 'column', 'T1'
go

/*==============================================================*/
/* Table: tbl_Pt_ZhuanXianShangQQ                               */
/*==============================================================*/
create table tbl_Pt_ZhuanXianShangQQ (
   IdentityId           int                  identity,
   ZxsId                char(36)             not null,
   MiaoShu              nvarchar(255)        null,
   QQ                   nvarchar(255)        null,
   constraint PK_TBL_PT_ZHUANXIANSHANGQQ primary key (IdentityId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר������ϵQQ��Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShangQQ'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShangQQ', 'column', 'IdentityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���̱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShangQQ', 'column', 'ZxsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'QQ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShangQQ', 'column', 'MiaoShu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'QQ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZhuanXianShangQQ', 'column', 'QQ'
go

/*==============================================================*/
/* Table: tbl_Pt_ZiXun                                          */
/*==============================================================*/
create table tbl_Pt_ZiXun (
   ZiXunId              char(36)             not null,
   CompanyId            int                  not null,
   LeiXing              tinyint              not null default 0,
   BiaoTi               nvarchar(255)        null,
   NeiRong              nvarchar(max)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           int                  not null,
   JianYaoJieShao       nvarchar(max)        null,
   FengMian             nvarchar(255)        null,
   constraint PK_TBL_PT_ZIXUN primary key (ZiXunId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨��Ѷ��Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ѷ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'ZiXunId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ѷ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ѷ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'BiaoTi'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ѷ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'NeiRong'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ա���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ҫ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'JianYaoJieShao'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ѷ����',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXun', 'column', 'FengMian'
go

/*==============================================================*/
/* Table: tbl_Pt_ZiXunFuJian                                    */
/*==============================================================*/
create table tbl_Pt_ZiXunFuJian (
   FuJianId             int                  identity,
   ZiXunId              char(36)             not null,
   LeiXing              tinyint              not null default 0,
   Filepath             nvarchar(255)        null,
   MiaoShu              nvarchar(255)        null,
   constraint PK_TBL_PT_ZIXUNFUJIAN primary key (FuJianId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͬ��ƽ̨��Ѷ������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXunFuJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXunFuJian', 'column', 'FuJianId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ѷ���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXunFuJian', 'column', 'ZiXunId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXunFuJian', 'column', 'LeiXing'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����·��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXunFuJian', 'column', 'Filepath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZiXunFuJian', 'column', 'MiaoShu'
go

/*==============================================================*/
/* Table: tbl_Pt_ZxsKV                                          */
/*==============================================================*/
create table tbl_Pt_ZxsKV (
   CompanyId            int                  not null,
   ZxsId                char(36)             not null,
   K                    nvarchar(50)         not null,
   V                    nvarchar(max)        null,
   constraint PK_TBL_PT_ZXSKV primary key (CompanyId, ZxsId, K)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר����������Ϣ',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZxsKV'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZxsKV', 'column', 'CompanyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ר���̱��',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZxsKV', 'column', 'ZxsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'K',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZxsKV', 'column', 'K'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'V',
   'user', @CurrentUser, 'table', 'tbl_Pt_ZxsKV', 'column', 'V'
go

alter table tbl_Pt_CuXiaoFuJian
   add constraint FK_TBL_PT_CUXIAOFUJIAN_REFERENCE_TBL_PT_CUXIAO foreign key (CuXiaoId)
      references tbl_Pt_CuXiao (CuXiaoId)
go

alter table tbl_Pt_GuangGaoFuJian
   add constraint FK_TBL_PT_GUANGGAOFUJIAN_REFERENCE_TBL_PT_GUANGGAO foreign key (GuangGaoId)
      references tbl_Pt_GuangGao (GuangGaoId)
go

alter table tbl_Pt_JiFenDingDanLiShiLiShi
   add constraint FK_TBL_PT_JIFENDINGDANLISHILISHI_REFERENCE_TBL_PT_JIFENDINGDAN foreign key (DingDanId)
      references tbl_Pt_JiFenDingDan (DingDanId)
go

alter table tbl_Pt_JiFenShangPinFuJian
   add constraint FK_TBL_PT_JIFENSHANGPINFUJIAN_REFERENCE_TBL_PT_JIFENSHANGPIN foreign key (ShangPinId)
      references tbl_Pt_JiFenShangPin (ShangPinId)
go

alter table tbl_Pt_JingDianFuJian
   add constraint FK_TBL_PT_JINGDIANFUJIAN_REFERENCE_TBL_PT_JINGDIAN foreign key (JingDianId)
      references tbl_Pt_JingDian (JingDianId)
go

alter table tbl_Pt_JiuDianFangXing
   add constraint FK_TBL_PT_JIUDIANFANGXING_REFERENCE_TBL_PT_JIUDIAN foreign key (JiuDianId)
      references tbl_Pt_JiuDian (JiuDianId)
go

alter table tbl_Pt_JiuDianFangXingFuJian
   add constraint FK_TBL_PT_JIUDIANFANGXINGFUJIAN_REFERENCE_TBL_PT_JIUDIANFANGXING foreign key (FangXingId)
      references tbl_Pt_JiuDianFangXing (FangXingId)
go

alter table tbl_Pt_JiuDianFuJian
   add constraint FK_TBL_PT_JIUDIANFUJIAN_REFERENCE_TBL_PT_JIUDIAN foreign key (JiuDianId)
      references tbl_Pt_JiuDian (JiuDianId)
go

alter table tbl_Pt_TuiJianFuJian
   add constraint FK_TBL_PT_TUIJIANFUJIAN_REFERENCE_TBL_PT_TUIJIAN foreign key (TuiJianId)
      references tbl_Pt_TuiJian (TuiJianId)
go

alter table tbl_Pt_ZhuanXaingShangZhanDian
   add constraint FK_TBL_PT_ZHUANXAINGSHANGZHANDIAN_REFERENCE_TBL_PT_ZHUANXIANSHANG foreign key (ZxsId)
      references tbl_Pt_ZhuanXianShang (ZxsId)
go

alter table tbl_Pt_ZhuanXianShangQQ
   add constraint FK_TBL_PT_ZHUANXIANSHANGQQ_REFERENCE_TBL_PT_ZHUANXIANSHANG foreign key (ZxsId)
      references tbl_Pt_ZhuanXianShang (ZxsId)
go

alter table tbl_Pt_ZiXunFuJian
   add constraint FK_TBL_PT_ZIXUNFUJIAN_REFERENCE_TBL_PT_ZIXUN foreign key (ZiXunId)
      references tbl_Pt_ZiXun (ZiXunId)
go
