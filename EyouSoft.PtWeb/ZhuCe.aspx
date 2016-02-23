<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuCe.aspx.cs" Inherits="EyouSoft.PtWeb.ZhuCe" MasterPageFile="~/MP/QianTai.Master" Title="注册"%>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
<h3 class="h3_title mt10">用户注册</h3>
    
    <div class="reg_box fixed">
    
      <div class="reg_L">
          
          <h4 class="h4_title">请您认真填写以下资料信息，我们将审核后为您开通账号。</h4>
          <form id="form1" method="get">
          <div class="reg_form">
             <ul class="botline">
                 <li><span class="name">公司名称：</span><input type="text" id="ComapnyName" name="ComapnyName"  class="input_bk formsize225"  valid="required|isName" errmsg="请填写公司名称！|公司名称格式错误！"/> <span class="fontred" >*</span><span id="errMsg_ComapnyName" class="errmsg"></span></li>
                 <li><span class="name">所在城市：</span> <select name="txtShengFen" id="txtShengFen" style=" width:112px;">
                 </select>  &nbsp;&nbsp;<select id="txtChengShi" name="txtChengShi" style=" width:112px;" valid="required" errmsg="请选择所在城市！">
                 </select> <span class="fontred" >*</span><span id="errMsg_txtChengShi" class="errmsg"></span></li>
                 <li><span class="name">详细地址：</span><input type="text" id="CompanyAdress" name="CompanyAdress" class="input_bk formsize225"  valid="required" errmsg="请填写公司详细地址！"/> <span class="fontred" >*</span><span id="errMsg_CompanyAdress" class="errmsg"></span></li>
                 <li><span class="name">公司电话：</span><input type="text" id="CompanyTel" name="CompanyTel" class="input_bk formsize225"  valid="required" errmsg="请填写公司电话！"/> <span class="fontred" >*</span><span id="errMsg_CompanyTel" class="errmsg"></span></li>
                 <li><span class="name">公司传真：</span><input type="text" id="CompanyFax" name="CompanyFax"  class="input_bk formsize225"  valid="required" errmsg="请填写公司传真！"/> <span class="fontred" >*</span><span id="errMsg_CompanyFax" class="errmsg"></span></li>
             </ul>
             
             <ul>
                 <li><span class="name">用户名：</span><input type="text" id="HuiYuanName" name="HuiYuanName" class="input_bk formsize225" valid="required|isMemberName" errmsg="请填写用户名！|用户名格式错误，用户名必须是数字或英文！"/> <span class="fontred" >*</span><span id="errMsg_HuiYuanName" class="errmsg"></span></li>
                 <li><span class="name">联系邮箱：</span><input type="text" id="HuiYuanEmail" name="HuiYuanEmail" class="input_bk formsize225" valid="required|isEmail" errmsg="请填写联系邮箱！|联系邮箱格式错误！"/> <span class="fontred" >*</span><span id="errMsg_HuiYuanEmail" class="errmsg"></span></li>
                 <li><span class="name">真实姓名：</span><input type="text" id="MemberName" name="MemberName" class="input_bk formsize225" valid="required|isName" errmsg="请填写真实姓名！|真实姓名格式错误，只能是中文或英文！"/> <span class="fontred" >*</span><span id="errMsg_MemberName" class="errmsg"></span></li>
                 <li><span class="name">联系电话：</span><input type="text" id="HuiYuanTel" name="HuiYuanTel" class="input_bk formsize225" valid="required|isPhone" errmsg="请填写联系电话！|联系电话格式错误！"/> <span class="fontred" >*</span><span id="errMsg_HuiYuanTel" class="errmsg"></span></li>
                 <li><span class="name">联系手机：</span><input type="text" id="HuiYuanMobile" name="HuiYuanMobile" class="input_bk formsize225" valid="required|isMobile" errmsg="请填写联系手机！|联系手机格式错误！"/> <span class="fontred" >*</span><span id="errMsg_HuiYuanMobile" class="errmsg"></span></li>
                 <li><span class="name">登录密码：</span><input type="password" id="HuiYuanPassword" name="HuiYuanPassword" class="input_bk formsize225" valid="required" errmsg="请填写登录密码！"/> <span class="fontred" >*</span><span id="errMsg_HuiYuanPassword" class="errmsg"></span></li>
                 <li><span class="name">确认密码：</span><input type="password" id="HuiYuanTwoPass" name="HuiYuanTwoPass" class="input_bk formsize225" /> <span class="fontred" >*</span><span id="errMsg_HuiYuanTwoPass" class="errmsg"></span></li>
             </ul>
             
             <div class="reg_fxk pb10"><input id="TianKuan" name="TianKuan" checked="checked" type="checkbox" value="" valid="checked" errmsg="请勾选接受注册条款！"/>我已仔细阅读并同意接受 <a href="tiaokuan.html" id="link01">
                 用户注册协议</a><span id="errMsg_TianKuan" class="errmsg"></span></div>

             <div class="reg_btn pb10"><input type="button" id="ZhuCebnt" value="同意协议并注册" /></div>
             
          </div>
          </form>
      </div>
      
      <div class="reg_R">
          <p>如果您已是会员，请在上方直接登录。<br />如果有问题请联系网站客服 <span class="fontgreen"><%=KeFuDianHua%></span></p>
           
          <div class="tj_line">
             <h3>热门线路推荐</h3>
             <ul>
                 <asp:Repeater ID="RepReMen" runat="server">
                 <ItemTemplate>
                 <li><a href="<%#Eval("XXUrl") %>"><img src="<%#ErpUrl+Eval("Filepath")%>" /><p><%# EyouSoft.Common.Utils.GetText2(Eval("MingCheng").ToString(), 33, true)%></p></a></li>
                 </ItemTemplate>
                 </asp:Repeater>
             </ul>
          </div>
       
      </div>
      
    </div>
    <script type="text/javascript">
        var pageData = {
            CheckForm: function() {
                var _v = ValiDatorForm.validator($("#form1").get(0), "span");

                if (_v) {
                    var onepass = $("#HuiYuanPassword").val();
                    var twopass = $("#HuiYuanTwoPass").val();
                    if (onepass != twopass) {
                        $("#errMsg_HuiYuanTwoPass").html('两次输入的密码不匹配!');
                        $("#errMsg_HuiYuanTwoPass").css('display', 'inline-block');
                        return false;
                    }
                    return true;
                }

                var mudicount = $(".errmsg").length;
                for (var zongnum = mudicount; zongnum > 0; zongnum--) {
                    if ($(".errmsg").eq(zongnum - 1).html() != "") {
                        $(".errmsg").eq(zongnum - 1).css('display', 'inline-block');
                    }
                }
                return false;
            },
            pageSave: function(obj) {
                if (!this.CheckForm()) return false;
                var _self = this;
                $(obj).unbind("click").attr("value", "正在注册");

                $.ajax({
                    type: "post",
                    url: "/ZhuCe.aspx?save=save",
                    dataType: "json",
                    data: $("#form1").serialize(),
                    success: function(ret) {
                        alert(ret.msg);
                        if (ret.result == "1") window.location.href = "/default.aspx";
                        $(obj).click(function() { return _self.pageSave(this); }).attr("value", "同意协议并注册");
                    },
                    error: function() {
                        alert("注册失败，请重试");
                        $(obj).click(function() { return _self.pageSave(this); }).attr("value", "同意协议并注册");
                    }
                });
            }
        }
        
        $(function() {
            gscx.init({ sid: "#txtShengFen", cid: "#txtChengShi", sv: "0", cv: "0", t: "0" });
            $("#ZhuCebnt").click(function() { pageData.pageSave(this); });

            $("#link01").click(function() {
                var url = "tiaokuan_boxy.html";
                parent.Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "用户注册协议",
                    modal: true,
                    width: "840px",
                    height: "550px"
                });
                return false;
            });
        })
    </script>
</asp:Content>