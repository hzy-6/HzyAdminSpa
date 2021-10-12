/*
 Navicat Premium Data Transfer

 Source Server         : 本地_SqlServer
 Source Server Type    : SQL Server
 Source Server Version : 14001000
 Source Host           : .:1433
 Source Catalog        : HzyAdminSpa
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 14001000
 File Encoding         : 65001

 Date: 15/09/2021 15:14:07
*/


-- ----------------------------
-- Table structure for Member
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Member]') AND type IN ('U'))
	DROP TABLE [dbo].[Member]
GO

CREATE TABLE [dbo].[Member] (
  [Id] uniqueidentifier  NOT NULL,
  [Number] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Phone] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Sex] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Birthday] datetime2(0)  NULL,
  [Photo] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Introduce] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [FilePath] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [UserId] uniqueidentifier  NULL,
  [CreateTime] datetime2(0)  NULL,
  [UpdateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[Member] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Member
-- ----------------------------
INSERT INTO [dbo].[Member] ([Id], [Number], [Name], [Phone], [Sex], [Birthday], [Photo], [Introduce], [FilePath], [UserId], [CreateTime], [UpdateTime]) VALUES (N'96A1AA3D-A61A-42D0-954A-C71753FB2065', N'123', N'123', N'123', N'女', N'2018-04-25 23:00:00', NULL, N'<p>123</p>', NULL, N'AC18F496-E93D-42F0-B59E-E321ACC85335', N'2020-10-24 00:07:42', N'2021-04-18 22:08:06')
GO

INSERT INTO [dbo].[Member] ([Id], [Number], [Name], [Phone], [Sex], [Birthday], [Photo], [Introduce], [FilePath], [UserId], [CreateTime], [UpdateTime]) VALUES (N'9A604AA2-9AE6-4A2F-8DDB-D9E0289EAD9E', N'1', N'测试会员', N'18510912123', N'男', N'2019-07-08 11:47:24', N'/upload/files/20210118/time_232747_old_name_hzy.png', N'<p>888</p>', N'/upload/files/20210118/time_233310_old_name_hzy.png', N'AC18F496-E93D-42F0-B59E-E321ACC85335', N'2018-04-25 23:00:00', N'2021-01-19 14:19:47')
GO


-- ----------------------------
-- Table structure for SysDictionary
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysDictionary]') AND type IN ('U'))
	DROP TABLE [dbo].[SysDictionary]
GO

CREATE TABLE [dbo].[SysDictionary] (
  [Id] uniqueidentifier  NOT NULL,
  [UpdateTime] datetime  NULL,
  [CreateTime] datetime  NULL,
  [Sort] int  NULL,
  [Code] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Name] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ParentId] uniqueidentifier  NULL
)
GO

ALTER TABLE [dbo].[SysDictionary] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'id',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'更新时间',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary',
'COLUMN', N'UpdateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'排序号',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary',
'COLUMN', N'Sort'
GO

EXEC sp_addextendedproperty
'MS_Description', N'编码',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary',
'COLUMN', N'Code'
GO

EXEC sp_addextendedproperty
'MS_Description', N'值',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary',
'COLUMN', N'Value'
GO

EXEC sp_addextendedproperty
'MS_Description', N'分组名/键',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary',
'COLUMN', N'Name'
GO

EXEC sp_addextendedproperty
'MS_Description', N'父级分组id',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary',
'COLUMN', N'ParentId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数据字典',
'SCHEMA', N'dbo',
'TABLE', N'SysDictionary'
GO


-- ----------------------------
-- Records of SysDictionary
-- ----------------------------
INSERT INTO [dbo].[SysDictionary] ([Id], [UpdateTime], [CreateTime], [Sort], [Code], [Value], [Name], [ParentId]) VALUES (N'B2770A68-A541-4E22-BCBC-08D94F78E4E4', N'2021-07-25 22:39:34.870', N'2021-07-25 22:31:30.490', N'1', N'news_type', NULL, N'资讯类别', NULL)
GO

INSERT INTO [dbo].[SysDictionary] ([Id], [UpdateTime], [CreateTime], [Sort], [Code], [Value], [Name], [ParentId]) VALUES (N'4A88DCC3-8299-4699-8B99-08D94F79EA5D', N'2021-07-25 22:40:30.037', N'2021-07-25 22:38:49.153', N'1', N'news_type_nan', N'1', N'男', N'B2770A68-A541-4E22-BCBC-08D94F78E4E4')
GO

INSERT INTO [dbo].[SysDictionary] ([Id], [UpdateTime], [CreateTime], [Sort], [Code], [Value], [Name], [ParentId]) VALUES (N'015B0F58-B9A5-4A11-8B9A-08D94F79EA5D', N'2021-07-25 22:40:52.990', N'2021-07-25 22:40:47.933', N'2', N'news_type_nv', N'2', N'女', N'B2770A68-A541-4E22-BCBC-08D94F78E4E4')
GO


-- ----------------------------
-- Table structure for SysFunction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysFunction]') AND type IN ('U'))
	DROP TABLE [dbo].[SysFunction]
GO

CREATE TABLE [dbo].[SysFunction] (
  [Id] uniqueidentifier  NOT NULL,
  [Number] int  NULL,
  [Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ByName] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysFunction] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysFunction
-- ----------------------------
INSERT INTO [dbo].[SysFunction] ([Id], [Number], [Name], [ByName], [Remark], [UpdateTime], [CreateTime]) VALUES (N'B6FD5425-504A-46A9-993B-2F8DC9158EB8', N'80', N'打印', N'Print', N'Print', N'2021-04-18 22:08:06', N'2016-06-20 13:40:52')
GO

INSERT INTO [dbo].[SysFunction] ([Id], [Number], [Name], [ByName], [Remark], [UpdateTime], [CreateTime]) VALUES (N'C9518758-B2E1-4F51-B517-5282E273889C', N'10', N'显示', N'Display', N'Display', N'2021-04-18 22:08:06', N'2016-06-20 13:40:52')
GO

INSERT INTO [dbo].[SysFunction] ([Id], [Number], [Name], [ByName], [Remark], [UpdateTime], [CreateTime]) VALUES (N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'60', N'检索', N'Search', N'Search', N'2021-04-18 22:08:06', N'2016-06-20 13:40:52')
GO

INSERT INTO [dbo].[SysFunction] ([Id], [Number], [Name], [ByName], [Remark], [UpdateTime], [CreateTime]) VALUES (N'383E7EE2-7690-46AC-9230-65155C84AA30', N'50', N'保存', N'Save', N'Save', N'2021-04-18 22:08:06', N'2016-06-20 13:40:52')
GO

INSERT INTO [dbo].[SysFunction] ([Id], [Number], [Name], [ByName], [Remark], [UpdateTime], [CreateTime]) VALUES (N'9C388461-2704-4C5E-A729-72C17E9018E1', N'40', N'删除', N'Delete', N'Delete', N'2021-04-18 22:08:06', N'2016-06-20 13:40:52')
GO

INSERT INTO [dbo].[SysFunction] ([Id], [Number], [Name], [ByName], [Remark], [UpdateTime], [CreateTime]) VALUES (N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'20', N'添加', N'Insert', N'Insert', N'2021-04-18 22:08:06', N'2016-06-20 13:40:52')
GO

INSERT INTO [dbo].[SysFunction] ([Id], [Number], [Name], [ByName], [Remark], [UpdateTime], [CreateTime]) VALUES (N'2401F4D0-60B0-4E2E-903F-84C603373572', N'70', N'导出', N'Export', N'Export', N'2021-04-18 22:08:06', N'2016-06-20 13:40:52')
GO

INSERT INTO [dbo].[SysFunction] ([Id], [Number], [Name], [ByName], [Remark], [UpdateTime], [CreateTime]) VALUES (N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'30', N'修改', N'Update', N'Update', N'2021-04-18 22:08:06', N'2016-06-20 13:40:52')
GO


-- ----------------------------
-- Table structure for SysMenu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysMenu]') AND type IN ('U'))
	DROP TABLE [dbo].[SysMenu]
GO

CREATE TABLE [dbo].[SysMenu] (
  [Id] uniqueidentifier  NOT NULL,
  [Number] int  NULL,
  [Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Url] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Router] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ComponentName] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Icon] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ParentId] uniqueidentifier  NULL,
  [Show] int  NULL,
  [Close] int  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL,
  [JumpUrl] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[SysMenu] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysMenu
-- ----------------------------
INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'9674D439-864E-4BF8-9DD8-08D7D70AD6BB', N'50', N'表格管理', NULL, NULL, NULL, N'TableOutlined', N'6F48B583-9C8F-490F-A3E0-81FC5F2E71B4', N'1', N'1', N'2021-01-16 17:32:07', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'F55A8858-EDE4-4380-85B2-08D8B9F578EF', N'10', N'Antd Vue3.0组件库', N'views/antd_vue_components', N'/antd/vue/components', N'antd_vue_components', N'LayoutOutlined', N'6F48B583-9C8F-490F-A3E0-81FC5F2E71B4', N'1', N'1', N'2021-01-16 16:05:46', N'2021-01-16 16:05:22', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'15455A8D-262D-4266-85B3-08D8B9F578EF', N'40', N'图表 AntV G2', NULL, NULL, NULL, N'PieChartOutlined', N'6F48B583-9C8F-490F-A3E0-81FC5F2E71B4', N'1', N'1', N'2021-01-16 16:06:33', N'2021-01-16 16:06:33', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'63A6D076-3E22-4D26-85B4-08D8B9F578EF', N'10', N'基础图表', N'views/chart/base', N'/chart/base', N'chart_base', NULL, N'15455A8D-262D-4266-85B3-08D8B9F578EF', N'1', N'1', N'2021-01-16 16:07:24', N'2021-01-16 16:07:24', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'9B01F9F3-5621-4BC2-85B5-08D8B9F578EF', N'20', N'更多示例', N'views/chart/more', N'/chart/more', N'chart_more', NULL, N'15455A8D-262D-4266-85B3-08D8B9F578EF', N'1', N'1', N'2021-01-16 16:10:06', N'2021-01-16 16:10:06', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'CC99F568-A831-4EA8-4C7A-08D8BBA503BF', N'60', N'富文本编辑器', N'views/editor', N'/editor', N'editor', N'PicRightOutlined', N'6F48B583-9C8F-490F-A3E0-81FC5F2E71B4', N'1', N'1', N'2021-01-18 19:34:54', N'2021-01-18 19:34:28', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'383053F9-DA70-4A0D-B9F0-08D94F7318CD', N'190', N'数据字典', N'views/system/dictionary/index', N'/system/dictionary', N'system_dictionary', N'FileDoneOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-07-25 21:51:53', N'2021-07-25 21:50:01', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'10E7B3CF-D846-4B1B-7662-08D95814698B', N'200', N'操作日志', N'views/system/sys_operation_log/index', N'/system/sys_operation_log', N'sys_operation_log', N'ContainerOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-08-05 21:48:54', N'2021-08-05 21:24:54', N'')
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'90E7F189-9160-4E46-E2D5-08D958181601', N'70', N'跳转外部地址', NULL, NULL, NULL, N'RadarChartOutlined', N'6F48B583-9C8F-490F-A3E0-81FC5F2E71B4', N'1', N'1', N'2021-08-05 21:51:12', N'2021-08-05 21:51:12', N'https://antv.vision/zh')
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'130', N'菜单功能', N'views/system/menu/index', N'/system/menu', N'system_menu', N'MenuOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-05-28 12:51:15', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'9A27DFC2-4A66-11EB-87B1-4CEDFB69A3E8', N'180', N'接口文档', N'views/system/swagger', N'/system/swagger', N'system_swagger', N'FileSearchOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-06-06 00:29:25', N'2018-03-10 12:17:03', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'D788896B-4033-11EB-A2CB-4CEDFB69A3E8', N'100', N'基础表格', N'views/baseList', N'/baseList', N'base_list', NULL, N'9674D439-864E-4BF8-9DD8-08D7D70AD6BB', N'1', N'1', N'2020-12-17 14:49:10', N'2020-12-17 14:49:12', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'35DC130E-4034-11EB-A2CB-4CEDFB69A3E8', N'110', N'标准表格', N'views/list/index', N'/list', N'list', NULL, N'9674D439-864E-4BF8-9DD8-08D7D70AD6BB', N'1', N'1', N'2020-12-17 14:51:05', N'2020-12-17 14:51:07', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'38FD48A9-4035-11EB-A2CB-4CEDFB69A3E8', N'30', N'按钮', N'views/button', N'/button', N'button', N'AppstoreOutlined', N'6F48B583-9C8F-490F-A3E0-81FC5F2E71B4', N'1', N'1', N'2021-01-16 16:04:05', N'2020-12-17 14:58:05', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'D29FDE94-0D6A-4A64-8446-55EE63DF5885', N'160', N'岗位管理', N'views/system/post/index', N'/system/post', N'system_post', N'IdcardOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-06-06 00:29:11', N'2021-05-27 17:29:49', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'D721FC55-2174-40EB-BB37-5C54A158525A', N'120', N'功能管理', N'views/system/function/index', N'/system/function', N'system_function', N'ControlOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-05-28 12:49:53', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'100', N'系统管理', NULL, NULL, NULL, N'DesktopOutlined', NULL, N'1', N'1', N'2018-03-10 12:16:38', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'6F48B583-9C8F-490F-A3E0-81FC5F2E71B4', N'10', N'更多示例', NULL, NULL, NULL, N'MoreOutlined', NULL, N'1', N'1', N'2021-06-06 00:29:45', N'2021-05-28 11:49:02', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'100', N'账户管理', N'views/system/user/index', N'/system/user', N'system_user', N'UserOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-05-28 12:44:36', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'BD024F3A-99A7-4407-861C-A016F243F222', N'140', N'角色功能', N'views/system/rolefunction/index', N'/system/role/function', N'system_role_function', N'UserSwitchOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-05-28 12:53:04', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'10', N'会员管理', N'views/base/member', N'/base/member', N'base_member', N'UsergroupAddOutlined', N'1EC76C4C-B9B3-4517-9854-F08CD11D653D', N'1', N'1', N'2021-05-28 12:58:22', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'60AE9382-31AB-4276-A379-D3876E9BB783', N'110', N'角色管理', N'views/system/role/index', N'/system/role', N'system_role', N'TeamOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-05-28 12:45:16', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'F35D64AE-ECB7-4D06-ACFB-D91595966D9E', N'150', N'个人中心', N'views/system/personal_center/index', N'/system/personal/center', N'system_personal_center', N'FormOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-06-06 00:28:43', N'2018-03-10 12:16:38', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'0ABFD53B-6BDE-42C6-9F99-E32775BC31DD', N'170', N'组织机构', N'views/system/organization/index', N'/system/organization', N'system_organization', N'ClusterOutlined', N'9591F249-1471-44F7-86B5-6FDAE8B93888', N'1', N'1', N'2021-06-06 00:29:19', N'2021-05-27 20:27:56', NULL)
GO

