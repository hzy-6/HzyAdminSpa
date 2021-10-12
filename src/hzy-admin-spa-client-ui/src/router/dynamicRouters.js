import router from '@/router/index.js'
import store from '@/store/index'

let dynamicRouters = [];
let allRouters = [];
// [{
//     path: '/system/role',
//     name: "system_role",
//     component: import('@/views/system/role'),
//     meta: {title: '角色管理', close: true, keepAlive: true, menuId: '60ae9382-31ab-4276-a379-d3876e9bb783'},
// }]

/**
 * 创建动态路由
 * @param data
 */
function createDynamicRouters(data) {
    for (let i = 0; i < data.length; i++) {
        let item = data[i];
        let path = item.router ? item.router : (item.url ? item.url : '/NotFound');
        if (item.children.length > 0) {
            createDynamicRouters(item.children);
        } else {
            var route = {
                path: path,
                name: item.componentName ? item.componentName : item.id,
                meta: {
                    title: item.name,
                    close: item.close,
                    keepAlive: true,
                    menuId: item.id,
                    parentId: item.parentId,
                    jumpUrl: item.jumpUrl
                },
            };

            if (path && path === '/NotFound') {
                route.redirect = '/NotFound';
            } else {
                route.component = () => import('@/' + item.url);
            }

            dynamicRouters.push(route);
            allRouters.push(route);

        }
    }
}

/**
 * 获取动态路由
 * @param data
 */
export function getDynamicRouters(data) {
    allRouters = []
    createDynamicRouters(data);
    let hasRouteLayout = router.hasRoute("dynamicLayout");
    if (!hasRouteLayout) {
        router.addRoute({
            name: 'dynamicLayout',
            path: '',
            redirect: '/home',
            component: () =>
                import('@/components/layout/layout'),
            children: dynamicRouters
        });
    }

    //store    
    store.commit("app/setAllRouters", allRouters)

    return hasRouteLayout;
}