<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiJieSheZhuTiYongHuEdit.aspx.cs" Inherits="Web.ResourceManage.DiJieSheZhuTiYongHuEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#FFFFFF">
            <tr class="odd">
                <th height="30" align="center" width="40px;">
                    序号
                </th>
                <th align="center">
                    姓名
                </th>
                <th align="center">
                    手机
                </th>
                <th align="center">
                    电话
                </th>
                <th align="center">
                    QQ
                </th>
                <th align="center">
                    账号
                </th>
                <th align="center">
                    密码
                </th>
                <th align="left" style="width:80px;">
                    &nbsp;操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <tr class="lxr_item <%#Container.ItemIndex%2==0?"even":"odd" %>" data-lxrid="<%#Eval("LxrId") %>" data-yonghuid="<%#Eval("YongHuId") %>">
                        <td align="center"><%# Container.ItemIndex + 1%></td>
                        <td height="30" align="center">
                            <input type="text" class="inputtext" name="txtLxrName" value="<%#Eval("LxrName") %>" style="width: 90px;" />
                        </td>
                        <td align="center">
                            <input type="text" class="inputtext" name="txtLxrShouJi" value="<%#Eval("LxrShouJi") %>" style="width: 90px;" />
                        </td>
                        <td align="center">
                            <input type="text" class="inputtext" name="txtLxrDianHua" value="<%#Eval("LxrDianHua") %>" style="width: 90px;" />
                        </td>
                        <td align="center">
                            <input type="text" class="inputtext" name="txtLxrQQ" value="<%#Eval("LxrQQ") %>" style="width: 90px;" />
                        </td>
                        <td align="center">
                            <input type="text" class="inputtext" style="width: 90px;" name="txtYongHuMing" value="<%#Eval("YongHuMing") %>" />
                        </td>
                        <td align="center">
                            <input type="password" class="inputtext" style="width: 90px;" name="txtMiMa" />
                        </td>
                        <td align="left">
                           &nbsp;<%#GetCaoZuo(Eval("LxrId"),Eval("YongHuId")) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        
        <div style="color:#666; margin-top:5px;">
        说明：修改账户信息时不填写密码将保留原始密码。
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
            baoCun: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtLxrId: _$tr.attr("data-lxrid"), txtYongHuId: _$tr.attr("data-yonghuid"), txtYongHuMing: "", txtMiMa: "",txtLxrName:"",txtLxrShouJi:"",txtLxrDianHua:"",txtLxrQQ:"" };
                _data.txtYongHuMing = $.trim(_$tr.find("input[name='txtYongHuMing']").val());
                _data.txtMiMa = $.trim(_$tr.find("input[name='txtMiMa']").val());
                _data.txtLxrName = $.trim(_$tr.find("input[name='txtLxrName']").val());
                _data.txtLxrShouJi = $.trim(_$tr.find("input[name='txtLxrShouJi']").val());
                _data.txtLxrDianHua = $.trim(_$tr.find("input[name='txtLxrDianHua']").val());
                _data.txtLxrQQ = $.trim(_$tr.find("input[name='txtLxrQQ']").val());

                if (_data.txtLxrName.length == 0) { alert("请输入姓名"); return false; }
                if (_data.txtYongHuMing.length == 0) { alert("请输入用户名"); return false; }
                if (_data.txtYongHuId == "0" && _data.txtMiMa.length == 0) { alert("请输入密码"); return false; }
               
                $(obj).unbind("click").css({ "color": "#999999" });
                var _self = this;
                $.newAjax({type: "post", cache: false, url: window.location.href + "&dotype=baocun", data: _data, dataType: "json",
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            _self.reload();
                        } else {
                            $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            },
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtLxrId: _$tr.attr("data-lxrid"), txtYongHuId: _$tr.attr("data-yonghuid") };

                if (!confirm("账号删除后不可恢复，你确定要删除吗？")) return false;

                $(obj).unbind("click").css({ "color": "#999999" });
                var _self = this;
                $.newAjax({ type: "post", cache: false, url: window.location.href + "&dotype=shanchu", data: _data, dataType: "json",
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            _self.reload();
                        } else {
                            $(obj).bind("click", function() { iPage.shanChu(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.shanChu(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $(".lxr_item").each(function() {
                var _$tr = $(this);
                if (_$tr.attr("data-yonghuid") != "0") {
                    _$tr.find("input[name='txtYongHuMing']").attr("readonly", "readonly").css({ "background-color": "#dadada" });
                }
            });

            $(".baocun").click(function() { iPage.baoCun(this); });
            $(".shanchu").click(function() { iPage.shanChu(this); });
        });
    </script>

</asp:Content>
