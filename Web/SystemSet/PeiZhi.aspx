<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeiZhi.aspx.cs" Inherits="Web.SystemSet.PeiZhi" MasterPageFile="~/MasterPage/Front.Master" Title="系统配置"%>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>

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
                            所在位置&gt;&gt; <a href="javascript:void(0)">系统设置</a>&gt;&gt;系统配置
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
                        <th bgcolor="#BDDCF4" align="center" colspan="3" style="height:30px;">
                            系统配置信息
                        </th>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>系统LOGO：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="up_logo" runat="server" IsUploadSelf="true" IsUploadMore="false" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>打印页眉：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="up_yemei" runat="server" IsUploadSelf="true" IsUploadMore="false" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>打印页脚：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="up_yejiao" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>打印模板：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="up_moban" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                        </td>
                    </tr>
                    <tr>
                        <td width="16%" height="35" bgcolor="#e3f1fc" align="right">
                            <strong>公章：</strong>
                        </td>
                        <td width="84%" height="35" bgcolor="#FAFDFF" align="left" class="pandl3" colspan="2">
                            <uc1:UploadControl ID="up_tuzhang" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                            <font color="#FF0000">请上传透明背景图片</font>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="center" colspan="3">
                            <table cellspacing="0" cellpadding="0" border="0" align="center">
                                <tbody>
                                    <tr>
                                        <td width="137" height="20" align="center" class="tjbtn02">
                                            <asp:Literal runat="server" ID="ltrCaoZuo"></asp:Literal>                                            
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
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            baoCun: function(obj) {
                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "?doType=baocun", data: $("#<%=form1.ClientID %>").serialize(), cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_baocun").click(function() { iPage.baoCun(this); });
        });
    </script>

</asp:Content>