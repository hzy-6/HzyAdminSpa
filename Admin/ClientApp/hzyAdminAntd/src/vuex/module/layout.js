import adminTabs from "../../js/tabs";

const main = {
    namespaced: true,
    state: {
        siderCollapsed: window.localStorage.getItem("siderCollapsed") == 1, //菜单收展 字段
        headerSkinColor: window.localStorage.getItem("headerSkinColor"), //头部颜色 字段
        menuSkin: window.localStorage.getItem("menuSkinColor"),
        tabs: {
            list: (localStorage.getItem('tabsListAntd') ? JSON.parse(localStorage.getItem('tabsListAntd')) : [{
                title: "首页",
                name: "/Home",
                active: true,
            }]),
        },
        menuList: [],
        routerConfig: [],
    },
    mutations: {
        addOrCheckedTab(state, param) {
            // console.log(param);
            //检测是否重复标签页
            var name = param.name;
            var title = param.title;
            var list = state.tabs.list;
            for (var i = 0; i < list.length; i++) {
                var item = list[i];
                item.active = false;
            }
            //console.log('param', param);
            var item = state.tabs.list.find(w => w.name == name);
            if (item) {
                item.active = true;
            } else {
                param.active = true;
                state.tabs.list.push(param);
            }

            adminTabs.setUlWidth(list.length);
            localStorage.setItem('tabsListAntd', JSON.stringify(state.tabs.list));
            return;
        },
        removeTab(state, param) {
            global.$router.push({ name: state.tabs.list[param - 1].name });
            console.log(state.tabs.list[param - 1]);
            state.tabs.list.splice(param, 1);

            adminTabs.setUlWidth(state.tabs.list.length);
            localStorage.setItem('tabsListAntd', JSON.stringify(state.tabs.list));
            return;
        },
        closeOtherTab(state, param) {
            var list = state.tabs.list;
            var itemActive = state.tabs.list.find(w => w.active);
            for (var i = 0; i < list.length; i++) {
                if (i == 0) continue;
                var item = list[i];
                if (item.name != itemActive.name) {
                    list.splice(i, 1);
                }
            }
            localStorage.setItem('tabsListAntd', JSON.stringify(state.tabs.list));
        },
        closeAllTab(state, param) {
            var list = state.tabs.list;
            state.tabs.list = [];
            state.tabs.list.push(list[0]);
            var _hash = window.location.hash;
            if (_hash === "#" + state.tabs.list[0].name) return; //判断路由不能重复加载
            global.$router.push({ name: state.tabs.list[0].name });
            localStorage.setItem('tabsListAntd', JSON.stringify(state.tabs.list));
        },
        //菜单切换事件
        changeSiderCollapsed(state, param) {
            if (param === typeof Boolean) {
                state.siderCollapsed = param;
            } else {
                state.siderCollapsed = !state.siderCollapsed;
            }
            window.localStorage.setItem("siderCollapsed", state.siderCollapsed ? 1 : 0);
        },
        //设置头部颜色
        setHeaderSkinColor(state, param) {
            state.headerSkinColor = param;
            window.localStorage.setItem("headerSkinColor", param);
        },
        //设置菜单颜色
        setMenuSkinColor(state, param) {
            state.menuSkin = param;
            window.localStorage.setItem("menuSkinColor", param);
        },
        setMenus(state, par) {
            if (state.menuList.length == 0) state.menuList = global.$menu;
        },
        setRouterConfig(state, par) {
            state.routerConfig = par;
        }
    },
    actions: {
        //获取菜单
        getMenus(context, callBack) {
            global
                .post('/Admin/Menus/SysTree', {}, true)
                .then(data => {
                    var _allList = data.allList;
                    var _list = data.list;
                    var _powerAll = data.powerState;
                    global.$menu = _list;
                    global.$powerAll = _powerAll;
                    if (callBack) callBack(data);
                });
        },
    },
    getters: {}
}
export default main;