INSERT INTO [dbo].[SysMenu] ([Id], [Number], [Name], [Url], [Router], [ComponentName], [Icon], [ParentId], [Show], [Close], [UpdateTime], [CreateTime], [JumpUrl]) VALUES (N'1EC76C4C-B9B3-4517-9854-F08CD11D653D', N'90', N'基础信息', NULL, NULL, NULL, N'GoldOutlined', NULL, N'1', N'1', N'2021-01-18 19:33:46', N'2018-03-10 12:16:38', NULL)
GO


-- ----------------------------
-- Table structure for SysMenuFunction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysMenuFunction]') AND type IN ('U'))
	DROP TABLE [dbo].[SysMenuFunction]
GO

CREATE TABLE [dbo].[SysMenuFunction] (
  [Id] uniqueidentifier  NOT NULL,
  [MenuId] uniqueidentifier  NULL,
  [FunctionId] uniqueidentifier  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysMenuFunction] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysMenuFunction
-- ----------------------------
INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'1F02B56D-D844-45A1-BF68-0500D19F0C95', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-28 12:51:15', N'2021-05-28 12:51:15')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'869A2231-5631-4067-B97B-08D88A2CED15', N'4CE21A81-1CAE-44D2-B29E-07058FF04B3E', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2020-11-16 20:41:23')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E28E11CD-27C5-475D-D6B1-08D8B9F5533B', N'F55A8858-EDE4-4380-85B2-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-16 16:05:46')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'BD144568-A24E-4F7E-D6B2-08D8B9F5533B', N'15455A8D-262D-4266-85B3-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-16 16:06:33')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'060D14F9-E066-44B9-D6B3-08D8B9F5533B', N'63A6D076-3E22-4D26-85B4-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-16 16:07:24')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E136CCDA-91CE-4041-D6B4-08D8B9F5533B', N'9B01F9F3-5621-4BC2-85B5-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-16 16:10:06')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'B010F911-257E-4FA3-5B15-08D8BA019738', N'9674D439-864E-4BF8-9DD8-08D7D70AD6BB', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-16 17:32:07')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'944F5D6A-19DC-4804-8374-08D8BB7CD668', N'D788896B-4033-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-18 14:46:52')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'9D63D074-85E7-48BD-8375-08D8BB7CD668', N'35DC130E-4034-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-18 14:46:55')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'11D28148-61DA-4F49-8376-08D8BB7CD668', N'38FD48A9-4035-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-18 14:54:30')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'F38D6E67-3F6F-495D-B759-08D8BBA503C2', N'CC99F568-A831-4EA8-4C7A-08D8BBA503BF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2021-01-18 19:34:54')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'5D8D881A-EA26-43E5-CD87-08D9283EFC24', N'F35D64AE-ECB7-4D06-ACFB-D91595966D9E', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-06-06 00:28:43', N'2021-06-06 00:28:43')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'339ADB40-D10C-4F44-CD89-08D9283EFC24', N'D29FDE94-0D6A-4A64-8446-55EE63DF5885', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-06-06 00:29:11', N'2021-06-06 00:29:11')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'7D3D75DC-7BFE-482E-CD8A-08D9283EFC24', N'D29FDE94-0D6A-4A64-8446-55EE63DF5885', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-06-06 00:29:11', N'2021-06-06 00:29:11')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'4A1A49BB-85CD-48E1-CD8B-08D9283EFC24', N'D29FDE94-0D6A-4A64-8446-55EE63DF5885', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-06-06 00:29:11', N'2021-06-06 00:29:11')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'B3A8B718-F660-4D8C-CD8C-08D9283EFC24', N'D29FDE94-0D6A-4A64-8446-55EE63DF5885', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-06-06 00:29:11', N'2021-06-06 00:29:11')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'74C2E47E-CB85-4C0D-CD8D-08D9283EFC24', N'D29FDE94-0D6A-4A64-8446-55EE63DF5885', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-06-06 00:29:11', N'2021-06-06 00:29:11')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'CA96585B-95D9-4D2F-CD8E-08D9283EFC24', N'D29FDE94-0D6A-4A64-8446-55EE63DF5885', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-06-06 00:29:11', N'2021-06-06 00:29:11')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C5D9BF24-7E6F-4160-CD8F-08D9283EFC24', N'0ABFD53B-6BDE-42C6-9F99-E32775BC31DD', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-06-06 00:29:19', N'2021-06-06 00:29:19')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'A357E5C8-F021-447A-CD90-08D9283EFC24', N'0ABFD53B-6BDE-42C6-9F99-E32775BC31DD', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-06-06 00:29:19', N'2021-06-06 00:29:19')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C7EB87B6-9A99-4C89-CD91-08D9283EFC24', N'0ABFD53B-6BDE-42C6-9F99-E32775BC31DD', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-06-06 00:29:19', N'2021-06-06 00:29:19')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'43A3097E-37EE-476A-CD92-08D9283EFC24', N'0ABFD53B-6BDE-42C6-9F99-E32775BC31DD', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-06-06 00:29:19', N'2021-06-06 00:29:19')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C98C4DB7-DFAB-4193-CD93-08D9283EFC24', N'0ABFD53B-6BDE-42C6-9F99-E32775BC31DD', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-06-06 00:29:19', N'2021-06-06 00:29:19')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'B930B4C3-5136-43C5-CD94-08D9283EFC24', N'0ABFD53B-6BDE-42C6-9F99-E32775BC31DD', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-06-06 00:29:19', N'2021-06-06 00:29:19')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'15CC0317-A15C-43E3-CD95-08D9283EFC24', N'9A27DFC2-4A66-11EB-87B1-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-06-06 00:29:25', N'2021-06-06 00:29:25')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'11FA6A85-A906-43A6-B97A-08D94F7318DF', N'383053F9-DA70-4A0D-B9F0-08D94F7318CD', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-07-25 21:51:53', N'2021-07-25 21:51:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C133E85D-5C65-4BCB-B97B-08D94F7318DF', N'383053F9-DA70-4A0D-B9F0-08D94F7318CD', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-07-25 21:51:53', N'2021-07-25 21:51:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'1219BFDC-AEAA-41F4-B97C-08D94F7318DF', N'383053F9-DA70-4A0D-B9F0-08D94F7318CD', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-07-25 21:51:53', N'2021-07-25 21:51:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E036CC12-A2C6-429A-B97D-08D94F7318DF', N'383053F9-DA70-4A0D-B9F0-08D94F7318CD', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-07-25 21:51:53', N'2021-07-25 21:51:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'D07E8419-9EC6-45C1-B97E-08D94F7318DF', N'383053F9-DA70-4A0D-B9F0-08D94F7318CD', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-07-25 21:51:53', N'2021-07-25 21:51:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'BBF9C49E-64FB-4BBF-B97F-08D94F7318DF', N'383053F9-DA70-4A0D-B9F0-08D94F7318CD', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-07-25 21:51:53', N'2021-07-25 21:51:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'7C1FE795-8251-4B16-F812-08D9581605F8', N'10E7B3CF-D846-4B1B-7662-08D95814698B', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-08-05 21:48:54', N'2021-08-05 21:48:54')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'5D9CB5D6-9112-42A6-F813-08D9581605F8', N'10E7B3CF-D846-4B1B-7662-08D95814698B', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-08-05 21:48:54', N'2021-08-05 21:48:54')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'DBFD79A0-A212-43EB-F814-08D9581605F8', N'90E7F189-9160-4E46-E2D5-08D958181601', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-08-05 21:51:12', N'2021-08-05 21:51:12')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C2207F27-9CAA-44F7-A31F-0B757B973E23', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-28 12:44:36', N'2021-05-28 12:44:36')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'511EF9D4-D4B6-4053-9B37-121F06B726C7', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-28 12:49:53', N'2021-05-28 12:49:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'81A43621-60CF-4F04-9279-13480D37E6A4', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'B6FD5425-504A-46A9-993B-2F8DC9158EB8', N'2021-05-28 12:51:15', N'2021-05-28 12:51:15')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'5B21D63C-6611-4B39-9C26-1510118969B2', N'0B7F8E2C-9FAA-4496-9068-80B87BA1B64E', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'774FE6FF-3ECC-40B0-A8A3-159CD2492FE2', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-28 12:51:15', N'2021-05-28 12:51:15')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'983CA076-0761-48BF-85E3-18BB24685A09', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-28 12:45:16', N'2021-05-28 12:45:16')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'8AAA6319-D36A-4FCD-8797-19D97A077E1B', N'74B837AE-D24F-4F57-B107-E20DBE70F5D3', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'179C8B22-EFDD-475C-AA78-1B939FF05876', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-28 12:51:15', N'2021-05-28 12:51:15')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'7E466377-1810-4027-AE1B-227F53953B21', N'74B837AE-D24F-4F57-B107-E20DBE70F5D3', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'D455B476-834C-4EF2-91AE-24F60559E029', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-28 12:58:22', N'2021-05-28 12:58:22')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'0A4ACC41-95D6-4CBC-A3CA-269E0A4061EB', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-28 12:44:36', N'2021-05-28 12:44:36')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'30B4B575-4881-41EA-AE33-27BFA151E423', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-28 12:58:22', N'2021-05-28 12:58:22')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'4F40CE17-C29C-4448-9D1D-46AAB970789A', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-28 12:45:16', N'2021-05-28 12:45:16')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'44DD215E-1EDF-45AA-B6C6-4910ED14A228', N'B73C82F9-54EA-4F02-B7D9-FC3976BECB19', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'4C74EE6A-DCBA-4192-B976-4E8FCF33A061', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-28 12:49:53', N'2021-05-28 12:49:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'0943B658-9FE1-4C9B-B583-6899CC364605', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-28 12:51:15', N'2021-05-28 12:51:15')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C6FAF480-7B10-4CD1-ABB5-69E0E4AE2B85', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-28 12:58:22', N'2021-05-28 12:58:22')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'5689B539-88DB-49D2-8C5B-720E9EBC673E', N'74B837AE-D24F-4F57-B107-E20DBE70F5D3', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C848EDB2-00B3-4F67-9362-72D3A2EEA88B', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-28 12:45:16', N'2021-05-28 12:45:16')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'B8AA1A54-9076-4C72-A323-7B3B95AB26F4', N'74B837AE-D24F-4F57-B107-E20DBE70F5D3', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'3315859E-BAD8-42A6-A9FC-7DEAEB5F6B79', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'B6FD5425-504A-46A9-993B-2F8DC9158EB8', N'2021-05-28 12:49:53', N'2021-05-28 12:49:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'25CFD1D0-04C4-4B2C-B534-7F3C8C0EB06D', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-28 12:45:16', N'2021-05-28 12:45:16')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'546CC6AF-BFA3-4B61-8FA8-85713E38BC60', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-28 12:49:53', N'2021-05-28 12:49:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'CF317057-34FB-4A07-91C6-86A3CBC541FA', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-28 12:49:53', N'2021-05-28 12:49:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'23B4AF49-6A18-471D-9F09-88296C234619', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-28 12:49:53', N'2021-05-28 12:49:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'7EC9B0FA-54EE-498E-A69B-8F689D019611', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-28 12:45:16', N'2021-05-28 12:45:16')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C4BFE58E-1CB8-49DB-A942-919D46F79BE9', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-28 12:51:15', N'2021-05-28 12:51:15')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'A3074D55-141E-496E-A55C-93B5FD2DCE6C', N'74B837AE-D24F-4F57-B107-E20DBE70F5D3', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'A96CC666-927D-4D27-8174-9C321F41236D', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-28 12:49:53', N'2021-05-28 12:49:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'BB14769D-4760-4341-9FAF-9FA82EEADA65', N'2FF9BB67-AA42-48CF-80C9-6D1CFB6B1EAD', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'7861B618-0B12-4A56-ABDA-A5E8D17AC5D7', N'2FF9BB67-AA42-48CF-80C9-6D1CFB6B1EAD', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'8C85E128-83AD-4079-8754-AC5679B04DF6', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-28 12:44:36', N'2021-05-28 12:44:36')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'09A29222-8F8D-4CA6-9BD1-AEDDBABE7D7B', N'2DC579DC-2325-4063-B051-E92454EE3838', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2020-11-16 13:24:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C6E873FC-A228-4418-B4AC-AFC45A612AF7', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-28 12:58:22', N'2021-05-28 12:58:22')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'5A0EA751-0C50-482A-BE15-AFEDB9FAAE64', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'B6FD5425-504A-46A9-993B-2F8DC9158EB8', N'2021-05-28 12:58:22', N'2021-05-28 12:58:22')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'101BAF28-DBFA-41E8-ACA3-B136E02AEE8B', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-28 12:49:53', N'2021-05-28 12:49:53')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'4F666139-2C4A-400B-BD35-B67B8AA1FE7D', N'BD024F3A-99A7-4407-861C-A016F243F222', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-28 12:53:04', N'2021-05-28 12:53:04')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'DE9FA7C5-2C58-414F-8186-B68036044ED7', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-28 12:44:36', N'2021-05-28 12:44:36')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E01F16A4-04C2-41DE-9C20-BE1747CF31AF', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-28 12:44:36', N'2021-05-28 12:44:36')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'92BD3806-C5B3-41FE-B6F9-C6FD7A9DD77E', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-28 12:58:22', N'2021-05-28 12:58:22')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'B1B627C4-AC62-4DAC-B4CC-C71392040543', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-28 12:51:15', N'2021-05-28 12:51:15')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'B2DD663B-67F3-478B-B8AA-CBE52480E133', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-28 12:51:15', N'2021-05-28 12:51:15')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'0E354FD7-690B-4D22-A9DB-E5025E353BFE', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-28 12:58:22', N'2021-05-28 12:58:22')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'DBCB960D-C4CD-4D27-B1AA-E5AAE91B727D', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-28 12:58:22', N'2021-05-28 12:58:22')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'2CF7A5E1-A38E-45D6-949E-E8BB65F60A5C', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-28 12:44:36', N'2021-05-28 12:44:36')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'ED0EAF25-AAFF-4E8B-9A85-F173603510EF', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-28 12:45:16', N'2021-05-28 12:45:16')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'1B4203A4-9FC4-42F8-9122-F1B3CDE687E9', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-28 12:44:36', N'2021-05-28 12:44:36')
GO

