<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiJiZhangEdit.aspx.cs"
    Inherits="Web.Fin.RiJiZhangEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/SupperControl.ascx" TagName="SupperControl" TagPrefix="uc1" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 700px; margin: 10px auto;" id="i_div_form">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="112" height="30" align="right">
                    登记日期：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtDengJiRiQi" type="text" class="formsize120 inputtext" id="txtDengJiRiQi"
                        disabled="disabled" onfocus="WdatePicker()" runat="server" />
                </td>
                <th align="right">
                    项目：
                </th>
                <td bgcolor="#E3F1FC">
                    <select name="txtXiangMu" id="txtXiangMu" class="inputselect" valid="required" errmsg="请选择项目">
                        <asp:Literal runat="server" ID="ltrXiangMuOptionHtml"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="112" height="30" align="right">
                    业务日期：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtYeWuRiQi" type="text" class="formsize80 inputtext" id="txtYeWuRiQi"
                        valid="required" errmsg="请填写业务日期" maxlength="50" onfocus="WdatePicker()" runat="server" />
                </td>
                <th width="110" align="right">
                    凭证编号：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtPingZhengHao" type="text" class="formsize120 inputtext" id="txtPingZhengHao" maxlength="50" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    银行账号：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <select name="txtZhangHuId" id="txtZhangHuId" class="inputselect" valid="required"
                        errmsg="请选择银行账号">
                        <asp:Literal runat="server" ID="ltrZhangHuOptionHtml"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    单位类型：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <select name="txtKeHuType" id="txtKeHuType" class="inputselect">
                        <asp:Literal runat="server" ID="ltrKeHuTypeHtml"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    往来单位：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <div id="div_kehu_xuanyong">
                        <uc1:KeHuXuanZe runat="server" id="txtKeHu" isrequired="false" />
                    </div>
                    <div id="div_gys_xuanyong">
                        <uc1:suppercontrol runat="server" id="txtGys" alltype="1" suppliertype="地接" />
                    </div>
                    <div id="div_yuangong_xuanyong">
                        <uc1:SellsSelect runat="server" ID="txtYuanGong" ReadOnly="true" IsShowSelect="true"
                            SetTitle="员工" IsNotValid="false" />
                    </div>
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    明细：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <textarea name="txtMingXi" rows="3" class="formsize260 inputarea" id="txtMingXi" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    借方：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtJieFangJinE" type="text" class="formsize80 inputtext" id="txtJieFangJinE"
                        valid="isNumber" errmsg="请填写正确借方余额" maxlength="11" runat="server" />
                </td>
                <th align="right">
                    贷方：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtDaiFangJinE" type="text" class="formsize80 inputtext" id="txtDaiFangJinE"
                        valid="isNumber" errmsg="请填写正确贷方余额" maxlength="11" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    余额：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <input type="hidden" id="txtYuE1" name="txtYuE1" runat="server" />
                    <input name="txtYuE" type="text" class="formsize80 inputtext" id="txtYuE" disabled="disabled" runat="server" />
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
            toMoneyString: function(money) {
                var _s = money.toString();
                if (_s.length == 0) return "0.00";
                if (_s.indexOf(".") == -1) return _s + ".00";
                return _s;
            },
            setYuE: function() {
                var _jieFangJinE = $.trim($("#<%=txtJieFangJinE.ClientID %>").val());
                var _daiFangJinE = $.trim($("#<%=txtDaiFangJinE.ClientID %>").val());
                var _yuE1 = $.trim($("#<%=txtYuE1.ClientID %>").val());

                var _yuE = tableToolbar.calculate(_yuE1, _jieFangJinE, "+");
                _yuE = tableToolbar.calculate(_yuE, _daiFangJinE, "-");

                $("#<%=txtYuE.ClientID %>").val(_yuE);
            },
            yanZhengJinE: function(obj) {
                var _jieFangJinE = $.trim($("#<%=txtJieFangJinE.ClientID %>").val());
                var _daiFangJinE = $.trim($("#<%=txtDaiFangJinE.ClientID %>").val());
                if (_jieFangJinE.length > 0 && _daiFangJinE.length > 0) {
                    var _jinE1 = parseFloat(_jieFangJinE);
                    var _jinE2 = parseFloat(_daiFangJinE);

                    if (_jinE1 != 0 && _jinE1 == _jinE2) { parent.tableToolbar._showMsg("借方和贷方只能填写一个"); return false; }
                    if (_jinE1 == 0 && _jinE2 == 0) { parent.tableToolbar._showMsg("借方和贷方至少要填写一个"); return false; }
                }

                if (_jieFangJinE.length == 0 && _daiFangJinE.length == 0) { parent.tableToolbar._showMsg("借方和贷方至少要填写一个"); return false; }

                return true;
            },
            save: function(obj) {
                var _data = { txtXiangMu: $.trim($("#txtXiangMu").val()),
                    txtXiangMu: $.trim($("#txtXiangMu").val()),
                    txtYeWuRiQi: $.trim($("#<%=txtYeWuRiQi.ClientID %>").val()),
                    txtPingZhengHao: $.trim($("#<%=txtPingZhengHao.ClientID %>").val()),
                    txtZhangHuId: $.trim($("#txtZhangHuId").val()),
                    txtMingXi: $.trim($("#<%=txtMingXi.ClientID %>").val()),
                    txtJieFangJinE: $.trim($("#<%=txtJieFangJinE.ClientID %>").val()),
                    txtDaiFangJinE: $.trim($("#<%=txtDaiFangJinE.ClientID %>").val()),
                    txtWangLaiDanWeiName: '',
                    txtWangLaiDanWeiId: '',
                    txtWangLaiDanWeiLeiXing: $("#txtKeHuType").val()
                };

                if (_data.txtWangLaiDanWeiLeiXing == "0") {
                    _data.txtWangLaiDanWeiId = $.trim($("#<%=txtKeHu.KeHuIdClientId %>").val());
                    _data.txtWangLaiDanWeiName = $("#<%=txtKeHu.KeHuMingChengClientId %>").val();
                } else if (_data.txtWangLaiDanWeiLeiXing == "1") {
                    _data.txtWangLaiDanWeiId = $.trim($("#<%=txtGys.ClientValue %>").val());
                    _data.txtWangLaiDanWeiName = $("#<%=txtGys.ClientText %>").val();
                } else if (_data.txtWangLaiDanWeiLeiXing == "2") {
                    _data.txtWangLaiDanWeiId = $.trim($("#<%=txtYuanGong.SellsIDClient %>").val());
                    _data.txtWangLaiDanWeiName = $("#<%=txtYuanGong.SellsNameClient %>").val();
                }

                if (_data.txtWangLaiDanWeiId.length == 0) { parent.tableToolbar._showMsg("请选择往来单位"); return; }

                var validatorResult = ValiDatorForm.validator($("#i_div_form").get(0), "parent") && iPage.yanZhengJinE(null);
                if (!validatorResult) return;

                if (_data.txtMingXi.length > 255) { parent.tableToolbar._showMsg("明细最多可输入255个字符"); return false; }

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
            setKeHuXuanYong: function() {
                var _v = $("#txtKeHuType").val();
                if (_v == "0") {
                    $("#div_kehu_xuanyong").show();
                    $("#div_gys_xuanyong").hide();
                    $("#div_yuangong_xuanyong").hide();
                } else if (_v == "1") {
                    $("#div_kehu_xuanyong").hide();
                    $("#div_gys_xuanyong").show();
                    $("#div_yuangong_xuanyong").hide();
                } else {
                    $("#div_kehu_xuanyong").hide();
                    $("#div_gys_xuanyong").hide();
                    $("#div_yuangong_xuanyong").show();
                }
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); });
            $("#<%=txtJieFangJinE.ClientID %>").bind("change", function() { iPage.setYuE(); });
            $("#<%=txtDaiFangJinE.ClientID %>").bind("change", function() { iPage.setYuE(); });
            $("#txtKeHuType").bind("change", function() { iPage.setKeHuXuanYong(); });
            iPage.setKeHuXuanYong();
        });
    </script>

</asp:Content>
