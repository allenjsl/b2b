<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMailList.aspx.cs" Inherits="Web.ManageCenter.PrintMailList" MasterPageFile="/masterpage/Print.Master" Title="内部通讯录_行政中心" ValidateRequest="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PrintC1" runat="server">
    <table width="690" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000" class="list"
        style="border-collapse: collapse; line-height: 16px; margin: 10px auto;word-wrap:break-word; overflow:hidden;word-break: break-all;table-layout:fixed;">
        <tr>
            <td width="62" height="20" align="center">
                <strong>姓名</strong>
            </td>
            <td width="91" align="center">
                <strong>部门</strong>
            </td>
            <td width="95" align="center">
                <strong>电话</strong>
            </td>
            <td width="85" align="center">
                <strong>手机</strong>
            </td>
            <td width="137" align="center">
                <strong>E-mail</strong>
            </td>
            <td width="71" align="center">
                <strong>QQ</strong>
            </td>
            <td width="138" align="center">
                <strong>MSN</strong>
            </td>
        </tr>
        <asp:repeater ID="rpt" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center" valign="middle" class="pandl4">
                        <%#Eval("UserName") %>
                    </td>
                    <td align="center" class="pandl4">
                        <%#this.getSectionInfo(Eval("DepartmentList"))%>
                    </td>
                    <td align="center" class="pandl4">
                        <%#Eval("ContactTel") %>
                    </td>
                    <td align="center" class="pandl4">
                        <%#Eval("ContactMobile")%>
                    </td>
                    <td align="center" class="pandl4">
                        <%#Eval("Email")%>
                    </td>
                    <td align="center" class="pandl4">
                        <%#Eval("QQ")%>
                    </td>
                    <td align="center" class="pandl4">
                        <%#Eval("MSN")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:repeater>
    </table>
</asp:Content>