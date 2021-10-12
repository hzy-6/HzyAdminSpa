<template>
  <a-config-provider :getPopupContainer="getPopupContainer" :locale="locale">
    <a-spin :spinning="globalLoading">
      <router-view />
    </a-spin>
  </a-config-provider>
</template>

<script>
import { computed, defineComponent, ref } from "vue";
import zhCN from "ant-design-vue/es/locale/zh_CN";
import moment from "moment";
import "moment/dist/locale/zh-cn";
import { useStore } from "vuex";
moment.locale("zh-cn");

export default defineComponent({
  name: "App",
  setup() {
    const locale = ref(zhCN);
    const store = useStore();
    const globalLoading = computed(() => store.state.app.globalLoading);

    const getPopupContainer = (el, dialogContext) => {
      if (dialogContext) {
        return dialogContext.getDialogWrap();
      } else {
        return document.body;
      }
    };

    return {
      locale,
      getPopupContainer,
      globalLoading,
    };
  },
});
</script>
