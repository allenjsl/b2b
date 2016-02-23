<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaoZuoRen.aspx.cs" Inherits="Web.TongJi.CaoZuoRen"
    MasterPageFile="~/MasterPage/Front.Master" Title="统计分析-我方操作人的统计表" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">统计分析</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                        <b>当前用您所在位置：</b> >> 统计分析 >> 我方操作人统计表
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
                    <img src="../images/yuanleft.gif" />
                </td>
                <td>
                    <div class="searchbox">
                        出团日期：
                        <input name="sendTimes" type="text" class="inputtext" id="sendTimes" size="12" onfocus="WdatePicker()" />
                        -
                        <input name="sendTimee" type="text" class="inputtext" id="sendTimee" size="12" onfocus="WdatePicker()" />
                        <input type="image" style="vertical-align: top;" src="/images/searchbtn.gif">
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="../images/yuanright.gif" />
                </td>
            </tr>
        </table>
        </form>
        <div class="btnbox">
            <asp:PlaceHolder runat="server" ID="phInsert">
                <table border="0" align="left" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="90" align="center">
                            <a href="javascript:void(0)" id="a_toExcel">导 出</a>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </div>
        <div class="tablelist" id="divXls">
            <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <th height="30" colspan="7" align="center">
                        <font style="font-size: 18px;">
                            <asp:Label ID="lbl_serch" runat="server" Text=""></asp:Label>
                        </font>
                    </th>
                </tr>
                <tr class="odd">
                    <th height="30" align="center" style="width:40px;">
                        序号
                    </th>
                    <th align="center">
                        操作人
                    </th>
                    <th align="center">
                        正常旅游
                    </th>
                    <th align="center">
                        私人订制<%--特殊旅游--%>
                    </th>
                    <th align="center">
                        自由行
                    </th>
                    <th align="center">
                        单定票
                    </th>
                    <th align="center">
                        代订酒店
                    </th>
                    <th align="center">
                        票务酒店
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpts">
                    <ItemTemplate>
                        <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                            <td align="center">
                                <%#Container.ItemIndex + 1 %>
                            </td>
                            <td align="center">
                                <%# Eval("OperatorName")%>
                            </td>
                            <td align="center">
                                <%# getRsHtml( Eval("T0"))%>
                            </td>
                            <td height="30" align="center">
                                <%# getRsHtml(  Eval("T4"))%>
                            </td>
                            <td height="30" align="center">
                                <%# getRsHtml(  Eval("T5"))%>
                            </td>
                            <td align="center">
                                <%#  getRsHtml( Eval("T1"))%>
                            </td>
                            <td align="center">
                                <%# getRsHtml(  Eval("T3"))%>
                            </td>
                            <td align="center">
                                <%# getRsHtml(  Eval("T2"))%>
                            </td>
                        </tr>
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
        </div>
        <form id="form2" action="CaoZuoRen.aspx" method="post">
        <input type="hidden" id="istoxls" name="istoxls" value="1" />
        <input type="hidden" id="txtXlsHTML" name="txtXlsHTML" />
        </form>
    </div>

    <script type="text/javascript">
        $(function() {
            utilsUri.initSearch();
            $("#a_toExcel").click(function() {
                $("#txtXlsHTML").val($("#divXls").html());

                $("#form2").submit();
                return false;
            });
        })
    </script>

</asp:Content>
