<template>
  <a-layout-header style="padding: 0; height: 98px; background: #fff">
    <div class="hzy-layout-header" :class="headerTheme">
      <div class="hzy-header-btn" @click="onCollapsed">
        <AppIcons iconName="MenuUnfoldOutlined" v-if="collapsed" />
        <AppIcons iconName="MenuFoldOutlined" v-else />
      </div>
      <!-- <div class="hzy-header-btn logo" v-if="!isMobile">{{ title }}</div> -->
      <div style="flex: 1 1 0%">
        <a-menu
          v-model:selectedKeys="selectedKeys"
          mode="horizontal"
          @select="onMenuSelected"
          style="line-height: 57px"
          v-if="topNavValue"
        >
          <a-menu-item
            v-for="item in oneLevels"
            :key="
              item.jumpUrl
                ? item.jumpUrl
                : item.componentName
                ? item.componentName
                : item.id
            "
          >
            <AppIcons :iconName="item.icon" />
            <span class="title">{{ item.name }}</span>
          </a-menu-item>
        </a-menu>
      </div>
      <div class="hzy-header-btn" @click="onReload">
        <AppIcons iconName="ReloadOutlined" />
      </div>
      <div class="hzy-header-btn" @click="onSettings">
        <AppIcons iconName="SettingOutlined" />
      </div>
      <div class="hzy-header-btn" @click="onFullScreen" v-if="!isMobile">
        <AppIcons iconName="FullscreenExitOutlined" v-if="fullscreen" />
        <AppIcons iconName="FullscreenOutlined" v-else />
      </div>
      <div class="hzy-header-btn">
        <a-dropdown>
          <div>
            <AppIcons iconName="UserOutlined" />
            &nbsp;&nbsp;{{ userName ? userName : "HZY" }}
          </div>
          <template #overlay>
            <a-menu>
              <a-menu-item>
                <router-link to="/system/personal/center">
                  <AppIcons iconName="FormOutlined" />&nbsp;&nbsp;个人中心</router-link
                >
              </a-menu-item>
              <a-menu-item>
                <router-link to="/login">
                  <AppIcons iconName="LogoutOutlined" />&nbsp;&nbsp;退出登录
                </router-link>
              </a-menu-item>
            </a-menu>
          </template>
        </a-dropdown>
      </div>
    </div>
    <layoutTabs v-model:propTabs="tabs" />
  </a-layout-header>
</template>
<script>
import { computed, defineComponent, onMounted, reactive, toRefs, watch } from "vue";
import AppIcons from "@/components/appIcons.vue";
import layoutTabs from "./layoutTabs.vue";
//vuex
import { useStore } from "vuex";
import router from "@/router/index";
import screenfull from "screenfull";
import tools from "@/scripts/tools";

