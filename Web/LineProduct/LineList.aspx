<%@ Page Title="线路管理" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="LineList.aspx.cs" Inherits="Web.LineProduct.LineList" %>

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
                            <span class="lineprotitle">线路产品</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            <b>所在位置：</b>&gt;&gt; 线路产品&gt;&gt; 线路管理
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%--<div class="lineCategorybox">
            <table width="99%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <!-- 每行14个，第一行第一个固定为所有线路，其他行的第一个固定为空 -->
                        <asp:Repeater runat="server" ID="rptArea">
                            <ItemTemplate>
                                <%# (Container.ItemIndex + 1) == 14 ? "</tr><tr>" : string.Empty %>
                                <td width="7%" height="25" align="<%# Container.ItemIndex % 14 == 0 ? "right" : "center" %>">
                                    <%# GetAreaName(Container.ItemIndex,Eval("AreaName"),Eval("Id"))%>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </tbody>
            </table>
        </div>--%>
        <form id="form1" action="" method="get">
        <input type="hidden" name="iscx" value="1" />
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/images/yuanleft.gif">
                    </td>
                    <td>
                        <div class="searchbox">
                            <label>
                                线路区域：</label>
                            <%--<%= GetAreaDropDownList() %>--%>
                            <select name="txtQuYu" class="inputselect" id="txtQuYu">
                                <asp:Literal runat="server" ID="ltrQuYuOption"></asp:Literal>
                            </select>                            
                            线路状态：
                            <select id="txtZhengCeStatus" name="txtZhengCeStatus" class="inputselect">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)), "", "-1", "-请选择-") %>
                            </select>
                            线路类型：<select class="inputselect" id="txtLeiXing" name="txtLeiXing"><option value="">-请选择-</option><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing)),"")%></select>
                            线路标准：<select class="inputselect" id="txtBiaoZhun" name="txtBiaoZhun"><option value="">-请选择-</option><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun)),"")%></select>
                            <label>线路名称：</label>
                            <input type="text" class="searchinput searchinput02 inputtext" id="rName" name="rName">
                            <input type="image" src="/images/searchbtn.gif" style="vertical-align: middle;" />
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="/images/yuanright.gif">
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <asp:PlaceHolder runat="server" ID="plnAdd"><a onclick="javascript:RouteManage.AddAndEditUrl('add','');return false;"
                                href="javascript:void(0);">新 增</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
                <tbody>
                    <tr>
                        <th width="36" height="30" bgcolor="#BDDCF4" align="center">
                            序号
                        </th>
                        <th bgcolor="#BDDCF4" align="center">
                            线路名称
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            线路区域
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            行程天数
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            发布日期
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            发布人
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            收客数
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            线路状态
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            线路类型
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            线路标准
                        </th>                        
                        <th width="10%" bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptRoute">
                        <ItemTemplate>
                            <tr bgcolor="<%# Container.ItemIndex % 2 == 0 ? "#E3F1FC" : "#BDDCF4" %>">
                                <td height="35" align="center">
                                    <%# GetIndex(Container.ItemIndex) %>
                                </td>
                                <td align="center">
                                    <a target="_blank" href="/PrintPage/RoutePlan.aspx?rid=<%# Eval("RouteId") %>">
                                        <%# Eval("RouteName") %></a>
                                </td>
                                <td align="center"><!--title="<%#Eval("ZhanDianName") %>站-<%#Eval("ZxlbName") %>"-->
                                    <%# Eval("AreaName") %>
                                </td>
                                <td align="center">
                                    <%# Eval("Days")%>
                                </td>
                                <td align="center">
                                    <%# EyouSoft.Common.UtilsCommons.GetDateString(Eval("IssueTime"), this.ProviderToDate)%>
                                </td>
                                <td align="center">
                                    <%# Eval("ContactName")%>
                                </td>
                                <td align="center">
                                    <a href="javascript:void(0);" onclick="javascript:RouteManage.ShowRouteOrder('<%# Eval("RouteId") %>')">
                                        <font class="fbred">
                                            <%# Eval("TotalAccounts")%></font></a>
                                </td>
                                <td style="text-align:center;">
                                    <%#GetStatus(Eval("Status"))%>
                                </td>
                                <td style="text-align:center;">
                                    <%#Eval("LeiXing")%>
                                </td>
                                <td style="text-align:center;">
                                    <%#Eval("BiaoZhun")%>
                                </td>
                                
                                <td align="center">
                                    <asp:PlaceHolder runat="server" ID="plnEdit" Visible='<%# IsEdit %>'><a href="javascript:void(0);"
                                        onclick="javascript:RouteManage.AddAndEditUrl('edit','<%# Eval("RouteId") %>');return false;">
                                        <font class="fblue">修改</font></a></asp:PlaceHolder>
                                    <a href="javascript:void(0)" onclick="javascript:RouteManage.AddAndEditUrl('copy','<%# Eval("RouteId") %>');return false;">
                                        <font class="fblue">复制</font></a>
                                    <asp:PlaceHolder runat="server" ID="plnDel" Visible='<%# IsDel %>'><a href="javascript:void(0);"
                                        onclick="javascript:RouteManage.DeleteRoute('<%# Eval("RouteId") %>');return false;">
                                        <font class="fblue">删除</font></a></asp:PlaceHolder>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td height="30" align="right" class="pageup" colspan="9">
                            <cc1:ExporPageInfoSelect runat="server" ID="page1" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var RouteManage = {
            AddAndEditUrl: function(type, rid) {
                var p = {};
                p.doType = type;
                if (rid != "") {
                    p.rid = rid;
                }
                p.rurl = window.location.href;

                window.location.href = "/LineProduct/LineAdd.aspx?" + $.param(p);
                
            },
            DeleteRoute: function(rid) {
                if (rid == "") return;
                tableToolbar.ShowConfirmMsg("确定要删除此线路吗？", function() {
                    $.newAjax({
                        type: "get",
                        cache: false,
                        url: "/LineProduct/LineList.aspx",
                        data: { doType: "del", rid: rid },
                        dataType: "json",
                        success: function(ret) {
                            //ajax回发提示
                            if (ret.result == "1") {
                                tableToolbar._showMsg("删除成功，稍后自动刷新页面！", function() {
                                    window.location.href = window.location.href;
                                });
                            }
                            else {
                                tableToolbar._showMsg(ret.msg, function() {
                                    window.location.href = window.location.href;
                                });
                            }

                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                        }
                    });
                })
            },
            ShowRouteOrder: function(rid) {
                Boxy.iframeDialog({
                    iframeUrl: "/LineProduct/RouteOrder.aspx?rid=" + rid,
                    title: "线路收客数",
                    modal: true,
                    width: "720px",
                    height: "370px"
                });
            }
        }

        $(document).ready(function() {
            utilsUri.initSearch();
            tableToolbar.init({ tableContainerSelector: "#liststyle" });

            $("#txtZhengCeStatus").val("<%=ZhuangTai %>");
            $("#txtLeiXing").val("<%=LeiXing %>");
        });
    </script>

</asp:Content>
