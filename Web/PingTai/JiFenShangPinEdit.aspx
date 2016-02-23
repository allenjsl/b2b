<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenShangPinEdit.aspx.cs" Inherits="Web.PingTai.JiFenShangPinEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
     <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>商品名称：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtMingCheng" type="text" class="inputtext" id="txtMingCheng" runat="server"
                        valid="required" errmsg="请填写酒店名称" maxlength="100" style="width:280px;" />
                </td>
                <th width="80" align="right">
                    <span class="fred">*</span>市场价格：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtJiaGe" type="text" class="inputtext" id="txtJiaGe" runat="server"
                        valid="required" errmsg="请填写市场价格" maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>商品类型：
                </th>
                <td style="background:#E3F1FC">
                    <select id="txtLeiXing" class="inputselect" name="txtLeiXing" valid="required" errmsg="请选择商品类型">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing)), "") %>
                    </select>
                </td>
                <th width="80" align="right">
                    <span class="fred">*</span>商品状态
                </th>
                <td style="background:#E3F1FC">
                    <select id="txtStatus" class="inputselect" name="txtStatus" valid="required" errmsg="请选择商品状态">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus)), "") %>
                    </select>        
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>兑换积分：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtJiFen" type="text" class="inputtext" id="txtJiFen" runat="server"
                        valid="required" errmsg="请填写兑换积分" maxlength="100" style="width:280px;" />
                </td>
                <th width="80" align="right">
                    
                </th>
                <td style="background:#E3F1FC">
                    
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    商品封面：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <uc1:UploadControl ID="up_fengmian" runat="server" TiShiXinXi="建议上传图片尺寸：241*169px" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    商品图片：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <uc1:UploadControl ID="up_fujian" runat="server" TiShiXinXi="建议上传图片尺寸：429*255px"/>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                   商品介绍：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtJieShao" style="width:99.9%; height:150px;" runat="server"></textarea>
                </th>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                   兑换须知：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtDuiHuanXuZhi" style="width:99.9%; height:150px;" runat="server"></textarea>
                </th>
            </tr>      
            <tr class="odd">
                <th height="30" align="right">
                   配送说明：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtPeiSongShuoMing" style="width:99.9%; height:150px;" runat="server"></textarea>
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
            UE.getEditor('<%=txtPeiSongShuoMing.ClientID %>', { toolbars: EnowUeditor.toolbars1 });
            UE.getEditor('<%=txtDuiHuanXuZhi.ClientID %>', { toolbars: EnowUeditor.toolbars1 });

            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $("#txtLeiXing").val("<%=SPLeiXing %>");
            $("#txtStatus").val("<%=SPStatus %>");
        });
    </script>
</asp:Content>
