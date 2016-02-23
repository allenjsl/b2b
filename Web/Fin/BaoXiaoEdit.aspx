<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaoXiaoEdit.aspx.cs" Inherits="Web.Fin.BaoXiaoEdit"
    MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc1" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 750px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="120" height="30" align="right">
                    报销日期：
                </th>
                <td width="167">
                    <input name="txtRiQi" type="text" class="formsize80 inputtext" id="txtRiQi" runat="server"
                        onfocus="WdatePicker()" valid="required|isDate" errmsg="请填写报销日期|请填写正确的报销日期" />
                </td>
                <th width="120" align="right">
                    报销人：
                </th>
                <td width="215">
                    <uc1:SellsSelect runat="server" ID="txtBaoXiaoRen" ReadOnly="true" IsShowSelect="true"
                        SetTitle="报销人" />
                </td>
            </tr>
            <tr class="odd">
            </tr>
            <tr class="even">
                <td colspan="4" align="right">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#ffffff"
                        id="i_table_autoadd">
                        <tr class="even">
                            <td width="36" height="30" align="center">
                                编号
                            </td>
                            <td align="center">
                                消费日期
                            </td>
                            <td align="center">
                                消费金额
                            </td>
                            <td  align="center">
                                消费类型
                            </td>
                            <td  align="center" style="width:250px;">
                                消费备注
                            </td>
                            <td align="center">
                                操作
                            </td>
                        </tr>
                        <asp:Repeater runat="server" ID="rpts">
                        <ItemTemplate>
                        <tr class="even tempRow">
                            <td height="30" align="center" class="index">
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td align="center">
                                <input name="txtXiaoFeiRiQi" type="text" class="formsize80 inputtext" onfocus="WdatePicker()"
                                    valid="required|isDate" errmsg="请填写消费日期|请填写正确的消费日期" value="<%#Eval("XiaoFeiRiQi","{0:yyyy-MM-dd}") %>" />
                            </td>
                            <td align="center">
                                <input name="txtXiaoFeiJinE" type="text" class="formsize50 inputtext i_td_heji_field"
                                    maxlength="8" valid="required|isNumber" errmsg="请填写消费金额|请填写正确的消费金额" value="<%#Eval("JinE","{0:F2}") %>" />
                            </td>
                            <td align="center">
                                <select name="txtXiaoFeiType" class="inputselect">
                                    <%#GetBaoXiaoTypeOptionHtml(Eval("XiaoFeiType"))%>
                                </select>
                            </td>
                            <td align="center">
                                <textarea name="txtXiaoFeiBeiZhu" rows="3" class="formsize180 inputarea"><%#Eval("XiaoFeiBeiZhu")%></textarea>
                            </td>
                            <td align="center">
                                <a href="javascript:void(0)" class="addbtn"><img src="/images/addimg.gif" width="48" height="20" /></a> 
                                <a href="javascript:void(0)"class="delbtn"><img src="/images/delimg.gif" width="48" height="20" /></a>
                            </td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                        <asp:PlaceHolder runat="server" ID="phEmpty">
                        <tr class="even tempRow">
                            <td height="30" align="center" class="index">
                                1
                            </td>
                            <td align="center">
                                <input name="txtXiaoFeiRiQi" type="text" class="formsize80 inputtext" onfocus="WdatePicker()"
                                    valid="required|isDate" errmsg="请填写消费日期|请填写正确的消费日期" />
                            </td>
                            <td align="center">
                                <input name="txtXiaoFeiJinE" type="text" class="formsize50 inputtext i_td_heji_field"
                                    maxlength="11" valid="required|isNumber" errmsg="请填写消费金额|请填写正确的消费金额" />
                            </td>
                            <td align="center">
                                <select name="txtXiaoFeiType" class="inputselect">
                                    <%=GetBaoXiaoTypeOptionHtml(null)%>
                                </select>
                            </td>
                            <td align="center">
                                <textarea name="txtXiaoFeiBeiZhu" rows="3" class="formsize180 inputarea" max="5"></textarea>
                            </td>
                            <td align="center">
                                <a href="javascript:void(0)" class="addbtn"><img src="/images/addimg.gif" width="48" height="20" /></a> 
                                <a href="javascript:void(0)" class="delbtn"><img src="/images/delimg.gif" width="48" height="20" /></a>
                            </td>
                        </tr>
                        </asp:PlaceHolder>
                    </table>
                </td>
            </tr>
            <tr class="odd">
                <th align="right" style="height:30px;">
                    报销总额：
                </th>
                <td colspan="3">
                    &nbsp;<span id="i_span_sum"></span>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02" >
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
                var _data = { txtRiQi: $.trim($("#<%=txtRiQi.ClientID %>").val()),
                    txtBaoXiaoRen: $.trim($("#<%=txtBaoXiaoRen.SellsIDClient %>").val()),
                    txtXiaoFeiRiQi: [], txtXiaoFeiJinE: [], txtXiaoFeiType: [], txtXiaoFeiBeiZhu: []
                };

                $("input[name='txtXiaoFeiRiQi']").each(function() { _data.txtXiaoFeiRiQi.push($.trim($(this).val())); });
                $("input[name='txtXiaoFeiJinE']").each(function() { _data.txtXiaoFeiJinE.push($.trim($(this).val())); });
                $("select[name='txtXiaoFeiType']").each(function() { _data.txtXiaoFeiType.push($.trim($(this).val())); });
                $("textarea[name='txtXiaoFeiBeiZhu']").each(function() { _data.txtXiaoFeiBeiZhu.push($.trim($(this).val())); });

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return false;

                for (var i = 0; i < _data.txtXiaoFeiBeiZhu.length; i++) {
                    if (parseFloat(_data.txtXiaoFeiJinE[i]) == 0) {
                        $("textarea[name='txtXiaoFeiJinE']").eq(i).focus();
                        parent.tableToolbar._showMsg("请输入正确的消费金额");
                        return;
                    }
                    if (_data.txtXiaoFeiBeiZhu[i].length > 255) {
                        $("textarea[name='txtXiaoFeiBeiZhu']").eq(i).focus();
                        parent.tableToolbar._showMsg("消费备注最多255个字符"); return false;
                        break;
                    }
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
                            iPage.close();
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
            heJi: function() {
                var _sum = 0;
                $(".i_td_heji_field").each(function() { _sum = tableToolbar.calculate(_sum, $(this).val(), "+"); });
                $("#i_span_sum").html(_sum + "");
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $(".i_td_heji_field").bind("change", iPage.heJi);
            $("#i_table_autoadd").autoAdd({ addCallBack: iPage.heJi, delCallBack: iPage.heJi });
            iPage.heJi();
        });
    </script>

</asp:Content>
