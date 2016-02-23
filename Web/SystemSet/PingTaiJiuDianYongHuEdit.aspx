<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PingTaiJiuDianYongHuEdit.aspx.cs"
    Inherits="Web.SystemSet.PingTaiJiuDianYongHuEdit" MasterPageFile="~/MasterPage/Boxy.Master"
    ValidateRequest="false" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span style="color: red">*</span>登录账号：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtYongHuMing" type="text" class="inputtext" id="txtYongHuMing" runat="server"
                        valid="required" errmsg="请填写用户名" maxlength="100" style="width: 180px;" />
                </td>
                <th width="80"align="right">
                    <span style="color: red;" id="i_span_mima">*</span>登录密码：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtMiMa" type="password" class="inputtext" id="txtMiMa" runat="server"
                        maxlength="100" style="width: 180px;" valid="required" errmsg="请填写登录密码" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <span style="color: red">*</span>真实姓名：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtXingMing" type="text" class="inputtext" id="txtXingMing" runat="server"
                        valid="required" errmsg="请填写姓名" maxlength="100" style="width: 180px;" />
                </td>
                <th align="right">
                    性别：
                </th>
                <td style="background: #E3F1FC">
                   <select name="txtXingBie" id="txtXingBie">
                        <option value="">-请选择-</option>
                       <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.Sex),new string[]{"0"}), "")%>
                   </select>
                </td>                
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <span style="color: red">*</span>联系电话：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtDianHua" type="text" class="inputtext" id="txtDianHua" runat="server"
                        maxlength="100" style="width: 180px;" valid="required" errmsg="请填写联系电话" />
                </td>
                <th align="right">
                    联系传真：
                </th>
                <td style="background: #E3F1FC">
                   <input name="txtFax" type="text" class="inputtext" id="txtFax" runat="server" maxlength="100"
                       style="width: 180px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <span style="color: red">*</span>联系手机：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtShouJi" type="text" class="inputtext" id="txtShouJi" runat="server"
                        maxlength="100" style="width: 180px;" valid="required" errmsg="请填写联系手机" />
                </td>
                <th align="right">
                    联系邮箱：
                </th>
                <td style="background: #E3F1FC">
                   <input name="txtYouXing" type="text" class="inputtext" id="txtYouXing" runat="server"
                       maxlength="100" style="width: 180px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    联系QQ：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtQQ" type="text" class="inputtext" id="txtQQ" runat="server" maxlength="100"
                        style="width: 180px;" />
                </td>
                <th align="right">
                    微信号：
                </th>
                <td style="background: #E3F1FC">
                   <input name="txtWeiXinHao" type="text" class="inputtext" id="txtWeiXinHao" runat="server"
                       maxlength="100" style="width: 180px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    简介：
                </th>
                <td height="30" colspan="3" bgcolor="#E3F1FC">
                    <textarea cols="80" rows="5" id="txtJianJie" class="inputtext" style="height: 100px"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    备注：
                </th>
                <td height="30" colspan="3" bgcolor="#E3F1FC">
                    <textarea cols="80" rows="5" id="txtBeiZhu" class="inputtext" style="height: 100px"
                        runat="server"></textarea>
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
            baoCun: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!validatorResult) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=baocun", data: $("#<%=form1.ClientID %>").serialize(),
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.close();
                        } else {
                            alert(response.msg);
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
            $("#txtXingBie").val("<%=XingBie %>");
            if ("<%=EditId %>" != "0") {
                $("#i_span_mima").hide();
                $("#<%=txtMiMa.ClientID %>").removeAttr("valid").removeAttr("errmsg");
            }
        });
    </script>
</asp:Content>
