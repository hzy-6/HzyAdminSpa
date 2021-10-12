<template>
  <div class="app-tabs">
    <a-tabs
      hide-add
      tabPosition="top"
      type="editable-card"
      :tabBarGutter="0"
      @edit="onEdit"
      @tabClick="tabClick"
      v-model:activeKey="activeKey"
    >
      <a-tab-pane
        v-for="item in tabList"
        :key="item.path"
        :closable="item.meta.close == 1"
      >
        <template #tab>
          <a-dropdown>
            <AppIcons iconName="EllipsisOutlined" class="tab-more" />
            <template #overlay>
              <a-menu>
                <a-menu-item key="1" @click="closeTabSelf(item.path)">
                  关闭当前
                </a-menu-item>
                <a-menu-item key="2" @click="closeTabOther(item.path)">
                  关闭其他
                </a-menu-item>
                <a-menu-item key="3" @click="closeTabAll()">关闭全部</a-menu-item>
              </a-menu>
            </template>
          </a-dropdown>
          <span style="user-select: none">{{ item.meta.title }}</span>
        </template>
      </a-tab-pane>
    </a-tabs>
  </div>
</template>
<script>
import { computed, defineComponent, onMounted, watch, ref } from "vue";
import { useStore } from "vuex";
import AppIcons from "@/components/appIcons.vue";
import router from "@/router/index";

export default defineComponent({
  name: "layoutTabs",
  components: { AppIcons },
  setup() {
    //计算属性
    const store = useStore();
    const tabList = computed(() => store.state.app.tabList);
    const activeKey = ref(router.currentRoute.value.fullPath);

    //
    watch(
      () => router.currentRoute.value.fullPath,
      (value) => {
        activeKey.value = value;
        methods.addTags();
      }
    );

    // const tabEvent = mapMutations("app", [
    //   "closeTabSelf",
    //   "closeTabOther",
    //   "closeTabAll",
    //   "tabClick",
    // ]);

    const methods = {
      addTags() {
        store.commit("app/addTab", { currentRoute: router.currentRoute.value });
      },
      onEdit(key, action) {
        if (action === "remove") {
          methods.closeTabSelf(key);
        }
      },
      closeTabSelf(key) {
        store.commit("app/closeTabSelf", key);
      },
      closeTabOther(key) {
        store.commit("app/closeTabOther", key);
      },
      closeTabAll() {
        store.commit("app/closeTabAll");
      },
      tabClick(key) {
        store.commit("app/tabClick", key);
      },
    };

    onMounted(() => {
      methods.addTags();
    });

    return {
      tabList,
      activeKey,
      ...methods,
    };
  },
});
</script>
<style lang="less" scope>
.app-tabs {
  background: #ffffff;
  position: relative;
  left: 0;
  width: 100%;
  z-index: 6;
  // box-shadow: 0 1px 4px rgba(0, 21, 41, 0.08);

  .ant-tabs-nav-container {
    margin-bottom: 0;
  }
  .ant-tabs-bar {
    margin: 0 !important;
    border-bottom: 0 !important;

    .ant-tabs-tab {
      background: #ffffff !important;
      border: 0 !important;
      border-radius: 0 !important;
      padding: 0 40px !important;
      line-height: 40px !important;
    }

    .ant-tabs-tab.ant-tabs-tab-active {
      background: #f0f2f5 !important;
    }

    .tab-more {
      position: absolute;
      margin-top: 13px;
      left: 18px;
      display: none;
    }

    .ant-tabs-close-x {
      position: absolute;
      margin-top: 13px;
      right: 18px;
      display: none;
    }

    .ant-tabs-tab:hover {
      .tab-more,
      .ant-tabs-close-x {
        display: inline-block;
      }
    }
  }
}
</style>
