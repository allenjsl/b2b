<%@ Page Title="文档管理-个人中心" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="FileList.aspx.cs" Inherits="Web.UserCenter.FileList" %>

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
                          所在位置&gt;&gt; 个人中心&gt;&gt; 文档管理
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
                            <a id="btnAdd" href="javascript:void(0);" runat="server">新 增</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <th width="36" height="30" bgcolor="#BDDCF4" align="center">
                            序号
                        </th>
                        <th bgcolor="#BDDCF4" align="center">
                            文档名称
                        </th>
                        <th width="18%" bgcolor="#bddcf4" align="center">
                            上传时间
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            上传人
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            附件
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rpFile" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td height="30" bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>"
                                    align="center">
                                    <%#Container.ItemIndex+1+(pageIndex-1)*pageSize %>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="left"
                                    class="pandl3">
                                    <%#Eval("DocumentName")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#this.ToDateTimeString(Eval("CreateTime"))%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <%#Eval("OperatorName")%>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <a href="<%#Eval("FilePath") %>">
                                        <img width="15" height="14" alt="" src="../images/fujian_bg.gif"></a>
                                </td>
                                <td bgcolor="<%#(Container.ItemIndex+1)%2==0?"#BDDCF4":"#e3f1fc" %>" align="center">
                                    <a class="link_update" data-id="<%#Eval("DocumentId") %>" href="javascript:void(0);">
                                        修改 </a>|<a class="link_del" data-id="<%#Eval("DocumentId") %>" href="javascript:;">删除</a>
                                    |<a class="link_detail" data-id="<%#Eval("DocumentId") %>" href="javascript:void(0);">查看</a>
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
        var FileList = {
            Add: function() {
                var url = "/UserCenter/FileAdd.aspx?do=add";
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "新增文档",
                    modal: true,
                    width: "520px",
                    height: "280px"
                });
                return false;
            },
            Update: function(id) {
                var url = "FileAdd.aspx?do=update&DocumentId=" + id;
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "修改文档",
                    modal: true,
                    width: "520px",
                    height: "280px"
                });
                return false;
            },
            Detail: function(id) {
                var url = "FileAdd.aspx?do=detail&DocumentId=" + id;
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "查看文档",
                    modal: true,
                    width: "520px",
                    height: "280px"
                });
                return false;
            },
            Delete: function(data) {
                tableToolbar.ShowConfirmMsg("是否确认删除？", function() {
                    $.newAjax({
                        type: "post",
                        url: "/UserCenter/FileList.aspx",
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
            $("#<%=this.btnAdd.ClientID %>").click(function() {
                FileList.Add();
            });

            $(".link_update").click(function() {
                var documentId = $(this).attr("data-id");
                FileList.Update(documentId);
            });
            $(".link_detail").click(function() {
                var documentId = $(this).attr("data-id");
                FileList.Detail(documentId);
            });

            $(".link_del").click(function() {
                var data = { Type: "Del", Id: $(this).attr("data-id") };
                FileList.Delete(data);
            });

        });
    
    </script>

</asp:Content>
