<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PingTaiJiChuXinXiDaoHang.ascx.cs" Inherits="Web.UserControl.PingTaiJiChuXinXiDaoHang" %>
<div style="height: 30px; margin-bottom:5px;" class="lineCategorybox">
<table cellspacing="0" cellpadding="0" border="0" class="xtnav">
    <tr>
        <td width="100" align="center" id="i_pingtaijichuxinxi_nav_td_1">
            <a href="WangZhanJiChuXinXi.aspx">基础信息</a>
        </td>
        <td width="100" align="center" id="i_pingtaijichuxinxi_nav_td_2">
            <a href="WangZhanJiChuXinXi1.aspx">关于我们</a>
        </td>
        <td width="100" align="center" id="i_pingtaijichuxinxi_nav_td_3">
            <a href="WangZhanJiChuXinXi2.aspx">联系方式</a>
        </td>
        <td width="100" align="center" id="i_pingtaijichuxinxi_nav_td_4">
            <a href="WangZhanJiChuXinXi3.aspx">免责声明</a>
        </td>
        <td width="100" align="center" id="i_pingtaijichuxinxi_nav_td_5">
            <a href="http://tongji.baidu.com/" target="_blank">平台流量统计</a>
        </td>
    </tr>
</table>
</div>
<script type="text/javascript">
    function setPingTaiJiChuXinXiDaoHang(index) {
        $("#i_pingtaijichuxinxi_nav_td_" + index).addClass("xtnav-on");
    }
</script>
