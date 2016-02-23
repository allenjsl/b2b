<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingDianEdit.aspx.cs" Inherits="Web.PingTai.JingDianEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
     <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th height="30" align="right" style="width: 10%">
                    <span class="fred">*</span>景点名称：
                </th>
                <td style="background:#E3F1FC;width:50%;" >
                    <input name="txtMingCheng" type="text" class="inputtext" id="txtMingCheng" runat="server"
                        valid="required" errmsg="请填写景点名称" maxlength="100" style="width:280px;" />
                </td>
                <th align="right" style="width: 10%">
                    <span class="fred">*</span>区域：
                </th>
                <td style="background:#E3F1FC">
                    <select id="txtJingDianQuYu" class="inputselect" name="txtJingDianQuYu" valid="required" errmsg="请选择区域">
                        <option value="">--请选择--</option>
                        <%=GetJingDianQuYu() %>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>景点地址：
                </th>
                <td style="background:#E3F1FC;" colspan="3">
                    <input name="txtDiZhi" type="text" class="inputtext" id="txtDiZhi" runat="server"
                        valid="required" errmsg="请填写景点地址" maxlength="100" style="width: 280px;" />
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phJingDianYongHu" Visible="false">
                <tr class="odd">
                    <th height="30" align="right">
                        景点账号：
                    </th>
                    <td style="background: #E3F1FC" colspan="3">
                        <select name="txtJingDianYongHu" id="txtJingDianYongHu">
                            <option value="0">-请选择-</option>
                            <asp:Literal runat="server" ID="ltrJingDianYongHu"></asp:Literal>
                        </select>
                        <span style="color: #666">选中的账号可登录系统维护该景点信息</span>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr class="odd">
                <th height="30" align="right">
                    景点封面：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <uc1:UploadControl ID="up_fengmian" runat="server" TiShiXinXi="建议上传图片尺寸：243*168px" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    景点图片：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <uc1:UploadControl ID="up_fujian" runat="server" TiShiXinXi="建议上传图片尺寸：685*319px" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    排序值：
                </th>
                <td style="background: #E3F1FC" colspan="3">
                    <input name="txtPaiXuId" type="text" class="inputtext" id="txtPaiXuId" runat="server"
                        value="0" maxlength="5" style="width: 100px;" />
                    <span style="color: #666">(按值升序排列)</span>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                   景点介绍：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtJieShao" style="width:99.9%; height:300px;" runat="server"></textarea>
                </th>
            </tr>            
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02" >
                                <asp:Literal runat="server" ID="ltrOperatorHtml" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.all.js"></script>
    
    <script type="text/javascript">
        var iPage = {
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            save: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!validatorResult) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=baocun", data: $("#<%=form1.ClientID %>").serialize(),
                    cache: false, dataType: "json", async: false,
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
            }
        };

        $(document).ready(function() {
            UE.getEditor('<%=txtJieShao.ClientID %>', { toolbars: EnowUeditor.toolbars1 });

            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $("#txtJingDianQuYu").val("<%=JingDianQuYuId %>");
            $("#txtJingDianYongHu").val("<%=JingDianYongHuId %>");
        });
    </script>
</asp:Content>
