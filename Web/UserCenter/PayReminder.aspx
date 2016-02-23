<%@ Page Title="付款提醒-个人中心" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="PayReminder.aspx.cs" Inherits="Web.UserCenter.PayReminder" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">个人中心</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            所在位置&gt;&gt; 个人中心&gt;&gt; 事务提醒
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="height: 35px;" class="lineCategorybox">
            <table cellspacing="0" cellpadding="0" border="0" class="grzxnav">
                <tbody>
                    <tr>
                        <td align="center">
                            <a href="ReceivablesRemind.aspx">收款提醒</a>
                        </td>
                        <td align="center" class="grzxnav-on">
                            <a href="PayReminder.aspx">付款提醒</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td height="30">
                        <form action="PayReminder.aspx" id="SearchFrom" method="get">
                        付款单位：
                        <input type="text" size="20" class="inputtext" name="BuyCustomerName" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("BuyCustomerName") %>' />
                        出团日期：
                        <input type="text" size="9" id="LBeginDate" class="inputtext" name="LBeginDate" onfocus="WdatePicker()"
                            value='<%=EyouSoft.Common.Utils.GetQueryStringValue("LBeginDate") %>' />
                        -
                        <input type="text" size="9" id="LEndDate" class="inputtext" name="LEndDate" onfocus="WdatePicker()"
                            value='<%=EyouSoft.Common.Utils.GetQueryStringValue("LEndDate") %>' />
                        <a href="#" id="btnSearch">
                            <img style="vertical-align: top;" src="../images/searchbtn.gif"></a>
                        </form>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <th width="36" height="30" bgcolor="#BDDCF4" align="center">
                            序号
                        </th>
                        <th bgcolor="#BDDCF4" align="center">
                            付款单位
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            联系人
                        </th>
                        <th width="20%" bgcolor="#bddcf4" align="center">
                            联系电话
                        </th>
                        <th width="15%" bgcolor="#bddcf4" align="center">
                            欠款金额
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            查看明细
                        </th>
                    </tr>
                    <asp:Repeater ID="rpRemind" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td height="30" bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                                </td>
                                <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="left" class="pandl3">
                                    <%#Eval("SupplierName")%>
                                </td>
                                <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("ContactName")%>
                                </td>
                                <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("ContactTel")%>
                                </td>
                                <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%# ToMoneyString(Eval("PayCash"))%>
                                </td>
                                <td bgcolor="<%#Container.ItemIndex%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <a class="link" data-customerid="<%#Eval("SupplierId") %>" href="javascript:void(0);">
                                        查看</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td align="right" class="pageup">
                            <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var ReceivablesRemind = {
            Search: function() {
                $("#SearchFrom").submit();
            },
            Detail: function(data) {
                var url = "/UserCenter/PayDetails.aspx?" + $.param(data);
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "付款提醒查看",
                    modal: true,
                    width: "740px",
                    height: "400px"
                });
                return false;
            }
        };

        $(function() {
            $("#btnSearch").click(function() {
                ReceivablesRemind.Search();
            });

            $(".link").click(function() {
                var _self = $(this);
                var data = {
                    SupplierId: _self.attr("data-customerid"),
                    LBeginDate: '<%=EyouSoft.Common.Utils.GetQueryStringValue("LBeginDate") %>',
                    LEndDate: '<%=EyouSoft.Common.Utils.GetQueryStringValue("LEndDate") %>'
                };
                ReceivablesRemind.Detail(data);
            });
        });
    </script>

</asp:Content>
