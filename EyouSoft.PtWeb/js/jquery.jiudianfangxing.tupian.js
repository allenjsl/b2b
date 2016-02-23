var jdfx_tupian_timer = null;

; (function($) {
    $.extend({
        'jdfx_tupian': function(con) {
            var $container = $('#jiudianfangxing_fullbanner')
                , $imgs = $container.find('li.plan')
            , $leftBtn = $container.find('a.prev')
            , $rightBtn = $container.find('a.next')
            , config = {
                interval: con && con.interval || 3500,
                animateTime: con && con.animateTime || 500,
                direction: con && (con.direction === 'right'),
                _imgLen: $imgs.length
            }
            , i = 0
            , getNextIndex = function(y) { return i + y >= config._imgLen ? i + y - config._imgLen : i + y; }
            , getPrevIndex = function(y) { return i - y < 0 ? config._imgLen + i - y : i - y; }
            , silde = function(d) {
                $imgs.eq((d ? getPrevIndex(2) : getNextIndex(2))).css('left', (d ? '-1540px' : '1540px'))
                $imgs.animate({
                    'left': (d ? '+' : '-') + '=770px'
                }, config.animateTime);
                i = d ? getPrevIndex(1) : getNextIndex(1);
            }
            , s = null;
            jdfx_tupian_timer = setInterval(function() { silde(config.direction); }, config.interval);
            $imgs.eq(i).css('left', 0).end().eq(i + 1).css('left', '770px').end().eq(i - 1).css('left', '-770px');
            $container.find('.wrappic').add($leftBtn).add($rightBtn).hover(function() { clearInterval(jdfx_tupian_timer); }, function() { jdfx_tupian_timer = setInterval(function() { silde(config.direction); }, config.interval); });
            $leftBtn.click(function() {
                if ($(':animated').length === 0) {
                    silde(false);
                }
            });
            $rightBtn.click(function() {
                if ($(':animated').length === 0) {
                    silde(true);
                }
            });
        }
    });
} (jQuery));
