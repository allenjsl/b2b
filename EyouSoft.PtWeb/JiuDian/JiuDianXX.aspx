<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiuDianXX.aspx.cs" Inherits="EyouSoft.PtWeb.JiuDian.JiuDianXX" MasterPageFile="~/MP/QianTai.Master" Title="酒店详情" %>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageWeiZhi" runat="server" ID="PageWeiZhi1">

    <script src="/js/bt.min.js" type="text/javascript"></script>
    
    <div class="lineT_box">
        <div class="lineT_txt">
            酒店 >
            <asp:Literal ID="ChengShiMing" runat="server"></asp:Literal>酒店 >
            <asp:Literal ID="JiuDianName" runat="server"></asp:Literal></div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="mainbox mt20">
        <div class="h_xxT">
            <asp:Literal ID="JDName" runat="server"></asp:Literal><span><asp:Literal ID="XingJi"
                runat="server"></asp:Literal></span></div>
        <div class="h_address fixed">
            <span>
                地址：<asp:Literal ID="DiZhi" runat="server"></asp:Literal>&nbsp;&nbsp;
                联系电话：<asp:Literal ID="LXDianHua" runat="server"></asp:Literal>&nbsp;&nbsp;
                <asp:Literal ID="ltrKaiYeShiJian" runat="server"></asp:Literal>&nbsp;&nbsp;
                <asp:Literal ID="ltrLouCengShuLiang" runat="server"></asp:Literal>&nbsp;&nbsp;
                <asp:Literal ID="ltrZhuangXiuShiJian" runat="server"></asp:Literal>
            </span><a href="javascript:window.history.go(-1)"
                    class="fanhui">返回</a></div>
    </div>
    <div class="mainbox mt20">
   
       <div id="hotel_picbox" class="hotel_picbox">           
          <asp:Literal runat="server" ID="ltrFuJianKuaiSuLiuLan"></asp:Literal>
          <div class="picBig">
              <asp:Repeater ID="ImgBig" runat="server">
              <ItemTemplate>
              <div class="lof-main-item"> <img src="<%#ErpUrl+Eval("Filepath") %>" /></div>
              </ItemTemplate>
              </asp:Repeater>
          </div>

          <div class="picSmall">
            <ul class="picSmall_list">
                <asp:Repeater ID="ImgSmall" runat="server">
                <ItemTemplate>
                <li><img src="<%#ErpUrl+Eval("Filepath") %>" /></li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
          </div>
          
       </div>
       
    </div>
    <div class="mainbox mt10">
        <div class="h_table">
            <table width="100%" border="0">
                <tr>
                    <td align="center" style="width:100px;">
                        房型
                    </td>
                    <td align="center">
                        房型介绍
                    </td>
                    <td align="center" style="width: 80px;">
                        面积
                    </td>
                    <td align="center" style="width: 80px;">
                        数量（间）
                    </td>
                    <td align="center" style="width: 80px;">
                        楼层
                    </td>
                    <td align="center" style="width: 110px;">
                        挂牌价
                    </td>
                    <td align="center" style="width: 150px;">
                        入住日期
                    </td>
                    <td align="center" style="width: 100px;">
                        优惠价
                    </td>
                </tr>
                <asp:Repeater ID="RepFangXing" runat="server">
                    <ItemTemplate>
                        <tr data-fangxingid="<%#Eval("FangXingId") %>">
                            <td align="center">
                                <a href="javascript:void(0)" class="jiudianfangxing"><%# Eval("MingCheng")%></a>
                            </td>
                            <td align="center" style="line-height:22px; text-align:left;">
                                <a href="javascript:void(0)" class="jiudianfangxing"><%# Eval("JieShao")%></a>
                            </td>
                            <td align="center">
                                <%# Eval("MianJi")%></td>
                                <td align="center">
                                    <%# Eval("ShuLiang")%>
                                </td>
                                <td align="center">
                                    <%# Eval("LouCeng")%>
                                </td>
                                <td align="center" >
                                    <span class="sr_price"><dfn>¥</dfn><strong style="vertical-align: middle; text-decoration: line-through;"><%# Eval("GuaPaiJiaGe","{0:F2}")%></strong></span>
                                </td>
                                <td align="center">
                                    <%# Eval("RuZhuRiQi1","{0:yyyy-MM-dd}")%>至<%# Eval("RuZhuRiQi2","{0:yyyy-MM-dd}")%>
                                </td>
                                <td align="center">
                                    <span class="sr_price"><dfn>¥</dfn><strong style="vertical-align: middle;"><%# Eval("YouHuiJiaGe","{0:F2}")%></strong></span>
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    <div class="mainbox mt20">
        <div class="hotel_T">
            <span>酒店详情</span>
        </div>
        <div class="hotel_cont">
            <div class="hotel_xx">
                <div class="leftM">
                    <s class="jieshao"></s>酒店介绍</div>
                <dl>
                    <asp:Literal ID="JieShao" runat="server"></asp:Literal>
                </dl>
            </div>
            <div class="hotel_xx">
                <div class="leftM">
                    <s class="sheshi"></s>网络设施</div>
                <dl>
                    <asp:Literal ID="SheShi" runat="server"></asp:Literal>
                </dl>
            </div>
            <div class="hotel_xx">
                <div class="leftM">
                    <s class="jiaotong"></s>位置交通</div>
                <dl class="last">
                    <asp:Literal ID="JIaoTong" runat="server"></asp:Literal>
                </dl>
            </div>
        </div>
    </div>

    <uc1:TuiJian ID="TuiJian1" runat="server" />
    
    <script type="text/javascript" src="/js/jquery.jiudianfangxing.tupian.js"></script>
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
                    if (_activeLiIndex >= _xiaoTuLis.length-1) return;

                    _xiaoTuLis.eq(_activeLiIndex + 1).click();
                });

                f1();
            }
        };

        var iPage = {
            xianShiFangXing: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _fxid = _$tr.attr("data-fangxingid");
                var _self = this;

                function callback(data) {
                    if (data.length == 0) {
                        $("#jiudianfangxing_fujian").html('<div style="text-align:center;width:770px;">暂无房型图片信息</div>');
                        return;
                    }

                    if (data.length == 1) { data.push(data[0]); data.push(data[0]) }
                    if (data.length == 2) { data.push(data[0]); }

                    var _s = [];
                    _s.push('<ul>');
                    for (var i = 0; i < data.length; i++) {
                        _s.push('<li class="plan"><a href="javascript:void(0)"><img width="760" height="320" src="<%=ErpUrl %>' + data[i].Filepath + '" /></a></li>');
                    }
                    _s.push('</ul>');

                    $("#jiudianfangxing_fujian").html(_s.join(''));
                    $("#jiudianfangxing_fujian_pn").show();
                    $.jdfx_tupian({ direction: 'right' });
                }

                function get1() {
                    var _data = _$tr.data("data-fujian");
                    if (typeof _data != "undefined") {
                        callback(_data); return;
                    }

                    $.ajax({
                        url: "/ashx/handler.ashx?dotype=getfangxingfujian&fangxingid=" + _fxid, cache: true, async: true, dataType: "json",
                        success: function(response) {
                            _$tr.data("data-fujian", response);
                            callback(response);
                        }
                    });
                }

                var _s = [];
                _s.push('<div class="jiudianfangxing_boxy user_boxy">');
                _s.push('<a class="close_btn" href="javascript:void(0)" onclick="iPage.guanBiFangXing()"><em>X</em>关闭</a>');
                _s.push('<div class="jiudianfangxing_focusbox">');
                _s.push('<div id="jiudianfangxing_fullbanner">');
                _s.push('<div class="wrappic" id="jiudianfangxing_fujian">');
                _s.push('<div style="text-align:center;width:770px;">正在加载，请稍候....</div>');
                /*_s.push('<ul>');
                _s.push('<li class="plan"><a href="javascript:void(0)"><img width="950" height="400" src="/images/jdfx_1.jpg" /></a></li>');
                _s.push('<li class="plan"><a href="javascript:void(0)"><img width="950" height="400" src="/images/jdfx_2.jpg" /></a></li>');
                _s.push('<li class="plan"><a href="javascript:void(0)"><img width="950" height="400" src="/images/jdfx_1.jpg" /></a></li>');
                _s.push('<li class="plan"><a href="javascript:void(0)"><img width="950" height="400" src="/images/jdfx_2.jpg" /></a></li>');
                _s.push('</ul>');*/
                _s.push('</div>');
                _s.push('<div class="helper" id="jiudianfangxing_fujian_pn" style="display:none;"><div class="mask-left"></div><div class="mask-right"></div><a href="javascript:void(0);" class="prev arrow-left"></a><a href="javascript:void(0);" class="next arrow-right"></a></div>');
                _s.push('</div>');
                _s.push('</div>');
                _s.push('</div>');
                xianShiZheZhao(_s.join(''));

                get1();
            },
            guanBiFangXing: function() {
                guanBiZheZhao();
                clearInterval(jdfx_tupian_timer);
            }
        }

        $(document).ready(function() {
            master.setDH(3);
            tplh.init();
            $(".jiudianfangxing").click(function() { iPage.xianShiFangXing(this); });
        });
    </script>


    
</asp:Content>
