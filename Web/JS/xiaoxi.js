//xiaoxi 汪奇志 2014-08-21

var xiaoXi = {
    options: { "selectorid": "i_a_wodexiaoxi", "delay": 60000, "xiaoxitiselectorid": "i_div_wodexiaoxi", xiaoxileixing: ["未确认订单", "申请中订单", "名单不全订单", "预留订单", "未确认兑换订单", "未审核注册用户"], cacheexpiration: 20000 }
    , _initStyle: function() {
        var s = [];
        s.push('<style type="text\/css">');
        s.push('.wodexiaoxi{z-index: 10; position: absolute; display: none; background:#fff;width:180px;min-height:150px; border:1px solid #888;box-shadow:0 1px 3px rgba(0, 0, 0, 0.2);border-radius:4px;}');
        s.push('.wodexiaoxi ul{padding:0px;margin:0px; list-style:none;width:100%; margin:0 auto;}');
        s.push('.wodexiaoxi ul li{padding:0px;margin:0px;list-style:none;width:100%;height:25px; line-height:25px; cursor:pointer;color:#333;font-family:"Microsoft Yahei";border-radius:4px;}');
        s.push('.wodexiaoxi ul li.close{}');
        s.push('.wodexiaoxi ul li.close1{margin-top:10px;}');
        s.push('.wodexiaoxi ul li.item{}');
        s.push('.wodexiaoxi ul li.loading{}');
        s.push('.wodexiaoxi ul li:hover{background:#efefef;color:#ff6600;}');
        s.push('.wodexiaoxi ul li span{margin-left:10px;}');
        s.push('.wodexiaoxi ul a{color:#333; text-decoration:none;}');
        s.push('.wodexiaoxi ul a:hover{color:#ff6600;}');
        s.push('<\/style');
        $("body").append(s.join("\n"));
    }
    , _setCache: function(data) {
        $("#" + this.options.xiaoxitiselectorid).data("xiaoxi-time", new Date().getTime());
        $("#" + this.options.xiaoxitiselectorid).data("xiaoxi-data", data);
    }
    , _getCache: function() {
        var _time = $("#" + this.options.xiaoxitiselectorid).data("xiaoxi-time");
        var _data = $("#" + this.options.xiaoxitiselectorid).data("xiaoxi-data");

        if (typeof _time == "undefined") return null;
        if (typeof _data == "undefined") return null;

        var _time1 = new Date().getTime();

        var _cha = _time1 - _time;

        if (_cha < this.options.cacheexpiration) return _data;

        return null;
    }
    , _getXiaoXi: function(callback) {
        var _async = false;
        if (typeof callback == "function") _async = true;
        var _data = [];
        var _self = this;
        _data = this._getCache();

        if (_data != null) {
            if (_async) callback(_data);

            return _data;
        }

        $.ajax({
            url: "/ashx/handler.ashx?dotype=getxiaoxi", cache: false, async: _async, dataType: "json",
            success: function(response) {
                _data = response;
                if (_async) {
                    _self._setCache(_data);
                    callback(_data);
                }
            }
        });
        _self._setCache(_data);
        return _data;
    }
    , _getShuLiang: function() {
        var _self = this;
        function _initShuLaing(data) {
            var _shuLiang = 0;
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    _shuLiang += data[i].ShuLiang;
                }
            }
            $("#" + _self.options.selectorid).html('<b>' + _shuLiang + "</b>个消息");

            setTimeout(function() { _self._getShuLiang(); }, _self.options.delay);
        }

        this._getXiaoXi(_initShuLaing);
    }
    , _close: function() {
        $("#" + this.options.xiaoxitiselectorid).hide();
    }
    , _goto: function(obj) {
        var _lx = $(obj).attr("data-lx");
        var _url = "";

        switch (_lx) {
            case "0": _url = "/teamplan/planlist.aspx?txtDingDanStatus=4"; break;
            case "1": _url = "/teamplan/planlist.aspx?txtDingDanStatus=6"; break;
            case "2": _url = "/teamplan/planlist.aspx?txtDingDanStatus=5"; break;
            case "3": _url = "/teamplan/planlist.aspx?txtDingDanStatus=0"; break;
            case "4": _url = "/pingtai/jifendingdan.aspx?txtDingDanStatus=0"; break;
            case "5": _url = "/customermanage/zhucekehu.aspx?txtShenHeStatus=0"; break;
            default: break;
        }

        if (_url.length > 0) window.location.href = _url;
    }
    , _xianShiXiaoXi: function() {
        var _self = this;
        var _offset = $("#" + this.options.selectorid).offset();
        if ((_offset.left + 180) > $(window).width()) _offset.left = _offset.left + $("#" + this.options.selectorid).width() - 175;
        else _offset.left = _offset.left - 5;
        _offset.top = _offset.top + $("#" + this.options.selectorid).height() + 2;
        $("#" + this.options.xiaoxitiselectorid).css({ "top": _offset.top + "px", "left": _offset.left + "px" });
        $("#" + this.options.xiaoxitiselectorid).html('<ul><li class="loading"><span>正在加载....</span><li></ul>');
        $("#" + this.options.xiaoxitiselectorid).show();

        var _data = this._getXiaoXi();
        var _s = [];
        _s.push('<ul>');
        if (_data.length > 0) {
            for (var i = 0; i < _data.length; i++) {
                _s.push('<li class="item" data-lx="' + _data[i].LeiXing + '"><span>');
                _s.push(this.options.xiaoxileixing[_data[i].LeiXing] + "（<b>" + _data[i].ShuLiang + '</b>）');
                _s.push('</span></li>');
            }

            _s.push('<li class="close"><span>关闭消息</span></li>')
        } else {
            _s.push('<li class="close1"><span>暂无消息，点击关闭</span></li>');
        }

        _s.push('</ul>');

        $("#" + this.options.xiaoxitiselectorid).html(_s.join(''));

        $("#" + this.options.xiaoxitiselectorid).find(".close,.close1").click(function() { _self._close(); });
        $("#" + this.options.xiaoxitiselectorid).find(".item").click(function() { _self._goto(this); });
    }
    , init: function() {
        var _self = this;
        this._initStyle();
        $("body").append('<div id="' + this.options.xiaoxitiselectorid + '" class="wodexiaoxi" />');
        $("#" + this.options.selectorid).mouseover(function() { _self._xianShiXiaoXi(); });

        this._getShuLiang();
    }
};

$(document).ready(function() { xiaoXi.init(); });
