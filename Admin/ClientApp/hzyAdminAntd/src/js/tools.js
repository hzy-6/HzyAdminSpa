import { message, Modal, notification } from 'ant-design-vue';

var tools = {
    //加载 loading
    loading: {
        //开始加载
        start() {
            global.$store.commit('app/setLoading', true);
        },
        //关闭加载
        close() {
            global.$store.commit('app/setLoading', false);
        }
    },
    //消息提醒
    msg(text, type = '') {
        if (type == '成功') {
            message.success(text);
        } else if (type == '警告') {
            message.warning(text);
        } else if (type == '错误') {
            message.error(text);
        } else {
            message.info(text);
        }
    },
    //alert
    alert(text, call, type) {
        if (type == '成功') {
            Modal.success({
                content: text,
                onOk() {
                    if (call) call();
                }
            });
        } else if (type == '警告') {
            Modal.warning({
                content: text,
                onOk() {
                    if (call) call();
                }
            });
        } else if (type == '错误') {
            Modal.error({
                content: text,
                onOk() {
                    if (call) call();
                }
            });
        } else {
            Modal.info({
                content: text,
                onOk() {
                    if (call) call();
                }
            });
        }
    },
    //询问
    confirm(text, successCallBack, cancelCallBack, title = '警告') {
        Modal.confirm({
            title: title,
            content: text,
            okText: '确认',
            cancelText: '取消',
            onOk() {
                if (successCallBack) successCallBack();
            },
            onCancel() {
                if (cancelCallBack) cancelCallBack();
            },
        });
    },
    //通知
    notice(text, type, title = "提示") {
        if (type == '成功') {
            notification.success({
                message: title,
                description: text
            });
        } else if (type == '警告') {
            notification.warning({
                message: title,
                description: text
            });
        } else if (type == '错误') {
            notification.error({
                message: title,
                description: text
            });
        } else {
            notification.info({
                message: title,
                description: text
            });
        }
    },
    //建立一個可存取到該file的url  用于上传图片，，可通过该地址浏览图片
    getObjectUrl: function(file) {
        var url = "";
        if (window.createObjectURL != undefined) { // basic
            url = window.createObjectURL(file);
        } else if (window.URL != undefined) { // mozilla(firefox)
            url = window.URL.createObjectURL(file);
        } else if (window.webkitURL != undefined) { // webkit or chrome
            url = window.webkitURL.createObjectURL(file);
        }
        return url;
    },
    //将图片对象转换为 base64
    readFile: function(obj, callBack) {
        var file = obj.files[0];
        var resVal;
        //判断类型是不是图片  
        if (!/image\/\w+/.test(file.type)) {
            alert("请确保文件为图像类型");
            return false;
        }
        var reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = function() {
            //alert(this.result); //就是base64  
            resVal = this.result;
            if (callBack) callBack(resVal);
            //return resVal;
        }

    },
    getCookie: function(name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = top.document.cookie.match(reg))
            return unescape(arr[2]);
        else
            return null;
    },
    delCookie: function(name) {
        var exp = new Date();
        exp.setTime(exp.getTime() - 1);
        var cval = tools.getCookie(name);
        if (cval != null)
            top.document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
    },
    //这是有设定过期时间的使用示例：
    //s20是代表20秒
    //h是指小时，如12小时则是：h12
    //d是天数，30天则：d30
    setCookie: function(name, value, time = 'h12', path = '/') {
        if (!time) time = 'h12';
        var strsec = tools.getSec(time);
        var exp = new Date();
        exp.setTime(exp.getTime() + strsec * 1);
        top.document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + (path ? (";path=" + path) : ";path=/");
    },
    getSec: function(str) {
        var str1 = str.substring(1, str.length) * 1;
        var str2 = str.substring(0, 1);
        if (str2 == "s") {
            return str1 * 1000;
        } else if (str2 == "h") {
            return str1 * 60 * 60 * 1000;
        } else if (str2 == "d") {
            return str1 * 24 * 60 * 60 * 1000;
        }
    },
    guidEmpty: '00000000-0000-0000-0000-000000000000',
    //获取按钮权限
    getPowerState(Id, callBack) {
        global
            .post('/Admin/User/GetPowerState', { MenuId: Id }, true)
            .then(data => { if (callBack) callBack(data.PowerState); });
    }

};

export default tools;