
require.config({
    paths: {
        jquery: 'jquery-1.11.1'
    }
});

require(["jquery", "jquery-ui.1.11.1/autocomplete"], function($1111) {
    var options = {
        source: function(request, response) {
            $1111.ajax({
                url: "/ashx/handler.ashx?dotype=getautocompletezxs",
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
            return false;
        },
        select: function(event, ui) {
            var _id = $1111(this).attr("id");
            var _options = $("#" + _id).data("options");
            $1111("#" + _options.ZxsIdClientId).val(ui.item.ZxsId);
            $1111(this).val(ui.item.ZxsName);

            return false;
        },
        minLength: 1,
        close: function(event) {
            /*var _id = $1111(this).attr("id");
            var _options = $("#" + _id).data("options");
            if ($1111("#" + _options.ZxsIdClientId).val().length == 0) {
                $1111(this).val("");
            }*/
        },
        change: function(event, item) {
            /*if (typeof item == "undefined" || item == null || typeof item.item == "undefined" || item.item == null) {
                var _id = $1111(this).attr("id");
                var _options = $("#" + _id).data("options");
                $1111(this).val("");
                $1111("#" + _options.ZxsIdClientId).val("");
            }*/
        },
        response: function(event, ui) {
            var _id = $1111(this).attr("id");
            var _options = $("#" + _id).data("options");
            $1111("#" + _options.ZxsIdClientId).val("");
        }
    };

    $("input[data-class='zxsxuanzeautocomplete']").each(function() {
        $1111(this).autocomplete(options).autocomplete("instance")._renderItem = function(ul, item) {
            return $1111("<li>").append("<a>" + item.ZxsName + "</a>").appendTo(ul);
        };
    });
});
