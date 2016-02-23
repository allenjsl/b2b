<%@ Page Title="线路区域管理" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="LineManage.aspx.cs" Inherits="Web.SystemSet.LineManage" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/JiChuXinXi.ascx" TagName="JiChuXinXi" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">系统设置</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                          所在位置&gt;&gt; <a href="#">系统设置</a>&gt;&gt; 基础设置
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <uc1:jichuxinxi runat="server" id="JiChuXinXi1" highlightnav="-2" />
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <a href="javascript:void(0);" id="add_bar">新 增</a>
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
                        <th bgcolor="#BDDCF4" align="center">
                            线路区域名称
                        </th>
                        <th bgcolor="#BDDCF4" align="center">
                            所属站点
                        </th>
                        <th bgcolor="#BDDCF4" align="center">
                            所属专线类别
                        </th>
                        <th width="17%" bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptList">
                        <ItemTemplate>
                            <tr class="<%#Container.ItemIndex%2==0 ? "even":"odd" %>" data-id='<%#Eval("Id") %>'>
                                <td align="center">
                                    <%#Container.ItemIndex+1%>
                                </td>
                                <td align="center">
                                    <%#Eval("AreaName") %>
                                </td>
                                <td align="center">
                                    <%#Eval("ZhanDianMingCheng") %>
                                </td>
                                <td align="center">
                                    <%#Eval("ZxlbMingCheng") %>
                                </td>
                                <td align="center">
                                    <a href="javascript:void(0);" class="update_bar">修改</a>&nbsp;|&nbsp;<a href="javascript:void(0);" class="delete_bar">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
                    <tr>
                        <td height="30" align="right" class="pageup" colspan="4">
                            <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location;
            },
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtQuYuId: _$tr.attr("data-id") };

                if (!confirm("线路区域信息删除后不可恢复，你确定要删除吗？")) return;
                $.newAjax({
                    type: "post", cache: false, url: "linemanage.aspx?dotype=shanchu", dataType: "json",
                    data: _data,
                    success: function(ret) {
                        alert(ret.msg);
                        iPage.reload();
                    },
                    error: function() {
                        iPage.reload();
                    }
                });
            },
            tianJia: function() {
                var _data = {}
                Boxy.iframeDialog({ title: "线路区域-添加", iframeUrl: "lineadd.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            xiuGai: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-id") };
                Boxy.iframeDialog({ title: "线路区域-修改", iframeUrl: "lineadd.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        }

        $(document).ready(function() {
            $("#add_bar").click(function() { iPage.tianJia(); });
            $(".update_bar").click(function() { iPage.xiuGai(this); });
            $(".delete_bar").click(function() { iPage.shanChu(this); });
        });
    </script>

</asp:Content>