INSERT INTO [dbo].[SysMenuFunction] ([Id], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'1A727D75-867E-4292-9024-F66A292B465F', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-28 12:45:16', N'2021-05-28 12:45:16')
GO


-- ----------------------------
-- Table structure for SysOperationLog
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysOperationLog]') AND type IN ('U'))
	DROP TABLE [dbo].[SysOperationLog]
GO

CREATE TABLE [dbo].[SysOperationLog] (
  [Id] uniqueidentifier  NOT NULL ROWGUIDCOL,
  [Api] varchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [Ip] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Form] varchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [FormBody] varchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [QueryString] varchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [Browser] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OS] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [UserId] uniqueidentifier  NULL,
  [TakeUpTime] bigint  NOT NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysOperationLog] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'接口地址',
'SCHEMA', N'dbo',
'TABLE', N'SysOperationLog',
'COLUMN', N'Api'
GO

EXEC sp_addextendedproperty
'MS_Description', N'ip地址',
'SCHEMA', N'dbo',
'TABLE', N'SysOperationLog',
'COLUMN', N'Ip'
GO

EXEC sp_addextendedproperty
'MS_Description', N'表单信息',
'SCHEMA', N'dbo',
'TABLE', N'SysOperationLog',
'COLUMN', N'Form'
GO

EXEC sp_addextendedproperty
'MS_Description', N'json表单信息',
'SCHEMA', N'dbo',
'TABLE', N'SysOperationLog',
'COLUMN', N'FormBody'
GO

EXEC sp_addextendedproperty
'MS_Description', N'地址栏信息',
'SCHEMA', N'dbo',
'TABLE', N'SysOperationLog',
'COLUMN', N'QueryString'
GO

EXEC sp_addextendedproperty
'MS_Description', N'当前操作人id',
'SCHEMA', N'dbo',
'TABLE', N'SysOperationLog',
'COLUMN', N'UserId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'接口耗时（毫秒）',
'SCHEMA', N'dbo',
'TABLE', N'SysOperationLog',
'COLUMN', N'TakeUpTime'
GO


