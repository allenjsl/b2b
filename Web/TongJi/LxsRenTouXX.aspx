<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LxsRenTouXX.aspx.cs" Inherits="Web.TongJi.LxsRenTouXX" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/sytle.css" />
    <link rel="stylesheet" type="text/css" href="/css/boxy.css" />
</head>
<body>
    <div class="mainbody">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" align="center">
                <tr>
                    <th height="30" colspan="7" align="center" bgcolor="#BDDCF4">
                        <font style="font-size: 18px;">
                            <asp:Label ID="lbl_serch" runat="server" Text=""></asp:Label>
                        </font>
                    </th>
                </tr>
                <tr>
                    <th height="30" align="center" bgcolor="#BDDCF4">
                        客户单位
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        业务类型
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        出团日期
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        线路名称
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        人数
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        对方操作人
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        小计
                    </th>
                </tr>
                <asp:Repeater ID="rpts" runat="server">
                    <ItemTemplate>
                        <%# getHtml(Eval("T0"),Eval("T1"),Eval("T2"),Eval("T3"),Eval("T4"),Eval("KeHuName"),Eval("DingDans"),Eval("T5"))%>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="even" colspan="6" style="height: 30px; text-align: center;">
                            暂无统计信息。
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phPaging">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right">
                            <cc1:ExporPageInfoSelect ID="paging" runat="server" />
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </div>
    </div>
</body>
</html>
