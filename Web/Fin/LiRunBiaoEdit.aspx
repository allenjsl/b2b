<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiRunBiaoEdit.aspx.cs"
    Inherits="Web.Fin.LiRunBiaoEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 850px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th style="width: 120px; text-align: right; height: 30px;">
                    年月：
                </th>
                <td colspan="3">
                    <select id="txtYear" name="txtYear" class="inputselect" valid="required"
                        errmsg="请选择年份">
                        <asp:Literal runat="server" ID="ltrYearOptions"></asp:Literal>
                    </select>
                    <select id="txtMonth" name="txtMonth" class="inputselect" valid="required"
                        errmsg="请选择月份">
                        <asp:Literal runat="server" ID="ltrMonthOptions"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    主营业务收入合计：
                </th>
                <td colspan="3">
                    <input type="text" id="txtZhuYingYeWuShouRu" runat="server" class="formsize100 inputtext i_txt_heji_field_4"
                        maxlength="11" valid="required|isNumber" errmsg="请填写主营业务收入|请填写正确的主营业务收入" readonly="readonly"
                        disabled="disabled" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    单订房应收款：
                </td>
                <td>
                    <input type="text" id="txtDanFangYingShouKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的单订房应收款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    单订票应收款：
                </td>
                <td>
                    <input type="text" id="txtDanDingPiaoYingShouKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的单订票应收款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    票务酒店应收款：
                </td>
                <td>
                    <input type="text" id="txtPiaoWuJiuDianYingShouKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的票务酒店应收款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    常规旅游应收款：
                </td>
                <td>
                    <input type="text" id="txtChangGuiLvYouYingShouKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的常规旅游应收款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    特殊旅游应收款：
                </td>
                <td>
                    <input type="text" id="txtTeShuLvYouYingShouKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的特殊旅游应收款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    退票收入：
                </td>
                <td>
                    <input type="text" id="txtTuiPiaoShouRu" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的退票收入" hejioperator="+" />
                </td>
            </tr>           
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    其它收入：
                </td>
                <td colspan="3">
                    <input type="text" id="txtQiTaZhuYingYeWuShouRu" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的其它收入" hejioperator="+" />
                </td>
            </tr> 
             <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtZhuYingYeWuShouRuBeiZhu" rows="3" class="formsize450 inputarea"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    主营业务成本合计：
                </th>
                <td colspan="3">
                    <input type="text" id="txtZhuYingYeWuZhiChu" runat="server" class="formsize100 inputtext i_txt_heji_field_4"
                        maxlength="11" valid="required|isNumber" errmsg="请填写主营业务成本|请填写正确的主营业务成本" readonly="readonly"
                        disabled="disabled" hejioperator="-" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    地接款：
                </td>
                <td>
                    <input type="text" id="txtDiJieKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的地接款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    机票款：
                </td>
                <td>
                    <input type="text" id="txtJiPiaoKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的机票款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    交通押金：
                </td>
                <td>
                    <input type="text" id="txtJiaoTongYaJin" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的交通押金" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    酒店款：
                </td>
                <td >
                    <input type="text" id="txtJiuDianKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的酒店款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    其它支出：
                </td>
                <td colspan="3">
                    <input type="text" id="txtQiTaZhuYingYeWuZhiChu" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的其它支出" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td  colspan="3">
                    <textarea id="txtZhuYingYeWuZhiChuBeiZhu" rows="3" class="formsize450 inputarea"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    团队结算毛利：
                </th>
                <td colspan="3">
                    <input type="text" id="txtTuanDuiJieSuanMaoLi" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的团队结算毛利" hejioperator="+"
                        readonly="readonly" disabled="disabled" />
                </td>
            </tr>            
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    营业费用：
                </th>
                <td colspan="3">
                    <input type="text" id="txtBaoXiaoFeiYong" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写营业费用|请填写正确的营业费用" hejioperator="-" />
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    营业外收入合计：
                </th>
                <td colspan="3">
                    <input type="text" id="txtYingYeWaiShouRu" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写营业外收入|请填写正确的营业外收入" hejioperator="+"
                        readonly="readonly" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    银行利息收入：
                </td>
                <td>
                    <input type="text" id="txtYingHangLiXiShouRu" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的银行利息收入" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    房租收入：
                </td>
                <td>
                    <input type="text" id="txtFangZuShouRu" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的房租收入" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    供应商返佣：
                </td>
                <td>
                    <input type="text" id="txtGongYingShangFanYong" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的供应商返佣" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    海口公司返佣：
                </td>
                <td>
                    <input type="text" id="txtHaiKouGongSiFanYong" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的海口公司返佣" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    其他营业外收入：
                </td>
                <td colspan="3">
                    <input type="text" id="txtQiTaYingYeWaiShouRu" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的其他营业外收入" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtYingYeWaiShouRuBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    营业外支出：
                </th>
                <td colspan="3">
                    <input type="text" id="txtYingYeWaiZhiChu" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写营业外支出|请填写正确的营业外支出" hejioperator="-" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtYingYeWaiZhiChuBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    其他损失：
                </th>
                <td colspan="3">
                    <input type="text" id="txtQiTaSunShi" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写其他损失|请填写正确的其他损失" hejioperator="-" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtQiTaSunShiBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    纯利润：
                </th>
                <td colspan="3">
                    <input type="text" id="txtChunLiRun" runat="server" class="formsize100 inputtext"
                        maxlength="11" readonly="readonly" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注：
                </td>
                <td  colspan="3">
                    <textarea id="txtBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phHistory">
            <tr>
                <td colspan="4">
                    <br />
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#ffffff"
                        id="i_table_autoadd">
                        <tr class="odd">
                            <td width="36" height="30" align="center">
                                编号
                            </td>
                            <td align="center">
                                修改日期
                            </td>
                            <td align="center">
                                修改项目
                            </td>
                            <td align="center">
                                修改备注
                            </td>
                            <td align="center">
                                操作
                            </td>
                        </tr>
                        <asp:Repeater runat="server" ID="rptHistorys">
                            <ItemTemplate>
                                <tr class="even tempRow">
                                    <td height="30" align="center" class="index">
                                        <%# Container.ItemIndex + 1%>
                                    </td>
                                    <td align="center">
                                        <input name="txtHTime" type="text" class="formsize80 inputtext" onfocus="WdatePicker()"
                                            value="<%#Eval("Time","{0:yyyy-MM-dd}") %>" />
                                    </td>
                                    <td align="center">
                                        <input name="txtHXiangMu" type="text" class="formsize180 inputtext" maxlength="50" value="<%#Eval("XiangMu") %>" />
                                    </td>
                                    <td align="center">
                                        <textarea name="txtHNeiRong" rows="3" class="formsize180 inputarea" style="width:250px;"><%#Eval("NeiRong")%></textarea>
                                    </td>
                                    <td align="center">
                                        <a href="javascript:void(0)" class="addbtn">
                                            <img src="/images/addimg.gif" width="48" height="20" /></a> <a href="javascript:void(0)"
                                                class="delbtn">
                                                <img src="/images/delimg.gif" width="48" height="20" /></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:PlaceHolder runat="server" ID="phEmptyHistory">
                            <tr class="even tempRow">
                                <td height="30" align="center" class="index">
                                    1
                                </td>
                                <td align="center">
                                    <input name="txtHTime" type="text" class="formsize80 inputtext" onfocus="WdatePicker()" />
                                </td>
                                <td align="center">
                                    <input name="txtHXiangMu" type="text" class="formsize180 inputtext" maxlength="50" />
                                </td>
                                <td align="center">
                                    <textarea name="txtHNeiRong" rows="3" class="formsize180 inputarea" style="width:250px;"></textarea>
                                </td>
                                <td align="center">
                                    <a href="javascript:void(0)" class="addbtn">
                                        <img src="/images/addimg.gif" width="48" height="20" /></a> <a href="javascript:void(0)"
                                            class="delbtn">
                                            <img src="/images/delimg.gif" width="48" height="20" /></a>
                                </td>
                            </tr>
                        </asp:PlaceHolder>
                    </table>                
                </td>            
            </tr>
            </asp:PlaceHolder>
        </table>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
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
                var _data = { txtYear: $.trim($("#txtYear").val())
                    , txtMonth: $.trim($("#txtMonth").val())
                    , txtTuanDuiJieSuanMaoLi: $.trim($("#<%=txtTuanDuiJieSuanMaoLi.ClientID %>").val())
                    , txtBaoXiaoFeiYong: $.trim($("#<%=txtBaoXiaoFeiYong.ClientID %>").val())
                    , txtYingYeWaiShouRu: $.trim($("#<%=txtYingYeWaiShouRu.ClientID %>").val())
                    , txtYingYeWaiZhiChu: $.trim($("#<%=txtYingYeWaiZhiChu.ClientID %>").val())
                    , txtChunLiRun: $.trim($("#<%=txtChunLiRun.ClientID %>").val())
                    , txtBeiZhu: $.trim($("#<%=txtBeiZhu.ClientID %>").val())
                    , txtZhuYingYeWuShouRu: $.trim($("#<%=txtZhuYingYeWuShouRu.ClientID %>").val())
                    , txtDanFangYingShouKuan: $.trim($("#<%=txtDanFangYingShouKuan.ClientID %>").val())
                    , txtDanDingPiaoYingShouKuan: $.trim($("#<%=txtDanDingPiaoYingShouKuan.ClientID %>").val())
                    , txtPiaoWuJiuDianYingShouKuan: $.trim($("#<%=txtPiaoWuJiuDianYingShouKuan.ClientID %>").val())
                    , txtChangGuiLvYouYingShouKuan: $.trim($("#<%=txtChangGuiLvYouYingShouKuan.ClientID %>").val())
                    , txtTeShuLvYouYingShouKuan: $.trim($("#<%=txtTeShuLvYouYingShouKuan.ClientID %>").val())
                    , txtTuiPiaoShouRu: $.trim($("#<%=txtTuiPiaoShouRu.ClientID %>").val())
                    , txtQiTaZhuYingYeWuShouRu: $.trim($("#<%=txtQiTaZhuYingYeWuShouRu.ClientID %>").val())
                    , txtZhuYingYeWuShouRuBeiZhu: $.trim($("#<%=txtZhuYingYeWuShouRuBeiZhu.ClientID %>").val())
                    , txtZhuYingYeWuZhiChu: $.trim($("#<%=txtZhuYingYeWuZhiChu.ClientID %>").val())
                    , txtDiJieKuan: $.trim($("#<%=txtDiJieKuan.ClientID %>").val())
                    , txtJiPiaoKuan: $.trim($("#<%=txtJiPiaoKuan.ClientID %>").val())
                    , txtJiaoTongYaJin: $.trim($("#<%=txtJiaoTongYaJin.ClientID %>").val())
                    , txtJiuDianKuan: $.trim($("#<%=txtJiuDianKuan.ClientID %>").val())
                    , txtQiTaZhuYingYeWuZhiChu: $.trim($("#<%=txtQiTaZhuYingYeWuZhiChu.ClientID %>").val())
                    , txtZhuYingYeWuZhiChuBeiZhu: $.trim($("#<%=txtZhuYingYeWuZhiChuBeiZhu.ClientID %>").val())
                    , txtYingHangLiXiShouRu: $.trim($("#<%=txtYingHangLiXiShouRu.ClientID %>").val())
                    , txtFangZuShouRu: $.trim($("#<%=txtFangZuShouRu.ClientID %>").val())
                    , txtGongYingShangFanYong: $.trim($("#<%=txtGongYingShangFanYong.ClientID %>").val())
                    , txtHaiKouGongSiFanYong: $.trim($("#<%=txtHaiKouGongSiFanYong.ClientID %>").val())
                    , txtQiTaYingYeWaiShouRu: $.trim($("#<%=txtQiTaYingYeWaiShouRu.ClientID %>").val())
                    , txtYingYeWaiShouRuBeiZhu: $.trim($("#<%=txtYingYeWaiShouRuBeiZhu.ClientID %>").val())
                    , txtYingYeWaiZhiChuBeiZhu: $.trim($("#<%=txtYingYeWaiZhiChuBeiZhu.ClientID %>").val())
                    , txtQiTaSunShi: $.trim($("#<%=txtQiTaSunShi.ClientID %>").val())
                    , txtQiTaSunShiBeiZhu: $.trim($("#<%=txtQiTaSunShiBeiZhu.ClientID %>").val())
                    , txtHTime: [], txtHXiangMu: [], txtHNeiRong: []
                };
                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return false;

                if (_data.txtBeiZhu.length > 255) { parent.tableToolbar._showMsg("备注内容不能超过255个字符。"); return; }
                if (_data.txtZhuYingYeWuShouRuBeiZhu.length > 255) { parent.tableToolbar._showMsg("主营业务收入备注内容不能超过255个字符。"); return; }
                if (_data.txtZhuYingYeWuZhiChuBeiZhu.length > 255) { parent.tableToolbar._showMsg("主营业务支出备注内容不能超过255个字符。"); return; }
                if (_data.txtYingYeWaiShouRuBeiZhu.length > 255) { parent.tableToolbar._showMsg("营业外收入备注内容不能超过255个字符。"); return; }
                if (_data.txtYingYeWaiZhiChuBeiZhu.length > 255) { parent.tableToolbar._showMsg("营业外支出备注内容不能超过255个字符。"); return; }
                if (_data.txtQiTaSunShiBeiZhu.length > 255) { parent.tableToolbar._showMsg("其他损失备注内容不能超过255个字符。"); return; }

                $("input[name='txtHTime']").each(function() { _data.txtHTime.push($.trim($(this).val())); });
                $("input[name='txtHXiangMu']").each(function() { _data.txtHXiangMu.push($.trim($(this).val())); });
                $("textarea[name='txtHNeiRong']").each(function() { _data.txtHNeiRong.push($.trim($(this).val())); });

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST", data: _data, cache: false, dataType: "json", async: false,
                    url: window.location.href + "&doType=save",
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
            heJi0: function(expr_0, expr_1) {
                var _sum = 0;
                $(expr_0).each(function() {
                    var _$obj = $(this);
                    var _operator = _$obj.attr("hejioperator");
                    _sum = tableToolbar.calculate(_sum, _$obj.val(), _operator);
                });
                $(expr_1).val(_sum + "");
            },
            heJi: function() {
                this.heJi0(".i_txt_heji_field", "#<%=txtChunLiRun.ClientID %>");
            },
            heJi1: function() {
                this.heJi0(".i_txt_heji_field_1", "#<%=txtZhuYingYeWuShouRu.ClientID %>");
                this.heJi4();
                this.heJi();
            },
            heJi2: function() {
                this.heJi0(".i_txt_heji_field_2", "#<%=txtZhuYingYeWuZhiChu.ClientID %>");
                this.heJi4();
                this.heJi();
            },
            heJi3: function() {
                this.heJi0(".i_txt_heji_field_3", "#<%=txtYingYeWaiShouRu.ClientID %>");
                this.heJi();
            },
            heJi4: function() {
                this.heJi0(".i_txt_heji_field_4", "#<%=txtTuanDuiJieSuanMaoLi.ClientID %>");
                this.heJi();
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $(".i_txt_heji_field").change(function() { iPage.heJi() });
            $(".i_txt_heji_field_1").change(function() { iPage.heJi1() });
            $(".i_txt_heji_field_2").change(function() { iPage.heJi2() });
            $(".i_txt_heji_field_3").change(function() { iPage.heJi3() });

            $("#i_table_autoadd").autoAdd({});
        });
    </script>

</asp:Content>
