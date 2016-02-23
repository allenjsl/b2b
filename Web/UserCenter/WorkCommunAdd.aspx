<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front.Master"
    CodeBehind="WorkCommunAdd.aspx.cs" Inherits="Web.UserCenter.WorkCommunAdd" ValidateRequest="false" Title="工作交流-个人中心" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <!-- InstanceBeginEditable name="EditRegion3" -->
        <div class="mainbody">
            <div class="lineprotitlebox">
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td width="15%" nowrap="nowrap">
                                <span class="lineprotitle">个人中心</span>
                            </td>
                            <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                                所在位置&gt;&gt; <a href="#">个人中心</a>&gt;&gt; 工作交流
                            </td>
                        </tr>
                        <tr>
                            <td height="2" bgcolor="#000000" colspan="2">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div style="height: 50px;" class="lineCategorybox">
                <table cellspacing="0" cellpadding="0" border="0" class="grzxnav">
                    <tbody>
                        <tr>
                            <%--<td width="108" align="center">
                                <a href="/UserCenter/WorkReport.aspx">工作汇报</a>
                            </td>
                            <td width="108" align="center">
                                <a href="/UserCenter/WorkPlan.aspx">工作计划</a>
                            </td>--%>
                            <td width="108" align="center" class="grzxnav-on">
                                <a href="/UserCenter/WorkCommun.aspx">工作交流</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tablelist">
                <form runat="server" id="frm">
                <asp:HiddenField ID="hidId" runat="server" />
                <table width="880" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4" align="center">
                    <tbody>
                        <tr>
                            <th bgcolor="#BDDCF4" align="center" colspan="3">
                                <asp:Literal runat="server" ID="ltTitle"></asp:Literal>
                            </th>
                        </tr>
                        <tr>
                            <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                                <span style="color: red">*</span><strong>类别：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <asp:DropDownList runat="server" ID="ddlStatus" CssClass="inputselect">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                                <span style="color: red">*</span><strong>标题：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="inputtext"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <span style="color: red">*</span> <strong>交流内容：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <strong>附件：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <uc1:UploadControl runat="server" ID="UploadControl1" />
                                <asp:Label runat="server" ID="lblFilePath"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <strong>发布人：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <label>
                                    <asp:Literal runat="server" ID="ltName"></asp:Literal>
                                </label>
                                <asp:CheckBox Text="匿名" ID="cbIsAnonymous" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <strong>发布时间：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <label>
                                    <asp:Literal ID="ltCreateDate" runat="server"></asp:Literal></label>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="center" colspan="3">
                                <table cellspacing="0" cellpadding="0" border="0" align="center">
                                    <tbody>
                                        <tr>
                                            <td width="86" height="40" align="center" class="tjbtn02">
                                                <a id="btnSave" runat="server" visible="false" href="javascript:;">保存</a>
                                            </td>
                                            <td width="86" height="40" align="center" class="tjbtn02">
                                                <a id="btnUpdate" runat="server" visible="false" href="javascript:;">修改</a>
                                            </td>
                                            <td width="86" height="40" align="center" class="tjbtn02">
                                                <a href="javascript:history.go(-1);">返回</a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </form>
            </div>
        </div>
        <!-- InstanceEndEditable -->
    </div>

    <script type="text/javascript">
        var Commun = {
            CreateCommunEdit: function() {
                //创建行程编辑器
            KEditer.init('<%=txtContent.ClientID %>', { resizeMode: 0, items: keSimple, height: "35px", width: "670px" });
            },
            Add: function() {
                if (Commun.IsValidate()) {
                    $("#<%=this.btnSave.ClientID %>").html("提交中...");
                    Commun.UnBind();
                    Commun.DoAjax("Save");
                }
            },
            Update: function() {
                if (Commun.IsValidate()) {
                    $("#<%=this.btnUpdate.ClientID %>").html("提交中...");
                    Commun.UnBind();
                    Commun.DoAjax("Update");
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
                    Commun.Add();
                    return false;
                });

                var _selfs = $("#<%=this.btnUpdate.ClientID %>");
                _selfs.html("修改");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    Commun.Update();
                    return false;
                });
            },
            IsValidate: function() {
                var status = $("#<%=this.ddlStatus.ClientID %>").val();
                if (status == "") {
                    tableToolbar._showMsg("交流类别不能为空！");
                    return false;
                }
                var title = $("#<%=this.txtTitle.ClientID %>").val();
                if (title == "") {
                    tableToolbar._showMsg("标题不能为空！");
                    return false;
                }
                var content = $("#<%=this.txtContent.ClientID %>").val();
                if (content == "") {
                    tableToolbar._showMsg("汇报内容不能为空！");
                    return false;
                }
                return true;
            },
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            DoAjax: function(type) {
                $.newAjax({
                    type: "post",
                    url: "/UserCenter/WorkCommunAdd.aspx?Type=" + type,
                    data: $("#<%=this.frm.ClientID %>").serialize(),
                    dataType: "json",
                    success: function(data) {
                        if (data.result == "1") {
                            tableToolbar._showMsg(data.msg, function() {
                                //window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                                //window.parent.location.reload();
                                window.location.href = "/UserCenter/WorkCommun.aspx";
                            });
                        }
                        else {
                            tableToolbar._showMsg(data.msg);
                            Commun.Bind();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg("服务器忙！");
                        Commun.Bind();
                    }
                });
            }

        };


        $(function() {
            Commun.CreateCommunEdit();

            //            var td = $("#tb").find("tr:eq(0)").find("td").each(function() {
            //                if ($(this).find("a").length == 0) {
            //                    $(this).remove();
            //                }
            //            });

            $("#<%=this.btnSave.ClientID %>").click(function() {
                KEditer.sync();
                Commun.Add();
            });
            $("#<%=this.btnUpdate.ClientID %>").click(function() {
                KEditer.sync();
                Commun.Update();
            });
        });
    </script>

</asp:Content>
