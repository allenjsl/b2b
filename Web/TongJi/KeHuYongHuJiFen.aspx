<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeHuYongHuJiFen.aspx.cs"
    Inherits="Web.TongJi.KeHuYongHuJiFen" MasterPageFile="~/MasterPage/Front.Master"
    Title="客户用户积分统计表-统计分析" %>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">统计分析</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 统计分析 >> 客户用户积分统计表
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
                    客户单位：<uc1:KeHuXuanZe runat="server" id="txtKeHu" DuiFangCaoZuoRenClientId="txtKeHuLxrId">
                    </uc1:KeHuXuanZe>
                    对方操作人：<select name="txtKeHuLxrId" id="txtKeHuLxrId" class="inputselect" data-v="<%=KeHuLxrId %>">
                        <option value="">请选择客户单位</option>
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
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="40" align="center">
                    序号
                </th>
                <th align="center">
                    客户单位
                </th>
                <th width="8%" align="center">
                    用户姓名
                </th>
                <th align="center" width="9%">
                    用户账号
                </th>
                <th width="9%" align="center">
                    联系电话
                </th>
                <th align="center" width="9%">
                    联系手机
                </th>
                <%--<th width="9%" align="center">
                    联系邮箱
                </th>--%>
                <th width="9%" align="right">
                    可用积分&nbsp;
                </th>
                <th width="9%" align="right">
                    冻结积分&nbsp;
                </th>
                <th width="9%" align="right">
                    已兑换积分&nbsp;
                </th>
                <th width="9%" align="center">
                    查看积分明细
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" style="height: 30px;" data-kehuid="<%#Eval("KeHuId") %>" data-yonghuid="<%#Eval("YongHuId") %>">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#Eval("KeHuName")%>
                        </td>
                        <td align="center">
                            <%#Eval("YongHuName")%>
                        </td>
                        <td align="center">
                            <%#Eval("YongHuMing")%>
                        </td>
                        <td align="center">
                            <%#Eval("YongHuDianHua")%>
                        </td>
                        <td align="center">
                            <%#Eval("YongHuShouJi")%>
                        </td>
                        <%--<td align="center">
                            <%#Eval("YongHuYouXiang")%>
                        </td>--%>
                        <td align="right">
                            <%#Eval("KeYongJiFen")%>&nbsp;
                        </td>
                        <td align="right">
                            <%#Eval("DongJieJiFen")%>&nbsp;
                        </td>
                        <td align="right">
                            <%#Eval("YiShiYongJiFen")%>&nbsp;
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" data-class="yonghujifenmingxi">查看积分明细</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何客户用户积分统计信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td colspan="6" style="text-align: right; height: 30px;">
                        合计：
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrKeYongJiFenHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrDongJieJiFenHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrYiShiYongJiFenHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td></td>
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
            chaKanYongHuJiFenMingXi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtKeHuId: _$tr.attr("data-kehuid"), txtYongHuId: _$tr.attr("data-yonghuid") };

                Boxy.iframeDialog({ title: "查看用户积分明细", iframeUrl: "kehuyonghujifenmingxi.aspx", width: "920px", height: "600px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $("a[data-class='yonghujifenmingxi']").click(function() { iPage.chaKanYongHuJiFenMingXi(this); });
        });
    </script>

</asp:Content>
