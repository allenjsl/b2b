<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DengZhangYiXiaoZhang.aspx.cs"
    Inherits="Web.Fin.DengZhangYiXiaoZhang" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="45" align="center">
                    序号
                </th>
                <th align="center" style="width:8%;">
                    控位号
                </th>
                <th align="center">
                    线路名称
                </th>
                <th align="center" style="width: 10%;">
                    订单号
                </th>
                <th align="center" style="width: 18%;">
                    对方单位
                </th>
                <th align="center" style="width: 10%;">
                    应收金额
                </th>
                <th align="center" style="width: 11%;">
                    销账/冲抵金额
                </th>
                <th align="center" style="width: 10%;">
                    销账/冲抵时间
                </th>
                <th align="center" style="width: 8%;">
                    操作人
                </th>
                <th align="center" style="width: 9%;">
                    销账类型
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" style="height: 30px;" i_xiaozhangid="<%#Eval("XiaoZhangId") %>"
                        i_leixing="<%#(int)Eval("LeiXing") %>">
                        <td style="text-align:right;">
                            <input type="checkbox" name="chk">&nbsp;<%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>&nbsp;
                        </td>
                        <td align="center">
                            <%#Eval("KongWeiCode")%>
                        </td>
                        <td align="center">
                            <%#GetRouteName(Eval("RouteName"),Eval("YeWuLeiXing"),Eval("LeiXing"))%>
                        </td>
                        <td align="center">
                            <%#Eval("OrderCode")%>
                        </td>
                        <td align="center">
                            <%#Eval("KeHuName") %>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YingShouJinE"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("XiaoZhangJinE"))%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("IssueTime"))%>
                        </td>
                        <td align="center">
                            <%#Eval("OperatorName")%>
                        </td>
                        <td align="center">
                            <%#GetXiaoZhangLeiXing1(Eval("LeiXing"),Eval("LeiXing1"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何销账信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="5">
                        <asp:PlaceHolder runat="server" ID="phQuXiaoXiaoZhang">
                        <input type="button" value="取消销账" id="btnQuXiaoXiaoZhang" />
                        </asp:PlaceHolder>
                        <asp:PlaceHolder runat="server" ID="phQuXiaoChongDi">
                        <input type="button" value="取消冲抵" id="btnQuXiaoChongDi" />
                        </asp:PlaceHolder>
                        &nbsp;
                    </td>
                    <td  align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrXiaoZhangJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center" colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <asp:PlaceHolder runat="server" ID="phPaging">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <cc1:exporpageinfoselect id="paging" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
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
            quXiaoXiaoZhang: function(obj) {
                var _data = { txtXiaoZhangId: [] };

                $(":checkbox:checked").each(function() {
                    var _$obj = $(this);
                    var _$tr = _$obj.closest("tr");
                    var _leiXing = _$tr.attr("i_leixing");

                    if (_leiXing != "<%=(int)EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing.销账 %>") {
                        _$obj.removeAttr("checked");
                        return true;
                    }

                    _data.txtXiaoZhangId.push(_$tr.attr("i_xiaozhangid"));
                });

                if (_data.txtXiaoZhangId.length == 0) { alert("请选择要取消销账的信息！"); return false; }
                if (!confirm("取消销账操作不可逆，你确定要取消销账吗？")) return false;

                $(obj).unbind("click").attr("disabled", "disabled");

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "quxiaoxiaozhang" }),
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
                            $(obj).bind("click", function() { iPage.quXiaoXiaoZhang(obj); }).removeAttr("disabled");
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.quXiaoXiaoZhang(obj); }).removeAttr("disabled");
                    }
                });
            },
            quXiaoChongDi: function(obj) {
                var _data = { txtXiaoZhangId: [] };

                $(":checkbox:checked").each(function() {
                    var _$obj = $(this);
                    var _$tr = _$obj.closest("tr");
                    var _leiXing = _$tr.attr("i_leixing");

                    if (_leiXing != "<%=(int)EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing.冲抵 %>") {
                        _$obj.removeAttr("checked");
                        return true;
                    }

                    _data.txtXiaoZhangId.push(_$tr.attr("i_xiaozhangid"));
                });

                if (_data.txtXiaoZhangId.length == 0) { alert("请选择要取消冲抵的信息！"); return false; }
                if (!confirm("取消冲抵操作不可逆，你确定要取消冲抵吗？")) return false;

                $(obj).unbind("click").attr("disabled", "disabled");

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "quxiaochongdi" }),
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
                            $(obj).bind("click", function() { iPage.quXiaoChongDi(obj); }).removeAttr("disabled");
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.quXiaoChongDi(obj); }).removeAttr("disabled");
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#btnQuXiaoXiaoZhang").click(function() { iPage.quXiaoXiaoZhang(this); });
            $("#btnQuXiaoChongDi").click(function() { iPage.quXiaoChongDi(this); });
        });
    </script>

</asp:Content>
