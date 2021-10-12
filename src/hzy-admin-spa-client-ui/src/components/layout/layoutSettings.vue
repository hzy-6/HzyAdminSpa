<template>
  <a-drawer class="app-settings" placement="right" width="300px" :closable="false" @close="setState(!state)" :visible="state">
    <a-divider>主题颜色</a-divider>
    <div class="app-skin-list mb-5">
      <div class="app-skin-item" v-for="(item, index) in headerThemes" :key="index" :style="{ background: item.color }" @click="onHeaderTheme(item.className)"></div>
    </div>
    <a-divider>菜单颜色</a-divider>
    <div class="mt-5">
      <a-radio-group name="radioGroup" defaultValue="dark" v-model:value="menuTheme">
        <a-radio value="dark">暗色</a-radio>
        <a-radio value="light">亮色</a-radio>
      </a-radio-group>
    </div>
    <a-divider>开启TopNav</a-divider>
    <div class="mt-5">
      <a-switch v-model:checked="topNav" />
    </div>
  </a-drawer>
</template>
<script>
import { defineComponent, reactive, toRefs, watch, computed } from "vue";
import tools from "@/scripts/tools";
//vuex
import { useStore } from "vuex";

export default defineComponent({
  props: {
    propState: Boolean,
    propMenuTheme: String,
    propHeaderTheme: String,
  },
  setup(props, context) {
    const store = useStore();
    const topNavValue = computed(() => store.state.app.topNav).value;
    const state = reactive({
      state: props.propState,
      menuTheme: props.propMenuTheme,
      headerTheme: props.propHeaderTheme,
      headerThemes: [
        { className: "hzy-layout-header-light", color: "#ffffff" },
        { className: "hzy-layout-header-dark", color: "#001529" },
        { className: "hzy-layout-header-blue", color: "#1890ff" },
        { className: "hzy-layout-header-1", color: "#997b71" },
        { className: "hzy-layout-header-2", color: "#11c26d" },
        { className: "hzy-layout-header-3", color: "#667afa" },
        { className: "hzy-layout-header-4", color: "#f74584" },
        { className: "hzy-layout-header-5", color: "#9463f7" },
        { className: "hzy-layout-header-6", color: "#ffcd17" },
        { className: "hzy-layout-header-7", color: "#ff4c52" },
      ],
      topNav: topNavValue,
    });
    watch(
      () => props.propState,
      (value) => {
        state.state = value;
      }
    );
    watch(
      () => props.propMenuTheme,
      (value) => {
        state.menuTheme = value;
      }
    );
    watch(
      () => props.propHeaderTheme,
      (value) => {
        state.headerTheme = value;
      }
    );
    watch(
      () => state.menuTheme,
      (value) => {
        context.emit("update:propMenuTheme", value);
        tools.setMenuTheme(value);
      }
    );
    watch(
      () => state.topNav,
      (value) => {
        methods.saveTopNavState(value);
      }
    );

    const methods = {
      setState(value) {
        this.state = value;
        this.$emit("update:propState", value);
      },
      onHeaderTheme(value) {
        this.headerTheme = value;
        this.$emit("update:propHeaderTheme", value);
        tools.setHeaderTheme(value);
      },
      saveTopNavState() {
        store.commit("app/saveTopNavState", state.topNav);
      },
    };

    return {
      ...toRefs(state),
      ...methods,
    };
  },
});
</script>
<style lang="less" scoped>
.app-settings {
  .app-skin-list {
    width: 100%;
    display: inline-block;
    .app-skin-item {
      width: 30px;
      height: 30px;
      float: left;
      margin: 8px;
      cursor: pointer;
      border-radius: 5px;
      border: 1px solid #f5222d;
    }
  }
}
</style>
