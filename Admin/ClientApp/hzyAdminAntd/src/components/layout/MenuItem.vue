<template functional>
  <a-sub-menu :key="props.menuInfo.id">
    <span slot="title">
      <a-icon type="mail" /><span>{{ props.menuInfo.name }}</span>
    </span>
    <template v-for="item in props.menuInfo.children">
      <a-menu-item v-if="item.children.length==0" :key="item.path">
        <a-icon type="pie-chart" />
        <span>{{ item.name }}</span>
      </a-menu-item>
      <MenuItem v-else :menu-info="item" :key="item.id" />
    </template>
  </a-sub-menu>
</template>
<script>
export default {
  props: ['menuInfo'],
};
</script>