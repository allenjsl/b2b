
require.config({
    paths: {
        jquery: 'jquery-1.11.1'
    }
});

require(["jquery", "jquery-ui.1.11.1/autocomplete"], function($1111) {
    var options = {
        source: function(request, response) {
            $1111.ajax({
                url: "/ashx/handler.ashx?dotype=getautocompletekehu",
                dataType: "json",
                data: {
                    q: request.term
                },
                success: function(data) {
                    response(data);
                }
            });
        },
        focus: function(event, ui) {
            /*var _id = $1111(this).attr("id");
            var _options = $("#" + _id).data("options");
            $1111("#" + _options.KeHuIdClientId).val(ui.item.kehuid);
            $1111(this).val(ui.item.kehuname);

            wuc.keHuXuanZe_InitDuiFangCaoZuoRen(_options.DuiFangCaoZuoRenClientId, _options.KeHuIdClientId);*/

            return false;
        },
        select: function(event, ui) {
            var _id = $1111(this).attr("id");
            var _options = $("#" + _id).data("options");
            $1111("#" + _options.KeHuIdClientId).val(ui.item.KeHuId);
            $1111(this).val(ui.item.KeHuName);

            wuc.keHuXuanZe_InitDuiFangCaoZuoRen(_options.DuiFangCaoZuoRenClientId, _options.KeHuIdClientId);

            return false;
        },
        minLength: 1,
        close: function(event) {
            var _id = $1111(this).attr("id");
            var _options = $("#" + _id).data("options");
            if ($1111("#" + _options.KeHuIdClientId).val().length == 0) {
                $1111(this).val("");
                wuc.keHuZuanZe_InitDuiFangCaoZuoRenOption(_options.DuiFangCaoZuoRenClientId);
            }
        },
        change: function(event, item) {
            if (typeof item == "undefined" || item == null || typeof item.item == "undefined" || item.item == null) {
                var _id = $1111(this).attr("id");
                var _options = $("#" + _id).data("options");
                $1111(this).val("");
                $1111("#" + _options.KeHuIdClientId).val("");
                wuc.keHuZuanZe_InitDuiFangCaoZuoRenOption(_options.DuiFangCaoZuoRenClientId);
            }
        }
    };

    $("input[data-class='kehuxuanzeautocomplete']").each(function() {
        $1111(this).autocomplete(options).autocomplete("instance")._renderItem = function(ul, item) {
            return $1111("<li>").append("<a>" + item.KeHuName + "</a>").appendTo(ul);
        };
    });
});
