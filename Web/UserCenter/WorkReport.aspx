<%@ Page Title="工作汇报-个人中心" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="WorkReport.aspx.cs" Inherits="Web.UserCenter.WorkReport" %>

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
                            <b>当前您所在位置</b>&gt;&gt; 个人中心&gt;&gt; 工作汇报
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
            <table cellspacing="0" cellpadding="0" border="0" class="grzxnav">
                <tbody>
                    <tr>
                        <td width="108" align="center" class="grzxnav-on">
                            <a href="WorkReport.aspx">工作汇报</a>
                        </td>
                        <td width="108" align="center">
                            <a href="WorkPlan.aspx">工作计划</a>
                        </td>
                        <td width="108" align="center">
                            <a href="WorkCommun.aspx">工作交流</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td height="30">
                        <form method="get" id="frmSearch">
                        标题：
                        <input type="text" id="txtRTitle" class="inputtext" name="txtRTitle" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtRTitle") %>'
                            style="width: 120px;">
                        <label>
                            汇报部门：</label>
                        <select id="ddlDepart" name="ddlDepart" class="inputselect">
                            <%=BindDepartment(EyouSoft.Common.Utils.GetQueryStringValue("ddlDepart"))%>
                        </select>
                        汇报人：
                        <input type="text" class="inputtext" id="txtRMan" name="txtRMan" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtRMan") %>'
                            style="width: 120px;" />
                        <label>
                            汇报时间：</label>
                        <input type="text" id="txtRBeginData" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtRBeginData") %>'
                            class="inputtext" name="txtRBeginData" style="width: 60px;" onfocus="WdatePicker()" />
                        至
                        <input type="text" class="inputtext" id="txtREndData" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtREndData") %>'
                            name="txtREndData" style="width: 60px;" onfocus="WdatePicker()" />
                        <a href="javascript:void(0);" id="btnSearch">
                            <img style="vertical-align: top;" src="../images/searchbtn.gif" /></a>
                        </form>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <a href="/UserCenter/WorkReportAdd.aspx?do=_add">新 增</a>
                        </td>
                        <!--<td width="90" align="center"><a href="geren-jl_xiugai.html">修 改</a></td>
                            <td width="90" align="center"><a href="#">删 除</a></td> -->
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
                            标题
                        </th>
                        <th width="15%" bgcolor="#bddcf4" align="center">
                            汇报部门
                        </th>
                        <th width="14%" bgcolor="#bddcf4" align="center">
                            汇报人
                        </th>
                        <th width="13%" bgcolor="#bddcf4" align="center">
                            汇报时间
                        </th>
                        <th width="9%" bgcolor="#bddcf4" align="center">
                            状态
                        </th>
                        <th width="14%" bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rpWorkReport">
                        <ItemTemplate>
                            <tr>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="left"
                                    class="pandl3">
                                    <a href="/UserCenter/WorkReportAdd.aspx?do=_check&Id=<%#Eval("ReportId") %>">
                                        <%#Eval("Title") %>
                                    </a>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("DepartmentName")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("OperatorName")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#this.ToDateTimeString( Eval("ReportingTime")) %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#BingStatus(Eval("Status"))%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <a href="/UserCenter/WorkReportAdd.aspx?do=_update&Id=<%#Eval("ReportId") %>">修改</a>
                                    | <a data-id="<%#Eval("ReportId") %>" href="javascript:;" class="link_del">删除</a>
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
        var WorkReport = {
            Search: function() {
                $("#frmSearch").submit();
            },
            Delete: function(data) {
                tableToolbar.ShowConfirmMsg("是否确认删除？", function() {
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/WorkReport.aspx",
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
            //搜索
            $("#btnSearch").click(function() {
                WorkReport.Search();
            });
            $(".link_del").click(function() {
                var data = { Type: "Del", Id: $(this).attr("data-id") };
                WorkReport.Delete(data);
            });

        });
        
    </script>

</asp:Content>
