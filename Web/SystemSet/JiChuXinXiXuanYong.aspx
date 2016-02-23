<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiChuXinXiXuanYong.aspx.cs"
    Inherits="Web.SystemSet.JiChuXinXiXuanYong" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 650px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th style="width: 50px; height: 30px; text-align: right;">选择&nbsp;</th>
                
                <th><%=IJiChuXinXiType %></th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
            <ItemTemplate>
            <tr style="height: 28px;" class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                <td style="text-align:right;">
                    <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                    <input type="checkbox" name="chk" id="chk_<%#Eval("Id") %>" />&nbsp;
                </td>
                <td>&nbsp;<label for="chk_<%#Eval("Id") %>"><%#Eval("Name") %></label></td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="3" style="height: 30px; text-align: center;">
                        暂无任何信息。
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
        <div style="line-height:30px; height:30px; text-align:center;">
            <input type="button" id="i_btn_xuanyong" value="  选  择  " />
        </div>
    </div>

    <script type="text/javascript">
        var iPage = {
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            xuanYong: function() {
                var _ret = [];
                $("input[type='checkbox']:checked").each(function() {
                    var _$nexttd = $(this).parent().next();
                    _ret.push(_$nexttd.find("label").html());
                });

                if (_ret.length == 0) { alert("未选择任何信息"); return; }

                var callBackFn = '<%=EyouSoft.Common.Utils.GetQueryStringValue("callbackfn") %>';
                var refererIframeId = '<%=EyouSoft.Common.Utils.GetQueryStringValue("refereriframeid") %>';
                var _win = top || window;

                if (callBackFn.length > 0) {
                    if (refererIframeId.length == 0) window.parent[callBackFn](_ret);
                    else _win.Boxy.getIframeWindow(refererIframeId)[callBackFn](_ret);
                }

                iPage.close();
            }
        };

        $(document).ready(function() {
            $("#i_btn_xuanyong").bind("click", function() { iPage.xuanYong(); });
        });
    </script>

</asp:Content>
