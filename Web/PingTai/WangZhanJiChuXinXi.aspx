<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WangZhanJiChuXinXi.aspx.cs" Inherits="Web.PingTai.WangZhanJiChuXinXi" MasterPageFile="~/MasterPage/Front.Master" Title="平台基础信息-同行端口" ValidateRequest="false"%>
<%@ Register Src="~/UserControl/PingTaiJiChuXinXiDaoHang.ascx" TagName="PingTaiJiChuXinXiDaoHang" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="mainbody">
            <div class="lineprotitlebox">
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td width="15%" nowrap="nowrap">
                                <span class="lineprotitle">同行端口</span>
                            </td>
                            <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                              所在位置&gt;&gt; <a href="javascript:void(0)">同行端口</a>&gt;&gt; 平台基础信息
                            </td>
                        </tr>
                        <tr>
                            <td height="2" bgcolor="#000000" colspan="2">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            
            <uc1:PingTaiJiChuXinXiDaoHang runat="server" ID="PingTaiJiChuXinXiDaoHang1" />
            
            <form runat="server" id="form1">
            <div class="tablelist">
                <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4" align="center">
                        <tr>
                            <th colspan="2" align="center" bgcolor="#BDDCF4" height="35">
                                平台基础信息
                            </th>
                        </tr>
                        <tr>
                            <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                                <strong>平台标题：</strong>
                            </td>
                            <td align="left" bgcolor="#FAFDFF">
                                <input type="text" runat ="server" id="txt1" class="inputtext" style="width:700px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                                <strong>平台关键字(keywords)：</strong>
                            </td>
                            <td align="left" bgcolor="#FAFDFF">
                                <input type="text" runat ="server" id="txt2" class="inputtext" style="width:700px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                                <strong>平台描述(description)：</strong>
                            </td>
                            <td align="left" bgcolor="#FAFDFF">
                                <input type="text" runat ="server" id="txt3" class="inputtext" style="width:700px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                                <strong>客服电话：</strong>
                            </td>
                            <td align="left" bgcolor="#FAFDFF">
                                <input type="text" runat ="server" id="txt4" class="inputtext" style="width:700px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                                <strong>平台版权：</strong>
                            </td>
                            <td align="left" bgcolor="#FAFDFF">
                                <textarea id="txt5" style="width:705px; height:150px;" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="center" colspan="2">
                                <table cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td height="40" align="center" class="tjbtn02" style="text-align:center;">                                                
                                            <asp:Literal runat="server" ID="ltrOperatorHtml"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                </table>
            </div>
            </form>
        </div>
    </div>
    
    <div class="clearboth">
    </div>

    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.all.js"></script>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            baoCun: function(obj) {
                $(obj).unbind("click").css({ "color": "#999999" });

                $.ajax({ type: "post", cache: false, url: "WangZhanJiChuXinXi.aspx?dotype=baocun", data: $("#<%=form1.ClientID %>").serialize(), dataType: "json",
                    success: function(response) {
                        alert(response.msg);
                        iPage.reload();
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            setPingTaiJiChuXinXiDaoHang(1);
            UE.getEditor('<%=txt5.ClientID %>', { toolbars: EnowUeditor.toolbars1 });
            $("#i_a_baocun").click(function() { iPage.baoCun(this); });
        });
   
    </script>

</asp:Content>