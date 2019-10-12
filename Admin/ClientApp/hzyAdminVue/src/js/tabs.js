var tabs = {
    ulInitOffsetLeft: 0, //ul 初始化偏移量
    visibleAreaWidth: 0, //可视区域宽度
    liWidth: 0, //一个li的宽度
    moveSpeed: 0, //移动延迟
    moveLock: true, //移动时锁
    domObj: {
        getAdminTabs() { return document.querySelector('.main-tabs'); },
        getUl() { return this.getAdminTabs().querySelector('ul'); },
        getLis() { return this.getAdminTabs().querySelectorAll('li'); }
    },
    start() {
        tabs.init();
        window.onresize = function() {
            this.console.log('οnresize');
            tabs.init();
        };
        //监听鼠标
        var _ul = tabs.domObj.getUl();
        this.mouseWheel(_ul, function(e, wheelDelta) {
            //console.log(wheelDelta);
            if (wheelDelta > 0) {
                tabs.leftMove();
            } else {
                tabs.rigthMove();
            }
        });
    },
    //初始化
    init() {
        var _adminTabs = tabs.domObj.getAdminTabs();
        if (!_adminTabs) return;
        //选项卡偏移量
        var _tabsOffsetLeft = _adminTabs.offsetLeft;
        //得到选项卡可视区域
        tabs.visibleAreaWidth = window.innerWidth - _tabsOffsetLeft;
        //
        //_adminTabs.style.width = tabs.visibleAreaWidth + 'px';
        //得到一个选项卡宽度
        var _Lis = tabs.domObj.getLis();
        tabs.liWidth = _Lis[0].offsetWidth;
        //计算出ul 的宽度
        var _ul = tabs.domObj.getUl();
        _ul.style.width = (tabs.liWidth * _Lis.length) + 'px';
        //
        tabs.ulInitOffsetLeft = _ul.offsetLeft;
    },
    //设置ul 宽度
    setUlWidth(count) {
        try {
            //计算出ul 的宽度
            var _ul = tabs.domObj.getUl();
            if (_ul) _ul.style.width = (tabs.liWidth * count) + 'px';
        } catch (error) {

        }

    },
    //向左移动
    leftMove() {
        tabs.checkMove(function(_ul, moveVal) { //偏移量
            var _checkVal = (_ul.offsetWidth - tabs.visibleAreaWidth);
            if (_ul.offsetLeft <= -_checkVal) return;
            var _ulOffsetLeft = _ul.offsetLeft;
            var totalOffsetLeft = Math.abs(_ulOffsetLeft) + moveVal;
            //console.log('totalOffsetLeft', totalOffsetLeft);
            tabs.move('-', function(timer) {
                if (_ul.offsetLeft <= -_checkVal) {
                    clearInterval(timer);
                    _ul.style.left = _checkVal; //回归零界点
                    tabs.moveLock = true;
                } else if (_ul.offsetLeft <= -(totalOffsetLeft + tabs.liWidth)) {
                    clearInterval(timer);
                    tabs.moveLock = true;
                } else {
                    _ulOffsetLeft = _ul.offsetLeft - 8;
                    _ul.style.left = _ulOffsetLeft + 'px';
                }
            });
        });
    },
    //向右移动
    rigthMove() {
        tabs.checkMove(function(_ul, moveVal) { //偏移量                
            var _ulOffsetLeft = _ul.offsetLeft;
            if (_ulOffsetLeft >= tabs.ulInitOffsetLeft) return;
            var totalOffsetLeft = Math.abs(_ulOffsetLeft) - moveVal;
            //console.log('totalOffsetLeft', totalOffsetLeft);
            tabs.move('+', function(timer) {
                if (_ulOffsetLeft >= tabs.ulInitOffsetLeft) {
                    clearInterval(timer);
                    _ul.style.left = tabs.ulInitOffsetLeft; //回归零界点
                    tabs.moveLock = true;
                } else if (_ul.offsetLeft >= -totalOffsetLeft) {
                    clearInterval(timer);
                    tabs.moveLock = true;
                } else {
                    _ulOffsetLeft = _ul.offsetLeft + 8;
                    _ul.style.left = _ulOffsetLeft + 'px';
                }
            });
        });
    },
    //检查能否移动
    checkMove: function(callback) {
        if (!tabs.moveLock) return;
        var _ul = tabs.domObj.getUl();
        if (_ul.offsetWidth <= tabs.visibleAreaWidth) return;
        if (callback) callback(_ul, tabs.liWidth * 4);
    },
    //左右移动
    move(operator, callback) {
        tabs.moveLock = false;
        var timer = setInterval(() => {
            callback(timer);
        }, tabs.moveSpeed);
    },
    //鼠标滚轮监听
    mouseWheel(target, callback) {
        //获取兼容事件
        let mouseWheel = (/Firefox/i.test(navigator.userAgent)) ? "DOMMouseScroll" : "mousewheel";
        //IE
        if (document.attachEvent) {
            document.attachEvent('on' + mouseWheel, function(e) {
                if (e.target.parentElement == target) {
                    callback(e, e.wheelDelta);
                }
            })
        }
        //FF、Chrome、Opera、safari
        else {
            document.addEventListener(mouseWheel, function(e) {
                e = e || window.event;
                if (e.target.parentElement == target) {
                    if (e.detail) { //FF
                        callback(e, e.detail * 40);
                    } else {
                        callback(e, e.wheelDelta);
                    }
                }
            })
        }
    }
}

export default tabs;