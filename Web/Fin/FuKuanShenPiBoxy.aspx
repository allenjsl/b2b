<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FuKuanShenPiBoxy.aspx.cs"
    Inherits="Web.Fin.FuKuanShenPiBoxy" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 630px; margin: 10px auto;" id="i_div_form">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <asp:PlaceHolder runat="server" ID="phShenPiBankDate" Visible="false">
            <tr class="odd">
                <th width="150" align="right">
                    银行实际业务日期：
                </th>
                <td width="477" bgcolor="#E3F1FC">
                    <input name="txtShenPiBankDate" type="text" class="formsize80 inputtext" 
                        id="txtShenPiBankDate" runat="server" valid="required|isDate" errmsg="请填写银行实际业务日期|请填写正确的银行实际业务日期" />
                </td>
            </tr>
            </asp:PlaceHolder>  
            
            <asp:PlaceHolder runat="server" ID="phShenPi">
            <tr class="odd">
                <th align="right">
                    审&nbsp;核&nbsp;人：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtShenPiRenName" type="text" class="formsize140 inputtext" disabled="disabled"
                        id="txtShenPiRenName" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    审核时间：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtShenPiTime" type="text" class="formsize140 inputtext" disabled="disabled"
                        id="txtShenPiTime" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th width="150" align="right">
                    审核备注：
                </th>
                <td bgcolor="#E3F1FC">
                    <textarea name="txtShenPiBeiZhu" rows="3" class="formsize450 inputarea" id="txtShenPiBeiZhu"
                        runat="server"></textarea>
                </td>
            </tr>
            </asp:PlaceHolder>
        </table>
        
        <asp:PlaceHolder runat="server" ID="phZhiFu" Visible="false">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top:5px;">
            <tr class="odd">
                <th width="150" align="right">
                    银行实际业务日期：
                </th>
                <td width="477" bgcolor="#E3F1FC">
                    <input name="txtZhiFuBankDate" type="text" class="formsize80 inputtext"
                        id="txtZhiFuBankDate" runat="server" valid="required|isDate" errmsg="请填写银行实际业务日期|请填写正确的银行实际业务日期" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    支&nbsp;付&nbsp;人
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtZhiFuRenName" type="text" class="formsize140 inputtext" disabled="disabled"
                        id="txtZhiFuRenName" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    支付时间：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtZhiFuTime" type="text" class="formsize140 inputtext" disabled="disabled"
                        id="txtZhiFuTime" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th width="150" align="right">
                    支付备注：
                </th>
                <td bgcolor="#E3F1FC">
                    <textarea name="txtZhiFuBeiZhu" rows="3" class="formsize450 inputarea" id="txtZhiFuBeiZhu"
                        runat="server"></textarea>
                </td>
            </tr>
        </table>
        </asp:PlaceHolder>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" align="left" bgcolor="#E3F1FC">
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
            //关闭窗口
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            //审批
            shenPi: function(obj) {
                if (!confirm("审批操作不可逆，你确定要审批吗？")) return;
                var _data = { txtBankDate: $.trim($("#<%=txtShenPiBankDate.ClientID %>").val()),
                    txtBeiZhu: $.trim($("#<%=txtShenPiBeiZhu.ClientID%>").val())
                };

                var validatorResult = ValiDatorForm.validator($("#i_div_form").get(0), "parent");
                if (!validatorResult) return;

                if (_data.txtBeiZhu.length > 255) {
                    parent.tableToolbar._showMsg("审批备注内容最多可输入255个字符");
                    return;
                }


                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=shenpi",
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
                if (!confirm("支付操作不可逆，你确定要支付吗？")) return;
                var _data = { txtBankDate: $.trim($("#<%=txtZhiFuBankDate.ClientID %>").val()),
                    txtBeiZhu: $.trim($("#<%=txtZhiFuBeiZhu.ClientID%>").val())
                };

                var validatorResult = ValiDatorForm.validator($("#i_div_form").get(0), "parent");
                if (!validatorResult) return;

                if (_data.txtBeiZhu.length > 255) {
                    parent.tableToolbar._showMsg("支付备注内容最多可输入255个字符");
                    return;
                }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=zhifu",
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
                            $(obj).bind("click", function() { iPage.zhiFu(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.zhiFu(obj); }).css({ "color": "" });
                    }
                });
            },
            //批量审批
            shenPiPiLiang: function(obj) {
                if (!confirm("批量审批操作不可逆，你确定要审批吗？")) return;
                var _p = parent;
                var _data = _p.iPage.getChks("<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批 %>");

                //var validatorResult = ValiDatorForm.validator($("#i_div_form").get(0), "parent");
                //if (!validatorResult) return;                
                _data["BeiZhu"] = $.trim($("#<%=txtShenPiBeiZhu.ClientID %>").val());

                if (_data["BeiZhu"].length > 255) {
                    parent.tableToolbar._showMsg("审批备注内容最多可输入255个字符");
                    return;
                }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=shenpipiliang",
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
                            $(obj).bind("click", function() { iPage.shenPiPiLiang(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.shenPiPiLiang(obj); }).css({ "color": "" });
                    }
                });
            },
            //批量支付
            zhiFuPiLiang: function(obj) {
                if (!confirm("批量支付操作不可逆，你确定要支付吗？")) return;
                var _p = parent;
                var _data = _p.iPage.getChks("<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未支付 %>");

                var validatorResult = ValiDatorForm.validator($("#i_div_form").get(0), "parent");
                if (!validatorResult) return;

                _data["BankDate"] = $.trim($("#<%=txtZhiFuBankDate.ClientID %>").val());
                _data["BeiZhu"] = $.trim($("#<%=txtZhiFuBeiZhu.ClientID %>").val());


                if (_data["BeiZhu"].length > 255) {
                    parent.tableToolbar._showMsg("支付备注内容最多可输入255个字符");
                    return;
                }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=zhifupiliang",
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
                            $(obj).bind("click", function() { iPage.zhiFuPiLiang(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.zhiFuPiLiang(obj); }).css({ "color": "" });
                    }
                });
            },
            //取消审批
            quXiaoShenPi: function(obj) {
                if (!confirm("取消审批操作不可逆，你确定要取消审批吗？")) return;
                var _data = {};

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=quxiaoshenpi",
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
                            $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                    }
                });
            },
            //取消支付
            quXiaoZhiFu: function(obj) {
                if (!confirm("取消支付操作不可逆，你确定要取消支付吗？")) return;
                var _data = {};

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=quxiaozhifu",
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
                            $(obj).bind("click", function() { iPage.zhiFu(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.zhiFu(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_shenpi").bind("click", function() { iPage.shenPi(this); });
            $("#i_a_zhifu").bind("click", function() { iPage.zhiFu(this); });
            $("#i_a_shenpi_piliang").bind("click", function() { iPage.shenPiPiLiang(this); });
            $("#i_a_zhifu_piliang").bind("click", function() { iPage.zhiFuPiLiang(this); });

            $("#<%=txtShenPiBankDate.ClientID %>").bind("focus", function() { WdatePicker({ maxDate: '<%=DateTime.Now.ToString("yyyy-MM-dd") %>' }); });
            $("#<%=txtZhiFuBankDate.ClientID %>").bind("focus", function() { WdatePicker({ maxDate: '<%=DateTime.Now.ToString("yyyy-MM-dd") %>' }); });

            $("#i_a_quxiaoshenpi").bind("click", function() { iPage.quXiaoShenPi(this); });
            $("#i_a_quxiaozhifu").bind("click", function() { iPage.quXiaoZhiFu(this); });
        });
    </script>

</asp:Content>
