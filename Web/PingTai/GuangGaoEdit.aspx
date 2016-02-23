<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuangGaoEdit.aspx.cs" Inherits="Web.PingTai.GuangGaoEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
     <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th height="30" align="right" style="width: 10%">
                    广告标题：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtBiaoTi" type="text" class="inputtext" id="txtBiaoTi" runat="server"
                        valid="required" errmsg="请填写广告标题" maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    广告位置：
                </th>
                <td style="background:#E3F1FC">
                    <select name="txtWeiZhi" id="txtWeiZhi" class="inputselect" valid="required" errmsg="请选择广告位置">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi)), "") %>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    广告状态：
                </th>
                <td style="background:#E3F1FC">
                    <select name="txtStatus" id="txtStatus" class="inputselect">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus)), "") %>
                    </select>
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
                    广告链接：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtUrl" type="text" class="inputtext" id="txtUrl" runat="server"
                        maxlength="255" style="width:280px;" />
                    <span style="color:#666">(格式：http://www.jmglv.com，不填写链接的广告将直接展示广告内容信息)</span>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    广告封面：
                </th>
                <td style="background:#E3F1FC">
                    <uc1:UploadControl ID="up_fengmian" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    封面说明：
                </th>
                <td style="background:#E3F1FC; color:#666">
                    1.建议导航滚动横幅封面图片尺寸：1440*298px;<a href="/images/pt.hengfushili.jpg" target="_blank">查看横幅图片实例</a><br />
                    2.建议酒店左侧广告封面图片尺寸：261*196px;<br />
                    3.建议注册右侧广告封面图片尺寸：248*157px;<br />
                    4.建议商家大全左侧广告封面图片尺寸：212*186px;
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    广告图片：
                </th>
                <td style="background: #E3F1FC">
                    <uc1:UploadControl ID="up_fujian" runat="server" TiShiXinXi="建议上传图片尺寸：940*317px" />
                </td>
            </tr>            
            <tr class="odd">
                <th height="30" align="right">
                   广告内容：
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
            $("#txtWeiZhi").val("<%=WeiZhi %>");
            $("#txtStatus").val("<%=Status %>");
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
        });
    </script>
</asp:Content>
