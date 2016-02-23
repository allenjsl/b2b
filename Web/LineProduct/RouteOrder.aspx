<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="RouteOrder.aspx.cs" Inherits="Web.LineProduct.RouteOrder" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="1" style="margin: 10px;"
        id="liststyle">
        <tr class="odd">
            <th width="10%" height="30" bgcolor="#BDDCF4">
                订单号
            </th>
            <th width="21%" bgcolor="#BDDCF4">
                客户单位
            </th>
            <th width="12%" bgcolor="#BDDCF4">
                对方操作人
            </th>
            <th width="11%" bgcolor="#BDDCF4">
                人数
            </th>
            <th width="9%" bgcolor="#BDDCF4">
                占位数
            </th>
            <th width="25%" bgcolor="#BDDCF4">
                价格明细
            </th>
            <th width="12%" bgcolor="#BDDCF4">
                总金额
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptOrder">
            <ItemTemplate>
                <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "old" %>">
                    <td height="30" align="center">
                        <%# Eval("OrderCode")%>
                    </td>
                    <td align="center">
                        <%# Eval("BuyCompanyName")%>
                    </td>
                    <td align="center">
                        <%# Eval("BuyOperatorName")%>
                    </td>
                    <td align="center">
                        <font class="fbred">
                            <%#Eval("Adults")%>+<%#Eval("Childs")%>+<%#Eval("YingErRenShu") %>+<%#Eval("Bears")%></font>
                    </td>
                    <td align="center">
                        <%# Eval("Accounts")%>
                    </td>
                    <td align="center">
                        <%# Eval("JiaGeMingXi1")%>
                    </td>
                    <td align="center">
                        <%# EyouSoft.Common.UtilsCommons.GetMoneyString(Eval("SumPrice"), this.ProviderToMoney)%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr class="even">
            <td height="30" colspan="7" align="right" class="pageup">
                <cc1:ExporPageInfoSelect runat="server" ID="page1" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        $(document).ready(function() {
            utilsUri.initSearch();
            tableToolbar.init({ tableContainerSelector: "#liststyle" });
        });
    </script>

</asp:Content>
