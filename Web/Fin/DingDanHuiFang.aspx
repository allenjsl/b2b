<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingDanHuiFang.aspx.cs"
    Inherits="Web.Fin.DingDanHuiFang" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 630px; margin: 10px auto;">
        <span class="formtableT">已回访列表</span>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="36" height="30">
                    编号
                </th>
                <th width="88">
                    回访时间
                </th>
                <th width="88">
                    被访人身份
                </th>
                <th width="75">
                    被访人姓名
                </th>
                <th width="110">
                    被访人电话
                </th>
                <th width="165">
                    回访结果
                </th>
                <th width="60">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
            <ItemTemplate>
            <tr class="even" i_xmid="<%#Eval("HuiFangId") %>" data-dingdanid="<%#Eval("OrderId") %>">
                <td height="30" align="center">
                    <%# Container.ItemIndex + 1%>
                </td>
                <td align="center">
                    <%#ToDateTimeString(Eval("Time"))%>
                </td>
                <td align="center">
                    <%#Eval("ShenFen")%>
                </td>
                <td align="center">
                    <%#Eval("XingMing")%>
                </td>
                <td align="center">
                    <%#Eval("Telephone")%>
                </td>
                <td align="center">
                    <%#Eval("JieGuo")%>
                </td>
                <td align="center">
                    <%#GetCaoZuo() %>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
            <tr class="even"><td style="height:30px; text-align:center;" colspan="7">暂无回访信息</td></tr>
            </asp:PlaceHolder>
        </table>
    </div>
    
    <div style="width: 630px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="120" align="right">
                    回访时间：
                </th>
                <td>
                    <input name="txtHuiFangTime" type="text" class="formsize80 inputtext" id="txtHuiFangTime"
                        runat="server" onfocus="WdatePicker()" valid="required|isDate" errmsg="请填写回访时间|请填写正确的回访时间" />
                </td>
                <th width="120" align="right">
                    被访人身份：
                </th>
                <td>
                    <input name="txtShenFen" type="text" class="formsize80 inputtext" id="txtShenFen"
                        runat="server" maxlength="20" valid="required" errmsg="请填写被访人身份" />
                </td>
            </tr>
            <tr class="odd">
                <th width="120" align="right">
                    被访人姓名：
                </th>
                <td>
                    <input name="txtXingMing" type="text" class="formsize80 inputtext" id="txtXingMing"
                        runat="server" maxlength="20" valid="required" errmsg="请填写被访人姓名" />
                </td>
                <th align="right">
                    被访人电话：
                </th>
                <td>
                    <input name="txtTelephone" type="text" class="formsize80 inputtext" id="txtTelephone" runat="server" maxlength="30" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    回访结果：
                </th>
                <td colspan="3">
                    <textarea name="txtJieGuo" rows="3" class="formsize450 inputarea" id="txtJieGuo" runat="server"></textarea>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left">
                    <table border="0" align="center" cellpadding="0" cellspacing="0" visible="true">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        var iPage = {
            //关闭窗口
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = "dingdanhuifang.aspx?orderid=<%=OrderId %>";
            },
            save: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return false;

                var _data = { txtHuiFangTime: $.trim($("#<%=txtHuiFangTime.ClientID %>").val()),
                    txtShenFen: $.trim($("#<%=txtShenFen.ClientID %>").val()),
                    txtXingMing: $.trim($("#<%=txtXingMing.ClientID %>").val()),
                    txtTelephone: $.trim($("#<%=txtTelephone.ClientID %>").val()),
                    txtJieGuo: $.trim($("#<%=txtJieGuo.ClientID %>").val())
                };

                if (_data.txtJieGuo.length > 255) { parent.tableToolbar._showMsg("回访结果最多可输入255个字符"); return false; }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=save",
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
                            $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                    }
                });
            },
            del: function(obj) {
                if (!confirm("回访信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { txtHuiFangId: _$tr.attr("i_xmid") };
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
            xiuGai: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { orderid: _$tr.attr("data-dingdanid"), huifangid: _$tr.attr("i_xmid") };
                window.location.href = "dingdanhuifang.aspx?" + $.param(_data);
                return false;
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $(".i_delete").bind("click", function() { iPage.del(this); return false; });
            $(".i_xiugai").click(function() { iPage.xiuGai(this); return false; });
        });
    </script>

</asp:Content>
