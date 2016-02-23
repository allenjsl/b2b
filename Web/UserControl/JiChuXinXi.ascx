<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JiChuXinXi.ascx.cs" Inherits="Web.UserControl.JiChuXinXi" %>
<div style="height: 90px; margin-bottom:5px;" class="lineCategorybox">
<table cellspacing="0" cellpadding="0" border="0" class="xtnav">
    <asp:PlaceHolder runat="server" ID="ph_tr0">
    <tr>
        <asp:PlaceHolder runat="server" ID="ph__3" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_-3" style="height:30px;">
            <a href="CityManage.aspx">城市管理</a>
        </td>
        </asp:PlaceHolder>            
        <asp:PlaceHolder runat="server" ID="ph__1" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_-1">
            <a href="TrafficManage.aspx">交通信息管理</a>
        </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_0" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_0">
            <a href="jichuxinxi.aspx?jichuxinxitype=0">去程时间</a>
        </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_1" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_1">
            <a href="jichuxinxi.aspx?jichuxinxitype=1">回程时间</a>
        </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_9" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_9">
            <a href="jichuxinxi.aspx?jichuxinxitype=9">其它收入项目</a>
        </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_10" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_10">
            <a href="jichuxinxi.aspx?jichuxinxitype=10">其它支出项目</a>
        </td>
        </asp:PlaceHolder>          
        <td colspan="2"></td>  
    </tr>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder runat="server" ID="ph_tr1">
    <tr>
        <asp:PlaceHolder runat="server" ID="ph__2" Visible="false">
            <td width="100" align="center" id="i_jichuxinxi_nav_td_-2">
                <a href="LineManage.aspx">线路区域管理</a>
            </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_6" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_6" style="height:30px;">
            <a href="jichuxinxi.aspx?jichuxinxitype=6">送团信息</a>
        </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_7" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_7">
            <a href="jichuxinxi.aspx?jichuxinxitype=7">目的地接团方式</a>
        </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_8" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_8">
            <a href="jichuxinxi.aspx?jichuxinxitype=8">用餐标准</a>
        </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_2" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_2">
            <a href="jichuxinxi.aspx?jichuxinxitype=2">去程班次</a>
        </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_3" Visible="false">
        <td width="100" align="center" id="i_jichuxinxi_nav_td_3">
            <a href="jichuxinxi.aspx?jichuxinxitype=3">回程班次</a>
        </td>
        </asp:PlaceHolder>        
    </tr>     
    </asp:PlaceHolder>
    
    <asp:PlaceHolder runat="server" ID="ph_tr2">
    <tr>
        <asp:PlaceHolder runat="server" ID="ph_4" Visible="false">
            <td width="100" align="center" id="i_jichuxinxi_nav_td_4">
                <a href="jichuxinxi.aspx?jichuxinxitype=4">集合地点</a>
            </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_5" Visible="false">
            <td width="100" align="center" id="i_jichuxinxi_nav_td_5">
                <a href="jichuxinxi.aspx?jichuxinxitype=5">集合时间</a>
            </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ph_11" Visible="false">
            <td width="100" align="center" id="i_jichuxinxi_nav_td_11">
                <a href="changyongchengshi.aspx">常用城市</a>
            </td>
        </asp:PlaceHolder>
    </tr>  
    </asp:PlaceHolder> 
</table>
</div>
<script type="text/javascript">
    $(document).ready(function() {
        $("#i_jichuxinxi_nav_td_<%=HighlightNav %>").addClass("xtnav-on");
    });
</script>

