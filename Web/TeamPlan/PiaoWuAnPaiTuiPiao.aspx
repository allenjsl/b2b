<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PiaoWuAnPaiTuiPiao.aspx.cs"
    Inherits="Web.TeamPlan.PiaoWuAnPaiTuiPiao" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody" runat="server">
    <div style="width: 950px; margin: 10px auto;">
        <span class="formtableT">已退票列表</span>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="36" height="30">
                    编号
                </th>
                <th width="106">
                    退票时间
                </th>
                <th width="67">
                    经手人
                </th>
                <th width="67">
                    退票人数
                </th>
                <th width="129">
                    客户单位
                </th>
                <th width="185">
                    损失明细
                </th>
                <th width="100">
                    损失金额
                </th>
                <th width="70">
                    应退金额
                </th>
                <th width="60">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="RptsYiTuiPiao">
            <ItemTemplate>
            <tr class="even" i_tuipiaoid="<%#Eval("TuiId") %>">
                <td height="30" align="center">
                    <%# Container.ItemIndex + 1%>
                </td>
                <td align="center">
                    <%#ToDateTimeString(Eval("TuiTime"))%>
                </td>
                <td align="center">
                    <%#Eval("OperatorName")%>
                </td>
                <td align="center">
                    <%#Eval("ShuLiang")%>
                </td>
                <td align="center">
                    <%#Eval("BuyCompanyName")%>
                </td>
                <td align="center">
                    <%#Eval("SunShiMX")%>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("SunShiAmount"))%>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("TuiAmount"))%>
                </td>
                <td align="center">
                    <%#YiTuiPiaoRptCaoZuoHtml %>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
            <tr>
                <td colspan="9" style="text-align: center; height: 30px;" class="even">
                    暂无退票信息
                </td>
            </tr>
            </asp:PlaceHolder>
        </table>
    </div>
    <div style="width: 950px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th height="22" colspan="4" align="left" class="pandl4">
                    请选择你需要退票的游客
                </th>
            </tr>
            
            <%=GetDingDanAndYouKeHtml()%>
            
            <tr class="odd">
                <th width="120" align="right">
                    退票时间：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtTuiTime" type="text" class="formsize80 inputtext" id="txtTuiTime"
                        runat="server" onfocus="WdatePicker()" valid="required|isDate" errmsg="请填写退票时间|请填写正确的退票时间" />
                </td>
                <th width="120" align="right">
                    损失明细：
                </th>
                <td style="background: #E3F1FC">
                    <textarea name="txtSunShiMX" rows="2" class="formsize450 inputarea" id="txtSunShiMX" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th width="120" align="right">
                    损失总价：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtSunShiJinE" type="text" class="formsize80 inputtext" id="txtSunShiJinE"
                        runat="server" maxlength="11" valid="required|isNumber" errmsg="请填写损失总价|请填写正确的损失总价" />
                </td>
                <th align="right">
                    承担方：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtChengDanFang" type="text" class="formsize80 inputtext" id="txtChengDanFang" runat="server"  maxlength="50"/>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    经手人：
                </th>
                <td style="background: #E3F1FC">
                    <asp:Literal runat="server" ID="ltrJingShouRen"></asp:Literal>
                </td>
                <th align="right">
                    应退金额：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtYingTuiJinE" type="text" class="formsize80 inputtext" id="txtYingTuiJinE"
                        runat="server" maxlength="8" valid="required|isNumber" errmsg="请填写应退金额|请填写正确的应退金额" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    备注：
                </th>
                <td colspan="3" style="background: #E3F1FC">
                    <textarea name="txtBeiZhu" rows="3" class="formsize450 inputtext" id="txtBeiZhu" runat="server"></textarea>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="even">
                <td height="30" colspan="14" align="left">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <form runat="server" id="form1"></form>
    
    <script type="text/javascript">
        var iPage = {
            _KongWeiId: "<%=KongWeiId %>",
            _AnPaiId: "<%=AnPaiId %>",
            _TuiPiaoId: "<%=TuiPiaoId %>",
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
            },
            toInt: function(s) {
                s = $.trim(s);
                var _v = parseInt(s);
                if (isNaN(_v)) return 0;
                return _v;
            },
            toFloat: function(s) {
                s = $.trim(s);
                var _v = parseFloat(s);
                if (isNaN(_v)) return 0;
                return _v;
            },
            //游客chk click
            youKeChkClick: function(obj) {
                var _$obj = $(obj);
                var _$objtr = _$obj.closest("tr");
                var _orders = [];
                $("input[name='chkYouKe']:enabled:checked").each(function() {
                    var _$tr = $(this).closest("tr");
                    var _orderid = _$tr.attr("i_orderid");

                    if ($.inArray(_orderid, _orders) == -1) _orders.push(_orderid);
                });

                if (_orders.length > 1) {
                    parent.tableToolbar._showMsg("退票只能选中一个订单下的游客进行操作");
                    _$obj.removeAttr("checked");
                    return false;
                }
            },
            //初始化安排信息
            initTui: function() {
                //此次安排的游客处理 未退票的chk设置可用
                for (var i = 0; i < anPaiYouKes.length; i++) {
                    var _$chk = $("#chkYouKe_" + anPaiYouKes[i].YouKeId);
                    var _chuPiaoStatus = _$chk.attr("i_chupiaostatus");
                    if (_chuPiaoStatus == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.已出票 %>") {
                        _$chk.removeAttr("disabled");
                        _$chk.bind("click", function() { iPage.youKeChkClick(this); })
                    } else if (_chuPiaoStatus == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.已退票 %>") {
                        _$chk.attr("checked", "checked");
                    }


                }
                //此次退票的游客处理 chk选中 设置可用
                for (var i = 0; i < tuiYouKes.length; i++) {
                    var _$chk = $("#chkYouKe_" + tuiYouKes[i].YouKeId);
                    _$chk.attr("checked", "checked");
                    if (_$chk.attr("i_chupiaostatus") == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.已退票 %>") {
                        _$chk.removeAttr("disabled");
                        _$chk.bind("click", function() { iPage.youKeChkClick(this); })
                    }
                }
            },
            //新增修改提交表单
            save: function(obj) {
                var _data = { txtTuiTime: $.trim($("#<%=txtTuiTime.ClientID %>").val()),
                    txtSunShiMX: $.trim($("#<%=txtSunShiMX.ClientID %>").val()),
                    txtSunShiJinE: $.trim($("#<%=txtSunShiJinE.ClientID %>").val()),
                    txtChengDanFang: $.trim($("#<%=txtChengDanFang.ClientID %>").val()),
                    txtYingTuiJinE: $.trim($("#<%=txtYingTuiJinE.ClientID %>").val()),
                    txtBeiZhu: $.trim($("#<%=txtBeiZhu.ClientID %>").val()),
                    txtYouKeId: [], txtOrderId: []
                };

                //选中的游客信息处理
                $("input[name='chkYouKe']:enabled:checked").each(function() {
                    var _$tr = $(this).closest("tr");
                    _data.txtYouKeId.push(_$tr.attr("i_youkeid"));
                    _data.txtOrderId.push(_$tr.attr("i_orderid"));
                });

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return;

                if (_data.txtYouKeId.length == 0) { parent.tableToolbar._showMsg("请选择你要退票的游客"); return false; }

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
            //已退票列表修改列操作
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { kongweiid: "<%=KongWeiId %>", anpaiid: "<%=AnPaiId %>", tuipiaoid: _$tr.attr("i_tuipiaoid"), iframeId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
                window.location.href = utilsUri.createUri("piaowuanpaituipiao.aspx", _data);
                return false;
            },
            //已退票列表删除列操作
            del: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtTuiPiaoId: _$tr.attr("i_tuipiaoid") };

                if (!confirm("退票信息删除后不可恢复，你确定要删除吗？")) return;
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
                            iPage.close();
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
            iPage.initTui();
            $("#i_a_save").bind("click", function() { iPage.save(this); });
            $(".i_update").bind("click", function() { return iPage.update(this); });
            $(".i_delete").bind("click", function() { iPage.del(this); return false; });
        })
    </script>
    
</asp:Content>
