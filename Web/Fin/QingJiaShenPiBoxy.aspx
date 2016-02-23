<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QingJiaShenPiBoxy.aspx.cs"
    Inherits="Web.Fin.QingJiaShenPiBoxy" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 630px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="120" height="30" align="right" style="width: 120px;">
                    审批人：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtShenPiRenName" type="text" class="formsize80 inputtext" id="txtShenPiRenName"
                        runat="server" disabled="disabled" />
                </td>
                <th align="right">
                    审批时间：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtShenPiTime" type="text" class="formsize100 inputtext" id="txtShenPiTime"
                        runat="server" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    审批备注：
                </th>
                <td colspan="3" style="background: #E3F1FC">
                    <textarea name="txtShenPiBeiZhu" rows="3" class="formsize450 inputarea" id="txtShenPiBeiZhu"
                        runat="server"></textarea>
                </td>
            </tr>
        </table>
        <asp:PlaceHolder runat="server" ID="phZuoFei">
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top: 10px;"
                id="i_table_zhifu">
                <tr class="odd">
                    <th height="30" align="right" style="width: 120px;">
                        作废人：
                    </th>
                    <td style="background: #E3F1FC">
                        <input name="txtZuoFeiRenName" type="text" class="formsize80 inputtext" id="txtZuoFeiRenName"
                            runat="server" disabled="disabled" />
                    </td>
                    <th align="right">
                        作废时间：
                    </th>
                    <td style="background: #E3F1FC">
                        <input name="txtZuoFeiTime" type="text" class="formsize100 inputtext" id="txtZuoFeiTime"
                            runat="server" disabled="disabled" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        作废备注：
                    </th>
                    <td colspan="3" style="background: #E3F1FC">
                        <textarea name="txtZuoFeiBeiZhu" rows="3" class="formsize450 inputarea" id="txtZuoFeiBeiZhu"
                            runat="server"></textarea>
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="180" height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <script type="text/javascript">
            var iPage = {
                //关闭窗口
                close: function() {
                    var _win = top || window;
                    _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                    return false;
                },
                //审批
                shenPi: function(obj) {
                    var _$obj = $(obj);
                    var _i_status = _$obj.attr("i_status");
                    var _data = { txtStatus: _i_status,
                        txtBeiZhu: $.trim($("#<%=txtShenPiBeiZhu.ClientID %>").val())
                    };
                    if (_data.txtBeiZhu.length > 255) { parent.tableToolbar._showMsg("审批备注内容最多可输入255个字符"); $("#<%=txtShenPiBeiZhu.ClientID %>").focus(); return false; }
                    var _confirmmsg = "审批操作不可逆，你确定要同意该请假申请吗？";
                    if (_i_status == "0") _confirmmsg = "审批操作不可逆，你确定要不通过该请假申请吗？";
                    if (!confirm(_confirmmsg)) return false;

                    _$obj.unbind("click").css({ "color": "#999999" });

                    $.newAjax({
                        type: "POST",
                        url: window.location.href + "&doType=shenpi",
                        data: _data,
                        cache: false,
                        dataType: "json",
                        async: false,
                        success: function(response) {
                            if (response.result == "1") {
                                alert(response.msg);
                                iPage.close();
                            } else {
                                alert(response.msg);
                                $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                            }
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                        }
                    });
                },
                //作废
                zuoFei: function(obj) {
                    var _$obj = $(obj);
                    var _data = { txtBeiZhu: $.trim($("#<%=txtZuoFeiBeiZhu.ClientID %>").val()) };
                    if (_data.txtBeiZhu.length > 255) { parent.tableToolbar._showMsg("作废备注内容最多可输入255个字符"); $("#<%=txtZuoFeiBeiZhu.ClientID %>").focus(); return false; }
                    var _confirmmsg = "作废操作不可逆，你确定要作废该请假申请吗？";
                    if (!confirm(_confirmmsg)) return false;

                    _$obj.unbind("click").css({ "color": "#999999" });

                    $.newAjax({
                        type: "POST",
                        url: window.location.href + "&doType=zuofei",
                        data: _data,
                        cache: false,
                        dataType: "json",
                        async: false,
                        success: function(response) {
                            if (response.result == "1") {
                                alert(response.msg);
                                iPage.close();
                            } else {
                                alert(response.msg);
                                $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                            }
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                        }
                    });
                }
            };

            $(document).ready(function() {
                $(".i_shenpi").bind("click", function() { return iPage.shenPi(this); });
                $("#i_zuofei").bind("click", function() { return iPage.zuoFei(this); });
            });
        </script>
</asp:Content>
