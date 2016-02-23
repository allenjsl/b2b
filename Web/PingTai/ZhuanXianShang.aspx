<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuanXianShang.aspx.cs" Inherits="Web.PingTai.ZhuanXianShang" MasterPageFile="~/MasterPage/Front.Master" Title="同行端口-专线商管理"%>
<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">同行端口</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 同行端口 >> 专线商管理
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    <div class="hr_10">
    </div>
    <%--<form id="form1" method="get" action="">
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
    </form>--%>
    
    <div class="btnbox">
    <asp:PlaceHolder runat="server" ID="phInsert">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:void(0)" id="i_insert">新增</a>
                </td>
                <asp:PlaceHolder runat="server" ID="phPrivsMoban">
                <td width="90" align="center">
                    <a href="javascript:void(0)" id="i_privs_moban">权限模板管理</a>
                </td>
                </asp:PlaceHolder>
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
                    专线商名称
                </th>
                <th align="center">
                    注册号
                </th>
                <th align="center">
                    税务号
                </th>
                <th align="center">
                    许可证
                </th>
                <th align="center">
                    公司法人
                </th>
                <th align="center">
                    专线负责人
                </th>
                <th align="center">
                    专线负责人电话
                </th>
                <th align="center">
                    专线负责人手机
                </th>            
                <th width="120" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-zxsid="<%#Eval("ZxsId") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1%>                            
                        </td>
                        <td align="center">
                            <%#Eval("MingCheng")%>
                        </td>
                        <td align="center">
                            <%#Eval("ZhuCeHao")%>
                        </td>     
                         <td align="center">
                            <%#Eval("ShuiWuHao")%>
                        </td>              
                        <td align="center">
                            <%#Eval("XuKeZhengHao")%>
                        </td>
                        <td align="center">
                            <%#Eval("FaRenName")%>
                        </td>
                        <td align="center">
                            <%#Eval("LxrName")%>
                        </td>
                        <td align="center">
                            <%#Eval("LxrDianHua")%>
                        </td>
                        <td align="center">
                            <%#Eval("LxrShouJi")%>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("T1"),Eval("Status"),Eval("JiFenStatus"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何专线商信息
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                
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
                Boxy.iframeDialog({ title: "新增专线商", iframeUrl: "zhuanxianshangedit.aspx", width: "900px", height: "600px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-zxsid") };
                var _title = "专线商修改";
                if ($(obj).attr("i_chakan") == "1") _title = "查看专线商信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "zhuanxianshangedit.aspx", width: "900px", height: "600px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("专线商删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { zxsid: _$tr.attr("data-zxsid") };

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
            },
            setStatus: function(obj) {
                var _data = { txtZxsId: $(obj).closest("tr").attr("data-zxsid"), txtStatus: $(obj).attr("data-status") };
                var _comfirm = "专线商禁用后所有用户将不能登录系统，你确定要禁用该专线商吗？";
                if (_data.txtStatus == "0") _comfirm = "你确定要启用该专线商吗？";
                if (!confirm(_comfirm)) return false;
                $(obj).unbind("click").css({ "color": "#999999" });
                $.newAjax({
                    type: "POST", url: utilsUri.createUri(window.location.href, { doType: "setstatus" }), data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.setStatus(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.setStatus(obj); }).css({ "color": "" });
                    }
                });
            },
            setJiFenStatus: function(obj) {
                var _data = { txtZxsId: $(obj).closest("tr").attr("data-zxsid"), txtStatus: $(obj).attr("data-status") };
                var _comfirm = "禁止发放积分后，该专线商所有线路产品均不会发放积分，你确定要禁止发放积分吗？";
                if (_data.txtStatus == "0") _comfirm = "你确定要启用发放积分吗？";
                if (!confirm(_comfirm)) return false;
                $(obj).unbind("click").css({ "color": "#999999" });
                $.newAjax({
                    type: "POST", url: utilsUri.createUri(window.location.href, { doType: "setjifenstatus" }), data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.setStatus(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.setStatus(obj); }).css({ "color": "" });
                    }
                });
            },
            setPrivs: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-zxsid") };
                var _title = "专线商授权";
                Boxy.iframeDialog({ title: _title, iframeUrl: "zhuanxianshangprivsedit.aspx", width: "900px", height: "600px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            privsMoBan: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "专线商权限模板管理", iframeUrl: "zhuanxianshangprivsmoban.aspx", width: "700px", height: "400px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            //utilsUri.initSearch();

            $("#i_insert").bind("click", function() { return iPage.insert(this); });
            $(".i_update").bind("click", function() { return iPage.update(this); });
            $(".i_delete").bind("click", function() { return iPage.del(this); return false; });

            $(".i_jinyong,.i_qiyong").click(function() { iPage.setStatus(this); });
            $(".i_jinyongjifen,.i_qiyongjifen").click(function() { iPage.setJiFenStatus(this); });
            $(".i_privs").click(function() { iPage.setPrivs(this); })

            $("#i_privs_moban").click(function() { iPage.privsMoBan(this); });
        });
    </script>

</asp:Content>
