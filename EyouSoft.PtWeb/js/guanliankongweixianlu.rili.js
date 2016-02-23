//关联产品日历 汪奇志
var glkwxlrili = {
    options: { "riliselector": "#guanlianchanpin_rili", "qudate": null, "xianluid": "" }
    //初始化样式
    , _initStyle: function() {
        var s = [];
        s.push('<style type="text\/css">');
        s.push('.guanlianchanpin_rili{z-index: 10; position: absolute; display: none; background:#fff;width:350px; border:1px solid #888;box-shadow:0 1px 3px rgba(0, 0, 0, 0.2);border-radius:4px;}');
        s.push('.guanlianchanpin_rili ul{padding:0px;margin:0px; list-style:none;width:100%; overflow:hidden;}');
        s.push('.guanlianchanpin_rili ul li{padding:0px;margin:0px;list-style:none; float:left;width:50px;height:50px; text-align:center; line-height:50px;}');
        s.push('.guanlianchanpin_rili ul.head{border-radius:4px;}');
        s.push('.guanlianchanpin_rili ul.head li{background:#f6f6f6; line-height:50px; height:50px;}');
        s.push('.guanlianchanpin_rili ul.rili{border-bottom-left-radius:4px;border-bottom-right-radius:4px;}');
        s.push('.guanlianchanpin_rili ul.rili li{border-right:1px solid #d7d7d7;border-bottom:1px solid #d7d7d7;width:49px;}');
        s.push('.guanlianchanpin_rili ul.rili li.rilihead{background:#bdebee; line-height:50px;border-top:1px solid #d7d7d7;}');
        s.push('.guanlianchanpin_rili ul.rili li.right{border-right:0;width:50px;}');
        s.push('.guanlianchanpin_rili ul.rili li.riliday{position:relative; text-align:center;cursor:pointer;}');
        s.push('.guanlianchanpin_rili ul.rili li.on{background:#fff5c4}');
        s.push('.guanlianchanpin_rili ul.rili li.riliday:hover{background:#fff5c4}');
        s.push('.guanlianchanpin_rili ul.rili li.riliday div.day{font-weight:bold;line-height:50px; height:50px;color:#ddd; font-size:26px;}');
        s.push('.guanlianchanpin_rili ul.rili li.riliday div.jiage{color:#666;height:25px;position:absolute;left:0;top:5px;width:100%; overflow:hidden;line-height:25px; color:#fe8700;}');
        s.push('.guanlianchanpin_rili ul.rili li.riliday div.shengyu{color:#666;height:25px;position:absolute;left:0;top:25px;width:100%;overflow:hidden;line-height:25px;color:#25c5ca;}');
        s.push('<\/style');

        $("body").append(s.join("\n"));
    },
    _toXianLuYuDing: function(obj) {
        var _xianLuId = $.trim($(obj).attr("xianluid"));
        if (_xianLuId.length < 1) return false;

        window.location.href = "xianluyuding.aspx?xianluid=" + _xianLuId;
        return false;
    },
    //获取日历HTML riqi:起始日期
    _getRiLiHTML: function(riqi) {
        var year = riqi.getFullYear();
        var month = riqi.getMonth();
        var date1 = new Date(year, month, 1);
        //起始天
        var sd = date1.getDate();
        //起始天星期
        var sdOfWeek = date1.getDay();
        date1.setMonth(date1.getMonth() + 1, 0);
        //结束天
        var fd = date1.getDate();

        var s = [];

        date1.setMonth(date1.getMonth() - 1, 1);

        s.push('<ul class="head">');

        s.push('<li style="width:40px;text-align:center;">');
        s.push('<a href="javascript:void(0)" onclick="glkwxlrili._initRiLi(new Date(' + date1.getFullYear() + ',' + date1.getMonth() + ',1))">上一月</a>');
        s.push('</li>');

        s.push('<li style="width:230px;text-align:center;font-weight:bold;">');
        s.push(year + '年' + (month + 1) + '月');
        s.push('</li>');

        date1.setMonth(date1.getMonth() + 2, 1);

        s.push('<li style="width:40px;text-align:center;">');
        s.push('<a href="javascript:void(0)" onclick="glkwxlrili._initRiLi(new Date(' + date1.getFullYear() + ',' + date1.getMonth() + ',1))">下一月</a>');
        s.push('</li>');

        s.push('<li style="width:40px;text-align:right;">');
        s.push('<a href="javascript:void(0)" onclick="glkwxlrili.close()">关闭</a>&nbsp;&nbsp;');
        s.push('</li>');

        s.push('</ul>');

        s.push('<ul class="rili">');
        s.push('<li class="rilihead">日</li><li class="rilihead">一</li><li class="rilihead">二</li><li class="rilihead">三</li><li class="rilihead">四</li><li class="rilihead">五</li><li class="rilihead right">六</li>');

        //创建前面空白日期
        for (var i = 0; i < sdOfWeek; i++) {
            s.push('<li>&nbsp;</li>')
        }

        do {
            var _liid = 'rili_day_' + year + '_' + (month + 1) + '_' + sd;
            var _riqi = year + '-' + (month + 1) + '-' + sd;
            var _class = "riliday";
            if ((sdOfWeek + sd) % 7 == 0) _class = "riliday right";
            s.push('<li class="' + _class + '" id="' + _liid + '" title="' + _riqi + '" data-riqi="' + _riqi + '">');
            s.push('<div class="day">' + sd + '</div>');
            s.push('<div class="jiage"></div>');
            s.push('<div class="shengyu"></div>');
            s.push("</li>");

            sd++;
        } while (sd <= fd)

        //创建后面空白日期
        var _kbcount = (7 - (sdOfWeek + sd - 1) % 7) % 7;
        for (var i = 0; i < _kbcount; i++) {
            var _class = "";
            if (i == _kbcount - 1) _class = "right";
            s.push('<li class="' + _class + '">&nbsp;</li>')
        }

        s.push('</ul>');

        return s.join('')
    },
    formatJsonDateTime: function(jsonDateTime) {
        var _rgExp = /-?\d+/;
        var _matchResult = _rgExp.exec(jsonDateTime);
        var d = new Date(parseInt(_matchResult[0]));
        return d;
    },
    _initRiLi: function(riqi) {
        var _self = this;
        _self._loading();
        var _html = $(this._getRiLiHTML(riqi));
        _html.find("#rili_day_" + this.options.qudate.getFullYear() + "_" + (this.options.qudate.getMonth() + 1) + "_" + this.options.qudate.getDate()).addClass("on");

        function _get() {
            var _txtriqi = riqi.getFullYear() + "-" + (riqi.getMonth() + 1) + "-1";
            var _cache = $(_self.options.riliselector).data(_txtriqi);
            if (typeof _cache != "undefined" && _cache != null) { _get_callback(_cache); return; }

            var _data = { txtXianLuId: _self.options.xianluid, txtRiQi: _txtriqi };
            $.ajax({ url: "/ashx/handler.ashx?dotype=getguanliankongweixianlu", cache: false, async: true, dataType: "json", data: _data, type: "post",
                success: function(response) {
                    $(_self.options.riliselector).data(_txtriqi, response);
                    _get_callback(response);
                }
            });
        }

        function _set(data) {
            if (typeof data == "undefined" || data != null && data.length == 0) return;
            for (var i = 0; i < data.length; i++) {
                var _qudate = _self.formatJsonDateTime(data[i].QuDate);
                var _liid = 'rili_day_' + _qudate.getFullYear() + '_' + (_qudate.getMonth() + 1) + '_' + _qudate.getDate();
                var _$li = _html.find("#" + _liid);
                _$li.find(".jiage").html(data[i].JieSuanJiaGe1.toFixed(2));
                _$li.find(".shengyu").html("余" + data[i].ShengYuShuLiang);
                _$li.attr("xianluid", data[i].XianLuId);
                _$li.click(function() { _self._toXianLuYuDing(this); });
            }
        }

        function _get_callback(data) {
            _set(data);
            $(_self.options.riliselector).html(_html);
        }

        _get();
    },
    //加载提示
    _loading: function() {
        $(this.options.riliselector).html('<p style="height:50px; line-height:50px;">&nbsp;<b>正在加载数据，请稍候....</b></p>');
    },
    //关闭日历
    close: function() {
        $(this.options.riliselector).hide();
    }
    , init: function(options) {
        if ($(this.options.riliselector).length == 0) { this._initStyle(); $("body").append('<div id="guanlianchanpin_rili" class="guanlianchanpin_rili" />'); }
        this.close();
        var _date = options.qudate.split("-");
        var _date1 = new Date(_date[0], _date[1] - 1, 1);
        this.options.qudate = new Date(_date[0], _date[1] - 1, _date[2]);
        this.options.xianluid = options.xianluid;

        var _objclosestul = $(options.obj).closest("ul");
        var offset = _objclosestul.offset();
        offset.left = offset.left + _objclosestul.width() - 360
        offset.top = offset.top + _objclosestul.height() + 1;
        $(this.options.riliselector).css({ "top": offset.top + "px", "left": offset.left + "px" });

        this._loading();
        $(this.options.riliselector).show();

        this._initRiLi(new Date(_date1.getFullYear(), _date1.getMonth(), 1));
    }
};