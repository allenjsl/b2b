<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="TicketAdd.aspx.cs" Inherits="Web.ResourceManage.TicketAdd" %>

<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc3" %>
<%@ Register Src="../UserControl/Contact.ascx" TagName="Contact" TagPrefix="uc4" %>
<%@ Register Src="../UserControl/BankContact.ascx" TagName="BankContact" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <table width="900" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top: 10px;">
        <tr class="odd">
            <th width="95" height="30" align="center">
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
            <td align="left">
                <input type="text" id="unionname" name="unionname" value="" runat="server" class="searchinput searchinput02"
                    valid="required" errmsg="单位不能为空" />
                <span id="errMsg_unionname" class="errmsg"></span>
            </td>
            <th align="center">
                地址：
            </th>
            <td align="left">
                <input type="text" id="txtAddress" name="txtAddress" value="" runat="server" class="searchinput searchinput02" />
            </td>
        </tr>
        <tr class="odd">
            <th height="30" align="center">
                合作协议：
            </th>
            <td colspan="3" align="left" class="updom">
                <uc3:UploadControl ID="UploadControl1" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr class="odd">
            <th height="30" align="center">
                其它附件：
            </th>
            <td colspan="3" align="left" class="updom">
                <uc3:UploadControl ID="UploadControl2" runat="server" IsUploadMore="true" IsUploadSelf="true" />
            </td>
        </tr>
        <tr class="even">
            <th align="center">
                联系人：
            </th>
            <td colspan="3" align="left">
                <uc4:Contact ID="Contact1" runat="server" />
            </td>
        </tr>
        <tr class="even">
            <th height="60" align="center">
                政策：
            </th>
            <td colspan="3">
                <textarea name="police" id="police" cols="45" rows="5" class="inputarea formsize600"
                    runat="server"></textarea>
            </td>
        </tr>
        <tr class="odd">
            <th height="60" align="center">
                银行账户：
            </th>
            <td colspan="3">
                <uc5:BankContact ID="BankContact1" runat="server" />
            </td>
        </tr>
        <tr class="odd">
            <th height="60" align="center">
                备注：
            </th>
            <td colspan="3">
                <textarea name="remark" id="remark" cols="45" rows="5" class="inputarea formsize600"
                    runat="server"></textarea>
            </td>
        </tr>
    </table>
    <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
            </td>
            <td height="40" align="center" class="tjbtn02">
                <%if (!show)
                  { %><a id="save" href="javascript:;" class="save">保存</a><%} %>
            </td>
            <td height="40" align="center" class="tjbtn02">
                <a href="javascript:;" id="linkCancel" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()">
                    关闭</a>
            </td>
            <input type="hidden" name="tid" value="<%=tid %>" />
        </tr>
    </table>

    <script type="text/javascript">
        function RemoveFile(obj) {
            $(obj).parent().remove();
        };

        $(function() {
            $("a.save").click(function() {
                var form = $(this).closest("form").get(0);
                if (ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent")) {
                    form.submit();
                }
                return false;
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

    </form>
</asp:Content>