-- ----------------------------
-- Records of SysOperationLog
-- ----------------------------
INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'5A45ABB9-139D-4FC5-E8A3-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'353', N'2021-08-05 21:33:47', N'2021-08-05 21:33:47')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'D51848D9-1A5D-4FF2-E8A4-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'83', N'2021-08-05 21:33:50', N'2021-08-05 21:33:50')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'50B78181-BA86-43ED-E8A5-08D95815A729', N'/api/admin/SysOperationLog/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'172', N'2021-08-05 21:33:51', N'2021-08-05 21:33:51')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B651DFA8-E681-4AB5-E8A6-08D95815A729', N'/api/admin/SysOperationLog/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'50', N'2021-08-05 21:33:54', N'2021-08-05 21:33:54')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'46321858-134E-4361-E8A7-08D95815A729', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'137', N'2021-08-05 21:33:57', N'2021-08-05 21:33:57')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'A40B8D61-A7F1-4AEF-E8A8-08D95815A729', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'121', N'2021-08-05 21:33:57', N'2021-08-05 21:33:57')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'945661CD-BEB0-4B7B-E8A9-08D95815A729', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"1b001a4d-bce5-4e09-bc96-4e7da7686c48"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'62', N'2021-08-05 21:33:59', N'2021-08-05 21:33:59')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F3855CFA-5141-4F2E-E8AA-08D95815A729', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'60', N'2021-08-05 21:34:00', N'2021-08-05 21:34:00')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'4C772382-A3B7-4319-E8AB-08D95815A729', N'/api/admin/SysUser/findForm/ac18f496-e93d-42f0-b59e-e321acc85335', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'101', N'2021-08-05 21:34:01', N'2021-08-05 21:34:01')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'2EB2D709-92C7-4729-E8AC-08D95815A729', N'/api/admin/SysRole/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'72', N'2021-08-05 21:34:07', N'2021-08-05 21:34:07')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'815352E0-7D83-47A2-E8AD-08D95815A729', N'/api/admin/SysFunction/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'68', N'2021-08-05 21:34:09', N'2021-08-05 21:34:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'23F7EE54-A0EA-40E7-E8AE-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'107', N'2021-08-05 21:36:15', N'2021-08-05 21:36:15')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'E6E7D604-C346-4700-E8AF-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'107', N'2021-08-05 21:36:15', N'2021-08-05 21:36:15')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'9B9592D8-B01C-47BE-E8B0-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'58', N'2021-08-05 21:36:16', N'2021-08-05 21:36:16')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'693AD86F-0167-4162-E8B1-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'57', N'2021-08-05 21:36:19', N'2021-08-05 21:36:19')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'2981E57A-C7DE-46B4-E8B2-08D95815A729', N'/api/admin/SysMenu/findForm/10e7b3cf-d846-4b1b-7662-08d95814698b', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'83', N'2021-08-05 21:36:20', N'2021-08-05 21:36:20')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'2D2BDD37-CDB6-4EED-E8B3-08D95815A729', N'/api/admin/SysMenu/saveForm', N'0.0.0.1', N'', N'{"id":"10e7b3cf-d846-4b1b-7662-08d95814698b","form":{"lazyLoader":{},"number":200,"name":"操作日志","componentName":"sys_operation_log","url":"views/system/sys_operation_log/index","router":"/system/sys_operation_log","jumpUrl":null,"icon":"ContainerOutlined","parentId":"9591f249-1471-44f7-86b5-6fdae8b93888","show":1,"close":1,"id":"10e7b3cf-d846-4b1b-7662-08d95814698b","updateTime":"2021-08-05T21:24:54","createTime":"2021-08-05T21:24:54","ParentId":"9591f249-1471-44f7-86b5-6fdae8b93888"},"allFunctions":[{"number":10,"name":"显示","byName":"Display","remark":"Display","id":"c9518758-b2e1-4f51-b517-5282e273889c","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":20,"name":"添加","byName":"Insert","remark":"Insert","id":"bffefb1c-8988-4ddf-b4ac-81c2b30e80cd","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":30,"name":"修改","byName":"Update","remark":"Update","id":"e7ef2a05-8317-41c3-b588-99519fe88bf9","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":40,"name":"删除","byName":"Delete","remark":"Delete","id":"9c388461-2704-4c5e-a729-72c17e9018e1","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":50,"name":"保存","byName":"Save","remark":"Save","id":"383e7ee2-7690-46ac-9230-65155c84aa30","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":60,"name":"检索","byName":"Search","remark":"Search","id":"f27ecb0a-197d-47b1-b243-59a8c71302bf","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":70,"name":"导出","byName":"Export","remark":"Export","id":"2401f4d0-60b0-4e2e-903f-84c603373572","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":80,"name":"打印","byName":"Print","remark":"Print","id":"b6fd5425-504a-46a9-993b-2f8dc9158eb8","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"}],"functionIds":["c9518758-b2e1-4f51-b517-5282e273889c","f27ecb0a-197d-47b1-b243-59a8c71302bf"]}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'129', N'2021-08-05 21:36:26', N'2021-08-05 21:36:26')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'ACDB76BF-5361-4264-E8B4-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'128', N'2021-08-05 21:36:27', N'2021-08-05 21:36:27')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'31EBBAB9-0802-468A-E8B5-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'132', N'2021-08-05 21:36:27', N'2021-08-05 21:36:27')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'95C3738B-9850-4C96-E8B6-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'91', N'2021-08-05 21:37:54', N'2021-08-05 21:37:54')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'662C08A9-07F7-4BF9-E8B7-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'95', N'2021-08-05 21:37:55', N'2021-08-05 21:37:55')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'93437653-6138-4B51-E8B8-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'93', N'2021-08-05 21:37:55', N'2021-08-05 21:37:55')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'85D2722C-AACB-4BA0-E8B9-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'61', N'2021-08-05 21:37:56', N'2021-08-05 21:37:56')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'BDE66D6D-0BF0-4AD4-E8BA-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'64', N'2021-08-05 21:37:58', N'2021-08-05 21:37:58')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'49EDBBC8-7BBF-4332-E8BB-08D95815A729', N'/api/admin/SysMenu/findForm/10e7b3cf-d846-4b1b-7662-08d95814698b', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'89', N'2021-08-05 21:38:00', N'2021-08-05 21:38:00')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F2E5A9B8-AE64-47EE-E8BC-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'61', N'2021-08-05 21:38:07', N'2021-08-05 21:38:07')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'84563A6F-ECA2-4ACD-E8BD-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'134', N'2021-08-05 21:38:35', N'2021-08-05 21:38:35')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B2EC3C3E-592B-401D-E8BE-08D95815A729', N'/api/admin/SysMenu/findForm/d721fc55-2174-40eb-bb37-5c54a158525a', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'64', N'2021-08-05 21:38:36', N'2021-08-05 21:38:36')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'21D68BB4-D4A5-40D1-E8BF-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'108', N'2021-08-05 21:40:25', N'2021-08-05 21:40:25')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C3A3E4C3-3F37-4942-E8C0-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'132', N'2021-08-05 21:40:26', N'2021-08-05 21:40:26')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F859412D-79A1-497E-E8C1-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'151', N'2021-08-05 21:40:26', N'2021-08-05 21:40:26')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'2A3850EF-FED1-4FEB-E8C2-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'62', N'2021-08-05 21:40:27', N'2021-08-05 21:40:27')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F692BB9F-C02A-4D78-E8C3-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'74', N'2021-08-05 21:40:29', N'2021-08-05 21:40:29')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'4CA0C02E-4214-4BD7-E8C4-08D95815A729', N'/api/admin/SysMenu/findForm/10e7b3cf-d846-4b1b-7662-08d95814698b', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'60', N'2021-08-05 21:40:30', N'2021-08-05 21:40:30')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'5CA31BE6-2CFE-4B0A-E8C5-08D95815A729', N'/api/admin/SysMenu/saveForm', N'0.0.0.1', N'', N'{"id":"10e7b3cf-d846-4b1b-7662-08d95814698b","form":{"lazyLoader":{},"number":200,"name":"操作日志","componentName":"sys_operation_log","url":"views/system/sys_operation_log/index","router":"/system/sys_operation_log","jumpUrl":"https://2x.antdv.com/components/icon-cn","icon":"ContainerOutlined","parentId":"9591f249-1471-44f7-86b5-6fdae8b93888","show":1,"close":1,"id":"10e7b3cf-d846-4b1b-7662-08d95814698b","updateTime":"2021-08-05T21:36:26","createTime":"2021-08-05T21:24:54","ParentId":"9591f249-1471-44f7-86b5-6fdae8b93888"},"allFunctions":[{"number":10,"name":"显示","byName":"Display","remark":"Display","id":"c9518758-b2e1-4f51-b517-5282e273889c","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":20,"name":"添加","byName":"Insert","remark":"Insert","id":"bffefb1c-8988-4ddf-b4ac-81c2b30e80cd","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":30,"name":"修改","byName":"Update","remark":"Update","id":"e7ef2a05-8317-41c3-b588-99519fe88bf9","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":40,"name":"删除","byName":"Delete","remark":"Delete","id":"9c388461-2704-4c5e-a729-72c17e9018e1","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":50,"name":"保存","byName":"Save","remark":"Save","id":"383e7ee2-7690-46ac-9230-65155c84aa30","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":60,"name":"检索","byName":"Search","remark":"Search","id":"f27ecb0a-197d-47b1-b243-59a8c71302bf","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":70,"name":"导出","byName":"Export","remark":"Export","id":"2401f4d0-60b0-4e2e-903f-84c603373572","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":80,"name":"打印","byName":"Print","remark":"Print","id":"b6fd5425-504a-46a9-993b-2f8dc9158eb8","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"}],"functionIds":["c9518758-b2e1-4f51-b517-5282e273889c","f27ecb0a-197d-47b1-b243-59a8c71302bf"]}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'120', N'2021-08-05 21:43:02', N'2021-08-05 21:43:02')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'95FBCC39-348B-4994-E8C6-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'190', N'2021-08-05 21:43:02', N'2021-08-05 21:43:02')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0B4AAC2D-2C87-4461-E8C7-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'228', N'2021-08-05 21:43:02', N'2021-08-05 21:43:02')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'24C7ABEE-1FBD-4126-E8C8-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'77', N'2021-08-05 21:43:07', N'2021-08-05 21:43:07')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'DDCBCCBB-F6B1-45DB-E8C9-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'63', N'2021-08-05 21:43:09', N'2021-08-05 21:43:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'7E4D0959-FC9E-4844-E8CA-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'145', N'2021-08-05 21:43:10', N'2021-08-05 21:43:10')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0CD6E66A-C395-4BE7-E8CB-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'167', N'2021-08-05 21:43:10', N'2021-08-05 21:43:10')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'920CF0F4-A45A-4B80-E8CC-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'83', N'2021-08-05 21:43:15', N'2021-08-05 21:43:15')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'FD9DB74F-9835-43F6-E8CD-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'96', N'2021-08-05 21:43:15', N'2021-08-05 21:43:15')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'923E710E-CB64-4982-E8CE-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'95', N'2021-08-05 21:43:25', N'2021-08-05 21:43:25')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'823AAB68-29C9-4EDC-E8CF-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'111', N'2021-08-05 21:43:25', N'2021-08-05 21:43:25')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'94DBAA10-D5CB-4E9F-E8D0-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'70', N'2021-08-05 21:43:50', N'2021-08-05 21:43:50')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'CE3FD8F6-DFD2-4E66-E8D1-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'98', N'2021-08-05 21:43:50', N'2021-08-05 21:43:50')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C8A020C1-194B-49B1-E8D2-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'135', N'2021-08-05 21:43:50', N'2021-08-05 21:43:50')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'41E2EC7D-217F-49B4-E8D3-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'90', N'2021-08-05 21:45:08', N'2021-08-05 21:45:08')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F71DE282-E09E-423B-E8D4-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'71', N'2021-08-05 21:45:09', N'2021-08-05 21:45:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'5DD1EFAF-79A5-4C36-E8D5-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'79', N'2021-08-05 21:45:09', N'2021-08-05 21:45:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'21DB902D-EC60-4CF3-E8D6-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'77', N'2021-08-05 21:46:37', N'2021-08-05 21:46:37')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'72F64FA0-82A5-4DDB-E8D7-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'98', N'2021-08-05 21:46:38', N'2021-08-05 21:46:38')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0BD29FB6-DA15-4458-E8D8-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'108', N'2021-08-05 21:46:38', N'2021-08-05 21:46:38')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B0A6689B-AAFF-4210-E8D9-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'87', N'2021-08-05 21:46:47', N'2021-08-05 21:46:47')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'01CF6F9C-873C-4563-E8DA-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'84', N'2021-08-05 21:46:47', N'2021-08-05 21:46:47')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'EFA20826-25A3-4F02-E8DB-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"6f48b583-9c8f-490f-a3e0-81fc5f2e71b4"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'55', N'2021-08-05 21:46:48', N'2021-08-05 21:46:48')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'FDD3BE4D-0634-46B4-E8DC-08D95815A729', N'/api/admin/SysMenu/deleteList', N'0.0.0.1', N'', N'["bc4b9153-c3ed-4185-3ba6-08d9580f5668"]', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'82', N'2021-08-05 21:46:51', N'2021-08-05 21:46:51')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'4175135F-CDA4-44FB-E8DD-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"6f48b583-9c8f-490f-a3e0-81fc5f2e71b4"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'94', N'2021-08-05 21:46:51', N'2021-08-05 21:46:51')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'71C400CB-0F8F-4C18-E8DE-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'100', N'2021-08-05 21:46:51', N'2021-08-05 21:46:51')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'FE64A08B-E207-45FE-E8DF-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'155', N'2021-08-05 21:47:49', N'2021-08-05 21:47:49')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'3559626A-C538-4ECC-E8E0-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'159', N'2021-08-05 21:47:49', N'2021-08-05 21:47:49')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C5BDB088-EB48-4078-E8E1-08D95815A729', N'/api/admin/SysMenu/findForm/1ec76c4c-b9b3-4517-9854-f08cd11d653d', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'56', N'2021-08-05 21:48:06', N'2021-08-05 21:48:06')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0516BD39-E6BE-4977-E8E2-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'47', N'2021-08-05 21:48:14', N'2021-08-05 21:48:14')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C2B7791E-6C0C-43C4-E8E3-08D95815A729', N'/api/admin/SysMenu/findForm/383053f9-da70-4a0d-b9f0-08d94f7318cd', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'57', N'2021-08-05 21:48:16', N'2021-08-05 21:48:16')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C3FE58D6-8554-471E-E8E4-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'55', N'2021-08-05 21:48:19', N'2021-08-05 21:48:19')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F6C4D29D-B6F7-4362-E8E5-08D95815A729', N'/api/admin/SysMenu/findForm/10e7b3cf-d846-4b1b-7662-08d95814698b', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'48', N'2021-08-05 21:48:20', N'2021-08-05 21:48:20')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'D027AC10-3512-4E89-E8E6-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'106', N'2021-08-05 21:48:35', N'2021-08-05 21:48:35')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'447DE32E-3D34-4A90-E8E7-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'89', N'2021-08-05 21:48:36', N'2021-08-05 21:48:36')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'20E22628-1812-48EB-E8E8-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'94', N'2021-08-05 21:48:36', N'2021-08-05 21:48:36')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C1D35608-A57E-4498-E8E9-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'54', N'2021-08-05 21:48:37', N'2021-08-05 21:48:37')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'66A6A7C3-9E29-4D8E-E8EA-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'56', N'2021-08-05 21:48:39', N'2021-08-05 21:48:39')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'80342D18-3C60-4E6F-E8EB-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'55', N'2021-08-05 21:48:41', N'2021-08-05 21:48:41')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F78CCD6D-8F3E-425A-E8EC-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'57', N'2021-08-05 21:48:47', N'2021-08-05 21:48:47')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'694568A9-1F10-48FC-E8ED-08D95815A729', N'/api/admin/SysMenu/findForm/10e7b3cf-d846-4b1b-7662-08d95814698b', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'61', N'2021-08-05 21:48:49', N'2021-08-05 21:48:49')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'11E5AA3A-C823-4322-E8EE-08D95815A729', N'/api/admin/SysMenu/saveForm', N'0.0.0.1', N'', N'{"id":"10e7b3cf-d846-4b1b-7662-08d95814698b","form":{"lazyLoader":{},"number":200,"name":"操作日志","componentName":"sys_operation_log","url":"views/system/sys_operation_log/index","router":"/system/sys_operation_log","jumpUrl":"","icon":"ContainerOutlined","parentId":"9591f249-1471-44f7-86b5-6fdae8b93888","show":1,"close":1,"id":"10e7b3cf-d846-4b1b-7662-08d95814698b","updateTime":"2021-08-05T21:43:01","createTime":"2021-08-05T21:24:54","ParentId":"9591f249-1471-44f7-86b5-6fdae8b93888"},"allFunctions":[{"number":10,"name":"显示","byName":"Display","remark":"Display","id":"c9518758-b2e1-4f51-b517-5282e273889c","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":20,"name":"添加","byName":"Insert","remark":"Insert","id":"bffefb1c-8988-4ddf-b4ac-81c2b30e80cd","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":30,"name":"修改","byName":"Update","remark":"Update","id":"e7ef2a05-8317-41c3-b588-99519fe88bf9","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":40,"name":"删除","byName":"Delete","remark":"Delete","id":"9c388461-2704-4c5e-a729-72c17e9018e1","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":50,"name":"保存","byName":"Save","remark":"Save","id":"383e7ee2-7690-46ac-9230-65155c84aa30","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":60,"name":"检索","byName":"Search","remark":"Search","id":"f27ecb0a-197d-47b1-b243-59a8c71302bf","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":70,"name":"导出","byName":"Export","remark":"Export","id":"2401f4d0-60b0-4e2e-903f-84c603373572","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":80,"name":"打印","byName":"Print","remark":"Print","id":"b6fd5425-504a-46a9-993b-2f8dc9158eb8","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"}],"functionIds":["c9518758-b2e1-4f51-b517-5282e273889c","f27ecb0a-197d-47b1-b243-59a8c71302bf"]}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'88', N'2021-08-05 21:48:55', N'2021-08-05 21:48:55')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'3C45D4F4-3D21-4668-E8EF-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"9591f249-1471-44f7-86b5-6fdae8b93888"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'89', N'2021-08-05 21:48:55', N'2021-08-05 21:48:55')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'DF9A78D5-FB1C-4C56-E8F0-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'92', N'2021-08-05 21:48:55', N'2021-08-05 21:48:55')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'7D46A134-0105-4AAE-E8F1-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"6f48b583-9c8f-490f-a3e0-81fc5f2e71b4"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'65', N'2021-08-05 21:49:09', N'2021-08-05 21:49:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'5BD7E9C8-4DED-43D0-E8F2-08D95815A729', N'/api/admin/SysMenu/findForm', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'59', N'2021-08-05 21:49:12', N'2021-08-05 21:49:12')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0AE1703B-BBC1-47C5-E8F3-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'78', N'2021-08-05 21:49:54', N'2021-08-05 21:49:54')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'DB2DC422-FD85-4411-E8F4-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"6f48b583-9c8f-490f-a3e0-81fc5f2e71b4"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'57', N'2021-08-05 21:49:55', N'2021-08-05 21:49:55')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'2DD28438-D6FE-41FF-E8F5-08D95815A729', N'/api/admin/SysMenu/findForm', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'71', N'2021-08-05 21:49:56', N'2021-08-05 21:49:56')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'7B622407-8E03-4ACB-E8F6-08D95815A729', N'/api/admin/SysMenu/saveForm', N'0.0.0.1', N'', N'{"id":"","form":{"number":"70","name":"跳转外部地址","componentName":null,"url":null,"router":null,"jumpUrl":"https://antv.vision/zh","icon":"RadarChartOutlined","parentId":null,"show":1,"close":1,"id":"00000000-0000-0000-0000-000000000000","updateTime":"0001-01-01T00:00:00","createTime":"0001-01-01T00:00:00","ParentId":"6f48b583-9c8f-490f-a3e0-81fc5f2e71b4"},"allFunctions":[{"number":10,"name":"显示","byName":"Display","remark":"Display","id":"c9518758-b2e1-4f51-b517-5282e273889c","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":20,"name":"添加","byName":"Insert","remark":"Insert","id":"bffefb1c-8988-4ddf-b4ac-81c2b30e80cd","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":30,"name":"修改","byName":"Update","remark":"Update","id":"e7ef2a05-8317-41c3-b588-99519fe88bf9","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":40,"name":"删除","byName":"Delete","remark":"Delete","id":"9c388461-2704-4c5e-a729-72c17e9018e1","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":50,"name":"保存","byName":"Save","remark":"Save","id":"383e7ee2-7690-46ac-9230-65155c84aa30","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":60,"name":"检索","byName":"Search","remark":"Search","id":"f27ecb0a-197d-47b1-b243-59a8c71302bf","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":70,"name":"导出","byName":"Export","remark":"Export","id":"2401f4d0-60b0-4e2e-903f-84c603373572","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"},{"number":80,"name":"打印","byName":"Print","remark":"Print","id":"b6fd5425-504a-46a9-993b-2f8dc9158eb8","updateTime":"2021-04-18T22:08:06","createTime":"2016-06-20T13:40:52"}],"functionIds":["c9518758-b2e1-4f51-b517-5282e273889c"]}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'73', N'2021-08-05 21:51:12', N'2021-08-05 21:51:12')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'539BAFA0-F1DA-4C9A-E8F7-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'106', N'2021-08-05 21:51:13', N'2021-08-05 21:51:13')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'838B5332-673C-456E-E8F8-08D95815A729', N'/api/admin/SysMenu/findList/10/2', N'0.0.0.1', N'', N'{"name":null,"parentId":"6f48b583-9c8f-490f-a3e0-81fc5f2e71b4"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'86', N'2021-08-05 21:51:13', N'2021-08-05 21:51:13')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'1A7D91C8-93FB-4C72-E8F9-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'96', N'2021-08-05 21:51:15', N'2021-08-05 21:51:15')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F00E6920-8641-4636-E8FA-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'84', N'2021-08-05 21:51:15', N'2021-08-05 21:51:15')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'717BC3E2-B23E-492C-E8FB-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'86', N'2021-08-05 21:51:15', N'2021-08-05 21:51:15')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'A1843D9E-F05F-4578-E8FC-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"6f48b583-9c8f-490f-a3e0-81fc5f2e71b4"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'71', N'2021-08-05 21:51:17', N'2021-08-05 21:51:17')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'D1DE0379-F36E-4A63-E8FD-08D95815A729', N'/api/admin/SysMenu/findForm/90e7f189-9160-4e46-e2d5-08d958181601', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'64', N'2021-08-05 22:11:57', N'2021-08-05 22:11:57')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'4A2B9747-81EB-4254-E8FE-08D95815A729', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'81', N'2021-08-05 22:12:08', N'2021-08-05 22:12:08')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'FBD3F0E6-085E-47F9-E8FF-08D95815A729', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'102', N'2021-08-05 22:12:09', N'2021-08-05 22:12:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'399AD601-9F0C-404A-E900-08D95815A729', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'112', N'2021-08-05 22:12:09', N'2021-08-05 22:12:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0BED23F2-5F0A-4937-0E58-08D9581B4DB3', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'354', N'2021-08-05 22:14:14', N'2021-08-05 22:14:14')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'635EAF1C-AB3A-404E-0E59-08D9581B4DB3', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'78', N'2021-08-05 22:14:18', N'2021-08-05 22:14:18')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'CF465000-7567-48CD-0E5A-08D9581B4DB3', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'115', N'2021-08-05 22:14:47', N'2021-08-05 22:14:47')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B92EECDC-759E-49A5-0E5B-08D9581B4DB3', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'191', N'2021-08-05 22:14:47', N'2021-08-05 22:14:47')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'00E6FC93-3D93-4659-0E5C-08D9581B4DB3', N'/api/admin/SysOperationLog/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'65', N'2021-08-05 22:14:48', N'2021-08-05 22:14:48')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'8C0DE278-15F6-470F-74B3-08D95963C989', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome92', N'Windows10', NULL, N'1124', N'2021-08-07 13:25:37', N'2021-08-07 13:25:37')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'AD9E2996-18FE-4CEA-74B4-08D95963C989', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'283', N'2021-08-07 13:25:37', N'2021-08-07 13:25:37')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'602EF775-FFAA-41CE-74B5-08D95963C989', N'/api/admin/SysOrganization/findList/', N'0.0.0.1', N'', N'{"name":null,"state":1,"parentId":null}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'82', N'2021-08-07 13:25:42', N'2021-08-07 13:25:42')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F47E7FCA-39B8-4E6D-74B6-08D95963C989', N'/api/admin/Member/findList/10/1', N'0.0.0.1', N'', N'{"name":""}', N'', N'Chrome92', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'137', N'2021-08-07 13:26:05', N'2021-08-07 13:26:05')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F775D62C-4920-450C-CCEC-08D9769A31CD', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', NULL, N'837', N'2021-09-13 17:38:08', N'2021-09-13 17:38:08')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'52F30E34-BC13-4097-CCED-08D9769A31CD', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'319', N'2021-09-13 17:38:09', N'2021-09-13 17:38:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'9753C3CC-7C71-43F7-CCEE-08D9769A31CD', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'95', N'2021-09-13 17:38:13', N'2021-09-13 17:38:13')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'AFBA87DF-7186-484B-CCEF-08D9769A31CD', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'175', N'2021-09-13 17:38:13', N'2021-09-13 17:38:13')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'8222B6C3-D7D9-463E-CCF0-08D9769A31CD', N'/api/admin/SysUser/findForm/ac18f496-e93d-42f0-b59e-e321acc85335', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'81', N'2021-09-13 17:38:15', N'2021-09-13 17:38:15')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'266D5D63-D3D0-4BF6-CCF1-08D9769A31CD', N'/api/admin/SysRole/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'80', N'2021-09-13 17:38:18', N'2021-09-13 17:38:18')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'749AC888-7A1F-43DF-58C4-08D977442C0F', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', NULL, N'1160', N'2021-09-14 13:54:53', N'2021-09-14 13:54:53')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'EBBFD455-A7F2-45B4-58C5-08D977442C0F', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'252', N'2021-09-14 13:54:54', N'2021-09-14 13:54:54')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B0EE1C72-3FCF-4119-58C6-08D977442C0F', N'/api/admin/Member/findList/10/1', N'0.0.0.1', N'', N'{"name":""}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'166', N'2021-09-14 13:54:58', N'2021-09-14 13:54:58')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'558E0BF6-8596-47A0-58C7-08D977442C0F', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'92', N'2021-09-14 13:55:00', N'2021-09-14 13:55:00')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'529D9F01-C69F-4D43-58C8-08D977442C0F', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'128', N'2021-09-14 13:55:00', N'2021-09-14 13:55:00')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'A1A1D32A-1801-449D-58C9-08D977442C0F', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"1b001a4d-bce5-4e09-bc96-4e7da7686c48"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'46', N'2021-09-14 13:55:03', N'2021-09-14 13:55:03')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'36E1AA3C-F90A-427F-58CA-08D977442C0F', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"47c547ea-e07a-4475-a4f7-ae09e3d8fafc"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'60', N'2021-09-14 13:55:04', N'2021-09-14 13:55:04')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B9D8FDC5-C32B-40F4-58CB-08D977442C0F', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'48', N'2021-09-14 13:55:05', N'2021-09-14 13:55:05')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'BF98429E-0011-4A72-58CC-08D977442C0F', N'/api/admin/SysRole/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'65', N'2021-09-14 13:55:06', N'2021-09-14 13:55:06')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'593B50CE-57B2-4E32-A77D-08D97754F6CE', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'338', N'2021-09-14 15:55:05', N'2021-09-14 15:55:05')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'3D846EE0-0AA7-460A-4158-08D9775F30C1', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'337', N'2021-09-14 17:08:17', N'2021-09-14 17:08:17')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'E4C11C45-ACA3-4266-4159-08D9775F30C1', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'86', N'2021-09-14 17:08:38', N'2021-09-14 17:08:38')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'8C728420-5296-4CC0-415A-08D9775F30C1', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'214', N'2021-09-14 17:08:39', N'2021-09-14 17:08:39')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'465915FD-26D7-438E-415B-08D9775F30C1', N'/api/admin/SysRole/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'63', N'2021-09-14 17:09:28', N'2021-09-14 17:09:28')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'E9545BDC-E2D7-4232-415C-08D9775F30C1', N'/api/admin/SysFunction/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'64', N'2021-09-14 17:09:30', N'2021-09-14 17:09:30')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'30E868A2-107D-4777-415D-08D9775F30C1', N'/api/admin/SysFunction/findForm/bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'58', N'2021-09-14 17:10:36', N'2021-09-14 17:10:36')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'8C9EE752-076C-4007-415E-08D9775F30C1', N'/api/admin/SysFunction/findForm/f27ecb0a-197d-47b1-b243-59a8c71302bf', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'36', N'2021-09-14 17:10:38', N'2021-09-14 17:10:38')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'70EFA5A2-F2E2-48E4-415F-08D9775F30C1', N'/api/admin/SysFunction/findForm/9c388461-2704-4c5e-a729-72c17e9018e1', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'35', N'2021-09-14 17:10:41', N'2021-09-14 17:10:41')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F539A46E-94AF-4579-4160-08D9775F30C1', N'/api/admin/SysFunction/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'25', N'2021-09-14 17:11:29', N'2021-09-14 17:11:29')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'25AB53E6-791B-4648-4161-08D9775F30C1', N'/api/admin/SysMenu/getMenusFunctionTree', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'93', N'2021-09-14 17:11:33', N'2021-09-14 17:11:33')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'006350B7-E2CA-4664-4162-08D9775F30C1', N'/api/admin/SysMenu/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'98', N'2021-09-14 17:11:33', N'2021-09-14 17:11:33')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'094E60A7-2B28-45AF-4163-08D9775F30C1', N'/api/admin/SysRoleMenuFunction/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'73', N'2021-09-14 17:11:40', N'2021-09-14 17:11:40')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'E3ED591F-CE2B-4262-4164-08D9775F30C1', N'/api/admin/SysRoleMenuFunction/getRoleMenuFunctionTree/18fa4771-6f58-46a3-80d2-6f0f5e9972e3', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'78', N'2021-09-14 17:11:40', N'2021-09-14 17:11:40')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'EAA8A3F1-0A82-41D3-4165-08D9775F30C1', N'/api/admin/SysPost/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'40', N'2021-09-14 17:11:44', N'2021-09-14 17:11:44')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'2E9C8900-5F45-40F9-4166-08D9775F30C1', N'/api/admin/SysOrganization/findList/', N'0.0.0.1', N'', N'{"name":null,"state":1,"parentId":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'48', N'2021-09-14 17:11:50', N'2021-09-14 17:11:50')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'39007683-0FC1-45F3-4167-08D9775F30C1', N'/api/admin/SysDictionary/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'70', N'2021-09-14 17:11:54', N'2021-09-14 17:11:54')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C9C57256-5709-44EC-4168-08D9775F30C1', N'/api/admin/SysDictionary/getDictionaryTree', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'119', N'2021-09-14 17:11:54', N'2021-09-14 17:11:54')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F766B525-9ACA-4651-4169-08D9775F30C1', N'/api/admin/SysDictionary/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"b2770a68-a541-4e22-bcbc-08d94f78e4e4"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'39', N'2021-09-14 17:11:57', N'2021-09-14 17:11:57')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B4B901A3-9EEF-4AF1-416A-08D9775F30C1', N'/api/admin/SysDictionary/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'32', N'2021-09-14 17:12:00', N'2021-09-14 17:12:00')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'9C763DF0-EB8D-425E-416B-08D9775F30C1', N'/api/admin/SysDictionary/findForm/b2770a68-a541-4e22-bcbc-08d94f78e4e4', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'48', N'2021-09-14 17:12:01', N'2021-09-14 17:12:01')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'251BF6A5-2739-422A-416C-08D9775F30C1', N'/api/admin/SysDictionary/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"parentId":"b2770a68-a541-4e22-bcbc-08d94f78e4e4"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'30', N'2021-09-14 17:12:08', N'2021-09-14 17:12:08')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'AA60E319-5BD7-4D24-416D-08D9775F30C1', N'/api/admin/SysDictionary/findForm/4a88dcc3-8299-4699-8b99-08d94f79ea5d', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'22', N'2021-09-14 17:12:10', N'2021-09-14 17:12:10')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'36B14600-9F6F-4CFD-416E-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'43', N'2021-09-14 17:12:13', N'2021-09-14 17:12:13')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'7ED58F27-3324-425B-416F-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/2', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'29', N'2021-09-14 17:12:17', N'2021-09-14 17:12:17')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'3594FA6A-F75F-4658-4170-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/3', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'28', N'2021-09-14 17:12:19', N'2021-09-14 17:12:19')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'EA9156E5-23A8-4AA5-4171-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/4', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'26', N'2021-09-14 17:12:20', N'2021-09-14 17:12:20')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'42EEF469-343D-462F-4172-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/5', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'27', N'2021-09-14 17:12:32', N'2021-09-14 17:12:32')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'52904B01-8DC4-4B97-4173-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/15', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'31', N'2021-09-14 17:12:34', N'2021-09-14 17:12:34')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'EA7B1C4D-134D-4B7F-4174-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/11', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'56', N'2021-09-14 17:12:36', N'2021-09-14 17:12:36')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'7F49F8E9-B12A-4332-4175-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/9', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'33', N'2021-09-14 17:12:37', N'2021-09-14 17:12:37')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'2CB50A16-6247-4DDF-4176-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/7', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'28', N'2021-09-14 17:12:39', N'2021-09-14 17:12:39')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'EAD1B38F-75D8-480A-4177-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/5', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'29', N'2021-09-14 17:12:39', N'2021-09-14 17:12:39')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0FF067A7-136D-4742-4178-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/3', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'26', N'2021-09-14 17:12:40', N'2021-09-14 17:12:40')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'13938024-C97B-4882-4179-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/5', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'38', N'2021-09-14 17:12:43', N'2021-09-14 17:12:43')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'6E8B95E2-F365-4C30-417A-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/6', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'60', N'2021-09-14 17:12:44', N'2021-09-14 17:12:44')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'7C02F571-FDDB-400B-417B-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'26', N'2021-09-14 17:12:46', N'2021-09-14 17:12:46')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C8B72C98-C9EE-4E76-417C-08D9775F30C1', N'/api/admin/SysOperationLog/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'55', N'2021-09-14 17:13:53', N'2021-09-14 17:13:53')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'E7F0A585-2CDE-4CB4-5D52-08D97760200F', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'358', N'2021-09-14 17:14:59', N'2021-09-14 17:14:59')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'94A77EA0-1016-457D-9C88-08D977603A0B', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'383', N'2021-09-14 17:15:42', N'2021-09-14 17:15:42')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0AC441CA-A880-4ADE-9C89-08D977603A0B', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'68', N'2021-09-14 17:15:48', N'2021-09-14 17:15:48')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F4EFB966-82AA-4E1F-9C8A-08D977603A0B', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'157', N'2021-09-14 17:15:49', N'2021-09-14 17:15:49')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'363B8044-B9E1-48EF-9C8B-08D977603A0B', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123qwe"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'108231', N'2021-09-14 17:17:44', N'2021-09-14 17:17:44')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'697CC9C3-C684-4E52-9C8C-08D977603A0B', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'6250', N'2021-09-14 17:18:10', N'2021-09-14 17:18:10')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'BFB7573F-74ED-46FE-9C8D-08D977603A0B', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'105', N'2021-09-14 17:18:13', N'2021-09-14 17:18:13')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'35FAF55A-ABEC-408A-54F4-08D97760A45C', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'326', N'2021-09-14 17:18:41', N'2021-09-14 17:18:41')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'3827AC55-ED78-4F71-54F5-08D97760A45C', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'70', N'2021-09-14 17:18:47', N'2021-09-14 17:18:47')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'3E85277C-0557-4527-54F6-08D97760A45C', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'172', N'2021-09-14 17:18:48', N'2021-09-14 17:18:48')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'C5DE8232-3E88-4D9A-54F7-08D97760A45C', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'62569', N'2021-09-14 17:19:53', N'2021-09-14 17:19:53')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'CE7AF9D1-5ADD-4C32-54F8-08D97760A45C', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'3237', N'2021-09-14 17:19:58', N'2021-09-14 17:19:58')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'5F20A5F8-EA61-4EC6-54F9-08D97760A45C', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'42', N'2021-09-14 17:19:58', N'2021-09-14 17:19:58')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F98271C6-279C-40FA-54FA-08D97760A45C', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'25', N'2021-09-14 17:20:08', N'2021-09-14 17:20:08')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'D50431F9-03E4-406C-54FB-08D97760A45C', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'41', N'2021-09-14 17:20:09', N'2021-09-14 17:20:09')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B98B2826-8E6D-4F53-90EE-08D97760E693', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'326', N'2021-09-14 17:20:32', N'2021-09-14 17:20:32')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'28346DA1-C366-4D3D-90EF-08D97760E693', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'97', N'2021-09-14 17:20:43', N'2021-09-14 17:20:43')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'11D89936-5127-46B5-90F0-08D97760E693', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'56', N'2021-09-14 17:20:43', N'2021-09-14 17:20:43')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B69C495F-B14E-446A-90F1-08D97760E693', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'86', N'2021-09-14 17:20:52', N'2021-09-14 17:20:52')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'38440262-8120-4D9C-90F2-08D97760E693', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'143', N'2021-09-14 17:20:52', N'2021-09-14 17:20:52')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'F72BCA86-7C90-4516-90F3-08D97760E693', N'/api/admin/SysOperationLog/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'56', N'2021-09-14 17:20:57', N'2021-09-14 17:20:57')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'D2BEDC4F-81AE-4134-90F4-08D97760E693', N'/api/admin/SysFunction/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'51', N'2021-09-14 17:20:59', N'2021-09-14 17:20:59')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'8EAC2412-F248-4396-90F5-08D97760E693', N'/api/admin/SysRole/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'59', N'2021-09-14 17:21:00', N'2021-09-14 17:21:00')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'24F33B8A-1CF6-4985-90F6-08D97760E693', N'/api/admin/SysRole/findForm/40ff1844-c099-4061-98e0-cd6e544fcfd3', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'54', N'2021-09-14 17:21:02', N'2021-09-14 17:21:02')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'3403F03E-16BD-4D78-4160-08D9780E3881', N'/api/account/check', N'0.0.0.1', N'', N'{"userName":"admin","userPassword":"123456"}', N'', N'Chrome93', N'Windows10', NULL, N'547', N'2021-09-15 14:01:12', N'2021-09-15 14:01:12')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'7C478C83-DC14-472E-4161-08D9780E3881', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'225', N'2021-09-15 14:01:13', N'2021-09-15 14:01:13')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'440989DD-C75F-4A79-4162-08D9780E3881', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'77', N'2021-09-15 14:01:18', N'2021-09-15 14:01:18')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'D06D2C3D-DC24-4593-4163-08D9780E3881', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'131', N'2021-09-15 14:01:18', N'2021-09-15 14:01:18')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'E7F7C4D0-0C26-4626-0BD2-08D9780E68D4', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'293', N'2021-09-15 14:02:33', N'2021-09-15 14:02:33')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'5CFF3523-50DF-4068-0BD3-08D9780E68D4', N'/api/admin/SysOperationLog/findList/10/1', N'0.0.0.1', N'', N'{"name":null}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'106', N'2021-09-15 14:02:37', N'2021-09-15 14:02:37')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'B2494AA8-0744-4243-6224-08D9780EA151', N'/api/admin/SysUser/info', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'267', N'2021-09-15 14:04:08', N'2021-09-15 14:04:08')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'6A4810CF-88F4-4A57-6225-08D9780EA151', N'/api/admin/SysUser/sysOrganizationTree', N'0.0.0.1', N'', N'{}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'73', N'2021-09-15 14:04:12', N'2021-09-15 14:04:12')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'0C9356DF-E146-4C71-6226-08D9780EA151', N'/api/admin/SysUser/findList/10/1', N'0.0.0.1', N'', N'{"name":null,"loginName":null,"organizationId":"f23777dd-2c03-449f-953b-df91c19dee5b"}', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'136', N'2021-09-15 14:04:13', N'2021-09-15 14:04:13')
GO

