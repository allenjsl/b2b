<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingDianQuYu.aspx.cs" Inherits="Web.PingTai.JingDianQuYu"
    MasterPageFile="~/MasterPage/Front.Master" Title="同行端口-景点区域管理" %>

<%@ Register Src="~/UserControl/PingTaiJingDianDaoHang.ascx" TagName="PingTaiJingDianDaoHang"
    TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">同行端口</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 同行端口 >> 站点管理
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    <uc1:PingTaiJingDianDaoHang runat="server" ID="PingTaiJingDianDaoHang1" />
    <div class="hr_10">
    </div>    
    <div class="btnbox">
        <asp:PlaceHolder runat="server" ID="phInsert">
            <table border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" id="i_insert">新增</a>
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="36" align="center">
                    序号
                </th>
                <th align="center">
                    区域名称
                </th>
                <th align="center" style="width: 10%">
                    排序值
                </th>
                <th width="15%" align="center">
                    添加时间
                </th>
                <th width="120" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-quyuid="<%#Eval("QuYuId") %>"
                        style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td align="center">
                            <%#Eval("MingCheng")%>
                        </td>
                        <td align="center">
                            <%#Eval("PaiXuId")%>
                        </td>
                        <td align="center">
                            <%#Eval("IssueTime","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml()%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="8" style="height: 30px; text-align: center;">
                        暂无任何景点区域信息
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server"></asp:PlaceHolder>
        </table>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "新增景点区域", iframeUrl: "jingdianquyuedit.aspx", width: "550px", height: "350px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-quyuid") };
                var _title = "景点区域修改";
                if ($(obj).attr("i_chakan") == "1") _title = "查看景点区域信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "jingdianquyuedit.aspx", width: "550px", height: "350px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("景点区域删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { txtQuYuId: _$tr.attr("data-quyuid") };

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "shanchu" }),
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
            $(".i_xiugai").bind("click", function() { return iPage.update(this); });
            $(".i_shanchu").bind("click", function() { return iPage.del(this); return false; });
            setPingTaiJingDianDaoHang(2)
        });
    </script>

</asp:Content>
