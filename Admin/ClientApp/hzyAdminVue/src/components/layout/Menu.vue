<template>
  <div>
    <!--@open="$emit('open', $event.target.open)"
    @close="$emit('close', $event.target.close)"-->
    <el-menu
      :default-active="$route.name"
      class="main-menu"
      :collapse="collapse"
      router
      :background-color="backgroundColor"
      :text-color="textColor"
      :active-text-color="activeTextColor"
    >
      <!-- <el-menu-item index="/Home">
        <i class="el-icon-s-home"></i>
        <span slot="title">首页</span>
      </el-menu-item> -->
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
      <!---->
    </el-menu>
  </div>
</template>

<script>
import MenuItemComponent from "../layout/MenuItem";

export default {
  name: "MenuComponent",
  props: {
    defaultActive: String,
    backgroundColor: String,
    textColor: String,
    activeTextColor: String,
    collapse: Boolean,
    open: Function,
    close: Function,
    dataMenu: Array
  },
  components: {
    MenuItemComponent
  },
  data() {
    return {};
  },
  mounted(){
    
  },
};
</script>