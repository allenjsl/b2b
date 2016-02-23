<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YinHangHeDuiEdit.aspx.cs"
    Inherits="Web.Fin.YinHangHeDuiEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 700px; margin: 10px auto;" id="i_div_form">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="112" height="30" align="right">
                    业务日期：
                </th>
                <td colspan="5" bgcolor="#E3F1FC">
                    <input name="txtYeWuRiQi" type="text" class="formsize80 inputtext" id="txtYeWuRiQi"
                        runat="server" valid="required|isDate" errmsg="请填写业务日期|请填写正确的业务日期" />
                </td>
            </tr>
            <tr class="odd">
                <td height="30" colspan="6" bgcolor="#E3F1FC" class="pandl3">
                    请填写<span id="i_span_riqi_0"></span>银行余额及<span id="i_span_yewuriqi_0"></span>收支信息
                </td>
            </tr>
            <tr class="odd">
                <td colspan="6" align="left">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#ffffff">
                        <tr class="even">
                            <td width="55" align="center">
                                序号
                            </td>
                            <td height="30" align="center">
                                账户名称
                            </td>
                            <td align="center">
                                开户银行
                            </td>
                            <td align="center" class="pandl3">
                                银行账号
                            </td>
                            <td align="center">
                                账户余额<span id="i_span_riqi_1"></span>
                            </td>
                            <td align="center">
                                借方<span id="i_span_yewuriqi_1"></span>
                            </td>
                            <td align="center">
                                贷方<span id="i_span_yewuriqi_2"></span>
                            </td>
                        </tr>
                        <asp:Repeater runat="server" ID="rpts">
                        <ItemTemplate>
                        <tr class="odd">
                            <td align="center" bgcolor="#E3F1FC">
                                <%# Container.ItemIndex + 1%>
                                <input type="hidden" value="<%#Eval("ZhangHuId") %>" name="txtZhangHuId" />
                            </td>
                            <td height="30" align="center" bgcolor="#E3F1FC">
                                <%#Eval("ZhangHuName")%>
                            </td>
                            <td align="center" bgcolor="#E3F1FC">
                                <%#Eval("YinHangName")%>
                            </td>
                            <td align="center" bgcolor="#E3F1FC" class="pandl3">
                                <%#Eval("ZhangHao")%>
                            </td>
                            <td align="center" bgcolor="#E3F1FC">
                                <input name="txtYuE" type="text" class="formsize50 inputtext i_yue" valid="required|isNumber"
                                    errmsg="请填写银行余额|请填写正确的银行余额" value="<%#GetJinE(Eval("YuE")) %>" maxlength="12" />
                            </td>
                            <td align="center" bgcolor="#E3F1FC">
                                <input name="txtJieFangJinE" type="text" class="formsize50 inputtext i_jiefangjine"
                                    valid="required|isNumber" errmsg="请填写借方金额|请填写正确的借方总额" value="<%#GetJinE(Eval("JieFangJinE")) %>"
                                    maxlength="12" />
                            </td>
                            <td align="center" bgcolor="#E3F1FC">
                                <input name="txtDaiFangJinE" type="text" class="formsize50 inputtext i_daifangjine"
                                    valid="required|isNumber" errmsg="请填写贷方金额|请填写正确的贷方金额" value="<%#GetJinE(Eval("DaiFangJinE")) %>"
                                    maxlength="12" />
                            </td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                        <tr class="even">
                            <td align="center" colspan="4" style="text-align:right">
                                合计：
                            </td>
                            <td align="center">
                                <span id="i_span_yue_heji">0.00</span>
                            </td>
                            <td align="center">
                                <span id="i_span_jiefangjine_heji">0.00</span>
                            </td>
                            <td align="center">
                                <span id="i_span_daifangjine_heji">0.00</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="6" bgcolor="#E3F1FC" class="pandl3">
                    请填写<span id="i_span_yewuriqi_3"></span>流水总额
                </td>
            </tr>
            <tr class="odd">
                <th width="112" height="30" align="right">
                    流水总额：
                </th>
                <td colspan="5" bgcolor="#E3F1FC">
                    <input name="txtLiuShuiZongE" type="text" class="formsize50 inputtext" id="txtLiuShuiZongE"
                        runat="server" valid="required|isNumber" errmsg="请填写流水总额|请填写正确的流水总额" />
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" bgcolor="#E3F1FC">
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
            save: function(obj) {
                var _data = { txtYeWuRiQi: $.trim($("#<%=txtYeWuRiQi.ClientID %>").val()),
                    txtLiuShuiZongE: $.trim($("#<%=txtLiuShuiZongE.ClientID %>").val()),
                    txtZhangHuId: [], txtYuE: [], txtDaiFangJinE: [], txtJieFangJinE: []
                };

                var validatorResult = ValiDatorForm.validator($("#i_div_form").get(0), "parent");
                if (!validatorResult) return;

                $("input[name='txtZhangHuId']").each(function() { _data.txtZhangHuId.push($.trim($(this).val())); });
                $("input[name='txtYuE']").each(function() { _data.txtYuE.push($.trim($(this).val())); });
                $("input[name='txtDaiFangJinE']").each(function() { _data.txtDaiFangJinE.push($.trim($(this).val())); });
                $("input[name='txtJieFangJinE']").each(function() { _data.txtJieFangJinE.push($.trim($(this).val())); });

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
            toMoneyString: function(money) {
                var _s = money.toString();
                if (_s.length == 0) return "0.00";
                if (_s.indexOf(".") == -1) return _s + ".00";
                return _s;
            },
            setYuE: function() {
                var _sum = 0;
                $(".i_yue").each(function() { _sum = tableToolbar.calculate(_sum, $(this).val(), "+"); });
                $("#i_span_yue_heji").html(this.toMoneyString(_sum));
            },
            setJieFangJinE: function() {
                var _sum = 0;
                $(".i_jiefangjine").each(function() { _sum = tableToolbar.calculate(_sum, $(this).val(), "+"); });
                $("#i_span_jiefangjine_heji").html(this.toMoneyString(_sum));
            },
            setDaiFangJinE: function() {
                var _sum = 0;
                $(".i_daifangjine").each(function() { _sum = tableToolbar.calculate(_sum, $(this).val(), "+"); });
                $("#i_span_daifangjine_heji").html(this.toMoneyString(_sum));
            },
            setRiQi: function(_d) {
                var _riqi = $.trim($("#<%=txtYeWuRiQi.ClientID %>").val());
                if (_d) _riqi = _d;
                if (_riqi.length == 0) return;
                var _part = _riqi.split("-");
                if (_part.length != 3) return;

                var _date = new Date(_part[0], _part[1] - 1, _part[2]);
                _date.setDate(_part[2] - 1);

                _part[0] = _date.getFullYear();
                _part[1] = _date.getMonth() + 1;
                _part[2] = _date.getDate();

                var _s = [];
                _s.push(_part[0]);
                _s.push(_part[1] < 10 ? "0" + _part[1] : _part[1]);
                _s.push(_part[2] < 10 ? "0" + _part[2] : _part[2]);

                var _s1 = _s.join("-");

                $("#i_span_yewuriqi_0").html(_riqi + "日的");
                $("#i_span_yewuriqi_1").html("(" + _riqi + ")");
                $("#i_span_yewuriqi_2").html("(" + _riqi + ")");
                $("#i_span_yewuriqi_3").html(_riqi + "日的");

                $("#i_span_riqi_0").html(_s1 + "日的");
                $("#i_span_riqi_1").html("(" + _s1 + ")");
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); });
            $("#<%=txtYeWuRiQi.ClientID %>").bind("focus", function() { WdatePicker({ maxDate: '<%=DateTime.Now.ToString("yyyy-MM-dd") %>', onpicking: function(dp) { iPage.setRiQi(dp.cal.getNewDateStr()); } }); });
            $(".i_yue").bind("change", function() { iPage.setYuE(); });
            $(".i_jiefangjine").bind("change", function() { iPage.setJieFangJinE(); });
            $(".i_daifangjine").bind("change", function() { iPage.setDaiFangJinE(); });

            iPage.setYuE();
            iPage.setJieFangJinE();
            iPage.setDaiFangJinE();
            iPage.setRiQi();
        });
    </script>

</asp:Content>
