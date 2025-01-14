﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="privs.aspx.cs" Inherits="Web.Webmaster._privs" MasterPageFile="~/Webmaster/mpage.Master" %>

<%@ MasterType VirtualPath="~/Webmaster/mpage.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="Scripts" ID="ScriptsContent">
    <style type="text/css">    
    .tblprivs{border-top:1px solid #ddd;border-left:1px solid #ddd;width: 100%;margin-bottom: 10px;}    
    .tblprivs .thead{text-align:left;background: #efefef; height:35px; font-size:14px;}
    .tblprivs td{border-right:1px solid #ddd;border-bottom:1px solid #ddd; height:35px;}
    
    .privs1{font-weight:bold;line-height:30px;font-size:14px; clear:both; margin-top:10px; background:#eee}
    .privs2{float:left;width:24%;list-style: none;margin: 0px;padding: 0px;}
    .privs2 li{line-height:22px;list-style: none;}
    .privs2 li.privs2title{font-weight:bold;line-height:24px;}
    .privs2space{clear:both;width:100%; height:10px;list-style: none;}
    .privs2space li{list-style: none;}
    .privs3{}
    .pcode{color:#ff0000; font-weight:normal;}
    </style>
    
    <script type="text/javascript">
        //初始化已经设置的权限信息
        function initPrivs() {
            if (comPrivs == null) return;

            if (comPrivs.Privs1 != null && comPrivs.Privs1.length > 0) {
                for (var i = 0; i < comPrivs.Privs1.length; i++) {
                    $("#chk_p_1_" + comPrivs.Privs1[i]).attr("checked", true);
                }
            }

            if (comPrivs.Privs2 != null && comPrivs.Privs2.length > 0) {
                for (var i = 0; i < comPrivs.Privs2.length; i++) {
                    $("#chk_p_2_" + comPrivs.Privs2[i]).attr("checked", true);
                }
            }

            if (comPrivs.Privs3 != null && comPrivs.Privs3.length > 0) {
                for (var i = 0; i < comPrivs.Privs3.length; i++) {
                    $("#chk_p_3_" + comPrivs.Privs3[i]).attr("checked", true);
                }
            }
        }

        $(document).ready(function() {
            initPrivs();

            //一级栏目(1)checkbox添加事件，全选或取消子栏目及所有权限
            $(".privs1 input[type='checkbox']").bind("click", function() {
                $(this).closest(".privs123").find("input[type='checkbox']").attr("checked", this.checked);
            });

            //二级栏目(2)checkbox添加事件，全选或取消全选所有权限，选中后并选中栏目
            $(".privs2title input[type='checkbox']").bind("click", function() {
                $(this).closest("ul").find("input[type='checkbox']").attr("checked", this.checked);
                if (this.checked) {
                    $(this).closest(".privs123").find(".privs1").find("input[type='checkbox']").attr("checked", true);
                } else {
                    if ($(this).closest(".privs123").find(".privs2title").find("input[type='checkbox']:checked").length == 0) {
                        $(this).closest(".privs123").find(".privs1").find("input[type='checkbox']").attr("checked", false);
                    }
                }
            });

            //权限(3)checkbox添加事件，选中后选中子栏目及栏目
            $(".privs3 input[type='checkbox']").bind("click", function() {
                if (this.checked) {
                    $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").attr("checked", true);
                    $(this).closest(".privs123").find(".privs1 input[type='checkbox']").attr("checked", true);
                } else {
                    if ($(this).closest("ul").find(".privs3 input[type='checkbox']:checked").length == 0) {
                        $(this).closest("ul").find("li:eq(0) input[type='checkbox']").attr("checked", false);
                    }
                    if ($(this).closest(".privs123").find(".privs2title").find("input[type='checkbox']:checked").length == 0) {
                        $(this).closest(".privs123").find(".privs1").find("input[type='checkbox']").attr("checked", false);
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageTitle" ID="TitleContent">
    子系统权限管理-<asp:Literal runat="server" ID="ltrSysName"></asp:Literal>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageContent" ID="MainContent">    
    <asp:PlaceHolder runat="server" ID="phPrivs">
    <table cellpadding="2" cellspacing="1" style="width: 100%;" class="tblprivs">
        <tr class="thead">
            <td colspan="2">
                <asp:Button ID="btnSetSysPrivs" runat="server" Text="设置子系统权限" OnClick="btnSetSysPrivs_Click" />&nbsp;
                <asp:Button ID="btnSetAdminRoleBySys" runat="server" Text="设置管理员角色权限为子系统权限" OnClick="btnSetAdminRoleBySys_Click" />&nbsp;
                <asp:Button ID="btnSetAdminPrivsBySys" runat="server" Text="设置管理员账号权限为子系统权限" OnClick="btnSetAdminPrivsBySys_Click" />&nbsp;
                <%--<asp:Button ID="btnSetAdminRoleByAdminRole" runat="server" Text="设置管理员为管理员角色" OnClick="btnSetAdminRoleByAdminRole_Click" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal runat="server" ID="ltrPrivs"></asp:Literal>
            </td>
        </tr>
    </table>
    </asp:PlaceHolder>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageRemark" ID="RemarkContent">
    <ul class="decimal">
        <li>权限类别-栏目：无栏目权限的用户看不到该二级栏目。</li>
    </ul>
</asp:Content>
