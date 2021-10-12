<template>
  <div id="hzy-layout">
    <a-layout style="min-height: 100vh">
      <a-layout-sider
        hasSider
        v-model:collapsed="collapsed"
        :breakpoint="'lg'"
        @breakpoint="onBreakpoint"
        :collapsedWidth="siderWidth"
        :style="{
          overflow: 'auto',
          height: '100vh',
          position: 'fixed',
          left: 0,
          zIndex: 9,
        }"
        :theme="menuTheme"
      >
        <div class="hzy-logo">{{ title }}</div>
        <a-drawer
          placement="left"
          :closable="false"
          :visible="!collapsed"
          @close="collapsed = !collapsed"
          :bodyStyle="{ padding: 0 }"
          :drawerStyle="{ background: menuTheme == 'dark' ? '#001529' : '' }"
          v-if="breakpoint"
        >
          <div class="hzy-logo">{{ title }}</div>
          <layoutMenus class="hzy-layout-sider" :propMenuTheme="menuTheme" />
        </a-drawer>
        <layoutMenus class="hzy-layout-sider" :propMenuTheme="menuTheme" v-else />
      </a-layout-sider>
      <a-layout :style="{ marginLeft: siderWidth + 'px', zIndex: 5 }">
        <layoutHeader
          v-model:propCollapsed="collapsed"
          v-model:propHeaderTheme="headerTheme"
          v-model:propLayoutSettingsState="layoutSettings.state"
          @reload="reload"
        />
        <a-layout-content>
          <!-- {{ $route.fullPath }}
          {{ cacheViews }} -->
          <!-- <transition name="fade" mode="out-in"> -->
          <!-- </transition> -->
          <router-view v-slot="{ Component }">
            <transition name="fade-transform" mode="out-in">
              <keep-alive :include="cacheViews">
                <component :is="Component" :key="$route.fullPath" />
              </keep-alive>
            </transition>
          </router-view>
        </a-layout-content>
        <a-layout-footer style="text-align: center">
          Hzy Antd Vue Admin ©2020 Created by Hzy
        </a-layout-footer>
      </a-layout>
    </a-layout>

    <!--设置弹框-->
    <layoutSettings
      v-model:propState="layoutSettings.state"
      v-model:propHeaderTheme="headerTheme"
      v-model:propMenuTheme="menuTheme"
    />
  </div>
</template>
<script>
import { computed, nextTick, reactive, watch, defineComponent, toRefs, ref } from "vue";
import tools from "@/scripts/tools";
import router from "@/router/index";
import { useStore } from "vuex";
import layoutHeader from "./layoutHeader.vue";
import layoutMenus from "./menus/layoutMenus.vue";
import layoutSettings from "./layoutSettings.vue";

export default defineComponent({
  name: "AppMain",
  components: {
    layoutHeader,
    layoutMenus,
    layoutSettings,
  },
  setup() {
    const fullPath = ref(router.currentRoute.value.fullPath);
    const headerTheme = tools.getHeaderTheme() ?? "hzy-layout-header-light";

    const state = reactive({
      collapsed: false,
      selectedKeys: ["1"],
      openKeys: [],
      siderWidth: 200,
      breakpoint: false,
      headerTheme,
      menuTheme: tools.getMenuTheme() ? tools.getMenuTheme() : "dark",
      layoutSettings: {
        state: false,
      },
    });

    //监听菜单收缩状态
    watch(
      () => state.collapsed,
      (value) => {
        if (state.breakpoint) {
          //如果小屏幕 菜单宽度
          state.siderWidth = 0;
        } else {
          state.siderWidth = value ? 80 : 200;
        }
      }
    );

    watch(
      () => router.currentRoute.value,
      (value) => {
        fullPath.value = value.fullPath;
      }
    );

    //计算属性
    const store = useStore();
    const title = computed(() => store.state.app.title);
    const cacheViews = computed(() => store.state.app.cacheViews);

    //
    const onBreakpoint = (broken) => {
      state.breakpoint = broken;
    };

    //刷新当前页面
    const reload = () => {
      store.dispatch("app/delCacheView", fullPath.value).then(() => {
        nextTick(() => {
          router.push({
            path: "/redirect" + fullPath.value,
          });
        });
      });
    };

    return {
      ...toRefs(state),
      onBreakpoint,
      reload,
      title,
      cacheViews,
    };
  },
});
</script>