INSERT INTO [dbo].[SysOperationLog] ([Id], [Api], [Ip], [Form], [FormBody], [QueryString], [Browser], [OS], [UserId], [TakeUpTime], [UpdateTime], [CreateTime]) VALUES (N'057D05B7-7988-460A-6227-08D9780EA151', N'/api/admin/SysUser/findForm/ac18f496-e93d-42f0-b59e-e321acc85335', N'0.0.0.1', N'', N'', N'', N'Chrome93', N'Windows10', N'0198459E-2034-4533-B843-5D227AD20740', N'73', N'2021-09-15 14:04:14', N'2021-09-15 14:04:14')
GO


-- ----------------------------
-- Table structure for SysOrganization
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysOrganization]') AND type IN ('U'))
	DROP TABLE [dbo].[SysOrganization]
GO

CREATE TABLE [dbo].[SysOrganization] (
  [Id] uniqueidentifier  NOT NULL,
  [Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderNumber] int  NULL,
  [Leader] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Phone] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [State] int  NULL,
  [ParentId] uniqueidentifier  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysOrganization] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysOrganization
-- ----------------------------
INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'E898E8AD-2DE7-46E0-B6F3-08F5FB9662ED', N'财务部门', N'4', N'财务部门', N'12323452345', N'12312@qq.com', N'1', N'47C547EA-E07A-4475-A4F7-AE09E3D8FAFC', N'2021-05-27 22:33:13', N'2021-05-27 22:33:13')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'A5E87436-53D5-4FFF-8F2E-0AF511DB9BA4', N'研发部门', N'1', N'研发部门', N'1234323423', N'12312@qq.com', N'1', N'47C547EA-E07A-4475-A4F7-AE09E3D8FAFC', N'2021-05-27 22:32:29', N'2021-05-27 22:32:08')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'9CF32211-F255-4C2E-9C53-4258755E43C5', N'测试部门', N'3', N'测试部门', N'12313', N'123123@qq.com', N'1', N'47C547EA-E07A-4475-A4F7-AE09E3D8FAFC', N'2021-05-27 22:32:59', N'2021-05-27 22:32:59')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'1B001A4D-BCE5-4E09-BC96-4E7DA7686C48', N'北京分部', N'3', N'北京分部', N'132123', N'13131', N'1', N'F23777DD-2C03-449F-953B-DF91C19DEE5B', N'2021-05-27 22:33:44', N'2021-05-27 22:33:44')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'05E55B19-261A-4DF8-AEA0-83A56F1AEB7A', N'市场部门', N'2', N'市场部门', N'123213', N'123@qq.com', N'1', N'47C547EA-E07A-4475-A4F7-AE09E3D8FAFC', N'2021-05-27 22:32:46', N'2021-05-27 22:32:40')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'47C547EA-E07A-4475-A4F7-AE09E3D8FAFC', N'成都分部', N'2', N'成都分部', N'123123123', N'123@qq.com', N'1', N'F23777DD-2C03-449F-953B-DF91C19DEE5B', N'2021-05-27 22:31:45', N'2021-05-27 21:01:50')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'6E36F7EB-3D03-417D-8815-C0E0F19CE6E6', N'市场部门', N'1', N'市场部门', N'234124234', N'234234@qq.com', N'1', N'1B001A4D-BCE5-4E09-BC96-4E7DA7686C48', N'2021-05-27 22:33:57', N'2021-05-27 22:33:57')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'F23777DD-2C03-449F-953B-DF91C19DEE5B', N'阿里巴巴集团', N'1', N'hzy', N'18410912184', N'18410912184@qq.com', N'1', NULL, N'2021-05-27 20:50:31', N'2021-05-27 20:50:31')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'EB913607-932F-433B-8321-DFE35258BB88', N'运维部门', N'5', N'运维部门', N'1232133452', N'12341@qq.com', N'1', N'47C547EA-E07A-4475-A4F7-AE09E3D8FAFC', N'2021-05-27 22:33:25', N'2021-05-27 22:33:25')
GO

