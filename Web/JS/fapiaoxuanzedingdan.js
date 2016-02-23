
define(["jquery", "jquery-ui.1.11.1/autocomplete"], function($1111) {

    function formatJsonDateTime(jsonDateTime) {
        var _rgExp = /-?\d+/;
        var _matchResult = _rgExp.exec(jsonDateTime);
        var d = new Date(parseInt(_matchResult[0]));
        return d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate();
    }

    var faPiaoXianZeDingDan = {}

    var autocomplete_options = {
        source: function(request, response) {
            var _notInDingDanId = [];

            $1111("#table_fapiaomx").find("input[name='txt_mx_dingdanid']").each(function() {
                var _v = $.trim($1111(this).val());
                if (_v.length == 0) return true;
                _notInDingDanId.push(_v);
            });

            var _$tr = $1111(request.element).closest("tr");

            var _keHuId = $1111("#" + faPiaoXianZeDingDan["KeHuIdInputId"]).val();
            var _dingDanId = _$tr.find("input[name='txt_mx_dingdanid']").val();
            
            $1111.ajax({
                url: "/ashx/handler.ashx?dotype=getautocompletefapiaodingdan",
                dataType: "json",
                data: {
                    q: request.term, notindingdanid: _notInDingDanId.join(","), kehuid: _keHuId, dingdanid: _dingDanId
                },
                success: function(data) {
                    response(data);
                }
            });
        },
        focus: function(event, ui) {
            return false;
        },
        select: function(event, ui) {
            var _$tr = $1111(this).closest("tr");
            _$tr.find("input[name='txt_mx_dingdanid']").val(ui.item.DingDanId);
            $1111(this).val(ui.item.DingDanHao);
            _$tr.find("input[name='txt_mx_qudate']").val(formatJsonDateTime(ui.item.QuDate));
            _$tr.find("input[name='txt_mx_jine']").val(ui.item.JinE.toFixed(2));

            return false;
        },
        minLength: 1,
        close: function(event) {
            var _$tr = $1111(this).closest("tr");
            if (_$tr.find("input[name='txt_mx_dingdanid']").length == 0) {
                $1111(this).val("");
                _$tr.find("input[name='txt_mx_qudate']").val("");
                _$tr.find("input[name='txt_mx_jine']").val("");
            }
        },
        change: function(event, item) {
            var _$tr = $1111(this).closest("tr");

            if (typeof item == "undefined" || item == null || typeof item.item == "undefined" || item.item == null) {
                $1111(this).val("");
                _$tr.find("input[name='txt_mx_qudate']").val("");
                _$tr.find("input[name='txt_mx_jine']").val("");
            }

            if (_$tr.find("input[name='txt_mx_dingdanid']").val().length == 0) {
                $1111(this).val("");
                _$tr.find("input[name='txt_mx_qudate']").val("");
                _$tr.find("input[name='txt_mx_jine']").val("");
            }
        }
    };

    faPiaoXianZeDingDan["KeHuIdInputId"] = "";

    faPiaoXianZeDingDan["init"] = function(options) {
        faPiaoXianZeDingDan["KeHuIdInputId"] = options.keHuIdInputId;
        $1111("#" + options.inputId).autocomplete(autocomplete_options).autocomplete("instance")._renderItem = function(ul, item) {
            var _s = [];

            _s.push('<a>'); if (item.DingDanId.length > 0) {
                _s.push("订单号：" + item.DingDanHao);
                _s.push("&nbsp;出团日期：" + formatJsonDateTime(item.QuDate));
                _s.push("&nbsp;订单金额：" + item.JinE.toFixed(2));
            } else {
                _s.push(item.DingDanHao);
            }
            _s.push('</a>');
            return $1111("<li>").append(_s.join('')).appendTo(ul);
        };
    }

    return faPiaoXianZeDingDan;
});
