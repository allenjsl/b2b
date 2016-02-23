<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YinHangMingXi.aspx.cs"
    Inherits="Web.Fin.YinHangMingXi" MasterPageFile="~/MasterPage/Front.Master" Title="银行明细表-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 银行明细表
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
                    银行实际业务日期：
                    <input name="txtSBankDate" type="text" class="searchinput formsize80 inputtext" id="txtSBankDate"
                        onfocus="WdatePicker()" value="<%=SBankDate %>" />-
                    <input name="txtEBankDate" type="text" class="searchinput formsize80 inputtext" id="txtEBankDate"
                        onfocus="WdatePicker()" value="<%=EBankDate %>" />
                    <input type="hidden" value="1" name="issearch" />
                    银行账户：<select name="txtYinHangZhangHu" id="txtYinHangZhangHu" class="inputselect"><%=GetYinHangZhangHuOptions()%></select>
                    <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>
    <div class="btnbox">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:void(0)" id="i_a_toxls">导出</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="36" height="30" align="center">
                    序号
                </th>
                <th align="center">
                    银行实际业务日期
                </th>
                <th align="center">
                    银行账号
                </th>
                <th align="center">
                    借
                </th>
                <th align="center">
                    贷
                </th>
                <th align="center">
                    往来单位
                </th>
                <th align="center">
                    备注
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                        <td height="30" align="center">
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("BankDate"))%>
                        </td>
                        <td align="center">
                            <%#Eval("ZhangHuName")%>
                        </td>
                        <td align="center">
                            <%#GetJieDaiFangJInE(Eval("JieFangJinE"))%>
                        </td>
                        <td align="center">
                            <%#GetJieDaiFangJInE(Eval("DaiFangJinE"))%>
                        </td>
                        <td align="center">
                            <%#Eval("WangLaiDanWeiName")%>
                        </td>
                        <td align="center">
                            <%#Eval("BeiZhu")%>
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
                    <td height="30" colspan="3" align="right" bgcolor="#E3F1FC">
                        合计：
                    </td>
                    <td height="30" align="center" bgcolor="#E3F1FC">
                        <asp:Literal runat="server" ID="ltrJieFangHeJi"></asp:Literal>
                    </td>
                    <td align="center" bgcolor="#E3F1FC">
                        <asp:Literal runat="server" ID="ltrDaiFangHeJi"></asp:Literal>
                    </td>
                    <td align="center" bgcolor="#E3F1FC">
                        &nbsp;
                    </td>
                    <td align="center" bgcolor="#E3F1FC">
                        &nbsp;
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
            },
            toXls: function() {
                var params = { doType: "toxls_yinhangmingxi" };
                toXls1(utilsUri.createUri(null, params));
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();

            $("#i_a_toxls").bind("click", function() {return iPage.toXls(); });
        });
    </script>

</asp:Content>
