<%@ Page Title="工作计划-个人中心" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="WorkPlan.aspx.cs" Inherits="Web.UserCenter.WorkPlan" %>

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
                            所在位置&gt;&gt; 个人中心&gt;&gt; 工作计划
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
                        <td width="108" align="center">
                            <a href="WorkReport.aspx">工作汇报</a>
                        </td>
                        <td width="108" align="center" class="grzxnav-on">
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
                        <form id="frmSearch" method="get">
                        计划标题：
                        <input type="text" class="inputtext" name="txtTitle" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtTitle") %>'
                            style="width: 120px;">
                        <label>
                        </label>
                        <label>
                            提交人：</label>
                        <input type="text" class="inputtext" name="txtName" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtName") %>' />
                        状态：
                        <select class="inputselect" name="ddlStatus">
                            <%=BindStatus(EyouSoft.Common.Utils.GetQueryStringValue("ddlStatus"))%>
                        </select>
                        <label>
                        </label>
                        <label>
                            预计完成时间：</label>
                        <input type="text" class="inputtext" name="LBeginDate" style="width: 60px;" onfocus="WdatePicker()"
                            value='<%=EyouSoft.Common.Utils.GetQueryStringValue("LBeginDate") %>' />
                        至
                        <input type="text" class="inputtext" name="LEndDate" style="width: 60px;" onfocus="WdatePicker()"
                            value='<%=EyouSoft.Common.Utils.GetQueryStringValue("LEndDate") %>' />
                        &nbsp; <a href="javascript:;" id="btnSearch">
                            <img style="vertical-align: top;" src="../images/searchbtn.gif">
                        </a>
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
                            <a href="WorkPlanAdd.aspx?do=_add">新 增</a>
                        </td>
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
                        <th width="6%" bgcolor="#BDDCF4" align="center">
                            编号
                        </th>
                        <th width="20%" bgcolor="#BDDCF4" align="center">
                            计划标题
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            计划说明
                        </th>
                        <th width="9%" bgcolor="#bddcf4" align="center">
                            提交人
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            状态
                        </th>
                        <th width="11%" bgcolor="#bddcf4" align="center">
                            预计完成时间
                        </th>
                        <th width="11%" bgcolor="#bddcf4" align="center">
                            实际完成时间
                        </th>
                        <th width="9%" bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rpPlan" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("PlanNO") %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="left"
                                    class="pandl3">
                                    <a href="WorkPlanAdd.aspx?do=_check&Id=<%#Eval("PlanId") %>">
                                        <%#Eval("Title")%></a>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="left"
                                    class="pandl3">
                                    <%#Eval("Remark")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("OperatorName")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("Status")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#this.ToDateTimeString(Eval("ExpectedDate"))%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#this.ToDateTimeString( Eval("ActualDate"))%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <a href='WorkPlanAdd.aspx?do=_update&Id=<%#Eval("PlanId") %>'>修改</a> | <a href="javascript:;"
                                        class="link_del" data-id="<%#Eval("PlanId") %>">删除</a>
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
        var WorkPlan = {
            Search: function() {
                $("#frmSearch").submit();
            },
            Delete: function(data) {
                tableToolbar.ShowConfirmMsg("是否确认删除？", function() {
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/WorkPlan.aspx",
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
                WorkPlan.Search();
            });
            $(".link_del").click(function() {
                var data = { Type: "Del", Id: $(this).attr("data-id") };
                WorkPlan.Delete(data);
            });

        });
        
    </script>

</asp:Content>
