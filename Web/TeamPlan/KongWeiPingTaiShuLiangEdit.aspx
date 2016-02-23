<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KongWeiPingTaiShuLiangEdit.aspx.cs"
    Inherits="Web.TeamPlan.KongWeiPingTaiShuLiangEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="80" height="30" align="right">
                    控位数量：
                </th>
                <td style="background: #E3F1FC">
                    <asp:Literal runat="server" ID="ltrShuLiang"></asp:Literal>
                    <input type="hidden" id="txtShuLiang" runat="server"/>
                </td>
            </tr>
            <tr class="odd">
                <th  height="30" align="right">
                    平台数量：
                </th>
                <td style="background: #E3F1FC">
                    <input type="text" class="inputtext" id="txtPingTaiShuLiang" runat="server" valid="required"
                        errmsg="请填写平台数量" maxlength="100" style="width: 100px;" />
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
    </form>
    
    

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
            submit: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!validatorResult) return false;

                var _pingTaiShuLiang = tableToolbar.getInt($("#<%=txtPingTaiShuLiang.ClientID %>").val());
                var _shuLiang = tableToolbar.getInt($("#<%=txtShuLiang.ClientID %>").val());
                if (_pingTaiShuLiang > _shuLiang) { alert("平台数量不能大于控位数量"); return false; }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=baocun", data: $("#<%=form1.ClientID %>").serialize(),
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.submit(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.submit(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.submit(this); return false; });
        });
    </script>
</asp:Content>
