import Vue from 'vue';
import Vuex from 'vuex'; //引入 vuex
//import store from './store' //注册store
//框架默认状态管理
import app from './module/app' // 主页
//系统管理
import User_Vuex from './Sys/User';
import Role_Vuex from './Sys/Role';
import Function_Vuex from './Sys/Function';
import Menus_Vuex from './Sys/Menus';
import RoleFunction_Vuex from './Sys/RoleFunction';
import AppLog_Vuex from './Sys/AppLog';
//
Vue.use(Vuex); //使用 vuex
export default new Vuex.Store({
    modules: {
        app,
        //系统管理
        User_Vuex,
        Role_Vuex,
        Function_Vuex,
        Menus_Vuex,
        RoleFunction_Vuex,
        AppLog_Vuex
    }
})