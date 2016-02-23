<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuXiaoEdit.aspx.cs" Inherits="Web.PingTai.CuXiaoEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
     <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th  height="30" align="right" style="width: 10%">
                    促销标题：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtBiaoTi" type="text" class="inputtext" id="txtBiaoTi" runat="server"
                        valid="required" errmsg="请填写促销标题" maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    促销日期：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtShiJian1" type="text" class="inputtext" id="txtShiJian1" runat="server"
                        valid="required" errmsg="请填写促销日期" maxlength="100" style="width:100px;" onfocus="WdatePicker()" /> -
                    <input name="txtShiJian2" type="text" class="inputtext" id="txtShiJian2" runat="server"
                        valid="required" errmsg="请填写促销日期" maxlength="100" style="width:100px;" onfocus="WdatePicker()" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    排序值：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtPaiXuId" type="text" class="inputtext" id="txtPaiXuId" runat="server" value="0" maxlength="5" style="width:100px;" />
                    <span style="color:#666">(按值升序排列)</span>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    促销状态：
                </th>
                <td style="background:#E3F1FC">
                    <select id="txtStatus" name="txtStatus" class="inputselect">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus)), "") %>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    促销封面：
                </th>
                <td style="background:#E3F1FC">
                    <uc1:UploadControl ID="up_fengmian" runat="server" TiShiXinXi="建议上传图片尺寸：253*144px" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    促销图片：
                </th>
                <td style="background: #E3F1FC">
                    <uc1:UploadControl ID="up_fujian" runat="server" TiShiXinXi="建议上传图片尺寸：940*317px" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                   简要介绍：
                </th>
                <td style="background:#E3F1FC">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="2" style="text-align:left;">
                    <textarea id="txtJianYaoJieShao" style="width:99.3%; height:100px;" runat="server"></textarea>
                </th>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                   促销内容：
                </th>
                <td style="background:#E3F1FC">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="2" style="text-align:left;">
                    <textarea id="txtNeiRong" style="width:99.9%; height:300px;" runat="server"></textarea>
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
            UE.getEditor('<%=txtNeiRong.ClientID %>', { toolbars: EnowUeditor.toolbars1 });
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $("#txtStatus").val("<%=(int)CuXiaoStatus %>");
        });
    </script>
</asp:Content>
