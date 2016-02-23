<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HuiChengShiJian.aspx.cs"
    Inherits="Web.SystemSet.HuiChengShiJian" MasterPageFile="~/MasterPage/Front.Master"
    Title="回程时间-基础设置-系统设置" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/JiChuXinXi.ascx" TagName="JiChuXinXi" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">系统设置</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 系统设置 >> 基础设置 >> 回程时间
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    <uc1:jichuxinxi runat="server" id="JiChuXinXi1" highlightnav="1" />
    
    <!--<form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox">
                    
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>-->
    
    <div class="btnbox">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:void(0)" id="i_insert">新增</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="36" align="center">
                    序号
                </th>
                <th align="center">
                    回程时间
                </th>
                <th width="80" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_id="<%#Eval("Id") %>"  style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#Eval("Name")%>
                        </td>
                        <td align="center">
                            <a class="i_update" href="javascript:void(0)">修改</a> | <a class="i_delete" href="javascript:void(0)">
                            删除</a> 
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="3" style="height: 30px; text-align: center;">
                        暂无任何回程时间信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <asp:PlaceHolder runat="server" ID="phPaging">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="paging" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "新增回程时间", iframeUrl: "huichengshijianedit.aspx", width: "470px", height: "140px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { xinxiid: _$tr.attr("i_id") };
                var _title = "回程时间修改";
                Boxy.iframeDialog({ title: _title, iframeUrl: "huichengshijianedit.aspx", width: "470px", height: "140px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("回程时间信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { txtId: _$tr.attr("i_id") };

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "delete" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            //utilsUri.initSearch();

            $("#i_insert").bind("click", function() { return iPage.insert(this); });
            $(".i_update").bind("click", function() { return iPage.update(this); });
            $(".i_delete").bind("click", function() { return iPage.del(this); return false; });
        });
    </script>

</asp:Content>
