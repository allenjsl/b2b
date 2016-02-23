<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhiDu.aspx.cs" Inherits="Web.PrintPage.ZhiDu" MasterPageFile="/MasterPage/Print.Master" Title="规章制度_行政中心" ValidateRequest="false"%>
<%@ MasterType VirtualPath="/MasterPage/Print.Master" %>
<asp:Content runat="server" ID="ZhiDu" ContentPlaceHolderID="PrintC1">
<link href="/css/sytle.css" rel="stylesheet" type="text/css" />
<table cellspacing="0" cellpadding="0" bordercolor="#000000" border="0" align="center" style="border-collapse:collapse; line-height:16px; margin:10px auto;" class="list">
  <tbody><tr>
    <td height="24" align="left"> 编 号： <span id="txtNo" runat="server"></span></td>
  </tr>
  <tr>
    <td valign="middle" align="center" class="pandl4"><strong><span id="txtTitle" runat="server"></span></strong></td>
  </tr>
  <tr>
    <td valign="middle" align="left" class="pandl4"><p style=" text-indent:28px; line-height:24px;"><span id="txtContent" runat="server"></span></p></td>
  </tr>
</tbody></table>
</asp:Content>
