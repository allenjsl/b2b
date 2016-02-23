<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XianLu.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.XianLu"
    MasterPageFile="~/MP/HuiYuan.Master" Title="旅游线路" %>

<%@ Register Src="~/WUC/HuiYuanLvYouZhuanXian.ascx" TagName="HuiYuanLvYouZhuanXian"
    TagPrefix="uc1" %>
<%@ Register Src="~/WUC/ZxsXinXi.ascx" TagName="ZxsXinXi" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10"></div>
    <uc1:HuiYuanLvYouZhuanXian runat="server" ID="HuiYuanLvYouZhuanXian1"></uc1:HuiYuanLvYouZhuanXian>
    
    <div data-xlqy="1">
    <%--<div class="title01">选择供应商</div>
        
    <div class="gys_xz mt15">
        <ul>
            <asp:Literal runat="server" ID="ltrZxs"></asp:Literal>
        </ul>
        <div class="clearboth">
        </div>
    </div>--%>
        
    <uc1:ZxsXinXi runat="server" ID="ZxsXinXi1"></uc1:ZxsXinXi>
    
    <asp:Literal runat="server" ID="ltrZuiXinBaoJia"></asp:Literal>
    
    <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0" class="mt15">
        <tr>
            <td width="10" valign="top">
                <img src="/huiyuan/images/yuanleft.gif">
            </td>
            <td>
                <div class="searchbox">
                    <form method="get">
                    <input type="hidden" id="zdid" name="zdid" value="<%=CXZdId %>" />
                    <input type="hidden" id="zxlbid" name="zxlbid" value="<%=CXZxlbId %>" />
                    <input type="hidden" id="zxsid" name="zxsid" value="<%=CXZxsId %>" />
                    
                    出团日期：<span class="date_bk">
                        <input type="text" class="d_input" id="txtQuDate1" name="txtQuDate1" onfocus="WdatePicker()" style="width:80px"><a
                            class="ico" href="javascript:void(0)" onclick="WdatePicker({el:'txtQuDate1'})"></a></span> - <span class="date_bk">
                                <input type="text" class="d_input" id="txtQuDate2" name="txtQuDate2" onfocus="WdatePicker()"
                                    style="width: 80px"><a
                                    class="ico" href="javascript:void(0)" onclick="WdatePicker({el:'txtQuDate2'})"></a></span>&nbsp;线路区域：
                    <select id="txtQuYu" name="txtQuYu">
                        <option value="">-请选择-</option>
                        <asp:Literal runat="server" ID="ltrQuYu"></asp:Literal>
                    </select>
                    &nbsp;标准：
                    <select id="txtBiaoZhun" name="txtBiaoZhun">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun),new string[]{"0"}), "")%>
                    </select>
                    &nbsp;线路检索：
                    <input type="text" size="12" id="txtRouteName" class="searchinput formsize180" name="txtRouteName">
                    <input type="image" src="/huiyuan/images/searchbtn.gif" />
                    </form>
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/huiyuan/images/yuanright.gif">
            </td>
        </tr>
    </table>
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist">
        <tbody>
        <tr>
            <th width="100" align="center">
                出团日期
            </th>
            <th width="150" align="center">
                线路区域
            </th>
            <th width="150" align="center">
                交通信息
            </th>
            <th width="40" align="center">
                天数
            </th>
            <th width="40" align="center">
                剩余
            </th>
            <th align="center" colspan="2">
                线路名称（积分/结算价）
            </th>
            <th width="65" align="center">
                操作
            </th>
        </tr>  
        </tbody>  
        <asp:Repeater runat="server" ID="rptXianLu"><ItemTemplate>
        <tbody>
        <tr data-kongweiid="<%#Eval("KongWeiId") %>" data-xianluid="<%#Eval("XianLuId") %>"
            data-kongweixianluleixing="<%#Eval("KongWeiXianLuLeiXing") %>" class="table_tr_item">
            <td align="center">
                <%#Eval("QuDate","{0:yyyy-MM-dd}")%>&nbsp;(<%#EyouSoft.Common.Utils.ConvertWeekDayToChinese(EyouSoft.Common.Utils.GetDateTime(Convert.ToString(Eval("QuDate"))))%>)
            </td>
            <td align="center">
                <%#Eval("QuYuname") %>
            </td>
            <td align="center">
                <a class="jiaotong" href="javascript:void(0)"><%#Eval("QuJiaoTongName") %>-<%#Eval("QuBanCi") %></a>
                <div style="display: none;">
                    去程交通：<%#Eval("QuJiaoTongName")%><br />
                    去程班次：<%#Eval("QuBanCi")%><br />
                    去程出发地：<%#Eval("QuChuFaDiChengShiName")%><br />
                    去程目的地：<%#Eval("QuMuDiDiChengShiName")%><br />
                    回程交通：<%#Eval("HuiJiaoTongName")%><br />
                    回程程班次：<%#Eval("HuiBanCi")%><br />
                    回程出发地：<%#Eval("HuiChuFaDiChengShiName")%><br />
                    回程目的地：<%#Eval("HuiMuDiDiChengShiName")%>
                </div>
            </td>
            <td align="center">
                <%#Eval("TianShu") %>
            </td>
            <td align="center">
                <%#Eval("PingTaiShengYuShuLiang") %>
            </td>
            <td>
                <%#GetBiaoZhun(Eval("XianLuBiaoZhun"),Eval("KongWeiXianLuLeiXing")) %><%#Eval("XianLuName") %><strong
                    class="fontred">（积分：<%#Eval("XianLuJiFen") %>）</strong><a href="javascript:void(0)"
                        class="xianlu_jiage_a">成人门市价<strong class="fontred"><%#Eval("XianLuMenShiJiaGe1", "{0:F2}")%></strong>
                        儿童门市价<strong class="fontred"><%#Eval("XianLuMenShiJiaGe2", "{0:F2}")%></strong></a><%#GetXianDingRenShu(Eval("XianDingRenShu")) %>
                &nbsp;<%#GetDaYinXingCheng(Eval("XianLuId"),Eval("KongWeiXianLuLeiXing"))%>
                <span style="display:none;" class="xianlu_jiage_span">
                成人结算价：<strong class="fontred"><%#Eval("XianLuJieSuanJiaGe1", "{0:F2}")%></strong><br />
                儿童结算价：<strong class="fontred"><%#Eval("XianLuJieSuanJiaGe2", "{0:F2}")%></strong>
                </span>
            </td>
            <td width="80" align="center">
                <a class="down" href="javascript:void(0)" data-class="gengduoxianlu" data-fs="0"></a>
            </td>
            <td align="center" data-class="caozuo">
                <%#GetCaoZuo(Eval("PingTaiShouKeStatus"),Eval("ShouKeStatus"),Eval("PingTaiShengYuShuLiang"))%>
            </td>
        </tr>
        </tbody>
        </ItemTemplate>
        </asp:Repeater>
        
        <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
        <tbody>
        <tr>
            <td colspan="20" style="font-size:30px;color:#666;"><br/>
                <br />
                <br />
                抱歉，未找到或线路已过期，请选择其它分类，谢谢！<br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        </tbody>
        </asp:PlaceHolder> 
    </table>
    
    <asp:PlaceHolder ID="phPaging" runat="server">
    <div class="page mt15">
        <cc1:ExporPageInfoSelect ID="paging" runat="server" />
    </div>
    </asp:PlaceHolder>
    
    </div>

    <script type="text/javascript" src="/js/MSClass.js"></script>
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            gengDuoXianLu: function(obj) {
                var _$obj = $(obj);
                var _$tr = $(obj).closest("tr");
                var _chaXun = { txtKongWeiId: _$tr.attr("data-kongweiid"), txtXianLuId: _$tr.attr("data-xianluid"), txtBiaoZhun: '<%=EyouSoft.Common.Utils.GetQueryStringValue("txtBiaoZhun") %>', txtRouteName: '<%=EyouSoft.Common.Utils.GetQueryStringValue("txtRouteName") %>' };
                var _$tbody = _$tr.closest("tbody");
                var _$nextTbody = _$tbody.next("tbody.zhankai");

                if (_$obj.attr("data-fs") == "0") _$obj.text("").removeClass("down").addClass("up").attr("data-fs", "1");
                else { _$obj.text("").removeClass("up").addClass("down").attr("data-fs", "0"); _$nextTbody.hide(); return; }

                if (_$nextTbody.length > 0) { _$nextTbody.show(); return; }

                function _callback(response) {
                    if (response.length == 0) { _$nextTbody.html('<tr><td colspan="20">抱歉，暂时没有更多线路。</td></tr>'); return; }

                    var s = [];

                    for (var i = 0; i < response.length; i++) {
                        var _data = response[i];
                        s.push('<tr data-kongweiid="' + _$tr.attr("data-kongweiid") + '" data-xianluid="' + _data.XianLuId + '" data-kongweixianluleixing="' + _data.KongWeiXianLuLeiXing + '">');
                        s.push('<td colspan="5"></td>');
                        s.push('<td colspan="2">');
                        if (_data.XianLuBiaoZhun > 0) s.push('<s class="icon0' + _data.XianLuBiaoZhun + '">' + _data.XianLuBiaoZhunName + '</s>');
                        if (_data.KongWeiXianLuLeiXing == 1) s.push('<s class="icon00">单订票</s>');
                        s.push(_data.XianLuName);
                        s.push('<strong class="fontred">（积分：' + _data.XianLuJiFen + '）</strong>');

                        s.push('<a href="javascript:void(0)" class="xianlu_jiage_a">');
                        s.push('成人门市价<strong class="fontred">' + _data.XianLuMenShiJiaGe1.toFixed(2) + '</strong>');
                        s.push(' 儿童门市价<strong class="fontred">' + _data.XianLuMenShiJiaGe2.toFixed(2) + '</strong>');
                        s.push('</a>')

                        if (_data.XianDingRenShu > 0) {
                            s.push('&nbsp;<span style="color:#2C6504">【每单限制总人数不超过' + _data.XianDingRenShu + '人】</span>');
                        }

                        if (_data.KongWeiXianLuLeiXing != 1) {
                            s.push('&nbsp;<a class="print_btn" href="/danju/xingchengdan.aspx?xianluid=' + _data.XianLuId + '" target="_blank">打印行程</a>');
                            s.push('&nbsp;<a class="print_btn" href="/xianlu/xianluxx.aspx?xlid=' + _data.XianLuId + '" target="_blank">线路详情</a>');
                        }

                        s.push('<span style="display:none;" class="xianlu_jiage_span">');
                        s.push('成人结算价：<strong class="fontred">' + _data.XianLuJieSuanJiaGe1.toFixed(2) + '</strong><br />');
                        s.push('儿童结算价：<strong class="fontred">' + _data.XianLuJieSuanJiaGe2.toFixed(2) + '</strong>')
                        s.push('</span>');

                        s.push('</td>');
                        s.push('<td style="text-align:center">');
                        //s.push('<a class="yudin-btn" href="javascript:void(0)" data-class="yuding">预定</a>')
                        s.push(_$tr.find('td[data-class="caozuo"]').html());
                        s.push('</td>');
                        s.push('</tr>');
                    }

                    var _$tr1 = $(s.join(''));

                    _$tr1.find('a[data-class="yuding"]').click(function() { return iPage.yuDing(this); });
                    _$tr1.find(".xianlu_jiage_a").bt({ contentSelector: function() { return $(this).closest("td").find("span.xianlu_jiage_span").html(); }, positions: ['left'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 180, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });

                    _$nextTbody.html(_$tr1);
                }

                _$tbody.after('<tbody class="zhankai"><tr><td colspan="20">正在加载更多线路，请稍候...</td></tr></tbody>');
                _$nextTbody = _$tbody.next("tbody.zhankai");

                $.ajax({ type: "post", url: "xianlu.aspx?dotype=getgengduoxianlu", dataType: "json", data: _chaXun, success: function(response) { _callback(response); } });
            },
            yuDing: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _xianLuId = _$tr.attr("data-xianluid");

                window.location.href = "xianluyuding.aspx?xianluid=" + _xianLuId;
                return false;
            },
            baoJiaXiaZai: function() {
                var _s = [];
                _s.push('<div class="baojiaxiazai_boxy">');
                _s.push('<span style="position: absolute; top: 10px; font-size: 16px;margin-left:10px;">');
                _s.push($("#div_baojia_biaoti").html());
                _s.push('</span>');
                _s.push('<a class="close_btn" href="javascript:void(0)" onclick="iPage.guanBiBaoJiaXiaZai()"><em>X</em>关闭</a>');
                _s.push($("#i_div_baojiafujian").html());
                _s.push("</div>")
                xianShiZheZhao(_s.join(""));
            },
            guanBiBaoJiaXiaZai: function() {
                guanBiZheZhao();
            },
            initGongGao: function() {
                if ($("#div_gonggao").length == 0) return;
                var _gongGaoWidth = $(".fujian_box").width() - $("#div_baojia_biaoti").outerWidth() - $("#zuixinbaojia_xiazai").outerWidth() - 35;
                new Marquee(["div_gonggao", "ul_gonggao"], 2, 2, _gongGaoWidth, 28, 50, 0, 0);
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $('a[data-class="gengduoxianlu"]').click(function() { iPage.gengDuoXianLu(this); });
            $('a[data-class="yuding"]').click(function() { return iPage.yuDing(this); });
            $('.jiaotong').bt({ contentSelector: function() { return $(this).next("div").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 320, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
            $("#zuixinbaojia_xiazai").click(function() { iPage.baoJiaXiaZai(); });

            $(".xianlu_jiage_a").bt({ contentSelector: function() { return $(this).closest("td").find("span.xianlu_jiage_span").html(); }, positions: ['left'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 180, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });

            iPage.initGongGao();
        });
    </script>
</asp:Content>