INSERT INTO [dbo].[SysOrganization] ([Id], [Name], [OrderNumber], [Leader], [Phone], [Email], [State], [ParentId], [UpdateTime], [CreateTime]) VALUES (N'AEA25949-B0A0-49A3-9FBC-E80224B75FC1', N'财务部门', N'2', N'财务部门', N'435543535', N'123@qq.com', N'1', N'1B001A4D-BCE5-4E09-BC96-4E7DA7686C48', N'2021-05-27 22:34:11', N'2021-05-27 22:34:11')
GO


-- ----------------------------
-- Table structure for SysPost
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysPost]') AND type IN ('U'))
	DROP TABLE [dbo].[SysPost]
GO

CREATE TABLE [dbo].[SysPost] (
  [Id] uniqueidentifier  NOT NULL,
  [Number] int  NULL,
  [Code] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [State] int  NULL,
  [Remarks] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysPost] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysPost
-- ----------------------------
INSERT INTO [dbo].[SysPost] ([Id], [Number], [Code], [Name], [State], [Remarks], [UpdateTime], [CreateTime]) VALUES (N'0716B4B0-9A06-43E9-8AE8-82C74875F83E', N'2', N'se', N'项目经理', N'1', NULL, N'2021-05-27 20:26:35', N'2021-05-27 20:26:35')
GO

