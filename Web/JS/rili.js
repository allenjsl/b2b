//控位出团日期日历 汪奇志
var rili = {
    options: { "riliselector": "#kongwei_rili", "date": null, "dates": [], "disable": false }
    //初始化样式
    , _initStyle: function() {
        var s = [];
        s.push('<style type="text\/css">');
        s.push('.kongwei_rili{z-index: 10; position: absolute; display: none; background:#fff;width:350px; border:1px solid #bbb;FILTER: progid:dXImageTransform.Microsoft.Shadow(color:black,direction:145,strength:3);-webkit-box-shadow: 4px 4px 8px 5px #999;-moz-box-shadow: 4px 4px 8px 5px #999}');
        s.push('.kongwei_rili ul{padding:0px;margin:0px; list-style:none;width:100%;}');
        s.push('.kongwei_rili ul li{padding:0px;margin:0px;list-style:none; float:left;width:50px;height:50px; text-align:center; line-height:50px;}');
        s.push('.kongwei_rili ul.head li{background:#f6f6f6; line-height:50px; height:50px;}');
        s.push('.kongwei_rili ul.rili li.rilihead{background:#bdebee; line-height:50px;}');
        s.push('.kongwei_rili ul.rili li.rilihead p.p1{line-height:25px;height:25px;}');
        s.push('.kongwei_rili ul.rili li.riliday{}');
        s.push('.kongwei_rili ul.rili li p.day{font-weight:bold;line-height:25px; height:25px;color:#333;}');
        s.push('.kongwei_rili ul.rili li p.disabled{color:#666;line-height:25px; height:25px;}');
        s.push('<\/style');

        $("body").append(s.join("\n"));
    }
    //获取日历HTML date:起始日期
    , _getRiLiHTML: function(date) {
        var year = date.getFullYear();
        var month = date.getMonth();
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
        s.push('<a href="javascript:void(0)" onclick="rili._initRiLi(new Date(' + date1.getFullYear() + ',' + date1.getMonth() + ',1))">上一月</a>');
        s.push('</li>');

        s.push('<li style="width:230px;text-align:center;font-weight:bold;">');
        s.push(year + '年' + (month + 1) + '月');
        s.push('</li>');

        date1.setMonth(date1.getMonth() + 2, 1);

        s.push('<li style="width:40px;text-align:center;">');
        s.push('<a href="javascript:void(0)" onclick="rili._initRiLi(new Date(' + date1.getFullYear() + ',' + date1.getMonth() + ',1))">下一月</a>');
        s.push('</li>');

        s.push('<li style="width:40px;text-align:right;">');
        s.push('<a href="javascript:void(0)" onclick="rili.close()">关闭</a>&nbsp;&nbsp;');
        s.push('</li>');

        s.push('</ul>');

        s.push('<ul class="rili">');
        //s.push('<li class="rilihead">日</li><li class="rilihead">一</li><li class="rilihead">二</li><li class="rilihead">三</li><li class="rilihead">四</li><li class="rilihead">五</li><li class="rilihead">六</li>');
        s.push('<li class="rilihead"><p class="p1"><label for="chk_xingqi_0">日</label></p><p class="p1"><input type="checkbox" id="chk_xingqi_0" name="chk_xingqi" data-xingqi="0" /></p></li>');
        s.push('<li class="rilihead"><p class="p1"><label for="chk_xingqi_1">一</label></p><p class="p1"><input type="checkbox" id="chk_xingqi_1" name="chk_xingqi" data-xingqi="1" /></p></li>');
        s.push('<li class="rilihead"><p class="p1"><label for="chk_xingqi_2">二</label></p><p class="p1"><input type="checkbox" id="chk_xingqi_2" name="chk_xingqi" data-xingqi="2" /></p></li>');
        s.push('<li class="rilihead"><p class="p1"><label for="chk_xingqi_3">三</label></p><p class="p1"><input type="checkbox" id="chk_xingqi_3" name="chk_xingqi" data-xingqi="3" /></p></li>');
        s.push('<li class="rilihead"><p class="p1"><label for="chk_xingqi_4">四</label></p><p class="p1"><input type="checkbox" id="chk_xingqi_4" name="chk_xingqi" data-xingqi="4" /></p></li>');
        s.push('<li class="rilihead"><p class="p1"><label for="chk_xingqi_5">五</label></p><p class="p1"><input type="checkbox" id="chk_xingqi_5" name="chk_xingqi" data-xingqi="5" /></p></li>');
        s.push('<li class="rilihead"><p class="p1"><label for="chk_xingqi_6">六</label></p><p class="p1"><input type="checkbox" id="chk_xingqi_6" name="chk_xingqi" data-xingqi="6" /></p></li>');
        //创建空白日期
        for (var i = 0; i < sdOfWeek; i++) {
            s.push('<li>&nbsp;</li>')
        }

        do {
            var _liid = 'rili_day_' + year + '_' + (month + 1) + '_' + sd;
            var _riqi = year + '-' + (month + 1) + '-' + sd;
            var _chkid = 'chk_day_' + year + '_' + (month + 1) + '_' + sd;
            var _chkdisabled = "";
            var _class = "day";


            if (new Date(year, month, sd) < this.options.date) { _chkdisabled = ' disabled="disabled" '; _class = "disabled"; }

            s.push('<li class="riliday" id="' + _liid + '" title="' + _riqi + '" data-riqi="' + _riqi + '">');
            s.push('<p class="' + _class + '"><label for="' + _chkid + '">' + sd + '</label></p><p class="day"><input type="checkbox" id="' + _chkid + '" ' + _chkdisabled + ' name="chk_day" /></p>');
            s.push("</li>");

            sd++;
        } while (sd <= fd)

        s.push('</ul>');

        return s.join('')
    }
    , _chkClick: function(obj) {
        var _riqi = $(obj).closest("li").attr("data-riqi");
        var _fs = -1;
        if ($(obj).attr("checked")) {
            if (this.options.dates.length == 31) {
                alert("一次最多可选择31个出团日期");
                $(obj).removeAttr("checked");
                return;
            }
            _fs = 1;
            this.options.dates.push(_riqi);
        }
        else {
            _fs = 0;
            this.options.dates.splice($.inArray(_riqi, this.options.dates), 1);
        }

        $("#i_a_riqi").text('当前已选择' + this.options.dates.length + '个出团日期');
        $("#txtRiQi").val(this.options.dates.join(","));

        kongweixianlurili.setKongWeiRiQi(_fs, _riqi);
    }
    //星期click
    , _chkClickXingQi: function(obj) {
        var _$obj = $(obj);
        var _xingQi = _$obj.attr("data-xingqi");
        var _checked = _$obj.attr("checked");
        var _$lis = $(this.options.riliselector).find("ul.rili").find("li");
        var _dayLiCount = _$lis.length;

        if (this.options.dates.length == 31 && _checked) { alert("一次最多可选择31个出团日期"); $(obj).removeAttr("checked"); return; }

        for (var i = 1; i < _dayLiCount / 7; i++) {
            if (this.options.dates.length == 31 && _checked) { break; }
            var _index = i * 7 + parseInt(_xingQi);
            var _$chk = _$lis.eq(_index).find("input[name='chk_day']");
            if (_$chk.length == 0 || _$chk.attr("disabled")) continue;
            if (_$chk.attr("checked") != _checked) {
                if (_checked) _$chk.attr("checked", "checked");
                else _$chk.removeAttr("checked");
                this._chkClick(_$chk);
            }
        }

    }
    , _initRiLi: function(date) {
        var _self = this;
        $(this.options.riliselector).html(this._getRiLiHTML(date));

        $(this.options.riliselector).find('input[type="checkbox"][name="chk_day"]').each(function() {
            var _riqi = $(this).closest("li").attr("data-riqi");
            if ($.inArray(_riqi, _self.options.dates) > -1) $(this).attr("checked", "checked");
            $(this).click(function() { _self._chkClick(this); });

            if (_self.options.disable) $(this).attr("disabled", "disabled");
        });

        $(this.options.riliselector).find('input[type="checkbox"][name="chk_xingqi"]').each(function() {
            if (_self.options.disable) $(this).attr("disabled", "disabled");
            $(this).click(function() { _self._chkClickXingQi(this); });
        });
    }
    //加载提示
    , _loading: function() {
        $(this.options.riliselector).html('<p style="height:50px; line-height:50px;">&nbsp;<b>正在加载数据，请稍候....</b></p>');
    }
    //关闭日历
    , close: function() {
        $(this.options.riliselector).hide();
    }
    , init: function(obj, date) {
        if ($(this.options.riliselector).length == 0) { this._initStyle(); $("body").append('<div id="kongwei_rili" class="kongwei_rili" />'); }
        this.close();
        var _date = date.split("-");
        var _date1 = new Date(_date[0], _date[1] - 1, 1);
        this.options.date = new Date(_date[0], _date[1] - 1, _date[2]);

        var offset = $(obj).offset();
        if ((offset.left + 350) > $(window).width()) offset.left = offset.left + $(obj).width() - 350;
        offset.top = offset.top + $(obj).height() + 2;
        $(this.options.riliselector).css({ "top": offset.top + "px", "left": offset.left + "px" });

        this._loading();
        $(this.options.riliselector).show();

        this._initRiLi(new Date(_date1.getFullYear(), _date1.getMonth(), 1));
        kongweixianlurili.close();
    }
    , intKongWeisRiQis: function() {
        if (typeof kongWeisRiQis == 'undefined') return;
        this.options.disable = true;
        for (var i = 0; i < kongWeisRiQis.length; i++) {
            this.options.dates.push(kongWeisRiQis[i].QuDate);
        }
        $("#i_a_riqi").text("当前已选择" + kongWeisRiQis.length + "个出团日期");
    }
    , getRiQis: function() {
        return this.options.dates;
    }
};
