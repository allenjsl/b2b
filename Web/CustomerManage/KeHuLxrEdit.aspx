<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeHuLxrEdit.aspx.cs" Inherits="Web.CustomerManage.KeHuLxrEdit"
    MasterPageFile="~/MasterPage/Boxy.Master" %>
    
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#FFFFFF">
            <tr class="odd">
                <th height="30" align="center">
                    姓名
                </th>
                <th align="center">
                    性别
                </th>
                <th align="center">
                    部门/职务
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
                    QQ/微信号
                </th>
                <th align="center">
                    状态
                </th>
                <th align="center" style="width:90px;">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <tr class="even">
                        <td height="30" align="center">
                            <input type="hidden" value='<%# Eval("ContactId") %>' name="txt_lxr_id" />
                            <input type="text" class="inputtext" style="width: 55px" name="txt_lxr_name"
                                value='<%#Eval("Name") %>'>
                        </td>
                        <td align="center">
                            <select name="txt_lxr_xingbie" class="inputselect" data-xingbie="<%#(int)Eval("Sex") %>">
                                <option value="0" >请选择</option>
                                <option value="1" >女</option>
                                <option value="2" >男</option>
                            </select>
                        </td>
                        <td align="left">
                            部门:
                            <input type="text" class="inputtext" name="txt_lxr_bumen" value='<%# Eval("DepartId") %>'
                                style="width: 50px;">
                            <br>
                            职务:
                            <input type="text" class="inputtext" name="txt_lxr_zhiwu" value='<%#Eval("Job") %>'
                                style="width: 50px">
                        </td>
                        <td align="center">
                            <input type="text" class="inputtext" name="txt_lxr_shouji" value='<%#Eval("Mobile") %>'
                                style="width: 75px">
                        </td>
                        <td align="center">
                            <input type="text" class="inputtext" name="txt_lxr_dianhua" value='<%#Eval("Tel") %>'
                                style="width: 75px">
                        </td>
                        <td align="center">
                            <input type="text" class="inputtext" name="txt_lxr_fax" value='<%#Eval("Fax") %>'
                                style="width: 75px">
                        </td>
                        <td align="left">
                            QQ:<input type="text" class="inputtext" name="txt_lxr_qq" value='<%#Eval("qq") %>'
                                style="width: 65px"><br />
                            WX:<input type="text" class="inputtext" name="txt_lxr_weixin"
                                value='<%#Eval("WeiXinHao") %>' style="width: 65px">
                        </td>
                        <td align="left">
                            <select name="txt_lxr_status" class="inputselect" data-status="<%#(int)Eval("Status") %>">
                                <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除 %>">
                                    不可修改不可删除</option>
                                <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改不可删除 %>">
                                    可修改不可删除</option>
                                <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改可删除 %>">
                                    可修改可删除</option>
                            </select>
                        </td>
                        <td align="center">
                            <%#GetCaoZuoHtml() %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            
            <tr class="even">
                <td height="30" align="center">
                    <input type="hidden" name="txt_lxr_id" />
                    <input type="text"  class="inputtext" style="width: 55px" name="txt_lxr_name">
                </td>
                <td align="center">
                    <select name="txt_lxr_xingbie" class="inputselect" >
                        <option value="0">请选择</option>
                        <option value="1">女</option>
                        <option value="2">男</option>
                    </select>
                </td>
                <td align="left">
                    部门:
                    <input type="text" class="inputtext" name="txt_lxr_bumen" 
                        style="width: 50px;">
                    <br>
                    职务:
                    <input type="text" class="inputtext" name="txt_lxr_zhiwu" 
                        style="width: 50px">
                </td>
                <td align="center">
                    <input type="text" class="inputtext" name="txt_lxr_shouji" 
                        style="width: 75px">
                </td>
                <td align="center">
                    <input type="text" class="inputtext" name="txt_lxr_dianhua" 
                        style="width: 75px">
                </td>
                <td align="center">
                    <input type="text" class="inputtext" name="txt_lxr_fax" 
                        style="width: 75px">
                </td>
                <td align="left">
                    QQ:<input type="text" class="inputtext" name="txt_lxr_qq" 
                        style="width: 65px"><br />
                    WX:<input type="text" class="inputtext" name="txt_lxr_weixin" 
                        style="width: 65px">
                </td>
                <td align="left">
                    <select name="txt_lxr_status" class="inputselect" data-status="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除 %>">
                        <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除 %>">
                            不可修改不可删除</option>
                        <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改不可删除 %>">
                            可修改不可删除</option>
                        <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改可删除 %>">
                            可修改可删除</option>
                    </select>
                </td>
                <td align="center">
                    <a href="javascript:void(0)" class="i_baocun">保存</a>
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
                _data["txt_lxr_id"] = $.trim(_$tr.find("input[name='txt_lxr_id']").val());
                _data["txt_lxr_name"] = $.trim(_$tr.find("input[name='txt_lxr_name']").val());
                _data["txt_lxr_xingbie"] = $.trim(_$tr.find("select[name='txt_lxr_xingbie']").val());
                _data["txt_lxr_bumen"] = $.trim(_$tr.find("input[name='txt_lxr_bumen']").val());
                _data["txt_lxr_zhiwu"] = $.trim(_$tr.find("input[name='txt_lxr_zhiwu']").val());
                _data["txt_lxr_shouji"] = $.trim(_$tr.find("input[name='txt_lxr_shouji']").val());
                _data["txt_lxr_dianhua"] = $.trim(_$tr.find("input[name='txt_lxr_dianhua']").val());
                _data["txt_lxr_fax"] = $.trim(_$tr.find("input[name='txt_lxr_fax']").val());
                _data["txt_lxr_qq"] = $.trim(_$tr.find("input[name='txt_lxr_qq']").val());
                _data["txt_lxr_weixin"] = $.trim(_$tr.find("input[name='txt_lxr_weixin']").val());
                _data["txt_lxr_status"] = $.trim(_$tr.find("select[name='txt_lxr_status']").val());

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
                _data["txt_lxr_id"] = $.trim(_$tr.find("input[name='txt_lxr_id']").val());

                if (!confirm("联系人信息删除后不可恢复，你确定要删除吗？")) return false;

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
            }
        };

        $(document).ready(function() {
            $(".i_baocun").click(function() { iPage.baoCun(this); });
            $(".i_shanchu").click(function() { iPage.del(this); });

            $("select[name='txt_lxr_xingbie']").each(function() { $(this).val($(this).attr("data-xingbie")) });
            $("select[name='txt_lxr_status']").each(function() { $(this).val($(this).attr("data-status")) });
        });
    </script>

</asp:Content>
