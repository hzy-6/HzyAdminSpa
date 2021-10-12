<template>
  <component :is="iconName" v-if="!!iconName" />
</template>
<script>
import { defineComponent } from "vue";
//程序中所有的 ant 图标 都需要在这个组件中 注册 且通过这个组件使用 图标
import {
  HomeOutlined,
  TableOutlined,
  AppstoreOutlined,
  PieChartOutlined,
  LayoutOutlined,
  PicRightOutlined,
  //layoutHeader
  MenuFoldOutlined,
  MenuUnfoldOutlined,
  UserOutlined,
  LogoutOutlined,
  FullscreenOutlined,
  FullscreenExitOutlined,
  ReloadOutlined,
  //curd
  PlusOutlined,
  DeleteOutlined,
  UpOutlined,
  DownOutlined,
  //home
  SettingOutlined,
  EditOutlined,
  EllipsisOutlined,
  ClockCircleOutlined,
  StarOutlined,
  EyeOutlined,
  BranchesOutlined,
  ArrowUpOutlined,
  //新增图标
  GoldOutlined,
  DesktopOutlined,
  LockOutlined,
  TeamOutlined,
  ControlOutlined,
  MenuOutlined,
  UserSwitchOutlined,
  FormOutlined,
  FileSearchOutlined,
  IdcardOutlined,
  ClusterOutlined,
  UsergroupAddOutlined,
  MoreOutlined,
  FileDoneOutlined,
  ContainerOutlined,
  RadarChartOutlined,
  //tab 选项卡
} from "@ant-design/icons-vue";

export default defineComponent({
  name: "appIcons",
  props: {
    iconName: String,
  },
  components: {
    HomeOutlined,
    TableOutlined,
    AppstoreOutlined,
    PieChartOutlined,
    LayoutOutlined,
    PicRightOutlined,
    //layoutHeader
    MenuFoldOutlined,
    MenuUnfoldOutlined,
    UserOutlined,
    LogoutOutlined,
    FullscreenOutlined,
    FullscreenExitOutlined,
    SettingOutlined,
    ReloadOutlined,
    //curd
    PlusOutlined,
    DeleteOutlined,
    UpOutlined,
    DownOutlined,
    //home
    EditOutlined,
    EllipsisOutlined,
    ClockCircleOutlined,
    StarOutlined,
    EyeOutlined,
    BranchesOutlined,
    ArrowUpOutlined,
    //新增图标
    GoldOutlined,
    DesktopOutlined,
    LockOutlined,
    TeamOutlined,
    ControlOutlined,
    MenuOutlined,
    UserSwitchOutlined,
    FormOutlined,
    FileSearchOutlined,
    IdcardOutlined,
    ClusterOutlined,
    UsergroupAddOutlined,
    MoreOutlined,
    FileDoneOutlined,
    ContainerOutlined,
    RadarChartOutlined,
  },
});
</script>
