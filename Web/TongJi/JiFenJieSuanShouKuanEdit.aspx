<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenJieSuanShouKuanEdit.aspx.cs" Inherits="Web.TongJi.JiFenJieSuanShouKuanEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
<style type="text/css">
body,html{ overflow-x: hidden;}
</style>
    <div style="width:99%; margin:0px auto; margin-top:5px;">
        <div style="line-height: 24px;"><asp:Literal runat="server" ID="ltrTiShiXinXi"></asp:Literal></div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_dengji_table">
            <tr class="odd">
                <th width="30" height="30">
                    编号
                </th>
                <th width="80">
                    收款日期
                </th>
                <th width="63">
                    收款人
                </th>
                <th width="55">
                    结算积分
                </th>
                <th width="55">
                    收款金额
                </th>
                <th width="84">
                    收款方式
                </th>
                <th>
                    收款账号
                </th>
                <th width="170">
                    备注
                </th>
                <th width="100">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="even">
                        <td height="30" align="center">
                            <input type="hidden" name="txtJieSuanId" value="<%#Eval("JieSuanId") %>" />
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td align="center">
                            <input name="txtRiQi" type="text" class="formsize80 inputtext" value="<%#Eval("JieSuanRiQi","{0:yyyy-MM-dd}") %>"
                                onfocus="WdatePicker()" valid="required" errmsg="请填写收款日期" />
                        </td>
                        <td align="center">
                            <input name="txtName" type="text" class="formsize50 inputtext" value="<%#Eval("JieSuanRenName") %>"
                                maxlength="10" valid="required" errmsg="请填写收款人姓名" />
                        </td>
                        <td align="center">
                            <input name="txtJiFen" type="text" class="formsize50 inputtext" value="<%#Eval("JiFen") %>"
                                maxlength="10" valid="required" errmsg="请填写结算积分" />
                        </td>
                        <td align="center">
                            <input name="txtJinE" type="text" class="formsize50 inputtext" value="<%#Eval("JinE","{0:F2}") %>"
                                maxlength="11" valid="required|isNumber" errmsg="请填写收款金额|请填写正确的收款金额" />
                        </td>
                        <td align="center">
                            <select name="txtFangShi" class="inputselect " valid="required" errmsg="请选择收款方式" data-v="<%#(int)Eval("JieSuanFangShi") %>">
                            <option value="">--请选择--</option>
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi)), "") %>
                            </select>
                        </td>
                        <td align="center">
                            <input name="txtYingHangZhangHao" type="text" class="formsize150 inputtext" value="<%#Eval("JieSuanZhangHao") %>"
                                maxlength="10" valid="required" errmsg="请填写银行账号" />
                        </td>
                        <td align="center">
                            <textarea name="txtBeiZhu" rows="3" class="formsize150 inputarea"><%#Eval("JieSuanBeiZhu") %></textarea>
                        </td>
                        <td align="center">                            
                            <%#GetOperatorHtml(Eval("Status")) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr class="even">
                <td height="30" align="center" id="i_dengji_td_index">
                    &nbsp;
                </td>
                <td align="center">
                    <input name="txtRiQi" type="text" class="formsize80 inputtext" onfocus="WdatePicker()"
                        value="<%=DateTime.Now.ToString("yyyy-MM-dd") %>" valid="required|isDate" errmsg="请填写收款日期|请填写正确的收款日期" />
                </td>
                <td align="center">
                    <input name="txtName" type="text" class="formsize50 inputtext" value="<%=SiteUserInfo.Name %>"
                        maxlength="10" valid="required" errmsg="请填写收款人姓名" />
                </td>
                <td align="center">
                    <input name="txtJiFen" type="text" class="formsize50 inputtext" maxlength="11" valid="required"
                        errmsg="请填写结算积分" />
                </td>
                <td align="center">
                    <input name="txtJinE" type="text" class="formsize50 inputtext" maxlength="11" valid="required|isNumber"
                        errmsg="请填写收款金额|请填写正确的收款金额" />
                </td>
                <td align="center">
                    <select name="txtFangShi" class="inputselect" valid="required" errmsg="请选择收款方式" data-v="">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi)), "") %>
                    </select>
                </td>
                <td align="center">
                   <input name="txtYingHangZhangHao" type="text" class="formsize150 inputtext"
                                maxlength="10" valid="required" errmsg="请填写银行账号" />
                </td>
                <td align="center">
                    <textarea name="txtBeiZhu" rows="3" class="formsize150 inputarea" ></textarea>
                </td>
                <td align="center">
                    <%if(Privs_DengJi) { %>
                    <a href="javascript:void(0)" class="i_baocun">保存</a><%} %>
                </td>
            </tr>
        </table>
        
    </div>
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            //新增、修改
            baoCun: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtJieSuanId: $.trim(_$tr.find("input[name='txtJieSuanId']").val()),
                    txtRiQi: $.trim(_$tr.find("input[name='txtRiQi']").val()),
                    txtName: $.trim(_$tr.find("input[name='txtName']").val()),
                    txtJinE: $.trim(_$tr.find("input[name='txtJinE']").val()),
                    txtFangShi: $.trim(_$tr.find("select[name='txtFangShi']").val()),
                    txtZhangHu: $.trim(_$tr.find("input[name='txtYingHangZhangHao']").val()),
                    txtBeiZhu: $.trim(_$tr.find("textarea[name='txtBeiZhu']").val()),
                    txtJiFen: $.trim(_$tr.find("input[name='txtJiFen']").val())
                };

                var validatorResult = ValiDatorForm.validator(_$tr.get(0), "parent");
                if (!validatorResult) return;

                if (parseFloat(_data.txtJinE) == 0) {
                    parent.tableToolbar._showMsg("请输入正确的收款金额");
                    return;
                }
                if (_data.txtBeiZhu.length > 255) {
                    parent.tableToolbar._showMsg("备注内容最多可输入255个字符"); return;
                    return;
                }
                if (parseInt(_data.txtJiFen) == 0) {
                    parent.tableToolbar._showMsg("请输入正确的结算积分");
                    return;
                }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=baocun",
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
                            $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            },
            //删除
            shanChu: function(obj) {
                if (!confirm("收款登记删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { txtJieSuanId: $.trim(_$tr.find("input[name='txtJieSuanId']").val()) };
                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=shanchu",
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
            $("#i_dengji_td_index").html($("#i_dengji_table").find("tr").length - 1);
            $(".i_baocun").bind("click", function() { iPage.baoCun(this); return false; });
            $(".i_shanchu").bind("click", function() { iPage.shanChu(this); return false; });

            $("select[name='txtFangShi']").each(function() { $(this).val($(this).attr("data-v")) });
        });
    </script>
</asp:Content>