INSERT INTO [dbo].[SysPost] ([Id], [Number], [Code], [Name], [State], [Remarks], [UpdateTime], [CreateTime]) VALUES (N'96927C30-41D0-4CED-8E29-CBED35C90FB0', N'1', N'ceo', N'董事长', N'1', NULL, N'2021-05-27 20:26:22', N'2021-05-27 20:26:22')
GO

INSERT INTO [dbo].[SysPost] ([Id], [Number], [Code], [Name], [State], [Remarks], [UpdateTime], [CreateTime]) VALUES (N'E46AF329-6D08-442C-9837-F22CFF954411', N'4', N'user', N'普通员工', N'1', NULL, N'2021-05-27 20:26:52', N'2021-05-27 20:26:52')
GO

INSERT INTO [dbo].[SysPost] ([Id], [Number], [Code], [Name], [State], [Remarks], [UpdateTime], [CreateTime]) VALUES (N'F0C67537-8094-429A-B474-F54AC518609E', N'3', N'hr', N'人力资源', N'1', NULL, N'2021-05-27 20:26:44', N'2021-05-27 20:26:44')
GO


-- ----------------------------
-- Table structure for SysRole
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysRole]') AND type IN ('U'))
	DROP TABLE [dbo].[SysRole]
GO

CREATE TABLE [dbo].[SysRole] (
  [Id] uniqueidentifier  NOT NULL,
  [Number] int  NULL,
  [Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDelete] int  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysRole] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysRole
-- ----------------------------
INSERT INTO [dbo].[SysRole] ([Id], [Number], [Name], [Remark], [IsDelete], [UpdateTime], [CreateTime]) VALUES (N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'1', N'超级管理员', N'拥有所有权限', N'0', N'2021-01-10 11:25:12', N'2016-07-06 17:59:20')
GO

INSERT INTO [dbo].[SysRole] ([Id], [Number], [Name], [Remark], [IsDelete], [UpdateTime], [CreateTime]) VALUES (N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'2', N'普通用户', N'普通用户', N'1', N'2021-01-30 00:51:17', N'2016-07-06 17:59:20')
GO


-- ----------------------------
-- Table structure for SysRoleMenuFunction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysRoleMenuFunction]') AND type IN ('U'))
	DROP TABLE [dbo].[SysRoleMenuFunction]
GO

CREATE TABLE [dbo].[SysRoleMenuFunction] (
  [Id] uniqueidentifier  NOT NULL,
  [RoleId] uniqueidentifier  NULL,
  [MenuId] uniqueidentifier  NULL,
  [FunctionId] uniqueidentifier  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysRoleMenuFunction] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysRoleMenuFunction
