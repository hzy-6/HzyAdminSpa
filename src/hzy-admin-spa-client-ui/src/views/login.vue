<template>
  <div id="login">
    <div class="login-modal"></div>
    <div class="login-container">
      <a-card>
        <div class="login-title">{{ title }}</div>
        <div class="p-20">
          <a-form layout="vertical">
            <a-form-item>
              <a-input
                v-model:value="userName"
                placeholder="请输入"
                size="large"
                allow-clear
              >
                <template #prefix>
                  <app-icons
                    icon-name="UserOutlined"
                    style="color: #1890ff; font-size: 14px"
                  />
                </template>
              </a-input>
            </a-form-item>
            <a-form-item>
              <a-input-password
                type="password"
                v-model:value="userPassword"
                size="large"
                ref="inputPassword"
                @keyup.enter="check"
              >
                <template #prefix>
                  <app-icons
                    icon-name="LockOutlined"
                    style="color: #1890ff; font-size: 14px"
                  />
                </template>
              </a-input-password>
            </a-form-item>
            <a-form-item>
              <a-button
                type="primary"
                @click="check"
                :loading="loading"
                size="large"
                block
              >
                登录
              </a-button>
            </a-form-item>
          </a-form>
        </div>
      </a-card>
    </div>
  </div>
</template>
<script>
import {
  computed,
  defineComponent,
  reactive,
  toRefs,
  ref,
  onMounted,
} from "vue";
//vuex
import { useStore } from "vuex";
import router from "@/router/index";
import AppIcons from "@/components/appIcons";
import tools from "@/scripts/tools";
import loginService from "@/service/system/loginService";

export default defineComponent({
  components: { AppIcons },
  setup() {
    const state = reactive({
      userName: "admin",
      userPassword: "123456",
    });
    const loading = ref(false);
    const inputPassword = ref(null);

    const store = useStore();
    const title = computed(() => store.state.app.title);

    store.commit("app/setUserInfo", {});

    const methods = {
      check() {
        if (!state.userName) return tools.message("用户名不能为空!", "警告");
        if (!state.userPassword) return tools.message("密码不能为空!", "警告");
        loading.value = true;
        loginService.login(state.userName, state.userPassword).then((res) => {
          loading.value = false;
          if (res.code !== 1) return;
          tools.setAuthorization(res.data.token);
          router.push("/");
        });
      },
    };

    onMounted(() => {
      tools.delAuthorization();
      inputPassword.value.focus();
    });

    return {
      ...toRefs(state),
      title,
      ...methods,
      loading,
      inputPassword,
    };
  },
});
</script>
<style lang="less" scoped>
#login {
  text-align: center;
  position: fixed;
  top: 0;
  bottom: 0;
  right: 0;
  left: 0;
  //可以解开一下注解 放置一个背景图片
  // background: url("../assets/images/login2.jpg") no-repeat;
  // background-size: cover;
  background: #f0f2f5 url("../assets/background.svg") no-repeat 50%;

  .login-modal {
    position: absolute;
    width: 100%;
    height: 100%;
    // background-color: #000000;
    // background: #f0f2f5;
    margin: 0 auto;
    // opacity: 0.3;
  }

  .login-container {
    position: absolute;
    width: 25rem;
    top: 50%;
    left: 50%;
    -webkit-transform: translate(-50%, -50%);
    transform: translate(-50%, -50%);

    .login-title {
      padding: 20px;
      font-size: 25px;
      font-weight: 500;
    }

    .form-title {
      text-align: left;
    }

    .ant-card {
      border: 0;
    }
  }

  @media (max-width: 720px) {
    .login-container {
      width: 100%;

      .ant-card {
        padding: 0;
      }
    }
  }
}
</style>
