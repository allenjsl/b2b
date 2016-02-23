<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EyouSoft.GysWeb.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>系统登录-<%=CompanyName %>-管理系统</title>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->
</head>
<body style="background: #DEEEFD">
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="background: url(/images/login05.jpg) repeat-x center top; margin: 0; padding: 0;">
        <tr style="background: url(/images/logintopbg.gif) no-repeat left top;">
            <td height="91" valign="bottom" class="login_logo">
                <img src="<%=LogoFilePath %>" alt="<%=CompanyName %>" />
            </td>
            <td valign="bottom">
                <table width="27%" border="0" align="right" cellpadding="0" cellspacing="0" class="datetimesbox">
                    <tr>
                        <td height="30">
                            <img src="images/dateicon.gif" alt="" style="margin-top: -3px" />
                            今天是：<span id="timeDiv"><%=DateTime.Now.ToString("yyyy年M月d日 dddd")   %></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <img src="/images/login02.jpg" width="998" height="137" alt="" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" valign="top" class="textbox" style="background: url(/images/login03.jpg) no-repeat center center; height: 186px;">
                <table width="400" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="132" height="35" align="right">
                            用户名：
                        </td>
                        <td width="9" align="center">
                            &nbsp;
                        </td>
                        <td width="165" align="left">
                            <input type="text" name="t_u" id="t_u" tabindex="1" />
                        </td>
                        <td width="94" rowspan="3" align="left" valign="middle">
                            <a href="javascript:void(0)" id="lnkLogin" tabindex="4">
                                <img src="/images/login04.jpg" width="68" height="69" alt="" style="cursor:pointer" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right">
                            密&nbsp;&nbsp;码：
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <input type="password" name="t_p" id="t_p" tabindex="2" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right">
                            验证码：
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <input type="text" name="t_vc" id="t_vc" style="width: 60px" tabindex="3" />
                            <img alt="点击更换验证码" title="点击更换验证码" style="cursor: pointer; margin-top: -4px;" onclick="this.src='/ashx/yanzhengma.ashx?ValidateCodeName=GYS_YIBAI_VC&id='+Math.random();return false;" align="middle" width="60" height="20" id="img1" src="/ashx/yanzhengma.ashx?ValidateCodeName=GYS_YIBAI_VC&t=<%=DateTime.Now.ToString("HHmmssffff") %>" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <span id="span_msg" style="color: red"></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 20px;">
        <tr>
            <td height="35" align="center">
                版权所有：<%=CompanyName1%>
                技术支持：杭州易诺科技
            </td>
        </tr>
    </table>
    </form>

    <script src="/js/jquery-1.4.4.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/utilsuri.js"></script>
    <script src="/js/slogin.js" type="text/javascript"></script>

    <script type="text/javascript">
    
        function getVC() {
            var c = document.cookie, ckcode = "", tenName = "";
            for (var i = 0; i < c.split(";").length; i++) {
                tenName = c.split(";")[i].split("=")[0];
                ckcode = c.split(";")[i].split("=")[1];
                if ($.trim(tenName) == "GYS_YIBAI_VC") {
                    break;
                } else {
                    ckcode = "";
                }
            }
            return $.trim(ckcode);
        };

        function setMsg(s) {
            $("#span_msg").html(s);
        }

        function login() {
            var u = $.trim($("#t_u").val()), p = $.trim($("#t_p").val()), vc = $.trim($("#t_vc").val());
            if (u == "") {
                setMsg("请输入用户名");
                $("#t_u").focus();
                return false;
            }
            if (p == "") {
                setMsg("请输入密码");
                $("#t_w").focus();
                return false;
            }
            if (vc == "" || vc != getVC()) {
                setMsg("请输入正确的验证码");
                return;
            }

            //显示登录状态
            setMsg("正在登录中....");
            //防止重复登陆
            $("#lnkLogin").unbind().css("cursor", "default");

            var _options = { yhm: u, mima: p, yzm: "", cookietian: 1 };
            _options["fn2"] = function(data) { alert(data.xiaoxi); $("#lnkLogin").click(function() { login(); return false; }); setMsg(""); }
            _options["fn1"] = function(data) { var _url = "/dijie/"; var _p = utilsUri.getUrlParams([]); if (typeof _p["rurl"] != "undefined" && _p["rurl"].length > 0) _url = _p["rurl"]; window.location.href = _url; }

            GYSYH.login(_options);
            return false;
        }

        $(document).ready(function() {
            $("#t_u").focus();
            $("#lnkLogin").click(function() { login(); return false; });
            $("#t_u,#t_p,#t_vc").keypress(function(e) { if (e.keyCode == 13) { login(); return false; } });

            $("#t_u").val("dijie01");
            $("#t_p").val("000000");
            $("#t_vc").val(getVC());
        });
    </script>

</body>
</html>