export default defineComponent({
  name: "layoutHeader",
  props: {
    propCollapsed: Boolean,
    propLayoutSettingsState: Boolean,
    propHeaderTheme: String,
  },
  components: {
    AppIcons,
    layoutTabs,
  },
  setup(props, context) {
    const fullPath = router.currentRoute.value.fullPath;
    const store = useStore();
    const title = computed(() => store.state.app.title);
    const userName = computed(() => store.state.app.userInfo.name);
    const menus = computed(() => store.state.app.userInfo.menus);
    const topMenuId = computed(() => store.getters["app/getTopMenuByLastId"]);
    const topNavValue = computed(() => store.state.app.topNav);
    const state = reactive({
      collapsed: props.propCollapsed,
      headerTheme: props.propHeaderTheme,
      fullscreen: false,
      layoutSettings: {
        state: props.propLayoutSettingsState,
      },
      screenWidth: 0,
      screenHeight: 0,
      isMobile: false,
      tabs: [],
      oneLevels: [],
      selectedKeys: [fullPath],
    });

    watch(
      () => props.propCollapsed,
      (value) => {
        state.collapsed = value;
      }
    );

    watch(
      () => props.propLayoutSettingsState,
      (value) => {
        state.layoutSettings.state = value;
      }
    );

    watch(
      () => props.propHeaderTheme,
      (value) => {
        state.headerTheme = value;
      }
    );

    const methods = {
      //实时计算监听 宽高
      calcScreen() {
        state.screenWidth = window.innerWidth;
        state.screenHeight = window.innerHeight;
        state.isMobile = state.screenWidth < 992;
        window.onresize = () => {
          return (() => {
            state.screenWidth = window.innerWidth;
            state.screenHeight = window.innerHeight;
            state.isMobile = state.screenWidth < 992;
          })();
        };
      },
      onCollapsed() {
        state.collapsed = !state.collapsed;
        context.emit("update:propCollapsed", state.collapsed);
      },
      onSettings() {
        context.emit("update:propLayoutSettingsState", !state.layoutSettings.state);
      },
      onReload(dom) {
        context.emit("reload", dom);
      },
      //全屏事件
      onFullScreen() {
        if (!screenfull.isEnabled) {
          return tools.message(
            "您的浏览器无法使用全屏功能，请更换谷歌浏览器或者请手动点击F11按钮全屏展示！"
          );
        }
        screenfull.toggle();
        state.fullscreen = !screenfull.isFullscreen;
      },
      //初始化 一级菜单
      initTopMenu() {
        // 监听窗口大小 小屏幕下不使用 topnav
        window.onresize = () => {
          store.commit("app/setTopNav", document.body.clientWidth > 1350);
        };
        methods.getOneLevelsMenu();
        //如果当前路由 父级菜单 有 则切换到这个菜单上去
        if (topMenuId.value) {
          state.selectedKeys = [topMenuId.value];
          methods.onMenuSelected({ key: topMenuId.value });
        } else {
          if (state.oneLevels.length > 0) {
            var menu = state.oneLevels[0];
            state.selectedKeys = [
              menu.jumpUrl
                ? menu.jumpUrl
                : menu.componentName
                ? menu.componentName
                : menu.id,
            ];
            methods.onMenuSelected({
              key: menu.componentName ? menu.componentName : menu.id,
            });
          }
        }
      },
      //获取第一级菜单
      getOneLevelsMenu() {
        state.oneLevels = menus.value.filter(
          (w) => w.parentId == null || w.parentId == ""
        );
      },
      //菜单选中
      onMenuSelected(obj) {
        const routeInfo = store.getters["app/getRouterByFullPath"](obj.key);
        if (routeInfo && router.hasRoute(routeInfo.name)) {
          router.push({ path: obj.key });
        } else {
          store.commit("app/setSubmenu", obj.key);
        }
      },
    };

    //页面加载 钩子函数
    onMounted(() => {
      methods.calcScreen();
      methods.initTopMenu();
    });

    return {
      ...toRefs(state),
      ...methods,
      title,
      userName,
      topNavValue,
    };
  },
});
</script>
<style lang="less">
#hzy-layout {
  //覆盖样式
  .ant-layout-header {
    position: relative;
    left: 0;
    z-index: 6;
    width: 100%;
    line-height: 60px;
  }

  //=======// 头部
  .hzy-layout-header {
    padding: 0;
    position: relative;
    display: flex;
    align-items: center;
    // height: 48px;
    height: 58px;
    // padding: 0 20px;
    border-bottom: 1px solid #f0f2f5;
    // box-shadow: 0 1px 4px rgba(0, 21, 41, 0.08);

    .hzy-header-btn {
      padding: 0 18px;
      cursor: pointer;
    }

    .hzy-header-btn:hover {
      background: rgba(243, 246, 248, 0.2);
    }

    .logo {
      text-align: center;
      font-size: 16px;
      font-weight: bold;
      color: #fff;
    }

    .anticon {
      color: #fff;
      font-size: 16px;
    }

    .ant-dropdown-trigger {
      color: #fff;
    }

    .ant-menu {
      background: none !important;
    }
  }

  //=======// 头部 亮色
  .hzy-layout-header-light {
    background: #fff;

    .hzy-header-btn:hover {
      background: rgba(0, 0, 0, 0.025);
    }

    .logo {
      color: rgba(0, 0, 0, 0.85);
    }

    .anticon {
      color: rgba(0, 0, 0, 0.85);
    }

    .ant-dropdown-trigger {
      color: rgba(0, 0, 0, 0.85);
    }
  }

  //=======// 头部 暗色
  .hzy-layout-header-dark {
    background: #001529;
    .ant-menu-item span {
      color: #fff;
    }
  }

  //=======// 头部 蓝色
  .hzy-layout-header-blue {
    background: #1890ff;
    .ant-menu-item span {
      color: #fff;
    }
  }

  //=======// 头部 红色
  .hzy-layout-header-1 {
    background: #997b71;
    .ant-menu-item span {
      color: #fff;
    }
  }

  //=======// 头部 橙色
  .hzy-layout-header-2 {
    background: #11c26d;
    .ant-menu-item span {
      color: #fff;
    }
  }

  //=======// 头部 黄色
  .hzy-layout-header-3 {
    background: #667afa;
    .ant-menu-item span {
      color: #fff;
    }
  }

  //=======// 头部 青色
  .hzy-layout-header-4 {
    background: #f74584;
    .ant-menu-item span {
      color: #fff;
    }
  }

  //=======// 头部 绿色
  .hzy-layout-header-5 {
    background: #9463f7;
    .ant-menu-item span {
      color: #fff;
    }
  }

  //=======// 头部 深蓝色
  .hzy-layout-header-6 {
    background: #ffcd17;
    .ant-menu-item span {
      color: #fff;
    }
  }

  //=======// 头部 紫色
  .hzy-layout-header-7 {
    background: #ff4c52;
    .ant-menu-item span {
      color: #fff;
    }
  }
}
</style>
