<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PingTaiJingDianDaoHang.ascx.cs" Inherits="Web.UserControl.PingTaiJingDianDaoHang" %>
<div style="height: 30px; margin-bottom: 5px;" class="lineCategorybox">
    <table cellspacing="0" cellpadding="0" border="0" class="xtnav">
        <tr>
            <td width="100" align="center" id="i_pingtaijingdian_nav_td_1">
                <a href="JingDian.aspx">景点管理</a>
            </td>
            <td width="100" align="center" id="i_pingtaijingdian_nav_td_2">
                <a href="JingDianQuYu.aspx">景点区域管理</a>
            </td>
        </tr>
    </table>
</div>

<script type="text/javascript">
    function setPingTaiJingDianDaoHang(index) {
        $("#i_pingtaijingdian_nav_td_" + index).addClass("xtnav-on");
    }
</script>

