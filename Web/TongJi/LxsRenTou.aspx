<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LxsRenTou.aspx.cs" Inherits="Web.TongJi.LxsRenTou"
    MasterPageFile="~/MasterPage/Front.Master" Title="统计分析-旅行社人头统计表"  ValidateRequest="false"%>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">统计分析</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            <b>当前用您所在位置：</b> &gt;&gt; 统计分析 &gt;&gt; 旅行社人头统计表
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#000000" height="2" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="hr_10">
        </div>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="../images/yuanleft.gif">
                    </td>
                    <td>
                        <form id="form1" method="get" action="">
                        <div class="searchbox">
                            年份：<select name="txtYear" id="txtYear" class="inputselect"><%=GetYearOptions(string.Empty)%></select>
                            <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                        </div>
                        </form>
                    </td>
                    <td width="10" valign="top">
                        <img src="../images/yuanright.gif">
                    </td>
                </tr>
            </tbody>
        </table>
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
            <table width="100%" cellspacing="1" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <th height="30" colspan="16" align="center">
                            <font style="font-size: 18px;">
                                <asp:Literal ID="ltrTableTitle" runat="server" />年 旅行社人头统计表
                            </font>
                        </th>
                    </tr>
                    <tr class="odd">
                        <th width="6%" align="center" height="30">
                            所在地
                        </th>
                        <th align="center">
                            市&nbsp;县
                        </th>
                        <th align="center">
                            年份
                        </th>
                        <th width="6%" align="center">
                            1月
                        </th>
                        <th width="6%" align="center">
                            2月
                        </th>
                        <th width="6%" align="center">
                            3月
                        </th>
                        <th width="6%" align="center">
                            4月
                        </th>
                        <th width="6%" align="center">
                            5月
                        </th>
                        <th width="6%" align="center">
                            6月
                        </th>
                        <th width="6%" align="center">
                            7月
                        </th>
                        <th width="6%" align="center">
                            8月
                        </th>
                        <th width="6%" align="center">
                            9月
                        </th>
                        <th width="6%" align="center">
                            10月
                        </th>
                        <th width="6%" align="center">
                            11月
                        </th>
                        <th width="6%" align="center">
                            12月
                        </th>
                        <th width="6%" align="center">
                            小计
                        </th>
                    </tr>
                    <%=strBu%>
                </tbody>
            </table>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="even" colspan="16" style="height: 30px; text-align: center;">
                            暂无统计信息。
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </div>
    </div>
    <form id="form2" action="LxsRenTou.aspx" method="post">
    <input type="hidden" id="istoxls" name="istoxls" value="1" />
    <input type="hidden" id="txtXlsHTML" name="txtXlsHTML" />
    </form>

    <script type="text/javascript">
        $(function() {
            $(".RenTouxx").each(function() {
                var _data = {
                    year: $(this).closest("tr").find(".yeartd").html(),
                    month: $(this).attr("dataMonth"),
                    chengshiID: $(this).attr("dataccid"),
                    diqu: $(this).attr("datadid")
                };
                $(this).click(function() {
                    Boxy.iframeDialog({ title: "旅行社人头统计明细", iframeUrl: "LxsRenTouXX.aspx", width: "750px", height: "700px", data: _data, afterHide: function() { window.location.href = window.location.href; } });
                    return false;
                })
            })
            utilsUri.initSearch();
            $("#a_toExcel").click(function() {
                $("#txtXlsHTML").val($("#divXls").html());
                $("#form2").submit();
                return false;
            })//导出
        })
    </script>

</asp:Content>
