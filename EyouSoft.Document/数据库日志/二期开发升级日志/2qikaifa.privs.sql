SET IDENTITY_INSERT [tbl_SysPrivs1] ON
INSERT [tbl_SysPrivs1] ([Id],[Name],[SortId],[IsEnable],[ClassName]) VALUES ( 10,'同行端口',0,'1','')
SET IDENTITY_INSERT [tbl_SysPrivs1] OFF
GO

SET IDENTITY_INSERT [tbl_SysPrivs2] ON
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 58,10,'站点管理','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 59,10,'专线类别管理','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 60,10,'专线商管理','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 61,10,'旅游资讯','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 62,10,'酒店管理','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 63,10,'景点管理','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 64,10,'广告管理','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 65,10,'平台推荐','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 66,10,'积分兑换商品管理','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 67,10,'积分兑换订单管理','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 68,10,'基础信息','',0,'1')

INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 69,4,'催款单','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 70,6,'注册客户管理','',0,'1')

INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 71,9,'积分发放明细表','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 72,9,'积分发放结算统计表','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 73,9,'积分收付款明细表','',0,'1')

INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 74,1,'消息提醒','',0,'1')
INSERT [tbl_SysPrivs2] ([Id],[ParentId],[Name],[Url],[SortId],[IsEnable]) VALUES ( 75,10,'促销信息','',0,'1')

SET IDENTITY_INSERT [tbl_SysPrivs2] OFF
GO

SET IDENTITY_INSERT [tbl_SysPrivs3] ON
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 245,58,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 246,58,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 247,58,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 248,58,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 249,59,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 250,59,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 251,59,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 252,59,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 253,60,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 254,60,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 255,60,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 256,60,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 257,61,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 258,61,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 259,61,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 260,61,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 261,62,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 262,62,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 263,62,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 264,62,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 265,63,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 266,63,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 267,63,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 268,63,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 269,64,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 270,64,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 271,64,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 272,64,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 273,65,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 274,65,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 275,65,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 276,65,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 277,66,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 278,66,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 279,66,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 280,66,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 281,67,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 282,67,'订单管理',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 283,68,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 284,68,'管理',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 285,34,'账号管理',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 286,69,'栏目',0,'1',1)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 287,70,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 288,70,'注册客户审核',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 289,70,'注册客户删除',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 290,70,'注册客户修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 291,70,'注册客户账号管理',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 292,71,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 293,72,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 294,72,'结算收款登记',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 295,73,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 296,73,'审核',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 297,73,'取消审核',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 298,62,'房型管理',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 299,74,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 300,74,'未确认订单',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 301,74,'申请中订单',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 302,74,'名单不全订单',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 303,74,'预留订单',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 304,74,'未处理兑换订单',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 305,74,'未审核注册用户',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 306,75,'栏目',0,'1',1)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 307,75,'新增',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 308,75,'修改',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 309,75,'删除',0,'1',0)

INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 310,45,'平台酒店用户管理栏目',0,'1',0)
INSERT [tbl_SysPrivs3] ([Id],[ParentId],[Name],[SortId],[IsEnable],[PrivsType]) VALUES ( 311,45,'平台景点用户管理栏目',0,'1',0)
SET IDENTITY_INSERT [tbl_SysPrivs3] OFF
GO
