import adminTabs from "../../js/tabs";

const app = {
    namespaced: true,
    state: {
        isMobile: (window.innerWidth <= 720),
        siderCollapsed: (window.localStorage.getItem("siderCollapsed") == 1), //菜单收展 字段
        headerSkinColor: (window.localStorage.getItem("headerSkinColor")), //头部颜色 字段
        menuSkin: {
            //菜单颜色 字段
            backgroundColor: (window.localStorage.getItem("menuSkinColor") ? JSON.parse(window.localStorage.getItem("menuSkinColor")).backgroundColor : '#545c64'),
            textColor: (window.localStorage.getItem("menuSkinColor") ? JSON.parse(window.localStorage.getItem("menuSkinColor")).textColor : '#fff'),
            activeTextColor: (window.localStorage.getItem("menuSkinColor") ? JSON.parse(window.localStorage.getItem("menuSkinColor")).activeTextColor : '#ffd04b'),
            parentBGColor: (window.localStorage.getItem("menuSkinColor") ? JSON.parse(window.localStorage.getItem("menuSkinColor")).parentBGColor : 'main-aside-color-2'),
        },
        tabs: {
            list: (localStorage.getItem('tabsList') ? JSON.parse(localStorage.getItem('tabsList')) : [{
                title: "首页",
                name: "/Home",
                active: true,
            }]),
        },
        menuList: [],
        routerConfig: [],
    },
    mutations: {
        addOrCheckedTab(state, par) {
            //检测是否重复标签页
            var name = par.name;
            //var title = par.title;
            var list = state.tabs.list;
            for (var i = 0; i < list.length; i++) {
                var item = list[i];
                item.active = false;
            }
            //console.log('par', par);
            var item = state.tabs.list.find(w => w.name == name);
            if (item) {
                item.active = true;
            } else {
                par.active = true;
                state.tabs.list.push(par);
            }

            adminTabs.setUlWidth(list.length);
            localStorage.setItem('tabsList', JSON.stringify(state.tabs.list));
            return;
        },
        removeTab(state, par) {
            var name = state.tabs.list[par - 1].name;
            global.$router.push({ name: name });
            //console.log(state.tabs.list[par - 1]);
            state.tabs.list.splice(par, 1);

            adminTabs.setUlWidth(state.tabs.list.length);
            localStorage.setItem('tabsList', JSON.stringify(state.tabs.list));

            console.log('vuex-this', this);
            //this.commit("main/setKeepAlive", { name: name, keepAlive: false });
            return;
        },
        closeOtherTab(state) {
            var list = state.tabs.list;
            var itemActive = state.tabs.list.find(w => w.active);
            for (var i = 0; i < list.length; i++) {
                if (i == 0) continue;
                var item = list[i];
                if (item.name != itemActive.name) {
                    list.splice(i, 1);
                }
            }
            localStorage.setItem('tabsList', JSON.stringify(state.tabs.list));
        },
        closeAllTab(state) {
            var list = state.tabs.list;
            state.tabs.list = [];
            state.tabs.list.push(list[0]);
            var _hash = window.location.hash;
            if (_hash === "#" + state.tabs.list[0].name) return; //判断路由不能重复加载
            global.$router.push({ name: state.tabs.list[0].name });
            localStorage.setItem('tabsList', JSON.stringify(state.tabs.list));
        },
        //菜单切换事件
        changeSiderCollapsed(state, par) {
            if (par === typeof Boolean) {
                state.siderCollapsed = par;
            } else {
                state.siderCollapsed = !state.siderCollapsed;
            }
            window.localStorage.setItem("siderCollapsed", state.siderCollapsed ? 1 : 0);
        },
        //设置头部颜色
        setHeaderSkinColor(state, par) {
            state.headerSkinColor = par;
            window.localStorage.setItem("headerSkinColor", par);
        },
        //设置菜单颜色
        setMenuSkinColor(state, par) {
            // backgroundColor:
            // textColor:
            // activeTextColor:
            if (par === 1) {
                state.menuSkin = {
                    backgroundColor: "",
                    textColor: "",
                    activeTextColor: "",
                    parentBGColor: "main-aside-color-1",
                };
            } else if (par === 2) {
                state.menuSkin = {
                    backgroundColor: "#545c64",
                    textColor: "#fff",
                    activeTextColor: "#ffd04b",
                    parentBGColor: "main-aside-color-2",
                };
            }
            window.localStorage.setItem("menuSkinColor", JSON.stringify(state.menuSkin));
        },
        setMenus(state, par) {
            if (state.menuList.length == 0) state.menuList = global.$menu;
        },
        getMenus(state, par) {
            return state.menuList;
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
export default app;