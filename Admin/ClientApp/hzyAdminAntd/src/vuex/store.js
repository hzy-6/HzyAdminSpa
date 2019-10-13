import Vue from 'vue';
import Vuex from 'vuex'; //引入 vuex
import store from './store' //注册store
// Module
import app from './module/app' // app.vue
import layout from './module/layout' // 主页

Vue.use(Vuex); //使用 vuex
export default new Vuex.Store({
    modules: {
        app,
        layout
    }
})