<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeHuLxrYongHuEdit.aspx.cs" Inherits="Web.CustomerManage.KeHuLxrYongHuEdit" MasterPageFile="~/MasterPage/Boxy.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#FFFFFF">
            <tr class="odd">
                <th height="30" align="center">
                    姓名
                </th>
                <th align="center">
                    性别
                </th>
                <th align="center">
                    手机
                </th>
                <th align="center">
                    电话
                </th>
                <th align="center">
                    传真
                </th>
                <th align="center">
                    QQ
                </th>
                <th align="center">
                    微信号
                </th>
                <th align="center">
                    状态
                </th>
                <th align="center">
                    账号
                </th>
                <th align="center">
                    邮箱
                </th>
                <th align="center">
                    密码
                </th>
                <th align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt"><ItemTemplate>
            <tr class="lxr_item <%#Container.ItemIndex%2==0?"even":"odd" %>" data-lxrid="<%#Eval("ContactId") %>" data-yonghuid="<%#Eval("YongHuId") %>">
                <td height="30" align="center">
                    <%#Eval("Name") %>
                </td>
                <td align="center">
                    <%#Eval("Sex") %>
                </td>
                <td align="center">
                    <%#Eval("Mobile") %>
                </td>
                <td align="center">
                    <%#Eval("Tel") %>
                </td>
                <td align="center">
                    <%#Eval("Fax") %>
                </td>
                <td align="center">
                    <%#Eval("QQ") %>
                </td>
                <td align="center">
                    <%#Eval("WeiXinHao") %>
                </td>
                <td align="center">
                    <%#Eval("Status") %>
                </td>
                <td align="center">
                    <input type="text" class="inputtext" style="width:60px;" name="txtYongHuMing" value="<%#Eval("YongHuMing") %>" />
                </td>
                <td align="center">
                    <input type="text" class="inputtext" style="width:60px;" name="txtYouXiang" value="<%#Eval("Email") %>" />
                </td>
                <td align="center">
                    <input type="password" class="inputtext" style="width:60px;" name="txtMiMa" />
                </td>
                <td align="center"> 
                    <%#GetCaoZuoHtml(Eval("YongHuId")) %>
                </td>
            </tr>
            </ItemTemplate></asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
            <tr class="even">
                <td colspan="20" style="text-align:center; height:30px;">该客户暂未录入联系人信息</td>
            </tr>
            </asp:PlaceHolder>
            <tr class="even">
                <td colspan="20" style="text-align:left; height:30px; color:#666;">
                注：删除操作仅删除该联系人分配的账号，联系人信息不删除。修改时不填写密码将保留原密码。
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
                var _data = { txtLxrId: _$tr.attr("data-lxrid"), txtYongHuId: _$tr.attr("data-yonghuid"), txtYongHuMing: "", txtMiMa: "", txtKeHuZxsId: "<%=KeHuZxsId %>", txtKeHuLaiYuan: "<%=(int)LaiYuan %>", txtYouXiang: "" };
                _data.txtYongHuMing = $.trim(_$tr.find("input[name='txtYongHuMing']").val());
                _data.txtMiMa = $.trim(_$tr.find("input[name='txtMiMa']").val());
                _data.txtYouXiang = $.trim(_$tr.find("input[name='txtYouXiang']").val());

                if (_data.txtYongHuMing.length == 0) { alert("请输入用户名"); return false; }
                if (_data.txtYongHuId == "0" && _data.txtMiMa.length == 0) { alert("请输入密码"); return false; }
                if (_data.txtYouXiang.length == 0) { alert("请输入邮箱"); return false; }

                $(obj).unbind("click").css({ "color": "#999999" });
                var _self = this;
                $.newAjax({
                    type: "post", cache: false, url: window.location.href + "&dotype=baocun", data: _data, dataType: "json",
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            _self.reload();
                        } else {
                            alert(response.msg);
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
                var _data = { txtLxrId: _$tr.attr("data-lxrid"), txtYongHuId: _$tr.attr("data-yonghuid"), txtYongHuMing: "", txtMiMa: "", txtKeHuZxsId: "<%=KeHuZxsId %>", txtKeHuLaiYuan: "<%=(int)LaiYuan %>" };
                _data.txtYongHuMing = $.trim(_$tr.find("input[name='txtYongHuMing']").val());
                _data.txtMiMa = $.trim(_$tr.find("input[name='txtMiMa']").val());

                if (!confirm("删除联系人账号不可恢复，你确定要删除吗？")) return false;

                $(obj).unbind("click").css({ "color": "#999999" });
                var _self = this;
                $.newAjax({
                    type: "post", cache: false, url: window.location.href + "&dotype=shanchu", data: _data, dataType: "json",
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            _self.reload();
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
            $(".lxr_item").each(function() {
                var _$tr = $(this);
                if (_$tr.attr("data-yonghuid") != "0") {
                    _$tr.find("input[name='txtYongHuMing']").attr("readonly", "readonly").css({ "background-color": "#dadada" });
                } else {
                    _$tr.find(".i_shanchu").remove();
                }
            });
            $(".i_baocun").click(function() { iPage.baoCun(this); });
            $(".i_shanchu").click(function() { iPage.del(this); });
        });
    </script>

</asp:Content>
