import { createRouter, createWebHashHistory } from 'vue-router';
import tools from '@/scripts/tools';
import defaultRouters from '@/router/defaultRouters';
import { getDynamicRouters } from '@/router/dynamicRouters';
import store from '@/store/index'

const routerHistory = createWebHashHistory(); // createWebHistory();

let router = createRouter({
    history: routerHistory,
    routes: defaultRouters,
    scrollBehavior: () => ({ top: 0 }),//to, from, savedPosition
});

//监听路由
router.beforeEach((to, from, next) => {
    tools.loadingStart();
    // console.log('路由拦截器=>', from, to);

    if (to.fullPath === "/login") {
        return next();
    }

    if (!tools.getAuthorization()) {
        return next('/login');
    }

    //路由和用户信息 处理
    store.dispatch('app/getUserInfo').then(data => {
        //创建动态路由
        let hasRouteLayout = getDynamicRouters(data.menus);
        // console.log(router.getRoutes());
        if (hasRouteLayout) {
            if (getAuthority(data, to)) {
                next()
            } else {
                next('/login');
            }
        } else {
            next(to.fullPath)
        }
    });
});

router.afterEach(() => {
    tools.loadingStop();
});

/**
 * 获取权限
 */
function getAuthority(data, to) {
    let menuId = to.meta.menuId;
    if (!menuId) return true;
    if (!data.menuPowers) return true;
    let power = data.menuPowers.find(w => w.menuId == menuId);
    if (!power) return true;
    // console.log('getAuthority=>', data, 'menuid=>', menuId, 'userId=>', userId, power.display);
    //检查页面是否有 display 权限
    return power.display;
}

export default router