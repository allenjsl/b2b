<%@ Page Title="新增修改政策" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="PolicyAdd.aspx.cs" Inherits="Web.LineProduct.PolicyAdd" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server">
    <table width="500" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
        <tbody>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    政策标题：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input runat="server" type="text" size="62" id="txtTitle" class="xtinput inputtext"
                        name="txtTitle" valid="required" errmsg="请填写政策标题!" maxlength="80">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    政策附件：
                </th>
                <td bgcolor="#E3F1FC">
                    <cc1:UploadControl runat="server" ID="UploadZCFJ" />
                    <asp:Literal runat="server" ID="ltrZCFJ"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    发布时间：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input runat="server" type="text" disabled="disabled" id="txtDate" class="formsize140 inputtext"
                        name="txtDate">
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    发布人：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input runat="server" type="text" disabled="disabled" id="txtContact" class="formsize80 inputtext"
                        name="txtContact">
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    政策状态：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <select name="txtStatus" class="inputselect">
                        <asp:Literal runat="server" ID="ltrStatusOptions"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="8">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="76" height="40" align="center" class="tjbtn02">
                                <asp:LinkButton runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        var PolicyEdit = {
            //删除附件
            RemoveFile: function(obj) {
                $(obj).closest("td").find("input[name='hide_Route_file']").val("");
                $(obj).closest("div[class='upload_filename']").remove();
                return false;
            },
            //按钮绑定事件
            BindBtn: function() {
                $("#<%= btnSave.ClientID %>").unbind("click").click(function() {
                    if (ValiDatorForm.validator($("#<%= btnSave.ClientID %>").closest("form").get(0), "parent")) {
                        $("#<%= btnSave.ClientID %>").unbind("click");
                        $("#<%= btnSave.ClientID %>").html("正在提交");
                        return true;
                    }
                    return false;
                })
            }
        }

        $(document).ready(function() {
            PolicyEdit.BindBtn();
        });
    </script>

    </form>
</asp:Content>
