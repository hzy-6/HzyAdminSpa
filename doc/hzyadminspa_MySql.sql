/*
 Navicat Premium Data Transfer

 Source Server         : 本地_MySql
 Source Server Type    : MySQL
 Source Server Version : 80019
 Source Host           : localhost:3306
 Source Schema         : hzyadminspa

 Target Server Type    : MySQL
 Target Server Version : 80019
 File Encoding         : 65001

 Date: 05/08/2021 22:16:38
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for member
-- ----------------------------
DROP TABLE IF EXISTS `member`;
CREATE TABLE `member`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Number` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Sex` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Birthday` datetime(0) NULL DEFAULT NULL,
  `Photo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Introduce` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FilePath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UserId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of member
-- ----------------------------
INSERT INTO `member` VALUES ('96a1aa3d-a61a-42d0-954a-c71753fb2065', '123', '123', '123', '女', '2018-04-25 23:00:00', NULL, '<p>123</p>', NULL, 'ac18f496-e93d-42f0-b59e-e321acc85335', '2020-10-24 00:07:42', '2021-04-18 22:08:06');
INSERT INTO `member` VALUES ('9a604aa2-9ae6-4a2f-8ddb-d9e0289ead9e', '1', '测试会员', '18510912123', '男', '2019-07-08 11:47:24', '/upload/files/20210118/time_232747_old_name_hzy.png', '<p>888</p>', '/upload/files/20210118/time_233310_old_name_hzy.png', 'ac18f496-e93d-42f0-b59e-e321acc85335', '2018-04-25 23:00:00', '2021-01-19 14:19:47');

-- ----------------------------
-- Table structure for sysdictionary
-- ----------------------------
DROP TABLE IF EXISTS `sysdictionary`;
CREATE TABLE `sysdictionary`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT 'id',
  `UpdateTime` datetime(0) NULL DEFAULT NULL COMMENT '更新时间',
  `CreateTime` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `Sort` int(0) NULL DEFAULT NULL COMMENT '排序号',
  `Code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '编码',
  `Value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '值',
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '分组名/键',
  `ParentId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '父级分组id',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `SysDictionary_Id_uindex`(`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '数据字典' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysdictionary
-- ----------------------------
INSERT INTO `sysdictionary` VALUES ('015B0F58-B9A5-4A11-8B9A-08D94F79EA5D', '2021-07-25 22:40:53', '2021-07-25 22:40:48', 2, 'news_type_nv', '2', '女', 'B2770A68-A541-4E22-BCBC-08D94F78E4E4');
INSERT INTO `sysdictionary` VALUES ('4A88DCC3-8299-4699-8B99-08D94F79EA5D', '2021-07-25 22:40:30', '2021-07-25 22:38:49', 1, 'news_type_nan', '1', '男', 'B2770A68-A541-4E22-BCBC-08D94F78E4E4');
INSERT INTO `sysdictionary` VALUES ('B2770A68-A541-4E22-BCBC-08D94F78E4E4', '2021-07-25 22:39:35', '2021-07-25 22:31:30', 1, 'news_type', NULL, '资讯类别', NULL);

-- ----------------------------
-- Table structure for sysfunction
-- ----------------------------
DROP TABLE IF EXISTS `sysfunction`;
CREATE TABLE `sysfunction`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Number` int(0) NULL DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ByName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysfunction
-- ----------------------------
INSERT INTO `sysfunction` VALUES ('2401f4d0-60b0-4e2e-903f-84c603373572', 70, '导出', 'Export', 'Export', '2021-04-18 22:08:06', '2016-06-20 13:40:52');
INSERT INTO `sysfunction` VALUES ('383e7ee2-7690-46ac-9230-65155c84aa30', 50, '保存', 'Save', 'Save', '2021-04-18 22:08:06', '2016-06-20 13:40:52');
INSERT INTO `sysfunction` VALUES ('9c388461-2704-4c5e-a729-72c17e9018e1', 40, '删除', 'Delete', 'Delete', '2021-04-18 22:08:06', '2016-06-20 13:40:52');
INSERT INTO `sysfunction` VALUES ('b6fd5425-504a-46a9-993b-2f8dc9158eb8', 80, '打印', 'Print', 'Print', '2021-04-18 22:08:06', '2016-06-20 13:40:52');
INSERT INTO `sysfunction` VALUES ('bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', 20, '添加', 'Insert', 'Insert', '2021-04-18 22:08:06', '2016-06-20 13:40:52');
INSERT INTO `sysfunction` VALUES ('c9518758-b2e1-4f51-b517-5282e273889c', 10, '显示', 'Display', 'Display', '2021-04-18 22:08:06', '2016-06-20 13:40:52');
INSERT INTO `sysfunction` VALUES ('e7ef2a05-8317-41c3-b588-99519fe88bf9', 30, '修改', 'Update', 'Update', '2021-04-18 22:08:06', '2016-06-20 13:40:52');
INSERT INTO `sysfunction` VALUES ('f27ecb0a-197d-47b1-b243-59a8c71302bf', 60, '检索', 'Search', 'Search', '2021-04-18 22:08:06', '2016-06-20 13:40:52');

-- ----------------------------
-- Table structure for sysmenu
-- ----------------------------
DROP TABLE IF EXISTS `sysmenu`;
CREATE TABLE `sysmenu`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Number` int(0) NULL DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Url` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Router` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ComponentName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Icon` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ParentId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Show` int(0) NULL DEFAULT NULL,
  `Close` int(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `JumpUrl` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysmenu
-- ----------------------------
INSERT INTO `sysmenu` VALUES ('0abfd53b-6bde-42c6-9f99-e32775bc31dd', 180, '组织机构', 'views/system/organization/index', '/system/organization', 'system_organization', 'ClusterOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:57:27', '2021-05-27 20:27:56', NULL);
INSERT INTO `sysmenu` VALUES ('10E7B3CF-D846-4B1B-7662-08D95814698B', 200, '操作日志', 'views/system/sys_operation_log/index', '/system/sys_operation_log', 'sys_operation_log', 'ContainerOutlined', '9591F249-1471-44F7-86B5-6FDAE8B93888', 1, 1, '2021-08-05 21:48:54', '2021-08-05 21:24:54', '');
INSERT INTO `sysmenu` VALUES ('15455a8d-262d-4266-85b3-08d8b9f578ef', 40, '图表 AntV G2', NULL, NULL, NULL, 'PieChartOutlined', '6f48b583-9c8f-490f-a3e0-81fc5f2e71b4', 1, 1, '2021-01-16 16:06:33', '2021-01-16 16:06:33', NULL);
INSERT INTO `sysmenu` VALUES ('1ec76c4c-b9b3-4517-9854-f08cd11d653d', 90, '基础信息', NULL, NULL, NULL, 'GoldOutlined', NULL, 1, 1, '2021-01-18 19:33:46', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('35dc130e-4034-11eb-a2cb-4cedfb69a3e8', 110, '标准表格', 'views/list/index', '/list', 'list', NULL, '9674d439-864e-4bf8-9dd8-08d7d70ad6bb', 1, 1, '2020-12-17 14:51:05', '2020-12-17 14:51:07', NULL);
INSERT INTO `sysmenu` VALUES ('383053F9-DA70-4A0D-B9F0-08D94F7318CD', 190, '数据字典', 'views/system/dictionary/index', '/system/dictionary', 'system_dictionary', 'FileDoneOutlined', '9591F249-1471-44F7-86B5-6FDAE8B93888', 1, 1, '2021-07-25 21:51:53', '2021-07-25 21:50:01', NULL);
INSERT INTO `sysmenu` VALUES ('38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 100, '账户管理', 'views/system/user/index', '/system/user', 'system_user', 'UserOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:44:36', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('38fd48a9-4035-11eb-a2cb-4cedfb69a3e8', 30, '按钮', 'views/button', '/button', 'button', 'AppstoreOutlined', '6f48b583-9c8f-490f-a3e0-81fc5f2e71b4', 1, 1, '2021-01-16 16:04:05', '2020-12-17 14:58:05', NULL);
INSERT INTO `sysmenu` VALUES ('60ae9382-31ab-4276-a379-d3876e9bb783', 110, '角色管理', 'views/system/role/index', '/system/role', 'system_role', 'TeamOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:45:16', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('63a6d076-3e22-4d26-85b4-08d8b9f578ef', 10, '基础图表', 'views/chart/base', '/chart/base', 'chart_base', NULL, '15455a8d-262d-4266-85b3-08d8b9f578ef', 1, 1, '2021-01-16 16:07:24', '2021-01-16 16:07:24', NULL);
INSERT INTO `sysmenu` VALUES ('6f48b583-9c8f-490f-a3e0-81fc5f2e71b4', 10, '更多示例', NULL, NULL, NULL, NULL, NULL, 1, 1, '2021-05-28 11:49:02', '2021-05-28 11:49:02', NULL);
INSERT INTO `sysmenu` VALUES ('7c34c2fd-98ed-4655-aa04-bb00b915a751', 10, '会员管理', 'views/base/member', '/base/member', 'base_member', 'UsergroupAddOutlined', '1ec76c4c-b9b3-4517-9854-f08cd11d653d', 1, 1, '2021-05-28 12:58:22', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('90E7F189-9160-4E46-E2D5-08D958181601', 70, '跳转外部地址', NULL, NULL, NULL, 'RadarChartOutlined', '6F48B583-9C8F-490F-A3E0-81FC5F2E71B4', 1, 1, '2021-08-05 21:51:12', '2021-08-05 21:51:12', 'https://antv.vision/zh');
INSERT INTO `sysmenu` VALUES ('9591f249-1471-44f7-86b5-6fdae8b93888', 100, '系统管理', NULL, NULL, NULL, 'DesktopOutlined', NULL, 1, 1, '2018-03-10 12:16:38', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('9674d439-864e-4bf8-9dd8-08d7d70ad6bb', 50, '表格管理', NULL, NULL, NULL, 'TableOutlined', '6f48b583-9c8f-490f-a3e0-81fc5f2e71b4', 1, 1, '2021-01-16 17:32:07', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('9a27dfc2-4a66-11eb-87b1-4cedfb69a3e8', 160, '接口文档', 'views/system/swagger', '/system/swagger', 'system_swagger', 'FileSearchOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:56:14', '2018-03-10 12:17:03', NULL);
INSERT INTO `sysmenu` VALUES ('9b01f9f3-5621-4bc2-85b5-08d8b9f578ef', 20, '更多示例', 'views/chart/more', '/chart/more', 'chart_more', NULL, '15455a8d-262d-4266-85b3-08d8b9f578ef', 1, 1, '2021-01-16 16:10:06', '2021-01-16 16:10:06', NULL);
INSERT INTO `sysmenu` VALUES ('bd024f3a-99a7-4407-861c-a016f243f222', 140, '角色功能', 'views/system/rolefunction/index', '/system/role/function', 'system_role_function', 'UserSwitchOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:53:04', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('cc99f568-a831-4ea8-4c7a-08d8bba503bf', 60, '富文本编辑器', 'views/editor', '/editor', 'editor', 'PicRightOutlined', '6f48b583-9c8f-490f-a3e0-81fc5f2e71b4', 1, 1, '2021-01-18 19:34:54', '2021-01-18 19:34:28', NULL);
INSERT INTO `sysmenu` VALUES ('d29fde94-0d6a-4a64-8446-55ee63df5885', 170, '岗位管理', 'views/system/post/index', '/system/post', 'system_post', 'IdcardOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:56:56', '2021-05-27 17:29:49', NULL);
INSERT INTO `sysmenu` VALUES ('d721fc55-2174-40eb-bb37-5c54a158525a', 120, '功能管理', 'views/system/function/index', '/system/function', 'system_function', 'ControlOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:49:53', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('d788896b-4033-11eb-a2cb-4cedfb69a3e8', 100, '基础表格', 'views/baseList', '/baseList', 'base_list', NULL, '9674d439-864e-4bf8-9dd8-08d7d70ad6bb', 1, 1, '2020-12-17 14:49:10', '2020-12-17 14:49:12', NULL);
INSERT INTO `sysmenu` VALUES ('e5d4da6b-aab0-4aaa-982f-43673e8152c0', 130, '菜单功能', 'views/system/menu/index', '/system/menu', 'system_menu', 'MenuOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:51:15', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('f35d64ae-ecb7-4d06-acfb-d91595966d9e', 150, '修改密码', 'views/system/changePassword/index', '/system/change/password', 'system_change_password', 'FormOutlined', '9591f249-1471-44f7-86b5-6fdae8b93888', 1, 1, '2021-05-28 12:55:04', '2018-03-10 12:16:38', NULL);
INSERT INTO `sysmenu` VALUES ('f55a8858-ede4-4380-85b2-08d8b9f578ef', 10, 'Antd Vue3.0组件库', 'views/antd_vue_components', '/antd/vue/components', 'antd_vue_components', 'LayoutOutlined', '6f48b583-9c8f-490f-a3e0-81fc5f2e71b4', 1, 1, '2021-01-16 16:05:46', '2021-01-16 16:05:22', NULL);

-- ----------------------------
-- Table structure for sysmenufunction
-- ----------------------------
DROP TABLE IF EXISTS `sysmenufunction`;
CREATE TABLE `sysmenufunction`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `MenuId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FunctionId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysmenufunction
-- ----------------------------
INSERT INTO `sysmenufunction` VALUES ('060d14f9-e066-44b9-d6b3-08d8b9f5533b', '63a6d076-3e22-4d26-85b4-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-16 16:07:24');
INSERT INTO `sysmenufunction` VALUES ('0645a7de-51e6-4c8d-a4e3-f860edd22bf8', '0abfd53b-6bde-42c6-9f99-e32775bc31dd', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:57:27', '2021-05-28 12:57:27');
INSERT INTO `sysmenufunction` VALUES ('0943b658-9fe1-4c9b-b583-6899cc364605', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-28 12:51:15', '2021-05-28 12:51:15');
INSERT INTO `sysmenufunction` VALUES ('09a29222-8f8d-4ca6-9bd1-aeddbabe7d7b', '2dc579dc-2325-4063-b051-e92454ee3838', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('0a4acc41-95d6-4cbc-a3ca-269e0a4061eb', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-28 12:44:36', '2021-05-28 12:44:36');
INSERT INTO `sysmenufunction` VALUES ('0e354fd7-690b-4d22-a9db-e5025e353bfe', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-28 12:58:22', '2021-05-28 12:58:22');
INSERT INTO `sysmenufunction` VALUES ('0f03b724-798b-4aa0-bd30-e4accacdd123', 'd29fde94-0d6a-4a64-8446-55ee63df5885', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-28 12:56:56', '2021-05-28 12:56:56');
INSERT INTO `sysmenufunction` VALUES ('101baf28-dbfa-41e8-aca3-b136e02aee8b', 'd721fc55-2174-40eb-bb37-5c54a158525a', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-28 12:49:53', '2021-05-28 12:49:53');
INSERT INTO `sysmenufunction` VALUES ('11d28148-61da-4f49-8376-08d8bb7cd668', '38fd48a9-4035-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-18 14:54:30');
INSERT INTO `sysmenufunction` VALUES ('179c8b22-efdd-475c-aa78-1b939ff05876', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-28 12:51:15', '2021-05-28 12:51:15');
INSERT INTO `sysmenufunction` VALUES ('1a727d75-867e-4292-9024-f66a292b465f', '60ae9382-31ab-4276-a379-d3876e9bb783', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-28 12:45:16', '2021-05-28 12:45:16');
INSERT INTO `sysmenufunction` VALUES ('1b4203a4-9fc4-42f8-9122-f1b3cde687e9', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-28 12:44:36', '2021-05-28 12:44:36');
INSERT INTO `sysmenufunction` VALUES ('1f02b56d-d844-45a1-bf68-0500d19f0c95', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:51:15', '2021-05-28 12:51:15');
INSERT INTO `sysmenufunction` VALUES ('23b4af49-6a18-471d-9f09-88296c234619', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-28 12:49:53', '2021-05-28 12:49:53');
INSERT INTO `sysmenufunction` VALUES ('25cfd1d0-04c4-4b2c-b534-7f3c8c0eb06d', '60ae9382-31ab-4276-a379-d3876e9bb783', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:45:16', '2021-05-28 12:45:16');
INSERT INTO `sysmenufunction` VALUES ('2cf7a5e1-a38e-45d6-949e-e8bb65f60a5c', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-28 12:44:36', '2021-05-28 12:44:36');
INSERT INTO `sysmenufunction` VALUES ('30b4b575-4881-41ea-ae33-27bfa151e423', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-28 12:58:22', '2021-05-28 12:58:22');
INSERT INTO `sysmenufunction` VALUES ('3315859e-bad8-42a6-a9fc-7deaeb5f6b79', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'b6fd5425-504a-46a9-993b-2f8dc9158eb8', '2021-05-28 12:49:53', '2021-05-28 12:49:53');
INSERT INTO `sysmenufunction` VALUES ('393ccaa5-973a-4efd-9a70-5da170be1e0d', '0abfd53b-6bde-42c6-9f99-e32775bc31dd', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-28 12:57:27', '2021-05-28 12:57:27');
INSERT INTO `sysmenufunction` VALUES ('44dd215e-1edf-45aa-b6c6-4910ed14a228', 'b73c82f9-54ea-4f02-b7d9-fc3976becb19', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('4c74ee6a-dcba-4192-b976-4e8fcf33a061', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:49:53', '2021-05-28 12:49:53');
INSERT INTO `sysmenufunction` VALUES ('4f40ce17-c29c-4448-9d1d-46aab970789a', '60ae9382-31ab-4276-a379-d3876e9bb783', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-28 12:45:16', '2021-05-28 12:45:16');
INSERT INTO `sysmenufunction` VALUES ('4f666139-2c4a-400b-bd35-b67b8aa1fe7d', 'bd024f3a-99a7-4407-861c-a016f243f222', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:53:04', '2021-05-28 12:53:04');
INSERT INTO `sysmenufunction` VALUES ('511ef9d4-d4b6-4053-9b37-121f06b726c7', 'd721fc55-2174-40eb-bb37-5c54a158525a', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-28 12:49:53', '2021-05-28 12:49:53');
INSERT INTO `sysmenufunction` VALUES ('546cc6af-bfa3-4b61-8fa8-85713e38bc60', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-28 12:49:53', '2021-05-28 12:49:53');
INSERT INTO `sysmenufunction` VALUES ('5689b539-88db-49d2-8c5b-720e9ebc673e', '74b837ae-d24f-4f57-b107-e20dbe70f5d3', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('5a0ea751-0c50-482a-be15-afedb9faae64', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'b6fd5425-504a-46a9-993b-2f8dc9158eb8', '2021-05-28 12:58:22', '2021-05-28 12:58:22');
INSERT INTO `sysmenufunction` VALUES ('5b21d63c-6611-4b39-9c26-1510118969b2', '0b7f8e2c-9faa-4496-9068-80b87ba1b64e', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('774fe6ff-3ecc-40b0-a8a3-159cd2492fe2', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-28 12:51:15', '2021-05-28 12:51:15');
INSERT INTO `sysmenufunction` VALUES ('7861b618-0b12-4a56-abda-a5e8d17ac5d7', '2ff9bb67-aa42-48cf-80c9-6d1cfb6b1ead', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('7e466377-1810-4027-ae1b-227f53953b21', '74b837ae-d24f-4f57-b107-e20dbe70f5d3', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('7ec9b0fa-54ee-498e-a69b-8f689d019611', '60ae9382-31ab-4276-a379-d3876e9bb783', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-28 12:45:16', '2021-05-28 12:45:16');
INSERT INTO `sysmenufunction` VALUES ('81a43621-60cf-4f04-9279-13480d37e6a4', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'b6fd5425-504a-46a9-993b-2f8dc9158eb8', '2021-05-28 12:51:15', '2021-05-28 12:51:15');
INSERT INTO `sysmenufunction` VALUES ('869a2231-5631-4067-b97b-08d88a2ced15', '4ce21a81-1cae-44d2-b29e-07058ff04b3e', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2020-11-16 20:41:23');
INSERT INTO `sysmenufunction` VALUES ('86d6303f-463e-4874-843e-a8a76ebe50d8', 'd29fde94-0d6a-4a64-8446-55ee63df5885', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-28 12:56:56', '2021-05-28 12:56:56');
INSERT INTO `sysmenufunction` VALUES ('8a691543-93a0-4e57-8411-c4723ecf5627', 'f35d64ae-ecb7-4d06-acfb-d91595966d9e', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:55:04', '2021-05-28 12:55:04');
INSERT INTO `sysmenufunction` VALUES ('8aaa6319-d36a-4fcd-8797-19d97a077e1b', '74b837ae-d24f-4f57-b107-e20dbe70f5d3', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('8c85e128-83ad-4079-8754-ac5679b04df6', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:44:36', '2021-05-28 12:44:36');
INSERT INTO `sysmenufunction` VALUES ('92bd3806-c5b3-41fe-b6f9-c6fd7a9dd77e', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-28 12:58:22', '2021-05-28 12:58:22');
INSERT INTO `sysmenufunction` VALUES ('93e91f91-3560-460d-9eea-760fa2b2fb66', 'd29fde94-0d6a-4a64-8446-55ee63df5885', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-28 12:56:56', '2021-05-28 12:56:56');
INSERT INTO `sysmenufunction` VALUES ('944f5d6a-19dc-4804-8374-08d8bb7cd668', 'd788896b-4033-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-18 14:46:52');
INSERT INTO `sysmenufunction` VALUES ('96581bb8-5f2d-460f-8cc2-a44247e791a7', 'd29fde94-0d6a-4a64-8446-55ee63df5885', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-28 12:56:56', '2021-05-28 12:56:56');
INSERT INTO `sysmenufunction` VALUES ('983ca076-0761-48bf-85e3-18bb24685a09', '60ae9382-31ab-4276-a379-d3876e9bb783', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-28 12:45:16', '2021-05-28 12:45:16');
INSERT INTO `sysmenufunction` VALUES ('9d63d074-85e7-48bd-8375-08d8bb7cd668', '35dc130e-4034-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-18 14:46:55');
INSERT INTO `sysmenufunction` VALUES ('a3074d55-141e-496e-a55c-93b5fd2dce6c', '74b837ae-d24f-4f57-b107-e20dbe70f5d3', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('a96cc666-927d-4d27-8174-9c321f41236d', 'd721fc55-2174-40eb-bb37-5c54a158525a', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-28 12:49:53', '2021-05-28 12:49:53');
INSERT INTO `sysmenufunction` VALUES ('b010f911-257e-4fa3-5b15-08d8ba019738', '9674d439-864e-4bf8-9dd8-08d7d70ad6bb', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-16 17:32:07');
INSERT INTO `sysmenufunction` VALUES ('b1b627c4-ac62-4dac-b4cc-c71392040543', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-28 12:51:15', '2021-05-28 12:51:15');
INSERT INTO `sysmenufunction` VALUES ('b2dd663b-67f3-478b-b8aa-cbe52480e133', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-28 12:51:15', '2021-05-28 12:51:15');
INSERT INTO `sysmenufunction` VALUES ('b43d31a9-b7a5-49ab-876c-2556745a9913', '0abfd53b-6bde-42c6-9f99-e32775bc31dd', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-28 12:57:27', '2021-05-28 12:57:27');
INSERT INTO `sysmenufunction` VALUES ('b8aa1a54-9076-4c72-a323-7b3b95ab26f4', '74b837ae-d24f-4f57-b107-e20dbe70f5d3', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('bb14769d-4760-4341-9faf-9fa82eeada65', '2ff9bb67-aa42-48cf-80c9-6d1cfb6b1ead', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-04-18 22:08:06', '2020-11-16 13:24:04');
INSERT INTO `sysmenufunction` VALUES ('bd144568-a24e-4f7e-d6b2-08d8b9f5533b', '15455a8d-262d-4266-85b3-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-16 16:06:33');
INSERT INTO `sysmenufunction` VALUES ('bec7a649-ed53-4471-bfd7-57978d397dae', '9a27dfc2-4a66-11eb-87b1-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:56:14', '2021-05-28 12:56:14');
INSERT INTO `sysmenufunction` VALUES ('c2207f27-9caa-44f7-a31f-0b757b973e23', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-28 12:44:36', '2021-05-28 12:44:36');
INSERT INTO `sysmenufunction` VALUES ('c4bfe58e-1cb8-49db-a942-919d46f79be9', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-28 12:51:15', '2021-05-28 12:51:15');
INSERT INTO `sysmenufunction` VALUES ('c4c16cef-501e-425d-88db-20bfcbaf461d', '0abfd53b-6bde-42c6-9f99-e32775bc31dd', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-28 12:57:27', '2021-05-28 12:57:27');
INSERT INTO `sysmenufunction` VALUES ('c6e873fc-a228-4418-b4ac-afc45a612af7', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-28 12:58:22', '2021-05-28 12:58:22');
INSERT INTO `sysmenufunction` VALUES ('c6eb3b9b-8ceb-4aee-8a3f-0755ffaed9d4', '0abfd53b-6bde-42c6-9f99-e32775bc31dd', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-28 12:57:27', '2021-05-28 12:57:27');
INSERT INTO `sysmenufunction` VALUES ('c6faf480-7b10-4cd1-abb5-69e0e4ae2b85', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-28 12:58:22', '2021-05-28 12:58:22');
INSERT INTO `sysmenufunction` VALUES ('c848edb2-00b3-4f67-9362-72d3a2eea88b', '60ae9382-31ab-4276-a379-d3876e9bb783', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-28 12:45:16', '2021-05-28 12:45:16');
INSERT INTO `sysmenufunction` VALUES ('cf317057-34fb-4a07-91c6-86a3cbc541fa', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-28 12:49:53', '2021-05-28 12:49:53');
INSERT INTO `sysmenufunction` VALUES ('d455b476-834c-4ef2-91ae-24f60559e029', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-28 12:58:22', '2021-05-28 12:58:22');
INSERT INTO `sysmenufunction` VALUES ('da4e3d9f-4e27-41af-8dd7-a682c70176c5', 'd29fde94-0d6a-4a64-8446-55ee63df5885', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-28 12:56:56', '2021-05-28 12:56:56');
INSERT INTO `sysmenufunction` VALUES ('dbcb960d-c4cd-4d27-b1aa-e5aae91b727d', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:58:22', '2021-05-28 12:58:22');
INSERT INTO `sysmenufunction` VALUES ('dd7ac46b-9420-450e-bdc2-9110b0056975', '0abfd53b-6bde-42c6-9f99-e32775bc31dd', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-28 12:57:27', '2021-05-28 12:57:27');
INSERT INTO `sysmenufunction` VALUES ('de9fa7c5-2c58-414f-8186-b68036044ed7', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-28 12:44:36', '2021-05-28 12:44:36');
INSERT INTO `sysmenufunction` VALUES ('e01f16a4-04c2-41de-9c20-be1747cf31af', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-28 12:44:36', '2021-05-28 12:44:36');
INSERT INTO `sysmenufunction` VALUES ('e136ccda-91ce-4041-d6b4-08d8b9f5533b', '9b01f9f3-5621-4bc2-85b5-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-16 16:10:06');
INSERT INTO `sysmenufunction` VALUES ('e28e11cd-27c5-475d-d6b1-08d8b9f5533b', 'f55a8858-ede4-4380-85b2-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-16 16:05:46');
INSERT INTO `sysmenufunction` VALUES ('ed0eaf25-aaff-4e8b-9a85-f173603510ef', '60ae9382-31ab-4276-a379-d3876e9bb783', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-28 12:45:16', '2021-05-28 12:45:16');
INSERT INTO `sysmenufunction` VALUES ('f0eef5bb-f327-4db7-af6c-c80bfb25389d', 'd29fde94-0d6a-4a64-8446-55ee63df5885', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-28 12:56:56', '2021-05-28 12:56:56');
INSERT INTO `sysmenufunction` VALUES ('f38d6e67-3f6f-495d-b759-08d8bba503c2', 'cc99f568-a831-4ea8-4c7a-08d8bba503bf', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2021-01-18 19:34:54');

-- ----------------------------
-- Table structure for sysoperationlog
-- ----------------------------
DROP TABLE IF EXISTS `sysoperationlog`;
CREATE TABLE `sysoperationlog`  (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Api` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '接口地址',
  `Ip` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT 'ip地址',
  `Form` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '表单信息',
  `FormBody` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT 'json表单信息',
  `QueryString` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '地址栏信息',
  `Browser` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `OS` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `UserId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '当前操作人id',
  `TakeUpTime` bigint(0) NOT NULL COMMENT '接口耗时（毫秒）',
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sysoperationlog
-- ----------------------------
INSERT INTO `sysoperationlog` VALUES ('08D957DB-FCDC-45AF-8599-A3C96CA2E2C1', '/api/admin/SysOperationLog/deleteAllData', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 297, '2021-08-05 14:41:00', '2021-08-05 14:41:00');
INSERT INTO `sysoperationlog` VALUES ('08D957DB-FDF0-4729-835F-1E455C7F403B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 162, '2021-08-05 14:41:02', '2021-08-05 14:41:02');
INSERT INTO `sysoperationlog` VALUES ('08D957DC-2E0A-43F6-8B68-3C8119DF478B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 164, '2021-08-05 14:42:23', '2021-08-05 14:42:23');
INSERT INTO `sysoperationlog` VALUES ('08D957DC-8969-4706-85A3-D796EFB5F5B4', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1195, '2021-08-05 14:44:56', '2021-08-05 14:44:56');
INSERT INTO `sysoperationlog` VALUES ('08D957DC-89E0-4CDC-8539-0E2D7071FA2B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 167, '2021-08-05 14:44:57', '2021-08-05 14:44:57');
INSERT INTO `sysoperationlog` VALUES ('08D957DD-69C4-4A2D-8C73-F0AC4E0838CC', '/api/admin/SysUser/sysOrganizationTree', '0.0.0.1', '', '{}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1124, '2021-08-05 14:51:12', '2021-08-05 14:51:12');
INSERT INTO `sysoperationlog` VALUES ('08D957DD-6A40-49E6-8638-53C4BEC566D8', '/api/admin/SysUser/findList/10/1', '0.0.0.1', '', '{\"name\":null,\"loginName\":null,\"organizationId\":\"f23777dd-2c03-449f-953b-df91c19dee5b\"}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 213, '2021-08-05 14:51:13', '2021-08-05 14:51:13');
INSERT INTO `sysoperationlog` VALUES ('08D957DD-6FBE-42CA-8167-4C80B741E12B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 141, '2021-08-05 14:51:22', '2021-08-05 14:51:22');
INSERT INTO `sysoperationlog` VALUES ('08D957DD-7691-4C3F-85F8-9A5B70DCD7FF', '/api/admin/SysRole/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 166, '2021-08-05 14:51:34', '2021-08-05 14:51:34');
INSERT INTO `sysoperationlog` VALUES ('08D957DD-7957-4B75-8D2D-87AD3CF88579', '/api/admin/SysFunction/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 153, '2021-08-05 14:51:38', '2021-08-05 14:51:38');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-47CE-4D08-8503-916C15C71037', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1189, '2021-08-05 14:57:25', '2021-08-05 14:57:25');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-4848-44A5-8159-5CFFFC8D0E7E', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 159, '2021-08-05 14:57:26', '2021-08-05 14:57:26');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-4F8D-42B3-8287-E5712687E62E', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1143, '2021-08-05 14:57:38', '2021-08-05 14:57:38');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-5000-460C-8867-68D957754CB7', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 157, '2021-08-05 14:57:39', '2021-08-05 14:57:39');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-5FD7-4FB7-8607-CDF4A2D7C0AD', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1144, '2021-08-05 14:58:05', '2021-08-05 14:58:05');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-6069-40C7-8BB2-E679CE34B6E2', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 155, '2021-08-05 14:58:06', '2021-08-05 14:58:06');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-88A4-4EFE-83BD-A41001C3A71E', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1495, '2021-08-05 14:59:14', '2021-08-05 14:59:14');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-8DF7-4D9A-826C-3DF52F346257', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1061, '2021-08-05 14:59:23', '2021-08-05 14:59:23');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-904A-4D39-8B86-DDFE10789C89', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 227, '2021-08-05 14:59:26', '2021-08-05 14:59:26');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-A903-463B-8B5A-0FC5DA820188', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 153, '2021-08-05 15:00:08', '2021-08-05 15:00:08');
INSERT INTO `sysoperationlog` VALUES ('08D957DE-ACFF-44ED-88D8-8D9685071822', '/api/admin/SysOperationLog/findForm/08d957de-904a-4d39-8b86-ddfe10789c89', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 87, '2021-08-05 15:00:15', '2021-08-05 15:00:15');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-AAD6-446E-8395-090A3D7624A2', '/api/admin/SysOperationLog/findForm/08d957de-88a4-4efe-83bd-a41001c3a71e', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 80, '2021-08-05 15:07:21', '2021-08-05 15:07:21');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-ABFD-4635-8E60-23360A71BD78', '/api/admin/SysOperationLog/findForm/08d957de-4f8d-42b3-8287-e5712687e62e', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 77, '2021-08-05 15:07:22', '2021-08-05 15:07:22');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-AD9E-4435-8422-885838F6CBEF', '/api/admin/SysOperationLog/findForm/08d957de-904a-4d39-8b86-ddfe10789c89', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 77, '2021-08-05 15:07:25', '2021-08-05 15:07:25');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-B356-458F-8CD5-5B0B6CDB94E5', '/api/admin/SysOperationLog/findForm/08d957de-8df7-4d9a-826c-3df52f346257', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 78, '2021-08-05 15:07:35', '2021-08-05 15:07:35');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-B609-48FA-8C25-7FD4DCA11D85', '/api/admin/SysOperationLog/findForm/08d957de-88a4-4efe-83bd-a41001c3a71e', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 79, '2021-08-05 15:07:39', '2021-08-05 15:07:39');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-B758-4F06-8B7B-8113F2800C62', '/api/admin/SysOperationLog/findForm/08d957de-5fd7-4fb7-8607-cdf4a2d7c0ad', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 81, '2021-08-05 15:07:42', '2021-08-05 15:07:42');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-B904-49BF-8EFF-91F80D9FDF81', '/api/admin/SysOperationLog/findForm/08d957de-4f8d-42b3-8287-e5712687e62e', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 77, '2021-08-05 15:07:44', '2021-08-05 15:07:44');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-BA8F-4DC6-809E-694A683C59B3', '/api/admin/SysOperationLog/findList/10/2', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 162, '2021-08-05 15:07:47', '2021-08-05 15:07:47');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-BB56-4103-8823-1F3F67FF443F', '/api/admin/SysOperationLog/findForm/08d957de-8df7-4d9a-826c-3df52f346257', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 78, '2021-08-05 15:07:48', '2021-08-05 15:07:48');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-FAA7-4A36-88AB-E9E835B5C7A9', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1124, '2021-08-05 15:09:34', '2021-08-05 15:09:34');
INSERT INTO `sysoperationlog` VALUES ('08D957DF-FB19-4127-8263-454F4DFF75CD', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 151, '2021-08-05 15:09:35', '2021-08-05 15:09:35');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-2E0E-4545-87D0-F93DCD7A8497', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1442, '2021-08-05 15:11:01', '2021-08-05 15:11:01');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-2E81-457B-84FE-DFECBDF280EE', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 151, '2021-08-05 15:11:01', '2021-08-05 15:11:01');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-3BB8-45BC-8D6A-C144C2BDC3F7', '/api/admin/SysOperationLog/findForm/08d957e0-2e0e-4545-87d0-f93dcd7a8497', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 87, '2021-08-05 15:11:24', '2021-08-05 15:11:24');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-61BE-4E15-84F7-DC0E44BD9D8A', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1125, '2021-08-05 15:12:27', '2021-08-05 15:12:27');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-6231-49F8-865A-4AC517DF035D', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 156, '2021-08-05 15:12:28', '2021-08-05 15:12:28');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-6351-4277-8B5F-D137421DA0CE', '/api/admin/SysOperationLog/findForm/08d957e0-61be-4e15-84f7-dc0e44bd9d8a', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 80, '2021-08-05 15:12:30', '2021-08-05 15:12:30');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-6D7D-40FE-814B-90773C5C0825', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1116, '2021-08-05 15:12:47', '2021-08-05 15:12:47');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-6DF1-4158-89D3-BDD8071D1E27', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 152, '2021-08-05 15:12:48', '2021-08-05 15:12:48');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-6EE0-4915-8979-115DF3808E03', '/api/admin/SysOperationLog/findForm/08d957e0-6d7d-40fe-814b-90773c5c0825', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 78, '2021-08-05 15:12:49', '2021-08-05 15:12:49');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-7860-43C7-8AA4-D803DC3B3E93', '/api/admin/SysOperationLog/findForm/08d957e0-2e0e-4545-87d0-f93dcd7a8497', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 81, '2021-08-05 15:13:05', '2021-08-05 15:13:05');
INSERT INTO `sysoperationlog` VALUES ('08D957E0-7A18-4D15-8C95-2AC731B2FDFD', '/api/admin/SysOperationLog/findForm/08d957df-faa7-4a36-88ab-e9e835b5c7a9', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 77, '2021-08-05 15:13:08', '2021-08-05 15:13:08');
INSERT INTO `sysoperationlog` VALUES ('08D957E1-8024-4A3E-8012-F64A474FE81E', '/api/admin/SysOperationLog/findForm/08d957e0-6d7d-40fe-814b-90773c5c0825', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 87, '2021-08-05 15:20:28', '2021-08-05 15:20:28');
INSERT INTO `sysoperationlog` VALUES ('08D957E1-8CBC-41EC-8E77-F094CB271D1E', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1564, '2021-08-05 15:20:49', '2021-08-05 15:20:49');
INSERT INTO `sysoperationlog` VALUES ('08D957E1-9145-4F76-8235-EDEC804EB63D', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1054, '2021-08-05 15:20:57', '2021-08-05 15:20:57');
INSERT INTO `sysoperationlog` VALUES ('08D957E1-93CC-4D1B-82C6-EA56868506E2', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 227, '2021-08-05 15:21:01', '2021-08-05 15:21:01');
INSERT INTO `sysoperationlog` VALUES ('08D957E1-948F-4705-83EB-D43E31AE7736', '/api/admin/SysOperationLog/findForm/08d957e1-9145-4f76-8235-edec804eb63d', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 88, '2021-08-05 15:21:02', '2021-08-05 15:21:02');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-9C3E-40E9-8AC9-C44F627EAB00', '/api/admin/SysOperationLog/findForm/08d957e0-6df1-4158-89d3-bdd8071d1e27', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 83, '2021-08-05 15:28:25', '2021-08-05 15:28:25');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-9FB2-40D1-85F6-F69AB39E2A8E', '/api/admin/SysRoleMenuFunction/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 190, '2021-08-05 15:28:30', '2021-08-05 15:28:30');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-A052-4DD4-8F15-A2631FFB21A6', '/api/admin/SysRoleMenuFunction/getRoleMenuFunctionTree/18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 431, '2021-08-05 15:28:31', '2021-08-05 15:28:31');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-A5F1-4CC9-8ECB-067323C4B4CC', '/api/admin/WorkOrders/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 275, '2021-08-05 15:28:41', '2021-08-05 15:28:41');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-A6D3-444B-881D-E360688FB157', '/api/admin/WorkOrders/findForm', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 359, '2021-08-05 15:28:42', '2021-08-05 15:28:42');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-AC4F-4552-8D3E-0CF16E5D74FE', '/api/admin/SysUser/sysOrganizationTree', '0.0.0.1', '', '{}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 972, '2021-08-05 15:28:51', '2021-08-05 15:28:51');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-ACB5-4D93-8DA6-FEDEF6750774', '/api/admin/SysUser/findList/10/1', '0.0.0.1', '', '{\"name\":null,\"loginName\":null,\"organizationId\":\"f23777dd-2c03-449f-953b-df91c19dee5b\"}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 207, '2021-08-05 15:28:52', '2021-08-05 15:28:52');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-B352-44A5-84D0-66C7BBD24421', '/api/admin/WorkOrders/saveForm', '0.0.0.1', '', '{\"title\":\"测试\",\"code\":null,\"locationId\":\"43fe2ed2-ce74-11eb-9351-00163e0a4e95\",\"equipmentName\":\"测试\",\"poolCode\":null,\"state\":0,\"stateDesc\":null,\"level\":2,\"causeLevelCode\":null,\"engineerId\":\"ac18f496-e93d-42f0-b59e-e321acc85335\",\"happenTime\":\"2021-08-13T07:28:54.960Z\",\"deadlineTime\":null,\"startTime\":null,\"endTime\":null,\"overDueTime\":null,\"durationMinute\":null,\"desc\":\"测试\",\"isExpatriate\":null,\"supplierId\":null,\"expatriateEngineer\":null,\"isEvaluate\":false,\"sourceType\":null,\"ccUserIds\":null,\"evaluateContent\":null,\"evaluateIntegral\":null,\"evaluateTime\":null,\"imgs\":\"/upload/files/20210805/time_152901_old_name_ff66f473-08da-47cc-8e10-458d5a27a538_1.jpg\",\"isDeleted\":false,\"deleteUserId\":null,\"deleteTime\":null,\"updateUserId\":null,\"updateTime\":null,\"createUserId\":null,\"createTime\":\"0001-01-01T00:00:00\",\"id\":\"00000000-0000-0000-0000-000000000000\",\"CauseLevelCode\":\"SG_MACHSTOP\"}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 403, '2021-08-05 15:29:03', '2021-08-05 15:29:03');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-B3B9-4195-86D0-24A4D4B93187', '/api/admin/WorkOrders/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 173, '2021-08-05 15:29:04', '2021-08-05 15:29:04');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-BC28-496D-8F6E-B081805A4529', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1154, '2021-08-05 15:29:18', '2021-08-05 15:29:18');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-BC9C-4A47-8368-BD1D2838AF3D', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 157, '2021-08-05 15:29:19', '2021-08-05 15:29:19');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-C0A9-4EF4-8CA9-444F8EBF6AA2', '/api/admin/SysOperationLog/findForm/08d957e2-b352-44a5-84d0-66c7bbd24421', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 77, '2021-08-05 15:29:26', '2021-08-05 15:29:26');
INSERT INTO `sysoperationlog` VALUES ('08D957E2-E405-4C19-8B2A-EED39983705C', '/api/admin/SysOperationLog/findForm/08d957e2-bc28-496d-8f6e-b081805a4529', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 81, '2021-08-05 15:30:25', '2021-08-05 15:30:25');
INSERT INTO `sysoperationlog` VALUES ('08D957E3-0313-434F-8580-156954611591', '/api/admin/SysOperationLog/findForm/08d957e2-acb5-4d93-8da6-fedef6750774', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 79, '2021-08-05 15:31:17', '2021-08-05 15:31:17');
INSERT INTO `sysoperationlog` VALUES ('08D957E3-0671-4BED-864B-CBECDEDF2B02', '/api/admin/SysOperationLog/findForm/08d957e2-ac4f-4552-8d3e-0cf16e5d74fe', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 83, '2021-08-05 15:31:23', '2021-08-05 15:31:23');
INSERT INTO `sysoperationlog` VALUES ('08D957E3-0B11-4340-83B1-4D18F8985D08', '/api/admin/SysOperationLog/findForm/08d957e2-b352-44a5-84d0-66c7bbd24421', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 79, '2021-08-05 15:31:30', '2021-08-05 15:31:30');
INSERT INTO `sysoperationlog` VALUES ('08D957E3-D383-428A-8EE9-9B3A1B303B51', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1594, '2021-08-05 15:37:07', '2021-08-05 15:37:07');
INSERT INTO `sysoperationlog` VALUES ('08D957E3-D991-45AF-82E5-2F983776FFD1', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1169, '2021-08-05 15:37:17', '2021-08-05 15:37:17');
INSERT INTO `sysoperationlog` VALUES ('08D957E3-DBAE-43C5-889A-41F3E397F83B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 231, '2021-08-05 15:37:20', '2021-08-05 15:37:20');
INSERT INTO `sysoperationlog` VALUES ('08D957E3-DC5E-412B-82F5-72FE125B522F', '/api/admin/SysOperationLog/findForm/08d957e3-d991-45af-82e5-2f983776ffd1', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 93, '2021-08-05 15:37:22', '2021-08-05 15:37:22');
INSERT INTO `sysoperationlog` VALUES ('08D957E4-5419-4412-88A2-09A3A0318A1F', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1119, '2021-08-05 15:40:42', '2021-08-05 15:40:42');
INSERT INTO `sysoperationlog` VALUES ('08D957E4-5497-4637-8590-F5E83020DE90', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 151, '2021-08-05 15:40:43', '2021-08-05 15:40:43');
INSERT INTO `sysoperationlog` VALUES ('08D957E4-5592-4794-8B35-9FFC651012ED', '/api/admin/SysOperationLog/findForm/08d957e4-5419-4412-88a2-09a3a0318a1f', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 76, '2021-08-05 15:40:45', '2021-08-05 15:40:45');
INSERT INTO `sysoperationlog` VALUES ('08D957E4-6040-4214-8955-10FF47CA2B2F', '/api/admin/SysOperationLog/findList/10/2', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 155, '2021-08-05 15:41:03', '2021-08-05 15:41:03');
INSERT INTO `sysoperationlog` VALUES ('08D957E4-6261-4FE1-8AF9-2AAE1B3CEF48', '/api/admin/SysOperationLog/findForm/08d957e2-b352-44a5-84d0-66c7bbd24421', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 76, '2021-08-05 15:41:06', '2021-08-05 15:41:06');
INSERT INTO `sysoperationlog` VALUES ('08D957E5-B8BB-4E7D-874A-ABB028404CD8', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1206, '2021-08-05 15:50:41', '2021-08-05 15:50:41');
INSERT INTO `sysoperationlog` VALUES ('08D957E5-B94C-45DE-8568-3F5F3277DFFD', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 150, '2021-08-05 15:50:42', '2021-08-05 15:50:42');
INSERT INTO `sysoperationlog` VALUES ('08D957E5-BAB4-4337-8755-C3B26DF8A981', '/api/admin/SysOperationLog/findForm/08d957e5-b8bb-4e7d-874a-abb028404cd8', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 79, '2021-08-05 15:50:44', '2021-08-05 15:50:44');
INSERT INTO `sysoperationlog` VALUES ('08D957E5-D160-4431-864F-4D00E29B2C88', '/api/admin/SysOperationLog/findForm/08d957e4-5419-4412-88a2-09a3a0318a1f', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 70, '2021-08-05 15:51:22', '2021-08-05 15:51:22');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-0E1E-4AC4-8CED-1B23D99C30D8', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1110, '2021-08-05 15:53:04', '2021-08-05 15:53:04');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-0E8E-46E9-85DD-105B5EAFE660', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 146, '2021-08-05 15:53:05', '2021-08-05 15:53:05');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-105E-4C62-8D44-AE7F63B69ED3', '/api/admin/SysOperationLog/findForm/08d957e5-b8bb-4e7d-874a-abb028404cd8', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 76, '2021-08-05 15:53:08', '2021-08-05 15:53:08');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-34E9-44A5-86BE-D554DB6379AB', '/api/admin/SysOperationLog/findForm/08d957e4-6261-4fe1-8af9-2aae1b3cef48', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 78, '2021-08-05 15:54:09', '2021-08-05 15:54:09');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-6AEC-4ADD-8F4D-0317D75DCAE1', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1070, '2021-08-05 15:55:40', '2021-08-05 15:55:40');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-6B78-4A1A-85A5-761619AFC1B2', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 206, '2021-08-05 15:55:41', '2021-08-05 15:55:41');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-6D46-46C7-8715-E525B0B2F28C', '/api/admin/SysOperationLog/findForm/08d957e5-d160-4431-864f-4d00e29b2c88', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 77, '2021-08-05 15:55:44', '2021-08-05 15:55:44');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-8A4D-4403-87D0-EBE536AEFAFD', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1113, '2021-08-05 15:56:32', '2021-08-05 15:56:32');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-8AC4-4033-885F-F1CD17D2FF60', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 147, '2021-08-05 15:56:33', '2021-08-05 15:56:33');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-8B7C-4DE6-8C60-1A96A376D292', '/api/admin/SysOperationLog/findForm/08d957e6-34e9-44a5-86be-d554db6379ab', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 67, '2021-08-05 15:56:34', '2021-08-05 15:56:34');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-A2E9-476A-801B-FBD930DE559A', '/api/admin/SysOperationLog/findForm/08d957e6-105e-4c62-8d44-ae7f63b69ed3', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 80, '2021-08-05 15:57:14', '2021-08-05 15:57:14');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-C3F4-4449-870B-C611C36AC9A0', '/api/admin/SysOperationLog/findForm/08d957e6-0e1e-4ac4-8ced-1b23d99c30d8', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 70, '2021-08-05 15:58:09', '2021-08-05 15:58:09');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-C618-4D47-8313-8769F18B20C7', '/api/admin/SysOperationLog/findForm/08d957e6-6d46-46c7-8715-e525b0b2f28c', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 78, '2021-08-05 15:58:13', '2021-08-05 15:58:13');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-CD0A-461F-808E-93B65CDE6131', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null,\"api\":\"save\"}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 171, '2021-08-05 15:58:24', '2021-08-05 15:58:24');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-CE77-40D1-8D78-814D901C0784', '/api/admin/SysOperationLog/findForm/08d957e2-b352-44a5-84d0-66c7bbd24421', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 71, '2021-08-05 15:58:27', '2021-08-05 15:58:27');
INSERT INTO `sysoperationlog` VALUES ('08D957E6-F12F-4CD7-828A-951B4287DFC3', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null,\"api\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 154, '2021-08-05 15:59:25', '2021-08-05 15:59:25');
INSERT INTO `sysoperationlog` VALUES ('08D957E7-3034-4192-86BE-8F600702D513', '/api/admin/SysOperationLog/findForm/08d957e6-ce77-40d1-8d78-814d901c0784', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 79, '2021-08-05 16:01:11', '2021-08-05 16:01:11');
INSERT INTO `sysoperationlog` VALUES ('08D957E7-3223-4064-8DA5-B1802EEF99A7', '/api/admin/SysOperationLog/findForm/08d957e6-c618-4d47-8313-8769f18b20c7', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 74, '2021-08-05 16:01:14', '2021-08-05 16:01:14');
INSERT INTO `sysoperationlog` VALUES ('08D957E7-6D7A-492C-8EB3-6F6CC2C8EABB', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1360, '2021-08-05 16:02:54', '2021-08-05 16:02:54');
INSERT INTO `sysoperationlog` VALUES ('08D957E7-7317-4565-85B3-5935C37CD0AA', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1222, '2021-08-05 16:03:03', '2021-08-05 16:03:03');
INSERT INTO `sysoperationlog` VALUES ('08D957E7-77E5-436D-8F01-69289C371F0E', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 229, '2021-08-05 16:03:11', '2021-08-05 16:03:11');
INSERT INTO `sysoperationlog` VALUES ('08D957E7-7932-4B64-869A-B8CD3B988F9A', '/api/admin/SysOperationLog/findForm/08d957e7-7317-4565-85b3-5935c37cd0aa', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 94, '2021-08-05 16:03:13', '2021-08-05 16:03:13');
INSERT INTO `sysoperationlog` VALUES ('08D957E7-B9BE-4A29-81D5-C78D21E14136', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1564, '2021-08-05 16:05:02', '2021-08-05 16:05:02');
INSERT INTO `sysoperationlog` VALUES ('08D957E7-BCC8-45B2-854C-9B5957028447', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1112, '2021-08-05 16:05:07', '2021-08-05 16:05:07');
INSERT INTO `sysoperationlog` VALUES ('08D957EB-B447-4908-816A-CCA6BE7FE94E', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1545, '2021-08-05 16:33:30', '2021-08-05 16:33:30');
INSERT INTO `sysoperationlog` VALUES ('08D957EC-38C1-4D12-8822-7939E2D1548A', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1415, '2021-08-05 16:37:13', '2021-08-05 16:37:13');
INSERT INTO `sysoperationlog` VALUES ('08D957EC-3D69-4D72-86D6-EFD9CBEAE398', '/api/admin/SysOrganization/findList/', '0.0.0.1', '', '{\"name\":null,\"state\":1,\"parentId\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 972, '2021-08-05 16:37:20', '2021-08-05 16:37:20');
INSERT INTO `sysoperationlog` VALUES ('08D957EC-40A6-42D2-8CA2-25975336F003', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1118, '2021-08-05 16:37:26', '2021-08-05 16:37:26');
INSERT INTO `sysoperationlog` VALUES ('08D957EC-41AA-48B5-84CA-F24D80C2045D', '/api/admin/SysOrganization/findList/', '0.0.0.1', '', '{\"name\":null,\"state\":1,\"parentId\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 926, '2021-08-05 16:37:28', '2021-08-05 16:37:28');
INSERT INTO `sysoperationlog` VALUES ('08D957EC-4223-4B12-829F-3679A925B1E1', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 237, '2021-08-05 16:37:28', '2021-08-05 16:37:28');
INSERT INTO `sysoperationlog` VALUES ('08D957EC-44A3-42FD-8F4D-5F216172030F', '/api/admin/SysOperationLog/findForm/08d957ec-41aa-48b5-84ca-f24d80c2045d', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 117, '2021-08-05 16:37:33', '2021-08-05 16:37:33');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-80C2-4FAD-8244-02B1BD4A2D71', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1402, '2021-08-05 16:46:23', '2021-08-05 16:46:23');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-B79E-4175-8A64-43832E740188', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1695, '2021-08-05 16:47:55', '2021-08-05 16:47:55');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-BFF4-4F29-8925-96352A706991', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1113, '2021-08-05 16:48:09', '2021-08-05 16:48:09');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-C1F3-427B-84B0-5C62D530144D', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 254, '2021-08-05 16:48:12', '2021-08-05 16:48:12');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-D27A-41CD-80D8-0463957C2B4A', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 163, '2021-08-05 16:48:40', '2021-08-05 16:48:40');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-D590-4ED4-8BB1-3D2998564B2B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 177, '2021-08-05 16:48:45', '2021-08-05 16:48:45');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-D964-4E9D-869E-CB035B20FC5B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 152, '2021-08-05 16:48:52', '2021-08-05 16:48:52');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-E5B1-4905-843A-53CB358FD2D2', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 161, '2021-08-05 16:49:12', '2021-08-05 16:49:12');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-E94F-447E-818B-073E3198E815', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 157, '2021-08-05 16:49:18', '2021-08-05 16:49:18');
INSERT INTO `sysoperationlog` VALUES ('08D957ED-EEDF-4577-86A8-BE6B112DD48B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 157, '2021-08-05 16:49:28', '2021-08-05 16:49:28');
INSERT INTO `sysoperationlog` VALUES ('08D957EE-049B-4952-80C1-639A04D0E538', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 173, '2021-08-05 16:50:04', '2021-08-05 16:50:04');
INSERT INTO `sysoperationlog` VALUES ('08D957EE-0E73-4EF8-866B-7197F9F29444', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 169, '2021-08-05 16:50:21', '2021-08-05 16:50:21');
INSERT INTO `sysoperationlog` VALUES ('08D957EE-1814-4752-8024-3453D801A5AD', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 164, '2021-08-05 16:50:37', '2021-08-05 16:50:37');
INSERT INTO `sysoperationlog` VALUES ('08D957EE-22CB-450B-83F9-F7CE2C5502F7', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 166, '2021-08-05 16:50:55', '2021-08-05 16:50:55');
INSERT INTO `sysoperationlog` VALUES ('08D957EE-27EF-46BF-83C1-BC8EA0249796', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 159, '2021-08-05 16:51:03', '2021-08-05 16:51:03');
INSERT INTO `sysoperationlog` VALUES ('08D957EE-2B52-4491-85B0-F770E56F54EA', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 155, '2021-08-05 16:51:09', '2021-08-05 16:51:09');
INSERT INTO `sysoperationlog` VALUES ('08D957EE-2C86-4526-8ED0-2994671AA14B', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Edge92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 158, '2021-08-05 16:51:11', '2021-08-05 16:51:11');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-92A2-45D3-87A5-100F94EF41B7', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1522, '2021-08-05 17:01:12', '2021-08-05 17:01:12');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-93F5-4BD0-838A-DDC042E81285', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 1049, '2021-08-05 17:01:14', '2021-08-05 17:01:14');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-963D-48BF-847D-3A66B4D13CD0', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 239, '2021-08-05 17:01:18', '2021-08-05 17:01:18');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-C90F-49C6-8A6E-3B26AC4F469C', '/api/admin/SysOperationLog/findForm/08d957ef-93f5-4bd0-838a-ddc042e81285', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 105, '2021-08-05 17:02:43', '2021-08-05 17:02:43');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-CAB1-47A6-8F76-EFE7C5AD234B', '/api/admin/SysOperationLog/findForm/08d957ee-27ef-46bf-83c1-bc8ea0249796', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 83, '2021-08-05 17:02:46', '2021-08-05 17:02:46');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-CD99-4785-805E-92096C1F8F68', '/api/admin/SysOperationLog/findList/10/13', '0.0.0.1', '', '{\"name\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 159, '2021-08-05 17:02:51', '2021-08-05 17:02:51');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-CFDE-4286-8CA0-9F2512BBA28E', '/api/admin/SysOperationLog/findForm/08d957dd-69c4-4a2d-8c73-f0ac4e0838cc', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 88, '2021-08-05 17:02:55', '2021-08-05 17:02:55');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-D233-40C4-8D9C-841B149EFE0F', '/api/admin/SysOperationLog/findForm/08d957db-fcdc-45af-8599-a3c96ca2e2c1', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 87, '2021-08-05 17:02:58', '2021-08-05 17:02:58');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-D3B7-45AE-8DA4-173846651868', '/api/admin/SysOperationLog/findList/10/9', '0.0.0.1', '', '{\"name\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 157, '2021-08-05 17:03:01', '2021-08-05 17:03:01');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-D7AD-4461-8A3C-E232D7556915', '/api/admin/SysOperationLog/findList/10/8', '0.0.0.1', '', '{\"name\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 156, '2021-08-05 17:03:08', '2021-08-05 17:03:08');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-DA09-4C8E-8088-59733827054C', '/api/admin/SysOperationLog/findList/10/6', '0.0.0.1', '', '{\"name\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 158, '2021-08-05 17:03:12', '2021-08-05 17:03:12');
INSERT INTO `sysoperationlog` VALUES ('08D957EF-DCD0-46E8-8F6C-461C0A260D28', '/api/admin/SysOperationLog/findList/10/1', '0.0.0.1', '', '{\"name\":null}', '', 'Chrome92', 'Windows10', '0198459E-2034-4533-B843-5D227AD20740', 159, '2021-08-05 17:03:16', '2021-08-05 17:03:16');
INSERT INTO `sysoperationlog` VALUES ('08d9581b-7675-4071-84a2-3abbfac4b426', '/api/admin/SysUser/info', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459e-2034-4533-b843-5d227ad20740', 346, '2021-08-05 22:15:22', '2021-08-05 22:15:22');
INSERT INTO `sysoperationlog` VALUES ('08d9581b-7918-49d9-8b68-cfaca9dd8e31', '/api/admin/SysDictionary/getDictionaryTree', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459e-2034-4533-b843-5d227ad20740', 117, '2021-08-05 22:15:27', '2021-08-05 22:15:27');
INSERT INTO `sysoperationlog` VALUES ('08d9581b-7935-4b47-844f-91c7219a8f0b', '/api/admin/SysDictionary/findList/10/1', '0.0.0.1', '', '{\"name\":null,\"parentId\":null}', '', 'Chrome92', 'Windows10', '0198459e-2034-4533-b843-5d227ad20740', 311, '2021-08-05 22:15:27', '2021-08-05 22:15:27');
INSERT INTO `sysoperationlog` VALUES ('08d9581b-7c26-46a7-8311-6330dcb8436b', '/api/admin/SysMenu/getMenusFunctionTree', '0.0.0.1', '', '', '', 'Chrome92', 'Windows10', '0198459e-2034-4533-b843-5d227ad20740', 120, '2021-08-05 22:15:32', '2021-08-05 22:15:32');
INSERT INTO `sysoperationlog` VALUES ('08d9581b-7c3a-4965-88bf-166d7be2bcf5', '/api/admin/SysMenu/findList/10/1', '0.0.0.1', '', '{\"name\":null,\"parentId\":null}', '', 'Chrome92', 'Windows10', '0198459e-2034-4533-b843-5d227ad20740', 116, '2021-08-05 22:15:32', '2021-08-05 22:15:32');
INSERT INTO `sysoperationlog` VALUES ('08d9581b-7d79-46c1-8d09-c37316502aa7', '/api/admin/SysMenu/findList/10/1', '0.0.0.1', '', '{\"name\":null,\"parentId\":\"9591f249-1471-44f7-86b5-6fdae8b93888\"}', '', 'Chrome92', 'Windows10', '0198459e-2034-4533-b843-5d227ad20740', 69, '2021-08-05 22:15:34', '2021-08-05 22:15:34');

-- ----------------------------
-- Table structure for sysorganization
-- ----------------------------
DROP TABLE IF EXISTS `sysorganization`;
CREATE TABLE `sysorganization`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `OrderNumber` int(0) NULL DEFAULT NULL,
  `Leader` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `State` int(0) NULL DEFAULT NULL,
  `ParentId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysorganization
-- ----------------------------
INSERT INTO `sysorganization` VALUES ('05e55b19-261a-4df8-aea0-83a56f1aeb7a', '市场部门', 2, '市场部门', '123213', '123@qq.com', 1, '47c547ea-e07a-4475-a4f7-ae09e3d8fafc', '2021-05-27 22:32:46', '2021-05-27 22:32:40');
INSERT INTO `sysorganization` VALUES ('1b001a4d-bce5-4e09-bc96-4e7da7686c48', '北京分部', 3, '北京分部', '132123', '13131', 1, 'f23777dd-2c03-449f-953b-df91c19dee5b', '2021-05-27 22:33:44', '2021-05-27 22:33:44');
INSERT INTO `sysorganization` VALUES ('47c547ea-e07a-4475-a4f7-ae09e3d8fafc', '成都分部', 2, '成都分部', '123123123', '123@qq.com', 1, 'f23777dd-2c03-449f-953b-df91c19dee5b', '2021-05-27 22:31:45', '2021-05-27 21:01:50');
INSERT INTO `sysorganization` VALUES ('6e36f7eb-3d03-417d-8815-c0e0f19ce6e6', '市场部门', 1, '市场部门', '234124234', '234234@qq.com', 1, '1b001a4d-bce5-4e09-bc96-4e7da7686c48', '2021-05-27 22:33:57', '2021-05-27 22:33:57');
INSERT INTO `sysorganization` VALUES ('9cf32211-f255-4c2e-9c53-4258755e43c5', '测试部门', 3, '测试部门', '12313', '123123@qq.com', 1, '47c547ea-e07a-4475-a4f7-ae09e3d8fafc', '2021-05-27 22:32:59', '2021-05-27 22:32:59');
INSERT INTO `sysorganization` VALUES ('a5e87436-53d5-4fff-8f2e-0af511db9ba4', '研发部门', 1, '研发部门', '1234323423', '12312@qq.com', 1, '47c547ea-e07a-4475-a4f7-ae09e3d8fafc', '2021-05-27 22:32:29', '2021-05-27 22:32:08');
INSERT INTO `sysorganization` VALUES ('aea25949-b0a0-49a3-9fbc-e80224b75fc1', '财务部门', 2, '财务部门', '435543535', '123@qq.com', 1, '1b001a4d-bce5-4e09-bc96-4e7da7686c48', '2021-05-27 22:34:11', '2021-05-27 22:34:11');
INSERT INTO `sysorganization` VALUES ('e898e8ad-2de7-46e0-b6f3-08f5fb9662ed', '财务部门', 4, '财务部门', '12323452345', '12312@qq.com', 1, '47c547ea-e07a-4475-a4f7-ae09e3d8fafc', '2021-05-27 22:33:13', '2021-05-27 22:33:13');
INSERT INTO `sysorganization` VALUES ('eb913607-932f-433b-8321-dfe35258bb88', '运维部门', 5, '运维部门', '1232133452', '12341@qq.com', 1, '47c547ea-e07a-4475-a4f7-ae09e3d8fafc', '2021-05-27 22:33:25', '2021-05-27 22:33:25');
INSERT INTO `sysorganization` VALUES ('f23777dd-2c03-449f-953b-df91c19dee5b', '阿里巴巴集团', 1, 'hzy', '18410912184', '18410912184@qq.com', 1, NULL, '2021-05-27 20:50:31', '2021-05-27 20:50:31');

-- ----------------------------
-- Table structure for syspost
-- ----------------------------
DROP TABLE IF EXISTS `syspost`;
CREATE TABLE `syspost`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Number` int(0) NULL DEFAULT NULL,
  `Code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `State` int(0) NULL DEFAULT NULL,
  `Remarks` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of syspost
-- ----------------------------
INSERT INTO `syspost` VALUES ('0716b4b0-9a06-43e9-8ae8-82c74875f83e', 2, 'se', '项目经理', 1, NULL, '2021-05-27 20:26:35', '2021-05-27 20:26:35');
INSERT INTO `syspost` VALUES ('96927c30-41d0-4ced-8e29-cbed35c90fb0', 1, 'ceo', '董事长', 1, NULL, '2021-05-27 20:26:22', '2021-05-27 20:26:22');
INSERT INTO `syspost` VALUES ('e46af329-6d08-442c-9837-f22cff954411', 4, 'user', '普通员工', 1, NULL, '2021-05-27 20:26:52', '2021-05-27 20:26:52');
INSERT INTO `syspost` VALUES ('f0c67537-8094-429a-b474-f54ac518609e', 3, 'hr', '人力资源', 1, NULL, '2021-05-27 20:26:44', '2021-05-27 20:26:44');

-- ----------------------------
-- Table structure for sysrole
-- ----------------------------
DROP TABLE IF EXISTS `sysrole`;
CREATE TABLE `sysrole`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Number` int(0) NULL DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsDelete` int(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysrole
-- ----------------------------
INSERT INTO `sysrole` VALUES ('18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 1, '超级管理员', '拥有所有权限', 0, '2021-01-10 11:25:12', '2016-07-06 17:59:20');
INSERT INTO `sysrole` VALUES ('40ff1844-c099-4061-98e0-cd6e544fcfd3', 2, '普通用户', '普通用户', 1, '2021-01-30 00:51:17', '2016-07-06 17:59:20');

-- ----------------------------
-- Table structure for sysrolemenufunction
-- ----------------------------
DROP TABLE IF EXISTS `sysrolemenufunction`;
CREATE TABLE `sysrolemenufunction`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `MenuId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FunctionId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysrolemenufunction
-- ----------------------------
INSERT INTO `sysrolemenufunction` VALUES ('052dd69b-c809-4f62-f107-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-12 20:25:54', '2021-05-12 20:25:54');
INSERT INTO `sysrolemenufunction` VALUES ('0920f21b-fbbf-45f4-f0c2-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '60ae9382-31ab-4276-a379-d3876e9bb783', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-12 20:25:46', '2021-05-12 20:25:46');
INSERT INTO `sysrolemenufunction` VALUES ('0946c554-84a7-4adb-f063-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '35dc130e-4034-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:27', '2021-05-12 20:25:27');
INSERT INTO `sysrolemenufunction` VALUES ('0be2633e-046d-40fa-98dc-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '38fd48a9-4035-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 14:58:38', '2021-01-19 14:58:38');
INSERT INTO `sysrolemenufunction` VALUES ('12ceef4d-03c0-45cc-98df-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', 'd788896b-4033-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 14:58:43', '2021-01-19 14:58:43');
INSERT INTO `sysrolemenufunction` VALUES ('1c082c5a-8383-443f-98e0-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '35dc130e-4034-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 14:58:44', '2021-01-19 14:58:44');
INSERT INTO `sysrolemenufunction` VALUES ('1e882fbe-fd88-407e-98dd-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '63a6d076-3e22-4d26-85b4-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 14:58:42', '2021-01-19 14:58:42');
INSERT INTO `sysrolemenufunction` VALUES ('26250c7d-b504-44cc-f0bf-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '60ae9382-31ab-4276-a379-d3876e9bb783', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:46', '2021-05-12 20:25:46');
INSERT INTO `sysrolemenufunction` VALUES ('2d23022c-df34-4847-f08e-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-12 20:25:38', '2021-05-12 20:25:38');
INSERT INTO `sysrolemenufunction` VALUES ('2f2f0c63-2e13-4137-98db-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', 'f55a8858-ede4-4380-85b2-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 14:58:36', '2021-01-19 14:58:36');
INSERT INTO `sysrolemenufunction` VALUES ('463acea8-60b0-4a59-7de7-08d8bb7c529a', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '60ae9382-31ab-4276-a379-d3876e9bb783', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-18 14:45:40', '2021-01-18 14:45:40');
INSERT INTO `sysrolemenufunction` VALUES ('4ca56fed-fc32-4456-f0e8-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-12 20:25:50', '2021-05-12 20:25:50');
INSERT INTO `sysrolemenufunction` VALUES ('541450f0-dbd3-4094-f0c3-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '60ae9382-31ab-4276-a379-d3876e9bb783', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-12 20:25:46', '2021-05-12 20:25:46');
INSERT INTO `sysrolemenufunction` VALUES ('57a97a6c-cc65-4ac6-f064-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'cc99f568-a831-4ea8-4c7a-08d8bba503bf', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:27', '2021-05-12 20:25:27');
INSERT INTO `sysrolemenufunction` VALUES ('5d470ae4-66a5-4cdf-f0e3-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-12 20:25:50', '2021-05-12 20:25:50');
INSERT INTO `sysrolemenufunction` VALUES ('5ee46cd1-b2a3-4bc2-f05f-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'f55a8858-ede4-4380-85b2-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:24', '2021-05-12 20:25:24');
INSERT INTO `sysrolemenufunction` VALUES ('623eaf4e-5263-4fb9-f0a7-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-12 20:25:42', '2021-05-12 20:25:42');
INSERT INTO `sysrolemenufunction` VALUES ('68ab8acc-4d11-4e66-f0e5-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd721fc55-2174-40eb-bb37-5c54a158525a', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-12 20:25:50', '2021-05-12 20:25:50');
INSERT INTO `sysrolemenufunction` VALUES ('6a3d6ac5-11c7-4592-98e4-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-01-19 15:12:04', '2021-01-19 15:12:04');
INSERT INTO `sysrolemenufunction` VALUES ('6c934fa6-eff0-42c7-f0c5-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '60ae9382-31ab-4276-a379-d3876e9bb783', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-12 20:25:46', '2021-05-12 20:25:46');
INSERT INTO `sysrolemenufunction` VALUES ('6dfa0985-81fa-4242-f06b-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'f35d64ae-ecb7-4d06-acfb-d91595966d9e', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:33', '2021-05-12 20:25:33');
INSERT INTO `sysrolemenufunction` VALUES ('704a78f1-5c00-4169-f10a-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'b6fd5425-504a-46a9-993b-2f8dc9158eb8', '2021-05-12 20:25:54', '2021-05-12 20:25:54');
INSERT INTO `sysrolemenufunction` VALUES ('754ad754-bbc4-47bc-f088-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:38', '2021-05-12 20:25:38');
INSERT INTO `sysrolemenufunction` VALUES ('7e74f26c-f63e-42f0-f0e4-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd721fc55-2174-40eb-bb37-5c54a158525a', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-12 20:25:50', '2021-05-12 20:25:50');
INSERT INTO `sysrolemenufunction` VALUES ('82eb14da-2b31-45d8-f0a5-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-12 20:25:42', '2021-05-12 20:25:42');
INSERT INTO `sysrolemenufunction` VALUES ('8e1ea93c-398c-4fe7-f0e6-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd721fc55-2174-40eb-bb37-5c54a158525a', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-12 20:25:50', '2021-05-12 20:25:50');
INSERT INTO `sysrolemenufunction` VALUES ('8e87c5cb-1c6e-481e-f0a6-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-12 20:25:42', '2021-05-12 20:25:42');
INSERT INTO `sysrolemenufunction` VALUES ('915ac7f5-4e1b-4d92-f06c-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '9a27dfc2-4a66-11eb-87b1-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:33', '2021-05-12 20:25:33');
INSERT INTO `sysrolemenufunction` VALUES ('92837e44-e8d2-48a2-f106-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-12 20:25:54', '2021-05-12 20:25:54');
INSERT INTO `sysrolemenufunction` VALUES ('92cec1e4-cc90-4c20-f08a-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-12 20:25:38', '2021-05-12 20:25:38');
INSERT INTO `sysrolemenufunction` VALUES ('93ce6573-523e-4e3c-3d63-08d88bc25510', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '0b7f8e2c-9faa-4496-9068-80b87ba1b64e', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-04-18 22:08:06', '2020-11-18 21:03:36');
INSERT INTO `sysrolemenufunction` VALUES ('97c80c3a-d00e-4788-f0e2-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-12 20:25:50', '2021-05-12 20:25:50');
INSERT INTO `sysrolemenufunction` VALUES ('9967c23d-9101-4543-f08d-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-12 20:25:38', '2021-05-12 20:25:38');
INSERT INTO `sysrolemenufunction` VALUES ('99e29596-75a0-4736-98e2-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '9a27dfc2-4a66-11eb-87b1-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 14:58:52', '2021-01-19 14:58:52');
INSERT INTO `sysrolemenufunction` VALUES ('9ac7bdfb-7398-4dc8-f0c4-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '60ae9382-31ab-4276-a379-d3876e9bb783', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-12 20:25:46', '2021-05-12 20:25:46');
INSERT INTO `sysrolemenufunction` VALUES ('9d35e600-ee44-479a-f061-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '9b01f9f3-5621-4bc2-85b5-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:25', '2021-05-12 20:25:25');
INSERT INTO `sysrolemenufunction` VALUES ('9f341e22-87c3-498a-f105-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-12 20:25:54', '2021-05-12 20:25:54');
INSERT INTO `sysrolemenufunction` VALUES ('a36d2f2e-56f4-4920-f108-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-12 20:25:54', '2021-05-12 20:25:54');
INSERT INTO `sysrolemenufunction` VALUES ('affc5760-c5bd-43fb-98e7-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-01-19 15:12:04', '2021-01-19 15:12:04');
INSERT INTO `sysrolemenufunction` VALUES ('b3ac009f-017b-4512-f0a9-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-12 20:25:42', '2021-05-12 20:25:42');
INSERT INTO `sysrolemenufunction` VALUES ('c0c76981-828b-435e-98e3-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 15:12:04', '2021-01-19 15:12:04');
INSERT INTO `sysrolemenufunction` VALUES ('c5abda7a-230d-469f-f104-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:54', '2021-05-12 20:25:54');
INSERT INTO `sysrolemenufunction` VALUES ('c5ad81cc-09ec-4007-f08b-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-05-12 20:25:38', '2021-05-12 20:25:38');
INSERT INTO `sysrolemenufunction` VALUES ('c636d222-58dc-410f-f089-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-12 20:25:38', '2021-05-12 20:25:38');
INSERT INTO `sysrolemenufunction` VALUES ('c9d1ed28-5f58-4c7e-f10b-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', 'f27ecb0a-197d-47b1-b243-59a8c71302bf', '2021-05-12 20:25:54', '2021-05-12 20:25:54');
INSERT INTO `sysrolemenufunction` VALUES ('cb043048-142d-464d-f0a4-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:42', '2021-05-12 20:25:42');
INSERT INTO `sysrolemenufunction` VALUES ('d5d321ce-28e6-4742-98e1-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', 'cc99f568-a831-4ea8-4c7a-08d8bba503bf', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 14:58:45', '2021-01-19 14:58:45');
INSERT INTO `sysrolemenufunction` VALUES ('d80e356e-0d71-411f-7de9-08d8bb7c529a', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '60ae9382-31ab-4276-a379-d3876e9bb783', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-01-18 14:45:40', '2021-01-18 14:45:40');
INSERT INTO `sysrolemenufunction` VALUES ('d92cc026-dfcf-49fe-f08f-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '7c34c2fd-98ed-4655-aa04-bb00b915a751', 'b6fd5425-504a-46a9-993b-2f8dc9158eb8', '2021-05-12 20:25:38', '2021-05-12 20:25:38');
INSERT INTO `sysrolemenufunction` VALUES ('de19371d-5fbe-4fc3-98de-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '9b01f9f3-5621-4bc2-85b5-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-01-19 14:58:42', '2021-01-19 14:58:42');
INSERT INTO `sysrolemenufunction` VALUES ('e02ef258-be98-4a5c-f0e1-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:50', '2021-05-12 20:25:50');
INSERT INTO `sysrolemenufunction` VALUES ('e08a05a7-c494-4e32-f0e7-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd721fc55-2174-40eb-bb37-5c54a158525a', 'b6fd5425-504a-46a9-993b-2f8dc9158eb8', '2021-05-12 20:25:50', '2021-05-12 20:25:50');
INSERT INTO `sysrolemenufunction` VALUES ('e18a8dad-716d-49cd-98e6-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-01-19 15:12:04', '2021-01-19 15:12:04');
INSERT INTO `sysrolemenufunction` VALUES ('e69fe992-e4a5-4ac9-f0c0-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '60ae9382-31ab-4276-a379-d3876e9bb783', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-05-12 20:25:46', '2021-05-12 20:25:46');
INSERT INTO `sysrolemenufunction` VALUES ('eb2ac2a6-36ac-4ee1-f05e-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '38fd48a9-4035-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:24', '2021-05-12 20:25:24');
INSERT INTO `sysrolemenufunction` VALUES ('ec8ed1ba-61c3-4219-f060-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '63a6d076-3e22-4d26-85b4-08d8b9f578ef', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:25', '2021-05-12 20:25:25');
INSERT INTO `sysrolemenufunction` VALUES ('ed97d135-4408-41cc-98e5-08d8bc47a2c8', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '9c388461-2704-4c5e-a729-72c17e9018e1', '2021-01-19 15:12:04', '2021-01-19 15:12:04');
INSERT INTO `sysrolemenufunction` VALUES ('eee9d884-a577-40d2-f06a-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'bd024f3a-99a7-4407-861c-a016f243f222', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:32', '2021-05-12 20:25:32');
INSERT INTO `sysrolemenufunction` VALUES ('f058d1c8-7633-4781-f08c-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '7c34c2fd-98ed-4655-aa04-bb00b915a751', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-12 20:25:38', '2021-05-12 20:25:38');
INSERT INTO `sysrolemenufunction` VALUES ('f1b431b3-d7ef-44ca-7de8-08d8bb7c529a', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '60ae9382-31ab-4276-a379-d3876e9bb783', 'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', '2021-01-18 14:45:40', '2021-01-18 14:45:40');
INSERT INTO `sysrolemenufunction` VALUES ('f2891613-0a65-4c93-f0aa-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-12 20:25:42', '2021-05-12 20:25:42');
INSERT INTO `sysrolemenufunction` VALUES ('f65adc84-d2a4-4f91-f109-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'e5d4da6b-aab0-4aaa-982f-43673e8152c0', '2401f4d0-60b0-4e2e-903f-84c603373572', '2021-05-12 20:25:54', '2021-05-12 20:25:54');
INSERT INTO `sysrolemenufunction` VALUES ('fa279e29-f44f-4424-f0c1-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '60ae9382-31ab-4276-a379-d3876e9bb783', 'e7ef2a05-8317-41c3-b588-99519fe88bf9', '2021-05-12 20:25:46', '2021-05-12 20:25:46');
INSERT INTO `sysrolemenufunction` VALUES ('fcccd730-d83e-47b1-f062-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', 'd788896b-4033-11eb-a2cb-4cedfb69a3e8', 'c9518758-b2e1-4f51-b517-5282e273889c', '2021-05-12 20:25:26', '2021-05-12 20:25:26');
INSERT INTO `sysrolemenufunction` VALUES ('ff047bdd-04f4-4597-f0a8-08d915410342', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', '383e7ee2-7690-46ac-9230-65155c84aa30', '2021-05-12 20:25:42', '2021-05-12 20:25:42');

-- ----------------------------
-- Table structure for sysuser
-- ----------------------------
DROP TABLE IF EXISTS `sysuser`;
CREATE TABLE `sysuser`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LoginName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `IsDelete` int(0) NULL DEFAULT NULL,
  `OrganizationId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysuser
-- ----------------------------
INSERT INTO `sysuser` VALUES ('0198459e-2034-4533-b843-5d227ad20740', '超级管理员', 'admin', '123456', '123123123', '1396510655@qq.com', 2, 'f23777dd-2c03-449f-953b-df91c19dee5b', '2021-05-24 10:52:53', '2017-04-06 19:55:53');
INSERT INTO `sysuser` VALUES ('ac18f496-e93d-42f0-b59e-e321acc85335', '用户', 'user', '123', '456456456', '18123456789@live.com', 1, 'f23777dd-2c03-449f-953b-df91c19dee5b', '2021-04-18 22:08:12', '2017-04-06 19:55:53');

-- ----------------------------
-- Table structure for sysuserpost
-- ----------------------------
DROP TABLE IF EXISTS `sysuserpost`;
CREATE TABLE `sysuserpost`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `PostId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysuserpost
-- ----------------------------
INSERT INTO `sysuserpost` VALUES ('091a2187-ced9-4226-aa22-41e4be863d3d', '0198459e-2034-4533-b843-5d227ad20740', '96927c30-41d0-4ced-8e29-cbed35c90fb0', '2021-07-23 23:14:08', '2021-07-23 23:14:08');
INSERT INTO `sysuserpost` VALUES ('8be16163-ce6b-4abb-908c-f343c6df5ecc', 'ac18f496-e93d-42f0-b59e-e321acc85335', '0716b4b0-9a06-43e9-8ae8-82c74875f83e', '2021-05-28 10:33:35', '2021-05-28 10:33:35');

-- ----------------------------
-- Table structure for sysuserrole
-- ----------------------------
DROP TABLE IF EXISTS `sysuserrole`;
CREATE TABLE `sysuserrole`  (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `RoleId` char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sysuserrole
-- ----------------------------
INSERT INTO `sysuserrole` VALUES ('9c6e49e7-fcf0-4372-b726-9d9d8b9a55e8', 'ac18f496-e93d-42f0-b59e-e321acc85335', '40ff1844-c099-4061-98e0-cd6e544fcfd3', '2021-05-28 10:33:35', '2021-05-28 10:33:35');
INSERT INTO `sysuserrole` VALUES ('a454f96e-4133-46bb-938e-d556c5f85c54', '0198459e-2034-4533-b843-5d227ad20740', '18fa4771-6f58-46a3-80d2-6f0f5e9972e3', '2021-07-23 23:14:08', '2021-07-23 23:14:08');

SET FOREIGN_KEY_CHECKS = 1;
