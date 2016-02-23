<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShouKuanShenPiBoxy.aspx.cs"
    Inherits="Web.Fin.ShouKuanShenPiBoxy" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 630px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="150" align="right">
                    银行实际业务日期：
                </th>
                <td width="477" bgcolor="#E3F1FC">
                    <input name="txtBankDate" type="text" class="formsize80 inputtext" id="txtBankDate" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th width="150" align="right">
                    审核备注：
                </th>
                <td bgcolor="#E3F1FC">
                    <textarea name="txtBeiZhu" rows="3" class="formsize450 inputarea" id="txtBeiZhu" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    审核人：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtName" type="text" class="formsize140 inputtext" disabled="disabled" id="txtName" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    审核时间：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtTime" type="text" class="formsize140 inputtext" disabled="disabled" id="txtTime" runat="server" />
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
                if (!confirm("收款审批操作不可逆，你确定要审批吗？")) return;
                var _data = { txtBankDate: $.trim($("#<%=txtBankDate.ClientID %>").val()),
                    txtBeiZhu: $.trim($("#<%=txtBeiZhu.ClientID%>").val())
                };

                if (_data.txtBankDate.length == 0) {
                    parent.tableToolbar._showMsg("请填写银行实际业务日期");
                    return;
                }
                if (_data.txtBeiZhu.length > 255) {
                    parent.tableToolbar._showMsg("备注内容最多可输入255个字符");
                    return;
                }


                $(obj).unbind("click").css({ "color": "#999999" });

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
                            //var _win = parent.Boxy.getIframeWindow('<%=EyouSoft.Common.Utils.GetQueryStringValue("refererWinId") %>');
                            //_win.location.href = _win.location.href;
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
            //审批
            quXiaoShenPi: function(obj) {
                if (!confirm("取消审批操作不可逆，你确定要取消审批吗？")) return;
                var _data = { };

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
            $("#a_save").bind("click", function() { iPage.shenPi(this); });
            $("#<%=txtBankDate.ClientID %>").bind("focus", function() { WdatePicker({ maxDate: '<%=DateTime.Now.ToString("yyyy-MM-dd") %>' }); });
            $("#i_a_quxiaoshenpi").click(function() { iPage.quXiaoShenPi(this); });
        });
    </script>
</asp:Content>