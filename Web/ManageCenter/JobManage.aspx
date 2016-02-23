<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="JobManage.aspx.cs" Inherits="Web.ManageCenter.JobManage" %>
<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td nowrap="nowrap" width="15%">
                        <span class="lineprotitle">行政中心</span>
                    </td>
                    <td align="right" nowrap="nowrap" style="padding: 0 10px 2px 0; color: #13509f;"
                        width="85%">
                        <b>当前所在位置：</b>&gt;&gt;行政中心&gt;&gt;职务管理
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#000000" colspan="2" height="2">
                    </td>
                </tr>
            </table>
        </div>
        <div class="lineCategorybox" style="height: 30px;">
        </div>
        <div class="btnbox">
            <table align="left" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" width="90">
                        <a id="add_bar" href="javascript:;">新 增</a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="tablelist">
            <table border="0" cellpadding="0" cellspacing="1" width="100%" style="word-wrap:break-word; overflow:hidden;word-break: break-all;table-layout:fixed;">
                <tr>
                    <th align="center" bgcolor="#BDDCF4" width="36">
                        序号
                    </th>
                    <th align="center" bgcolor="#BDDCF4" width="18%">
                        职务名称
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        职务说明
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="20%">
                        职务具体要求
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="20%">
                        备注
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="12%">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%#Container.ItemIndex%2==0 ? "even":"odd" %>" data-id='<%#Eval("Id") %>'>
                            <td align="center">
                                <%# Container.ItemIndex+1+(this.pageIndex-1)*this.pageSize %>
                            </td>
                            <td align="center">
                                <%#Eval("JobName") %>
                            </td>
                            <td align="left">
                                <%#Eval("Help") %>
                            </td>
                            <td align="left">
                                <%#Eval("Requirement")%>
                            </td>
                            <td align="left">
                                <%#Eval("Remark")%>
                            </td>
                            <td align="center">
                                <a class="update_bar" href="javascript:;">修改</a> | <a href="javascript:;" class="delete_bar">
                                    删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" class="pageup">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript">
    $(function(){
        JobManage.PageInit();
    })
    var JobManage={
         ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            AddData:function(){
                JobManage.ShowBoxy({ iframeUrl: "/ManageCenter/JobAdd.aspx?dotype=add", title: "新增", width: "520px", height: "420px" });
            },
            UpdateData:function(id){
                JobManage.ShowBoxy({ iframeUrl: "/ManageCenter/JobAdd.aspx?dotype=update&dutyid="+id, title: "修改", width: "520px", height: "420px" });
            },
            PageInit:function(){
                $("#add_bar").click(function(){
                    JobManage.AddData();
                    return false;
                })
                $(".update_bar").click(function(){
                    var id=$(this).closest("tr").attr("data-id");
                    JobManage.UpdateData(id);
                    return false;
                })
                $(".delete_bar").click(function(){
                    var id=$(this).closest("tr").attr("data-id");
                    var url="/ManageCenter/JobManage.aspx?dotype=delete&id="+id;
                    JobManage.GoAjax(url);
                    return false;
                })
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
    }
    </script>

</asp:Content>
