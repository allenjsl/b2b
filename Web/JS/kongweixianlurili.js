//控位线路日历 汪奇志
var kongweixianlurili = {
    options: { "riliselector": "#kongwei_xianlu_rili", "date": null, "dates": [], "rowindex": 0 }
    //初始化样式
    , _initStyle: function() {
        var s = [];
        s.push('<style type="text\/css">');
        s.push('.kongwei_xianlu_rili{z-index: 10; position: absolute; display: none; background:#fff;width:280px; border:1px solid #bbb;FILTER: progid:dXImageTransform.Microsoft.Shadow(color:black,direction:145,strength:3);-webkit-box-shadow: 4px 4px 8px 5px #999;-moz-box-shadow: 4px 4px 8px 5px #999}');
        s.push('.kongwei_xianlu_rili ul{padding:0px;margin:0px; list-style:none;width:100%;}');
        s.push('.kongwei_xianlu_rili ul li{padding:0px;margin:0px;list-style:none; float:left;width:40px;height:40px; text-align:center; line-height:40px;}');
        s.push('.kongwei_xianlu_rili ul.head li{background:#f6f6f6; line-height:40px; height:40px;}');
        s.push('.kongwei_xianlu_rili ul.rili li.rilihead{background:#bdebee; line-height:40px;}');
        s.push('.kongwei_xianlu_rili ul.rili li.riliday{}');
        s.push('.kongwei_xianlu_rili ul.rili li p.day{font-weight:bold;line-height:20px; height:20px;color:#333;}');
        s.push('.kongwei_xianlu_rili ul.rili li p.disabled{color:#666;line-height:20px; height:20px;}');
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
        s.push('<a href="javascript:void(0)" onclick="kongweixianlurili._initRiLi(new Date(' + date1.getFullYear() + ',' + date1.getMonth() + ',1))">上一月</a>');
        s.push('</li>');

        s.push('<li style="width:160px;text-align:center;font-weight:bold;">');
        s.push(year + '年' + (month + 1) + '月');
        s.push('</li>');

        date1.setMonth(date1.getMonth() + 2, 1);

        s.push('<li style="width:40px;text-align:center;">');
        s.push('<a href="javascript:void(0)" onclick="kongweixianlurili._initRiLi(new Date(' + date1.getFullYear() + ',' + date1.getMonth() + ',1))">下一月</a>');
        s.push('</li>');

        s.push('<li style="width:40px;text-align:right;">');
        s.push('<a href="javascript:void(0)" onclick="kongweixianlurili.close()">关闭</a>&nbsp;&nbsp;');
        s.push('</li>');

        s.push('</ul>');

        s.push('<ul class="rili">');
        s.push('<li class="rilihead">日</li><li class="rilihead">一</li><li class="rilihead">二</li><li class="rilihead">三</li><li class="rilihead">四</li><li class="rilihead">五</li><li class="rilihead">六</li>');

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
            s.push('<p class="' + _class + '"><label for="' + _chkid + '">' + sd + '</label></p><p class="day"><input type="checkbox" id="' + _chkid + '" ' + _chkdisabled + ' /></p>');
            s.push("</li>");

            sd++;
        } while (sd <= fd)

        s.push('</ul>');

        return s.join('')
    }
    , _chkClick: function(obj) {
        var _riqi = $(obj).closest("li").attr("data-riqi");
        var _fs = -1;
        if ($(obj).attr("checked")) _fs = 1;
        else _fs = 0;

        var _riqis = this._getXlItemRiQis();
        if (_fs == 0 && _riqis.length == 1) { alert("至少要保留一个日期"); $(obj).attr("checked", "checked"); return; }

        if (_fs == 0) _riqis.splice($.inArray(_riqi, _riqis), 1);
        if (_fs == 1) _riqis.push(_riqi);

        var _xlItem = this._getXlItem();
        _xlItem.find("textarea[name='txt_xl_riqi']").val(JSON.stringify(_riqis));
        _xlItem.find("a.a_xl_riqi").text('共' + _riqis.length + '个日期，点击查看');
    }
    , _initRiLi: function(date) {
        var _self = this;
        $(this.options.riliselector).html(this._getRiLiHTML(date));
        var _riqis = this._getXlItemRiQis();

        $(this.options.riliselector).find('input[type="checkbox"]').attr("disabled", "disabled");

        $(this.options.riliselector).find('input[type="checkbox"]').each(function() {
            var _riqi = $(this).closest("li").attr("data-riqi");
            if ($.inArray(_riqi, _riqis) > -1) {
                $(this).attr("checked", "checked");
            }
            if ($.inArray(_riqi, rili.options.dates) > -1) {
                $(this).click(function() { _self._chkClick(this); });
                $(this).removeAttr("disabled");
            }
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
        if ($(this.options.riliselector).length == 0) { this._initStyle(); $("body").append('<div id="kongwei_xianlu_rili" class="kongwei_xianlu_rili" />'); }
        this.close();
        var _date = date.split("-");
        var _date1 = new Date(_date[0], _date[1] - 1, 1);
        this.options.date = new Date(_date[0], _date[1] - 1, _date[2]);

        var offset = $(obj).offset();
        if ((offset.left + 280) > $(window).width()) offset.left = offset.left + $(obj).width() - 280;
        offset.top = offset.top + $(obj).height() + 2;
        $(this.options.riliselector).css({ "top": offset.top + "px", "left": offset.left + "px" });

        this._loading();
        this.options.rowindex = $(".a_xl_riqi").index($(obj));
        $(this.options.riliselector).show();
        this._initRiLi(new Date(_date1.getFullYear(), _date1.getMonth(), 1));
        rili.close();
    }
    , setKongWeiRiQi: function(fs, riqi) {
        var _xlitems = this._getXlItems();
        var _self = this;
        _xlitems.each(function() {
            var _riqis = _self._getXlItemRiQis(this);
            if (fs == 1) _riqis.push(riqi);
            if (fs == 0 && $.inArray(riqi, _riqis) > -1) _riqis.splice($.inArray(riqi, _riqis), 1);

            /*for (var i = _riqis.length - 1; i >= 0; i--) {
            if ($.inArray(_riqis[i], rili.options.dates) == -1) {
            _riqis.splice(i, 1);
            }
            }*/

            $(this).find("textarea[name='txt_xl_riqi']").val(JSON.stringify(_riqis));

            $(this).find("a.a_xl_riqi").text('共' + _riqis.length + '个日期，点击查看');
        });
    }
    , _getXlItems: function() {
        return $("#table_xl tr.xlitem");
    }
    , _getXlItem: function(obj) {
        if (obj != null && typeof obj != "undefined") return $(obj);
        var _xlitems = this._getXlItems();
        return $(_xlitems[this.options.rowindex]);
    }
    , _getXlItemRiQis: function(obj) {
        var _xlitem = this._getXlItem(obj);
        var _riqis = [];
        var _s = _xlitem.find("textarea[name='txt_xl_riqi']").val();
        if (_s.length > 0) _riqis = JSON.parse(_s);

        return _riqis;
    }    
    , initXlItems: function() {
        var _xlItems = this._getXlItems();
        _xlItems.find("textarea[name='txt_xl_riqi']").val("[]");
        
        kongweixianlu.initRpt();
    }
};

//控位线路处理 汪奇志
var kongweixianlu = {
    _xls: []
    , _isinitddp: false
    , _getXlItems: function() {
        return $("#table_xl tr.xlitem");
    }
    , _getXlItem: function(rowindex) {
        var _items = this._getXlItems();
        return _items.eq(rowindex);
    }
    , _insertXlItem: function() {
        var _$trs = this._getXlItems();
        var _$tr = _$trs.eq(0).clone(true);
        _$tr.find("input").val("");
        _$tr.find("textarea").val("[]");
        _$tr.find("a.a_xl_riqi").text('共0个日期，点击查看');
        _$tr.find(".xlindex").html(_$trs.length + 1);
        $("#table_xl").append(_$tr);
    }
    , _getXlInfo: function(routeid) {
        var _info = { routeid: "", rowindex: -1, isinitjiben: false };
        for (var i = 0; i < this._xls.length; i++) {
            if (this._xls[i].routeid == routeid) {
                _info = this._xls[i];
                break;
            }
        }
        var _isInsert = false;
        if (_info.rowindex == -1) {
            _info.routeid = routeid;
            _info.rowindex = this._xls.length;
            _info.isinitjiben = false;
            _isInsert = true;
            this._xls.push(_info);
        }

        if (_isInsert && _info.rowindex > 0) {
            this._insertXlItem();
        }

        return _info;
    }
    , _getKongWeiRiQi: function(kongWeiId) {
        var _riqi = "";
        if (typeof kongWeisRiQis == 'undefined') return _riqi;
        for (var i = 0; i < kongWeisRiQis.length; i++) {
            var _item = kongWeisRiQis[i];
            if (_item.KongWeiId == kongWeiId) { _riqi = _item.QuDate; break; }
        }
        return _riqi;
    }
    , _getXlItemRiQis: function(rowindex) {
        var _xlitem = this._getXlItem(rowindex);
        var _riqis = [];
        var _s = _xlitem.find("textarea[name='txt_xl_riqi']").val();
        if (_s.length > 0) _riqis = JSON.parse(_s);

        return _riqis;
    }
    , _setXlItemRiQi: function(rowindex, riqi) {
        if (riqi == "") return;
        var _riqis = this._getXlItemRiQis(rowindex);

        if ($.inArray(riqi, _riqis) == -1) {
            _riqis.push(riqi);
            var _xlitem = this._getXlItem(rowindex);
            _xlitem.find("textarea[name='txt_xl_riqi']").val(JSON.stringify(_riqis));
            _xlitem.find("a.a_xl_riqi").text('共' + _riqis.length + '个日期，点击查看');
        }
    }
    , _initXlItem: function(xlinfo, info) {
        var _$tr = this._getXlItem(xlinfo.rowindex);

        if (!xlinfo.isinitjiben) {
            _$tr.find("input[name='txt_xl_routeid']").val(info.RouteId);
            _$tr.find("input[name='txt_xl_routename']").val(info.RouteName);
            _$tr.find("input[name='txt_xl_menshijiage1']").val(info.MenShiJiaGe1.toFixed(2));
            _$tr.find("input[name='txt_xl_menshijiage2']").val(info.MenShiJiaGe2.toFixed(2));
            _$tr.find("input[name='txt_xl_menshijiage3']").val(info.MenShiJiaGe3.toFixed(2));
            _$tr.find("input[name='txt_xl_jiesuanjiage1']").val(info.JieSuanJiaGe1.toFixed(2));
            _$tr.find("input[name='txt_xl_jiesuanjiage2']").val(info.JieSuanJiaGe2.toFixed(2));
            _$tr.find("input[name='txt_xl_jiesuanjiage3']").val(info.JieSuanJiaGe3.toFixed(2));
            _$tr.find("input[name='txt_xl_quanpeijiage']").val(info.QuanPeiJiaGe.toFixed(2));
            _$tr.find("input[name='txt_xl_bufangchajiage']").val(info.BuFangChaJiaGe.toFixed(2));
            _$tr.find("input[name='txt_xl_tuifangchajiage']").val(info.TuiFangChaJiaGe.toFixed(2));
            _$tr.find("input[name='txt_xl_jifen']").val(info.JiFen);
            _$tr.find("select[name='txt_xl_status']").val(info.Status);
            _$tr.find("input[name='txt_xl_paixuid']").val(info.PaiXuId);
            _$tr.find("input[name='txt_xl_xiandingrenshu']").val(info.XianDingRenShu);
            _$tr.find("input[name='txt_xl_zuixiaorenshu']").val(info.ZuiXiaoRenShu);

            _$tr.find("span.span_xianlucode").html(info.XianLuCode);

            xlinfo.isinitjiben = true;
        }

        if (kongWeiCaoZuoFangShi == "UPDATE") {
            var _riqi = this._getKongWeiRiQi(info.KongWeiId);
            this._setXlItemRiQi(xlinfo.rowindex, _riqi);
        }
    }
    , _initDanDingPiao: function(info) {
        if (this._isinitddp) return;
        var _$table = $("#table_ddp");
        _$table.find("input[name='txt_ddp_menshijiage1']").val(info.MenShiJiaGe1.toFixed(2));
        _$table.find("input[name='txt_ddp_menshijiage2']").val(info.MenShiJiaGe2.toFixed(2));
        _$table.find("input[name='txt_ddp_menshijiage3']").val(info.MenShiJiaGe3.toFixed(2));
        _$table.find("input[name='txt_ddp_jiesuanjiage1']").val(info.JieSuanJiaGe1.toFixed(2));
        _$table.find("input[name='txt_ddp_jiesuanjiage2']").val(info.JieSuanJiaGe2.toFixed(2));
        _$table.find("input[name='txt_ddp_jiesuanjiage3']").val(info.JieSuanJiaGe3.toFixed(2));
        _$table.find("select[name='txt_ddp_status']").val(info.Status);
        this._isinitddp = true;
    }
    //修改时是否有绑定线路 要是未绑定线路初始化第一行适用日期
    , _initRpt_0: function() {        
        if (kongWeiCaoZuoFangShi != "UPDATE") return;
        var _v = false;
        if (typeof kongWeisXls == "undefined" || kongWeisXls == null || kongWeisXls.length == 0) {
            _v = true;
        } else {
            _v = true;
            for (var i = 0; i < kongWeisXls.length; i++) {
                if (kongWeisXls[i].LeiXing == 0) { _v = false; break; }
            }
        }
        if (!_v) return;
        var _$tr = this._getXlItem(0);
        var _riqis = rili.getRiQis();
        _$tr.find("textarea").val(JSON.stringify(_riqis));
        _$tr.find("a.a_xl_riqi").text('共' + _riqis.length + '个日期，点击查看');
    }
    , initRpt: function() {
        this._initRpt_0();
        if (typeof kongWeisXls == "undefined") return;
        if (kongWeisXls == null || kongWeisXls.length == 0) return;

        for (var i = 0; i < kongWeisXls.length; i++) {
            var _item = kongWeisXls[i];
            if (_item.LeiXing == 1) { this._initDanDingPiao(_item); continue; }
            var _xlinfo = this._getXlInfo(_item.RouteId);
            this._initXlItem(_xlinfo, _item);
        }
    }
};
