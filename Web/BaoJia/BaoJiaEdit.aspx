<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaoJiaEdit.aspx.cs" Inherits="Web.BaoJia.BaoJiaEdit"
    MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false" %>

<%@ Register Src="~/UserControl/ShangChuan.ascx" TagName="ShangChuan" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th height="30" align="right" style="width: 10%">
                    报价标题：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtBiaoTi" type="text" class="inputtext" id="txtBiaoTi" runat="server"
                        valid="required" errmsg="请填写报价标题" maxlength="255" style="width: 280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    专线类别：
                </th>
                <td style="background: #E3F1FC">
                    <select name="txtZxlb" id="txtZxlb" valid="required" errmsg="请选择专线类别" class="inputselect">
                        <option value="">请选择</option>
                        <asp:Literal runat="server" ID="ltrZxlbOption"></asp:Literal>
                    </select>                     
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    报价附件：
                </th>
                <td style="background: #E3F1FC">
                    <uc1:ShangChuan runat="server" ID="txtFuJian">
                    </uc1:ShangChuan>
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
    

    <script src="/uploadify3_2_1/jquery.uploadify.js" type="text/javascript"></script>
    <link href="/uploadify3_2_1/uploadify.css" rel="stylesheet" type="text/css" />

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
            baoCun: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!validatorResult) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=baocun", data: $("#<%=form1.ClientID %>").serialize(),
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            iPage.close();
                        } else {
                            $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.baoCun(this); return false; });
            $("#txtZxlb").val("<%=ZxlbId %>");
        });
    </script>

</asp:Content>
