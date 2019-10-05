<template>
  <div>
    <el-row :gutter="20">
      <el-col :offset="8" :xs="24" :sm="24" :md="8" :lg="8" :xl="8">
        <el-card class="box-card">
          <el-row :gutter="20">
            <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
              <h5>旧密码</h5>
              <el-input v-model="OldPwd" type="password"></el-input>
            </el-col>
            <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
              <h5>新密码</h5>
              <el-input v-model="NewPwd" type="password"></el-input>
            </el-col>
            <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
              <h5>确认密码</h5>
              <el-input v-model="QrPwd" type="password"></el-input>
            </el-col>
            <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid" class="mt-30 mb-30">
              <el-button type="primary" style="width:100%" @click="update">保存</el-button>
            </el-col>
          </el-row>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>
<!--脚本-->
<script>
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
var _controllerName = "ChangePassword";
//业务
export default {
  name: _controllerName,
  data() {
    return {
      grid: 24,
      power: global.$power,
      OldPwd: null,
      NewPwd: null,
      QrPwd: null
    };
  },
  //计算属性
  computed: {},
  mounted() {
    //元素创建完成
  },
  methods: {
    //获取数据
    ...mapActions("User_Vuex", {
      updatePassword: "updatePassword"
    }),
    update() {
      if (!this.OldPwd) return global.tools.msg("请输入旧密码", "错误");
      if (!this.NewPwd) return global.tools.msg("请输入新密码", "错误");
      if (!this.QrPwd) return global.tools.msg("请输入确认密码", "错误");
      if (this.NewPwd != this.QrPwd)
        return global.tools.msg("新密码和确认密码不一致!", "错误");
      this.updatePassword({
        OldPwd: this.OldPwd,
        NewPwd: this.NewPwd
      });
    }
  }
};
</script>