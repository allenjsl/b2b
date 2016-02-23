<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Boxy.Master"
    CodeBehind="PayDetails.aspx.cs" Inherits="Web.UserCenter.PayDetails" Title="付款提醒查看" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server">
    <table width="99%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr class="odd">
                <th height="30" align="center">
                    控位号
                </th>
                <th align="center">
                    线路名称
                </th>
                <th align="center">
                    出团日期
                </th>
                <%--<th align="center">
                    人数
                </th>--%>
                <th align="center">
                    总金额
                </th>
                <th align="center">
                    未付金额
                </th>
            </tr>
            <asp:Repeater ID="rpPay" runat="server">
                <ItemTemplate>
                    <tr class="odd">
                        <td height="30" bgcolor="#E3F1FC" align="center">
                            <%#Eval("KongWeiCode") %>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#Eval("RouteName")%>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#Eval("QuDate","{0:yyyy-MM-dd}") %>
                        </td>
                        <%--<td bgcolor="#E3F1FC" align="center">
                            <%#Eval("ChengRenShu")%>+<%#Eval("ErTongShu")%>+<%#Eval("YingErShu") %>+<%#Eval("QuanPeiShu") %><sup></sup>
                        </td>--%>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#ToMoneyString(Eval("JinE"))%>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#ToMoneyString(Eval("WeiZhiFuJinE"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <table width="700" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr>
                <td align="right" class="pageup">
                    <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</asp:Content>
