<template>
  <div class="main">
    <a-layout class="main-layout">
      <a-layout-header class="main-header">
        <div
          class="main-header-color"
          :class="headerSkinColor?headerSkinColor:'main-header-color-3'"
        >
          <div class="main-header-left">
            <ul>
              <li @click="changeSiderCollapsed">
                <a-icon :type="siderCollapsed?'menu-unfold':'menu-fold'" />
              </li>
              <li class="logo">HzyAdmin-Antd Vue单页版</li>
            </ul>
          </div>
          <div class="main-header-right">
            <ul>
              <li>
                <a-dropdown>
                  <span class="ant-dropdown-link" style="height:100%;display:block">
                    <a-icon type="meh" />&nbsp;管理员
                    <a-icon type="down" />
                  </span>
                  <a-menu slot="overlay">
                    <a-menu-item class="text-danger">
                      <div @click="logout">
                        <a-icon type="logout" />&nbsp;退出登录
                      </div>
                    </a-menu-item>
                  </a-menu>
                </a-dropdown>
              </li>
              <li title="美化" @click="dialogVisibleSkin=true">
                <a-icon type="skin" />
              </li>
              <li title="放大/缩小" @click="handleFullScreen">
                <a-icon :type="fullscreen?'fullscreen-exit':'fullscreen'" />
              </li>
              <li title="选项卡右移动" @click="tabsMove(1)">
                <a-icon type="right" />
              </li>
              <li>
                <a-dropdown>
                  <span class="ant-dropdown-link" style="height:100%;display:block;">选项卡</span>
                  <a-menu slot="overlay">
                    <a-menu-item class="text-danger">
                      <div @click="closeOtherTab">
                        <a-icon type="close" />&nbsp;关闭其他
                      </div>
                    </a-menu-item>
                    <a-menu-item class="text-danger">
                      <div @click="closeAllTab">
                        <a-icon type="close" />&nbsp;关闭所有
                      </div>
                    </a-menu-item>
                  </a-menu>
                </a-dropdown>
              </li>
              <li title="选项卡左移动" @click="tabsMove(0)">
                <a-icon type="left" />
              </li>
            </ul>
            <ul class="main-login">
              <li @click="logout">
                <a-icon type="logout" />
              </li>
            </ul>
          </div>
        </div>
      </a-layout-header>
      <a-layout class="main-container">
        <a-layout-sider
          class="main-aside"
          :theme="menuSkin?menuSkin:'dark'"
          :width="220"
          :class="[(siderCollapsed?'main-aside-0':'main-aside-220')]"
          :trigger="null"
          collapsible
          v-model="siderCollapsed"
        >
          <MenusCom
            :theme="menuSkin?menuSkin:'dark'"
            :inlineCollapsed="siderCollapsed"
            :dataMenu="menuList"
            :select="handleMenuSelete"
          />
          <!-- <a-menu
            mode="inline"
            :theme="menuSkin?menuSkin:'dark'"
            :defaultSelectedKeys="[$route.name]"
            :selectedKeys="[$route.name]"
            :inlineCollapsed="siderCollapsed"
            @select="handleMenuSelete"
          >
            <a-menu-item key="/Home">
              <a-icon type="home" />
              <span>主页</span>
            </a-menu-item>
            <a-sub-menu key="Sys">
              <span slot="title">
                <a-icon type="desktop" />
                <span>系统管理</span>
              </span>
              <a-menu-item key="/User">
                <span>用户管理</span>
              </a-menu-item>
              <a-menu-item key="2">
                <span>角色管理</span>
              </a-menu-item>
              <a-menu-item key="3">
                <span>功能管理</span>
              </a-menu-item>
              <a-menu-item key="4">
                <span>修改密码</span>
              </a-menu-item>
              <a-menu-item key="5">
                <span>修改密码</span>
              </a-menu-item>
              <a-menu-item key="6">
                <span>修改密码</span>
              </a-menu-item>
              <a-menu-item key="7">
                <span>修改密码</span>
              </a-menu-item>
              <a-menu-item key="8">
                <span>修改密码</span>
              </a-menu-item>
            </a-sub-menu>
            <a-sub-menu key="sub1">
              <span slot="title">
                <a-icon type="mail" />
                <span>Navigation One</span>
              </span>
              <a-menu-item key="5">Option 5</a-menu-item>
              <a-menu-item key="6">Option 6</a-menu-item>
              <a-menu-item key="7">Option 7</a-menu-item>
              <a-menu-item key="8">Option 8</a-menu-item>
            </a-sub-menu>
            <a-sub-menu key="sub2">
              <span slot="title">
                <a-icon type="appstore" />
                <span>Navigation Two</span>
              </span>
              <a-menu-item key="9">Option 9</a-menu-item>
              <a-menu-item key="10">Option 10</a-menu-item>
              <a-sub-menu key="sub3" title="Submenu">
                <a-menu-item key="11">Option 11</a-menu-item>
                <a-menu-item key="12">Option 12</a-menu-item>
              </a-sub-menu>
            </a-sub-menu>
          </a-menu> -->
        </a-layout-sider>
        <a-layout class="main-main">
          <div class="main-tabs">
            <ul>
              <!-- <li v-for="(item,index) in 50" :key="index" v-bind:class="index==2?'active':''">
                <span>{{'我是菜单'+item}}</span>
                <template v-if="index>0">
                  <a-icon type="close" />
                </template>
              </li>-->
              <li
                v-for="(item,index) in tabList"
                :key="index"
                v-bind:class="{active:item.active}"
                @click="triggerTab(item)"
              >
                <span>{{item.title}}</span>
                <template v-if="index>0">
                  <a-icon type="close" @click.stop="removeTab(index)" />
                </template>
              </li>
            </ul>
          </div>
          <a-layout-content class="main-body">
            <transition name="page-toggle">
              <keep-alive>
                <router-view />
              </keep-alive>
            </transition>
          </a-layout-content>
        </a-layout>
      </a-layout>
    </a-layout>
    <!-- 皮肤 -->
    <a-drawer
      placement="right"
      getContainer=".main"
      width="350"
      :closable="false"
      @close="dialogVisibleSkin=!dialogVisibleSkin"
      :visible="dialogVisibleSkin"
    >
      <div>
        <h3>头部颜色</h3>
        <div class="main-Skin">
          <div class="main-Skin-header-color-1" @click="setHeaderSkinColor('main-header-color-1')"></div>
        </div>
        <div class="main-Skin">
          <div class="main-Skin-header-color-2" @click="setHeaderSkinColor('main-header-color-2')"></div>
        </div>
        <div class="main-Skin">
          <div class="main-Skin-header-color-3" @click="setHeaderSkinColor('main-header-color-3')"></div>
        </div>
      </div>
      <div>
        <h3>菜单颜色</h3>
        <div class="main-Skin">
          <div class="main-Skin-menu-color-1" @click="setMenuSkinColor('light')"></div>
        </div>
        <div class="main-Skin">
          <div class="main-Skin-menu-color-2" @click="setMenuSkinColor('dark')"></div>
        </div>
      </div>
    </a-drawer>
  </div>
