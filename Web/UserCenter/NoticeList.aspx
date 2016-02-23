<%@ Page Title="公告通知-个人中心" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="Web.UserCenter.NoticeList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td nowrap="nowrap" width="15%">
                        <span class="lineprotitle">个人中心</span>
                    </td>
                    <td align="right" nowrap="nowrap" style="padding: 0 10px 2px 0; color: #13509f;"
                        width="85%">
                        所在位置&gt;&gt; 个人中心&gt;&gt; 公告通知
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#000000" colspan="2" height="2">
                    </td>
                </tr>
            </table>
        </div>
        <div class="tablelist">
            <table border="0" cellpadding="0" cellspacing="1" width="100%">
                <tr>
                    <th align="center" bgcolor="#BDDCF4" height="30" width="36">
                        序号
                    </th>
                    <th align="center" bgcolor="#BDDCF4">
                        标题
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="12%">
                        浏览数
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="15%">
                        发布人
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="20%">
                        发布时间
                    </th>
                </tr>
                <asp:Repeater ID="rpNotice" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td height="30" bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                            </td>
                            <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="left" class="pandl3">
                                <a href="/UserCenter/NoticeDetail.aspx?Id=<%#Eval("Id") %>">
                                    <%#Eval("Title")%></a>
                            </td>
                            <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                <%#Eval("ClickNum")%>
                            </td>
                            <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                <%#Eval("OperateName")%>
                            </td>
                            <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                <%#this.ToDateTimeString(Eval("IssueTime"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" class="pageup">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
