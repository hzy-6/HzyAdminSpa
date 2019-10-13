<template>
  <a-locale-provider :locale="zh_CN">
    <a-spin :spinning="loading">
      <div id="app">
        <router-view></router-view>
      </div>
    </a-spin>
  </a-locale-provider>
</template>

<script>
import zh_CN from "ant-design-vue/lib/locale-provider/zh_CN";
// import moment from "moment";
// import "moment/locale/zh-cn";
//
// moment.locale("zh-cn");
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
//
export default {
  name: "app",
  data() {
    return {
      zh_CN
    };
  },
  computed: {
    ...mapState("app", {
      loading: state => state.loading
    })
  }
};
</script>

<style lang="less">
body {
  width: 100%;
  height: 100%;
  overflow: hidden;
  margin: 0;
}
#app {
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", "PingFang SC",
    "Hiragino Sans GB", "Microsoft YaHei", "Helvetica Neue", Helvetica, Arial,
    sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
  height: 100%;
  width: 100%;
  overflow: hidden;
}
:global {
  //页面切换动画
  .page-toggle-enter-active {
    transition: all 0.2s ease-in 0.25s;
  }
  .page-toggle-leave-active {
    transition: all 0.2s ease-out 0s;
  }
  .page-toggle-enter,
  .page-toggle-leave-to {
    opacity: 0;
    padding: 0px;
  }
}
</style>
