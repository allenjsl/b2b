
require.config({
    paths: {
        jquery: 'jquery-1.11.1'
    }
});

require(["jquery", "jquery-ui.1.11.1/autocomplete"], function($1111) {
    var options = {
        source: function(request, response) {
            $1111.ajax({
                url: "/ashx/handler.ashx?dotype=getautocompletedaoyou",
                dataType: "json",
                data: {
                    q: request.term, q1: $1111(request.element).attr("data-dijiesheid")
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
            if (ui.item.DaoYouName != '未匹配到导游，请直接录入，建议录入格式如：张姐 13812345678') {
                $1111(this).val(ui.item.DaoYouName);
            }

            return false;
        },
        minLength: 1,
        close: function(event) {

        },
        change: function(event, item) {

        },
        response: function(event, ui) {

        }
    };

    $("input[data-class='daoyouxuanzeautocomplete']").each(function() {
        $1111(this).autocomplete(options).autocomplete("instance")._renderItem = function(ul, item) {
            return $1111("<li>").append("<a>" + item.DaoYouName + "</a>").appendTo(ul);
        };
    });
});
