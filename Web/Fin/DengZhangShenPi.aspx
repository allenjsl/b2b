<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="DengZhangShenPi.aspx.cs" Inherits="Web.Fin.DengZhangShenPi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server">
    <div style="width: 600px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    银行实际业务日期：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input runat="server" name="txtBankDate" type="text" id="txtBankDate" onfocus="WdatePicker({ maxDate: '%y-%M-{%d}' })"
                        class="searchinput inputtext" />
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    审核备注：
                </th>
                <td bgcolor="#E3F1FC">
                    <textarea runat="server" name="txtRemark" id="txtRemark" rows="3" class="formsize450 inputarea"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    审核人：
                </th>
                <td bgcolor="#E3F1FC">
                    <input runat="server" name="txtOperatorId" type="text" id="txtOperatorId" class="searchinput formsize140 inputtext"
                        disabled="disabled" />
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    审核时间：
                </th>
                <td bgcolor="#E3F1FC">
                    <input runat="server" name="txtTime" type="text" id="txtTime" class="searchinput formsize140 inputtext"
                        disabled="disabled" />
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" bgcolor="#E3F1FC">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        var DengZhangShenPi = {
            //关闭窗口
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            //审批
            shenPi: function(obj) {
                tableToolbar.ShowConfirmMsg("审批操作不可逆，你确定要审批吗？", function() {
                    var _data = { txtBankDate: $.trim($("#<%= txtBankDate.ClientID %>").val()),
                        txtRemark: $.trim($("#<%= txtRemark.ClientID %>").val())
                    };
                    var strErr = "";
                    if (_data.txtBankDate.length == 0) {
                        strErr += "请填写银行实际业务日期！<br />";
                    }
                    if (_data.txtRemark.length > 255) {
                        strErr += "备注内容最多可输入255个字符！<br />";

                    }
                    if (strErr != "") {
                        parent.tableToolbar._showMsg(strErr);
                        return;
                    }
                    $(obj).unbind("click").css({ "color": "#999999" }).html("正在提交");
                    $.newAjax({
                        type: "POST",
                        url: window.location.href + "&doType=save",
                        data: _data,
                        cache: false,
                        dataType: "json",
                        async: false,
                        success: function(ret) {
                            if (ret.result == "1") {
                                tableToolbar._showMsg(ret.msg, function() {
                                    DengZhangShenPi.close();
                                });
                            } else {
                                tableToolbar._showMsg(ret.msg);
                                $(obj).bind("click", function() { DengZhangShenPi.shenPi(obj); return false; }).css({ "color": "" }).html("审批");
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                            $(obj).bind("click", function() { DengZhangShenPi.shenPi(obj); return false; }).css({ "color": "" }).html("审批");
                        }
                    });
                });
            },
            quXiaoShenPi: function(obj) {
                if (!confirm("取消审批操作不可逆，你确定要取消审批吗？")) return;
                var _data = {};

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=quxiaoshenpi",
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            DengZhangShenPi.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { DengZhangShenPi.quXiaoShenPi(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { DengZhangShenPi.quXiaoShenPi(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#a_DengZhangShenPi_Save").bind("click", function() { DengZhangShenPi.shenPi(this); return false; });
            $("#i_a_quxiaoshenpi").click(function() { DengZhangShenPi.quXiaoShenPi(this); });
        });
    </script>

</asp:Content>
