<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="Web.UserControl.Contact" %>
<table width="99%" cellspacing="0" cellpadding="0" border="0" style="height: auto;
    margin: 0 auto; zoom: 1; overflow: hidden;" id="contact_tbl">
    <tbody>
        <tr style="height: 28px;">
            <td bgcolor="#B7E0F3" align="center" class="alertboxTableT">
                姓名
            </td>
            <td bgcolor="#B7E0F3" align="center" class="alertboxTableT">
                职务
            </td>
            <td bgcolor="#B7E0F3" align="center" class="alertboxTableT">
                电话
            </td>
            <td bgcolor="#B7E0F3" align="center" class="alertboxTableT">
                手机
            </td>
            <td bgcolor="#B7E0F3" align="center" class="alertboxTableT">
                QQ
            </td>
            <td bgcolor="#B7E0F3" align="center" class="alertboxTableT">
                E-mail
            </td>
            <td bgcolor="#B7E0F3" align="center" class="alertboxTableT">
                传真
            </td>
            <td bgcolor="#B7E0F3" align="center" class="alertboxTableT">
                操作
            </td>
        </tr>
        <asp:PlaceHolder runat="server" ID="ph_showorhide">
            <tr class="Trcontact">
                <td height="28" align="center">
                    <input type="hidden" value='0' name="txtLxrId" />
                    <input type="text" value="" errmsg="请输入联系人名称!" valid="required" class="inputtext formsize70"
                        name="Name">
                </td>
                <td align="center">
                    <input type="text" value="" class="inputtext formsize70" name="Post">
                </td>
                <td align="center">
                    <input type="text" value="" valid="isTelephone" errmsg="电话格式错误!" class="inputtext"
                        name="TelPhone" style="width: 100px;">
                </td>
                <td align="center">
                    <input type="text" value="" valid="isTelephone" errmsg="手机格式错误!" class="inputtext"
                        name="Mobel" style="width: 100px;">
                </td>
                <td align="center">
                    <input type="text" valid="isQQ" errmsg="QQ格式错误!" class="inputtext formsize70" value=""
                        digits="true" errmsg="请输入正确的QQ!" name="QQ">
                </td>
                <td align="center">
                    <input type="text" value="" valid="isEmail" errmsg="邮箱格式错误!" class="inputtext formsize120"
                        name="EMail">
                </td>
                <td align="center">
                    <input type="text" value="" class="inputtext" name="Fax" style="width: 100px;">
                </td>
                <td align="center">
                    <a class="addcontact" href="javascript:void(0)">
                        <img width="48" height="20" src="/images/addimg.gif"></a> <a class="delcontact" href="javascript:void(0)">
                            <img src="/images/delimg.gif"></a>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <tr class="Trcontact">
                    <td height="28" align="center">
                        <input type="hidden" name="txtLxrId" value="<%#Eval("Id") %>" />
                        <input type="text" errmsg="请输入联系人名称!" valid="required" value="<%#Eval("ContactName")%>"
                            class="inputtext formsize70" name="Name"><font class="fontbsize12">*</font>
                    </td>
                    <td align="center">
                        <input type="text" value="<%#Eval("JobTitle")%>" class="inputtext formsize70" name="Post">
                    </td>
                    <td align="center">
                        <input type="text" valid="isTelephone" errmsg="电话格式错误!" value="<%#Eval("ContactTel")%>"
                            class="inputtext" name="TelPhone" style="width: 100px;">
                    </td>
                    <td align="center">
                        <input type="text" valid="isTelephone" errmsg="手机格式错误!" value="<%#Eval("ContactMobile")%>"
                            class="inputtext" name="Mobel" style="width: 100px;">
                    </td>
                    <td align="center">
                        <input type="text" valid="isQQ" errmsg="QQ格式错误!" class="inputtext formsize70" value="<%#Eval("Qq")%>"
                            digits="true" name="QQ">
                    </td>
                    <td align="center">
                        <input type="text" valid="isEmail" errmsg="邮箱格式错误!" value="<%#Eval("Email")%>" class="inputtext formsize120"
                            name="EMail">
                    </td>
                    <td align="center">
                        <input type="text" value="<%#Eval("ContactFax") %>" class="inputtext" name="Fax" style="width:100px;">
                    </td>
                    <td align="center">
                        <a class="addcontact" href="javascript:void(0)">
                            <img width="48" height="20" src="/images/addimg.gif"></a> <a class="delcontact" href="javascript:void(0)">
                                <img src="/images/delimg.gif"></a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

<script type="text/javascript">
    $(function() {
        $("#contact_tbl").autoAdd({tempRowClass:"Trcontact",addButtonClass:"addcontact",delButtonClass:"delcontact",indexClass: "indexcontact"})

    })
    
</script>

