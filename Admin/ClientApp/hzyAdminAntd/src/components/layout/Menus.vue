<template>
  <div>
    <a-menu
      mode="inline"
      :theme="theme"
      :defaultSelectedKeys="[$route.name]"

      :inlineCollapsed="inlineCollapsed"
      @select="select"
    >
      <template v-for="item in dataMenu">
        <a-menu-item v-if="item.children.length==0" :key="item.path">
          <a-icon :type="item.icon" />
          <span>{{item.name}}</span>
        </a-menu-item>
        <MenuItemCom v-else :menu-info="item" :key="item.id" />
      </template>
    </a-menu>
  </div>
</template>
<script>
import MenuItemCom from "../layout/MenuItem";

export default {
  name: "MenusCom",
  props: {
    theme: String,
    inlineCollapsed: Boolean,
    dataMenu: Array,
    select: Function
  },
  components: {
    MenuItemCom
  },
  data() {
    return {};
  },
  mounted() {}
};
</script>