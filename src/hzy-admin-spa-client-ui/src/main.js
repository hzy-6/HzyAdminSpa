import { createApp } from 'vue'
import App from './App.vue'
//vue 路由
import router from './router'
//属性状态管理
import store from './store'
//ant-design-vue
import antd from 'ant-design-vue'
//样式-引入覆盖antd
import '@/assets/styles/hzy-admin-ui-antd.less'
//样式-nprogress
import 'nprogress/nprogress.css';

createApp(App)
    .use(store)
    .use(router)
    .use(antd)
    .mount('#app')
