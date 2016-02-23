<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiHuaXX.aspx.cs" Inherits="EyouSoft.GysWeb.dijie.JiHuaXX" MasterPageFile="~/mp/DiJie.Master" Title="计划信息-计划中心" %>

<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10">
    </div>
    <div class="lineprotitlebox">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">计划信息</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right">
                        当前用您所在位置：&gt;&gt; 计划中心 &gt;&gt; 计划信息
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    
    <div class="yg_bar mt15">
        <ul>
            <li><a href="/danju/dijiejihuadan.aspx?anpaiid=<%=AnPaiId %>" target="_blank">打印计划单</a></li>
        </ul>
    </div>
    <div style="clear: both;">
    </div>
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <td colspan="4" style="font-weight: bold; font-size: 16px; text-align: center;">
                <asp:Literal runat="server" ID="ltrDiJieRouteName">线路名称</asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;" class="td_yuding_biaoti">
                专线商名称：
            </td>
            <td style="width: 39%">
                <asp:Literal runat="server" ID="ltrZxsName"></asp:Literal>
            </td>
            <td style="width: 120px;" class="td_yuding_biaoti">
                专线商线路名称：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrZxsRouteName"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;" class="td_yuding_biaoti">
                专线商团号：
            </td>
            <td style="width: 39%">
                <asp:Literal runat="server" ID="ltrZxsTuanHao"></asp:Literal>
            </td>
            <td style="width: 120px;" class="td_yuding_biaoti">
                人数：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrRenShu"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">
                去程日期：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrQuRiQi"></asp:Literal>
            </td>
            <td class="td_yuding_biaoti">
                去程交通：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrQuJiaoTong"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">
                返程日期：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrHuiRiQi"></asp:Literal>
            </td>
            <td class="td_yuding_biaoti">
                返程交通：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrHuiJiaoTong"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">
                用餐：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrYongCan"></asp:Literal>
            </td>
            <td class="td_yuding_biaoti">
                全陪：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrQuanPei"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">
                导游：
            </td>
            <td>
                <input type="text" class="input1" style="width: 70%;" maxlength="50" id="txtDaoYouName" runat="server" data-class="daoyouxuanzeautocomplete" />
            </td>
            <td class="td_yuding_biaoti">
                接团方式：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrJieTuanFangShi"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">
                结算明细：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrJieSuanXX"></asp:Literal>
            </td>
            <td class="td_yuding_biaoti">
                结算金额：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrJieSuanJinE"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">
                客人信息：
            </td>
            <td colspan="3">
                <asp:Literal runat="server" ID="ltrYouKe"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">
                安排备注：
            </td>
            <td colspan="3">
                <asp:Literal runat="server" ID="ltrBeiZhu"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">
                我方线路名称：
            </td>
            <td colspan="3">
                <input type="text" class="input1" style="width:50%;" maxlength="50" id="txtDiJieRouteName" runat="server"  />
            </td>
        </tr>
    </table>
    
    <div class="mt15" style="font-weight: bold; color: #2f2f2f;">
        客人名单<a name="youkemingdan"></a></div>
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15" style="text-align: center;">
        <tr>
            <td class="td_yuding_biaoti" style="text-align: center; width: 40px;">
                序号
            </td>
            <td class="td_yuding_biaoti" style="text-align: center;">
                姓名
            </td>
            <td class="td_yuding_biaoti" style="text-align: center; width: 60px;">
                类型
            </td>
            <td class="td_yuding_biaoti" style="text-align: center; width: 110px;">
                性别
            </td>
            <td class="td_yuding_biaoti" style="text-align: center; width: 110px;">
                证件类型
            </td>
            <td class="td_yuding_biaoti" style="text-align: center;">
                证件号码
            </td>
            <td class="td_yuding_biaoti" style="text-align: center;">
                联系方式
            </td>
        </tr>
        <asp:Repeater ID="rptYouKe" runat="server">
        <ItemTemplate>
        <tr>
            <td class="tr_youke_item" style="text-align: center;">
                <%# Container.ItemIndex + 1%>
            </td>
            <td class="tr_youke_item" style="text-align: center;">
                <%#Eval("TravellerName")%>
            </td>
            <td class="tr_youke_item" style="text-align: center;">
                <%#Eval("TravellerType")%>
            </td>
            <td class="tr_youke_item" style="text-align: center;">
                <%#Eval("Sex")%>
            </td>
            <td class="tr_youke_item" style="text-align: center;">
                <%#Eval("CardType")%>
            </td>
            <td class="tr_youke_item" style="text-align: center;">
                <%#Eval("CardNumber")%>
            </td>
            <td class="tr_youke_item" style="text-align: center;">
                <%#Eval("Contact")%>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <asp:PlaceHolder runat="server" ID="phYouKeEmpty" Visible="false">
        <tr>
            <td class="tr_youke_item" colspan="7" style="text-align:left;">
                暂无详细客人名单
            </td>
        </tr>
        </asp:PlaceHolder>
    </table>
    
    <div style="margin-top: 20px; color: #2f2f2f;">
        <b>
            <asp:Literal runat="server" ID="ltrTiShiXinXi"></asp:Literal></b></div>
            
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 0px auto; margin-top: 20px; margin-bottom: 15px;">
        <tr>
            <td style="text-align: left;">
                <asp:Literal runat="server" ID="ltrCaoZuo"></asp:Literal>
                <a href="javascript:void(0)" class="baocun" id="a_fanhui">返 回</a>
            </td>
        </tr>
    </table>

    <script data-main="/js/daoyouxuanze.main" src="/js/require.2.1.14.minified.js"></script>
    <link href="/js/jquery-ui.1.11.1/themes/redmond/jquery-ui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            fanHui: function() {
                history.back(); return false;
            },
            baoCun: function(obj) {
                var _data = { txtDaoYouName: $.trim($("#<%=txtDaoYouName.ClientID %>").val()), txtDiJieRouteName: $.trim($("#<%=txtDiJieRouteName.ClientID %>").val()) }
                if (_data.txtDaoYouName.length < 1) { alert("请输入导游"); return false; }
                $(obj).unbind("click").css({ "color": "#666666" });
                var _self = this;
                var _url = window.location.href.replace(/#youkemingdan/, "");
                $.ajax({ type: "post", url: _url + "&dotype=baocun", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") _self.reload();
                        $(obj).click(function() { _self.baoCun(this); }).css({ "color": "" });
                    }
                });
            },
            queRen: function(obj) {
                var _data = { txtDaoYouName: $.trim($("#<%=txtDaoYouName.ClientID %>").val()), txtDiJieRouteName: $.trim($("#<%=txtDiJieRouteName.ClientID %>").val()) }
                if (_data.txtDaoYouName.length < 1) { alert("请输入导游"); return false; }
                if (!confirm("确认计划操作不可逆，你确定要确认该计划吗？")) return false;
                $(obj).unbind("click").css({ "color": "#666666" });
                var _self = this;
                var _url = window.location.href.replace(/#youkemingdan/, "");
                $.ajax({ type: "post", url: _url + "&dotype=queren", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") _self.reload();
                        $(obj).click(function() { _self.queRen(this); }).css({ "color": "" });
                    }
                });
            }
        }

        $(document).ready(function() {
            $("#a_fanhui").click(function() { iPage.fanHui(); });
            $("#a_baocun").click(function() { iPage.baoCun(this); });
            $("#a_queren").click(function() { iPage.queRen(this); });

            var _options = {};
            _options["DaoYouNameClientId"] = "<%=txtDaoYouName.ClientID %>";

            $("#<%=txtDaoYouName.ClientID %>").data("options", _options);
        });
    
    </script>
</asp:Content>
