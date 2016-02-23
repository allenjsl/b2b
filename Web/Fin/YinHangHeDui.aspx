<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YinHangHeDui.aspx.cs" Inherits="Web.Fin.YinHangHeDui"
    MasterPageFile="~/MasterPage/Front.Master" Title="银行核对表-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 银行核对表
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
                    业务日期：
                    <input name="txtSYeWuRiQi" type="text" class="searchinput formsize80 inputtext" id="txtSYeWuRiQi"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtEYeWuRiQi" type="text" class="searchinput formsize80 inputtext" id="txtEYeWuRiQi"
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
    <div class="btnbox">
    <asp:PlaceHolder runat="server" ID="phInsert">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:void(0)" id="i_insert">登记</a>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="36" align="center" style="height: 30px;">
                    序号
                </th>
                <th width="8%" align="center">
                    日期
                </th>
                <th width="8%" align="center">
                    银行总额
                </th>
                <th width="8%" align="center">
                    业务日期
                </th>
                <th align="center">
                    借方总额
                </th>
                <th align="center">
                    贷方总额
                </th>
                <th align="center">
                    流水总额
                </th>
                <th align="center">
                    差额
                </th>
                <th align="center">
                    状态
                </th>
                <th width="80" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_xmid="<%#Eval("HeDuiId") %>">
                        <td align="center" style="height:30px;">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("RiQi")) %>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YinHangZongE")) %>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("YeWuRiQi")) %>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("JieFangZongE")) %>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("DaiFangZongE")) %>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("LiuShuiZongE")) %>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("ChaE")) %>
                        </td>
                        <td align="center">
                            <%#GetStatus(Eval("Status")) %>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何银行核对信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server"></asp:PlaceHolder>
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
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "新增银行核对信息", iframeUrl: "yinhangheduiedit.aspx", width: "720px", height: "450px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { heduiid: _$tr.attr("i_xmid") };
                var _title = "修改银行核对信息";
                if ($(obj).attr("i_chakan") == "1") _title = "查看银行核对信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "yinhangheduiedit.aspx", width: "720px", height: "450px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("银行核对信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { heduiid: _$tr.attr("i_xmid") };

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "delete" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                    }
                });
            },
            queRen: function(obj) {
                if (!confirm("确认后不可逆，你确定要确认该银行核对信息吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { heduiid: _$tr.attr("i_xmid") };

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "queren" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.queRen(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.queRen(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();

            $("#i_insert").bind("click", function() { return iPage.insert(this); });
            $(".i_update").bind("click", function() { return iPage.update(this); });
            $(".i_delete").bind("click", function() { return iPage.del(this); return false; });
            $(".i_queren").bind("click", function() { return iPage.queRen(this); return false; });
        });
    </script>

</asp:Content>
