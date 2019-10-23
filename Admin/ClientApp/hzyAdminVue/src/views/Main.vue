<template>
  <div class="main">
    <el-container class="main-container">
      <!--头部-->
      <el-header class="main-header">
        <div
          class="main-header-color"
          :class="headerSkinColor?headerSkinColor:'main-header-color-1'"
        >
          <div class="main-header-left">
            <ul>
              <el-tooltip class="item" effect="dark" content="菜单 收起/展开" placement="left">
                <li @click="changeSiderCollapsed">
                  <i :class="siderCollapsed?'el-icon-s-unfold':'el-icon-s-fold'"></i>
                </li>
              </el-tooltip>
              <el-tooltip class="item" effect="dark" content="Logo" placement="left">
                <li class="logo">HzyAdminElement</li>
              </el-tooltip>
            </ul>
          </div>
          <div class="main-header-right">
            <ul>
              <el-tooltip class="item" effect="dark" content="退出登录" placement="left">
                <li>
                  <el-dropdown @command="logout">
                    <span class="el-dropdown-link">
                      <i class="el-icon-s-custom el-icon--left"></i>
                      {{userName}}
                      <i
                        class="el-icon-arrow-down el-icon--right"
                      ></i>
                    </span>
                    <el-dropdown-menu slot="dropdown">
                      <el-dropdown-item command="logout" class="text-danger">
                        <i class="el-icon-switch-button"></i>退出登录
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </el-dropdown>
                </li>
              </el-tooltip>
              <el-tooltip class="item" effect="dark" content="美化" placement="left">
                <li @click="dialogVisibleSkin=!dialogVisibleSkin;">
                  <i class="el-icon-magic-stick"></i>
                </li>
              </el-tooltip>
              <el-tooltip class="item" effect="dark" content="放大/缩小" placement="left">
                <li @click="handleFullScreen">
                  <i class="iconfont" :class="fullscreen?'icon-suoxiao':'icon-quanping'"></i>
                </li>
              </el-tooltip>
              <el-tooltip class="item" effect="dark" content="选项卡右移动" placement="left">
                <li @click="tabsMove(1)">
                  <i class="el-icon-arrow-right"></i>
                </li>
              </el-tooltip>
              <el-tooltip class="item" effect="dark" content="选项卡操作" placement="left">
                <li>
                  <el-dropdown @command="handleTabsCommand">
                    <span class="el-dropdown-link">选项卡</span>
                    <el-dropdown-menu slot="dropdown">
                      <el-dropdown-item command="Other" class="text-danger">
                        <i class="el-icon-circle-close"></i>关闭其他
                      </el-dropdown-item>
                      <el-dropdown-item command="All" class="text-danger">
                        <i class="el-icon-circle-close"></i>关闭所有
                      </el-dropdown-item>
                    </el-dropdown-menu>
                  </el-dropdown>
                </li>
              </el-tooltip>
              <el-tooltip class="item" effect="dark" content="选项卡左移动" placement="left">
                <li @click="tabsMove(0)" title="选项卡左移动">
                  <i class="el-icon-arrow-left"></i>
                </li>
              </el-tooltip>
            </ul>
            <!-- 移动端头部退出 -->
            <ul class="main-login">
              <li @click="logout">
                <i class="el-icon-arrow-right"></i>
              </li>
            </ul>
          </div>
        </div>
      </el-header>
      <el-container>
        <!--菜单-->
        <el-aside
          class="main-aside"
          width
          :class="[(siderCollapsed?'main-aside-0':'main-aside-220'),menuSkin.parentBGColor]"
        >
          <!-- <el-menu
            :default-active="$route.name"
            class="main-menu"
            @open="handleOpen"
            @close="handleClose"
            :collapse="siderCollapsed"
            router
            :background-color="menuSkin.backgroundColor"
            :text-color="menuSkin.textColor"
            :active-text-color="menuSkin.activeTextColor"
          >
            
          </el-menu>-->
          <Menu
            :default-active="$route.name"
            :collapse="siderCollapsed"
            :background-color="menuSkin.backgroundColor"
            :text-color="menuSkin.textColor"
            :active-text-color="menuSkin.activeTextColor"
            :dataMenu="menus"
          />
        </el-aside>

        <!--content 内容-->
        <el-main class="main-main">
          <div class="main-tabs">
            <ul>
              <!-- <li v-for="(item,index) in 50" :key="index" v-bind:class="index==2?'active':''">
                <span>{{'我是菜单'+item}}</span>
                <template v-if="index>0">
                  <i class="el-icon-close"></i>
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
                  <i class="el-icon-close" @click.stop="removeTab(index)"></i>
                </template>
              </li>
            </ul>
          </div>
          <!--body 内容-->
          <div class="main-body">
            <!-- 选择性缓存 -->
            <transition name="page-toggle">
              <!-- <keep-alive :include="tabNameList" >
                <router-view />
              </keep-alive>-->
              <keep-alive>
                <router-view />
              </keep-alive>
            </transition>
          </div>
        </el-main>
      </el-container>
    </el-container>
    <!--弹框 皮肤修改-->
    <el-drawer
      :visible.sync="dialogVisibleSkin"
      direction="rtl"
      size="350px"
      :modalAppendToBody="true"
    >
      <div class="p-20">
        <div>
          <h4>头部颜色</h4>
          <div class="main-Skin">
            <div
              class="main-Skin-header-color-1"
              @click="setHeaderSkinColor('main-header-color-1')"
            ></div>
          </div>
          <div class="main-Skin">
            <div
              class="main-Skin-header-color-2"
              @click="setHeaderSkinColor('main-header-color-2')"
            ></div>
          </div>
          <div class="main-Skin">
            <div
              class="main-Skin-header-color-3"
              @click="setHeaderSkinColor('main-header-color-3')"
            ></div>
          </div>
        </div>
        <div>
          <h4>菜单颜色</h4>
          <div class="main-Skin">
            <div class="main-Skin-menu-color-1" @click="setMenuSkinColor(1)"></div>
          </div>
          <div class="main-Skin">
            <div class="main-Skin-menu-color-2" @click="setMenuSkinColor(2)"></div>
          </div>
        </div>
      </div>
    </el-drawer>
  </div>
