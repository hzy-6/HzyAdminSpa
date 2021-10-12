// import { createStore } from 'vuex';
//属性状态管理
import tools from "@/scripts/tools";
import store from "@/store/index";
import router from "@/router/index";
import userService from "@/service/system/userService";

function getTabs() {
    return [
        {
            path: "/home",
            name: "home",
            meta: { title: "首页", close: false, keepAlive: true },
        },
    ];
}

export default {
    namespaced: true,
    state: () => ({
        tabList: getTabs(),
        //缓存视图
        cacheViews: ["home"],
        title: "HzyAdminSpa",
        topNav: tools.getTopNav(),
        userInfo: {},
        submenus: [],
        //全局加载
        globalLoading: false,
        //所有路由
        allRouters: []
    }),
    mutations: {
        //添加缓存视图
        addCacheView(state, value) {
            const { path, meta } = value;
            if (!meta.keepAlive) return;
            const { name } = store.getters["app/getRouterByFullPath"](path);
            let any = state.cacheViews.includes(name);
            if (any) return;
            state.cacheViews.push(name);
        },
        //删除缓存视图
        delCacheView(state, value) {
            const { name } = store.getters["app/getRouterByFullPath"](value);
            const index = state.cacheViews.indexOf(name);
            state.cacheViews.splice(index, 1);
        },
        //删除其他缓存视图
        delCacheViewOther(state, value) {
            const { name } = store.getters["app/getRouterByFullPath"](value);
            const index = state.cacheViews.indexOf(name);
            if (index > -1) {
                state.cacheViews = state.cacheViews.slice(index, index + 1);
            } else {
                state.cacheViews = [];
            }
        },
        //删除所有缓存视图
        delCacheViewAll(state) {
            state.cacheViews = [];
        },
        //添加标签页
        addTab(state, { currentRoute, title }) {
            const { path, hidden, meta } = currentRoute;

            if (Object.prototype.hasOwnProperty.call(currentRoute, "hidden") && hidden) return;

            if (!Object.prototype.hasOwnProperty.call(meta, "close")) return;

            if (title) {
                meta.title = title;
            }

            //检查是否存在
            let tab = state.tabList.find((w) => w.path == path);
            if (!tab) {
                state.tabList.push(currentRoute);
            }

            store.commit("app/addCacheView", currentRoute);
        },
        //关闭当前
        closeTabSelf(state, value) {
            let index = state.tabList.findIndex((w) => w.path == value);
            let oldTab = state.tabList[index];
            if (oldTab.meta.close) {
                state.tabList.splice(index, 1);
                store.commit("app/delCacheView", oldTab.path);
            }
            let tab = state.tabList[index - 1];
            if (!tab) return;
            router.push({ path: tab.path });
        },
        //关闭其他
        closeTabOther(state, value) {
            let path = value;
            let list = [];
            for (let i = 0; i < state.tabList.length; i++) {
                let item = state.tabList[i];
                if (!item.meta.close || item.path == path) {
                    list.push(item);
                }
            }

            let route = router.currentRoute.value;
            if (path != route.path) {
                router.push({ path });
            }

            store.commit("app/delCacheViewOther", path);
            state.tabList = list;
        },
        //关闭所有
        closeTabAll(state) {
            let tab = state.tabList.find((w) => !w.meta.close);
            let route = router.currentRoute.value;

            if (tab.path != route.path) {
                router.push({ path: tab.path });
            }

            state.tabList = [];
            state.tabList.push(tab);

            store.commit("app/delCacheViewAll");
        },
        //点击切换选项卡
        tabClick(state, value) {
            router.push({ path: value });
        },
        //设置用户信息
        setUserInfo(state, value) {
            state.userInfo = value;
        },
        //设置子菜单
        setSubmenu(state, parentId) {
            var menus = state.userInfo.menus.filter((w) => w.id == parentId);
            if (menus.length > 0) {
                state.submenus = menus[0].children;
            }
        },
        //设置 TopNav
        setTopNav(state, value) {
            if (tools.getTopNav()) {
                state.topNav = value;
            }
        },
        //保存 topnav 状态
        saveTopNavState(state, value) {
            state.topNav = value;
            tools.setTopNav(value);
        },
        //设置全局加载值
        setGlobalLoading(state, value) {
            state.globalLoading = value;
        },
        //设置所有路由
        setAllRouters(state, value) {
            state.allRouters = value;
        }
    },
    getters: {
        /**
         * 根据菜单 Id 获取 菜单所 对应的 权限
         * @param menuId
         * @returns {*}
         */
        getMenuPowerById: (state) => {
            let route = router.currentRoute.value;
            const data = state.userInfo.menuPowers.find((w) => w.menuId == route.meta.menuId);
            return data ? data : {};
        },
        /**
         * 根据最后id 查找 最上级 id
         */
        getTopMenuByLastId(state) {
            let route = router.currentRoute.value;
            let currentMenuId = route.meta.menuId;
            let allMenus = state.userInfo.menus;
            let topMenuId = null;

            const findId = (menus, id) => {
                for (let index = 0; index < menus.length; index++) {
                    const element = menus[index];
                    if (element.id == currentMenuId) {
                        topMenuId = id;
                        break;
                    }
                    if (element.children.length > 0) {
                        findId(element.children, element.parentId ? null : element.id);
                    }
                }
            };

            findId(allMenus, null);

            return topMenuId;
        },
        /**
         * 根据全路径信息获取 router 信息
         */
        getRouterByFullPath: (state) => (fullPath) => {
            let result = state.allRouters.find(w => w.path == fullPath);
            if (!result) {
                result = state.tabList.find(w => w.path == fullPath);
            }
            return result;
        }
    },
    actions: {
        delCacheView({ commit, state }, view) {
            return new Promise((resolve) => {
                commit("delCacheView", view);
                resolve([...state.cacheViews]);
            });
        },
        //获取用户信息 与 菜单
        getUserInfo({ state }) {
            return new Promise((resolve) => {
                if (Object.prototype.hasOwnProperty.call(state.userInfo, "sysRoles")) {
                    return resolve(state.userInfo);
                }
                store.dispatch("app/refreshUserInfo").then((data) => {
                    resolve(data);
                });
            });
        },
        //刷新用户信息
        refreshUserInfo({ commit }) {
            commit("setGlobalLoading", true);
            return new Promise((resolve) => {
                userService
                    .getUserInfo()
                    .then((res) => {
                        let data = res.data;
                        commit("setUserInfo", data);
                        commit("setGlobalLoading", false);
                        resolve(data);
                    })
                    .catch(() => {
                        commit("setGlobalLoading", false);
                    });
            });
        },
    },
};
