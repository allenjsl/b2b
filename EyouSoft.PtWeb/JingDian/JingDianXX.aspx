<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingDianXX.aspx.cs" Inherits="EyouSoft.PtWeb.JingDian.JingDianXX"
    MasterPageFile="~/MP/QianTai.Master" Title="景点" %>

<asp:Content ContentPlaceHolderID="PageWeiZhi" runat="server" ID="PageWeiZhi1">
    <div class="lineT_box">
        <div class="lineT_txt">
            景点 >
            <asp:Literal ID="ltrJingDianName" runat="server"></asp:Literal></div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="mainbox mt20">
        <div class="h_xxT">
            <asp:Literal ID="ltrJingDianName1" runat="server"></asp:Literal></div>
        <div class="h_address fixed">
            <span>地址：
                <asp:Literal ID="ltrJingDianDiZhi" runat="server"></asp:Literal></span><a href="javascript:window.history.go(-1)"
                    class="fanhui">返回</a></div>
    </div>
    <div class="mainbox mt20">
        <div id="hotel_picbox" class="hotel_picbox">
            <asp:Literal runat="server" ID="ltrFuJianKuaiSuLiuLan"></asp:Literal>
            <div class="picBig">
                <asp:Repeater ID="rptFuJianDaTu" runat="server">
                    <ItemTemplate>
                        <div class="lof-main-item">
                            <img src="<%#ErpUrl+Eval("Filepath") %>" /></div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="picSmall">
                <ul class="picSmall_list">
                    <asp:Repeater ID="rtpFuJianXiaoTu" runat="server">
                        <ItemTemplate>
                            <li>
                                <img src="<%#ErpUrl+Eval("Filepath") %>" /></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <div class="mainbox mt20">
        <div class="hotel_T">
            <span>景点详情</span>
        </div>
        <div class="chakan_box mt20">
            <div class="chakan_cont">
                <asp:Literal ID="ltrJieShao" runat="server"></asp:Literal>
                <p>
                    <a href="javascript:window.history.go(-1)" class="fanhui">返回</a></p>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var tplh = {
            _timer: null,
            init: function() {
                var _daTuDivs = $(".picBig").find("div");
                var _xiaoTuUl = $(".picSmall_list");
                var _xiaoTuLis = $(".picSmall_list").find("li");
                var _xiaoTuCount = _xiaoTuLis.length;
                if (_xiaoTuCount < 1) return;

                if (_xiaoTuCount == 1) {
                    _xiaoTuLis.eq(0).addClass("active");
                    return;
                }

                _daTuDivs.css({ "display": "none" });
                var _self = this;

                function f1() {
                    var _daTuDivs = $(".picBig").find("div");
                    var _xiaoTuUl = $(".picSmall_list");
                    var _xiaoTuLis = $(".picSmall_list").find("li");
                    var _activeLiIndex = _xiaoTuLis.index($(".picSmall_list").find("li.active"));
                    var _nextIndex = _activeLiIndex + 1;
                    if (_nextIndex == _xiaoTuCount) _nextIndex = 0;
                    var _top = (_nextIndex - 1) * 121;
                    if (_nextIndex == 0) _top = 0;
                    _xiaoTuLis.eq(_activeLiIndex).removeClass("active");
                    _xiaoTuLis.eq(_nextIndex).addClass("active");

                    _daTuDivs.eq(_activeLiIndex).fadeOut("fast");
                    _daTuDivs.eq(_nextIndex).fadeOut("fast", function() { _daTuDivs.eq(_nextIndex).fadeIn("slow") });

                    if ((_activeLiIndex > 0 && _activeLiIndex < _xiaoTuCount - 2) || (_nextIndex == 0 && _activeLiIndex == _xiaoTuCount - 1)) {
                        _xiaoTuUl.animate({ marginTop: -_top + "px" }, 1000, "swing", function() { });
                    }

                    _self.timer1 = setTimeout(function() { f1(); }, 3000);
                }

                _xiaoTuLis.click(function() {
                    clearTimeout(_self.timer1);
                    var _daTuDivs = $(".picBig").find("div");
                    var _xiaoTuUl = $(".picSmall_list");
                    var _xiaoTuLis = $(".picSmall_list").find("li");
                    var _activeLiIndex = _xiaoTuLis.index($(".picSmall_list").find("li.active"));
                    var _nextIndex = _xiaoTuLis.index($(this));
                    var _top = (_nextIndex - 1) * 121;
                    _xiaoTuLis.eq(_activeLiIndex).removeClass("active");
                    _xiaoTuLis.eq(_nextIndex).addClass("active");

                    _daTuDivs.eq(_activeLiIndex).fadeOut("fast");
                    _daTuDivs.eq(_nextIndex).fadeOut("fast", function() { _daTuDivs.eq(_nextIndex).fadeIn("slow") })

                    if (_nextIndex > 0 && _nextIndex < _xiaoTuCount - 1) {
                        _xiaoTuUl.animate({ marginTop: -_top + "px" }, 1000, "swing", function() { });
                    }

                    _self.timer1 = setTimeout(function() { f1(); }, 3000);
                });

                $("#span_fujian_shang").click(function() {
                    clearTimeout(_self.timer1);
                    var _xiaoTuLis = $(".picSmall_list").find("li");
                    var _activeLiIndex = _xiaoTuLis.index($(".picSmall_list").find("li.active"));
                    if (_activeLiIndex <= 0) return;

                    _xiaoTuLis.eq(_activeLiIndex - 1).click();
                });

                $("#span_fujian_xia").click(function() {
                    clearTimeout(_self.timer1);
                    var _xiaoTuLis = $(".picSmall_list").find("li");
                    var _activeLiIndex = _xiaoTuLis.index($(".picSmall_list").find("li.active"));
                    if (_activeLiIndex >= _xiaoTuLis.length - 1) return;

                    _xiaoTuLis.eq(_activeLiIndex + 1).click();
                });

                f1();
            }
        };


        $(document).ready(function() {
            master.setDH(4);
            tplh.init();
        });
    </script>

</asp:Content>
