<template>
  <div class="login">
    <div class="login-modal"></div>
    <div class="login-container">
      <a-card style="padding:40px 40px">
        <div class="login-title">HzyAdmin-Antd Vue单页版</div>
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
            <a-button type="primary" @click="check">登录</a-button>
          </div>
        </div>
      </a-card>
    </div>
  </div>
</template>

<script>
//css
import "../css/layout.less";
//
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
    console.log(this.$route.params);
  },
  methods: {
    check() {
      if (!this.UserName) return global.tools.notice("用户名不能为空!");
      if (!this.UserPassword) return global.tools.notice("密码不能为空!");
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

