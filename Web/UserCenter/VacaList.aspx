<%@ Page Title="请假申请-个人中心" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="VacaList.aspx.cs" Inherits="Web.UserCenter.VacaList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">个人中心</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            所在位置&gt;&gt; <a href="#">个人中心</a>&gt;&gt; 请假申请
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="height: 30px;" class="lineCategorybox">
        </div>
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <a id="btnAdd" href="javascript:;">新 增</a>
                        </td>
                        <!--					<td width="90" align="center"><a href="geren-shq_update.html" class="link2">修改</a></td>
                    <td width="90" align="center"><a href="#">删 除</a></td>
-->
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <th width="36" bgcolor="#BDDCF4" align="center">
                            序号
                        </th>
                        <th bgcolor="#BDDCF4" align="center">
                            请假时间
                        </th>
                        <th width="11%" bgcolor="#bddcf4" align="center">
                            申请人
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            请假原因
                        </th>
                        <th width="9%" bgcolor="#bddcf4" align="center">
                            请假性质
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            申请时间
                        </th>
                        <th width="10%" bgcolor="#bddcf4" align="center">
                            审批状态
                        </th>
                        <th width="11%" bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rpVaca">
                        <ItemTemplate>
                            <tr>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center"
                                    class="pandl3">
                                    <%#Eval("StartDate", "{0:d}")%>至<%#Eval("EndDate","{0:d}") %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("UserContactName")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("Reason") %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("Nature")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#this.ToDateTimeString(Eval("IssueTime"))%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("State")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <a class="link_Update" data-id="<%#Eval("LeaveId") %>" href="javascript:;">修改</a>
                                    | <a class="link_Del" data-id="<%#Eval("LeaveId") %>" href="javascript:;">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td align="right" class="pageup">
                            <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var Vaca = {
            Add: function() {
                var url = "/UserCenter/VacaAdd.aspx?do=_add";
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "新增请假申请",
                    modal: true,
                    width: "580px",
                    height: "320px"
                });
                return false;

            },
            Update: function(data) {
                var url = "/UserCenter/VacaAdd.aspx?" + $.param(data);
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "修改请假申请",
                    modal: true,
                    width: "580px",
                    height: "320px"
                });
                return false;

            },
            Delete: function(data) {
                tableToolbar.ShowConfirmMsg("是否确认删除？", function() {
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/VacaList.aspx",
                        data: $.param(data),
                        dataType: "json",
                        success: function(data) {
                            if (data.result == "1") {
                                tableToolbar._showMsg(data.msg, function() {
                                    window.location.reload();
                                });
                            }
                            else {
                                tableToolbar._showMsg(data.msg);
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg("服务器忙！");
                        }
                    });

                });
            }
        };

        $(function() {
            //添加
            $("#btnAdd").click(function() {
                Vaca.Add();
            });
            //更新
            $(".link_Update").click(function() {
                var data = { "do": "_update", Id: $(this).attr("data-id") };
                Vaca.Update(data);
            });
            //删除
            $(".link_Del").click(function() {
                var data = { Type: "Del", Id: $(this).attr("data-id") };
                Vaca.Delete(data);
            });

        });
    </script>

</asp:Content>
