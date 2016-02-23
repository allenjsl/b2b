<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiXunEdit.aspx.cs" Inherits="Web.PingTai.ZiXunEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
     <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th height="30" align="right" style="width: 10%">
                    资讯标题：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtBiaoTi" type="text" class="inputtext" id="txtBiaoTi" runat="server"
                        valid="required" errmsg="请填写资讯标题" maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    资讯类型：
                </th>
                <td style="background:#E3F1FC">
                    <select name="txtLeiXing" id="txtLeiXing" class="inputselect" valid="required" errmsg="请选择资讯类型">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing)), "") %>
                    </select>
                </td>
            </tr>
            <tr class="odd" style="display:none;" id="i_tr_zhandian">
                <th height="30" align="right">
                    资讯站点：
                </th>
                <td style="background:#E3F1FC">
                    <select name="txtZhanDian" id="txtZhanDian" class="inputselect">
                        <option value="">--请选择--</option>
                        <asp:Literal runat="server" ID="ltrZhanDianOption"></asp:Literal>
                    </select>
                    <span style="color:#666">说明：不选择站点将会在所在站点下显示。</span>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    资讯状态：
                </th>
                <td style="background: #E3F1FC">
                    <select id="txtStatus" name="txtStatus" class="inputselect">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.ZiXunStatus)), "") %>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    资讯封面：
                </th>
                <td style="background: #E3F1FC">
                    <uc1:uploadcontrol id="up_fengmian" runat="server" TiShiXinXi="建议上传图片尺寸：253*144px" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    资讯图片：
                </th>
                <td style="background: #E3F1FC">
                    <uc1:UploadControl ID="up_fujian" runat="server" TiShiXinXi="建议上传图片尺寸：685*319px" />
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
                    <textarea id="txtJianYaoJieShao" style="width: 99.3%; height: 100px;" runat="server"></textarea>
                </th>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    资讯内容：
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
            },
            changeLeiXing: function() {
                var _leiXing = $("#txtLeiXing").val();

                if (_leiXing == "<%=(int)EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing.平台站点公告 %>") {
                    $("#i_tr_zhandian").show();
                    return;
                }

                $("#i_tr_zhandian").hide();
                return;
            }
        };

        $(document).ready(function() {
            UE.getEditor('<%=txtNeiRong.ClientID %>', { toolbars: EnowUeditor.toolbars1 });

            $("#txtLeiXing").val("<%=LeiXing %>");
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $("#txtStatus").val("<%=(int)ZiXunStatus %>");
            $("#txtZhanDian").val("<%=ZhanDianId %>");

            $("#txtLeiXing").change(function() { iPage.changeLeiXing(); });
            iPage.changeLeiXing();
        });
    </script>
</asp:Content>
