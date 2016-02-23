<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KongWeiBeiZhu.aspx.cs" Inherits="Web.TeamPlan.KongWeiBeiZhu" MasterPageFile="~/MasterPage/Boxy.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 98%; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="text-align:center;">
            <tr class="odd">
                <th width="40" height="30">
                    序号
                </th>
                <th width="80">
                    操作时间
                </th>
                <th width="60">
                    操作人
                </th>
                <th>
                    内容
                </th>
                <th width="160">
                    状态
                </th>
                <th width="70">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt"><ItemTemplate>
            <tr class="<%#(int)Eval("Status")==1?"even":"odd" %>" data-beizhuid="<%#Eval("BeiZhuId") %>">
                <td height="30">
                    <%# Container.ItemIndex + 1%>                            
                </td>
                <td>
                    <%#Eval("IssueTime","{0:yyyy-MM-dd}") %>
                </td>
                <td>
                    <%#Eval("OperatorName") %>
                </td>
                <td style="text-align:left;">
                    <%--<%#EyouSoft.Common.Function.StringValidate.TextToHtml(Eval("NeiRong").ToString()) %>--%>
                    <textarea style="width:410px;" cols="20" rows="4"><%#Eval("NeiRong") %></textarea>
                </td>
                <td>
                    <%#GetStatus(Eval("Status"),Eval("LatestOperatorName"),Eval("LatestTime")) %>
                </td>
                <td>
                    <%#GetCaoZuo(Eval("Status")) %>
                </td>
            </tr>
            </ItemTemplate></asp:Repeater>
            <tr class="even" id="tr_form">
                <td height="30">
                    -
                </td>
                <td>
                    <%=DateTime.Now.ToString("yyyy-MM-dd") %>
                </td>
                <td>
                    <%=SiteUserInfo.Name %>
                </td>
                <td style="text-align:left;">
                    <textarea id="txtNeiRong" name="txtNeiRong" style="width:410px;" cols="20" rows="4"></textarea>
                </td>
                <td>
                    有效
                </td>
                <td>
                    <a href="javascript:void(0)" id="i_a_save">保存</a>
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
            save: function(obj) {
                var _data = { txtNeiRong: $.trim($("#txtNeiRong").val()) };

                if (_data.txtNeiRong.length < 1) { alert("请填写备注内容"); return false; }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST", url: window.location.href + "&doType=save", data: _data, cache: false, dataType: "json", async: false,
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
            shiXiao: function(obj) {
                var _data = { txtBeiZhuId: $(obj).closest("tr").attr("data-beizhuid") };
                if (!confirm("你确定要将该操作备注设为失效吗？")) return false;
                $(obj).unbind("click").css({ "color": "#999999" });
                $.newAjax({
                    type: "POST", url: window.location.href + "&doType=shixiao", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.shiXiao(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.shiXiao(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $(".shixiao").click(function() { iPage.shiXiao(this); return false; });
        });
    </script>

</asp:Content>
