<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JieKuanShenPiBoxy.aspx.cs"
    Inherits="Web.Fin.JieKuanShenPiBoxy" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 630px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="120" height="30" align="right" style="width:120px;">
                    审批人：
                </th>
                <td >
                    <input name="txtShenPiRenName" type="text" class="formsize80 inputtext" id="txtShenPiRenName"
                        runat="server" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd">
                <th width="118" height="30" align="right">
                    审批时间：
                </th>
                <td >
                    <input name="txtShenPiTime" type="text" class="formsize80 inputtext" id="txtShenPiTime"
                        runat="server" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    审批备注：
                </th>
                <td >
                    <textarea name="txtShenPiBeiZhu" rows="3" class="formsize450 inputarea" id="txtShenPiBeiZhu" runat="server"></textarea>
                </td>
            </tr>
        </table>
        <asp:PlaceHolder runat="server" ID="phZhiFu">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top:10px;" id="i_table_zhifu">
            <tr class="odd">
                <th height="30" align="right" style="width:120px;">
                    支付人：
                </th>
                <td >
                    <input name="txtZhiFuRenName" type="text" class="formsize80 inputtext" id="txtZhiFuRenName"
                        runat="server" disabled="disabled" />
                </td>
                <th align="right">
                    支付时间：
                </th>
                <td >
                    <input name="txtZhiFuTime" type="text" class="formsize80 inputtext" id="txtZhiFuTime"
                        runat="server" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    支付账号：
                </th>
                <td colspan="3" >
                    <asp:Literal runat="server" ID="ltrZhiFuZhangHu"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    支付备注：
                </th>
                <td colspan="3" >
                    <textarea name="txtZhiFuBeiZhu" rows="3" class="formsize450 inputarea" id="txtZhiFuBeiZhu" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    银行实际业务日期：
                </th>
                <td colspan="3" >
                    <input name="txtZhiFuBankDate" type="text" class="formsize80 inputtext" id="txtZhiFuBankDate"
                        runat="server" />
                </td>
            </tr>   
        </table>
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="phGuiHuan">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top: 10px;"
            id="i_table_guihuan">
            <tr class="odd">
                <th width="120" height="30" align="right">
                    归还时间：
                </th>
                <td >
                    <input name="txtGuiHuanTime" type="text" class="formsize80 inputtext" id="txtGuiHuanTime"
                        runat="server" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    归还金额：
                </th>
                <td >
                    <input name="txtGuiHuanJinE" type="text" class="formsize80 inputtext" id="txtGuiHuanJinE"
                        runat="server" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    归还账号：
                </th>
                <td >
                    <asp:Literal runat="server" ID="ltrGuiHuanZhangHu"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    归还备注：
                </th>
                <td >
                    <textarea name="txtGuiHuanBeiZhu" rows="3" class="formsize450 inputarea" id="txtGuiHuanBeiZhu"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    银行实际业务日期：
                </th>
                <td >
                    <input name="txtGuiHuanBankDate" type="text" class="formsize80 inputtext " id="txtGuiHuanBankDate"
                        runat="server" />
                </td>
            </tr>
        </table>
        </asp:PlaceHolder>
                
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" >
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="180" height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
        <script type="text/javascript">
            var iPage = {
                //关闭窗口
                close: function() {
                    var _win = top || window;
                    _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                    return false;
                },
                //审批
                shenPi: function(obj) {
                    var _$obj = $(obj);
                    var _i_status = _$obj.attr("i_status");
                    var _data = { txtStatus: _i_status,
                        txtBeiZhu: $.trim($("#<%=txtShenPiBeiZhu.ClientID %>").val())
                    };
                    if (_data.txtBeiZhu.length > 255) { parent.tableToolbar._showMsg("审批备注内容最多可输入255个字符"); $("#<%=txtShenPiBeiZhu.ClientID %>").focus(); return false; }
                    var _confirmmsg = "审批操作不可逆，你确定要审批该借款信息吗？";
                    if (_i_status == "0") _confirmmsg = "审批操作不可逆，你确定要不通过该借款信息吗？";
                    if (!confirm(_confirmmsg)) return false;

                    _$obj.unbind("click").css({ "color": "#999999" });

                    $.newAjax({
                        type: "POST", data: _data, cache: false, dataType: "json", async: false,
                        url: window.location.href + "&doType=shenpi",
                        success: function(response) {
                            if (response.result == "1") {
                                alert(response.msg);
                                iPage.close();
                            } else {
                                alert(response.msg);
                                $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                            }
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                        }
                    });
                },
                //支付
                zhiFu: function(obj) {
                    var _data = { txtBeiZhu: $.trim($("#<%=txtZhiFuBeiZhu.ClientID %>").val()),
                        txtZhangHu: $.trim($("#txtZhiFuZhangHu").val()),
                        txtBankDate: $.trim($("#<%=txtZhiFuBankDate.ClientID %>").val())
                    };
                    if (_data.txtBankDate.length == 0) { parent.tableToolbar._showMsg("请输入支付银行实际业务日期"); return; }
                    if (_data.txtZhangHu.length == 0) { $("#txtZhiFuZhangHu").focus(); parent.tableToolbar._showMsg("请选择支付账号"); return false; }
                    if (_data.txtBeiZhu.length > 255) { $("#<%=txtZhiFuBeiZhu.ClientID %>").focus(); parent.tableToolbar._showMsg("支付备注内容最多可输入255个字符"); return false; }

                    var _confirmmsg = "支付操作不可逆，你确定要支付该借款信息吗？";
                    if (!confirm(_confirmmsg)) return false;

                    $(obj).unbind("click").css({ "color": "#999999" });

                    $.newAjax({
                        type: "POST", data: _data, cache: false, dataType: "json", async: false,
                        url: window.location.href + "&doType=zhifu",
                        success: function(response) {
                            if (response.result == "1") {
                                alert(response.msg);
                                iPage.close();
                            } else {
                                alert(response.msg);
                                $(obj).bind("click", function() { iPage.zhiFu(obj); }).css({ "color": "" });
                            }
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.zhiFu(obj); }).css({ "color": "" });
                        }
                    });
                },
                //归还
                guiHuan: function(obj) {
                    var _data = { txtBeiZhu: $.trim($("#<%=txtGuiHuanBeiZhu.ClientID %>").val()),
                        txtZhangHu: $.trim($("#txtGuiHuanZhangHu").val()),
                        txtBankDate: $.trim($("#<%=txtGuiHuanBankDate.ClientID %>").val())
                    };
                    if (_data.txtBankDate.length == 0) { parent.tableToolbar._showMsg("请输入归还银行实际业务日期"); return false; }
                    if (_data.txtZhangHu.length == 0) { $("#txtGuiHuanZhangHu").focus(); parent.tableToolbar._showMsg("请选择归还账号"); return false; }
                    if (_data.txtBeiZhu.length > 255) { $("#<%=txtGuiHuanBeiZhu.ClientID %>").focus(); parent.tableToolbar._showMsg("归还备注内容最多可输入255个字符"); return false; }

                    var _confirmmsg = "归还操作不可逆，你确定要归还该借款信息吗？";
                    if (!confirm(_confirmmsg)) return false;

                    $(obj).unbind("click").css({ "color": "#999999" });

                    $.newAjax({
                        type: "POST", data: _data, cache: false, dataType: "json", async: false,
                        url: window.location.href + "&doType=guihuan",
                        success: function(response) {
                            if (response.result == "1") {
                                alert(response.msg);
                                iPage.close();
                            } else {
                                alert(response.msg);
                                $(obj).bind("click", function() { iPage.guiHuan(obj); }).css({ "color": "" });
                            }
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.guiHuan(obj); }).css({ "color": "" });
                        }
                    });
                },
                quXiaoGuiHuan: function(obj) {
                    var _data = {};
                    var _confirmmsg = "取消归还操作不可逆，你确定要取消归还该借款信息吗？";
                    if (!confirm(_confirmmsg)) return false;

                    $(obj).unbind("click").css({ "color": "#999999" });

                    $.newAjax({
                        type: "POST", data: _data, cache: false, dataType: "json", async: false,
                        url: window.location.href + "&doType=quxiaoguihuan",
                        success: function(response) {
                            if (response.result == "1") {
                                alert(response.msg);
                                iPage.close();
                            } else {
                                alert(response.msg);
                                $(obj).bind("click", function() { iPage.quXiaoGuiHuan(obj); }).css({ "color": "" });
                            }
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.quXiaoGuiHuan(obj); }).css({ "color": "" });
                        }
                    });
                },
                quXiaoZhiFu: function(obj) {
                    var _data = {};
                    var _confirmmsg = "取消支付操作不可逆，你确定要取消支付该借款信息吗？";
                    if (!confirm(_confirmmsg)) return false;

                    $(obj).unbind("click").css({ "color": "#999999" });

                    $.newAjax({
                        type: "POST", data: _data, cache: false, dataType: "json", async: false,
                        url: window.location.href + "&doType=quxiaozhifu",
                        success: function(response) {
                            if (response.result == "1") {
                                alert(response.msg);
                                iPage.close();
                            } else {
                                alert(response.msg);
                                $(obj).bind("click", function() { iPage.quXiaoZhiFu(obj); }).css({ "color": "" });
                            }
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.quXiaoZhiFu(obj); }).css({ "color": "" });
                        }
                    });
                },
                quXiaoShenPi: function(obj) {
                    var _data = {};
                    var _confirmmsg = "取消审批操作不可逆，你确定要取消审批该借款信息吗？";
                    if (!confirm(_confirmmsg)) return false;

                    $(obj).unbind("click").css({ "color": "#999999" });

                    $.newAjax({
                        type: "POST", data: _data, cache: false, dataType: "json", async: false,
                        url: window.location.href + "&doType=quxiaoshenpi",
                        success: function(response) {
                            if (response.result == "1") {
                                alert(response.msg);
                                iPage.close();
                            } else {
                                alert(response.msg);
                                $(obj).bind("click", function() { iPage.quXiaoShenPi(obj); }).css({ "color": "" });
                            }
                        },
                        error: function() {
                            $(obj).bind("click", function() { iPage.quXiaoShenPi(obj); }).css({ "color": "" });
                        }
                    });
                }
            };

            $(document).ready(function() {
                $(".i_shenpi").bind("click", function() { return iPage.shenPi(this); });
                $("#i_zhifu").bind("click", function() { return iPage.zhiFu(this); });
                $("#i_guihuan").bind("click", function() { return iPage.guiHuan(this); });
                $("#i_quxiaoguihuan").bind("click", function() { return iPage.quXiaoGuiHuan(this); });
                $("#i_quxiaozhifu").bind("click", function() { return iPage.quXiaoZhiFu(this); });
                $("#i_quxiaoshenpi").bind("click", function() { return iPage.quXiaoShenPi(this); });
                $("#<%=txtZhiFuBankDate.ClientID %>").bind("focus", function() { WdatePicker({ maxDate: '<%=DateTime.Now.ToString("yyyy-MM-dd") %>' }); });
                $("#<%=txtGuiHuanBankDate.ClientID %>").bind("focus", function() { WdatePicker({ maxDate: '<%=DateTime.Now.ToString("yyyy-MM-dd") %>' }); });
            });
        </script>
</asp:Content>
