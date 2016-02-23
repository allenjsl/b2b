<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="OtherAdd.aspx.cs" Inherits="Web.ResourceManage.OtherAdd" %>

<%@ Register Src="../UserControl/Contact.ascx" TagName="Contact" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc5" %>
<%@ Register Src="../UserControl/BankContact.ascx" TagName="BankContact" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <table width="900" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top: 10px;">
        <tr class="odd">
            <th  width="95" align="center">
                <span style="color: red">*</span>省份：
            </th>
            <td width="330" align="left">
                <select name="txtProvince" id="txtProvince" class="inputselect" valid="required"
                    errmsg="请选择省份!">
                </select>
            </td>
            <th width="80" align="center">
                城市：
            </th>
            <td width="330" align="left">
                <select name="txtCity" id="txtCity" class="inputselect">
                </select>
            </td>
        </tr>
        <tr class="even">
            <th height="30" align="center">
                <span style="color: red">*</span>单位名称：
            </th>
            <td colspan="3" align="left">
                <input class="inputtext" type="text" id="unionname" name="unionname" value=" " runat="server"
                    valid="required" errmsg="单位不能为空" />
            </td>
        </tr>
        <tr class="odd">
            <th height="30" align="center">
                地址：
            </th>
            <td colspan="3" align="left">
                <input class="inputtext" type="text" id="txtAddress" name="txtAddress" value="" runat="server" />
            </td>
        </tr>
        <tr class="even">
            <th height="30" align="center">
                合作协议：
            </th>
            <td colspan="3" align="left" class="updom">
                <uc5:UploadControl ID="UploadControl1" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr class="odd">
            <th height="30" align="center">
                其它附件：
            </th>
            <td colspan="3" align="left" class="updom">
                <uc5:uploadcontrol id="UploadControl2" runat="server" isuploadmore="true" isuploadself="true" />
            </td>
        </tr>
        <tr class="even">
            <th align="center">
                联系人：
            </th>
            <td colspan="3" align="left">
                <uc2:Contact ID="Contact1" runat="server" />
            </td>
        </tr>
        <tr class="odd">
            <th>
                银行账户：
            </th>
            <td colspan="3">
                <uc1:BankContact ID="BankContact1" runat="server" />
            </td>
        </tr>
        <tr class="even">
            <th height="60" align="center">
                备注：
            </th>
            <td colspan="3">
                <textarea name="remark" id="remark" cols="45" rows="5" class="inputarea formsize600"
                    runat="server"></textarea>
            </td>
        </tr>
    </table>
    <table id="aa" width="320" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
            </td>
            <%if (!show)
              { %>
            <td height="40" align="center" class="tjbtn02">
                <a href="javascript:;" class="save" id="save">保存</a>
            </td>
            <%} %>
            <td height="40" align="center" class="tjbtn02">
                <a href="javascript:;" id="linkCancel" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()">
                    关闭</a>
            </td>
            <input type="hidden" name="tid" value="<%=tid %>" />
        </tr>
    </table>
    </form>

    <script type="text/javascript">
        function RemoveFile(obj) {
            $(obj).parent().remove();
        };
        $(function() {
            $("#tblbank").autoAdd({ tempRowClass: "trbank", addButtonClass: "addbtn", delButtonClass: "delbtn", indexClass: "indexcontact" });
            var form = $("#save").closest("form").get(0);
            $("#save").click(function() {
                if (ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent")) {
                    form.submit();
                }
            });
            pcToobar.init({
                pID: "#txtProvince",
                cID: "#txtCity",
                pSelect: '<%= ProvinceId %>',
                cSelect: '<%= CityId %>',
                comID: '<%= this.SiteUserInfo.CompanyId %>',
                isCy: "0"
            });
        });



    </script>

</asp:Content>
