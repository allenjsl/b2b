<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YinHangZhangHuEdit.aspx.cs"
    Inherits="Web.Fin.YinHangZhangHuEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="120" height="30" align="right">
                    账户性质：
                </th>
                <td bgcolor="#E3F1FC">
                    <select id="txtXingZhi" name="txtXingZhi" class="inputselect">
                        <asp:Literal runat="server" ID="ltrXingZhiHtml"></asp:Literal>
                    </select>
                </td>
                <th width="120" align="right">
                    账户名称：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtName" type="text" class="formsize120 inputtext" id="txtName" runat="server"
                        valid="required" errmsg="请填写账户名称" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    开户银行：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <input name="txtYinHangName" type="text" class="formsize140 inputtext" id="txtYinHangName"
                        runat="server" valid="required" errmsg="请填写开户银行" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    银行账号：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <input name="txtZhangHao" type="text" class="formsize140 inputtext" id="txtZhangHao"
                        runat="server" valid="required" errmsg="请填写银行账号" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    原始金额：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <input name="txtJinE" type="text" class="formsize80 inputtext" id="txtJinE" runat="server"
                        valid="required|isNumber" errmsg="请填写原始金额|请填写正确的原始金额" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    附件上传：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <uc1:UploadControl ID="UploadFuJian" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    账户类型：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <select name="txtLeiXing" id="txtLeiXing" class="inputselect">
                    <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing)), "")%>
                    </select>
                </td>
            </tr>
            <tr class="even">
                <td colspan="4" style="color:#666; height:30px;">
                    说明：账户类型为<b>收付款账户</b>的供系统内<b>收付款操作</b>时使用。账户类型为<b>打印单据账户</b>的供系统内<b>打印单据</b>使用。
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
            reload: function() {
                window.location.href = window.location.href;
            },
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            save: function(obj) {
                var _data = { txtJinE: $.trim($("#<%=txtJinE.ClientID %>").val()),
                    txtName: $.trim($("#<%=txtName.ClientID %>").val()),
                    txtXingZhi: $.trim($("#txtXingZhi").val()),
                    txtYinHangName: $.trim($("#<%=txtYinHangName.ClientID %>").val()),
                    txtZhangHao: $.trim($("#<%=txtZhangHao.ClientID %>").val()),
                    txtFilePath: $.trim($("input[name='<%=UploadFuJian.ClientHideID %>']").val()),
                    txtYFilePath: $.trim($("input[name='<%=UploadFuJian.YuanFilePathClientName %>']").val()),
                    txtLeiXing: $("#txtLeiXing").val()
                };

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return;

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
            $("#i_a_save").bind("click", function() { iPage.save(this); });
            swfUploadHandler.init({ movies: [window["<%=UploadFuJian.ClientID %>"]], startFn: function() { $("#i_a_save").unbind("click").css({ "color": "#999999" }); }, completeFn: function() { $("#i_a_save").bind("click", function() { iPage.save(this); }).css({ "color": "" }); } });

            $("#txtLeiXing").val("<%=LeiXing %>");
        });
    </script>

</asp:Content>
