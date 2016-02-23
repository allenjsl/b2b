<%@ Page Title="请假申请" MasterPageFile="~/MasterPage/Boxy.Master" Language="C#" AutoEventWireup="true"
    CodeBehind="VacaAdd.aspx.cs" Inherits="Web.UserCenter.VacaAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="frm" runat="server">
    <table width="500" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    请假时间：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input type="text" style="width: 80px;" id="txtStartDate" runat="server" class="inputtext"
                        onfocus="WdatePicker()" />
                    <input type="text" id="txtStartTime" runat="server" class="inputtext" style="width: 60px;" />
                    -
                    <input type="text" style="width: 80px;" id="txtEndDate" runat="server" class="inputtext"
                        onfocus="WdatePicker()" />
                    <input type="text" id="txtEndTime" runat="server" class="inputtext" style="width: 60px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    申请人：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input type="text" disabled="disabled" size="10" value="<%=SiteUserInfo.Name %>"
                        id="textfield9" class="inputtext" name="textfield9" />
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    请假原因：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <textarea id="txtReason" runat="server" rows="3" cols="40" class="inputarea"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    请假性质：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="inputselect">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    调班情况：
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" id="txtSituation" runat="server" size="60" class="inputtext" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    申请时间：
                </th>
                <td bgcolor="#E3F1FC">
                    <input type="text" size="20" value="<%=DateTime.Now.ToString() %>" id="textfield2"
                        class="inputtext" disabled="disabled" name="textfield2" />
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
                                    <a href="javascript:;" onclick="window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();">
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
        var Vaca = {
            Add: function() {
                if (Vaca.IsValidate()) {
                    $("#<%=this.btnSave.ClientID %>").html("提交中...");
                    Vaca.UnBind();
                    var Data = { Type: "Save" };
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/VacaAdd.aspx?Type=Save",
                        data: $("#<%=this.frm.ClientID %>").serialize(),
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
                                Vaca.Bind();
                            }

                        },
                        error: function() {
                            tableToolbar._showMsg("服务器忙！");
                            Vaca.Bind();
                        }
                    });
                }
            },
            Update: function() {
                if (Vaca.IsValidate()) {
                    $("#<%=this.btnUpdate.ClientID %>").html("提交中...");
                    Vaca.UnBind();
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/VacaAdd.aspx?Type=Update",
                        data: $("#<%=this.frm.ClientID %>").serialize(),
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
                                Vaca.Bind();
                            }

                        },
                        error: function() {
                            tableToolbar._showMsg("服务器忙！");
                            Vaca.Bind();
                        }
                    });
                }
            },
            UnBind: function() {
                $("#<%=this.btnSave.ClientID %>").unbind("click");
                $("#<%=this.btnUpdate.ClientID %>").unbind("click");
            },
            Bind: function() {
                var _selfs = $("#<%=this.btnSave.ClientID %>");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    if (Vaca.IsValidate()) {
                        Vaca.Add();
                        return false;
                    }
                });

                var _selfu = $("#<%=this.btnUpdate.ClientID %>");
                _selfu.html("修改");
                _selfu.css("cursor", "pointer");
                _selfu.click(function() {
                    if (Vaca.IsValidate()) {
                        Vaca.Update();
                        return false;
                    }
                });

            },
            IsValidate: function() {
                if ($("#<%=this.txtStartDate.ClientID %>").val() == "") {
                    tableToolbar._showMsg("请假开始日期不能为空！");
                    return false;
                }
                if ($("#<%=this.txtStartTime.ClientID %>").val() == "") {
                    tableToolbar._showMsg("请假开始时间不能为空！");
                    return false;
                }
                if ($("#<%=this.txtEndDate.ClientID %>").val() == "") {
                    tableToolbar._showMsg("请假结束日期不能为空！");
                    return false;
                }
                if ($("#<%=this.txtEndTime.ClientID %>").val() == "") {
                    tableToolbar._showMsg("请假结束时间不能为空！");
                    return false;
                }
                if ($("#<%=this.txtReason.ClientID %>").val() == "") {
                    tableToolbar._showMsg("请假原因不能为空！");
                    return false;
                }
                if ($("#<%=this.ddlStatus.ClientID %>").val() == "") {
                    tableToolbar._showMsg("请选择请假性质！");
                    return false;
                }
                if ($("#<%=this.txtSituation.ClientID %>").val() == "") {
                    tableToolbar._showMsg("调班状况不能为空！");
                    return false;
                }
                return true;
            }

        };
        $(function() {

            $("#<%=this.btnSave.ClientID %>").click(function() {
                Vaca.Add();
            });

            $("#<%=this.btnUpdate.ClientID %>").click(function() {
                Vaca.Update();
            });
        });
    </script>

</asp:Content>
