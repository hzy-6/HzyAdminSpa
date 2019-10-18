//import Vue from 'vue';
import axios from 'axios';
import qs from 'qs';
import { Loading } from 'element-ui';
import tools from './tools';
//
axios.defaults.timeout = 10000;
axios.defaults.baseURL = '';
let loading;
let isloading = true;
//http request 拦截器
axios.interceptors.request.use(
    config => {
        if (isloading) {
            loading = Loading.service({
                lock: true,
                background: 'rgba(0, 0, 0, 0.1)'
            });
        }
        config.headers = {
            'Content-Type': (config.data.isUpload ? 'multipart/form-data' : 'application/x-www-form-urlencoded; charset=UTF-8'),
            'x-requested-width': 'XMLHttpRequest',
            'Authorization': tools.getCookie('Authorization')
        };
        //如果是上传类型 则 将数据重新组装
        if (!config.data.isUpload) {
            config.data = qs.stringify(config.data);
        }
        return config;
    },
    error => {
        return Promise.reject(error);
    }
);

//http response 拦截器
axios.interceptors.response.use(
    response => {
        if (loading) {
            loading.close();
        }
        var data = response.data;

        if (data.hasOwnProperty('status')) {
            // public enum EMessageBoxStatus
            // {
            //     接口授权码无效 = -3,
            //     服务端异常 = -2,
            //     自定义 = -1,
            //     失败 = 0,
            //     成功 = 1,
            // }

            if (data.status == -3) { //接口授权码无效
                tools.alert(data.msg + '请重新登录!', () => global.$router.push("/Login"));
                return;
            }
            if (data.status == -2) { //服务端异常
                tools.alert(data.msg);
                return;
            }
            if (data.status == 0) { //失败
                tools.msg(data.msg, '错误');
                return;
            }
        }

        return response;
    },
    error => {
        if (error.response.status === 401) {
            global.tools.notice("无权访问!", "错误");
            return global.$router.push('/Login');
        } else
            return Promise.reject(error)
    }
)

/**
 * 封装get方法
 * @param url
 * @param data
 * @param loading 是否有加载效果
 * @returns {Promise}
 */
export function get(url, data = {}, loading = true) {
    isloading = loading;
    return new Promise((resolve, reject) => {
        axios.get(url, {
                data: data
            })
            .then(response => {
                resolve(response.data);
            })
            .catch(err => {
                reject(err)
            })
    })
}

/**
 * 封装post请求
 * @param url
 * @param data
 * @param loading 是否有加载效果
 * @returns {Promise}
 */
export function post(url, data = {}, loading = true) {
    isloading = loading;
    return new Promise((resolve, reject) => {
        axios.post(url, data)
            .then(response => {
                if (response != undefined) {
                    resolve(response.data);
                }
            }, err => {
                reject(err)
            })
    })
}

/**
 * 封装post请求 用于上传文件
 * @param url
 * @param data
 * @param loading 是否有加载效果
 * @returns {Promise}
 */
export function postUpload(url, data = {}, loading = true) {
    isloading = loading;
    if (!data) data = {};
    data.isUpload = true;
    return new Promise((resolve, reject) => {
        axios.post(url, data)
            .then(response => {
                if (response != undefined) {
                    resolve(response.data);
                }
            }, err => {
                reject(err)
            })
    })
}

/**
 * 封装patch请求
 * @param url
 * @param data
 * @param loading 是否有加载效果
 * @returns {Promise}
 */
export function patch(url, data = {}, loading = true) {
    isloading = loading;
    return new Promise((resolve, reject) => {
        axios.patch(url, data)
            .then(response => {
                resolve(response.data);
            }, err => {
                reject(err)
            })
    })
}

/**
 * 封装put请求
 * @param url
 * @param data
 * @param loading 是否有加载效果
 * @returns {Promise}
 */
export function put(url, data = {}, loading = true) {
    isloading = loading;
    return new Promise((resolve, reject) => {
        axios.put(url, data)
            .then(response => {
                resolve(response.data);
            }, err => {
                reject(err)
            })
    })
}