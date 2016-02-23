<%@ Page Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    Title="个人借款表-个人中心" CodeBehind="LoanList.aspx.cs" Inherits="Web.UserCenter.LoanList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
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
                        所在位置&gt;&gt; 个人中心&gt;&gt; 个人借款表
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
                    <th align="center" bgcolor="#BDDCF4" width="15%">
                        借款日期
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        借款金额
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        借款原因
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="11%">
                        借款人
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="14%">
                        借款状态
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="12%">
                        归还时间
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpLoan">
                    <ItemTemplate>
                        <tr>
                            <td align="center" bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>"
                                height="35">
                                <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                            </td>
                            <td align="center" bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>">
                                <%#this.ToDateTimeString(Eval("JieKuanRiQi"))%>
                            </td>
                            <td align="center" bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>">
                                <%#this.ToMoneyString( Eval("JinE"))%>
                            </td>
                            <td align="center" bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>">
                                <%#Eval("JieKuanYuanYin")%>
                            </td>
                            <td align="center" bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>">
                                <%#Eval("JieKuanRenName")%>
                            </td>
                            <td align="center" bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>">
                                <%#Eval("Status")%>
                            </td>
                            <td align="center" bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>">
                                <%#this.ToDateTimeString(Eval("GuiHuanTime"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <th width="36" height="30" align="center" bgcolor="#BDDCF4">
                        &nbsp;
                    </th>
                    <th width="15%" align="center" bgcolor="#BDDCF4">
                        &nbsp;
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        合计：<asp:Literal runat="server" ID="ltTotal"></asp:Literal>
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        &nbsp;
                    </th>
                    <th width="11%" align="center" bgcolor="#bddcf4">
                        &nbsp;
                    </th>
                    <th width="14%" align="center" bgcolor="#bddcf4">
                        &nbsp;
                    </th>
                    <th width="12%" align="center" bgcolor="#bddcf4">
                        &nbsp;
                    </th>
                </tr>
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
