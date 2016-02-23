<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.XianLu.Default" MasterPageFile="~/MP/QianTai.Master" Title="旅游线路" %>
<%@ Register Src="~/WUC/LvYouZhuanXian.ascx" TagName="LvYouZhuanXian" TagPrefix="uc1" %>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/js/ajaxpage.js" type="text/javascript"></script>
    <script src="/js/datepicker/wdatepicker.js" type="text/javascript"></script>
    <script src="/js/utilsUri.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
    <uc1:LvYouZhuanXian runat="server" id="LvYouZhuanXian1"></uc1:LvYouZhuanXian>
    
    <div class="mainbox mt10" data-xlqy="1">
        <div class="line_search" style="color:#666;">
            <form method="get">
            <input type="hidden" id="zdid" name="zdid" />
            <input type="hidden" id="zxlbid" name="zxlbid" />
            <ul class="fixed">
                <li>出团日期：</li>
                <li><span class="date_bk" style="width:100px;">
                    <input type="text" class="d_input" id="txtQuDate1" name="txtQuDate1" onfocus="WdatePicker()" style="width:80px;"><a
                        class="ico" href="javascript:void(0)" onclick="WdatePicker({el:'txtQuDate1'})"></a></span></li>
                <li>-</li>
                <li><span class="date_bk" style="width:100px;">
                    <input type="text" class="d_input" id="txtQuDate2" name="txtQuDate2" onfocus="WdatePicker()" style="width:80px;"><a
                        class="ico" href="javascript:void(0)" onclick="WdatePicker({el:'txtQuDate2'})"></a></span></li>
                <li>线路区域：</li>
                <li><select id="txtQuYu" name="txtQuYu">
                        <option value="">-请选择-</option>
                        <asp:Literal runat="server" ID="ltrQuYu"></asp:Literal>
                    </select></li>
                <li>标准：</li>
                <li>
                    <select id="txtBiaoZhun" name="txtBiaoZhun">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun),new string[]{"0"}), "")%>
                    </select>
                </li>
                <li>线路检索：</li>
                <li><span class="date_bk" style="width:150px;">
                    <input type="text" size="12" id="txtRouteName" class="d_input" name="txtRouteName" style="width:140px;"></span></li>
                <li><input type="submit" class="line_sbtn" value=" 查 询 "></li>
            </ul>
            </form>
        </div>
    </div>
    
    <div class="mainbox mt10" data-xlqy="1">
    
        <asp:Repeater ID="rptXianLu" runat="server">
        <ItemTemplate>
        <div class="line_box" data-kongweiid="<%#Eval("KongWeiId") %>" data-xianluid="<%#Eval("XianLuId") %>">
    
       <div class="line_head fixed">
            <div class="line_Headimg"><a href="XianLuXX.aspx?xlid=<%#Eval("XianLuId") %>"><img src="<%#GetXianLuFengMian(Eval("XianLuFengMian")) %>" /></a></div>
            <div class="line_center">
                <dl>
                   <dt><a href="XianLuXX.aspx?xlid=<%#Eval("XianLuId") %>"><%#Eval("XianLuName") %></a></dt>
                   <dd><strong>发团日期：</strong><%# Convert.ToDateTime(Eval("QuDate")).ToString("yyyy-MM-dd")%>   <strong>交通班次：</strong><%#Eval("QuJiaoTongName") %>-<%#Eval("QuBanCi") %> </dd>
                   <dd><strong>旅游天数：</strong><%# Eval("TianShu")%>天    <strong>线路区域：</strong><%#Eval("QuYuname") %></dd>
                   <dd><%#GetBiaoZhun(Eval("XianLuBiaoZhun"),Eval("KongWeiXianLuLeiXing")) %></dd>
                </dl>
            </div>
            
            <div class="line_price">
               <ul>
                  <li><em>成人门市价</em><span class="sr_price" style="color:#ff0000;"><dfn>¥</dfn><strong><%#Eval("XianLuMenShiJiaGe1", "{0:F2}")%></strong></span></li>
                  <li><em>儿童门市价</em><span class="sr_price" style="color: #ff0000;"><dfn>¥</dfn><strong><%#Eval("XianLuMenShiJiaGe2", "{0:F2}")%></strong></span></li>
                  <li class="lineT" data-xianluid="<%#Eval("XianLuId") %>">
                  <%# GetYuDing(Eval("XianLuBiaoZhun"), Eval("KongWeiXianLuLeiXing"), Eval("XianLuId"))%>
                  </li>
               </ul>
            </div>
            
       </div>
       
       <div class="ck_more"><a class="up" href="javascript:void(0)" data-class="gengduoxianlu"></a></div>
       
       <div class="line_more" style="display:none;">
          
       </div>
       
       <div class="ck_more ck_more2" style="display:none;"><a class="down" href="javascript:void(0)" data-class="gengduoxianlu_guanbi"></a></div>
        
    </div>
        </ItemTemplate>
        </asp:Repeater>
      <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
      <br />
      <br />
       <div class="tishi mt10"><img src="../images/sorry.png" />&nbsp;抱歉，未找到或线路已过期，请选择其它分类，谢谢！</div>
                <br />
                <br />
        </asp:PlaceHolder> 
  </div>

    <div class="page" id="page" data-xlqy="1">
    </div>
    
    <uc1:TuiJian ID="TuiJian1" runat="server" />    <script type="text/javascript">
        var pagingConfig = { pageSize: 6, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
    </script>
    <script type="text/javascript">
        var iPage = {
            gengDuoXianLu: function(obj) {
                var _$obj = $(obj);
                var _chaXun = { txtKongWeiId: _$obj.parents('.line_box').attr("data-kongweiid"), txtXianLuId: _$obj.parents('.line_box').attr("data-xianluid"), txtBiaoZhun: '<%=EyouSoft.Common.Utils.GetQueryStringValue("txtBiaoZhun") %>', txtRouteName: '<%=EyouSoft.Common.Utils.GetQueryStringValue("searchkey") %>' };
                var _$lineMore = _$obj.parents('.line_box').find('.line_more');
                var _$shouqi = _$obj.parents('.line_box').find(".ck_more2");

                function _callback(response) {
                    if (response.length == 0) { _$lineMore.html("<span style='font-size:12px; color:#727272'>暂无更多线路！</span><br /><br />"); return; }
                    var s = [];

                    s.push('<ul>');
                    for (var i = 0; i < response.length; i++) {
                        var _data = response[i];

                        s.push('<li class="fixed" data-xianluid="' + _data.XianLuId + '"><div class="line_Headimg">');
                        s.push('<a href="XianLuXX.aspx?xlid=' + _data.XianLuId + '">');
                        var _fengMianFilepath = "/images/line2_no.gif";
                        if (_data.XianLuFengMian.length > 0) _fengMianFilepath = "<%=ErpUrl %>" + _data.XianLuFengMian;
                        s.push('<img src="' + _fengMianFilepath + '" /></a></div>');
                        s.push('<div class="line_center"><dl>');
                        s.push('<dt><a href="XianLuXX.aspx?xlid=' + _data.XianLuId + '">' + _data.XianLuName + '</a></dt>');
                        s.push('<dd>');
                        if (_data.XianLuBiaoZhun > 0) s.push('<s class="icon0' + _data.XianLuBiaoZhun + '">' + _data.XianLuBiaoZhunName + '</s>');
                        if (_data.KongWeiXianLuLeiXing == 1) s.push('<s class="icon00">单订票</s>');
                        s.push('成人门市价：<span class="sr_price" style="color:#ff0000"><dfn>¥</dfn><strong>' + _data.XianLuMenShiJiaGe1.toFixed(2) + '</strong></span>');
                        s.push('儿童门市价：<span class="sr_price" style="color:#ff0000"><dfn>¥</dfn><strong>' + _data.XianLuMenShiJiaGe2.toFixed(2) + '</strong></span></dd>');                       
                        s.push('</dl></div>');

                        if (_data.KongWeiXianLuLeiXing == 1) {
                            s.push('<div class="line_price"><a data-class="yuding" href="javascript:void(0);">立即预定</a></div>');
                        }
                        else {
                            s.push('<div class="line_price"><a href="XianLuXX.aspx?xlid=' + _data.XianLuId + '">查看详细</a></div>');
                        }

                        s.push('</li>');
                    }
                    s.push('</ul>');
                    var _$tr1 = $(s.join(''));
                    _$tr1.find('a[data-class="yuding"]').click(function() { return iPage.yuDing(this); });

                    _$lineMore.html('');
                    _$lineMore.html(_$tr1);
                    _$lineMore.attr("data-isjiazai", "1");
                }

                if (_$obj.attr('class') == "down") {
                    _$obj.removeClass().addClass("up");
                    _$lineMore.css('display', 'none');
                    _$shouqi.hide();
                    return;
                }

                if (_$obj.attr('class') == "up") {
                    _$obj.removeClass().addClass("down");
                    _$lineMore.css('display', 'block');
                    _$shouqi.show();
                }

                if (_$lineMore.attr("data-isjiazai") == "1") {
                    return;
                }

                _$lineMore.html("正在加载更多线路，请稍候...");
                $.ajax({ type: "post", url: "Default.aspx?dotype=getgengduoxianlu", dataType: "json", data: _chaXun, success: function(response) { _callback(response); } });
            },
            yuDing: function(obj) {
                var _m = THYH.getYH();
                if (!_m.isLogin) { alert("请登录后再预订"); return; }

                var _$tr = $(obj).closest("li");
                var _xianLuId = _$tr.attr("data-xianluid");
                window.location.href = "/huiyuan/xianluyuding.aspx?xianluid=" + _xianLuId;
                return false;
            },
            guanBiGengDuoXianLu: function(obj) {
                $(obj).closest("div.line_box").find('a[data-class="gengduoxianlu"]').click();
            }
        };

        $(document).ready(function() {
            master.setDH(1);
            $('a[data-class="gengduoxianlu"]').click(function() { iPage.gengDuoXianLu(this); });
            $('a[data-class="yuding"]').click(function() { return iPage.yuDing(this); });
            $('a[data-class="gengduoxianlu_guanbi"]').click(function() { iPage.guanBiGengDuoXianLu(this); });
            utilsUri.initSearch();
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
</asp:Content>
