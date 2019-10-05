<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script>
export default {
  name: "app"
};
</script>

<style lang='scss'>
body {
  position: absolute;
  width: 100%;
  height: 100%;
  overflow: hidden;
  margin: 0;
}

#app {
  font-family: "Helvetica Neue", Helvetica, "PingFang SC", "Hiragino Sans GB",
    "Microsoft YaHei", "微软雅黑", Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #313a46;
}

:global {
  //页面切换动画
  .page-toggle-enter-active {
    transition: all 0.1s ease-in 0.15s;
  }
  .page-toggle-leave-active {
    transition: all 0.1s ease-out 0s;
  }
  .page-toggle-enter,
  .page-toggle-leave-to {
    opacity: 0;
    padding: 0px;
  }
}
</style>
