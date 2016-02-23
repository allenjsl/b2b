<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouKeMingDan.aspx.cs" Inherits="EyouSoft.PtWeb.DanJu.YouKeMingDan"
    Title="客人名单表" MasterPageFile="~/MP/DanJu.Master" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MP/DanJu.Master" %>
<asp:Content ContentPlaceHolderID="PageYeMei" runat="server" ID="PageYeMei1">
    <asp:PlaceHolder runat="server" ID="phYeMei1" Visible="false">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="41%" rowspan="3" style="padding: 11px 9px; height: 91px;">
                    <asp:Literal runat="server" ID="ltrDanJuTaiTouLogo"><%--<img src="/images/logo.gif" class="djtt_logo">--%></asp:Literal>
                </td>
                <td width="59%" align="center" class="p_title" style="text-align: left;">
                    <asp:Literal runat="server" ID="ltrDanJuTaiTouMingCheng">金芒果商旅网</asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="center" style="text-align: left;">
                    <asp:Literal runat="server" ID="ltrDanJuTaiTouDiZhi">&nbsp;</asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="center" style="text-align: left;">
                    <asp:Literal runat="server" ID="ltrDanJuTaiTouDianHua">&nbsp;</asp:Literal>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="phYeMei2" Visible="false">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td align="center" class="p_title" style="text-align: left;">
                    <asp:Literal runat="server" ID="ltrDanJuTaiTouMingCheng1">金芒果商旅网</asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="center" style="text-align: left; line-height: 22px;">
                    <asp:Literal runat="server" ID="ltrDanJuTaiTouDiZhi1"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="center" style="text-align: left; line-height: 22px;">
                    <asp:Literal runat="server" ID="ltrDanJuTaiTouDianHua1"></asp:Literal>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
</asp:Content>

<asp:Content ID="PageMain1" ContentPlaceHolderID="PageMain" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24">客人名单表</b>
            </td>
        </tr>
    </table>
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <td height="30" align="center" colspan="2"><b style="font-size:16px;"><asp:Literal runat="server" ID="ltrRouteName"></asp:Literal></b></td>
        </tr>
        <tr>
            <th style="width:80px;">出发交通</th>
            <td><asp:Literal runat="server" ID="ltrQuJiaoTong"></asp:Literal></td>
        </tr>
        <tr>
            <th>返程交通</th>
            <td><asp:Literal runat="server" ID="ltrHuiJiaoTong"></asp:Literal></td>
        </tr>
    </table>
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0" class="list">
        <tr>
            <th align="center" width="40">序号</th>
            <th width="100" align="center">姓名</th>
            <th width="60" align="center">类型</th>
            <th width="60" align="center">性别</th>
            <th width="80" align="center">证件</th>
            <th width="" align="center">证件号码</th>
            <th width="120" align="center">游客电话</th>
        </tr>
        <asp:Repeater runat="server" ID="rptYouKe">
            <ItemTemplate>
                <tr>
                    <td align="center"><%#Container.ItemIndex + 1%></td>
                    <td align="center"><%# Eval("TravellerName")%></td>
                    <td align="center"><%#Eval("TravellerType")%></td>
                    <td align="center"><%# Eval("Sex")%></td>
                    <td align="center"><%#Eval("CardType")%></td>
                    <td align="center"><%# Eval("CardNumber")%></td>
                    <td align="center"><%# Eval("Contact")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
        <tr>
            <td colspan="7">暂无游客信息</td>
        </tr>
        </asp:PlaceHolder>
    </table>
</asp:Content>

<asp:Content ContentPlaceHolderID="PageYeJiao" runat="server" ID="PageYeJiao1">
    <table border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
        <tr>
            <td align="left">
                <asp:Literal runat="server" ID="ltrYeJiao"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
