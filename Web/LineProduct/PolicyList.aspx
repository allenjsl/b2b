<%@ Page Title="政策中心" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="PolicyList.aspx.cs" Inherits="Web.LineProduct.PolicyList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td>
                            <span class="lineprotitle">线路产品</span>
                        </td>
                        <td align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            <b>所在位置：</b> &gt;&gt; 线路产品 &gt;&gt;政策中心
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="hr_10">
        </div>
        <form id="form1" method="get" action="">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/images/yuanleft.gif">
                    </td>
                    <td>
                        <div class="searchbox">
                            政策标题：
                            <input type="text" id="t" class="searchinput inputtext" name="t" />
                            发布时间：
                            <input type="text" id="sd" class="searchinput inputtext" name="sd" onfocus="WdatePicker()" />
                            -
                            <input type="text" id="ed" class="searchinput inputtext" name="ed" onfocus="WdatePicker()" />
                            政策状态：
                            <select name="txtStatus" id="txtStatus" class="inputselect">
                                <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)), EyouSoft.Common.Utils.GetQueryStringValue("txtStatus"), "", "-请选择-")%></select>
                            <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
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
            <table cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <asp:PlaceHolder runat="server" ID="plnAdd"><a href="javascript:void(0);"
                                onclick="javascript:PolicyManage.AddAndEditUrl('add','');return false;">新增</a></asp:PlaceHolder>
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
                            政策标题
                        </th>
                        <th bgcolor="#BDDCF4" align="center" style="width: 80px;">政策状态</th>
                        <th bgcolor="#bddcf4" align="center">
                            发布时间
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            发布人
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            政策附件
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptPolicy">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>">
                                <td height="30" align="center">
                                    <%# GetIndex(Container.ItemIndex) %>
                                </td>
                                <td align="left" class="pandl3">
                                    <%# Eval("Title") %>
                                </td>
                                <td align="center">
                                    <b><%#GetStatus(Eval("Status"))%></b></td>
                                <td align="center">
                                    <%# EyouSoft.Common.UtilsCommons.GetDateString(Eval("IssueTime"), this.ProviderToDate)%>
                                </td>
                                <td align="center">
                                    <%# Eval("OperatorName")%>
                                </td>
                                <td align="center">
                                    <%# GetFilePath(Eval("FilePath")) %>
                                </td>
                                <td align="center">
                                    <asp:PlaceHolder runat="server" ID="plnEdit" Visible='<%# IsEdit %>'><a class="update"
                                        href="javascript:void(0);" onclick="javascript:PolicyManage.AddAndEditUrl('edit','<%# Eval("Id") %>');return false;">
                                        修改 </a></asp:PlaceHolder>
                                    |&nbsp;<asp:PlaceHolder runat="server" ID="plnDel" Visible='<%# IsDel %>'><a href="javascript:void(0);"
                                        onclick="javascript:PolicyManage.DeletePolicy('<%# Eval("Id") %>');return false;">删除</a></asp:PlaceHolder>
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
                            <cc1:ExporPageInfoSelect runat="server" ID="page1" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">

        var PolicyManage = {
            AddAndEditUrl: function(type, pid) {
                var p = {};
                p.doType = type;
                if (pid != "") {
                    p.pid = pid;
                }
                Boxy.iframeDialog({
                    iframeUrl: "/LineProduct/PolicyAdd.aspx?" + $.param(p),
                    title: type == "edit" ? "修改政策" : "新增政策",
                    modal: true,
                    width: "520px",
                    height: "270px"
                });
            },
            DeletePolicy: function(pid) {
                if (pid == "") return;
                tableToolbar.ShowConfirmMsg("确定要删除此政策吗？", function() {
                    $.newAjax({
                        type: "get",
                        cache: false,
                        url: "/LineProduct/PolicyList.aspx",
                        data: { doType: "del", pid: pid },
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
            }
        }

        $(document).ready(function() {
            utilsUri.initSearch();
            tableToolbar.init({ tableContainerSelector: "#liststyle" });
        });
    </script>

</asp:Content>
