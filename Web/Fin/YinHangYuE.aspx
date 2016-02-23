<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YinHangYuE.aspx.cs" Inherits="Web.Fin.YinHangYuE"
    MasterPageFile="~/MasterPage/Front.Master" Title="银行余额表-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 银行余额表
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    <div class="hr_10">
    </div>
    <form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox">
                    日期：
                    <input name="txtTime" type="text" class="searchinput formsize80 inputtext" id="txtTime"
                        onfocus="WdatePicker()" />
                    <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>
    
    <table width="99%" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="30" align="center">
                <strong>截止至 <asp:Literal runat="server" ID="ltrTime"></asp:Literal> 银行余额情况</strong>
            </td>
        </tr>
    </table>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="7%" height="30" align="center">
                    序号
                </th>
                <th align="center">
                    账户名称
                </th>
                <th align="center">
                    开户银行
                </th>
                <th align="center">
                    银行账号
                </th>
                <th align="center">
                    账户余额
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                        <td height="30" align="center">
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td align="center">
                            <%#Eval("MingCheng")%>
                        </td>
                        <td align="center">
                            <%#Eval("KaiHuHang")%>
                        </td>
                        <td align="center">
                            <%#Eval("ZhangHao")%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YuE"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="9" style="height: 30px; text-align: center;">
                        暂无信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="4" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrYuEHeJi"></asp:Literal>
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
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

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
        });
    </script>

</asp:Content>
