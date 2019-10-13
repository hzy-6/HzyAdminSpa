import Vue from 'vue'
import App from './App.vue'
//vuex
import store from './vuex/store'
//router
import router from './js/router/index'
//antd
import Antd from 'ant-design-vue'
//import 'ant-design-vue/dist/antd.css'
import './css/theme-ext.less'
//http request
import {get, post, postUpload } from './js/http'
//tools 工具
import tools from './js/tools'
Vue.use(Antd);
//
global.$store = store;
global.$router = router;
global.tools = tools;
global.get = get;
global.post = post;
global.postUpload = postUpload;
//菜单
global.$menu = [];
//权限
global.$powerAll = [];
global.$power = {};
//
Vue.config.productionTip = false
    //
new Vue({
    store,
    router, //加入我自己的路由
    render: h => h(App)
}).$mount('#app')