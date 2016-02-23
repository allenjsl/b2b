<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhaoHuiMiMa.aspx.cs" Inherits="EyouSoft.PtWeb.ZhaoHuiMiMa"
    Title="找回密码" MasterPageFile="~/MP/QianTai.Master" %>

<asp:content contentplaceholderid="PageMain" runat="server" id="PageMain1">
    <style type="text/css">
    .placeholder1 {color: #c6c6c6;left: 0;position: absolute;text-align:left;top: 0;visibility: visible;width: 100%;text-indent: 70px;height: 21px; line-height: 21px; margin: 5px; text-align:left;-text-indent: 0px;} 
    </style>
    
    <input type="hidden" id="txtYanZhengMaId" />
    
    <h3 class="h3_title mt10">找回密码</h3>
    
    <div class="reg_box" id="i_div_step_1">
        <div class="find_box">
            <ul>
                <li style="position: relative;"><span class="name">登录名：</span><input type="text"
                    class="input_bk formsize225" id="txtYongHuMing" data-placeholderid="txtYongHuMing_placeholder">
                    <label id="txtYongHuMing_placeholder" class="placeholder1" for="txtYongHuMing">
                        用户名/邮箱</label>
                </li>
                <%--<li><span class="name">验证码：</span><input type="text" value="" class="input_bk formsize60"><img
                    src="/images/code.gif"><a href="#">换一张</a></li>--%>
                <li class="reg_btn"><input type="button" value="提交" id="i_btn_step_1"></li>
            </ul>
        </div>
    </div>
    
    <div class="reg_box" id="i_div_step_2" style="display: none;">
        <div class="find_box">
            <div class="msg">
                我们已将重置密码验证码发至您的注册邮箱：<em id="i_em_youxiang">******527@qq.com</em> ，请在下方输入您收到的验证码</div>
            <div class="msg">
                <input type="text" class="input_bk formsize180" value="" id="txtYanZhengMa">
                <input type="button" class="tijiao" id="i_btn_step_2"  value="提交"></div>
        </div>
    </div>
    
    <div class="reg_box" id="i_div_step_3" style="display: none;">
        <div class="find_box">
            <ul>
                <li style="position: relative;"><span class="name">新密码：</span><input type="password" class="input_bk formsize225"
                    id="txtMiMa1" data-placeholderid="txtMiMa1_placeholder">
                <label id="txtMiMa1_placeholder" class="placeholder1" for="txtMiMa1">
                        请输入您的新密码</label>
                </li>
                <li style="position: relative;"><span class="name">重复密码：</span><input type="password"
                    class="input_bk formsize225" id="txtMiMa2" data-placeholderid="txtMiMa2_placeholder">
                    <label id="txtMiMa2_placeholder" class="placeholder1" for="txtMiMa2">
                        请重复输入您的新密码</label>
                </li>
                <li class="reg_btn"><input type="button" value="提交" id="i_btn_step_3"></li>
            </ul>
        </div>
    </div>
    
    <div class="reg_box" id="i_div_step_4" style="display: none;">
        <div class="find_box">
            <div class="ok_box">
                <img src="/images/ok.gif"><em>重置成功！</em>请用新密码重新登录！</div>
        </div>
    </div>

    <script type="text/javascript">
        var iPage = {
            step1: function(obj) {
                var _self = this;
                var _data = { txtYongHuMing: $.trim($("#txtYongHuMing").val()) };
                if (_data.txtYongHuMing.length < 1) { alert("请输入你要找回密码的账号或邮箱"); return false; }
                $(obj).unbind("click").val("正在处理");

                function _callback(response) {
                    if (response.RetCode != 1) {
                        alert(response.XiaoXi);
                        $(obj).val("提交").click(function() { _self.step1(this); });
                        return;
                    }

                    $("#txtYanZhengMaId").val(response.YanZhengMaId);
                    $("#i_em_youxiang").html(response.YouXiang);

                    $("#i_div_step_1").hide();
                    $("#i_div_step_2").show();
                }

                $.ajax({ type: "post", url: "zhaohuimima.aspx?dotype=step1", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        _callback(response);
                    }
                });

            },
            step2: function(obj) {
                var _self = this;
                var _data = { txtYanZhengMaId: $.trim($("#txtYanZhengMaId").val()), txtYanZhengMa: $.trim($("#txtYanZhengMa").val()) };
                if (_data.txtYanZhengMa.length < 1) { alert("请输入您收到的验证码"); return false; }
                $(obj).unbind("click").val("正在处理");

                function _callback(response) {
                    if (response.RetCode != 1) {
                        alert(response.XiaoXi);
                        $(obj).val("提交").click(function() { _self.step2(this); });
                        return;
                    }

                    $("#i_div_step_2").hide();
                    $("#i_div_step_3").show();
                }

                $.ajax({ type: "post", url: "zhaohuimima.aspx?dotype=step2", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        _callback(response);
                    }
                });
            },
            step3: function(obj) {
                var _self = this;
                var _data = { txtYanZhengMaId: $.trim($("#txtYanZhengMaId").val()), txtYanZhengMa: $.trim($("#txtYanZhengMa").val()), txtMiMa1: $.trim($("#txtMiMa1").val()), txtMiMa2: $.trim($("#txtMiMa2").val()) };

                if (_data.txtMiMa1.length < 1) { alert("请输入你的新密码"); return false; }
                if (_data.txtMiMa2 != _data.txtMiMa1) { alert("两次输入的密码不一致，请重新输入"); return false; }

                $(obj).unbind("click").val("正在处理");

                function _callback(response) {
                    if (response.RetCode != 1) {
                        alert(response.XiaoXi);
                        $(obj).val("提交").click(function() { _self.step3(this); });
                        return;
                    }

                    $("#i_div_step_3").hide();
                    $("#i_div_step_4").show();
                }

                $.ajax({ type: "post", url: "zhaohuimima.aspx?dotype=step3", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        _callback(response);
                    }
                });

            }
        };

        $(document).ready(function() {
            $("#i_btn_step_1").click(function() { iPage.step1(this); });
            $("#i_btn_step_2").click(function() { iPage.step2(this); });
            $("#i_btn_step_3").click(function() { iPage.step3(this); });
            $("#txtYongHuMing").val("");
            $("#txtYongHuMing,#txtMiMa1,#txtMiMa2").keyup(function() { if ($.trim(this.value).length == 0) { $("#" + $(this).attr("data-placeholderid")).css({ "visibility": "visible" }); } else { $("#" + $(this).attr("data-placeholderid")).css({ "visibility": "hidden" }); } });
            $("#txtYongHuMing,#txtMiMa1,#txtMiMa2").blur(function() { if ($.trim(this.value).length == 0) { $("#" + $(this).attr("data-placeholderid")).css({ "visibility": "visible" }); } else { $("#" + $(this).attr("data-placeholderid")).css({ "visibility": "hidden" }); } });
        });
    </script>
</asp:content>