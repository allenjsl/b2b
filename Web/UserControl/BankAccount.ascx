<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankAccount.ascx.cs"
    Inherits="Web.UserControl.BankAccount" %>
<table width="500" cellspacing="1" cellpadding="0" border="0" class="table_white autoAdd"
    id="tabBankAccount">
    <tbody>
        <tr>
            <th align="center">
                账户名称
            </th>
            <th align="center">
                开户银行
            </th>
            <th align="center">
                银行账号
            </th>
            <th align="center">
                操作
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="phdefault">
            <tr class="tempRow">
                <td height="30" align="center">
                    <span class="index"></span>
                    <input type="text" size="10" value="" class="xtinput" name="txtAccountName" />
                </td>
                <td align="center">
                    <input type="text" size="18" value="" class="xtinput inputtext" name="txtBankName" />
                </td>
                <td align="center">
                    <input type="text" size="22" value="" class="xtinput inputtext" name="txtAccount" />
                </td>
                <td align="center">
                    <a class="addbtn" href="javascript:void(0)">
                        <img width="48" height="20" src="../images/addimg.gif" alt="" /></a> <a class="delbtn"
                            href="javascript:void(0)">
                            <img width="48" height="20" src="../images/delimg.gif" alt="" /></a>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:Repeater runat="server" ID="rptlist">
            <ItemTemplate>
                <tr class="tempRow">
                    <td height="30" align="center">
                        <span class="index"></span>
                        <input type="text" size="10" value='<%#Eval("AccountName") %>' class="xtinput" name="txtAccountName" />
                    </td>
                    <td align="center">
                        <input type="text" size="18" value='<%#Eval("BankName") %>' class="xtinput inputtext"
                            name="txtBankName" />
                    </td>
                    <td align="center">
                        <input type="text" size="22" value='<%#Eval("BankNo") %>' class="xtinput inputtext"
                            name="txtAccount" />
                    </td>
                    <td align="center">
                        <a class="addbtn_a" href="javascript:void(0)">
                            <img width="48" height="20" src="../images/addimg.gif" alt="" /></a> <a class="delbtn_a"
                                href="javascript:void(0)">
                                <img width="48" height="20" src="../images/delimg.gif" alt="" /></a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

<script type="text/javascript">
    $(function() {
        $("#tabBankAccount").autoAdd({ addButtonClass: "addbtn_a", delButtonClass: "delbtn_a" });
    })
    
</script>

