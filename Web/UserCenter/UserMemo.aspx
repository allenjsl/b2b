<%@ Page Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="UserMemo.aspx.cs" Inherits="Web.UserCenter.UserMemo" Title="个人备忘-个人中心" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">个人中心</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                        所在位置&gt;&gt; 个人中心&gt;&gt; 个人备忘
                    </td>
                </tr>
                <tr>
                    <td height="2" bgcolor="#000000" colspan="2">
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox">
                    主题：
                    <input type="text" style="width: 120px;" class="searchinput" name="txtTitle" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtTitle") %>'>
                    备忘时间：<input type="text" style="width: 120px;" class="inputtext" name="txtMBeginDate"
                        style="width: 50px;" onfocus="WdatePicker()" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtMBeginDate") %>' />
                    -
                    <input type="text" style="width: 120px;" class="inputtext" name="txtMEndDate" style="width: 50px;"
                        onfocus="WdatePicker()" value='<%=EyouSoft.Common.Utils.GetQueryStringValue("txtMEndDate") %>' />
                    <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>
    <div class="btnbox">
        <table cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="90" align="center">
                        <a id="btnAdd" href="javascript:void(0);">新 增</a>
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
                    <th width="19%" bgcolor="#BDDCF4" align="center">
                        主题
                    </th>
                    <th width="16%" bgcolor="#bddcf4" align="center">
                        时间
                    </th>
                    <th bgcolor="#bddcf4" align="center">
                        内容
                    </th>
                    <th width="11%" bgcolor="#bddcf4" align="center">
                        完成情况
                    </th>
                    <th width="11%" bgcolor="#bddcf4" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rpMemo" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                            </td>
                            <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="left"
                                class="pandl3">
                                <a class="link_Detail" data-id="<%#Eval("Id") %>" href="javascript:void(0);">
                                    <%#Eval("Title")%></a>
                            </td>
                            <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                <%#this.ToDateTimeString(Eval("AlertTime"))%>
                            </td>
                            <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="left">
                                <span class="pandl3">
                                    <%#Eval("Content") %></span>
                            </td>
                            <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                <%#this.BindStatus(Eval("State"))%>
                            </td>
                            <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                <a class="link_Update" visible="false" data-id="<%#Eval("Id") %>" href="javascript:void(0)">
                                    修改</a> | <a class="link_Del" id="a" data-id="<%#Eval("Id") %>" href="javascript:void(0)">
                                        删除</a>
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

    <script type="text/javascript">
        var UserMemo = {
            Add: function() {
                var url = "/UserCenter/UserMomoAdd.aspx?do=_add";
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "新增备忘",
                    modal: true,
                    width: "520px",
                    height: "230px"
                });
                return false;

            },
            Update: function(data) {
                var url = "/UserCenter/UserMomoAdd.aspx?" + $.param(data);
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "修改备忘",
                    modal: true,
                    width: "520px",
                    height: "230px"
                });
                return false;

            },
            Delete: function(data) {
                tableToolbar.ShowConfirmMsg("是否确认删除？", function() {
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/UserMemo.aspx",
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
            },
            Detail: function(data) {
                var url = "/UserCenter/UserMomoAdd.aspx?" + $.param(data);
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "修改备忘",
                    modal: true,
                    width: "520px",
                    height: "230px"
                });
                return false;
            }
        };

        $(function() {
            //添加

            $("#btnAdd").click(function() {
                UserMemo.Add();
            });
            //更新
            $(".link_Update").click(function() {
                var data = { "do": "_update", Id: $(this).attr("data-id") };
                UserMemo.Update(data);
            });
            //删除
            $(".link_Del").click(function() {
                var data = { Type: "Del", Id: $(this).attr("data-id") };
                UserMemo.Delete(data);
            });
            //详情
            $(".link_Detail").click(function() {
                var data = { "do": "_detail", Id: $(this).attr("data-id") }
                UserMemo.Detail(data);
            });
        });
    </script>

</asp:Content>
