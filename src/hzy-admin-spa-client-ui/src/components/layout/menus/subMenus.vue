<template>
  <a-sub-menu :key="menuInfo.id" v-bind="$attrs">
    <template #title>
      <span>
        <AppIcons :iconName="menuInfo.icon" />
        <span>{{ menuInfo.name }}</span>
      </span>
    </template>
    <template v-for="item in menuInfo.children">
      <a-menu-item
        v-if="item.children.length === 0"
        :key="item.jumpUrl ? item.jumpUrl : item.id"
        :title="item.name"
      >
        <AppIcons :iconName="item.icon" />
        <span>{{ item.name }}</span>
      </a-menu-item>
      <sub-menus v-else :menu-info="item" :key="item.id" />
    </template>
  </a-sub-menu>
</template>
<script>
import { defineComponent } from "vue";
import AppIcons from "@/components/appIcons.vue";

export default defineComponent({
  name: "subMenus",
  props: ["menuInfo"],
  components: {
    AppIcons,
  },
});
</script>