-- ----------------------------
INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'93CE6573-523E-4E3C-3D63-08D88BC25510', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'0B7F8E2C-9FAA-4496-9068-80B87BA1B64E', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-04-18 22:08:06', N'2020-11-18 21:03:36')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'463ACEA8-60B0-4A59-7DE7-08D8BB7C529A', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-18 14:45:40', N'2021-01-18 14:45:40')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'F1B431B3-D7EF-44CA-7DE8-08D8BB7C529A', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-01-18 14:45:40', N'2021-01-18 14:45:40')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'D80E356E-0D71-411F-7DE9-08D8BB7C529A', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-01-18 14:45:40', N'2021-01-18 14:45:40')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'2F2F0C63-2E13-4137-98DB-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'F55A8858-EDE4-4380-85B2-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 14:58:36', N'2021-01-19 14:58:36')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'0BE2633E-046D-40FA-98DC-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'38FD48A9-4035-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 14:58:38', N'2021-01-19 14:58:38')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'1E882FBE-FD88-407E-98DD-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'63A6D076-3E22-4D26-85B4-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 14:58:42', N'2021-01-19 14:58:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'DE19371D-5FBE-4FC3-98DE-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'9B01F9F3-5621-4BC2-85B5-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 14:58:42', N'2021-01-19 14:58:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'12CEEF4D-03C0-45CC-98DF-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'D788896B-4033-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 14:58:43', N'2021-01-19 14:58:43')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'1C082C5A-8383-443F-98E0-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'35DC130E-4034-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 14:58:44', N'2021-01-19 14:58:44')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'D5D321CE-28E6-4742-98E1-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'CC99F568-A831-4EA8-4C7A-08D8BBA503BF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 14:58:45', N'2021-01-19 14:58:45')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'99E29596-75A0-4736-98E2-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'9A27DFC2-4A66-11EB-87B1-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 14:58:52', N'2021-01-19 14:58:52')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C0C76981-828B-435E-98E3-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-01-19 15:12:04', N'2021-01-19 15:12:04')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'6A3D6AC5-11C7-4592-98E4-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-01-19 15:12:04', N'2021-01-19 15:12:04')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'ED97D135-4408-41CC-98E5-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-01-19 15:12:04', N'2021-01-19 15:12:04')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E18A8DAD-716D-49CD-98E6-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-01-19 15:12:04', N'2021-01-19 15:12:04')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'AFFC5760-C5BD-43FB-98E7-08D8BC47A2C8', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-01-19 15:12:04', N'2021-01-19 15:12:04')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'EB2AC2A6-36AC-4EE1-F05E-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'38FD48A9-4035-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:24', N'2021-05-12 20:25:24')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'5EE46CD1-B2A3-4BC2-F05F-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'F55A8858-EDE4-4380-85B2-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:24', N'2021-05-12 20:25:24')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'EC8ED1BA-61C3-4219-F060-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'63A6D076-3E22-4D26-85B4-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:25', N'2021-05-12 20:25:25')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'9D35E600-EE44-479A-F061-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'9B01F9F3-5621-4BC2-85B5-08D8B9F578EF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:25', N'2021-05-12 20:25:25')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'FCCCD730-D83E-47B1-F062-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D788896B-4033-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:26', N'2021-05-12 20:25:26')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'0946C554-84A7-4ADB-F063-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'35DC130E-4034-11EB-A2CB-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:27', N'2021-05-12 20:25:27')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'57A97A6C-CC65-4AC6-F064-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'CC99F568-A831-4EA8-4C7A-08D8BBA503BF', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:27', N'2021-05-12 20:25:27')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'EEE9D884-A577-40D2-F06A-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'BD024F3A-99A7-4407-861C-A016F243F222', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:32', N'2021-05-12 20:25:32')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'6DFA0985-81FA-4242-F06B-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'F35D64AE-ECB7-4D06-ACFB-D91595966D9E', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:33', N'2021-05-12 20:25:33')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'915AC7F5-4E1B-4D92-F06C-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'9A27DFC2-4A66-11EB-87B1-4CEDFB69A3E8', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:33', N'2021-05-12 20:25:33')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'CB043048-142D-464D-F0A4-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:42', N'2021-05-12 20:25:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'82EB14DA-2B31-45D8-F0A5-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-12 20:25:42', N'2021-05-12 20:25:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'8E87C5CB-1C6E-481E-F0A6-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-12 20:25:42', N'2021-05-12 20:25:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'623EAF4E-5263-4FB9-F0A7-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-12 20:25:42', N'2021-05-12 20:25:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'FF047BDD-04F4-4597-F0A8-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-12 20:25:42', N'2021-05-12 20:25:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'B3AC009F-017B-4512-F0A9-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-12 20:25:42', N'2021-05-12 20:25:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'F2891613-0A65-4C93-F0AA-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'38D864FF-F6E7-43AF-8C5C-8BBCF9FA586D', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-12 20:25:42', N'2021-05-12 20:25:42')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'26250C7D-B504-44CC-F0BF-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:46', N'2021-05-12 20:25:46')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E69FE992-E4A5-4AC9-F0C0-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-12 20:25:46', N'2021-05-12 20:25:46')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'FA279E29-F44F-4424-F0C1-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-12 20:25:46', N'2021-05-12 20:25:46')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'0920F21B-FBBF-45F4-F0C2-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-12 20:25:46', N'2021-05-12 20:25:46')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'541450F0-DBD3-4094-F0C3-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-12 20:25:46', N'2021-05-12 20:25:46')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'9AC7BDFB-7398-4DC8-F0C4-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-12 20:25:46', N'2021-05-12 20:25:46')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'6C934FA6-EFF0-42C7-F0C5-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'60AE9382-31AB-4276-A379-D3876E9BB783', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-12 20:25:46', N'2021-05-12 20:25:46')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E02EF258-BE98-4A5C-F0E1-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:50', N'2021-05-12 20:25:50')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'97C80C3A-D00E-4788-F0E2-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-12 20:25:50', N'2021-05-12 20:25:50')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'5D470AE4-66A5-4CDF-F0E3-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-12 20:25:50', N'2021-05-12 20:25:50')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'7E74F26C-F63E-42F0-F0E4-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-12 20:25:50', N'2021-05-12 20:25:50')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'68AB8ACC-4D11-4E66-F0E5-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-12 20:25:50', N'2021-05-12 20:25:50')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'8E1EA93C-398C-4FE7-F0E6-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-12 20:25:50', N'2021-05-12 20:25:50')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E08A05A7-C494-4E32-F0E7-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'B6FD5425-504A-46A9-993B-2F8DC9158EB8', N'2021-05-12 20:25:50', N'2021-05-12 20:25:50')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'4CA56FED-FC32-4456-F0E8-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'D721FC55-2174-40EB-BB37-5C54A158525A', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-12 20:25:50', N'2021-05-12 20:25:50')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C5ABDA7A-230D-469F-F104-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-05-12 20:25:54', N'2021-05-12 20:25:54')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'9F341E22-87C3-498A-F105-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-05-12 20:25:54', N'2021-05-12 20:25:54')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'92837E44-E8D2-48A2-F106-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-05-12 20:25:54', N'2021-05-12 20:25:54')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'052DD69B-C809-4F62-F107-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-05-12 20:25:54', N'2021-05-12 20:25:54')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'A36D2F2E-56F4-4920-F108-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-05-12 20:25:54', N'2021-05-12 20:25:54')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'F65ADC84-D2A4-4F91-F109-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-05-12 20:25:54', N'2021-05-12 20:25:54')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'704A78F1-5C00-4169-F10A-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'B6FD5425-504A-46A9-993B-2F8DC9158EB8', N'2021-05-12 20:25:54', N'2021-05-12 20:25:54')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'C9D1ED28-5F58-4C7E-F10B-08D915410342', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'E5D4DA6B-AAB0-4AAA-982F-43673E8152C0', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-05-12 20:25:54', N'2021-05-12 20:25:54')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'3D48F0A9-103D-4AFD-C3BD-08D94DEFE002', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'BFFEFB1C-8988-4DDF-B4AC-81C2B30E80CD', N'2021-07-23 23:38:11', N'2021-07-23 23:38:11')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'F35E685F-FD6F-4143-C3BE-08D94DEFE002', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'E7EF2A05-8317-41C3-B588-99519FE88BF9', N'2021-07-23 23:38:11', N'2021-07-23 23:38:11')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'FA870601-C8B8-4ED7-C3BF-08D94DEFE002', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'9C388461-2704-4C5E-A729-72C17E9018E1', N'2021-07-23 23:38:11', N'2021-07-23 23:38:11')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'CDDD1528-3849-4193-C3C0-08D94DEFE002', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'383E7EE2-7690-46AC-9230-65155C84AA30', N'2021-07-23 23:38:11', N'2021-07-23 23:38:11')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'7017A61D-206B-43AF-C3C1-08D94DEFE002', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'F27ECB0A-197D-47B1-B243-59A8C71302BF', N'2021-07-23 23:38:11', N'2021-07-23 23:38:11')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'642A76A6-B53F-4BBF-C3C2-08D94DEFE002', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'2401F4D0-60B0-4E2E-903F-84C603373572', N'2021-07-23 23:38:11', N'2021-07-23 23:38:11')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E060ECA0-7F5E-4B87-C3C3-08D94DEFE002', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'B6FD5425-504A-46A9-993B-2F8DC9158EB8', N'2021-07-23 23:38:11', N'2021-07-23 23:38:11')
GO

INSERT INTO [dbo].[SysRoleMenuFunction] ([Id], [RoleId], [MenuId], [FunctionId], [UpdateTime], [CreateTime]) VALUES (N'E73BA3C0-508A-4792-C3C4-08D94DEFE002', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'7C34C2FD-98ED-4655-AA04-BB00B915A751', N'C9518758-B2E1-4F51-B517-5282E273889C', N'2021-07-23 23:38:11', N'2021-07-23 23:38:11')
GO


-- ----------------------------
-- Table structure for SysUser
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysUser]') AND type IN ('U'))
	DROP TABLE [dbo].[SysUser]
GO

CREATE TABLE [dbo].[SysUser] (
  [Id] uniqueidentifier  NOT NULL,
  [Name] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LoginName] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Password] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Phone] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [IsDelete] int  NULL,
  [OrganizationId] uniqueidentifier  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysUser] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysUser
-- ----------------------------
INSERT INTO [dbo].[SysUser] ([Id], [Name], [LoginName], [Password], [Phone], [Email], [IsDelete], [OrganizationId], [UpdateTime], [CreateTime]) VALUES (N'0198459E-2034-4533-B843-5D227AD20740', N'超级管理员', N'admin', N'E10ADC3949BA59ABBE56E057F20F883E', N'123123123', N'1396510655@qq.com', N'2', N'F23777DD-2C03-449F-953B-DF91C19DEE5B', N'2021-05-24 10:52:53', N'2017-04-06 19:55:53')
GO

INSERT INTO [dbo].[SysUser] ([Id], [Name], [LoginName], [Password], [Phone], [Email], [IsDelete], [OrganizationId], [UpdateTime], [CreateTime]) VALUES (N'AC18F496-E93D-42F0-B59E-E321ACC85335', N'用户', N'user', N'E10ADC3949BA59ABBE56E057F20F883E', N'456456456', N'18123456789@live.com', N'1', N'F23777DD-2C03-449F-953B-DF91C19DEE5B', N'2021-04-18 22:08:12', N'2017-04-06 19:55:53')
GO


-- ----------------------------
-- Table structure for SysUserPost
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysUserPost]') AND type IN ('U'))
	DROP TABLE [dbo].[SysUserPost]
GO

CREATE TABLE [dbo].[SysUserPost] (
  [Id] uniqueidentifier  NOT NULL,
  [UserId] uniqueidentifier  NULL,
  [PostId] uniqueidentifier  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysUserPost] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysUserPost
-- ----------------------------
INSERT INTO [dbo].[SysUserPost] ([Id], [UserId], [PostId], [UpdateTime], [CreateTime]) VALUES (N'0639DDA4-DD3E-42C8-9237-037941DCA9D1', N'0198459E-2034-4533-B843-5D227AD20740', N'96927C30-41D0-4CED-8E29-CBED35C90FB0', N'2021-08-01 22:51:59', N'2021-08-01 22:51:59')
GO

INSERT INTO [dbo].[SysUserPost] ([Id], [UserId], [PostId], [UpdateTime], [CreateTime]) VALUES (N'8BE16163-CE6B-4ABB-908C-F343C6DF5ECC', N'AC18F496-E93D-42F0-B59E-E321ACC85335', N'0716B4B0-9A06-43E9-8AE8-82C74875F83E', N'2021-05-28 10:33:35', N'2021-05-28 10:33:35')
GO


-- ----------------------------
-- Table structure for SysUserRole
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SysUserRole]') AND type IN ('U'))
	DROP TABLE [dbo].[SysUserRole]
GO

CREATE TABLE [dbo].[SysUserRole] (
  [Id] uniqueidentifier  NOT NULL,
  [UserId] uniqueidentifier  NULL,
  [RoleId] uniqueidentifier  NULL,
  [UpdateTime] datetime2(0)  NULL,
  [CreateTime] datetime2(0)  NULL
)
GO

ALTER TABLE [dbo].[SysUserRole] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of SysUserRole
-- ----------------------------
INSERT INTO [dbo].[SysUserRole] ([Id], [UserId], [RoleId], [UpdateTime], [CreateTime]) VALUES (N'9C6E49E7-FCF0-4372-B726-9D9D8B9A55E8', N'AC18F496-E93D-42F0-B59E-E321ACC85335', N'40FF1844-C099-4061-98E0-CD6E544FCFD3', N'2021-05-28 10:33:35', N'2021-05-28 10:33:35')
GO

INSERT INTO [dbo].[SysUserRole] ([Id], [UserId], [RoleId], [UpdateTime], [CreateTime]) VALUES (N'22D86F5E-A737-411D-B33C-FC0FF485C78E', N'0198459E-2034-4533-B843-5D227AD20740', N'18FA4771-6F58-46A3-80D2-6F0F5E9972E3', N'2021-08-01 22:51:59', N'2021-08-01 22:51:59')
GO


-- ----------------------------
-- Primary Key structure for table Member
-- ----------------------------
ALTER TABLE [dbo].[Member] ADD CONSTRAINT [Member_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table SysDictionary
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [SysDictionary_Id_uindex]
ON [dbo].[SysDictionary] (
  [Id] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table SysDictionary
-- ----------------------------
ALTER TABLE [dbo].[SysDictionary] ADD CONSTRAINT [SysDictionary_pk] PRIMARY KEY NONCLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysFunction
-- ----------------------------
ALTER TABLE [dbo].[SysFunction] ADD CONSTRAINT [SysFunction_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysMenu
-- ----------------------------
ALTER TABLE [dbo].[SysMenu] ADD CONSTRAINT [SysMenu_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysMenuFunction
-- ----------------------------
ALTER TABLE [dbo].[SysMenuFunction] ADD CONSTRAINT [SysMenuFunction_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysOperationLog
-- ----------------------------
ALTER TABLE [dbo].[SysOperationLog] ADD CONSTRAINT [PK__SysOpera__3214EC0743ACCFCD] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysOrganization
-- ----------------------------
ALTER TABLE [dbo].[SysOrganization] ADD CONSTRAINT [SysOrganization_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysPost
-- ----------------------------
ALTER TABLE [dbo].[SysPost] ADD CONSTRAINT [SysPost_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysRole
-- ----------------------------
ALTER TABLE [dbo].[SysRole] ADD CONSTRAINT [SysRole_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysRoleMenuFunction
-- ----------------------------
ALTER TABLE [dbo].[SysRoleMenuFunction] ADD CONSTRAINT [SysRoleMenuFunction_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysUser
-- ----------------------------
ALTER TABLE [dbo].[SysUser] ADD CONSTRAINT [SysUser_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysUserPost
-- ----------------------------
ALTER TABLE [dbo].[SysUserPost] ADD CONSTRAINT [SysUserPost_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table SysUserRole
-- ----------------------------
ALTER TABLE [dbo].[SysUserRole] ADD CONSTRAINT [SysUserRole_pkey] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

