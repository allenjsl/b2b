<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JieKuanEdit.aspx.cs" Inherits="Web.Fin.JieKuanEdit"
    MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc1" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 630px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="150" align="right" style="height:30px;">
                    借款日期：
                </th>
                <td width="477" bgcolor="#E3F1FC">
                    <input name="txtRiQi" type="text" class="formsize80 inputtext" id="txtRiQi" onfocus="WdatePicker()"
                        runat="server" valid="required|isDate" errmsg="请填写借款日期|请填写正确的借款日期" />
                </td>
            </tr>
            <tr class="odd">
                <th width="150" align="right" style="height: 30px;">
                    借款金额：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtJinE" type="text" class="formsize80 inputtext" id="txtJinE" runat="server"
                        maxlength="11" valid="required|isNumber" errmsg="请填写借款金额|请填写正确的借款金额" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right" style="height: 30px;">
                    借款原因：
                </th>
                <td bgcolor="#E3F1FC">
                    <textarea name="txtYuanYin" rows="3" class="formsize450 inputarea" id="txtYuanYin"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th align="right" style="height: 30px;">
                    借款人：
                </th>
                <td bgcolor="#E3F1FC">
                    <uc1:SellsSelect runat="server" ID="txtJieKuanRen" ReadOnly="true" IsShowSelect="true"
                        SetTitle="借款人" runat="server" />
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" bgcolor="#E3F1FC">
                    <table border="0" align="center" cellpadding="0" cellspacing="0" visible="true">    
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
                var _data = { txtRiQi: $.trim($("#<%=txtRiQi.ClientID %>").val()),
                    txtJinE: $.trim($("#<%=txtJinE.ClientID %>").val()),
                    txtYuanYin: $.trim($("#<%=txtYuanYin.ClientID %>").val()),
                    txtJieKuanRenId: $.trim($("#<%=txtJieKuanRen.SellsIDClient %>").val())
                };

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return;

                if (parseFloat(_data.txtJinE) == 0) {
                    parent.tableToolbar._showMsg("请输入正确的借款金额");
                    return;
                }
                if (_data.txtYuanYin.length > 255) {
                    parent.tableToolbar._showMsg("借款原因最多255个字符"); return;
                }

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
            $("#a_save").bind("click", function() { iPage.save(this); return false; });
        });
    </script>

</asp:Content>
