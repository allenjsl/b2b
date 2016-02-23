<%@ Page Title="个人信息" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="UserInfo.aspx.cs" Inherits="Web.UserCenter.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="mainbody">
            <div class="lineprotitlebox">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">个人中心</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            所在位置>> 个人中心>> 个人信息
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="2" bgcolor="#000000">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="lineCategorybox" style="height: 30px;">
            </div>
            <div class="tablelist">
                <form id="frm">
                <table width="780" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#BDDCF4">
                    <tr>
                        <th colspan="3" align="center" bgcolor="#BDDCF4">
                            填写个人信息
                        </th>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>所属公司：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <label>
                                <% =SiteUserInfo.ZxsName %></label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>所属部门：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <label>
                                <% =SiteUserInfo.DeptName%></label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>密码：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input type="password" class="inputtext" value="<%=SetPwd %>" id="txtPwd" name="txtPwd"
                                valid="required" errmsg="请填写密码!" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>姓名：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input type="text" class="inputtext" size="30" runat="server" id="txtName" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>性别：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input type="radio" id="rbman" name="rbsex" value="2" runat="server" />男
                            <input type="radio" id="rbwoman" name="rbsex" value="1" runat="server" />女
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>职位：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <asp:Literal runat="server" ID="ltJob"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>联系电话：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input class="inputtext" type="text" size="40" id="txtPhone" runat="server" valid="isPhone"
                                errmsg="请填写正确的电话！" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>传真：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input class="inputtext" type="text" size="40" runat="server" id="txtFax" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>手机：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input id="txtMobile" class="inputtext" type="text" size="40" runat="server" valid="isMobile"
                                errmsg="请填写正确的手机！" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>QQ：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input id="txtQQ" class="inputtext" type="text" size="40" runat="server" valid="isQQ"
                                errmsg="请填写正确的QQ号码！" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>MSN：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input id="txtMsn" class="inputtext" runat="server" type="text" size="40" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                            <strong>E-mail：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <input id="txtEmail" class="inputtext" runat="server" type="text" size="40" valid="isEmail"
                                errmsg="请填写正确的email！" />
                        </td>
                    </tr>
                    <tr>
                        <td height="30" colspan="3" align="center">
                            <table border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="86" height="40" align="center" class="tjbtn02">
                                        <a href="javascript:;" id="btnSave">保存</a>
                                    </td>
                                    <td width="86" height="40" align="center" class="tjbtn02">
                                        <a href="javascript:history.go(-1);">返回</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </form>
            </div>
        </div>
        <!-- InstanceEndEditable -->
    </div>

    <script type="text/javascript">
        var User = {
            UnBind: function() {
                $("#btnSave").unbind("click");

            },
            Bind: function() {
                var _selfs = $("#btnSave");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    if (ValiDatorForm.validator($("#frm").get(0), "alert")) {
                        User.Save();
                        return false;
                    }
                });
            },
            Save: function() {
                $("#btnSave").html("提交中...");
                User.UnBind();
                var rbSex = 1;
                if ($("#<%=this.rbman.ClientID %>").attr("checked") == true) {
                    rbSex = 2;
                }
                var Data = { Type: "Save", rbSex: rbSex };
                $.newAjax({
                    type: "post",
                    url: "/UserCenter/UserInfo.aspx?" + $.param(Data),
                    data: $("#frm").serialize(),
                    dataType: "json",
                    success: function(data) {
                        if (data.result == "1") {
                            tableToolbar._showMsg(data.msg, function() {
                                window.location.reload();
                            });
                        }
                        else {
                            tableToolbar._showMsg(data.msg);
                            User.Bind();
                        }


                    },
                    error: function() {
                        tableToolbar._showMsg("服务器忙！");
                        User.Bind();
                    }
                });
            }
        };


        $(function() {
            FV_onBlur.initValid($("#frm").get(0));
            $("#btnSave").click(function() {
                if (ValiDatorForm.validator($("#frm").get(0), "alert")) {
                    // alert($("#frm").serialize());
                    User.Save();
                }
            });

        });
    </script>

</asp:Content>