</template>

<script>
//css
import "../css/layout.less";
//js
import adminTabs from "../js/tabs";
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
//components
import MenusCom from "../components/layout/Menus";

export default {
  name: "Layout",
  data() {
    return {
      fullscreen: false,
      dialogVisibleSkin: false
    };
  },
  computed: {
    ...mapState("layout", {
      siderCollapsed: state => state.siderCollapsed,
      tabList: state => state.tabs.list,
      headerSkinColor: state => state.headerSkinColor,
      menuSkin: state => state.menuSkin,
      menuList: state => state.menuList
    })
  },
  components: {
    MenusCom
  },
  mounted() {
    this.setMenus();
    adminTabs.start();
    //页面加载 设置菜单选中状态
    //页面加载 设置菜单选中状态
    var _hash = window.location.hash;
    if (_hash !== "#/Home") {
      this.$router.push({ name: this.$route.name });
    }
    if (this.$store.state.app.isMobile && !this.siderCollapsed) {
      this.changeSiderCollapsed(true);
    }
  },
  methods: {
    handleMenuSelete(obj) {
      //菜单选中 事件
      console.log("obj", obj);
      var _hash = window.location.hash;
      if (_hash === "#" + obj.key) return; //判断路由不能重复加载
      this.$router.push({ name: obj.key });
    },
    logout() {
      //退出登录
      this.$router.push("/Login");
    },
    tabsMove(o) {
      if (o == 1) {
        adminTabs.leftMove();
      } else {
        adminTabs.rigthMove();
      }
    },
    //点击选项卡 路由到地址
    triggerTab(item) {
      var _hash = window.location.hash;
      if (_hash === "#" + item.name) return; //判断路由不能重复加载
      this.$router.push({ name: item.name });
    },
    // 全屏事件
    handleFullScreen() {
      let element = document.documentElement;
      if (this.fullscreen) {
        if (document.exitFullscreen) {
          document.exitFullscreen();
        } else if (document.webkitCancelFullScreen) {
          document.webkitCancelFullScreen();
        } else if (document.mozCancelFullScreen) {
          document.mozCancelFullScreen();
        } else if (document.msExitFullscreen) {
          document.msExitFullscreen();
        }
      } else {
        if (element.requestFullscreen) {
          element.requestFullscreen();
        } else if (element.webkitRequestFullScreen) {
          element.webkitRequestFullScreen();
        } else if (element.mozRequestFullScreen) {
          element.mozRequestFullScreen();
        } else if (element.msRequestFullscreen) {
          // IE11
          element.msRequestFullscreen();
        }
      }
      this.fullscreen = !this.fullscreen;
    },
    ...mapMutations("layout", {
      addOrCheckedTab: "addOrCheckedTab", //添加选项卡
      removeTab: "removeTab", //移除选项卡
      closeOtherTab: "closeOtherTab", //关闭其他选项卡
      closeAllTab: "closeAllTab", //关闭所有选项卡
      changeSiderCollapsed: "changeSiderCollapsed", //改变左侧菜单状态
      setHeaderSkinColor: "setHeaderSkinColor", //设置头部皮肤颜色
      setMenuSkinColor: "setMenuSkinColor", //设置菜单皮肤颜色
      setMenus:"setMenus"//设置菜单
    }),
    ...mapActions("layout", { postAuthorize: "postAuthorize" })
  }
};
</script>