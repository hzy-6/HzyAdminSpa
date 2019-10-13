const app = {
    namespaced: true,
    state: {
        isMobile: (window.innerWidth <= 720),
        loading: false
    },
    mutations: {
        setLoading(state, par) {
            state.loading = !!par;
        }
    },
    actions: {
        // postAuthorize(context, param) {
        //     // setTimeout(() => {
        //     //     context.commit('changePage', { page: 50 })
        //     // }, 2000)
        // },
    },
    getters: {}
}
export default app