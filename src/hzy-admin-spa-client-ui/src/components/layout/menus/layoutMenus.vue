<template>
  <a-menu
    :theme="menuTheme"
    v-model:selectedKeys="selectedKeys"
    v-model:openKeys="openKeys"
    mode="inline"
    @select="onMenuSelected"
  >
    <!-- <a-menu-item key="/home" title="首页">
      <desktop-outlined />
      <span>首页</span>
    </a-menu-item>
    <a-menu-item key="/button" title="按钮">
      <pie-chart-outlined />
      <span>按钮</span>
    </a-menu-item>
    <a-sub-menu key="sub2">
      <template #title>
        <span>
          <team-outlined />
          <span>列表页</span>
        </span>
      </template>
      <a-menu-item key="/baseList" title="基础列表">基础列表</a-menu-item>
      <a-menu-item key="/list" title="标准列表">标准列表</a-menu-item>
    </a-sub-menu> -->

    <!-- 动态生成 topnav-->
    <template v-if="topNavValue">
      <template v-for="item in subMenus">
        <a-menu-item
          v-if="item.children.length === 0"
          :key="item.jumpUrl ? item.jumpUrl : item.id"
          :title="item.name"
        >
          <AppIcons :iconName="item.icon" />
          <span>{{ item.name }}</span>
        </a-menu-item>
        <SubMenus v-else :menu-info="item" :key="item.id" />
      </template>
    </template>

    <template v-else>
      <template v-for="item in menus">
        <a-menu-item
          v-if="item.children.length === 0"
          :key="item.jumpUrl ? item.jumpUrl : item.id"
          :title="item.name"
        >
          <AppIcons :iconName="item.icon" />
          <span>{{ item.name }}</span>
        </a-menu-item>
        <SubMenus v-else :menu-info="item" :key="item.id" />
      </template>
    </template>
  </a-menu>
</template>
<script>
import { computed, defineComponent, reactive, toRefs, watch } from "vue";
import AppIcons from "@/components/appIcons.vue";
import router from "@/router/index";
import { useStore } from "vuex";
import SubMenus from "./subMenus";

export default defineComponent({
  name: "layoutMenus",
  components: { AppIcons, SubMenus },
  props: {
    propMenuTheme: {
      type: String,
      required: true,
    },
  },
  setup(props) {
    const store = useStore();
    const fullPath = router.currentRoute.value.fullPath;
    const openKeysString = localStorage.getItem("openKeys") ?? "";
    const openKeys = openKeysString ? JSON.parse(openKeysString) ?? [] : [];
    const topNavValue = computed(() => store.state.app.topNav);
    const subMenus = computed(() => store.state.app.submenus); //topnav 菜单
    const menus = computed(() => store.state.app.userInfo.menus);

    const state = reactive({
      defaultSelectedKeys: [fullPath],
      selectedKeys: [fullPath],
      openKeys: openKeys,
      menuTheme: props.propMenuTheme,
    });

    watch(
      () => router.currentRoute.value,
      (value) => {
        state.selectedKeys = [value.fullPath];
      }
    );
    watch(
      () => props.propMenuTheme,
      (value) => {
        state.menuTheme = value;
      }
    );

    watch(
      () => state.openKeys,
      (value) => {
        localStorage.setItem("openKeys", JSON.stringify(value));
      }
    );

    //菜单选中
    const onMenuSelected = (obj) => {
      if (!obj.key) return;
      var externalAddress =
        obj.key.indexOf("http://") > -1 || obj.key.indexOf("https://") > -1;
      if (externalAddress) {
        return window.open(obj.key, "black");
      }
      router.push({ path: obj.key });
    };

    return {
      ...toRefs(state),
      onMenuSelected,
      topNavValue,
      subMenus,
      menus,
    };
  },
});
</script>
