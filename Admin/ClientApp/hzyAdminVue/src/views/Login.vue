<template>
  <div class="login">
    <div class="login-modal"></div>
    <div class="login-container">
      <el-card class="box-card" body-style="padding:60px 40px">
        <div class="login-title">HzyAdminUI Vue 管理系统</div>
        <div class="p-20">
          <div class="login-input">
            <div class="form-title">用户名</div>
            <input type="text" v-model="UserName" />
          </div>
          <div class="login-input">
            <div class="form-title">密码</div>
            <input type="password" v-model="UserPassword" />
          </div>
          <div class="login-btn">
            <el-button type="primary" size="medium" @click="check">登录</el-button>
          </div>
        </div>
      </el-card>
    </div>
  </div>
</template>

<script>
export default {
  name: "Login",
  data() {
    return {
      UserName: "",
      UserPassword: "",
      LoginCode: ""
    };
  },
  mounted() {
    //console.log(this.$route.params);
    // admin.alert();
  },
  methods: {
    check() {
      global
        .post("/Admin/Authorization/Check", {
          UserName: this.UserName,
          UserPassword: this.UserPassword,
          LoginCode: this.LoginCode
        })
        .then(data => {
          global.tools.setCookie("Authorization", data.token);
          this.$router.push("/");
        });
    }
  }
};
</script>

<style type="text/css">
</style>

