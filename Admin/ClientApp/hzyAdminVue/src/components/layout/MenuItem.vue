<template>
  <div>
    <template v-for="(item,index) in dataMenu">
      <el-menu-item :key="index" :index="item.path" v-if="item.children.length==0">
        <i :class="item.icon"></i>
        <span slot="title">{{item.name}}</span>
      </el-menu-item>
      <el-submenu :key="index" :index="item.id" v-else>
        <template slot="title">
          <i :class="item.icon"></i>
          <span slot="title">{{item.name}}</span>
        </template>
        <MenuItemComponent :dataMenu="item.children" />
      </el-submenu>
    </template>
  </div>
</template>

<script>
export default {
  name: "MenuItemComponent",
  props: {
    dataMenu: Array
  },
  components: {},
  data() {
    return {};
  }
};
</script>