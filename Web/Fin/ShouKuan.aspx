<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShouKuan.aspx.cs" Inherits="Web.Fin.ShouKuan" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
<style type="text/css">
body,html{ overflow-x: hidden;}
</style>
    <div style="width:880px; margin:10px auto;">
        <div style="line-height: 24px;"><asp:Literal runat="server" ID="ltrJinE"></asp:Literal></div>
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
                            <input type="hidden" name="txtShouKuanId" value="<%#Eval("DengJiId") %>" />
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td align="center">
                            <input name="txtRiQi" type="text" class="formsize80 inputtext" value="<%#Eval("ShouKuanRiQi","{0:yyyy-MM-dd}") %>"
                                onfocus="WdatePicker()" valid="required|isDate" errmsg="请填写收款日期|请填写正确的收款日期" />
                        </td>
                        <td align="center">
                            <input name="txtName" type="text" class="formsize50 inputtext" value="<%#Eval("ShouKuanRenName") %>"
                                maxlength="10" valid="required" errmsg="请填写收款人姓名" />
                        </td>
                        <td align="center">
                            <input name="txtJinE" type="text" class="formsize50 inputtext" value="<%#Eval("JinE","{0:F2}") %>"
                                maxlength="11" valid="required|isNumber" errmsg="请填写收款金额|请填写正确的收款金额" />
                        </td>
                        <td align="center">
                            <select name="txtFangShi" class="inputselect " valid="required" errmsg="请选择收款方式">
                                <%#GetFangShiOptionHtml((int)Eval("FangShi"))%>
                            </select>
                        </td>
                        <td align="center">
                            <select name="txtZhangHu" class="inputselect  formsize260" valid="required" errmsg="请选择收款账号">
                                <%#GetZhangHuOptionHtml(Eval("ZhangHuId"))%>
                            </select>
                        </td>
                        <td align="center">
                            <textarea name="txtBeiZhu" rows="3" class="formsize150 inputarea"><%#Eval("ShouKuanBeiZhu") %></textarea>
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
                    <input name="txtJinE" type="text" class="formsize50 inputtext" maxlength="11" valid="required|isNumber"
                        errmsg="请填写收款金额|请填写正确的收款金额" />
                </td>
                <td align="center">
                    <select name="txtFangShi" class="inputselect" valid="required" errmsg="请选择收款方式">
                        <%=GetFangShiOptionHtml("")%>
                    </select>
                </td>
                <td align="center">
                    <select name="txtZhangHu" class="inputselect formsize260" valid="required" errmsg="请选择收款账号">
                        <%=GetZhangHuOptionHtml("") %>
                    </select>
                </td>
                <td align="center">
                    <textarea name="txtBeiZhu" rows="3" class="formsize150 inputarea" ></textarea>
                </td>
                <td align="center">
                    <%if (Privs_Insert)
                      { %>
                    <a href="javascript:void(0)" class="i_save">保存</a>
                    <%} %>
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
            save: function(obj) {
                var _$tr = $(obj).closest("tr");
                //_$tr.find("input").each(function() { _$obj = $(this); if (_$obj.attr("id").length == 0) _$obj.attr("id", "txt" + Math.random()) });
                var _data = { txtShouKuanId: $.trim(_$tr.find("input[name='txtShouKuanId']").val()),
                    txtRiQi: $.trim(_$tr.find("input[name='txtRiQi']").val()),
                    txtName: $.trim(_$tr.find("input[name='txtName']").val()),
                    txtJinE: $.trim(_$tr.find("input[name='txtJinE']").val()),
                    txtFangShi: $.trim(_$tr.find("select[name='txtFangShi']").val()),
                    txtZhangHu: $.trim(_$tr.find("select[name='txtZhangHu']").val()),
                    txtBeiZhu: $.trim(_$tr.find("textarea[name='txtBeiZhu']").val())
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
            //删除
            del: function(obj) {
                if (!confirm("收款登记删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { txtShouKuanId: $.trim(_$tr.find("input[name='txtShouKuanId']").val()) };
                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=delete",
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
            //审批
            shenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { xmid: '<%=XiangMuId %>', kxtype: '<%=(int)IKuanXiangType.Value %>', shoukuanid: $.trim(_$tr.find("input[name='txtShouKuanId']").val()), refererWinId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
                parent.Boxy.iframeDialog({ title: "审批", iframeUrl: "shoukuanshenpiboxy.aspx", width: "650", height: "200px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            $("#i_dengji_td_index").html($("#i_dengji_table").find("tr").length - 1);
            $(".i_save").bind("click", function() { iPage.save(this); return false; });
            $(".i_delete").bind("click", function() { iPage.del(this); return false; });
            $(".i_shenpi").bind("click", function() { iPage.shenPi(this) });
            
        });
    </script>
</asp:Content>