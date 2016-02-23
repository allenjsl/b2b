<%@ Page Title="工作交流-个人中心" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="WorkCommun.aspx.cs" Inherits="Web.UserCenter.WorkCommun" %>

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
                            所在位置&gt;&gt; 个人中心&gt;&gt; 工作交流
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
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td height="30">
                        <form id="frmSearch" action="/UserCenter/WorkCommun.aspx">
                        交流类别：
                        <select name="ddlType" class="inputselect">
                            <%=BindStatus(EyouSoft.Common.Utils.GetQueryStringValue("ddlType"))%>
                        </select>
                        标题：
                        <input type="text" class="inputtext" name="txtTitle" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtTitle") %>'
                            style="width: 120px;" />
                        交流时间：<input type="text" class="inputtext" name="LBeginDate" style="width: 60px;"
                            onfocus="WdatePicker()" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("LBeginDate") %>' />
                        至
                        <input type="text" class="inputtext" name="LEndDate" style="width: 60px;" onfocus="WdatePicker()"
                            value='<%=EyouSoft.Common.Utils.GetQueryStringValue("LEndDate") %>' />
                        <a href="javascript:;" id="btnSearch">
                            <img style="vertical-align: top;" src="../images/searchbtn.gif" />
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
                            <a href="/UserCenter/WorkCommunAdd.aspx?do=_add">新 增</a>
                        </td>
                        <!--<td width="90" align="center"><a href="geren-jl-zhuanqu_xiugai.html">修 改</a></td>
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
                        <th width="13%" bgcolor="#BDDCF4" align="center">
                            交流类别
                        </th>
                        <th bgcolor="#BDDCF4" align="center">
                            标题
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            发布时间
                        </th>
                        <th width="14%" bgcolor="#bddcf4" align="center">
                            发布人
                        </th>
                        <th width="9%" bgcolor="#bddcf4" align="center">
                            浏览次数
                        </th>
                        <th width="9%" bgcolor="#bddcf4" align="center">
                            回复数
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rpCommun" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center"
                                    class="pandl3">
                                    <%#Eval("Type") %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="left"
                                    class="pandl3">
                                    <a href="WorkCommunReply.aspx?Id=<%#Eval("ExchangeId") %>">
                                        <%#Eval("Title") %></a>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center"
                                    class="pandl3">
                                    <%#this.ToDateTimeString(Eval("CreateTime")) %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Convert.ToBoolean(Eval("IsAnonymous"))==true?"匿名": Eval("OperatorName") %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("Clicks") %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("Replys") %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <a href="/UserCenter/WorkCommunAdd.aspx?do=_update&Id=<%#Eval("ExchangeId") %>">修改</a>
                                    | <a href="javascript:;" class="link_del" data-id="<%#Eval("ExchangeId") %>">删除</a>
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
        var WorkCommun = {
            Search: function() {
                $("#frmSearch").submit();
            },
            Delete: function(obj) {
                if (!confirm("你确定要删除吗？")) return false;
                var _data = { txtId: $(obj).attr("data-id") }
                $.newAjax({
                    type: "post",
                    url: "/UserCenter/WorkCommun.aspx?dotype=shanchu",
                    data: _data,
                    dataType: "json",
                    success: function(data) {
                        alert(data.msg);
                        window.location.href = window.location.href;
                    },
                    error: function() {
                        window.location.href = window.location.href;
                    }
                });
            }
        };

        $(function() {
            //搜索
            $("#btnSearch").click(function() {
                WorkCommun.Search();
            });
            $(".link_del").click(function() {
                WorkCommun.Delete(this);
            });
        });
        
    </script>

</asp:Content>
