<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMomoAdd.aspx.cs" Inherits="Web.UserCenter.UserMomoAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/sytle.css" rel="Stylesheet" />

    <script src="/Js/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/Js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/Js/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body>
    <form id="frm" runat="server">
    <table width="500" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 0 auto;">
        <tbody>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    主题：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input type="text" size="50" id="txtTitle" class="inputtext" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    时间：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input type="text" size="30" runat="server" id="txtDate" onfocus="WdatePicker()"
                        class="inputtext" />
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    内容：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <textarea id="txtContent" class="inputtext" style="height: 60px;" rows="3" cols="40"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    完成状况：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="inputselect">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="8">
                    <table width="340" cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td width="106" height="40" align="center">
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <input type="hidden" id="hidId" runat="server" />
                                    <a href="javascript:;" id="btnSave" runat="server" visible="false">保存</a> <a href="javascript:;"
                                        id="btnUpdate" runat="server" visible="false">修改</a>
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;"  onclick="window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();">
                                        取消</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>

    <script type="text/javascript">
        var UserMemo = {
            Add: function() {
                if (UserMemo.IsValidate()) {
                    $("#btnSave").html("提交中...");
                    UserMemo.UnBind();
                    var Data = { Type: "Save" };
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/UserMomoAdd.aspx?Type=Save",
                        data: $("#frm").serialize(),
                        dataType: "json",
                        success: function(data) {
                            if (data.result == "1") {
                                tableToolbar._showMsg(data.msg, function() {
                                    window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                                    window.parent.location.reload();
                                });
                            }
                            else {
                                tableToolbar._showMsg(data.msg);
                                UserMemo.Bind();
                            }

                        },
                        error: function() {
                            tableToolbar._showMsg("服务器忙！");
                            UserMemo.Bind();
                        }
                    });
                }
            },
            Update: function() {
                if (UserMemo.IsValidate()) {
                    $("#btnUpdate").html("提交中...");
                    UserMemo.UnBind();
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/UserMomoAdd.aspx?Type=Update",
                        data: $("#frm").serialize(),
                        dataType: "json",
                        success: function(data) {
                            if (data.result == "1") {
                                tableToolbar._showMsg(data.msg, function() {
                                    window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                                    window.parent.location.reload();
                                });
                            }
                            else {
                                tableToolbar._showMsg(data.msg);
                                UserMemo.Bind();
                            }

                        },
                        error: function() {
                            tableToolbar._showMsg("服务器忙！");
                            UserMemo.Bind();
                        }
                    });
                }
            },
            UnBind: function() {
                $("#btnSave").unbind("click");
                $("#btnUpdate").unbind("click");
            },
            Bind: function() {
                var _selfs = $("#btnSave");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    if (UserMemo.IsValidate()) {
                        UserMemo.Add();
                        return false;
                    }
                });

                var _selfu = $("#btnUpdate");
                _selfu.html("修改");
                _selfu.css("cursor", "pointer");
                _selfu.click(function() {
                    if (UserMemo.IsValidate()) {
                        UserMemo.Update();
                        return false;
                    }
                });

            },
            IsValidate: function() {
                var title = $("#txtTitle").val();

                if (title == "") {
                    tableToolbar._showMsg("主题不能为空！");
                    return false
                }
                var date = $("#txtDate").val();
                if (date == "") {
                    tableToolbar._showMsg("时间不能为空！");
                    return false;
                }

                var content = $("#txtContent").val();
                if (content == "") {
                    tableToolbar._showMsg("内容不能为空！");
                    return false;
                }
                var status = $("#ddlStatus").val();
                if (status == "") {
                    tableToolbar._showMsg("请选择完成状况！");
                    return false;
                }
                return true;
            }

        };
        $(function() {
            $("#btnSave").click(function() {
                UserMemo.Add();
            });

            $("#btnUpdate").click(function() {
                UserMemo.Update();
            });
        });
    </script>

</body>
</html>