</template>

<script>
//css
import "../css/main.scss";
//js
import adminTabs from "../js/tabs";
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
//components
import Menu from "../components/layout/Menu";
//逻辑
export default {
  name: "AdminMain",
  data() {
    return {
      fullscreen: false,
      dialogVisibleSkin: false
    };
  },
  computed: {
    ...mapState("app", {
      siderCollapsed: state => state.siderCollapsed,
      tabList: state => state.tabs.list,
      headerSkinColor: state => state.headerSkinColor,
      menuSkin: state => state.menuSkin,
      menus: state => state.menus,
      userName: state => state.userName //用户名称
    }),
    tabNameList() {
      let arr = [];
      for (let i = 0; i < this.tabList.length; i++) {
        arr.push(this.tabList[i].name);
      }
      console.log(arr);
      return arr;
    },
  },
  components: {
    Menu
  },
  mounted() {
    adminTabs.start();
    //
    if (this.$store.state.app.isMobile && !this.siderCollapsed) {
      this.changeSiderCollapsed(true);
    }
  },
  methods: {
    ...mapMutations("app", {
      //添加选项卡
      addOrCheckedTab: "addOrCheckedTab",
      //移除选项卡
      removeTab: "removeTab",
      //关闭其他选项卡
      closeOtherTab: "closeOtherTab",
      //关闭所有选项卡
      closeAllTab: "closeAllTab",
      //改变左侧菜单状态
      changeSiderCollapsed: "changeSiderCollapsed",
      //设置头部皮肤颜色
      setHeaderSkinColor: "setHeaderSkinColor",
      //设置菜单皮肤颜色
      setMenuSkinColor: "setMenuSkinColor"
    }),
    logout() {
      //退出登录
      this.$router.push("/Login");
    },
    //
    handleTabsCommand(tag) {
      console.log(tag);
      if (tag == "Other") {
        this.closeOtherTab();
      } else {
        this.closeAllTab();
      }
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
      // var _pathname = window.location.pathname;
      // if (_pathname === item.name) return;//判断路由不能重复加载
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
    }
  }
};
</script>
<style lang="scss">
.el-dropdown-link {
  height: 100%;
  display: block;
}
</style>