<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front.Master"
    CodeBehind="WorkCommunReply.aspx.cs" Inherits="Web.UserCenter.WorkCommunReply"
    ValidateRequest="false"  Title="工作交流-个人中心" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <form id="Form1" runat="server">
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
                <asp:HiddenField ID="hidId" runat="server" />
                <table width="880" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4" align="center">
                    <tbody>
                        <tr>
                            <th bgcolor="#BDDCF4" align="center" colspan="3">
                                交流专区查看
                            </th>
                        </tr>
                        <tr>
                            <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                                <strong>标题：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <asp:Literal runat="server" ID="ltTitle"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <strong>交流内容：</strong>
                            </td>
                            <td height="100" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <asp:Literal runat="server" ID="ltContent"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <strong>发布人：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <asp:Literal runat="server" ID="ltOperatorName"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <strong>发布时间：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <asp:Literal runat="server" ID="ltCreateDate"></asp:Literal>
                            </td>
                        </tr>
                        <asp:Repeater ID="rpReply" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td colspan="2" bgcolor="#BDDCF4" style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="35" bgcolor="#e3f1fc" align="right">
                                        <strong>
                                            <%#GetHuiFuRenName(Eval("IsAnonymous"), Eval("OperatorName"))%>：
                                        </strong>
                                    </td>
                                    <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                        <label>
                                            <%#Eval("Description") %></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="35" bgcolor="#e3f1fc" align="right">
                                        <strong></strong>
                                    </td>
                                    <td height="35" bgcolor="#FAFDFF" align="right" class="pandl3" colspan="2">
                                        <label>
                                            <%#Eval("ReplyTime")%></label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <strong>回复：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <textarea cols="3" style="width: 600px;" class="inputarea" id="txtReply"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td height="35" bgcolor="#e3f1fc" align="right">
                                <strong>回复人：</strong>
                            </td>
                            <td height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                                <label>
                                    <%=SiteUserInfo.Name %>
                                </label>
                                <input type="checkbox" id="replyIsAnonymous"  />匿名
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="center" colspan="3">
                                <table cellspacing="0" cellpadding="0" border="0" align="center">
                                    <tbody>
                                        <tr>
                                            <td width="86" height="40" align="center" class="tjbtn02">
                                                <a class="repeat" id="btnReply" href="javascript:;">回复</a>
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
            </div>
        </div>
        <!-- InstanceEndEditable -->
        </form>
    </div>

    <script type="text/javascript">
        var Reply = {
            Save: function() {

                var content = $("#txtReply").val();
                if (content == "") {
                    tableToolbar._showMsg("回复内容不能为空！");
                }
                else {
                    var Id = $("#<%=this.hidId.ClientID %>").val();
                    var replyIsAnonymous = 0;
                    if ($("#replyIsAnonymous").attr("checked") == true) {
                        replyIsAnonymous = 1;
                    }
                    var data = { Id: Id, Content: content, IsAnonymous: replyIsAnonymous };
                    // alert($.param(data));
                    $("#btnReply").html("提交中...");
                    Reply.UnBind();
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/WorkCommunReply.aspx?Type=Save",
                        data: $.param(data),
                        dataType: "json",
                        success: function(data) {
                            if (data.result == "1") {
                                tableToolbar._showMsg(data.msg, function() {
                                    //window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                                    //window.parent.location.reload();
                                    $("#txtReply").val(" ");
                                    window.location.reload();
                                });

                            }
                            else {
                                tableToolbar._showMsg(data.msg);
                                Reply.Bind();
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg("服务器忙！");
                            Reply.Bind();
                        }
                    });
                }
            },
            UnBind: function() {
                $("#btnReply").unbind("click");
            },
            Bind: function() {
                var _selfs = $("#btnReply");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    Reply.Save();
                    return false;
                });
            }
        };
        $(function() {

            $("#btnReply").click(function() {

                Reply.Save();
            });
        });
    </script>

</asp:Content>
