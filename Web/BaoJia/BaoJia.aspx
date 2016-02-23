<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaoJia.aspx.cs" Inherits="Web.BaoJia.BaoJia"
    MasterPageFile="~/MasterPage/Front.Master" Title="收客计划-最新报价" %>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">收客计划</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 收客计划 >> 最新报价
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
    <form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox">
                    报价标题：
                    <input name="txtBiaoTi" type="text" class="inputtext" id="txtBiaoTi" maxlength="50"
                        style="width: 150px;" />
                    专线类别：<select name="txtZxlb" id="txtZxlb" valid="required" errmsg="请选择专线类别" class="inputselect">
                        <option value="">请选择</option>
                        <asp:Literal runat="server" ID="ltrZxlbOption"></asp:Literal>
                    </select>
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
        <asp:PlaceHolder runat="server" ID="phInsert">
            <table border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" id="i_tianjia">新增</a>
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
                    标题
                </th>
                <th align="center" width="15%">
                    附件
                </th>
                <th align="center" width="15%">
                    专线类别
                </th>
                <th width="10%" align="center">
                    发布时间
                </th>
                <th width="10%" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-baojiaid="<%#Eval("BaoJiaId") %>"
                        style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#Eval("BiaoTi")%>
                        </td>
                        <td align="center">
                            <%#GetFuJian(Eval("FuJians")) %>
                        </td>
                        <td align="center">
                            <%#Eval("ZxlbName") %>
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
                        暂无任何报价信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server"></asp:PlaceHolder>
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
            tianJia: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "最新报价新增", iframeUrl: "baojiaedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtBaoJiaId: _$tr.attr("data-baojiaid") };

                if (!confirm("报价信息删除后不可恢复，你确定要删除吗？")) return;
                $.newAjax({
                    type: "post", cache: false, url: "baojia.aspx?dotype=shanchu", dataType: "json",
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
            xiuGai: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-baojiaid") };
                var _title = "最新报价修改";
                if ($(obj).attr("data-chakan") == "1") _title = "查看报价信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "baojiaedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $("#i_tianjia").click(function() { iPage.tianJia(this); });
            $(".i_xiugai").click(function() { iPage.xiuGai(this); });
            $(".i_shanchu").click(function() { iPage.shanChu(this); });
            $('.fujian_ck').bt({ contentSelector: function() { return $(this).next("div").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 320, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
        });
    </script>

</asp:Content>
