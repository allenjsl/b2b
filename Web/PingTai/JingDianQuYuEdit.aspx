<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingDianQuYuEdit.aspx.cs"
    Inherits="Web.PingTai.JingDianQuYuEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 98%; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="100" height="30" align="right">
                    区域名称：
                </th>
                <td>
                    <input name="txtMingCheng" type="text" class="formsize120 inputtext" id="txtMingCheng"
                        runat="server" valid="required" errmsg="请填写区域名称" maxlength="10" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    排序值：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtPaiXuId" type="text" class="inputtext" id="txtPaiXuId" runat="server"
                        value="0" maxlength="5" style="width: 100px;" />
                    <span style="color: #666">(按值升序排列)</span>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
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
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            save: function(obj) {
                var _data = { txtMingCheng: $.trim($("#<%=txtMingCheng.ClientID %>").val()), txtPaiXuId: $.trim($("#<%=txtPaiXuId.ClientID %>").val()) };

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=save",
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
                            $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
        });
    </script>

</asp:Content>
