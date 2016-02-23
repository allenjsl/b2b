<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HuiYuanLvYouZhuanXian.ascx.cs" Inherits="EyouSoft.PtWeb.WUC.HuiYuanLvYouZhuanXian" %>
<div id="i_div_zd_zx">
    <div class="line_menu">
        <ul class="TabTitle" id="i_ul_zhandian">
            <asp:Literal runat="server" ID="ltrZD"></asp:Literal>
        </ul>
        <a class="more" href="javascript:void(0)" id="i_a_gengduozhandian">更多</a>
    </div>
    <div class="TabContent">
        <asp:Literal runat="server" ID="ltrZX"></asp:Literal>
    </div>
</div>

<div class="citybox" id="i_div_zd_gengduo" style="display: none; position: absolute;
    z-index: 1; background: #fff;">
    <div class="city_title">
        <h2>
            全部站点</h2>
        <a href="javascript:void(0)" class="close" id="i_a_guanbigengduo">[关闭]</a>
    </div>
    <div class="city_name">
        <asp:Literal runat="server" ID="ltrZD1"></asp:Literal>
        <br />
        <br />
        <br />
    </div>
</div>

<style type="text/css">
.citybox{ width:385px; border:#ddd solid 1px;}
.city_title { background:#efefef; height:30px;border-bottom:#ddd solid 1px;padding:0 16px; position: relative; }
.city_title h2 {font-size: 14px; color:#333; line-height: 32px; font-weight: bold; float:left; display:inline;}
.city_title .close {position: absolute; display:block; width:11px; height:10px;top: 11px; right: 16px; text-indent:-9999px; background:url(/images/closebox.gif) no-repeat;}
.city_title .close:hover {background:url(/images/closebox2.gif);}
.city_name{ padding:25px 0 0 25px;}
.city_name a{ display:inline-block; color:#2f2f2f; padding-right:25px; padding-bottom:10px;white-space:nowrap;}
.city_name a:hover{color:#25c5ca; text-decoration:underline;}
</style>

<script type="text/javascript">
    var lvYouZhuanXian = {
        zdClick: function(obj) {
            if ($(obj).hasClass("active")) return;
            $("#i_div_zd_zx").find("li[data-class='zhandian']").removeClass("active");
            $(obj).addClass("active");
            $("#i_div_zd_zx").find("div[data-class='zxlb']").addClass("none");
            $("#i_div_zx_zd_" + $(obj).attr("data-zhandianid")).removeClass("none");

            if ($(obj).attr("data-zhandianid") == '<%=Request.QueryString["zdid"] %>') $('div[data-xlqy="1"]').show();
            else $('div[data-xlqy="1"]').hide();
        },
        setZd: function(data) {
            var _$obj = $("#i_li_zd_" + data.zdid);
            if (_$obj.length > 0) { _$obj.click(); return; }
            _$obj = $('<li data-class="zhandian" data-zhandianid="' + data.zdid + '" id="i_li_zd_' + data.zdid + '" ><a href="javascript:void(0);">' + data.mc + '</a></li>');
            _$obj.click(function() { lvYouZhuanXian.zdClick(this); });
            if ($("#i_ul_zhandian").find("li").length > parseInt("<%=XianShiZhanDianShuaLiang %>")) $("#i_ul_zhandian").find("li").eq(6).remove();
            $("#i_ul_zhandian").append(_$obj);
            _$obj.click();
        },
        xianShiGengDuo: function(obj) {
            var _offset = $(obj).offset();
            $("#i_div_zd_gengduo").css({ "top": _offset.top + 35 + "px", "left": _offset.left + $(obj).width() + 8 - $("#i_div_zd_gengduo").width() + "px" });
            $("#i_div_zd_gengduo").show();
        },
        guanBiGengDuo: function() {
            $("#i_div_zd_gengduo").hide();
        },
        zdClick1: function(obj) {
            var _$obj = $(obj);
            var _data = { zdid: _$obj.attr("data-zhandianid"), mc: _$obj.text() };
            this.setZd(_data);
            this.guanBiGengDuo();
        }
    }

    $(document).ready(function() {
        $("#i_div_zd_zx").find("li[data-class='zhandian']").click(function() {
            lvYouZhuanXian.zdClick(this);
        });

        /*$("#i_a_gengduozhandian").click(function() {
            top.Boxy.iframeDialog({ title: "全部站点", iframeUrl: "/gengduozhandian.aspx", width: "380px", height: "180px" });
        });*/
        $("#i_a_guanbigengduo").click(function() { lvYouZhuanXian.guanBiGengDuo(); });
        $("#i_div_zd_gengduo").find("a[data-class='gengduozhandian']").click(function() { lvYouZhuanXian.zdClick1(this); });
        $("#i_a_gengduozhandian").click(function() { lvYouZhuanXian.xianShiGengDuo(this); });
    });
</script>

