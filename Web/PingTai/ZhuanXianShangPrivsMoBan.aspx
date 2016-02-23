<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuanXianShangPrivsMoBan.aspx.cs"
    Inherits="Web.PingTai.ZhuanXianShangPrivsMoBan" MasterPageFile="~/MasterPage/Boxy.Master"
    ValidateRequest="false" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 98%; margin: 10px auto;">    
    <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#FFFFFF">
        <tr class="odd">
            <th height="30" width="40" align="center">
                序号
            </th>
            <th align="left">
                权限模板名称
            </th>
            <th align="center" style="width: 120px;">
                操作
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <tr class="even" data-mobanid="<%#Eval("MoBanId") %>">
                    <td height="30" align="center"><%#Container.ItemIndex+1 %></td>
                    <td>
                        <input type="hidden" name="txt_moban_id" value="<%#Eval("MoBanId") %>" />
                        <input type="text" class="inputtext" style="width: 200px" name="txt_moban_name" value="<%#Eval("MingCheng") %>">
                    </td>
                    <td style="text-align:center;">
                        <%#GetCaoZuoHtml() %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr class="even">
            <td height="30" align="center">-</td>
            <td>
                <input type="hidden" name="txt_moban_id" />
                <input type="text" class="inputtext" style="width: 200px" name="txt_moban_name">
            </td>
            <td style="text-align:center;">
                <%=GetCaoZuoHtml1() %>
            </td>
        </tr>
    </table>
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
            baoCun: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = {};
                _data["txt_moban_id"] = $.trim(_$tr.find("input[name='txt_moban_id']").val());
                _data["txt_moban_name"] = $.trim(_$tr.find("input[name='txt_moban_name']").val());

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=baocun", data: _data,
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            iPage.reload();
                        } else {
                            $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                    }
                });

            },
            del: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = {};
                _data["txt_moban_id"] = $.trim(_$tr.find("input[name='txt_moban_id']").val());

                if (!confirm("权限模板信息删除后不可恢复，你确定要删除吗？")) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=shanchu", data: _data,
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            iPage.reload();
                        } else {
                            $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                    }
                });
            },
            sheZhiPrivs: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-mobanid") };
                var _title = "专线商权限模板权限管理";
                top.Boxy.iframeDialog({ title: _title, iframeUrl: "zhuanxianshangprivsmobanprivsedit.aspx", width: "900px", height: "600px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            $(".i_baocun").click(function() { iPage.baoCun(this); });
            $(".i_shanchu").click(function() { iPage.del(this); });
            $(".i_shezhiprivs").click(function() { iPage.sheZhiPrivs(this); });
        });
    </script>
</asp:Content>
