<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BianGengList.aspx.cs" Inherits="Web.CommonPage.BianGengList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>变更历史</title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="98%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 0px auto; margin-top:5px;">
        <tbody>
            <tr class="odd">
                <th height="30" align="center">
                    变更时间
                </th>
                <th width="70" align="center">
                    变更人
                </th>
                <th width="86" align="center">
                    变更内容
                </th>
            </tr>
            <asp:repeater ID="rpt" runat="server">
                <ItemTemplate>
                    <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                        <td width="120" height="30" align="center">
                            <%#Eval("IssueTime")%>
                        </td>
                        <td align="center">
                            <%#Eval("OperatorName")%>
                        </td>
                        <td align="center">
                            <a class="historybox" href="<%#Eval("Url") %>" target="_blank">查看</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:repeater>
        </tbody>
    </table>
    </div>
    </form>
</body>
</html>
