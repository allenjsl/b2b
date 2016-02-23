<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangAn.aspx.cs" Inherits="Web.PrintPage.DangAn" MasterPageFile="/MasterPage/Print.Master"  Title="人事档案_行政中心" ValidateRequest="false"%>
<%@ Import Namespace="EyouSoft.Common" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ MasterType VirtualPath="/MasterPage/Print.Master" %>
<asp:Content runat="server" ID="DangAn" ContentPlaceHolderID="PrintC1">
<table cellspacing="0" cellpadding="0" bordercolor="#000000" border="0" align="center" style="border-collapse:collapse; line-height:16px; margin:10px auto;" class="list">
  <tbody><tr>
    <td width="30" height="20" align="center"><strong>序号</strong></td>
    <td width="60" align="center"><strong>档案编号</strong></td>
    <td width="45" align="center"><strong>姓名</strong></td>
    <td width="36" align="center"><strong>性别</strong></td>
    <td width="72" align="center"><strong>出生日期</strong></td>
    <td width="67" align="center"><strong>所属部门</strong></td>
    <td width="62" align="center"><strong>职务</strong></td>
    <td width="33" align="center"><strong>工龄</strong></td>
    <td width="85" align="center"><strong>联系电话</strong></td>
    <td width="85" align="center"><strong>手机</strong></td>
    <td width="96" align="center"><strong>E-mail</strong></td>
  </tr>
  <asp:repeater ID="rpt" runat="server">
  <ItemTemplate>
  <tr>
    <td valign="middle" align="center" class="pandl4"><%#Container.ItemIndex+1+(this.pageIndex-1)*pageSize %></td>
    <td align="center" class="pandl4"><%#Eval("ArchiveNo")%></td>
    <td align="center" class="pandl4"><%#Eval("UserName")%></td>
    <td align="center" class="pandl4"><%#Eval("ContactSex") %></td>
    <td align="center" class="pandl4"><%#UtilsCommons.GetDateString(Eval("BirthDate"),ProviderToDate)%></td>
    <td align="center" class="pandl4"><%#this.GetDept((List<EyouSoft.Model.CompanyStructure.Department>)Eval("DepartmentList"))%></td>
    <td align="center" class="pandl4"><%#Eval("DutyName")%></td>
    <td align="center" class="pandl4"><%#Eval("WorkYear")%></td>
    <td align="center" class="pandl4"><%#Eval("ContactTel")%></td>
    <td align="center" class="pandl4"><%#Eval("ContactMobile")%></td>
    <td align="center" class="pandl4"><%#Eval("Email") %></td>
  </tr>
  </ItemTemplate>
  </asp:repeater>
</tbody></table>
</asp:Content>
