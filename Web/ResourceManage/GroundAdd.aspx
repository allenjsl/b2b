<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="GroundAdd.aspx.cs" Inherits="Web.ResourceManage.GroundAdd" %>

<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc3" %>
<%@ Register Src="../UserControl/Contact.ascx" TagName="Contact" TagPrefix="uc4" %>
<%@ Register Src="../UserControl/BankContact.ascx" TagName="BankContact" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top: 10px;">
            <tr class="odd">
                <th  width="95" height="30" align="center">
                    <span style="color: red">*</span>ʡ�ݣ�
                </th>
                <td width="330" align="left">
                    <select name="txtProvince" id="txtProvince" class="inputselect" valid="required"
                        errmsg="��ѡ��ʡ��!"> </select>                    
                </td>
                <th width="80" align="center">
                    ���У�
                </th>
                <td width="330" align="left">
                    <select name="txtCity" id="txtCity" class="inputselect">
                    </select>
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="center">
                    <span style="color: red">*</span>��λ���ƣ�
                </th>
                <td align="left">
                    <input type="text" id="unionname" name="unionname" value="" runat="server" class="searchinput searchinput02"
                        valid="required" errmsg="��λ����Ϊ��" />
                    <span id="errMsg_unionname" class="errmsg"></span>
                </td>
                <th align="center">
                    ��ַ��
                </th>
                <td align="left">
                    <input type="text" id="txtAddress" name="txtAddress" value="" runat="server" class="searchinput searchinput02" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    ����Э�飺
                </th>
                <td align="left" class="updom">
                    <uc3:UploadControl ID="UploadControl1" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                    <asp:Label runat="server" ID="lbfilename"></asp:Label>
                </td>
                <th align="center">
                    &nbsp;
                </th>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    ����������
                </th>
                <td colspan="3" align="left" class="updom">
                    <uc3:UploadControl ID="UploadControl2" runat="server" IsUploadMore="true" IsUploadSelf="true" />
                </td>
            </tr>
            <tr class="even">
                <th align="center">
                    ��ϵ�ˣ�
                </th>
                <td colspan="3" align="left">
                    <uc4:Contact ID="Contact1" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th height="60" align="center">
                    �����˻���
                </th>
                <td colspan="3">
                    <uc5:BankContact ID="BankContact1" runat="server" />
                </td>
            </tr>
            <tr class="even">
                <th height="60" align="center">
                    ��ע��
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
                    <a href="###" style="display: <%=!show?"block":"none"%>" class="save" id="save">
                        ����</a>
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:;" id="linkCancel" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()">
                        �ر�</a>
                </td>
                <input type="hidden" name="tid" value="<%=tid %>" />
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function RemoveFile(obj) {
            $(obj).parent().remove();
        }

        $(function() {
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

    </form>
</asp:Content>
