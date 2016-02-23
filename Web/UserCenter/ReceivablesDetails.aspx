<%@ Page Title="收款提醒查看" Language="C#" AutoEventWireup="true" CodeBehind="ReceivablesDetails.aspx.cs"
    Inherits="Web.UserCenter.ReceivablesDetails" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server">
    <table width="99%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr class="odd">
                <th height="30" align="center">
                    订单号
                </th>
                <th align="center">
                    客户单位
                </th>
                <th align="center">
                    对方操作人
                </th>
                <th align="center">
                    人数
                </th>
                <th align="center">
                    占位数
                </th>
                <th align="center">
                    应收金额
                </th>
                <th align="center">
                    待收金额
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpOrder">
                <ItemTemplate>
                    <tr class="odd">
                        <td height="30" bgcolor="#E3F1FC" align="center">
                            <%#Eval("JiaoYiHao")%>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#Eval("KeHuName") %>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#Eval("DuiFangCaoZuoRenName")%>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#Eval("ChengRenShu")%>+<%#Eval("ErTongShu") %>+<%#Eval("YingErShu") %>+<%#Eval("QuanPeiShu")%>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#Eval("ZhanWeiShu")%>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%# ToMoneyString(Eval("JinE"))%>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <%#ToMoneyString(Eval("WeiShouJinE"))%>
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
