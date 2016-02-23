<%--<%@ Page Title="系统配置" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="ConfigInfo.aspx.cs" Inherits="Web.SystemSet.ConfigInfo" %>

<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">系统设置</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            所在位置&gt;&gt; <a href="#">系统设置</a>&gt;&gt;系统配置
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="height: 30px;" class="lineCategorybox">
        </div>
        <div class="tablelist">
            <table width="780" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4" align="center">
                <tbody>
                    <tr>
                        <th bgcolor="#BDDCF4" align="center" colspan="3">
                            系统配置信息
                        </th>
                    </tr>
                    <%--<tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>最长留位时间：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <input id="txthour" type="text" size="10" name="txthour" class="inputtext" runat="server"
                                onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                            <font color="#FF0000">小时(只能填写正整数)</font>
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>公司LOGO：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="uclogo" runat="server" IsUploadSelf="true" IsUploadMore="false" />
                            <asp:Label runat="server" ID="lbfilelogo" class="labelFiles"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>打印页眉：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="ucheaderImg" runat="server" IsUploadSelf="true" IsUploadMore="false" />
                            <asp:Label runat="server" ID="lbfileheadimg" class="labelFiles"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>打印页脚：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="ucfooterImg" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                            <asp:Label runat="server" ID="lbfilefooterimg" class="labelFiles"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>打印模板：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="ucprintImg" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                            <asp:Label runat="server" ID="lbfileprintimg" class="labelFiles"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>公章：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="ucchapterImg" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                            <asp:Label runat="server" ID="lbfilechapterimg" class="labelFiles"></asp:Label>
                            <font color="#FF0000">请上传透明背景图片</font>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="center" colspan="3">
                            <table cellspacing="0" cellpadding="0" border="0" align="center">
                                <tbody>
                                    <tr>
                                        <td width="137" height="20" align="center" class="tjbtn02">
                                            <a id="btnSave" href="javascript:;">保存</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    </form>

    <script type="text/javascript">
    var PrintConfig={
     UnBindBtn:function(){
       $("#btnSave").text("提交中...");
       $("#btnSave").unbind("click");
     },
     //按钮绑定事件
      BindBtn: function() {
        $("#btnSave").bind("click");
        $("#btnSave").text("保存");
         $("#btnSave").click(function() {
            PrintConfig.Save();
            return false;
         });
      },
      //删除签证附件
            RemoveFile: function(obj) {
                $(obj).parent().remove();
            },
      //提交表单
            Save: function() {
                PrintConfig.UnBindBtn();
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/SystemSet/ConfigInfo.aspx?dotype=save",
                    data: $("#btnSave").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg,function(){ window.location.href='/SystemSet/ConfigInfo.aspx';});
                        } else {
                            tableToolbar._showMsg(ret.msg);
                        }
                        PrintConfig.BindBtn();
                    },
                    error: function() {
                        tableToolbar._showMsg("操作失败，请稍后再试!");
                        PrintConfig.BindBtn();
                    }
                });
           }
         };
        $(function() {
           PrintConfig.BindBtn();
        })
    </script>

</asp:Content>
--%>