<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuanGongEdit.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.YuanGongEdit" MasterPageFile="~/MP/HuiYuanBoxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageMain" ID="PageMain1">
    <form runat="server" id="form1">
    <table cellspacing="0" cellpadding="0" border="0" class="tablelist" style="width:99%;margin:0px auto; margin-top:5px;">
        <tr>
            <td style="width: 100px; text-align: right;">
                登账账号：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtYongHuMing" runat="server"
                    maxlength="50" />
                <span style="color: #666">说明：如果不需要分配账号可不填写。</span>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                登录密码：
            </td>
            <td>
                <input type="password" class="input1" style="width: 250px;" id="txtMiMa" runat="server" maxlength="50" />
                <span
                    style="color: #666">说明：如不需要修改密码，登录密码、确认密码不填写即可。</span>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                确认密码：
            </td>
            <td>
                <input type="password" class="input1" style="width: 250px;" id="txtQuRenMiMa" runat="server"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                <span class="fred">*</span>员工姓名：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtXingMing" runat="server"
                    maxlength="10" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                <span class="fred">*</span>性别：
            </td>
            <td>
                <input type="radio" name="txtXingBie" id="txtXingBie2" value="2" /><label for="txtXingBie2">&nbsp;男</label>&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="radio" name="txtXingBie" id="txtXingBie1" value="1" />&nbsp;<label for="txtXingBie1">&nbsp;女</label>&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="radio" name="txtXingBie" id="txtXingBie0" value="0" />&nbsp;<label for="txtXingBie0">&nbsp;保密</label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>手机号码：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtShouJi" runat="server"
                    maxlength="20" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>电话号码：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtDianHua" runat="server"
                    maxlength="20" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>传真号码：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtFax" runat="server"
                    maxlength="20" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>电子信箱：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtYouXiang" runat="server"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                QQ号码：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtQQ" runat="server"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                微信号：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtWeiXinHao" runat="server"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                部门（门市部）：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtBuMenName" runat="server"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                职务：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtZhiWu" runat="server"
                    maxlength="50" />
            </td>
        </tr>        
     </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" style="width:99%;margin: 0px auto;
        margin-top: 15px; margin-bottom: 15px;">
        <tr>
            <td style="text-align:center;">
                <a href="javascript:void(0)" id="i_a_submit" class="baocun">提 交</a>
            </td>
        </tr>
    </table>
    </form>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

    <script type="text/javascript">
        var iPage = {
            close: function() {
                top.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
            },
            webForm_OnSubmit_Validate: function() {
                var _v = true;

                if ("<%=KeHuLxrStatus %>" == "UNLOCK") {
                    if ($.trim($("#<%=txtXingMing.ClientID%>").val()).length == 0) { alert("请输入员工姓名"); return false; }
                    if ($.trim($("#<%=txtShouJi.ClientID%>").val()).length == 0) { alert("请输入手机号码"); return false; }
                    if ($.trim($("#<%=txtDianHua.ClientID%>").val()).length == 0) { alert("请输入电话号码"); return false; }
                    if ($.trim($("#<%=txtFax.ClientID%>").val()).length == 0) { alert("请输入传真号码"); return false; }
                    if ($.trim($("#<%=txtYouXiang.ClientID%>").val()).length == 0) { alert("请输入电子信箱"); return false; }

                    if (!RegExps.isMobile.test($.trim($("#<%=txtShouJi.ClientID%>").val()))) { alert("请输入正确的手机号码"); return false; }
                    if (!RegExps.isPhone.test($.trim($("#<%=txtDianHua.ClientID%>").val()))) { alert("请输入正确的电话号码"); return false; }
                    if (!RegExps.isPhone.test($.trim($("#<%=txtFax.ClientID%>").val()))) { alert("请输入正确的传真号码"); return false; }
                    if (!RegExps.isEmail.test($.trim($("#<%=txtYouXiang.ClientID%>").val()))) { alert("请输入正确的电子信箱"); return false; }
                }

                var _miMa = $.trim($("#<%=txtMiMa.ClientID %>").val());
                var _queRenMiMa = $.trim($("#<%=txtQuRenMiMa.ClientID %>").val());

                if (_miMa.length > 0) {
                    if (_queRenMiMa.length == 0) { alert("请输入确认密码"); return false; }
                    if (_miMa != _queRenMiMa) { alert("两次输入的密码不一致"); return false; }
                }

                if ("<%=YongHuCZFS %>" == "C") {
                    if ($.trim($("#<%=txtYongHuMing.ClientID%>").val()).length > 0) {
                        if (_miMa.length == 0) { alert("请输入登录密码"); return false; }
                    }
                }

                return _v;
            },
            submit: function(obj) {
                if (!this.webForm_OnSubmit_Validate()) return false;
                $(obj).unbind("click").text("正在处理");

                var _data = $("#<%=form1.ClientID %>").serialize();
                var _self = this;
                $.ajax({ type: "post", url: window.location.href + "&dotype=submit", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        $(obj).click(function() { return _self.submit(this); }).text("提交");
                        if (response.result == "1") _self.close();
                    }
                });
            },
            initYeMianZhuangTai: function() {
                if ("<%=YongHuCZFS %>" == "U") {
                    $("#<%=txtYongHuMing.ClientID %>").addClass("input_readonly").attr("readonly", "readonly");
                }

                if ("<%=KeHuLxrStatus %>" == "LOCK") {
                    $("#<%=txtXingMing.ClientID %>").addClass("input_readonly").attr("readonly", "readonly");
                    $("#<%=txtShouJi.ClientID %>").addClass("input_readonly").attr("readonly", "readonly");
                    $("#<%=txtDianHua.ClientID %>").addClass("input_readonly").attr("readonly", "readonly");
                    $("#<%=txtFax.ClientID %>").addClass("input_readonly").attr("readonly", "readonly");
                    $("#<%=txtYouXiang.ClientID %>").addClass("input_readonly").attr("readonly", "readonly");
                    $("#<%=txtBuMenName.ClientID %>").addClass("input_readonly").attr("readonly", "readonly");
                    $("#<%=txtZhiWu.ClientID %>").addClass("input_readonly").attr("readonly", "readonly");
                }
            }
        };

        $(document).ready(function() {
            $("#i_a_submit").click(function() { return iPage.submit(this); });
            $("#txtXingBie" + "<%=XingBie %>").attr("checked", "checked");
            iPage.initYeMianZhuangTai();            
        });
    </script>
</asp:Content>